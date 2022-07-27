Imports System.Web.UI.WebControls
Partial Class CustomerService_ChequeRequestList
    Inherits SessionCheck
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = "CUSTOMER SERVICE"
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        If Page.IsPostBack = False Then
          
            bind2()
        End If


    End Sub
    Sub bind2()
        Dim selBind As String = "select accountnumber,b.typedesc,c.branchname 'source',c.branchname 'Destin',a.numberofleaves,valuedate from tbl_CheqRequest a,tbl_checkbooks b,tbl_branch c where a.chktype=b.typeid and a.sourcebr=c.branchcode and a.destbr=c.branchcode and a.status=" & "1" & ""
        If con.SqlDs(selBind).Tables(0).Rows.Count > 0 Then
            GridView2.DataSource = con.SqlDs(selBind)
            GridView2.DataBind()
            Me.GridView2.Visible = True
        Else
            Me.GridView2.Visible = False
        End If

    End Sub

    Protected Sub BtnReturn2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReturn2.Click
        Response.Redirect("Default.aspx")
    End Sub
End Class
