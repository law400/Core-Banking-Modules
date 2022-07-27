Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
'Imports System.Web.Mail
Imports System.Net.Mail.MailMessage
Imports System.Net
Imports System.Net.Mail
Imports System.Web.Configuration
Imports System.Net.Configuration
Imports System.IO
Imports Toastr
Imports log4net
Imports log4net.Config

Partial Class CustomerService_CreatePortalAccess
    Inherits SessionCheck2
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(CustomerService_CreatePortalAccess))
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim cnt As Integer = 0
    Dim userNAMEs As String
    Dim qry As String = ""
    Dim Surname, FirstName, Othername, Phone1, Email, UserPassword_encrypt, Userpassword As String
	Private TenantName As String

    Private MyCon As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Prime").ConnectionString)

    Protected Sub BtnSubmit_Click(sender As Object, e As EventArgs) Handles BtnSubmit.Click
        Try
            
			If Me.txtusername.Text = "" then
				Panel2.Visible = True
                Panel2.Focus()

                Label_error.Text = "Please Enter Username"

                Panel1.Visible = False
				'smartobj.ShowToast(Me.Page, ToastType.Warning, "Please Enter Username", "Oops!", ToastPosition.TopRight, True)
				return
			End if
			
			If Me.txtpassword.Text = "" then 
				Panel2.Visible = True
                Panel2.Focus()

                Label_error.Text = "Please Enter Password"

                Panel1.Visible = False
				'smartobj.ShowToast(Me.Page, ToastType.Warning, "Please Enter Password", "Oops!", ToastPosition.TopRight, True)
				return
			End If
			
			Dim password As String = con.EncryptText(Me.txtpassword.Text.Trim)

            logger.Info("CREATE PORTAL ACCESS: '" & "BtnSubmit_Click" & "'' " _
      & vbNewLine & "   <<<<Direction: INPUT" _
      & vbNewLine & "      INPUT PARAMETERS LIST & " _
      & vbNewLine & "           User name: '" & txtusername.Text & "'" _
      & vbNewLine & "           PWD: '" & password & "'" _
      & vbNewLine & "           Node_id: '" & Session("node_id") & "'" _
      & vbNewLine & "       INPUT PARAMETERS LIST END----------'" _
      & vbNewLine & "************************************************************************************************************************************************************************************")

            qry = " declare @retmsg varchar(100),@retVal int " & vbNewLine
            qry = qry & "Exec Proc_Create_Portal_Access "
            qry = qry & smartobj.EncoteWithSingleQuote(txtusername.Text.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(password.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Request.QueryString("UniqueID")) & ",@retVal OUTPUT,@retmsg OUTPUT , " & Session("node_ID") & ""
            qry = qry & " select @retVal,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next
            logger.Info("CREATE PORTAL ACCESS:'" & "RESPONSE" & " : '" & "BtnSubmit_Click" & "'' " _
      & vbNewLine & "   <<<<Direction: OUTPUT" _
      & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
      & vbNewLine & "          RetVal: '" & retval & "'" _
      & vbNewLine & "          RetMsg: '" & retmsg & "'" _
      & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" & "" & "'" & " " _
      & vbNewLine & "************************************************************************************************************************************************************************************")


            If retval = "0" Then
                Me.Panel1.Visible = True
                Panel1.Focus()
                Me.Panel2.Visible = False
                Me.Label_success.Visible = True
                Me.Label_error.Visible = False
                Me.Label_success.Text = "Member portal access successfully created"
				
				'smartobj.ShowToast(Me.Page, ToastType.Success, retmsg, "Yessss!", ToastPosition.TopRight, True)
				'smartobj.ShowToast(Me.Page, ToastType.Warning, "Oops! Please enter a custom member id", "Oops!", ToastPosition.TopRight, True)

                'Session("RadWindowCode") = "0"
                'Session("RadWindowMsg") = retmsg
                ''    smartobj.alertwindow(Me.Page, retmsg, "Prime")


                SendEmail()

                clear()
            Else


                Panel2.Visible = True
                Panel2.Focus()

                Label_error.Text = retmsg

                Panel1.Visible = False
				smartobj.ShowToast(Me.Page, ToastType.Warning, retmsg, "Oops!", ToastPosition.TopRight, True)
                'Session("RadWindowCode") = "998"
                'Session("RadWindowMsg") = retmsg

            End If
        Catch ex As Exception
            logger.Info("USER: Create Portal Access - ERROR AT BtnSubmit_Click '" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")
            Panel2.Visible = True
            Panel2.Focus()

            Label_error.Text = "Error Occurred"

            Panel1.Visible = False

            'Session("RadWindowCode") = "XXX"
			smartobj.ShowToast(Me.Page, ToastType.Warning, "Error Occurred", "Oops!", ToastPosition.TopRight, True)
        End Try
    End Sub
    Sub clear()
        Me.txtusername.Text = Nothing
        Me.txtpassword.Text = Nothing
        Me.txtconfirmpassword.Text = Nothing
    End Sub
    Protected Sub CustomerService_CreatePortalAccess_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            someLabelBelowTheTextBox.Text = ""
			If Not IsPostBack Then
            If Request.QueryString("UniqueID") <> "" Then
				qry = " declare @retmsg varchar(100),@retVal int,@Surname varchar(300),@FirstName varchar(300),@Othername varchar(300),@Phone1 varchar(30),@Email varchar(30),@Username Varchar(200),@Userpassword varchar(500),@TenantName varchar(500) " & vbNewLine
                qry = qry & "Exec Proc_Validate_Portal_Email"
                qry = qry & smartobj.EncoteWithSingleQuote(Request.QueryString("UniqueID")) & ", " & Session("node_ID") & ","
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
                    userNAMEs = dr(7).ToString
                    UserPassword_encrypt = dr(8).ToString
                    TenantName = dr(9).ToString
					
					Me.txtUsername.Text = userNAMEs

                Next
                If retval = "0" Then
                    Session("Surname") = Surname
                    Session("First_Name") = FirstName
                    Session("Other_Name") = Othername
                    Session("Phone1") = Phone1
                    Session("Email") = Email
					Session("TenantName") = TenantName
                Else
                    Panel2.Visible = True
                Panel2.Focus()

                    Label_error.Text = "Unable to create portal access: " + retmsg
                    Panel1.Visible = False

                Session("RadWindowCode") = "998"
                    Session("RadWindowMsg") = "Unable to create portal access: " + retmsg
                    BtnSubmit.Enabled = False
            End If
            Else
            Panel2.Visible = True
            Panel2.Focus()

            Label_error.Text = "Unable to create portal access: Invalid profile"

            Panel1.Visible = False

            Session("RadWindowCode") = "998"
            Session("RadWindowMsg") = "Unable to create portal access: Invalid profile"
            BtnSubmit.Enabled = False
            End If
			End If
        Catch ex As Exception
            logger.Info("USER: Create Portal Access - ERROR AT Page_Load '" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")
            Panel2.Visible = True
            Panel2.Focus()

            Label_error.Text = "Error Occurred"

            Panel1.Visible = False

            Session("RadWindowCode") = "XXX"
            BtnSubmit.Enabled = False
        End Try
    End Sub
    Sub SendEmail()
        Try

            Dim configurationFile As Configuration = WebConfigurationManager.OpenWebConfiguration("~/web.config")
            Dim mailSettings As MailSettingsSectionGroup = configurationFile.GetSectionGroup("system.net/mailSettings")
            Dim msg As New MailMessage()
            'msg.From = New MailAddress("noreply@infosightonline.com")
            msg.From = New MailAddress(mailSettings.Smtp.From)

            msg.To.Add(Session("Email"))


            msg.Subject = "Creation of UCP Portal Access"

            msg.IsBodyHtml = True


            Dim body2 As String = " "

            '' Dim FullName As String = Nothing

            Dim FullName As String = Session("First_Name") + " " + Session("Other_name") + " " + Session("Surname")

            'Dim qry As String = "select tenant from Tbl_Tenants where Node_id = '" & Session("node_ID") & "'and status = '1'"

            Dim FilePath As String = HttpContext.Current.Server.MapPath("~/Email_Template.html")
            Dim str As StreamReader = New StreamReader(FilePath)
            Dim MailText As String = str.ReadToEnd()
            str.Close()
            MailText = MailText.Replace("{Username}", FullName)

            Dim subject As String = "Welcome to " + Session("TenantName")

            MailText = MailText.Replace("{Heading}", msg.Subject.Trim())

            MailText = MailText.Replace("{Title}", subject.Trim)

            body2 += "Hello " + FullName + " ,<br/><br/> "

            body2 += "Greetings to you.<br/> "
            'Dim body2 As String = <b><font Size ="3"><font color="Blue"> "Dear " + txtUsername.Text.Trim() + " </b><DIV>&nbsp;</DIV>,"

            body2 += "Your portal access has been created.<br/><br/>"

            body2 += "Your login details are: <br/>"

            body2 += "<b>COOPERATIVE NAME: " + Session("TenantName") + "</b><br/>"
            body2 += "<b>USERNAME: " + txtusername.Text() + "</b><br/>"
            body2 += "<b>PASSWORD: " + txtpassword.Text() + "</b><br/> <br/>"

            'body2 += "<br /><a href = 'http://41.78.157.166/Multi_Migrats/Activation.aspx?ActivationCode=" & activationCode & "'>Click here to access your account <br/></a>"
            body2 += "<b>Click on link <a href = 'http://solutions.cooplatform.com.ng/UCPWEB/ResetPassword.aspx?ActivationCode=" & Session("Email") & "&Node_id=" & Session("Node_id") & "'> here</a> to access your profile.</b><br/><br/>"
            body2 += "Thank you for your interest in " + Session("TenantName") + ".<br/><br/> "

            body2 += "Best Regards,<br/> "

            body2 += Session("TenantName") + "<br/> <br/>"

            MailText = MailText.Replace("{Body}", body2)

            MailText = MailText.Replace("{user}", txtusername.Text.Trim())

            MailText = MailText.Replace("{email}", Session("Email").Trim())
            msg.Body = MailText

            Dim smtp1 As New SmtpClient() 'specify the mail server address
            smtp1.Credentials = New Net.NetworkCredential(mailSettings.Smtp.From, mailSettings.Smtp.Network.Password)
            smtp1.Host = mailSettings.Smtp.Network.Host
            smtp1.Port = mailSettings.Smtp.Network.Port
            smtp1.Timeout = 700000
            smtp1.Send(msg)
            ' Next
        Catch ex As Exception
            logger.Info("USER: Create Portal Access - ERROR AT     Sub SendEmail() '" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")
        End Try
    End Sub
    Protected Sub txtUserName_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim constr As String = WebConfigurationManager.ConnectionStrings("Prime").ConnectionString
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand = New SqlCommand("select Ltrim(rtrim(Username)) from Memcos_Reg_Table where lower(username) = lower(@Usn) and node_id = " & Session("node_id") & "", con)
        cmd.Parameters.AddWithValue("@Usn", txtusername.Text)
        Dim is_exists As Boolean = False
        Try
            con.Open()
            is_exists = If(cmd.ExecuteScalar() Is Nothing, False, True)
        Catch ex As Exception
            logger.Info("USER: Create Portal Access - ERROR AT  txtUserName_TextChanged '" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")
        Finally
            con.Close()
        End Try

        If is_exists Then
            someLabelBelowTheTextBox.Text = "This UserName already exists, Please Choose another one"
            BtnSubmit.Enabled = False
            txtusername.Focus()
        Else
            BtnSubmit.Enabled = True
        End If
    End Sub

End Class
