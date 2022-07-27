Imports System.Web.UI.WebControls
Partial Class CustomerService_CustAccountInfo
    Inherits System.Web.UI.Page
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
    Protected Sub txtaccountnumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtaccountnumber.TextChanged
        Try
            show()
        Catch ex As Exception

        End Try

    End Sub
    Sub show()
        Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtaccountnumber.Text.Trim & "',@retval output,@retmsg output select @retval,@retmsg"
        For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
            retval = dr(0).ToString
            retmsg = dr(1).ToString
        Next

        If retval = "0" Then
            Me.txtaccountnumber.Text = retmsg
        End If

        Dim selExist As String = "Exec Proc_CustAcctDetailInfo '" & Me.txtaccountnumber.Text.Trim & "'"
        If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then

            drx = con.SqlDs(selExist).Tables(0).Rows(0)

            Me.txttitle.Text = drx.Item("accounttitle").ToString
            Me.txtaddress.Text = drx.Item("address").ToString
            Me.txtphone.Text = drx.Item("phone").ToString

            Me.GridView1.DataSource = con.SqlDs(selExist)
            Me.GridView1.DataBind()
            Me.GridView1.Visible = True

        Else

            'Image1.Visible = False
            Me.GridView1.Visible = False
            smartobj.alertwindow(Me.Page, "Account Number Does Not Exist", "Prime")
            Exit Sub
        End If
    End Sub
   

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Me.txtphone.Text = ""
        Me.txttitle.Text = ""
        Me.txtaddress.Text = ""
        Me.txtaccountnumber.Text = ""
        Me.GridView1.Visible = False

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = "CUSTOMER SERVICE"
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        If Page.IsPostBack = False Then
            hypsearch.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtaccountnumber.ClientID.ToString() + "');"

        End If
    End Sub

    Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        Response.Redirect("Default.aspx")
    End Sub
End Class
