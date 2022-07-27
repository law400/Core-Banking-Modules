
Partial Class CustomerService_AccountEnquiry
    Inherits SessionCheck2
#Region "Pageload"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Button3.Attributes.Add("onclick", "window.close('Authorise.aspx')")
    End Sub
#End Region
#Region "Task"
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Dim dv As DataView
        Dim qry As String = ""

        qry = "Exec Proc_CustSearch '" & Me.txtAccountName.Text.Trim.Replace("'", "") & "', " & Session("node_ID") & ""
        If con.SqlDs(qry).Tables(0).Rows.Count > 0 Then
            Try
                GridView1.Visible = True

                GridView1.DataSource = con.SqlDs(qry).Tables(0)
                GridView1.DataBind()
                Me.GridView1.Visible = True

            Catch ex As Exception
                smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")
                Exit Sub
            End Try

        Else
            Me.GridView1.Visible = False
        End If



    End Sub


    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim gvIDs As String = ""
        Dim chkBox As Boolean = False
        For Each gv As GridViewRow In GridView1.Rows
            Dim selectedChkBxItem As System.Web.UI.WebControls.CheckBox = CType(gv.FindControl("Searchid"), System.Web.UI.WebControls.CheckBox)
            If selectedChkBxItem.Checked Then
                chkBox = True
                gvIDs += CType(gv.FindControl("Accountnumber"), System.Web.UI.WebControls.Label).Text.ToString
            End If
        Next

        Try

            Button2.Enabled = False
            'Button3.Text = "Close"
            returnToPage(gvIDs)
            Session("acctreset") = "1"
        Catch ex As Exception

        End Try

    End Sub
    Sub returnToPage(ByVal staffid As String)
        Response.Write("<script>window.opener." + Request.QueryString("field").ToString() + ".value='" + staffid + "';window.close();</script>")
    End Sub
#End Region
End Class
