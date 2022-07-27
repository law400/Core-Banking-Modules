Imports Toastr
Partial Class CustomerService_Test2
    Inherits SessionCheck
    Private qry As String, qryval As String = "", retval As Integer, retmsg As String = ""
    Public Enum MessageType
        Success
        [Error]
        Info
        Warning
    End Enum
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


        ' ''Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        ' ''l.Text = "CUSTOMER SERVICE"
        ''   Me.hypsearch.NavigateUrl = "javascript:customer2('document.aspnetForm." + txtnone.ClientID.ToString() + "');"
        '  HypSearch0.NavigateUrl = "javascript:staff('document.aspnetForm." + txtofficer.ClientID.ToString() + "');"
        '   HypSearch1.NavigateUrl = "javascript:staff('document.aspnetForm." + txtCompOffc.ClientID.ToString() + "');"

        Dim l As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("Label3"), System.Web.UI.WebControls.Label)
        l.Text = ""
        Dim ll As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("Label4"), System.Web.UI.WebControls.Label)
        ll.Text = "MEMBER CREATION" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim

        Dim menuname As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("lbldisplay"), System.Web.UI.WebControls.Label)
        menuname.Text = Request.QueryString("XXX")
        'If menuname.Text = "" Then
        '    Response.Redirect("~/Unauthorize.aspx")
        'End If

        'If Validate_Access(menuname.Text) = 0 Then
        '    Response.Redirect("~/Unauthorize.aspx")
        'End If

        Dim rpt As Repeater = CType(Master.FindControl("rptMenu"), Repeater)

        For Each ri As RepeaterItem In rpt.Items
            'If ri.ItemType = ListItemType.Item OrElse ri.ItemType = ListItemType.AlternatingItem Then
            '   For each li As HtmlGenericControl In 

            Dim span As HtmlGenericControl = TryCast(ri.FindControl("spanid"), HtmlGenericControl)
            If span.InnerHtml = Request.QueryString("YYY") Then
                Dim li As HtmlGenericControl = TryCast(ri.FindControl("parentli"), HtmlGenericControl)
                li.Attributes.Add("class", "parent active")
            End If
            'do something with the checkbox
            ' End If
        Next

        If Page.IsPostBack = False Then

            Me.MultiView1.ActiveViewIndex = 0
            Try

                'imgdate1.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtDOB.ClientID.ToString() + "');"
                'imgdate3.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtExpirydate.ClientID.ToString() + "');"
                'imgdate2.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtIssue.ClientID.ToString() + "');"
                '   HyperLink1.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtcompDateReg.ClientID.ToString() + "');"



                '    smartobj.loadComboValues("--Select a Sector--- ", Me.Drpsector, Dstring7)

                'Dim Dstring1 As String = "SELECT cast(ltrim(rtrim(titlecode)) as varchar) titleid,titlename FROM tbl_title where status=1 and titlecode<>3"
                'smartobj.loadComboValues("--Select a Title--- ", Me.DrpTitle, Dstring1)

                'Dim Dstring2 As String = "SELECT cast(ltrim(rtrim(sexcode)) as varchar) sexid,sexname FROM tbl_sex where status=1"
                'smartobj.loadComboValues("--Select a Gender--- ", Me.DrpSex, Dstring2)






                ''  Me.Btnsubmit.Text = "Submit"

            Catch ex As Exception
                '  smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")
                PrimeApp.ShowToastr(Page, "Data Warning error...", "Error!", "Danger", False, "toast-top-right", False)


            End Try
        End If
    End Sub
    Protected Sub ShowMessage(Message As String, title As String, type As MessageType, position As ToastPosition)
        ' ScriptManager.RegisterStartupScript(Me, Me.[GetType](), System.Guid.NewGuid().ToString(), "ShowMessage('" & Message & "','" & type.ToString() & "');", True)
        Toastr.ShowToast(Me, type, Message, title, position, True)
    End Sub

    Protected Sub btnSuccess_Click(sender As Object, e As EventArgs) Handles btnSuccess.Click
        ''  ShowMessage("Record submitted successfully", "Yessss!", ToastType.Success, ToastPosition.TopRight)
        smartobj.ShowToast(Me.Page, ToastType.Success, "Record submitted successfully", "Yessss!", ToastPosition.TopRight, True)
        DrpTitle.Focus()
    End Sub

    Protected Sub btnDanger_Click(sender As Object, e As EventArgs) Handles btnDanger.Click
        ShowMessage("A problem has occurred while submitting data", "Error", ToastType.Error, ToastPosition.TopStretch)
    End Sub

    Protected Sub btnWarning_Click(sender As Object, e As EventArgs) Handles btnWarning.Click
        ShowMessage("There was a problem with your internet connection", "Info", ToastType.Warning, ToastPosition.TopCenter)
    End Sub

    Protected Sub btnInfo_Click(sender As Object, e As EventArgs) Handles btnInfo.Click
        ShowMessage("Please verify your data before submitting", "Info", ToastType.Info, ToastPosition.TopLeft)
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        smartobj.ShowToast(Me.Page, ToastType.Success, "Record submitted successfully", "Yessss!", ToastPosition.TopRight, True)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        smartobj.ShowToast(Me.Page, ToastType.Success, "Record submitted successfully", "Yessss!", ToastPosition.TopRight, True)

    End Sub

    Protected Sub BtnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsubmit.Click
        Try
            Dim istate As Integer = 0
            retmsg = ""

            Dim globaldate As Date = Now.Date


            If Me.RdBCustType.SelectedValue = "1" Then
                If Me.DrpTitle.SelectedValue = "0" Then


                    smartobj.ShowToast(Me.Page, ToastType.Error, "Pls Enter Address", "Oops!", ToastPosition.TopRight, True)
                    DrpTitle.Focus()
                    Exit Sub

                End If
                If Me.txtSurname.Text = "" Then
                    '  smartobj.alertwindow(Me.Page, "Please Enter Surname", "Prime")

                    PrimeApp.ShowToastr(Page, "Please Enter Surname", "Oops!", "Warning", False, "toast-top-right", False)

                    txtSurname.Focus()
                    Exit Sub

                End If
                If Me.txtFirstname.Text = "" Then
                    '  smartobj.alertwindow(Me.Page, "Please Enter First Name", "Prime")

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
                    'smartobj.alertwindow(Me.Page, "Choose a Gender", "Prime")

                    PrimeApp.ShowToastr(Page, "Choose a Gender", "Oops!", "Warning", False, "toast-top-right", False)

                    DrpSex.Focus()
                    Exit Sub

                End If
                If Me.DrpNational.SelectedIndex = 0 Then
                    '  smartobj.alertwindow(Me.Page, "Choose a Nationality", "Prime")

                    PrimeApp.ShowToastr(Page, "Choose a Nationality", "Oops!", "Warning", False, "toast-top-right", False)


                    DrpNational.Focus()
                    Exit Sub

                End If
                If Me.DrpState.SelectedIndex = 0 Then
                    ''  smartobj.alertwindow(Me.Page, "Choose a State of Origin", "Prime")

                    PrimeApp.ShowToastr(Page, "Choose a State of Origin", "Oops!", "Warning", False, "toast-top-right", False)

                    DrpState.Focus()
                    Exit Sub
                End If
                If Me.txtAddress.Text = "" Then
                    ''  smartobj.alertwindow(Me.Page, "Enter Residential Address", "Prime")

                    PrimeApp.ShowToastr(Page, "Enter Residential Address", "Oops!", "Warning", False, "toast-top-right", False)


                    txtAddress.Focus()
                    Exit Sub

                End If
                If Me.DrpResState.SelectedIndex = 0 Then
                    '' smartobj.alertwindow(Me.Page, "Choose a Residential State", "Prime")

                    PrimeApp.ShowToastr(Page, "Choose a Residential State", "Oops!", "Warning", False, "toast-top-right", False)


                    DrpResState.Focus()
                    Exit Sub
                End If
                If Me.DrpTown.SelectedIndex = 0 Then
                    '' smartobj.alertwindow(Me.Page, "Choose a Residential Town", "Prime")

                    PrimeApp.ShowToastr(Page, "Choose a Residential Town", "Oops!", "Warning", False, "toast-top-right", False)


                    DrpTown.Focus()
                    Exit Sub
                End If

                If Me.txtphone1.Text = "" Then
                    ''   smartobj.alertwindow(Me.Page, "Enter Mobile Phone 1", "Prime")

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
                    ''   smartobj.alertwindow(Me.Page, "Enter ID Issue Date", "Prime")

                    PrimeApp.ShowToastr(Page, "Enter ID Issue Date", "Oops!", "Warning", False, "toast-top-right", False)


                    txtIssue.Focus()
                    Exit Sub
                End If
                If Me.txtExpirydate.Text = "" Then
                    ''  smartobj.alertwindow(Me.Page, "Enter ID Expiry Date", "Prime")


                    PrimeApp.ShowToastr(Page, "Enter ID Expiry Date", "Oops!", "Warning", False, "toast-top-right", False)

                    txtExpirydate.Focus()
                    Exit Sub
                End If

                If DrpIdType.SelectedValue <> 0 Then
                    If Me.txtExpirydate.Text = "" Then
                        '' smartobj.alertwindow(Me.Page, "Enter ID expiry Date", "Prime")

                        PrimeApp.ShowToastr(Page, "Enter ID Expiry Date", "Oops!", "Warning", False, "toast-top-right", False)

                        DrpIdType.Focus()
                        Exit Sub

                    End If
                    If Me.txtIssue.Text = "" Then

                        ''    smartobj.alertwindow(Me.Page, "Enter Issue Date", "Prime")



                        PrimeApp.ShowToastr(Page, "Enter Issue Date", "Oops!", "Warning", False, "toast-top-right", False)

                        txtIssue.Focus()
                        Exit Sub

                    End If
                End If

                'If Me.txtIntroID.Text = "" Then
                '    smartobj.alertwindow(Me.Page, "Enter Introducer ID", "Prime")
                '    Exit Sub

                'End If

                If Me.Drpsector.SelectedValue = "0" Then
                    '     smartobj.alertwindow(Me.Page, "Choose a Sector", "Prime")

                    PrimeApp.ShowToastr(Page, "Choose a Sector", "Oops!", "Warning", False, "toast-top-right", False)


                    Drpsector.Focus()
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
                    ''   smartobj.alertwindow(Me.Page, "Expiry date cannot be before issue date", "Error")

                    PrimeApp.ShowToastr(Page, "Expiry date cannot be before issue date", "Oops!", "Warning", False, "toast-top-right", False)


                    Me.txtExpirydate.Focus()
                    Exit Sub
                End If

                If CDate(Me.txtExpirydate.Text) < CDate(Profile.sysdate) Then
                    '   smartobj.alertwindow(Me.Page, "Expiry date is Invalid", "Error")

                    PrimeApp.ShowToastr(Page, "Expiry date is Invalid", "Oops!", "Warning", False, "toast-top-right", False)


                    Me.txtExpirydate.Focus()
                    Exit Sub
                End If

                Dim overline As String = ""
                Dim overlineid As String = ""

                If Profile.overide = "1" Then
                    If Profile.valid <> "0" Then
                        '' smartobj.alertwindow(Me.Page, "Data Posted Was Not Override.Please Re-Post Data", "Prime")

                        PrimeApp.ShowToastr(Page, "Data Posted Was Not Override.Please Re-Post Data", "Oops!", "Warning", False, "toast-top-right", False)


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


                If Me.txtCustomerId.Text = "" Then
                    If Me.RadioBut_CustomerType.SelectedValue = "Yes" Then

                        'smartobj.alertwindow(Me.Page, "Please enter a custom member id", "Prime")

                        PrimeApp.ShowToastr(Page, "Please enter a custom member id", "Oops!", "Warning", False, "toast-top-right", False)



                        Me.txtCustomerId.Focus()
                        Exit Sub
                    End If
                End If
                'Individual
                qry = " declare @retmsg varchar(100),@retVal int " & vbNewLine
                qry = qry & "execute Proc_InsCustomer "
                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpTitle.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtSurname.Text.Trim.Replace("'", "")) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtCustomerId.Text.Trim.Replace("'", "")) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.RadioBut_CustomerType.SelectedValue) & ","
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
                qry = qry & smartobj.EncoteWithSingleQuote(Me.DrpRela.SelectedValue.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtIntroID.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtrefname.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtRefphone.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtOfficer.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtsignacct.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(smartobj.DecodeCkeckBox(Me.chksms)) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(smartobj.DecodeCkeckBox(Me.chksms2)) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(smartobj.DecodeCkeckBox(Me.chkStaffType)) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Profile.Userid.Trim) & ",NULL,@retVal OUTPUT,@retmsg OUTPUT," & Profile.node_ID & " "
                qry = qry & " select @retVal,@retmsg"


                For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                    retval = dr(0).ToString
                    retmsg = dr(1).ToString

                Next

                If retval = "0" Then
                    '  smartobj.alertwindow(Me.Page, retmsg, "Prime")


                    PrimeApp.ShowToastr(Page, retmsg, "Yessss!", "Success", False, "toast-top-right", False)


                    ' uploadimage()
                Else
                    ' Me.Btnsubmit.Enabled = True
                    '  smartobj.alertwindow(Me.Page, retmsg, "Prime")

                    ''  PrimeApp.ShowToastr(Page, retmsg, "Error!", "Danger", False, "toast-top-right", False)


                End If
                Me.Btnsubmit.Enabled = False



            End If




        Catch ex As Exception

            '' smartobj.alertwindow(Me.Page, ex.Message, "Prime")

            PrimeApp.ShowToastr(Page, "Error Occurred", "Error!", "Danger", False, "toast-top-right", False)


        End Try
    End Sub
End Class
