Imports System.Web.UI.WebControls
Partial Class CustomerService_CustAccountInfo
    Inherits SessionCheck
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
        Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtaccountnumber.Text.Trim & "',@retval output,@retmsg output, " & Session("node_ID") & " select @retval,@retmsg"
        For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
            retval = dr(0).ToString
            retmsg = dr(1).ToString
        Next

        If retval = "0" Then
            Me.txtaccountnumber.Text = retmsg
        End If

        Dim selExist As String = "Exec Proc_CustAcctDetailInfo '" & Me.txtaccountnumber.Text.Trim & "', " & Session("node_ID") & ""
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


    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReset.Click
        Me.txtphone.Text = ""
        Me.txttitle.Text = ""
        Me.txtaddress.Text = ""
        Me.txtaccountnumber.Text = ""
        Me.GridView1.DataSource = Nothing
        Me.GridView1.DataBind()
        Me.GridView1.Visible = False

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = ""
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "ACCOUNT RECORD" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        Dim menuname As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("lbldisplay"), System.Web.UI.WebControls.Label)

        menuname.Text = Request.QueryString("XXX")
        If menuname.Text = "" Then
            Response.Redirect("~/Unauthorize.aspx")
        End If

        If Validate_Access(menuname.Text) = 0 Then
            Response.Redirect("~/Unauthorize.aspx")
        End If
        If Page.IsPostBack = False Then
            hypsearch.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtaccountnumber.ClientID.ToString() + "');"

        End If
    End Sub
    Function Validate_Access(ByVal MenuName As String) As Integer

        qry = " declare @retVal int " & vbNewLine
        qry = qry & "execute Proc_RM_Validate "
        qry = qry & smartobj.EncoteWithSingleQuote(Session("Roleid")) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(MenuName) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Session("Userid")) & ",@retVal OUTPUT," & Session("node_ID") & " "
        qry = qry & " select @retVal"

        For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
            retval = dr(0).ToString
        Next
        Return retval
    End Function
    'Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
    '    Response.Redirect("Default.aspx")
    'End Sub
    'Protected Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
    '    If Session("node_ID") = Nothing Then
    '        Response.Redirect("../PageExpire.aspx")
    '    Else
    '        Me.MasterPageFile = "~/Tenant" + Session("node_ID").ToString + "/Tenant.master"

    '    End If
    'End Sub
End Class
