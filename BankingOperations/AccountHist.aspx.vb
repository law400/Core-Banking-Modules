Imports System.Web.UI.WebControls
Imports log4net
Imports log4net.Config
Partial Class BankingOperations_AccountHist
    Inherits SessionCheck2
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(BankingOperations_AccountHist))
#Region "Pageload"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Button3.Attributes.Add("onclick", "window.close('Authorise.aspx')")
    End Sub
#End Region
#Region "Task"
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Dim dv As DataView
        Dim qry As String = ""

        qry = "Exec Proc_RptHist '" & Me.txtAccountName.Text.Trim & "'"

        Try
            If con.SqlDs(qry).Tables(0).Rows.Count > 0 Then

                GridView1.Visible = True

                GridView1.DataSource = con.SqlDs(qry).Tables(0)
                GridView1.DataBind()
                Me.GridView1.Visible = True

       

            Else
                Me.GridView1.Visible = False
            End If
        Catch ex As Exception

            smartobj.alertwindow(Me.Page, "No Record In List", "Prime")

            Exit Sub
        End Try


    End Sub


    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
      
        Try

            Button2.Enabled = False
            'Button3.Text = "Close"
            returnToPage(0)
        Catch ex As Exception

        End Try

    End Sub
    Sub returnToPage(ByVal staffid As String)
        Response.Write("<script>window.close();</script>")
    End Sub
#End Region
End Class
