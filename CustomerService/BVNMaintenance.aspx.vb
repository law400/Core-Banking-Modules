Imports System.Web.UI.WebControls
Partial Class BVNMaintenance
    Inherits SessionCheck
    Private retmsg As String = ""
    Private retval As Integer
    Private Bsubmit As Boolean
    'Private post As String
    'Private lst As New Collection
#Region "Task"

    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        Response.Redirect("~/home.aspx")
    End Sub
    Sub till()
        Dim strTill As String = "Exec [proc_tellerBalance] '" & Session("Userid").ToString.Trim & "'"
        'Me.GridView1.DataSource = con.SqlDs(strTill).Tables(0)
        'Me.GridView1.DataBind()
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try
            If Bsubmit = False Then
                Bsubmit = True
                'Me.btnSubmit.Enabled = False

                If Me.txtAcNumber.Text = "" Then
                    smartobj.alertwindow(Me.Page, "Enter Account number", "Prime")
                    Exit Sub
                End If

                If Me.txtBVNNumber.Text = "" Then
                    smartobj.alertwindow(Me.Page, "Enter BVN", "Prime")
                    Exit Sub
                End If

                If Not IsNumeric(Me.txtBVNNumber.Text) Then
                    smartobj.alertwindow(Me.Page, "BVN Must Be Numeric ", "Prime")
                    Exit Sub
                End If
                If Me.txtAcNumber.Text = "" Then
                    smartobj.alertwindow(Me.Page, "Enter Account Number", "Prime")
                    Exit Sub
                End If

                'If Me.txtValueDate.Text = "" Then
                '    smartobj.alertwindow(Me.Page, "Enter a Value Date", "Prime")
                '    Exit Sub
                'End If

                'latesttime = CDate(Me.txtValueDate.Text)
                'If IsDate(latesttime) Then
                '    latesttime = latesttime.AddHours(Now.Hour)
                '    latesttime = latesttime.AddMinutes(Now.Minute)
                '    latesttime = latesttime.AddSeconds(Now.Second)
                'End If

                'Dim overline As String = ""
                'Dim overlineid As String = ""

                'If Session("overide") = "1" Then
                '    If Session("valid") <> "0" Then
                '        smartobj.alertwindow(Me.Page, "Transaction Was Not Override. Please Re-Post Transaction", "Prime")
                '        smartobj.ClearWebPage(Me.Page)
                '        Exit Sub
                '    Else
                '        overline = Session("overide")
                '        overlineid = Session("overideid")
                '    End If

                'Else
                '    overline = 0
                '    overlineid = 0
                'End If

                Dim dateTime As System.DateTime


                If (Me.txtValueDate.Text.Trim()) = "" Then
                    dateTime = "1900-01-01"
                Else
                    dateTime = Convert.ToDateTime(Me.txtValueDate.Text.Trim())
                End If

                qry = "Declare @retval int,@behav int,@retmsg varchar(100) exec Proc_InsBVN '" & Me.txtAcNumber.Text.Trim & "'," &
                "'" & Me.txtBVNNumber.Text.Trim & "'," &
                "'" & Strings.Format(dateTime, "MM/dd/yyyy hh:mm:ss") & "','" & Session("Userid").Trim & "',NULL," &
                "@retval output,@retmsg output select @retval ,@retmsg"


                ''qry = "Declare @retval int,@retmsg varchar(100) exec Proc_InsertCASA '" & glnumber & "'," & _
                ''"'" & Me.txtAcNumber.Text.Trim & "','" & CDbl(Me.txtTransAmount.Text.Trim) & "','" & "001" & "'," & _
                ''"'" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "',null,'" & Session("Userid").Trim & "',null,'" & Me.txtNaration.Text.Trim & "'," & _
                ''"'" & Me.drpCurrency.SelectedValue.Trim & "'," & CInt(Me.txtRate.Text.Trim) & ",'" & Me.txtTellerNo.Text.Trim & "'," & _
                ''"null,null,null,NULL,@retVal output,@retmsg output select @retval ,@retmsg"

                For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                    retval = dr(0).ToString
                    retmsg = dr(1).ToString
                Next

                'If behav = 2

                If retval = 0 Then

                    Me.btnSubmit.Enabled = False
                    Me.btnUpdate.Enabled = False

                    'Prompt
                    smartobj.alertwindow(Me.Page, retmsg, "Prime")
                    smartobj.ClearWebPage(Me.Page)
                Else
                    'Me.btnSubmit.Enabled = True
                    'Prompt
                    smartobj.alertwindow(Me.Page, retmsg, "Prime")
                    smartobj.ClearWebPage(Me.Page)
                End If

                Session("overide") = ""
                Session("overideid") = ""
                Session("valid") = ""

                Bsubmit = False

            End If

        Catch ex As Exception
            smartobj.alertwindow(Me.Page, retmsg, "Prime")

        End Try

    End Sub
    Sub clear()
        retval = -1
        retmsg = ""
        Me.txtAcNumber.Text = ""
        Me.txtValueDate.Text = ""
        Me.txtBVNNumber.Text = ""
        Me.HypAuth.Visible = False
        'loaddate()
    End Sub
    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Try
            Bsubmit = False
            clear()
            Session("overide") = ""
            Session("overideid") = ""
            Session("valid") = ""

            Me.btnAppoff.Enabled = True
            ''smartobj.ClearWebPage(Me.Page)
            Me.btnSubmit.Enabled = False
            Me.btnUpdate.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    'Protected Sub txtTellerNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTellerNo.TextChanged
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
    Protected Sub txtAcNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcNumber.TextChanged
        Try
            Session("Custchg1") = ""
            'post = Guid.NewGuid.ToString
            'Dim xItem As New ListItem
            'xItem.Text = post

            Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtAcNumber.Text.Trim & "',@retval output,@retmsg output select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            If retval = "0" Then
                Me.txtAcNumber.Text = retmsg
            End If

            Dim selExist As String = "Exec Proc_CustAcctDetail '" & Me.txtAcNumber.Text.Trim & "'"
            If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then
                'Dim seltyp As String = "Select apptype from tbl_bankproduct a,tbl_casaaccount b where a.productcode=b.productcode and b.accountnumber='" & Me.txtAcNumber.Text.Trim & "'"
                'For Each dr As Data.DataRow In con.SqlDs(seltyp).Tables(0).Rows
                '    app = dr!apptype.ToString.Trim
                'Next
                'If app = "CK" Then
                '    smartobj.alertwindow(Me.Page, "Transaction is Not Allowed On Checking Account.", "Prime")
                '    Exit Sub
                'End If
                Session("Custchg1") = Me.txtAcNumber.Text.Trim
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
                Me.Label10.Text = drx.Item("TotalCharge").ToString
                Me.txtBVNNumber.Text = drx.Item("TotalCharge").ToString

                'Me.Label11.Text = drx.Item("Phone").ToString

                If Me.Label9.Text <> "Active" Then
                    Me.Label9.BackColor = Drawing.Color.Red
                Else
                    Me.Label9.BackColor = Drawing.Color.Orange
                    Me.Label9.ForeColor = Drawing.Color.Blue

                End If

                Dim prostatus As String = drx.Item("prodstatus").ToString
                Dim prodesc As String = drx.Item("proddesc").ToString

                Dim idimg As String = drx.Item("customerid").ToString.Trim

                'Image1.Visible = True
                'Image1.ImageUrl = FormatURL(idimg)

                If prostatus = "1" Then
                    smartobj.alertwindow(Me.Page, prodesc, "Prime")
                    Me.btnSubmit.Enabled = False
                    Me.btnUpdate.Enabled = False
                    Me.btnAppoff.Enabled = False

                Else
                    Me.btnAppoff.Enabled = True
                    'Me.btnSubmit.Enabled = True
                End If

                'ENABLE / DISABLE submit or update button depending on if BVN Label is populated or not
                If Label10.Text <> "" Then
                    Me.btnSubmit.Enabled = False
                    Me.btnUpdate.Enabled = True
                Else
                    Me.btnSubmit.Enabled = True
                    Me.btnUpdate.Enabled = False
                End If
            Else
                Me.Label1.Text = ""
                Me.Label2.Text = ""
                Me.Label3.Text = ""
                Me.Label4.Text = ""
                Me.Label5.Text = ""
                Me.Label6.Text = ""
                Me.Label7.Text = ""
                Me.Label8.Text = ""
                Me.Label9.Text = ""
                'Image1.Visible = False
                smartobj.alertwindow(Me.Page, "Account Number Does Not Exist", "Prime")

                Exit Sub
            End If

            Dim selex As String = "Delete from tbl_postlog where accountno='" & Me.txtAcNumber.Text.Trim & "'"
            con.SqlDs(selex)

        Catch ex As Exception

        End Try
    End Sub

    Function FormatURL(ByVal strArgument As String) As String
        Return ("~/Customerservice/getimg.aspx?id=" & strArgument)
    End Function
