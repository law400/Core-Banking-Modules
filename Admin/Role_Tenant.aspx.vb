Imports System.IO

Partial Class Security_Role_Tenant
    Inherits SessionCheck
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
#Region "Task"
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("roleedit_global.aspx")
    End Sub


    Protected Sub Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Delete.Click

    End Sub

#End Region

#Region "PageLoad"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("Label3"), System.Web.UI.WebControls.Label)
        l.Text = ""
        Dim ll As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("Label4"), System.Web.UI.WebControls.Label)
        ll.Text = "TENANT LIST" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        'Dim menuname As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("lbldisplay"), System.Web.UI.WebControls.Label)
        'menuname.Text = Request.QueryString("XXX")
        'If menuname.Text = "" Then
        '    Response.Redirect("~/Unauthorize.aspx")
        'End If

        'If Validate_Access(menuname.Text) = 0 Then
        '    Response.Redirect("~/Unauthorize.aspx")
        'End If

        If Page.IsPostBack = False Then

            Dim Dstring As String = "SELECT [Tenant], [Node_id] FROM [tbl_Tenants] where status = 1"
            'smartobj.loadComboValues("--Select a Function--- ", Me.DrpRole, Dstring3)
            Me.GridView1.DataSource = con.SqlDs(Dstring).Tables(0)
            Me.GridView1.DataBind()
        End If
        Me.Delete.Visible = False
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
#End Region

    'Protected Sub Btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btncancel.Click
    '    Response.Redirect("Default.aspx")
    'End Sub
    'Protected Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
    '    Me.MasterPageFile = "~/Tenant" + Session("node_ID").ToString + "/Tenant.master"
    'End Sub
End Class
