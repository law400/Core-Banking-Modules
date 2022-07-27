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
Imports System.Security.Cryptography
Imports Toastr
Imports log4net
Imports log4net.Config
Partial Class ViewCoopReqDetail
    Inherits System.Web.UI.Page
    Dim retval As Integer
    Dim retmsg As String = ""
    Dim node_id As String = ""
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(ViewCoopReqDetail))
    Dim Amount As Decimal = 0 : Dim Amount_Discount As Decimal = 0 : Dim Discount As Integer : Dim PartialPay As Integer
    Protected Sub ButAccept_Click(sender As Object, e As EventArgs) Handles ButAccept.Click
        Try
            Dim returnmessage As String = ""


            Me.ButAccept.Enabled = False
            ButCancel.Enabled = False
            lbl_id0.Visible = True


            Try


                ''''''''''Started Commenting Here'''''''''''''''''''''''
                'Dim PlainPwd As String = GenerateRandomCode(9)

                'Dim EncryptPwd As String = con.EncryptText(PlainPwd)

                If Me.RadioButPartial.SelectedValue = "Partial" Then
                    PartialPay = 1
                    Discount = 0
                    If CDec(Me.txtPartialPayment.Text) = 0.00 Then
                        Panel2.Visible = True
                        Panel1.Visible = False
                        Label_success.Visible = False
                        Label_error.Visible = True
                        Label_error.Text = "Partial Payment Amount cannot be 0"
                        Exit Sub
                    End If

                ElseIf Me.RadioButPartial.SelectedValue = "Discount" Then
                    PartialPay = 0
                    Discount = 1
                    If CDec(Me.txtdiscount.Text) = 0.00 Then
                        Panel2.Visible = True
                        Panel1.Visible = False
                        Label_success.Visible = False
                        Label_error.Visible = True
                        Label_error.Text = "Discount cannot be 0"
                        Exit Sub
                    End If

                Else
                    PartialPay = 0
                    Discount = 0
                    Lbl_TotalAmount2.Text = Amount
                    LblOutstanding.Text = 0
                    txtPartialPayment.Text = 0

                End If
                Dim UpdateReg As String = ""

                UpdateReg = "Declare @retval int,@retmsg varchar(200) Exec [Proc_Approve_Coop]"
                UpdateReg = UpdateReg & "'" & Me.LblEmail.Text.Trim & "' ,'" & LblTransactionID.Text.Trim & "' ,"
                UpdateReg = UpdateReg & "'" & Me.txtdiscount.Text & "' ,'" & Session("Userid") & "' ,'" & Session("Node_id") & "','" & Amount & "','" & CDec(Lbl_TotalAmount2.Text) & "', '" & CDec(txtPartialPayment.Text) & "','" & CDec(LblOutstanding.Text) & "'," & Discount & ", " & PartialPay & ","
                UpdateReg = UpdateReg & "@retval Output,@retmsg Output Select @retval,@retmsg"

                For Each dr In con.SqlDs(UpdateReg).Tables(0).Rows
                    retval = dr(0).ToString
                    retmsg = dr(1).ToString
                Next




                If retval = 0 Then

                    Email_successful_Subscription_Payment()

                    Panel1.Visible = True
                    Panel2.Visible = False
                    Label_success.Visible = True
                    Label_error.Visible = False
                    Label_success.Text = retmsg
                    lbl_id0.Visible = False
                    ''   smartobj.alertwindow(Me.Page, retmsg, "Prime")
                    ''  smartobj.ShowToast(Me.Page, ToastType.Success, retmsg, "Yessss!", ToastPosition.TopRight, True)
                    ButAccept.Enabled = False
                Else
                    ''smartobj.ShowToast(Me.Page, ToastType.Error, retmsg, "Yessss!", ToastPosition.TopRight, True)
                    ''    smartobj.alertwindow(Me.Page, retmsg, "Prime")

                    Email_Failed()
                    Panel2.Visible = True
                    Panel1.Visible = False
                    Label_success.Visible = False
                    Label_error.Visible = True
                    Label_error.Text = retmsg

                    Me.ButAccept.Enabled = True
                    ButCancel.Enabled = True
                    lbl_id0.Visible = False
                End If



                '''''''''''''''''Stopped Commenting Here''''''''''''''''''''



            Catch ex As Exception

                'Dim ExMSG As String = "update Reg_table set Status='" & ex.Message & "' where Email = '" & Me.LblEmail.Text & "' "
                'con.SqlDs(ExMSG)
                '' HideTextboxes()
                ''  smartobj.alertwindow(Me.Page, ex.Message, "Prime")

                ''   smartobj.ShowToast(Me.Page, ToastType.Error, "Data Error Occurred", "Error!", ToastPosition.TopRight, True)

                Panel2.Visible = True
                Panel1.Visible = False
                Label_success.Visible = False
                Label_error.Visible = True
                Label_error.Text = "Data Error Occurred"
                '' Me.ButAccept.Enabled = True
                lbl_id0.Visible = False
            End Try




            'Dim UpadteRecord As String = "Update Memcos_Reg_table set status ='Approved' where EmployeeID=  '" & TxtEmployeeid.Text & "' "

            'con.SqlDs(UpadteRecord)
            ''smartobj.alertwindow(Me.Page, "Record Approved successfully: Activation message is sent to your mailbox", "Prime")

        Catch ex As Exception

            ''   smartobj.alertwindow(Me.Page, ex.Message, "Prime")


            ''  smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)
            Panel2.Visible = True
            Panel1.Visible = False
            Label_success.Visible = False
            Label_error.Visible = True
            Label_error.Text = "Error Occurred"

        End Try
    End Sub
    Sub Email_Failed()
        Try
            Dim constr As String = ConfigurationManager.ConnectionStrings("prime").ConnectionString

            Dim activationCode As String = Guid.NewGuid().ToString()
            Dim EmailId As String = LblEmail.Text

            Dim configurationFile As Configuration = WebConfigurationManager.OpenWebConfiguration("~/web.config")
            Dim mailSettings As MailSettingsSectionGroup = configurationFile.GetSectionGroup("system.net/mailSettings")

            Dim msg As New MailMessage()
            'msg.From = New MailAddress("noreply@infosightonline.com")
            msg.From = New MailAddress(mailSettings.Smtp.From)

            msg.To.Add(EmailId)

           


            msg.Subject = "UCP REGISTRATION APPROVAL NOTIFICATION"

            msg.IsBodyHtml = True

            Dim FilePath As String = HttpContext.Current.Server.MapPath("~/Email_Template.html")
            Dim str As StreamReader = New StreamReader(FilePath)
            Dim MailText As String = str.ReadToEnd()
            str.Close()
            MailText = MailText.Replace("{Username}", LblCoopName.Text.Trim)

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

            MailText = MailText.Replace("{user}", LblCoopName.Text.Trim())

            MailText = MailText.Replace("{email}", EmailId.Trim())

            msg.Body = MailText

            Dim smtp1 As New SmtpClient() 'specify the mail server address
            smtp1.Credentials = New Net.NetworkCredential(mailSettings.Smtp.From, mailSettings.Smtp.Network.Password)
            smtp1.Host = mailSettings.Smtp.Network.Host
            smtp1.Port = mailSettings.Smtp.Network.Port
            smtp1.Timeout = 700000

            MSGFormat2()
            smtp1.Send(msg)
        Catch ex As Exception
            logger.Info("Cooperative Registration: ViewCoopReqDetail.aspx  Email_Failed()" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
        End Try
    End Sub
    Public Shared Function GenerateRandomCode(ByVal length As Integer) As String
        Dim rdm As Random = New Random()
        Dim sb As StringBuilder = New StringBuilder()
        For i As Integer = 0 To length - 1
            sb.Append(Convert.ToChar(rdm.[Next](101, 132)))
        Next

        Return sb.ToString()
    End Function
    Sub Email_successful_Subscription_Payment()

        Try
            Dim constr As String = ConfigurationManager.ConnectionStrings("prime").ConnectionString

            Dim activationCode As String = Guid.NewGuid().ToString()
            Dim EmailId As String = LblEmail.Text

            Dim configurationFile As Configuration = WebConfigurationManager.OpenWebConfiguration("~/web.config")
            Dim mailSettings As MailSettingsSectionGroup = configurationFile.GetSectionGroup("system.net/mailSettings")

            Dim msg As New MailMessage()
            'msg.From = New MailAddress("noreply@infosightonline.com")
            msg.From = New MailAddress(mailSettings.Smtp.From)

            msg.To.Add(EmailId)
            



            msg.Subject = "UCP REGISTRATION APPROVAL NOTIFICATION"

            msg.IsBodyHtml = True


            '' Dim txtPassword1 As String = "12345678"
            Dim FilePath As String = HttpContext.Current.Server.MapPath("~/Email_Template.html")
            Dim str As StreamReader = New StreamReader(FilePath)
            Dim MailText As String = str.ReadToEnd()
            str.Close()
            MailText = MailText.Replace("{Username}", LblCoopName.Text.Trim)

            Dim body2 As String = ""
            Dim subject As String = "Warm Co-operative greetings to you."

            MailText = MailText.Replace("{Heading}", msg.Subject.Trim())

            MailText = MailText.Replace("{Title}", subject.Trim)

            '' Dim body2 As String = "Dear " + LblCoopName.Text + " ,<br/><br/> "

            '' body2 += "Warm Co-operative greetings to you.<br/> <br/>"

            body2 += "This is to inform you that your UCP registration has been approved.<br/>"
            body2 += "You will need to make payment to activate your subscription.<br/>"
            Dim amount2 As Decimal = Lbl_TotalAmount2.Text
            body2 += "Total Subscription Amount Payable: <b>₦" + String.Format("{0:#,#.00}", amount2) + "</b><br/>"

            If Me.RadioButPartial.SelectedValue = "Partial" And CDec(txtPartialPayment.Text) <> 0.00 Then
                Dim Outstandingamount As Decimal = CDec(LblOutstanding.Text)
                body2 += "Outstanding Amount Payable: <b>₦" + String.Format("{0:#,#.00}", Outstandingamount) + "</b><br/>"
            End If
            'body2 += "Please kindly click below to make payments: <br/> <br/>"

            Dim TransactiondID As String = "" : Dim Email As String = "" : Dim Phone As String = ""
            Dim UserName As String = ""
            TransactiondID = con.encryptNewest(LblTransactionID.Text.Trim)
            Email = con.encryptNewest(LblEmail.Text.Trim)
            Phone = con.encryptNewest(LblPhone.Text.Trim)
            UserName = con.encryptNewest(LblCoopName.Text.Trim)
            body2 += "Please click <a href = 'https://solutions.cooplatform.com.ng/Finedge_UCP/RegFee.aspx?TransactionId=" & TransactiondID & "&Amount=" & amount2 & "&Email=" & Email & "&Phone=" & Phone & "&Coop=" & UserName & "'> <b>here</b></a> to make payment<br/><br/>"


            body2 += "<b>Regards,  <br/>"

            body2 += "<b>Administrator <br/> <br/>"




            MailText = MailText.Replace("{Body}", body2)

            MailText = MailText.Replace("{user}", LblCoopName.Text.Trim())

            MailText = MailText.Replace("{email}", EmailId.Trim())

            msg.Body = MailText

            Dim smtp1 As New SmtpClient() 'specify the mail server address
            smtp1.Credentials = New Net.NetworkCredential(mailSettings.Smtp.From, mailSettings.Smtp.Network.Password)
            smtp1.Host = mailSettings.Smtp.Network.Host
            smtp1.Port = mailSettings.Smtp.Network.Port
            smtp1.Timeout = 700000

            MSGFormat()
            smtp1.Send(msg)

        Catch ex As Exception
            logger.Info("Cooperative Registration: ViewCoopReqDetail.aspx  Email_successful_Subscription_Payment()" _
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
            Dim EmailId As String = LblEmail.Text

            Dim configurationFile As Configuration = WebConfigurationManager.OpenWebConfiguration("~/web.config")
            Dim mailSettings As MailSettingsSectionGroup = configurationFile.GetSectionGroup("system.net/mailSettings")

            Dim msg As New MailMessage()
            'msg.From = New MailAddress("noreply@infosightonline.com")
            msg.From = New MailAddress(mailSettings.Smtp.From)

            msg.To.Add(EmailId)
            



            msg.Subject = "UCP REGISTRATION APPROVAL NOTIFICATION"

            msg.IsBodyHtml = True


            '' Dim txtPassword1 As String = "12345678"
            Dim FilePath As String = HttpContext.Current.Server.MapPath("~/Email_Template.html")
            Dim str As StreamReader = New StreamReader(FilePath)
            Dim MailText As String = str.ReadToEnd()
            str.Close()
            MailText = MailText.Replace("{Username}", LblCoopName.Text.Trim)

            Dim body2 As String = ""
            Dim subject As String = "Warm Co-operative greetings to you."

            MailText = MailText.Replace("{Heading}", msg.Subject.Trim())

            MailText = MailText.Replace("{Title}", subject.Trim)

            '' Dim body2 As String = "Dear " + LblCoopName.Text + " ,<br/><br/> "

            Dim userid As String = "Admin"
            '' body2 += "Warm Co-operative greetings to you.<br/> <br/>"

            body2 += "This is to inform you that your UCP registration has been approved.<br/>"

            body2 += "Please find your login details below: <br/> <br/>"

            body2 += "<b>Node ID  :  " + Nodeid + "<br/>"

            body2 += "<b>User ID  :  " + userid + "<br/>"

            body2 += "<b>Password :  " + Password.Trim() + "<br/> <br/>"

            body2 += "<b>Please click the link below to login to UCP solution:<br/>"
            ''body2 += "<br /><a href = 'http://solutions.cooplatform.com.ng/UCP/'>Click here to log in <br/><br/></a>"

            ''  body2 += "<br /><a href = 'http://41.78.157.166/Finedge_UCP/'>Click here to log in <br/><br/></a>"

            body2 += "<b><a href = 'http://solutions.cooplatform.com.ng/Finedge_UCP/'>Click here to log in </a></b><br/>"

            body2 += "<b>Regards,  <br/>"

            body2 += "<b>Administrator <br/> <br/>"




            MailText = MailText.Replace("{Body}", body2)

            MailText = MailText.Replace("{user}", LblCoopName.Text.Trim())

            MailText = MailText.Replace("{email}", EmailId.Trim())

            msg.Body = MailText

            Dim smtp1 As New SmtpClient() 'specify the mail server address
            smtp1.Credentials = New Net.NetworkCredential(mailSettings.Smtp.From, mailSettings.Smtp.Network.Password)
            smtp1.Host = mailSettings.Smtp.Network.Host
            smtp1.Port = mailSettings.Smtp.Network.Port
            smtp1.Timeout = 700000

            MSGFormat()
            smtp1.Send(msg)

        Catch ex As Exception
            logger.Info("Cooperative Registration: ViewCoopReqDetail.aspx  Email_successful()" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
        End Try
    End Sub
    Protected Sub ButCancel_Click(sender As Object, e As EventArgs) Handles ButCancel.Click
        Try
            lbl_id0.Visible = True
            ButCancel.Enabled = False
            ButAccept.Enabled = False
            Dim UpadteRecord As String = "Update Reg_table set status ='Rejected' where Email=  '" & Me.LblEmail.Text & "' "

            con.SqlDs(UpadteRecord)
            '' HideTextboxes()
            ''   smartobj.alertwindow(Me.Page, "Record Rejected successfully", "Prime")

  Email_Failed()
            Panel1.Visible = True
            Panel2.Visible = False
            Label_success.Visible = True
            Label_error.Visible = False
            Label_success.Text = "Registration Rejected successfully"

            lbl_id0.Visible = False

            ''  smartobj.ShowToast(Me.Page, ToastType.Success, "Record Rejected successfully", "Yessss!", ToastPosition.TopRight, True)


        Catch ex As Exception
            Panel2.Visible = True
            Panel1.Visible = False
            Label_success.Visible = False
            Label_error.Visible = True
            Label_error.Text = "Error Occurred"
        End Try
    End Sub
    Sub MSGFormat()

        Dim newMobile5 As String = Nothing
        Dim newmgs As String = Nothing
        Dim body1 As String = ""

        Dim activationCode As String = Guid.NewGuid().ToString()
        ''   Dim EmailId As String = Me.TxtDataKey.Text



        body1 += "ATTENTION! Your UCP registration has been approved. Please check your email. For more info? Call 09062741935 " & vbCrLf & vbCrLf









        Dim PhoneNumber As String = ""

        'Dim CoopReq As String = "select * from Reg_table where Email ='" & Me.TxtDataKey.Text & "' "
        'If con.SqlDs(CoopReq).Tables(0).Rows.Count > 0 Then
        '    drx = con.SqlDs(CoopReq).Tables(0).Rows(0)
        '    PhoneNumber = drx.Item("Phone").ToString



        PhoneNumber = LblPhone.Text
        'newmgs = (TextBox1.Text.Trim + " " + "scores" + " " + "60 Marks" + "" + " " + "in" + " " + "maths")
        If PhoneNumber <> "" Then

            If Mid(PhoneNumber, 1, 3) = "234" Then
                newMobile5 = PhoneNumber.Trim
            ElseIf Mid(PhoneNumber, 1, 4) = "+234" Then
                newMobile5 = "234" + Mid(lbl_id.Text, 5, Len(PhoneNumber))
            Else
                PhoneNumber = Mid(PhoneNumber, 2, Len(PhoneNumber))
                newMobile5 = "234" + PhoneNumber.Trim
            End If
            SendSmsHTTP2(body1, newMobile5)
        End If
    End Sub
    Sub MSGFormat2()

        Dim newMobile5 As String = Nothing
        Dim newmgs As String = Nothing
        Dim body1 As String = ""

        Dim activationCode As String = Guid.NewGuid().ToString()
        ''   Dim EmailId As String = Me.TxtDataKey.Text



        body1 += "ATTENTION! Your UCP registration has been rejected. Please check email. For more info? Call 09062741935 " & vbCrLf & vbCrLf









        Dim PhoneNumber As String = ""

        'Dim CoopReq As String = "select * from Reg_table where Email ='" & Me.TxtDataKey.Text & "' "
        'If con.SqlDs(CoopReq).Tables(0).Rows.Count > 0 Then
        '    drx = con.SqlDs(CoopReq).Tables(0).Rows(0)
        '    PhoneNumber = drx.Item("Phone").ToString



        PhoneNumber = LblPhone.Text
        'newmgs = (TextBox1.Text.Trim + " " + "scores" + " " + "60 Marks" + "" + " " + "in" + " " + "maths")
        If PhoneNumber <> "" Then

            If Mid(PhoneNumber, 1, 3) = "234" Then
                newMobile5 = PhoneNumber.Trim
            ElseIf Mid(PhoneNumber, 1, 4) = "+234" Then
                newMobile5 = "234" + Mid(lbl_id.Text, 5, Len(PhoneNumber))
            Else
                PhoneNumber = Mid(PhoneNumber, 2, Len(PhoneNumber))
                newMobile5 = "234" + PhoneNumber.Trim
            End If
            SendSmsHTTP2(body1, newMobile5)
        End If
    End Sub
    Private Function SendSmsHTTP2(ByVal message As String, ByVal receiverList As String) As String
        Try
            Dim subacctpwd = "ucp987c"
            Dim ownermail = "mary.adeyemi@cwg-plc.com"
            Dim msgtype = "0"
            'Dim message = "Test Message"
            Dim subacct As String = "UCP"
            Dim senderid = "CWG UCP"
            Dim apicommand As String = "http://www.smslive247.com/http/index.aspx?cmd=sendquickmsg&owneremail=" & ownermail & "&subacct=" & subacct & "&subacctpwd=" & subacctpwd & "&message=" & message & "&sender=" & senderid & "&sendto=" & receiverList & "&msgtype=" & msgtype

            Dim c As New Net.WebClient
            Dim response As String = c.DownloadString(apicommand)
            'MsgBox(response)


            'Me.lblMsg.Text = response.ToString
            Return response
        Catch ex As Exception
            'Me.lblMsg.Text = ex.Message
        End Try
    End Function
    Private Function GetSubscriptionAmount(ByVal MemberStrength As Integer) As Decimal


        Dim InsertReg As String = ""
        Dim amount As Decimal = Nothing

        InsertReg = "Declare @retval int,@retmsg varchar(200),@Amount decimal Exec [Fetch_Registration_Subscription]"
        InsertReg = InsertReg & "'" & Me.Lbl_NoOfMembers.Text & "',"
        InsertReg = InsertReg & "@Amount Output,@retval Output,@retmsg Output Select @Amount,@retval,@retmsg"

        For Each dr In con.SqlDs(InsertReg).Tables(0).Rows
            amount = dr(0).ToString
            retval = dr(1).ToString
            retmsg = dr(2).ToString


        Next

        Return amount

    End Function
    Private Sub ViewCoopReqDetail_Load(sender As Object, e As EventArgs) Handles Me.Load


        Dim Req As String = "select * from Reg_table where UniqueID = '" & Request.QueryString("UniqueID") & "'"

            If con.SqlDs(Req).Tables(0).Rows.Count > 0 Then

                drx = con.SqlDs(Req).Tables(0).Rows(0)
                Me.LblCoopID.Text = drx.Item("CoopId").ToString
                Me.LblCoopName.Text = drx.Item("Org_name").ToString
                Me.LblEmail.Text = drx.Item("Email").ToString
                Me.LblPhone.Text = drx.Item("Phone").ToString
                Me.LblContactPerson.Text = drx.Item("contact_person").ToString
                Me.LblPhone.Text = drx.Item("phone").ToString
                Me.LblContactDesig.Text = drx.Item("Designation").ToString
                Me.LblCoopAddress.Text = drx.Item("org_address").ToString
                Me.Lbl_NoOfMembers.Text = drx.Item("MemberStrength").ToString
                Amount = GetSubscriptionAmount(Lbl_NoOfMembers.Text)
                '' Amount_Discount = Amount
                ''  Me.TxtDiscount.Text = "0"
                Me.Lbl_AmountPaid.Text = "₦" + String.Format("{0:#,#.00}", Amount)

                Me.Lbl_TotalAmount.Text = "₦" + String.Format("{0:#,#.00}", Amount)
                Me.LblTransactionID.Text = drx.Item("TransactionId").ToString
                'RadListView1.DataSource = con.SqlDs(R
                'RadListView1.DataBind()

                If Me.txtdiscount.Text = Nothing Then
                    Me.txtdiscount.Text = 0
                End If
            End If


            Dim Dstring5 As String = "SELECT cast(ltrim(rtrim(stateCode)) as varchar) statecode,Statename FROM tbl_state"
            smartobj.loadComboValues("--Select a State--- ", Me.DrpState, Dstring5)


            Me.DrpState.SelectedValue = drx.Item("StateCode").ToString


    End Sub

    Private Sub txtdiscount_TextChanged(sender As Object, e As EventArgs) Handles txtdiscount.TextChanged
        Dim DiscountPercent As Decimal = 0
        Dim DiscountAmt As Decimal = 0 : Dim AmountPaid As Decimal = 0
        AmountPaid = Amount
        DiscountPercent = CDec(txtdiscount.Text)

        If DiscountPercent = 0.00 Then
            Lbl_TotalAmount.Text = Lbl_AmountPaid.Text
            Discount = 0
            PartialPay = 0
        ElseIf txtdiscount.Text = "" Then
            Lbl_TotalAmount.Text = Lbl_AmountPaid.Text
            Discount = 0
            PartialPay = 0
        Else

            DiscountAmt = (DiscountPercent * AmountPaid) / 100
            Amount_Discount = AmountPaid - DiscountAmt
            ''  Lbl_TotalAmount.Text = CStr(Amount_Discount)
            Lbl_TotalAmount.Text = "₦" + String.Format("{0:#,#.00}", Amount_Discount)
            Lbl_TotalAmount2.Text = Amount_Discount

            Discount = 1
            PartialPay = 0

            'Me.RadioButPartial.SelectedValue = "No"
            txtPartialPayment.Text = 0.00
            LblOutstanding.Text = "0.00"
            LblOutstandingWord.Text = "₦0.00"
            LblOutstandingWord.Visible = False

        End If
    End Sub

    Private Sub txtPartialPayment_TextChanged(sender As Object, e As EventArgs) Handles txtPartialPayment.TextChanged
        Dim Amount_To_Be_Paid As Decimal = Amount

        If CDec(Me.txtPartialPayment.Text) < Amount_To_Be_Paid Then
            If CDec(txtPartialPayment.Text) <> 0 Then
                Lbl_TotalAmount2.Text = txtPartialPayment.Text

                Lbl_TotalAmount.Text = "₦" + String.Format("{0:#,#.00}", Lbl_TotalAmount2.Text)
                LblOutstandingWord.Visible = True
                LblOutstanding.Text = Amount_To_Be_Paid - CDec(txtPartialPayment.Text)
                LblOutstandingWord.Text = "₦" + String.Format("{0:#,#.00}", LblOutstanding.Text)
                PartialPay = 1
                Discount = 0

            Else
                PartialPay = 0
                Panel2.Visible = True
                Panel2.Focus()
                Panel1.Visible = False
                Label_success.Visible = False
                Label_error.Visible = True
                Label_error.Text = "Partial amount cannot be 0"
            End If
        Else
            LblOutstandingWord.Visible = False
            PartialPay = 0
            Panel2.Visible = True
            Panel2.Focus()
            Panel1.Visible = False
            Label_success.Visible = False
            Label_error.Visible = True
            Label_error.Text = "Partial amount cannot be greater or equal to the expected payment amount"
            Exit Sub
        End If


    End Sub
    Protected Sub RadioButPartial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButPartial.SelectedIndexChanged
        'If Me.RadioButPartial.SelectedValue = "Yes" Then
        '    Me.txtPartialPayment.Visible = True
        '    Me.txtPartialPayment.Text = 0.00
        '    LblOutstanding.Text = "0.00"
        '    txtdiscount.Text = 0
        'Else

        '    Me.txtPartialPayment.Text = Nothing
        '    Me.txtPartialPayment.Visible = False
        'End If

        If Me.RadioButPartial.SelectedValue = "Discount" Then
            Me.Discount_Section.Visible = True
            Me.Partial_Section.Visible = False
            LblOutstanding.Text = 0.00
            LblOutstandingWord.Visible = False
            LblOutstanding0.Visible = False
            Me.txtdiscount.Text = Nothing
            txtPartialPayment.Text = 0.00
            PartialPay = 0
            Discount = 1
        ElseIf Me.RadioButPartial.SelectedValue = "Partial" Then
            Me.txtPartialPayment.Text = Nothing
            Me.Discount_Section.Visible = False
            Me.Partial_Section.Visible = True
            LblOutstandingWord.Visible = True
            LblOutstanding0.Visible = True
            txtPartialPayment.Visible = True
            LblOutstanding.Text = 0.00
            LblOutstandingWord.Text = "₦0.00"
            Me.txtdiscount.Text = 0.00
            PartialPay = 1
            Discount = 0
        Else
            Me.Discount_Section.Visible = False
            Me.Partial_Section.Visible = False
            LblOutstanding.Visible = False
            LblOutstanding0.Visible = False
            LblOutstandingWord.Visible = False
            Discount = 0
            PartialPay = 0
            txtPartialPayment.Text = "0.00"
            LblOutstanding.Text = "0.00"
            Lbl_TotalAmount.Text = "₦" + String.Format("{0:#,#.00}", Amount)
            Lbl_TotalAmount2.Text = Amount
        End If
    End Sub
End Class
