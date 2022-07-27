Imports System
Imports System.Data.OleDb
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Data.SqlClient


Partial Class CustEnquiry
    Inherits SessionCheck2
#Region "Pageload"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Button3.Attributes.Add("onclick", "window.close('Authorise.aspx')")
    End Sub
#End Region
#Region "Task"
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        refresh()



    End Sub
    Sub refresh()
        'Dim dv As DataView
        Dim qry As String = ""

        qry = "Exec Proc_CustSearch '" & Me.txtAccountName.Text.Trim.Replace("'", "") & "'," & Session("node_ID") & ""
        If con.SqlDs(qry).Tables(0).Rows.Count > 0 Then
            Try
                GridView1.Visible = True

                GridView1.DataSource = con.SqlDs(qry).Tables(0)
                GridView1.DataBind()
                If Me.GridView1.Rows.Count > 0 Then
                    Me.GridView1.Visible = True

                Else
                    Me.GridView1.Visible = False

                End If


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
            Dim selectedChkBxItem As CheckBox = CType(gv.FindControl("Searchid"), CheckBox)
            If selectedChkBxItem.Checked Then
                chkBox = True
                gvIDs += CType(gv.FindControl("customerid"), Label).Text.ToString
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



    Protected Sub txtAccountName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountName.TextChanged
        Me.GridView1.Visible = False
    End Sub

End Class
