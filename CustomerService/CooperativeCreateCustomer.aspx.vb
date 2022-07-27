Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Partial Class CustomerService_CooperativeCreateCustomer
    Inherits SessionCheck
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
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
#Region "Pageload"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = "CUSTOMER SERVICE"
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim

        HypSearch1.NavigateUrl = "javascript:staff('document.aspnetForm." + txtOfficer.ClientID.ToString() + "');"

        'Me.Hypsearch.NavigateUrl = "javascript:customer('document.aspnetForm." + txtCustomerid.ClientID.ToString() + "');"
        imgdate1.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtDOB.ClientID.ToString() + "');"
        imgdate3.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtExpirydate.ClientID.ToString() + "');"
        imgdate2.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtIssue.ClientID.ToString() + "');"

        If Page.IsPostBack = False Then

            Try



                Dim Dstring7 As String = "SELECT cast(ltrim(rtrim(sectorcode)) as varchar) sectorcode,sectorname FROM tbl_sector where status=1"

                smartobj.loadComboValues("--Select a Sector--- ", Me.Drpsector, Dstring7)

                Dim Dstring1 As String = "SELECT cast(ltrim(rtrim(titlecode)) as varchar) titleid,titlename FROM tbl_title where status=1"
                smartobj.loadComboValues("--Select a Title--- ", Me.DrpTitle, Dstring1)

                Dim Dstring2 As String = "SELECT cast(ltrim(rtrim(sexcode)) as varchar) sexid,sexname FROM tbl_sex where status=1"
                smartobj.loadComboValues("--Select a Gender--- ", Me.DrpSex, Dstring2)

                Dim Dstring3 As String = "SELECT cast(ltrim(rtrim(profcode)) as varchar) prof_id,profname FROM tbl_profession where status=1"
                smartobj.loadComboValues("--Select an Occupation--- ", Me.DrpOccupation, Dstring3)

                Dim Dstring4 As String = "SELECT cast(ltrim(rtrim(Countrycode)) as varchar) Country_id,Countryname FROM tbl_Country where status=1"
                smartobj.loadComboValues("--Select a Country--- ", Me.DrpNational, Dstring4)

                Dim Dstring5 As String = "SELECT cast(ltrim(rtrim(EducationCode)) as varchar) EducationCode,Educationname FROM tbl_Education where status=1"
                smartobj.loadComboValues("--Select Education Level--- ", Me.DrpEdu, Dstring5)

                Dim Dstring9 As String = "SELECT cast(ltrim(rtrim(stateCode)) as varchar) statecode,Statename FROM tbl_state where status=1"
                smartobj.loadComboValues("--Select a State--- ", Me.DrpState, Dstring9)

                Dim Dstring10 As String = "SELECT cast(ltrim(rtrim(stateCode)) as varchar) statecode,Statename FROM tbl_state where status=1"
                smartobj.loadComboValues("--Select a State--- ", Me.DrpResState, Dstring10)

                Dim Dstring6 As String = "SELECT cast(ltrim(rtrim(townCode)) as varchar) towncode,townname FROM tbl_town where status=1"
                smartobj.loadComboValues("--Select a Town--- ", Me.DrpTown, Dstring6)


                Dim Dstring11 As String = "SELECT cast(ltrim(rtrim(idcardid)) as varchar) idcardid,idcardname FROM tbl_idcard where status=1"
                smartobj.loadComboValues("--Select an ID Type--- ", Me.DrpIdType, Dstring11)

                Dim Dstring21 As String = "SELECT cast(ltrim(rtrim(GroupID)) as varchar) GroupID,GroupName FROM tbl_group where status=1"
                smartobj.loadComboValues("--Select a Group--- ", Me.DrpGroup, Dstring21)


                Me.Btnsubmit.Text = "Submit"

            Catch ex As Exception
                smartobj.alertwindow(Me.Page, "Data Warnning error...", "Prime")

            End Try
            search()
        End If
        'search()
    End Sub
