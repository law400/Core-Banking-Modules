Imports log4net
Imports log4net.Config
Partial Class Admin_AddUser
    Inherits SessionCheck2
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(Admin_AddUser))

#Region "Declaration"
    Private Structure vardeclare
        Dim staffid As String
        Dim staffname As String
        Dim Branch As String
        Dim department As String
        Dim phoneno As String
        Dim email As String
        Dim userfunction As String
        Dim staffstatus As String
        Dim loginstatus As String
        Dim reportlevel As String
        Dim postacctno As String
        Dim authstatus As String
        Dim statement As String

        Dim newfunction As String
        Dim password As String

    End Structure
    Private decl As New vardeclare
    Dim qryval As String = ""

#End Region
#Region "Pageload"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim l As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("Label3"), System.Web.UI.WebControls.Label)
        'l.Text = ""
        'Dim ll As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("Label4"), System.Web.UI.WebControls.Label)
        'll.Text = "MANAGE USERS" & Request.QueryString("menu")
        'Page.Header.Title = ll.Text.Trim

        Session("RadWindowCode") = ""
        If Page.IsPostBack = False Then

            ''checkusers()

            retmsg = ""
            Try
                shownew()

                Dim Dstring1 As String = "SELECT cast(ltrim(rtrim(branchcode)) as varchar) branchcode,branchname FROM tbl_branch where status=1 and node_id = " & Session("node_ID") & ""
                smartobj.loadComboValues("--Select a Branch--- ", Me.DrpBranch, Dstring1)

                Dim Dstring2 As String = "SELECT cast(ltrim(rtrim(deptid)) as varchar) deptid,deptname FROM tbl_department where status=1"
                smartobj.loadComboValues("--Select a Department--- ", Me.DrpDept, Dstring2)

                Dim Dstring3 As String = "SELECT cast(ltrim(rtrim(role_id)) as varchar) role_id,role_name FROM tbl_role where node_id  = " & Session("node_ID") & ""
                smartobj.loadComboValues("--Select a Function--- ", Me.DrpFunction1, Dstring3)

                Dim Dstring4 As String = "SELECT cast(ltrim(rtrim(sbucode)) as varchar) sbucode,sbuname FROM tbl_SBU where status=1 and node_id = " & Session("node_ID") & ""
                'smartobj.loadComboValues("--Select a SBU--- ", Me.DrpSBU, Dstring4)

                Dim Dstring5 As String = "SELECT cast(ltrim(rtrim(statusCode)) as varchar) statuscode,StatusDesc FROM tbl_userstatus"
                smartobj.loadComboValues("--Select Status--- ", Me.DrpStatus1, Dstring5)
                'Dim Dstring6 As String = "SELECT cast(ltrim(rtrim(statusCode)) as varchar) statuscode,StatusDesc FROM tbl_loginstatus"
                'smartobj.loadComboValues("--Select Status--- ", Me.DrpStatus2, Dstring6)
                ''Menu1.SelectedItem.Text = "Add New"
                Me.BtnSubmit.Text = "Submit"

            Catch ex As Exception
                logger.Info("USER: BANK PAGE - ERROR AT PAGE LOAD '" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")
                smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")

            End Try
        End If
    End Sub

    ''Sub checkusers()
    ''    Dim access As String = "exec proc_Usercount"
    ''    If con.SqlDs(access).Tables(0).Rows.Count > 0 Then
    ''        Me.BtnSubmit.Enabled = True

    ''        Dim i As Integer = con.SqlDs(access).Tables(0).Rows(0).Item(0).ToString

    ''        Dim sel As String = "select isnull(count(userid),0) from tbl_userprofile"
    ''        If con.SqlDs(sel).Tables(0).Rows(0).Item(0).ToString > con.SqlDs(access).Tables(0).Rows(0).Item(0).ToString Then
    ''            Me.BtnSubmit.Enabled = False
    ''            smartobj.alertwindow(Me.Page, "Application User Limit Exceeded. Pls Contact Software Vendor.", "Prime")
    ''            Exit Sub
    ''        End If
    ''    Else
    ''        Me.BtnSubmit.Enabled = False
    ''        smartobj.alertwindow(Me.Page, "Application Not Registered. Pls Contact Software Vendor.", "Prime")
    ''        Exit Sub

    ''    End If

    ''End Sub
#End Region
#Region "Task"


    Sub shownew()
        Me.BtnSubmit.Text = "Submit"
        Me.Label7.Visible = True
        Me.Label8.Visible = True
        Me.txtNewPassword.Visible = True
        Me.txtPassword.Visible = True
        Me.txttillaccno.Visible = False
    End Sub

    Sub showedit()
        Me.BtnSubmit.Text = "Update"
        smartobj.ClearWebPage(Me.Page)
        'Me.MultiView1.Visible = False
        BtnSubmit.Enabled = True
        Me.Label7.Visible = False
        Me.Label8.Visible = False
        Me.txtNewPassword.Visible = False
        Me.txtPassword.Visible = False

    End Sub

    Protected Sub BtnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSubmit.Click
        Try
            If Me.txtStaffid.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Staff ID", "Prime")
                txtStaffid.Focus()
                Exit Sub
            End If

            If Me.txtStaffName.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Staff Name", "Prime")
                txtStaffName.Focus()
                Exit Sub
            End If
            If Me.DrpBranch.SelectedIndex = 0 Then
                smartobj.alertwindow(Me.Page, "Please select Branch", "Prime")
                DrpBranch.Focus()
                Exit Sub
            End If
            If Me.DrpDept.SelectedIndex = 0 Then
                smartobj.alertwindow(Me.Page, "Please select Department", "Prime")
                DrpDept.Focus()
                Exit Sub
            End If
            If Me.DrpFunction1.SelectedIndex = 0 Then
                smartobj.alertwindow(Me.Page, "Please select Role", "Prime")
                DrpFunction1.Focus()
                Exit Sub
            End If
            If Me.DrpStatus1.SelectedIndex = 0 Then
                smartobj.alertwindow(Me.Page, "Please select staff status", "Prime")
                DrpStatus1.Focus()
                Exit Sub
            End If
            If Me.txtPhone.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Staff Phone No", "Prime")
                txtPhone.Focus()
                Exit Sub
            End If

            If Me.DrpBranch.SelectedValue.Length > 10 Then
                smartobj.alertwindow(Me.Page, "Please Select a Branch", "Prime")
                DrpBranch.Focus()
                Exit Sub
            End If

            If Me.DrpFunction1.SelectedValue.Length > 10 Then
                smartobj.alertwindow(Me.Page, "Please Select a User Role", "Prime")
                DrpFunction1.Focus()
                Exit Sub
            End If

            If Me.DrpDept.SelectedValue.Length > 10 Then
                smartobj.alertwindow(Me.Page, "Please Select a User Department", "Prime")
                DrpDept.Focus()
                Exit Sub
            End If
            'If Me.DrpReport.SelectedValue.Length > 10 Then
            '    Me.DrpReport.SelectedValue = Me.txtStaffid.Text.Trim

            'End If

            Dim istate As Integer = 0
            Dim istate2 As Integer = 0

            If Me.ChkAuth.Checked = True Then
                istate = 1
            Else
                istate = 0
            End If


            istate2 = 1

            istate2 = 0


            ''If Me.txttillaccno.Visible = True Then

            ''    If Me.txttillaccno.Text = "" Then
            ''        smartobj.alertwindow(Me.Page, "Please Enter a Till Account Number", "Prime")
            ''        Me.BtnSubmit.Enabled = False
            ''        Exit Sub
            ''    End If
            ''Else
            ''    Me.BtnSubmit.Enabled = True
            ''End If


            If Me.txtPassword.Text.Trim <> Me.txtNewPassword.Text.Trim Then
                smartobj.alertwindow(Me.Page, "Password Not Matched", "Prime")
                txtNewPassword.Focus()
                Exit Sub
            End If

            decl.staffstatus = Me.DrpStatus1.SelectedValue
            decl.Branch = Me.DrpBranch.SelectedValue
            decl.department = Me.DrpDept.SelectedValue
            decl.email = Me.txtemail.Text.Trim
            decl.userfunction = Me.DrpFunction1.SelectedValue
            decl.phoneno = Me.txtPhone.Text.Trim
            decl.reportlevel = Me.DrpReport.SelectedValue
            decl.staffid = Me.txtStaffid.Text.Trim
            decl.staffname = Me.txtStaffName.Text.Trim.Replace("'", "")
            decl.authstatus = istate
            decl.statement = istate2

            If Me.BtnSubmit.Text = "Submit" Then

                If txtPassword.Text = "" Then
                    smartobj.alertwindow(Me.Page, "Enter Password", "Prime")
                    txtPassword.Focus()
                    Exit Sub
                End If
                Dim contlen, pwd As Integer
                Dim passlen As String = "select passlen from tbl_bank where node_id = " & Session("node_ID") & ""
                For Each drow1 As Data.DataRow In con.SqlDs(passlen).Tables(0).Rows
                    pwd = drow1!passlen
                Next

                contlen = CInt(Me.txtPassword.Text.Length)
                If contlen < pwd Then
                    smartobj.alertwindow(Me.Page, "Password Length must not be less than " & pwd & " Characters. Contact the System Administrator for further Detail", "Prime")
                    txtPassword.Focus()
                    Exit Sub
                End If
                Dim smsalert As String = "1"
                Dim Emailalert As String = "1"
                Dim chkoffline As String = "0"
                Dim Unknown As String = String.Empty
                decl.password = con.EncryptText(Me.txtPassword.Text.Trim)
                qry = " declare @retmsg varchar(100),@retVal int " & vbNewLine
                qry = qry & "execute Proc_InsUsers "
                qry = qry & smartobj.EncoteWithSingleQuote(decl.staffid.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(decl.staffname.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(decl.department.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(decl.userfunction.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(decl.Branch.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(decl.reportlevel.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(smartobj.DecodeCkeckBox(Me.ChkAuth)) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(decl.password) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(decl.email.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txttillaccno.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(smsalert) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Emailalert) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(chkoffline) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(decl.statement.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(decl.phoneno.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Unknown) & ","

                qry = qry & smartobj.EncoteWithSingleQuote(Session("userid").Trim) & ",NULL,@retVal OUTPUT,@retmsg OUTPUT , " & Session("node_ID") & ""
                qry = qry & " select @retVal,@retmsg"
                For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                    retval = dr(0).ToString
                    retmsg = dr(1).ToString
                Next
                If retval = "0" Then
                    ''  ShowToastr(Page, retmsg, "Yessss!", "Success", False, "toast-top-full-width", False)
                    Panel1.Visible = True
                    Panel1.Focus()

                    Label_success.Text = retmsg

                    Panel2.Visible = False

                    Session("RadWindowCode") = "0"
                    Session("RadWindowMsg") = retmsg
                    ''    smartobj.alertwindow(Me.Page, retmsg, "Prime")
                    clear()

                    ''checkusers()
                Else


                    Panel2.Visible = True
                    Panel2.Focus()

                    Label_error.Text = retmsg

                    Panel1.Visible = False

                    Session("RadWindowCode") = "998"
                    Session("RadWindowMsg") = retmsg

                End If

            End If
            'Me.GridView1.DataBind()
        Catch ex As Exception
            logger.Info("USER: User management PAGE - ERROR AT BtnSubmit_Click '" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")
            Panel2.Visible = True
            Panel2.Focus()

            Label_error.Text = "Error Occurred"

            Panel1.Visible = False

            Session("RadWindowCode") = "XXX"
        End Try
    End Sub
    Sub refreshmenu()
        Try
            Dim rec As String = "Delete from tbl_menudisable where userid='" & Me.txtStaffid.Text.Trim & "' and node_id = " & Session("node_ID") & ""
            con.SqlDs(rec)

            For i = 0 To chkmenu.Items.Count - 1
                Dim xItem As New System.Web.UI.WebControls.ListItem
                xItem.Text = chkmenu.Items(i).Text
                xItem.Value = chkmenu.Items(i).Value

                If chkmenu.Items(i).Selected = False Then

                    Dim upd As String = "Insert into tbl_menudisable(menu_id,userid,node_id) values (" & xItem.Value & ",'" & Me.txtStaffid.Text.Trim & "', " & Session("node_ID") & ")"
                    con.SqlDs(upd)
                End If

            Next

        Catch ex As Exception
            logger.Info("USER: User management PAGE - ERROR AT refreshmenu() '" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")
        End Try

    End Sub
    Sub clear()
        Me.DrpStatus1.SelectedValue = 0
        Me.DrpBranch.SelectedValue = 0
        Me.DrpDept.SelectedValue = 0
        Me.txtemail.Text = ""
        Me.DrpFunction1.SelectedValue = 0
        Me.txtPhone.Text = ""
        Me.txtStaffName.Text = ""
        Me.txttillaccno.Text = ""

        Me.DrpReport.SelectedValue = Nothing
        Me.ChkAuth.Checked = False



    End Sub


    Sub listmenu()
        Me.Label9.Visible = True
        Me.chkmenu.Visible = True
        Me.Label9.Text = "USER PRIVILEDGE"
        Dim Dstring4 As String = "exec Proc_RMUser " & DrpFunction1.SelectedValue.Trim & ", " & Session("node_ID") & ""
        smartobj.loadCheckBoxList(Me.chkmenu, Dstring4)
        'For Each dr As Data.DataRow In con.SqlDs(Dstring4).Tables(0).Rows
        Dim ii As Int16

        For i = 0 To chkmenu.Items.Count - 1
            Dim xItem As New System.Web.UI.WebControls.ListItem
            xItem.Text = chkmenu.Items(i).Text
            xItem.Value = chkmenu.Items(i).Value
            chkmenu.Items(i).Selected = True

            Dim sel As String = "select isnull(menu_id,0) from tbl_menudisable where menu_id='" & xItem.Value & "' and userid='" & Me.txtStaffid.Text.Trim & "' and node_id = " & Session("node_ID") & ""
            If con.SqlDs(sel).Tables(0).Rows.Count > 0 Then
                ii = con.SqlDs(sel).Tables(0).Rows(0).Item(0)

                If ii > 0 Then
                    chkmenu.Items(i).Selected = False
                End If

            End If


        Next
    End Sub

    Protected Sub DrpBranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpBranch.SelectedIndexChanged
        chooseauth()
    End Sub

    Sub chooseauth()
        Try
            Dim Dstring2 As String = "Exec proc_ListSupervisor '" & Me.DrpBranch.SelectedValue & "','" & Me.DrpDept.SelectedValue.Trim & "'," & Session("node_ID") & ""
            smartobj.loadComboValues("--Select a Supervisor--- ", Me.DrpReport, Dstring2)

        Catch ex As Exception

            logger.Info("AddUSER: User management PAGE - ERROR AT chooseauth() '" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")
            smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")

        End Try
    End Sub
    Protected Sub BtnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReset.Click
        smartobj.ClearWebPage(Me.Page)
        clear()
        Me.txtStaffid.Text = ""
        ' Me.DrpSBU.SelectedValue = 0
        Me.BtnSubmit.Enabled = True
        Me.Label9.Visible = False
        Me.chkmenu.Visible = False
    End Sub
    'Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
    '    Response.Redirect("default.aspx")

    'End Sub
    Sub loadauth()

        chooseauth()

        Dim selop As String = "Select isoperation from tbl_role where role_id='" & Me.DrpFunction1.SelectedValue.Trim & "'"
        Dim gtt As Integer = con.SqlDs(selop).Tables(0).Rows(0).Item(0)
        If gtt = 1 Then
            Me.txttillaccno.Visible = True
            Me.Label5.Visible = True
            Me.Label6.Visible = True
        Else
            Me.txttillaccno.Visible = False
            Me.Label5.Visible = False
            Me.Label6.Visible = False

        End If
    End Sub
    Protected Sub DrpFunction1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpFunction1.SelectedIndexChanged
        Try
            loadauth()

        Catch ex As Exception
            logger.Info("USER: User management PAGE - ERROR AT DrpFunction1_SelectedIndexChanged '" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")
            smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")

        End Try
    End Sub

    'Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
    '    Me.txtStaffid.Text = Me.GridView1.SelectedValue
    '    detail()
    'End Sub
    Protected Sub txttillaccno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttillaccno.TextChanged
        Try


            Dim selacct As String = "Select glnumber,acctname from tbl_bankgl where glnumber='" & txttillaccno.Text.Trim & "' and node_id = " & Session("node_ID") & ""
            If con.SqlDs(selacct).Tables(0).Rows.Count < 1 Then
                smartobj.alertwindow(Me.Page, "Invalid Accountnumber", "Prime")

                Me.txttillaccno.Text = ""
                Label6.Text = ""
                Me.BtnSubmit.Enabled = False
            Else
                Label6.Text = con.SqlDs(selacct).Tables(0).Rows(0).Item(1).ToString
                Me.BtnSubmit.Enabled = True

            End If

        Catch ex As Exception
            logger.Info("USER: User management PAGE - ERROR AT txttillaccno_TextChanged '" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")
            smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")

        End Try
    End Sub
    Protected Sub DrpDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpDept.SelectedIndexChanged
        chooseauth()
    End Sub
    Protected Sub ChkAuth_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkAuth.CheckedChanged
        'If Me.ChkAuth.Checked = True Then
        '    Me.Label5.Visible = True
        '    ' Me.ChkEmail.Visible = True
        '    ' Me.ChkOffline.Visible = True
        '    ' Me.ChkSMS.Visible = True

        'Else
        '    Me.Label5.Visible = False
        '    'Me.ChkEmail.Visible = False
        '    'Me.ChkOffline.Visible = False
        '    'Me.ChkSMS.Visible = False

        'End If
    End Sub
    'Protected Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
    '    If Session("node_ID") = Nothing Then
    '        Response.Redirect("../PageExpire.aspx")
    '    Else
    '        Me.MasterPageFile = "~/Tenant" + Session("node_ID").ToString + "/Tenant.master"

    '    End If
    'End Sub
#End Region
End Class
