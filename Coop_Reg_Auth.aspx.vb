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
Partial Class Coop_Reg_Auth
    Inherits SessionCheck

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim Dstring5 As String = "SELECT cast(ltrim(rtrim(stateCode)) as varchar) statecode,Statename FROM tbl_state"
            smartobj.loadComboValues("--Select a State--- ", Me.DrpState, Dstring5)

        End If



    End Sub



    Sub ViewApplication()
        Try
            Dim Appstatus As String = ""

            Dim CoopReq As String = "select * from Reg_table where Email ='" & Me.TxtDataKey.Text & "' "
            If con.SqlDs(CoopReq).Tables(0).Rows.Count > 0 Then
                drx = con.SqlDs(CoopReq).Tables(0).Rows(0)
                LblCoopName0.Text = drx.Item("Org_name").ToString
                LblCoopId0.Text = drx.Item("Coopid").ToString
                LblPhone0.Text = drx.Item("Contact_person").ToString
                Appstatus = drx.Item("Status").ToString

            End If

            If Appstatus = "Approved" Then
                smartobj.alertwindow(Me.Page, "This Application has already been approved", "prime")
                Me.ButAccept.Enabled = False
                Me.ButCancel.Enabled = False
            Else
                Me.ButAccept.Enabled = True
                Me.ButCancel.Enabled = True
            End If


            If Appstatus = "Data Migrated" Then
                smartobj.alertwindow(Me.Page, "Cooperative has completed data migration", "prime")
                Me.ButAccept.Enabled = False
                Me.ButCancel.Enabled = False
            Else
                Me.ButAccept.Enabled = True
                Me.ButCancel.Enabled = True
            End If


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ButAccept_Click(sender As Object, e As EventArgs) Handles ButAccept.Click
        Try
            Dim returnmessage As String = ""


            Dim constr As String = ConfigurationManager.ConnectionStrings("prime").ConnectionString

            Dim activationCode As String = Guid.NewGuid().ToString()
            Dim EmailId As String = Me.TxtDataKey.Text

            Dim configurationFile As Configuration = WebConfigurationManager.OpenWebConfiguration("~/web.config")
            Dim mailSettings As MailSettingsSectionGroup = configurationFile.GetSectionGroup("system.net/mailSettings")

            Dim msg As New MailMessage()
            'msg.From = New MailAddress("noreply@infosightonline.com")
            msg.From = New MailAddress(mailSettings.Smtp.From)

            msg.To.Add(EmailId)
            msg.Bcc.Add("newabode4me@yahoo.com")
            msg.Bcc.Add("Funmilola.abimbola@cwlgroup.com")




            msg.Subject = "ACTIVATION NOTIFCATION MAIL"

            msg.IsBodyHtml = True


            Dim txtPassword1 As String = "12345678"


            Dim body2 As String = "Dear " + LblPhone0.Text + " ,<br/><br/> "


            body2 += "Warm Co-operative greetings to you.<br/> <br/>"

            body2 += "This is to inform you that you that your registration has been approved.<br/> <br/>"

            body2 += "Your login details are: <br/> <br/>"

            body2 += "<b>Userid :" + Me.TxtDataKey.Text + "<br/>"

            body2 += "<b>Password :" + txtPassword1.Trim() + "<br/> <br/>"

            body2 += "<b>Please click the link below to activate your account and commence data upload. <br/><br/>"
            body2 += "<br /><a href = 'http://solutions.cooplatform.com.ng/UCPUpload/Activation.aspx?ActivationCode=" & activationCode & "'>Click here to activate your account <br/><br/></a>"


            body2 += "<b>Regards,  <br/> <br/>"

            body2 += "<b>Administrator <br/> <br/>"



            msg.Body = body2

            Dim smtp1 As New SmtpClient() 'specify the mail server address
            smtp1.Credentials = New Net.NetworkCredential(mailSettings.Smtp.From, mailSettings.Smtp.Network.Password)
            smtp1.Host = mailSettings.Smtp.Network.Host
            smtp1.Port = mailSettings.Smtp.Network.Port
            smtp1.Timeout = 700000




            Try 


               MSGFormat()
                smtp1.Send(msg)

                Using con As New SqlConnection(constr)
                    Using cmd As New SqlCommand("INSERT INTO UserActivation(UserId,ActivationCode) VALUES(@Email, @ActivationCode)")
                        Using sda As New SqlDataAdapter()
                            cmd.CommandType = CommandType.Text
                            cmd.Parameters.AddWithValue("@Email", Me.TxtDataKey.Text)
                            cmd.Parameters.AddWithValue("@ActivationCode", activationCode)
                            cmd.Connection = con
                            con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End Using
                    End Using
                End Using

                Dim ExMSG As String = "update Reg_table set Status='Approved' where Email = '" & Me.TxtDataKey.Text & "' "
                con.SqlDs(ExMSG)

                HideTextboxes()
                smartobj.alertwindow(Me.Page, "Record Approved successfully", "prime")

            Catch ex As Exception

                Dim ExMSG As String = "update Reg_table set Status='" & ex.Message & "' where Email = '" & Me.TxtDataKey.Text & "' "
                con.SqlDs(ExMSG)
                HideTextboxes()
                smartobj.alertwindow(Me.Page, ex.Message, "Prime")

            End Try




            'Dim UpadteRecord As String = "Update Memcos_Reg_table set status ='Approved' where EmployeeID=  '" & TxtEmployeeid.Text & "' "

            'con.SqlDs(UpadteRecord)
            ''smartobj.alertwindow(Me.Page, "Record Approved successfully: Activation message is sent to your mailbox", "Prime")

        Catch ex As Exception

            smartobj.alertwindow(Me.Page, ex.Message, "Prime")

        End Try
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Try


            Me.TxtDataKey.Text = Me.GridView1.SelectedValue

            ViewApplication()
            VisibleTextboxes()

        Catch ex As Exception

        End Try
    End Sub

    Sub HideTextboxes()
        Me.LblCoopId.Visible = False
        Me.LblCoopId0.Visible = False
        Me.LblCoopName.Visible = False
        Me.LblCoopName0.Visible = False
        Me.LblPhone.Visible = False
        Me.LblPhone0.Visible = False
        Me.ButAccept.Visible = False
        Me.ButCancel.Visible = False
    End Sub

    Sub VisibleTextboxes()
        Me.LblCoopId.Visible = True
        Me.LblCoopId0.Visible = True
        Me.LblCoopName.Visible = True
        Me.LblCoopName0.Visible = True
        Me.LblPhone.Visible = True
        Me.LblPhone0.Visible = True
        Me.ButAccept.Visible = True
        Me.ButCancel.Visible = True
    End Sub

    Protected Sub ButCancel_Click(sender As Object, e As EventArgs) Handles ButCancel.Click
        Try
            Dim UpadteRecord As String = "Update Reg_table set status ='Rejected' where Email=  '" & Me.TxtDataKey.Text & "' "

            con.SqlDs(UpadteRecord)
            HideTextboxes()
            smartobj.alertwindow(Me.Page, "Record Rejected successfully", "Prime")

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ButSearch_Click(sender As Object, e As EventArgs) Handles ButSearch.Click
        Dim Reg As String = "exec proc_UCP_Select_RFEg_Appicants  '" & Me.DrpState.SelectedValue & "','" & Me.DrpStatus.SelectedValue & "'"
        Me.GridView1.DataSource = con.SqlDs(Reg)
        Me.GridView1.DataBind()
    End Sub



    Sub MSGFormat()

        Dim newMobile5 As String = Nothing
        Dim newmgs As String = Nothing
        Dim body1 As String = ""

        Dim activationCode As String = Guid.NewGuid().ToString()
        Dim EmailId As String = Me.TxtDataKey.Text

     

        body1 += "ATTENTION! Your UCP registration has been approved by CFAN. Login to your email to complete the upload process and view login info. For more info? Call 09062741935 " & vbCrLf & vbCrLf


   






        Dim PhoneNumber As String = ""

        Dim CoopReq As String = "select * from Reg_table where Email ='" & Me.TxtDataKey.Text & "' "
        If con.SqlDs(CoopReq).Tables(0).Rows.Count > 0 Then
            drx = con.SqlDs(CoopReq).Tables(0).Rows(0)
            PhoneNumber = drx.Item("Phone").ToString

        End If

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

End Class
