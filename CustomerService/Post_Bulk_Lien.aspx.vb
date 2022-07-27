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
Partial Class CustomerService_Post_Bulk_Lien
    Inherits SessionCheck
    Private msgger As String
    Private DrAcctNumber As String
    Dim Bulksched As New Lst_Schedule
    Dim Blogin As Boolean
    Public qry As String
    Public Structure Lst_Schedule
        Public Holdnumber As String
        Public Accountnumber As String
        Public EffectiveDate As String
        Public EndDate As String
        Public CreateDate As String
        Public HoldAmount As String
        Public Status As String
        Public HoldReason As String
        Public userid As String
        Public authid As String
        Public Lientype As String
        Public Create_dt As String
    End Structure

    Protected Sub upload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles upload.Click
        'Upld()
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

    '            'If Me.DrpExcelType.SelectedValue <> "0" Then
    '            '    sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Server.MapPath("~/Upload/" + strFileNameOnly) + ";" + "Extended Properties=Excel 8.0;"
    '            '    objConn = New OleDbConnection(sConnectionString)
    '            'End If

    '            If Me.DrpExcelType.SelectedValue <> "0" Then
    '                'sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Server.MapPath("~/Upload/" + strFileNameOnly) + ";" + "Extended Properties=""Excel 4.0 Xml;HDR=YES;"""
    '                'objConn = New OleDbConnection(sConnectionString)
    '                sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Server.MapPath("~/Upload/" + strFileNameOnly) + ";" + "Extended Properties=""Excel 12.0 Xml;HDR=YES;"""
    '                objConn = New OleDbConnection(sConnectionString)
    '            End If


    '            objConn.Open()
    '            Dim objCmdSelect As OleDbCommand = New OleDbCommand("SELECT * FROM [sheet1$] where Accountnumber <> null ", objConn)

    '            Dim objAdapter1 As OleDbDataAdapter = New OleDbDataAdapter()
    '            Dim custCB As OleDbCommandBuilder = New OleDbCommandBuilder(objAdapter1)
    '            objAdapter1.SelectCommand = objCmdSelect
    '            Dim objDataset1 As DataSet = New DataSet()
    '            objAdapter1.AcceptChangesDuringFill = False
    '            objAdapter1.Fill(objDataset1, "Payment")

    '            Me.GridView1.DataSource = objDataset1.Tables(0).DefaultView
    '            GridView1.DataBind()

    '            'Label7.Text = GridView1.Rows.Count

    '            objConn.Close()

    '            If Me.GridView1.Rows.Count > 0 Then
    '                upload.Enabled = False
    '                Me.Button1.Enabled = True
    '                Me.GridView1.Visible = True
    '            Else
    '                upload.Enabled = True
    '                Me.Button1.Enabled = False
    '                Me.GridView1.Visible = False
    '            End If

    '            ''Dim proc As String = "Exec proc_Checkaccount"
    '            ''Dim conrec As Integer = con.SqlDs(proc).Tables(0).Rows.Count
    '            ''If conrec > 0 Then
    '            ''    For Each dr As DataRow In con.SqlDs(proc).Tables(0).Rows
    '            ''        Me.ListBox1.Visible = True
    '            ''        smartobj.loadListBox(Me.ListBox1, proc)

    '            ''        Me.Button1.Enabled = False
    '            ''    Next
    '            ''    Me.Label6.Visible = True
    '            ''    Me.Label6.Text = conrec & " Failed Account"

    '            ''Else
    '            ''    Me.Label6.Text = conrec & " Failed Account"

    '            ''    Me.Button1.Enabled = True
    '            ''    Me.ListBox1.Visible = False

    '            ''End If
    '        End If
    '    Catch ex As Exception
    '        Label9.Text = ex.Message.ToString
    '        Label9.Text = Label9.Text + "Please Check the Bulk upload template and make corrections "
    '        'Me.GridView1.Visible = False
    '        'MsgBox("An exception occurred:" & vbCrLf & ex.Message)
    '    End Try
    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then

            'If Session("UserID") = Nothing Then
            '    Response.Redirect("~/PageExpire.aspx")
            'End If

            Label1.Text = "Upload Bulk Lien From Excel File in Sheet$1"
            'GridView1.Visible = False"
            'LnkCharge0.NavigateUrl = "javascript:acctdetail('document.aspnetForm." + txtNoRow.ClientID.ToString() + "');"


            Me.PaneValidate.Visible = False
            Me.LblAccountLien.Visible = False
            Me.LblAccountvalidate.Visible = False
            Me.LblHoldAmount.Visible = False


            Dim RandomClass As New Random()

            Dim RandomNumber As Integer
            RandomNumber = RandomClass.Next(6, 9000000)

            Me.txtBatch.Text = RandomNumber
        End If
    End Sub
    Dim dTotal As Decimal = 0
    Dim ctotal As Decimal = 0
    'Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        dTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DebitTranAmount"))
    '        ctotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "creditTranAmount"))
    '    End If


    '    Me.txtTotal.Text = dTotal + ctotal

    '    If e.Row.RowType = DataControlRowType.Footer Then
    '        e.Row.Cells(1).Text = "Totals:"
    '        e.Row.Cells(2).Text = dTotal.ToString("n")
    '        e.Row.Cells(3).Text = ctotal.ToString("n")
    '        e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
    '        e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '        'Dim rect As Integer = CInt(dTotal1.ToString("n"))
    '        'e.Row.Cells(0).Text = "Total Count: " & rect
    '        'Me.Label10.Text = CInt(rect)
    '        e.Row.Font.Bold = True
    '    End If
    'End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try


            If DropReason.SelectedValue = "DY-BVN" Then

                BVNLien()
            Else
                OtherLien()
            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Function InsertBulkScript(ByVal Bulksched As Lst_Schedule) As String
        Dim sqlstr As String
        sqlstr = "insert into tbl_holdTransBulk(accountnumber,"
        sqlstr = sqlstr & "Effective_dt,End_dt,HoldAmount,HoldReason,UserId,"
        sqlstr = sqlstr & "authid, Status, Holdnumber,lientype,batchNo) values("
        sqlstr = sqlstr & smartobj.EncoteWithSingleQuote(Bulksched.Accountnumber) & ","
        sqlstr = sqlstr & " case when isdate(" & smartobj.EncoteWithSingleQuote(Bulksched.EffectiveDate) & ")<>1 then null else " & smartobj.EncoteWithSingleQuote(Bulksched.EffectiveDate) & "end ,"
        sqlstr = sqlstr & " case when isdate(" & smartobj.EncoteWithSingleQuote(Bulksched.EndDate) & ")<>1 then null else " & smartobj.EncoteWithSingleQuote(Bulksched.EndDate) & "end ,"
        sqlstr = sqlstr & Bulksched.HoldAmount & ","
        sqlstr = sqlstr & smartobj.EncoteWithSingleQuote(Bulksched.HoldReason) & ","
        sqlstr = sqlstr & smartobj.EncoteWithSingleQuote(Bulksched.userid) & ","
        sqlstr = sqlstr & smartobj.EncoteWithSingleQuote(Bulksched.authid) & ","
        sqlstr = sqlstr & smartobj.EncoteWithSingleQuote(Bulksched.Status) & ","
        'sqlstr = sqlstr & smartobj.EncoteWithSingleQuote(Bulksched.Create_dt) & ","
        sqlstr = sqlstr & smartobj.EncoteWithSingleQuote(Bulksched.Holdnumber) & ","
        sqlstr = sqlstr & smartobj.EncoteWithSingleQuote(Me.DrpLien.SelectedValue) & ","
        sqlstr = sqlstr & smartobj.EncoteWithSingleQuote(Me.txtBatch.Text.Trim) & ")"
        Return sqlstr
    End Function


    'Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
    '    Try
    '        Dim app As Object
    '        Dim xlbook As Object
    '        Dim xlsheet As Object
    '        app = CreateObject("Excel.Application")
    '        xlbook = app.Workbooks.Add()
    '        xlsheet = xlbook.ActiveSheet
    '        app.Visible = True
    '        Dim iX As Integer
    '        Dim iY As Integer
    '        Dim iC As Integer
    '        Dim iz As Integer
    '        For iC = 0 To GridView1.Columns.Count - 1
    '            xlsheet.Cells(1, iC + 1).Value = GridView1.Columns(iC).HeaderText
    '        Next
    '        iz = 1
    '        For iX = 0 To GridView1.Rows.Count - 1
    '            For iY = 0 To GridView1.Columns.Count - 1
    '                Dim a As String = GridView2(iY, iX).Value
    '                If a <> Nothing Then xlsheet.Cells(iz + 1, iY + 1).value = GridView1(iY, iX).Value.ToString
    '            Next
    '            iz = iz + 1
    '        Next

    '        MsgBox("Export Done", MsgBoxStyle.Information, "MODEL AND WARRANTY")

    '        app.Visible = True
    '        app.UserControl = True
    '        releaseobject(app)
    '        releaseobject(xlbook)
    '        releaseobject(xlsheet)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString())
    '    End Try
    'End Sub

    Sub releaseobject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        End Try
    End Sub

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


                Dim valuesarr As String = String.Empty
                'For i As Integer = 0 To dt.Rows.Count - 1
                For i As Integer = dt.Rows.Count - 1 To 0 Step -1
                    Dim lst As New List(Of Object)(dt.Rows(i).ItemArray)
                    For Each s As Object In lst
                        valuesarr &= s.ToString
                    Next
                    If String.IsNullOrEmpty(valuesarr) Then
                        'Remove row here, this row do not have any value
                        dt.Rows.RemoveAt(i)
                    End If
                Next



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

    Sub BVNLien()
        If Blogin = False Then
            Blogin = True

            Dim cmd As New SqlCommand
            Dim retVal As String = ""
            Dim retMsg As String = ""
            Dim i As Int32 = GridView1.Rows.Count
            Dim j As Int32 = GridView1.Columns.Count
            Dim k As Int32 = 0

            Try


                If DrpLien.SelectedValue = 0 Then
                    smartobj.alertwindow(Me.Page, "Please Select Lien Type", "prime")
                    Exit Sub
                End If

                If DropReason.SelectedValue = "NO_Value" Then
                    smartobj.alertwindow(Me.Page, "Please Select Option", "prime")
                    Exit Sub
                End If


                If Button1.Text <> "Return" Then
                    IO.File.Delete(Server.MapPath("~/Upload/" & Session("strFil1")))
                    Dim trunc As String = "Delete from tbl_holdTransBulk where batchno='" & Me.txtBatch.Text.Trim & "'"
                    con.SqlDs(trunc)

                    Dim RandomClass As New Random()
                    Dim RandomNumber As Integer

                    For k = 0 To i - 1


                        'RandomNumber = RandomClass.Next(6, 9000000)
                        'Me.txtBatch.Text = RandomNumber

                        Bulksched.Accountnumber = GridView1.Rows(k).Cells(0).Text
                        Bulksched.EffectiveDate = GridView1.Rows(k).Cells(1).Text
                        Bulksched.EndDate = GridView1.Rows(k).Cells(2).Text
                        Bulksched.HoldAmount = GridView1.Rows(k).Cells(3).Text
                        Bulksched.HoldReason = GridView1.Rows(k).Cells(4).Text
                        Bulksched.Status = "1"
                        Bulksched.userid = Session("Userid")
                        Bulksched.userid = Session("Userid")
                        Bulksched.Holdnumber = RandomClass.Next(11, 900000000)
                        'Bulksched.CreateDate = Profile.sysdate

                        'Bulksched.userid = "admin"
                        'Bulksched.authid = "admin"

                        If Bulksched.Accountnumber = "&nbsp;" Then
                            Bulksched.Accountnumber = Nothing
                        End If


                        If Bulksched.EffectiveDate = "&nbsp;" Then
                            Bulksched.EffectiveDate = Nothing
                        End If


                        If Bulksched.EndDate = "&nbsp;" Then
                            Bulksched.EndDate = Nothing
                        End If


                        If Bulksched.HoldAmount = "&nbsp;" Then
                            Bulksched.HoldAmount = "NULL"
                        End If

                        If Bulksched.Lientype = "&nbsp;" Then
                            Bulksched.Lientype = Nothing
                        End If


                        ''If Bulksched.HoldAmount < 0 Then
                        ''    smartobj.alertwindow(Me.Page, "Lien Amount cannot be less than Zeo: Please check the Upload file", "prime")
                        ''    Exit Sub
                        ''End If

                        Try
                            Dim selacct As String = "select count(1) from tbl_holdTransBulk where accountnumber='" & Bulksched.Accountnumber & "'"
                            Dim dr2 As Data.DataRow
                            dr2 = con.SqlDs(selacct).Tables(0).Rows(0)
                            Dim val As Integer = dr2.Item(0).ToString
                            Me.txtTotal.Text = val + 1


                            con.SqlDs(InsertBulkScript(Bulksched))

                        Catch ex As Exception

                            Exit Sub
                        End Try

                    Next

                    ' ''Dim insval As String = "declare @retval int,@retmsg varchar(200) proc_postBulk_lienAmount proc_postBulk '" & Me.txtBatch.Text.Trim & "',@retval output,@retmsg output select @retval,@retmsg"
                    ' ''For Each dr As Data.DataRow In con.SqlDs(insval).Tables(0).Rows
                    ' ''    retVal = dr(0).ToString
                    ' ''    retMsg = dr(1).ToString
                    ' ''Next

                    Dim insval As String = "declare @retval int,@retmsg varchar(200) exec proc_postBulk_lienAmount_BVN '" & Me.txtBatch.Text.Trim & "','" & Me.DropReason.SelectedValue & "',@retval output,@retmsg output select @retval,@retmsg"
                    For Each dr As Data.DataRow In con.SqlDs(insval).Tables(0).Rows
                        retVal = dr(0).ToString
                        retMsg = dr(1).ToString
                    Next
                    'Dim error2 As String = "select * from tbl_holdTransBulk_Error where batchno='" & Me.txtBatch.Text.Trim & "'"

                    Dim error2 As String = "SELECT a.accountnumber, a.effective_dt, a.End_dt, a.HoldAmount, a.HoldReason, STUFF((SELECT ';  ' + ErrorReason FROM tbl_holdtransbulk_error b WHERE b.accountnumber = a.accountnumber and BatchNo='" & Me.txtBatch.Text.Trim & "' FOR XML PATH('')), 1, 2, '') as 'ErrorReason' FROM tbl_holdtransbulk_error a where BatchNo='" & Me.txtBatch.Text.Trim & "' GROUP BY a.accountnumber, a.effective_dt, a.End_dt, a.HoldAmount, a.HoldReason"
                    con.SqlDs(error2)

                    If con.SqlDs(error2).Tables(0).Rows.Count > 0 Then

                        Session("Rpqry") = error2
                        Me.GridView2.DataSource = con.SqlDs(error2)
                        Me.GridView2.DataBind()
                        Me.GridView2.Visible = True

                        Me.PaneValidate.Visible = True
                        Me.LblAccountLien.Visible = True
                        Me.LblAccountvalidate.Visible = True
                        Me.LblHoldAmount.Visible = True

                    End If

                    smartobj.alertwindow(Me.Page, retMsg, "Prime")
                    Me.Button1.Enabled = False
                    'Me.Label1.Text = retMsg
                    'Button1.Text = "Return"
                    'If retVal = "0" Then
                    '    ''Me.Button1.Enabled = False
                    '    Blogin = False
                    '    Me.GridView1.Visible = False
                    '    Session("strFil1") = Nothing
                    'End If
                    Me.GridView1.Visible = False
                Else
                    Response.Redirect("Default.aspx")
                End If

            Catch ex As Exception
                smartobj.alertwindow(Me.Page, ex.Message, "Prime")
            End Try

            Blogin = False

        End If
    End Sub


    Sub OtherLien()
        If Blogin = False Then
            Blogin = True

            Dim cmd As New SqlCommand
            Dim retVal As String = ""
            Dim retMsg As String = ""
            Dim i As Int32 = GridView1.Rows.Count
            Dim j As Int32 = GridView1.Columns.Count
            Dim k As Int32 = 0

            Try


                If DrpLien.SelectedValue = 0 Then
                    smartobj.alertwindow(Me.Page, "Please Select Lien Type", "prime")
                    Exit Sub
                End If

                If DropReason.SelectedValue = "NO_Value" Then
                    smartobj.alertwindow(Me.Page, "Please Select Option", "prime")
                    Exit Sub
                End If


                If Button1.Text <> "Return" Then
                    IO.File.Delete(Server.MapPath("~/Upload/" & Session("strFil1")))
                    Dim trunc As String = "Delete from tbl_holdTransBulk where batchno='" & Me.txtBatch.Text.Trim & "'"
                    con.SqlDs(trunc)

                    Dim RandomClass As New Random()
                    Dim RandomNumber As Integer

                    For k = 0 To i - 1


                        'RandomNumber = RandomClass.Next(6, 9000000)
                        'Me.txtBatch.Text = RandomNumber

                        Bulksched.Accountnumber = GridView1.Rows(k).Cells(0).Text
                        Bulksched.EffectiveDate = GridView1.Rows(k).Cells(1).Text
                        Bulksched.EndDate = GridView1.Rows(k).Cells(2).Text
                        Bulksched.HoldAmount = GridView1.Rows(k).Cells(3).Text
                        Bulksched.HoldReason = GridView1.Rows(k).Cells(4).Text
                        Bulksched.Status = "1"
                        Bulksched.userid = Session("Userid")
                        Bulksched.userid = Session("Userid")
                        Bulksched.Holdnumber = RandomClass.Next(11, 900000000)
                        'Bulksched.CreateDate = Profile.sysdate

                        'Bulksched.userid = "admin"
                        'Bulksched.authid = "admin"

                        If Bulksched.Accountnumber = "&nbsp;" Then
                            Bulksched.Accountnumber = Nothing
                        End If


                        If Bulksched.EffectiveDate = "&nbsp;" Then
                            Bulksched.EffectiveDate = Nothing
                        End If


                        If Bulksched.EndDate = "&nbsp;" Then
                            Bulksched.EndDate = Nothing
                        End If


                        If Bulksched.HoldAmount = "&nbsp;" Then
                            Bulksched.HoldAmount = "NULL"
                        End If

                        If Bulksched.Lientype = "&nbsp;" Then
                            Bulksched.Lientype = Nothing
                        End If


                        ''If Bulksched.HoldAmount < 0 Then
                        ''    smartobj.alertwindow(Me.Page, "Lien Amount cannot be less than Zeo: Please check the Upload file", "prime")
                        ''    Exit Sub
                        ''End If

                        Try
                            Dim selacct As String = "select count(1) from tbl_holdTransBulk where accountnumber='" & Bulksched.Accountnumber & "'"
                            Dim dr2 As Data.DataRow
                            dr2 = con.SqlDs(selacct).Tables(0).Rows(0)
                            Dim val As Integer = dr2.Item(0).ToString
                            Me.txtTotal.Text = val + 1


                            con.SqlDs(InsertBulkScript(Bulksched))

                        Catch ex As Exception

                            Exit Sub
                        End Try

                    Next

                    ' ''Dim insval As String = "declare @retval int,@retmsg varchar(200) proc_postBulk_lienAmount proc_postBulk '" & Me.txtBatch.Text.Trim &                     "',@retval output,@retmsg output select @retval,@retmsg"
                    ' ''For Each dr As Data.DataRow In con.SqlDs(insval).Tables(0).Rows
                    ' ''    retVal = dr(0).ToString
                    ' ''    retMsg = dr(1).ToString
                    ' ''Next

                    Dim insval As String = "declare @retval int,@retmsg varchar(200) exec proc_postBulk_lienAmount_Other_lien '" & Me.txtBatch.Text.Trim & "','" & Me.DropReason.SelectedValue & "',@retval output,@retmsg output select @retval,@retmsg"
                    For Each dr As Data.DataRow In con.SqlDs(insval).Tables(0).Rows
                        retVal = dr(0).ToString
                        retMsg = dr(1).ToString
                    Next

                    'Dim error2 As String = "select * from tbl_holdTransBulk_Error where batchno='" & Me.txtBatch.Text.Trim & "'"

                    Dim error2 As String = "SELECT a.accountnumber, a.effective_dt, a.End_dt, a.HoldAmount, a.HoldReason, STUFF((SELECT ';  ' + ErrorReason FROM tbl_holdtransbulk_error b WHERE b.accountnumber = a.accountnumber and BatchNo='" & Me.txtBatch.Text.Trim & "' FOR XML PATH('')), 1, 2, '') as 'ErrorReason' FROM tbl_holdtransbulk_error a where BatchNo='" & Me.txtBatch.Text.Trim & "' GROUP BY a.accountnumber, a.effective_dt, a.End_dt, a.HoldAmount, a.HoldReason"





                    con.SqlDs(error2)

                    If con.SqlDs(error2).Tables(0).Rows.Count > 0 Then

                        Session("Rpqry") = error2
                        Me.GridView2.DataSource = con.SqlDs(error2)
                        Me.GridView2.DataBind()
                        Me.GridView2.Visible = True

                        Me.PaneValidate.Visible = True
                        Me.LblAccountLien.Visible = True
                        Me.LblAccountvalidate.Visible = True
                        Me.LblHoldAmount.Visible = True

                    End If

                    smartobj.alertwindow(Me.Page, retMsg, "Prime")
                    Me.Button1.Enabled = False
                    'Me.Label1.Text = retMsg
                    'Button1.Text = "Return"
                    'If retVal = "0" Then
                    '    ''Me.Button1.Enabled = False
                    '    Blogin = False
                    '    Me.GridView1.Visible = False
                    '    Session("strFil1") = Nothing
                    'End If
                    Me.GridView1.Visible = False
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
