Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Data
Imports System.Threading
Imports System.Web.UI.WebControls
Partial Class CustomerService_CreateCustomer
    Inherits System.Web.UI.Page
    Private retmsg As String = ""
    Private retval As Integer
    Private MyCon As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Prime").ConnectionString)
    Dim customer As String = ""
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

#End Region
#Region "Pageload"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = "CUSTOMER SERVICE"
        Me.hypsearch.NavigateUrl = "javascript:customer2('document.aspnetForm." + txtnone.ClientID.ToString() + "');"
        HypSearch0.NavigateUrl = "javascript:staff('document.aspnetForm." + txtofficer.ClientID.ToString() + "');"
        HypSearch1.NavigateUrl = "javascript:staff('document.aspnetForm." + txtCompOffc.ClientID.ToString() + "');"

        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        If Page.IsPostBack = False Then

            Me.MultiView1.ActiveViewIndex = Me.RdBCustType.SelectedValue.Trim - 1
            Try

                imgdate1.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtDOB.ClientID.ToString() + "');"
                imgdate3.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtExpirydate.ClientID.ToString() + "');"
                imgdate2.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtIssue.ClientID.ToString() + "');"
                HyperLink1.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtcompDateReg.ClientID.ToString() + "');"

                Dim Dstring7 As String = "SELECT cast(ltrim(rtrim(sectorcode)) as varchar) sectorcode,sectorname FROM tbl_sector where status=1"
                smartobj.loadComboValues("--Select a Sector--- ", Me.DrpcompSector, Dstring7)

                smartobj.loadComboValues("--Select a Sector--- ", Me.Drpsector, Dstring7)

                Dim Dstring1 As String = "SELECT cast(ltrim(rtrim(titlecode)) as varchar) titleid,titlename FROM tbl_title where status=1 and titlecode<>3"
                smartobj.loadComboValues("--Select a Title--- ", Me.DrpTitle, Dstring1)

                Dim Dstring2 As String = "SELECT cast(ltrim(rtrim(sexcode)) as varchar) sexid,sexname FROM tbl_sex where status=1"
                smartobj.loadComboValues("--Select a Gender--- ", Me.DrpSex, Dstring2)

                Dim Dstring3 As String = "SELECT cast(ltrim(rtrim(profcode)) as varchar) prof_id,profname FROM tbl_profession where status=1"
                smartobj.loadComboValues("--Select an Occupation--- ", Me.DrpOccupation, Dstring3)

                Dim Dstring4 As String = "SELECT cast(ltrim(rtrim(Countrycode)) as varchar) Country_id,Countryname FROM tbl_Country where status=1"
                smartobj.loadComboValues("--Select a Country--- ", Me.DrpNational, Dstring4)

                Dim Dstring8 As String = "SELECT cast(ltrim(rtrim(Countrycode)) as varchar) Country_id,Countryname FROM tbl_Country where status=1"
                smartobj.loadComboValues("--Select a Country--- ", Me.DrpcompCountry, Dstring8)

                Dim Dstring5 As String = "SELECT cast(ltrim(rtrim(EducationCode)) as varchar) EducationCode,Educationname FROM tbl_Education where status=1"
                smartobj.loadComboValues("--Select Education Level--- ", Me.DrpEdu, Dstring5)

                Dim Dstring11 As String = "SELECT cast(ltrim(rtrim(GroupID)) as varchar) GroupID,GroupName FROM tbl_group where status=1"
                smartobj.loadComboValues("--Select a Group--- ", Me.DrpGroup, Dstring11)

                smartobj.loadComboValues("--Select a Group--- ", Me.DrpGroup0, Dstring11)

                Dim Dstring6 As String = "SELECT cast(ltrim(rtrim(idcardid)) as varchar) idcardid,idcardname FROM tbl_idcard where status=1"
                smartobj.loadComboValues("--Select an ID Type--- ", Me.DrpIdType, Dstring6)

                Dim Dstring As String = "SELECT cast(ltrim(rtrim(relationid)) as varchar) relationid,relationname FROM tbl_relationship where status=1 and relationid not in (0)"
                smartobj.loadComboValues("--Choose a Relationship--- ", Me.DrpRela, Dstring)

                Me.Btnsubmit.Text = "Submit"

            Catch ex As Exception
                smartobj.alertwindow(Me.Page, "Data Warnning error...", "Prime")

            End Try
        End If
    End Sub
