
Partial Class PrimeError
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            Dim strsessionKill As String = "exec sessionKll '" & Profile.Userid & "'"
            con.SqlDs(strsessionKill)
            Dim selSession As String = "Update tbl_userprofile set sessionid=0,loginstatus=0 where userid ='" & Profile.Userid & "'"
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
        Response.Redirect("~/default.aspx")
        
    End Sub
End Class
