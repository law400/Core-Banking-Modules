Imports Toastr
Imports log4net
Imports log4net.Config
Partial Class Security_RoleEdit
    Inherits SessionCheck
#Region "PageLoad"
    Dim dr As Data.DataRow
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(Security_RoleEdit))

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("Label3"), System.Web.UI.WebControls.Label)
        l.Text = ""
        Dim ll As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("Label4"), System.Web.UI.WebControls.Label)
        ll.Text = "MANAGE ROLE - ROLE EDIT" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim

        If Page.IsPostBack = False Then
            Try

                TxtRole_name.Visible = False
                LstFrom_Menu.SelectedIndex = 0
                LstTo_Menu.SelectedIndex = 0

                Dim Roleid_Pick As Integer = Request.QueryString("roleid")
                ' Dim Role_name As String = Request.QueryString("rolename")
                Dim reqlimit As String = ""



                'Label1.Text = Role_name
                If (Roleid_Pick <> Nothing) Then
                    Dim qry1 As String = ""
                    Me.Submit.Text = "Update"
                    Session("RolePicked") = Roleid_Pick

                    Dim sRole As String = "select role_name,access_days,isnull(reqLimit,0) reqLimit,isnull(canauth,0) canauth,isnull(isoperation,0) isoperation,roledesc from tbl_Role where role_id=" & Roleid_Pick & " and node_id = " & Session("node_ID") & ""
                    For Each dr As Data.DataRow In con.SqlDs(sRole).Tables(0).Rows
                        Label1.Text = dr("role_name").ToString
                        Me.TxtRole_name0.Text = dr("roledesc").ToString
                        Me.CheckBox3.Checked = smartobj.encodeCkeckBox(dr("isoperation").ToString)
                        Me.CheckBox2.Checked = smartobj.encodeCkeckBox(dr("canauth").ToString)
                        Me.txtDays.Text = dr("access_days").ToString

                    Next

                    If Me.CheckBox2.Checked = True Then
                        Me.MultiView2.Visible = True
                        Me.MultiView2.ActiveViewIndex = 0


                    Else

                        ''Dim st2 As String = "select a.authid,authdesc from tbl_authorisation a,tbl_authrole b where a.authid=b.authid and b.roleid=" & Roleid_Pick & " order by authdesc asc"
                        ''smartobj.loadListBox(Me.ListBox2, st2)

                        ''Dim st3 As String = "Exec proc_rolepriv '" & Roleid_Pick & "'"
                        ''smartobj.loadListBox(Me.ListBox1, st3)

                        Me.MultiView2.Visible = False
                    End If

                    'refreshgrid()
                    '' Dim st As String = "select * from tbl_RM where role_id=" & Roleid_Pick & " and node_id = " & Session("node_ID") & ""
                    Dim st As String = "select 1 from tbl_RM a, tbl_RM_Tenants b where a.role_id=" & Roleid_Pick & "and a.node_id = " & Session("node_ID") & " and b.node_id = " & Session("node_ID") & " and a.menu_id = b.menu_id"
                    Try
                        If con.SqlDs(st).Tables(0).Rows.Count > 0 Then
                            'Dim dint, dname As String
                            Dim st1 As String = "select  cast(a.menu_id as varchar(3)) menu_id,a.menu_name from tbl_Menu a,tbl_RM b,Tbl_RM_Tenants c where a.menu_id = b.menu_id and b.role_id='" & Roleid_Pick & "' and a.url <> '" & "null" & "' and b.node_id = " & Session("node_ID") & " and c.node_id = " & Session("node_ID") & " and a.menu_id = c.menu_id order by a.menu_name asc"

                            smartobj.loadListBox(Me.LstTo_Menu, st1)


                            relarefresh(Roleid_Pick)

                            Dim st4 As String = "select menu_name from tbl_menu a,tbl_rm b where a.menu_id=b.menu_id and ltrim(rtrim(a.menu_name))='" & "GROUP REPORT" & "' and b.role_id='" & Roleid_Pick & "' and b.node_id = " & Session("node_ID") & ""
                            If con.SqlDs(st4).Tables(0).Rows.Count > 0 Then
                                Me.panelreport.Visible = True
                                showreportlist()
                            Else
                                Me.panelreport.Visible = False
                            End If


                        Else


                            refreshgrid()

                        End If

                    Catch ex As Exception
                        ''    smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")
                        logger.Info("SETUP: ROLE EDIT PAGE - ERROR AT PAGE LOAD '" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")
                        smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)


                    End Try
                Else
                    Label1.Visible = False
                    TxtRole_name.Visible = True
                    Me.Label2.Visible = True
                    Me.TxtRole_name0.Text = ""
                    refreshgrid()
                    ''refreshgrid2()
                    Me.Submit.Text = "Save Record"


                End If
                refreshgrid2()
            Catch ex As Exception
                logger.Info("SETUP: ROLE EDIT PAGE - ERROR AT PAGE LOAD '" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")
                smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)
            End Try

        End If
    End Sub
    Sub showreportlist()
        Try

            Dim selrpt As String = "select grouprptid from tbl_reportgrole where roleid=" & Request.QueryString("roleid") & " and node_id= " & Session("node_ID") & ""
            For Each dr As Data.DataRow In con.SqlDs(selrpt).Tables(0).Rows
                Dim ii As Int16 = dr.Item(0)

                For i = 0 To ChkReportList.Items.Count - 1
                    Dim xItem As New System.Web.UI.WebControls.ListItem
                    xItem.Text = ChkReportList.Items(i).Text
                    xItem.Value = ChkReportList.Items(i).Value
                    If ii = xItem.Value Then
                        ChkReportList.Items(i).Selected = True
                    End If

                Next
            Next
        Catch ex As Exception
            logger.Info("SETUP: ROLE EDIT PAGE - ERROR AT showreportlist() '" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "************************************************************************************************************************************************************************************")
            smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)
        End Try
    End Sub

