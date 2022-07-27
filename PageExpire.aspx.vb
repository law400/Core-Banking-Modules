
Partial Class PageExpire
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim strsessionKill As String = "exec sessionKll '" & Session("Userid") & "'"
            con.SqlDs(strsessionKill)
            Dim selSession As String = "Update tbl_userprofile set sessionid=0,loginstatus=0,logincount=0 where userid ='" & Session("Userid") & "'"
            con.SqlDs(selSession)
            Profile.AuthRemote = ""
            Profile.AuthLocal = ""

            'If Profile.Authori = "1" Then
            '    Response.Write("<script>window.close('http://localhost:1590/Infobanker/Authwatch.aspx');</script>")
            'End If
        Catch ex As Exception
            smartobj.alertwindow(Me.Page, "System Processing Error", "Prime")
            Exit Sub
        End Try
    End Sub

   
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        ''Dim qry4 As String = "Delete from tbl_LoginCounter where Username = '" & Session("username") & "'and SessionID = '" & Session.SessionID.ToString() & "'"
        ''con.SqlDs(qry4)
        ''Dim qry5 As String = "update tbl_users set loginstatus = 0 where loginstatus = 1 and Username='" & Session("username") & "'and Password = '" & Session("userpassword") & "'  "
        ''con.SqlDs(qry5)
        Response.Cache.SetAllowResponseInBrowserHistory(False)
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1))
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetNoStore()
        'If Page.IsPostBack Then
        Session("username") = " "
        Session("userpassword") = " "
        Session("Role") = " "
        Session.Abandon()
        Session.Clear()
        Response.Buffer = True
        Response.CacheControl = "no-cache"
        Response.AppendHeader("Cache-Control", "no-store")
        Response.AddHeader("Pragma", "no-cache")
        Response.Expires = -1
        Session.RemoveAll()
        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache)
        Response.Cache.SetNoStore()
        Response.Cache.SetExpires(DateTime.Now)
        'HttpContext.Current.Response.Redirect("~/PageExpire.aspx", True)

        'PreviousPage.Dispose()
    End Sub
End Class