#End Region

#Region "Declaration"
    Dim qry As String = ""
    Dim anx As Date
    Dim glnumber As String = ""
#End Region
#Region "PageLoad"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'LnkCharge.NavigateUrl = "javascript:Chgdetail('document.aspnetForm." + txtNoRow.ClientID.ToString() + "');"
        'LnkCharge0.NavigateUrl = "javascript:acctdetail('document.aspnetForm." + txtNoRow.ClientID.ToString() + "');"

        hypValueDate.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtValueDate.ClientID.ToString() + "');"
        hypAccount.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtAcNumber.ClientID.ToString() + "');"
        txtNoRow.Text = 20
        HypAuth.NavigateUrl = "javascript:authPicker('document.aspnetForm." + txtNoRow.ClientID.ToString() + "');"

        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = "BANKING OPERATION"
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim


        If Page.IsPostBack = False Then
            Try
                Session("Custchg1") = ""
                till()

                If Session("valid") <> "0" Then
                    Me.btnAppoff.Enabled = True
                    Me.btnSubmit.Enabled = False
                    Me.btnUpdate.Enabled = False
                    Session("overide") = ""
                    Session("overideid") = ""
                    Session("valid") = ""

                Else
                    Me.btnAppoff.Enabled = False
                    'Me.btnSubmit.Enabled = True

                End If

                'loaddate()

            Catch
                smartobj.alertwindow(Me.Page, "Data Warnning error...", "Prime")
                Exit Sub
            End Try
            'If IsDate(latesttime) Then
            '    'latesttime = latesttime.AddHours(Now.Hour)
            '    'latesttime = latesttime.AddMinutes(Now.Minute)
            '    'latesttime = latesttime.AddSeconds(Now.Second)
            '    latesttime = Format(CDate(latesttime.Date), "dd/MM/yyyy")
            'End If

            'Dim Dstring7 As String = "SELECT cast(ltrim(rtrim(countrycode)) as varchar) countrycode,currencymne FROM tbl_country where status=1"
            'smartobj.loadComboValues("--Select a Currecy--- ", Me.drpCurrency, Dstring7)
        End If
    End Sub

    'Sub loaddate()
    '    Dim qry As String = "select cast(sys_date as datetime)sys_date,sys_phase from tbl_system"
    '    For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
    '        latesttime = Format(CDate(dr!sys_date), "dd/MM/yyyy")
    '    Next
    '    Me.txtValueDate.Text = latesttime
    'End Sub
