Imports System.Web.UI.WebControls
Partial Class CustomerService_CoopCustomerReq
    Inherits SessionCheck2

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then

            Dim qry As String = "exec Proc_CooperativeCustReq"

            Me.GridView1.DataSource = con.SqlDs(qry).Tables(0)
            Me.GridView1.DataBind()

           
        End If
    End Sub
    Sub returnToPage()
        Response.Write("<script>window.close();</script>")
    End Sub
    Protected Sub BtnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReturn.Click
       
        Response.Redirect("~/Home.aspx")
        

    End Sub

    Protected Sub BtnReturn0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReturn0.Click
        Response.Redirect("~/Home.aspx")

    End Sub
End Class
