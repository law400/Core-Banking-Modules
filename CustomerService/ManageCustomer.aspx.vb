Imports System.Data.SqlClient
Imports log4net

Partial Class CustomerService_ManageCustomer
    Inherits SessionCheck
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(CustomerService_ManageCustomer))

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

#End Region
    'Sub clear()
    '    Me.DrpTitle.SelectedValue = Nothing
    '    Me.txtSurname.Text = ""
    '    Me.txtOthername.Text = ""
    '    Me.txtFirstname.Text = ""
    '    Me.txtDOB.Text = ""
    '    Me.DrpSex.SelectedValue = Nothing
    '    Me.DrpNational.SelectedValue = Nothing
    '    Me.DrpState.SelectedValue = Nothing
    '    Me.DrpOccupation.SelectedValue = Nothing
    '    Me.txtAddress.Text = ""
    '    Me.DrpResState.SelectedValue = Nothing
    '    Me.DrpTown.SelectedValue = Nothing
    '    Me.txtPhone1.Text = ""
    '    Me.txtPhone2.Text = ""
    '    Me.txtphone3.Text = ""
    '    Me.txtPhone4.Text = ""
    '    Me.txtemail.Text = ""
    '    Me.txtnextofKin.Text = ""
    '    Me.DrpIdType.SelectedValue = Nothing
    '    Me.txtIssue.Text = ""
    '    Me.txtExpirydate.Text = ""
    '    Me.txtOfficer.Text = ""
    '    Me.txtIntroID.Text = ""
    'End Sub
#Region "Pageload"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("Label3"), System.Web.UI.WebControls.Label)
        l.Text = ""
        Dim ll As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("Label4"), System.Web.UI.WebControls.Label)
        ll.Text = "EDIT MEMBER" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim

        Dim menuname As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("lbldisplay"), System.Web.UI.WebControls.Label)
        menuname.Text = Request.QueryString("XXX")
        If menuname.Text = "" Then
            Response.Redirect("~/Unauthorize.aspx")
        End If

        If Validate_Access(menuname.Text) = 0 Then
            Response.Redirect("~/Unauthorize.aspx")
        End If

        ' HypSearch1.NavigateUrl = "javascript:staff('document.aspnetForm." + txtOfficer.ClientID.ToString() + "');"
        ' HypSearch0.NavigateUrl = "javascript:staff('document.aspnetForm." + txtCompOffc.ClientID.ToString() + "');"

        Me.Hypsearch.NavigateUrl = "javascript:customer2('document.aspnetForm." + txtCustomerid.ClientID.ToString() + "');"
        imgdate1.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtDOB.ClientID.ToString() + "');"
        imgdate3.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtExpirydate.ClientID.ToString() + "');"
        imgdate2.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtIssue.ClientID.ToString() + "');"

        If Page.IsPostBack = False Then

            Try



                Dim Dstring7 As String = "SELECT cast(ltrim(rtrim(sectorcode)) as varchar) sectorcode,sectorname FROM tbl_sector where status=1"
                smartobj.loadComboValues("--Select a Sector--- ", Me.DrpcompSector, Dstring7)

                smartobj.loadComboValues("--Select a Sector--- ", Me.Drpsector, Dstring7)

                Dim Dstring1 As String = "SELECT cast(ltrim(rtrim(titlecode)) as varchar) titleid,titlename FROM tbl_title where status=1"
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

                Dim Dstring9 As String = "SELECT cast(ltrim(rtrim(stateCode)) as varchar) statecode,Statename FROM tbl_state where status=1"
                smartobj.loadComboValues("--Select a State--- ", Me.DrpState, Dstring9)

                Dim Dstring10 As String = "SELECT cast(ltrim(rtrim(stateCode)) as varchar) statecode,Statename FROM tbl_state where status=1"
                smartobj.loadComboValues("--Select a State--- ", Me.DrpResState, Dstring10)

                Dim Dstring6 As String = "SELECT cast(ltrim(rtrim(townCode)) as varchar) towncode,townname FROM tbl_town where status=1"
                smartobj.loadComboValues("--Select a Town--- ", Me.DrpTown, Dstring6)

                smartobj.loadComboValues("--Select a Town--- ", Me.DrpCompTown, Dstring6)

                Dim Dstring11 As String = "SELECT cast(ltrim(rtrim(idcardid)) as varchar) idcardid,idcardname FROM tbl_idcard where status=1"
                smartobj.loadComboValues("--Select an ID Type--- ", Me.DrpIdType, Dstring11)
                smartobj.loadComboValues("--Select a State--- ", Me.DrpcompStateInc, Dstring10)

                Dim Dstring21 As String = "SELECT cast(ltrim(rtrim(GroupID)) as varchar) GroupID,GroupName FROM tbl_group where status=1"
                smartobj.loadComboValues("--Select a Group--- ", Me.DrpGroup, Dstring21)


                Me.Btnsubmit.Text = "Update"

            Catch ex As Exception
                ''     smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")

                logger.Info("Manage Customer: ManageCustomer PAGE - ERROR AT Page_Load '" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")

                PrimeApp.ShowToastr(Page, "Data Warning error...", "Error!", "Danger", False, "toast-top-right", False)


            End Try
        End If
    End Sub

    Function Validate_Access(ByVal MenuName As String) As Integer

        qry = " declare @retVal int " & vbNewLine
        qry = qry & "execute Proc_RM_Validate "
        qry = qry & smartobj.EncoteWithSingleQuote(Session("Roleid")) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(MenuName) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Session("Userid")) & ",@retVal OUTPUT," & Session("node_ID") & " "
        qry = qry & " select @retVal"

        For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
            retval = dr(0).ToString
        Next
        Return retval
    End Function