#End Region

    'Protected Sub btnAppoff_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAppoff.Click
    '    Try
    '        If Me.txtAcNumber.Text = "" Then
    '            smartobj.alertwindow(Me.Page, "Enter Account number", "Prime")
    '            Exit Sub
    '        End If

    '        If Me.txtBVNNumber.Text = "" Then
    '            smartobj.alertwindow(Me.Page, "Enter BVN", "Prime")
    '            Exit Sub
    '        End If

    '        latesttime = CDate(Me.txtValueDate.Text)
    '        If IsDate(latesttime) Then
    '            latesttime = latesttime.AddHours(Now.Hour)
    '            latesttime = latesttime.AddMinutes(Now.Minute)
    '            latesttime = latesttime.AddSeconds(Now.Second)
    '        End If
    '        Dim branchcode As String
    '        Dim selacc As String = "Select branchcode,postGl_Acctno from tbl_UserProfile where userid='" & Session("Userid").Trim & "'"
    '        If con.SqlDs(selacc).Tables(0).Rows.Count > 0 Then
    '            drx = con.SqlDs(selacc).Tables(0).Rows(0)
    '            glnumber = drx.Item("postGl_Acctno").ToString.Trim
    '            branchcode = drx.Item("branchcode").ToString.Trim

    '            If glnumber = "" Then
    '                smartobj.alertwindow(Me.Page, "You Do Not Have Posting Right Account number", "Prime")
    '                Exit Sub
    '            End If

    '        Else
    '            smartobj.alertwindow(Me.Page, "You Do Not Have Posting Right", "Prime")
    '            smartobj.ClearWebPage(Me.Page)
    '            Exit Sub
    '        End If
    '        Dim overline As String = Session("overide")
    '        If overline = "" Then
    '            overline = 0
    '        End If

    '        'qry = "Declare @retval int,@retmsg varchar(100) exec Proc_InsAuthTran '" & glnumber & "'," & _
    '        ' "'" & Me.txtAcNumber.Text.Trim & "'," & CDbl(Me.txtTransAmount.Text.Trim) & ",'" & "516" & "','" & "001" & "'," & _
    '        ' "'" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "','" & Session("Userid").Trim & "',null,'" & branchcode & "','" & Me.txtNaration.Text.Trim.Replace("'", "") & "','" & "0" & "'," & _
    '        ' "'" & Me.drpCurrency.SelectedValue.Trim & "','" & "2" & "','" & "1" & "'," & CInt(Me.txtRate.Text.Trim) & ",'" & Me.txtTellerNo.Text.Trim & "'," & _
    '        ' "null,null,null,null," & "1111" & ",null,'" & overline & "','" & "cash Deposit" & "',NULL,@retVal output,@retmsg output select @retval ,@retmsg"


    '        'For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
    '        '    retval = dr(0).ToString
    '        '    retmsg = dr(1).ToString
    '        'Next

    '        smartobj.alertwindow(Me.Page, retmsg, "Prime")
    '        Me.btnAppoff.Enabled = False
    '        clear()

    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As System.EventArgs) Handles btnUpdate.Click
        Try
            If Bsubmit = False Then
                Bsubmit = True
                'Me.btnSubmit.Enabled = False

                If Me.txtAcNumber.Text = "" Then
                    smartobj.alertwindow(Me.Page, "Enter Account number", "Prime")
                    Exit Sub
                End If

                If Me.txtBVNNumber.Text = "" Then
                    smartobj.alertwindow(Me.Page, "Enter BVN", "Prime")
                    Exit Sub
                End If

                If Not IsNumeric(Me.txtBVNNumber.Text) Then
                    smartobj.alertwindow(Me.Page, "BVN Must Be Numeric ", "Prime")
                    Exit Sub
                End If

                'If Me.txtValueDate.Text = "" Then
                '    smartobj.alertwindow(Me.Page, "Enter a Value Date", "Prime")
                '    Exit Sub
                'End If

                'latesttime = CDate(Me.txtValueDate.Text)
                'If IsDate(latesttime) Then
                '    latesttime = latesttime.AddHours(Now.Hour)
                '    latesttime = latesttime.AddMinutes(Now.Minute)
                '    latesttime = latesttime.AddSeconds(Now.Second)
                'End If

                'Dim overline As String = ""
                'Dim overlineid As String = ""

                'If Session("overide") = "1" Then
                '    If Session("valid") <> "0" Then
                '        smartobj.alertwindow(Me.Page, "Transaction Was Not Override. Please Re-Post Transaction", "Prime")
                '        smartobj.ClearWebPage(Me.Page)
                '        Exit Sub
                '    Else
                '        overline = Session("overide")
                '        overlineid = Session("overideid")
                '    End If

                'Else
                '    overline = 0
                '    overlineid = 0
                'End If

                Dim dateTime1 As System.DateTime

                If (Me.txtValueDate.Text.Trim()) = "" Then
                    dateTime1 = "1900-01-01"
                Else
                    dateTime1 = Convert.ToDateTime(Me.txtValueDate.Text.Trim())
                End If

                qry = "Declare @retval int,@behav int,@retmsg varchar(100) exec Proc_UpdBVN '" & Me.txtAcNumber.Text.Trim & "'," &
                "'" & Me.txtBVNNumber.Text.Trim & "'," &
                "'" & Strings.Format(dateTime1, "MM/dd/yyyy hh:mm:ss") & "','" & Session("Userid").Trim & "',NULL," &
                "@retval output,@retmsg output select @retval ,@retmsg"


                ''qry = "Declare @retval int,@retmsg varchar(100) exec Proc_InsertCASA '" & glnumber & "'," & _
                ''"'" & Me.txtAcNumber.Text.Trim & "','" & CDbl(Me.txtTransAmount.Text.Trim) & "','" & "001" & "'," & _
                ''"'" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "',null,'" & Session("Userid").Trim & "',null,'" & Me.txtNaration.Text.Trim & "'," & _
                ''"'" & Me.drpCurrency.SelectedValue.Trim & "'," & CInt(Me.txtRate.Text.Trim) & ",'" & Me.txtTellerNo.Text.Trim & "'," & _
                ''"null,null,null,NULL,@retVal output,@retmsg output select @retval ,@retmsg"

                For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                    retval = dr(0).ToString
                    retmsg = dr(1).ToString
                Next

                'If behav = 2

                If retval = 0 Then

                    Me.btnSubmit.Enabled = False
                    Me.btnUpdate.Enabled = False
                    'Prompt
                    smartobj.alertwindow(Me.Page, retmsg, "Prime")
                    smartobj.ClearWebPage(Me.Page)
                Else
                    'Me.btnSubmit.Enabled = True

                    'Prompt
                    smartobj.alertwindow(Me.Page, retmsg, "Prime")
                    smartobj.ClearWebPage(Me.Page)
                End If

                Session("overide") = ""
                Session("overideid") = ""
                Session("valid") = ""

                Bsubmit = False

            End If

        Catch ex As Exception
            smartobj.alertwindow(Me.Page, retmsg, "Prime")

        End Try
    End Sub
End Class
