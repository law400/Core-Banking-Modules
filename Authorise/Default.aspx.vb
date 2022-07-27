Imports System.Web.UI.WebControls

Partial Class Setup_Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            If Request.QueryString("id") <> "" Then
                Profile.parentid = Request.QueryString("id")
            End If
               Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
            ll.Text = "Setup"
        End If
    End Sub
End Class
