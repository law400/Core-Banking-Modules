Imports System.IO
Imports Telerik.Web.UI
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Drawing
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
'For Ability to query directory content
'Imports System.IO.Directory
Imports System.Data
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Data.OleDb
Imports System.Data.SqlClient
'Import log4net to handle the logging
Imports log4net
Imports log4net.Config
Imports log4net.Appender
Imports log4net.LogManager
Imports log4net.Repository
Imports log4net.Repository.Hierarchy
Imports log4net.Layout

Partial Class CustomerService_MemberContributions
    Inherits SessionCheck
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim Bulksched As New Lst_Schedule
    Dim Blogin As Boolean
    Dim qry As String = ""
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(CustomerService_MemberContributions))
    Private MyCon As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Prime").ConnectionString)
    Public Structure Lst_Schedule
        Public customerid As String
        Public empID As String
        Public HRapproved_Amount As Decimal
    End Structure
#Region "Declaration"
    Private Structure vardeclare
        Dim customerid As String
        Dim customername As String
        Dim Branch As String
        Dim department As String
        Dim phoneno As String
        Dim email As String
        Dim userfunction As String
        Dim customerstatus As String
        Dim loginstatus As String
        Dim reportlevel As String
        Dim postacctno As String
        Dim authstatus As String
        Dim newfunction As String
        Dim password As String
    End Structure
    Private decl As New vardeclare

#End Region
    Sub clear()

        Me.txtContAmount.Text = "0"
        Me.txtEmpID.Text = ""
        Me.txtCustomerid.Text = ""

    End Sub
#Region "Pageload"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = "CUSTOMER SERVICE"
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim

        'HypSearch1.NavigateUrl = "javascript:staff('document.aspnetForm." + txtOfficer.ClientID.ToString() + "');"
        'HypSearch0.NavigateUrl = "javascript:staff('document.aspnetForm." + txtCompOffc.ClientID.ToString() + "');"

        Me.Hypsearch.NavigateUrl = "javascript:customer2('document.aspnetForm." + txtCustomerid.ClientID.ToString() + "');"
        'imgdate1.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtDOB.ClientID.ToString() + "');"
        'imgdate3.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtExpirydate.ClientID.ToString() + "');"
        'imgdate2.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtIssue.ClientID.ToString() + "');"

        'Start with Submit Button and CustomerID control as Disabled and Text="Action"
        'BtnSubmit.Visible = False
        'BtnUpdate.Visible = False
        txtCustomerid.Enabled = False


        If Page.IsPostBack = False Then

            Try

                'Me.Btnsubmit.Text = "Submit"
                'RETURN DATA TO GRID
                Dim selres As String = "exec proc_getMemberContributions '" & Me.txtCustomerid.Text.Trim & "'"


                Me.GridView1.DataSource = Module1.con.SqlDs(selres).Tables.Item(0)
                Me.GridView1.DataBind()
                Me.GridView1.Visible = True
                'RadGrid1.DataSource = con.SqlDs(selres).Tables(0)
                'Me.RadGrid1.DataBind()

                Session("postjourn") = selres

            Catch ex As Exception
                smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")

            End Try
        End If
    End Sub
