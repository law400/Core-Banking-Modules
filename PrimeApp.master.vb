Imports System.Data
Imports System.Net
Imports System.Xml
Imports Microsoft.VisualBasic
Imports System.Web.UI
Imports System.IO
Imports System.Xml.Serialization
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web.Configuration

Partial Class PrimeApp
    Inherits System.Web.UI.MasterPage
 Public qry As String
    Private _userName As String = ""

    Private _enablepersonalization As Boolean = False
    'Private _lable2 As Label
 Dim profileImg As String = ""
    Public Property ProfileImage() As String
        Get
            Return profileImg
        End Get
        Set(value As String)
            profileImg = value
        End Set
    End Property
    Public Property enablepersonalization() As Boolean

        Get

            Return _enablepersonalization

        End Get

        Set(ByVal Value As Boolean)

            _enablepersonalization = Value

        End Set

    End Property

    Public Function GetDataTop(query As String, Value1 As Integer, Value2 As String, Value3 As Integer) As DataTable
        Dim dt As New DataTable()
        Dim constr As String = ConfigurationManager.ConnectionStrings("Prime").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query)
                Using sda As New SqlDataAdapter()
                    cmd.Parameters.Add(New SqlParameter("@roleid", Value1))
                    cmd.Parameters.Add(New SqlParameter("@userid", Value2))
                    cmd.Parameters.Add(New SqlParameter("@node_id", Value3))
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    sda.Fill(dt)
                End Using
            End Using
            Return dt
        End Using
    End Function

    Public Function GetDataChild(query As String, Value1 As Integer, Value2 As String, Value3 As String, Value4 As Integer) As DataTable
        Dim dt As New DataTable()
        Dim constr As String = ConfigurationManager.ConnectionStrings("Prime").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query)
                Using sda As New SqlDataAdapter()
                    cmd.Parameters.Add(New SqlParameter("@roleid", Value1))
                    cmd.Parameters.Add(New SqlParameter("@parent", Value2))
                    cmd.Parameters.Add(New SqlParameter("@userid", Value3))
                    cmd.Parameters.Add(New SqlParameter("@node_id", Value4))
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    sda.Fill(dt)
                End Using
            End Using
            Return dt
        End Using
    End Function
    Protected Sub rptMenu_ItemDataBound(ByVal sender As Object, ByVal e As RepeaterItemEventArgs)
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim rptSubMenu As Repeater = TryCast(e.Item.FindControl("rptChildMenu"), Repeater)

            'rptSubMenu.DataSource = GetData("SELECT Menu_id,Menu_Name,Url FROM tbl_menu WHERE Parent =" & (CType((e.Item.DataItem), System.Data.DataRowView)).Row(0))

            '  Dim rows As System.Data.DataRow = (CType((e.Item.DataItem), System.Data.DataRow))


            Dim Qry As String = "Proc_UserMenu"
            Dim DatRowView As DataRowView = (CType((e.Item.DataItem), DataRowView))
            Dim Parent As String = Convert.ToString(DatRowView("Menu_Id"))
            Dim MenuName As String = Convert.ToString(DatRowView("Menu_Name"))
            rptSubMenu.DataSource = GetDataChild(Qry, Session("Roleid"), Parent, Session("Userid"), Session("node_ID"))
            ' rptSubMenu.DataSource = con.SqlDs(Qry)
            rptSubMenu.DataBind()

            '   lbldisplay.Text = MenuName
            '    Dim parentactive As HtmlGenericControl = CType(rptMenu.FindControl("parentli"), HtmlGenericControl)
            ' parentactive.Attributes.Add("class", "parent")
        End If
    End Sub
    Private Sub BindMenu()
        Dim Qry As String = "Proc_TopMenuList"
        ' Me.rptMenu.DataSource = GetData("exec [Proc_TopMenuList] '" & Session("Roleid") & "','" & Session("Userid") & "'," & Session("node_ID") & "")

        '  Me.rptMenu.DataSource = con.SqlDs(Qry)
        Me.rptMenu.DataSource = GetDataTop(Qry, Session("Roleid"), Session("Userid"), Session("node_ID"))
        Me.rptMenu.DataBind()
        '  myli.Attributes["class"] = "myClass"
        'parentli.Attributes("Parent")



    End Sub
    Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        'page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)

        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastr_message", toastrScript, True)
    End Sub
    Private Sub PrimeApp_Load(sender As Object, e As EventArgs) Handles Me.Load
        'If Not Me.Page.User.Identity.IsAuthenticated Then
        '    FormsAuthentication.RedirectToLoginPage()
        'End If

        If Session("Userid") = Nothing Then
            '' FormsAuthentication.RedirectToLoginPage()
            Response.Redirect("~/Default.aspx")
        End If

        If Session("node_id") = Nothing Then
            '' FormsAuthentication.RedirectToLoginPage()
            Response.Redirect("~/Default.aspx")
        End If
        If Session("node_id") = "" Then
            '' FormsAuthentication.RedirectToLoginPage()
            Response.Redirect("~/Default.aspx")
        End If
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If Not Me.IsPostBack Then
            Session("Reset") = True
            Dim config As Configuration = WebConfigurationManager.OpenWebConfiguration("~/Web.Config")
            Dim section As SessionStateSection = DirectCast(config.GetSection("system.web/sessionState"), SessionStateSection)
            Dim timeout As Integer = CInt(section.Timeout.TotalMinutes) * 1000 * 60
            '' Page.ClientScript.RegisterStartupScript(Me.GetType(), "SessionAlert", "SessionExpireAlert(" & timeout & ");", True)
            ScriptManager.RegisterStartupScript(Page, GetType(Page), "SessionAlert", "SessionExpireAlert(" & timeout & ");", True)
        End If
        If Not Me.IsPostBack Then
            Me.BindMenu()
            Dim Str100 As String = "Select ltrim(rtrim(upper(Bankname))) BankName from tbl_bank where node_id=" & Session("node_ID")
            If con.SqlDs(Str100).Tables(0).Rows.Count > 0 Then
                drx = con.SqlDs(Str100).Tables(0).Rows(0)
                Me.LblCoop.Text = drx.Item("BankName").ToString

            End If

            Dim str101 As String = "select ltrim(rtrim(b.imgpath)) imgpath  from tbl_bank a, Tbl_Uploads b where  a.LogoPathId=b.Record_Id and a.node_id=" & Session("node_ID")
            If con.SqlDs(str101).Tables(0).Rows.Count > 0 Then
                drx = con.SqlDs(str101).Tables(0).Rows(0)
             ''   Me.ImgLogo.ImageUrl = drx.Item("imgpath").ToString

            End If
        End If
        'Dim filePath As String = "https://solutions.cooplatform.com.ng/upl/"
        '      qry = "select LogoPathId  from tbl_Bank where node_id=  " & Session("NodE_id")
        '      For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows


        '          qry = "select ImgName  from Tbl_Uploads where Record_Id ='" & dr("LogoPathId") & "'"
        '          For Each dr1 As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
        '              ProfileImage = filePath + dr1(0).ToString
        '          Next
        '      Next
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'If Session("Userid") = Nothing Then
        '    FormsAuthentication.RedirectToLoginPage()
        'End If
        'Dim filePath As String = "https://solutions.cooplatform.com.ng/upl/"
        '      qry = "select LogoPathId  from tbl_Bank where node_id=  " & Session("NodE_id")
        '      For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows


        '          qry = "select ImgName  from Tbl_Uploads where Record_Id ='" & dr("LogoPathId") & "'"
        '          For Each dr1 As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
        '              ProfileImage = filePath + dr1(0).ToString
        '          Next
        '      Next
    End Sub
    Protected Sub btnLogoutNow_click(ByVal sender As Object, ByVal e As EventArgs)
        Dim strsessionKill As String = "exec sessionKll '" & Session("userid") & "', " & Session("NodE_id") & ""
        con.SqlDs(strsessionKill)
        Dim selSession As String = "Update tbl_userprofile set sessionid=0,loginstatus=0,logincount=0 where userid ='" & Session("userid") & "' and node_id = " & Session("NodE_id") & ""
        con.SqlDs(selSession)
        Dim TrackLogOut As String = "Exec Proc_LoginTrack '" & Session("userid") & "','" & Session("SessionID") & "'," & Session("NodE_id") & ""
        con.SqlDs(TrackLogOut)
        Session("authremote") = ""
        Session("authlocal") = ""
        Session.RemoveAll()
        Session.Abandon()
        FormsAuthentication.SignOut()

        FormsAuthentication.RedirectToLoginPage()
    End Sub


End Class

