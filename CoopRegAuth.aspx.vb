Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
'Imports System.Web.Mail
Imports System.Net.Mail.MailMessage
Imports System.Net
Imports System.Net.Mail
Imports System.Web.Configuration
Imports System.Net.Configuration
Imports System.IO
Imports System.Security.Cryptography
Imports Telerik.Web.UI
'Imports System.Web.Mail

Imports System
Imports System.Web.UI.WebControls
Partial Class CoopRegAuth
    Inherits SessionCheck
    Dim qry As String
    Dim retval As Integer

    Protected Sub Gridview1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName.Equals("Refresh") Then
            Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)


        ElseIf e.CommandName.Equals("RebindGrid") Then
            GridView1.DataBind()
            ''     Panel4.Visible = False

            'ElseIf e.CommandName.Equals("FooterInsert") Then
            '    ' Retrieve controls
            '    Dim txtCompanyName As TextBox = TryCast(gvSuppliers.FooterRow.FindControl("txtCompanyName"), TextBox)
            '    Dim txtPhone As TextBox = TryCast(gvSuppliers.FooterRow.FindControl("txtPhone"), TextBox)

            '    If txtCompanyName Is Nothing Then
            '        Return
            '    End If
            '    If txtPhone Is Nothing Then
            '        Return
            '    End If

            '    ' Set parameters
            '    sdsSuppliers.InsertParameters("CompanyName").DefaultValue = txtCompanyName.Text
            '    sdsSuppliers.InsertParameters("Phone").DefaultValue = txtPhone.Text

            '    ' Perform insert
            '    sdsSuppliers.Insert()
        End If
    End Sub
    Sub BindToGrid()
        Try
            Dim status As String = "o"
            Dim Item As String = "select * from Reg_table where status  = 'Activated' or status = 'Approved'"
            'Me.RadGrid1.DataSource = con.SqlDs(Item)
            'Me.RadGrid1.DataBind()

            Me.GridView1.DataSource = con.SqlDs(Item)
            Me.GridView1.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CoopRegAuth_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = ""
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "COOP REGISTRATION REQUEST" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim

        Dim menuname As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("lbldisplay"), System.Web.UI.WebControls.Label)
        menuname.Text = Request.QueryString("XXX")
        'If menuname.Text = "" Then
        '    Response.Redirect("~/Unauthorize.aspx")
        'End If

        'If Validate_Access(menuname.Text) = 0 Then
        '    Response.Redirect("~/Unauthorize.aspx")
        'End If

        BindToGrid()
    End Sub
    Function Validate_Access(ByVal MenuName As String) As Integer

        qry = " declare @retVal int " & vbNewLine
        qry = qry & "execute Proc_RM_Validate "
        qry = qry & smartobj.EncoteWithSingleQuote(Session("Roleid")) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(MenuName) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Session("Userid")) & ",@retVal OUTPUT," & Session("node_id") & " "
        qry = qry & " select @retVal"

        For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
            retval = dr(0).ToString
        Next
        Return retval
    End Function
    Protected Sub Gridview1_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim editLinkDetail As LinkButton = DirectCast(e.Row.FindControl("editLinkDetail"), LinkButton)
            Dim Status As Label = DirectCast(e.Row.FindControl("Label_Status"), Label)
            Dim SendEmailAccess As LinkButton = DirectCast(e.Row.FindControl("ResendEmailLink"), LinkButton)

            SendEmailAccess.Visible = False
            If Status.Text = "Approved" Then

                SendEmailAccess.Visible = True
                editLinkDetail.Visible = False
            Else

                SendEmailAccess.Visible = False
                editLinkDetail.Visible = True
            End If
            If SendEmailAccess IsNot Nothing Then
                Dim iID As Integer = Integer.Parse(GridView1.DataKeys(e.Row.RowIndex).Values(0).ToString())
                SendEmailAccess.Attributes("href") = "javascript:void(0);"
                SendEmailAccess.Attributes("onclick") = [String].Format("return ResendAccessLink('{0}','{1}');", iID, e.Row.RowIndex)
            End If
            If editLinkDetail IsNot Nothing Then
                Dim iID As Integer = Integer.Parse(GridView1.DataKeys(e.Row.RowIndex).Values(0).ToString())
                '  editLinkDetail.Attributes.Add("onclick", "window.open('ViewRegdetail.aspx?UniqueID=" + iID + "')")

                editLinkDetail.Attributes("href") = "javascript:void(0);"
                editLinkDetail.Attributes("onclick") = [String].Format("return ShowRegDetail('{0}','{1}');", iID, e.Row.RowIndex)
            End If
        End If
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GridView1.DataBind()
    End Sub
End Class
