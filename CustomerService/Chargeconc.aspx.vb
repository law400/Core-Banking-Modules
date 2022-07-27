Imports System.Web.UI.WebControls
Partial Class CustomerService_Chargeconc
    Inherits SessionCheck
#Region "Task"
    Protected Sub txtPayAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPayAmount.TextChanged
        Try
            txtPayAmount.Text = smartobj.FormatMoney(txtPayAmount.Text)
         
        Catch ex As Exception
            smartobj.alertwindow(Me.Page, "Invalid Amount Specified", "Halt")
        End Try
    End Sub
    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        Response.Redirect("~/home.aspx")
    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try
            If Me.txtTellerNo.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Teller No", "Prime")
                Exit Sub
            End If

            If Me.txtAcNumber.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Account Number", "Prime")
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


        Catch ex As Exception

        End Try

    End Sub
    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Try
            smartobj.ClearWebPage(Me.Page)
            Me.btnSubmit.Enabled = True
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

                If Me.Label9.Text <> "Active" Then
                    Me.Label9.BackColor = Drawing.Color.Red
                Else
                    Me.Label9.BackColor = Drawing.Color.Blue

                End If

                Dim prostatus As String = drx.Item("prodstatus").ToString
                Dim prodesc As String = drx.Item("proddesc").ToString

                Dim idimg As String = drx.Item("customerid").ToString.Trim

                'Image1.Visible = True
                'Image1.ImageUrl = FormatURL(idimg)
                Me.txtNaration.Text = "C/D In Favour Of: " & Me.Label1.Text & " Paid in By Self"

                If prostatus = "1" Then
                    smartobj.alertwindow(Me.Page, prodesc, "Prime")
                    Me.btnSubmit.Enabled = False
                Else
                    Me.btnSubmit.Enabled = True
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
        hypAccount.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtAcNumber.ClientID.ToString() + "');"

        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = "CUSTOMER SERVICE"
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        If Page.IsPostBack = False Then
            Try

                Dim qry As String = "select cast(sys_date as datetime)sys_date,sys_phase from tbl_system"
                For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                    latesttime = Format(CDate(dr!sys_date), "dd/MM/yyyy")
                Next

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
            Dim Dstring7 As String = "SELECT cast(ltrim(rtrim(chargecode)) as varchar) chargecode,chargedesc FROM tbl_charges where status=1"
            smartobj.loadComboValues("--Select Charge Type--- ", Me.drpchargetype, Dstring7)

        End If
    End Sub


#End Region

   
End Class
