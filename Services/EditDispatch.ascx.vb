Imports Telerik.Web.UI
Partial Class Services_EditDispatch
    Inherits System.Web.UI.UserControl
    Dim bll As New BusinessLayer.BLL
    Sub checkdetail()
        Try
            If Me.RDmessage.SelectedValue = 1 Then
                Panel1.Visible = True
                Panel2.Visible = False
            Else
                Panel2.Visible = True
                Panel1.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub rebind()
        Dim qrysel As String = "exec [proc_selDispatchtype]"
        'Me.GridView1.DataSource = bll.SQLRecordDs(qrysel)
        'Me.GridView1.DataBind()
        Me.RadGrid1.DataSource = bll.SQLRecordDs(qrysel)
        Me.RadGrid1.DataBind()


    End Sub
    Sub detail()
        Dim dr As Data.DataRow
        Dim seldetail As String = "exec proc_seldispatch '" & Me.drpdesc.SelectedValue.Trim & "'"
        dr = bll.SQLRecordDs(seldetail).Rows(0)

        RDmessage.SelectedValue = dr.Item("message_type").ToString
        checkdetail()
        txtreorder.Text = dr.Item("reorder_level").ToString
        txtemail.Text = dr.Item("email").ToString
        txtphone.Text = dr.Item("phone").ToString
        txtwebsite.Text = dr.Item("website").ToString
        RDUsage.SelectedValue = dr.Item("usage").ToString
        txtgateway.Text = dr.Item("gateway").ToString
        Me.txtrescode.Text = dr.Item("responsecode").ToString
        txtdllfile.Text = dr.Item("DLLFilename").ToString
        txtfunction.Text = dr.Item("DLLFunction").ToString
        Me.txtsmstpserver.Text = dr.Item("SmtpServer").ToString
        txtusername.Text = dr.Item("Smtpuser").ToString
        txtpassword.Text = dr.Item("smtppassword").ToString
        txtportno.Text = dr.Item("port").ToString
        txtemail.Text = dr.Item("fromemail").ToString
        chk1.Checked = dr.Item("SSLrequired").ToString
    End Sub
    Sub detail2()
        Dim dr As Data.DataRow
        Dim seldetail As String = "exec proc_seldispatch 1"
        dr = bll.SQLRecordDs(seldetail).Rows(0)
        Me.drpdesc.SelectedValue = dr.Item("description").ToString
        RDmessage.SelectedValue = dr.Item("message_type").ToString
        checkdetail()
        txtreorder.Text = dr.Item("reorder_level").ToString
        txtemail.Text = dr.Item("email").ToString
        txtphone.Text = dr.Item("phone").ToString
        txtwebsite.Text = dr.Item("website").ToString
        RDUsage.SelectedValue = dr.Item("usage").ToString
        txtgateway.Text = dr.Item("gateway").ToString
        Me.txtrescode.Text = dr.Item("responsecode").ToString
        txtdllfile.Text = dr.Item("DLLFilename").ToString
        txtfunction.Text = dr.Item("DLLFunction").ToString
        Me.txtsmstpserver.Text = dr.Item("SmtpServer").ToString
        txtusername.Text = dr.Item("Smtpuser").ToString
        txtpassword.Text = dr.Item("smtppassword").ToString
        txtportno.Text = dr.Item("port").ToString
        txtemail.Text = dr.Item("fromemail").ToString
        chk1.Checked = dr.Item("SSLrequired").ToString
    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' Panel3.Visible = False
        If Page.IsPostBack = False Then

            rebind()
            If Page.IsPostBack = False Then
                '' smartobj.Clear_Controls(Me.Page)
                'detail2()
                'RDmessage.SelectedValue = 1

                'Panel1.Visible = True
                'Panel2.Visible = False
                Dim seldetail3 As String = "Exec [proc_selDispatchtype]"
                smartobj.loadRadComboValues("-Choose Dispatch Type-", drpdesc, seldetail3)

            End If
        End If
    End Sub

    Protected Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If e.CommandName = "Select" Then
            Panel3.Visible = True
            Dim items As GridDataItem = DirectCast(e.Item, GridDataItem)
            Dim ID As String = items.OwnerTableView.DataKeyValues(items.ItemIndex)("id").ToString()
            Try
                Dim dr As Data.DataRow
                Dim seldetail As String = "exec proc_seldispatch '" & ID & "'"
                dr = bll.SQLRecordDs(seldetail).Rows(0)

                Me.drpdesc.SelectedValue = dr.Item("description").ToString
                RDmessage.SelectedValue = dr.Item("message_type").ToString
                checkdetail()
                txtreorder.Text = dr.Item("reorder_level").ToString
                txtemail.Text = dr.Item("email").ToString
                txtphone.Text = dr.Item("phone").ToString
                txtwebsite.Text = dr.Item("website").ToString
                RDUsage.SelectedValue = dr.Item("usage").ToString
                txtgateway.Text = dr.Item("gateway").ToString
                Me.txtrescode.Text = dr.Item("responsecode").ToString
                txtdllfile.Text = dr.Item("DLLFilename").ToString
                txtfunction.Text = dr.Item("DLLFunction").ToString
                Me.txtsmstpserver.Text = dr.Item("SmtpServer").ToString
                txtusername.Text = dr.Item("Smtpuser").ToString
                txtpassword.Text = dr.Item("smtppassword").ToString
                txtportno.Text = dr.Item("port").ToString
                txtemail.Text = dr.Item("fromemail").ToString
                chk1.Checked = dr.Item("SSLrequired").ToString
            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Sub RDmessage_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RDmessage.SelectedIndexChanged
        checkdetail()
    End Sub
End Class