#End Region
#Region "Task"
    Protected Sub BtnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsubmit.Click
        Try
            Dim globaldate As Date = "01/01/1900"
            Dim istate As Integer = 0
            retmsg = ""
            Dim customer As String = ""
            If Session("Custtype") = "1" Then

                If Me.DrpTitle.SelectedValue = "0" Then
                    '  smartobj.alertwindow(Me.Page, "Choose a Title", "Prime")
                    PrimeApp.ShowToastr(Page, "Choose a Title", "Oops!", "Warning", False, "toast-top-right", False)


                    DrpTitle.Focus()
                    Exit Sub

                End If
                If Me.txtSurname.Text = "" Then
                    ''   smartobj.alertwindow(Me.Page, "Please Enter Surname", "Prime")
                    PrimeApp.ShowToastr(Page, "Please Enter Surname", "Oops!", "Warning", False, "toast-top-right", False)

                    txtSurname.Focus()
                    Exit Sub

                End If
                If Me.txtFirstname.Text = "" Then
                    ''  smartobj.alertwindow(Me.Page, "Please Enter First Name", "Prime")

                    PrimeApp.ShowToastr(Page, "Please Enter First Name", "Oops!", "Warning", False, "toast-top-right", False)

                    txtFirstname.Focus()
                    Exit Sub

                End If
                If Me.txtDOB.Text = "" Then
                    ''  smartobj.alertwindow(Me.Page, "Enter Date Of Birth", "Prime")

                    PrimeApp.ShowToastr(Page, "Enter Date Of Birth", "Oops!", "Warning", False, "toast-top-right", False)


                    txtDOB.Focus()
                    Exit Sub

                End If
                If Me.DrpSex.SelectedIndex = 0 Then
                    ''  smartobj.alertwindow(Me.Page, "Choose a Gender", "Prime")

                    PrimeApp.ShowToastr(Page, "Choose a Gender", "Oops!", "Warning", False, "toast-top-right", False)


                    DrpSex.Focus()
                    Exit Sub

                End If
                If Me.DrpNational.SelectedIndex = 0 Then
                    ''    smartobj.alertwindow(Me.Page, "Choose a Nationality", "Prime")

                    PrimeApp.ShowToastr(Page, "Choose a Nationality", "Oops!", "Warning", False, "toast-top-right", False)


                    DrpNational.Focus()
                    Exit Sub

                End If
                If Me.DrpState.SelectedIndex = 0 Then
                    ''   smartobj.alertwindow(Me.Page, "Choose a State of Origin", "Prime")

                    PrimeApp.ShowToastr(Page, "Choose a State of Origin", "Oops!", "Warning", False, "toast-top-right", False)


                    DrpState.Focus()
                    Exit Sub
                End If
                If Me.txtAddress.Text = "" Then
                    ''     smartobj.alertwindow(Me.Page, "Enter Residential Address", "Prime")

                    PrimeApp.ShowToastr(Page, "Enter Residential Address", "Oops!", "Warning", False, "toast-top-right", False)


                    txtAddress.Focus()
                    Exit Sub

                End If
                If Me.DrpResState.SelectedIndex = 0 Then
                    ''     smartobj.alertwindow(Me.Page, "Choose a Residential State", "Prime")

                    PrimeApp.ShowToastr(Page, "Choose a Residential State", "Oops!", "Warning", False, "toast-top-right", False)


                    DrpResState.Focus()
                    Exit Sub
                End If
                If Me.DrpTown.SelectedIndex = 0 Then
                    ''  smartobj.alertwindow(Me.Page, "Choose a Residential Town", "Prime")

                    PrimeApp.ShowToastr(Page, "Choose a Residential Town", "Oops!", "Warning", False, "toast-top-right", False)


                    DrpTown.Focus()
                    Exit Sub
                End If

                If Me.txtphone1.Text = "" Then
                    ''  smartobj.alertwindow(Me.Page, "Enter Mobile Phone 1", "Prime")

                    PrimeApp.ShowToastr(Page, "Enter Mobile Phone 1", "Oops!", "Warning", False, "toast-top-right", False)


                    txtphone1.Focus()
                    Exit Sub

                End If
                If Me.DrpIdType.SelectedIndex = 0 Then
                    ''  smartobj.alertwindow(Me.Page, "Choose an ID Type", "Prime")

                    PrimeApp.ShowToastr(Page, "Choose an ID Type", "Oops!", "Warning", False, "toast-top-right", False)


                    DrpIdType.Focus()
                    Exit Sub
                End If
                If Me.txtIdNo.Text = "" Then
                    '' smartobj.alertwindow(Me.Page, "Enter ID Number", "Prime")

                    PrimeApp.ShowToastr(Page, "Enter ID Number", "Oops!", "Warning", False, "toast-top-right", False)


                    txtIdNo.Focus()
                    Exit Sub
                End If
                If Me.txtIssue.Text = "" Then
                    ''    smartobj.alertwindow(Me.Page, "Enter ID Issue Date", "Prime")

                    PrimeApp.ShowToastr(Page, "Enter ID Issue Date", "Oops!", "Warning", False, "toast-top-right", False)


                    txtIssue.Focus()
                    Exit Sub
                End If
                If Me.txtExpirydate.Text = "" Then
                    ''    smartobj.alertwindow(Me.Page, "Enter ID Expiry Date", "Prime")

                    PrimeApp.ShowToastr(Page, "Enter ID Expiry Date", "Oops!", "Warning", False, "toast-top-right", False)


                    txtExpirydate.Focus()
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
                ' ''If Me.txtIssue.Text Or Me.txtExpirydate.Text <> "" Then
                ' ''    If CDate(Me.txtExpirydate.Text) <= CDate(Me.txtIssue.Text) Then
                ' ''        smartobj.alertwindow(Me.Page, "Expiry date cannot be before issue date", "Error")
                ' ''        Me.txtExpirydate.Focus()
                ' ''        Exit Sub
                ' ''    End If
                ' ''End If
                'Individual
                qry = " declare @retmsg varchar(100),@retVal int " & vbNewLine
                qry = qry & "execute Proc_updcustomer "
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtCustomerid.Text.Trim) & ","
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
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtphone1.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.Txtphone2.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtphone3.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.Txtphone4.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtemail.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtnextofKin.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.Txtkinphone.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtKinAddress.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpIdType.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtIdNo.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Format(CDate(issdate), "MM/dd/yyyy hh:mm:ss")) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Format(CDate(expdate), "MM/dd/yyyy hh:mm:ss")) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpGroup.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.Drpsector.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtcustid.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtsignacct.Text.Trim) & ","

                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpRela.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtIntroID.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtrefname.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtRefphone.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(smartobj.DecodeCkeckBox(Me.chksms)) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpCustType.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Session("Userid").Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Session("EventLogID")) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(smartobj.DecodeCkeckBox(Me.chkStaffType)) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtOfficer.Text.Trim) & ",@retVal OUTPUT,@retmsg OUTPUT, " & Session("node_ID") & " "
                qry = qry & " select @retVal,@retmsg"


                For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                    retval = dr(0).ToString
                    retmsg = dr(1).ToString
                Next
                'If retval = "1" Then
                '    smartobj.alertwindow(Me.Page, retmsg, "Prime")
                '    uploadimage()
                'Else

                'End If
                ''  smartobj.alertwindow(Me.Page, retmsg, "Prime")

                PrimeApp.ShowToastr(Page, retmsg, "Info!", "Info", False, "toast-top-right", False)


                smartobj.ClearWebPage(Me.Page)
            Else

                Dim dreg As Date
                ' dreg = System.DateTime.Parse(Me.txtcompDateReg.Text)
                If Me.txtcompRegno.Text = "" Then
                    ''  smartobj.alertwindow(Me.Page, "Please Enter Company Registration Number", "Prime")


                    PrimeApp.ShowToastr(Page, "Please Enter Company Registration Number", "Oops!", "Warning", False, "toast-top-right", False)


                    txtcompRegno.Focus()
                    Exit Sub
                End If
                If Me.txtCompname.Text = "" Then
                    ''    smartobj.alertwindow(Me.Page, "Please Enter Company Name", "Prime")

                    PrimeApp.ShowToastr(Page, "Please Enter Company Name", "Oops!", "Warning", False, "toast-top-right", False)


                    txtCompname.Focus()
                    Exit Sub
                End If
                If Me.txtcompDateReg.Text = "" Then
                    ''   smartobj.alertwindow(Me.Page, "Please Enter Company's Date of Incorporation", "Prime")

                    PrimeApp.ShowToastr(Page, "Please Enter Company's Date of Incorporation", "Oops!", "Warning", False, "toast-top-right", False)



                    txtcompDateReg.Focus()
                    Exit Sub
                Else
                    dreg = System.DateTime.Parse(Me.txtcompDateReg.Text)
                End If
                If Me.DrpcompCountry.SelectedIndex = 0 Then
                    '' smartobj.alertwindow(Me.Page, "Please Enter Country of Incorporation", "Prime")


                    PrimeApp.ShowToastr(Page, "Please Enter Country of Incorporation", "Oops!", "Warning", False, "toast-top-right", False)


                    DrpcompCountry.Focus()
                    Exit Sub
                End If

                If Me.txtCompaddr.Text = "" Then
                    ''    smartobj.alertwindow(Me.Page, "Please Enter Company Address", "Prime")

                    PrimeApp.ShowToastr(Page, "Please Enter Company Address", "Oops!", "Warning", False, "toast-top-right", False)


                    txtCompaddr.Focus()
                    Exit Sub
                End If
                If Me.Txtcomephone1.Text = "" Then
                    ''  smartobj.alertwindow(Me.Page, "Please Enter Company Phone No", "Prime")


                    PrimeApp.ShowToastr(Page, "Please Enter Company Phone No", "Oops!", "Warning", False, "toast-top-right", False)


                    Txtcomephone1.Focus()
                    Exit Sub
                End If
                'Corporate
                qry = " declare @retmsg varchar(100),@retVal int " & vbNewLine
                qry = qry & "execute Proc_updcorporatecustomer "
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtCustomerid.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtcompRegno.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtCompname.Text.Trim.Replace("'", "")) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Format(CDate(dreg), "MM/dd/yyyy hh:mm:ss")) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpcompSector.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpcompCountry.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpcompStateInc.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpCompTown.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtCompaddr.Text.Trim.Replace("'", "")) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.Txtcomephone1.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.Txtcomephone2.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.Txtcomephone3.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.Txtcomephone4.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtcompemail.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtcontact.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtCompintro.Text.Trim) & ","
                ''qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpIdType.SelectedValue.Trim) & ","
                ''qry = qry & smartobj.EncoteWithSingleQuote(Me.txtIntroID.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(smartobj.DecodeCkeckBox(Me.chksms0)) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpCustType0.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Session("Userid").Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtCompOffc.Text.Trim) & ",@retVal OUTPUT,@retmsg OUTPUT , " & Session("node_ID") & ""
                qry = qry & " select @retVal ,@retmsg "

                For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                    retval = dr(0).ToString
                    retmsg = dr(1).ToString
                Next
                'If retval = "1" Then
                '    smartobj.alertwindow(Me.Page, retmsg, "Prime")
                'Else

                'End If
                ''  smartobj.alertwindow(Me.Page, retmsg, "Prime")

                PrimeApp.ShowToastr(Page, retmsg, "Info!", "Info", False, "toast-top-right", False)


                smartobj.ClearWebPage(Me.Page)
            End If




        Catch ex As Exception

            logger.Info("Manage Customer: ManageCustomer PAGE - ERROR AT BtnSubmit_Click '" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")

            ''    smartobj.alertwindow(Me.Page, retmsg, "Prime")

            PrimeApp.ShowToastr(Page, "Error Occurred", "Error!", "Danger", False, "toast-top-right", False)


        End Try
    End Sub

    'Protected Sub Btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
    '    smartobj.ClearWebPage(Me.Page)
    '    clear()
    '    Response.Redirect("Default.aspx")
    '    Me.BtnSubmit.Enabled = True
    'End Sub
    Protected Sub DrpNational_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpNational.SelectedIndexChanged
        Dim Dstring5 As String = "SELECT cast(ltrim(rtrim(stateCode)) as varchar) statecode,Statename FROM tbl_state where status=1 and Countrycode='" & Me.DrpNational.SelectedValue & "'"
        smartobj.loadComboValues("--Select a State--- ", Me.DrpState, Dstring5)

        Dim Dstring6 As String = "SELECT cast(ltrim(rtrim(stateCode)) as varchar) statecode,Statename FROM tbl_state where status=1 and Countrycode='" & Me.DrpNational.SelectedValue & "'"
        smartobj.loadComboValues("--Select a State--- ", Me.DrpResState, Dstring6)

    End Sub
    Protected Sub DrpResState_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpResState.SelectedIndexChanged
        Dim Dstring6 As String = "SELECT cast(ltrim(rtrim(townCode)) as varchar) towncode,townname FROM tbl_town where status=1 and Statecode='" & Me.DrpResState.SelectedValue & "'"
        smartobj.loadComboValues("--Select a Town--- ", Me.DrpTown, Dstring6)

    End Sub
    Protected Sub DrpcompCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpcompCountry.SelectedIndexChanged
        Dim Dstring5 As String = "SELECT cast(ltrim(rtrim(stateCode)) as varchar) statecode,Statename FROM tbl_state where status=1 and Countrycode='" & Me.DrpcompCountry.SelectedValue & "'"
        smartobj.loadComboValues("--Select a State--- ", Me.DrpcompStateInc, Dstring5)

    End Sub
    ''Protected Sub DrpIdType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpIdType.SelectedIndexChanged
    ''    If Me.DrpIdType.SelectedValue.Length > 5 Then
    ''        Me.txtIdNo.ReadOnly = True
    ''        Me.txtIssue.ReadOnly = True
    ''        Me.txtExpirydate.ReadOnly = True
    ''    Else
    ''        Me.txtIdNo.ReadOnly = False
    ''        Me.txtIssue.ReadOnly = False
    ''        Me.txtExpirydate.ReadOnly = False
    ''    End If
    ''End Sub
    Protected Sub txtIntroID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIntroID.TextChanged
        Try
            Me.Label1.Text = ""
            If Me.DrpIntro.SelectedValue = "2" Then
                Dim selcust As String = "Select Surname+' '+Firstname+' '+ othername 'name' from tbl_customer where customerid='" & Me.txtIntroID.Text & "' and node_id = " & Session("node_ID") & ""
                If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                    For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                        Me.Label1.Text = dr!name.ToString
                    Next
                Else
                    Me.Label1.Text = "INVALID CUSTOMERID"
                    Exit Sub
                End If
            Else
                Dim selcust As String = "Exec proc proc_Officers '" & Me.txtIntroID.Text & "', " & Session("node_ID") & ""
                If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                    For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                        Me.Label1.Text = dr!fullname.ToString
                    Next
                Else
                    Me.Label1.Text = "INVALID STAFF ID"
                    Exit Sub
                End If
            End If
        Catch ex As Exception

            logger.Info("Manage Customer: ManageCustomer PAGE - ERROR AT txtIntroID_TextChanged '" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")
        End Try
    End Sub
    Protected Sub txtOfficer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOfficer.TextChanged
        Try
            Dim selcust As String = "Select fullname from tbl_userprofile where userid='" & Me.txtOfficer.Text & "' and node_id = " & Session("node_ID") & ""
            If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                    Me.Label2.Text = dr!fullname.ToString
                Next
            Else
                Me.Label2.Text = "INVALID STAFF ID"
                Exit Sub
            End If
        Catch ex As Exception


            logger.Info("Manage Customer: ManageCustomer PAGE - ERROR AT txtOfficer_TextChanged '" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")
        End Try
    End Sub
    Protected Sub txtCompintro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCompintro.TextChanged
        Try
            Me.Label3.Text = ""
            If Me.drpintro2.SelectedValue = "2" Then
                Dim selcust As String = "Select Surname+' '+Firstname+' '+ othername 'name' from tbl_customer where customerid='" & Me.txtCompintro.Text & "' and node_id = " & Session("node_ID") & ""
                If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                    For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                        Me.Label3.Text = dr!name.ToString
                    Next
                Else
                    Me.Label3.Text = "INVALID CUSTOMERID"
                    Exit Sub
                End If
            Else
                Dim selcust As String = "Select fullname from tbl_userprofile where userid='" & Me.txtCompintro.Text & "' and node_id = " & Session("node_ID") & " "
                If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                    For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                        Me.Label3.Text = dr!fullname.ToString
                    Next
                Else
                    Me.Label3.Text = "INVALID STAFF ID"
                    Exit Sub
                End If
            End If
        Catch ex As Exception

            logger.Info("Manage Customer: ManageCustomer PAGE - ERROR AT txtCompintro_TextChanged '" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")
        End Try
    End Sub
    Protected Sub txtCompOffc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCompOffc.TextChanged
        Try
            Dim selcust As String = "Select fullname from tbl_userprofile where userid='" & Me.txtCompOffc.Text & "' and node_id = " & Session("node_ID") & ""
            If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                    Me.Label4.Text = dr!fullname.ToString
                Next
            Else
                Me.Label4.Text = "INVALID STAFF ID"
                Exit Sub
            End If
        Catch ex As Exception
            logger.Info("Manage Customer: ManageCustomer PAGE - ERROR AT txtCompOffc_TextChanged '" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")
        End Try
    End Sub
    Protected Sub DrpcompStateInc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpcompStateInc.SelectedIndexChanged
        Dim Dstring6 As String = "SELECT cast(townCode as varchar) towncode,townname FROM tbl_town where status=1 and towncode='" & Me.DrpcompStateInc.SelectedValue & "'"
        smartobj.loadComboValues("--Select Company Town--- ", Me.DrpCompTown, Dstring6)

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
    '        strSQL = "Update tbl_Customer set customerImage=@content,signatureImage=@content2,Image_Type=@type,Image_Type2=@type where CustomerId=@title"

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
    Sub clear2()

        Me.txtcompRegno.Text = ""
        Me.DrpcompSector.SelectedValue = Nothing
        Me.DrpcompCountry.SelectedValue = Nothing
        Me.DrpcompStateInc.SelectedValue = Nothing
        Me.DrpCompTown.SelectedValue = Nothing
        Me.txtCompaddr.Text = ""
        Me.Txtcomephone1.Text = ""
        Me.Txtcomephone2.Text = ""
        Me.Txtcomephone3.Text = ""
        Me.Txtcomephone4.Text = ""
        Me.txtcompemail.Text = ""
        Me.txtCompintro.Text = ""
        Me.txtCompOffc.Text = ""
        Me.txtCompname.Text = ""
        Me.txtcompDateReg.Text = ""
    End Sub
    Protected Sub ChkGroup_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkGroup.CheckedChanged
        If Me.ChkGroup.Checked = True Then
            Me.DrpGroup.Visible = True
        Else
            Me.DrpGroup.Visible = False

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
    Sub loadlist()
        Dim Dstring7 As String = "SELECT cast(ltrim(rtrim(sectorcode)) as varchar) sectorcode,sectorname FROM tbl_sector where status=1"
        smartobj.loadComboValues("--Select a Sector--- ", Me.DrpcompSector, Dstring7)

        smartobj.loadComboValues("--Select a Sector--- ", Me.Drpsector, Dstring7)

        Dim Dstring1 As String = "SELECT cast(ltrim(rtrim(titlecode)) as varchar) titleid,titlename FROM tbl_title where status=1"
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

        Dim Dstring9 As String = "SELECT cast(ltrim(rtrim(stateCode)) as varchar) statecode,Statename FROM tbl_state where status=1"
        smartobj.loadComboValues("--Select a State--- ", Me.DrpState, Dstring9)

        Dim Dstring10 As String = "SELECT cast(ltrim(rtrim(stateCode)) as varchar) statecode,Statename FROM tbl_state where status=1"
        smartobj.loadComboValues("--Select a State--- ", Me.DrpResState, Dstring10)

        Dim Dstring6 As String = "SELECT cast(ltrim(rtrim(townCode)) as varchar) towncode,townname FROM tbl_town where status=1"
        smartobj.loadComboValues("--Select a Town--- ", Me.DrpTown, Dstring6)

        smartobj.loadComboValues("--Select a Town--- ", Me.DrpCompTown, Dstring6)

        Dim Dstring11 As String = "SELECT cast(ltrim(rtrim(idcardid)) as varchar) idcardid,idcardname FROM tbl_idcard where status=1"
        smartobj.loadComboValues("--Select an ID Type--- ", Me.DrpIdType, Dstring11)
        smartobj.loadComboValues("--Select a State--- ", Me.DrpcompStateInc, Dstring10)

        Dim Dstring26 As String = "SELECT cast(townCode as varchar) towncode,townname FROM tbl_town where status=1"
        smartobj.loadComboValues("--Select Company Town--- ", Me.DrpCompTown, Dstring26)

        Dim Dstring21 As String = "SELECT cast(ltrim(rtrim(GroupID)) as varchar) GroupID,GroupName FROM tbl_group where status=1"
        smartobj.loadComboValues("--Select a Group--- ", Me.DrpGroup, Dstring21)


    End Sub
    Sub search()

        Try
            clear3()
            loadlist()
            Dim sql1 As String = "exec Proc_Custdetail '" & Me.txtCustomerid.Text.Trim & "', " & Session("node_ID") & ""
            'Me.txtCustomerid.ReadOnly = True

            If con.SqlDs(sql1).Tables(0).Rows.Count > 0 Then
                MultiView1.Visible = True
                drx = con.SqlDs(sql1).Tables(0).Rows(0)
                Session("Custtype") = drx.Item("customertype").ToString.Trim

            Else
                MultiView1.Visible = False
                Exit Sub
            End If

            If Session("Custtype") = "1" Then
                MultiView1.ActiveViewIndex = 0
                drx = con.SqlDs(sql1).Tables(0).Rows(0)

                If drx.Item("title").ToString.Trim <> "" Then
                    Me.DrpTitle.SelectedValue = drx.Item("title").ToString.Trim

                End If

                If drx.Item("sector").ToString.Trim <> "" Then
                    Me.Drpsector.SelectedValue = drx.Item("sector").ToString.Trim

                End If
                Me.DrpCustType.SelectedValue = "1"
                Me.txtSurname.Text = drx.Item("surname").ToString.Trim
                Me.txtOthername.Text = drx.Item("othername").ToString.Trim
                Me.txtFirstname.Text = drx.Item("firstname").ToString.Trim
                Me.DrpEdu.SelectedValue = drx.Item("edulevel").ToString.Trim

                Dim dob As String = drx.Item("dob").ToString
                If dob <> Nothing Then
                    If dob = "01/01/1900 12:00:00" Then
                        txtDOB.Text = ""
                    Else
                        Me.txtDOB.Text = Format(CDate(drx.Item("dob").ToString), "dd/MM/yyyy")

                    End If
                End If

                If drx.Item("sex").ToString.Trim <> "" Then
                    Me.DrpSex.SelectedValue = drx.Item("sex").ToString

                End If

                If drx.Item("nationality").ToString.Trim <> "" Then
                    Me.DrpNational.SelectedValue = drx.Item("nationality").ToString

                End If

                If drx.Item("statecode").ToString.Trim <> "" Then
                    Me.DrpState.SelectedValue = drx.Item("statecode").ToString.Trim

                End If
                Me.DrpOccupation.SelectedValue = drx.Item("occupation").ToString.Trim.Trim
                Me.txtAddress.Text = drx.Item("address").ToString.Trim
                Me.txtAddress0.Text = drx.Item("address2").ToString.Trim

                Me.txtsignacct.Text = drx.Item("signacct").ToString.Trim

                If txtsignacct.Text <> "" Then
                    Me.txtsignacct.Visible = True
                    Me.Label8.Visible = True
                    Me.Label7.Visible = True
                    Me.CheckBox2.Checked = True
                Else
                    Me.CheckBox2.Checked = False
                    Me.txtsignacct.Visible = False
                    Me.Label8.Visible = False
                    Me.Label7.Visible = False
                End If

                If drx.Item("residentstatecode").ToString.Trim <> "" Then
                    Me.DrpResState.SelectedValue = drx.Item("residentstatecode").ToString.Trim

                End If

                If drx.Item("residenttowncode").ToString.Trim <> "" Then
                    Me.DrpTown.SelectedValue = drx.Item("residenttowncode").ToString.Trim

                End If
                Me.txtphone1.Text = drx.Item("phone1").ToString.Trim
                Me.Txtphone2.Text = drx.Item("phone2").ToString.Trim
                Me.txtphone3.Text = drx.Item("phone3").ToString.Trim
                Me.Txtphone4.Text = drx.Item("phone4").ToString.Trim
                Me.txtemail.Text = drx.Item("email").ToString.Trim
                Me.txtnextofKin.Text = drx.Item("nextofkin").ToString.Trim
                Me.Txtkinphone.Text = drx.Item("nextofkinphone").ToString.Trim
                Me.txtKinAddress.Text = drx.Item("nextofkinaddr").ToString.Trim
                Me.txtrefname.Text = drx.Item("refname").ToString.Trim
                Me.txtRefphone.Text = drx.Item("refphone").ToString.Trim
                Me.chkStaffType.Checked = drx.Item("stafftype")

                If drx.Item("idtype").ToString.Trim <> "" Then
                    Me.DrpIdType.SelectedValue = drx.Item("idtype").ToString.Trim

                End If

                Dim iss As String = drx.Item("idissuedate").ToString.Trim
                If iss <> Nothing Then
                    If iss = "01/01/1900 12:00:00" Then
                        txtIssue.Text = ""
                    Else
                        Me.txtIssue.Text = Format(CDate(drx.Item("idissuedate").ToString.Trim), "dd/MM/yyyy")
                    End If
                End If
                Me.txtIdNo.Text = drx.Item("idno").ToString.Trim
                Dim exps As String = drx.Item("idexprydate").ToString.Trim
                If exps <> Nothing Then
                    If exps = "01/01/1900 12:00:00" Then
                        Me.txtExpirydate.Text = ""
                    Else
                        Me.txtExpirydate.Text = Format(CDate(drx.Item("idexprydate").ToString.Trim), "dd/MM/yyyy")
                    End If
                End If
                Me.txtOfficer.Text = drx.Item("acctofficer").ToString.Trim
                Dim intro As String = drx.Item("type").ToString.Trim
                Me.DrpIntro.SelectedValue = intro
                Me.chksms.Checked = smartobj.encodeCkeckBox(drx("smsalert"))

                Me.txtIntroID.Text = drx.Item("introducer").ToString.Trim
                Dim dd As String = drx.Item("groupcode").ToString.Trim
                Dim rr As String = drx.Item("relid").ToString.Trim

                If dd <> "" Or dd <> Nothing Then
                    Me.ChkGroup.Checked = True
                    Me.DrpGroup.SelectedValue = dd
                    Me.DrpGroup.Visible = True
                Else
                    Me.ChkGroup.Checked = False
                    Me.DrpGroup.SelectedValue = Nothing
                    Me.DrpGroup.Visible = False

                End If

                If rr <> "" Or rr <> Nothing Then
                    Me.CheckBox1.Checked = True
                    Me.txtcustid.Text = rr
                    Me.txtcustid.Visible = True
                Else
                    Me.CheckBox1.Checked = False
                    Me.txtcustid.Text = ""
                    Me.txtcustid.Visible = False

                End If

                ''Dim selcust As String = "Select Surname+' '+Firstname+' '+ othername 'name' from tbl_customer where customerid='" & intro & "'"
                ''If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                ''    For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                ''        Me.txtIntroID.Text = dr!name.ToString
                ''    Next

                ''    selcust = "Select fullname from tbl_userprofile where userid='" & intro & "'"
                ''    If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                ''        For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                ''            Me.txtIntroID.Text = dr!fullname.ToString
                ''        Next

                ''    End If

                ''End If



            Else
                MultiView1.ActiveViewIndex = 1
                Me.txtCompname.Text = drx.Item("fullname").ToString.Trim
                Me.DrpCustType0.SelectedValue = "2"

                Dim dob As Date = drx.Item("dob").ToString
                If dob <> Nothing Then
                    If dob = "01/01/1900" Then
                        txtcompDateReg.Text = ""
                    Else
                        Me.txtcompDateReg.Text = Format(CDate(drx.Item("dob").ToString), "dd/MM/yyyy")

                    End If
                End If



                If drx.Item("nationality").ToString.Trim <> "" Then
                    Me.DrpcompCountry.SelectedValue = drx.Item("nationality").ToString

                End If

                Me.txtcompRegno.Text = drx.Item("rcno").ToString
                '' Me.txtcontact.Text = drx.Item("contactperson").ToString
                If drx.Item("statecode").ToString.Trim <> "" Then
                    Me.DrpcompStateInc.SelectedValue = drx.Item("statecode").ToString.Trim

                End If
                Me.txtCompaddr.Text = drx.Item("address").ToString.Trim



                If drx.Item("residenttowncode").ToString.Trim <> "" Then
                    Me.DrpCompTown.SelectedValue = drx.Item("residenttowncode").ToString.Trim

                End If
                Me.Txtcomephone1.Text = drx.Item("phone1").ToString.Trim
                Me.Txtcomephone2.Text = drx.Item("phone2").ToString.Trim
                Me.Txtcomephone3.Text = drx.Item("phone3").ToString.Trim
                Me.Txtcomephone4.Text = drx.Item("phone4").ToString.Trim
                Me.txtcompemail.Text = drx.Item("email").ToString.Trim
                Me.txtcontact.Text = drx.Item("contactperson").ToString.Trim

                Me.chksms0.Checked = smartobj.encodeCkeckBox(drx("smsalert"))

                Me.txtCompOffc.Text = drx.Item("acctofficer").ToString.Trim
                Me.txtCompintro.Text = drx.Item("introducer").ToString.Trim
                Dim intro As String = drx.Item("type").ToString.Trim
                Me.drpintro2.SelectedValue = intro

                'Dim selcust As String = "Select Surname+' '+Firstname+' '+ othername 'name' from tbl_customer where customerid='" & intro2 & "'"
                'If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                '    For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                '        Me.txtCompintro.Text = dr!name.ToString
                '    Next

                '    selcust = "Select fullname from tbl_userprofile where userid='" & intro2 & "'"
                '    If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                '        For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                '            Me.txtCompintro.Text = dr!fullname.ToString
                '        Next

                '    End If

                'End If

            End If

        Catch ex As Exception

            logger.Info("Manage Customer: ManageCustomer PAGE - ERROR AT search() '" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")


        End Try
    End Sub
    Protected Sub txtCustomerid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustomerid.TextChanged
        Try
            search()

        Catch ex As Exception

            logger.Info("Manage Customer: ManageCustomer PAGE - ERROR AT txtCustomerid_TextChanged'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")
        End Try

    End Sub
    'Function FormatURL2(ByVal strArgument As String) As String
    '    Return ("getimg2.aspx?id=" & strArgument)
    'End Function
    'Function FormatURL(ByVal strArgument As String) As String
    '    Return ("getimg.aspx?id=" & strArgument)
    'End Function
#End Region



    Protected Sub txtsignacct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsignacct.TextChanged
        Try
            Label8.Text = ""
            Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtsignacct.Text.Trim & "',@retval output,@retmsg output," & Session("node_ID") & " select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            If retval = "0" Then
                Me.txtsignacct.Text = retmsg
            End If

            Dim selExist As String = "Exec Proc_CustAcctDetail '" & Me.txtsignacct.Text.Trim & "', " & Session("node_ID") & ""
            If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then
                drx = con.SqlDs(selExist).Tables(0).Rows(0)
                Me.Label8.Text = drx.Item("accounttitle").ToString
            End If


        Catch ex As Exception

            logger.Info("Manage Customer: ManageCustomer PAGE - ERROR AT txtsignacct_TextChanged '" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")

            PrimeApp.ShowToastr(Page, "Data Warning error...", "Error!", "Danger", False, "toast-top-right", False)


        End Try
    End Sub

    'Protected Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
    '    If Session("node_ID") = Nothing Then
    '        Response.Redirect("../PageExpire.aspx")
    '    Else
    '        Me.MasterPageFile = "~/Tenant" + Session("node_ID").ToString + "/Tenant.master"

    '    End If
    'End Sub
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
        Me.Drpsector.SelectedValue = Nothing
        Me.txtphone1.Text = ""
        Me.Txtphone2.Text = ""
        Me.txtphone3.Text = ""
        Me.Txtphone4.Text = ""
        Me.txtemail.Text = ""
        Me.txtnextofKin.Text = ""
        Me.Txtkinphone.Text = ""
        Me.txtKinAddress.Text = ""
        Me.DrpIdType.SelectedValue = Nothing
        Me.txtIntroID.Text = ""
        Me.DrpGroup.SelectedValue = Nothing
        Me.txtOfficer.Text = ""
        Me.Btnsubmit.Enabled = True
        Me.ChkGroup.Checked = False
        Me.chksms.Checked = False
        Me.chksms2.Checked = False
        Me.txtCustomerid.Text = ""
        '' Me.txtCustomerId.Visible = False
        ''  Me.RadioBut_CustomerType.SelectedValue = "No"
        Me.txtDOB.Text = ""
        Me.txtIssue.Text = ""
        Me.txtExpirydate.Text = ""
        Me.txtrefname.Text = ""
        Me.txtRefphone.Text = ""
    End Sub
    Protected Sub But_Reset_Click(sender As Object, e As EventArgs) Handles But_Reset.Click
        clear()
    End Sub
    Sub clear3()
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
        Me.Drpsector.SelectedValue = Nothing
        Me.txtphone1.Text = ""
        Me.Txtphone2.Text = ""
        Me.txtphone3.Text = ""
        Me.Txtphone4.Text = ""
        Me.txtemail.Text = ""
        Me.txtnextofKin.Text = ""
        Me.Txtkinphone.Text = ""
        Me.txtKinAddress.Text = ""
        Me.DrpIdType.SelectedValue = Nothing
        Me.txtIntroID.Text = ""
        Me.DrpGroup.SelectedValue = Nothing
        Me.txtOfficer.Text = ""
        Me.Btnsubmit.Enabled = True
        Me.ChkGroup.Checked = False
        Me.chksms.Checked = False
        Me.chksms2.Checked = False
        ' Me.txtCustomerId.Text = ""
        ' Me.txtCustomerId.Visible = False
        ''  Me.RadioBut_CustomerType.SelectedValue = "No"
        Me.txtDOB.Text = ""
        Me.txtIssue.Text = ""
        Me.txtExpirydate.Text = ""
        Me.txtrefname.Text = ""
        Me.txtRefphone.Text = ""
    End Sub
End Class
