Imports System.Web.UI.WebControls
Imports log4net
Imports log4net.Config
Imports Toastr

Partial Class BankingOperations_TransfersDeposit
    Inherits SessionCheck
    Private retmsg As String = ""
    Private retval As Integer
    Private dr As String = ""
    Private cr As String = ""
    Private Bsubmit As Boolean
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(BankingOperations_TransfersDeposit))

#Region "Task"
    Protected Sub txtPayAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPayAmount.TextChanged
        Try
            txtPayAmount.Text = smartobj.FormatMoney(txtPayAmount.Text)
            txtTransAmount.Text = CInt(txtRate.Text.Trim) * CDec(txtPayAmount.Text.Trim)
            txtTransAmount.Text = smartobj.FormatMoney(txtTransAmount.Text)
            Me.txttellerno.Focus()
            If Session("pointingRes") = "T" Then
                Me.txtPayAmount0.Text = Session("pointbal")
                If CDec(Me.txtPayAmount0.Text.Trim) <> 0 Then
                    If CDec(Me.txtPayAmount.Text.Trim) > CDec(Me.txtPayAmount0.Text.Trim) Then
                        smartobj.alertwindow(Me.Page, "Amount Greater than Pointing Account Balance", "Halt")
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            '' smartobj.alertwindow(Me.Page, "Invalid Amount Specified", "Halt")

            smartobj.ShowToast(Me.Page, ToastType.Error, "Invalid Amount Specified", "Error!", ToastPosition.TopRight, True)

        End Try
    End Sub
    Sub till()
        Dim strTill As String = "Exec [proc_tellerBalance] '" & Session("Userid").ToString.Trim & "', " & Session("node_ID") & ""
        Me.GridView1.DataSource = con.SqlDs(strTill).Tables(0)
        Me.GridView1.DataBind()
    End Sub
    'Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
    '    Response.Redirect("Default.aspx")
    'End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try

            '' Me.btnSubmit.Enabled = False

            If Me.DropMode.SelectedIndex = 0 Then
                ''  smartobj.alertwindow(Me.Page, "Enter Account Number", "Prime")
                smartobj.ShowToast(Me.Page, ToastType.Warning, "Please Select Mode of Payment", "Oops!", ToastPosition.TopRight, True)

                DropMode.Focus()
                Exit Sub
            End If
            'Dim selex As String = "Select accountno from tbl_postlog where node_id=" & Session("node_ID") & " and ltrim(rtrim(accountno))='" & Me.txtAcNumber.Text.Trim & "'"
            'If con.SqlDs(selex).Tables(0).Rows.Count > 0 Then
            '    Exit Sub
            'Else

            Dim inst As String = "Insert into tbl_postlog Values ('" & Me.txtAcNumber.Text.Trim & "', " & Session("node_ID") & ")"
            con.SqlDs(inst)

            ''   End If

            'Dim selex1 As String = "Select accountno from tbl_postlog where node_id=" & Session("node_ID") & " and ltrim(rtrim(accountno))='" & Me.txtAccountNo2.Text.Trim & "'"
            'If con.SqlDs(selex1).Tables(0).Rows.Count > 0 Then
            '    Exit Sub
            'Else

            Dim inst2 As String = "Insert into tbl_postlog Values ('" & Me.txtAccountNo2.Text.Trim & "', " & Session("node_ID") & ")"
            con.SqlDs(inst2)

            ' End If

            If Me.txtAcNumber.Text = "" Then
                ''  smartobj.alertwindow(Me.Page, "Enter Account Number", "Prime")
                smartobj.ShowToast(Me.Page, ToastType.Warning, "Please Enter Account Number", "Oops!", ToastPosition.TopRight, True)

                txtAcNumber.Focus()
                Exit Sub
            End If


            ''Check debit account
            Dim selacct As String = "select accountnumber from tbl_casaaccount where node_id=" & Session("node_ID") & " and accountnumber='" & Me.txtAcNumber.Text.Trim & "' and status=1"
            If con.SqlDs(selacct).Tables(0).Rows.Count > 0 Then

            Else

                Dim selacct2 As String = "select glnumber from tbl_bankgl where node_id=" & Session("node_ID") & " and glnumber='" & Me.txtAcNumber.Text.Trim & "'"
                If con.SqlDs(selacct2).Tables(0).Rows.Count > 0 Then

                Else
                    '' smartobj.alertwindow(Me.Page, "Account Number Does not Exist", "Prime")

                    smartobj.ShowToast(Me.Page, ToastType.Warning, "Account Number Does not Exist", "Oops!", ToastPosition.TopRight, True)


                    txtAcNumber.Focus()
                    Exit Sub
                End If


            End If

            ''Check credit account
            selacct = "select accountnumber from tbl_casaaccount where node_id=" & Session("node_ID") & " and accountnumber='" & Me.txtAccountNo2.Text.Trim & "' and status=1"
            If con.SqlDs(selacct).Tables(0).Rows.Count > 0 Then

            Else

                Dim selacct2 As String = "select glnumber from tbl_bankgl where node_id=" & Session("node_ID") & " and glnumber='" & Me.txtAccountNo2.Text.Trim & "'"
                If con.SqlDs(selacct2).Tables(0).Rows.Count > 0 Then

                Else
                    ''  smartobj.alertwindow(Me.Page, "Account Number Does not Exist", "Prime")
                    smartobj.ShowToast(Me.Page, ToastType.Warning, "Account Number Does not Exist", "Oops!", ToastPosition.TopRight, True)


                    txtAccountNo2.Focus()
                    Exit Sub
                End If


            End If

            If Not IsNumeric(Me.txttellerno.Text) Then
                ''  smartobj.alertwindow(Me.Page, "Voucher Number Must Be Numeric ", "Prime")

                smartobj.ShowToast(Me.Page, ToastType.Warning, "Voucher Number Must Be Numeric", "Oops!", ToastPosition.TopRight, True)


                txttellerno.Focus()
                Exit Sub
            End If

            If Me.txtAccountNo2.Text = "" Then
                ''   smartobj.alertwindow(Me.Page, "Enter Account Number", "Prime")
                smartobj.ShowToast(Me.Page, ToastType.Warning, "Please Enter Account Number", "Oops!", ToastPosition.TopRight, True)


                txtAccountNo2.Focus()
                Exit Sub
            End If
            If Me.txtValueDate.Text = "" Then
                ''  smartobj.alertwindow(Me.Page, "Enter a Value Date", "Prime")

                smartobj.ShowToast(Me.Page, ToastType.Warning, "Please Enter a Value Date", "Oops!", ToastPosition.TopRight, True)

                txtValueDate.Focus()
                Exit Sub
            End If

            If Me.txtNaration.Text = "" Then
                ''   smartobj.alertwindow(Me.Page, "Enter Posting Narration", "Prime")

                smartobj.ShowToast(Me.Page, ToastType.Warning, "Please Enter Posting Narration", "Oops!", ToastPosition.TopRight, True)

                txtNaration.Focus()
                Exit Sub
            End If

            If Me.txtPayAmount.Text = "" Then
                ''  smartobj.alertwindow(Me.Page, "Enter Posting amount", "Prime")

                smartobj.ShowToast(Me.Page, ToastType.Warning, "Please Enter Posting Amount", "Oops!", ToastPosition.TopRight, True)


                txtPayAmount.Focus()
                Exit Sub
            End If

            latesttime = CDate(Me.txtValueDate.Text)
            ' valuedate = Date.Parse(MyTrans1, MyCultureInfo)
            'latesttime = CDate(valuedate)

            If IsDate(latesttime) Then
                latesttime = latesttime.AddHours(Now.Hour)
                latesttime = latesttime.AddMinutes(Now.Minute)
                latesttime = latesttime.AddSeconds(Now.Second)
                'latesttime = Format(CDate(latesttime.Date), "MM/dd/yyyy hh:mm:ss")
            End If



            Dim branchcode As String
            Dim selacc As String = "Select branchcode,postGl_Acctno from tbl_UserProfile where node_id=" & Session("node_ID") & " and userid='" & Session("Userid").Trim & "'"
            If con.SqlDs(selacc).Tables(0).Rows.Count > 0 Then
                drx = con.SqlDs(selacc).Tables(0).Rows(0)
                glnumber = drx.Item("postGl_Acctno").ToString.Trim
                branchcode = drx.Item("branchcode").ToString.Trim


            Else
                ''    smartobj.alertwindow(Me.Page, "You Do Not Have Posting Right", "Prime")

                smartobj.ShowToast(Me.Page, ToastType.Warning, "You Do Not Have Posting Right", "Oops!", ToastPosition.TopRight, True)

                smartobj.ClearWebPage(Me.Page)
                Exit Sub
            End If

            Dim overline As String
            Dim overlineid As String

            If Session("overide") = "1" Then
                If Session("valid") <> "0" Then
                    ''    smartobj.alertwindow(Me.Page, "Transaction Was Not Override.Please Re-Post Transaction", "Prime")

                    smartobj.ShowToast(Me.Page, ToastType.Warning, "Transaction Was Not Override.Please Re-Post Transaction", "Oops!", ToastPosition.TopRight, True)


                    smartobj.ClearWebPage(Me.Page)
                    Exit Sub
                Else
                    overline = Session("overide")
                    overlineid = Session("overideid")
                End If

            Else
                overline = 0
                overlineid = 0
            End If
            Dim ptyp As String = ""
            Dim pcode As String = ""
            Dim ppaytyp As String = ""

            If Session("pointingflag") = 1 Then
                If (Session("pointing").Trim = Me.txtAcNumber.Text.Trim) And (Session("pointing2").Trim = Me.txtAccountNo2.Text.Trim) Then
                    ''  smartobj.alertwindow(Me.Page, Session("pointingResmsg"), "Prime")

                    smartobj.ShowToast(Me.Page, ToastType.Warning, Session("pointingResmsg"), "Oops!", ToastPosition.TopRight, True)


                    Exit Sub
                End If

                If Session("pointingRes") = "F" Then
                    Me.btnSubmit.Enabled = False
                    ''    smartobj.alertwindow(Me.Page, Session("pointingResmsg"), "Prime")

                    smartobj.ShowToast(Me.Page, ToastType.Warning, Session("pointingResmsg"), "Oops!", ToastPosition.TopRight, True)

                    Exit Sub

                End If
                ptyp = "POINT"
                pcode = Me.txtPaycode.Text.Trim
                If Session("pointing") <> "" Then
                    ppaytyp = Session("paytype")
                End If
                If Session("pointing2") <> "" Then
                    ppaytyp = Session("paytype2")
                End If
            Else
                ptyp = "0"
                pcode = "0"
                ppaytyp = "0"
            End If

            Dim narration As String = Me.txtNaration.Text.Trim.Replace("'", "")
            narration = narration.Trim

            If Me.txttellerno.Text = "" Then
                Me.txttellerno.Text = 0
            End If
            Dim getchk1 As Integer = 0
            Dim getchk2 As Integer = 0

            getchk1 = Session("idcnt")
            getchk2 = Session("idcnt2")

            Dim sum As Integer = CInt(getchk1) + CInt(getchk2)


            Dim reversal As String
            If Me.CKBLien.Checked = True Then
                reversal = 3
            Else
                reversal = 1
            End If

            reversal = reversal.Trim

            If sum = 0 Then
                qry = "Declare @retval int,@behav int,@retmsg varchar(100) exec Proc_InfoPosting '" & Me.txtAcNumber.Text.Trim & "'," &
         "'" & Me.txtAccountNo2.Text.Trim & "'," & CDbl(Me.txtTransAmount.Text.Trim) & ",'" & "523" & "','" & "002" & "'," &
         "'" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "','" & Session("Userid").Trim & "',null,'" & branchcode & "','" & narration & "','" & reversal & "'," &
         "'" & Me.drpCurrency.SelectedValue.Trim & "','" & "1" & "','" & "1" & "'," & CInt(Me.txtRate.Text.Trim) & ",'" & Me.txttellerno.Text.Trim & "'," &
        "null,'" & DrpTransfer.SelectedValue.Trim & "','" & ptyp & "','" & pcode & "',null,'" & ppaytyp & "','" & overline & "','" & overlineid & "',null,@behav output,@retval output,@retmsg output, " & Session("node_ID") & " select @behav, @retval ,@retmsg"

            ElseIf sum = 1 Then
                If getchk1 = 0 Then
                    ''casa debit gl credit

                    qry = "Declare @retval int,@behav int,@retmsg varchar(100) exec Proc_InfoPosting '" & Me.txtAcNumber.Text.Trim & "'," &
                             "'" & Me.txtAccountNo2.Text.Trim & "'," & CDbl(Me.txtTransAmount.Text.Trim) & ",'" & "523" & "','" & "002" & "'," &
                             "'" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "','" & Session("Userid").Trim & "',null,'" & branchcode & "','" & narration & "','" & reversal & "'," &
                             "'" & Me.drpCurrency.SelectedValue.Trim & "','" & "1" & "','" & "2" & "'," & CInt(Me.txtRate.Text.Trim) & ",'" & Me.txttellerno.Text.Trim & "'," &
        "null,'" & DrpTransfer.SelectedValue.Trim & "','" & ptyp & "','" & pcode & "',null,'" & ppaytyp & "','" & overline & "','" & overlineid & "',null,@behav output,@retval output,@retmsg output, " & Session("node_ID") & " select @behav, @retval ,@retmsg"

                Else
                    ''gl debit casa credit
                    qry = "Declare @retval int,@behav int,@retmsg varchar(100) exec Proc_InfoPosting '" & Me.txtAcNumber.Text.Trim & "'," &
                                            "'" & Me.txtAccountNo2.Text.Trim & "'," & CDbl(Me.txtTransAmount.Text.Trim) & ",'" & "516" & "','" & "002" & "'," &
                                            "'" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "','" & Session("Userid").Trim & "',null,'" & branchcode & "','" & narration & "','" & reversal & "'," &
                                            "'" & Me.drpCurrency.SelectedValue.Trim & "','" & "2" & "','" & "1" & "'," & CInt(Me.txtRate.Text.Trim) & ",'" & Me.txttellerno.Text.Trim & "'," &
                                                          "null,'" & DrpTransfer.SelectedValue.Trim & "','" & ptyp & "','" & pcode & "',null,'" & ppaytyp & "','" & overline & "','" & overlineid & "',null,@behav output,@retval output,@retmsg output, " & Session("node_ID") & " select @behav, @retval ,@retmsg"


                End If
            ElseIf sum = 2 Then
                ''gl to gl
                qry = "Declare @retval int,@behav int,@retmsg varchar(100) exec Proc_InfoPosting '" & Me.txtAcNumber.Text.Trim & "'," &
                                                           "'" & Me.txtAccountNo2.Text.Trim & "'," & CDbl(Me.txtTransAmount.Text.Trim) & ",'" & "516" & "','" & "008" & "'," &
                                                           "'" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "','" & Session("Userid").Trim & "',null,'" & branchcode & "','" & narration & "','" & reversal & "'," &
                                                           "'" & Me.drpCurrency.SelectedValue.Trim & "','" & "2" & "','" & "2" & "'," & CInt(Me.txtRate.Text.Trim) & ",'" & Me.txttellerno.Text.Trim & "'," &
                                                          "null,'" & DrpTransfer.SelectedValue.Trim & "','" & ptyp & "','" & pcode & "',null,'" & ppaytyp & "','" & overline & "','" & overlineid & "',null,@behav output,@retval output,@retmsg output, " & Session("node_ID") & " select @behav, @retval ,@retmsg"


            End If


            ''qry = "Declare @retval int,@retmsg varchar(100) exec Proc_InsertCASA '" & glnumber & "'," & _
            ''"'" & Me.txtAcNumber.Text.Trim & "','" & CDbl(Me.txtTransAmount.Text.Trim) & "','" & "001" & "'," & _
            ''"'" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "',null,'" & Session("Userid").Trim & "',null,'" & narration & "'," & _
            ''"'" & Me.drpCurrency.SelectedValue.Trim & "'," & CInt(Me.txtRate.Text.Trim) & ",'" & Me.txtTellerNo.Text.Trim & "'," & _
            ''"null,null,null,NULL,@retVal output,@retmsg output select @retval ,@retmsg"

            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                behav = dr(0).ToString
                retval = dr(1).ToString
                retmsg = dr(2).ToString
            Next

            If behav > 1 Then
                ''Me.btnSubmit.Enabled = False
                Dim selex4 As String = "Delete from tbl_postlog where node_id=" & Session("node_ID") & " and accountno='" & Me.txtAcNumber.Text.Trim & "'"
                con.SqlDs(selex4)

                ''    smartobj.alertwindow(Me.Page, retmsg & " Choose Overide Button and Call For Overrride", "Prime")

                smartobj.ShowToast(Me.Page, ToastType.Warning, retmsg & " Choose Overide Button and Call For Overrride", "Oops!", ToastPosition.TopRight, True)

                ''Response.Write("<script>window.open('/Prime/BankingOperations/Override.aspx', 'overlinePopup','titlebar=no,left=50,top=100,width=220,height=220,resizable=no');</script>")
                HypAuth.Visible = True
                Me.btnAppoff.Enabled = True
                Session("overide") = "0"
                Exit Sub
            Else
                ''   smartobj.alertwindow(Me.Page, retmsg, "Prime")


                'clear()
                'smartobj.ClearWebPage(Me.Page)
                ''Me.btnSubmit.Enabled = False
                HypAuth.Visible = False
                Me.btnAppoff.Enabled = False
                Bsubmit = False

            End If

            If retval = 0 Then
                Me.btnSubmit.Enabled = False

                Dim selex3 As String = "Delete from tbl_postlog where node_id=" & Session("node_ID") & " and accountno='" & Me.txtAcNumber.Text.Trim & "'"
                con.SqlDs(selex3)

                Dim selex2 As String = "Delete from tbl_postlog where node_id=" & Session("node_ID") & " and accountno='" & Me.txtAccountNo2.Text.Trim & "'"
                con.SqlDs(selex2)

                '' postpointing()

                till()
                clear()
                Session("pointingRes") = ""
                Session("pointing") = ""
                Session("paycode") = ""
                Session("idcnt") = 0
                Session("idcnt2") = 0
                Session("pointbal") = 0
                Session("pointingflag") = 0



                smartobj.ShowToast(Me.Page, ToastType.Success, retmsg, "Yessss!", ToastPosition.TopRight, True)

            Else
                Me.btnSubmit.Enabled = True
                smartobj.ShowToast(Me.Page, ToastType.Error, retmsg, "Error!", ToastPosition.TopRight, True)

            End If
            Session("overide") = ""
            Session("overideid") = ""
            Session("valid") = ""
            Bsubmit = False

            'End If


        Catch ex As Exception
            logger.Info("BANKING OPERATION: TRANSFERS SUBMIT BTN'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "*******************************************************************************************************************************************************************")

            smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)

        End Try

    End Sub
    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Try
            smartobj.ClearWebPage(Me.Page)
            clear()
            Session("pointingRes") = ""
            Session("pointing") = ""
            Session("paycode") = ""
            Session("idcnt") = 0
            Session("idcnt2") = 0
            Session("pointbal") = 0
            Session("pointingflag") = 0

            txtAcNumber.Text = String.Empty
            txtAccountNo2.Text = String.Empty
            Label1.Text = String.Empty
            Label2.Text = String.Empty
            Label3.Text = String.Empty
            Label4.Text = String.Empty
            Label5.Text = String.Empty
            Label6.Text = String.Empty
            Label7.Text = String.Empty
            Label8.Text = String.Empty
            Label9.Text = String.Empty
            Label10.Text = String.Empty
            Label11.Text = String.Empty
            Label12.Text = String.Empty
            Label13.Text = String.Empty
            Label14.Text = String.Empty
            Label15.Text = String.Empty
            Label16.Text = String.Empty
            Label17.Text = String.Empty
            Label18.Text = String.Empty
            Label21.Text = String.Empty
            Label22.Text = String.Empty
            txtAcNumber.Focus()
            Me.btnSubmit.Enabled = True
            Me.btnAppoff.Enabled = True
            selcurrency()
        Catch ex As Exception
            logger.Info("BANKING OPERATION: TRANSFERS RESET BTN'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "*******************************************************************************************************************************************************************")
        End Try
    End Sub
    Sub selcurrency()
        Try
            Dim Lock As Integer
            qry = "Select lockcurrency,country from tbl_bank where node_id=" & Session("node_ID") & " "
            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                Lock = dr!lockcurrency
                Me.drpCurrency.SelectedValue = dr!country.ToString.Trim
            Next
            If Lock = 1 Then
                drpCurrency.Enabled = False
                Me.txtRate.Text = 1
            Else
                drpCurrency.Enabled = True

            End If
        Catch ex As Exception
            logger.Info("BANKING OPERATION: TRANSFERS SELECT CURRENCY'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "*******************************************************************************************************************************************************************")
        End Try
    End Sub
    Function FormatURL(ByVal strArgument As String) As String
        Return ("~/Customerservice/getimg.aspx?id=" & strArgument)
    End Function
    'Protected Sub txtTellerNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttellerno.TextChanged
    '    Try

    '        qry = "Declare @retval int,@retmsg varchar(100) exec proc_validatetill '" & Me.txtTellerNo.Text.Trim & "','" & Me.txtAcNumber.Text.Trim & "'," & _
    '        "'" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "',@retval output,@retmsg output select @retval ,@retmsg"

    '        For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
    '            retval = dr(0).ToString
    '            retmsg = dr(1).ToString
    '        Next
    '        If retval <> "0" Then
    '            smartobj.alertwindow(Me.Page, retmsg, "Prime")
    '            smartobj.ClearWebPage(Me.Page)
    '            Me.btnSubmit.Enabled = False
    '        Else
    '            Me.btnSubmit.Enabled = True
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub

#End Region
#Region "Declaration"
    Dim qry As String = ""
    Dim anx As Date
    Dim glnumber As String = ""
#End Region
#Region "PageLoad"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LnkCharge.NavigateUrl = "javascript:Chgdetail('document.aspnetForm." + txtNoRow.ClientID.ToString() + "');"
        LnkCharge2.NavigateUrl = "javascript:Chgdetail('document.aspnetForm." + txtNoRow.ClientID.ToString() + "');"
        LnkCharge0.NavigateUrl = "javascript:acctdetail('document.aspnetForm." + txtNoRow.ClientID.ToString() + "');"

        Me.HyperLink1.NavigateUrl = "javascript:accountGLPicker('document.aspnetForm." + txtAcNumber.ClientID.ToString() + "');"
        Me.HyperLink2.NavigateUrl = "javascript:accountGLPicker('document.aspnetForm." + Me.txtAccountNo2.ClientID.ToString() + "');"

        hypValueDate.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtValueDate.ClientID.ToString() + "');"
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = ""
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "MEMBER DEPOSIT" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        Dim menuname As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("lbldisplay"), System.Web.UI.WebControls.Label)

        menuname.Text = Request.QueryString("XXX")
        'If menuname.Text = "" Then
        '    Response.Redirect("~/Unauthorize.aspx")
        'End If

        'If Validate_Access(menuname.Text) = 0 Then
        '    Response.Redirect("~/Unauthorize.aspx")
        'End If
        txtNoRow.Text = 20
        HypAuth.NavigateUrl = "javascript:authPicker('document.aspnetForm." + txtNoRow.ClientID.ToString() + "');"

        ''linkpaycode.NavigateUrl = "javascript:payPicker('document.aspnetForm." + txtPayAmount0.ClientID.ToString() + "');"

        If Page.IsPostBack = False Then

            till()
            If Session("valid") <> "0" Then
                Me.btnAppoff.Enabled = True
                Me.btnSubmit.Enabled = False
                Session("overide") = ""
                Session("overideid") = ""
                Session("Custchg1") = ""
                Session("Custchg2") = ""

                Session("valid") = ""

            Else
                Me.btnAppoff.Enabled = False
                Me.btnSubmit.Enabled = True

            End If

            selcurrency()
            loaddate()

            Dim Dstring7 As String = "SELECT cast(ltrim(rtrim(countrycode)) as varchar) countrycode,currencymne FROM tbl_country where status=1"
            smartobj.loadComboValues("--Select a Currency--- ", Me.drpCurrency, Dstring7)

            Dim Dstring8 As String = "SELECT cast(ltrim(rtrim(sbucode)) as varchar) sbucode,sbuname FROM tbl_sbu where node_id=" & Session("node_ID") & ""

            smartobj.loadComboValues("--Select a SBU--- ", Me.DrpSubBr1, Dstring8)

            smartobj.loadComboValues("--Select a SBU--- ", Me.DrpSubBr2, Dstring8)

        End If
    End Sub
    Function Validate_Access(ByVal MenuName As String) As Integer

        qry = " declare @retVal int " & vbNewLine
        qry = qry & "execute Proc_RM_Validate "
        qry = qry & smartobj.EncoteWithSingleQuote(Session("Roleid")) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(MenuName) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Session("Userid")) & ",@retVal OUTPUT," & Session("node_ID") & " "
        qry = qry & " select @retVal"

        For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
            retval = dr(0).ToString
        Next
        Return retval
    End Function
    Sub loaddate()
        Dim qry As String = "select cast(sys_date as datetime)sys_date,sys_phase from tbl_system where node_id=" & Session("node_ID") & ""
        For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
            latesttime = Format(CDate(dr!sys_date), "dd/MM/yyyy")
        Next
        Me.txtValueDate.Text = latesttime
    End Sub

