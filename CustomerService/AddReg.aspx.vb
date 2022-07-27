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


Partial Class WebPortal_AddReg
    Inherits SessionCheck2
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(WebPortal_AddReg))
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim cnt As Integer = 0
    Dim userNAME As String
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
    Dim checker As Integer = 0
    Public Property ProfileImage() As String
        Get
            Return profileImg
        End Get
        Set(value As String)
            profileImg = value
        End Set
    End Property
	'    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
	'        Dim filepath1 As String = "http://localhost/imgs/"
	'        If Not IsPostBack Then
	'            Try
	'                '' Me.Calendar1.Visible = False
	'                Me.Panel3.Visible = False
	'                Me.Panel5.Visible = False
	'                'imgdate1.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtDOB.ClientID.ToString() + "');"

	'                Dim Dstring7 As String = "SELECT cast(ltrim(rtrim(sectorcode)) as varchar) sectorcode,sectorname FROM tbl_sector where status=1"
	'                'smartobj.loadComboValues("--Select a Sector--- ", Me.DrpcompSector, Dstring7)

	'                smartobj.loadComboValues("--Select a Sector--- ", Me.Drpsector, Dstring7)

	'                Dim Dstring2 As String = "SELECT cast(ltrim(rtrim(sexcode)) as varchar) sexid,sexname FROM tbl_sex where status=1"
	'                smartobj.loadComboValues("--Select a Gender--- ", Me.DrpSex, Dstring2)

	'                Dim Dstring4 As String = "SELECT cast(ltrim(rtrim(Countrycode)) as varchar) Country_id,Countryname FROM tbl_Country where status=1"
	'                smartobj.loadComboValues("--Select a Country--- ", Me.DrpNational, Dstring4)

	'                Dim Dstring3 As String = "SELECT cast(ltrim(rtrim(branchcode)) as varchar) branchcode,branchname FROM tbl_branch where status=1 and node_id = " & Session("node_ID") & ""
	'                smartobj.loadComboValues("--Select a Branch--- ", Me.DrpBranch, Dstring3)


	'                Dim Dstring5 As String = "SELECT cast(ltrim(rtrim(productcode))as varchar) productcode,productname FROM tbl_BankProduct where status=1 and productclass=1 and node_id = " & Session("node_ID") & ""
	'                smartobj.loadComboValues("--Select a Product--- ", Me.DrpProduct, Dstring5)

	'                Dim Dstring6 As String = "SELECT cast(ltrim(rtrim(idcardid)) as varchar) idcardid,idcardname FROM tbl_idcard where status=1"
	'                smartobj.loadComboValues("--Select an ID Type--- ", Me.DrpIdType, Dstring6)

	'                Dim qry As String = "select a.surname,a.firstname,a.othername,a.Nationality,a.statecode,a.sector, a.ResidentStatecode,a.ResidentTowncode,a.address,a.address2,a.phone1,a.phone2,a.phone3,a.phone4,a.IDType ,a.IDno ,a.NextOfKin ,a.NextOfKinphone ,a.RelType,b.branchcode ,b.productcode ,b.accountdesc ,c.MonthlyContri,isnull(c.Bank_AcctNo,'')Bank_AcctNo ,a.customerid ,isnull(c.Amount,0.00)Amount,isnull(c.[Teller Number],'')[Teller Number],a.sex, isnull(REPLACE(CONVERT(VARCHAR(11),a.DOB,106), ' ','/'), '01/01/1900') dob,a.NextOfKinaddr,a.image_type ,a.image_type2,isnull(c.bank,'')bank ,isnull(c.Username,'')Username , a.EmployeeID, a.Email , c.MonthlyContri  from tbl_customer a inner join  tbl_casaaccount b on a.Customerid= b.Customerid and a.node_id=b.node_id left outer join Memcos_Reg_table c on a.Customerid= c.Customerid and a.node_id=c.node_id  where a.UniqueID = '" _
	'           & Request.QueryString("UniqueID") & "' and a.node_id = '" & Session("node_ID") & "'"



	'                Dim Dstring51 As String = "SELECT cast(ltrim(rtrim(stateCode)) as varchar) statecode,Statename FROM tbl_state where status=1"
	'                smartobj.loadComboValues("--Select a State--- ", Me.DrpState, Dstring51)

	'                Dim Dstring61 As String = "SELECT cast(ltrim(rtrim(stateCode)) as varchar) statecode,Statename FROM tbl_state where status=1 "
	'                smartobj.loadComboValues("--Select a State--- ", Me.DrpResState, Dstring61)

	'                Dim Dstring62 As String = "SELECT cast(ltrim(rtrim(townCode)) as varchar) towncode,townname FROM tbl_town where status=1 "
	'                smartobj.loadComboValues("--Select a Town--- ", Me.DrpTown, Dstring62)

	'                'Session("node_ID")

	'                If Request.QueryString("UniqueID") <> "" Then
	'                    '  Me.Image1.Visible = True
	'                    Me.Image2.Visible = True
	'                    Me.BtnEdit.Visible = True
	'                    Me.BtnSubmit.Visible = False
	'                    Me.DrpBranch.Enabled = False
	'                    Me.DrpProduct.Enabled = False
	'                    Me.txtacctdesc.Enabled = False
	'                    Me.Panel4.Visible = False
	'                    Me.txtemployeeid.Visible = True
	'                    ' Me.txtusername.Visible = False
	'                    Me.CheckBox1.Visible = False

	'                    Me.Panel3.Visible = False
	'                    Me.CustomValidator10.Enabled = False
	'                    Me.CustomValidator11.Enabled = False
	'                    Me.RequiredFieldValidator9.Enabled = False
	'                    Me.div_AcctBranch.Visible = False
	'                    Me.div_AcctProduct.Visible = False
	'                    Me.div_AcctDesc.Visible = False
	'                    Me.div_SubBranch.Visible = False
	'                    Me.Panel5.Visible = True
	'                    For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
	'                        Me.TxtLastname.Text = dr(0).ToString
	'                        Me.TxtFirstName.Text = dr(1).ToString
	'                        Me.TxtMiddlename.Text = dr(2).ToString
	'                        Me.DrpSex.SelectedValue = dr(27)
	'                        Me.txtDOB.SelectedDate = (dr(28).ToString.Trim)
	'                        Me.DrpNational.SelectedValue = dr(3).ToString





	'                        Me.DrpState.SelectedValue = dr(4).ToString


	'                        Me.Drpsector.SelectedValue = dr(5).ToString
	'                        Me.DrpResState.SelectedValue = dr(6).ToString



	'                        Me.DrpTown.SelectedValue = dr(7).ToString
	'                        Me.txtAddress.Text = dr(8).ToString
	'                        Me.txtAddress0.Text = dr(9).ToString



	'                        Me.txtphone1.Text = dr(10).ToString
	'                        Me.Txtphone2.Text = dr(11).ToString
	'                        Me.txtphone3.Text = dr(12).ToString
	'                        Me.Txtphone4.Text = dr(13).ToString
	'                        Me.DrpIdType.SelectedValue = dr(14).ToString
	'                        Me.txtIdNo.Text = dr(15).ToString
	'                        Me.txtnextofKin.Text = dr(16).ToString
	'                        Me.Txtkinphone.Text = dr(17).ToString

	'                        Me.TxtNOKRelationship.Text = dr(18).ToString
	'                        Me.DrpBranch.SelectedValue = dr(19).ToString
	'                        Me.DrpProduct.SelectedValue = dr(20).ToString
	'                        Me.txtacctdesc.Text = dr(21).ToString
	'                        Me.TxtContribution.Text = dr(22).ToString & vbNullString
	'                        Me.TxtyourAcctnumber.Text = dr(23).ToString

	'                        Me.Txtamount.Text = dr(25).ToString
	'                        Me.TxtTellerNumber.Text = dr(26).ToString

	'                        '   Format(CDate(dr("last_procdate").ToString.Trim), "dd-MM-yyyy")
	'                        '   Format(CDate(dr("last_procdate").ToString.Trim), "dd-MM-yyyy")

	'                        'CDate(Me.txtDOB.Text) = dr(29).ToString
	'                        Me.txtKinAddress.Text = dr(29).ToString
	'                        '   ProfileImage = filePath1 + drx.Item("Piture").ToString
	'                        '  Image1.ImageUrl = "~/UCP_IMAGE_FOLDER/Reg_Upload/" + dr(30).ToString
	'                        ProfileImage = filepath1 + dr(30).ToString
	'                        Image2.ImageUrl = "~/UCP_IMAGE_FOLDER/ID_Card_Upload/" + dr(31).ToString
	'                        Me.DropDownfee.SelectedValue = dr(32).ToString
	'                        Me.txtusername.Text = dr(33).ToString
	'                        userNAME = dr(33).ToString
	'                        Me.txtemployeeid.Text = dr(34).ToString
	'                        Me.txtemail.Text = dr(35).ToString




	'                        ' retmsg = dr(1).ToString

	'                    Next



	'                End If

	'            Catch ex As Exception
	'                logger.Info("CUSTOMER SERVICE: MEMBER CREATION  Page_Load" _
	'& vbNewLine & "   <<<<Direction: OUTPUT" _
	'& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
	'& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
	'& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
	'& vbNewLine & "******************************************************************************************************")
	'            End Try
	'            'RadComboBox2.DataSource = "SELECT  Node_id,tenant from Tbl_Tenants ORDER By tenant"
	'            'RadComboBox2.DataBind()
	'        End If
	'    End Sub
	Protected Sub BtnSubmit_Click(sender As Object, e As EventArgs) Handles BtnSubmit.Click

		Try


			If Me.txtphone1.Text = "" Then
					Me.Panel2.Visible = True
					Me.Panel1.Visible = False
					Me.Label_error.Visible = True
					Me.Label_success.Visible = False
					Me.Label_error.Text = "Oops! Please Enter Mobile Phone 1"

					'  txtphone1.Focus()
					Exit Sub
				Else

					Me.Panel2.Visible = False
					Me.Panel1.Visible = False


				End If



			If Me.txtfullname.Text = "" Then

				Me.Panel2.Visible = True
				Me.Panel1.Visible = False
				Me.Label_error.Visible = True
				Me.Label_success.Visible = False
				Me.Label_error.Text = "Oops! Please Enter Full Name"

				'txtnextofKin.Focus()
				Exit Sub
			Else

				Me.Panel2.Visible = False
				Me.Panel1.Visible = False

			End If



			qry = " declare @retmsg varchar(100),@retVal int " & vbNewLine
			qry = qry & "execute Proc_SP_InsCustomer "
			qry = qry & smartobj.EncoteWithSingleQuote(Me.txtfullname.Text.Trim.Replace("'", "")) & "," 'surname 
			qry = qry & smartobj.EncoteWithSingleQuote(Me.txtphone1.Text.Trim.Replace("'", "")) & ","


			qry = qry & smartobj.EncoteWithSingleQuote(Session("node_ID")) & " "
			qry = qry & ",@retVal OUTPUT,@retmsg OUTPUT select @retVal,@retmsg"


			For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
					retval = dr(0).ToString
					retmsg = dr(1).ToString

				Next


			If retval = "0" Then


				Me.Panel1.Visible = True
					Me.Panel2.Visible = False
					Me.Label_error.Visible = False
					Me.Label_success.Visible = True
					Me.Label_error.Visible = False
				Me.Label_success.Text = retmsg

			Else



				Me.Panel1.Visible = False
					Me.Panel2.Visible = True
					Me.Label_error.Visible = True
					Me.Label_success.Visible = False
					Me.Label_error.Text = retmsg



			End If
				Me.BtnSubmit.Enabled = False









		Catch ex As Exception

			'' smartobj.alertwindow(Me.Page, ex.Message, "Prime")

			logger.Info("CUSTOMER SERVICE: MEMBER CREATION  BtnSubmit_Click" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
			smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)

			Me.Panel2.Visible = True
			Me.Panel1.Visible = False
			Me.Label_error.Visible = True
			Me.Label_success.Visible = False
			Me.Label_error.Text = "Error Occurred Error!"


		End Try
	End Sub

End Class

