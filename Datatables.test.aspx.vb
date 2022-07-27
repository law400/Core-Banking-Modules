Imports Telerik.Web.UI
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
'Imports System.Web.Mail
Imports System.Net.Mail.MailMessage
'Imports System.Net
Imports System.Net.Mail
Imports System.Web.Configuration
Imports System.Net.Configuration
Imports System.IO
Imports System.Security.Cryptography
Imports System
Imports System.Web.UI.WebControls
Partial Class Datatables_test
    Inherits System.Web.UI.Page


    Sub BindToGrid()
        Try
            Dim status As String = "o"
            Dim Item As String = "select * from Memcos_Reg_table where node_id  = '" & Profile.node_ID & "' and status  = 'Pending'"
            Me.RadGrid1.DataSource = con.SqlDs(Item)
            Me.RadGrid1.DataBind()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Datatables_test_Load(sender As Object, e As EventArgs) Handles Me.Load
        BindToGrid()
    End Sub

    Protected Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim Item As String = "select * from Memcos_Reg_table where node_id  = '" & Profile.node_ID & "' "
        Me.RadGrid1.DataSource = con.SqlDs(Item)
    End Sub

    Protected Sub RadGrid1_ItemCreated(ByVal sender As Object, ByVal e As GridItemEventArgs)


        If TypeOf e.Item Is GridDataItem Then

            Dim editLinkDetail As ImageButton = DirectCast(e.Item.FindControl("editLinkDetail"), ImageButton)
            editLinkDetail.Attributes("href") = "javascript:void(0);"
            editLinkDetail.Attributes("onclick") = [String].Format("return ShowRegDetail('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues(e.Item.ItemIndex)("Employeeid"), e.Item.ItemIndex)

        End If
    End Sub


End Class
