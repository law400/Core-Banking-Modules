Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Drawing
Partial Class CustomerService_Account_BVM
    Inherits SessionCheck2
    Implements IRequiresSessionState



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' '' ''If Not Me.Page.IsPostBack Then
        ' '' ''    Me.RadGrid1.Visible = False
        ' '' ''    'Me.GridView1.Visible = False
        ' '' ''    'If (Me.Profile.Userid = "") Then
        ' '' ''    'Me.Response.Redirect("Default.aspx")
        ' '' ''    'End If


        ' '' ''End If

        If Page.IsPostBack = False Then

            If Session("UserID") = Nothing Then
               Response.Redirect("~/PageExpire.aspx")
            End If


            Dim productname As String = "SELECT cast(ltrim(rtrim(productcode)) as varchar) productcode,productname FROM tbl_Bankproduct "
            smartobj.loadComboValues("--Select product --- ", Me.DrpProductCode, productname)


            Dim Account_tier As String = "SELECT cast(ltrim(rtrim(tier_id)) as varchar) tier_id,tier_name FROM tbl_Account_Tier "
            smartobj.loadComboValues("--Select Account Tier--- ", Me.DrpAccount_tier, Account_tier)
            'Dim qry As String = ""

        End If

    End Sub


    'Public Sub refreshOld()
    '    Try
    '        Dim time2 As DateTime
    '        Dim sqlString As String = ""
    '        'time2 = Conversions.ToDate(Me.RadDatePicker1.SelectedDate)
    '        sqlString = ((sqlString & "Exec [Proc_RptRisksummary] '") & Me.TextBox1.Text.Trim() & "'")
    '        Me.SqlDataSource1.ConnectionString = ConfigurationManager.ConnectionStrings.Item("Prime").ConnectionString
    '        Me.SqlDataSource1.SelectCommandType = SqlDataSourceCommandType.Text
    '        Me.SqlDataSource1.SelectCommand = sqlString
    '        Me.SqlDataSource1.DataBind()
    '        Me.RadGrid1.DataBind()
    '        Me.RadGrid1.Visible = True
    '        'Me.GridView1.DataBind()
    '        'Me.GridView1.Visible = True



    '    Catch exception1 As Exception
    '        ProjectData.SetProjectError(exception1)
    '        Dim exception As Exception = exception1
    '        ProjectData.ClearProjectError()
    '    End Try
    'End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    If (Me.TextBox1.Text.Trim() = Nothing) Then
    '        smartobj.alertwindow(Me.Page, "Enter a Valid Date", "Prime")
    '    End If
    '    Me.refresh()
    '    Me.DropDownList1.SelectedValue = 0
    'End Sub

    'Protected Sub RadGrid1_ExportCellFormatting(ByVal sender As Object, ByVal e As Telerik.Web.UI.ExportCellFormattingEventArgs) Handles RadGrid1.ExportCellFormatting
    '    If e.FormattedColumn.UniqueName = "accountnumber" Then
    '        'To export in text format
    '        e.Cell.Style("mso-number-format") = "\@"
    '    End If
    '    If e.FormattedColumn.UniqueName = "settlementacct" Then
    '        'To export in text format
    '        e.Cell.Style("mso-number-format") = "\@"
    '    End If
    '    If e.FormattedColumn.UniqueName = "startdate" Then
    '        'To export in text format
    '        e.Cell.Style("mso-number-format") = "\@"
    '    End If
    '    If e.FormattedColumn.UniqueName = "maturitydate" Then
    '        'To export in text format
    '        e.Cell.Style("mso-number-format") = "\@"
    '    End If

    'End Sub

    Protected Sub RadGrid1_GroupsChanging(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridGroupsChangingEventArgs) Handles RadGrid1.GroupsChanging
        Me.refresh()
    End Sub

    Protected Sub RadGrid1_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        Me.refresh()
    End Sub


    Protected Sub RadGrid1_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGrid1.PageIndexChanged
        Me.refresh()
    End Sub

    Protected Sub RadGrid1_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles RadGrid1.SortCommand
        Me.refresh()
    End Sub

    Protected Sub RadGrid2_GroupsChanging(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridGroupsChangingEventArgs) Handles RadGrid2.GroupsChanging
        Me.refresh()
    End Sub

    Protected Sub RadGrid2_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid2.ItemCommand
        Me.refresh()
    End Sub


    Protected Sub RadGrid2_PageIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGrid2.PageIndexChanged
        Me.refresh()
    End Sub

    Protected Sub RadGrid2_SortCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles RadGrid2.SortCommand
        Me.refresh()
    End Sub



    'Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    'If Not Me.Page.IsPostBack Then
    '    'smartobj.alertwindow(Me.Page, "No Data to Export!!!", "Prime")
    '    'End If

    '    If RadGrid1.Visible = False Then
    '        smartobj.alertwindow(Me.Page, "No Data to Export!!!", "Prime")

    '    ElseIf Me.DropDownList1.SelectedValue = 1 Then
    '        ' RadGrid1.MasterTableView.GetColumn("TemplateColumn").Visible = False

    '        Me.RadGrid1.MasterTableView.ExportToExcel()

    '    ElseIf Me.DropDownList1.SelectedValue = 2 Then
    '        'RadGrid1.MasterTableView.GetColumn("TemplateColumn").Visible = False
    '        Me.RadGrid1.MasterTableView.ExportToCSV()

    '    ElseIf Me.DropDownList1.SelectedValue = 3 Then
    '        'RadGrid1.MasterTableView.GetColumn("TemplateColumn").Visible = False
    '        Me.RadGrid1.MasterTableView.ExportToPdf()

    '    ElseIf Me.DropDownList1.SelectedValue = 4 Then
    '        'RadGrid1.MasterTableView.GetColumn("TemplateColumn").Visible = False
    '        Me.RadGrid1.MasterTableView.ExportToWord()

    '    End If
    'End Sub



    Sub refresh()
        If RadioButtonList1.SelectedValue = Nothing Then
            smartobj.alertwindow(Me.Page, "Please select option ", "prime")
            Exit Sub

        End If


        If RadioButtonList1.SelectedValue = 1 Then

            Try           'dt1 = CDate(Me.txtDate.Text.Trim)

                Dim qry As String = ""

                qry = qry & "Exec proc_DYA_Account_That_Have_BVM_Captured "
                qry = qry & smartobj.EncoteWithSingleQuote(Format(Me.TxtAccountNumber.Text)) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Format(Me.DrpProductCode.SelectedValue)) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Format(Me.TxtPhone_number.Text)) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Format(Me.DrpAccount_tier.SelectedValue)) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Format(Me.TxtBVM.Text)) & ""

                Me.RadGrid1.DataSource = con.SqlDs(qry)
                Me.RadGrid1.DataBind()
                Me.RadGrid1.Visible = True

            Catch ex As Exception

            End Try

        Else
            Try           'dt1 = CDate(Me.txtDate.Text.Trim)


                Dim qry As String = ""

                qry = qry & "Exec proc_DYA_Account_That_Do_not_Have_BVM_Captured "
                qry = qry & smartobj.EncoteWithSingleQuote(Format(Me.TxtAccountNumber.Text)) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Format(Me.DrpProductCode.SelectedValue)) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Format(Me.TxtPhone_number.Text)) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Format(Me.DrpAccount_tier.SelectedValue)) & ""


                Me.RadGrid2.DataSource = con.SqlDs(qry)
                Me.RadGrid2.DataBind()
                Me.RadGrid2.Visible = True

            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Sub BtnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        refresh()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        '' ''If Not Me.Page.IsPostBack Then
        '' ''smartobj.alertwindow(Me.Page, "No Data to Export!!!", "Prime")
        '' ''End If


        ' ''If Me.DropDownList1.SelectedValue = 1 Then
        ' ''    ' RadGrid1.MasterTableView.GetColumn("TemplateColumn").Visible = False

        ' ''    Me.RadGrid1.MasterTableView.ExportToExcel()

        ' ''Else : Me.DropDownList1.SelectedValue = 2
        ' ''    'RadGrid1.MasterTableView.GetColumn("TemplateColumn").Visible = False
        ' ''    Me.RadGrid1.MasterTableView.ExportToCSV()


        ' ''End If


        Try
            'Me.Panel3.Visible = True
            If Me.DropDownList1.SelectedValue = 1 Then
                'RadGrid2.MasterTableView.GetColumn("TemplateColumn").Visible = False
                If RadGrid1.Visible = True Then
                    RadGrid1.MasterTableView.ExportToExcel()
                End If
                If RadGrid2.Visible = True Then
                    RadGrid2.MasterTableView.ExportToExcel()
                End If

            End If
            If Me.DropDownList1.SelectedValue = 3 Then
                'RadGrid2.MasterTableView.GetColumn("TemplateColumn").Visible = False
                If RadGrid1.Visible = True Then
                    RadGrid1.MasterTableView.ExportToCSV()
                End If
                If RadGrid2.Visible = True Then
                    RadGrid2.MasterTableView.ExportToCSV()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedValue = 1 Then
            Me.TxtBVM.Visible = true
            Me.LblBVM.Visible = true

            'Me.RadGrid2.Visible = false
            Me.LblBVM_Captured.Text = "ACCOUNT WITH BVM CATPTURED "
            
            Me.RadGrid2.Visible = False

        Else
            Me.TxtBVM.Visible = False
            Me.LblBVM.Visible = False
            Me.LblBVM_Captured.Text = "ACCOUNT WITHOUT BVM  "
            Me.RadGrid1.Visible = False
            'Me.RadGrid2.Visible = True
        End If
    End Sub

    Protected Sub ButReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButReturn.Click
        Response.Redirect("~/Home.aspx")
    End Sub
End Class
