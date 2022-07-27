Imports Telerik.Web.UI

Partial Class Services_EditService
    Inherits System.Web.UI.UserControl
    Dim bll As New BusinessLayer.BLL
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        ' Panel1.Visible = False
        If Page.IsPostBack = False Then

            rebind()

            If Page.IsPostBack = False Then
                RdConnect.SelectedValue = 1
                ' ''txtconstring.Text = "Data Source=.;Initial Catalog=alertz" _
                ' ''                                  & ";User Id=sa;Password=password;"
                'Panel1.Visible = True
                Panel2.Visible = False

                Dim seldetail As String = "exec [proc_selfrequency] "
                smartobj.loadComboValues("--Choose a Frequency--", drpfrequency, seldetail)
                smartobj.loadComboValues("--Choose a Frequency--", drpfrequency0, seldetail)

                Dim seldetail2 As String = "exec [proc_selDispatchtypesms] "
                Dim seldetail3 As String = "exec [proc_selDispatchtypeemail] "
                smartobj.loadRadComboValues("-Choose a SMS Dispatch Type-", drpdispatch, seldetail2)
                smartobj.loadRadComboValues("-Choose Email Dispatch Type-", drpdispatch0, seldetail3)
            End If
        End If
    End Sub

    Sub rebind()
        Dim qrysel As String = "exec [proc_selservicetypelist]"
        'Me.GridView1.DataSource = bll.SQLRecordDs(qrysel)
        'Me.GridView1.DataBind()
        Me.RadGrid1.DataSource = bll.SQLRecordDs(qrysel)
        Me.RadGrid1.DataBind()

       
    End Sub

    'Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged
    '    Try



    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If e.CommandName = "Select" Then
            Panel1.Visible = True
            Dim items As GridDataItem = DirectCast(e.Item, GridDataItem)
            Dim ID As String = items.OwnerTableView.DataKeyValues(items.ItemIndex)("ID").ToString()
            Try
                Dim dr As Data.DataRow
                Dim seldetail As String = "exec proc_selServicetypeid '" & ID & "'"
                dr = bll.SQLRecordDs(seldetail).Rows(0)
                Me.txtdesc.Text = dr.Item("description").ToString
                RdConnect.SelectedValue = dr.Item("datasource").ToString
                drpdispatch.SelectedValue = dr.Item("message_type").ToString
                Me.txtperiods.Text = dr.Item("period").ToString
                drpfrequency.SelectedValue = dr.Item("frequency").ToString

                txt_childprocedure.Text = dr.Item("child_procedure").ToString
                Me.txt_parentprocedure.Text = dr.Item("parent_procedure").ToString
                txtconstring1.Text = dr.Item("defaultmsg").ToString
            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Sub RdConnect_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RdConnect.SelectedIndexChanged
        Try
            If RdConnect.SelectedValue = 1 Then
                Me.Panel5.Visible = True
                Me.Panel2.Visible = False
                'Me.Panel4.Visible = False

            Else
                Me.Panel2.Visible = True
                Me.Panel5.Visible = False
                'Me.Panel4.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