#End Region
#Region "Task"
    Sub clear()
        Me.DrpTitle.SelectedValue = Nothing
        Me.txtSurname.Text = ""
        Me.txtFirstname.Text = ""
        Me.txtOthername.Text = ""
        Me.txtIdNo.Text = ""
        Me.DrpSex.SelectedValue = Nothing
        Me.DrpNational.SelectedValue = Nothing
        Me.DrpEdu.SelectedValue = Nothing
        Me.DrpState.SelectedValue = Nothing
        Me.DrpOccupation.SelectedValue = Nothing
        Me.txtAddress.Text = ""
        Me.DrpResState.SelectedValue = Nothing
        Me.DrpTown.SelectedValue = Nothing
        Me.txtPhone1.Text = ""
        Me.txtPhone2.Text = ""
        Me.txtphone3.Text = ""
        Me.txtPhone4.Text = ""
        Me.txtemail.Text = ""
        Me.txtnextofKin.Text = ""
        Me.txtKinphone.Text = ""
        Me.txtKinAddress.Text = ""
        Me.DrpIdType.SelectedValue = Nothing
        Me.txtIntroID.Text = ""
        Me.DrpGroup.SelectedValue = Nothing
        Me.txtOfficer.Text = ""
        Me.Btnsubmit.Enabled = True
        Me.ChkGroup.Checked = False
        Me.chksms.Checked = False
        Me.chksms2.Checked = False
    End Sub
    Sub clear2()

        Me.txtcompRegno.Text = ""
        Me.DrpcompSector.SelectedValue = Nothing
        Me.DrpcompCountry.SelectedValue = Nothing
        Me.DrpcompStateInc.SelectedValue = Nothing
        Me.DrpCompTown.SelectedValue = Nothing
        Me.txtCompaddr.Text = ""
        Me.txtcomePhone1.Text = ""
        Me.txtcomePhone2.Text = ""
        Me.txtcomePhone3.Text = ""
        Me.txtcomePhone4.Text = ""
        Me.txtcompemail.Text = ""
        Me.txtCompintro.Text = ""
        Me.txtCompOffc.Text = ""
        Me.txtCompname.Text = ""
        Me.txtcompDateReg.Text = ""
        Me.BtnSubmit2.Enabled = True
        Me.ChkGroup0.Checked = False
        Me.chksms0.Checked = False
        Me.chksms1.Checked = False
    End Sub
    Protected Sub BtnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsubmit.Click
        Try
            Dim istate As Integer = 0
            retmsg = ""

            Dim globaldate As Date = Now.Date


            If Me.RdBCustType.SelectedValue = "1" Then
                If Me.DrpTitle.SelectedValue = "0" Then
                    smartobj.alertwindow(Me.Page, "Choose a Title", "Prime")
                    DrpTitle.Focus()
                    Exit Sub

                End If
                If Me.txtSurname.Text = "" Then
                    smartobj.alertwindow(Me.Page, "Please Enter Surname", "Prime")
                    txtSurname.Focus()
                    Exit Sub

                End If
                If Me.txtFirstname.Text = "" Then
                    smartobj.alertwindow(Me.Page, "Please Enter First Name", "Prime")
                    txtFirstname.Focus()
                    Exit Sub

                End If
                If Me.txtDOB.Text = "" Then
                    smartobj.alertwindow(Me.Page, "Enter Date Of Birth", "Prime")
                    txtDOB.Focus()
                    Exit Sub

                End If
                If Me.DrpSex.SelectedIndex = 0 Then
                    smartobj.alertwindow(Me.Page, "Choose a Gender", "Prime")
                    DrpSex.Focus()
                    Exit Sub

                End If
                If Me.DrpNational.SelectedIndex = 0 Then
                    smartobj.alertwindow(Me.Page, "Choose a Nationality", "Prime")
                    DrpNational.Focus()
                    Exit Sub

                End If
                If Me.DrpState.SelectedIndex = 0 Then
                    smartobj.alertwindow(Me.Page, "Choose a State of Origin", "Prime")
                    DrpState.Focus()
                    Exit Sub
                End If
                If Me.txtAddress.Text = "" Then
                    smartobj.alertwindow(Me.Page, "Enter Residential Address", "Prime")
                    txtAddress.Focus()
                    Exit Sub

                End If
                If Me.DrpResState.SelectedIndex = 0 Then
                    smartobj.alertwindow(Me.Page, "Choose a Residential State", "Prime")
                    DrpResState.Focus()
                    Exit Sub
                End If
                If Me.DrpTown.SelectedIndex = 0 Then
                    smartobj.alertwindow(Me.Page, "Choose a Residential Town", "Prime")
                    DrpTown.Focus()
                    Exit Sub
                End If
               
                If Me.Txtphone1.Text = "" Then
                    smartobj.alertwindow(Me.Page, "Enter Mobile Phone 1", "Prime")
                    Txtphone1.Focus()
                    Exit Sub

                End If
                If Me.DrpIdType.SelectedIndex = 0 Then
                    smartobj.alertwindow(Me.Page, "Choose an ID Type", "Prime")
                    DrpIdType.Focus()
                    Exit Sub
                End If
                If Me.txtIdNo.Text = "" Then
                    smartobj.alertwindow(Me.Page, "Enter ID Number", "Prime")
                    txtIdNo.Focus()
                    Exit Sub
                End If
                If Me.txtIssue.Text = "" Then
                    smartobj.alertwindow(Me.Page, "Enter ID Issue Date", "Prime")
                    txtIssue.Focus()
                    Exit Sub
                End If
                If Me.txtExpirydate.Text = "" Then
                    smartobj.alertwindow(Me.Page, "Enter ID Expiry Date", "Prime")
                    txtExpirydate.Focus()
                    Exit Sub
                End If

                If DrpIdType.SelectedValue <> 0 Then
                    If Me.txtExpirydate.Text = "" Then
                        smartobj.alertwindow(Me.Page, "Enter ID expiry Date", "Prime")

                        Exit Sub

                    End If
                    If Me.txtIssue.Text = "" Then
                        smartobj.alertwindow(Me.Page, "Enter Issue Date", "Prime")
                        Exit Sub

                    End If
                End If

                If Me.txtIntroID.Text = "" Then
                    smartobj.alertwindow(Me.Page, "Enter Introducer ID", "Prime")
                    Exit Sub

                End If

                If Me.Drpsector.SelectedValue = "0" Then
                    smartobj.alertwindow(Me.Page, "Choose a Sector", "Prime")
                    Exit Sub

                End If


               
                Dim dob, issdate, expdate As Date
                If txtDOB.Text <> "" Then
                    If IsDate(txtDOB.Text.Trim) Then
                        'dob = System.DateTime.Parse(txtDOB.Text.Trim)
                        dob = CDate(txtDOB.Text.Trim)

                    End If
                Else
                    dob = globaldate
                End If

                If txtIssue.Text <> "" Then
                    If IsDate(txtIssue.Text.Trim) Then
                        'issdate = System.DateTime.Parse(Me.txtIssue.Text.Trim)
                        issdate = CDate(Me.txtIssue.Text.Trim)


                    End If
                Else
                    issdate = globaldate
                End If

                If txtExpirydate.Text <> "" Then
                    If IsDate(txtExpirydate.Text.Trim) Then
                        'expdate = System.DateTime.Parse(Me.txtExpirydate.Text.Trim)
                        expdate = CDate(Me.txtExpirydate.Text.Trim)


                    End If

                Else
                    expdate = globaldate

                End If
                If CDate(Me.txtExpirydate.Text) <= CDate(Me.txtIssue.Text) Then
                    smartobj.alertwindow(Me.Page, "Expiry date cannot be before issue date", "Error")
                    Me.txtExpirydate.Focus()
                    Exit Sub
                End If

                If CDate(Me.txtExpirydate.Text) < CDate(Profile.sysdate) Then
                    smartobj.alertwindow(Me.Page, "Expiry date is Invalid", "Error")
                    Me.txtExpirydate.Focus()
                    Exit Sub
                End If

                Dim overline As String = ""
                Dim overlineid As String = ""

                If Profile.overide = "1" Then
                    If Profile.valid <> "0" Then
                        smartobj.alertwindow(Me.Page, "Data Posted Was Not Override.Please Re-Post Data", "Prime")
                        smartobj.ClearWebPage(Me.Page)
                        Exit Sub
                    Else
                        overline = Profile.overide
                        overlineid = Profile.overideid
                    End If

                Else
                    overline = 0
                    overlineid = 0
                End If
                'Individual
                qry = " declare @retmsg varchar(100),@retVal int " & vbNewLine
                qry = qry & "execute Proc_InsCustomer "
                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpTitle.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtSurname.Text.Trim.Replace("'", "")) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtFirstname.Text.Trim.Replace("'", "")) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtOthername.Text.Trim.Replace("'", "")) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Format(CDate(dob), "MM/dd/yyyy hh:mm:ss")) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpSex.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpNational.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpEdu.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpState.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpOccupation.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtAddress.Text.Trim.Replace("'", "")) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtAddress0.Text.Trim.Replace("'", "")) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpResState.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpTown.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.Txtphone1.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.Txtphone2.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.Txtphone3.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.Txtphone4.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtemail.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtnextofKin.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.TxtKinphone.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtKinAddress.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpIdType.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtIdNo.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Format(CDate(issdate), "MM/dd/yyyy hh:mm:ss")) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Format(CDate(expdate), "MM/dd/yyyy hh:mm:ss")) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpGroup.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.Drpsector.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtcustid.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpRela.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtIntroID.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtrefname.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.Txtrefphone.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtOfficer.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtsignacct.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(smartobj.DecodeCkeckBox(Me.chksms)) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(smartobj.DecodeCkeckBox(Me.chksms2)) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(smartobj.DecodeCkeckBox(Me.chkStaffType)) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Profile.Userid.Trim) & ",NULL,@retVal OUTPUT,@retmsg OUTPUT "
                qry = qry & " select @retVal,@retmsg"


                For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                    retval = dr(0).ToString
                    retmsg = dr(1).ToString

                Next
                
                If retval = "0" Then
                    smartobj.alertwindow(Me.Page, retmsg, "Prime")

                    
                    ' uploadimage()
                Else
                    ' Me.Btnsubmit.Enabled = True
                    smartobj.alertwindow(Me.Page, retmsg, "Prime")

                End If
                Me.Btnsubmit.Enabled = False

                clear()


            End If




        Catch ex As Exception

            smartobj.alertwindow(Me.Page, "CustomerID Already exist", "Prime")

        End Try
    End Sub
    'Sub uploadimage()
    '    Try
    '        Dim intLength As Integer
    '        Dim intLength2 As Integer
    '        Dim imgType = File1.PostedFile.ContentType
    '        Dim imgType2 = File2.PostedFile.ContentType
    '        Dim arrContent As Byte()
    '        Dim arrContent2 As Byte()
    '        Dim empttyContent As Byte()
    '        Dim ext As String = "" : Dim ext2 As String = ""
    '        intLength = Convert.ToInt32(File1.PostedFile.InputStream.Length)
    '        intLength2 = Convert.ToInt32(File2.PostedFile.InputStream.Length)
    '        If File1.PostedFile Is Nothing Then
    '            smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
    '        Else
    '            If (intLength > 35001) Then
    '                smartobj.alertwindow(Me.Page, "Photo too Large for Upload", "Prime")
    '                Exit Sub
    '            Else
    '                Dim fileName As String = File1.PostedFile.FileName
    '                If fileName = "" Then
    '                Else
    '                    ext = fileName.Substring(fileName.LastIndexOf("."))
    '                    ext = ext.ToLower

    '                End If

    '            End If
    '        End If

    '        If File2.PostedFile Is Nothing Then
    '            smartobj.alertwindow(Me.Page, "Please Upload Account Signature", "Prime")
    '        Else
    '            If (intLength2 > 35001) Then
    '                smartobj.alertwindow(Me.Page, "Signature too large to Upload", "Prime")
    '                Exit Sub
    '            Else
    '                Dim fileName2 As String = File2.PostedFile.FileName
    '                If fileName2 = "" Then
    '                Else
    '                    ext2 = fileName2.Substring(fileName2.LastIndexOf("."))
    '                    ext2 = ext2.ToLower

    '                End If
    '            End If
    '        End If
    '        ReDim arrContent(intLength)
    '        ReDim arrContent2(intLength2)
    '        ReDim empttyContent(2)
    '        If intLength = 0 Then
    '            File1.PostedFile.InputStream.Read(empttyContent, 0, 2)
    '            imgType = ext
    '        Else
    '            File1.PostedFile.InputStream.Read(arrContent, 0, intLength)
    '        End If
    '        If intLength2 = 0 Then
    '            File2.PostedFile.InputStream.Read(empttyContent, 0, 2)
    '            imgType2 = ext2
    '        Else
    '            File2.PostedFile.InputStream.Read(arrContent2, 0, intLength)
    '        End If

    '        If Doc2SQLServer(Profile.CustomerNO.ToString.Trim, arrContent, arrContent2, imgType, imgType2) = True Then
    '            smartobj.alertwindow(Me.Page, "Image uploaded successfully.", "Prime")
    '        Else
    '            smartobj.alertwindow(Me.Page, "Please upload Signature in Jpeg Format Only", "Prime")
    '        End If


    '    Catch ex As Exception
    '        smartobj.alertwindow(Me.Page, "Please upload Signature in Jpeg Format Only", "Prime")
    '    End Try

    'End Sub
    'Protected Function Doc2SQLServer(ByVal title As String, ByVal Content As Byte(), ByVal Content2 As Byte(), ByVal strType As String, ByVal strType2 As String) As Boolean
    '    Try
    '        Dim cmd As Data.SqlClient.SqlCommand
    '        Dim param As Data.SqlClient.SqlParameter
    '        Dim strSQL As String
    '        strSQL = "Update tbl_CustomerTemp set customerImage=@content,signatureImage=@content2,Image_Type=@type,Image_Type2=@type where CustomerId=@title"

    '        cmd = New Data.SqlClient.SqlCommand(strSQL, MyCon)
    '        param = New Data.SqlClient.SqlParameter("@content", Data.SqlDbType.Image)
    '        param.Value = Content
    '        cmd.Parameters.Add(param)
    '        param = New Data.SqlClient.SqlParameter("@content2", Data.SqlDbType.Image)
    '        param.Value = Content2
    '        cmd.Parameters.Add(param)
    '        param = New Data.SqlClient.SqlParameter("@title", Data.SqlDbType.VarChar)
    '        param.Value = title
    '        cmd.Parameters.Add(param)
    '        param = New Data.SqlClient.SqlParameter("@type", Data.SqlDbType.VarChar)
    '        param.Value = strType
    '        cmd.Parameters.Add(param)
    '        param = New Data.SqlClient.SqlParameter("@type2", Data.SqlDbType.VarChar)
    '        param.Value = strType2
    '        cmd.Parameters.Add(param)
    '        MyCon.Open()
    '        cmd.ExecuteNonQuery()
    '        MyCon.Close()
    '        Return True
    '    Catch ex As Exception
    '        smartobj.alertwindow(Me.Page, "Error uploading Image", "Prime")
    '        'Return False

    '    End Try

    'End Function
    Protected Sub Btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btncancel.Click
        clear()
        Me.Btnsubmit.Enabled = True
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub DrpNational_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpNational.SelectedIndexChanged
        Dim Dstring5 As String = "SELECT cast(ltrim(rtrim(stateCode)) as varchar) statecode,Statename FROM tbl_state where status=1 and Countrycode='" & Me.DrpNational.SelectedValue & "'"
        smartobj.loadComboValues("--Select a State--- ", Me.DrpState, Dstring5)

        Dim Dstring6 As String = "SELECT cast(ltrim(rtrim(stateCode)) as varchar) statecode,Statename FROM tbl_state where status=1 and Countrycode='" & Me.DrpNational.SelectedValue & "'"
        smartobj.loadComboValues("--Select a State--- ", Me.DrpResState, Dstring6)

    End Sub

    Protected Sub DrpResState_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpResState.SelectedIndexChanged
        Dim Dstring6 As String = "SELECT cast(ltrim(rtrim(townCode)) as varchar) towncode,townname FROM tbl_town where status=1 and statecode='" & Me.DrpResState.SelectedValue & "'"
        smartobj.loadComboValues("--Select a Town--- ", Me.DrpTown, Dstring6)

    End Sub

    Protected Sub DrpcompCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpcompCountry.SelectedIndexChanged
        Dim Dstring5 As String = "SELECT cast(ltrim(rtrim(stateCode)) as varchar) statecode,Statename FROM tbl_state where status=1 and Countrycode='" & Me.DrpcompCountry.SelectedValue & "'"
        smartobj.loadComboValues("--Select a State--- ", Me.DrpcompStateInc, Dstring5)

    End Sub
    Protected Sub DrpIdType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpIdType.SelectedIndexChanged
        If Me.DrpIdType.SelectedValue.Length > 5 Then
            Me.txtIdNo.ReadOnly = True
            Me.txtIssue.ReadOnly = True
            Me.txtExpirydate.ReadOnly = True
        Else
            Me.txtIdNo.ReadOnly = False
            Me.txtIssue.ReadOnly = False
            Me.txtExpirydate.ReadOnly = False
        End If
    End Sub

    Protected Sub txtIntroID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIntroID.TextChanged
        valintro()
    End Sub

    Protected Sub RdBCustType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdBCustType.SelectedIndexChanged
        If Me.RdBCustType.SelectedValue = "1" Then
            Me.MultiView1.ActiveViewIndex = 0
        Else
            Me.MultiView1.ActiveViewIndex = 1

        End If
    End Sub
    Protected Sub txtOfficer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOfficer.TextChanged
        Dim selcust As String = "exec proc_Officers '" & Me.txtOfficer.Text & "'"
        If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
            For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                Me.Label2.Text = dr!fullname.ToString
            Next
        Else
            Me.Label2.Text = "INVALID STAFF ID"
            Exit Sub
        End If
    End Sub
    Protected Sub txtCompintro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCompintro.TextChanged
        Me.Label3.Text = ""
        If Me.drpintro2.SelectedValue = "2" Then
            Dim selcust As String = "Select Surname+' '+Firstname+' '+ othername 'name' from tbl_customer where customerid='" & Me.txtCompintro.Text & "'"
            If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                    Me.Label3.Text = dr!name.ToString
                Next
            Else
                Me.Label3.Text = "INVALID CUSTOMERID"
                Exit Sub
            End If
        Else
            Dim selcust As String = "exec proc_Officers '" & Me.txtCompintro.Text & "'"
            If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                    Me.Label3.Text = dr!fullname.ToString
                Next
            Else
                Me.Label3.Text = "INVALID STAFF ID"
                Exit Sub
            End If
        End If
    End Sub
    Protected Sub txtCompOffc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCompOffc.TextChanged
        Dim selcust As String = "exec proc_Officers '" & Me.txtCompOffc.Text & "'"
        If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
            For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                Me.Label4.Text = dr!fullname.ToString
            Next
        Else
            Me.Label4.Text = "INVALID STAFF ID"
            Exit Sub
        End If
    End Sub

    Protected Sub DrpcompStateInc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpcompStateInc.SelectedIndexChanged
        Dim Dstring6 As String = "SELECT cast(ltrim(rtrim(townCode)) as varchar) towncode,townname FROM tbl_town where status=1 and statecode='" & Me.DrpcompStateInc.SelectedValue & "'"
        smartobj.loadComboValues("--Select Company Town--- ", Me.DrpCompTown, Dstring6)

    End Sub
    Protected Sub ChkGroup_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkGroup.CheckedChanged
        If Me.ChkGroup.Checked = True Then
            Me.DrpGroup.Visible = True
        Else
            Me.DrpGroup.Visible = False

        End If
    End Sub

    Protected Sub BtnSubmit2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSubmit2.Click

        Dim dreg As Date


        If Me.txtcompRegno.Text = "" Then
            smartobj.alertwindow(Me.Page, "Please Enter Company Registration Number", "Prime")
            txtcompRegno.Focus()
            Exit Sub
        End If
        If Me.txtCompname.Text = "" Then
            smartobj.alertwindow(Me.Page, "Please Enter Company Name", "Prime")
            txtCompname.Focus()
            Exit Sub
        End If
        If Me.txtcompDateReg.Text = "" Then
            smartobj.alertwindow(Me.Page, "Please Enter Companys Date of Incorporation", "Prime")
            txtcompDateReg.Focus()
            Exit Sub
        Else
            dreg = System.DateTime.Parse(Me.txtcompDateReg.Text)
        End If
        If Me.DrpcompCountry.SelectedIndex = 0 Then
            smartobj.alertwindow(Me.Page, "Please Enter Country of Incorporation", "Prime")
            DrpcompCountry.Focus()
            Exit Sub
        End If

        If Me.txtCompaddr.Text = "" Then
            smartobj.alertwindow(Me.Page, "Please Enter Company Address", "Prime")
            txtCompaddr.Focus()
            Exit Sub
        End If
        If Me.TxtcomePhone1.Text = "" Then
            smartobj.alertwindow(Me.Page, "Please Enter Company Phone No", "Prime")
            TxtcomePhone1.Focus()
            Exit Sub
        End If

        'Corporate
        qry = " declare @retmsg varchar(100),@retVal int " & vbNewLine
        qry = qry & "execute Proc_insCorporateCustomer "
        qry = qry & smartobj.EncoteWithSingleQuote(Me.txtcompRegno.Text.Trim) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Me.txtCompname.Text.Trim.Replace("'", "")) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Format(CDate(dreg), "MM/dd/yyyy hh:mm:ss")) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpcompSector.SelectedValue.Trim) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpcompCountry.SelectedValue.Trim) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpcompStateInc.Text.Trim) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpCompTown.SelectedValue.Trim) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Me.txtCompaddr.Text.Trim.Replace("'", "")) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Me.TxtcomePhone1.Text.Trim) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Me.TxtcomePhone2.Text.Trim) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Me.TxtcomePhone3.Text.Trim) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Me.TxtcomePhone4.Text.Trim) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Me.txtcompemail.Text.Trim) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Me.txtcontactperson.Text.Trim) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Me.txtCompintro.Text.Trim) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpGroup0.SelectedValue.Trim) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(smartobj.DecodeCkeckBox(Me.chksms0)) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(smartobj.DecodeCkeckBox(Me.chksms1)) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Profile.Userid.Trim) & ",null,"
        qry = qry & smartobj.EncoteWithSingleQuote(Me.txtCompOffc.Text.Trim) & ",@retVal OUTPUT,@retmsg OUTPUT "
        qry = qry & " select @retVal ,@retmsg "

        For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
            retval = dr(0).ToString
            retmsg = dr(1).ToString
            'Profile.CustomerNO = customer

        Next
        If retval = "0" Then

            'smartobj.alertwindow(Me.Page, retmsg, "Prime")
            smartobj.alertwindow(Me.Page, retmsg, "Prime")

            ' Me.BtnSubmit2.Enabled = True
        Else
            smartobj.alertwindow(Me.Page, retmsg, "Prime")

            ' Me.BtnSubmit2.Enabled = True

        End If
        Me.Btnsubmit.Enabled = False

        clear2()
    End Sub
    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        clear()
        Me.Btnsubmit.Enabled = True
        Response.Redirect("Default.aspx")
    End Sub
    Protected Sub DrpIntro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpIntro.SelectedIndexChanged
        valintro()
    End Sub
    Sub valintro()
        Me.Label1.Text = ""
        If Me.DrpIntro.SelectedValue = "2" Then
            If Me.txtIntroID.Text <> "" Then
                Dim selcust As String = "Select Surname+' '+Firstname+' '+ othername 'name' from tbl_customer where customerid='" & Me.txtIntroID.Text & "'"
                If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                    For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                        Me.Label1.Text = dr!name.ToString
                    Next
                Else
                    Me.Label1.Text = "INVALID CUSTOMERID"
                    Exit Sub
                End If
            End If

        Else
            If Me.txtIntroID.Text <> "" Then
                Dim selcust As String = "exec proc_Officers '" & Me.txtIntroID.Text & "'"
                If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                    For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                        Me.Label1.Text = dr!fullname.ToString
                    Next
                Else
                    Me.Label1.Text = "INVALID STAFF ID"
                    Exit Sub
                End If
            End If

        End If
    End Sub
    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Me.DrpRela.Visible = True
            Me.txtcustid.Visible = True
            Me.Label5.Visible = True
        Else
            Me.DrpRela.Visible = False
            Me.txtcustid.Visible = False
            Me.Label5.Visible = False
        End If
    End Sub

    Protected Sub txtcustid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcustid.TextChanged
        Try
            Dim selcust As String = "Select Surname+' '+Firstname+' '+ othername 'name' from tbl_customer where customerid='" & Me.txtcustid.Text & "'"
            If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                    Me.Label6.Text = dr!name.ToString
                Next
            Else
                Me.Label6.Text = "INVALID CUSTOMERID"
                Me.txtcustid.Text = ""
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region
    

  
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        clear2()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        clear()
    End Sub

  
    Protected Sub ChkGroup0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkGroup0.CheckedChanged
        If Me.ChkGroup0.Checked = True Then
            Me.DrpGroup0.Visible = True
        Else
            Me.DrpGroup0.Visible = False

        End If
    End Sub

    Protected Sub txtsignacct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsignacct.TextChanged
        Try
            Label8.Text = ""
            Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtsignacct.Text.Trim & "',@retval output,@retmsg output select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            If retval = "0" Then
                Me.txtsignacct.Text = retmsg
            End If

            Dim selExist As String = "Exec Proc_CustAcctDetail '" & Me.txtsignacct.Text.Trim & "'"
            If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then
                drx = con.SqlDs(selExist).Tables(0).Rows(0)
                Me.Label8.Text = drx.Item("accounttitle").ToString
            End If


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If Me.CheckBox2.Checked = True Then
            Me.txtsignacct.Visible = True
            Me.Label8.Visible = True
            Me.Label7.Visible = True
        Else
            Me.txtsignacct.Visible = False
            Me.Label8.Visible = False
            Me.Label7.Visible = False
        End If
    End Sub
    Private Function IsNumber(ByVal text As String) As Boolean
        Dim res As Boolean = True

        Try
            If Not String.IsNullOrEmpty(text) AndAlso ((text.Length <> 1) OrElse (text <> "-")) Then
                Dim d As Decimal = Decimal.Parse(text, CultureInfo.CurrentCulture)
            End If
        Catch
            res = False
        End Try

        Return res
    End Function

    Protected Sub txtExpirydate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExpirydate.TextChanged
        'If Me.txtIssue .Text 
    End Sub
End Class
