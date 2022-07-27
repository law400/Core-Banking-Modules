Imports Toastr
Partial Class Security_RoleEdit_Global
    Inherits SessionCheck
#Region "PageLoad"
    Dim dr As Data.DataRow
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("Label3"), System.Web.UI.WebControls.Label)
        l.Text = ""
        Dim ll As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("Label4"), System.Web.UI.WebControls.Label)
        ll.Text = "GLOBAL ROLE CONFIG. " & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        Dim menuname As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("lbldisplay"), System.Web.UI.WebControls.Label)
        menuname.Text = Request.QueryString("XXX")
        'If menuname.Text = "" Then
        '    Response.Redirect("~/Unauthorize.aspx")
        'End If

        'If Validate_Access(menuname.Text) = 0 Then
        '    Response.Redirect("~/Unauthorize.aspx")
        'End If

        If Page.IsPostBack = False Then
            Try


                LstFrom_Menu.SelectedIndex = 0
                LstTo_Menu.SelectedIndex = 0

                Dim node_ID_Pick As Integer = Request.QueryString("roleid")
                ' Dim Role_name As String = Request.QueryString("rolename")
                Dim reqlimit As String = ""



                'Label1.Text = Role_name
                If (node_ID_Pick <> Nothing) Then
                    Dim qry1 As String = ""
                    Me.Submit.Text = "Update"
                    Session("node_ID_Picked") = node_ID_Pick

                    Dim sTenant As String = "select Tenant from tbl_Tenants where node_id=" & node_ID_Pick & ""
                    For Each dr As Data.DataRow In con.SqlDs(sTenant).Tables(0).Rows
                        Label1.Text = dr("Tenant").ToString



                    Next



                    'refreshgrid()
                    Dim st As String = "select * from tbl_Tenants where node_id=" & node_ID_Pick & ""
                    Try
                        If con.SqlDs(st).Tables(0).Rows.Count > 0 Then
                            'Dim dint, dname As String
                            Dim st1 As String = "select  cast(a.menu_id as varchar(3)) menu_id,a.menu_name from tbl_Menu a,tbl_RM_Tenants b where a.parent is not null and a.menu_id = b.menu_id and b.node_id='" & node_ID_Pick & "' and a.url <> '" & "null" & "' order by a.menu_name asc"

                            smartobj.loadListBox(Me.LstTo_Menu, st1)


                            relarefresh(node_ID_Pick)




                        Else


                            refreshgrid()

                        End If

                    Catch ex As Exception
                        ''      smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")

                        smartobj.ShowToast(Me.Page, ToastType.Error, "Data Warning error...", "Error!", ToastPosition.TopRight, True)


                    End Try
                Else
                    Label1.Visible = False

                    Me.TxtRole_name0.Text = ""
                    refreshgrid()
                    ''refreshgrid2()
                    Me.Submit.Text = "Save Record"


                End If

            Catch ex As Exception

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
    Sub relarefresh(ByVal node_id As Integer)
        Try
            Dim qry As String = "select cast(menu_id as varchar(3)) menu_id,menu_name from tbl_Menu where url <> '" & "null" & "' and parent is not null and menu_id not in (select a.menu_id from tbl_Menu a,tbl_RM_Tenants b where a.parent is not null and a.menu_id = b.menu_id and b.node_id=" & node_id & " and a.url <> '" & "null" & "') order by menu_name asc"
            smartobj.loadListBox(Me.LstFrom_Menu, qry)

        Catch ex As Exception

        End Try

    End Sub
    Sub refreshgrid()
        Try
            Dim strSQL1 As String = "select cast(menu_id as varchar(3)) menu_id,menu_name from tbl_Menu where parent is not null and url <> '" & "null" & "' order by menu_name asc"

            smartobj.loadListBox(Me.LstFrom_Menu, strSQL1)

        Catch ex As Exception

        End Try
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


    Protected Sub Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Close.Click
        Session("node_ID_Picked") = Nothing
        Response.Redirect("Role_Tenant.aspx")
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


            If Me.Submit.Text = "Update" Then

                If Session("node_ID_Picked") = Nothing Then
                    smartobj.alertwindow(Me.Page, "Nothing to update", "Prime")

                    Exit Sub
                End If

                Dim st As String = "delete from tbl_RM_Tenants where node_id=" & Session("node_ID_Picked") & ""
                con.SqlDs(st)



                Dim parent As Integer
                Dim count As Integer = 0

                For i = 0 To xArr.Count - 1
                    Dim xItem As New System.Web.UI.WebControls.ListItem
                    xItem = CType(xArr.Item(i), System.Web.UI.WebControls.ListItem)
                    Dim selparent As String = "select a.menu_id,b.node_id,a.parent from tbl_Menu a,tbl_Tenants b where a.menu_name='" & xItem.ToString.Trim.Replace("'", "") & "' and b.node_id='" & Session("node_ID_Picked") & "' and url<>'" & "null" & "'"

                    If con.SqlDs(selparent).Tables(0).Rows.Count > 0 Then
                        drx = con.SqlDs(selparent).Tables(0).Rows(0)

                        parent = drx.Item("parent")
                        'If parent = "" Then
                        '    parent = 0
                        'End If
                        'If count <> parent Then
                        '    Dim instParnt As String = "Insert into tbl_RM(menu_id,role_id) values ('" & parent & "','" & Profile.RolePicked & "')"
                        '    con.SqlDs(instParnt)
                        '    count = parent
                        'Else
                        'End If
                        Dim st3 As String = "insert into tbl_RM_Tenants(menu_ID,node_id) select a.menu_id,b.node_id from tbl_Menu a,tbl_Tenants b where a.menu_name='" & xItem.ToString.Trim.Replace("'", "") & "' and b.node_id='" & CInt(Session("node_ID_Picked")) & "'"
                        con.SqlDs(st3)
                    End If

                Next

                ''   smartobj.alertwindow(Me.Page, "Function Successfully updated", "Prime")

                smartobj.ShowToast(Me.Page, ToastType.Success, "Function Successfully updated", "Yessss!", ToastPosition.TopRight, True)



                'Else
                '    Dim rolid As Integer
                '    Dim st As String = ""
                '    If Me.Label1.Text = "" Then
                '        If TxtRole_name.Text = "" Then
                '            smartobj.alertwindow(Me.Page, "Enter Role Name...", "Prime")

                '            Exit Sub
                '        Else



                '            Dim st3 As String = "insert into tbl_Menu(role_name,roledesc,isoperation,canauth,createdate,access_days) values ('" & TxtRole_name.Text.Trim.Replace("'", "") & "','" & Me.TxtRole_name0.Text.Trim & "','" & smartobj.DecodeCkeckBox(Me.CheckBox3) & "'," & smartobj.DecodeCkeckBox(Me.CheckBox2) & ",'" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "'," & CInt(Me.txtDays.Text.Trim) & ")"
                '            con.SqlDs(st3)


                '            st = "select role_id from tbl_Role where role_name='" & TxtRole_name.Text.Trim.Replace("'", "") & " '"
                '            rolid = con.SqlDs(st).Tables(0).Rows(0).Item("role_id").ToString

                '        End If

                '    Else

                '        st = "select role_id from tbl_Role where role_name='" & Me.Label1.Text.Trim.Replace("'", "") & " '"
                '        rolid = con.SqlDs(st).Tables(0).Rows(0).Item("role_id").ToString

                '    End If



                '    Dim parent1 As Integer
                '    Dim count1 As Integer = 0
                '    For i = 0 To xArr.Count - 1
                '        Dim xItem As New ListItem
                '        xItem = CType(xArr.Item(i), ListItem)
                '        Dim selparent As String = "select a.menu_id,b.role_id,a.parent from tbl_Menu a,tbl_Role b where a.menu_name='" & xItem.ToString.Trim.Replace("'", "") & "' and b.role_id='" & rolid & "'"
                '        For Each dr As Data.DataRow In con.SqlDs(selparent).Tables(0).Rows
                '            parent1 = dr("parent")
                '            If count1 <> parent1 Then
                '                Dim instParnt As String = "Insert into tbl_RM(menu_id,role_id) values ('" & parent1 & "','" & rolid & "')"
                '                con.SqlDs(instParnt)
                '                count1 = parent1
                '            Else
                '            End If
                '        Next
                '        Dim stINST As String = "insert into tbl_RM(menu_ID,role_id) select a.menu_id,b.role_id from tbl_Menu a,tbl_Role b where a.menu_name='" & xItem.ToString.Trim.Replace("'", "") & "' and b.role_id='" & CInt(rolid) & "'"
                '        con.SqlDs(stINST)
                '    Next


                '    If Me.panelreport.Visible = True Then

                '    End If

                '    smartobj.alertwindow(Me.Page, "Function Successfully Created", "Prime")
                '    Me.Submit.Enabled = False



            End If



        Catch ex As Exception
            ''   smartobj.alertwindow(Me.Page, "Menu Already Created..", "Prime")


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


            Next



        Catch ex As Exception
            ''  smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")

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
            ''     smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")


            smartobj.ShowToast(Me.Page, ToastType.Error, "Error Occurred", "Error!", ToastPosition.TopRight, True)

        End Try
    End Sub


#End Region




    'Protected Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
    '    Me.MasterPageFile = "~/Tenant" + Session("node_ID").ToString + "/Tenant.master"
    'End Sub
End Class
