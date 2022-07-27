Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Net
Imports System.Data.Entity
Imports Telerik.Web.UI
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text
Imports System.Security.Cryptography
Imports System.Xml
Imports log4net
Imports log4net.Config
Imports System.Net.Mail
Imports System.Web.Configuration
Imports System.Net.Configuration
Imports System.Net.Mail.MailMessage
Imports System.IO
Imports Toastr
Partial Class Receipt
    Inherits System.Web.UI.Page
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(Receipt))

    Dim status As String = String.Empty, message As String = String.Empty, amount As String = String.Empty
    Dim transdate As String = String.Empty, nibssRef As String = String.Empty, transaction_id As String = String.Empty
    Dim merchant_id As String = String.Empty, rrr_id As String = String.Empty, paymentDate As String = String.Empty
    Dim orderId As String = String.Empty
    Dim Node_id As String = String.Empty
    Dim bankname As String = String.Empty
    Dim bankEmail As String = String.Empty
    Dim retval As Integer
    Dim retmsg As String = ""
    Dim constring As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("prime").ConnectionString)
    Public Shared Function GenerateRandomCode(ByVal length As Integer) As String
        Dim rdm As Random = New Random()
        Dim sb As StringBuilder = New StringBuilder()
        For i As Integer = 0 To length - 1
            sb.Append(Convert.ToChar(rdm.[Next](101, 132)))
        Next

        Return sb.ToString()
    End Function
    Public Function GenerateTransactionID() As String

        Dim DateString As String = DateTime.Now.ToString("yyMMddHHmmss")

        Dim RandomClass As New Random()

        Dim RandomNumber2 As Integer : Dim Rand2 As String = String.Empty : Dim TransactionID As String = String.Empty


        RandomNumber2 = RandomClass.Next(100, 999)
        Rand2 = CStr(RandomNumber2)


        TransactionID = Rand2 + DateString

        Return TransactionID

    End Function
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim request As WebRequest

        'Dim response As WebResponse
        'Dim postData As String = "message=" + message
        'Dim data As Byte() = Encoding.UTF8.GetBytes(postData)



        'response = request.GetResponse()
        'Dim sr As New StreamReader(response.GetResponseStream())


        'MsgBox(sr.ReadToEnd)
        'sr.r


        'Dim nvclc As NameValueCollection = Request.Form
        orderId = Request.Form("orderID")
        rrr_id = Request.Form("RRR")
        paymentDate = Request.Form("paymentDate")

        status = Request.Form("status")
        message = Request.Form("message")
        amount = Request.Form("amount")
        transdate = Request.Form("transactionDate")
        paymentDate = Request.Form("paymentDate")
        transaction_id = Request.Form("transactionId")

        lbldate.Text = paymentDate
        lblrrr.Text = rrr_id

        'LblAmount.Text = amount


        logger.Info("Portal: PaymentReceipt   - Input parameters     Sub Button2_Click '" _
       & vbNewLine & "   <<<<Direction: INPUTS" _
       & vbNewLine & "      INPUTS PARAMETERS LIST & " _
        & vbNewLine & "      Name: '" & lblCoopName.Text & "'" _
                & vbNewLine & "      Email: '" & lblEmail.Text & "'" _
        & vbNewLine & "      orderId: '" & orderId & "'" _
            & vbNewLine & "       rrr_id: '" & rrr_id & "'" _
       & vbNewLine & "            paymentDate : '" & paymentDate & "'" _
            & vbNewLine & "       status : '" & status & "'" _
            & vbNewLine & "       message : '" & message & "'" _
               & vbNewLine & "    amount : '" & amount & "'" _
                & vbNewLine & "   transdate : '" & transdate & "'" _
               & vbNewLine & "   paymentDate : '" & paymentDate & "'" _
             & vbNewLine & "     transaction_id : '" & transaction_id & "'" _
            & vbNewLine & "       INPUTS PARAMETERS LIST END----------'" _
            & vbNewLine & "************************************************************************************************************************************************************************************")




        Try








            'nvclc.Add("status", status)

            'nvclc.Add("message", message)
            'nvclc.Add("amount", amount)

            'nvclc.Add("transdate", transdate)
            'nvclc.Add("paymentDate", paymentDate)


            'nvclc.Add("transactionId", transaction_id)
            'nvclc.Add("rrr", rrr_id)

            lblTransactionId.Text = transaction_id
            lblTransactionID2.Text = transaction_id
            Dim Retval As Integer = 11111
            Dim Retmsg As String = "", CoopName As String = "", Email As String = "", Paymentstatus As String = ""







            Dim cmd As New SqlCommand()
            constring.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@TransactionId", transaction_id)
            cmd.Parameters.AddWithValue("@status", status)
            cmd.Parameters.AddWithValue("@status_message", message)
            cmd.Parameters.AddWithValue("@Transaction_date", transdate)

            cmd.CommandText = "UCP_PaymentLog_Update"
            cmd.CommandTimeout = 500
            cmd.Connection = constring

            Dim RegAdapter As New SqlDataAdapter()
            RegAdapter.SelectCommand = cmd
            Dim DataReg As New DataSet()
            RegAdapter.Fill(DataReg)

            For Each Tablex As DataTable In DataReg.Tables

                Retval = Tablex.Rows(0)("Retval")
                Retmsg = Tablex.Rows(0)("RetMsg")

                lblCoopName.Text = Tablex.Rows(0)("CoopName")

                lblEmail.Text = Tablex.Rows(0)("Email")

                lblMobileNo.Text = Tablex.Rows(0)("MobileNo")
                lbldate.Text = Tablex.Rows(0)("ActualDate")
                Dim TotalAmt As Decimal = Tablex.Rows(0)("TotalAmount")
                lblTotalamount.Text = String.Format("{0:#,#.00}", TotalAmt)
                Dim Amount As Decimal = Tablex.Rows(0)("Amount")
                LblAmount.Text = String.Format("{0:#,#.00}", Amount)
                Dim Convenience As Decimal = Tablex.Rows(0)("Fee_Amt")
                lblcharge.Text = String.Format("{0:#,#.00}", Convenience)
                lblsubamount.Text = String.Format("{0:#,#.00}", Amount)
                '  LblDescription.Text = Tablex.Rows(0)("Decription")
                Node_id = Tablex.Rows(0)("Node_id")
                Dim MemberStrength As Integer = Tablex.Rows(0)("MemberStrength")
                Lbl_MemberStrength.Text = String.Format("{0:#,#.}", MemberStrength)



                ''''''''Generate Sessions for the Print Page'''''
                'Session("CoopName") = Tablex.Rows(0)("CoopName")
                'Session("Email") = Tablex.Rows(0)("Email")
                'Session("Address") = Tablex.Rows(0)("Address")
                'Session("MobileNo") = Tablex.Rows(0)("MobileNo")
                'Session("Date") = Tablex.Rows(0)("ActualDate")
                'Session("Transactionid") = transaction_id
                'Session("TranAmt") = CDec(amount) / 100

            Next




            If status = "00" Or status = "01" Then


                Dim todayDate As DateTime = DateTime.Now : Dim YearInFuture As DateTime
                YearInFuture = todayDate.AddYears(1)

                lblnextDate.Text = YearInFuture.ToString("dd MMM yyyy")
                Panel_Success.Visible = True
                Panel_Failed.Visible = False
                PrintReceipt.Visible = True
                PrintReceipt2.Visible = True
                ''   Dim PlainPwd As String = GenerateRandomCode(9)
                Dim PlainPwd As String = ""
                PlainPwd = "P@s1234@"
                Dim EncryptPwd As String = con.EncryptText(PlainPwd)

                Dim UpdateReg As String = ""

                UpdateReg = "Declare @Node_id int, @retval int,@retmsg varchar(200) Exec [Proc_TenantCreation]"
                UpdateReg = UpdateReg & "'" & Me.lblEmail.Text.Trim & "' ,'" & EncryptPwd & "' ,"
                UpdateReg = UpdateReg & "@Node_id Output,@retval Output,@retmsg Output Select @Node_id, @retval,@retmsg"

                For Each dr In con.SqlDs(UpdateReg).Tables(0).Rows
                    Node_id = dr(0).ToString
                    Retval = dr(1).ToString
                    Retmsg = dr(2).ToString
                Next



                Email_successful(Node_id, PlainPwd)

                ''    Label_success.Text = "Payment Successful with Transaction Id: " + transaction_id + ""

                smartobj.ShowToast(Me.Page, ToastType.Success, "Payment Successful with Transaction Id: " + transaction_id + "", "Yessss!", ToastPosition.TopRight, True)

                'Label_error.Text = ""
                ''lbl_RegStatus.Text = "Successful"
                'lbl_Transaction_Date.Text = transdate
                'RadAmount.Text = CDec(amount) / 100
                'RadAmount2.Text = CDec(amount) / 100
                'Panel2.Visible = True

            Else

                'Label_success.Text = ""
                'Label_error.Text = "Cooperative Payment Not Successful: Payment Failed"
                ''lbl_RegStatus.Text = "Failed"
                'lbl_Transaction_Date.Text = transdate
                'RadAmount.Text = CDec(amount) / 100
                'Panel3.Visible = False

                '' Label_success.Text = "Payment Not Successful"

                smartobj.ShowToast(Me.Page, ToastType.Error, "Payment Not Successful", "Oops!", ToastPosition.TopRight, True)

                Panel_Success.Visible = False
                Panel_Failed.Visible = True
                PrintReceipt.Visible = False
                PrintReceipt2.Visible = False
                Email_Failed()
            End If

        Catch ex As Exception
            'Label_error.Text = ex.Message
            logger.Info("Cooperative Registration: Receipt.aspx  Load_Payment()" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
        Finally
            constring.Close()
        End Try
    End Sub
    Sub Email_Failed()
        Try
            Dim constr As String = ConfigurationManager.ConnectionStrings("prime").ConnectionString

            Dim activationCode As String = Guid.NewGuid().ToString()
            Dim EmailId As String = lblEmail.Text

            Dim configurationFile As Configuration = WebConfigurationManager.OpenWebConfiguration("~/web.config")
            Dim mailSettings As MailSettingsSectionGroup = configurationFile.GetSectionGroup("system.net/mailSettings")

            Dim msg As New MailMessage()
            'msg.From = New MailAddress("noreply@infosightonline.com")
            msg.From = New MailAddress(mailSettings.Smtp.From)

            msg.To.Add(EmailId)
            msg.Bcc.Add("newabode4me@yahoo.com")
            msg.Bcc.Add("Funmilola.abimbola@cwlgroup.com")




            msg.Subject = "UCP REGISTRATION PAYMENT NOTIFICATION"

            msg.IsBodyHtml = True

            Dim FilePath As String = HttpContext.Current.Server.MapPath("~/Email_Template.html")
            Dim str As StreamReader = New StreamReader(FilePath)
            Dim MailText As String = str.ReadToEnd()
            str.Close()
            MailText = MailText.Replace("{Username}", lblCoopName.Text.Trim)

            Dim body2 As String = ""
            Dim subject As String = "Warm Co-operative greetings to you."

            MailText = MailText.Replace("{Heading}", msg.Subject.Trim())

            MailText = MailText.Replace("{Title}", subject.Trim)

            Dim txtPassword1 As String = "12345678"


            ''  Dim body2 As String = "Dear " + LblCoopName.Text + " ,<br/><br/> "


            '' body2 += "Warm Co-operative greetings to you.<br/> <br/>"

            body2 += "This is to inform you that your UCP registration payment was not successful.<br/>"

            Dim TransactiondID As String = "" : Dim Email As String = "" : Dim Phone As String = ""
            Dim UserName As String = ""
            Dim RetryTransactionID As String = GenerateTransactionID()
            TransactiondID = con.encryptNewest(RetryTransactionID)
            Email = con.encryptNewest(lblEmail.Text.Trim)
            Phone = con.encryptNewest(lblMobileNo.Text.Trim)
            UserName = con.encryptNewest(lblCoopName.Text.Trim)
            body2 += "We implore you to try again <a href = 'https://solutions.cooplatform.com.ng/Finedge_UCP/RegFee.aspx?TransactionId=" & TransactiondID & "&Amount=" & amount & "&Email=" & Email & "&Phone=" & Phone & "&Coop=" & UserName & "'> <b>here</b></a> to make payment or at a later time by referring to this email.<br/><br/>"

            'body2 += "We implore you to try again or at a later time referring to the last email sent to you for payment.<br/><br/>"


            body2 += "<b>Regards,  <br/>"

            body2 += "<b>Administrator <br/> <br/>"




            MailText = MailText.Replace("{Body}", body2)

            MailText = MailText.Replace("{user}", lblCoopName.Text.Trim())

            MailText = MailText.Replace("{email}", EmailId.Trim())

            msg.Body = MailText

            Dim smtp1 As New SmtpClient() 'specify the mail server address
            smtp1.Credentials = New Net.NetworkCredential(mailSettings.Smtp.From, mailSettings.Smtp.Network.Password)
            smtp1.Host = mailSettings.Smtp.Network.Host
            smtp1.Port = mailSettings.Smtp.Network.Port
            smtp1.Timeout = 700000

            ''   MSGFormat2()
            smtp1.Send(msg)
        Catch ex As Exception
            logger.Info("Cooperative Registration: Payfee.aspx  Email_Failed()" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
        End Try
    End Sub
    Sub Email_successful(ByVal Nodeid As String, ByVal Password As String)

        Try
            Dim constr As String = ConfigurationManager.ConnectionStrings("prime").ConnectionString

            Dim activationCode As String = Guid.NewGuid().ToString()
            Dim EmailId As String = lblEmail.Text

            Dim configurationFile As Configuration = WebConfigurationManager.OpenWebConfiguration("~/web.config")
            Dim mailSettings As MailSettingsSectionGroup = configurationFile.GetSectionGroup("system.net/mailSettings")

            Dim msg As New MailMessage()
            'msg.From = New MailAddress("noreply@infosightonline.com")
            msg.From = New MailAddress(mailSettings.Smtp.From)

            msg.To.Add(EmailId)
            msg.Bcc.Add("newabode4me@yahoo.com")
            msg.Bcc.Add("Funmilola.abimbola@cwlgroup.com")




            msg.Subject = "UCP REGISTRATION PAYMENT NOTIFICATION"

            msg.IsBodyHtml = True


            '' Dim txtPassword1 As String = "12345678"
            Dim FilePath As String = HttpContext.Current.Server.MapPath("~/Email_Template.html")
            Dim str As StreamReader = New StreamReader(FilePath)
            Dim MailText As String = str.ReadToEnd()
            str.Close()
            MailText = MailText.Replace("{Username}", lblCoopName.Text.Trim)

            Dim body2 As String = ""
            Dim subject As String = "Warm Co-operative greetings to you."

            MailText = MailText.Replace("{Heading}", msg.Subject.Trim())

            MailText = MailText.Replace("{Title}", subject.Trim)

            '' Dim body2 As String = "Dear " + LblCoopName.Text + " ,<br/><br/> "

            Dim userid As String = "Admin"
            '' body2 += "Warm Co-operative greetings to you.<br/> <br/>"

            body2 += "This is to inform you that your UCP registration payment was successful and has been approved.<br/>"

            body2 += "Total Subscription Amount Paid: ₦" + String.Format("{0:#,#.00}", lblsubamount.Text) + " "
            body2 += "<br/> "
            body2 += "Transaction ID :" + lblTransactionId.Text + " , RRR: " + lblrrr.Text + ""
            body2 += "<br/> "
            Dim todayDate As DateTime = DateTime.Now : Dim YearInFuture As DateTime
            YearInFuture = todayDate.AddYears(1)

            body2 += "Your Next Subscription Due Date Is: " + YearInFuture.ToString("dd MMM yyyy") + ""
            body2 += "<br/> "
            body2 += "You now have access to the UCP Admin Portal.<br/>"

            body2 += "Please find your login details below: <br/> <br/>"

            body2 += "<b>Node ID  :  " + Nodeid + "</b><br/>"

            body2 += "<b>User ID  :  " + userid + "</b><br/>"

            body2 += "<b>Password :  " + Password.Trim() + "</b><br/> <br/>"

            ''  body2 += "<b>Please click the link below to login to UCP solution:<br/>"
            ''body2 += "<br /><a href = 'http://solutions.cooplatform.com.ng/UCP/'>Click here to log in <br/><br/></a>"

            ''  body2 += "<br /><a href = 'http://41.78.157.166/Finedge_UCP/'>Click here to log in <br/><br/></a>"

            body2 += "Please click <a href = 'http://solutions.cooplatform.com.ng/Finedge_UCP/'><b>here</b> </a> to login to the UCP Portal<br/><br/>"

            body2 += "<b>Regards,  </b><br/>"

            body2 += "<b>Administrator </b><br/> <br/>"




            MailText = MailText.Replace("{Body}", body2)

            MailText = MailText.Replace("{user}", lblCoopName.Text.Trim())

            MailText = MailText.Replace("{email}", EmailId.Trim())

            msg.Body = MailText

            Dim smtp1 As New SmtpClient() 'specify the mail server address
            smtp1.Credentials = New Net.NetworkCredential(mailSettings.Smtp.From, mailSettings.Smtp.Network.Password)
            smtp1.Host = mailSettings.Smtp.Network.Host
            smtp1.Port = mailSettings.Smtp.Network.Port
            smtp1.Timeout = 700000

            ''   MSGFormat()
            smtp1.Send(msg)

        Catch ex As Exception
            logger.Info("Cooperative Registration: PayFee.aspx  Email_successful()" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
        End Try
    End Sub

    'Sub SendEmail()
    '    Try


    '        Dim findcoop As String = "select BankName,Email from Tbl_Bank where Node_id = '" & Node_id & "'"
    '        If con.SqlDs(findcoop).Tables(0).Rows.Count > 0 Then
    '            drx = con.SqlDs(findcoop).Tables(0).Rows(0)
    '            bankname = drx.Item("bankname").ToString
    '            bankEmail = drx.Item("Email").ToString

    '        End If

    '        Dim configurationFile As Configuration = WebConfigurationManager.OpenWebConfiguration("~/web.config")
    '        Dim mailSettings As MailSettingsSectionGroup = configurationFile.GetSectionGroup("system.net/mailSettings")
    '        Dim msg As New MailMessage()
    '        'msg.From = New MailAddress("noreply@infosightonline.com")
    '        msg.From = New MailAddress(mailSettings.Smtp.From)
    '        msg.To.Add(lblEmail.Text)
    '        msg.To.Add("newabode4me@yahoo.com")


    '        msg.Subject = "Registartion Acknowledgement"

    '        msg.IsBodyHtml = True


    '        Dim body2 As String = ""




    '        Dim FullName As String = lblCoopName.Text

    '        ' body2 += "Hello " + FullName + " ,<br/><br/> "

    '        Dim FilePath As String = HttpContext.Current.Server.MapPath("~/Email_Template.html")
    '        Dim str As StreamReader = New StreamReader(FilePath)
    '        Dim MailText As String = str.ReadToEnd()
    '        str.Close()
    '        MailText = MailText.Replace("{Username}", FullName)

    '        Dim subject As String = "Welcome to " + bankname.Trim


    '        MailText = MailText.Replace("{Heading}", subject.Trim())

    '        MailText = MailText.Replace("{Title}", msg.Subject.Trim)

    '        'Dim body2 As String = <b><font Size ="3"><font color="Blue"> "Dear " + txtUsername.Text.Trim() + " </b><DIV>&nbsp;</DIV>,"

    '        body2 += "This is to acknowledge the receipt of your application. We will respond to your application within 72 Hours. We will  also advise you on the next step to take. <br/><br/>"

    '        body2 += "Thank you for your interest in our Cooperative.<br/><br/> "
    '        body2 += "Regards,<br/> "
    '        body2 += bankname.Trim + "<br/><br/> "
    '        msg.Body = body2



    '        MailText = MailText.Replace("{Body}", body2)

    '        MailText = MailText.Replace("{user}", bankname.Trim)

    '        MailText = MailText.Replace("{email}", lblCoopName.Text.Trim())
    '        msg.Body = MailText


    '        Dim smtp1 As New SmtpClient() 'specify the mail server address
    '        smtp1.Credentials = New Net.NetworkCredential(mailSettings.Smtp.From, mailSettings.Smtp.Network.Password)
    '        smtp1.Host = mailSettings.Smtp.Network.Host
    '        smtp1.Port = mailSettings.Smtp.Network.Port
    '        smtp1.Timeout = 700000
    '        smtp1.Send(msg)
    '    Catch ex As Exception

    '    End Try
    'End Sub


End Class