#End Region
    Protected Sub BtnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSubmit.Click
        Try
            Dim istate As Integer = 0
            retmsg = ""

            Dim globaldate As Date = Now.Date

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

            If Me.DrpTitle.SelectedValue = "0" Then
                smartobj.alertwindow(Me.Page, "Choose a Title", "Prime")
                Exit Sub

            End If
            If Me.txtDOB.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Date Of Birth", "Prime")
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

            'Individual
            qry = " declare @retmsg varchar(100),@retVal int " & vbNewLine
            qry = qry & "execute Proc_CooperativeInsCustomer "
            qry = qry & smartobj.EncoteWithSingleQuote(Me.LblEmployeeNo.Text.Trim) & ","
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
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtPhone1.Text.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtPhone2.Text.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtphone3.Text.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtPhone4.Text.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtemail.Text.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtnextofKin.Text.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtKinphone.Text.Trim) & ","
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
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtrefphone.Text.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtOfficer.Text.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtsignacct.Text.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(smartobj.DecodeCkeckBox(Me.chksms)) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(smartobj.DecodeCkeckBox(Me.chksms)) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Session("Userid").Trim) & ",NULL,@retVal OUTPUT,@retmsg OUTPUT "
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
            Me.BtnSubmit.Enabled = False

            clear()






        Catch ex As Exception

            smartobj.alertwindow(Me.Page, retmsg, "Prime")

        End Try
    End Sub
    Protected Sub Btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        smartobj.ClearWebPage(Me.Page)
        clear()
        Response.Redirect("~/CustomerService/CoopCustomerReq.aspx")
        Me.BtnSubmit.Enabled = True
    End Sub
    Sub clear()
        Me.DrpTitle.SelectedValue = Nothing
        Me.txtSurname.Text = ""
        Me.txtOthername.Text = ""
        Me.txtFirstname.Text = ""
        Me.txtDOB.Text = ""
        Me.DrpSex.SelectedValue = Nothing
        Me.DrpNational.SelectedValue = Nothing
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
        Me.DrpIdType.SelectedValue = Nothing
        Me.txtIssue.Text = ""
        Me.txtExpirydate.Text = ""
        Me.txtOfficer.Text = ""
        Me.txtIntroID.Text = ""
    End Sub
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
        Try
            Me.Label1.Text = ""
            If Me.DrpIntro.SelectedValue = "2" Then
                Dim selcust As String = "Select Surname+' '+Firstname+' '+ othername 'name' from tbl_customer where customerid='" & Me.txtIntroID.Text & "'"
                If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                    For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                        Me.Label1.Text = dr!name.ToString
                    Next
                Else
                    Me.Label1.Text = "INVALID CUSTOMERID"
                    Exit Sub
                End If
            Else
                Dim selcust As String = "Exec proc proc_Officers '" & Me.txtIntroID.Text & "'"
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

        End Try
    End Sub
    Protected Sub txtOfficer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOfficer.TextChanged
        Try
            Dim selcust As String = "Select fullname from tbl_userprofile where userid='" & Me.txtOfficer.Text & "'"
            If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                    Me.Label2.Text = dr!fullname.ToString
                Next
            Else
                Me.Label2.Text = "INVALID STAFF ID"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
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

        smartobj.loadComboValues("--Select a Sector--- ", Me.Drpsector, Dstring7)

        Dim Dstring1 As String = "SELECT cast(ltrim(rtrim(titlecode)) as varchar) titleid,titlename FROM tbl_title where status=1"
        smartobj.loadComboValues("--Select a Title--- ", Me.DrpTitle, Dstring1)

        Dim Dstring2 As String = "SELECT cast(ltrim(rtrim(sexcode)) as varchar) sexid,sexname FROM tbl_sex where status=1"
        smartobj.loadComboValues("--Select a Gender--- ", Me.DrpSex, Dstring2)

        Dim Dstring3 As String = "SELECT cast(ltrim(rtrim(profcode)) as varchar) prof_id,profname FROM tbl_profession where status=1"
        smartobj.loadComboValues("--Select an Occupation--- ", Me.DrpOccupation, Dstring3)

        Dim Dstring4 As String = "SELECT cast(ltrim(rtrim(Countrycode)) as varchar) Country_id,Countryname FROM tbl_Country where status=1"
        smartobj.loadComboValues("--Select a Country--- ", Me.DrpNational, Dstring4)


        Dim Dstring5 As String = "SELECT cast(ltrim(rtrim(EducationCode)) as varchar) EducationCode,Educationname FROM tbl_Education where status=1"
        smartobj.loadComboValues("--Select Education Level--- ", Me.DrpEdu, Dstring5)

        Dim Dstring9 As String = "SELECT cast(ltrim(rtrim(stateCode)) as varchar) statecode,Statename FROM tbl_state where status=1"
        smartobj.loadComboValues("--Select a State--- ", Me.DrpState, Dstring9)

        Dim Dstring10 As String = "SELECT cast(ltrim(rtrim(stateCode)) as varchar) statecode,Statename FROM tbl_state where status=1"
        smartobj.loadComboValues("--Select a State--- ", Me.DrpResState, Dstring10)

        Dim Dstring6 As String = "SELECT cast(ltrim(rtrim(townCode)) as varchar) towncode,townname FROM tbl_town where status=1"
        smartobj.loadComboValues("--Select a Town--- ", Me.DrpTown, Dstring6)

        
        Dim Dstring21 As String = "SELECT cast(ltrim(rtrim(GroupID)) as varchar) GroupID,GroupName FROM tbl_group where status=1"
        smartobj.loadComboValues("--Select a Group--- ", Me.DrpGroup, Dstring21)


    End Sub
    Sub search()
        LblEmployeeNo.Text = Request.QueryString("ID")
        Try
            loadlist()
            Dim sql1 As String = "exec Proc_CooperativeCustdetail '" & Request.QueryString("ID") & "'"
            'Me.txtCustomerid.ReadOnly = True

            If con.SqlDs(sql1).Tables(0).Rows.Count > 0 Then
                drx = con.SqlDs(sql1).Tables(0).Rows(0)
                Session("Custtype") = drx.Item("customertype").ToString.Trim

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
                Me.txtPhone1.Text = drx.Item("phone1").ToString.Trim
                Me.txtPhone2.Text = drx.Item("phone2").ToString.Trim
                Me.txtphone3.Text = drx.Item("phone3").ToString.Trim
                Me.txtPhone4.Text = drx.Item("phone4").ToString.Trim
                Me.txtemail.Text = drx.Item("email").ToString.Trim
                Me.txtnextofKin.Text = drx.Item("nextofkin").ToString.Trim
                Me.txtKinphone.Text = drx.Item("nextofkinphone").ToString.Trim
                Me.txtKinAddress.Text = drx.Item("nextofkinaddr").ToString.Trim
                Me.txtrefname.Text = drx.Item("refname").ToString.Trim
                Me.txtrefphone.Text = drx.Item("refphone").ToString.Trim


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


            Else


            End If

        Catch ex As Exception

        End Try
    End Sub
End Class