#End Region
#Region "Task"
    Protected Sub BtnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsubmit.Click
        Try
            Dim globaldate As Date = "01/01/1900"
            Dim istate As Integer = 0
            retmsg = ""
            Dim customer As String = ""
            'If Profile.Custtype = "1" Then


            If Me.txtCustomerid.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Customer ID", "Prime")
                txtCustomerid.Enabled = True
                txtCustomerid.Focus()
                Exit Sub

            End If

            If Me.txtEmpID.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Staff ID", "Prime")
                txtEmpID.Focus()
                Exit Sub

            End If

            If Me.txtContAmount.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Contribution Amount", "Prime")
                txtContAmount.Focus()
                Exit Sub

            End If

            'If BtnSubmit.Text = "Submit" Then
            'Save to table
            qry = " declare @retmsg varchar(100),@retVal int " & vbNewLine
            qry = qry & "execute Proc_insMemberContrib "
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtCustomerid.Text.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtEmpID.Text.Trim) & ","
            qry = qry & smartobj.EncoteWithSingleQuote(Me.txtContAmount.Text.Trim) & ",@retVal OUTPUT,@retmsg OUTPUT "
            qry = qry & " select @retVal,@retmsg"


            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next
            'If retval = "1" Then
            '    smartobj.alertwindow(Me.Page, retmsg, "Prime")
            '    uploadimage()
            'Else

            'End If
            smartobj.alertwindow(Me.Page, retmsg, "Prime")
            smartobj.ClearWebPage(Me.Page)

            'End If




        Catch ex As Exception

            smartobj.alertwindow(Me.Page, retmsg, "Prime")

        End Try
    End Sub

    Protected Sub Btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        smartobj.ClearWebPage(Me.Page)
        clear()
        Response.Redirect("Default.aspx")
        Me.BtnSubmit.Enabled = True
    End Sub

    Protected Sub BtnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        search()
    End Sub

    Sub clear2()


        Me.txtContAmount.Text = "0"
        Me.txtEmpID.Text = ""
        Me.txtCustomerid.Text = ""

    End Sub

    Sub search()

        Try
            Dim sql1 As String = "exec proc_getMemberContributions '" & Me.txtCustomerid.Text.Trim & "'"
            'Me.txtCustomerid.ReadOnly = True

            If con.SqlDs(sql1).Tables(0).Rows.Count > 0 Then
                'MultiView1.Visible = True
                drx = con.SqlDs(sql1).Tables(0).Rows(0)
                Me.txtEmpID.Text = drx.Item("empID").ToString.Trim
                Me.txtContAmount.Text = drx.Item("contrib_Amount").ToString.Trim
                'Profile.Custtype = drx.Item("customertype").ToString.Trim

                'RETURN DATA TO GRID
                Dim selres As String = "exec proc_getMemberContributions '" & Me.txtCustomerid.Text.Trim & "'"


                Me.GridView1.DataSource = Module1.con.SqlDs(selres).Tables.Item(0)
                Me.GridView1.DataBind()
                Me.GridView1.Visible = True
                'RadGrid1.DataSource = con.SqlDs(selres).Tables(0)
                'Me.RadGrid1.DataBind()

                Session("postjourn") = selres

            Else
                'MultiView1.Visible = False
                'Return all to grid
                'RETURN DATA TO GRID
                Dim selres As String = "exec proc_getMemberContributions '" & Me.txtCustomerid.Text.Trim & "'"


                Me.GridView1.DataSource = Module1.con.SqlDs(selres).Tables.Item(0)
                Me.GridView1.DataBind()
                Me.GridView1.Visible = True
                'RadGrid1.DataSource = con.SqlDs(selres).Tables(0)
                'Me.RadGrid1.DataBind()

                Session("postjourn") = selres

                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub

    Sub search2()

        Try
            Dim sql1 As String = "exec proc_getMemberContributions '" & Me.txtCustomerid.Text.Trim & "'"
            'Me.txtCustomerid.ReadOnly = True

            If con.SqlDs(sql1).Tables(0).Rows.Count > 0 Then
                'MultiView1.Visible = True
                'Profile.Custtype = drx.Item("customertype").ToString.Trim

                'RETURN DATA TO GRID
                Dim selres As String = "exec proc_getMemberContributions '" & Me.txtCustomerid.Text.Trim & "'"


                Me.GridView1.DataSource = Module1.con.SqlDs(selres).Tables.Item(0)
                Me.GridView1.DataBind()
                Me.GridView1.Visible = True
                'RadGrid1.DataSource = con.SqlDs(selres).Tables(0)
                'Me.RadGrid1.DataBind()

                Session("postjourn") = selres

            Else
                'MultiView1.Visible = False
                'Return all to grid
                'RETURN DATA TO GRID
                Dim selres As String = "exec proc_getMemberContributions '" & Me.txtCustomerid.Text.Trim & "'"


                Me.GridView1.DataSource = Module1.con.SqlDs(selres).Tables.Item(0)
                Me.GridView1.DataBind()
                Me.GridView1.Visible = True
                'RadGrid1.DataSource = con.SqlDs(selres).Tables(0)
                'Me.RadGrid1.DataBind()

                Session("postjourn") = selres

                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txtCustomerid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustomerid.TextChanged
        Try
            search()
            'BtnSubmit.Visible = True

        Catch ex As Exception

        End Try

    End Sub
    'Function FormatURL2(ByVal strArgument As String) As String
    '    Return ("getimg2.aspx?id=" & strArgument)
    'End Function
    'Function FormatURL(ByVal strArgument As String) As String
    '    Return ("getimg.aspx?id=" & strArgument)
    'End Function
