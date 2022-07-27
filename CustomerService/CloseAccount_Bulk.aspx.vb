Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Net
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Text
Partial Class CustomerService_CloseAccount_Bulk
    Inherits SessionCheck
    Private msgger As String
    Private DrAcctNumber As String
    Dim Bulksched As New Lst_Schedule
    Dim Blogin As Boolean
    Public Structure Lst_Schedule
        Public AccountNumber As String
        Public tranamount As Decimal
        Public trancode As String
        Public currency As String
        Public Date_due As String
        Public narration As String
        Public tellerno As String
        Public userid As String
        Public authid As String
        Public Charges As String
    End Structure
    Protected Sub upload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles upload.Click
        ' Upld()
        Upload_Using_OpenXML()
    End Sub
    Public Sub uploadFileUsingFTP(ByVal CompleteFTPPath As String, ByVal CompleteLocalPath As String, Optional ByVal UName As String = "", Optional ByVal PWD As String = "")
        Dim reqObj As FtpWebRequest = WebRequest.Create(CompleteFTPPath)

        reqObj.Method = WebRequestMethods.Ftp.UploadFile
        reqObj.Credentials = New NetworkCredential(UName, PWD)
        Dim streamObj As FileStream = File.OpenRead(CompleteLocalPath)

        Dim buffer(streamObj.Length) As Byte

        streamObj.Read(buffer, 0, buffer.Length)

        streamObj.Close()

        streamObj = Nothing

        reqObj.GetRequestStream().Write(buffer, 0, buffer.Length)

        reqObj = Nothing



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

            ' The condition that the extension is not xlsx
            If Not fileExten.Equals(".xlsx", StringComparison.OrdinalIgnoreCase) Then
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
                        '' Dim first_value As Integer = 0
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
            'Throw New IOException(ex.Message)
            smartobj.alertwindow(Me.Page, "Error in reading Sheet, please check the format of Sheet.", "Prime")
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
    Sub Upld()
        Dim intFileNameLength As Integer
        Dim strFileNamePath As String = ""
        ''Dim strFileNameOnly As String = ""
        Try

            'If Not (Myfile.PostedFile Is Nothing) Then
            Dim img As FileUpload = CType(Myfile, FileUpload)
            If img.HasFile AndAlso Not img.PostedFile Is Nothing Then


                Dim File As HttpPostedFile = Myfile.PostedFile
                Dim strFileNameOnly As String = Path.GetFileName(Myfile.PostedFile.FileName)

                ''strFileNamePath = Myfile.PostedFile.FileName
                ''intFileNameLength = InStr(1, StrReverse(strFileNamePath), "\")
                ''strFileNameOnly = Mid(strFileNamePath, (Len(strFileNamePath) - intFileNameLength) + 2)

                If IO.File.Exists(Server.MapPath("~/Upload/" & strFileNameOnly)) Then
                    IO.File.Delete(Server.MapPath("~/Upload/" & strFileNameOnly))
                End If
                Myfile.PostedFile.SaveAs(Server.MapPath("~/Upload/" & strFileNameOnly))
                Session("strFil1") = strFileNameOnly

                'Dim FTPAddress As String = "http://localhost:10039/Prime"
                'Dim fileInfo As IO.FileInfo = New IO.FileInfo(strFileNamePath)

                'uploadFileUsingFTP("ftp://" + FTPAddress + "/Upload/" + strFileNameOnly, strFileNamePath)

                Dim sConnectionString As String
                Dim objConn As OleDbConnection

                If Me.DrpExcelType.SelectedValue = "0" Then
                    smartobj.alertwindow(Me.Page, "Please Select an Upload MS-Office Excel Type", "Prime")

                    Exit Sub
                End If
                If Me.DrpExcelType.SelectedValue = "1" Then
                    sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Server.MapPath("~/Upload/" + strFileNameOnly) + ";" + "Extended Properties=Excel 8.0;"
                    objConn = New OleDbConnection(sConnectionString)

                Else
                    sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Server.MapPath("~/Upload/" + strFileNameOnly) + ";" + "Extended Properties=""Excel 12.0 Xml;HDR=YES;"""
                    objConn = New OleDbConnection(sConnectionString)

                End If

                objConn.Open()
                Dim objCmdSelect As OleDbCommand = New OleDbCommand("SELECT * FROM [sheet1$] where Accountnumber <> null", objConn)
                Dim objAdapter1 As OleDbDataAdapter = New OleDbDataAdapter()
                Dim custCB As OleDbCommandBuilder = New OleDbCommandBuilder(objAdapter1)
                objAdapter1.SelectCommand = objCmdSelect
                Dim objDataset1 As DataSet = New DataSet()
                objAdapter1.AcceptChangesDuringFill = False
                objAdapter1.Fill(objDataset1, "Payment")
                Me.GridView1.DataSource = objDataset1.Tables(0).DefaultView
                GridView1.DataBind()

                objConn.Close()
                If Me.GridView1.Rows.Count > 0 Then
                    upload.Enabled = False
                    Me.Button1.Enabled = True
                    Me.GridView1.Visible = True
                Else
                    upload.Enabled = True
                    Me.Button1.Enabled = False
                    Me.GridView1.Visible = False
                End If

                ''Dim proc As String = "Exec proc_Checkaccount"
                ''Dim conrec As Integer = con.SqlDs(proc).Tables(0).Rows.Count
                ''If conrec > 0 Then
                ''    For Each dr As DataRow In con.SqlDs(proc).Tables(0).Rows
                ''        Me.ListBox1.Visible = True
                ''        smartobj.loadListBox(Me.ListBox1, proc)

                ''        Me.Button1.Enabled = False
                ''    Next
                ''    Me.Label6.Visible = True
                ''    Me.Label6.Text = conrec & " Failed Account"

                ''Else
                ''    Me.Label6.Text = conrec & " Failed Account"

                ''    Me.Button1.Enabled = True
                ''    Me.ListBox1.Visible = False

                ''End If

            End If

        Catch ex As Exception

        End Try


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Label1.Text = "Upload Bulk Transaction From Excel File On Sheet$1"
            'GridView1.Visible = False"
            'LnkCharge0.NavigateUrl = "javascript:acctdetail('document.aspnetForm." + txtNoRow.ClientID.ToString() + "');"

            Dim RandomClass As New Random()

            Dim RandomNumber As Integer
            RandomNumber = RandomClass.Next(6, 9000000)

            Me.txtBatch.Text = RandomNumber
        End If
    End Sub
    Dim dTotal As Decimal = 0
    '    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
    '        ''If e.Row.RowType = DataControlRowType.DataRow Then

    '        ''    dTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TranAmount"))

    '        ''End If

    '        ''Me.txtTotal.Text = dTotal.ToString("n")
    '        Dim dTotal As Decimal = 0
    '        Dim i As Int32 = GridView1.Rows.Count
    '        Dim j As Int32 = GridView1.Columns.Count
    '        Dim k As Int32 = 0
    '        For k = 0 To i - 1



    '            If GridView1.Rows(k).Cells(0).Text = Nothing Then GoTo NEXT_VALUE
    '            If GridView1.Rows(k).Cells(0).Text = "&nbsp;" Then GoTo NEXT_VALUE
    '            If GridView1.Rows(k).Cells(1).Text = "&nbsp;" Then GoTo NEXT_VALUE




    '            Try
    '                dTotal += Convert.ToDecimal(GridView1.Rows(k).Cells(1).Text)


    '            Catch ex As Exception

    '                Exit Sub
    '            End Try

    'NEXT_VALUE: Next
    '        Me.txtTotal.Text = dTotal.ToString("n")

    '    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
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
                    Dim trunc As String = "Delete from tbl_AccountClosure_Bulk where batchno='" & Me.txtBatch.Text.Trim & "'"
                    con.SqlDs(trunc)

                    For k = 0 To i - 1


                        Bulksched.AccountNumber = GridView1.Rows(k).Cells(0).Text
                        If Bulksched.AccountNumber = Nothing Then GoTo NEXT_VALUE
                        If Bulksched.AccountNumber = "&nbsp;" Then GoTo NEXT_VALUE
                        If GridView1.Rows(k).Cells(1).Text = Nothing Then GoTo NEXT_VALUE
                        If GridView1.Rows(k).Cells(1).Text = "&nbsp;" Then GoTo NEXT_VALUE
                        Bulksched.narration = GridView1.Rows(k).Cells(1).Text
                        Bulksched.Charges = GridView1.Rows(k).Cells(2).Text
                        

                        Try
                            con.SqlDs(InsertBulkScript(Bulksched))


                        Catch ex As Exception

                            Exit Sub
                        End Try

NEXT_VALUE:         Next

                    Dim insval As String = "declare @retval int,@retmsg varchar(200) exec Proc_Bulk_InsertClosure '" & Me.txtBatch.Text.Trim & "',@retval output,@retmsg output select @retval,@retmsg"
                    For Each dr As Data.DataRow In con.SqlDs(insval).Tables(0).Rows
                        retVal = dr(0).ToString
                        retMsg = dr(1).ToString
                    Next

                    smartobj.alertwindow(Me.Page, retMsg, "Prime")
                    Me.Label1.Text = retMsg
                    Button1.Text = "Return"
                    If retVal = "0" Then
                        ''Me.Button1.Enabled = False
                        Dim trunc1 As String = "Delete from tbl_AccountClosure_Bulk where batchno='" & Me.txtBatch.Text.Trim & "'"
                        con.SqlDs(trunc1)

                        Blogin = False
                        Me.GridView1.Visible = False
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
    Private Function InsertBulkScript(ByVal Bulksched As Lst_Schedule) As String
        Dim sqlstr As String
        sqlstr = "insert into tbl_AccountClosure_Bulk(AccountNumber,"
        sqlstr = sqlstr & "Narration,Charges,"
        sqlstr = sqlstr & "UserID, AuthID,batchno) values("
        sqlstr = sqlstr & smartobj.EncoteWithSingleQuote(Bulksched.AccountNumber) & ","
        sqlstr = sqlstr & smartobj.EncoteWithSingleQuote(Bulksched.narration.Trim) & ","
        sqlstr = sqlstr & smartobj.EncoteWithSingleQuote(Bulksched.Charges.Trim) & ","
        sqlstr = sqlstr & smartobj.EncoteWithSingleQuote(Session("Userid")) & ","
        sqlstr = sqlstr & smartobj.EncoteWithSingleQuote(Session("authuserid")) & ","
        sqlstr = sqlstr & smartobj.EncoteWithSingleQuote(Me.txtBatch.Text.Trim) & ")"

        Return sqlstr
    End Function

End Class
