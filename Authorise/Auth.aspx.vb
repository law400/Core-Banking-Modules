
Partial Class Authorise_Auth
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then

            'If Profile.Authori <> "1" Then
            '    Response.Redirect("~/default.aspx")
            'End If

            '' Dim qry As String = "Select * from tbl_authlist where authstatus='" & "U" & "' and authid='" & Session("Userid") & "'"
            '' Dim qry As String = "exec proc_authpriv '" & Session("Userid") & "'"
            Dim qry As String = "exec proc_authpriv '" & Session("Userid").Trim & "', " & Session("node_id") & ""

            Me.GridView1.DataSource = con.SqlDs(qry).Tables(0)
            Me.GridView1.DataBind()

            'If GridView1.Rows.Count < 1 Then
            '    If Profile.keep = Nothing Or Profile.keep = "" Then

            '        If Request.QueryString("id") <> Nothing Then
            '            returnToPage()
            '        End If


            '    End If
            'End If
        End If
      

    End Sub
    Sub returnToPage()
        Response.Write("<script>window.close();</script>")
    End Sub
    Protected Sub BtnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReturn.Click
        'Response.Redirect("~/Home.aspx")
        'If Profile.keep <> Nothing Or Profile.keep <> "" Then
        '    Profile.keep = ""
        Response.Redirect("~/Dashboard.aspx")
        'Else
        '    returnToPage()

        'End If


        ' End If

    End Sub

    'Protected Sub BtnReturn0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReturn0.Click
    '    Response.Redirect("~/Home.aspx")

    'End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class
