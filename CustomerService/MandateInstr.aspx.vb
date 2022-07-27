Imports System
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data

Partial Class CustomerService_MandateInstr
    Inherits SessionCheck
    'Dim txt As New TextBox
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim cnt As Integer = 0
    Private MyCon As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Prime").ConnectionString)

    Dim qry As String = ""
#Region "Declaration"
    Dim chkrel As Integer
    Dim gvIDs As String = ""
    Dim chkBox As Boolean = False

#End Region
#Region "Page Load"

#End Region
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
#Region "Loadimage"
    Sub insone(ByVal serial As Integer)
        Try



            Dim filepath1 As String = File1.PostedFile.ContentType
            If File1.PostedFile Is Nothing Then
                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
                Me.Label32.Text = "Photo Image not Provided"

                Exit Sub

            End If

            Dim filetype1 As String ''= Path.GetExtension(filepath)
            ''filetype = filepath.Substring(filepath.LastIndexOf("."))
            filetype1 = File1.PostedFile.ContentType
            Dim filename1 As String = Path.GetFileNameWithoutExtension(filepath1)
            Dim filelength1 As Integer = Convert.ToInt32(File1.PostedFile.InputStream.Length)

            If (filelength1 > 80001) Then
                smartobj.alertwindow(Me.Page, "Upload Image too Large", "Prime")
                Exit Sub
            End If
            Dim filestream1 As Stream
            Dim buffer1(filelength1) As Byte
            filestream1 = File1.PostedFile.InputStream
            filestream1.Read(buffer1, 0, filelength1)


            Dim filepath2 As String = File2.PostedFile.ContentType
            If File2.PostedFile Is Nothing Then
                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
                Me.Label32.Text = "Signature Image not Provided"

                Exit Sub

            End If

            Dim filetype2 As String ''= Path.GetExtension(filepath)
            ''filetype = filepath.Substring(filepath.LastIndexOf("."))
            filetype2 = File2.PostedFile.ContentType
            Dim filename2 As String = Path.GetFileNameWithoutExtension(filepath2)
            Dim filelength2 As Integer = Convert.ToInt32(File2.PostedFile.InputStream.Length)

            If (filelength2 > 80001) Then
                smartobj.alertwindow(Me.Page, "Upload Image too Large", "Prime")
                Exit Sub
            End If
            Dim filestream2 As Stream
            Dim buffer2(filelength2) As Byte
            filestream2 = File2.PostedFile.InputStream
            filestream2.Read(buffer2, 0, filelength2)


            Dim proc As String = ""

            If Me.Btnsubmit.Text = "Submit" Then
                proc = "proc_insMandate"
            Else
                proc = "proc_updmandate"
            End If


            Dim cmd As Data.SqlClient.SqlCommand
            cmd = New Data.SqlClient.SqlCommand(proc, constring)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Accountno", SqlDbType.VarChar, 22)
            cmd.Parameters.Add("@content1", SqlDbType.Image)
            cmd.Parameters.Add("@content2", SqlDbType.Image)
            cmd.Parameters.Add("@type1", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@type2", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@signatoryname", SqlDbType.VarChar, 150)
            cmd.Parameters.Add("@designation", SqlDbType.VarChar, 100)
            cmd.Parameters.Add("@mandatedesc1", SqlDbType.VarChar, 80)

            cmd.Parameters.Add("@mandateid", SqlDbType.Int)
            cmd.Parameters.Add("@serial", SqlDbType.Int)
            cmd.Parameters.Add("@userid", SqlDbType.VarChar, 20)
            cmd.Parameters.Add("@authid", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Refid", SqlDbType.Int)
            cmd.Parameters.Add("@node_id", SqlDbType.Int)
            cmd.Parameters.Add("@retval", SqlDbType.Int)
            cmd.Parameters.Add("@retmsg", SqlDbType.VarChar, 50)

            cmd.Parameters(0).Value = Me.txtAcNumber.Text.Trim
            cmd.Parameters(1).Value = buffer1
            cmd.Parameters(2).Value = buffer2
            cmd.Parameters(3).Value = filetype1
            cmd.Parameters(4).Value = filetype2
            cmd.Parameters(5).Value = Me.txtname1.Text.Trim
            cmd.Parameters(6).Value = Me.txtdesig1.Text.Trim
            cmd.Parameters(7).Value = Me.txtmandate1.Text.Trim
            cmd.Parameters(8).Value = Me.txtcustomerid.Text.Trim
            cmd.Parameters(9).Value = serial
            cmd.Parameters(10).Value = Session("Userid")
            cmd.Parameters(11).Value = ""
            cmd.Parameters(12).Value = Session("EventLogID")
            cmd.Parameters(13).Value = Session("node_ID")
            cmd.Parameters(14).Direction = Data.ParameterDirection.Output
            cmd.Parameters(15).Direction = Data.ParameterDirection.Output

            constring.Close()
            constring.Open()

            Dim reader As System.Data.SqlClient.SqlDataReader = cmd.ExecuteReader()
            retval = cmd.Parameters.Item(14).Value
            retmsg = (cmd.Parameters.Item(15).Value).ToString

            If retval = 0 Then
                retmsg = "Image Uploaded Successfully"
            End If

            Session("retmsg") = retmsg
            reader.Close()
            cmd.Dispose()


            constring.Close()

            If retval = 0 Then
                Me.Label32.Text = "Image Uploaded successfully"
                cnt += 1

            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub instwo(ByVal serial As Integer)
        Try

            Dim filepath1 As String = File3.PostedFile.ContentType
            If File3.PostedFile Is Nothing Then
                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
                Me.Label32.Text = "Photo Image not Provided"

                Exit Sub

            End If

            Dim filetype1 As String ''= Path.GetExtension(filepath)
            ''filetype = filepath.Substring(filepath.LastIndexOf("."))
            filetype1 = File3.PostedFile.ContentType
            Dim filename1 As String = Path.GetFileNameWithoutExtension(filepath1)
            Dim filelength1 As Integer = Convert.ToInt32(File3.PostedFile.InputStream.Length)

            If (filelength1 > 80001) Then
                smartobj.alertwindow(Me.Page, "Upload Image too Large", "Prime")
                Exit Sub
            End If
            Dim filestream1 As Stream
            Dim buffer1(filelength1) As Byte
            filestream1 = File3.PostedFile.InputStream
            filestream1.Read(buffer1, 0, filelength1)


            Dim filepath2 As String = File4.PostedFile.ContentType
            If File4.PostedFile Is Nothing Then
                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
                Me.Label32.Text = "Signature Image not Provided"

                Exit Sub

            End If

            Dim filetype2 As String ''= Path.GetExtension(filepath)
            ''filetype = filepath.Substring(filepath.LastIndexOf("."))
            filetype2 = File4.PostedFile.ContentType
            Dim filename2 As String = Path.GetFileNameWithoutExtension(filepath2)
            Dim filelength2 As Integer = Convert.ToInt32(File4.PostedFile.InputStream.Length)

            If (filelength2 > 80001) Then
                smartobj.alertwindow(Me.Page, "Upload Image too Large", "Prime")
                Exit Sub
            End If
            Dim filestream2 As Stream
            Dim buffer2(filelength2) As Byte
            filestream2 = File4.PostedFile.InputStream
            filestream2.Read(buffer2, 0, filelength2)


            Dim proc As String = ""

            If Me.Btnsubmit.Text = "Submit" Then
                proc = "proc_insMandate"
            Else
                proc = "proc_updmandate"
            End If


            Dim cmd As Data.SqlClient.SqlCommand
            cmd = New Data.SqlClient.SqlCommand(proc, constring)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Accountno", SqlDbType.VarChar, 22)
            cmd.Parameters.Add("@content1", SqlDbType.Image)
            cmd.Parameters.Add("@content2", SqlDbType.Image)
            cmd.Parameters.Add("@type1", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@type2", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@signatoryname", SqlDbType.VarChar, 150)
            cmd.Parameters.Add("@designation", SqlDbType.VarChar, 60)
            cmd.Parameters.Add("@mandatedesc1", SqlDbType.VarChar, 80)

            cmd.Parameters.Add("@mandateid", SqlDbType.Int)
            cmd.Parameters.Add("@serial", SqlDbType.Int)
            cmd.Parameters.Add("@userid", SqlDbType.VarChar, 20)
            cmd.Parameters.Add("@authid", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Refid", SqlDbType.Int)
            cmd.Parameters.Add("@node_id", SqlDbType.Int)
            cmd.Parameters.Add("@retval", SqlDbType.Int)
            cmd.Parameters.Add("@retmsg", SqlDbType.VarChar, 50)

            cmd.Parameters(0).Value = Me.txtAcNumber.Text.Trim
            cmd.Parameters(1).Value = buffer1
            cmd.Parameters(2).Value = buffer2
            cmd.Parameters(3).Value = filetype1
            cmd.Parameters(4).Value = filetype2
            cmd.Parameters(5).Value = Me.txtname2.Text.Trim
            cmd.Parameters(6).Value = Me.txtdesig2.Text.Trim
            cmd.Parameters(7).Value = Me.txtmandate1.Text.Trim
            cmd.Parameters(8).Value = Me.txtcustomerid.Text.Trim
            cmd.Parameters(9).Value = serial
            cmd.Parameters(10).Value = Session("Userid")
            cmd.Parameters(11).Value = ""
            cmd.Parameters(12).Value = Session("EventLogID")
            cmd.Parameters(13).Value = Session("node_ID")
            cmd.Parameters(14).Direction = Data.ParameterDirection.Output
            cmd.Parameters(15).Direction = Data.ParameterDirection.Output

            constring.Close()
            constring.Open()

            Dim reader As System.Data.SqlClient.SqlDataReader = cmd.ExecuteReader()
            retval = cmd.Parameters.Item(14).Value
            retmsg = (cmd.Parameters.Item(15).Value).ToString
            If retval = 0 Then
                retmsg = "Image Uploaded Successfully"
            End If
            Session("retmsg") = retmsg
            reader.Close()
            cmd.Dispose()


            If retval = 0 Then
                Me.Label32.Text = "Image Uploaded successfully"
                cnt += 1
            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub insthree(ByVal serial As Integer)
        Try

            Dim filepath1 As String = File5.PostedFile.ContentType
            If File5.PostedFile Is Nothing Then
                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
                Me.Label32.Text = "Photo Image not Provided"

                Exit Sub

            End If


            Dim filetype1 As String ''= Path.GetExtension(filepath)
            ''filetype = filepath.Substring(filepath.LastIndexOf("."))
            filetype1 = File5.PostedFile.ContentType
            Dim filename1 As String = Path.GetFileNameWithoutExtension(filepath1)
            Dim filelength1 As Integer = Convert.ToInt32(File5.PostedFile.InputStream.Length)

            If (filelength1 > 80001) Then
                smartobj.alertwindow(Me.Page, "Upload Image too Large", "Prime")
                Exit Sub
            End If
            Dim filestream1 As Stream
            Dim buffer1(filelength1) As Byte
            filestream1 = File5.PostedFile.InputStream
            filestream1.Read(buffer1, 0, filelength1)


            Dim filepath2 As String = File6.PostedFile.ContentType
            If File6.PostedFile Is Nothing Then
                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
                Me.Label32.Text = "Signature Image not Provided"

                Exit Sub

            End If
            Dim filetype2 As String ''= Path.GetExtension(filepath)
            ''filetype = filepath.Substring(filepath.LastIndexOf("."))
            filetype2 = File6.PostedFile.ContentType
            Dim filename2 As String = Path.GetFileNameWithoutExtension(filepath2)
            Dim filelength2 As Integer = Convert.ToInt32(File6.PostedFile.InputStream.Length)

            If (filelength2 > 80001) Then
                smartobj.alertwindow(Me.Page, "Upload Image too Large", "Prime")
                Exit Sub
            End If
            Dim filestream2 As Stream
            Dim buffer2(filelength2) As Byte
            filestream2 = File6.PostedFile.InputStream
            filestream2.Read(buffer2, 0, filelength2)


            Dim proc As String = ""

            If Me.Btnsubmit.Text = "Submit" Then
                proc = "proc_insMandate"
            Else
                proc = "proc_updmandate"
            End If


            Dim cmd As Data.SqlClient.SqlCommand
            cmd = New Data.SqlClient.SqlCommand(proc, constring)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Accountno", SqlDbType.VarChar, 22)
            cmd.Parameters.Add("@content1", SqlDbType.Image)
            cmd.Parameters.Add("@content2", SqlDbType.Image)
            cmd.Parameters.Add("@type1", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@type2", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@signatoryname", SqlDbType.VarChar, 150)
            cmd.Parameters.Add("@designation", SqlDbType.VarChar, 60)
            cmd.Parameters.Add("@mandatedesc1", SqlDbType.VarChar, 80)

            cmd.Parameters.Add("@mandateid", SqlDbType.Int)
            cmd.Parameters.Add("@serial", SqlDbType.Int)
            cmd.Parameters.Add("@userid", SqlDbType.VarChar, 20)
            cmd.Parameters.Add("@authid", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Refid", SqlDbType.Int)
            cmd.Parameters.Add("@node_id", SqlDbType.Int)
            cmd.Parameters.Add("@retval", SqlDbType.Int)
            cmd.Parameters.Add("@retmsg", SqlDbType.VarChar, 50)

            cmd.Parameters(0).Value = Me.txtAcNumber.Text.Trim
            cmd.Parameters(1).Value = buffer1
            cmd.Parameters(2).Value = buffer2
            cmd.Parameters(3).Value = filetype1
            cmd.Parameters(4).Value = filetype2
            cmd.Parameters(5).Value = Me.txtname3.Text.Trim
            cmd.Parameters(6).Value = Me.txtdesig3.Text.Trim
            cmd.Parameters(7).Value = Me.txtmandate1.Text.Trim
            cmd.Parameters(8).Value = Me.txtcustomerid.Text.Trim
            cmd.Parameters(9).Value = serial
            cmd.Parameters(10).Value = Session("Userid")
            cmd.Parameters(11).Value = ""
            cmd.Parameters(12).Value = Session("EventLogID")
            cmd.Parameters(13).Value = Session("node_ID")
            cmd.Parameters(14).Direction = Data.ParameterDirection.Output
            cmd.Parameters(15).Direction = Data.ParameterDirection.Output

            constring.Close()
            constring.Open()

            Dim reader As System.Data.SqlClient.SqlDataReader = cmd.ExecuteReader()
            retval = cmd.Parameters.Item(14).Value
            retmsg = (cmd.Parameters.Item(15).Value).ToString
            If retval = 0 Then
                retmsg = "Image Uploaded Successfully"
            End If
            Session("retmsg") = retmsg
            reader.Close()
            cmd.Dispose()


            If retval = 0 Then
                Me.Label32.Text = "Image Uploaded successfully"
                cnt += 1
            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub insfour(ByVal serial As Integer)
        Try

            Dim filepath1 As String = File7.PostedFile.ContentType
            If File7.PostedFile Is Nothing Then
                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
                Me.Label32.Text = "Photo Image not Provided"

                Exit Sub

            End If

            Dim filetype1 As String ''= Path.GetExtension(filepath)
            ''filetype = filepath.Substring(filepath.LastIndexOf("."))
            filetype1 = File7.PostedFile.ContentType
            Dim filename1 As String = Path.GetFileNameWithoutExtension(filepath1)
            Dim filelength1 As Integer = Convert.ToInt32(File7.PostedFile.InputStream.Length)

            If (filelength1 > 80001) Then
                smartobj.alertwindow(Me.Page, "Upload Image too Large", "Prime")

                Exit Sub
            End If
            Dim filestream1 As Stream
            Dim buffer1(filelength1) As Byte
            filestream1 = File7.PostedFile.InputStream
            filestream1.Read(buffer1, 0, filelength1)


            Dim filepath2 As String = File8.PostedFile.ContentType
            If File8.PostedFile Is Nothing Then
                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
                Me.Label32.Text = "Signature Image not Provided"

                Exit Sub

            End If

            Dim filetype2 As String ''= Path.GetExtension(filepath)
            ''filetype = filepath.Substring(filepath.LastIndexOf("."))
            filetype2 = File8.PostedFile.ContentType
            Dim filename2 As String = Path.GetFileNameWithoutExtension(filepath2)
            Dim filelength2 As Integer = Convert.ToInt32(File8.PostedFile.InputStream.Length)

            If (filelength2 > 80001) Then
                smartobj.alertwindow(Me.Page, "Upload Image too Large", "Prime")
                Exit Sub
            End If
            Dim filestream2 As Stream
            Dim buffer2(filelength2) As Byte
            filestream2 = File8.PostedFile.InputStream
            filestream2.Read(buffer2, 0, filelength2)


            Dim proc As String = ""

            If Me.Btnsubmit.Text = "Submit" Then
                proc = "proc_insMandate"
            Else
                proc = "proc_updmandate"
            End If


            Dim cmd As Data.SqlClient.SqlCommand
            cmd = New Data.SqlClient.SqlCommand(proc, constring)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Accountno", SqlDbType.VarChar, 22)
            cmd.Parameters.Add("@content1", SqlDbType.Image)
            cmd.Parameters.Add("@content2", SqlDbType.Image)
            cmd.Parameters.Add("@type1", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@type2", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@signatoryname", SqlDbType.VarChar, 150)
            cmd.Parameters.Add("@designation", SqlDbType.VarChar, 60)
            cmd.Parameters.Add("@mandatedesc1", SqlDbType.VarChar, 80)

            cmd.Parameters.Add("@mandateid", SqlDbType.Int)
            cmd.Parameters.Add("@serial", SqlDbType.Int)
            cmd.Parameters.Add("@userid", SqlDbType.VarChar, 20)
            cmd.Parameters.Add("@authid", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Refid", SqlDbType.Int)
            cmd.Parameters.Add("@node_id", SqlDbType.Int)
            cmd.Parameters.Add("@retval", SqlDbType.Int)
            cmd.Parameters.Add("@retmsg", SqlDbType.VarChar, 50)

            cmd.Parameters(0).Value = Me.txtAcNumber.Text.Trim
            cmd.Parameters(1).Value = buffer1
            cmd.Parameters(2).Value = buffer2
            cmd.Parameters(3).Value = filetype1
            cmd.Parameters(4).Value = filetype2
            cmd.Parameters(5).Value = Me.txtname4.Text.Trim
            cmd.Parameters(6).Value = Me.txtdesig4.Text.Trim
            cmd.Parameters(7).Value = Me.txtmandate1.Text.Trim
            cmd.Parameters(8).Value = Me.txtcustomerid.Text.Trim
            cmd.Parameters(9).Value = serial
            cmd.Parameters(10).Value = Session("Userid")
            cmd.Parameters(11).Value = ""
            cmd.Parameters(12).Value = Session("EventLogID")
            cmd.Parameters(13).Value = Session("node_ID")
            cmd.Parameters(14).Direction = Data.ParameterDirection.Output
            cmd.Parameters(15).Direction = Data.ParameterDirection.Output

            constring.Close()
            constring.Open()

            Dim reader As System.Data.SqlClient.SqlDataReader = cmd.ExecuteReader()
            retval = cmd.Parameters.Item(14).Value
            retmsg = (cmd.Parameters.Item(15).Value).ToString
            If retval = 0 Then
                retmsg = "Image Uploaded Successfully"
            End If
            Session("retmsg") = retmsg
            reader.Close()
            cmd.Dispose()


            If retval = 0 Then
                Me.Label32.Text = "Image Uploaded successfully"
                cnt += 1
            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub insfive(ByVal serial As Integer)
        Try

            Dim filepath1 As String = File9.PostedFile.ContentType
            If File9.PostedFile Is Nothing Then
                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
                Me.Label32.Text = "Photo Image not Provided"

                Exit Sub

            End If

            Dim filetype1 As String ''= Path.GetExtension(filepath)
            ''filetype = filepath.Substring(filepath.LastIndexOf("."))
            filetype1 = File9.PostedFile.ContentType
            Dim filename1 As String = Path.GetFileNameWithoutExtension(filepath1)
            Dim filelength1 As Integer = Convert.ToInt32(File9.PostedFile.InputStream.Length)

            If (filelength1 > 80001) Then
                smartobj.alertwindow(Me.Page, "Upload Image too Large", "Prime")
                Exit Sub
            End If
            Dim filestream1 As Stream
            Dim buffer1(filelength1) As Byte
            filestream1 = File9.PostedFile.InputStream
            filestream1.Read(buffer1, 0, filelength1)


            Dim filepath2 As String = File10.PostedFile.ContentType
            If File10.PostedFile Is Nothing Then
                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
                Me.Label32.Text = "Signature Image not Provided"

                Exit Sub

            End If

            Dim filetype2 As String ''= Path.GetExtension(filepath)
            ''filetype = filepath.Substring(filepath.LastIndexOf("."))
            filetype2 = File10.PostedFile.ContentType
            Dim filename2 As String = Path.GetFileNameWithoutExtension(filepath2)
            Dim filelength2 As Integer = Convert.ToInt32(File10.PostedFile.InputStream.Length)

            If (filelength2 > 80001) Then
                smartobj.alertwindow(Me.Page, "Upload Image too Large", "Prime")
                Exit Sub
            End If
            Dim filestream2 As Stream
            Dim buffer2(filelength2) As Byte
            filestream2 = File10.PostedFile.InputStream
            filestream2.Read(buffer2, 0, filelength2)


            Dim proc As String = ""

            If Me.Btnsubmit.Text = "Submit" Then
                proc = "proc_insMandate"
            Else
                proc = "proc_updmandate"
            End If


            Dim cmd As Data.SqlClient.SqlCommand
            cmd = New Data.SqlClient.SqlCommand(proc, constring)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Accountno", SqlDbType.VarChar, 22)
            cmd.Parameters.Add("@content1", SqlDbType.Image)
            cmd.Parameters.Add("@content2", SqlDbType.Image)
            cmd.Parameters.Add("@type1", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@type2", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@signatoryname", SqlDbType.VarChar, 150)
            cmd.Parameters.Add("@designation", SqlDbType.VarChar, 60)
            cmd.Parameters.Add("@mandatedesc1", SqlDbType.VarChar, 80)

            cmd.Parameters.Add("@mandateid", SqlDbType.Int)
            cmd.Parameters.Add("@serial", SqlDbType.Int)
            cmd.Parameters.Add("@userid", SqlDbType.VarChar, 20)
            cmd.Parameters.Add("@authid", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Refid", SqlDbType.Int)
            cmd.Parameters.Add("@node_id", SqlDbType.Int)
            cmd.Parameters.Add("@retval", SqlDbType.Int)
            cmd.Parameters.Add("@retmsg", SqlDbType.VarChar, 50)

            cmd.Parameters(0).Value = Me.txtAcNumber.Text.Trim
            cmd.Parameters(1).Value = buffer1
            cmd.Parameters(2).Value = buffer2
            cmd.Parameters(3).Value = filetype1
            cmd.Parameters(4).Value = filetype2
            cmd.Parameters(5).Value = Me.txtname5.Text.Trim
            cmd.Parameters(6).Value = Me.txtdesig5.Text.Trim
            cmd.Parameters(7).Value = Me.txtmandate1.Text.Trim
            cmd.Parameters(8).Value = Me.txtcustomerid.Text.Trim
            cmd.Parameters(9).Value = serial
            cmd.Parameters(10).Value = Session("Userid")
            cmd.Parameters(11).Value = ""
            cmd.Parameters(12).Value = Session("EventLogID")
            cmd.Parameters(13).Value = Session("node_ID")
            cmd.Parameters(14).Direction = Data.ParameterDirection.Output
            cmd.Parameters(15).Direction = Data.ParameterDirection.Output

            constring.Close()
            constring.Open()

            Dim reader As System.Data.SqlClient.SqlDataReader = cmd.ExecuteReader()
            retval = cmd.Parameters.Item(14).Value
            retmsg = (cmd.Parameters.Item(15).Value).ToString

            If retval = 0 Then
                retmsg = "Image Uploaded Successfully"
            End If
            Session("retmsg") = retmsg
            reader.Close()
            cmd.Dispose()


            If retval = 0 Then
                Me.Label32.Text = "Image Uploaded successfully"
                cnt += 1
            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub insSix(ByVal serial As Integer)
        Try

            Dim filepath1 As String = File11.PostedFile.ContentType
            If File11.PostedFile Is Nothing Then
                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
                Me.Label32.Text = "Photo Image not Provided"

                Exit Sub

            End If

            Dim filetype1 As String ''= Path.GetExtension(filepath)
            ''filetype = filepath.Substring(filepath.LastIndexOf("."))
            filetype1 = File11.PostedFile.ContentType
            Dim filename1 As String = Path.GetFileNameWithoutExtension(filepath1)
            Dim filelength1 As Integer = Convert.ToInt32(File11.PostedFile.InputStream.Length)

            If (filelength1 > 80001) Then
                smartobj.alertwindow(Me.Page, "Upload Image too Large", "Prime")
                Exit Sub
            End If
            Dim filestream1 As Stream
            Dim buffer1(filelength1) As Byte
            filestream1 = File11.PostedFile.InputStream
            filestream1.Read(buffer1, 0, filelength1)


            Dim filepath2 As String = File12.PostedFile.ContentType
            If File12.PostedFile Is Nothing Then
                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
                Me.Label32.Text = "Signature Image not Provided"

                Exit Sub

            End If

            Dim filetype2 As String ''= Path.GetExtension(filepath)
            ''filetype = filepath.Substring(filepath.LastIndexOf("."))
            filetype2 = File12.PostedFile.ContentType
            Dim filename2 As String = Path.GetFileNameWithoutExtension(filepath2)
            Dim filelength2 As Integer = Convert.ToInt32(File12.PostedFile.InputStream.Length)

            If (filelength2 > 80001) Then
                smartobj.alertwindow(Me.Page, "Upload Image too Large", "Prime")
                Exit Sub
            End If
            Dim filestream2 As Stream
            Dim buffer2(filelength2) As Byte
            filestream2 = File12.PostedFile.InputStream
            filestream2.Read(buffer2, 0, filelength2)


            Dim proc As String = ""

            If Me.Btnsubmit.Text = "Submit" Then
                proc = "proc_insMandate"
            Else
                proc = "proc_updmandate"
            End If


            Dim cmd As Data.SqlClient.SqlCommand
            cmd = New Data.SqlClient.SqlCommand(proc, constring)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Accountno", SqlDbType.VarChar, 22)
            cmd.Parameters.Add("@content1", SqlDbType.Image)
            cmd.Parameters.Add("@content2", SqlDbType.Image)
            cmd.Parameters.Add("@type1", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@type2", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@signatoryname", SqlDbType.VarChar, 150)
            cmd.Parameters.Add("@designation", SqlDbType.VarChar, 60)
            cmd.Parameters.Add("@mandatedesc1", SqlDbType.VarChar, 80)

            cmd.Parameters.Add("@mandateid", SqlDbType.Int)
            cmd.Parameters.Add("@serial", SqlDbType.Int)
            cmd.Parameters.Add("@userid", SqlDbType.VarChar, 20)
            cmd.Parameters.Add("@authid", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Refid", SqlDbType.Int)
            cmd.Parameters.Add("@node_id", SqlDbType.Int)
            cmd.Parameters.Add("@retval", SqlDbType.Int)
            cmd.Parameters.Add("@retmsg", SqlDbType.VarChar, 50)

            cmd.Parameters(0).Value = Me.txtAcNumber.Text.Trim
            cmd.Parameters(1).Value = buffer1
            cmd.Parameters(2).Value = buffer2
            cmd.Parameters(3).Value = filetype1
            cmd.Parameters(4).Value = filetype2
            cmd.Parameters(5).Value = Me.txtname6.Text.Trim
            cmd.Parameters(6).Value = Me.txtdesig6.Text.Trim
            cmd.Parameters(7).Value = Me.txtmandate1.Text.Trim
            cmd.Parameters(8).Value = Me.txtcustomerid.Text.Trim
            cmd.Parameters(9).Value = serial
            cmd.Parameters(10).Value = Session("Userid")
            cmd.Parameters(11).Value = ""
            cmd.Parameters(12).Value = Session("EventLogID")
            cmd.Parameters(13).Value = Session("node_ID")
            cmd.Parameters(14).Direction = Data.ParameterDirection.Output
            cmd.Parameters(15).Direction = Data.ParameterDirection.Output

            constring.Close()
            constring.Open()

            Dim reader As System.Data.SqlClient.SqlDataReader = cmd.ExecuteReader()
            retval = cmd.Parameters.Item(14).Value
            retmsg = (cmd.Parameters.Item(15).Value).ToString

            If retval = 0 Then
                retmsg = "Image Uploaded Successfully"
            End If
            Session("retmsg") = retmsg
            reader.Close()
            cmd.Dispose()


            If retval = 0 Then
                Me.Label32.Text = "Image Uploaded successfully"
                cnt += 1
            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub insSeven(ByVal serial As Integer)
        Try

            Dim filepath1 As String = File13.PostedFile.ContentType
            If File13.PostedFile Is Nothing Then
                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
                Me.Label32.Text = "Photo Image not Provided"

                Exit Sub

            End If

            Dim filetype1 As String ''= Path.GetExtension(filepath)
            ''filetype = filepath.Substring(filepath.LastIndexOf("."))
            filetype1 = File13.PostedFile.ContentType
            Dim filename1 As String = Path.GetFileNameWithoutExtension(filepath1)
            Dim filelength1 As Integer = Convert.ToInt32(File13.PostedFile.InputStream.Length)

            If (filelength1 > 80001) Then
                smartobj.alertwindow(Me.Page, "Upload Image too Large", "Prime")
                Exit Sub
            End If
            Dim filestream1 As Stream
            Dim buffer1(filelength1) As Byte
            filestream1 = File13.PostedFile.InputStream
            filestream1.Read(buffer1, 0, filelength1)


            Dim filepath2 As String = File13.PostedFile.ContentType
            If File13.PostedFile Is Nothing Then
                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
                Me.Label32.Text = "Signature Image not Provided"

                Exit Sub

            End If

            Dim filetype2 As String ''= Path.GetExtension(filepath)
            ''filetype = filepath.Substring(filepath.LastIndexOf("."))
            filetype2 = File14.PostedFile.ContentType
            Dim filename2 As String = Path.GetFileNameWithoutExtension(filepath2)
            Dim filelength2 As Integer = Convert.ToInt32(File14.PostedFile.InputStream.Length)

            If (filelength2 > 80001) Then
                smartobj.alertwindow(Me.Page, "Upload Image too Large", "Prime")
                Exit Sub
            End If
            Dim filestream2 As Stream
            Dim buffer2(filelength2) As Byte
            filestream2 = File14.PostedFile.InputStream
            filestream2.Read(buffer2, 0, filelength2)


            Dim proc As String = ""

            If Me.Btnsubmit.Text = "Submit" Then
                proc = "proc_insMandate"
            Else
                proc = "proc_updmandate"
            End If


            Dim cmd As Data.SqlClient.SqlCommand
            cmd = New Data.SqlClient.SqlCommand(proc, constring)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Accountno", SqlDbType.VarChar, 22)
            cmd.Parameters.Add("@content1", SqlDbType.Image)
            cmd.Parameters.Add("@content2", SqlDbType.Image)
            cmd.Parameters.Add("@type1", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@type2", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@signatoryname", SqlDbType.VarChar, 150)
            cmd.Parameters.Add("@designation", SqlDbType.VarChar, 60)
            cmd.Parameters.Add("@mandatedesc1", SqlDbType.VarChar, 80)

            cmd.Parameters.Add("@mandateid", SqlDbType.Int)
            cmd.Parameters.Add("@serial", SqlDbType.Int)
            cmd.Parameters.Add("@userid", SqlDbType.VarChar, 20)
            cmd.Parameters.Add("@authid", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Refid", SqlDbType.Int)
            cmd.Parameters.Add("@node_id", SqlDbType.Int)
            cmd.Parameters.Add("@retval", SqlDbType.Int)
            cmd.Parameters.Add("@retmsg", SqlDbType.VarChar, 50)

            cmd.Parameters(0).Value = Me.txtAcNumber.Text.Trim
            cmd.Parameters(1).Value = buffer1
            cmd.Parameters(2).Value = buffer2
            cmd.Parameters(3).Value = filetype1
            cmd.Parameters(4).Value = filetype2
            cmd.Parameters(5).Value = Me.txtname7.Text.Trim
            cmd.Parameters(6).Value = Me.txtdesig7.Text.Trim
            cmd.Parameters(7).Value = Me.txtmandate1.Text.Trim
            cmd.Parameters(8).Value = Me.txtcustomerid.Text.Trim
            cmd.Parameters(9).Value = serial
            cmd.Parameters(10).Value = Session("Userid")
            cmd.Parameters(11).Value = ""
            cmd.Parameters(12).Value = Session("EventLogID")
            cmd.Parameters(13).Value = Session("node_ID")
            cmd.Parameters(14).Direction = Data.ParameterDirection.Output
            cmd.Parameters(15).Direction = Data.ParameterDirection.Output

            constring.Close()
            constring.Open()

            Dim reader As System.Data.SqlClient.SqlDataReader = cmd.ExecuteReader()
            retval = cmd.Parameters.Item(14).Value
            retmsg = (cmd.Parameters.Item(15).Value).ToString

            If retval = 0 Then
                retmsg = "Image Uploaded Successfully"
            End If
            Session("retmsg") = retmsg
            reader.Close()
            cmd.Dispose()


            If retval = 0 Then
                Me.Label32.Text = "Image Uploaded successfully"
                cnt += 1
            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub insEight(ByVal serial As Integer)
        Try

            Dim filepath1 As String = File15.PostedFile.ContentType
            If File15.PostedFile Is Nothing Then
                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
                Me.Label32.Text = "Photo Image not Provided"

                Exit Sub

            End If

            Dim filetype1 As String ''= Path.GetExtension(filepath)
            ''filetype = filepath.Substring(filepath.LastIndexOf("."))
            filetype1 = File15.PostedFile.ContentType
            Dim filename1 As String = Path.GetFileNameWithoutExtension(filepath1)
            Dim filelength1 As Integer = Convert.ToInt32(File15.PostedFile.InputStream.Length)

            If (filelength1 > 80001) Then
                smartobj.alertwindow(Me.Page, "Upload Image too Large", "Prime")
                Exit Sub
            End If
            Dim filestream1 As Stream
            Dim buffer1(filelength1) As Byte
            filestream1 = File15.PostedFile.InputStream
            filestream1.Read(buffer1, 0, filelength1)


            Dim filepath2 As String = File16.PostedFile.ContentType
            If File16.PostedFile Is Nothing Then
                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
                Me.Label32.Text = "Signature Image not Provided"

                Exit Sub

            End If

            Dim filetype2 As String ''= Path.GetExtension(filepath)
            ''filetype = filepath.Substring(filepath.LastIndexOf("."))
            filetype2 = File16.PostedFile.ContentType
            Dim filename2 As String = Path.GetFileNameWithoutExtension(filepath2)
            Dim filelength2 As Integer = Convert.ToInt32(File16.PostedFile.InputStream.Length)

            If (filelength2 > 80001) Then
                smartobj.alertwindow(Me.Page, "Upload Image too Large", "Prime")
                Exit Sub
            End If
            Dim filestream2 As Stream
            Dim buffer2(filelength2) As Byte
            filestream2 = File16.PostedFile.InputStream
            filestream2.Read(buffer2, 0, filelength2)


            Dim proc As String = ""

            If Me.Btnsubmit.Text = "Submit" Then
                proc = "proc_insMandate"
            Else
                proc = "proc_updmandate"
            End If


            Dim cmd As Data.SqlClient.SqlCommand
            cmd = New Data.SqlClient.SqlCommand(proc, constring)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Accountno", SqlDbType.VarChar, 22)
            cmd.Parameters.Add("@content1", SqlDbType.Image)
            cmd.Parameters.Add("@content2", SqlDbType.Image)
            cmd.Parameters.Add("@type1", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@type2", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@signatoryname", SqlDbType.VarChar, 150)
            cmd.Parameters.Add("@designation", SqlDbType.VarChar, 60)
            cmd.Parameters.Add("@mandatedesc1", SqlDbType.VarChar, 80)

            cmd.Parameters.Add("@mandateid", SqlDbType.Int)
            cmd.Parameters.Add("@serial", SqlDbType.Int)
            cmd.Parameters.Add("@userid", SqlDbType.VarChar, 20)
            cmd.Parameters.Add("@authid", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Refid", SqlDbType.Int)
            cmd.Parameters.Add("@node_id", SqlDbType.Int)
            cmd.Parameters.Add("@retval", SqlDbType.Int)
            cmd.Parameters.Add("@retmsg", SqlDbType.VarChar, 50)

            cmd.Parameters(0).Value = Me.txtAcNumber.Text.Trim
            cmd.Parameters(1).Value = buffer1
            cmd.Parameters(2).Value = buffer2
            cmd.Parameters(3).Value = filetype1
            cmd.Parameters(4).Value = filetype2
            cmd.Parameters(5).Value = Me.txtname8.Text.Trim
            cmd.Parameters(6).Value = Me.txtdesig8.Text.Trim
            cmd.Parameters(7).Value = Me.txtmandate1.Text.Trim
            cmd.Parameters(8).Value = Me.txtcustomerid.Text.Trim
            cmd.Parameters(9).Value = serial
            cmd.Parameters(10).Value = Session("Userid")
            cmd.Parameters(11).Value = ""
            cmd.Parameters(12).Value = Session("EventLogID")
            cmd.Parameters(13).Value = Session("node_ID")
            cmd.Parameters(14).Direction = Data.ParameterDirection.Output
            cmd.Parameters(15).Direction = Data.ParameterDirection.Output

            constring.Close()
            constring.Open()

            Dim reader As System.Data.SqlClient.SqlDataReader = cmd.ExecuteReader()
            retval = cmd.Parameters.Item(14).Value
            retmsg = (cmd.Parameters.Item(15).Value).ToString

            If retval = 0 Then
                retmsg = "Image Uploaded Successfully"
            End If
            Session("retmsg") = retmsg
            reader.Close()
            cmd.Dispose()


            If retval = 0 Then
                Me.Label32.Text = "Image Uploaded successfully"
                cnt += 1
            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub insNine(ByVal serial As Integer)
        Try

            Dim filepath1 As String = File17.PostedFile.ContentType
            If File17.PostedFile Is Nothing Then
                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
                Me.Label32.Text = "Photo Image not Provided"

                Exit Sub

            End If

            Dim filetype1 As String ''= Path.GetExtension(filepath)
            ''filetype = filepath.Substring(filepath.LastIndexOf("."))
            filetype1 = File17.PostedFile.ContentType
            Dim filename1 As String = Path.GetFileNameWithoutExtension(filepath1)
            Dim filelength1 As Integer = Convert.ToInt32(File17.PostedFile.InputStream.Length)

            If (filelength1 > 80001) Then
                smartobj.alertwindow(Me.Page, "Upload Image too Large", "Prime")
                Exit Sub
            End If
            Dim filestream1 As Stream
            Dim buffer1(filelength1) As Byte
            filestream1 = File17.PostedFile.InputStream
            filestream1.Read(buffer1, 0, filelength1)


            Dim filepath2 As String = File18.PostedFile.ContentType
            If File18.PostedFile Is Nothing Then
                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
                Me.Label32.Text = "Signature Image not Provided"

                Exit Sub

            End If

            Dim filetype2 As String ''= Path.GetExtension(filepath)
            ''filetype = filepath.Substring(filepath.LastIndexOf("."))
            filetype2 = File18.PostedFile.ContentType
            Dim filename2 As String = Path.GetFileNameWithoutExtension(filepath2)
            Dim filelength2 As Integer = Convert.ToInt32(File18.PostedFile.InputStream.Length)

            If (filelength2 > 80001) Then
                smartobj.alertwindow(Me.Page, "Upload Image too Large", "Prime")
                Exit Sub
            End If
            Dim filestream2 As Stream
            Dim buffer2(filelength2) As Byte
            filestream2 = File18.PostedFile.InputStream
            filestream2.Read(buffer2, 0, filelength2)


            Dim proc As String = ""

            If Me.Btnsubmit.Text = "Submit" Then
                proc = "proc_insMandate"
            Else
                proc = "proc_updmandate"
            End If


            Dim cmd As Data.SqlClient.SqlCommand
            cmd = New Data.SqlClient.SqlCommand(proc, constring)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Accountno", SqlDbType.VarChar, 22)
            cmd.Parameters.Add("@content1", SqlDbType.Image)
            cmd.Parameters.Add("@content2", SqlDbType.Image)
            cmd.Parameters.Add("@type1", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@type2", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@signatoryname", SqlDbType.VarChar, 150)
            cmd.Parameters.Add("@designation", SqlDbType.VarChar, 60)
            cmd.Parameters.Add("@mandatedesc1", SqlDbType.VarChar, 80)

            cmd.Parameters.Add("@mandateid", SqlDbType.Int)
            cmd.Parameters.Add("@serial", SqlDbType.Int)
            cmd.Parameters.Add("@userid", SqlDbType.VarChar, 20)
            cmd.Parameters.Add("@authid", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Refid", SqlDbType.Int)
            cmd.Parameters.Add("@node_id", SqlDbType.Int)
            cmd.Parameters.Add("@retval", SqlDbType.Int)
            cmd.Parameters.Add("@retmsg", SqlDbType.VarChar, 50)

            cmd.Parameters(0).Value = Me.txtAcNumber.Text.Trim
            cmd.Parameters(1).Value = buffer1
            cmd.Parameters(2).Value = buffer2
            cmd.Parameters(3).Value = filetype1
            cmd.Parameters(4).Value = filetype2
            cmd.Parameters(5).Value = Me.txtname9.Text.Trim
            cmd.Parameters(6).Value = Me.txtdesig9.Text.Trim
            cmd.Parameters(7).Value = Me.txtmandate1.Text.Trim
            cmd.Parameters(8).Value = Me.txtcustomerid.Text.Trim
            cmd.Parameters(9).Value = serial
            cmd.Parameters(10).Value = Session("Userid")
            cmd.Parameters(11).Value = ""
            cmd.Parameters(12).Value = Session("EventLogID")
            cmd.Parameters(13).Value = Session("node_ID")
            cmd.Parameters(14).Direction = Data.ParameterDirection.Output
            cmd.Parameters(15).Direction = Data.ParameterDirection.Output

            constring.Close()
            constring.Open()

            Dim reader As System.Data.SqlClient.SqlDataReader = cmd.ExecuteReader()
            retval = cmd.Parameters.Item(14).Value
            retmsg = (cmd.Parameters.Item(15).Value).ToString

            If retval = 0 Then
                retmsg = "Image Uploaded Successfully"
            End If
            Session("retmsg") = retmsg
            reader.Close()
            cmd.Dispose()


            If retval = 0 Then
                Me.Label32.Text = "Image Uploaded successfully"
                cnt += 1
            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub insTen(ByVal serial As Integer)
        Try

            Dim filepath1 As String = File19.PostedFile.ContentType
            If File19.PostedFile Is Nothing Then
                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
                Me.Label32.Text = "Photo Image not Provided"

                Exit Sub

            End If

            Dim filetype1 As String ''= Path.GetExtension(filepath)
            ''filetype = filepath.Substring(filepath.LastIndexOf("."))
            filetype1 = File19.PostedFile.ContentType
            Dim filename1 As String = Path.GetFileNameWithoutExtension(filepath1)
            Dim filelength1 As Integer = Convert.ToInt32(File19.PostedFile.InputStream.Length)

            If (filelength1 > 80001) Then
                smartobj.alertwindow(Me.Page, "Upload Image too Large", "Prime")
                Exit Sub
            End If
            Dim filestream1 As Stream
            Dim buffer1(filelength1) As Byte
            filestream1 = File19.PostedFile.InputStream
            filestream1.Read(buffer1, 0, filelength1)


            Dim filepath2 As String = File20.PostedFile.ContentType
            If File20.PostedFile Is Nothing Then
                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
                Me.Label32.Text = "Signature Image not Provided"

                Exit Sub

            End If

            Dim filetype2 As String ''= Path.GetExtension(filepath)
            ''filetype = filepath.Substring(filepath.LastIndexOf("."))
            filetype2 = File20.PostedFile.ContentType
            Dim filename2 As String = Path.GetFileNameWithoutExtension(filepath2)
            Dim filelength2 As Integer = Convert.ToInt32(File20.PostedFile.InputStream.Length)

            If (filelength2 > 80001) Then
                smartobj.alertwindow(Me.Page, "Upload Image too Large", "Prime")
                Exit Sub
            End If
            Dim filestream2 As Stream
            Dim buffer2(filelength2) As Byte
            filestream2 = File20.PostedFile.InputStream
            filestream2.Read(buffer2, 0, filelength2)


            Dim proc As String = ""

            If Me.Btnsubmit.Text = "Submit" Then
                proc = "proc_insMandate"
            Else
                proc = "proc_updmandate"
            End If


            Dim cmd As Data.SqlClient.SqlCommand
            cmd = New Data.SqlClient.SqlCommand(proc, constring)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Accountno", SqlDbType.VarChar, 22)
            cmd.Parameters.Add("@content1", SqlDbType.Image)
            cmd.Parameters.Add("@content2", SqlDbType.Image)
            cmd.Parameters.Add("@type1", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@type2", SqlDbType.VarChar, 30)
            cmd.Parameters.Add("@signatoryname", SqlDbType.VarChar, 150)
            cmd.Parameters.Add("@designation", SqlDbType.VarChar, 60)
            cmd.Parameters.Add("@mandatedesc1", SqlDbType.VarChar, 80)

            cmd.Parameters.Add("@mandateid", SqlDbType.Int)
            cmd.Parameters.Add("@serial", SqlDbType.Int)
            cmd.Parameters.Add("@userid", SqlDbType.VarChar, 20)
            cmd.Parameters.Add("@authid", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@Refid", SqlDbType.Int)
            cmd.Parameters.Add("@node_id", SqlDbType.Int)
            cmd.Parameters.Add("@retval", SqlDbType.Int)
            cmd.Parameters.Add("@retmsg", SqlDbType.VarChar, 50)

            cmd.Parameters(0).Value = Me.txtAcNumber.Text.Trim
            cmd.Parameters(1).Value = buffer1
            cmd.Parameters(2).Value = buffer2
            cmd.Parameters(3).Value = filetype1
            cmd.Parameters(4).Value = filetype2
            cmd.Parameters(5).Value = Me.txtname10.Text.Trim
            cmd.Parameters(6).Value = Me.txtdesig10.Text.Trim
            cmd.Parameters(7).Value = Me.txtmandate1.Text.Trim
            cmd.Parameters(8).Value = Me.txtcustomerid.Text.Trim
            cmd.Parameters(9).Value = serial
            cmd.Parameters(10).Value = Session("Userid")
            cmd.Parameters(11).Value = ""
            cmd.Parameters(12).Value = Session("EventLogID")
            cmd.Parameters(13).Value = Session("node_ID")
            cmd.Parameters(14).Direction = Data.ParameterDirection.Output
            cmd.Parameters(15).Direction = Data.ParameterDirection.Output

            constring.Close()
            constring.Open()

            Dim reader As System.Data.SqlClient.SqlDataReader = cmd.ExecuteReader()
            retval = cmd.Parameters.Item(14).Value
            retmsg = (cmd.Parameters.Item(15).Value).ToString

            If retval = 0 Then
                retmsg = "Image Uploaded Successfully"
            End If
            Session("retmsg") = retmsg
            reader.Close()
            cmd.Dispose()


            If retval = 0 Then
                Me.Label32.Text = "Image Uploaded successfully"
                cnt += 1
            End If

        Catch ex As Exception

        End Try

    End Sub
#End Region
    Protected Sub txtAcNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcNumber.TextChanged

        Me.Label33.Text = ""
        Me.Label32.Text = ""

        txtcustomerid.Text = ""

        Try

            Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtAcNumber.Text.Trim & "',@retval output,@retmsg output, " & Session("node_ID") & " select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            If retval = "0" Then
                Me.txtAcNumber.Text = retmsg
            End If

            Dim selExist As String = "Exec Proc_CustAcctDetail '" & Me.txtAcNumber.Text.Trim & "', " & Session("node_ID") & ""
            If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then
                drx = con.SqlDs(selExist).Tables(0).Rows(0)
                Me.Label1.Text = drx.Item("accounttitle").ToString
                Me.Label2.Text = drx.Item("prodname").ToString
                Me.Label3.Text = drx.Item("branch").ToString
                Me.Label4.Text = smartobj.FormatMoney(Format(drx.Item("bkbal"), "###0.00"))
                Me.Label5.Text = smartobj.FormatMoney(Format(drx.Item("effbal"), "###0.00"))
                Me.Label6.Text = smartobj.FormatMoney(Format(drx.Item("usebal"), "###0.00"))
                Me.Label7.Text = drx.Item("acctty").ToString
                Me.Label8.Text = drx.Item("source").ToString
                Me.Label9.Text = drx.Item("acctstatus").ToString
                Dim prostatus As String = drx.Item("prodstatus").ToString
                Dim prodesc As String = drx.Item("proddesc").ToString
                Me.txtcustomerid.Text = drx.Item("customerid").ToString.Trim

                'Image1.Visible = True
                'Image1.ImageUrl = FormatURL(idimg)

                If Me.Label9.Text = "Active" Then
                    Me.AcctStatus.Attributes.Add("class", "pull-right badge bg-green")
                Else

                    Me.AcctStatus.Attributes.Add("class", "pull-right badge bg-red")

                End If
                If drx.Item("bkbal") > 0 Then

                    Me.BookBalance.Attributes.Add("class", "pull-right badge bg-green")
                Else

                    Me.BookBalance.Attributes.Add("class", "pull-right badge bg-red")

                End If
                If drx.Item("effbal") > 0 Then

                    Me.EffectiveBal.Attributes.Add("class", "pull-right badge bg-green")
                Else

                    Me.EffectiveBal.Attributes.Add("class", "pull-right badge bg-red")

                End If

                If drx.Item("usebal") > 0 Then

                    Me.UsableBal.Attributes.Add("class", "pull-right badge bg-green")
                Else

                    Me.UsableBal.Attributes.Add("class", "pull-right badge bg-red")

                End If

                If prostatus = "1" Then
                    smartobj.alertwindow(Me.Page, prodesc, "Prime")
                    Me.Btnsubmit.Enabled = False
                Else
                    Me.Btnsubmit.Enabled = True
                End If

                Dim selexist1 As String = "exec proc_mandatelist '" & Me.txtAcNumber.Text.Trim & "', " & Session("node_ID") & ""
                If con.SqlDs(selexist1).Tables(0).Rows.Count > 0 Then
                    ''smartobj.alertwindow(Me.Page, "Mandate Already Attached to Account.You can Proceed to Modify Account", "Prime")
                    Me.Label32.Text = "Mandate Already Attached to Account.You can Proceed to Modify Mandate Detail. Please note that to increase or decrease the number of signatories, you need to remove mandate and add new one(s)."
                    Me.Btnsubmit.Text = "Update"
                    Me.txtnosign.Text = con.SqlDs(selexist1).Tables(0).Rows.Count
                    ''much display
                    refresh2()
                Else
                    Me.Btnsubmit.Text = "Submit"
                    Me.txtnosign.Text = "1"
                    viscase1()
                End If
            Else
                Me.Label1.Text = ""
                Me.Label2.Text = ""
                Me.Label3.Text = ""
                Me.Label4.Text = ""
                Me.Label5.Text = ""
                Me.Label6.Text = ""
                Me.Label7.Text = ""
                Me.Label8.Text = ""
                Me.Label9.Text = ""
                'Image1.Visible = False
                smartobj.alertwindow(Me.Page, "Account Number Does Not Exist", "Prime")

                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub
    'Sub insmandate()
    '    Dim strFileName As String
    '    Dim objFile As HttpPostedFile
    '    Dim files As HttpFileCollection = Page.Request.Files
    '    Dim iu As Integer = Request.Files.Count
    '    Dim ii As Integer = CInt(Me.txtnosign.Text.Trim)
    '    Dim i As Integer
    '    Try
    '        For i = 0 To ii - 1
    '            objFile = Request.Files(i)
    '            If Not (objFile Is Nothing Or objFile.FileName = "" Or objFile.ContentLength < 1) Then
    '                strFileName = objFile.FileName
    '                strFileName = Path.GetFileName(strFileName)

    '                Dim filetype1 As String ''= Path.GetExtension(filepath)
    '                ''filetype = filepath.Substring(filepath.LastIndexOf("."))
    '                filetype1 = objFile.ContentType
    '                Dim filelength1 As Integer = Convert.ToInt32(objFile.InputStream.Length)

    '                If (filelength1 > 35001) Then
    '                    smartobj.alertwindow(Me.Page, "Upload Image too Large", "Prime")
    '                    Exit Sub
    '                Else
    '                    Dim ext As String = ""

    '                    ext = strFileName.Substring(strFileName.LastIndexOf("."))
    '                    ext = ext.ToLower

    '                    If ext <> "jpg" Or ext <> "gif" Then
    '                        smartobj.alertwindow(Me.Page, "Image Format Not supported", "Prime")
    '                        Exit Sub
    '                    End If

    '                End If


    '                Dim filestream1 As Stream
    '                Dim buffer1(filelength1) As Byte
    '                filestream1 = objFile.InputStream
    '                filestream1.Read(buffer1, 0, filelength1)

    '            End If
    '        Next



    '    Catch errorVariable As Exception

    '    End Try




    '    'Dim proc As String = ""

    '    'If Me.btnSubmit.Text = "Submit" Then
    '    '    proc = "proc_insmandate"
    '    'Else
    '    '    proc = "proc_updmandate"
    '    'End If


    '    'Dim cmd As Data.SqlClient.SqlCommand
    '    'cmd = New Data.SqlClient.SqlCommand(proc, constring)
    '    'cmd.CommandType = CommandType.StoredProcedure
    '    'cmd.Parameters.Add("@content1", SqlDbType.Image)
    '    'cmd.Parameters.Add("@type1", SqlDbType.VarChar, 30)
    '    'cmd.Parameters.Add("@content2", SqlDbType.Image)
    '    'cmd.Parameters.Add("@type2", SqlDbType.VarChar, 30)
    '    'cmd.Parameters.Add("@acctno", SqlDbType.VarChar, 22)
    '    'cmd.Parameters.Add("@signatory", SqlDbType.VarChar, 150)

    '    'cmd.Parameters.Add("@designation", SqlDbType.VarChar, 100)
    '    'cmd.Parameters.Add("@mandatedesc", SqlDbType.VarChar, 40)
    '    'cmd.Parameters.Add("@mandatedesc2", SqlDbType.VarChar, 40)
    '    'cmd.Parameters.Add("@serial", SqlDbType.Int)
    '    'cmd.Parameters.Add("@mandateid", SqlDbType.VarChar, 22)
    '    'cmd.Parameters.Add("@userid", SqlDbType.VarChar, 50)
    '    ' '' cmd.Parameters.Add("@authid", SqlDbType.VarChar, 50)
    '    'cmd.Parameters.Add("@retval", SqlDbType.Int)
    '    'cmd.Parameters.Add("@retmsg", SqlDbType.VarChar, 50)


    '    'cmd.Parameters(0).Value = Me.drpdeliv.SelectedValue.Trim
    '    'cmd.Parameters(1).Value = Me.txtregno.Text.Trim
    '    'cmd.Parameters(2).Value = buffer1
    '    'cmd.Parameters(3).Value = filetype1
    '    'cmd.Parameters(4).Value = Me.txtcost.Text.Trim
    '    'cmd.Parameters(5).Value = Me.DrpState.SelectedValue.Trim
    '    'cmd.Parameters(6).Value = Me.DrpCompTown.SelectedValue.Trim
    '    'cmd.Parameters(7).Value = Format(latesttime, "yyyy-MM-dd")
    '    'cmd.Parameters(8).Value = Me.txtDebit.Text.Trim
    '    'cmd.Parameters(9).Value = Me.txtcredit.Text.Trim
    '    'cmd.Parameters(10).Value = Session("Userid")
    '    'cmd.Parameters(11).Value = " "
    '    'cmd.Parameters(12).Direction = Data.ParameterDirection.Output
    '    'cmd.Parameters(13).Direction = Data.ParameterDirection.Output


    '    'constring.Open()

    '    'Dim reader As System.Data.SqlClient.SqlDataReader = cmd.ExecuteReader()
    '    'retval = cmd.Parameters.Item(12).Value
    '    'retmsg = (cmd.Parameters.Item(13).Value).ToString
    '    'reader.Close()
    '    'cmd.Dispose()
    '    'constring.Close()

    '    ''If retval = 0 Then
    '    ''    '' uploadimage()

    '    ''End If

    '    'smartobj.alertwindow(Me.Page, retmsg, "Prime")
    '    'smartobj.ClearWebPage(Me.Page)
    'End Sub
    Sub refresh2()
        If IsNumeric(Me.txtnosign.Text) Then
            Dim inc As Integer = Me.txtnosign.Text.Trim
            Select Case inc
                Case 1
                    viscase11()
                Case 2
                    viscase22()
                Case 3
                    viscase33()
                Case 4
                    viscase44()
                Case 5
                    viscase55()
                Case 6
                    viscase66()
                Case 7
                    viscase77()
                Case 8
                    viscase88()
                Case 9
                    viscase99()
                Case 10
                    viscase1010()
            End Select
        End If
    End Sub
    Sub viscase11()
        Me.Label10.Visible = True
        Me.Label11.Visible = True
        Me.Label12.Visible = True
        Me.Label13.Visible = True
        Me.txtname1.Visible = True
        Me.txtdesig1.Visible = True
        Me.File1.Visible = True
        Me.File2.Visible = True
        Me.Label30.Visible = True

        Dim signatory(10) As String
        Dim mandate1(10) As String
        Dim mandate2(10) As String
        Dim designate(10) As String

        Dim selexist1 As String = "exec proc_mandatelist '" & Me.txtAcNumber.Text.Trim & "', " & Session("node_ID") & ""
        Dim i As Integer = 0
        If con.SqlDs(selexist1).Tables(0).Rows.Count > 0 Then
            For Each dr As Data.DataRow In con.SqlDs(selexist1).Tables(0).Rows
                signatory(i) = dr!signatoryname.ToString
                mandate1(i) = dr!mandatedesc1.ToString
                designate(i) = dr!designation.ToString
                'mandate2(i) = dr!mandatedesc2.ToString
                i = i + 1
            Next

        End If

        Me.txtname1.Text = signatory(0)
        Me.txtmandate1.Text = mandate1(0)
        Me.txtdesig1.Text = designate(0)


        Me.txtmandate1.Visible = True

        Me.Label14.Visible = False
        Me.Label15.Visible = False
        Me.Label16.Visible = False
        Me.Label17.Visible = False
        Me.txtname2.Visible = False
        Me.txtdesig2.Visible = False
        Me.File3.Visible = False
        Me.File4.Visible = False

        Me.Label18.Visible = False
        Me.Label19.Visible = False
        Me.Label20.Visible = False
        Me.Label21.Visible = False
        Me.txtname3.Visible = False
        Me.txtdesig3.Visible = False
        Me.File5.Visible = False
        Me.File6.Visible = False


        Me.Label22.Visible = False
        Me.Label23.Visible = False
        Me.Label24.Visible = False
        Me.Label25.Visible = False
        Me.txtname4.Visible = False
        Me.txtdesig4.Visible = False
        Me.File7.Visible = False
        Me.File8.Visible = False


        Me.Label26.Visible = False
        Me.Label27.Visible = False
        Me.Label28.Visible = False
        Me.Label29.Visible = False
        Me.txtname5.Visible = False
        Me.txtdesig5.Visible = False
        Me.File9.Visible = False
        Me.File10.Visible = False

        '--------------------------------------------------

        Me.Label34.Visible = False
        Me.Label35.Visible = False
        Me.Label36.Visible = False
        Me.Label37.Visible = False
        Me.txtname6.Visible = False
        Me.txtdesig6.Visible = False
        Me.File11.Visible = False
        Me.File12.Visible = False

        Me.Label38.Visible = False
        Me.Label39.Visible = False
        Me.Label40.Visible = False
        Me.Label41.Visible = False
        Me.txtname7.Visible = False
        Me.txtdesig7.Visible = False
        Me.File13.Visible = False
        Me.File14.Visible = False

        Me.Label42.Visible = False
        Me.Label43.Visible = False
        Me.Label44.Visible = False
        Me.Label45.Visible = False
        Me.txtname8.Visible = False
        Me.txtdesig8.Visible = False
        Me.File15.Visible = False
        Me.File16.Visible = False

        Me.Label46.Visible = False
        Me.Label47.Visible = False
        Me.Label48.Visible = False
        Me.Label49.Visible = False
        Me.txtname9.Visible = False
        Me.txtdesig9.Visible = False
        Me.File17.Visible = False
        Me.File18.Visible = False

        Me.Label50.Visible = False
        Me.Label51.Visible = False
        Me.Label52.Visible = False
        Me.Label53.Visible = False
        Me.txtname10.Visible = False
        Me.txtdesig10.Visible = False
        Me.File19.Visible = False
        Me.File20.Visible = False

    End Sub
    Sub viscase22()
        Me.Label10.Visible = True
        Me.Label11.Visible = True
        Me.Label12.Visible = True
        Me.Label13.Visible = True
        Me.txtname1.Visible = True
        Me.txtdesig1.Visible = True
        Me.File1.Visible = True
        Me.File2.Visible = True

        Me.Label14.Visible = True
        Me.Label15.Visible = True
        Me.Label16.Visible = True
        Me.Label17.Visible = True
        Me.txtname2.Visible = True
        Me.txtdesig2.Visible = True
        Me.File3.Visible = True
        Me.File4.Visible = True

        Dim signatory(10) As String
        Dim mandate1(10) As String
        Dim mandate2(10) As String
        Dim designate(10) As String

        Dim selexist1 As String = "exec proc_mandatelist '" & Me.txtAcNumber.Text.Trim & "', " & Session("node_ID") & ""
        Dim i As Integer = 0
        If con.SqlDs(selexist1).Tables(0).Rows.Count > 0 Then
            For Each dr As Data.DataRow In con.SqlDs(selexist1).Tables(0).Rows
                signatory(i) = dr!signatoryname.ToString
                mandate1(i) = dr!mandatedesc1.ToString
                designate(i) = dr!designation.ToString
                'mandate2(i) = dr!mandatedesc2.ToString
                i = i + 1
            Next

        End If

        Me.txtname1.Text = signatory(0)
        Me.txtmandate1.Text = mandate1(0)
        Me.txtdesig1.Text = designate(0)

        Me.txtname2.Text = signatory(1)
        Me.txtdesig2.Text = designate(1)

        Me.Label18.Visible = False
        Me.Label19.Visible = False
        Me.Label20.Visible = False
        Me.Label21.Visible = False
        Me.txtname3.Visible = False
        Me.txtdesig3.Visible = False
        Me.File5.Visible = False
        Me.File6.Visible = False


        Me.Label22.Visible = False
        Me.Label23.Visible = False
        Me.Label24.Visible = False
        Me.Label25.Visible = False
        Me.txtname4.Visible = False
        Me.txtdesig4.Visible = False
        Me.File7.Visible = False
        Me.File8.Visible = False


        Me.Label26.Visible = False
        Me.Label27.Visible = False
        Me.Label28.Visible = False
        Me.Label29.Visible = False
        Me.txtname5.Visible = False
        Me.txtdesig5.Visible = False
        Me.File9.Visible = False
        Me.File10.Visible = False

        '--------------------------------------------------

        Me.Label34.Visible = False
        Me.Label35.Visible = False
        Me.Label36.Visible = False
        Me.Label37.Visible = False
        Me.txtname6.Visible = False
        Me.txtdesig6.Visible = False
        Me.File11.Visible = False
        Me.File12.Visible = False

        Me.Label38.Visible = False
        Me.Label39.Visible = False
        Me.Label40.Visible = False
        Me.Label41.Visible = False
        Me.txtname7.Visible = False
        Me.txtdesig7.Visible = False
        Me.File13.Visible = False
        Me.File14.Visible = False

        Me.Label42.Visible = False
        Me.Label43.Visible = False
        Me.Label44.Visible = False
        Me.Label45.Visible = False
        Me.txtname8.Visible = False
        Me.txtdesig8.Visible = False
        Me.File15.Visible = False
        Me.File16.Visible = False

        Me.Label46.Visible = False
        Me.Label47.Visible = False
        Me.Label48.Visible = False
        Me.Label49.Visible = False
        Me.txtname9.Visible = False
        Me.txtdesig9.Visible = False
        Me.File17.Visible = False
        Me.File18.Visible = False

        Me.Label50.Visible = False
        Me.Label51.Visible = False
        Me.Label52.Visible = False
        Me.Label53.Visible = False
        Me.txtname10.Visible = False
        Me.txtdesig10.Visible = False
        Me.File19.Visible = False
        Me.File20.Visible = False

    End Sub
    Sub viscase33()
        Me.Label10.Visible = True
        Me.Label11.Visible = True
        Me.Label12.Visible = True
        Me.Label13.Visible = True
        Me.txtname1.Visible = True
        Me.txtdesig1.Visible = True
        Me.File1.Visible = True
        Me.File2.Visible = True

        Me.Label14.Visible = True
        Me.Label15.Visible = True
        Me.Label16.Visible = True
        Me.Label17.Visible = True
        Me.txtname2.Visible = True
        Me.txtdesig2.Visible = True
        Me.File3.Visible = True
        Me.File4.Visible = True

        Dim signatory(10) As String
        Dim mandate1(10) As String
        Dim mandate2(10) As String
        Dim designate(10) As String
        Dim selexist1 As String = "exec proc_mandatelist '" & Me.txtAcNumber.Text.Trim & "', " & Session("node_ID") & ""
        Dim i As Integer = 0
        If con.SqlDs(selexist1).Tables(0).Rows.Count > 0 Then
            For Each dr As Data.DataRow In con.SqlDs(selexist1).Tables(0).Rows
                signatory(i) = dr!signatoryname.ToString
                mandate1(i) = dr!mandatedesc1.ToString
                designate(i) = dr!designation.ToString
                ' mandate2(i) = dr!mandatedesc2.ToString
                i = i + 1
            Next

        End If

        Me.txtname1.Text = signatory(0)

        Me.txtdesig1.Text = designate(0)
        Me.txtmandate1.Text = mandate1(0)

        Me.txtname2.Text = signatory(1)
        Me.txtdesig2.Text = designate(1)

        Me.txtname3.Text = signatory(2)
        Me.txtdesig3.Text = designate(2)

        Me.Label18.Visible = True
        Me.Label19.Visible = True
        Me.Label20.Visible = True
        Me.Label21.Visible = True
        Me.txtname3.Visible = True
        Me.txtdesig3.Visible = True
        Me.File5.Visible = True
        Me.File6.Visible = True


        Me.Label22.Visible = False
        Me.Label23.Visible = False
        Me.Label24.Visible = False
        Me.Label25.Visible = False
        Me.txtname4.Visible = False
        Me.txtdesig4.Visible = False
        Me.File7.Visible = False
        Me.File8.Visible = False


        Me.Label26.Visible = False
        Me.Label27.Visible = False
        Me.Label28.Visible = False
        Me.Label29.Visible = False
        Me.txtname5.Visible = False
        Me.txtdesig5.Visible = False
        Me.File9.Visible = False
        Me.File10.Visible = False

        '--------------------------------------------------

        Me.Label34.Visible = False
        Me.Label35.Visible = False
        Me.Label36.Visible = False
        Me.Label37.Visible = False
        Me.txtname6.Visible = False
        Me.txtdesig6.Visible = False
        Me.File11.Visible = False
        Me.File12.Visible = False

        Me.Label38.Visible = False
        Me.Label39.Visible = False
        Me.Label40.Visible = False
        Me.Label41.Visible = False
        Me.txtname7.Visible = False
        Me.txtdesig7.Visible = False
        Me.File13.Visible = False
        Me.File14.Visible = False

        Me.Label42.Visible = False
        Me.Label43.Visible = False
        Me.Label44.Visible = False
        Me.Label45.Visible = False
        Me.txtname8.Visible = False
        Me.txtdesig8.Visible = False
        Me.File15.Visible = False
        Me.File16.Visible = False

        Me.Label46.Visible = False
        Me.Label47.Visible = False
        Me.Label48.Visible = False
        Me.Label49.Visible = False
        Me.txtname9.Visible = False
        Me.txtdesig9.Visible = False
        Me.File17.Visible = False
        Me.File18.Visible = False

        Me.Label50.Visible = False
        Me.Label51.Visible = False
        Me.Label52.Visible = False
        Me.Label53.Visible = False
        Me.txtname10.Visible = False
        Me.txtdesig10.Visible = False
        Me.File19.Visible = False
        Me.File20.Visible = False

    End Sub
    Sub viscase44()
        Me.Label10.Visible = True
        Me.Label11.Visible = True
        Me.Label12.Visible = True
        Me.Label13.Visible = True
        Me.txtname1.Visible = True
        Me.txtdesig1.Visible = True
        Me.File1.Visible = True
        Me.File2.Visible = True

        Me.Label14.Visible = True
        Me.Label15.Visible = True
        Me.Label16.Visible = True
        Me.Label17.Visible = True
        Me.txtname2.Visible = True
        Me.txtdesig2.Visible = True
        Me.File3.Visible = True
        Me.File4.Visible = True


        Dim signatory(10) As String
        Dim mandate1(10) As String
        Dim mandate2(10) As String
        Dim designate(10) As String
        Dim selexist1 As String = "exec proc_mandatelist '" & Me.txtAcNumber.Text.Trim & "', " & Session("node_ID") & ""
        Dim i As Integer = 0
        If con.SqlDs(selexist1).Tables(0).Rows.Count > 0 Then
            For Each dr As Data.DataRow In con.SqlDs(selexist1).Tables(0).Rows
                signatory(i) = dr!signatoryname.ToString
                mandate1(i) = dr!mandatedesc1.ToString
                designate(i) = dr!designation.ToString
                'mandate2(i) = dr!mandatedesc2.ToString
                i = i + 1
            Next

        End If

        Me.txtname1.Text = signatory(0)

        Me.txtdesig1.Text = designate(0)
        Me.txtmandate1.Text = mandate1(0)

        Me.txtname2.Text = signatory(1)
        Me.txtdesig2.Text = designate(1)

        Me.txtname3.Text = signatory(2)
        Me.txtdesig3.Text = designate(2)

        Me.txtname4.Text = signatory(3)
        Me.txtdesig4.Text = designate(3)

        Me.Label18.Visible = True
        Me.Label19.Visible = True
        Me.Label20.Visible = True
        Me.Label21.Visible = True
        Me.txtname3.Visible = True
        Me.txtdesig3.Visible = True
        Me.File5.Visible = True
        Me.File6.Visible = True


        Me.Label22.Visible = True
        Me.Label23.Visible = True
        Me.Label24.Visible = True
        Me.Label25.Visible = True
        Me.txtname4.Visible = True
        Me.txtdesig4.Visible = True
        Me.File7.Visible = True
        Me.File8.Visible = True


        Me.Label26.Visible = False
        Me.Label27.Visible = False
        Me.Label28.Visible = False
        Me.Label29.Visible = False
        Me.txtname5.Visible = False
        Me.txtdesig5.Visible = False
        Me.File9.Visible = False
        Me.File10.Visible = False

        '--------------------------------------------------

        Me.Label34.Visible = False
        Me.Label35.Visible = False
        Me.Label36.Visible = False
        Me.Label37.Visible = False
        Me.txtname6.Visible = False
        Me.txtdesig6.Visible = False
        Me.File11.Visible = False
        Me.File12.Visible = False

        Me.Label38.Visible = False
        Me.Label39.Visible = False
        Me.Label40.Visible = False
        Me.Label41.Visible = False
        Me.txtname7.Visible = False
        Me.txtdesig7.Visible = False
        Me.File13.Visible = False
        Me.File14.Visible = False

        Me.Label42.Visible = False
        Me.Label43.Visible = False
        Me.Label44.Visible = False
        Me.Label45.Visible = False
        Me.txtname8.Visible = False
        Me.txtdesig8.Visible = False
        Me.File15.Visible = False
        Me.File16.Visible = False

        Me.Label46.Visible = False
        Me.Label47.Visible = False
        Me.Label48.Visible = False
        Me.Label49.Visible = False
        Me.txtname9.Visible = False
        Me.txtdesig9.Visible = False
        Me.File17.Visible = False
        Me.File18.Visible = False

        Me.Label50.Visible = False
        Me.Label51.Visible = False
        Me.Label52.Visible = False
        Me.Label53.Visible = False
        Me.txtname10.Visible = False
        Me.txtdesig10.Visible = False
        Me.File19.Visible = False
        Me.File20.Visible = False

    End Sub
    Sub viscase55()
        Me.Label10.Visible = True
        Me.Label11.Visible = True
        Me.Label12.Visible = True
        Me.Label13.Visible = True
        Me.txtname1.Visible = True
        Me.txtdesig1.Visible = True
        Me.File1.Visible = True
        Me.File2.Visible = True

        Me.Label14.Visible = True
        Me.Label15.Visible = True
        Me.Label16.Visible = True
        Me.Label17.Visible = True
        Me.txtname2.Visible = True
        Me.txtdesig2.Visible = True
        Me.File3.Visible = True
        Me.File4.Visible = True
        Dim signatory(10) As String
        Dim mandate1(10) As String
        Dim mandate2(10) As String
        Dim designate(10) As String
        Dim selexist1 As String = "exec proc_mandatelist '" & Me.txtAcNumber.Text.Trim & "', " & Session("node_ID") & ""
        Dim i As Integer = 0
        If con.SqlDs(selexist1).Tables(0).Rows.Count > 0 Then
            For Each dr As Data.DataRow In con.SqlDs(selexist1).Tables(0).Rows
                signatory(i) = dr!signatoryname.ToString
                mandate1(i) = dr!mandatedesc1.ToString
                designate(i) = dr!designation.ToString
                ' mandate2(i) = dr!mandatedesc2.ToString
                i = i + 1
            Next

        End If

        Me.txtname1.Text = signatory(0)
        Me.txtdesig1.Text = designate(0)
        Me.txtmandate1.Text = mandate1(0)

        Me.txtname2.Text = signatory(1)
        Me.txtdesig2.Text = designate(1)

        Me.txtname3.Text = signatory(2)
        Me.txtdesig3.Text = designate(2)

        Me.txtname4.Text = signatory(3)
        Me.txtdesig4.Text = designate(3)

        Me.txtname5.Text = signatory(4)
        Me.txtdesig5.Text = designate(4)

        Me.Label18.Visible = True
        Me.Label19.Visible = True
        Me.Label20.Visible = True
        Me.Label21.Visible = True
        Me.txtname3.Visible = True
        Me.txtdesig3.Visible = True
        Me.File5.Visible = True
        Me.File6.Visible = True


        Me.Label22.Visible = True
        Me.Label23.Visible = True
        Me.Label24.Visible = True
        Me.Label25.Visible = True
        Me.txtname4.Visible = True
        Me.txtdesig4.Visible = True
        Me.File7.Visible = True
        Me.File8.Visible = True



        Me.Label26.Visible = True
        Me.Label27.Visible = True
        Me.Label28.Visible = True
        Me.Label29.Visible = True
        Me.txtname5.Visible = True
        Me.txtdesig5.Visible = True
        Me.File9.Visible = True
        Me.File10.Visible = True

        '--------------------------------------------------

        Me.Label34.Visible = False
        Me.Label35.Visible = False
        Me.Label36.Visible = False
        Me.Label37.Visible = False
        Me.txtname6.Visible = False
        Me.txtdesig6.Visible = False
        Me.File11.Visible = False
        Me.File12.Visible = False

        Me.Label38.Visible = False
        Me.Label39.Visible = False
        Me.Label40.Visible = False
        Me.Label41.Visible = False
        Me.txtname7.Visible = False
        Me.txtdesig7.Visible = False
        Me.File13.Visible = False
        Me.File14.Visible = False

        Me.Label42.Visible = False
        Me.Label43.Visible = False
        Me.Label44.Visible = False
        Me.Label45.Visible = False
        Me.txtname8.Visible = False
        Me.txtdesig8.Visible = False
        Me.File15.Visible = False
        Me.File16.Visible = False

        Me.Label46.Visible = False
        Me.Label47.Visible = False
        Me.Label48.Visible = False
        Me.Label49.Visible = False
        Me.txtname9.Visible = False
        Me.txtdesig9.Visible = False
        Me.File17.Visible = False
        Me.File18.Visible = False

        Me.Label50.Visible = False
        Me.Label51.Visible = False
        Me.Label52.Visible = False
        Me.Label53.Visible = False
        Me.txtname10.Visible = False
        Me.txtdesig10.Visible = False
        Me.File19.Visible = False
        Me.File20.Visible = False

    End Sub
    Sub viscase66()
        Me.Label10.Visible = True
        Me.Label11.Visible = True
        Me.Label12.Visible = True
        Me.Label13.Visible = True
        Me.txtname1.Visible = True
        Me.txtdesig1.Visible = True
        Me.File1.Visible = True
        Me.File2.Visible = True

        Me.Label14.Visible = True
        Me.Label15.Visible = True
        Me.Label16.Visible = True
        Me.Label17.Visible = True
        Me.txtname2.Visible = True
        Me.txtdesig2.Visible = True
        Me.File3.Visible = True
        Me.File4.Visible = True
        Dim signatory(10) As String
        Dim mandate1(10) As String
        Dim mandate2(10) As String
        Dim designate(10) As String
        Dim selexist1 As String = "exec proc_mandatelist '" & Me.txtAcNumber.Text.Trim & "', " & Session("node_ID") & ""
        Dim i As Integer = 0
        If con.SqlDs(selexist1).Tables(0).Rows.Count > 0 Then
            For Each dr As Data.DataRow In con.SqlDs(selexist1).Tables(0).Rows
                signatory(i) = dr!signatoryname.ToString
                mandate1(i) = dr!mandatedesc1.ToString
                designate(i) = dr!designation.ToString
                'mandate2(i) = dr!mandatedesc2.ToString
                i = i + 1
            Next

        End If

        Me.txtname1.Text = signatory(0)
        Me.txtdesig1.Text = designate(0)
        Me.txtmandate1.Text = mandate1(0)

        Me.txtname2.Text = signatory(1)
        Me.txtdesig2.Text = designate(1)

        Me.txtname3.Text = signatory(2)
        Me.txtdesig3.Text = designate(2)

        Me.txtname4.Text = signatory(3)
        Me.txtdesig4.Text = designate(3)

        Me.txtname5.Text = signatory(4)
        Me.txtdesig5.Text = designate(4)

        Me.txtname6.Text = signatory(5)
        Me.txtdesig6.Text = designate(5)

        Me.Label18.Visible = True
        Me.Label19.Visible = True
        Me.Label20.Visible = True
        Me.Label21.Visible = True
        Me.txtname3.Visible = True
        Me.txtdesig3.Visible = True
        Me.File5.Visible = True
        Me.File6.Visible = True


        Me.Label22.Visible = True
        Me.Label23.Visible = True
        Me.Label24.Visible = True
        Me.Label25.Visible = True
        Me.txtname4.Visible = True
        Me.txtdesig4.Visible = True
        Me.File7.Visible = True
        Me.File8.Visible = True



        Me.Label26.Visible = True
        Me.Label27.Visible = True
        Me.Label28.Visible = True
        Me.Label29.Visible = True
        Me.txtname5.Visible = True
        Me.txtdesig5.Visible = True
        Me.File9.Visible = True
        Me.File10.Visible = True

        '--------------------------------------------------

        Me.Label34.Visible = True
        Me.Label35.Visible = True
        Me.Label36.Visible = True
        Me.Label37.Visible = True
        Me.txtname6.Visible = True
        Me.txtdesig6.Visible = True
        Me.File11.Visible = True
        Me.File12.Visible = True

        Me.Label38.Visible = False
        Me.Label39.Visible = False
        Me.Label40.Visible = False
        Me.Label41.Visible = False
        Me.txtname7.Visible = False
        Me.txtdesig7.Visible = False
        Me.File13.Visible = False
        Me.File14.Visible = False

        Me.Label42.Visible = False
        Me.Label43.Visible = False
        Me.Label44.Visible = False
        Me.Label45.Visible = False
        Me.txtname8.Visible = False
        Me.txtdesig8.Visible = False
        Me.File15.Visible = False
        Me.File16.Visible = False

        Me.Label46.Visible = False
        Me.Label47.Visible = False
        Me.Label48.Visible = False
        Me.Label49.Visible = False
        Me.txtname9.Visible = False
        Me.txtdesig9.Visible = False
        Me.File17.Visible = False
        Me.File18.Visible = False

        Me.Label50.Visible = False
        Me.Label51.Visible = False
        Me.Label52.Visible = False
        Me.Label53.Visible = False
        Me.txtname10.Visible = False
        Me.txtdesig10.Visible = False
        Me.File19.Visible = False
        Me.File20.Visible = False

    End Sub
    Sub viscase77()
        Me.Label10.Visible = True
        Me.Label11.Visible = True
        Me.Label12.Visible = True
        Me.Label13.Visible = True
        Me.txtname1.Visible = True
        Me.txtdesig1.Visible = True
        Me.File1.Visible = True
        Me.File2.Visible = True

        Me.Label14.Visible = True
        Me.Label15.Visible = True
        Me.Label16.Visible = True
        Me.Label17.Visible = True
        Me.txtname2.Visible = True
        Me.txtdesig2.Visible = True
        Me.File3.Visible = True
        Me.File4.Visible = True
        Dim signatory(10) As String
        Dim mandate1(10) As String
        Dim mandate2(10) As String
        Dim designate(10) As String
        Dim selexist1 As String = "exec proc_mandatelist '" & Me.txtAcNumber.Text.Trim & "', " & Session("node_ID") & ""
        Dim i As Integer = 0
        If con.SqlDs(selexist1).Tables(0).Rows.Count > 0 Then
            For Each dr As Data.DataRow In con.SqlDs(selexist1).Tables(0).Rows
                signatory(i) = dr!signatoryname.ToString
                mandate1(i) = dr!mandatedesc1.ToString
                designate(i) = dr!designation.ToString
                ' mandate2(i) = dr!mandatedesc2.ToString
                i = i + 1
            Next

        End If

        Me.txtname1.Text = signatory(0)
        Me.txtdesig1.Text = designate(0)
        Me.txtmandate1.Text = mandate1(0)

        Me.txtname2.Text = signatory(1)
        Me.txtdesig2.Text = designate(1)

        Me.txtname3.Text = signatory(2)
        Me.txtdesig3.Text = designate(2)

        Me.txtname4.Text = signatory(3)
        Me.txtdesig4.Text = designate(3)

        Me.txtname5.Text = signatory(4)
        Me.txtdesig5.Text = designate(4)

        Me.txtname6.Text = signatory(5)
        Me.txtdesig6.Text = designate(5)

        Me.txtname7.Text = signatory(6)
        Me.txtdesig7.Text = designate(6)

        Me.Label18.Visible = True
        Me.Label19.Visible = True
        Me.Label20.Visible = True
        Me.Label21.Visible = True
        Me.txtname3.Visible = True
        Me.txtdesig3.Visible = True
        Me.File5.Visible = True
        Me.File6.Visible = True


        Me.Label22.Visible = True
        Me.Label23.Visible = True
        Me.Label24.Visible = True
        Me.Label25.Visible = True
        Me.txtname4.Visible = True
        Me.txtdesig4.Visible = True
        Me.File7.Visible = True
        Me.File8.Visible = True



        Me.Label26.Visible = True
        Me.Label27.Visible = True
        Me.Label28.Visible = True
        Me.Label29.Visible = True
        Me.txtname5.Visible = True
        Me.txtdesig5.Visible = True
        Me.File9.Visible = True
        Me.File10.Visible = True

        '--------------------------------------------------

        Me.Label34.Visible = True
        Me.Label35.Visible = True
        Me.Label36.Visible = True
        Me.Label37.Visible = True
        Me.txtname6.Visible = True
        Me.txtdesig6.Visible = True
        Me.File11.Visible = True
        Me.File12.Visible = True

        Me.Label38.Visible = True
        Me.Label39.Visible = True
        Me.Label40.Visible = True
        Me.Label41.Visible = True
        Me.txtname7.Visible = True
        Me.txtdesig7.Visible = True
        Me.File13.Visible = True
        Me.File14.Visible = True

        Me.Label42.Visible = False
        Me.Label43.Visible = False
        Me.Label44.Visible = False
        Me.Label45.Visible = False
        Me.txtname8.Visible = False
        Me.txtdesig8.Visible = False
        Me.File15.Visible = False
        Me.File16.Visible = False

        Me.Label46.Visible = False
        Me.Label47.Visible = False
        Me.Label48.Visible = False
        Me.Label49.Visible = False
        Me.txtname9.Visible = False
        Me.txtdesig9.Visible = False
        Me.File17.Visible = False
        Me.File18.Visible = False

        Me.Label50.Visible = False
        Me.Label51.Visible = False
        Me.Label52.Visible = False
        Me.Label53.Visible = False
        Me.txtname10.Visible = False
        Me.txtdesig10.Visible = False
        Me.File19.Visible = False
        Me.File20.Visible = False

    End Sub
    Sub viscase88()
        Me.Label10.Visible = True
        Me.Label11.Visible = True
        Me.Label12.Visible = True
        Me.Label13.Visible = True
        Me.txtname1.Visible = True
        Me.txtdesig1.Visible = True
        Me.File1.Visible = True
        Me.File2.Visible = True

        Me.Label14.Visible = True
        Me.Label15.Visible = True
        Me.Label16.Visible = True
        Me.Label17.Visible = True
        Me.txtname2.Visible = True
        Me.txtdesig2.Visible = True
        Me.File3.Visible = True
        Me.File4.Visible = True
        Dim signatory(10) As String
        Dim mandate1(10) As String
        Dim mandate2(10) As String
        Dim designate(10) As String
        Dim selexist1 As String = "exec proc_mandatelist '" & Me.txtAcNumber.Text.Trim & "', " & Session("node_ID") & ""
        Dim i As Integer = 0
        If con.SqlDs(selexist1).Tables(0).Rows.Count > 0 Then
            For Each dr As Data.DataRow In con.SqlDs(selexist1).Tables(0).Rows
                signatory(i) = dr!signatoryname.ToString
                mandate1(i) = dr!mandatedesc1.ToString
                designate(i) = dr!designation.ToString
                ' mandate2(i) = dr!mandatedesc2.ToString
                i = i + 1
            Next

        End If

        Me.txtname1.Text = signatory(0)
        Me.txtdesig1.Text = designate(0)
        Me.txtmandate1.Text = mandate1(0)

        Me.txtname2.Text = signatory(1)
        Me.txtdesig2.Text = designate(1)

        Me.txtname3.Text = signatory(2)
        Me.txtdesig3.Text = designate(2)

        Me.txtname4.Text = signatory(3)
        Me.txtdesig4.Text = designate(3)

        Me.txtname5.Text = signatory(4)
        Me.txtdesig5.Text = designate(4)

        Me.txtname6.Text = signatory(5)
        Me.txtdesig6.Text = designate(5)

        Me.txtname7.Text = signatory(6)
        Me.txtdesig7.Text = designate(6)

        Me.txtname8.Text = signatory(7)
        Me.txtdesig8.Text = designate(7)

        Me.Label18.Visible = True
        Me.Label19.Visible = True
        Me.Label20.Visible = True
        Me.Label21.Visible = True
        Me.txtname3.Visible = True
        Me.txtdesig3.Visible = True
        Me.File5.Visible = True
        Me.File6.Visible = True


        Me.Label22.Visible = True
        Me.Label23.Visible = True
        Me.Label24.Visible = True
        Me.Label25.Visible = True
        Me.txtname4.Visible = True
        Me.txtdesig4.Visible = True
        Me.File7.Visible = True
        Me.File8.Visible = True



        Me.Label26.Visible = True
        Me.Label27.Visible = True
        Me.Label28.Visible = True
        Me.Label29.Visible = True
        Me.txtname5.Visible = True
        Me.txtdesig5.Visible = True
        Me.File9.Visible = True
        Me.File10.Visible = True

        '--------------------------------------------------

        Me.Label34.Visible = True
        Me.Label35.Visible = True
        Me.Label36.Visible = True
        Me.Label37.Visible = True
        Me.txtname6.Visible = True
        Me.txtdesig6.Visible = True
        Me.File11.Visible = True
        Me.File12.Visible = True

        Me.Label38.Visible = True
        Me.Label39.Visible = True
        Me.Label40.Visible = True
        Me.Label41.Visible = True
        Me.txtname7.Visible = True
        Me.txtdesig7.Visible = True
        Me.File13.Visible = True
        Me.File14.Visible = True

        Me.Label42.Visible = True
        Me.Label43.Visible = True
        Me.Label44.Visible = True
        Me.Label45.Visible = True
        Me.txtname8.Visible = True
        Me.txtdesig8.Visible = True
        Me.File15.Visible = True
        Me.File16.Visible = True

        Me.Label46.Visible = False
        Me.Label47.Visible = False
        Me.Label48.Visible = False
        Me.Label49.Visible = False
        Me.txtname9.Visible = False
        Me.txtdesig9.Visible = False
        Me.File17.Visible = False
        Me.File18.Visible = False

        Me.Label50.Visible = False
        Me.Label51.Visible = False
        Me.Label52.Visible = False
        Me.Label53.Visible = False
        Me.txtname10.Visible = False
        Me.txtdesig10.Visible = False
        Me.File19.Visible = False
        Me.File20.Visible = False

    End Sub
    Sub viscase99()
        Me.Label10.Visible = True
        Me.Label11.Visible = True
        Me.Label12.Visible = True
        Me.Label13.Visible = True
        Me.txtname1.Visible = True
        Me.txtdesig1.Visible = True
        Me.File1.Visible = True
        Me.File2.Visible = True

        Me.Label14.Visible = True
        Me.Label15.Visible = True
        Me.Label16.Visible = True
        Me.Label17.Visible = True
        Me.txtname2.Visible = True
        Me.txtdesig2.Visible = True
        Me.File3.Visible = True
        Me.File4.Visible = True
        Dim signatory(10) As String
        Dim mandate1(10) As String
        Dim mandate2(10) As String
        Dim designate(10) As String
        Dim selexist1 As String = "exec proc_mandatelist '" & Me.txtAcNumber.Text.Trim & "', " & Session("node_ID") & ""
        Dim i As Integer = 0
        If con.SqlDs(selexist1).Tables(0).Rows.Count > 0 Then
            For Each dr As Data.DataRow In con.SqlDs(selexist1).Tables(0).Rows
                signatory(i) = dr!signatoryname.ToString
                mandate1(i) = dr!mandatedesc1.ToString
                designate(i) = dr!designation.ToString
                ' mandate2(i) = dr!mandatedesc2.ToString
                i = i + 1
            Next

        End If

        Me.txtname1.Text = signatory(0)
        Me.txtdesig1.Text = designate(0)
        Me.txtmandate1.Text = mandate1(0)

        Me.txtname2.Text = signatory(1)
        Me.txtdesig2.Text = designate(1)

        Me.txtname3.Text = signatory(2)
        Me.txtdesig3.Text = designate(2)

        Me.txtname4.Text = signatory(3)
        Me.txtdesig4.Text = designate(3)

        Me.txtname5.Text = signatory(4)
        Me.txtdesig5.Text = designate(4)

        Me.txtname6.Text = signatory(5)
        Me.txtdesig6.Text = designate(5)

        Me.txtname7.Text = signatory(6)
        Me.txtdesig7.Text = designate(6)

        Me.txtname8.Text = signatory(7)
        Me.txtdesig8.Text = designate(7)

        Me.txtname9.Text = signatory(8)
        Me.txtdesig9.Text = designate(8)

        Me.Label18.Visible = True
        Me.Label19.Visible = True
        Me.Label20.Visible = True
        Me.Label21.Visible = True
        Me.txtname3.Visible = True
        Me.txtdesig3.Visible = True
        Me.File5.Visible = True
        Me.File6.Visible = True


        Me.Label22.Visible = True
        Me.Label23.Visible = True
        Me.Label24.Visible = True
        Me.Label25.Visible = True
        Me.txtname4.Visible = True
        Me.txtdesig4.Visible = True
        Me.File7.Visible = True
        Me.File8.Visible = True



        Me.Label26.Visible = True
        Me.Label27.Visible = True
        Me.Label28.Visible = True
        Me.Label29.Visible = True
        Me.txtname5.Visible = True
        Me.txtdesig5.Visible = True
        Me.File9.Visible = True
        Me.File10.Visible = True

        '--------------------------------------------------

        Me.Label34.Visible = True
        Me.Label35.Visible = True
        Me.Label36.Visible = True
        Me.Label37.Visible = True
        Me.txtname6.Visible = True
        Me.txtdesig6.Visible = True
        Me.File11.Visible = True
        Me.File12.Visible = True

        Me.Label38.Visible = True
        Me.Label39.Visible = True
        Me.Label40.Visible = True
        Me.Label41.Visible = True
        Me.txtname7.Visible = True
        Me.txtdesig7.Visible = True
        Me.File13.Visible = True
        Me.File14.Visible = True

        Me.Label42.Visible = True
        Me.Label43.Visible = True
        Me.Label44.Visible = True
        Me.Label45.Visible = True
        Me.txtname8.Visible = True
        Me.txtdesig8.Visible = True
        Me.File15.Visible = True
        Me.File16.Visible = True

        Me.Label46.Visible = True
        Me.Label47.Visible = True
        Me.Label48.Visible = True
        Me.Label49.Visible = True
        Me.txtname9.Visible = True
        Me.txtdesig9.Visible = True
        Me.File17.Visible = True
        Me.File18.Visible = True

        Me.Label50.Visible = False
        Me.Label51.Visible = False
        Me.Label52.Visible = False
        Me.Label53.Visible = False
        Me.txtname10.Visible = False
        Me.txtdesig10.Visible = False
        Me.File19.Visible = False
        Me.File20.Visible = False

    End Sub
    Sub viscase1010()
        Me.Label10.Visible = True
        Me.Label11.Visible = True
        Me.Label12.Visible = True
        Me.Label13.Visible = True
        Me.txtname1.Visible = True
        Me.txtdesig1.Visible = True
        Me.File1.Visible = True
        Me.File2.Visible = True

        Me.Label14.Visible = True
        Me.Label15.Visible = True
        Me.Label16.Visible = True
        Me.Label17.Visible = True
        Me.txtname2.Visible = True
        Me.txtdesig2.Visible = True
        Me.File3.Visible = True
        Me.File4.Visible = True
        Dim signatory(10) As String
        Dim mandate1(10) As String
        Dim mandate2(10) As String
        Dim designate(10) As String
        Dim selexist1 As String = "exec proc_mandatelist '" & Me.txtAcNumber.Text.Trim & "', " & Session("node_ID") & ""
        Dim i As Integer = 0
        If con.SqlDs(selexist1).Tables(0).Rows.Count > 0 Then
            For Each dr As Data.DataRow In con.SqlDs(selexist1).Tables(0).Rows
                signatory(i) = dr!signatoryname.ToString
                mandate1(i) = dr!mandatedesc1.ToString
                designate(i) = dr!designation.ToString
                '  mandate2(i) = dr!mandatedesc2.ToString
                i = i + 1
            Next

        End If

        Me.txtname1.Text = signatory(0)
        Me.txtdesig1.Text = designate(0)
        Me.txtmandate1.Text = mandate1(0)

        Me.txtname2.Text = signatory(1)
        Me.txtdesig2.Text = designate(1)

        Me.txtname3.Text = signatory(2)
        Me.txtdesig3.Text = designate(2)

        Me.txtname4.Text = signatory(3)
        Me.txtdesig4.Text = designate(3)

        Me.txtname5.Text = signatory(4)
        Me.txtdesig5.Text = designate(4)

        Me.txtname6.Text = signatory(5)
        Me.txtdesig6.Text = designate(5)

        Me.txtname7.Text = signatory(6)
        Me.txtdesig7.Text = designate(6)

        Me.txtname8.Text = signatory(7)
        Me.txtdesig8.Text = designate(7)

        Me.txtname9.Text = signatory(8)
        Me.txtdesig9.Text = designate(8)

        Me.txtname10.Text = signatory(9)
        Me.txtdesig10.Text = designate(9)

        Me.Label18.Visible = True
        Me.Label19.Visible = True
        Me.Label20.Visible = True
        Me.Label21.Visible = True
        Me.txtname3.Visible = True
        Me.txtdesig3.Visible = True
        Me.File5.Visible = True
        Me.File6.Visible = True


        Me.Label22.Visible = True
        Me.Label23.Visible = True
        Me.Label24.Visible = True
        Me.Label25.Visible = True
        Me.txtname4.Visible = True
        Me.txtdesig4.Visible = True
        Me.File7.Visible = True
        Me.File8.Visible = True



        Me.Label26.Visible = True
        Me.Label27.Visible = True
        Me.Label28.Visible = True
        Me.Label29.Visible = True
        Me.txtname5.Visible = True
        Me.txtdesig5.Visible = True
        Me.File9.Visible = True
        Me.File10.Visible = True

        '--------------------------------------------------

        Me.Label34.Visible = True
        Me.Label35.Visible = True
        Me.Label36.Visible = True
        Me.Label37.Visible = True
        Me.txtname6.Visible = True
        Me.txtdesig6.Visible = True
        Me.File11.Visible = True
        Me.File12.Visible = True

        Me.Label38.Visible = True
        Me.Label39.Visible = True
        Me.Label40.Visible = True
        Me.Label41.Visible = True
        Me.txtname7.Visible = True
        Me.txtdesig7.Visible = True
        Me.File13.Visible = True
        Me.File14.Visible = True

        Me.Label42.Visible = True
        Me.Label43.Visible = True
        Me.Label44.Visible = True
        Me.Label45.Visible = True
        Me.txtname8.Visible = True
        Me.txtdesig8.Visible = True
        Me.File15.Visible = True
        Me.File16.Visible = True

        Me.Label46.Visible = True
        Me.Label47.Visible = True
        Me.Label48.Visible = True
        Me.Label49.Visible = True
        Me.txtname9.Visible = True
        Me.txtdesig9.Visible = True
        Me.File17.Visible = True
        Me.File18.Visible = True

        Me.Label50.Visible = True
        Me.Label51.Visible = True
        Me.Label52.Visible = True
        Me.Label53.Visible = True
        Me.txtname10.Visible = True
        Me.txtdesig10.Visible = True
        Me.File19.Visible = True
        Me.File20.Visible = True

    End Sub
#Region "disable"
    Sub viscase1()
        Me.Label10.Visible = True
        Me.Label11.Visible = True
        Me.Label12.Visible = True
        Me.Label13.Visible = True
        Me.txtname1.Visible = True
        Me.txtdesig1.Visible = True
        Me.File1.Visible = True
        Me.File2.Visible = True
        Me.Label30.Visible = True
        Me.txtname1.Text = Me.Label1.Text.Trim
        Me.txtmandate1.Text = "Sole Signatory"

        Me.txtmandate1.Visible = True

        Me.Label14.Visible = False
        Me.Label15.Visible = False
        Me.Label16.Visible = False
        Me.Label17.Visible = False
        Me.txtname2.Visible = False
        Me.txtdesig2.Visible = False
        Me.File3.Visible = False
        Me.File4.Visible = False

        Me.Label18.Visible = False
        Me.Label19.Visible = False
        Me.Label20.Visible = False
        Me.Label21.Visible = False
        Me.txtname3.Visible = False
        Me.txtdesig3.Visible = False
        Me.File5.Visible = False
        Me.File6.Visible = False


        Me.Label22.Visible = False
        Me.Label23.Visible = False
        Me.Label24.Visible = False
        Me.Label25.Visible = False
        Me.txtname4.Visible = False
        Me.txtdesig4.Visible = False
        Me.File7.Visible = False
        Me.File8.Visible = False


        Me.Label26.Visible = False
        Me.Label27.Visible = False
        Me.Label28.Visible = False
        Me.Label29.Visible = False
        Me.txtname5.Visible = False
        Me.txtdesig5.Visible = False
        Me.File9.Visible = False
        Me.File10.Visible = False

        Me.Label34.Visible = False
        Me.Label35.Visible = False
        Me.Label36.Visible = False
        Me.Label37.Visible = False
        Me.txtname6.Visible = False
        Me.txtdesig6.Visible = False
        Me.File11.Visible = False
        Me.File12.Visible = False

        Me.Label38.Visible = False
        Me.Label39.Visible = False
        Me.Label40.Visible = False
        Me.Label41.Visible = False
        Me.txtname7.Visible = False
        Me.txtdesig7.Visible = False
        Me.File13.Visible = False
        Me.File14.Visible = False

        Me.Label42.Visible = False
        Me.Label43.Visible = False
        Me.Label44.Visible = False
        Me.Label45.Visible = False
        Me.txtname8.Visible = False
        Me.txtdesig8.Visible = False
        Me.File15.Visible = False
        Me.File16.Visible = False

        Me.Label46.Visible = False
        Me.Label47.Visible = False
        Me.Label48.Visible = False
        Me.Label49.Visible = False
        Me.txtname9.Visible = False
        Me.txtdesig9.Visible = False
        Me.File17.Visible = False
        Me.File18.Visible = False

        Me.Label50.Visible = False
        Me.Label51.Visible = False
        Me.Label52.Visible = False
        Me.Label53.Visible = False
        Me.txtname10.Visible = False
        Me.txtdesig10.Visible = False
        Me.File19.Visible = False
        Me.File20.Visible = False
    End Sub
    Sub viscase2()
        Me.Label10.Visible = True
        Me.Label11.Visible = True
        Me.Label12.Visible = True
        Me.Label13.Visible = True
        Me.txtname1.Visible = True
        Me.txtdesig1.Visible = True
        Me.File1.Visible = True
        Me.File2.Visible = True

        Me.Label14.Visible = True
        Me.Label15.Visible = True
        Me.Label16.Visible = True
        Me.Label17.Visible = True
        Me.txtname2.Visible = True
        Me.txtdesig2.Visible = True
        Me.File3.Visible = True
        Me.File4.Visible = True

        Me.Label18.Visible = False
        Me.Label19.Visible = False
        Me.Label20.Visible = False
        Me.Label21.Visible = False
        Me.txtname3.Visible = False
        Me.txtdesig3.Visible = False
        Me.File5.Visible = False
        Me.File6.Visible = False


        Me.Label22.Visible = False
        Me.Label23.Visible = False
        Me.Label24.Visible = False
        Me.Label25.Visible = False
        Me.txtname4.Visible = False
        Me.txtdesig4.Visible = False
        Me.File7.Visible = False
        Me.File8.Visible = False


        Me.Label26.Visible = False
        Me.Label27.Visible = False
        Me.Label28.Visible = False
        Me.Label29.Visible = False
        Me.txtname5.Visible = False
        Me.txtdesig5.Visible = False
        Me.File9.Visible = False
        Me.File10.Visible = False

        Me.Label34.Visible = False
        Me.Label35.Visible = False
        Me.Label36.Visible = False
        Me.Label37.Visible = False
        Me.txtname6.Visible = False
        Me.txtdesig6.Visible = False
        Me.File11.Visible = False
        Me.File12.Visible = False

        Me.Label38.Visible = False
        Me.Label39.Visible = False
        Me.Label40.Visible = False
        Me.Label41.Visible = False
        Me.txtname7.Visible = False
        Me.txtdesig7.Visible = False
        Me.File13.Visible = False
        Me.File14.Visible = False

        Me.Label42.Visible = False
        Me.Label43.Visible = False
        Me.Label44.Visible = False
        Me.Label45.Visible = False
        Me.txtname8.Visible = False
        Me.txtdesig8.Visible = False
        Me.File15.Visible = False
        Me.File16.Visible = False

        Me.Label46.Visible = False
        Me.Label47.Visible = False
        Me.Label48.Visible = False
        Me.Label49.Visible = False
        Me.txtname9.Visible = False
        Me.txtdesig9.Visible = False
        Me.File17.Visible = False
        Me.File18.Visible = False

        Me.Label50.Visible = False
        Me.Label51.Visible = False
        Me.Label52.Visible = False
        Me.Label53.Visible = False
        Me.txtname10.Visible = False
        Me.txtdesig10.Visible = False
        Me.File19.Visible = False
        Me.File20.Visible = False
    End Sub
    Sub viscase3()
        Me.Label10.Visible = True
        Me.Label11.Visible = True
        Me.Label12.Visible = True
        Me.Label13.Visible = True
        Me.txtname1.Visible = True
        Me.txtdesig1.Visible = True
        Me.File1.Visible = True
        Me.File2.Visible = True

        Me.Label14.Visible = True
        Me.Label15.Visible = True
        Me.Label16.Visible = True
        Me.Label17.Visible = True
        Me.txtname2.Visible = True
        Me.txtdesig2.Visible = True
        Me.File3.Visible = True
        Me.File4.Visible = True


        Me.Label18.Visible = True
        Me.Label19.Visible = True
        Me.Label20.Visible = True
        Me.Label21.Visible = True
        Me.txtname3.Visible = True
        Me.txtdesig3.Visible = True
        Me.File5.Visible = True
        Me.File6.Visible = True


        Me.Label22.Visible = False
        Me.Label23.Visible = False
        Me.Label24.Visible = False
        Me.Label25.Visible = False
        Me.txtname4.Visible = False
        Me.txtdesig4.Visible = False
        Me.File7.Visible = False
        Me.File8.Visible = False


        Me.Label26.Visible = False
        Me.Label27.Visible = False
        Me.Label28.Visible = False
        Me.Label29.Visible = False
        Me.txtname5.Visible = False
        Me.txtdesig5.Visible = False
        Me.File9.Visible = False
        Me.File10.Visible = False

        Me.Label34.Visible = False
        Me.Label35.Visible = False
        Me.Label36.Visible = False
        Me.Label37.Visible = False
        Me.txtname6.Visible = False
        Me.txtdesig6.Visible = False
        Me.File11.Visible = False
        Me.File12.Visible = False

        Me.Label38.Visible = False
        Me.Label39.Visible = False
        Me.Label40.Visible = False
        Me.Label41.Visible = False
        Me.txtname7.Visible = False
        Me.txtdesig7.Visible = False
        Me.File13.Visible = False
        Me.File14.Visible = False

        Me.Label42.Visible = False
        Me.Label43.Visible = False
        Me.Label44.Visible = False
        Me.Label45.Visible = False
        Me.txtname8.Visible = False
        Me.txtdesig8.Visible = False
        Me.File15.Visible = False
        Me.File16.Visible = False

        Me.Label46.Visible = False
        Me.Label47.Visible = False
        Me.Label48.Visible = False
        Me.Label49.Visible = False
        Me.txtname9.Visible = False
        Me.txtdesig9.Visible = False
        Me.File17.Visible = False
        Me.File18.Visible = False

        Me.Label50.Visible = False
        Me.Label51.Visible = False
        Me.Label52.Visible = False
        Me.Label53.Visible = False
        Me.txtname10.Visible = False
        Me.txtdesig10.Visible = False
        Me.File19.Visible = False
        Me.File20.Visible = False
    End Sub
    Sub viscase4()
        Me.Label10.Visible = True
        Me.Label11.Visible = True
        Me.Label12.Visible = True
        Me.Label13.Visible = True
        Me.txtname1.Visible = True
        Me.txtdesig1.Visible = True
        Me.File1.Visible = True
        Me.File2.Visible = True

        Me.Label14.Visible = True
        Me.Label15.Visible = True
        Me.Label16.Visible = True
        Me.Label17.Visible = True
        Me.txtname2.Visible = True
        Me.txtdesig2.Visible = True
        Me.File3.Visible = True
        Me.File4.Visible = True


        Me.Label18.Visible = True
        Me.Label19.Visible = True
        Me.Label20.Visible = True
        Me.Label21.Visible = True
        Me.txtname3.Visible = True
        Me.txtdesig3.Visible = True
        Me.File5.Visible = True
        Me.File6.Visible = True


        Me.Label22.Visible = True
        Me.Label23.Visible = True
        Me.Label24.Visible = True
        Me.Label25.Visible = True
        Me.txtname4.Visible = True
        Me.txtdesig4.Visible = True
        Me.File7.Visible = True
        Me.File8.Visible = True


        Me.Label26.Visible = False
        Me.Label27.Visible = False
        Me.Label28.Visible = False
        Me.Label29.Visible = False
        Me.txtname5.Visible = False
        Me.txtdesig5.Visible = False
        Me.File9.Visible = False
        Me.File10.Visible = False

        Me.Label34.Visible = False
        Me.Label35.Visible = False
        Me.Label36.Visible = False
        Me.Label37.Visible = False
        Me.txtname6.Visible = False
        Me.txtdesig6.Visible = False
        Me.File11.Visible = False
        Me.File12.Visible = False

        Me.Label38.Visible = False
        Me.Label39.Visible = False
        Me.Label40.Visible = False
        Me.Label41.Visible = False
        Me.txtname7.Visible = False
        Me.txtdesig7.Visible = False
        Me.File13.Visible = False
        Me.File14.Visible = False

        Me.Label42.Visible = False
        Me.Label43.Visible = False
        Me.Label44.Visible = False
        Me.Label45.Visible = False
        Me.txtname8.Visible = False
        Me.txtdesig8.Visible = False
        Me.File15.Visible = False
        Me.File16.Visible = False

        Me.Label46.Visible = False
        Me.Label47.Visible = False
        Me.Label48.Visible = False
        Me.Label49.Visible = False
        Me.txtname9.Visible = False
        Me.txtdesig9.Visible = False
        Me.File17.Visible = False
        Me.File18.Visible = False

        Me.Label50.Visible = False
        Me.Label51.Visible = False
        Me.Label52.Visible = False
        Me.Label53.Visible = False
        Me.txtname10.Visible = False
        Me.txtdesig10.Visible = False
        Me.File19.Visible = False
        Me.File20.Visible = False
    End Sub
    Sub viscase5()
        Me.Label10.Visible = True
        Me.Label11.Visible = True
        Me.Label12.Visible = True
        Me.Label13.Visible = True
        Me.txtname1.Visible = True
        Me.txtdesig1.Visible = True
        Me.File1.Visible = True
        Me.File2.Visible = True

        Me.Label14.Visible = True
        Me.Label15.Visible = True
        Me.Label16.Visible = True
        Me.Label17.Visible = True
        Me.txtname2.Visible = True
        Me.txtdesig2.Visible = True
        Me.File3.Visible = True
        Me.File4.Visible = True


        Me.Label18.Visible = True
        Me.Label19.Visible = True
        Me.Label20.Visible = True
        Me.Label21.Visible = True
        Me.txtname3.Visible = True
        Me.txtdesig3.Visible = True
        Me.File5.Visible = True
        Me.File6.Visible = True


        Me.Label22.Visible = True
        Me.Label23.Visible = True
        Me.Label24.Visible = True
        Me.Label25.Visible = True
        Me.txtname4.Visible = True
        Me.txtdesig4.Visible = True
        Me.File7.Visible = True
        Me.File8.Visible = True



        Me.Label26.Visible = True
        Me.Label27.Visible = True
        Me.Label28.Visible = True
        Me.Label29.Visible = True
        Me.txtname5.Visible = True
        Me.txtdesig5.Visible = True
        Me.File9.Visible = True
        Me.File10.Visible = True

        Me.Label34.Visible = False
        Me.Label35.Visible = False
        Me.Label36.Visible = False
        Me.Label37.Visible = False
        Me.txtname6.Visible = False
        Me.txtdesig6.Visible = False
        Me.File11.Visible = False
        Me.File12.Visible = False

        Me.Label38.Visible = False
        Me.Label39.Visible = False
        Me.Label40.Visible = False
        Me.Label41.Visible = False
        Me.txtname7.Visible = False
        Me.txtdesig7.Visible = False
        Me.File13.Visible = False
        Me.File14.Visible = False

        Me.Label42.Visible = False
        Me.Label43.Visible = False
        Me.Label44.Visible = False
        Me.Label45.Visible = False
        Me.txtname8.Visible = False
        Me.txtdesig8.Visible = False
        Me.File15.Visible = False
        Me.File16.Visible = False

        Me.Label46.Visible = False
        Me.Label47.Visible = False
        Me.Label48.Visible = False
        Me.Label49.Visible = False
        Me.txtname9.Visible = False
        Me.txtdesig9.Visible = False
        Me.File17.Visible = False
        Me.File18.Visible = False

        Me.Label50.Visible = False
        Me.Label51.Visible = False
        Me.Label52.Visible = False
        Me.Label53.Visible = False
        Me.txtname10.Visible = False
        Me.txtdesig10.Visible = False
        Me.File19.Visible = False
        Me.File20.Visible = False


    End Sub
    Sub viscase6()
        Me.Label10.Visible = True
        Me.Label11.Visible = True
        Me.Label12.Visible = True
        Me.Label13.Visible = True
        Me.txtname1.Visible = True
        Me.txtdesig1.Visible = True
        Me.File1.Visible = True
        Me.File2.Visible = True

        Me.Label14.Visible = True
        Me.Label15.Visible = True
        Me.Label16.Visible = True
        Me.Label17.Visible = True
        Me.txtname2.Visible = True
        Me.txtdesig2.Visible = True
        Me.File3.Visible = True
        Me.File4.Visible = True


        Me.Label18.Visible = True
        Me.Label19.Visible = True
        Me.Label20.Visible = True
        Me.Label21.Visible = True
        Me.txtname3.Visible = True
        Me.txtdesig3.Visible = True
        Me.File5.Visible = True
        Me.File6.Visible = True


        Me.Label22.Visible = True
        Me.Label23.Visible = True
        Me.Label24.Visible = True
        Me.Label25.Visible = True
        Me.txtname4.Visible = True
        Me.txtdesig4.Visible = True
        Me.File7.Visible = True
        Me.File8.Visible = True



        Me.Label26.Visible = True
        Me.Label27.Visible = True
        Me.Label28.Visible = True
        Me.Label29.Visible = True
        Me.txtname5.Visible = True
        Me.txtdesig5.Visible = True
        Me.File9.Visible = True
        Me.File10.Visible = True
        '-----------------------------------------------------------------
        Me.Label34.Visible = True
        Me.Label35.Visible = True
        Me.Label36.Visible = True
        Me.Label37.Visible = True
        Me.txtname6.Visible = True
        Me.txtdesig6.Visible = True
        Me.File11.Visible = True
        Me.File12.Visible = True

        Me.Label38.Visible = False
        Me.Label39.Visible = False
        Me.Label40.Visible = False
        Me.Label41.Visible = False
        Me.txtname7.Visible = False
        Me.txtdesig7.Visible = False
        Me.File13.Visible = False
        Me.File14.Visible = False

        Me.Label42.Visible = False
        Me.Label43.Visible = False
        Me.Label44.Visible = False
        Me.Label45.Visible = False
        Me.txtname8.Visible = False
        Me.txtdesig8.Visible = False
        Me.File15.Visible = False
        Me.File16.Visible = False

        Me.Label46.Visible = False
        Me.Label47.Visible = False
        Me.Label48.Visible = False
        Me.Label49.Visible = False
        Me.txtname9.Visible = False
        Me.txtdesig9.Visible = False
        Me.File17.Visible = False
        Me.File18.Visible = False

        Me.Label50.Visible = False
        Me.Label51.Visible = False
        Me.Label52.Visible = False
        Me.Label53.Visible = False
        Me.txtname10.Visible = False
        Me.txtdesig10.Visible = False
        Me.File19.Visible = False
        Me.File20.Visible = False

    End Sub

    Sub viscase7()
        Me.Label10.Visible = True
        Me.Label11.Visible = True
        Me.Label12.Visible = True
        Me.Label13.Visible = True
        Me.txtname1.Visible = True
        Me.txtdesig1.Visible = True
        Me.File1.Visible = True
        Me.File2.Visible = True

        Me.Label14.Visible = True
        Me.Label15.Visible = True
        Me.Label16.Visible = True
        Me.Label17.Visible = True
        Me.txtname2.Visible = True
        Me.txtdesig2.Visible = True
        Me.File3.Visible = True
        Me.File4.Visible = True


        Me.Label18.Visible = True
        Me.Label19.Visible = True
        Me.Label20.Visible = True
        Me.Label21.Visible = True
        Me.txtname3.Visible = True
        Me.txtdesig3.Visible = True
        Me.File5.Visible = True
        Me.File6.Visible = True


        Me.Label22.Visible = True
        Me.Label23.Visible = True
        Me.Label24.Visible = True
        Me.Label25.Visible = True
        Me.txtname4.Visible = True
        Me.txtdesig4.Visible = True
        Me.File7.Visible = True
        Me.File8.Visible = True



        Me.Label26.Visible = True
        Me.Label27.Visible = True
        Me.Label28.Visible = True
        Me.Label29.Visible = True
        Me.txtname5.Visible = True
        Me.txtdesig5.Visible = True
        Me.File9.Visible = True
        Me.File10.Visible = True
        '-----------------------------------------------------------------
        Me.Label34.Visible = True
        Me.Label35.Visible = True
        Me.Label36.Visible = True
        Me.Label37.Visible = True
        Me.txtname6.Visible = True
        Me.txtdesig6.Visible = True
        Me.File11.Visible = True
        Me.File12.Visible = True

        Me.Label38.Visible = True
        Me.Label39.Visible = True
        Me.Label40.Visible = True
        Me.Label41.Visible = True
        Me.txtname7.Visible = True
        Me.txtdesig7.Visible = True
        Me.File13.Visible = True
        Me.File14.Visible = True

        Me.Label42.Visible = False
        Me.Label43.Visible = False
        Me.Label44.Visible = False
        Me.Label45.Visible = False
        Me.txtname8.Visible = False
        Me.txtdesig8.Visible = False
        Me.File15.Visible = False
        Me.File16.Visible = False

        Me.Label46.Visible = False
        Me.Label47.Visible = False
        Me.Label48.Visible = False
        Me.Label49.Visible = False
        Me.txtname9.Visible = False
        Me.txtdesig9.Visible = False
        Me.File17.Visible = False
        Me.File18.Visible = False

        Me.Label50.Visible = False
        Me.Label51.Visible = False
        Me.Label52.Visible = False
        Me.Label53.Visible = False
        Me.txtname10.Visible = False
        Me.txtdesig10.Visible = False
        Me.File19.Visible = False
        Me.File20.Visible = False

    End Sub
    Sub viscase8()
        Me.Label10.Visible = True
        Me.Label11.Visible = True
        Me.Label12.Visible = True
        Me.Label13.Visible = True
        Me.txtname1.Visible = True
        Me.txtdesig1.Visible = True
        Me.File1.Visible = True
        Me.File2.Visible = True

        Me.Label14.Visible = True
        Me.Label15.Visible = True
        Me.Label16.Visible = True
        Me.Label17.Visible = True
        Me.txtname2.Visible = True
        Me.txtdesig2.Visible = True
        Me.File3.Visible = True
        Me.File4.Visible = True


        Me.Label18.Visible = True
        Me.Label19.Visible = True
        Me.Label20.Visible = True
        Me.Label21.Visible = True
        Me.txtname3.Visible = True
        Me.txtdesig3.Visible = True
        Me.File5.Visible = True
        Me.File6.Visible = True


        Me.Label22.Visible = True
        Me.Label23.Visible = True
        Me.Label24.Visible = True
        Me.Label25.Visible = True
        Me.txtname4.Visible = True
        Me.txtdesig4.Visible = True
        Me.File7.Visible = True
        Me.File8.Visible = True



        Me.Label26.Visible = True
        Me.Label27.Visible = True
        Me.Label28.Visible = True
        Me.Label29.Visible = True
        Me.txtname5.Visible = True
        Me.txtdesig5.Visible = True
        Me.File9.Visible = True
        Me.File10.Visible = True
        '-----------------------------------------------------------------
        Me.Label34.Visible = True
        Me.Label35.Visible = True
        Me.Label36.Visible = True
        Me.Label37.Visible = True
        Me.txtname6.Visible = True
        Me.txtdesig6.Visible = True
        Me.File11.Visible = True
        Me.File12.Visible = True

        Me.Label38.Visible = True
        Me.Label39.Visible = True
        Me.Label40.Visible = True
        Me.Label41.Visible = True
        Me.txtname7.Visible = True
        Me.txtdesig7.Visible = True
        Me.File13.Visible = True
        Me.File14.Visible = True

        Me.Label42.Visible = True
        Me.Label43.Visible = True
        Me.Label44.Visible = True
        Me.Label45.Visible = True
        Me.txtname8.Visible = True
        Me.txtdesig8.Visible = True
        Me.File15.Visible = True
        Me.File16.Visible = True

        Me.Label46.Visible = False
        Me.Label47.Visible = False
        Me.Label48.Visible = False
        Me.Label49.Visible = False
        Me.txtname9.Visible = False
        Me.txtdesig9.Visible = False
        Me.File17.Visible = False
        Me.File18.Visible = False

        Me.Label50.Visible = False
        Me.Label51.Visible = False
        Me.Label52.Visible = False
        Me.Label53.Visible = False
        Me.txtname10.Visible = False
        Me.txtdesig10.Visible = False
        Me.File19.Visible = False
        Me.File20.Visible = False


    End Sub
    Sub viscase9()
        Me.Label10.Visible = True
        Me.Label11.Visible = True
        Me.Label12.Visible = True
        Me.Label13.Visible = True
        Me.txtname1.Visible = True
        Me.txtdesig1.Visible = True
        Me.File1.Visible = True
        Me.File2.Visible = True

        Me.Label14.Visible = True
        Me.Label15.Visible = True
        Me.Label16.Visible = True
        Me.Label17.Visible = True
        Me.txtname2.Visible = True
        Me.txtdesig2.Visible = True
        Me.File3.Visible = True
        Me.File4.Visible = True


        Me.Label18.Visible = True
        Me.Label19.Visible = True
        Me.Label20.Visible = True
        Me.Label21.Visible = True
        Me.txtname3.Visible = True
        Me.txtdesig3.Visible = True
        Me.File5.Visible = True
        Me.File6.Visible = True


        Me.Label22.Visible = True
        Me.Label23.Visible = True
        Me.Label24.Visible = True
        Me.Label25.Visible = True
        Me.txtname4.Visible = True
        Me.txtdesig4.Visible = True
        Me.File7.Visible = True
        Me.File8.Visible = True



        Me.Label26.Visible = True
        Me.Label27.Visible = True
        Me.Label28.Visible = True
        Me.Label29.Visible = True
        Me.txtname5.Visible = True
        Me.txtdesig5.Visible = True
        Me.File9.Visible = True
        Me.File10.Visible = True
        '-----------------------------------------------------------------
        Me.Label34.Visible = True
        Me.Label35.Visible = True
        Me.Label36.Visible = True
        Me.Label37.Visible = True
        Me.txtname6.Visible = True
        Me.txtdesig6.Visible = True
        Me.File11.Visible = True
        Me.File12.Visible = True

        Me.Label38.Visible = True
        Me.Label39.Visible = True
        Me.Label40.Visible = True
        Me.Label41.Visible = True
        Me.txtname7.Visible = True
        Me.txtdesig7.Visible = True
        Me.File13.Visible = True
        Me.File14.Visible = True

        Me.Label42.Visible = True
        Me.Label43.Visible = True
        Me.Label44.Visible = True
        Me.Label45.Visible = True
        Me.txtname8.Visible = True
        Me.txtdesig8.Visible = True
        Me.File15.Visible = True
        Me.File16.Visible = True

        Me.Label46.Visible = True
        Me.Label47.Visible = True
        Me.Label48.Visible = True
        Me.Label49.Visible = True
        Me.txtname9.Visible = True
        Me.txtdesig9.Visible = True
        Me.File17.Visible = True
        Me.File18.Visible = True

        Me.Label50.Visible = False
        Me.Label51.Visible = False
        Me.Label52.Visible = False
        Me.Label53.Visible = False
        Me.txtname10.Visible = False
        Me.txtdesig10.Visible = False
        Me.File19.Visible = False
        Me.File20.Visible = False


    End Sub
    Sub viscase10()
        Me.Label10.Visible = True
        Me.Label11.Visible = True
        Me.Label12.Visible = True
        Me.Label13.Visible = True
        Me.txtname1.Visible = True
        Me.txtdesig1.Visible = True
        Me.File1.Visible = True
        Me.File2.Visible = True

        Me.Label14.Visible = True
        Me.Label15.Visible = True
        Me.Label16.Visible = True
        Me.Label17.Visible = True
        Me.txtname2.Visible = True
        Me.txtdesig2.Visible = True
        Me.File3.Visible = True
        Me.File4.Visible = True


        Me.Label18.Visible = True
        Me.Label19.Visible = True
        Me.Label20.Visible = True
        Me.Label21.Visible = True
        Me.txtname3.Visible = True
        Me.txtdesig3.Visible = True
        Me.File5.Visible = True
        Me.File6.Visible = True


        Me.Label22.Visible = True
        Me.Label23.Visible = True
        Me.Label24.Visible = True
        Me.Label25.Visible = True
        Me.txtname4.Visible = True
        Me.txtdesig4.Visible = True
        Me.File7.Visible = True
        Me.File8.Visible = True



        Me.Label26.Visible = True
        Me.Label27.Visible = True
        Me.Label28.Visible = True
        Me.Label29.Visible = True
        Me.txtname5.Visible = True
        Me.txtdesig5.Visible = True
        Me.File9.Visible = True
        Me.File10.Visible = True
        '-----------------------------------------------------------------
        Me.Label34.Visible = True
        Me.Label35.Visible = True
        Me.Label36.Visible = True
        Me.Label37.Visible = True
        Me.txtname6.Visible = True
        Me.txtdesig6.Visible = True
        Me.File11.Visible = True
        Me.File12.Visible = True

        Me.Label38.Visible = True
        Me.Label39.Visible = True
        Me.Label40.Visible = True
        Me.Label41.Visible = True
        Me.txtname7.Visible = True
        Me.txtdesig7.Visible = True
        Me.File13.Visible = True
        Me.File14.Visible = True

        Me.Label42.Visible = True
        Me.Label43.Visible = True
        Me.Label44.Visible = True
        Me.Label45.Visible = True
        Me.txtname8.Visible = True
        Me.txtdesig8.Visible = True
        Me.File15.Visible = True
        Me.File16.Visible = True

        Me.Label46.Visible = True
        Me.Label47.Visible = True
        Me.Label48.Visible = True
        Me.Label49.Visible = True
        Me.txtname9.Visible = True
        Me.txtdesig9.Visible = True
        Me.File17.Visible = True
        Me.File18.Visible = True

        Me.Label50.Visible = True
        Me.Label51.Visible = True
        Me.Label52.Visible = True
        Me.Label53.Visible = True
        Me.txtname10.Visible = True
        Me.txtdesig10.Visible = True
        Me.File19.Visible = True
        Me.File20.Visible = True


    End Sub


#End Region
    Sub refresh()
        If IsNumeric(Me.txtnosign.Text) Then
            Dim inc As Integer = Me.txtnosign.Text.Trim
            Select Case inc
                Case 1
                    viscase1()
                Case 2
                    viscase2()
                Case 3
                    viscase3()
                Case 4
                    viscase4()
                Case 5
                    viscase5()
                Case 6
                    viscase6()
                Case 7
                    viscase7()
                Case 8
                    viscase8()
                Case 9
                    viscase9()
                Case 10
                    viscase10()
            End Select
        End If
    End Sub
    Protected Sub txtnosign_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnosign.TextChanged
        refresh()

    End Sub
    '#Region "upload"
    '    Sub uploadimage1()
    '        Try
    '            Dim intLength As Integer
    '            Dim intLength2 As Integer
    '            Dim imgType = File1.PostedFile.ContentType
    '            Dim imgType2 = File11.PostedFile.ContentType
    '            Dim arrContent As Byte()
    '            Dim arrContent2 As Byte()
    '            Dim empttyContent As Byte()
    '            Dim ext As String = "" : Dim ext2 As String = ""
    '            intLength = Convert.ToInt32(File1.PostedFile.InputStream.Length)
    '            intLength2 = Convert.ToInt32(File11.PostedFile.InputStream.Length)
    '            If File1.PostedFile Is Nothing Then
    '                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
    '            Else
    '                'If (intLength > 35001) Then
    '                '    smartobj.alertwindow(Me.Page, "Photo too Large for Upload", "Prime")
    '                '    Exit Sub
    '                'Else
    '                '    Dim fileName As String = File1.PostedFile.FileName
    '                '    If fileName = "" Then
    '                '    Else
    '                '        ext = fileName.Substring(fileName.LastIndexOf("."))
    '                '        ext = ext.ToLower

    '                '    End If

    '                'End If
    '            End If

    '            If File11.PostedFile Is Nothing Then
    '                smartobj.alertwindow(Me.Page, "Please Upload Account Signature", "Prime")
    '                Exit Sub
    '            Else
    '                'If (intLength2 > 35001) Then
    '                '    smartobj.alertwindow(Me.Page, "Signature too large to Upload", "Prime")
    '                '    Exit Sub
    '                'Else
    '                '    Dim fileName2 As String = File11.PostedFile.FileName
    '                '    If fileName2 = "" Then
    '                '    Else
    '                '        ext2 = fileName2.Substring(fileName2.LastIndexOf("."))
    '                '        ext2 = ext2.ToLower

    '                '    End If
    '                'End If
    '            End If
    '            ReDim arrContent(intLength)
    '            ReDim arrContent2(intLength2)
    '            ReDim empttyContent(2)
    '            If intLength = 0 Then
    '                File1.PostedFile.InputStream.Read(empttyContent, 0, 2)
    '                imgType = ext
    '            Else
    '                File1.PostedFile.InputStream.Read(arrContent, 0, intLength)
    '            End If
    '            If intLength2 = 0 Then
    '                File11.PostedFile.InputStream.Read(empttyContent, 0, 2)
    '                imgType2 = ext2
    '            Else
    '                File11.PostedFile.InputStream.Read(arrContent2, 0, intLength)
    '            End If

    '            If Doc2SQLServer1(Me.txtAcNumber.Text.Trim, arrContent, arrContent2, imgType, imgType2) = True Then
    '                'smartobj.alertwindow(Me.Page, "Image uploaded successfully.", "Prime")
    '            Else
    '                'smartobj.alertwindow(Me.Page, "Please upload Signature in Jpeg Format Only", "Prime")
    '            End If


    '        Catch ex As Exception
    '            smartobj.alertwindow(Me.Page, "Please upload Signature in Jpeg Format Only", "Prime")
    '        End Try

    '    End Sub
    '    Protected Function Doc2SQLServer1(ByVal accountnumber As String, ByVal Content As Byte(), ByVal Content2 As Byte(), ByVal strType As String, ByVal strType2 As String) As Boolean
    '        Try
    '            Dim cmd As Data.SqlClient.SqlCommand
    '            Dim param As Data.SqlClient.SqlParameter
    '            Dim strSQL As String
    '            strSQL = "Insert into tbl_mandatepicts (customerImage,signatureImage,Image_Type,Image_Type2,accountnumber) Values (@content,@content2,@type,@type,@Accountno)"

    '            cmd = New Data.SqlClient.SqlCommand(strSQL, MyCon)
    '            param = New Data.SqlClient.SqlParameter("@content", Data.SqlDbType.Image)
    '            param.Value = Content
    '            cmd.Parameters.Add(param)
    '            param = New Data.SqlClient.SqlParameter("@content2", Data.SqlDbType.Image)
    '            param.Value = Content2
    '            cmd.Parameters.Add(param)
    '            param = New Data.SqlClient.SqlParameter("@Accountno", Data.SqlDbType.VarChar)
    '            param.Value = accountnumber
    '            cmd.Parameters.Add(param)
    '            param = New Data.SqlClient.SqlParameter("@type", Data.SqlDbType.VarChar)
    '            param.Value = strType
    '            cmd.Parameters.Add(param)
    '            param = New Data.SqlClient.SqlParameter("@type2", Data.SqlDbType.VarChar)
    '            param.Value = strType2
    '            cmd.Parameters.Add(param)
    '            MyCon.Open()
    '            cmd.ExecuteNonQuery()
    '            MyCon.Close()
    '            Return True
    '        Catch ex As Exception
    '            smartobj.alertwindow(Me.Page, "Error uploading Image", "Prime")
    '            'Return False

    '        End Try

    '    End Function
    '    Sub uploadimage2()
    '        Try
    '            Dim intLength As Integer
    '            Dim intLength2 As Integer
    '            Dim imgType = file2.PostedFile.ContentType
    '            Dim imgType2 = file21.PostedFile.ContentType
    '            Dim arrContent As Byte()
    '            Dim arrContent2 As Byte()
    '            Dim empttyContent As Byte()
    '            Dim ext As String = "" : Dim ext2 As String = ""
    '            intLength = Convert.ToInt32(file2.PostedFile.InputStream.Length)
    '            intLength2 = Convert.ToInt32(file21.PostedFile.InputStream.Length)
    '            If file2.PostedFile Is Nothing Then
    '                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
    '            Else
    '                If (intLength > 35001) Then
    '                    smartobj.alertwindow(Me.Page, "Photo too Large for Upload", "Prime")
    '                    Exit Sub
    '                Else
    '                    Dim fileName As String = file2.PostedFile.FileName
    '                    If fileName = "" Then
    '                    Else
    '                        ext = fileName.Substring(fileName.LastIndexOf("."))
    '                        ext = ext.ToLower

    '                    End If

    '                End If
    '            End If

    '            If file21.PostedFile Is Nothing Then
    '                smartobj.alertwindow(Me.Page, "Please Upload Account Signature", "Prime")
    '                Exit Sub
    '            Else
    '                If (intLength2 > 35001) Then
    '                    smartobj.alertwindow(Me.Page, "Signature too large to Upload", "Prime")
    '                    Exit Sub
    '                Else
    '                    Dim fileName2 As String = file21.PostedFile.FileName
    '                    If fileName2 = "" Then
    '                    Else
    '                        ext2 = fileName2.Substring(fileName2.LastIndexOf("."))
    '                        ext2 = ext2.ToLower

    '                    End If
    '                End If
    '            End If
    '            ReDim arrContent(intLength)
    '            ReDim arrContent2(intLength2)
    '            ReDim empttyContent(2)
    '            If intLength = 0 Then
    '                file2.PostedFile.InputStream.Read(empttyContent, 0, 2)
    '                imgType = ext
    '            Else
    '                file2.PostedFile.InputStream.Read(arrContent, 0, intLength)
    '            End If
    '            If intLength2 = 0 Then
    '                file21.PostedFile.InputStream.Read(empttyContent, 0, 2)
    '                imgType2 = ext2
    '            Else
    '                file21.PostedFile.InputStream.Read(arrContent2, 0, intLength)
    '            End If

    '            If Doc2SQLServer2(Me.txtAcNumber.Text.Trim, arrContent, arrContent2, imgType, imgType2) = True Then
    '                'smartobj.alertwindow(Me.Page, "Image uploaded successfully.", "Prime")
    '            Else
    '                'smartobj.alertwindow(Me.Page, "Please upload Signature in Jpeg Format Only", "Prime")
    '            End If


    '        Catch ex As Exception
    '            smartobj.alertwindow(Me.Page, "Please upload Signature in Jpeg Format Only", "Prime")
    '        End Try

    '    End Sub
    '    Protected Function Doc2SQLServer2(ByVal accountnumber As String, ByVal Content As Byte(), ByVal Content2 As Byte(), ByVal strType As String, ByVal strType2 As String) As Boolean
    '        Try
    '            Dim cmd As Data.SqlClient.SqlCommand
    '            Dim param As Data.SqlClient.SqlParameter
    '            Dim strSQL As String
    '            strSQL = "Insert into tbl_mandatepicts (customerImage,signatureImage,Image_Type,Image_Type2,accountnumber) Values (@content,@content2,@type,@type,@Accountno)"

    '            cmd = New Data.SqlClient.SqlCommand(strSQL, MyCon)
    '            param = New Data.SqlClient.SqlParameter("@content", Data.SqlDbType.Image)
    '            param.Value = Content
    '            cmd.Parameters.Add(param)
    '            param = New Data.SqlClient.SqlParameter("@content2", Data.SqlDbType.Image)
    '            param.Value = Content2
    '            cmd.Parameters.Add(param)
    '            param = New Data.SqlClient.SqlParameter("@Accountno", Data.SqlDbType.VarChar)
    '            param.Value = accountnumber
    '            cmd.Parameters.Add(param)
    '            param = New Data.SqlClient.SqlParameter("@type", Data.SqlDbType.VarChar)
    '            param.Value = strType
    '            cmd.Parameters.Add(param)
    '            param = New Data.SqlClient.SqlParameter("@type2", Data.SqlDbType.VarChar)
    '            param.Value = strType2
    '            cmd.Parameters.Add(param)
    '            MyCon.Open()
    '            cmd.ExecuteNonQuery()
    '            MyCon.Close()
    '            Return True
    '        Catch ex As Exception
    '            smartobj.alertwindow(Me.Page, "Error uploading Image", "Prime")
    '            'Return False

    '        End Try

    '    End Function
    '    Sub uploadimage3()
    '        Try
    '            Dim intLength As Integer
    '            Dim intLength2 As Integer
    '            Dim imgType = file3.PostedFile.ContentType
    '            Dim imgType2 = file31.PostedFile.ContentType
    '            Dim arrContent As Byte()
    '            Dim arrContent2 As Byte()
    '            Dim empttyContent As Byte()
    '            Dim ext As String = "" : Dim ext2 As String = ""
    '            intLength = Convert.ToInt32(file3.PostedFile.InputStream.Length)
    '            intLength2 = Convert.ToInt32(file31.PostedFile.InputStream.Length)
    '            If file3.PostedFile Is Nothing Then
    '                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
    '            Else
    '                If (intLength > 35001) Then
    '                    smartobj.alertwindow(Me.Page, "Photo too Large for Upload", "Prime")
    '                    Exit Sub
    '                Else
    '                    Dim fileName As String = file3.PostedFile.FileName
    '                    If fileName = "" Then
    '                    Else
    '                        ext = fileName.Substring(fileName.LastIndexOf("."))
    '                        ext = ext.ToLower

    '                    End If

    '                End If
    '            End If

    '            If file31.PostedFile Is Nothing Then
    '                smartobj.alertwindow(Me.Page, "Please Upload Account Signature", "Prime")
    '                Exit Sub
    '            Else
    '                If (intLength2 > 35001) Then
    '                    smartobj.alertwindow(Me.Page, "Signature too large to Upload", "Prime")
    '                    Exit Sub
    '                Else
    '                    Dim fileName2 As String = file31.PostedFile.FileName
    '                    If fileName2 = "" Then
    '                    Else
    '                        ext2 = fileName2.Substring(fileName2.LastIndexOf("."))
    '                        ext2 = ext2.ToLower

    '                    End If
    '                End If
    '            End If
    '            ReDim arrContent(intLength)
    '            ReDim arrContent2(intLength2)
    '            ReDim empttyContent(2)
    '            If intLength = 0 Then
    '                file3.PostedFile.InputStream.Read(empttyContent, 0, 2)
    '                imgType = ext
    '            Else
    '                file3.PostedFile.InputStream.Read(arrContent, 0, intLength)
    '            End If
    '            If intLength2 = 0 Then
    '                file31.PostedFile.InputStream.Read(empttyContent, 0, 2)
    '                imgType2 = ext2
    '            Else
    '                file31.PostedFile.InputStream.Read(arrContent2, 0, intLength)
    '            End If

    '            If Doc2SQLServer3(Me.txtAcNumber.Text.Trim, arrContent, arrContent2, imgType, imgType2) = True Then
    '                'smartobj.alertwindow(Me.Page, "Image uploaded successfully.", "Prime")
    '            Else
    '                'smartobj.alertwindow(Me.Page, "Please upload Signature in Jpeg Format Only", "Prime")
    '            End If


    '        Catch ex As Exception
    '            smartobj.alertwindow(Me.Page, "Please upload Signature in Jpeg Format Only", "Prime")
    '        End Try

    '    End Sub
    '    Protected Function Doc2SQLServer3(ByVal accountnumber As String, ByVal Content As Byte(), ByVal Content2 As Byte(), ByVal strType As String, ByVal strType2 As String) As Boolean
    '        Try
    '            Dim cmd As Data.SqlClient.SqlCommand
    '            Dim param As Data.SqlClient.SqlParameter
    '            Dim strSQL As String
    '            strSQL = "Insert into tbl_mandatepicts (customerImage,signatureImage,Image_Type,Image_Type2,accountnumber) Values (@content,@content2,@type,@type,@Accountno)"

    '            cmd = New Data.SqlClient.SqlCommand(strSQL, MyCon)
    '            param = New Data.SqlClient.SqlParameter("@content", Data.SqlDbType.Image)
    '            param.Value = Content
    '            cmd.Parameters.Add(param)
    '            param = New Data.SqlClient.SqlParameter("@content2", Data.SqlDbType.Image)
    '            param.Value = Content2
    '            cmd.Parameters.Add(param)
    '            param = New Data.SqlClient.SqlParameter("@Accountno", Data.SqlDbType.VarChar)
    '            param.Value = accountnumber
    '            cmd.Parameters.Add(param)
    '            param = New Data.SqlClient.SqlParameter("@type", Data.SqlDbType.VarChar)
    '            param.Value = strType
    '            cmd.Parameters.Add(param)
    '            param = New Data.SqlClient.SqlParameter("@type2", Data.SqlDbType.VarChar)
    '            param.Value = strType2
    '            cmd.Parameters.Add(param)
    '            MyCon.Open()
    '            cmd.ExecuteNonQuery()
    '            MyCon.Close()
    '            Return True
    '        Catch ex As Exception
    '            smartobj.alertwindow(Me.Page, "Error uploading Image", "Prime")
    '            'Return False

    '        End Try

    '    End Function
    '    Sub uploadimage4()
    '        Try
    '            Dim intLength As Integer
    '            Dim intLength2 As Integer
    '            Dim imgType = file4.PostedFile.ContentType
    '            Dim imgType2 = file41.PostedFile.ContentType
    '            Dim arrContent As Byte()
    '            Dim arrContent2 As Byte()
    '            Dim empttyContent As Byte()
    '            Dim ext As String = "" : Dim ext2 As String = ""
    '            intLength = Convert.ToInt32(file4.PostedFile.InputStream.Length)
    '            intLength2 = Convert.ToInt32(file41.PostedFile.InputStream.Length)
    '            If file4.PostedFile Is Nothing Then
    '                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
    '            Else
    '                If (intLength > 35001) Then
    '                    smartobj.alertwindow(Me.Page, "Photo too Large for Upload", "Prime")
    '                    Exit Sub
    '                Else
    '                    Dim fileName As String = file4.PostedFile.FileName
    '                    If fileName = "" Then
    '                    Else
    '                        ext = fileName.Substring(fileName.LastIndexOf("."))
    '                        ext = ext.ToLower

    '                    End If

    '                End If
    '            End If

    '            If file41.PostedFile Is Nothing Then
    '                smartobj.alertwindow(Me.Page, "Please Upload Account Signature", "Prime")
    '                Exit Sub
    '            Else
    '                If (intLength2 > 35001) Then
    '                    smartobj.alertwindow(Me.Page, "Signature too large to Upload", "Prime")
    '                    Exit Sub
    '                Else
    '                    Dim fileName2 As String = file41.PostedFile.FileName
    '                    If fileName2 = "" Then
    '                    Else
    '                        ext2 = fileName2.Substring(fileName2.LastIndexOf("."))
    '                        ext2 = ext2.ToLower

    '                    End If
    '                End If
    '            End If
    '            ReDim arrContent(intLength)
    '            ReDim arrContent2(intLength2)
    '            ReDim empttyContent(2)
    '            If intLength = 0 Then
    '                file4.PostedFile.InputStream.Read(empttyContent, 0, 2)
    '                imgType = ext
    '            Else
    '                file4.PostedFile.InputStream.Read(arrContent, 0, intLength)
    '            End If
    '            If intLength2 = 0 Then
    '                file41.PostedFile.InputStream.Read(empttyContent, 0, 2)
    '                imgType2 = ext2
    '            Else
    '                file41.PostedFile.InputStream.Read(arrContent2, 0, intLength)
    '            End If

    '            If Doc2SQLServer4(Me.txtAcNumber.Text.Trim, arrContent, arrContent2, imgType, imgType2) = True Then
    '                'smartobj.alertwindow(Me.Page, "Image uploaded successfully.", "Prime")
    '            Else
    '                'smartobj.alertwindow(Me.Page, "Please upload Signature in Jpeg Format Only", "Prime")
    '            End If


    '        Catch ex As Exception
    '            smartobj.alertwindow(Me.Page, "Please upload Signature in Jpeg Format Only", "Prime")
    '        End Try

    '    End Sub
    '    Protected Function Doc2SQLServer4(ByVal accountnumber As String, ByVal Content As Byte(), ByVal Content2 As Byte(), ByVal strType As String, ByVal strType2 As String) As Boolean
    '        Try
    '            Dim cmd As Data.SqlClient.SqlCommand
    '            Dim param As Data.SqlClient.SqlParameter
    '            Dim strSQL As String
    '            strSQL = "Insert into tbl_mandatepicts (customerImage,signatureImage,Image_Type,Image_Type2,accountnumber) Values (@content,@content2,@type,@type,@Accountno)"

    '            cmd = New Data.SqlClient.SqlCommand(strSQL, MyCon)
    '            param = New Data.SqlClient.SqlParameter("@content", Data.SqlDbType.Image)
    '            param.Value = Content
    '            cmd.Parameters.Add(param)
    '            param = New Data.SqlClient.SqlParameter("@content2", Data.SqlDbType.Image)
    '            param.Value = Content2
    '            cmd.Parameters.Add(param)
    '            param = New Data.SqlClient.SqlParameter("@Accountno", Data.SqlDbType.VarChar)
    '            param.Value = accountnumber
    '            cmd.Parameters.Add(param)
    '            param = New Data.SqlClient.SqlParameter("@type", Data.SqlDbType.VarChar)
    '            param.Value = strType
    '            cmd.Parameters.Add(param)
    '            param = New Data.SqlClient.SqlParameter("@type2", Data.SqlDbType.VarChar)
    '            param.Value = strType2
    '            cmd.Parameters.Add(param)
    '            MyCon.Open()
    '            cmd.ExecuteNonQuery()
    '            MyCon.Close()
    '            Return True
    '        Catch ex As Exception
    '            smartobj.alertwindow(Me.Page, "Error uploading Image", "Prime")
    '            'Return False

    '        End Try


    '    End Function
    '    Sub uploadimage5()
    '        Try
    '            Dim intLength As Integer
    '            Dim intLength2 As Integer
    '            Dim imgType = file5.PostedFile.ContentType
    '            Dim imgType2 = file51.PostedFile.ContentType
    '            Dim arrContent As Byte()
    '            Dim arrContent2 As Byte()
    '            Dim empttyContent As Byte()
    '            Dim ext As String = "" : Dim ext2 As String = ""
    '            intLength = Convert.ToInt32(file5.PostedFile.InputStream.Length)
    '            intLength2 = Convert.ToInt32(file51.PostedFile.InputStream.Length)
    '            If file5.PostedFile Is Nothing Then
    '                smartobj.alertwindow(Me.Page, "Please Upload Account Image/Photo", "Prime")
    '            Else
    '                If (intLength > 35001) Then
    '                    smartobj.alertwindow(Me.Page, "Photo too Large for Upload", "Prime")
    '                    Exit Sub
    '                Else
    '                    Dim fileName As String = file5.PostedFile.FileName
    '                    If fileName = "" Then
    '                    Else
    '                        ext = fileName.Substring(fileName.LastIndexOf("."))
    '                        ext = ext.ToLower

    '                    End If

    '                End If
    '            End If

    '            If file51.PostedFile Is Nothing Then
    '                smartobj.alertwindow(Me.Page, "Please Upload Account Signature", "Prime")
    '                Exit Sub
    '            Else
    '                If (intLength2 > 35001) Then
    '                    smartobj.alertwindow(Me.Page, "Signature too large to Upload", "Prime")
    '                    Exit Sub
    '                Else
    '                    Dim fileName2 As String = file51.PostedFile.FileName
    '                    If fileName2 = "" Then
    '                    Else
    '                        ext2 = fileName2.Substring(fileName2.LastIndexOf("."))
    '                        ext2 = ext2.ToLower

    '                    End If
    '                End If
    '            End If
    '            ReDim arrContent(intLength)
    '            ReDim arrContent2(intLength2)
    '            ReDim empttyContent(2)
    '            If intLength = 0 Then
    '                file5.PostedFile.InputStream.Read(empttyContent, 0, 2)
    '                imgType = ext
    '            Else
    '                file5.PostedFile.InputStream.Read(arrContent, 0, intLength)
    '            End If
    '            If intLength2 = 0 Then
    '                file51.PostedFile.InputStream.Read(empttyContent, 0, 2)
    '                imgType2 = ext2
    '            Else
    '                file51.PostedFile.InputStream.Read(arrContent2, 0, intLength)
    '            End If

    '            If Doc2SQLServer5(Me.txtAcNumber.Text.Trim, arrContent, arrContent2, imgType, imgType2) = True Then
    '                'smartobj.alertwindow(Me.Page, "Image uploaded successfully.", "Prime")
    '            Else
    '                'smartobj.alertwindow(Me.Page, "Please upload Signature in Jpeg Format Only", "Prime")
    '            End If


    '        Catch ex As Exception
    '            smartobj.alertwindow(Me.Page, "Please upload Signature in Jpeg Format Only", "Prime")
    '        End Try

    '    End Sub
    '    Protected Function Doc2SQLServer5(ByVal accountnumber As String, ByVal Content As Byte(), ByVal Content2 As Byte(), ByVal strType As String, ByVal strType2 As String) As Boolean
    '        Try
    '            Dim cmd As Data.SqlClient.SqlCommand
    '            Dim param As Data.SqlClient.SqlParameter
    '            Dim strSQL As String
    '            strSQL = "Insert into tbl_mandatepicts (customerImage,signatureImage,Image_Type,Image_Type2,accountnumber) Values (@content,@content2,@type,@type,@Accountno)"

    '            cmd = New Data.SqlClient.SqlCommand(strSQL, MyCon)
    '            param = New Data.SqlClient.SqlParameter("@content", Data.SqlDbType.Image)
    '            param.Value = Content
    '            cmd.Parameters.Add(param)
    '            param = New Data.SqlClient.SqlParameter("@content2", Data.SqlDbType.Image)
    '            param.Value = Content2
    '            cmd.Parameters.Add(param)
    '            param = New Data.SqlClient.SqlParameter("@Accountno", Data.SqlDbType.VarChar)
    '            param.Value = accountnumber
    '            cmd.Parameters.Add(param)
    '            param = New Data.SqlClient.SqlParameter("@type", Data.SqlDbType.VarChar)
    '            param.Value = strType
    '            cmd.Parameters.Add(param)
    '            param = New Data.SqlClient.SqlParameter("@type2", Data.SqlDbType.VarChar)
    '            param.Value = strType2
    '            cmd.Parameters.Add(param)
    '            MyCon.Open()
    '            cmd.ExecuteNonQuery()
    '            MyCon.Close()
    '            Return True
    '        Catch ex As Exception
    '            smartobj.alertwindow(Me.Page, "Error uploading Image", "Prime")
    '            'Return False

    '        End Try

    '    End Function
    '#End Region
#Region "submit"
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsubmit.Click
        Try
            If Me.txtcustomerid.Text = "" Then
                Exit Sub
            Else

                If chkStatus.Checked = True Then
                    Dim str As String = "Delete from tbl_mandatepicts where accountnumber='" & Me.txtAcNumber.Text.Trim & "' and node_id = " & Session("node_ID") & ""
                    con.SqlDs(str)
                    Me.Label33.Text = "Mandate Successfully Removed From Account"
                    Exit Sub
                End If

                ''If Me.btnSubmit.Text = "Submit" Then
                Dim i As Integer = Me.txtnosign.Text.Trim
                Select Case i
                    Case 1
                        insone(1)
                    Case 2
                        insone(1)
                        instwo(2)
                    Case 3
                        insone(1)
                        instwo(2)
                        insthree(3)
                    Case 4
                        insone(1)
                        instwo(2)
                        insthree(3)
                        insfour(4)
                    Case 5
                        insone(1)
                        instwo(2)
                        insthree(3)
                        insfour(4)
                        insfive(5)

                    Case 6
                        insone(1)
                        instwo(2)
                        insthree(3)
                        insfour(4)
                        insfive(5)
                        insSix(6)
                    Case 7
                        insone(1)
                        instwo(2)
                        insthree(3)
                        insfour(4)
                        insfive(5)
                        insSix(6)
                        insSeven(7)
                    Case 8
                        insone(1)
                        instwo(2)
                        insthree(3)
                        insfour(4)
                        insfive(5)
                        insSix(6)
                        insSeven(7)
                        insEight(8)
                    Case 9
                        insone(1)
                        instwo(2)
                        insthree(3)
                        insfour(4)
                        insfive(5)
                        insSix(6)
                        insSeven(7)
                        insEight(8)
                        insNine(9)
                    Case 10
                        insone(1)
                        instwo(2)
                        insthree(3)
                        insfour(4)
                        insfive(5)
                        insSix(6)
                        insSeven(7)
                        insEight(8)
                        insNine(9)
                        insTen(10)
                End Select

                Me.Label33.Text = cnt & " Out Of " & i & " Mandate Records Uploaded................."

                If cnt > 0 Then
                    Me.LinkButton1.Visible = True
                    smartobj.ClearWebPage(Me.Page) : clear()
                Else
                    Me.LinkButton1.Visible = False
                    ' smartobj.ClearWebPage(Me.Page) : clear()

                End If
                cnt = 0
                ''insertrec()
                ''Else
                ''updaterec()
                '' End If
                smartobj.alertwindow(Me.Page, Session("retmsg"), "Prime")
                ''smartobj.ClearWebPage(Me.Page)



            End If


        Catch ex As Exception

            Me.Label1.Text = ex.Message
        End Try
    End Sub
#End Region
    Sub clear()
        '' Me.txtAcNumber.Text = ""
        Me.txtcustomerid.Text = ""
        Me.txtdesig1.Text = ""
        Me.txtdesig2.Text = ""
        Me.txtdesig3.Text = ""
        Me.txtdesig4.Text = ""
        Me.txtdesig5.Text = ""
        '' Session("retmsg") = ""
        Me.Label1.Text = ""
        Me.Label2.Text = ""
        Me.Label3.Text = ""
        Me.Label4.Text = ""
        Me.Label5.Text = ""
        Me.Label6.Text = ""
        Me.Label7.Text = ""
        Me.Label8.Text = ""
        Me.Label9.Text = ""
        Me.Label10.Text = ""
    End Sub
    'Sub insertrec()
    '    Dim i As Integer = Me.txtnosign.Text.Trim
    '    Select Case i
    '        Case 1
    '            Dim insrec As String = "Insert into tbl_mandatelist(accountnumber,signatoryname,designation," & _
    '            "mandatedesc1,mandatedesc2) Values ('" & Me.txtAcNumber.Text.Trim.Replace("'", " ") & "','" & Me.txtname1.Text.Trim & "'," & _
    '            "'" & Me.txtdesig1.Text.Trim & "','" & Me.txtmandate1.Text.Trim & "','" & Me.txtmandate2.Text.Trim & "')"

    '            con.SqlDs(insrec)
    '            uploadimage1()
    '        Case 2
    '            Dim insrec As String = "Insert into tbl_mandatelist(accountnumber,signatoryname,designation," & _
    '            "mandatedesc1,mandatedesc2) Values ('" & Me.txtAcNumber.Text.Trim.Replace("'", " ") & "','" & Me.txtname1.Text.Trim & "'," & _
    '            "'" & Me.txtdesig1.Text.Trim & "','" & Me.txtmandate1.Text.Trim & "','" & Me.txtmandate2.Text.Trim & "')"

    '            con.SqlDs(insrec)

    '            Dim insrec2 As String = "Insert into tbl_mandatelist(accountnumber,signatoryname,designation,serial) Values " & _
    '           "('" & Me.txtAcNumber.Text.Trim.Replace("'", " ") & "','" & Me.txtname2.Text.Trim & "','" & Me.txtdesig2.Text.Trim & "'," & i & ")"

    '            con.SqlDs(insrec2)
    '            'uploadimage1()
    '            'uploadimage2()

    '        Case 3
    '            Dim insrec As String = "Insert into tbl_mandatelist(accountnumber,signatoryname,designation," & _
    '           "mandatedesc1,mandatedesc2,serial) Values ('" & Me.txtAcNumber.Text.Trim.Replace("'", " ") & "','" & Me.txtname1.Text.Trim & "'," & _
    '           "'" & Me.txtdesig1.Text.Trim & "','" & Me.txtmandate1.Text.Trim & "','" & Me.txtmandate2.Text.Trim & "'," & i - 2 & ")"

    '            con.SqlDs(insrec)

    '            Dim insrec2 As String = "Insert into tbl_mandatelist(accountnumber,signatoryname,designation,serial) Values " & _
    '           "('" & Me.txtAcNumber.Text.Trim.Replace("'", " ") & "','" & Me.txtname2.Text.Trim & "','" & Me.txtdesig2.Text.Trim & "'," & i - 1 & ")"

    '            con.SqlDs(insrec2)

    '            Dim insrec3 As String = "Insert into tbl_mandatelist(accountnumber,signatoryname,designation,serial) Values " & _
    '          "('" & Me.txtAcNumber.Text.Trim.Replace("'", " ") & "','" & Me.txtname3.Text.Trim & "','" & Me.txtdesig3.Text.Trim & "'," & i & ")"

    '            con.SqlDs(insrec3)

    '            uploadimage1()
    '            uploadimage2()
    '            uploadimage3()
    '        Case 4
    '            Dim insrec As String = "Insert into tbl_mandatelist(accountnumber,signatoryname,designation," & _
    '           "mandatedesc1,mandatedesc2,serial) Values ('" & Me.txtAcNumber.Text.Trim.Replace("'", " ") & "','" & Me.txtname1.Text.Trim.Replace("'", " ") & "'," & _
    '           "'" & Me.txtdesig1.Text.Trim.Replace("'", " ") & "','" & Me.txtmandate1.Text.Trim.Replace("'", " ") & "','" & Me.txtmandate2.Text.Trim.Replace("'", " ") & "'," & i - 3 & ")"

    '            con.SqlDs(insrec)

    '            Dim insrec2 As String = "Insert into tbl_mandatelist(accountnumber,signatoryname,designation,serial) Values " & _
    '          "('" & Me.txtAcNumber.Text.Trim.Replace("'", " ") & "','" & Me.txtname2.Text.Trim & "','" & Me.txtdesig2.Text.Trim & "'," & i - 2 & ")"

    '            con.SqlDs(insrec2)

    '            Dim insrec3 As String = "Insert into tbl_mandatelist(accountnumber,signatoryname,designation,serial) Values " & _
    '           "('" & Me.txtAcNumber.Text.Trim.Replace("'", " ") & "','" & Me.txtname3.Text.Trim & "','" & Me.txtdesig3.Text.Trim & "'," & i - 1 & ")"

    '            con.SqlDs(insrec3)

    '            Dim insrec4 As String = "Insert into tbl_mandatelist(accountnumber,signatoryname,designation,serial) Values " & _
    '           "('" & Me.txtAcNumber.Text.Trim.Replace("'", " ") & "','" & Me.txtname4.Text.Trim & "','" & Me.txtdesig4.Text.Trim & "'," & i & ")"

    '            con.SqlDs(insrec4)

    '            uploadimage1()
    '            uploadimage2()
    '            uploadimage3()
    '            uploadimage4()

    '        Case 5
    '            Dim insrec As String = "Insert into tbl_mandatelist(accountnumber,signatoryname,designation," & _
    '           "mandatedesc1,mandatedesc2,serial) Values ('" & Me.txtAcNumber.Text.Trim.Replace("'", " ") & "','" & Me.txtname1.Text.Trim.Replace("'", " ") & "'," & _
    '           "'" & Me.txtdesig1.Text.Trim.Replace("'", " ") & "','" & Me.txtmandate1.Text.Trim.Replace("'", " ") & "','" & Me.txtmandate2.Text.Trim.Replace("'", " ") & "'," & i - 4 & ")"

    '            con.SqlDs(insrec)

    '            Dim insrec2 As String = "Insert into tbl_mandatelist(accountnumber,signatoryname,designation,serial) Values " & _
    '         "('" & Me.txtAcNumber.Text.Trim.Replace("'", " ") & "','" & Me.txtname2.Text.Trim & "','" & Me.txtdesig2.Text.Trim & "'," & i - 3 & ")"

    '            con.SqlDs(insrec2)

    '            Dim insrec3 As String = "Insert into tbl_mandatelist(accountnumber,signatoryname,designation,serial) Values " & _
    '            "('" & Me.txtAcNumber.Text.Trim.Replace("'", " ") & "','" & Me.txtname3.Text.Trim & "','" & Me.txtdesig3.Text.Trim & "'," & i - 2 & ")"

    '            con.SqlDs(insrec3)

    '            Dim insrec4 As String = "Insert into tbl_mandatelist(accountnumber,signatoryname,designation,serial) Values " & _
    '            "('" & Me.txtAcNumber.Text.Trim.Replace("'", " ") & "','" & Me.txtname4.Text.Trim & "','" & Me.txtdesig4.Text.Trim & "'," & i - 1 & ")"

    '            con.SqlDs(insrec4)

    '            Dim insrec5 As String = "Insert into tbl_mandatelist(accountnumber,signatoryname,designation,serial) Values " & _
    '         "('" & Me.txtAcNumber.Text.Trim.Replace("'", " ") & "','" & Me.txtname5.Text.Trim & "','" & Me.txtdesig5.Text.Trim & "'," & i & ")"

    '            con.SqlDs(insrec5)

    '            uploadimage1()
    '            uploadimage2()
    '            uploadimage3()
    '            uploadimage4()
    '            uploadimage5()
    '    End Select

    '    smartobj.alertwindow(Me.Page, "Mandate Infomation Updated Successfully...", "Prime")
    '    smartobj.ClearWebPage(Me.Page):Clear
    '    Me.btnSubmit.Enabled = False
    '    Exit Sub
    'End Sub

    'Sub updaterec()
    '    Dim i As Integer = Me.txtnosign.Text.Trim
    '    Select Case i
    '        Case 1
    '            Dim insrec As String = "Update tbl_mandatelist set  signatoryname='" & Me.txtname1.Text.Trim & "',designation='" & Me.txtdesig1.Text.Trim & "'," & _
    '            "mandatedesc1='" & Me.txtmandate1.Text.Trim & "',mandatedesc2='" & Me.txtmandate2.Text.Trim & "' where accountnumber='" & Me.txtAcNumber.Text.Trim & "' and serial='" & i & "'"

    '            con.SqlDs(insrec)
    '            If Not File1.PostedFile Is Nothing Then
    '                uploadimage1()
    '            End If

    '        Case 2
    '            Dim insrec As String = "Update tbl_mandatelist set  signatoryname='" & Me.txtname1.Text.Trim & "',designation='" & Me.txtdesig1.Text.Trim & "'," & _
    '            "mandatedesc1='" & Me.txtmandate1.Text.Trim & "',mandatedesc2='" & Me.txtmandate2.Text.Trim & "' where accountnumber='" & Me.txtAcNumber.Text.Trim & "' and serial='" & i - 1 & "'"
    '            con.SqlDs(insrec)


    '            Dim insrec2 As String = "Update tbl_mandatelist set  signatoryname='" & Me.txtname2.Text.Trim & "',designation='" & Me.txtdesig2.Text.Trim & "'," & _
    '            "where accountnumber='" & Me.txtAcNumber.Text.Trim & "' and serial='" & i & "'"
    '            con.SqlDs(insrec2)

    '            If Not File1.PostedFile Is Nothing Then
    '                uploadimage1()
    '            End If
    '            If Not file2.PostedFile Is Nothing Then
    '                uploadimage2()
    '            End If



    '            'uploadimage1()
    '            'uploadimage2()

    '        Case 3
    '            Dim insrec As String = "Update tbl_mandatelist set  signatoryname='" & Me.txtname1.Text.Trim & "',designation='" & Me.txtdesig1.Text.Trim & "'," & _
    '            "mandatedesc1='" & Me.txtmandate1.Text.Trim & "',mandatedesc2='" & Me.txtmandate2.Text.Trim & "' where accountnumber='" & Me.txtAcNumber.Text.Trim & "' and serial='" & i - 2 & "'"
    '            con.SqlDs(insrec)


    '            Dim insrec2 As String = "Update tbl_mandatelist set  signatoryname='" & Me.txtname2.Text.Trim & "',designation='" & Me.txtdesig2.Text.Trim & "'," & _
    '            "where accountnumber='" & Me.txtAcNumber.Text.Trim & "' and serial='" & i - 1 & "'"
    '            con.SqlDs(insrec2)

    '            Dim insrec3 As String = "Update tbl_mandatelist set  signatoryname='" & Me.txtname3.Text.Trim & "',designation='" & Me.txtdesig3.Text.Trim & "'," & _
    '          "where accountnumber='" & Me.txtAcNumber.Text.Trim & "' and serial='" & i & "'"
    '            con.SqlDs(insrec3)

    '            If Not File1.PostedFile Is Nothing Then
    '                uploadimage1()
    '            End If
    '            If Not file2.PostedFile Is Nothing Then
    '                uploadimage2()
    '            End If

    '            If Not file3.PostedFile Is Nothing Then
    '                uploadimage3()
    '            End If

    '        Case 4
    '            Dim insrec As String = "Update tbl_mandatelist set  signatoryname='" & Me.txtname1.Text.Trim & "',designation='" & Me.txtdesig1.Text.Trim & "'," & _
    '            "mandatedesc1='" & Me.txtmandate1.Text.Trim & "',mandatedesc2='" & Me.txtmandate2.Text.Trim & "' where accountnumber='" & Me.txtAcNumber.Text.Trim & "' and serial='" & i - 3 & "'"
    '            con.SqlDs(insrec)


    '            Dim insrec2 As String = "Update tbl_mandatelist set  signatoryname='" & Me.txtname2.Text.Trim & "',designation='" & Me.txtdesig2.Text.Trim & "'," & _
    '            "where accountnumber='" & Me.txtAcNumber.Text.Trim & "' and serial='" & i - 2 & "'"
    '            con.SqlDs(insrec2)

    '            Dim insrec3 As String = "Update tbl_mandatelist set  signatoryname='" & Me.txtname3.Text.Trim & "',designation='" & Me.txtdesig3.Text.Trim & "'," & _
    '          "where accountnumber='" & Me.txtAcNumber.Text.Trim & "' and serial='" & i - 1 & "'"
    '            con.SqlDs(insrec3)

    '            Dim insrec4 As String = "Update tbl_mandatelist set  signatoryname='" & Me.txtname4.Text.Trim & "',designation='" & Me.txtdesig4.Text.Trim & "'," & _
    '         "where accountnumber='" & Me.txtAcNumber.Text.Trim & "' and serial='" & i & "'"
    '            con.SqlDs(insrec4)

    '            If Not File1.PostedFile Is Nothing Then
    '                uploadimage1()
    '            End If
    '            If Not file2.PostedFile Is Nothing Then
    '                uploadimage2()
    '            End If

    '            If Not file3.PostedFile Is Nothing Then
    '                uploadimage3()
    '            End If

    '            If Not file4.PostedFile Is Nothing Then
    '                uploadimage4()
    '            End If

    '        Case 5
    '            Dim insrec As String = "Update tbl_mandatelist set  signatoryname='" & Me.txtname1.Text.Trim & "',designation='" & Me.txtdesig1.Text.Trim & "'," & _
    '            "mandatedesc1='" & Me.txtmandate1.Text.Trim & "',mandatedesc2='" & Me.txtmandate2.Text.Trim & "' where accountnumber='" & Me.txtAcNumber.Text.Trim & "' and serial='" & i - 4 & "'"
    '            con.SqlDs(insrec)


    '            Dim insrec2 As String = "Update tbl_mandatelist set  signatoryname='" & Me.txtname2.Text.Trim & "',designation='" & Me.txtdesig2.Text.Trim & "'," & _
    '            "where accountnumber='" & Me.txtAcNumber.Text.Trim & "' and serial='" & i - 3 & "'"
    '            con.SqlDs(insrec2)

    '            Dim insrec3 As String = "Update tbl_mandatelist set  signatoryname='" & Me.txtname3.Text.Trim & "',designation='" & Me.txtdesig3.Text.Trim & "'," & _
    '          "where accountnumber='" & Me.txtAcNumber.Text.Trim & "' and serial='" & i - 2 & "'"
    '            con.SqlDs(insrec3)

    '            Dim insrec4 As String = "Update tbl_mandatelist set  signatoryname='" & Me.txtname4.Text.Trim & "',designation='" & Me.txtdesig4.Text.Trim & "'," & _
    '         "where accountnumber='" & Me.txtAcNumber.Text.Trim & "'and serial='" & i - 1 & "'"
    '            con.SqlDs(insrec4)

    '            Dim insrec5 As String = "Update tbl_mandatelist set  signatoryname='" & Me.txtname5.Text.Trim & "',designation='" & Me.txtdesig5.Text.Trim & "'," & _
    '      "where accountnumber='" & Me.txtAcNumber.Text.Trim & "' and serial='" & i & "'"
    '            con.SqlDs(insrec5)

    '            If Not File1.PostedFile Is Nothing Then
    '                uploadimage1()
    '            End If
    '            If Not file2.PostedFile Is Nothing Then
    '                uploadimage2()
    '            End If

    '            If Not file3.PostedFile Is Nothing Then
    '                uploadimage3()
    '            End If

    '            If Not file4.PostedFile Is Nothing Then
    '                uploadimage4()
    '            End If

    '    End Select

    '    smartobj.alertwindow(Me.Page, "Mandate Infomation Recorded...", "Prime")
    '    smartobj.ClearWebPage(Me.Page):Clear
    '    Me.btnSubmit.Enabled = False
    '    Exit Sub
    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("Label3"), System.Web.UI.WebControls.Label)
        l.Text = ""
        Dim ll As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("Label4"), System.Web.UI.WebControls.Label)
        ll.Text = "MANAGE MANDATE" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        Dim menuname As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("lbldisplay"), System.Web.UI.WebControls.Label)

        menuname.Text = Request.QueryString("XXX")
        If menuname.Text = "" Then
            Response.Redirect("~/Unauthorize.aspx")
        End If

        If Validate_Access(menuname.Text) = 0 Then
            Response.Redirect("~/Unauthorize.aspx")
        End If
        If Page.IsPostBack = False Then
            hypAccount.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtAcNumber.ClientID.ToString() + "');"

            Session("retmsg") = ""
            Me.txtAcNumber.Text = ""

            hypAccount.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtAcNumber.ClientID.ToString() + "');"

        End If
    End Sub

    'Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
    '    Response.Redirect("Default.aspx")
    'End Sub
    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        smartobj.ClearWebPage(Me.Page) : clear()
        Me.Btnsubmit.Enabled = True
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Try
            Response.Redirect("Mandatedetail.aspx?id=" & Me.txtAcNumber.Text.Trim)
            Session("retmsg") = ""
            Me.txtAcNumber.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    'Protected Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
    '    If Session("node_ID") = Nothing Then
    '        Response.Redirect("../PageExpire.aspx")
    '    Else
    '        Me.MasterPageFile = "~/Tenant" + Session("node_ID").ToString + "/Tenant.master"

    '    End If
    'End Sub
End Class