#End Region



    Protected Sub LinkButton1_Click(sender As Object, e As System.EventArgs) Handles LinkButton1.Click
        'Hide BtnSubmit and show BtnUpdate"
        BtnUpdate.Visible = True
        BtnSubmit.Visible = False
        txtCustomerid.Enabled = True

        'Refresh and show the grid
        search()
    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As System.EventArgs) Handles LinkButton2.Click
        'Hide BtnUpdate and Show BtnSubmit
        BtnUpdate.Visible = False
        BtnSubmit.Visible = True
        txtCustomerid.Enabled = True

        'Refresh and show the grid
        clear()
        search2()

    End Sub

    Public Sub GV_RowDataBound(o As Object, e As GridViewRowEventArgs)
        ' apply custom formatting to data cells
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' set formatting for the category cell
            Dim cell As TableCell = e.Row.Cells(0)
            cell.Width = New Unit("120px")
            cell.Style("border-right") = "2px solid #666666"
            cell.BackColor = System.Drawing.Color.LightGray

            ' set formatting for value cells
            For i As Integer = 1 To e.Row.Cells.Count - 1
                cell = e.Row.Cells(i)

                ' right-align each of the column cells after the first
                ' and set the width
                cell.HorizontalAlign = HorizontalAlign.Right
                cell.Width = New Unit("90px")

                ' alternate background colors
                If i Mod 2 = 1 Then
                    cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#EFEFEF")
                End If

                ' check value columns for a high enough value
                ' (value >= 8000) and apply special highlighting
                'If GetCellValue(cell) >= 8000 Then
                '    cell.Font.Bold = True
                '    cell.BorderWidth = New Unit("1px")
                '    cell.BorderColor = System.Drawing.Color.Gray
                '    cell.BorderStyle = BorderStyle.Dotted
                '    cell.BackColor = System.Drawing.Color.Honeydew

                'End If
            Next
        End If

        ' apply custom formatting to the header cells
        If e.Row.RowType = DataControlRowType.Header Then
            For Each cell As TableCell In e.Row.Cells
                cell.Style("border-bottom") = "2px solid #666666"
                cell.BackColor = System.Drawing.Color.LightGray
            Next
        End If

    End Sub

    Public Sub ExportToExcel()
        Response.ClearContent()
        Response.Buffer = True
        Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "MemberContributions.xls"))
        Response.ContentType = "application/ms-excel"
        Dim sw As New StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        Me.GridView1.AllowPaging = False
        Me.search()
        'Change the Header Row back to white color
        Me.GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF")
        'Applying stlye to gridview header cells
        For i As Integer = 0 To GridView1.HeaderRow.Cells.Count - 1
            Me.GridView1.HeaderRow.Cells(i).Style.Add("background-color", "#df5015")
        Next
        Me.GridView1.RenderControl(htw)
        Response.Write(sw)
        Response.[End]()

    End Sub


    Public Sub ExportToCSV()
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=MemberContributions.csv")
        Response.Charset = ""
        Response.ContentType = "application/text"
        Dim sBuilder As StringBuilder = New System.Text.StringBuilder()
        GridView1.AllowPaging = False
        Me.search()

        For index As Integer = 0 To GridView1.Columns.Count - 1
            sBuilder.Append(GridView1.Columns(index).HeaderText.Trim + ","c)
        Next

        sBuilder.Append(vbCr & vbLf)

        For i As Integer = 0 To GridView1.Rows.Count - 1
            For k As Integer = 0 To GridView1.HeaderRow.Cells.Count - 1
                sBuilder.Append(GridView1.Rows(i).Cells(k).Text.Replace(",", "").Replace("&nbsp;", "") + ","c)
            Next
            sBuilder.Append(vbCr & vbLf)
        Next

        Response.Output.Write(sBuilder.ToString())
        Response.Flush()
        Response.[End]()
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Me.GridView1.PageIndex = e.NewPageIndex
        Me.search()

    End Sub

    Protected Sub OnPageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        Me.search()

    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As System.Web.UI.Control)
        ' Verifies that the control is rendered
    End Sub

    Protected Sub BtnReturn1_Click(sender As Object, e As System.EventArgs) Handles BtnReturn1.Click
        Try
            If Not Me.Page.IsPostBack Then
                smartobj.alertwindow(Me.Page, "No Data to Export!!!", "Prime")
            End If

            If Me.GridView1.Visible = False Then
                smartobj.alertwindow(Me.Page, "No Data to Export!!!", "Prime")

            ElseIf Me.DropDownList2.SelectedValue = "1" Then
                ' RadGrid1.MasterTableView.GetColumn("TemplateColumn").Visible = False

                'RadGrid1.MasterTableView.ExportToExcel()
                Me.ExportToExcel()


            ElseIf Me.DropDownList2.SelectedValue = "3" Then
                'RadGrid1.MasterTableView.GetColumn("TemplateColumn").Visible = False
                'RadGrid1.MasterTableView.ExportToCSV()
                Me.ExportToCSV()

            End If

        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            Dim exception2 As Exception = ex
            smartobj.alertwindow(Me.Page, exception2.Message, "Prime")
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Protected Sub upload_Click(sender As Object, e As System.EventArgs) Handles upload.Click
        'Upld()
        Upload_Using_OpenXML()
    End Sub

