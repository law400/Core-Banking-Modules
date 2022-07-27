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

Partial Class UserAccount
    Inherits System.Web.UI.Page
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
    Dim constr As String = ConfigurationManager.ConnectionStrings("prime").ConnectionString
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(UserAccount))
    Public Function GenerateTransactionID() As String

        Dim DateString As String = DateTime.Now.ToString("yyMMddHHmmss")

        Dim RandomClass As New Random()

        Dim RandomNumber2 As Integer : Dim Rand2 As String = String.Empty : Dim TransactionID As String = String.Empty


        RandomNumber2 = RandomClass.Next(100, 999)
        Rand2 = CStr(RandomNumber2)


        TransactionID = Rand2 + DateString

        Return TransactionID

    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try


            If txtUsername.Text = "" Then

                ''  smartobj.alertwindow(Me.Page, "Please Enter your Organization Name", "Good News!")

                smartobj.ShowToast(Me.Page, ToastType.Warning, "Please Enter your Organization Name", "Oops!", ToastPosition.TopRight, True)

                'MsgBox("Not a valid Email address ")
                Me.txtUsername.Focus()
                Exit Sub
            End If

            If txtCoopID.Text = "" Then
                ''  smartobj.alertwindow(Me.Page, "Please Enter Your Cooperative Registration number", "Good News!")

                smartobj.ShowToast(Me.Page, ToastType.Warning, "Please Enter Your Cooperative Registration number", "Oops!", ToastPosition.TopRight, True)

                Me.txtCoopID.Focus()
                Exit Sub
            End If

            If txtOrdAdd.Text = "" Then
                '' smartobj.alertwindow(Me.Page, "Please Enter Your Address", "Good News!")

                smartobj.ShowToast(Me.Page, ToastType.Warning, "Please Enter Cooperative Contact Address", "Oops!", ToastPosition.TopRight, True)

                Me.txtOrdAdd.Focus()
                Exit Sub
            End If


            If Me.DrpState.SelectedValue = 0 Then
                '' smartobj.alertwindow(Me.Page, "Please select State", "Good News!")

                smartobj.ShowToast(Me.Page, ToastType.Warning, "Please select State", "Oops!", ToastPosition.TopRight, True)

                Me.DrpState.Focus()
                Exit Sub
            End If


            If txtPhone.Text = "" Then
                '' smartobj.alertwindow(Me.Page, "Please Enter Your Contact person Phone Number", "Good News!")

                smartobj.ShowToast(Me.Page, ToastType.Warning, "Please Enter Your Contact person Phone Number", "Oops!", ToastPosition.TopRight, True)


                Me.txtPhone.Focus()
                Exit Sub
            End If


            If Not IsNumeric(txtPhone.Text) Then

                '' smartobj.alertwindow(Me.Page, "Only Numeric Numeric Number is allowed", "Good News!")

                smartobj.ShowToast(Me.Page, ToastType.Warning, "Only Numeric Numeric Number is allowed", "Oops!", ToastPosition.TopRight, True)

                Me.txtPhone.Focus()
                Exit Sub
            End If

            If Me.txtEmail.Text = "" Then

                ''  smartobj.alertwindow(Me.Page, "Please Enter Your Email  Address", "Good News!")

                smartobj.ShowToast(Me.Page, ToastType.Warning, "Please Enter Contact Email Address", "Oops!", ToastPosition.TopRight, True)

                TxtAlterEmail2.Text = ""
                Me.txtEmail.Focus()
                Exit Sub
            End If

            Dim pattern As String
            pattern = "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"

            If Not Regex.IsMatch(Me.txtEmail.Text.Trim, pattern) Then

                ''   smartobj.alertwindow(Me.Page, "Please Enter Your Email Address Correctly", "Good News!")

                smartobj.ShowToast(Me.Page, ToastType.Warning, "Please Enter Your Contact Email Address Correctly", "Oops!", ToastPosition.TopRight, True)

                Me.txtEmail.Focus()
                Exit Sub
            End If


            If txtContactPerson.Text = "" Then

                '' smartobj.alertwindow(Me.Page, "Please Enter Your Contact person", "Good News!")

                smartobj.ShowToast(Me.Page, ToastType.Warning, "Please Enter Your Contact Person", "Oops!", ToastPosition.TopRight, True)

                Me.txtContactPerson.Focus()
                Exit Sub
            End If

            If txtDesignation.Text = "" Then

                '' smartobj.alertwindow(Me.Page, "Please Enter Your Designation", "Good News!")

                smartobj.ShowToast(Me.Page, ToastType.Warning, "Please Enter Your Contact Person's Designation", "Oops!", ToastPosition.TopRight, True)

                Me.txtDesignation.Focus()
                Exit Sub
            End If















            'if TxtAlterEmail1.Text ="" then

            'TxtAlterEmail1.Text ="Funmilola.abimbola@cwlgroup.com"

            'end if 

            'if TxtAlterEmail2.Text ="" then

            'TxtAlterEmail2.Text ="Funmilola.abimbola@cwlgroup.com"

            'end if 

            If agree.Checked = False Then
                smartobj.ShowToast(Me.Page, ToastType.Warning, "Please accept Terms and Condition", "Oops!", ToastPosition.TopRight, True)

                Me.agree.Focus()
                Exit Sub
            End If

            Dim InsertReg As String = ""

            Dim txtPassword As String = "12345678"

            Dim TransactionID As String = GenerateTransactionID()
            'InsertReg = "Declare @retval int,@retmsg varchar(1000) Exec [Insert_User]"
            'InsertReg = InsertReg & "'" & Me.txtUsername.Text & "','" & Me.txtOrdAdd.Text.Trim & "',"
            'InsertReg = InsertReg & "'" & Me.txtContactPerson.Text.Trim & "','" & Me.txtDesignation.Text.Trim & "',"
            'InsertReg = InsertReg & "'" & Me.txtEmail.Text.Trim & "','" & Me.txtPhone.Text.Trim & "',"
            'InsertReg = InsertReg & "'" & con.EncryptText(txtPassword.Trim()) & "','" & con.EncryptText(txtPassword.Trim()) & "',"
            'InsertReg = InsertReg & "'" & Me.txtCoopID.Text.Trim & "' , '" & Me.DrpState.SelectedValue.Trim & "',"
            'InsertReg = InsertReg & "'" & Me.txtAlterEmail1.Text.Trim & "' , '" & Me.TxtAlterEmail2.Text & "','" & TxtReferrer.Text.Trim & "','" & TxtMemberStrength.Text.Trim & "','" & TransactionID & "',"
            'InsertReg = InsertReg & "@retval Output,@retmsg Output Select @retval,@retmsg"

            'For Each dr In con.SqlDs(InsertReg).Tables(0).Rows
            '    retval = dr(0).ToString
            '    retmsg = dr(1).ToString
            'Next

            Dim Password As String = con.EncryptText(txtPassword.Trim())

            Dim constring As String = ConfigurationManager.ConnectionStrings("Prime").ConnectionString
            Using con As New System.Data.SqlClient.SqlConnection(constring)
                Using cmd As New System.Data.SqlClient.SqlCommand("[Insert_User]", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@Org_name", Me.txtUsername.Text)
                    cmd.Parameters.AddWithValue("@Org_Addres", Me.txtOrdAdd.Text.Trim)
                    cmd.Parameters.AddWithValue("@contact_person", Me.txtContactPerson.Text.Trim)
                    cmd.Parameters.AddWithValue("@Designation", Me.txtDesignation.Text.Trim)
                    cmd.Parameters.AddWithValue("@Email", Me.txtEmail.Text.Trim)
                    cmd.Parameters.AddWithValue("@Phone", Me.txtPhone.Text.Trim)
                    cmd.Parameters.AddWithValue("@Password", Password)
                    cmd.Parameters.AddWithValue("@Comfirm_Password", Password)
                    cmd.Parameters.AddWithValue("@CoopId", Me.txtCoopID.Text.Trim)
                    cmd.Parameters.AddWithValue("@StateCode", Me.DrpState.SelectedValue.Trim)
                    cmd.Parameters.AddWithValue("@AltEmail1", Me.txtAlterEmail1.Text.Trim)
                    cmd.Parameters.AddWithValue("@AltEmail2", Me.TxtAlterEmail2.Text)
                    cmd.Parameters.AddWithValue("@referrer", TxtReferrer.Text.Trim)
                    cmd.Parameters.AddWithValue("@MemberStrength", TxtMemberStrength.Text.Trim)
                    cmd.Parameters.AddWithValue("@TransactionID", TransactionID)
                    cmd.Parameters.Add("@retval", SqlDbType.Int)
                    cmd.Parameters("@retval").Direction = ParameterDirection.Output
                    cmd.Parameters.Add("@retmsg", SqlDbType.VarChar, 200)
                    cmd.Parameters("@retmsg").Direction = ParameterDirection.Output
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    Me.retval = cmd.Parameters("@retval").Value.ToString()
                    Me.retmsg = cmd.Parameters("@retmsg").Value.ToString()
                End Using
            End Using

            If retval = 0 Then
                Label1.Focus()
                SendEmail()

                Dim Mailsent As String = " Update reg_table set Status= 'Mail Sent' where  Email ='" & Me.txtEmail.Text.Trim & "'"
                con.SqlDs(Mailsent)
                CleartextBoxes()

                ''   smartobj.alertwindow(Me.Page, retmsg, "Good News!")

                'Dim url As String = "~/RegFee?Txn=" & con.EncryptText(TransactionID.Trim) & "&email=" & con.EncryptText(txtEmail.Text.Trim) & "&Coop=" & con.EncryptText(txtUsername.Text.Trim) & "&Amount=" & con.EncryptText(Lblamt.Text.ToString) & "&mobileno=" & con.EncryptText(txtPhone.Text.Trim) & ""

                'Response.Redirect(url)

                  txtUsername.Focus()

                smartobj.ShowToast(Me.Page, ToastType.Success, retmsg, "Yessss!", ToastPosition.TopRight, True)





            Else

                ''  smartobj.alertwindow(Me.Page, retmsg, "Good News!")

                Label2.Focus()

                txtUsername.Focus()
                smartobj.ShowToast(Me.Page, ToastType.Error, retmsg, "Error!", ToastPosition.TopRight, True)



            End If



        Catch ex As Exception

            logger.Info("Coop Creation: UserAccount.aspx  Button1_Click" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
            Label2.Focus()
            smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)

        End Try
    End Sub


    Private Sub SendActivationEmail()
        Dim constr As String = ConfigurationManager.ConnectionStrings("prime").ConnectionString
        Dim activationCode As String = Guid.NewGuid().ToString()
        Dim EmailId As String = txtEmail.Text.Trim()
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("INSERT INTO UserActivation(UserId,ActivationCode) VALUES(@Email, @ActivationCode)")
                Using sda As New SqlDataAdapter()
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@Email", EmailId)
                    cmd.Parameters.AddWithValue("@ActivationCode", activationCode)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        End Using

        Dim configurationFile As Configuration = WebConfigurationManager.OpenWebConfiguration("~/web.config")
        Dim mailSettings As MailSettingsSectionGroup = configurationFile.GetSectionGroup("system.net/mailSettings")
        Dim msg As New MailMessage()
        'msg.From = New MailAddress("noreply@infosightonline.com")
        msg.From = New MailAddress(mailSettings.Smtp.From)
        msg.To.Add(txtEmail.Text.Trim)


        msg.Subject = "UCP Registration Email Activation"

        msg.IsBodyHtml = True


        Dim body2 As String = "Hello " + txtUsername.Text.Trim() + "<br/> "

        Dim txtPassword1 As String = "12345678"

        'Dim body2 As String = <b><font Size ="3"><font color="Blue"> "Dear " + txtUsername.Text.Trim() + " </b><DIV>&nbsp;</DIV>,"

        body2 += "Thank you for having interest in our solution. Based on the information provided by you, your account has been created <br/>"

        body2 += "<b>Login Information : <br/>"

        body2 += "<b>UserId :" + txtEmail.Text.Trim() + "<br/> <br/>"

        body2 += "<b>Password :" + txtPassword1.Trim() + "<br/> <br/>"

        'body2 += "<br /><a href = Url='~/Activation.aspx ? ActivationCode=" & activationCode + "'>Click here to activate your account.</a>"

        'body2 += "<a href = '" + Request.Url.AbsoluteUri("Activation.aspx") + "?ActivationCode='" & activationCode + "'>Click here to activate your account.</a>"


        'body2 += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("UserAccount.aspx", Convert.ToString("Activation.aspx?ActivationCode=") & activationCode) + "'>Click here to activate your account.</a>"

        'body2 += "<br /><a href = '" + Request.Url.AbsoluteUri("Activation.aspx") + "?ActivationCode=" & activationCode + " '>Click here to activate your account.</a>"
        'body2 += "<a href = '" + Request.Url.AbsoluteUri.Replace("UserAccount.aspx", Convert.ToString("Activation.aspx")) + "?ActivationCode='" & activationCode + "'>Click here to activate your account.</a

        body2 += "<br /><a href = 'http://41.78.157.166/Multi_Migrats/Activation.aspx?ActivationCode=" & activationCode & "'>Click here to activate your account <br/></a>"


        body2 += "Thank you for your interest in Cooperative Solution."
        msg.Body = body2




        Dim smtp1 As New SmtpClient() 'specify the mail server address
        smtp1.Credentials = New Net.NetworkCredential(mailSettings.Smtp.From, mailSettings.Smtp.Network.Password)
        smtp1.Host = mailSettings.Smtp.Network.Host
        smtp1.Port = mailSettings.Smtp.Network.Port
        smtp1.Timeout = 700000
        smtp1.Send(msg)


        'End Using
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim Dstring5 As String = "SELECT cast(ltrim(rtrim(stateCode)) as varchar) statecode,Statename FROM tbl_state"
            smartobj.loadComboValues("[Cooperative Location] ", Me.DrpState, Dstring5)

        End If
        Dim Dstring15 As String = "select cast(ltrim(rtrim(ID))as varchar)ID ,Coop_Type from Tbl_Cooperative_Type where status=1"
        smartobj.loadComboValues("[Choose a Cooperative Type] ", Me.DropCoopType, Dstring15)

        Dim ent As String = "  "
        '' agree.Text = ent & "  " & ""
        '' Button1.Enabled = False
        'Dim activationCode As String = Request.QueryString("ActivationCode")
        'Dim UserNames As String = Request.QueryString("UserName")
        ''Dim activationCode As String = If(Not String.IsNullOrEmpty(Request.QueryString("ActivationCode")), Request.QueryString("ActivationCode"), Guid.Empty.ToString())


        'Dim UpadteAct As String = "Update UserActivation set ActivationStatus = 1 WHERE ActivationCode = " & activationCode & ""
        'con.SqlDs(UpadteAct)

        'Me.lbl_Fullname.Text = UserNames
        'Button1.Enabled = False
    End Sub

   ' Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
     '   Response.Redirect("~/Default.aspx")
  '  End Sub




    Sub CleartextBoxes()
        Me.txtUsername.Text = ""
        Me.txtContactPerson.Text = ""
        Me.txtDesignation.Text = ""
        Me.txtPhone.Text = ""
        Me.txtOrdAdd.Text = ""
        Me.txtEmail.Text = ""
        Me.txtCoopID.Text = ""
        Me.TxtAlterEmail1.Text = ""
        Me.TxtAlterEmail2.Text = ""

    End Sub

     Sub SendEmail()
        Try





            Dim activationCode As String = Guid.NewGuid().ToString()
            Dim configurationFile As Configuration = WebConfigurationManager.OpenWebConfiguration("~/web.config")
            Dim mailSettings As MailSettingsSectionGroup = configurationFile.GetSectionGroup("system.net/mailSettings")
            Dim msg As New MailMessage()
            'msg.From = New MailAddress("noreply@infosightonline.com")
            msg.From = New MailAddress(mailSettings.Smtp.From)


            If TxtAlterEmail1.Text = "" Then

                TxtAlterEmail1.Text = "Funmilola.abimbola@cwlgroup.com"

            End If

            If TxtAlterEmail2.Text = "" Then

                TxtAlterEmail2.Text = "Funmilola.abimbola@cwlgroup.com"

            End If

            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand("INSERT INTO UserActivation(UserId,ActivationCode) VALUES(@Email, @ActivationCode)")
                    Using sda As New SqlDataAdapter()
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@Email", Me.txtEmail.Text)
                        cmd.Parameters.AddWithValue("@ActivationCode", activationCode)
                        cmd.Connection = con
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End Using
            End Using


            msg.To.Add(Txtemail.Text)
            msg.Bcc.Add("newabode4me@yahoo.com")
            msg.Bcc.Add("Funmilola.abimbola@cwlgroup.com")
            msg.Bcc.Add(TxtAlterEmail1.Text)
            msg.Bcc.Add(TxtAlterEmail2.Text)



            msg.Subject = "UCP REGISTRATION ACTIVATION NOTIFICATION MAIL"

            msg.IsBodyHtml = True

            Dim FilePath As String = HttpContext.Current.Server.MapPath("~/Email_Template.html")
            Dim str As StreamReader = New StreamReader(FilePath)
            Dim MailText As String = str.ReadToEnd()
            str.Close()
            MailText = MailText.Replace("{Username}", txtUsername.Text.Trim)

            Dim subject As String = "Warm Co-operative greetings to you."

            MailText = MailText.Replace("{Heading}", msg.Subject.Trim())

            MailText = MailText.Replace("{Title}", subject.Trim)

            Dim body2 As String = ""

            Dim FullName As String = txtContactPerson.Text

            ''     body2 += "Dear " + FullName + " ,<br/><br/> "

            ''   body2 = "Dear " + txtUsername.Text + " ,<br/><br/> "


            'Dim body2 As String = <b><font Size ="3"><font color="Blue"> "Dear " + txtUsername.Text.Trim() + " </b><DIV>&nbsp;</DIV>,"
            '' body2 += "Warm Co-operative greetings to you.<br/> <br/>"
            body2 += "This is to acknowledge the receipt of your registration. <br/>"
            body2 += "Click<a href = 'https://solutions.cooplatform.com.ng/Finedge_UCP/Activation.aspx?ActivationCode=" & activationCode & "'> <b>here</b> </a>to confirm your email.<br/>"

            'body2 += "<b>Please click the link below to confirm your email address to proceed in the approval of your registration. <br/><br/>"
            ''   body2 += "<br /><a href = 'http://solutions.cooplatform.com.ng/UCP/Activation.aspx?ActivationCode=" & activationCode & "'>Click here to confirm your email <br/><br/></a>"
            ''body2 += "<br /><a href = 'http://41.78.157.166/Finedge_UCP/Activation.aspx?ActivationCode=" & activationCode & "'>Click here to confirm your email <br/><br/></a>"
            'body2 += "<b><a href = 'http://solutions.cooplatform.com.ng/Finedge_UCP/Activation.aspx?ActivationCode=" & activationCode & "'>Click here to confirm your email <br/><br/></a>"
            '' body2 += "<br /><a href = 'http://localhost:32651/Activation.aspx?ActivationCode=" & activationCode & "'>Click here to confirm your email <br/><br/></a>"
            body2 += "Once your email is confirmed, your application will be reviewed and you will be contacted within 72 hours. <br/>"
            body2 += "If you do not hear from us in 72 hours, please contact Us with details below: <br/><br/>"
            body2 += "<b>CWG PLC</b><br/>"
            body2 += "Address: Block 54A, Plot 10, Off Rufus Giwa Street, Lekki Phase 1, Lagos. <br/>"
            body2 += "Telephone: +2349062741935 <br/>"
            body2 += "E-mail(s): support.cooperative@cwg-plc.com ; UCP.Support@cwg-plc.com <br/><br/>"

            body2 += "<b>CFAN</b><br/>"
            body2 += "Address: Plot 3, Ubiaja Crescent , Near Tantalizer, Garki II, Abuja. <br/>"
            body2 += "Telephone: +234(0)9 292 1197, +234(0) 803 294 5737, +234(0) 817 543 8979 <br/>"
            body2 += "E-mail: contact@cfan.coop <br/><br/>"
            body2 += "Thank you for your interest in Unified Cooperative Platform (UCP). <br/><br/>"




            'body2 += "<b>Login Information : <br/>"

            'body2 += "<b>EmployeeID :" + TxtEmployeeid.Text + "<br/> <br/>"

            'body2 += "<b>Password :" + txtPassword1.Trim() + "<br/> <br/>"

            body2 += "<b>Warm Regards,<br/> "

            body2 += "<b>Administrator<br/> "


            MailText = MailText.Replace("{Body}", body2)

            MailText = MailText.Replace("{user}", txtUsername.Text.Trim())

            MailText = MailText.Replace("{email}", txtEmail.Text.Trim())

            msg.Body = MailText
            ''  msg.Body = body2

            Dim smtp1 As New SmtpClient() 'specify the mail server address
            smtp1.Credentials = New Net.NetworkCredential(mailSettings.Smtp.From, mailSettings.Smtp.Network.Password)
            smtp1.Host = mailSettings.Smtp.Network.Host
            smtp1.Port = mailSettings.Smtp.Network.Port
            smtp1.Timeout = 700000
            smtp1.Send(msg)
            MSGFormat()
        Catch ex As Exception

            ''    smartobj.alertwindow(Me.Page, "Please Provide a valide Email Address", "Prime")
            logger.Info("Cooperative Registration: UserAccount.aspx  SendEmail()" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
            smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)


        End Try
    End Sub
    Sub MSGFormat()
        Try
            Dim newMobile5 As String = Nothing
            Dim newmgs As String = Nothing

            Dim body1 As String = ""




            body1 += " Your UCP registration has been received, kindly check your email for activation. Once email is activated, your registration shall be approved shortly. For more information, please contact 09062741935 " & vbCrLf & vbCrLf









            'newmgs = (TextBox1.Text.Trim + " " + "scores" + " " + "60 Marks" + "" + " " + "in" + " " + "maths")
            If txtPhone.Text <> "" Then

                If Mid(txtPhone.Text, 1, 3) = "234" Then
                    newMobile5 = txtPhone.Text.Trim
                ElseIf Mid(txtPhone.Text, 1, 4) = "+234" Then
                    newMobile5 = "234" + Mid(lbl_id.Text, 5, Len(txtPhone.Text))
                Else
                    txtPhone.Text = Mid(txtPhone.Text, 2, Len(txtPhone.Text))
                    newMobile5 = "234" + txtPhone.Text.Trim
                End If
                SendSmsHTTP2(body1, newMobile5)
            End If

        Catch ex As Exception

            ''    smartobj.alertwindow(Me.Page, "Please Provide a valide Email Address", "Prime")
            logger.Info("Cooperative Registration: UserAccount.aspx  MSGFormat()" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")


        End Try
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

    'Private Sub TxtMemberStrength_TextChanged(sender As Object, e As EventArgs) Handles TxtMemberStrength.TextChanged
    '    Dim InsertReg As String = ""
    '    Dim amount As String = ""
    '    InsertReg = "Declare @Amount decimal(22,2), @retval int,@retmsg varchar(200) Exec [Fetch_Registration_Subscription]"
    '    InsertReg = InsertReg & "'" & Me.TxtMemberStrength.Text.Trim & "',"
    '    InsertReg = InsertReg & "@Amount Output,@retval Output,@retmsg Output Select @Amount, @retval,@retmsg"

    '    For Each dr In con.SqlDs(InsertReg).Tables(0).Rows
    '        amount = dr(0).ToString()
    '        Lblamt.Text = dr(0)
    '        retval = dr(1).ToString
    '        retmsg = dr(2).ToString
    '    Next


    '    Dim AmountString As String = "Subscription amount: ₦" + String.Format("{0:#,#}", amount)


    '    '''  TxtAmount.Text = AmountString
    '    LblSub.Text = "Subscription Amount: ₦" + String.Format("{0:C}", amount)
    'End Sub


    'Protected Sub agree_CheckedChanged(sender As Object, e As EventArgs) Handles agree.CheckedChanged
    '    If agree.Checked = True Then
    '        Button1.Enabled = True
    '    Else
    '        Button1.Enabled = False
    '    End If
    'End Sub
End Class
