
Partial Class Authorise_authlist
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.BtnReturn.Attributes.Add("onclick", "window.close('Authorise.aspx')")
        If Page.IsPostBack = False Then
            Try
                refresh()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Sub refresh()
        Dim str As String = "exec proc_BatchDetail '" & Session("batchno") & "'"
        Me.GridView2.DataSource = con.SqlDs(str).Tables(0)
        Me.GridView2.DataBind()
        Me.GridView2.Visible = True
    End Sub
    Protected Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged

        refresh()
    End Sub

    Protected Sub BtnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReturn.Click
        Response.Write("<script>window.close();</script>")

    End Sub
End Class
