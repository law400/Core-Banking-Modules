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


Partial Class ResendEmail
    Inherits SessionCheck2
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(ResendEmail))
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
    Sub Email_Failed(ByVal Emails As String, ByVal CoopName As String)
        Try
            Dim constr As String = ConfigurationManager.ConnectionStrings("prime").ConnectionString

            Dim activationCode As String = Guid.NewGuid().ToString()
            Dim EmailId As String = Emails

            Dim configurationFile As Configuration = WebConfigurationManager.OpenWebConfiguration("~/web.config")
            Dim mailSettings As MailSettingsSectionGroup = configurationFile.GetSectionGroup("system.net/mailSettings")

            Dim msg As New MailMessage()
            'msg.From = New MailAddress("noreply@infosightonline.com")
            msg.From = New MailAddress(mailSettings.Smtp.From)

            msg.To.Add(EmailId)
            msg.Bcc.Add("newabode4me@yahoo.com")
            msg.Bcc.Add("Funmilola.abimbola@cwlgroup.com")




            msg.Subject = "UCP REGISTRATION APPROVAL NOTIFICATION"

            msg.IsBodyHtml = True

            Dim FilePath As String = HttpContext.Current.Server.MapPath("~/Email_Template.html")
            Dim str As StreamReader = New StreamReader(FilePath)
            Dim MailText As String = str.ReadToEnd()
            str.Close()
            MailText = MailText.Replace("{Username}", CoopName.Trim)

            Dim body2 As String = ""
            Dim subject As String = "Warm Co-operative greetings to you."

            MailText = MailText.Replace("{Heading}", msg.Subject.Trim())

            MailText = MailText.Replace("{Title}", subject.Trim)

            Dim txtPassword1 As String = "12345678"


            ''  Dim body2 As String = "Dear " + LblCoopName.Text + " ,<br/><br/> "


            '' body2 += "Warm Co-operative greetings to you.<br/> <br/>"

            body2 += "This is to inform you that your UCP registration has been rejected.<br/>"

            body2 += "We implore you to try again.<br/>"


            body2 += "Regards,  <br/>"

            body2 += "Administrator <br/> <br/>"




            MailText = MailText.Replace("{Body}", body2)

            MailText = MailText.Replace("{user}", CoopName.Trim)

            MailText = MailText.Replace("{email}", EmailId.Trim())

            msg.Body = MailText

            Dim smtp1 As New SmtpClient() 'specify the mail server address
            smtp1.Credentials = New Net.NetworkCredential(mailSettings.Smtp.From, mailSettings.Smtp.Network.Password)
            smtp1.Host = mailSettings.Smtp.Network.Host
            smtp1.Port = mailSettings.Smtp.Network.Port
            smtp1.Timeout = 700000

            smtp1.Send(msg)
        Catch ex As Exception
            logger.Info("Resend Coop Approval Email: ResendEmail.aspx  Email_Failed()" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
        End Try
    End Sub
    Sub Email_successful_Subscription_Payment(ByVal Emails As String, ByVal CoopName As String, ByVal Amount_To_Pay As Decimal, ByVal TransactionID As String, ByVal PhoneMobile As String, ByVal OutStandingBal As Decimal, ByVal PartialPayFlag As Integer, ByVal PartialAmt As Decimal)

        Try

            ''''''''''''''Hardcode Email To Test''''''''''''
            '''''  Emails = "oluwaseyi.oyewo@gmail.com"
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim constr As String = ConfigurationManager.ConnectionStrings("prime").ConnectionString

            Dim activationCode As String = Guid.NewGuid().ToString()
            Dim EmailId As String = Emails

            Dim configurationFile As Configuration = WebConfigurationManager.OpenWebConfiguration("~/web.config")
            Dim mailSettings As MailSettingsSectionGroup = configurationFile.GetSectionGroup("system.net/mailSettings")

            Dim msg As New MailMessage()
            'msg.From = New MailAddress("noreply@infosightonline.com")
            msg.From = New MailAddress(mailSettings.Smtp.From)

            msg.To.Add(EmailId)
            msg.Bcc.Add("newabode4me@yahoo.com")
            msg.Bcc.Add("Funmilola.abimbola@cwlgroup.com")




            msg.Subject = "UCP REGISTRATION APPROVAL NOTIFICATION"

            msg.IsBodyHtml = True


            '' Dim txtPassword1 As String = "12345678"
            Dim FilePath As String = HttpContext.Current.Server.MapPath("~/Email_Template.html")
            Dim str As StreamReader = New StreamReader(FilePath)
            Dim MailText As String = str.ReadToEnd()
            str.Close()
            MailText = MailText.Replace("{Username}", CoopName.Trim)

            Dim body2 As String = ""
            Dim subject As String = "Warm Co-operative greetings to you."

            MailText = MailText.Replace("{Heading}", msg.Subject.Trim())

            MailText = MailText.Replace("{Title}", subject.Trim)

            '' Dim body2 As String = "Dear " + LblCoopName.Text + " ,<br/><br/> "

            '' body2 += "Warm Co-operative greetings to you.<br/> <br/>"

            body2 += "This is to inform you that your UCP registration has been approved.<br/>"
            body2 += "You will need to make payment to activate your subscription.<br/>"
            Dim amount2 As Decimal = Amount_To_Pay
            body2 += "Total Subscription Amount Payable: <b>₦" + String.Format("{0:#,#.00}", amount2) + "</b><br/>"


            If PartialPayFlag = 1 And PartialAmt <> 0.00 Then
                body2 += "Outstanding Amount Payable: <b>₦" + String.Format("{0:#,#.00}", OutStandingBal) + "</b><br/>"
            End If
            'body2 += "Please kindly click below to make payments: <br/> <br/>"

            Dim TransactiondID As String = "" : Dim Email As String = "" : Dim Phone As String = ""
            Dim UserName As String = ""
            TransactiondID = con.encryptNewest(TransactionID.Trim)
            Email = con.encryptNewest(Emails.Trim)
            Phone = con.encryptNewest(PhoneMobile.Trim)
            UserName = con.encryptNewest(CoopName.Trim)
            body2 += "Please click <a href = 'https://solutions.cooplatform.com.ng/Finedge_UCP/RegFee.aspx?TransactionId=" & TransactiondID & "&Amount=" & amount2 & "&Email=" & Email & "&Phone=" & Phone & "&Coop=" & UserName & "'> <b>here</b></a> to make payment<br/><br/>"


            body2 += "<b>Regards,  <br/>"

            body2 += "<b>Administrator <br/> <br/>"




            MailText = MailText.Replace("{Body}", body2)

            MailText = MailText.Replace("{user}", CoopName.Trim())

            MailText = MailText.Replace("{email}", EmailId.Trim())

            msg.Body = MailText

            Dim smtp1 As New SmtpClient() 'specify the mail server address
            smtp1.Credentials = New Net.NetworkCredential(mailSettings.Smtp.From, mailSettings.Smtp.Network.Password)
            smtp1.Host = mailSettings.Smtp.Network.Host
            smtp1.Port = mailSettings.Smtp.Network.Port
            smtp1.Timeout = 700000


            smtp1.Send(msg)

        Catch ex As Exception
            logger.Info("Resend Coop Approval Email: ResendEmail.aspx  Email_successful_Subscription_Payment()" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
        End Try
    End Sub

    Private Function Get_SubscriptionAmount(ByVal Discount As Decimal, ByVal Amount_due As Decimal) As Decimal
        Dim DiscountPercent As Decimal = 0
        Dim DiscountAmt As Decimal = 0 : Dim AmountPaid As Decimal = 0 : Dim Amount_Discount As Decimal
        AmountPaid = Amount_due
        DiscountPercent = Discount

        If DiscountPercent = 0.00 Then
            Return Amount_due


        Else

            DiscountAmt = (DiscountPercent * AmountPaid) / 100
            Amount_Discount = AmountPaid - DiscountAmt
            Return Amount_Discount
        End If
    End Function

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


        'Session("node_ID")

        If Request.QueryString("UniqueID") <> "" Then



            Try


                Dim Req As String = "select Org_name,Email,Phone,Discount,isnull(Amount_Due,0)'Amount_Due',status,TransactionId,isnull(Discount_Flag,0)'Discount_Flag', isnull(PartialPay_Flag,0)'PartialPay_Flag', isnull(Amount_Paying,0)'Amount_Paying', isnull(Partial_Amount,0)'Partial_Amount', isnull(Outstanding_Bal,0)'Outstanding_Bal' from Reg_table where UniqueID = '" & Request.QueryString("UniqueID") & "'"

                If con.SqlDs(Req).Tables(0).Rows.Count > 0 Then

                    drx = con.SqlDs(Req).Tables(0).Rows(0)
                    Dim CoopName As String = drx.Item("Org_name").ToString
                    Dim Email As String = drx.Item("Email").ToString
                    Dim Phone As String = drx.Item("Phone").ToString
                    Dim Discount As Decimal = drx.Item("Discount")
                    Dim Amount_Due As Decimal = drx.Item("Amount_Due")
                    Dim Status As String = drx.Item("Status").ToString
                    Dim TransactionID As String = drx.Item("TransactionId").ToString
                    Dim DiscountFlag As Integer = drx.Item("Discount_Flag").ToString
                    Dim PartialPayFlag As Integer = drx.Item("PartialPay_Flag").ToString
                    Dim Amount_Paying As Decimal = drx.Item("Amount_Paying")
                    Dim OutstandingBal As Decimal = drx.Item("Outstanding_Bal")
                    Dim PartialAmt As Decimal = drx.Item("Partial_Amount")
                    ' Amount_ToPay = Get_SubscriptionAmount(Discount, Amount_Due)

                    If Status = "Approved" Then



                        Email_successful_Subscription_Payment(Email, CoopName, Amount_Paying, TransactionID, Phone, OutstandingBal, PartialPayFlag, PartialAmt)

                        Panel1.Visible = True
                        Panel1.Focus()
                        Label_success.Text = "Email Resent Successfully"
                        Panel2.Visible = False
                        Session("RadWindowCode") = "0"
                        Session("RadWindowMsg") = "Email Resent Successfully"

                    ElseIf Status = "Rejected" Then

                        Email_Failed(Email, CoopName)

                        Panel1.Visible = True
                        Panel1.Focus()
                        Label_success.Text = "Email Resent Successfully"
                        Panel2.Visible = False
                        Session("RadWindowCode") = "0"
                        Session("RadWindowMsg") = "Email Resent Successfully"


                    End If
                    Else


                    Panel2.Visible = True
                        Panel2.Focus()

                    Label_error.Text = "Unable to fetch record to re-send email for payment: " + retmsg

                    Panel1.Visible = False

                    Session("RadWindowCode") = "998"
                    Session("RadWindowMsg") = "Unable to fetch record to re-send email for payment"
                    Exit Sub
                    End If


            Catch ex As Exception
                logger.Info("Resend Email: ResendEmail.aspx - ERROR AT     Page_Load '" _
    & vbNewLine & "   <<<<Direction: OUTPUT" _
    & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
    & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
    & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
    & vbNewLine & "************************************************************************************************************************************************************************************")

                Panel2.Visible = True
                Panel2.Focus()

                Label_error.Text = "Unable to re-send email for payment: Error Occurred"

                ''    Label_error.Text = ex.Message


                Panel1.Visible = False

            End Try

        Else


            Session("RadWindowCode") = "998"
            Session("RadWindowMsg") = "Unable to re-send email for payment: Invalid profile"

            Panel2.Visible = True
            Panel2.Focus()

            Label_error.Text = "Unable to re-send email for payment: Invalid profile"

            Panel1.Visible = False

            smartobj.ShowToast(Me.Page, ToastType.Error, "Unable to send portal access link: Invalid profile", "Error!", ToastPosition.TopRight, True)


        End If

    End Sub

End Class

