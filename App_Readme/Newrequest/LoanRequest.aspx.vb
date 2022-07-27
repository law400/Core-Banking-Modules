Imports Telerik.Web.UI
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
'Imports System.Web.Mail
Imports System.Net.Mail.MailMessage
'Imports System.Net
Imports System.Net.Mail
Imports System.Web.Configuration
Imports System.Net.Configuration
Imports System.IO
Imports System.Security.Cryptography
Imports System
Imports System.Web.UI.WebControls

Partial Class LoanRequest
    Inherits System.Web.UI.Page
    Dim qry As String
    Dim StatusReg As Integer
    Dim RevID As String = ""
    Dim Txtemail As String = ""
    Dim FullName As String = ""
    Dim guarantorEmail As String = ""

    Sub BindToGrid()
        Try
            Dim Item As String = ""
            Dim status As String = "o"
            Item = "select * from tbl_M_loanApplication a ,tbl_bankproduct b  ,Tbl_guarantorsetup c ,Memcos_Reg_table d where a.productcode = b.ProductCode and a.productcode = c.ProductCode and  b.productcode = c.ProductCode and d.EmployeeID = a.Employeeid"
            Me.RadGrid1.DataSource = con.SqlDs(Item)
            Me.RadGrid1.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        BindToGrid()
    End Sub
    Protected Sub RadGrid1_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        BindToGrid()
    End Sub

    Protected Sub RadGrid1_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand

        'If e.CommandName = "mycommand" Then
        '    Panel6.Visible = True

        '    Image_add.Visible = True
        '    Image_update.Visible = False
        '    Image_cancel.Visible = True

        'End If

        If e.CommandName = "SelectData" Then

            Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
            'Get the primary key value using the DataKeyValue.
            Dim RevID As String = item.OwnerTableView.DataKeyValues(item.ItemIndex)("ID").ToString()


            Dim bindreg As String = "select * from tbl_M_loanApplication a, Memcos_Reg_table b  where a.ID = '" & RevID & "' and a.Employeeid =b.Employeeid"

            If con.SqlDs(bindreg).Tables(0).Rows.Count > 0 Then
                drx = con.SqlDs(bindreg).Tables(0).Rows(0)
                Label6.Text = drx.Item("EmployeeName").ToString
                Label7.Text = drx.Item("Accountnumber").ToString

                LblID.Text = RevID

                Me.Image1.ImageUrl = drx.Item("PictureUrl").ToString
                'RadListView2.DataSource = con.SqlDs(LoanReq)
                'RadListView2.DataBind()
                Panel6.Visible = True
                'Image_add.Visible = True
                'Image_update.Visible = False
                'Image_cancel.Visible = True
                BindToGrid()
                'Dim bindreg As String = ""
                'bindreg = "select * from Tbl_ItemRequest a, Memcos_Reg_table b  where a.ID = '" & RevID & "' and a.Employeeid =b.Employeeid"

                ''bindreg = "select * from Memcos_Reg_table where node_id= '" & Session("Node_id") & "' and EmployeeID='" & RevID & "'"
                ''RadListView2.DataSource = con.SqlDs(bindreg)
                ''RadListView2.DataBind()




            End If
        End If




        If e.CommandName = "ProcessData" Then

            Dim loanstatus As String = ""

            Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
            'Get the primary key value using the DataKeyValue.
            Dim RevID As String = item.OwnerTableView.DataKeyValues(item.ItemIndex)("ID").ToString()


            Dim bindreg As String = "select * from tbl_M_loanApplication a, Memcos_Reg_table b  where a.ID = '" & RevID & "' and a.Employeeid =b.Employeeid"

            If con.SqlDs(bindreg).Tables(0).Rows.Count > 0 Then
                drx = con.SqlDs(bindreg).Tables(0).Rows(0)

                loanstatus = drx.Item("status").ToString

                If loanstatus <> "Approved" Then
                    Panel2.Visible = True
                    Panel1.Visible = False
                    Label_error.Text = "This Loan is not approved by the Exco"
                    BindToGrid()
                    Exit Sub
                End If



                If loanstatus = "Approved" And Profile.Roleid = 1 Then
                    Response.Redirect("~/Loan/ApplyForLoan.aspx")

                Else
                    Panel2.Visible = True
                    Panel1.Visible = False
                    Label_error.Text = "You are not authorized to process this loan"
                    BindToGrid()
                    Exit Sub
                End If
               
              
                BindToGrid()
               


            End If
        End If

        If e.CommandName = "Delete" Then
            Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
            'Get the primary key value using the DataKeyValue.
            Dim RevID As String = item.OwnerTableView.DataKeyValues(item.ItemIndex)("ID").ToString()

            Dim deleteQuery As String = "DELETE from tbl_M_loanApplication where Id='" & RevID & "'"
            con.SqlDs(deleteQuery)

        End If

        If e.CommandName = "RebindGrid" Then
            'clear()
            'connect()
            RadGrid1.DataBind()
            Panel4.Visible = False
        End If
    End Sub

    'Protected Sub RadGrid1_DeleteCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.DeleteCommand
    '    'Get the GridDataItem of the RadGrid
    '    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
    '    'Get the primary key value using the DataKeyValue.
    '    Dim ID As String = item.OwnerTableView.DataKeyValues(item.ItemIndex)("ID").ToString()
    '    Try

    '        Dim deleteQuery As String = "DELETE from Tbl_ItemRequest where Id='" & ID & "'"
    '        con.SqlDs(deleteQuery)

    '    Catch ex As Exception

    '        RadGrid1.Controls.Add(New LiteralControl("Unable to delete record. Reason: " + ex.Message))
    '        e.Canceled = True

    '    End Try

    'End Sub



    Protected Sub AddItem_Click(sender As Object, e As EventArgs) Handles AddItem.Click
        Try

            Dim getstatus As String = ""


            Dim LoanReq As String = "select * from tbl_M_loanApplication where id = '" & LblID.Text & "'"
            If con.SqlDs(LoanReq).Tables(0).Rows.Count > 0 Then
                drx = con.SqlDs(LoanReq).Tables(0).Rows(0)
                Txtemail = drx.Item("Email").ToString
                getstatus = drx.Item("Status").ToString

            End If

            If getstatus = "Approved" Then


                Panel2.Visible = True
                Panel1.Visible = False
                Label_error.Text = "This request has already been approved"
                BindToGrid()
                Exit Sub
            End If


            If Profile.Roleid = 1 And getstatus = "Not Approve" Then
                Dim UpadteRecord As String = "Update tbl_M_loanApplication set status ='Verified'  where Id=  '" & LblID.Text & "'"
                con.SqlDs(UpadteRecord)

                BindToGrid()

            Else
                Panel2.Visible = True
                Panel1.Visible = False
                Label_error.Text = "This request can only be Verified by admin"

                BindToGrid()

                Exit Sub
            End If


            If Profile.Roleid = 2 And getstatus = "Verified" Then
                Dim UpadteRecord As String = "Update tbl_M_loanApplication set status ='Approved'  where Id=  '" & LblID.Text & "' "
                con.SqlDs(UpadteRecord)
                BindToGrid()
            Else
                Panel2.Visible = True
                Panel1.Visible = False
                Label_error.Text = "This request can only be Approved by the Execo"
                BindToGrid()
            End If
           


            Dim findifupdated As String = "select status from tbl_M_loanApplication where status ='Approved' and Id=  '" & LblID.Text & "'"
            If con.SqlDs(findifupdated).Tables(0).Rows.Count > 0 Then

                'SendEmail()

                Panel1.Visible = True
                Panel2.Visible = False
                Label_error.Visible = False
                Label_success.Visible = True
                Label_success.Text = "This request is Approved"
                BindToGrid()

            Else
                Panel2.Visible = False
                Label_success.Visible = False
                Panel1.Visible = True
                Label_error.Visible = True
                Label_success.Text = "Error: Please contact your cooperative"
                BindToGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Sub SendEmail()
        Try

            Dim GetCoopMail As String = ""

            Dim Coop_Email As String = ""
            guarantorEmail = Session("Email")

            Dim TenantName As String = ""
            'GetCoopPhone = "select b.phone from Tbl_Tenants  a , EmployeeOnlineReq b  where a.Node_id = '" & RadComboBox2.SelectedValue & "' and a.useremail = b.email "
            GetCoopMail = "select * from tbl_Bank"

            If con.SqlDs(GetCoopMail).Tables(0).Rows.Count > 0 Then
                'Label2.Visible = True
                'Label1.Visible = True
                drx = con.SqlDs(GetCoopMail).Tables(0).Rows(0)

                Coop_Email = drx!Email

                TenantName = drx!BankName

            End If

            Dim configurationFile As Configuration = WebConfigurationManager.OpenWebConfiguration("~/web.config")
            Dim mailSettings As MailSettingsSectionGroup = configurationFile.GetSectionGroup("system.net/mailSettings")
            Dim msg As New MailMessage()
            'msg.From = New MailAddress("noreply@infosightonline.com")
            msg.From = New MailAddress(mailSettings.Smtp.From)
            msg.To.Add(Txtemail)
            msg.CC.Add(Coop_Email)


            msg.Subject = "Loan Request Approval"

            msg.IsBodyHtml = True


            Dim body2 As String = "<b><u>Cooperative Mail Content</u> </b><br/> <br/>"

            'FullName = TxtFirstName.Text + "  " + TxtLastname.Text

            body2 += "Hello " + Label6.Text + " ,<br/><br/> "




            body2 = "This is to notify you that your request has  been approved <br/> <br/>"


            body2 += "Regards,<br/> "
            body2 += TenantName + " <br/> "
            msg.Body = body2


            Dim smtp1 As New SmtpClient() 'specify the mail server address
            smtp1.Credentials = New Net.NetworkCredential(mailSettings.Smtp.From, mailSettings.Smtp.Network.Password)
            smtp1.Host = mailSettings.Smtp.Network.Host
            smtp1.Port = mailSettings.Smtp.Network.Port
            smtp1.Timeout = 700000
            smtp1.Send(msg)
        Catch ex As Exception

        End Try
    End Sub



    Sub RejectSendEmail()
        Try

            Dim GetCoopMail As String = ""

            Dim Coop_Email As String = ""
            guarantorEmail = Session("Email")

            Dim TenantName As String = ""
            'GetCoopPhone = "select b.phone from Tbl_Tenants  a , EmployeeOnlineReq b  where a.Node_id = '" & RadComboBox2.SelectedValue & "' and a.useremail = b.email "
            GetCoopMail = "select * from tbl_Bank"

            If con.SqlDs(GetCoopMail).Tables(0).Rows.Count > 0 Then
                'Label2.Visible = True
                'Label1.Visible = True
                drx = con.SqlDs(GetCoopMail).Tables(0).Rows(0)

                Coop_Email = drx!Email

                TenantName = drx!BankName

            End If

            Dim configurationFile As Configuration = WebConfigurationManager.OpenWebConfiguration("~/web.config")
            Dim mailSettings As MailSettingsSectionGroup = configurationFile.GetSectionGroup("system.net/mailSettings")
            Dim msg As New MailMessage()
            'msg.From = New MailAddress("noreply@infosightonline.com")
            msg.From = New MailAddress(mailSettings.Smtp.From)
            msg.To.Add(Txtemail)
            msg.CC.Add(Coop_Email)


            msg.Subject = "Loan Request Approval"

            msg.IsBodyHtml = True


            Dim body2 As String = "<b><u>Cooperative Mail Content</u> </b><br/> <br/>"

            'FullName = TxtFirstName.Text + "  " + TxtLastname.Text

            body2 += "Hello " + Label6.Text + " ,<br/><br/> "




            body2 += TxtReason.Text + " <br/><br/> "


            body2 += "Regards,<br/> "
            body2 += TenantName + " <br/> "
            msg.Body = body2


            Dim smtp1 As New SmtpClient() 'specify the mail server address
            smtp1.Credentials = New Net.NetworkCredential(mailSettings.Smtp.From, mailSettings.Smtp.Network.Password)
            smtp1.Host = mailSettings.Smtp.Network.Host
            smtp1.Port = mailSettings.Smtp.Network.Port
            smtp1.Timeout = 700000
            smtp1.Send(msg)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ButCancel_Click(sender As Object, e As EventArgs) Handles ButCancel.Click
        'Me.Panel6.Visible = False
        Try

            Dim getstatus As String = ""
            TxtReason.Visible = True

            If TxtReason.Text = "" Then
                Panel2.Visible = True
                Panel1.Visible = False
                Label_error.Text = " Please add reason why you reject request "
                TxtReason.Focus()
                Exit Sub
            End If

            Dim Req As String = "select * from tbl_M_loanApplication where id = '" & LblID.Text & "'"
            If con.SqlDs(Req).Tables(0).Rows.Count > 0 Then
                drx = con.SqlDs(Req).Tables(0).Rows(0)
                Txtemail = drx.Item("Email").ToString
                getstatus = drx.Item("Status").ToString

            End If

            If getstatus = "Rejected" Then



                Panel2.Visible = True
                Panel1.Visible = False
                Label_error.Text = " This request Rejected aready"

                BindToGrid()
                Exit Sub
            End If


            Dim UpadteRecord As String = "Update tbl_M_loanApplication set status ='Rejected'  where Id=  '" & LblID.Text & "' "
            con.SqlDs(UpadteRecord)


            Dim findifupdated As String = "select status from tbl_M_loanApplication where status ='Rejected' and Id=  '" & LblID.Text & "'"
            If con.SqlDs(findifupdated).Tables(0).Rows.Count > 0 Then

                RejectSendEmail()

                Panel1.Visible = True
                Panel2.Visible = False
                Label_error.Visible = False
                Label_success.Visible = True
                Label_success.Text = "This request is Rejected"

                BindToGrid()

            Else
                Panel2.Visible = False
                Label_success.Visible = False
                Panel1.Visible = True
                Label_error.Visible = True
                Label_success.Text = "Error: Please contact your cooperative"
                BindToGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub


End Class
