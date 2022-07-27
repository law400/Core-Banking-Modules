
Partial Class SignOut
    Inherits System.Web.UI.Page
#Region "Pageload"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
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

            Response.Redirect("~/Default.aspx")
            'If Profile.Authori = "1" Then
            '    Response.Write("<script>window.close('http://localhost:1590/Infobanker/Authwatch.aspx');</script>")
            'End If
        Catch ex As Exception
            smartobj.alertwindow(Me.Page, "System Processing Error", "Prime")
            Exit Sub
        End Try
        '' Response.Redirect("~/default.aspx")
    End Sub
#End Region
    

End Class
