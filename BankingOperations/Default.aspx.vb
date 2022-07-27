Imports System.Web.UI.WebControls
Imports log4net
Imports log4net.Config
Partial Class Reports_Default
    Inherits System.Web.UI.Page
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(Reports_Default))
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            If Request.QueryString("id") <> "" Then
                Profile.parentid = Request.QueryString("id")
            End If
            Dim ll As Label = CType(Page.Master.FindControl("Label3"), Label)
            ll.Text = "Banking"
        End If
    End Sub
End Class
