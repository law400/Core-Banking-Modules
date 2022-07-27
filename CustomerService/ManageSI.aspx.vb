Imports System.Web.UI.WebControls
Imports log4net
Imports log4net.Config

Partial Class CustomerService_ManageSI
    Inherits SessionCheck
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(CustomerService_ManageSI))
    Protected Sub Menu1_MenuItemClick(ByVal sender As Object, _
                  ByVal e As MenuEventArgs) Handles Menu1.MenuItemClick
        Try
            Dim i As Integer
            For i = 0 To Menu1.Items.Count - 1
                If i = e.Item.Value Then
                    Menu1.Items(i).ImageUrl = "~/Images/pic2.gif"
                Else
                    Menu1.Items(i).ImageUrl = "~/Images/pic1.gif"
                End If
            Next

            If e.Item.Text = "Add SI" Then
                showadd()
            ElseIf e.Item.Text = "Remove SI" Then

                showedit()

            End If
        Catch ex As Exception
            logger.Info("CUSTOMER SERVICE: ManageSI Menu1_MenuItemClick" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

            smartobj.alertwindow(Me.Page, "Error has Occurred", "Prime")
            'smartobj.alertwindow(Me.Page, "Data Server Error....", "Prime")
        End Try
    End Sub

    Sub showadd()
        Me.btnSubmit.Text = "Submit"
        smartobj.ClearWebPage(Me.Page)
        btnSubmit.Enabled = True
        Me.DrpSerial.Visible = False
        Me.txtSeqNo.Visible = True
    End Sub
    Sub showedit()
        Me.btnSubmit.Text = "Remove"
        smartobj.ClearWebPage(Me.Page)
        btnSubmit.Enabled = True
        Me.DrpSerial.Visible = True
        Me.txtSeqNo.Visible = False


    End Sub

    Protected Sub Btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSubmit.Click
        Try
            If Me.txtAcNumber.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Account Number", "Prime")
                Exit Sub
            End If

            If Me.txtAccountNo2.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Account Number", "Prime")
                Exit Sub
            End If
            If Me.txtStartdate.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter a Value Date", "Prime")
                Exit Sub
            End If

            If Me.txtAccountNo2.Text.Trim = Me.txtAcNumber.Text.Trim Then
                smartobj.alertwindow(Me.Page, "Standing Instruction Cannot attached on the same Account", "Prime")
                Exit Sub
            End If
            If Me.txtNaration.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Posting Narration", "Prime")
                Exit Sub
            End If

            If Me.txtPayAmount.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Posting amount", "Prime")
                Exit Sub
            End If

            Dim ans1, ans2 As String
            ' Dim userid As String = Session("Userid").ToString

            If txtStartdate.Text <> "" Then
                Try
                    ans1 = CDate(txtStartdate.Text.Trim)

                Catch ex As Exception
                    logger.Info("CUSTOMER SERVICE: ManageSI Btnsubmit_Click: TxtStartDate.Text" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

                    smartobj.alertwindow(Me.Page, "Date Format Not supported", "Prime")
                    Exit Sub
                End Try

            Else
                smartobj.alertwindow(Me.Page, "Enter Start Date", "Prime")
                Exit Sub
            End If

            If txtEnddate.Text <> "" Then
                Try
                    ans2 = CDate(txtEnddate.Text.Trim)
                Catch ex As Exception
                    logger.Info("CUSTOMER SERVICE: ManageSI Btnsubmit_Click: TxtEnddate.Text" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

                    smartobj.alertwindow(Me.Page, "Date Format Not supported", "Prime")
                    Exit Sub
                End Try

            Else
                smartobj.alertwindow(Me.Page, "Enter End Date", "Prime")
                Exit Sub
            End If

            '' ''If Format(CDate(ans1), "MM-dd-yyyy") > Format(CDate(ans2), "MM-dd-yyyy") Then
            '' ''    smartobj.alertwindow(Me.Page, "Start Date Must be Less than End Date", "Prime")
            '' ''    Exit Sub
            '' ''End If

            If Not IsNumeric(txtPayAmount.Text) Or Val(txtPayAmount.Text) < 0 Then
                smartobj.alertwindow(Me.Page, "Hold Amount Amount must be numeric", "Prime")
                Exit Sub
            End If

            If Me.btnSubmit.Text = "Submit" Then
                qry = "declare @retVal int,@retMsg varchar(100) execute Proc_InsaddSI '" & Me.txtAcNumber.Text & "','" & Me.txtAccountNo2.Text & "','" & Me.RDList.SelectedValue.Trim & "'," & CDec(Me.txtPayAmount.Text.Trim) & "," & CInt(Me.txtSeqNo.Text.Trim) & ",'" & Format(CDate(ans1), "MM-dd-yyyy") & "','" & Format(CDate(ans2), "MM-dd-yyyy") & "','" & Me.txtNaration.Text.Trim & "','" & Me.DDaccrualfreq.SelectedValue.Trim & "','" & Session("Userid").ToString & "',NULL,@retVal OUTPUT,@retMsg OUTPUT," & Session("node_ID") & " select @retVal,@retMsg"
            ElseIf Me.Menu1.SelectedValue = "1" Then
                qry = "declare @retVal int,@retMsg varchar(100) execute Proc_InsRemSI '" & Me.txtAcNumber.Text & "','" & Me.txtAccountNo2.Text & "'," & CInt(Me.DrpSerial.SelectedValue.Trim) & ",'" & Me.DDaccrualfreq.SelectedValue & "','" & Session("Userid").ToString & "',NULL,@retVal OUTPUT,@retMsg OUTPUT, " & Session("node_ID") & " select @retVal,@retMsg"

            End If

            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            Me.btnSubmit.Enabled = False
            clear()
            smartobj.alertwindow(Me.Page, retmsg, "Prime")
            smartobj.ClearWebPage(Me.Page)

        Catch ex As Exception

            logger.Info("CUSTOMER SERVICE: ManageSI Btnsubmit_Click" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

            smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")

        End Try
    End Sub
    Sub clear()
        Me.txtAccountNo2.Text = ""
        Me.txtAcNumber.Text = ""
        Me.txtEnddate.Text = ""
        Me.txtNaration.Text = ""
        Me.txtPayAmount.Text = ""
        Me.txtRate.Text = ""
        Me.txtSeqNo.Text = ""
        Me.txtStartdate.Text = ""
        Me.txtTransAmount.Text = ""

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
        Label19.Text = String.Empty
        Label20.Text = String.Empty
        txtAcNumber.Focus()
    End Sub
    Sub selExistw()
        Try
            DrpSerial.Items.Clear()
            Dim app As String = ""
            DrpSerial.Items.Add(" ")
            Dim selacct As String = "Select count(1) from tbl_SITrans where fromaccountnumber='" & Me.txtAcNumber.Text.Trim & "' and toaccountnumber='" & Me.txtAccountNo2.Text.Trim & "' and status=1 and node_id = " & Session("node_ID") & ""

            If con.SqlDs(selacct).Tables(0).Rows.Count > 0 Then
                Dim dr1 As Data.DataRow
                dr1 = con.SqlDs(selacct).Tables(0).Rows(0)
                If dr1.Item(0) > 0 Then
                    If Me.Menu1.SelectedItem.Text = "Add SI" Then
                        Dim dr2 As Data.DataRow
                        dr2 = con.SqlDs(selacct).Tables(0).Rows(0)
                        Dim val As Integer = dr2.Item(0).ToString
                        Me.txtSeqNo.Text = val + 1
                        Me.DrpSerial.Visible = False
                        Me.txtSeqNo.Visible = True
                        Me.btnSubmit.Text = "Submit"

                    Else
                        Dim seltyp As String = "Select Sinumber from tbl_SITrans where fromaccountnumber='" & Me.txtAcNumber.Text.Trim & "' and toaccountnumber='" & Me.txtAccountNo2.Text.Trim & "' and status=1 and node_id = " & Session("node_ID") & ""

                        For Each dr As Data.DataRow In con.SqlDs(seltyp).Tables(0).Rows
                            DrpSerial.Items.Add(dr!Sinumber.ToString)
                        Next
                        Me.DrpSerial.Visible = True
                        Me.txtSeqNo.Visible = False
                        Me.btnSubmit.Text = "Remove"

                    End If
                Else
                    Me.DrpSerial.Visible = False
                    Me.txtSeqNo.Visible = True
                    Me.txtSeqNo.Text = 1
                End If
            End If
        Catch ex As Exception

            logger.Info("CUSTOMER SERVICE: ManageSI  Sub selExistw" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

            smartobj.alertwindow(Me.Page, "Error has Occurred", "Prime")
        End Try
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = ""
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "STANDING INSTRUCTION" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim

        Dim menuname As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("lbldisplay"), System.Web.UI.WebControls.Label)

        menuname.Text = Request.QueryString("XXX")
        If menuname.Text = "" Then
            Response.Redirect("~/Unauthorize.aspx")
        End If

        If Validate_Access(menuname.Text) = 0 Then
            Response.Redirect("~/Unauthorize.aspx")
        End If
        hypAccount.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtAcNumber.ClientID.ToString() + "');"
        HyperLink2.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtAccountNo2.ClientID.ToString() + "');"
        hypValueDate.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtStartdate.ClientID.ToString() + "');"
        Me.HyperLink1.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtEnddate.ClientID.ToString() + "');"

        If Page.IsPostBack = False Then


            Dim Dstring As String = "SELECT cast(ltrim(rtrim(freqcode)) as varchar) freqcode,freqname FROM tbl_frequency"
            smartobj.loadComboValues("--Choose a Frequency--- ", Me.DDaccrualfreq, Dstring)

            selcurrency()
            txtStartdate.Text = Format(CDate(Session("sysdate")), "dd/MM/yyyy")

            Dim Dstring7 As String = "SELECT cast(ltrim(rtrim(countrycode)) as varchar) countrycode,currencymne FROM tbl_country where status=1"
            smartobj.loadComboValues("--Select a Currecy--- ", Me.drpCurrency, Dstring7)
        End If
    End Sub
    Protected Sub txtPayAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPayAmount.TextChanged
        Try
            txtPayAmount.Text = smartobj.FormatMoney(txtPayAmount.Text)
            txtTransAmount.Text = CInt(txtRate.Text.Trim) * CDec(txtPayAmount.Text.Trim)
            txtTransAmount.Text = smartobj.FormatMoney(txtTransAmount.Text)
        Catch ex As Exception
            logger.Info("CUSTOMER SERVICE: ManageSI txtPayAmount_TextChanged" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")


            smartobj.alertwindow(Me.Page, "Invalid Amount Specified", "Halt")
        End Try
    End Sub
    Sub selcurrency()
        Try
            Dim Lock As Integer
            qry = "Select lockcurrency,country from tbl_bank where node_id = " & Session("node_ID") & ""
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
            logger.Info("CUSTOMER SERVICE: ManageSI Sub selcurrency" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

            smartobj.alertwindow(Me.Page, "Error has Occurred", "Prime")
        End Try
    End Sub


    Protected Sub DrpSerial_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpSerial.SelectedIndexChanged


    End Sub

    Protected Sub BtnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Try
            smartobj.ClearWebPage(Me.Page)
            Me.btnSubmit.Enabled = True
            clear()
        Catch ex As Exception
            logger.Info("CUSTOMER SERVICE: ManageSI BtnReset_Click" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

            smartobj.alertwindow(Me.Page, "Error has Occurred", "Prime")
        End Try
    End Sub

    'Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
    '    Try
    '        Response.Redirect("Default.aspx")
    '    Catch ex As Exception

    '    End Try
    'End Sub


    Protected Sub RDList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RDList.SelectedIndexChanged
        Try
            If Me.RDList.SelectedValue = 1 Then
                Me.txtPayAmount.Text = ""
                Me.txtPayAmount.ReadOnly = False
            Else
                Me.txtPayAmount.Text = Me.txtSI.Text
                Me.txtPayAmount.ReadOnly = True
            End If
        Catch ex As Exception

            logger.Info("CUSTOMER SERVICE: ManageSI RDList_SelectedIndexChanged" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

            smartobj.alertwindow(Me.Page, "Error has Occurred", "Prime")
        End Try
    End Sub

    Protected Sub txtAcNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcNumber.TextChanged
        Try

            Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtAcNumber.Text.Trim & "',@retval output,@retmsg output, " & Session("node_ID") & " select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            If retval = "0" Then
                Me.txtAcNumber.Text = retmsg
            End If

            Dim selExist As String = "Exec Proc_CustAcctDetail '" & Me.txtAcNumber.Text.Trim & "', " & Session("node_ID") & ""
            If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then
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
                Me.Label4.Text = drx.Item("bkbal").ToString
                Me.Label5.Text = drx.Item("effbal").ToString
                Me.Label6.Text = drx.Item("usebal").ToString
                Me.Label7.Text = drx.Item("acctty").ToString
                Me.Label8.Text = drx.Item("source").ToString
                Me.Label9.Text = drx.Item("acctstatus").ToString
                Me.txtSI.Text = drx.Item("SI Floor").ToString
                Dim prostatus As String = drx.Item("prodstatus").ToString
                Dim prodesc As String = drx.Item("proddesc").ToString
                Dim si As String = drx.Item("Allow SI").ToString

                If Me.Label9.Text <> "Active" Then
                    Me.Label9.BackColor = Drawing.Color.Red
                Else
                    Me.Label9.BackColor = Drawing.Color.Orange
                    Me.Label9.ForeColor = Drawing.Color.Blue

                End If

                If si <> "1" Then
                    smartobj.alertwindow(Me.Page, "Standing Instruction is not Permitted On this Product Account", "Prime")
                    Me.txtAcNumber.Text = ""
                    Exit Sub
                End If
                Dim idimg As String = drx.Item("customerid").ToString.Trim

                'Image1.Visible = True
                'Image1.ImageUrl = FormatURL(idimg)

                If prostatus = "1" Then
                    smartobj.alertwindow(Me.Page, prodesc, "Prime")
                    Me.btnSubmit.Enabled = False
                Else
                    Me.btnSubmit.Enabled = True
                End If
                ' selcurrency()
                selExistw()
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
                smartobj.alertwindow(Me.Page, "Account Number Does Not Exist", "Prime")

                Exit Sub
            End If

        Catch ex As Exception

            logger.Info("CUSTOMER SERVICE: ManageSI txtAcNumber_TextChanged" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

            smartobj.alertwindow(Me.Page, "Error has Occurred", "Prime")
        End Try
    End Sub

    Protected Sub txtAccountNo2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountNo2.TextChanged
        Try
            Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtAcNumber.Text.Trim & "',@retval output,@retmsg output, " & Session("node_ID") & " select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            If retval = "0" Then
                Me.txtAcNumber.Text = retmsg
            End If

            Dim selExist As String = "Exec Proc_CustAcctDetail '" & Me.txtAccountNo2.Text.Trim & "', " & Session("node_ID") & ""
            If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then
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
                Me.Label13.Text = drx.Item("bkbal").ToString
                Me.Label14.Text = drx.Item("effbal").ToString
                Me.Label15.Text = drx.Item("usebal").ToString
                Me.Label16.Text = drx.Item("acctty").ToString
                Me.Label17.Text = drx.Item("source").ToString
                Me.Label18.Text = drx.Item("acctstatus").ToString
                Dim prostatus As String = drx.Item("prodstatus").ToString
                Dim prodesc As String = drx.Item("proddesc").ToString

                Dim idimg As String = drx.Item("customerid").ToString.Trim

                If Me.Label18.Text <> "Active" Then
                    Me.Label18.BackColor = Drawing.Color.Red
                Else
                    Me.Label18.BackColor = Drawing.Color.Orange
                    Me.Label18.ForeColor = Drawing.Color.Blue

                End If

                'Image1.Visible = True
                'Image1.ImageUrl = FormatURL(idimg)

                If prostatus = "1" Then
                    smartobj.alertwindow(Me.Page, prodesc, "Prime")
                    Me.btnSubmit.Enabled = False
                Else
                    Me.btnSubmit.Enabled = True
                End If
                selcurrency()
                selExistw()

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
                smartobj.alertwindow(Me.Page, "Account Number Does Not Exist", "Prime")

                Exit Sub
            End If
        Catch ex As Exception
            logger.Info("CUSTOMER SERVICE: ManageSI txtAccountNo2_TextChanged" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

            smartobj.alertwindow(Me.Page, "Error has Occurred", "Prime")
        End Try
    End Sub
End Class
