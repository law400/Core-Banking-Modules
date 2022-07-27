Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports log4net
Imports log4net.Config
Imports System.Data.Objects
Partial Class UCP_Deploy_DeductionDownload
    Inherits SessionCheck
    Dim xe As New XAAS_MultiEntities
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(UCP_Deploy_DeductionDownload))
    Protected Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

        Dim w = From d In xe.Memcos_Reg_table
            Select d

        Try
            RadGrid1.DataSource = w.ToList
        Catch ex As Exception

            smartobj.alertwindow(Me.Page, "Error occurred in populating data...", "Prime")
            logger.Info("Manage Vendors: Populate Records in Gridview'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

        End Try

        'If w.Count > 0 Then
        '    btnSubmit.Visible = True
        'Else
        '    btnSubmit.Visible = False
        'End If




    End Sub
    Protected Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        Try
            'Dim qry As String = "Select Distinct b.EmployeeID,CustId 'customerid',EmployeeName,a.AccountNumber,TotalRepayAmt 'MonthlyContri' from tbl_loanscheduledetail a, Memcos_Reg_table b where a.custId = b.customerid and Convert(Char,DateName( Month, Date_Due ) + ' ' + DateName( Year, Date_Due )) = '" & RadMonthYearPicker1.SelectedDate & "'"

            Dim qry As String = "Select Distinct b.EmployeeID,CustId 'customerid',EmployeeName,a.AccountNumber,TotalRepayAmt 'MonthlyContri' from tbl_loanscheduledetail a, Memcos_Reg_table b where a.custId = b.customerid and Convert(Char,DateName( Month, Date_Due ) + ' ' + DateName( Year, Date_Due )) = 'August 2014'"

            RadGrid2.DataSource = con.SqlDs(qry)
        Catch ex As Exception

            smartobj.alertwindow(Me.Page, "Error occurred in populating data...", "Prime")
            logger.Info("Manage Vendors: Populate Records in Gridview'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

        End Try

        'If w.Count > 0 Then
        '    btnSubmit.Visible = True
        'Else
        '    btnSubmit.Visible = False
        'End If




    End Sub
    Protected Sub CheckBoxList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckBoxList1.SelectedIndexChanged


        'For Each li As System.Web.UI.WebControls.ListItem In CheckBoxList1.Items
        '    If li.Value = "1" Then
        '        If li.Selected Then
        '            Contributions.Visible = True
        '        Else
        '            'It is not checked, disable TextBox
        '            Contributions.Visible = True
        '        End If
        '    ElseIf li.Value = "2" Then
        '        If li.Selected Then
        '            Contributions.Visible = True
        '        Else
        '            'It is not checked, disable TextBox
        '            Contributions.Visible = True
        '        End If
        '    ElseIf li.Value = "3" Then
        '        If li.Selected Then
        '            Contributions.Visible = True
        '        Else
        '            'It is not checked, disable TextBox
        '            Contributions.Visible = True
        '        End If
        '    ElseIf li.Value = "4" Then
        '        If li.Selected Then
        '            Contributions.Visible = True
        '        Else
        '            'It is not checked, disable TextBox
        '            Contributions.Visible = True
        '        End If
        '    End If


        'Next
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim l As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("Label3"), System.Web.UI.WebControls.Label)
        l.Text = ""
        Dim ll As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("Label4"), System.Web.UI.WebControls.Label)
        ll.Text = "DEDUCTION DOWNLOAD" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim

        Contributions.Visible = True
        ProjectFinance.Visible = True
        LoanRepay.Visible = True
        PurchaseOfItems.Visible = True
    End Sub
    Protected Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs)
        If e.CommandName = RadGrid.ExportToExcelCommandName Then

            RadGrid1.ExportSettings.IgnorePaging = True
            RadGrid1.ExportSettings.ExportOnlyData = True
            RadGrid1.ExportSettings.OpenInNewWindow = True
        End If
    End Sub
    Protected Sub ButGenerateContib_Click(sender As Object, e As EventArgs) Handles ButGenerateContib.Click

        RadGrid1.ExportSettings.ExportOnlyData = True
        RadGrid1.ExportSettings.IgnorePaging = True
        RadGrid1.ExportSettings.OpenInNewWindow = False
        RadGrid1.MasterTableView.ExportToExcel()
    End Sub

    Protected Sub ButLonRepay_Click(sender As Object, e As EventArgs) Handles ButLonRepay.Click
        RadGrid2.ExportSettings.ExportOnlyData = True
        RadGrid2.ExportSettings.IgnorePaging = True
        RadGrid2.ExportSettings.OpenInNewWindow = False
        RadGrid2.MasterTableView.ExportToExcel()
    End Sub

    Protected Sub ButProjectFinance_Click(sender As Object, e As EventArgs) Handles ButProjectFinance.Click
        RadGrid3.ExportSettings.ExportOnlyData = True
        RadGrid3.ExportSettings.IgnorePaging = True
        RadGrid3.ExportSettings.OpenInNewWindow = False
        RadGrid3.MasterTableView.ExportToExcel()
    End Sub

    Protected Sub ButPurchaseOfItems_Click(sender As Object, e As EventArgs) Handles ButPurchaseOfItems.Click
        RadGrid4.ExportSettings.ExportOnlyData = True
        RadGrid4.ExportSettings.IgnorePaging = True
        RadGrid4.ExportSettings.OpenInNewWindow = False
        RadGrid4.MasterTableView.ExportToExcel()
    End Sub
End Class
