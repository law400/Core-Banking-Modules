Imports System
Imports System.IO
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Net
Imports System.Data.Entity
Imports Telerik.Web.UI
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text
Imports System.Security.Cryptography
Imports System.Xml
Imports System.Data
Imports System.Web.WebPages
Imports log4net
Imports log4net.Config
Imports Toastr


Partial Class RegFee
    Inherits System.Web.UI.Page

    Dim constring As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("prime").ConnectionString)
    Dim Consume_URL As String = ConfigurationSettings.AppSettings("Consume_Url")
    Dim Client_id As String = String.Empty : Dim product_id As String = String.Empty
    Dim product_description As String = String.Empty : Dim currency As String = String.Empty
    Dim Return_URI As String = String.Empty : Dim Secret_Key As String = String.Empty
    Dim TotalAmount As Decimal = 0 : Dim payAmt As Decimal = 0 : Dim ConvenienceFee As Decimal = 0
    Dim SHA512_Hash As String = String.Empty
    Dim TransactionId As String = String.Empty
    Dim TransactionId_Old As String = String.Empty
    Dim SHA512_InputString As String = String.Empty
    Dim EmployeeyNo As String = String.Empty
    Dim Node_id As String = String.Empty
    Dim Fullname As String = String.Empty
    Dim MobileNo As String = String.Empty
    Dim CoopEmail As String = String.Empty
    Dim Pay_type As String = String.Empty
    Dim Username As String = String.Empty
    Dim FeeAmount As Decimal = 0
    Dim PaymentAmount As Decimal = 0
    Dim Payment_URL As String = ""
    Dim Amount As Decimal = 0
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(RegFee))



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        LoadPayment()
    End Sub


    Sub LoadPayment()

        Try
            Dim Retval As Integer
            Dim Retmsg As String = ""
            If Request.QueryString("TransactionId") = "" Then
                smartobj.ShowToast(Me.Page, ToastType.Error, "Invalid Transaction ID", "Oops!", ToastPosition.TopRight, True)
                Exit Sub
            End If

            'If Request.QueryString("Email") = "" Then
            '    smartobj.ShowToast(Me.Page, ToastType.Error, "Invalid Email", "Oops!", ToastPosition.TopRight, True)
            '    Exit Sub
            'End If

            'If Request.QueryString("Coop") = "" Then
            '    smartobj.ShowToast(Me.Page, ToastType.Error, "Invalid Coop Name", "Oops!", ToastPosition.TopRight, True)
            '    Exit Sub
            'End If

            Amount = Request.QueryString("Amount")

            TxtAmount.Text = "₦" + String.Format("{0:#,#.00}", Amount)

            payAmt = Amount


            Pay_type = "Coop_Signup_Reg_Fee"
            Dim TransactionID_Encrypt As String = "" : Dim TransactionID As String = ""
            TransactionID_Encrypt = Request.QueryString("TransactionId")
            Dim FullNames As String = Request.QueryString("Coop")
            TransactionId_Old = con.DecryptNewest(TransactionID_Encrypt)


            TransactionID = GenerateTransactionID()




            LblTransactionId.Text = TransactionID
            Fullname = con.DecryptNewest(FullNames)

            Dim CoopEmails As String = Request.QueryString("Email")

            CoopEmail = con.DecryptNewest(CoopEmails)


            Dim MobileNos As String = Request.QueryString("Phone")
            MobileNo = con.DecryptNewest(MobileNos)

            txtname.Text = Fullname
            txtEmail.Text = CoopEmail
            TxtPhone.Text = MobileNo


            Dim Qry As String = "Update reg_table set TransactionId = '" & TransactionID & "' where TransactionId = '" & TransactionId_Old & "' and Email  = '" & CoopEmail & "'"
            con.SqlDs(Qry)
            ''cmd.CommandText = "Proc_UCP_Payment_Confirmation"
            'Dim UpdateReg As String = ""
            'UpdateReg = "Declare @retval int,@retmsg varchar(200) Exec [Proc_UCP_Payment_Confirmation]"
            'UpdateReg = UpdateReg & "'" & Me.TransactionId.Trim & "',"
            'UpdateReg = UpdateReg & "@retval Output,@retmsg Output Select @retval,@retmsg"

            'For Each dr In con.SqlDs(UpdateReg).Tables(0).Rows
            '    Retval = dr(0).ToString
            '    Retmsg = dr(1).ToString
            'Next
            Dim Status As String = ""
            Dim UpdateReg2 As String = "Select isnull(Status,'') from Tbl_UCP_PaymentLog with(nolock) where ltrim(rtrim(Transactionid)) = '" & TransactionID.Trim & "'"
            For Each dr As Data.DataRow In con.SqlDs(UpdateReg2).Tables(0).Rows

                Status = dr(0).ToString
            Next
            If Status = "00" Or Status = "01" Then
                Retmsg = "Payment transaction has been completed or expired"
                ' If Retval = 998 Then
                BtnSubmit.Enabled = False
                Drp_Paymenttype.Enabled = False

                Me.Panel2.Visible = True
                Me.Panel1.Visible = False

                Me.Label_error.Visible = True

                Me.Label_error.Text = Retmsg
                Me.Label_error.Focus()

                smartobj.ShowToast(Me.Page, ToastType.Error, "Oops!" + Retmsg, "Oops!", ToastPosition.TopRight, True)
                Exit Sub

            End If


            Dim cmd As New SqlCommand()
            constring.Open()
            cmd.CommandType = CommandType.StoredProcedure



            cmd.CommandText = "proc_UCP_Fetch_PaymentValues"
            cmd.CommandTimeout = 500
            cmd.Connection = constring

            Dim RegAdapter As New SqlDataAdapter()
            RegAdapter.SelectCommand = cmd
            Dim DataReg As New DataSet()
            RegAdapter.Fill(DataReg)

            For Each Tablex As DataTable In DataReg.Tables


                ConvenienceFee = Tablex.Rows(0)("Convenience_Amt")
                TxtProcessingFee.Text = "₦" + String.Format("{0:#,#.00}", ConvenienceFee)
                Client_id = Tablex.Rows(0)("Client_id")
                product_id = Tablex.Rows(0)("Product_id")
                product_description = Tablex.Rows(0)("Product_description")
                currency = Tablex.Rows(0)("Currency")
                Return_URI = Tablex.Rows(0)("Return_URL_Admin")
                Secret_Key = Tablex.Rows(0)("Secret_Key")
                Payment_URL = Tablex.Rows(0)("Payment_URL")


                TotalAmount = payAmt + ConvenienceFee

                Txt_TotalPay.Text = "₦" + String.Format("{0:#,#.00}", TotalAmount)
                TotalAmount = Decimal.Truncate(TotalAmount)
            Next




        Catch ex As Exception

            logger.Info("RegFee.aspx: Reg Fee  - ERROR AT     Sub LoadPayment() '" _
        & vbNewLine & "   <<<<Direction: OUTPUT" _
        & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
        & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
        & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
        & vbNewLine & "************************************************************************************************************************************************************************************")

        Finally
            constring.Close()
        End Try



    End Sub

    Public Shared Function GenerateSHA256String(ByVal inputString As String) As String
        Dim sha256 As SHA256 = SHA256Managed.Create()
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(inputString)
        Dim hash As Byte() = sha256.ComputeHash(bytes)
        Dim stringBuilder As New StringBuilder()

        For i As Integer = 0 To hash.Length - 1
            stringBuilder.Append(hash(i).ToString("X2"))
        Next

        Return stringBuilder.ToString()
    End Function

    Public Shared Function GenerateSHA512String(ByVal inputString As String) As String
        Dim sha512 As SHA512 = SHA512Managed.Create()
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(inputString)
        Dim hash As Byte() = sha512.ComputeHash(bytes)
        Dim stringBuilder As New StringBuilder()
        For i As Integer = 0 To hash.Length - 1
            stringBuilder.Append(hash(i).ToString("X2"))
        Next
        Return stringBuilder.ToString()
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
    Private Function PreparePOSTForm(ByVal url As String, ByVal data As NameValueCollection) As String
        Dim formID As String = "PostForm"
        Dim strForm As StringBuilder = New StringBuilder()
        strForm.Append("<form id=""" & formID & """ name=""" & formID & """ action=""" & url & """ method=""POST"">")

        For Each key As String In data
            strForm.Append("<input type=""hidden"" name=""" & key & """ value=""" & data(key) & """>")
        Next

        strForm.Append("</form>")
        Dim strScript As StringBuilder = New StringBuilder()
        strScript.Append("<script language='javascript'>")
        strScript.Append("var v" & formID & " = document." & formID & ";")
        strScript.Append("v" & formID & ".submit();")
        strScript.Append("</script>")
        Return strForm.ToString() & strScript.ToString()
    End Function

    Sub RedirectAndPOST(ByVal page As Page, ByVal destinationUrl As String, ByVal data As NameValueCollection)
        Dim strForm As String = PreparePOSTForm(destinationUrl, data)
        page.Controls.Add(New LiteralControl(strForm))
    End Sub
    Protected Sub BtnSubmit_Click(sender As Object, e As EventArgs) Handles BtnSubmit.Click
        Dim data As New NameValueCollection
        ''    TransactionId = GenerateTransactionID()
        TransactionId = LblTransactionId.Text.Trim
        If TransactionId = "" Then
            Me.Panel2.Visible = True
            Me.Panel1.Visible = False

            Me.Label_error.Visible = True

            Me.Label_error.Text = "Oops! Unable to fetch Transaction ID"
            Me.Label_error.Focus()
            smartobj.ShowToast(Me.Page, ToastType.Error, "Oops! Unable to fetch Transaction ID", "Oops!", ToastPosition.TopRight, True)
            Exit Sub
        End If
        SHA512_InputString = Client_id + TotalAmount.ToString + TransactionId + Return_URI + Secret_Key
        SHA512_Hash = GenerateSHA512String(SHA512_InputString).ToLower
        '''''Log Payment Data to DB
        Dim Retval As Integer
        Dim Retmsg As String = ""

        Try


            If Me.txtname.Text = "" Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False

                Me.Label_error.Visible = True

                Me.Label_error.Text = "Please Enter Your Cooperative Name"
                Me.txtname.Focus()

                Exit Sub
            End If

            If Me.txtEmail.Text = "" Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False

                Me.Label_error.Visible = True

                Me.Label_error.Text = "Please Enter Your Contact Email"
                Me.txtEmail.Focus()

                Exit Sub
            End If



            Dim pattern As String
            pattern = "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"

            If Not Regex.IsMatch(Me.txtEmail.Text.Trim, pattern) Then

                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Please Enter Your Email Address Correctly"
                'smartobj.alertwindow(Me.Page, "Please Enter Your Email Address Correctly", "Good News!")
                'MsgBox("Not a valid Email address ")
                Me.txtEmail.Focus()

                Exit Sub
            End If


            If TxtPhone.Text = "" Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Please Enter Your Phone Number"
                Me.TxtPhone.Focus()
                Exit Sub
            End If

            If Not IsNumeric(TxtPhone.Text) Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Only Numeric Number is allowed"
                'smartobj.alertwindow(Me.Page, "Phone Number can only be Numeric Number. ", "Good News!")
                Me.TxtPhone.Focus()
                Exit Sub
            End If


            logger.Info("************************************************************************************************************************************************************************]" _
               & vbNewLine & "Reg fee : STARTING... [*******************]" _
               & vbNewLine & "   <<<<Direction: INPUT" _
                     & vbNewLine & "      INPUT PARAMETERS LIST & " _
                     & vbNewLine & "          Username: '" & EmployeeyNo & "'" _
                     & vbNewLine & "          Request ID: '" & TransactionId & "'" _
                     & vbNewLine & "          Amount paid: '" & TotalAmount & "'" _
                     & vbNewLine & "          Fee Amount: '" & TxtProcessingFee.Text & "'" _
                     & vbNewLine & "          Total Amount Paid: '" & TotalAmount & "'" _
                      & vbNewLine & "         Return Meesage : '" & Retmsg & "'" _
                     & vbNewLine & "       INPUT PARAMETERS LIST END" & " ")



            Dim cmd As New SqlCommand()
            constring.Open()
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Username", Username)

            cmd.Parameters.AddWithValue("@EmployeeName", Fullname)
            cmd.Parameters.AddWithValue("@Node_id", Node_id)
            cmd.Parameters.AddWithValue("@Pay_type", Pay_type)
            cmd.Parameters.AddWithValue("@Email", CoopEmail)
            cmd.Parameters.AddWithValue("@Mobile_No", MobileNo)
            cmd.Parameters.AddWithValue("@TransactionId", TransactionId)
            cmd.Parameters.AddWithValue("@Transaction_hash", SHA512_Hash)

            cmd.Parameters.AddWithValue("@Fee_Amt", ConvenienceFee)

            cmd.Parameters.AddWithValue("@PaymentAmt", Amount)

            cmd.Parameters.AddWithValue("@TotalPaymentAmt", TotalAmount)

            cmd.CommandText = "Proc_UCP_Payment_Insert"
            cmd.CommandTimeout = 500
            cmd.Connection = constring

            Dim RegAdapter As New SqlDataAdapter()
            RegAdapter.SelectCommand = cmd
            Dim DataReg As New DataSet()
            RegAdapter.Fill(DataReg)




            For Each Tablex As DataTable In DataReg.Tables

                Retval = Tablex.Rows(0)("Retval")
                Retmsg = Tablex.Rows(0)("RetMsg")


                cmd.Parameters.AddWithValue("@EmployeeName", Fullname)
                cmd.Parameters.AddWithValue("@Node_id", Node_id)
                cmd.Parameters.AddWithValue("@Pay_type", Pay_type)
                cmd.Parameters.AddWithValue("@Email", CoopEmail)
                cmd.Parameters.AddWithValue("@Mobile_No", MobileNo)
                cmd.Parameters.AddWithValue("@TransactionId", TransactionId)
                cmd.Parameters.AddWithValue("@Transaction_hash", SHA512_Hash)

                cmd.Parameters.AddWithValue("@Fee_Amt", ConvenienceFee)

                cmd.Parameters.AddWithValue("@PaymentAmt", Amount)

                cmd.Parameters.AddWithValue("@TotalPaymentAmt", TotalAmount)





                If Retval = 0 Then

                    data.Add("appName", Client_id)
                    data.Add("returnURL", Return_URI)
                    data.Add("payerName", Fullname)
                    data.Add("payerEmail", CoopEmail)
                    data.Add("paymentType", Drp_Paymenttype.SelectedValue)
                    data.Add("amt", TotalAmount)
                    data.Add("hash", SHA512_Hash)
                    data.Add("payerPhone", MobileNo)
                    data.Add("transactionId", TransactionId)

					logger.Info("************************************************************************************************************************************************************************]" _
					 & vbNewLine & "New Reg fee to Payment Gateway: STARTING... [*******************]" _
					 & vbNewLine & "   <<<<Direction: INPUT" _
                     & vbNewLine & "      INPUT PARAMETERS LIST & " _
                     & vbNewLine & "          appName: '" & Client_id & "'" _
                     & vbNewLine & "          returnURL: '" & Return_URI & "'" _
                     & vbNewLine & "          payerName: '" & Fullname & "'" _
                     & vbNewLine & "          payerEmail: '" & CoopEmail & "'" _
                     & vbNewLine & "          paymentType: '" & Drp_Paymenttype.SelectedValue & "'" _
                     & vbNewLine & "          amt : '" & TotalAmount & "'" _
					 & vbNewLine & "          hash: '" & SHA512_Hash & "'" _
                     & vbNewLine & "          payerPhone: '" & MobileNo & "'" _
                     & vbNewLine & "          transactionId : '" & TransactionId & "'" _
                     & vbNewLine & "       INPUT PARAMETERS LIST END" & " ")


                    If Payment_URL = "" Then
                        Me.Panel2.Visible = True
                        Me.Panel1.Visible = False

                        Me.Label_error.Visible = True

                        Me.Label_error.Text = "Oops! System Error Occurred,unable to send payment"
                        Me.Label_error.Focus()
                        smartobj.ShowToast(Me.Page, ToastType.Error, "Oops! System Error Occurred", "Oops!", ToastPosition.TopRight, True)
                        Exit Sub
                    End If
                    'HttpHelper.RedirectAndPOST(Me.Page, "https://www.cwgpay.com/indexRemita/pay", data)
                    RedirectAndPOST(Me.Page, Payment_URL, data)


                Else
                    Label_error.Text = Retmsg
                    Panel1.Visible = False
                    Panel2.Visible = True
                    Panel2.Focus()
                End If
            Next


        Catch ex As Exception
            Label_error.Text = Retmsg
            Panel1.Visible = False
            Panel2.Visible = True
            Panel2.Focus()

        Finally
            constring.Close()


        End Try
    End Sub
End Class