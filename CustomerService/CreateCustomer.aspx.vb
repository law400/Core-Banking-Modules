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
Imports Toastr
Imports log4net
Imports log4net.Config

Partial Class CreateCustomer
    Inherits SessionCheck
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(CreateCustomer))

    Dim qry As String
    Dim returnmessage As String = ""
    Dim StatusReg As Integer
    Dim RevID As String = ""
    Dim Txtemail As String = ""
    Dim FullName As String = ""
    Dim guarantorEmail As String = ""
    Dim retval As Integer
    Dim PhoneNumber As String = ""
    Dim regnumber As String = ""
    Dim Surname, FirstName, Othername, Phone1, Email, Username, UserPassword_encrypt, Userpassword, retmsg, TenantName As String
    Private MyCon As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Prime").ConnectionString)
    Sub BindToGrid()
        Try
            Dim status As String = "1"
            Dim Item As String = "select a.UniqueID ,a.CustomerId ,a.Fullname,b.accountnumber,b.DateOpened from tbl_customer a ,tbl_casaaccount b  where a.CustomerId =b.customerid and a.Node_ID=b.Node_ID "
            'Me.RadGrid1.DataSource = con.SqlDs(Item)
            'Me.RadGrid1.DataBind()

            Me.GridView1.DataSource = con.SqlDs(Item)
            Me.GridView1.DataBind()

        Catch ex As Exception

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
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = ""
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "REGISTRATION REQUEST" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim

        Dim menuname As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("lbldisplay"), System.Web.UI.WebControls.Label)
        menuname.Text = Request.QueryString("XXX")
        If menuname.Text = "" Then
            Response.Redirect("~/Unauthorize.aspx")
        End If

        If Validate_Access(menuname.Text) = 0 Then
            Response.Redirect("~/Unauthorize.aspx")
        End If
        If Session("RadWindowCode") = "0" Then

            smartobj.ShowToast(Me.Page, ToastType.Success, Session("RadWindowMsg"), "Yessss!", ToastPosition.TopRight, True)

            Session("RadWindowCode") = ""
        ElseIf Session("RadWindowCode") = "998" Then
            smartobj.ShowToast(Me.Page, ToastType.Error, Session("RadWindowMsg"), "Error!", ToastPosition.TopRight, True)
            Session("RadWindowCode") = ""

        Else
            Session("RadWindowCode") = ""

        End If

        If Page.IsPostBack = False Then
            'Dim aa As String = "select UniqueID ,a.CustomerId ,Fullname ,case when sex='1' then 'INDIVIDUAL' when sex='2' then 'INDIVIDUAL'else 'CORPORATE' end as sex,phone1,CreateDate ,case when isnull(status,1)  = '1' then 'ACTIVE'else 'INACTIVE' end as status,isnull(Portal_Access, 'None') 'Portal_Access',*  from tbl_customer a with (nolock) where node_id  = '" & Session("node_ID") & "' and isnull(status,1)  = '1' order by convert(int,a.customerid)"
            Dim aa As String = "select a.UniqueID ,a.CustomerId ,a.Fullname,b.accountnumber,b.DateOpened from tbl_customer a ,tbl_casaaccount b  where a.CustomerId =b.customerid and a.Node_ID=b.Node_ID and a.node_id  = '" & Session("node_ID") & "' "

            Me.GridView1.DataSource = con.SqlDs(aa)
            Me.GridView1.DataBind()
        End If
        'BindToGrid()
    End Sub
    Protected Sub Gridview1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName.Equals("Refresh") Then
            Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)

        ElseIf e.CommandName.Equals("Linkphoto") Then



            Dim viewphoto As LinkButton = DirectCast(e.CommandArgument.FindControl("editLinkphoto"), LinkButton)


            If viewphoto IsNot Nothing Then
                Dim i As Integer = Integer.Parse(GridView1.DataKeys(e.CommandArgument.RowIndex).Values(0).ToString)
                viewphoto.Attributes("href") = "javascript:void(0);"
                viewphoto.Attributes("onclick") = [String].Format("return showRegphoto('{0}','{1}');", i, e.CommandArgument.RowIndex)


            End If


        ElseIf e.CommandName.Equals("RebindGrid") Then

            GridView1.DataBind()




            ''     Panel4.Visible = False

            'ElseIf e.CommandName.Equals("FooterInsert") Then
            '    ' Retrieve controls
            '    Dim txtCompanyName As TextBox = TryCast(gvSuppliers.FooterRow.FindControl("txtCompanyName"), TextBox)
            '    Dim txtPhone As TextBox = TryCast(gvSuppliers.FooterRow.FindControl("txtPhone"), TextBox)

            '    If txtCompanyName Is Nothing Then
            '        Return
            '    End If
            '    If txtPhone Is Nothing Then
            '        Return
            '    End If

            '    ' Set parameters
            '    sdsSuppliers.InsertParameters("CompanyName").DefaultValue = txtCompanyName.Text
            '    sdsSuppliers.InsertParameters("Phone").DefaultValue = txtPhone.Text

            '    ' Perform insert
            '    sdsSuppliers.Insert()
        ElseIf e.CommandName = "Select" Then
            'Determine the RowIndex of the Row whose Button was clicked.
            Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)

                'Reference the GridView Row.
                Dim row As GridViewRow = GridView1.Rows(rowIndex)

                'Fetch value of Unique Id.
                Dim id As String = TryCast(row.FindControl("Label_uniqueID"), Label).Text

                Try

                    Dim configurationFile As Configuration = WebConfigurationManager.OpenWebConfiguration("~/web.config")
                    Dim mailSettings As MailSettingsSectionGroup = configurationFile.GetSectionGroup("system.net/mailSettings")
                    Dim msg As New MailMessage()
                    'msg.From = New MailAddress("noreply@infosightonline.com")

                    qry = " declare @retmsg varchar(100),@retVal int,@Surname varchar(300),@FirstName varchar(300),@Othername varchar(300),@Phone1 varchar(30),@Email varchar(30),@Email varchar(30),@Username Varchar(200),@Userpassword varchar(500),@TenantName varchar(500) " & vbNewLine
                    qry = qry & "Exec Proc_Validate_Portal_Email"
                    qry = qry & smartobj.EncoteWithSingleQuote(id) & ", " & Session("node_ID") & ","
                    qry = qry & "@retVal OUTPUT,@retmsg OUTPUT ,@Surname output,@FirstName output,@OtherName output,@Phone1 output,@Email output,@Username output,@Userpassword output,@TenantName output"
                    qry = qry & " select @retVal,@retmsg,@Surname,@FirstName,@Othername,@Phone1,@Email,@Username,@Userpassword,@TenantName"
                    For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                        retval = dr(0).ToString
                        retmsg = dr(1).ToString
                        Surname = dr(2).ToString
                        FirstName = dr(3).ToString
                        Othername = dr(4).ToString
                        Phone1 = dr(5).ToString
                        Email = dr(6).ToString
                        Username = dr(7).ToString
                        UserPassword_encrypt = dr(8).ToString
                        TenantName = dr(9).ToString
                        Userpassword = con.DecryptText(UserPassword_encrypt)


                    Next
                    If retval = "0" Then
                        Session("Surname") = Surname
                        Session("First_Name") = FirstName
                        Session("Other_Name") = Othername
                        Session("Phone1") = Phone1
                        Session("Email") = Email
                        Session("Username") = Username
                        Session("Password") = Userpassword
                        Session("TenantName") = TenantName
                    Else
                    '  smartobj.ShowToast(Me.Page, ToastType.Error, retmsg, "Error!", ToastPosition.TopRight, True)
                    smartobj.alertwindow(Me.Page, retmsg, "Prime")

                    Exit Sub
                End If
                    msg.From = New MailAddress(mailSettings.Smtp.From)

                    msg.To.Add(Session("Email"))


                    msg.Subject = "Creation of UCP Portal Access"

                    msg.IsBodyHtml = True


                    Dim body2 As String = " "

                    '' Dim FullName As String = Nothing

                    Dim FullName As String = Session("First_Name") + " " + Session("Other_name") + " " + Session("Surname")

                    'Dim qry As String = "select tenant from Tbl_Tenants where Node_id = '" & Session("node_ID") & "'and status = '1'"

                    body2 += "Hello " + FullName + " ,<br/><br/> "


                    'Dim body2 As String = <b><font Size ="3"><font color="Blue"> "Dear " + txtUsername.Text.Trim() + " </b><DIV>&nbsp;</DIV>,"

                    body2 += "Your Portal Access has been created<br/><br/>"

                    body2 += "<b>Login Information : <br/>"

                    body2 += "<b>Username :" + Session("Username") + "<br/> <br/>"

                    body2 += "<b>Password :" + Session("Password") + "<br/> <br/>"

                    'body2 += "<br /><a href = 'http://41.78.157.166/Multi_Migrats/Activation.aspx?ActivationCode=" & activationCode & "'>Click here to access your account <br/></a>"
                    body2 += "<br /><a href = 'https://solutions.cooplatform.com.ng/UCPWEB/ResetPassword.aspx?ActivationCode=" & Session("Email") & "&Node_id=" & Session("Node_id") & "'>Click here to login<br/><br/></a>"
                    body2 += "Thank you.<br/><br/> "
                    body2 += "Regards,<br/> "
                    body2 += Session("TenantName")
                    msg.Body = body2

                    Dim smtp1 As New SmtpClient() 'specify the mail server address
                    smtp1.Credentials = New Net.NetworkCredential(mailSettings.Smtp.From, mailSettings.Smtp.Network.Password)
                    smtp1.Host = mailSettings.Smtp.Network.Host
                    smtp1.Port = mailSettings.Smtp.Network.Port
                    smtp1.Timeout = 700000
                    smtp1.Send(msg)

                '  smartobj.ShowToast(Me.Page, ToastType.Success, retmsg, "Access Link Successfully Sent", ToastPosition.TopRight, True)
                smartobj.alertwindow(Me.Page, "Successful", "Prime")
                ' Next
            Catch ex As Exception
                    logger.Info("Member: Create Customer - ERROR AT     Sub Button2_Click '" _
        & vbNewLine & "   <<<<Direction: OUTPUT" _
        & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
        & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
        & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
        & vbNewLine & "************************************************************************************************************************************************************************************")
                ' smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)
                smartobj.alertwindow(Me.Page, "Error Occurred", "Prime")

            End Try

                '' ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Name: " & name & "\nCountry: " & country + "');", True)
            End If
    End Sub


    'Protected Sub RadGrid1_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand

    '    If e.CommandName = "Refresh" Then

    '        Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)

    '    End If

    '    If e.CommandName = "SelectData" Then
    '        Dim dstatus As String = ""
    '        Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
    '        'Get the primary key value using the DataKeyValue.
    '        Dim RevID As String = item.OwnerTableView.DataKeyValues(item.ItemIndex)("UniqueID").ToString()
    '        Dim bindreg As String = "select * from Memcos_Reg_table  where UniqueID = " & RevID & " "

    '        If con.SqlDs(bindreg).Tables(0).Rows.Count > 0 Then
    '            drx = con.SqlDs(bindreg).Tables(0).Rows(0)
    '            Label6.Text = drx.Item("EmployeeName").ToString
    '            Label7.Text = drx.Item("EmployeeID").ToString
    '            dstatus = drx.Item("Status").ToString

    '            LblID.Text = RevID

    '            Me.Image1.ImageUrl = drx.Item("PictureUrl").ToString
    '            'RadListView2.DataSource = con.SqlDs(LoanReq)
    '            'RadListView2.DataBind()

    '            If dstatus = "Not Approve" Then
    '                AddItem.Text = "Verify request"
    '            End If

    '            If dstatus = "Verified" Then
    '                AddItem.Text = "Approve request"
    '            End If

    '            Panel6.Visible = True



    '            BindToGrid()

    '            'Dim bindreg As String = ""
    '            'bindreg = "select * from Tbl_ItemRequest a, Memcos_Reg_table b  where a.ID = '" & RevID & "' and a.Employeeid =b.Employeeid"

    '            ''bindreg = "select * from Memcos_Reg_table where node_id= '" & Session("Node_id") & "' and EmployeeID='" & RevID & "'"
    '            ''RadListView2.DataSource = con.SqlDs(bindreg)
    '            ''RadListView2.DataBind()




    '        End If
    '    End If

    '    If e.CommandName = "RebindGrid" Then
    '        'clear()
    '        'connect()
    '        RadGrid1.DataBind()
    '        Panel4.Visible = False
    '    End If

    '    If e.CommandName = RadGrid.ExportToExcelCommandName Then
    '        RadGrid1.MasterTableView.GetColumn("TemplateEditColumn").Visible = False
    '    End If

    '    If e.CommandName = RadGrid.ExportToPdfCommandName Then
    '        RadGrid1.MasterTableView.GetColumn("TemplateEditColumn").Visible = False
    '    End If

    '    If e.CommandName = RadGrid.ExportToWordCommandName Then
    '        RadGrid1.MasterTableView.GetColumn("TemplateEditColumn").Visible = False
    '    End If

    '    If e.CommandName = RadGrid.ExportToCsvCommandName Then
    '        RadGrid1.MasterTableView.GetColumn("TemplateEditColumn").Visible = False
    '    End If
    'End Sub

    'Protected Sub RadGrid1_DeleteCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.DeleteCommand
    '    'Get the GridDataItem of the RadGrid
    '    Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
    '    'Get the primary key value using the DataKeyValue.
    '    Dim ID As String = item.OwnerTableView.DataKeyValues(item.ItemIndex)("UniqueID").ToString()
    '    Try
    '        Dim deleteQuery As String = "DELETE from Memcos_Reg_table where UniqueID='" & ID & "'"
    '        con.SqlDs(deleteQuery)
    '    Catch ex As Exception
    '        RadGrid1.Controls.Add(New LiteralControl("Unable to delete Record. Reason: " + ex.Message))
    '        e.Canceled = True
    '    End Try

    'End Sub


    Protected Sub AddItem_Click(sender As Object, e As EventArgs) Handles AddItem.Click
        Try

            Dim getstatus As String = ""
            Dim dstatus As String = ""



            Dim LoanReq As String = "select * from Memcos_Reg_table where UniqueID = '" & LblID.Text & "'"
            If con.SqlDs(LoanReq).Tables(0).Rows.Count > 0 Then
                drx = con.SqlDs(LoanReq).Tables(0).Rows(0)
                Txtemail = drx.Item("Email").ToString
                getstatus = drx.Item("Status").ToString
                regnumber = drx.Item("Employeeid").ToString
                PhoneNumber = drx.Item("Phone").ToString
                FullName = drx.Item("EmployeeName").ToString

            End If

            If getstatus = "Approved" Then
                Panel2.Visible = True
                Panel1.Visible = False
                Label_error.Text = "This request has already been approved"
                BindToGrid()
                Exit Sub
            End If







            Panel6.Visible = True







            'Dim UpadteRecord As String = "Update Memcos_Reg_table set status ='Approved'  where Employeeid =  '" & LblID.Text & "' "
            'con.SqlDs(UpadteRecord)


            Dim InsertReg As String = ""
            InsertReg = "Declare @retval int,@retmsg varchar(200) Exec [Proc_Coop_CustomerCreation]"
            InsertReg = InsertReg & "'" & regnumber & "','" & FullName & "',"
            InsertReg = InsertReg & "'" & PhoneNumber & "','" & Txtemail & "',"
            InsertReg = InsertReg & "'" & Session("Roleid") & "','" & getstatus & "',"
            InsertReg = InsertReg & "'" & Session("node_ID") & "',"
            InsertReg = InsertReg & "@retval Output,@retmsg Output Select @retval,@retmsg"

            For Each dr In con.SqlDs(InsertReg).Tables(0).Rows
                retval = dr(0).ToString
                returnmessage = dr(1).ToString
            Next


            If retval = 10 Then
                Panel1.Visible = True
                Panel2.Visible = False
                Label_error.Visible = False
                Label_success.Visible = True
                Label_success.Text = returnmessage
                BindToGrid()
                Exit Sub
            End If

            If retval = 0 Then

                SendEmail()

                Panel1.Visible = True
                Panel2.Visible = False
                Label_error.Visible = False
                Label_success.Visible = True
                Label_success.Text = "This request is Approved"
                BindToGrid()

            Else
                Panel2.Visible = True
                Label_success.Visible = False
                Panel1.Visible = False
                Label_error.Visible = True
                Label_error.Text = "Error: Please contact your cooperative"
                BindToGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Sub SendEmail()
        Try

            Dim GetCoopMail As String = ""
            Dim txtPassword1 As String = "12345678"

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


            msg.Subject = "Registration Request Approval"

            msg.IsBodyHtml = True


            Dim body2 As String = "<b><u>MOD Cooperative Mail Content</u> </b><br/> <br/>"

            'FullName = TxtFirstName.Text + "  " + TxtLastname.Text

            body2 += "Hello " + Label6.Text + " ,<br/><br/> "

            body2 = "This is to notify you that your request has  been approved <br/> <br/>"


            body2 += "Your login details are: <br/> <br/>"

            body2 += "<b>Userid :" + regnumber + "<br/>"

            body2 += "<b>Password :" + txtPassword1.Trim() + "<br/> <br/>"

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


            msg.Subject = "Registration Request Approval"

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

            Dim Req As String = "select * from Memcos_Reg_table where UniqueID = '" & LblID.Text & "'"
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


            Dim UpadteRecord As String = "Update Memcos_Reg_table set status ='Rejected'  where UniqueID =  '" & LblID.Text & "' "
            con.SqlDs(UpadteRecord)


            Dim findifupdated As String = "select status from Memcos_Reg_table where status ='Rejected' and UniqueID =  '" & LblID.Text & "'"
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

    'Protected Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
    '    Dim Item As String = "select * from Memcos_Reg_table where node_id  = '" & Session("node_ID") & "' "
    '    Me.RadGrid1.DataSource = con.SqlDs(Item)
    'End Sub
    'Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs)
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        e.Row.Attributes("onmouseover") = "this.style.backgroundColor='aquamarine';"
    '        e.Row.Attributes("onmouseout") = "this.style.backgroundColor='white';"
    '        e.Row.ToolTip = "Click last column for selecting this row."
    '    End If
    'End Sub
    'Protected Sub OnSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)


    '    Dim iID = GridView1.SelectedRow.Cells(1).Text
    '    Dim editLinkDetail As LinkButton = DirectCast(GridView1.SelectedRow.Cells(1).FindControl("editLinkDetail"), LinkButton)
    '    Dim qry As String = "select sex ,UniqueID  from tbl_customer where node_id  = '" & Session("node_ID") & "' and status  = '1'" & " and CustomerId =" & iID
    '    ' Dim qry As String = "select Fullname ,Position ,Address , bvn,PhoneNo ,Email ,ImagePath ,IDcardPath,IDtype ,idno,id from tbl_signatories where id =" & pName
    '    Dim i As Integer = Integer.Parse(GridView1.SelectedRow.Cells(1).Text.ToString())
    '    For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows

    '        Select Case dr(0).ToString
    '            Case "1", "2"
    '                '  Response.Redirect("AddReg.aspx?" & ID = dr(1).ToString)
    '                editLinkDetail.Attributes("href") = "javascript:void(0);"
    '                editLinkDetail.Attributes("onclick") = [String].Format("return ShowRegDetail('{0}','{1}');", i, iID)
    '            Case "3"
    '                '  Response.Redirect("AddCoopReg.aspx?" & ID = dr(1).ToString)
    '                editLinkDetail.Attributes("href") = "javascript:void(0);"
    '                editLinkDetail.Attributes("onclick") = [String].Format("return showCorpDetail('{0}','{1}');", i, iID)
    '        End Select


    '    Next

    '    ' msg.Text = (Convert.ToString("<b>Publisher Name  &nbsp;:&nbsp;&nbsp;   ") & pName) + "</b>"
    'End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    Protected Sub Gridview1_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim editLinkDetail As LinkButton = DirectCast(e.Row.FindControl("editLinkDetail"), LinkButton)

            Dim PortalAccess As Label = DirectCast(e.Row.FindControl("Label_Portal"), Label)

            Dim CreatePortalAccess As LinkButton = DirectCast(e.Row.FindControl("CreatePortalAccess"), LinkButton)
            Dim ManageLinkDetailPortalAccess As LinkButton = DirectCast(e.Row.FindControl("ManageLinkDetailPortalAccess"), LinkButton)
            Dim ResendAccessLink As LinkButton = DirectCast(e.Row.FindControl("ResendAccessLink"), LinkButton)
 Dim EditcontributionLink As LinkButton = DirectCast(e.Row.FindControl("EditContribution"), LinkButton)
            CreatePortalAccess.Visible = False


            If CreatePortalAccess IsNot Nothing Then
                Dim iID As Integer = Integer.Parse(GridView1.DataKeys(e.Row.RowIndex).Values(0).ToString())
                CreatePortalAccess.Attributes("href") = "javascript:void(0);"
                CreatePortalAccess.Attributes("onclick") = [String].Format("return CreatePortalAccess('{0}','{1}');", iID, e.Row.RowIndex)
            End If

            If ManageLinkDetailPortalAccess IsNot Nothing Then
                Dim iID As Integer = Integer.Parse(GridView1.DataKeys(e.Row.RowIndex).Values(0).ToString())
                ManageLinkDetailPortalAccess.Attributes("href") = "javascript:void(0);"
                ManageLinkDetailPortalAccess.Attributes("onclick") = [String].Format("return ManagePortalAccess('{0}','{1}');", iID, e.Row.RowIndex)
            End If
            If ResendAccessLink IsNot Nothing Then
                Dim iID As Integer = Integer.Parse(GridView1.DataKeys(e.Row.RowIndex).Values(0).ToString())
                ResendAccessLink.Attributes("href") = "javascript:void(0);"
                ResendAccessLink.Attributes("onclick") = [String].Format("return ResendAccessLink('{0}','{1}');", iID, e.Row.RowIndex)
            End If
			 If EditcontributionLink IsNot Nothing Then
                Dim iID As Integer = Integer.Parse(GridView1.DataKeys(e.Row.RowIndex).Values(0).ToString())
                EditcontributionLink.Attributes("href") = "javascript:void(0);"
                EditcontributionLink.Attributes("onclick") = [String].Format("return EditContribution('{0}','{1}');", iID, e.Row.RowIndex)
            End If
            'If sender.Equals Then
            If editLinkDetail IsNot Nothing Then
                    Dim iID As Integer = Integer.Parse(GridView1.DataKeys(e.Row.RowIndex).Values(0).ToString())
                    '  editLinkDetail.Attributes.Add("onclick", "window.open('ViewRegdetail.aspx?UniqueID=" + iID + "')")
                    Dim qry As String = "select isnull(sex,1) from tbl_customer where node_id  = '" & Session("node_ID") & "' and isnull(status,1)  = '1'" & " and UniqueID =" & iID

                    For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows

                        Select Case dr(0).ToString
                            Case "0", "1", "2", "4"
                                '  Response.Redirect("AddReg.aspx?" & ID = dr(1).ToString)
                                editLinkDetail.Attributes("href") = "javascript:void(0);"
                                editLinkDetail.Attributes("onclick") = [String].Format("return ShowRegDetail('{0}','{1}');", iID, e.Row.RowIndex)
                            Case "3"
                                '  Response.Redirect("AddCoopReg.aspx?" & ID = dr(1).ToString)
                                editLinkDetail.Attributes("href") = "javascript:void(0);"
                                editLinkDetail.Attributes("onclick") = [String].Format("return showCorpDetail('{0}','{1}');", iID, e.Row.RowIndex)
                        End Select


                    Next


                    'editLinkDetail.Attributes("href") = "javascript:void(0);"
                    'editLinkDetail.Attributes("onclick") = [String].Format("return ShowRegDetail('{0}','{1}');", iID, e.Row.RowIndex)
                End If

                'ElseIf viewphoto.CommandName = "photo" Then

            End If





    End Sub



    'Protected Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
    '    If e.Argument = "Rebind" Then
    '        RadGrid1.MasterTableView.SortExpressions.Clear()
    '        RadGrid1.MasterTableView.GroupByExpressions.Clear()
    '        RadGrid1.Rebind()
    '        BindToGrid()


    '    ElseIf e.Argument = "RebindAndNavigate" Then
    '        RadGrid1.MasterTableView.SortExpressions.Clear()
    '        RadGrid1.MasterTableView.GroupByExpressions.Clear()
    '        RadGrid1.MasterTableView.CurrentPageIndex = RadGrid1.MasterTableView.PageCount - 1
    '        RadGrid1.Rebind()

    '        BindToGrid()
    '    End If
    'End Sub
    'Private Sub Export_To_Word_Click(sender As Object, e As EventArgs) Handles Export_To_Word.Click
    '    RadGrid1.ExportSettings.FileName = "RegistrationRequest"
    '    RadGrid1.MasterTableView.ExportToWord()
    '    RadGrid1.Rebind()
    'End Sub
    'Private Sub Export_To_Excel_Click(sender As Object, e As EventArgs) Handles Export_To_Excel.Click
    '    RadGrid1.ExportSettings.FileName = "RegistrationRequest"
    '    RadGrid1.MasterTableView.ExportToExcel()
    '    RadGrid1.Rebind()
    'End Sub
    'Private Sub Export_To_PDF_Click(sender As Object, e As EventArgs) Handles Export_To_PDF.Click
    '    RadGrid1.ExportSettings.FileName = "RegistrationRequest"
    '    RadGrid1.MasterTableView.ExportToPdf()
    '    RadGrid1.Rebind()
    'End Sub
    'Private Sub Export_To_CSV_Click(sender As Object, e As EventArgs) Handles Export_To_CSV.Click
    '    RadGrid1.ExportSettings.FileName = "RegistrationRequest"
    '    RadGrid1.MasterTableView.ExportToCSV()
    '    RadGrid1.Rebind()
    'End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GridView1.DataBind()
    End Sub

    '    Protected Sub Button2_Click(sender As Object, e As System.EventArgs)
    '        Dim btn As Button = TryCast(sender, Button)
    '        Dim gridrow As GridViewRow = TryCast(btn.NamingContainer, GridViewRow)
    '        Dim id As Integer = Convert.ToInt32(GridView1.DataKeys(gridrow.RowIndex).Value.ToString())


    '        Try

    '            Dim configurationFile As Configuration = WebConfigurationManager.OpenWebConfiguration("~/web.config")
    '            Dim mailSettings As MailSettingsSectionGroup = configurationFile.GetSectionGroup("system.net/mailSettings")
    '            Dim msg As New MailMessage()
    '            'msg.From = New MailAddress("noreply@infosightonline.com")

    '            qry = " declare @retmsg varchar(100),@retVal int,@Surname varchar(300),@FirstName varchar(300),@Othername varchar(300),@Phone1 varchar(30),@Email varchar(30),@Email varchar(30),@Username Varchar(200),@Userpassword varchar(500),@TenantName varchar(500) " & vbNewLine
    '            qry = qry & "Exec Proc_Validate_Portal_Email"
    '            qry = qry & smartobj.EncoteWithSingleQuote(id) & ", " & Session("node_ID") & ","
    '            qry = qry & "@retVal OUTPUT,@retmsg OUTPUT ,@Surname output,@FirstName output,@OtherName output,@Phone1 output,@Email output,@Username output,@Userpassword output,@TenantName output"
    '            qry = qry & " select @retVal,@retmsg,@Surname,@FirstName,@Othername,@Phone1,@Email,@Username,@Userpassword,@TenantName"
    '            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
    '                retval = dr(0).ToString
    '                retmsg = dr(1).ToString
    '                Surname = dr(2).ToString
    '                FirstName = dr(3).ToString
    '                Othername = dr(4).ToString
    '                Phone1 = dr(5).ToString
    '                Email = dr(6).ToString
    '                Username = dr(7).ToString
    '                UserPassword_encrypt = dr(8).ToString
    '                TenantName = dr(9).ToString
    '                Userpassword = con.DecryptText(UserPassword_encrypt)


    '            Next
    '            If retval = "0" Then
    '                Session("Surname") = Surname
    '                Session("First_Name") = FirstName
    '                Session("Other_Name") = Othername
    '                Session("Phone1") = Phone1
    '                Session("Email") = Email
    '                Session("Username") = Username
    '                Session("Password") = Userpassword
    '                Session("TenantName") = TenantName
    '            Else
    '                smartobj.ShowToast(Me.Page, ToastType.Error, retmsg, "Error!", ToastPosition.TopRight, True)
    '                smartobj.alertwindow(Me.Page, retmsg, "Prime")

    '                Exit Sub
    '            End If
    '            msg.From = New MailAddress(mailSettings.Smtp.From)

    '            msg.To.Add(Session("Email"))


    '            msg.Subject = "Creation of UCP Portal Access"

    '            msg.IsBodyHtml = True


    '            Dim body2 As String = " "

    '            '' Dim FullName As String = Nothing

    '            Dim FullName As String = Session("First_Name") + " " + Session("Other_name") + " " + Session("Surname")

    '            'Dim qry As String = "select tenant from Tbl_Tenants where Node_id = '" & Session("node_ID") & "'and status = '1'"

    '            body2 += "Hello " + FullName + " ,<br/><br/> "


    '            'Dim body2 As String = <b><font Size ="3"><font color="Blue"> "Dear " + txtUsername.Text.Trim() + " </b><DIV>&nbsp;</DIV>,"

    '            body2 += "Your Portal Access has been created<br/><br/>"

    '            body2 += "<b>Login Information : <br/>"

    '            body2 += "<b>Username :" + Session("Username") + "<br/> <br/>"

    '            body2 += "<b>Password :" + Session("Password") + "<br/> <br/>"

    '            'body2 += "<br /><a href = 'http://41.78.157.166/Multi_Migrats/Activation.aspx?ActivationCode=" & activationCode & "'>Click here to access your account <br/></a>"
    '            body2 += "<br /><a href = 'http://41.78.157.166/UCPWEB/ResetPassword.aspx?ActivationCode=" & Session("Email") & "&Node_id=" & Session("Node_id") & "'>Click here to login<br/><br/></a>"
    '            body2 += "Thank you.<br/><br/> "
    '            body2 += "Regards,<br/> "
    '            body2 += Session("TenantName")
    '            msg.Body = body2

    '            Dim smtp1 As New SmtpClient() 'specify the mail server address
    '            smtp1.Credentials = New Net.NetworkCredential(mailSettings.Smtp.From, mailSettings.Smtp.Network.Password)
    '            smtp1.Host = mailSettings.Smtp.Network.Host
    '            smtp1.Port = mailSettings.Smtp.Network.Port
    '            smtp1.Timeout = 700000
    '            smtp1.Send(msg)

    '            smartobj.ShowToast(Me.Page, ToastType.Success, retmsg, "Access Link Successfully Sent", ToastPosition.TopRight, True)
    '            smartobj.alertwindow(Me.Page, "Successful", "Prime")
    '            ' Next
    '        Catch ex As Exception
    '            logger.Info("Member: Create Customer - ERROR AT     Sub Button2_Click '" _
    '& vbNewLine & "   <<<<Direction: OUTPUT" _
    '& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
    '& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
    '& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
    '& vbNewLine & "************************************************************************************************************************************************************************************")
    '            smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)
    '            smartobj.alertwindow(Me.Page, "Error Occurred", "Prime")

    '        End Try

    '    End Sub
	Protected Sub TxtCustSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCustSearch.TextChanged
			If Me.TxtCustSearch.Text <> Nothing then
				Dim aa As String = "select UniqueID ,a.CustomerId ,Fullname ,case when isnull(customertype,1)='1' then 'INDIVIDUAL' else 'CORPORATE' end as sex,phone1,CreateDate ,case when status='1' then 'ACTIVE'else 'INACTIVE' end as status,isnull(Portal_Access, 'None') 'Portal_Access',*  from tbl_customer a where node_id  = '" & Session("node_ID") & "' and isnull(status,1)  = '1' and fullname like '%'+'" & Me.TxtCustSearch.Text.Trim & "'+'%' order by convert(int,a.customerid)"
				Me.GridView1.DataSource = con.SqlDs(aa)
				Me.GridView1.DataBind()
				Me.GridView1.Visible = True
			Else
				Dim bb As String = "select UniqueID ,a.CustomerId ,Fullname ,case when isnull(customertype,1)='1' then 'INDIVIDUAL' else 'CORPORATE' end as sex,phone1,CreateDate ,case when status='1' then 'ACTIVE'else 'INACTIVE' end as status,isnull(Portal_Access, 'None') 'Portal_Access',*  from tbl_customer a where node_id  = '" & Session("node_ID") & "' and isnull(status,1)  = '1' order by convert(int,a.customerid)"
				Me.GridView1.DataSource = con.SqlDs(bb)
				Me.GridView1.DataBind()
				Me.GridView1.Visible = True
			End If
    End Sub

End Class