#Region "Import operation"
    Sub Upload_Using_OpenXML()


        '''' <summary>
        ''''  Import Excel Data into GridView Control 
        '''' </summary>
        '''' <param name="sender"></param>
        '''' <param name="e"></param>
        ' The condition that FileUpload control contains a file 
        If myfile.HasFile Then
            ' Get selected file name
            ' Dim filename As String = myfile.PostedFile.FileName
            Dim filename As String = Path.GetFileName(Myfile.PostedFile.FileName)

            ' Get the extension of the selected file
            Dim fileExten As String = Path.GetExtension(filename)


            If IO.File.Exists(Server.MapPath("~/Upload/" & filename)) Then
                IO.File.Delete(Server.MapPath("~/Upload/" & filename))
            End If
            Myfile.PostedFile.SaveAs(Server.MapPath("~/Upload/" & filename))
            Session("strFil1") = filename

            '(.xls)
            ' The condition that the extension is not xlsx
            If fileExten.Equals(".xlsx", StringComparison.OrdinalIgnoreCase) Then
                'proceed with upload
            ElseIf fileExten.Equals(".xls", StringComparison.OrdinalIgnoreCase) Then
                'proceed with upload
            Else 'Then
                '''''Response.Write("<script language=""javascript"">alert('The extension of selected file is incorrect ,please select again');</script>")

                smartobj.alertwindow(Me.Page, "The extension of selected file is incorrect ,please select again a .xlsx file", "Prime")

                Return
            End If

            ' Read Data in excel file
            Try
                Dim dt As DataTable = ReadExcelFile(filename)

                If dt.Rows.Count = 0 Then
                    '''' Response.Write("<script language=""javascript"">alert('The first sheet is empty.');</script>")

                    smartobj.alertwindow(Me.Page, "The first sheet is empty.", "Prime")


                    Return
                End If

                ' Bind Datasource

                Me.GridView1.DataSource = dt
                Me.GridView1.DataBind()
                If Me.GridView1.Rows.Count > 0 Then
                    upload.Enabled = False
                    Me.Button1.Enabled = True
                    Me.GridView1.Visible = True
                Else
                    upload.Enabled = True
                    Me.Button1.Enabled = False
                    Me.GridView1.Visible = False
                End If


                ' Enable Export button
                '''' Me.btnExport.Enabled = True
            Catch ex As IOException
                Dim exceptionmessage As String = ex.Message

                '' Response.Write("<script language=""javascript"">alert(""" & exceptionmessage & """);</script>")

                smartobj.alertwindow(Me.Page, "Error Occurred", "Prime")

                logger.Info("CUSTOMER SERVICE OPERATION: MEMBER CONTRIBUTION READ DATA IN EXCEL'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "*******************************************************************************************************************************************************************")
            End Try
        Else
            ''  Response.Write("<script language=""javascript"">alert('You did not specify a file to import');</script>")

            smartobj.alertwindow(Me.Page, "You did not specify a file to import", "Prime")
        End If
    End Sub


    Private Function ReadExcelFile(ByVal filename As String) As DataTable
        ' Initializate an instance of DataTable
        Dim dt As New DataTable()

        ''Dim File As HttpPostedFile = Myfile.PostedFile
        ''Dim strFileNameOnly As String = Path.GetFileName(Myfile.PostedFile.FileName)

        '' ''strFileNamePath = Myfile.PostedFile.FileName
        '' ''intFileNameLength = InStr(1, StrReverse(strFileNamePath), "\")
        '' ''strFileNameOnly = Mid(strFileNamePath, (Len(strFileNamePath) - intFileNameLength) + 2)

        ''If IO.File.Exists(Server.MapPath("~/Upload/" & strFileNameOnly)) Then
        ''    IO.File.Delete(Server.MapPath("~/Upload/" & strFileNameOnly))
        ''End If
        ''Myfile.PostedFile.SaveAs(Server.MapPath("~/Upload/" & strFileNameOnly))
        ''Session("strFil1") = strFileNameOnly


        Try
            ' Use SpreadSheetDocument class of Open XML SDK to open excel file
            'Dim strDoc As String = "~/Upload/" & filename
            'Dim stream As Stream = File.Open(strDoc, FileMode.Open)
            'OpenAndAddToSpreadsheetStream(stream)
            'stream.Close()
            '  Dim fileNames As String = "d:\bulkpostingNew.xlsx"
            Dim fileNames As String = Server.MapPath("~/Upload/" & filename)
            Using fs As New FileStream(fileNames, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                Using spreadsheetDocument__1 As SpreadsheetDocument = SpreadsheetDocument.Open(fs, False)
                    ' Get Workbook Part of Spread Sheet Document
                    Dim workbookPart As WorkbookPart = spreadsheetDocument__1.WorkbookPart

                    ' Get all sheets in spread sheet document 
                    Dim sheetcollection As IEnumerable(Of Sheet) = spreadsheetDocument__1.WorkbookPart.Workbook.GetFirstChild(Of Sheets)().Elements(Of Sheet)()

                    ' Get relationship Id
                    Dim relationshipId As String = sheetcollection.First().Id.Value

                    ' Get sheet1 Part of Spread Sheet Document
                    Dim worksheetPart As WorksheetPart = DirectCast(spreadsheetDocument__1.WorkbookPart.GetPartById(relationshipId), WorksheetPart)

                    ' Get Data in Excel file
                    Dim sheetData As SheetData = worksheetPart.Worksheet.Elements(Of SheetData)().First()
                    Dim rowcollection As IEnumerable(Of Row) = sheetData.Descendants(Of Row)()

                    If rowcollection.Count() = 0 Then
                        Return dt
                    End If

                    ' Add columns
                    For Each cell As Cell In rowcollection.ElementAt(0)
                        dt.Columns.Add(GetValueOfCell(spreadsheetDocument__1, cell))
                    Next

                    ' Add rows into DataTable
                    For Each row As Row In rowcollection
                        Dim temprow As DataRow = dt.NewRow()
                        For i As Integer = 0 To row.Descendants(Of Cell)().Count() - 1
                            temprow(i) = GetValueOfCell(spreadsheetDocument__1, row.Descendants(Of Cell)().ElementAt(i))
                        Next

                        ' Add the row to DataTable
                        ' the rows include header row
                        dt.Rows.Add(temprow)
                    Next
                End Using
            End Using
            ' Here remove header row
            dt.Rows.RemoveAt(0)
            Return dt
        Catch ex As IOException
            '' Throw New IOException(ex.Message)
            smartobj.alertwindow(Me.Page, "Error in reading Sheet, please check the format of Sheet.", "Prime")

            logger.Info("CUSTOMER SERVICE OPERATION: MEMBER CONTRIBUTION READ EXCEL SHEET'" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "*******************************************************************************************************************************************************************")
        End Try
    End Function
    Private Shared Function GetValueOfCell(ByVal spreadsheetdocument As SpreadsheetDocument, ByVal cell As Cell) As String
        ' Get value in Cell
        Dim sharedString As SharedStringTablePart = spreadsheetdocument.WorkbookPart.SharedStringTablePart
        If cell.CellValue Is Nothing Then
            Return String.Empty
        End If

        Dim cellValue As String = cell.CellValue.InnerText

        ' The condition that the Cell DataType is SharedString
        If cell.DataType IsNot Nothing AndAlso cell.DataType.Value = CellValues.SharedString Then
            Return sharedString.SharedStringTable.ChildElements(Integer.Parse(cellValue)).InnerText
        Else
            Return cellValue
        End If
    End Function

#End Region


    'Sub Upld()
    '    Dim intFileNameLength As Integer
    '    Dim strFileNamePath As String = ""
    '    ''Dim strFileNameOnly As String = ""
    '    Try

    '        'If Not (Myfile.PostedFile Is Nothing) Then
    '        Dim img As FileUpload = CType(Myfile, FileUpload)
    '        If img.HasFile AndAlso Not img.PostedFile Is Nothing Then


    '            Dim File As HttpPostedFile = Myfile.PostedFile
    '            Dim strFileNameOnly As String = Path.GetFileName(Myfile.PostedFile.FileName)

    '            ''strFileNamePath = Myfile.PostedFile.FileName
    '            ''intFileNameLength = InStr(1, StrReverse(strFileNamePath), "\")
    '            ''strFileNameOnly = Mid(strFileNamePath, (Len(strFileNamePath) - intFileNameLength) + 2)

    '            If IO.File.Exists(Server.MapPath("~/Upload/" & strFileNameOnly)) Then
    '                IO.File.Delete(Server.MapPath("~/Upload/" & strFileNameOnly))
    '            End If
    '            Myfile.PostedFile.SaveAs(Server.MapPath("~/Upload/" & strFileNameOnly))
    '            Session("strFil1") = strFileNameOnly

    '            'Dim FTPAddress As String = "http://localhost:10039/Prime"
    '            'Dim fileInfo As IO.FileInfo = New IO.FileInfo(strFileNamePath)

    '            'uploadFileUsingFTP("ftp://" + FTPAddress + "/Upload/" + strFileNameOnly, strFileNamePath)

    '            Dim sConnectionString As String
    '            Dim objConn As OleDbConnection

    '            If Me.DrpExcelType.SelectedValue = "0" Then
    '                smartobj.alertwindow(Me.Page, "Please Select an Upload MS-Office Excel Type", "Prime")

    '                Exit Sub
    '            End If
    '            If Me.DrpExcelType.SelectedValue = "1" Then
    '                sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Server.MapPath("~/Upload/" + strFileNameOnly) + ";" + "Extended Properties=Excel 8.0;"
    '                objConn = New OleDbConnection(sConnectionString)

    '            Else
    '                sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Server.MapPath("~/Upload/" + strFileNameOnly) + ";" + "Extended Properties=""Excel 12.0 Xml;HDR=YES;"""
    '                objConn = New OleDbConnection(sConnectionString)

    '            End If

    '            objConn.Open()

    '            Dim objCmdSelect As OleDbCommand = New OleDbCommand("SELECT * FROM [MemberContributions$] ", objConn)
    '            Dim objAdapter1 As OleDbDataAdapter = New OleDbDataAdapter()
    '            Dim custCB As OleDbCommandBuilder = New OleDbCommandBuilder(objAdapter1)
    '            objAdapter1.SelectCommand = objCmdSelect
    '            objCmdSelect.ExecuteNonQuery()
    '            Dim objDataset1 As DataSet = New DataSet()
    '            objAdapter1.AcceptChangesDuringFill = False
    '            objAdapter1.Fill(objDataset1, "MemberContributions")


    '            'objAdapter1.Fill(objDataset1)

    '            'Me.GridView1.DataSource = objDataset1
    '            Me.GridView2.DataSource = objDataset1.Tables(0).DefaultView
    '            GridView2.DataBind()

    '            'SHOW Gridview2 and HIDE Gridview1
    '            Me.GridView1.Visible = False
    '            Me.GridView2.Visible = True

    '            objConn.Close()
    '            If Me.GridView2.Rows.Count > 0 Then
    '                upload.Enabled = False
    '                Me.Button1.Enabled = True
    '                Me.GridView1.Visible = False
    '                Me.GridView2.Visible = True
    '            Else
    '                upload.Enabled = True
    '                Me.Button1.Enabled = False
    '                Me.GridView2.Visible = False
    '                Me.GridView1.Visible = False
    '            End If

    '        End If

    '    Catch ex As Exception

    '    End Try


    'End Sub

    'Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
    '    If Blogin = False Then
    '        Blogin = True

    '        Dim cmd As New SqlCommand
    '        Dim retVal As String = ""
    '        Dim retMsg As String = ""
    '        Dim i As Int32 = GridView1.Rows.Count
    '        Dim j As Int32 = GridView1.Columns.Count
    '        Dim k As Int32 = 0

    '        Try
    '            If Button1.Text <> "Return" Then
    '                IO.File.Delete(Server.MapPath("~/Upload/" & Session("strFil1")))
    '                Dim trunc As String = "Delete from tbl_Bulktran where batchno='" & Me.txtBatch.Text.Trim & "'"
    '                con.SqlDs(trunc)

    '                For k = 0 To i - 1


    '                    Bulksched.CustID = GridView1.Rows(k).Cells(0).Text
    '                    Bulksched.EmpID = GridView1.Rows(k).Cells(1).Text
    '                    Bulksched.Approvedamount = GridView1.Rows(k).Cells(2).Text

    '                    Try
    '                        con.SqlDs(InsertBulkScript(Bulksched))


    '                    Catch ex As Exception

    '                        Exit Sub
    '                    End Try

    '                Next

    '                Dim insval As String = "declare @retval int,@retmsg varchar(200) exec proc_postBulk '" & Me.txtBatch.Text.Trim & "',@retval output,@retmsg output select @retval,@retmsg"
    '                For Each dr As Data.DataRow In con.SqlDs(insval).Tables(0).Rows
    '                    retVal = dr(0).ToString
    '                    retMsg = dr(1).ToString
    '                Next

    '                smartobj.alertwindow(Me.Page, retMsg, "Prime")
    '                Me.Label1.Text = retMsg
    '                Button1.Text = "Return"
    '                If retVal = "0" Then
    '                    ''Me.Button1.Enabled = False
    '                    Dim trunc1 As String = "Delete from tbl_Bulktran where batchno='" & Me.txtBatch.Text.Trim & "'"
    '                    con.SqlDs(trunc1)

    '                    Blogin = False
    '                    Me.GridView1.Visible = False
    '                    Session("strFil1") = Nothing
    '                End If
    '            Else
    '                Response.Redirect("Default.aspx")
    '            End If

    '        Catch ex As Exception
    '            smartobj.alertwindow(Me.Page, ex.Message, "Prime")
    '        End Try

    '        Blogin = False

    '    End If
    'End Sub

    Private Function InsertBulkScript(ByVal Bulksched As Lst_Schedule) As String

        Dim sqlstr As String
        sqlstr = "Update tbl_member_contributions set HRapproved_Amount = " & smartobj.EncoteWithSingleQuote(Bulksched.HRapproved_Amount) & " "
        sqlstr = sqlstr & "where customerid="
        sqlstr = sqlstr & smartobj.EncoteWithSingleQuote(Bulksched.customerid) & ""

        Return sqlstr
    End Function

    Protected Sub BtnUpdate_Click(sender As Object, e As System.EventArgs) Handles BtnUpdate.Click
        Try
            Dim globaldate As Date = "01/01/1900"
            Dim istate As Integer = 0
            retmsg = ""
            Dim customer As String = ""
            If Profile.Custtype = "1" Then


                If Me.txtCustomerid.Text = "" Then
                    smartobj.alertwindow(Me.Page, "Enter Customer ID", "Prime")
                    txtCustomerid.Enabled = True
                    txtCustomerid.Focus()
                    Exit Sub

                End If

                If Me.txtEmpID.Text = "" Then
                    smartobj.alertwindow(Me.Page, "Enter Staff ID", "Prime")
                    txtEmpID.Focus()
                    Exit Sub

                End If

                If Me.txtContAmount.Text = "" Then
                    smartobj.alertwindow(Me.Page, "Enter Contribution Amount", "Prime")
                    txtContAmount.Focus()
                    Exit Sub

                End If

                'If BtnSubmit.Text = "Submit" Then
                'Save to table
                qry = " declare @retmsg varchar(100),@retVal int " & vbNewLine
                qry = qry & "execute Proc_updMemberContrib "
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtCustomerid.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtEmpID.Text.Trim) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.txtContAmount.Text.Trim.Replace("'", "")) & ","
                qry = qry & smartobj.EncoteWithSingleQuote(Me.drpStatus.SelectedValue.Trim) & ",@retVal OUTPUT,@retmsg OUTPUT "
                qry = qry & " select @retVal,@retmsg"


                For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                    retval = dr(0).ToString
                    retmsg = dr(1).ToString
                Next
                'If retval = "1" Then
                '    smartobj.alertwindow(Me.Page, retmsg, "Prime")
                '    uploadimage()
                'Else

                'End If
                smartobj.alertwindow(Me.Page, retmsg, "Prime")
                smartobj.ClearWebPage(Me.Page)

            End If




        Catch ex As Exception

            smartobj.alertwindow(Me.Page, retmsg, "Prime")

        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        If Blogin = False Then
            Blogin = True

            Dim cmd As New SqlCommand
            Dim retVal As String = ""
            Dim retMsg As String = ""
            Dim i As Int32 = GridView1.Rows.Count
            Dim j As Int32 = GridView1.Columns.Count
            Dim k As Int32 = 0

            Try
                If Button1.Text <> "Return" Then
                    IO.File.Delete(Server.MapPath("~/Upload/" & Session("strFil1")))

                    For k = 0 To i - 1


                        Bulksched.HRapproved_Amount = GridView1.Rows(k).Cells(4).Text
                        Bulksched.customerid = GridView1.Rows(k).Cells(0).Text
                        Bulksched.empID = GridView1.Rows(k).Cells(1).Text

                        Try

                            'DO DEDUCTIONS
                            Dim insDeductions As String = "declare @retval int,@retmsg varchar(200) exec proc_PostMemberContributions '1000350828'," & smartobj.EncoteWithSingleQuote(Bulksched.customerid) & ", " & smartobj.EncoteWithSingleQuote(Bulksched.HRapproved_Amount) & "," & smartobj.EncoteWithSingleQuote(Profile.Userid.Trim) & ", @retval output,@retmsg output select @retval,@retmsg"
                            con.SqlDs(insDeductions)

                            con.SqlDs(InsertBulkScript(Bulksched))


                        Catch ex As Exception

                            Exit Sub
                        End Try

                    Next

                    'DO THE LOGGING

                    'INSERT MEMBER APPROVED AMOUNTS
                    Dim insval As String = "declare @retval int,@retmsg varchar(200) exec proc_insMemberApprovedAmount '" & GridView1.Rows(k).Cells(0).Text & "', " & GridView1.Rows(k).Cells(4).Text & " @retval output,@retmsg output select @retval,@retmsg"
                    For Each dr As Data.DataRow In con.SqlDs(insval).Tables(0).Rows
                        retVal = dr(0).ToString
                        retMsg = dr(1).ToString
                    Next

                    smartobj.alertwindow(Me.Page, retMsg, "Prime")
                    Me.Label1.Visible = True
                    Me.Label1.Text = retMsg
                    Button1.Text = "Return"
                    If retVal = "0" Then
                        ''Me.Button1.Enabled = False

                        Blogin = False
                        Me.GridView2.Visible = False
                        Session("strFil1") = Nothing
                    End If
                Else
                    Response.Redirect("Default.aspx")
                End If

            Catch ex As Exception
                smartobj.alertwindow(Me.Page, ex.Message, "Prime")
            End Try

            Blogin = False

        End If
    End Sub
End Class
