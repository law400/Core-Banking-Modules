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


Partial Class WebPortal_ResendEmail
    Inherits SessionCheck2
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(WebPortal_ResendEmail))
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim cnt As Integer = 0
    Dim userNAME As String
    Dim Surname, FirstName, Othername, Phone1, Email, UserPassword_encrypt, Userpassword, TenantName As String

    Private MyCon As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Prime").ConnectionString)
#Region "Declaration"
    Private Structure vardeclare
        Dim customerid As String
        Dim customername As String
        Dim Branch As String
        Dim department As String
        Dim phoneno As String
        Dim email As String
        Dim userfunction As String
        Dim customerstatus As String
        Dim loginstatus As String
        Dim reportlevel As String
        Dim postacctno As String
        Dim authstatus As String
        Dim newfunction As String
        Dim password As String

    End Structure
    Private decl As New vardeclare
    Private qry As String, qryval As String = ""
    Public Enum MessageType
        Success
        [Error]
        Info
        Warning
    End Enum
    Protected Sub ShowMessage(Message As String, title As String, type As MessageType, position As ToastPosition)
        ' ScriptManager.RegisterStartupScript(Me, Me.[GetType](), System.Guid.NewGuid().ToString(), "ShowMessage('" & Message & "','" & type.ToString() & "');", True)
        Toastr.ShowToast(Me, type, Message, title, position, True)
    End Sub
#End Region
    Dim profileImg As String = ""


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


        'Session("node_ID")

        If Request.QueryString("UniqueID") <> "" Then



            Try

                Dim configurationFile As Configuration = WebConfigurationManager.OpenWebConfiguration("~/web.config")
                Dim mailSettings As MailSettingsSectionGroup = configurationFile.GetSectionGroup("system.net/mailSettings")
                Dim msg As New MailMessage()
                'msg.From = New MailAddress("noreply@infosightonline.com")

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
                    userNAME = dr(7).ToString
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
                    Session("Username") = userNAME
                    Session("Password") = Userpassword
                    Session("TenantName") = TenantName
                Else
                    ''  smartobj.ShowToast(Me.Page, ToastType.Error, "Unable to send portal access link: " + retmsg, "Error!", ToastPosition.TopRight, True)
                    'smartobj.alertwindow(Me.Page, retmsg, "Prime")

                    Panel2.Visible = True
                    Panel2.Focus()

                    Label_error.Text = "Unable to send portal access link: " + retmsg

                    Panel1.Visible = False

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


                Dim FilePath As String = HttpContext.Current.Server.MapPath("~/Email_Template.html")
                Dim str As StreamReader = New StreamReader(FilePath)
                Dim MailText As String = str.ReadToEnd()
                str.Close()
                MailText = MailText.Replace("{Username}", FullName)

                Dim subject As String = "Welcome to " + TenantName


                MailText = MailText.Replace("{Heading}", msg.Subject.Trim())

                MailText = MailText.Replace("{Title}", subject.Trim)

                body2 += "Hello " + FullName + " ,<br/><br/> "

                body2 += "Greetings to you.<br/> "
                'Dim body2 As String = <b><font Size ="3"><font color="Blue"> "Dear " + txtUsername.Text.Trim() + " </b><DIV>&nbsp;</DIV>,"

                body2 += "Your portal access has been created.<br/><br/>"

                body2 += "Your login details are: <br/>"

                body2 += "<b>COOPERATIVE NAME: " + Session("TenantName") + "</b><br/>"

                body2 += "<b>USERNAME: " + Session("Username") + "</b><br/>"

                body2 += "<b>PASSWORD: " + Session("Password") + "</b><br/><br/>"

                'body2 += "<br /><a href = 'http://41.78.157.166/Multi_Migrats/Activation.aspx?ActivationCode=" & activationCode & "'>Click here to access your account <br/></a>"
                body2 += "<b>Click on link <a href = 'http://solutions.cooplatform.com.ng/ucpweb/ResetPassword.aspx?ActivationCode=" & Session("Email") & "&Node_id=" & Session("Node_id") & "'> here</a> to access your profile.</b><br/><br/>"
                body2 += "Thank you for your interest in " + Session("TenantName") + ".<br/><br/> "

                body2 += "Best Regards,<br/> "
                body2 += Session("TenantName") + "<br/> <br/>"


                MailText = MailText.Replace("{Body}", body2)

                MailText = MailText.Replace("{user}", Session("Username").Trim())

                MailText = MailText.Replace("{email}", Session("Email").Trim())
                msg.Body = MailText

                Dim smtp1 As New SmtpClient() 'specify the mail server address
                smtp1.Credentials = New Net.NetworkCredential(mailSettings.Smtp.From, mailSettings.Smtp.Network.Password)
                smtp1.Host = mailSettings.Smtp.Network.Host
                smtp1.Port = mailSettings.Smtp.Network.Port
                smtp1.Timeout = 700000
                smtp1.Send(msg)

                ''   smartobj.ShowToast(Me.Page, ToastType.Success, retmsg, "Access Link Successfully Sent", ToastPosition.TopRight, True)
                ''   smartobj.alertwindow(Me.Page, "Access Link Successfully Sent", "Prime")


                Panel1.Visible = True
                Panel1.Focus()

                Label_success.Text = "Access Link Successfully Sent"

                Panel2.Visible = False
                ' Next
            Catch ex As Exception
                logger.Info("Member: Create Customer - ERROR AT     Sub Button2_Click '" _
    & vbNewLine & "   <<<<Direction: OUTPUT" _
    & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
    & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
    & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
    & vbNewLine & "************************************************************************************************************************************************************************************")
                '' smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)
                ''  smartobj.alertwindow(Me.Page, "Error Occurred", "Prime")
                Panel2.Visible = True
                Panel2.Focus()

                Label_error.Text = "Unable to send portal access link: Error Occurred"

                ''    Label_error.Text = ex.Message


                Panel1.Visible = False

            End Try

        Else
          

            Session("RadWindowCode") = "998"
            Session("RadWindowMsg") = "Unable to Resend access Link: Invalid profile"

            Panel2.Visible = True
            Panel2.Focus()

            Label_error.Text = "Unable to send portal access link: Invalid profile"

            Panel1.Visible = False

            smartobj.ShowToast(Me.Page, ToastType.Error, "Unable to send portal access link: Invalid profile", "Error!", ToastPosition.TopRight, True)


        End If

    End Sub














End Class

