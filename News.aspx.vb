
Partial Class News
    Inherits SessionCheck

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then

            Dim selnews As String = "Select * from tbl_bulletin where status=1"
            Me.GridView1.DataSource = con.SqlDs(selnews).Tables(0)
            Me.GridView1.DataBind()
        End If
    End Sub
End Class
