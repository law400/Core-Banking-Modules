Imports System.Web.UI.WebControls
Partial Class BankingOperations_GLCustEnquiry
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

        qry = "Exec Proc_GLCustSearch '" & Me.txtAccountName.Text.Trim.Replace("'", "") & "'," & Me.RDOption.SelectedValue.Trim & ""
        If con.SqlDs(qry).Tables(0).Rows.Count > 0 Then
            Try
                GridView1.Visible = True

                GridView1.DataSource = con.SqlDs(qry).Tables(0)
                GridView1.DataBind()
                Me.GridView1.Visible = True

            Catch ex As Exception
                smartobj.alertwindow(Me.Page, "Data Warnning error...", "Prime")
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
            Dim selectedChkBxItem As CheckBox = CType(gv.FindControl("Searchid"), CheckBox)
            If selectedChkBxItem.Checked Then
                chkBox = True
                gvIDs += CType(gv.FindControl("Accountnumber"), Label).Text.ToString
            End If
        Next

        Try

            Button2.Enabled = False
            'Button3.Text = "Close"
            returnToPage(gvIDs)
        Catch ex As Exception

        End Try

    End Sub
    Sub returnToPage(ByVal staffid As String)
        Response.Write("<script>window.opener." + Request.QueryString("field").ToString() + ".value='" + staffid + "';window.close();</script>")
    End Sub
#End Region

  
End Class
