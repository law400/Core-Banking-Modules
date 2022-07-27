
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Configuration
Imports System.Net.Mail
Imports System.Web.Configuration
Imports log4net
Imports log4net.Config
Partial Class CustomerService_AddCoopReg
    Inherits SessionCheck2
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(CustomerService_AddCoopReg))
    Dim retmsg As String = ""
    Dim retval As Integer
    Private qry As String, qryval As String = ""
    Dim profileImg As String = ""
    Dim idimage As String = ""
    Dim pName As String
    Public Property ProfileImage() As String
        Get
            Return profileImg
        End Get
        Set(value As String)
            profileImg = value
        End Set
    End Property
    Public Property IDcardImage() As String
        Get
            Return idimage
        End Get
        Set(value As String)
            idimage = value
        End Set
    End Property
    Private MyCon As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Prime").ConnectionString)
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Me.Calendar1.Visible = False
                Me.Panel3.Visible = False
                Me.TxtGuid.Text = Guid.NewGuid.ToString()
                Dim Dstring61 As String = "SELECT cast(ltrim(rtrim(stateCode)) as varchar) statecode,Statename FROM tbl_state where status=1 and Countrycode='" & "001" & "'"
                smartobj.loadComboValues("--Select a State--- ", Me.DrpState, Dstring61)
                Dim Dstring7 As String = "SELECT cast(ltrim(rtrim(sectorcode)) as varchar) sectorcode,sectorname FROM tbl_sector where status=1"
                smartobj.loadComboValues("--Select a Sector--- ", Me.Drpsector, Dstring7)
                Dim Dstring62 As String = "SELECT cast(ltrim(rtrim(townCode)) as varchar) towncode,townname FROM tbl_town where status=1 and statecode='" & Me.DrpState.SelectedValue & "'"
                smartobj.loadComboValues("--Select a Town--- ", Me.DrpTown, Dstring62)
                Dim Dstring3 As String = "SELECT cast(ltrim(rtrim(branchcode)) as varchar) branchcode,branchname FROM tbl_branch where status=1 and node_id = " & Session("node_ID") & ""
                smartobj.loadComboValues("--Select a Branch--- ", Me.DrpBranch, Dstring3)
                Dim Dstring5 As String = "SELECT cast(ltrim(rtrim(productcode))as varchar) productcode,productname FROM tbl_BankProduct where status=1 and productclass=1 and node_id = " & Session("node_ID") & ""
                smartobj.loadComboValues("--Select a Product--- ", Me.DrpProduct, Dstring5)

                Dim Dstring6 As String = "SELECT cast(ltrim(rtrim(idcardid)) as varchar) idcardid,idcardname FROM tbl_idcard where status=1"
                smartobj.loadComboValues("--Select an ID Type--- ", Me.DrpIdType, Dstring6)

                Dim qry As String = "select Fullname ,isnull(convert(char,a.DOB,103), '') DOB,isnull(Statecode,0) Statecode,a.Address,isnull(ResidentTowncode,0) ResidentTowncode,Phone1,phone4,a.Email,a.BusinessObjective ,"
                qry = qry & "a.Sourcefunding ,a.Memberstrength,isnull(sector,0) sector,RegNo,isnull(b.branchcode,0) branchcode ,isnull(b.productcode,0) productcode ,b.accountdesc ,b.Contribution,c.Bank_AcctNo ,"
                qry = qry & "isnull(c.bank,0) bank,c.Amount,c.[Teller Number],a.Customerid,c.PaymentReferenceID  from tbl_customer a "
                qry = qry & "inner join  tbl_casaaccount b on a.Customerid= b.Customerid and a.node_id=b.node_id "
                qry = qry & "left outer join Memcos_Reg_table c on a.Customerid= c.Customerid and a.node_id=c.node_id  "
                qry = qry & "where a.UniqueID ='" & Request.QueryString("UniqueID") & "' and a.node_id = '" & Session("node_ID") & "'"

                If Request.QueryString("UniqueID") <> "" Then
                    Me.Panel8.Visible = False
                    Me.Panel3.Enabled = False
                    Me.Panel5.Enabled = False
                    Me.BtnAdd.Visible = False
                    Me.BtnSubmit.Visible = False
                    Me.BtnEdit.Visible = True
                    Me.panel4.Visible = False
                    Me.CheckBox1.Visible = False
                    For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                        Me.txtid.Text = dr(21).ToString
						Me.TxtFullname.Text = dr(0).ToString
                        Me.txtDOB.Text = dr(1).ToString
                        Dim Dstring1 As String = "SELECT cast(ltrim(rtrim(stateCode)) as varchar) statecode,Statename FROM tbl_state where status=1 and Countrycode='" & "001" & "'"
                        smartobj.loadComboValues("--Select a State--- ", Me.DrpState, Dstring1)
                        Me.DrpState.SelectedValue = dr(2).ToString
                        Me.txtAddress.Text = dr(3).ToString
                        Dim Dstring2 As String = "SELECT cast(ltrim(rtrim(townCode)) as varchar) towncode,townname FROM tbl_town where status=1 and statecode='" & Me.DrpState.SelectedValue & "'"
                        smartobj.loadComboValues("--Select a Town--- ", Me.DrpTown, Dstring2)
                        Me.DrpTown.SelectedValue = dr(4).ToString
                        Me.txtphone.Text = dr(5).ToString
                        Me.TxtBVN.Text = dr(6).ToString
                        Me.txtemail.Text = dr(7).ToString
						
                        Me.Txtbusinessobjective.Text = dr(8).ToString
                        Me.txtsourcefunding.Text = dr(9).ToString
                        Me.txtMemberstrength.Text = dr(10).ToString
                        Dim Dstring4 As String = "SELECT cast(ltrim(rtrim(sectorcode)) as varchar) sectorcode,sectorname FROM tbl_sector where status=1"
                        smartobj.loadComboValues("--Select a Sector--- ", Me.Drpsector, Dstring4)
                        Me.Drpsector.SelectedValue = dr(11).ToString
                        Me.txtregno.Text = dr(12).ToString
                        Dim Dstring55 As String = "SELECT cast(ltrim(rtrim(branchcode)) as varchar) branchcode,branchname FROM tbl_branch where status=1 and node_id = " & Session("node_ID") & ""
                        smartobj.loadComboValues("--Select a Branch--- ", Me.DrpBranch, Dstring55)
                        Me.DrpBranch.SelectedValue = dr(13).ToString

                        Dim Dstring56 As String = "SELECT cast(ltrim(rtrim(productcode))as varchar) productcode,productname FROM tbl_BankProduct where status=1 and productclass=1 and node_id = " & Session("node_ID") & ""
                        smartobj.loadComboValues("--Select a Product--- ", Me.DrpProduct, Dstring56)
                        Me.DrpProduct.SelectedValue = dr(14).ToString
                        Me.txtacctdesc.Text = dr(15).ToString
                        Me.TxtContribution.Text = dr(16).ToString
                        Me.TxtyourAcctnumber.Text = dr(17).ToString
                        Me.DrpBank.SelectedValue = dr(18).ToString
                        Me.Txtamount.Text = dr(19).ToString
                        Me.TxtTellerNumber = dr(20)
						 
                       
                        Dim a As String = "select id,Fullname,Position ,PhoneNo ,Email   from tbl_signatories where node_id  = " & Session("node_ID") & " and Guidno = '" & dr(22) & "'"
                        Me.GridView1.DataSource = con.SqlDs(a)
                        Me.GridView1.DataBind()


                    Next
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Protected Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Try
            If Me.txtname.Text = "" Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Please Enter the signatory fullname Oops!"

                Me.txtname.Focus()
                Exit Sub
            Else
                Me.Panel2.Visible = False
                Me.Panel1.Visible = False
            End If

            If Me.Drpposition.SelectedIndex = 0 Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Please Choose a Position Oops!"
                Me.Drpposition.Focus()
                Exit Sub
            Else
                Me.Panel2.Visible = False
                Me.Panel1.Visible = False
            End If

            If Me.Txtperaddress.Text = "" Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Please Enter Residential Address Oops!"

                Txtperaddress.Focus()
                Exit Sub
            Else

                Me.Panel2.Visible = False
                Me.Panel1.Visible = False

            End If

            If Me.Txtperphone.Text = "" Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Please Enter Signatory phone no Oops!"

                Txtperphone.Focus()
                Exit Sub
            Else

                Me.Panel2.Visible = False
                Me.Panel1.Visible = False

            End If

            Dim size1 As Decimal = Math.Round((CDec(FileUpload1.PostedFile.ContentLength) / CDec(1024)), 2)
            If size1 > 200 Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Upload OF photo too Large, Image should not be more than 200k"
                Me.FileUpload1.Focus()
                Exit Sub
            End If

            Dim size As Decimal = Math.Round((CDec(FileUpload2.PostedFile.ContentLength) / CDec(1024)), 2)
            If size > 200 Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Upload OF id card too Large, Image should not be more than 200k"
                Exit Sub
                Me.FileUpload1.Focus()
            End If
            Dim pic As FileUpload = Me.FindControl("FileUpload1")
            Dim id As FileUpload = Me.FindControl("FileUpload2")
            Dim photoreg As String = pic.FileName + DateTime.Now.ToString("yyyyMMddHHmmssfff") + System.IO.Path.GetExtension(FileUpload1.FileName)
            Dim photoid As String = id.FileName + DateTime.Now.ToString("yyyyMMddHHmmssfff") + System.IO.Path.GetExtension(FileUpload2.FileName)
            Dim file_photo As String = Path.Combine("C:/inetpub/wwwroot/UCP_IMAGE_FOLDER/Reg_Upload/" + photoreg)
            Dim fileid_card As String = Path.Combine("C:/inetpub/wwwroot/UCP_IMAGE_FOLDER/ID_Card_Upload/" + photoid)

            logger.Info("CUSTOMER SERVICE: MEMBER CREATION '" & "CORPERATE SIGNATORY REGISTRATION " & " : '" & "BtnAdd_Click" & "'' " _
  & vbNewLine & "   <<<<Direction: INPUT" _
  & vbNewLine & "      INPUT PARAMETERS LIST & " _
  & vbNewLine & "          Full Name: '" & txtname.Text & "'" _
  & vbNewLine & "          pOSITION : '" & Drpposition.SelectedValue & "'" _
 & vbNewLine & "          Resident Address : '" & Me.Txtperaddress.Text & "'" _
  & vbNewLine & "          Mobile Phone1 : '" & Me.Txtperphone.Text & "'" _
 & vbNewLine & "          BVN : '" & Me.TxtBVN.Text & "'" _
  & vbNewLine & "          Email Address : '" & Me.txtperemail.Text & "'" _
  & vbNewLine & "         ID Type : '" & Me.DrpIdType.SelectedValue & "'" _
  & vbNewLine & "          signatory picture  : '" & photoreg & "'" _
& vbNewLine & "          ID card image : '" & photoid & "'" _
 & vbNewLine & "          ID No : '" & Me.txtIdNo.Text & "'" _
& vbNewLine & "          UserName  : '" & Me.txtusername.Text & "'" _
  & vbNewLine & "          UserID : '" & Session("Userid").Trim & "'" _
 & vbNewLine & "          NodeID : '" & Session("node_ID") & "'" _
  & vbNewLine & "       INPUT PARAMETERS LIST END----------'" _
  & vbNewLine & "************************************************************************************************************************************************************************************")


            qry = " declare @retmsg varchar(100),@retVal int " & vbNewLine
            qry = qry & "execute Proc_Service_RegisterSignatories"
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtname.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.Drpposition.SelectedValue.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.Txtperaddress.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.TxtBVN.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.Txtperphone.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtperemail.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(photoreg) & "," 'PICTURE UPLOAD
            qry = qry & smartobj.EncoteWithSingleQuote(photoid) & "," 'ID CARD UPLOAD
            qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpIdType.SelectedValue.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtIdNo.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.TxtGuid.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Session("Userid").Trim) & "," & Session("node_ID") & "," & "@retVal OUTPUT,@retmsg OUTPUT" & " "
            qry = qry & " select @retVal,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next
            logger.Info("CUSTOMER SERVICE: MEMBER CREATION '" & "CORPERATE REGISTRATION RESPONSE" & " : '" & "BtnAdd_Click" & "'' " _
  & vbNewLine & "   <<<<Direction: OUTPUT" _
  & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
  & vbNewLine & "          RetVal: '" & retval & "'" _
  & vbNewLine & "          RetMsg: '" & retmsg & "'" _
  & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" & "" & "'" & " " _
  & vbNewLine & "************************************************************************************************************************************************************************************")

            If retval = 0 Then

                FileUpload1.PostedFile.SaveAs(file_photo)
                FileUpload2.PostedFile.SaveAs(fileid_card)

                Dim a As String = "select id,Fullname,Position ,PhoneNo ,Email   from tbl_signatories where node_id  = " & Session("node_ID") & " and Guidno = '" & Me.TxtGuid.Text & "'"
                Me.GridView1.DataSource = con.SqlDs(a)
                Me.GridView1.DataBind()
                If Me.CheckBox1.Checked = True Then
                    SendEmail()
                Else
                    SendEmail2()
                End If

                Me.txtname.Text = Nothing
                Me.Drpposition.SelectedIndex = 0
                Me.Txtperaddress = Nothing
                Me.Textperbvn.Text = Nothing
                Me.Txtperphone.Text = Nothing
                Me.txtperemail.Text = Nothing
                Me.DrpIdType.SelectedIndex = 0
                Me.txtIdNo.Text = Nothing


            Else

                Me.Panel1.Visible = False
                Me.Panel2.Visible = True
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Visible = False
                Me.Label_success.Text = retmsg

            End If
        Catch ex As Exception
            logger.Info("CUSTOMER SERVICE: MEMBER SIGNATORY CREATION  BtnAdd_Click" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
            Me.Panel2.Visible = True
            Me.Panel1.Visible = False
            Me.Label_error.Visible = True
            Me.Label_success.Visible = False
            Me.Label_error.Text = "Error Occurred Error!"
        End Try
    End Sub
    Protected Sub BtnSubmit_Click(sender As Object, e As EventArgs) Handles BtnSubmit.Click
        Dim checker As Integer = 0
        Try
            If Me.txtname.Text = "" Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Please Enter the signatory fullname Oops!"

                Me.txtname.Focus()
                Exit Sub
            Else
                Me.Panel2.Visible = False
                Me.Panel1.Visible = False
            End If
            If Me.txtregno.Text = "" Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Please Enter the Registration Number Oops!"

                Me.txtregno.Focus()
                Exit Sub
            Else
                Me.Panel2.Visible = False
                Me.Panel1.Visible = False
            End If
            Dim globaldate As Date = Now.Date
            Dim dob As Date
            If txtDOB.Text <> "" Then
                If IsDate(txtDOB.Text.Trim) Then
                    'dob = System.DateTime.Parse(txtDOB.Text.Trim)
                    dob = CDate(txtDOB.Text.Trim)

                End If
            Else
                dob = globaldate
            End If

            If Me.DrpState.SelectedIndex = 0 Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Please Choose a state Oops!"
                Me.DrpState.Focus()
                Exit Sub
            Else
                Me.Panel2.Visible = False
                Me.Panel1.Visible = False
            End If
            If Me.DrpTown.SelectedIndex = 0 Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Please Choose a LGA Oops!"
                Me.DrpTown.Focus()
                Exit Sub
            Else
                Me.Panel2.Visible = False
                Me.Panel1.Visible = False
            End If
            If Me.txtAddress.Text = "" Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Please Enter Contact Address Oops!"

                txtAddress.Focus()
                Exit Sub
            Else

                Me.Panel2.Visible = False
                Me.Panel1.Visible = False

            End If
            If Me.Drpsector.SelectedIndex = 0 Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Please Choose a Sector Oops!"
                Me.Drpsector.Focus()
                Exit Sub
            Else
                Me.Panel2.Visible = False
                Me.Panel1.Visible = False
            End If
            If Me.txtphone.Text = "" Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Please Enter  phone no Oops!"

                txtphone.Focus()
                Exit Sub
            Else

                Me.Panel2.Visible = False
                Me.Panel1.Visible = False

            End If
            If Me.DrpBranch.SelectedIndex = 0 Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Please Choose a Branch Oops!"
                Me.DrpBranch.Focus()
                Exit Sub
            Else
                Me.Panel2.Visible = False
                Me.Panel1.Visible = False
            End If
            If Me.DrpProduct.SelectedIndex = 0 Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Please Choose a product Oops!"
                Me.DrpProduct.Focus()
                Exit Sub
            Else
                Me.Panel2.Visible = False
                Me.Panel1.Visible = False
            End If
            If Me.txtacctdesc.Text = "" Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Please Enter the Account Description Oops!"

                Me.txtacctdesc.Focus()
                Exit Sub
            Else
                Me.Panel2.Visible = False
                Me.Panel1.Visible = False
            End If
            If Me.TxtContribution.Text = "" Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Please Enter the Contribution Amount Oops!"

                Me.TxtContribution.Focus()
                Exit Sub
            Else
                Me.Panel2.Visible = False
                Me.Panel1.Visible = False
            End If
            If Me.CheckBox1.Checked = True Then
                If Me.txtusername.Text = "" Then
                    Me.Panel2.Visible = True
                    Me.Panel1.Visible = False
                    Me.Label_error.Visible = True
                    Me.Label_success.Visible = False
                    Me.Label_error.Text = "Please Enter Username Oops!"

                    txtusername.Focus()
                    Exit Sub
                Else

                    Me.Panel2.Visible = False
                    Me.Panel1.Visible = False
                End If
                If Me.txtpassword.Text = "" Then
                    Me.Panel2.Visible = True
                    Me.Panel1.Visible = False
                    Me.Label_error.Visible = True
                    Me.Label_success.Visible = False
                    Me.Label_error.Text = "Please Enter Password Oops!"

                    txtpassword.Focus()
                    Exit Sub
                Else

                    Me.Panel2.Visible = False
                    Me.Panel1.Visible = False
                End If
                If Me.txtconfirmpassword.Text = "" Then
                    Me.Panel2.Visible = True
                    Me.Panel1.Visible = False
                    Me.Label_error.Visible = True
                    Me.Label_success.Visible = False
                    Me.Label_error.Text = "Please Enter Confirm Password Oops!"

                    txtconfirmpassword.Focus()
                    Exit Sub
                Else

                    Me.Panel2.Visible = False
                    Me.Panel1.Visible = False
                End If
                If Me.txtconfirmpassword.Text <> Me.txtpassword.Text Then
                    Me.Panel2.Visible = True
                    Me.Panel1.Visible = False
                    Me.Label_error.Visible = True
                    Me.Label_success.Visible = False
                    Me.Label_error.Text = "Please Password and Confirm Password can not be different Oops!"
                    txtpassword.Focus()
                    txtconfirmpassword.Focus()
                    Exit Sub
                Else

                    Me.Panel2.Visible = False
                    Me.Panel1.Visible = False
                End If
            End If
            If Me.CheckBox1.Checked = True Then
                Session("checker") = 1
            Else
                Session("checker") = 0
            End If
            logger.Info("CUSTOMER SERVICE: MEMBER CREATION '" & "CORPERATE REGISTRATION " & " : '" & "BtnSubmit_Click" & "'' " _
  & vbNewLine & "   <<<<Direction: INPUT" _
  & vbNewLine & "      INPUT PARAMETERS LIST & " _
  & vbNewLine & "          Full Name: '" & TxtFullname.Text & "'" _
  & vbNewLine & "          Date of Registration: '" & dob & "'" _
  & vbNewLine & "         State  : '" & Me.DrpState.SelectedValue & "'" _
  & vbNewLine & "          Sector : '" & Me.Drpsector.SelectedValue & "'" _
        & vbNewLine & "          Town : '" & Me.DrpTown.SelectedValue & "'" _
          & vbNewLine & "          Resident Address : '" & Me.txtAddress.Text & "'" _
                        & vbNewLine & "          Mobile Phone1 : '" & Me.txtphone.Text & "'" _
                 & vbNewLine & "          BVN : '" & Me.TxtBVN.Text & "'" _
                   & vbNewLine & "          Reg No : '" & Me.txtregno.Text & "'" _
                  & vbNewLine & "          Business Objective : '" & Me.Txtbusinessobjective.Text & "'" _
                   & vbNewLine & "          Source Funding : '" & Me.txtsourcefunding.Text & "'" _
                     & vbNewLine & "          Member : '" & Me.txtMemberstrength.Text & "'" _
                   & vbNewLine & "          BVN : '" & Me.TxtBVN.Text & "'" _
                 & vbNewLine & "          Email Address : '" & Me.txtemail.Text & "'" _
                  & vbNewLine & "         ID Type : '" & Me.DrpIdType.SelectedValue & "'" _
                 & vbNewLine & "          ID No : '" & Me.txtIdNo.Text & "'" _
                 & vbNewLine & "          UserName  : '" & Me.txtusername.Text & "'" _
                 & vbNewLine & "          Password : '" & con.EncryptText(Me.txtpassword.Text) & "'" _
                & vbNewLine & "          con Password : '" & con.EncryptText(Me.txtconfirmpassword.Text) & "'" _
                 & vbNewLine & "          Account Branch : '" & Me.DrpBranch.SelectedValue & "'" _
                 & vbNewLine & "         Account Product : '" & Me.DrpProduct.SelectedValue & "'" _
                 & vbNewLine & "          Account Description  : '" & Me.txtacctdesc.Text & "'" _
                 & vbNewLine & "          SubBranch : '" & Me.DrpSubBranch.SelectedValue & "'" _
                 & vbNewLine & "          Monthly Contribution : '" & Me.TxtContribution.Text & "'" _
                  & vbNewLine & "         Account number : '" & Me.TxtyourAcctnumber.Text & "'" _
                 & vbNewLine & "          Payment Bank : '" & Me.DrpBank.SelectedValue & "'" _
                & vbNewLine & "          UserID : '" & Session("Userid").Trim & "'" _
                 & vbNewLine & "          NodeID : '" & Session("node_ID") & "'" _
                  & vbNewLine & "          checker : '" & checker & "'" _
  & vbNewLine & "       INPUT PARAMETERS LIST END----------'" _
  & vbNewLine & "************************************************************************************************************************************************************************************")

            qry = "declare @retmsg varchar(100),@retval int " & vbNewLine
            qry = qry & "execute Proc_InsCustomer_And_InsCASAAccount_Cooperate"
            qry = qry & smartobj.EncoteWithSingleQuote(Me.TxtFullname.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Format(CDate(dob), "MM/dd/yyyy hh:mm:ss")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpState.SelectedValue.Trim) & ","

            qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpTown.SelectedValue.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtAddress.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtphone.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.TxtBVN.Text.Trim.Replace("'", "")) & ","

            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtemail.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.Drpsector.SelectedValue.Trim) & ", null, null, null, null, null, 0,"
            qry = qry & smartobj.EncoteWithSingleQuote(Session("Userid").Trim) & "," & "@retVal OUTPUT,@retmsg OUTPUT" & "," & Session("node_ID") & ","

            qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpBranch.SelectedValue.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpProduct.SelectedValue.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpSubBranch.SelectedValue.Trim) & ","

            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtacctdesc.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.TxtContribution.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.TxtyourAcctnumber.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpBank.SelectedValue.Trim) & ", null,"

            qry = qry & smartobj.EncoteWithSingleQuote(Me.Txtamount.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.TxtTellerNumber.Text.Trim.Replace("'", "")) & ", null,"

            qry = qry & smartobj.EncoteWithSingleQuote(con.EncryptText(Me.txtpassword.Text)) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(con.EncryptText(Me.txtconfirmpassword.Text)) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtusername.Text.Trim.Replace("'", "")) & ","

            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtregno.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.TxtGuid.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.Txtbusinessobjective.Text.Trim.Replace("'", "")) & ","

            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtsourcefunding.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtMemberstrength.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Session("checker")) & " "
           
            qry = qry & " select @retVal,@retmsg"


            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString

            Next
            logger.Info("CUSTOMER SERVICE: MEMBER CREATION '" & "CORPERATE REGISTRATION RESPONSE" & " : '" & "BtnSubmit_Click" & "'' " _
  & vbNewLine & "   <<<<Direction: OUTPUT" _
  & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
  & vbNewLine & "          RetVal: '" & retval & "'" _
  & vbNewLine & "          RetMsg: '" & retmsg & "'" _
  & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" & "" & "'" & " " _
  & vbNewLine & "************************************************************************************************************************************************************************************")

            If retval = 0 Then


                Me.Panel1.Visible = True
                Me.Panel2.Visible = False
                Me.Label_error.Visible = False
                Me.Label_success.Visible = True
                Me.Label_error.Visible = False
                Me.Label_success.Text = "Member Registration save successfully"
                If Me.CheckBox1.Checked = True Then
                    SendEmail()
                Else
                    SendEmail2()
                End If
                clear()
                BtnSubmit.Enabled = False

            Else

                Me.Panel1.Visible = False
                Me.Panel2.Visible = True
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Visible = False
                Me.Label_success.Text = retmsg

            End If
        Catch ex As Exception
            logger.Info("CUSTOMER SERVICE: MEMBER CREATION  BtnSubmit_Click" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
            Me.Panel2.Visible = True
            Me.Panel1.Visible = False
            Me.Label_error.Visible = True
            Me.Label_success.Visible = False
            Me.Label_error.Text = "Error Occurred Error!"
        End Try
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onmouseover") = "this.style.backgroundColor='aquamarine';"
            e.Row.Attributes("onmouseout") = "this.style.backgroundColor='white';"
            e.Row.ToolTip = "Click last column for selecting this row."
        End If
    End Sub
    Protected Sub OnSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim filePath As String = "http://solutions.cooplatform.com.ng/imgs/"
        Dim idpath As String = "http://solutions.cooplatform.com.ng/imgs/"
        Dim filepath1 As String = "http://localhost/imgs/"
        pName = GridView1.SelectedRow.Cells(1).Text
        Me.panel4.Visible = True
        Dim qry As String = "select Fullname ,Position ,Address , bvn,PhoneNo ,Email ,ImagePath ,IDcardPath,IDtype ,idno,id from tbl_signatories where id =" & pName
        If pName <> "" Then
            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows

                Me.txtname.Text = dr(0).ToString
                Me.Drpposition.SelectedValue = dr(1).ToString
                Me.Txtperaddress.Text = dr(2).ToString
                Me.TxtBVN.Text = dr(3).ToString
                Me.Txtperphone.Text = dr(4).ToString
                Me.txtperemail.Text = dr(5).ToString
                ProfileImage = filePath + dr(6).ToString
                IDcardImage = idpath + dr(7).ToString
                ' qry = qry & smartobj.EncoteWithSingleQuote(photoreg) & "," 'PICTURE UPLOAD
                ' qry = qry & smartobj.EncoteWithSingleQuote(photoid) & "," 'ID CARD UPLOAD
                Me.DrpIdType.SelectedValue = dr(8)
                txtIdNo.Text = dr(9)
                Me.txtid.Text = dr(10)

            Next
        End If
        ' msg.Text = (Convert.ToString("<b>Publisher Name  &nbsp;:&nbsp;&nbsp;   ") & pName) + "</b>"
    End Sub
    Protected Sub gridView_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

        MyCon.Open()
        Dim stor_id As String = GridView1.DataKeys(e.RowIndex).Values("id").ToString()
        Dim cmd As New SqlCommand("delete from tbl_signatories where id=" + stor_id, MyCon)
        Dim result As Integer = cmd.ExecuteNonQuery()
        MyCon.Close()
        If result = 1 Then
            MsgBox(stor_id + "      Deleted successfully.......    ")
            ' lblmsg.Text = stor_id + "      Deleted successfully.......    "
        End If
    End Sub

    Protected Sub DrpBranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpBranch.SelectedIndexChanged
        Try
            Dim selbranch As String = "Select subbranchcode from tbl_subbranch where mbranchcode='" & Me.DrpBranch.SelectedValue.Trim & "'and node_id = " & Session("node_ID") & ""

            If con.SqlDs(selbranch).Tables(0).Rows.Count > 0 Then
                Dim Dstring33 As String = "SELECT cast(ltrim(rtrim(subbranchcode)) as varchar) subbranchcode,subbranchname FROM tbl_subbranch where mbranchcode='" & Me.DrpBranch.SelectedValue.Trim & "' and node_id = " & Session("node_ID") & " "
                smartobj.loadComboValues("--Select a Sub Branch--- ", Me.DrpSubBranch, Dstring33)
                Me.DrpSubBranch.Enabled = True

            Else
                Me.DrpSubBranch.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub DDrpState_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpState.SelectedIndexChanged
        Dim Dstring6 As String = "SELECT cast(ltrim(rtrim(townCode)) as varchar) towncode,townname FROM tbl_town where status=1 and statecode='" & Me.DrpState.SelectedValue & "'"
        smartobj.loadComboValues("--Select a Town--- ", Me.DrpTown, Dstring6)

    End Sub
    Sub SendEmail()
        Try

            Dim configurationFile As Configuration = WebConfigurationManager.OpenWebConfiguration("~/web.config")
            Dim mailSettings As MailSettingsSectionGroup = configurationFile.GetSectionGroup("system.net/mailSettings")
            Dim msg As New MailMessage()
            'msg.From = New MailAddress("noreply@infosightonline.com")
            msg.From = New MailAddress(mailSettings.Smtp.From)

            msg.To.Add(txtperemail.Text)


            msg.Subject = "Registration Acknowledgement"

            msg.IsBodyHtml = True


            Dim body2 As String = " "
            Dim tenat As String
            Dim FullName As String = TxtFullname.Text
            Dim qry As String = "select tenant from Tbl_Tenants where Node_id = '" & Session("node_ID") & "'and status = '1'"
            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                Session("TenantName") = dr(0).ToString
            Next

            body2 += "Hello " + FullName + " ,<br/><br/> "


            'Dim body2 As String = <b><font Size ="3"><font color="Blue"> "Dear " + txtUsername.Text.Trim() + " </b><DIV>&nbsp;</DIV>,"

            body2 += "This is to inform you that you have been registered with " + ("TenantName") + "  <br/><br/>"

            body2 += "<b>Login Information : <br/>"

                body2 += "<b>Username :" + Me.txtusername.Text + "<br/> <br/>"

                body2 += "<b>Password :" + txtpassword.Text() + "<br/> <br/>"

                body2 += "Thank you for your interest in our Cooperative.<br/><br/> "
                body2 += "Regards,<br/> "
            body2 += ("TenantName")
            msg.Body = body2

                Dim smtp1 As New SmtpClient() 'specify the mail server address
                smtp1.Credentials = New Net.NetworkCredential(mailSettings.Smtp.From, mailSettings.Smtp.Network.Password)
                smtp1.Host = mailSettings.Smtp.Network.Host
                smtp1.Port = mailSettings.Smtp.Network.Port
                smtp1.Timeout = 700000
                smtp1.Send(msg)
            ' Next

        Catch ex As Exception

        End Try
    End Sub
    Sub SendEmail2()
        Try

            Dim configurationFile As Configuration = WebConfigurationManager.OpenWebConfiguration("~/web.config")
            Dim mailSettings As MailSettingsSectionGroup = configurationFile.GetSectionGroup("system.net/mailSettings")
            Dim msg As New MailMessage()
            'msg.From = New MailAddress("noreply@infosightonline.com")
            msg.From = New MailAddress(mailSettings.Smtp.From)

            msg.To.Add(txtemail.Text)


            msg.Subject = "Registration Acknowledgement"

            msg.IsBodyHtml = True


            Dim body2 As String = " "

            Dim FullName As String = TxtFullname.Text
            Dim qry As String = "select tenant from Tbl_Tenants where Node_id = '" & Session("node_ID") & "'and status = '1'"

            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                Session("TenantName") = dr(0).ToString
            Next
            body2 += "Hello " + FullName + " ,<br/><br/> "


            'Dim body2 As String = <b><font Size ="3"><font color="Blue"> "Dear " + txtUsername.Text.Trim() + " </b><DIV>&nbsp;</DIV>,"

            body2 += "This is to inform you that you have successfully registered with " + Session("TenantName") + "  <br/><br/>"

            'body2 += "<b>Login Information : <br/>"

            'body2 += "<b>Username :" + Me.txtusername.Text + "<br/> <br/>"

            'body2 += "<b>Password :" + txtpassword.Text() + "<br/> <br/>"

            body2 += "Thank you for joining our Cooperative.<br/><br/> "
            body2 += "Regards,<br/> "
            body2 += Session("TenantName")
            msg.Body = body2

            Dim smtp1 As New SmtpClient() 'specify the mail server address
            smtp1.Credentials = New Net.NetworkCredential(mailSettings.Smtp.From, mailSettings.Smtp.Network.Password)
            smtp1.Host = mailSettings.Smtp.Network.Host
            smtp1.Port = mailSettings.Smtp.Network.Port
            smtp1.Timeout = 700000
            smtp1.Send(msg)
            ' Next
        Catch ex As Exception

        End Try
    End Sub
    Sub clear()

        Me.TxtFullname.Text = ""
        Me.txtname.Text = ""
        Me.txtregno.Text = ""
        Me.txtIdNo.Text = ""
        Me.Drpposition.SelectedValue = Nothing
        Me.DrpBank.SelectedValue = Nothing

        Me.DrpState.SelectedValue = Nothing

        Me.txtAddress.Text = ""

        Me.DrpTown.SelectedValue = Nothing
        Me.Drpsector.SelectedValue = Nothing
        Me.txtphone.Text = ""
        Me.Txtperphone.Text = ""
        Me.txtperemail.Text = ""
        Me.txtperemail.Text = ""
        Me.txtemail.Text = ""
        Me.Txtperaddress.Text = ""

        Me.DrpIdType.SelectedValue = Nothing
        Me.txtIdNo.Text = ""
        Me.DrpBranch.SelectedValue = Nothing
        Me.DrpProduct.SelectedValue = Nothing
        Me.txtacctdesc.Text = ""
        Me.txtDOB.Text = ""
        'Me.DrpGroup.SelectedValue = Nothing
        Me.Txtbusinessobjective.Text = ""
        Me.txtsourcefunding.Text = ""
        Me.txtMemberstrength.Text = ""
        Me.BtnSubmit.Enabled = True
        Me.BtnAdd.Enabled = True
        Me.TxtGuid.Text = ""

        Me.txtDOB.Text = ""
        TxtyourAcctnumber.Text = ""
        TxtTellerNumber.Text = ""
        Txtamount.Text = ""
        TxtContribution.Text = ""
        Me.txtusername.Text = ""
        Me.txtpassword.Text = ""
        Me.txtconfirmpassword.Text = ""

    End Sub
    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        If Me.Calendar1.Visible = True Then
            Me.Calendar1.Visible = False
        Else
            Me.Calendar1.Visible = True
        End If
    End Sub
    Protected Sub Calendar1_SelectionChanged(sender As Object, e As EventArgs) Handles Calendar1.SelectionChanged
        Me.txtDOB.Text = Me.Calendar1.SelectedDate.ToString("d")
        Me.Calendar1.Visible = False

    End Sub
    Protected Sub BtnSignatoryEdit_Click(sender As Object, e As EventArgs) Handles BtnSignatoryEdit.Click
        Try
            If Me.txtname.Text = "" Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Please Enter the signatory fullname Oops!"

                Me.txtname.Focus()
                Exit Sub
            Else
                Me.Panel2.Visible = False
                Me.Panel1.Visible = False
            End If

            If Me.Drpposition.SelectedIndex = 0 Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Please Choose a Position Oops!"
                Me.Drpposition.Focus()
                Exit Sub
            Else
                Me.Panel2.Visible = False
                Me.Panel1.Visible = False
            End If

            If Me.Txtperaddress.Text = "" Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Please Enter Residential Address Oops!"

                Txtperaddress.Focus()
                Exit Sub
            Else

                Me.Panel2.Visible = False
                Me.Panel1.Visible = False

            End If

            If Me.Txtperphone.Text = "" Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Please Enter Signatory phone no Oops!"

                Txtperphone.Focus()
                Exit Sub
            Else

                Me.Panel2.Visible = False
                Me.Panel1.Visible = False

            End If
            Dim pic As FileUpload = Me.FindControl("FileUpload1")
            Dim id As FileUpload = Me.FindControl("FileUpload2")
            Dim photoreg As String = pic.FileName + DateTime.Now.ToString("yyyyMMddHHmmssfff") + System.IO.Path.GetExtension(FileUpload1.FileName)
            Dim photoid As String = id.FileName + DateTime.Now.ToString("yyyyMMddHHmmssfff") + System.IO.Path.GetExtension(FileUpload2.FileName)
            Dim file_photo As String = Path.Combine("C:/inetpub/wwwroot/UCP_IMAGE_FOLDER/Reg_Upload/" + photoreg)
            Dim fileid_card As String = Path.Combine("C:/inetpub/wwwroot/UCP_IMAGE_FOLDER/ID_Card_Upload/" + photoid)

            Dim size1 As Decimal = Math.Round((CDec(FileUpload1.PostedFile.ContentLength) / CDec(1024)), 2)
            If size1 > 200 Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Upload OF photo too Large, Image should not be more than 200k"
                Exit Sub
            End If

            Dim size As Decimal = Math.Round((CDec(FileUpload2.PostedFile.ContentLength) / CDec(1024)), 2)
            If size > 200 Then
                Me.Panel2.Visible = True
                Me.Panel1.Visible = False
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Text = "Upload OF id card too Large, Image should not be more than 200k"
                Exit Sub
            End If

            logger.Info("CUSTOMER SERVICE: MEMBER CREATION '" & "CORPERATE SIGNATORY REGISTRATION " & " : '" & "BtnSignatoryEdit_Click" & "'' " _
  & vbNewLine & "   <<<<Direction: INPUT" _
  & vbNewLine & "      INPUT PARAMETERS LIST & " _
  & vbNewLine & "          Full Name: '" & txtname.Text & "'" _
  & vbNewLine & "          pOSITION : '" & Drpposition.SelectedValue & "'" _
  & vbNewLine & "          Resident Address : '" & Me.Txtperaddress.Text & "'" _
& vbNewLine & "          Mobile Phone1 : '" & Me.Txtperphone.Text & "'" _
 & vbNewLine & "          signatory picture  : '" & photoreg & "'" _
& vbNewLine & "          ID card image : '" & photoid & "'" _
 & vbNewLine & "          BVN : '" & Me.TxtBVN.Text & "'" _
 & vbNewLine & "          Email Address : '" & Me.txtperemail.Text & "'" _
                  & vbNewLine & "         ID Type : '" & Me.DrpIdType.SelectedValue & "'" _
                 & vbNewLine & "          ID No : '" & Me.txtIdNo.Text & "'" _
                 & vbNewLine & "          UserName  : '" & Me.txtusername.Text & "'" _
                        & vbNewLine & "          UserID : '" & Session("Userid").Trim & "'" _
                 & vbNewLine & "          NodeID : '" & Session("node_ID") & "'" _
  & vbNewLine & "       INPUT PARAMETERS LIST END----------'" _
  & vbNewLine & "************************************************************************************************************************************************************************************")


            qry = " declare @retmsg varchar(100),@retVal int " & vbNewLine
            qry = qry & "execute Proc_Service_RegisterSignatories_Update"
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtname.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.Drpposition.SelectedValue.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.Txtperaddress.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.TxtBVN.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.Txtperphone.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtperemail.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(photoreg) & "," 'PICTURE UPLOAD
            qry = qry & smartobj.EncoteWithSingleQuote(photoid) & "," 'ID CARD UPLOAD
            qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpIdType.SelectedValue.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtIdNo.Text.Trim.Replace("'", "")) & ","

            qry = qry & Session("node_ID") & "," & Me.txtid.Text & "," & "@retVal OUTPUT,@retmsg OUTPUT" & " "
            qry = qry & " select @retVal,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next
            logger.Info("CUSTOMER SERVICE: MEMBER CREATION '" & "CORPERATE REGISTRATION RESPONSE EDIT" & " : '" & "BtnSignatoryEdit_Click" & "'' " _
  & vbNewLine & "   <<<<Direction: OUTPUT" _
  & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
  & vbNewLine & "          RetVal: '" & retval & "'" _
  & vbNewLine & "          RetMsg: '" & retmsg & "'" _
  & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" & "" & "'" & " " _
  & vbNewLine & "************************************************************************************************************************************************************************************")

            If retval = 0 Then

                FileUpload1.PostedFile.SaveAs(file_photo)
                FileUpload2.PostedFile.SaveAs(fileid_card)

                Dim a As String = "select id,Fullname,Position ,PhoneNo ,Email   from tbl_signatories where node_id  = " & Session("node_ID") & " and Guidno = '" & Me.TxtGuid.Text & "'"
                Me.GridView1.DataSource = con.SqlDs(a)
                Me.GridView1.DataBind()
                SendEmail()
            Else

                Me.Panel1.Visible = False
                Me.Panel2.Visible = True
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Visible = False
                Me.Label_success.Text = retmsg

            End If
        Catch ex As Exception
            logger.Info("CUSTOMER SERVICE: MEMBER SIGNATORY CREATION  BtnAdd_Click" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

            Me.Panel2.Visible = True
            Me.Panel1.Visible = False
            Me.Label_error.Visible = True
            Me.Label_success.Visible = False
            Me.Label_error.Text = "Error Occurred Error!"
        End Try
    End Sub
    Protected Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Try
            Dim globaldate As Date = Now.Date
            Dim dob As Date
            If txtDOB.Text <> "" Then
                If IsDate(txtDOB.Text.Trim) Then
                    'dob = System.DateTime.Parse(txtDOB.Text.Trim)
                    dob = CDate(txtDOB.Text.Trim)

                End If
            Else
                dob = globaldate
            End If



            logger.Info("CUSTOMER SERVICE: MEMBER CREATION '" & "CORPERATE REGISTRATION " & " : '" & "BtnEdit_Click" & "'' " _
  & vbNewLine & "   <<<<Direction: INPUT" _
  & vbNewLine & "      INPUT PARAMETERS LIST & " _
  & vbNewLine & "          Full Name: '" & TxtFullname.Text & "'" _
  & vbNewLine & "          Date of Registration: '" & dob & "'" _
  & vbNewLine & "         State  : '" & Me.DrpState.SelectedValue & "'" _
  & vbNewLine & "          Sector : '" & Me.Drpsector.SelectedValue & "'" _
        & vbNewLine & "          Town : '" & Me.DrpTown.SelectedValue & "'" _
          & vbNewLine & "          Resident Address : '" & Me.txtAddress.Text & "'" _
                        & vbNewLine & "          Mobile Phone1 : '" & Me.txtphone.Text & "'" _
                 & vbNewLine & "          BVN : '" & Me.TxtBVN.Text & "'" _
                   & vbNewLine & "          Reg No : '" & Me.txtregno.Text & "'" _
                  & vbNewLine & "          Business Objective : '" & Me.Txtbusinessobjective.Text & "'" _
                   & vbNewLine & "          Source Funding : '" & Me.txtsourcefunding.Text & "'" _
          & vbNewLine & "          Member : '" & Me.txtMemberstrength.Text & "'" _
        & vbNewLine & "          BVN : '" & Me.TxtBVN.Text & "'" _
    & vbNewLine & "          Email Address : '" & Me.txtemail.Text & "'" _
    & vbNewLine & "         Amount : '" & Me.Txtamount.Text.Trim & "'" _
   & vbNewLine & "          Customer ID : '" & Me.txtid.Text.Trim & "'" _
   & vbNewLine & "          Teller Number  : '" & Me.TxtTellerNumber.Text.Trim & "'" _
 & vbNewLine & "          Password : '" & con.EncryptText(Me.txtpassword.Text) & "'" _
 & vbNewLine & "          con Password : '" & con.EncryptText(Me.txtconfirmpassword.Text) & "'" _
  & vbNewLine & "         Account number : '" & Me.TxtyourAcctnumber.Text & "'" _
                 & vbNewLine & "          Payment Bank : '" & Me.DrpBank.SelectedValue & "'" _
                & vbNewLine & "          UserID : '" & Session("Userid").Trim & "'" _
                 & vbNewLine & "          NodeID : '" & Session("node_ID") & "'" _
  & vbNewLine & "       INPUT PARAMETERS LIST END----------'" _
  & vbNewLine & "************************************************************************************************************************************************************************************")

            qry = "declare @retmsg varchar(100),@retval int " & vbNewLine
            qry = qry & "execute Proc_InsCustomer_And_InsCASAAccount_Cooperate_update "
            qry = qry & smartobj.EncoteWithSingleQuote(Me.TxtFullname.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Format(CDate(dob), "MM/dd/yyyy hh:mm:ss")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpState.SelectedValue.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpTown.SelectedValue.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtAddress.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtphone.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.TxtBVN.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtemail.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.Drpsector.SelectedValue.Trim) & ", null, "
            qry = qry & "@retVal OUTPUT,@retmsg OUTPUT" & "," & Session("node_ID") & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.TxtyourAcctnumber.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpBank.SelectedValue.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.Txtamount.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.TxtTellerNumber.Text.Trim.Replace("'", "")) & ", null,"
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtregno.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtid.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.Txtbusinessobjective.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtsourcefunding.Text.Trim.Replace("'", "")) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtMemberstrength.Text.Trim.Replace("'", "")) & " "
            qry = qry & " select @retVal,@retmsg"

            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString

            Next
            logger.Info("CUSTOMER SERVICE: MEMBER CREATION '" & "CORPERATE REGISTRATION RESPONSE EDIT" & " : '" & "BtnEdit_Click" & "'' " _
  & vbNewLine & "   <<<<Direction: OUTPUT" _
  & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
  & vbNewLine & "          RetVal: '" & retval & "'" _
  & vbNewLine & "          RetMsg: '" & retmsg & "'" _
  & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" & "" & "'" & " " _
  & vbNewLine & "************************************************************************************************************************************************************************************")

            If retval = 0 Then


                Me.Panel1.Visible = True
                Me.Panel2.Visible = False
                Me.Label_error.Visible = False
                Me.Label_success.Visible = True
                Me.Label_error.Visible = False
                Me.Label_success.Text = "Member Registration Edit save successfully"
                clear()
                BtnSubmit.Enabled = False

            Else

                Me.Panel1.Visible = False
                Me.Panel2.Visible = True
                Me.Label_error.Visible = True
                Me.Label_success.Visible = False
                Me.Label_error.Visible = False
                Me.Label_success.Text = retmsg

            End If
        Catch ex As Exception
            logger.Info("CUSTOMER SERVICE: MEMBER SIGNATORY CREATION EDIT  BtnAdd_Click" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

            Me.Panel2.Visible = True
            Me.Panel1.Visible = False
            Me.Label_error.Visible = True
            Me.Label_success.Visible = False
            Me.Label_error.Text = "Error Occurred Error!"
        End Try

    End Sub
    Protected Sub RdBCustType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RdBCustType.SelectedIndexChanged
        If RdBCustType.SelectedValue = "1" Then
            Response.Redirect("AddReg.aspx")
        End If
    End Sub
    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked = True Then
            Me.Panel3.Visible = True

        Else
            Me.Panel3.Visible = False
        End If
    End Sub
End Class