#End Region
#Region "Task"
    Sub relarefresh(ByVal roleid As String)
        Try
            Dim qry As String = "select cast(a.menu_id as varchar(3)) menu_id,a.menu_name from tbl_Menu a,tbl_RM_Tenants b where a.url <> '" & "null" & "' and a.menu_id not in (select a.menu_id from tbl_Menu a,tbl_RM b where a.menu_id = b.menu_id and b.role_id='" & roleid & "' and a.url <> '" & "null" & "' and b.node_id = " & Session("node_ID") & ") and a.menu_id = b.menu_id and b.node_id =  " & Session("node_ID") & " order by a.menu_name asc"
            smartobj.loadListBox(Me.LstFrom_Menu, qry)

        Catch ex As Exception
            logger.Info("SETUP: ROLE EDIT PAGE - ERROR AT relarefresh '" _
                                        & vbNewLine & "   <<<<Direction: OUTPUT" _
                                        & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
                                        & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
                                        & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
                                        & vbNewLine & "************************************************************************************************************************************************************************************")
            smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)
        End Try

    End Sub
    Sub refreshgrid()
        Try
            Dim strSQL1 As String = " select cast(a.menu_id as varchar(3)) menu_id,a.menu_name from tbl_Menu a, tbl_RM_Tenants b where url <> '" & "null" & "' and a.menu_id = b.menu_id and b.node_id = " & Session("node_ID") & " order by menu_name asc"

            smartobj.loadListBox(Me.LstFrom_Menu, strSQL1)

        Catch ex As Exception
            logger.Info("SETUP: ROLE EDIT PAGE - ERROR AT refreshgrid()'" _
                                       & vbNewLine & "   <<<<Direction: OUTPUT" _
                                       & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
                                       & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
                                       & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
                                       & vbNewLine & "************************************************************************************************************************************************************************************")
            smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)
        End Try
    End Sub

    Sub refreshgrid2()
        refreshgridexist()
        refreshgridexist2()
    End Sub
    'Sub refreshgrid3()
    '    refreshgridexist3()
    '    refreshgridexist4()
    'End Sub
    'Sub refreshgridexist3()
    '    Dim strSQL1 As String = "Exec proc_roleauthlist4 " & Request.QueryString("roleid").Trim & ""

    '    smartobj.loadListBox(Me.ListBox2, strSQL1)
    'End Sub
    'Sub refreshgridexist4()
    '    Dim strSQL1 As String = "Exec proc_roleauthlist3 " & Request.QueryString("roleid").Trim & ""

    '    smartobj.loadListBox(Me.ListBox1, strSQL1)
    'End Sub
    Sub refreshgridexist()
        Dim strSQL1 As String = "Exec proc_roleauthlist2 " & Request.QueryString("roleid") & ", " & Session("node_ID") & ""

        smartobj.loadListBox(Me.ListBox2, strSQL1)
    End Sub
    Sub refreshgridexist2()
        Dim strSQL1 As String = "Exec proc_roleauthlist1 " & Request.QueryString("roleid") & ", " & Session("node_ID") & ""

        smartobj.loadListBox(Me.ListBox1, strSQL1)
    End Sub
    Protected Sub Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Close.Click
        Session("RolePicked") = Nothing
        Response.Redirect("Role.aspx")
    End Sub
    Sub rolereport()
        Dim st As String = "delete from tbl_reportgrole where roleid='" & Session("RolePicked") & "' and node_id = " & Session("node_ID") & ""
        con.SqlDs(st)

        For i = 0 To ChkReportList.Items.Count - 1
            Dim xItem As New System.Web.UI.WebControls.ListItem
            xItem.Text = ChkReportList.Items(i).Text
            xItem.Value = ChkReportList.Items(i).Value

            If ChkReportList.Items(i).Selected Then
                Dim inst As String = "Insert into tbl_reportgrole Values (" & xItem.Value & ",'" & Session("RolePicked") & "', " & Session("node_ID") & ")"
                con.SqlDs(inst)
            End If


        Next

    End Sub
    Sub updauth()
        Dim k1 As Integer = ListBox2.Items.Count
        Dim i As Integer
        Dim xArr As New System.Collections.ArrayList
        For i = 0 To ListBox2.Items.Count - 1
            Dim xItem As New System.Web.UI.WebControls.ListItem
            xItem.Text = ListBox2.Items(i).Text
            xItem.Value = ListBox2.Items(i).Value
            xArr.Add(xItem)
        Next
        If Request.QueryString("roleid") <> "" Then
            Dim st As String = "Delete from tbl_authrole where ltrim(rtrim(roleid))=" & Session("RolePicked") & " and node_id = " & Session("node_ID") & ""
            con.SqlDs(st)
            Try
                Dim count As Integer = 0

                For i = 0 To xArr.Count - 1
                    Dim xItem As New System.Web.UI.WebControls.ListItem
                    xItem = CType(xArr.Item(i), System.Web.UI.WebControls.ListItem)
                    Dim inst As String = "Insert into tbl_authrole(AuthID,RoleID,node_id) Values (" & xItem.Value & "," & Session("RolePicked") & ", " & Session("node_ID") & ")"
                    con.SqlDs(inst)

                Next
            Catch ex As Exception
                logger.Info("SETUP: ROLE EDIT PAGE - ERROR AT updauth() '" _
                                                       & vbNewLine & "   <<<<Direction: OUTPUT" _
                                                       & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
                                                       & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
                                                       & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
                                                       & vbNewLine & "************************************************************************************************************************************************************************************")
                smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)
            End Try

        End If

    End Sub
    Protected Sub Submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Submit.Click
        Try
            Dim k1 As Integer = LstTo_Menu.Items.Count
            Dim i As Integer
            Dim xArr As New System.Collections.ArrayList
            For i = 0 To LstTo_Menu.Items.Count - 1
                Dim xItem As New System.Web.UI.WebControls.ListItem
                xItem.Text = LstTo_Menu.Items(i).Text
                xItem.Value = LstTo_Menu.Items(i).Value
                xArr.Add(xItem)
            Next

            latesttime = CDate(Session("sysdate"))
            If IsDate(latesttime) Then
                latesttime = latesttime.AddHours(Now.Hour)
                latesttime = latesttime.AddMinutes(Now.Minute)
                latesttime = latesttime.AddSeconds(Now.Second)
            End If

            'If Not IsNumeric(Me.txtDays.Text.Trim) Then
            '    smartobj.alertwindow(Me.Page, "Access Days Must be Numeric", "Prime")

            '    Exit Sub
            'End If
            If Me.Submit.Text <> "Update" Then
                If Me.TxtRole_name.Text = "" Then
                    ''    smartobj.alertwindow(Me.Page, "Please enter role name", "Prime")

                    smartobj.ShowToast(Me.Page, ToastType.Warning, "Please enter role name", "Oops!", ToastPosition.TopRight, True)

                    TxtRole_name.Focus()
                    Exit Sub
                End If
            End If

            If Me.TxtRole_name0.Text = "" Then
                ''   smartobj.alertwindow(Me.Page, "Please enter description", "Prime")

                smartobj.ShowToast(Me.Page, ToastType.Warning, "Please enter description", "Oops!", ToastPosition.TopRight, True)

                TxtRole_name0.Focus()
                Exit Sub
            End If
            If Me.txtDays.Text = "" Then
                ''  smartobj.alertwindow(Me.Page, "Please enter access days", "Prime")

                smartobj.ShowToast(Me.Page, ToastType.Warning, "Please enter access days", "Oops!", ToastPosition.TopRight, True)

                txtDays.Focus()
                Exit Sub
            End If
            If Me.Submit.Text = "Update" Then

                If Session("RolePicked") = Nothing Then
                    ''      smartobj.alertwindow(Me.Page, "Nothing to update", "Prime")

                    smartobj.ShowToast(Me.Page, ToastType.Warning, "Nothing to update", "Oops!", ToastPosition.TopRight, True)


                    Exit Sub
                End If

                Dim st As String = "delete from tbl_RM where role_id='" & Session("RolePicked") & "' and node_id = " & Session("node_ID") & ""
                con.SqlDs(st)



                Dim parent As Integer
                Dim count As Integer = 0

                For i = 0 To xArr.Count - 1
                    Dim xItem As New System.Web.UI.WebControls.ListItem
                    xItem = CType(xArr.Item(i), System.Web.UI.WebControls.ListItem)
                    Dim selparent As String = "select a.menu_id,b.role_id,a.parent from tbl_Menu a,tbl_Role b, tbl_RM_Tenants c where a.menu_id = c.menu_id and c.node_id = " & Session("node_ID") & " and b.node_id = " & Session("node_ID") & " and a.menu_name='" & xItem.ToString.Trim.Replace("'", "") & "' and b.role_id='" & Session("RolePicked") & "' and url<>'" & "null" & "'"

                    If con.SqlDs(selparent).Tables(0).Rows.Count > 0 Then
                        drx = con.SqlDs(selparent).Tables(0).Rows(0)

                        parent = drx.Item("parent")
                        'If parent = "" Then
                        '    parent = 0
                        'End If
                        'If count <> parent Then
                        '    Dim instParnt As String = "Insert into tbl_RM(menu_id,role_id) values ('" & parent & "','" & Session("RolePicked") & "')"
                        '    con.SqlDs(instParnt)
                        '    count = parent
                        'Else
                        'End If
                        Dim st3 As String = "insert into tbl_RM(menu_ID,role_id,node_id) select a.menu_id,b.role_id, " & Session("node_ID") & " from tbl_Menu a,tbl_Role b, tbl_RM_Tenants c where a.menu_name='" & xItem.ToString.Trim.Replace("'", "") & "' and b.role_id='" & CInt(Session("RolePicked")) & "' and a.menu_id = c.menu_id and c.node_id = " & Session("node_ID") & " and b.node_id = " & Session("node_ID") & ""
                        con.SqlDs(st3)
                    End If

                Next
                Dim stupdate As String = "update tbl_Role set access_days=" & CInt(Me.txtDays.Text.Trim) & ",canauth=" & smartobj.DecodeCkeckBox(Me.CheckBox2) & ",isoperation='" & smartobj.DecodeCkeckBox(Me.CheckBox3) & "',roledesc='" & Me.TxtRole_name0.Text.Trim & "',role_name='" & Label1.Text.Trim & "',createdate='" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "' where role_id='" & CInt(Session("RolePicked")) & "' and node_id = " & Session("node_ID") & ""
                con.SqlDs(stupdate)
                ''If Me.CheckBox2.Checked = True Then
                ''    updauth()

                ''End If

                If Me.panelreport.Visible = True Then
                    rolereport()
                End If

                ''  smartobj.alertwindow(Me.Page, "Function Successfully update", "Prime")

                smartobj.ShowToast(Me.Page, ToastType.Success, "Function Successfully Updated", "Yessss!", ToastPosition.TopRight, True)




            Else
                Dim rolid As Integer
                Dim st As String = ""
                If Me.TxtRole_name.Text = "" Then
                    ''       smartobj.alertwindow(Me.Page, "Please enter role name", "Prime")

                    smartobj.ShowToast(Me.Page, ToastType.Warning, "Please enter role name", "Oops!", ToastPosition.TopRight, True)

                    TxtRole_name.Focus()
                    Exit Sub
                End If
                If Me.TxtRole_name0.Text = "" Then
                    ''  smartobj.alertwindow(Me.Page, "Please enter description", "Prime")

                    smartobj.ShowToast(Me.Page, ToastType.Warning, "Please enter description", "Oops!", ToastPosition.TopRight, True)

                    TxtRole_name0.Focus()
                    Exit Sub
                End If
                If Me.txtDays.Text = "" Then
                    ''    smartobj.alertwindow(Me.Page, "Please enter access days", "Prime")

                    smartobj.ShowToast(Me.Page, ToastType.Warning, "Please enter access days", "Oops!", ToastPosition.TopRight, True)

                    txtDays.Focus()
                    Exit Sub
                End If
                If Me.Label1.Text = "" Then
                    If TxtRole_name.Text = "" Then
                        ''    smartobj.alertwindow(Me.Page, "Enter Role Name...", "Prime")

                        smartobj.ShowToast(Me.Page, ToastType.Warning, "Enter Role Name...", "Oops!", ToastPosition.TopRight, True)

                        TxtRole_name.Focus()
                        Exit Sub

                    Else



                        Dim st3 As String = "insert into tbl_Role(role_name,roledesc,isoperation,canauth,createdate,access_days,node_id) values ('" & TxtRole_name.Text.Trim.Replace("'", "") & "','" & Me.TxtRole_name0.Text.Trim & "','" & smartobj.DecodeCkeckBox(Me.CheckBox3) & "'," & smartobj.DecodeCkeckBox(Me.CheckBox2) & ",'" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "'," & CInt(Me.txtDays.Text.Trim) & ", " & Session("node_ID") & ")"
                        con.SqlDs(st3)


                        st = "select role_id from tbl_Role where role_name='" & TxtRole_name.Text.Trim.Replace("'", "") & " ' and node_id = " & Session("node_ID") & ""
                        rolid = con.SqlDs(st).Tables(0).Rows(0).Item("role_id").ToString

                    End If

                Else

                    st = "select role_id from tbl_Role where role_name='" & Me.Label1.Text.Trim.Replace("'", "") & " ' and node_id = " & Session("node_ID") & ""
                    rolid = con.SqlDs(st).Tables(0).Rows(0).Item("role_id").ToString

                End If



                Dim parent1 As Integer
                Dim count1 As Integer = 0
                For i = 0 To xArr.Count - 1
                    Dim xItem As New System.Web.UI.WebControls.ListItem
                    xItem = CType(xArr.Item(i), System.Web.UI.WebControls.ListItem)
                    Dim selparent As String = "select a.menu_id,b.role_id,a.parent from tbl_Menu a,tbl_Role b,tbl_RM_Tenants c where a.menu_name='" & xItem.ToString.Trim.Replace("'", "") & "' and b.role_id='" & rolid & "' and a.menu_id = c.menu_id and c.node_id = " & Session("node_ID") & " and b.node_id = " & Session("node_ID") & ""
                    For Each dr As Data.DataRow In con.SqlDs(selparent).Tables(0).Rows
                        parent1 = dr("parent")
                        If count1 <> parent1 Then
                            Dim instParnt As String = "Insert into tbl_RM(menu_id,role_id,node_id) values ('" & parent1 & "','" & rolid & "', " & Session("node_ID") & ")"
                            con.SqlDs(instParnt)
                            count1 = parent1
                        Else
                        End If
                    Next
                    Dim stINST As String = "insert into tbl_RM(menu_ID,role_id,node_id) select a.menu_id,b.role_id, " & Session("node_ID") & " from tbl_Menu a,tbl_Role b, tbl_RM_Tenants c where a.menu_id = c.menu_id and  a.menu_name='" & xItem.ToString.Trim.Replace("'", "") & "' and b.role_id='" & CInt(rolid) & "'"
                    con.SqlDs(stINST)
                Next


                If Me.panelreport.Visible = True Then
                    rolereport()
                End If

                ''  smartobj.alertwindow(Me.Page, "Function Successfully Created", "Prime")

                smartobj.ShowToast(Me.Page, ToastType.Success, "Function Successfully Created", "Yessss!", ToastPosition.TopRight, True)

                Me.Submit.Enabled = False



            End If

            Dim stfil As String = "Exec proc_rolepriv '" & Session("RolePicked") & "'"
            smartobj.loadListBox(Me.ListBox1, stfil)

        Catch ex As Exception
            '' smartobj.alertwindow(Me.Page, "Role Already Created..", "Prime")

            logger.Info("SETUP: ROLE EDIT PAGE - ERROR AT Submit_Click '" _
                                                   & vbNewLine & "   <<<<Direction: OUTPUT" _
                                                   & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
                                                   & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
                                                   & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
                                                   & vbNewLine & "************************************************************************************************************************************************************************************")
            smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)
        End Try
    End Sub
    'Protected Sub AddItem(ByVal li As ListItem)
    '    LstTo_menu.SelectedIndex = -1
    '    LstTo_menu.Items.Add(li)
    'End Sub

    Protected Sub nextbln_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles nextbln.Click
        Try
            Dim k1 As Integer = LstFrom_Menu.Items.Count
            Dim i As Integer
            Dim xArr As New System.Collections.ArrayList

            For i = 0 To LstFrom_Menu.Items.Count - 1
                If LstFrom_Menu.Items(i).Selected = True Then
                    Dim xItem As New System.Web.UI.WebControls.ListItem
                    xItem.Text = LstFrom_Menu.Items(i).Text
                    xItem.Value = LstFrom_Menu.Items(i).Value
                    xArr.Add(xItem)

                End If
            Next

            For i = 0 To xArr.Count - 1
                Dim xItem As New System.Web.UI.WebControls.ListItem
                xItem = CType(xArr.Item(i), System.Web.UI.WebControls.ListItem)

                LstTo_Menu.Items.Add(xItem)
                LstFrom_Menu.Items.Remove(xItem)

                If xItem.Text.Trim = "GROUP REPORT" Then
                    panelreport.Visible = True
                Else
                    panelreport.Visible = False

                End If
            Next



        Catch ex As Exception
            ''  smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")


            logger.Info("SETUP: ROLE EDIT PAGE - ERROR AT nextbln_Click '" _
                                                   & vbNewLine & "   <<<<Direction: OUTPUT" _
                                                   & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
                                                   & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
                                                   & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
                                                   & vbNewLine & "************************************************************************************************************************************************************************************")
            smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)
        End Try
    End Sub

    Protected Sub Back_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Back.Click
        Try

            Dim k1 As Integer = LstTo_Menu.Items.Count
            Dim i As Integer
            Dim xArr As New System.Collections.ArrayList

            For i = 0 To LstTo_Menu.Items.Count - 1
                If LstTo_Menu.Items(i).Selected = True Then
                    Dim xItem As New System.Web.UI.WebControls.ListItem
                    xItem.Text = LstTo_Menu.Items(i).Text
                    xItem.Value = LstTo_Menu.Items(i).Value
                    xArr.Add(xItem)

                End If
            Next

            For i = 0 To xArr.Count - 1
                Dim xItem As New System.Web.UI.WebControls.ListItem
                xItem = CType(xArr.Item(i), System.Web.UI.WebControls.ListItem)

                LstFrom_Menu.Items.Add(xItem)
                LstTo_Menu.Items.Remove(xItem)
            Next

        Catch ex As Exception
            ''    smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")

            logger.Info("SETUP: ROLE EDIT PAGE - ERROR AT Back_Click '" _
                                                             & vbNewLine & "   <<<<Direction: OUTPUT" _
                                                             & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
                                                             & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
                                                             & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
                                                             & vbNewLine & "************************************************************************************************************************************************************************************")
            smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)
        End Try
    End Sub

    Protected Sub TxtRole_name_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtRole_name.TextChanged
        Try
            Dim selv As String = "Select * from tbl_role where role_name='" & Me.TxtRole_name.Text.Trim & "' and node_id = " & Session("node_ID") & ""
            If con.SqlDs(selv).Tables(0).Rows.Count > 0 Then
                ''  smartobj.alertwindow(Me.Page, "Role Name  Already Exist", "Prime")

                smartobj.ShowToast(Me.Page, ToastType.Warning, "Role Name  Already Exist", "Oops!", ToastPosition.TopRight, True)

                Me.TxtRole_name.Text = ""
                Exit Sub
            End If
        Catch ex As Exception
            logger.Info("SETUP: ROLE EDIT PAGE - ERROR AT TxtRole_name_TextChanged '" _
                                                                         & vbNewLine & "   <<<<Direction: OUTPUT" _
                                                                         & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
                                                                         & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
                                                                         & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
                                                                         & vbNewLine & "************************************************************************************************************************************************************************************")
            smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)
        End Try
    End Sub