#End Region


    Sub clear()
        Me.txtAccountNo2.Text = ""
        Me.txtAcNumber.Text = ""
        Me.txtNaration.Text = ""
        '' Me.txtNaration0.Text = ""
        Me.txtNoRow.Text = ""
        Me.txttellerno.Text = ""
        Me.txtTransAmount.Text = ""
        'Me.txtRate.Text = ""
        Me.txtPayAmount.Text = ""
        Me.txtPayAmount0.Text = ""
        Me.txtPaycode.Text = ""
        Me.DrpSubBr1.Visible = False
        Me.DrpSubBr2.Visible = False
        txtAcNumber.Text = String.Empty
        txtAccountNo2.Text = String.Empty
        Label1.Text = String.Empty
        Label2.Text = String.Empty
        Label3.Text = String.Empty
        Label4.Text = String.Empty
        Label5.Text = String.Empty
        Label6.Text = String.Empty
        Label7.Text = String.Empty
        Label8.Text = String.Empty
        Label9.Text = String.Empty
        Label10.Text = String.Empty
        Label11.Text = String.Empty
        Label12.Text = String.Empty
        Label13.Text = String.Empty
        Label14.Text = String.Empty
        Label15.Text = String.Empty
        Label16.Text = String.Empty
        Label17.Text = String.Empty
        Label18.Text = String.Empty
        Label21.Text = String.Empty
        Label22.Text = String.Empty


        Me.DropMode.SelectedIndex = 0
    End Sub

    Protected Sub txtAcNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcNumber.TextChanged
        Try

            Dim selex As String = "Delete from tbl_postlog where ltrim(rtrim(accountno))='" & Me.txtAcNumber.Text.Trim & "' and node_id = " & Session("node_ID") & ""
            con.SqlDs(selex)


            Session("Custchg1") = ""
            Session("pointing") = ""
            ''Session("pointing2") = ""

            Session("pointingRes") = ""
            Session("pointingflag") = 0
            If Session("pointing2") = "" Then
                Me.txtPaycode.Visible = False
                Me.Label20.Visible = False
                Session("pointingflag") = 0
                Session("pointingRes") = ""
                Session("pointing2") = ""

            Else
                Me.txtPaycode.Visible = True
                Me.Label20.Visible = True
            End If


            Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtAcNumber.Text.Trim & "',@retval output,@retmsg output, " & Session("node_ID") & " select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            If retval = "0" Then
                Me.txtAcNumber.Text = retmsg
            End If

            Dim selacct As String = "select substring(accountnumber,1,3) from tbl_casaaccount where accountnumber='" & Me.txtAcNumber.Text.Trim & "' and status=1 and node_id = " & Session("node_ID") & ""
            If con.SqlDs(selacct).Tables(0).Rows.Count > 0 Then
                accdetail1(Me.txtAcNumber.Text.Trim, 0)



                Session("idcnt") = 0
                Dim strv As String = con.SqlDs(selacct).Tables(0).Rows(0).Item(0)
                Dim Dstring1 As String = "SELECT subbranchcode FROM tbl_subbranch where Mbranchcode='" & strv & "' and node_id = " & Session("node_ID") & ""
                If con.SqlDs(Dstring1).Tables(0).Rows.Count > 0 Then
                    Dim Dstring33 As String = "SELECT cast(ltrim(rtrim(subbranchcode)) as varchar) subbranchcode,subbranchname FROM tbl_subbranch where Mbranchcode='" & strv & "' and node_id = " & Session("node_ID") & ""
                    smartobj.loadComboValues("--Select a Sub-Branch--- ", Me.DrpSubBr1, Dstring33)
                    Me.DrpSubBr1.Visible = True
                Else

                    Me.DrpSubBr1.Visible = False

                End If
            Else
                selfind = "declare @retval int,@retmsg varchar(100) exec [proc_ValidOldGL] '" & Me.txtAcNumber.Text.Trim & "', " & Session("node_ID") & ",@retval output,@retmsg output select @retval,@retmsg"
                For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                    retval = dr(0).ToString
                    retmsg = dr(1).ToString
                Next

                If retval = "0" Then
                    If retmsg <> "ok" Then
                        ''smartobj.alertwindow(Me.Page, retmsg, "Prime")
                        smartobj.ShowToast(Me.Page, ToastType.Warning, retmsg, "Oops!", ToastPosition.TopRight, True)

                    Else
                        Me.txtAcNumber.Text = retmsg

                    End If
                End If

                Dim selacct2 As String = "select substring(glnumber,1,3),isnull(pointing,0) from tbl_bankgl where glnumber='" & Me.txtAcNumber.Text.Trim & "' and isnull(Blocked,0)<>1 and node_id = " & Session("node_ID") & ""
                If con.SqlDs(selacct2).Tables(0).Rows.Count > 0 Then
                    accdetail1(Me.txtAcNumber.Text.Trim, 1)
                    Session("idcnt") = 1
                    Dim strv As String = con.SqlDs(selacct2).Tables(0).Rows(0).Item(0)
                    Dim point As String = con.SqlDs(selacct2).Tables(0).Rows(0).Item(1)



                    If point = "1" Then
                        txtPaycode.Visible = True
                        Me.Label20.Visible = True

                        Session("pointingflag") = 1
                        Me.Label19.Visible = True
                        Me.txtPayAmount0.Visible = True
                        Me.txtPayAmount0.ReadOnly = True
                        Me.btnSubmit.Enabled = True
                        Me.btnAppoff.Enabled = True
                        Session("pointing") = Me.txtAcNumber.Text
                        Session("paytype") = "D"
                        detail()
                    Else
                        ''Me.Label19.Visible = False
                        ''Me.txtPayAmount0.Visible = False

                        ''Me.txtPaycode.Visible = False
                        '' Me.Label20.Visible = False
                        Me.btnSubmit.Enabled = True
                        Me.btnAppoff.Enabled = True

                    End If


                    Dim Dstring1 As String = "SELECT subbranchcode FROM tbl_subbranch where Mbranchcode='" & strv & "' and node_id = " & Session("node_ID") & ""
                    If con.SqlDs(Dstring1).Tables(0).Rows.Count > 0 Then
                        Dim Dstring33 As String = "SELECT cast(ltrim(rtrim(subbranchcode)) as varchar) subbranchcode,subbranchname FROM tbl_subbranch where Mbranchcode='" & strv & "' and node_id = " & Session("node_ID") & ""
                        smartobj.loadComboValues("--Select a Sub-Branch--- ", Me.DrpSubBr1, Dstring33)

                        Me.DrpSubBr1.Visible = True
                    Else
                        Me.DrpSubBr1.Visible = False

                    End If


                    Dim selacct3 As String = "select glnumber from tbl_bankgl where gl_classcode >70000 and isnull(Blocked,0)<>1 and node_id = " & Session("node_ID") & ""
                    If con.SqlDs(selacct3).Tables(0).Rows.Count > 0 Then

                        Dim sbu As String = "select isnull(POSTSBU,0) from tbl_bank and node_id = " & Session("node_ID") & ""
                        Dim sbuacct As String = con.SqlDs(sbu).Tables(0).Rows(0).Item(0).ToString

                        If sbuacct = "1" Then
                            Me.DrpSubBr1.Visible = True
                        Else
                            Me.DrpSubBr1.Visible = False
                        End If

                    End If

                Else
                    ''smartobj.alertwindow(Me.Page, "Error: Either GL OR Customer Account Does Not Exist OR Posting Not Allowed On Account", "Prime")

                    smartobj.ShowToast(Me.Page, ToastType.Warning, "Error: Either GL OR Customer Account Does Not Exist OR Posting Not Allowed On Account", "Oops!", ToastPosition.TopRight, True)


                    Me.DrpSubBr1.Visible = False

                    Exit Sub
                End If

            End If

            Me.txtAccountNo2.Focus()
        Catch ex As Exception
            logger.Info("BANKING OPERATION: TRANSFERS ACCT NUMBER TEXT CHANGED'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "*******************************************************************************************************************************************************************")
        End Try
    End Sub
    Sub postpointing()
        If Session("pointingflag") = 1 Then

            If Session("pointingRes") = "T" Then
                Me.btnSubmit.Enabled = True
                If Session("pointing").Trim = Me.txtAcNumber.Text.Trim Then
                    Dim selExist As String = "- '" & Session("pointing").Trim & "','" & Me.txtPaycode.Text.Trim & "','" & Me.txtNaration.Text.Trim & "'," &
               "'" & Session("paytype").Trim & "','" & CDec(Me.txtPayAmount.Text.Trim) & "','" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "'," &
               "'" & Session("Userid").Trim & "'"
                    con.SqlDs(selExist)
                End If

                If Session("pointing2").Trim = Me.txtAccountNo2.Text.Trim Then
                    Dim selExist As String = "Exec [Proc_PointingPost] '" & Session("pointing2").Trim & "','" & Me.txtPaycode.Text.Trim & "','" & Me.txtNaration.Text.Trim & "'," &
               "'" & Session("paytype2").Trim & "','" & CDec(Me.txtPayAmount.Text.Trim) & "','" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "'," &
               "'" & Session("Userid").Trim & "', " & Session("node_ID") & ""
                    con.SqlDs(selExist)
                End If
            End If
        End If


    End Sub
    Sub accdetail1(ByVal acctno As String, ByVal type As Integer)
        Try
            Dim selExist As String = "Exec Proc_CustAcctDetail2 '" & acctno & "'," & type & ", " & Session("node_ID") & ""
            If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then
                Session("Custchg1") = Me.txtAcNumber.Text.Trim
                'Dim seltyp As String = "Select apptype from tbl_bankproduct a,tbl_casaaccount b where a.productcode=b.productcode and b.accountnumber='" & Me.txtAcNumber.Text.Trim & "'"
                'For Each dr As Data.DataRow In con.SqlDs(seltyp).Tables(0).Rows
                '    app = dr!apptype.ToString.Trim
                'Next
                'If app = "CK" Then
                '    smartobj.alertwindow(Me.Page, "Transaction is Not Allowed On Checking Account.", "Prime")
                '    Exit Sub
                'End If
                drx = con.SqlDs(selExist).Tables(0).Rows(0)
                Me.Label1.Text = drx.Item("accounttitle").ToString
                Me.Label2.Text = drx.Item("prodname").ToString
                Me.Label3.Text = drx.Item("branch").ToString

                Me.Label4.Text = smartobj.FormatMoney(Format(drx.Item("bkbal"), "###0.00"))
                Me.Label5.Text = smartobj.FormatMoney(Format(drx.Item("effbal"), "###0.00"))
                Me.Label6.Text = smartobj.FormatMoney(Format(drx.Item("usebal"), "###0.00"))

                Me.Label7.Text = drx.Item("acctty").ToString
                Me.Label8.Text = drx.Item("source").ToString
                Me.Label9.Text = drx.Item("acctstatus").ToString
                Dim prostatus As String = drx.Item("prodstatus").ToString
                Dim prodesc As String = drx.Item("proddesc").ToString

                Me.Label22.Text = drx.Item("TotalCharge").ToString

                'If Me.Label9.Text <> "Active" Then
                '    Me.Label9.BackColor = Drawing.Color.Red
                'Else
                '    Me.Label9.BackColor = Drawing.Color.Orange
                '    Me.Label9.ForeColor = Drawing.Color.Blue

                'End If
                If type = 0 Then
                    If Me.Label9.Text = "Active" Then
                        Me.AcctStatus.Attributes.Add("class", "pull-right badge bg-green")
                    Else

                        Me.AcctStatus.Attributes.Add("class", "pull-right badge bg-red")

                    End If
                    If drx.Item("bkbal") > 0 Then

                        Me.BookBalance.Attributes.Add("class", "pull-right badge bg-green")
                    Else

                        Me.BookBalance.Attributes.Add("class", "pull-right badge bg-red")

                    End If
                    If drx.Item("effbal") > 0 Then

                        Me.EffectiveBal.Attributes.Add("class", "pull-right badge bg-green")
                    Else

                        Me.EffectiveBal.Attributes.Add("class", "pull-right badge bg-red")

                    End If

                    If drx.Item("usebal") > 0 Then

                        Me.UsableBal.Attributes.Add("class", "pull-right badge bg-green")
                    Else

                        Me.UsableBal.Attributes.Add("class", "pull-right badge bg-red")

                    End If
                Else
                    If Me.Label9.Text = "Active" Then
                        Me.AcctStatus.Attributes.Add("class", "pull-right badge bg-green")
                    Else

                        Me.AcctStatus.Attributes.Add("class", "pull-right badge bg-red")

                    End If

                End If

                If Me.Label22.Text.Trim <> "" Then
                    If CDec(Me.Label22.Text.Trim) > 0 Then
                        Me.LnkCharge.Visible = True
                    Else
                        Me.LnkCharge.Visible = False

                    End If
                End If
                Dim idimg As String = drx.Item("customerid").ToString.Trim

                'Image1.Visible = True
                'Image1.ImageUrl = FormatURL(idimg)

                If prostatus = "1" Then
                    smartobj.alertwindow(Me.Page, prodesc, "Prime")
                    Me.btnSubmit.Enabled = False
                    Me.btnAppoff.Enabled = False

                Else
                    Me.btnAppoff.Enabled = True
                    Me.btnSubmit.Enabled = True
                End If
                ' selcurrency()
            Else
                Me.Label1.Text = ""
                Me.Label2.Text = ""
                Me.Label3.Text = ""
                Me.Label4.Text = ""
                Me.Label5.Text = ""
                Me.Label6.Text = ""
                Me.Label7.Text = ""
                Me.Label8.Text = ""
                'Image1.Visible = False
                '' smartobj.alertwindow(Me.Page, "Account Number Does Not Exist", "Prime")

                smartobj.ShowToast(Me.Page, ToastType.Warning, "Account Number Does Not Exist", "Oops!", ToastPosition.TopRight, True)

                txtAcNumber.Focus()
                Exit Sub
            End If

        Catch ex As Exception
            logger.Info("BANKING OPERATION: TRANSFERS ACCOUNT DETAIL 1'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "*******************************************************************************************************************************************************************")
        End Try
    End Sub
    Sub accdetail2(ByVal acctno As String, ByVal type As Integer)

        Try
            Dim selExist As String = "Exec Proc_CustAcctDetail2 '" & acctno & "'," & type & ", " & Session("node_ID") & ""
            If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then
                Session("Custchg2") = Me.txtAccountNo2.Text.Trim
                'Dim seltyp As String = "Select apptype from tbl_bankproduct a,tbl_casaaccount b where a.productcode=b.productcode and b.accountnumber='" & Me.txtAcNumber.Text.Trim & "'"
                'For Each dr As Data.DataRow In con.SqlDs(seltyp).Tables(0).Rows
                '    app = dr!apptype.ToString.Trim
                'Next
                'If app = "CK" Then
                '    smartobj.alertwindow(Me.Page, "Transaction is Not Allowed On Checking Account.", "Prime")
                '    Exit Sub
                'End If
                drx = con.SqlDs(selExist).Tables(0).Rows(0)
                Me.Label10.Text = drx.Item("accounttitle").ToString
                Me.Label11.Text = drx.Item("prodname").ToString
                Me.Label12.Text = drx.Item("branch").ToString

                Me.Label13.Text = smartobj.FormatMoney(Format(drx.Item("bkbal"), "###0.00"))
                Me.Label14.Text = smartobj.FormatMoney(Format(drx.Item("effbal"), "###0.00"))
                Me.Label15.Text = smartobj.FormatMoney(Format(drx.Item("usebal"), "###0.00"))


                Me.Label16.Text = drx.Item("acctty").ToString
                Me.Label17.Text = drx.Item("source").ToString
                Me.Label18.Text = drx.Item("acctstatus").ToString
                Dim prostatus As String = drx.Item("prodstatus").ToString
                Dim prodesc As String = drx.Item("proddesc").ToString

                Me.Label21.Text = drx.Item("TotalCharge").ToString

                'If Me.Label18.Text <> "Active" Then
                '    Me.Label18.BackColor = Drawing.Color.Red
                'Else
                '    Me.Label18.BackColor = Drawing.Color.Orange
                '    Me.Label18.ForeColor = Drawing.Color.Blue

                'End If

                If type = 0 Then
                    If Me.Label18.Text = "Active" Then
                        Me.AccountStatus2.Attributes.Add("class", "pull-right badge bg-green")
                    Else

                        Me.AccountStatus2.Attributes.Add("class", "pull-right badge bg-red")

                    End If
                    If drx.Item("bkbal") > 0 Then

                        Me.BookBalance2.Attributes.Add("class", "pull-right badge bg-green")
                    Else

                        Me.BookBalance2.Attributes.Add("class", "pull-right badge bg-red")

                    End If
                    If drx.Item("effbal") > 0 Then

                        Me.EffectiveBal2.Attributes.Add("class", "pull-right badge bg-green")
                    Else

                        Me.EffectiveBal2.Attributes.Add("class", "pull-right badge bg-red")

                    End If

                    If drx.Item("usebal") > 0 Then

                        Me.UsableBal2.Attributes.Add("class", "pull-right badge bg-green")
                    Else

                        Me.UsableBal2.Attributes.Add("class", "pull-right badge bg-red")

                    End If
                Else
                    If Me.Label18.Text = "Active" Then
                        Me.AccountStatus2.Attributes.Add("class", "pull-right badge bg-green")
                    Else

                        Me.AccountStatus2.Attributes.Add("class", "pull-right badge bg-red")

                    End If
                End If

                If Me.Label21.Text.Trim <> "" Then
                    If CDec(Me.Label21.Text.Trim) > 0 Then
                        Me.LnkCharge.Visible = True
                    Else
                        Me.LnkCharge.Visible = False

                    End If
                End If
                Dim idimg As String = drx.Item("customerid").ToString.Trim

                'Image1.Visible = True
                'Image1.ImageUrl = FormatURL(idimg)

                If prostatus = "1" Then
                    smartobj.alertwindow(Me.Page, prodesc, "Prime")
                    Me.btnSubmit.Enabled = False
                    Me.btnAppoff.Enabled = False

                Else
                    Me.btnAppoff.Enabled = True
                    Me.btnSubmit.Enabled = True
                End If
                selcurrency()
            Else
                Me.Label10.Text = ""
                Me.Label11.Text = ""
                Me.Label12.Text = ""
                Me.Label13.Text = ""
                Me.Label14.Text = ""
                Me.Label15.Text = ""
                Me.Label16.Text = ""
                Me.Label17.Text = ""
                Me.Label18.Text = ""
                'Image1.Visible = False
                ''   smartobj.alertwindow(Me.Page, "Account Number Does Not Exist", "Prime")

                smartobj.ShowToast(Me.Page, ToastType.Warning, "Account Number Does Not Exist", "Oops!", ToastPosition.TopRight, True)

                txtAccountNo2.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            logger.Info("BANKING OPERATION: TRANSFERS ACCOUNT DETAIL 2'" _
           & vbNewLine & "   <<<<Direction: OUTPUT" _
           & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
           & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
           & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
           & vbNewLine & "*******************************************************************************************************************************************************************")
        End Try
    End Sub
    Protected Sub txtAccountNo2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountNo2.TextChanged
        Try

            Dim selex2 As String = "Delete from tbl_postlog where node_id=" & Session("node_ID") & " and ltrim(rtrim(accountno))='" & Me.txtAccountNo2.Text.Trim & "'"
            con.SqlDs(selex2)

            Session("Custchg1") = ""
            ''Session("pointing") = ""
            Session("pointing2") = ""

            Session("pointingRes") = ""
            Session("pointingflag") = 0
            If Session("pointing") = "" Then
                Me.txtPaycode.Visible = False
                Me.Label20.Visible = False
                Session("pointingflag") = 0
                Session("pointingRes") = ""
                Session("pointing") = ""

            Else
                Me.txtPaycode.Visible = True
                Me.Label20.Visible = True
            End If

            Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtAccountNo2.Text.Trim & "',@retval output,@retmsg output, " & Session("node_ID") & " select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            If retval = "0" Then
                Me.txtAccountNo2.Text = retmsg
            End If

            Dim selacct As String = "select substring(accountnumber,1,3) from tbl_casaaccount where node_id=" & Session("node_ID") & " and accountnumber='" & Me.txtAccountNo2.Text.Trim & "' and status=1"
            If con.SqlDs(selacct).Tables(0).Rows.Count > 0 Then
                accdetail2(Me.txtAccountNo2.Text.Trim, 0)
                Session("idcnt2") = 0
                Dim strv As String = con.SqlDs(selacct).Tables(0).Rows(0).Item(0)

                Dim Dstring1 As String = "SELECT subbranchcode FROM tbl_subbranch where node_id=" & Session("node_ID") & " and Mbranchcode='" & strv & "'"
                If con.SqlDs(Dstring1).Tables(0).Rows.Count > 0 Then
                    Dim Dstring33 As String = "SELECT cast(ltrim(rtrim(subbranchcode)) as varchar) subbranchcode,subbranchname FROM tbl_subbranch where node_id=" & Session("node_ID") & " and Mbranchcode='" & strv & "'"
                    smartobj.loadComboValues("--Select a Sub-Branch--- ", Me.DrpSubBr2, Dstring33)

                    Me.DrpSubBr2.Visible = True
                Else
                    Me.DrpSubBr2.Visible = False

                End If
            Else

                selfind = "declare @retval int,@retmsg varchar(100) exec [proc_ValidOldGL] '" & Me.txtAccountNo2.Text.Trim & "', " & Session("node_ID") & ",@retval output,@retmsg output select @retval,@retmsg"
                For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                    retval = dr(0).ToString
                    retmsg = dr(1).ToString
                Next

                If retval = "0" Then
                    If retmsg <> "ok" Then
                        ''  smartobj.alertwindow(Me.Page, retmsg, "Prime")
                        smartobj.ShowToast(Me.Page, ToastType.Warning, retmsg, "Oops!", ToastPosition.TopRight, True)


                    Else
                        Me.txtAcNumber.Text = retmsg

                    End If
                End If



                Dim selacct2 As String = "select substring(glnumber,1,3),isnull(pointing,0) from tbl_bankgl where node_id=" & Session("node_ID") & " and glnumber='" & Me.txtAccountNo2.Text.Trim & "' and isnull(Blocked,0)<>1"
                If con.SqlDs(selacct2).Tables(0).Rows.Count > 0 Then
                    accdetail2(Me.txtAccountNo2.Text.Trim, 1)
                    Session("idcnt2") = 1
                    Dim strv As String = con.SqlDs(selacct2).Tables(0).Rows(0).Item(0)
                    Dim point As String = con.SqlDs(selacct2).Tables(0).Rows(0).Item(1)




                    If point = "1" Then
                        txtPaycode.Visible = True
                        Me.Label20.Visible = True
                        Session("pointingflag") = 1

                        Me.Label19.Visible = True
                        Me.txtPayAmount0.Visible = True
                        Me.btnSubmit.Enabled = True
                        Session("pointing2") = Me.txtAccountNo2.Text
                        Me.btnAppoff.Enabled = True
                        Session("paytype2") = "C"

                        detail()
                    Else

                        If Me.txtPayAmount0.Visible <> True Then
                            'Me.Label19.Visible = False
                            'Me.Label20.Visible = False
                            'Me.txtPayAmount0.Visible = False
                            ''Me.txtPaycode.Visible = False
                            Me.btnSubmit.Enabled = True
                            Me.btnAppoff.Enabled = True
                        End If


                    End If

                    Dim Dstring1 As String = "SELECT subbranchcode FROM tbl_subbranch where node_id=" & Session("node_ID") & " and Mbranchcode='" & strv & "'"
                    If con.SqlDs(Dstring1).Tables(0).Rows.Count > 0 Then
                        Dim Dstring33 As String = "SELECT cast(ltrim(rtrim(subbranchcode)) as varchar) subbranchcode,subbranchname FROM tbl_subbranch where node_id=" & Session("node_ID") & " and Mbranchcode='" & strv & "'"
                        smartobj.loadComboValues("--Select a Sub-Branch--- ", Me.DrpSubBr2, Dstring33)

                        Me.DrpSubBr2.Visible = True
                    Else
                        Me.DrpSubBr2.Visible = False

                    End If

                    Dim selacct3 As String = "select glnumber from tbl_bankgl where node_id=" & Session("node_ID") & " and gl_classcode >70000 and isnull(Blocked,0)<>1"
                    If con.SqlDs(selacct3).Tables(0).Rows.Count > 0 Then

                        Dim sbu As String = "select isnull(POSTSBU,0) from tbl_bank where node_id=" & Session("node_ID") & ""
                        Dim sbuacct As String = con.SqlDs(sbu).Tables(0).Rows(0).Item(0).ToString

                        If sbuacct = "1" Then
                            Me.DrpSubBr2.Visible = True
                        Else
                            Me.DrpSubBr2.Visible = False
                        End If

                    End If

                Else

                    ''   smartobj.alertwindow(Me.Page, "Error: Either GL Does Not Exist OR Posting Not Allowed On GL Account", "Prime")

                    smartobj.ShowToast(Me.Page, ToastType.Warning, "Error: Either GL Does Not Exist OR Posting Not Allowed On GL Account", "Oops!", ToastPosition.TopRight, True)


                    Me.DrpSubBr2.Visible = False

                    Exit Sub
                End If

            End If

            Me.txtPayAmount.Focus()
        Catch ex As Exception
            logger.Info("BANKING OPERATION: TRANSFERS ACCOUNT NO. 2 TEXT CHANGED'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "*******************************************************************************************************************************************************************")
        End Try
    End Sub
    Sub detail()
        Dim strTill As String = ""
        If Session("pointing") <> "" Then
            strTill = "Exec [proc_pointlist] '" & Session("pointing") & "','" & Me.txtPaycode.Text.Trim & "', " & Session("node_ID") & ""

        End If

        If Session("pointing2") <> "" Then
            strTill = "Exec [proc_pointlist] '" & Session("pointing2") & "','" & Me.txtPaycode.Text.Trim & "', " & Session("node_ID") & ""
        End If
        Me.GridView2.DataSource = con.SqlDs(strTill).Tables(0)
        Me.GridView2.DataBind()
        If GridView2.Rows.Count > 0 Then
            Me.GridView2.Visible = True
        Else
            Me.GridView2.Visible = False

        End If
    End Sub


    Protected Sub txtPaycode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPaycode.TextChanged
        Try
            Dim selExist As String = ""

            If Session("pointing") <> "" Then
                selExist = "Declare @retval int,@retmsg varchar(120) Exec Proc_pointing '" & Session("pointing").Trim & "','" & Me.txtPaycode.Text.Trim & "','" & Session("paytype").Trim & "', " & Session("node_ID") & ",@retval output,@retmsg output select @retval,@retmsg"
                If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then

                    drx = con.SqlDs(selExist).Tables(0).Rows(0)

                    Dim valid As String = drx.Item(0).ToString.Trim
                    Dim msg As String = drx.Item(1).ToString.Trim

                    If valid = "0" Then
                        'Me.btnLogin.Text = "Close"
                        'Me.btnLogin.Enabled = False
                        Session("pointingRes") = "T"
                        Session("pointbal") = msg
                        Me.btnSubmit.Enabled = True
                        Me.btnAppoff.Enabled = True
                        detail()

                        'authoriser
                    Else
                        ''  smartobj.alertwindow(Me.Page, msg, "Prime")

                        smartobj.ShowToast(Me.Page, ToastType.Warning, msg, "Oops!", ToastPosition.TopRight, True)

                        'Me.btnLogin.Enabled = True
                        Session("pointingRes") = "F"
                        Session("pointingResmsg") = msg
                        Me.btnSubmit.Enabled = False
                        Me.btnAppoff.Enabled = False
                        Exit Sub
                        ''non auth
                    End If
                End If
            End If

            If Session("pointing2") <> "" Then
                selExist = "Declare @retval int,@retmsg varchar(120) Exec Proc_pointing '" & Session("pointing2").Trim & "','" & Me.txtPaycode.Text.Trim & "','" & Session("paytype2").Trim & "', " & Session("node_ID") & ",@retval output,@retmsg output select @retval,@retmsg"
                If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then

                    drx = con.SqlDs(selExist).Tables(0).Rows(0)

                    Dim valid As String = drx.Item(0).ToString.Trim
                    Dim msg As String = drx.Item(1).ToString.Trim

                    If valid = "0" Then
                        'Me.btnLogin.Text = "Close"
                        'Me.btnLogin.Enabled = False
                        Session("pointingRes") = "T"
                        Session("pointbal") = msg
                        Me.btnSubmit.Enabled = True
                        Me.btnAppoff.Enabled = True
                        detail()
                        'authoriser
                    Else
                        ''  smartobj.alertwindow(Me.Page, msg, "Prime")

                        smartobj.ShowToast(Me.Page, ToastType.Warning, msg, "Oops!", ToastPosition.TopRight, True)

                        'Me.btnLogin.Enabled = True
                        Session("pointingRes") = "F"
                        Session("pointingResmsg") = msg
                        Me.btnSubmit.Enabled = False
                        Me.btnAppoff.Enabled = False
                        Exit Sub
                        ''non auth
                    End If
                End If
            End If

            Me.txtPayAmount0.Text = Session("pointbal")
        Catch ex As Exception
            logger.Info("BANKING OPERATION: TRANSFERS PAYCODE TEXT CHANGED'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "*******************************************************************************************************************************************************************")
        End Try
    End Sub

    Protected Sub DrpTransfer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpTransfer.SelectedIndexChanged
        Me.txtAcNumber.Focus()
    End Sub

    Protected Sub txttellerno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttellerno.TextChanged
        Me.txtNaration.Focus()
    End Sub

    Protected Sub txtNaration_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNaration.TextChanged
        btnSubmit.Focus()

    End Sub
    'Protected Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
    '    If Session("node_ID") = Nothing Then
    '        Response.Redirect("../PageExpire.aspx")
    '    Else
    '        Me.MasterPageFile = "~/Tenant" + Session("node_ID").ToString + "/Tenant.master"

    '    End If
    'End Sub
    Protected Sub DropMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropMode.SelectedIndexChanged
        If Me.DropMode.SelectedValue = 0 Then
            UploadEvidence.Visible = False
            txtAcNumber.Enabled = True
            HyperLink1.Enabled = True
            Debit_Details.Visible = True
            Panel1.Visible = False
            txtAcNumber.Text = ""
        ElseIf Me.DropMode.SelectedValue = 1 Then
            UploadEvidence.Visible = False
            Panel1.Visible = True
            Dim selacc As String = "Select branchcode,postGl_Acctno from tbl_UserProfile where userid='" & Session("Userid").Trim & "' and node_id = " & Session("node_ID") & ""
            If con.SqlDs(selacc).Tables(0).Rows.Count > 0 Then
                drx = con.SqlDs(selacc).Tables(0).Rows(0)
                txtAcNumber.Text = drx.Item("postGl_Acctno").ToString.Trim


                If txtAcNumber.Text = "" Then
                    ''smartobj.alertwindow(Me.Page, "You Do Not Have Posting Right Account number", "Prime")
                    smartobj.ShowToast(Me.Page, ToastType.Warning, "You Do Not Have Posting Right Account number", "Oops!", ToastPosition.TopRight, True)
                    txtAcNumber.Enabled = True
                    HyperLink1.Enabled = True
                    Exit Sub

                Else
                    txtAcNumber.Enabled = False
                    HyperLink1.Enabled = False
                    Debit_Details.Visible = False
                    ''accdetail1(Me.txtAcNumber.Text.Trim, 0)
                    Try

                        Dim selex As String = "Delete from tbl_postlog where ltrim(rtrim(accountno))='" & Me.txtAcNumber.Text.Trim & "' and node_id = " & Session("node_ID") & ""
                        con.SqlDs(selex)


                        Session("Custchg1") = ""
                        Session("pointing") = ""
                        ''Session("pointing2") = ""

                        Session("pointingRes") = ""
                        Session("pointingflag") = 0
                        If Session("pointing2") = "" Then
                            Me.txtPaycode.Visible = False
                            Me.Label20.Visible = False
                            Session("pointingflag") = 0
                            Session("pointingRes") = ""
                            Session("pointing2") = ""

                        Else
                            Me.txtPaycode.Visible = True
                            Me.Label20.Visible = True
                        End If


                        Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtAcNumber.Text.Trim & "',@retval output,@retmsg output, " & Session("node_ID") & " select @retval,@retmsg"
                        For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                            retval = dr(0).ToString
                            retmsg = dr(1).ToString
                        Next

                        If retval = "0" Then
                            Me.txtAcNumber.Text = retmsg
                        End If

                        Dim selacct As String = "select substring(accountnumber,1,3) from tbl_casaaccount where accountnumber='" & Me.txtAcNumber.Text.Trim & "' and status=1 and node_id = " & Session("node_ID") & ""
                        If con.SqlDs(selacct).Tables(0).Rows.Count > 0 Then
                            accdetail1(Me.txtAcNumber.Text.Trim, 0)



                            Session("idcnt") = 0
                            Dim strv As String = con.SqlDs(selacct).Tables(0).Rows(0).Item(0)
                            Dim Dstring1 As String = "SELECT subbranchcode FROM tbl_subbranch where Mbranchcode='" & strv & "' and node_id = " & Session("node_ID") & ""
                            If con.SqlDs(Dstring1).Tables(0).Rows.Count > 0 Then
                                Dim Dstring33 As String = "SELECT cast(ltrim(rtrim(subbranchcode)) as varchar) subbranchcode,subbranchname FROM tbl_subbranch where Mbranchcode='" & strv & "' and node_id = " & Session("node_ID") & ""
                                smartobj.loadComboValues("--Select a Sub-Branch--- ", Me.DrpSubBr1, Dstring33)
                                Me.DrpSubBr1.Visible = True
                            Else

                                Me.DrpSubBr1.Visible = False

                            End If
                        Else
                            selfind = "declare @retval int,@retmsg varchar(100) exec [proc_ValidOldGL] '" & Me.txtAcNumber.Text.Trim & "', " & Session("node_ID") & ",@retval output,@retmsg output select @retval,@retmsg"
                            For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                                retval = dr(0).ToString
                                retmsg = dr(1).ToString
                            Next

                            If retval = "0" Then
                                If retmsg <> "ok" Then
                                    ''smartobj.alertwindow(Me.Page, retmsg, "Prime")
                                    smartobj.ShowToast(Me.Page, ToastType.Warning, retmsg, "Oops!", ToastPosition.TopRight, True)

                                Else
                                    Me.txtAcNumber.Text = retmsg

                                End If
                            End If

                            Dim selacct2 As String = "select substring(glnumber,1,3),isnull(pointing,0) from tbl_bankgl where glnumber='" & Me.txtAcNumber.Text.Trim & "' and isnull(Blocked,0)<>1 and node_id = " & Session("node_ID") & ""
                            If con.SqlDs(selacct2).Tables(0).Rows.Count > 0 Then
                                accdetail1(Me.txtAcNumber.Text.Trim, 1)
                                Session("idcnt") = 1
                                Dim strv As String = con.SqlDs(selacct2).Tables(0).Rows(0).Item(0)
                                Dim point As String = con.SqlDs(selacct2).Tables(0).Rows(0).Item(1)



                                If point = "1" Then
                                    txtPaycode.Visible = True
                                    Me.Label20.Visible = True

                                    Session("pointingflag") = 1
                                    Me.Label19.Visible = True
                                    Me.txtPayAmount0.Visible = True
                                    Me.txtPayAmount0.ReadOnly = True
                                    Me.btnSubmit.Enabled = True
                                    Me.btnAppoff.Enabled = True
                                    Session("pointing") = Me.txtAcNumber.Text
                                    Session("paytype") = "D"
                                    detail()
                                Else
                                    ''Me.Label19.Visible = False
                                    ''Me.txtPayAmount0.Visible = False

                                    ''Me.txtPaycode.Visible = False
                                    '' Me.Label20.Visible = False
                                    Me.btnSubmit.Enabled = True
                                    Me.btnAppoff.Enabled = True

                                End If


                                Dim Dstring1 As String = "SELECT subbranchcode FROM tbl_subbranch where Mbranchcode='" & strv & "' and node_id = " & Session("node_ID") & ""
                                If con.SqlDs(Dstring1).Tables(0).Rows.Count > 0 Then
                                    Dim Dstring33 As String = "SELECT cast(ltrim(rtrim(subbranchcode)) as varchar) subbranchcode,subbranchname FROM tbl_subbranch where Mbranchcode='" & strv & "' and node_id = " & Session("node_ID") & ""
                                    smartobj.loadComboValues("--Select a Sub-Branch--- ", Me.DrpSubBr1, Dstring33)

                                    Me.DrpSubBr1.Visible = True
                                Else
                                    Me.DrpSubBr1.Visible = False

                                End If


                                Dim selacct3 As String = "select glnumber from tbl_bankgl where gl_classcode >70000 and isnull(Blocked,0)<>1 and node_id = " & Session("node_ID") & ""
                                'If con.SqlDs(selacct3).Tables(0).Rows.Count > 0 Then

                                '    Dim sbu As String = "select isnull(POSTSBU,0) from tbl_bank and node_id = " & Session("node_ID") & ""
                                '    Dim sbuacct As String = con.SqlDs(sbu).Tables(0).Rows(0).Item(0).ToString

                                '    If sbuacct = "1" Then
                                '        Me.DrpSubBr1.Visible = True
                                '    Else
                                '        Me.DrpSubBr1.Visible = False
                                '    End If

                                'End If

                            Else
                                ''smartobj.alertwindow(Me.Page, "Error: Either GL OR Customer Account Does Not Exist OR Posting Not Allowed On Account", "Prime")

                                smartobj.ShowToast(Me.Page, ToastType.Warning, "Error: Either GL OR Customer Account Does Not Exist OR Posting Not Allowed On Account", "Oops!", ToastPosition.TopRight, True)


                                Me.DrpSubBr1.Visible = False

                                Exit Sub
                            End If

                        End If

                        Me.txtAccountNo2.Focus()
                    Catch ex As Exception
                        logger.Info("BANKING OPERATION: TRANSFERS ACCT NUMBER TEXT CHANGED'" _
            & vbNewLine & "   <<<<Direction: OUTPUT" _
            & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
            & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
            & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
            & vbNewLine & "*******************************************************************************************************************************************************************")
                    End Try
                End If
            Else
                ''   smartobj.alertwindow(Me.Page, "You Do Not Have Posting Right", "Prime")
                smartobj.ShowToast(Me.Page, ToastType.Warning, "You Do Not Have Posting Right", "Oops!", ToastPosition.TopRight, True)

                smartobj.ClearWebPage(Me.Page)
                txtAcNumber.Enabled = True
                HyperLink1.Enabled = True
                Exit Sub
            End If
        ElseIf Me.DropMode.SelectedValue = 2 Then
            UploadEvidence.Visible = True
            txtAcNumber.Enabled = True
            HyperLink1.Enabled = True
            Panel1.Visible = False
            Debit_Details.Visible = True
            txtAcNumber.Text = ""
            Label1.Text = String.Empty
            Label2.Text = String.Empty
            Label3.Text = String.Empty
            Label4.Text = String.Empty
            Label5.Text = String.Empty
            Label6.Text = String.Empty
            Label7.Text = String.Empty
            Label8.Text = String.Empty
            Label9.Text = String.Empty
        ElseIf Me.DropMode.SelectedValue = 3 Then
            UploadEvidence.Visible = True
            txtAcNumber.Enabled = True
            HyperLink1.Enabled = True
            Panel1.Visible = False
            Debit_Details.Visible = True
            txtAcNumber.Text = ""
            Label1.Text = String.Empty
            Label2.Text = String.Empty
            Label3.Text = String.Empty
            Label4.Text = String.Empty
            Label5.Text = String.Empty
            Label6.Text = String.Empty
            Label7.Text = String.Empty
            Label8.Text = String.Empty
            Label9.Text = String.Empty
        End If
    End Sub
End Class


