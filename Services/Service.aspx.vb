
Partial Class Services_Service
    Inherits System.Web.UI.Page
    Dim retval As Integer
    Dim retmsg As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not IsPostBack Then
            RadTabStrip1.Visible = True
            If Request.QueryString("id") <> Nothing Then
                Me.RadPageView2.Focus()
            End If
        End If
    End Sub

    Protected Sub RadTabStrip1_TabClick(sender As Object, e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStrip1.TabClick
        ''Page.DataBind()
    End Sub
End Class