#End Region
    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        Try
            If Me.CheckBox2.Checked = True Then
                Me.MultiView2.Visible = True
                Me.MultiView2.ActiveViewIndex = 0
            Else
                Me.MultiView2.Visible = False
            End If
        Catch ex As Exception
            logger.Info("SETUP: ROLE EDIT PAGE - ERROR AT CheckBox2_CheckedChanged '" _
           & vbNewLine & "   <<<<Direction: OUTPUT" _
           & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
           & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
           & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
           & vbNewLine & "************************************************************************************************************************************************************************************")
            smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)
        End Try
    End Sub
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            Dim k1 As Integer = ListBox2.Items.Count
            Dim i As Integer
            Dim xArr As New System.Collections.ArrayList

            For i = 0 To ListBox2.Items.Count - 1
                If ListBox2.Items(i).Selected = True Then
                    Dim xItem As New System.Web.UI.WebControls.ListItem
                    xItem.Text = ListBox2.Items(i).Text
                    xItem.Value = ListBox2.Items(i).Value
                    xArr.Add(xItem)

                End If
            Next

            For i = 0 To xArr.Count - 1
                Dim xItem As New System.Web.UI.WebControls.ListItem
                xItem = CType(xArr.Item(i), System.Web.UI.WebControls.ListItem)

                ListBox1.Items.Add(xItem)
                ListBox2.Items.Remove(xItem)
            Next

        Catch ex As Exception
            ''   smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")

            logger.Info("SETUP: ROLE EDIT PAGE - ERROR AT Button2_Click '" _
                      & vbNewLine & "   <<<<Direction: OUTPUT" _
                      & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
                      & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
                      & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
                      & vbNewLine & "************************************************************************************************************************************************************************************")
            smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)
        End Try
    End Sub
    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Dim k1 As Integer = ListBox1.Items.Count
            Dim i As Integer
            Dim xArr As New System.Collections.ArrayList

            For i = 0 To ListBox1.Items.Count - 1
                If ListBox1.Items(i).Selected = True Then
                    Dim xItem As New System.Web.UI.WebControls.ListItem
                    xItem.Text = ListBox1.Items(i).Text
                    xItem.Value = ListBox1.Items(i).Value
                    xArr.Add(xItem)

                End If
            Next

            For i = 0 To xArr.Count - 1
                Dim xItem As New System.Web.UI.WebControls.ListItem
                xItem = CType(xArr.Item(i), System.Web.UI.WebControls.ListItem)

                ListBox2.Items.Add(xItem)
                ListBox1.Items.Remove(xItem)


            Next



        Catch ex As Exception
            ''    smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")
            logger.Info("SETUP: ROLE EDIT PAGE - ERROR AT Button3_Click '" _
                              & vbNewLine & "   <<<<Direction: OUTPUT" _
                              & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
                              & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
                              & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
                              & vbNewLine & "************************************************************************************************************************************************************************************")
            smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)
        End Try
    End Sub

    Protected Sub Submit0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Submit0.Click
        Try
            updauth()
            ''   smartobj.alertwindow(Me.Page, "Authorisation Saved Successfully", "Prime")

            smartobj.ShowToast(Me.Page, ToastType.Success, "Authorisation Saved Successfully", "Yessss!", ToastPosition.TopRight, True)


        Catch ex As Exception
            logger.Info("SETUP: ROLE EDIT PAGE - ERROR AT Submit0_Click '" _
                              & vbNewLine & "   <<<<Direction: OUTPUT" _
                              & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
                              & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
                              & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
                              & vbNewLine & "************************************************************************************************************************************************************************************")
            smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)

        End Try
    End Sub
    'Protected Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
    '    Me.MasterPageFile = "~/Tenant" + Session("node_ID").ToString + "/Tenant.master"
    'End Sub
End Class
