Imports System.Web.UI.WebControls
Partial Class Reports_Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            If Request.QueryString("id") <> "" Then
                Profile.parentid = Request.QueryString("id")
            End If
        End If
    End Sub
End Class
