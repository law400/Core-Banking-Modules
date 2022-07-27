Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports log4net
Imports log4net.Config
Imports System.Data.Objects
Imports ClosedXML.Excel
Imports System.IO
Imports Toastr

Partial Class UCP_Deploy_DeductionDownload
    Inherits SessionCheck
    Dim xe As New XAAS_MultiEntities
    Private retmsg As String = ""
    Private retval As Integer
    Dim qry As String

    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(UCP_Deploy_DeductionDownload))
    '    Protected Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

    '        'Dim w = From d In xe.Memcos_Reg_table
    '        '    Select d

    '        Try
    '            'RadGrid1.DataSource = w.ToList


    '            Dim qry As String = "Exec Proc_DeductionDownload '" & RadMonthYearPicker1.SelectedDate & "','" & TxtBatch.Text & "','" & Session("Userid") & "', " & Session("node_ID") & ""

    '            RadGrid1.DataSource = con.SqlDs(qry)
    '        Catch ex As Exception

    '            smartobj.alertwindow(Me.Page, "Error occurred in populating data...", "Prime")
    '            logger.Info("Deduction Download: RadGrid1_NeedDataSource - Populate Records in Gridview'" _
    '& vbNewLine & "   <<<<Direction: OUTPUT" _
    '& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
    '& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
    '& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
    '& vbNewLine & "******************************************************************************************************")

    '        End Try

    '        'If w.Count > 0 Then
    '        '    btnSubmit.Visible = True
    '        'Else
    '        '    btnSubmit.Visible = False
    '        'End If




    '    End Sub
    '    Protected Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
    '        Try
    '            'Dim qry As String = "Select Distinct b.EmployeeID,CustId 'customerid',EmployeeName,a.AccountNumber,TotalRepayAmt 'MonthlyContri' from tbl_loanscheduledetail a, Memcos_Reg_table b where a.custId = b.customerid and Convert(Char,DateName( Month, Date_Due ) + ' ' + DateName( Year, Date_Due )) = '" & RadMonthYearPicker1.SelectedDate & "'"

    '            Dim qry As String = "Select Distinct b.EmployeeID,CustId 'customerid',EmployeeName,a.AccountNumber,TotalRepayAmt 'MonthlyContri' from tbl_loanscheduledetail a, Memcos_Reg_table b where a.custId = b.customerid and Convert(Char,DateName( Month, Date_Due ) + ' ' + DateName( Year, Date_Due )) = 'August 2014'"

    '            RadGrid2.DataSource = con.SqlDs(qry)
    '        Catch ex As Exception

    '            smartobj.alertwindow(Me.Page, "Error occurred in populating data...", "Prime")
    '            logger.Info("Deduction Download: RadGrid2_NeedDataSource - Populate Records in Gridview'" _
    '& vbNewLine & "   <<<<Direction: OUTPUT" _
    '& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
    '& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
    '& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
    '& vbNewLine & "******************************************************************************************************")

    '        End Try

    '        'If w.Count > 0 Then
    '        '    btnSubmit.Visible = True
    '        'Else
    '        '    btnSubmit.Visible = False
    '        'End If




    '    End Sub


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim l As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("Label3"), System.Web.UI.WebControls.Label)
        l.Text = ""
        Dim ll As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("Label4"), System.Web.UI.WebControls.Label)
        ll.Text = "DEDUCTION DOWNLOAD" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        Dim menuname As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("lbldisplay"), System.Web.UI.WebControls.Label)
        menuname.Text = Request.QueryString("XXX")
        If menuname.Text = "" Then
            Response.Redirect("~/Unauthorize.aspx")
        End If

        If Validate_Access(menuname.Text) = 0 Then
            Response.Redirect("~/Unauthorize.aspx")
        End If
        ''  ButCompleteValidation.Enabled = False
        Contributions.Visible = True
        If Page.IsPostBack = False Then

            generate_batch()

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
    Sub generate_batch()
        Dim RandomClass As New Random()

        Dim RandomNumber As Integer
        RandomNumber = RandomClass.Next(9, 9000000)

        Me.TxtBatch.Text = RandomNumber
    End Sub
    'Protected Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs)
    '    If e.CommandName = RadGrid.ExportToExcelCommandName Then

    '        If Me.RadGrid2.Items.Count > 0 Then
    '            RadGrid2.ExportSettings.IgnorePaging = True
    '            RadGrid2.ExportSettings.ExportOnlyData = True
    '            RadGrid2.ExportSettings.OpenInNewWindow = True
    '        End If
    '    End If
    'End Sub
    Sub BindToGrid()
        Try

            Dim s1 As String = String.Format("{0:MM/dd/yyyy}", RadMonthYearPicker1.SelectedDate)

            Dim qry As String = "Exec Proc_DeductionDownload '" & s1 & "','" & TxtBatch.Text & "','" & Session("Userid") & "', " & Session("node_ID") & ""

            GridView1.DataSource = con.SqlDs(qry)
            GridView1.DataBind()
            'RadGrid2.DataSource = con.SqlDs(qry)
            'RadGrid2.DataBind()

            If GridView1.Rows.Count > 0 Then
                ButCompleteValidation.Enabled = True
            End If
        Catch ex As Exception
            ''    smartobj.alertwindow(Me.Page, "Error occurred in populating data...", "Prime")

            ' PrimeApp.ShowToastr(Page, "Error occurred in populating data...", "Error!", "Danger", False, "toast-top-right", False)

            smartobj.ShowToast(Me.Page, ToastType.Error, "Error occurred in populating data...", "Error!", ToastPosition.TopRight, True)

            logger.Info("Deduction Download: RadGrid1_NeedDataSource - Populate Records in Gridview'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

        End Try
    End Sub
    '    Protected Sub ButGenerateContib_Click(sender As Object, e As EventArgs) Handles ButGenerateContib.Click
    '        'If Me.RadGrid1.MasterTableView.Items.Count > 0 Then
    '        '    RadGrid1.ExportSettings.ExportOnlyData = True
    '        '    RadGrid1.ExportSettings.IgnorePaging = True
    '        '    RadGrid1.ExportSettings.OpenInNewWindow = False
    '        '    RadGrid1.MasterTableView.ExportToExcel()
    '        'End If

    '        Try
    '            'RadGrid1.DataSource = w.ToList

    '            BindToGrid()

    '        Catch ex As Exception

    '            smartobj.alertwindow(Me.Page, "Error occurred in populating data...", "Prime")
    '            logger.Info("Deduction Download: RadGrid1_NeedDataSource - Populate Records in Gridview'" _
    '& vbNewLine & "   <<<<Direction: OUTPUT" _
    '& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
    '& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
    '& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
    '& vbNewLine & "******************************************************************************************************")

    '        End Try
    '    End Sub




    Protected Sub RadMonthYearPicker1_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadMonthYearPicker1.SelectedDateChanged
        Try

            ButCompleteValidation.Enabled = False
            'generate_batch()
			if TxtBatch.Text="" then
				  smartobj.ShowToast(Me.Page, ToastType.Error, "Batch Number cannot be blank...", "Error!", ToastPosition.TopRight, True)
				  Exit Sub
			End if 
            BindToGrid()


        Catch ex As Exception
            ''    smartobj.alertwindow(Me.Page, "Error occurred in populating data...", "Prime")

            '    PrimeApp.ShowToastr(Page, "Error occurred in populating data...", "Error!", "Danger", False, "toast-top-right", False)


            smartobj.ShowToast(Me.Page, ToastType.Error, "Error occurred in populating data...", "Error!", ToastPosition.TopRight, True)

            logger.Info("Deduction Download: RadGrid1_NeedDataSource - Populate Records in Gridview'" _
    & vbNewLine & "   <<<<Direction: OUTPUT" _
    & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
    & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
    & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
    & vbNewLine & "******************************************************************************************************")

        End Try
    End Sub

    Protected Sub ButGenerateContib0_Click(sender As Object, e As EventArgs) Handles ButGenerateContib0.Click
        'If Me.RadGrid2.MasterTableView.Items.Count > 0 Then
        '    RadGrid2.ExportSettings.ExportOnlyData = True
        '    RadGrid2.ExportSettings.IgnorePaging = True
        '    RadGrid2.ExportSettings.OpenInNewWindow = False
        '    RadGrid2.ExportSettings.FileName = "Deduction Download "
        '    RadGrid2.MasterTableView.ExportToExcel()
        '    ' RadGrid2.MasterTableView.ExportToCSV()
        '    Me.ButCompleteValidation.Enabled = True
        'End If
        If Me.GridView1.Rows.Count > 0 Then
            ''ButCompleteValidation.Enabled = True

            Dim dt As New DataTable("Schedule")
            For Each cell As TableCell In GridView1.HeaderRow.Cells
                dt.Columns.Add(cell.Text)
            Next
            For Each row As GridViewRow In GridView1.Rows
                dt.Rows.Add()
                For i As Integer = 0 To row.Cells.Count - 1
                    dt.Rows(dt.Rows.Count - 1)(i) = row.Cells(i).Text
                Next
            Next
            Using wb As New XLWorkbook()
                Dim ws = wb.Worksheets.Add(dt)

                ' On this sheet we will only allow:
                ' Cell Formatting
                ' Inserting Columns
                ' Deleting Columns
                'ws.Protect().SetFormatCells().SetInsertColumns().SetDeleteColumns().SetDeleteRows()
                '' Deleting Rows
                'ws.Cell("A1").SetValue("Locked, No Hidden (Default):").Style.Font.SetBold().Fill.SetBackgroundColor(XLColor.Cyan)
                'ws.Cell("B1").Style.Border.SetOutsideBorder(XLBorderStyleValues.Medium)

                'ws.Cell("A2").SetValue("Locked, Hidden:").Style.Font.SetBold().Fill.SetBackgroundColor(XLColor.Cyan)
                'ws.Cell("B2").Style.Protection.SetHidden().Border.SetOutsideBorder(XLBorderStyleValues.Medium)

                'ws.Cell("A3").SetValue("Not Locked, Hidden:").Style.Font.SetBold().Fill.SetBackgroundColor(XLColor.Cyan)
                'ws.Cell("B3").Style.Protection.SetLocked(False).Protection.SetHidden().Border.SetOutsideBorder(XLBorderStyleValues.Medium)

                'ws.Cell("A4").SetValue("Not Locked, Not Hidden:").Style.Font.SetBold().Fill.SetBackgroundColor(XLColor.Cyan)
                'ws.Cell("B4").Style.Protection.SetLocked(False).Border.SetOutsideBorder(XLBorderStyleValues.Medium)

                'ws.Columns().AdjustToContents()

                ' Protect a sheet with a password
                'Dim protectedSheet = wb.Worksheets.Add("Protected Password = 123")
                'Dim protection = protectedSheet.Protect("123")
                'protection.InsertRows = True
                'protection.InsertColumns = True

                '    Dim SheetProtect = ws.Protect("CWG")
                ws.SheetView.FreezeColumns(1)
                ws.SheetView.FreezeColumns(2)
                ws.SheetView.FreezeColumns(3)
                ws.SheetView.FreezeColumns(4)
                ws.SheetView.FreezeColumns(5)
                ws.SheetView.FreezeColumns(6)
                ws.SheetView.FreezeColumns(7)
                ws.SheetView.FreezeColumns(8)
                '' wb.SaveAs("SheetProtection.xlsx")
                Response.Clear()
                Response.Buffer = True
                Response.Charset = ""
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                Response.AddHeader("content-disposition", "attachment;filename=Deduction_Download.xlsx")
                Using MyMemoryStream As New MemoryStream()
                    wb.SaveAs(MyMemoryStream)
                    MyMemoryStream.WriteTo(Response.OutputStream)
                    Response.Flush()
                    Response.[End]()
                End Using
            End Using
        End If
    End Sub
    'Protected Sub RadGrid2_ExcelExportCellFormatting(ByVal source As Object, ByVal e As ExcelExportCellFormattingEventArgs)
    '    If e.FormattedColumn.UniqueName = "column2" Then
    '        'To export in text format
    '        e.Cell.Style("mso-number-format") = "\@"
    '    End If
    'End Sub

    Protected Sub ButCompleteValidation_Click(sender As Object, e As EventArgs) Handles ButCompleteValidation.Click
        '  ButCompleteValidation.Attributes("Onclick") = "return confirm('Do you really want to complete this?')"
        Dim qry As String = "Declare @retval int,@retmsg varchar(100) Exec Proc_DeductionDownload_Confirmation '" & Session("Userid") & "','" & TxtBatch.Text & "'," & Session("node_ID") & ",@retval output,@retmsg output select @retval ,@retmsg"
        For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
            retval = dr(0).ToString
            retmsg = dr(1).ToString
        Next

        If retval = 0 Then
            '' smartobj.alertwindow(Me.Page, retmsg, "Alert")

            ''   PrimeApp.ShowToastr(Page, retmsg, "Yessss!", "Success", False, "toast-top-right", False)


            smartobj.ShowToast(Me.Page, ToastType.Success, retmsg, "Yessss!", ToastPosition.TopRight, True)


            ButCompleteValidation.Enabled = False
        Else
            ''  smartobj.alertwindow(Me.Page, retmsg, "Alert")

            ''     PrimeApp.ShowToastr(Page, retmsg, "Error!", "Danger", False, "toast-top-right", False)

            smartobj.ShowToast(Me.Page, ToastType.Error, retmsg, "Error!", ToastPosition.TopRight, True)



            ButCompleteValidation.Enabled = True
        End If

    End Sub
End Class
