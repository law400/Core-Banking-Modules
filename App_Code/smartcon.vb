Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography
Imports System.Drawing
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Threading
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.Literal
Imports System
Imports Microsoft.VisualBasic
Imports System.Web.UI
Public Class smartcon
    'Public Shared const2 As String = String.Format(ConfigurationManager.AppSettings("Prime"), "Snow", "managermc!12", "Prime")
    Public Shared const2 As String = ConfigurationManager.ConnectionStrings("Prime").ConnectionString

    Private Shared theCons As New System.Data.SqlClient.SqlConnection
    Private Shared selbdet As String = "Select CBNCODE,bankname from tbl_bank"
    Private Shared footer As String = "Select * from tbl_footer"
    Public Structure stAttachment
        Public Attachment As String
        Public Savelocation As String
        Public Path As String
        Public Filename As String
        Public PhysicalFilePath As String
        Public ID As Integer
    End Structure
    Public Enum detSubmit
        AddRecord = 1
        UpdateRecord = 2
        DeleteRecord = 3
        AuthorizeRecord = 4
    End Enum
    Public Enum detAuthorise
        AuthorizeRecord = 1
        PendingAuth = 2
        RejectedAuth = 3
    End Enum
    Public Structure detmessage
        Dim retVal As Boolean
        Dim retMsg As String
        Dim retAcct As String
        Dim drow1 As DataRow
    End Structure
    Public Function EncryptText(ByVal strText As String) As String
        Return Encrypt(strText, ":&;,#@?*")

    End Function
    Public Function amountformatter(ByVal amount As String) As String
        Try
            Dim val As String
            Dim txtconvert As String = amount
            Dim lngthvalue As Integer = amount.Length - 1
            Dim actualVal As Decimal
            txtconvert = Right(amount, 1)

            If txtconvert = "m" Or txtconvert = "M" Then
                actualVal = Left(amount, lngthvalue)
                amount = Format(CDec(actualVal * 1000000), "#,##0.00")
            ElseIf txtconvert = "t" Or txtconvert = "T" Then
                actualVal = Left(amount, lngthvalue)
                amount = Format(CDec(actualVal * 1000), "#,##0.00")
            ElseIf txtconvert = "h" Or txtconvert = "H" Then
                actualVal = Left(amount, lngthvalue)
                amount = Format(CDec(actualVal * 100), "#,##0.00")
            Else
                amount = Format(CDec(amount), "#,##0.00")
            End If

            val = amount
            Return val
        Catch ex As Exception
        End Try
        Return True
    End Function
    Public Function FormatMony(ByVal Dmoney As String) As String
        Dim Nmoney As Double = CDbl(Dmoney)
        Return Format(CDec(Nmoney), "#,##0.00")

    End Function
    Public Function DecryptText(ByVal strText As String) As String
        Return Decrypt(strText, ":&;,#@?*")
    End Function
    Private key() As Byte = {}
    Private IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
    Public Function Decrypt(ByVal stringToDecrypt As String, _
        ByVal sEncryptionKey As String) As String
        Dim inputByteArray(stringToDecrypt.Length) As Byte
        Try
            key = System.Text.Encoding.UTF8.GetBytes(Left(sEncryptionKey, 8))
            Dim des As New DESCryptoServiceProvider
            inputByteArray = Convert.FromBase64String(stringToDecrypt)
            Dim ms As New MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(key, IV), _
                CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
            Return encoding.GetString(ms.ToArray())
        Catch e As Exception
            Return e.Message
        End Try
    End Function
    Public Function Encrypt(ByVal stringToEncrypt As String, _
        ByVal SEncryptionKey As String) As String
        Try
            key = System.Text.Encoding.UTF8.GetBytes(Left(SEncryptionKey, 8))
            Dim des As New DESCryptoServiceProvider
            Dim inputByteArray() As Byte = Encoding.UTF8.GetBytes( _
                stringToEncrypt)
            Dim ms As New MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(key, IV), _
                CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())
        Catch e As Exception
            Return e.Message
        End Try
    End Function
    Public Function SqlDs(ByVal SqlString As String) As DataSet

        Using theCons As New SqlConnection(const2)
            theCons.Open()
            ''Dim tran As SqlTransaction = theCons.BeginTransaction
            Try
                ''Dim cmd As New System.Data.SqlClient.SqlCommand(SqlString, theCons, tran)
                Dim cmd As New System.Data.SqlClient.SqlCommand(SqlString, theCons)
                cmd.CommandTimeout = 0
                'Dim dep As SqlDependency = New SqlDependency(cmd)
                'dep.AddCommandDependency(cmd)
                Dim reader As SqlDataReader = cmd.ExecuteReader
                Dim ds As DataSet = New DataSet()
                ds.Load(reader, LoadOption.OverwriteChanges, "Result")
                ''tran.Commit()

                Return ds
                reader.Close()


            Catch ex As Exception

            Finally
                theCons.Close()

            End Try
           

        End Using
        'Catch ex As Exception

        'End Try




        'theCons.ConnectionString = constring
        'theCons.Open()
        'Dim cmd As New System.Data.SqlClient.SqlCommand
        'cmd.CommandType = Data.CommandType.Text
        'cmd.CommandText = SqlString
        'cmd.CommandTimeout = 0
        'cmd.Connection = theCons
        'Dim reader As System.Data.SqlClient.SqlDataReader = cmd.ExecuteReader
        'Dim ds As DataSet = New DataSet()
        'ds.Load(reader, LoadOption.OverwriteChanges, "Result")
        'reader.Close()
        'cmd.Dispose()
        'theCons.Close()
        'theCons.Dispose()
        'Return ds
        'Using da As New SqlDataAdapter(SqlString, constring)
        '    Dim ds As DataSet = New DataSet()
        '    'Dim dep As SqlDependency = New SqlDependency(da)
        '    'da.MissingSchemaAction = MissingSchemaAction.AddWithKey
        '    da.Fill(ds)
        '    Return ds
        'End Using
        'Dim da As SqlDataAdapter = New SqlDataAdapter(SqlString, constring)


    End Function

    
    'Function OraCmd(ByVal str_ora As String) As OracleDataReader
    '    Dim oradbcon As New OracleConnection(Mycon1)
    '    Dim oracmd As New OracleCommand(str_ora, oradbcon)
    '    OraCmd.CommandType = CommandType.Text
    '    sqldbcon.Open()
    '    Return cmd.ExecuteReader(CommandBehavior.CloseConnection)
    'End Function
    'Function sqlCmd(ByVal str_ins As String) As SqlDataReader
    '    Dim sqldbcon As New SqlConnection(Mycon1)
    '    Dim cmd As New SqlCommand(str_ins, sqldbcon)
    '    cmd.CommandType = CommandType.Text
    '    sqldbcon.Open()
    '    Return cmd.ExecuteReader(CommandBehavior.CloseConnection)
    'End Function
    Public Shared Sub Convet(ByVal ds As DataSet, ByVal response As HttpResponse)
        response.Clear()
        response.Charset = ""
        response.ContentType = "application/vnd.ms-excel"

        Dim stringWrite As New System.IO.StringWriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)

        Dim dg As New DataGrid

        dg.DataSource = ds.Tables(0)
        'bind the datagrid
        dg.DataBind()
        'tell the datagrid to render itself to our htmltextwriter
        dg.RenderControl(htmlWrite)
        'all that's left is to output the html
        response.Write(stringWrite.ToString)
        response.End()
    End Sub
    Public Shared Function XML_Gen1(ByVal path As String, ByVal Fs As FileStream, _
                    ByVal rpt As XmlTextWriter, ByVal qry As String, ByVal Bodyname As String, _
                    ByVal rptname As String, ByVal rptCallrpt As String, ByVal httpath As String, ByVal xsdpath As String, _
                    ByVal xmlTitle As String, ByVal header As String, ByVal xmltitleID As String, _
                    ByVal xmlTitleDesc As String, ByVal instID As String, ByVal instDesc As String, _
                    ByVal ddateFrom As String, ByVal ddateTo As String, ByVal ddesc As String, ByVal rept As String) As String


        Dim bankcode As String = ""
        Dim bank As String = ""

        bankcode = con.SqlDs(selbdet).Tables(0).Rows(0).Item(0).ToString
        bank = con.SqlDs(selbdet).Tables(0).Rows(0).Item(1).ToString

        Dim dacon As New Data.SqlClient.SqlDataAdapter( _
               qry, const2)
        Dim dscon As New DataSet(Bodyname)
        dacon.Fill(dscon, rptCallrpt)

        Fs = New FileStream(path, FileMode.Create)
        rpt = New XmlTextWriter(Fs, New UTF8Encoding)
        rpt.Formatting = Formatting.Indented
        rpt.Indentation = 4
        rpt.WriteStartDocument()
        rpt.WriteStartElement(xmlTitle)
        'rpt.WriteAttributeString("xmlns", "xsi", Nothing, httpath)
        'rpt.WriteAttributeString("xsi", "noNamespaceSchemaLocation", Nothing, xsdpath)
        rpt.WriteStartElement(header)
        rpt.WriteElementString(instID, bankcode)
        rpt.WriteElementString(instDesc, bank)
        rpt.WriteElementString(xmltitleID, rptname)
        rpt.WriteElementString(xmlTitleDesc, rept)
        rpt.WriteElementString("PERIODFROM", ddateFrom)
        rpt.WriteElementString("PERIODEND", ddateTo)
        rpt.WriteElementString("VER", "ORIG")
        rpt.WriteElementString("SIGNED", "")
        rpt.WriteElementString("LNG", "en_US")
        rpt.WriteEndElement()
        dscon.WriteXml(rpt)
        'rpt.WriteStartElement("FOOTER")
        'Dim prepby As String = "" : Dim authby As String = ""
        ' ''    Dim TYPE_OF_FACILITY As String = "" : Dim AMOUNT_AUTHORISED As String = ""
        'For Each dr As Data.DataRow In con.SqlDs(footer).Tables(0).Rows
        '    prepby = dr("PREPARED_BY").ToString
        '    authby = dr("AUTH_BY").ToString
        '    rpt.WriteElementString("PREPARED_BY", prepby)
        '    rpt.WriteElementString("AUTH_BY", authby)

        'Next
        'rpt.WriteEndElement()
        'rpt.WriteEndElement()


        rpt.WriteEndDocument()
        rpt.Flush()
        rpt.Close()
        Return 1
    End Function
    Public Shared Function XML_EFASS_Gen1(ByVal path As String, ByVal Fs As FileStream, _
                    ByVal rpt As XmlTextWriter, ByVal qry As String, ByVal Bodyname As String, _
                    ByVal rptname As String, ByVal rptCallrpt As String, ByVal httpath As String, ByVal xsdpath As String, _
                    ByVal xmlTitle As String, ByVal header As String, ByVal xmltitleID As String, _
                    ByVal xmlTitleDesc As String, ByVal instID As String, ByVal instDesc As String, _
                    ByVal ddateFrom As String, ByVal ddesc As String, ByVal rept As String) As String


        Dim bankcode As String = ""
        Dim bank As String = ""

        bankcode = con.SqlDs(selbdet).Tables(0).Rows(0).Item(0).ToString
        bank = con.SqlDs(selbdet).Tables(0).Rows(0).Item(1).ToString

        Dim dacon As New Data.SqlClient.SqlDataAdapter( _
               qry, const2)
        Dim dscon As New DataSet(Bodyname)
        dacon.Fill(dscon, rptCallrpt)

        Fs = New FileStream(path, FileMode.Create)
        rpt = New XmlTextWriter(Fs, New UTF8Encoding)
        rpt.Formatting = Formatting.Indented
        rpt.Indentation = 4
        rpt.WriteStartDocument()
        rpt.WriteStartElement(xmlTitle)
        rpt.WriteAttributeString("xmlns", "xsi", Nothing, httpath)
        rpt.WriteAttributeString("xsi", "noNamespaceSchemaLocation", Nothing, xsdpath)
        rpt.WriteStartElement(header)
        rpt.WriteElementString(xmltitleID, LTrim(RTrim(rptname)))
        rpt.WriteElementString(xmlTitleDesc, LTrim(RTrim(rept)))
        rpt.WriteElementString(instID, LTrim(RTrim(bankcode)))
        rpt.WriteElementString(instDesc, LTrim(RTrim(bank)))
        rpt.WriteElementString("AS_AT", LTrim(RTrim(ddateFrom)))
        rpt.WriteEndElement()
        rpt.WriteStartElement("BODY")
        dscon.WriteXml(rpt)
        rpt.WriteEndElement()

        rpt.WriteStartElement("FOOTER")
        Dim prepby As String = "" : Dim position As String = ""
        ''    Dim TYPE_OF_FACILITY As String = "" : Dim AMOUNT_AUTHORISED As String = ""
        For Each dr As Data.DataRow In con.SqlDs(footer).Tables(0).Rows
            prepby = dr("PREPARED_BY").ToString
            position = dr("POSITION").ToString
            rpt.WriteStartElement("AUTH_SIGNATORY")
            rpt.WriteElementString("NAME", LTrim(RTrim(prepby)))
            rpt.WriteElementString("POSITION", LTrim(RTrim(position)))
            rpt.WriteElementString("DATE", LTrim(RTrim(ddateFrom)))
            rpt.WriteEndElement()

        Next
        rpt.WriteEndElement()
        rpt.WriteEndElement()


        rpt.WriteEndDocument()
        rpt.Flush()
        rpt.Close()
        Return 1
    End Function
    Public Shared Function XML_EFASS_Gen2(ByVal path As String, ByVal Fs As FileStream, _
                   ByVal rpt As XmlTextWriter, ByVal qry As String, ByVal Bodyname As String, _
                    ByVal rptname As String, ByVal rptCallrpt As String, ByVal httpath As String, ByVal xsdpath As String, _
                    ByVal xmlTitle As String, ByVal header As String, ByVal xmltitleID As String, _
                    ByVal xmlTitleDesc As String, ByVal instID As String, ByVal instDesc As String, _
                    ByVal ddateFrom As String, ByVal ddesc As String, ByVal rept As String) As String




        Dim bankcode As String = ""
        Dim bank As String = ""

        bankcode = con.SqlDs(selbdet).Tables(0).Rows(0).Item(0).ToString
        bank = con.SqlDs(selbdet).Tables(0).Rows(0).Item(1).ToString


        Fs = New FileStream(path, FileMode.Create)
        rpt = New XmlTextWriter(Fs, New UTF8Encoding)
        rpt.Formatting = Formatting.Indented
        rpt.Indentation = 4
        rpt.WriteStartDocument()
        rpt.WriteStartElement(xmlTitle)
        rpt.WriteAttributeString("xmlns", "xsi", Nothing, httpath)
        rpt.WriteAttributeString("xsi", "noNamespaceSchemaLocation", Nothing, xsdpath)
        rpt.WriteStartElement(header)
        rpt.WriteElementString(xmltitleID, LTrim(RTrim(rptname)))
        rpt.WriteElementString(xmlTitleDesc, LTrim(RTrim(rept)))
        rpt.WriteElementString(instID, LTrim(RTrim(bankcode)))
        rpt.WriteElementString(instDesc, LTrim(RTrim(bank)))
        rpt.WriteElementString("AS_AT", LTrim(RTrim(ddateFrom)))
        rpt.WriteEndElement()
        rpt.WriteStartElement("BODY")

        ''looop thorugh breakdown
        Dim SLNo As String = "" : Dim Customer As String = "" : Dim DateApproved As String = "" : Dim ApprovedLimit As String = ""
        Dim Naira As String = "" : Dim Percent As String = "" : Dim UndrawnComit As String = ""

        rpt.WriteStartElement(rptCallrpt)
        For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows

            ''CALLREPORT_DATA
            SLNo = dr("SL_NO").ToString
            Customer = dr("CUST_NAME").ToString
            DateApproved = dr("DATE_APPROVED").ToString
            ApprovedLimit = dr("APPROVED_LIMIT").ToString
            Naira = dr("NAIRA").ToString
            Percent = dr("PERCENT").ToString
            UndrawnComit = dr("UNDRAWN_COMMITMENTS").ToString
            

            rpt.WriteElementString("SL_NO", LTrim(RTrim(SLNo)))
            rpt.WriteElementString("CUST_NAME", LTrim(RTrim(Customer)))
            rpt.WriteElementString("DATE_APPROVED", LTrim(RTrim(DateApproved)))
            rpt.WriteElementString("APPROVED_LIMIT", LTrim(RTrim(ApprovedLimit)))

            rpt.WriteStartElement("AMOUNT_DRAWN")
            rpt.WriteElementString("NAIRA", LTrim(RTrim(Naira)))
            rpt.WriteElementString("PERCENT", LTrim(RTrim(Percent)))
           
            rpt.WriteEndElement()

            rpt.WriteElementString("UNDRAWN_COMMITMENTS", LTrim(RTrim(UndrawnComit)))

        Next



        rpt.WriteEndElement()

        rpt.WriteEndElement()

        rpt.WriteStartElement("FOOTER")
        Dim prepby As String = "" : Dim position As String = ""
        ''    Dim TYPE_OF_FACILITY As String = "" : Dim AMOUNT_AUTHORISED As String = ""
        For Each dr As Data.DataRow In con.SqlDs(footer).Tables(0).Rows
            prepby = dr("PREPARED_BY").ToString
            position = dr("POSITION").ToString
            rpt.WriteStartElement("AUTH_SIGNATORY")
            rpt.WriteElementString("NAME", LTrim(RTrim(prepby)))
            rpt.WriteElementString("POSITION", LTrim(RTrim(position)))
            rpt.WriteElementString("DATE", LTrim(RTrim(ddateFrom)))
            rpt.WriteEndElement()

        Next
        rpt.WriteEndElement()
        rpt.WriteEndDocument()
        rpt.Flush()
        rpt.Close()
        Return 1
    End Function
    Public Shared Function XML_EFASS_Gen5(ByVal path As String, ByVal Fs As FileStream, _
                   ByVal rpt As XmlTextWriter, ByVal qry As String, ByVal Bodyname As String, _
                    ByVal rptname As String, ByVal rptCallrpt As String, ByVal httpath As String, ByVal xsdpath As String, _
                    ByVal xmlTitle As String, ByVal header As String, ByVal xmltitleID As String, _
                    ByVal xmlTitleDesc As String, ByVal instID As String, ByVal instDesc As String, _
                    ByVal ddateFrom As String, ByVal ddesc As String, ByVal rept As String) As String




        Dim bankcode As String = ""
        Dim bank As String = ""

        bankcode = con.SqlDs(selbdet).Tables(0).Rows(0).Item(0).ToString
        bank = con.SqlDs(selbdet).Tables(0).Rows(0).Item(1).ToString


        Fs = New FileStream(path, FileMode.Create)
        rpt = New XmlTextWriter(Fs, New UTF8Encoding)
        rpt.Formatting = Formatting.Indented
        rpt.Indentation = 4
        rpt.WriteStartDocument()
        rpt.WriteStartElement(xmlTitle)
        rpt.WriteAttributeString("xmlns", "xsi", Nothing, httpath)
        rpt.WriteAttributeString("xsi", "noNamespaceSchemaLocation", Nothing, xsdpath)
        rpt.WriteStartElement(header)
        rpt.WriteElementString(xmltitleID, LTrim(RTrim(rptname)))
        rpt.WriteElementString(xmlTitleDesc, LTrim(RTrim(rept)))
        rpt.WriteElementString(instID, LTrim(RTrim(bankcode)))
        rpt.WriteElementString(instDesc, LTrim(RTrim(bank)))
        rpt.WriteElementString("AS_AT", LTrim(RTrim(ddateFrom)))
        rpt.WriteEndElement()
        rpt.WriteStartElement("BODY")

        ''looop thorugh breakdown
        Dim Code As String = "" : Dim Customer As String = "" : Dim Demand As String = "" : Dim Savings As String = ""
        Dim Upto90days As String = "" : Dim From91days As String = "" : Dim From181Days As String = "" : Dim Over365days As String = ""
        Dim TotalDep As String = ""
        rpt.WriteStartElement(rptCallrpt)
        For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows

            ''CALLREPORT_DATA
            Code = dr("Code").ToString
            Customer = dr("Customer").ToString
            Demand = dr("Demand").ToString
            Savings = dr("Savings").ToString
            Upto90days = dr("UPTO_90_DAYS_N1000").ToString
            From91days = dr("FROM_91_TO_180_DAYS_N1000").ToString
            From181Days = dr("FROM_181_TO_365_DAYS_N1000").ToString
            Over365days = dr("OVER_365_DAYS_N1000").ToString
            TotalDep = dr("TOTAL_DEP").ToString

            rpt.WriteElementString("CODE", LTrim(RTrim(Code)))
            rpt.WriteElementString("CUSTOMER", LTrim(RTrim(Customer)))
            rpt.WriteElementString("DEMAND", LTrim(RTrim(Demand)))
            rpt.WriteElementString("SAVINGS", LTrim(RTrim(Savings)))

            rpt.WriteStartElement("TIME")
            rpt.WriteElementString("UPTO_90_DAYS_N1000", LTrim(RTrim(Upto90days)))
            rpt.WriteElementString("FROM_91_TO_180_DAYS_N1000", LTrim(RTrim(From91days)))
            rpt.WriteElementString("FROM_181_TO_365_DAYS_N1000", LTrim(RTrim(From181Days)))
            rpt.WriteElementString("OVER_365_DAYS_N1000", LTrim(RTrim(Over365days)))
            rpt.WriteEndElement()

            rpt.WriteElementString("TOTAL_DEP", LTrim(RTrim(TotalDep)))

        Next



        rpt.WriteEndElement()

        rpt.WriteEndElement()

        rpt.WriteStartElement("FOOTER")
        Dim prepby As String = "" : Dim position As String = ""
        ''    Dim TYPE_OF_FACILITY As String = "" : Dim AMOUNT_AUTHORISED As String = ""
        For Each dr As Data.DataRow In con.SqlDs(footer).Tables(0).Rows
            prepby = dr("PREPARED_BY").ToString
            position = dr("POSITION").ToString
            rpt.WriteStartElement("AUTH_SIGNATORY")
            rpt.WriteElementString("NAME", LTrim(RTrim(prepby)))
            rpt.WriteElementString("POSITION", LTrim(RTrim(position)))
            rpt.WriteElementString("DATE", LTrim(RTrim(ddateFrom)))
            rpt.WriteEndElement()

        Next
        rpt.WriteEndElement()
        rpt.WriteEndDocument()
        rpt.Flush()
        rpt.Close()
        Return 1
    End Function

    Public Shared Function XML_EFASS_Gen6(ByVal path As String, ByVal Fs As FileStream, _
                   ByVal rpt As XmlTextWriter, ByVal qry As String, ByVal Bodyname As String, _
                    ByVal rptname As String, ByVal rptCallrpt As String, ByVal httpath As String, ByVal xsdpath As String, _
                    ByVal xmlTitle As String, ByVal header As String, ByVal xmltitleID As String, _
                    ByVal xmlTitleDesc As String, ByVal instID As String, ByVal instDesc As String, _
                    ByVal ddateFrom As String, ByVal ddesc As String, ByVal rept As String) As String




        Dim bankcode As String = ""
        Dim bank As String = ""

        bankcode = con.SqlDs(selbdet).Tables(0).Rows(0).Item(0).ToString
        bank = con.SqlDs(selbdet).Tables(0).Rows(0).Item(1).ToString


        Fs = New FileStream(path, FileMode.Create)
        rpt = New XmlTextWriter(Fs, New UTF8Encoding)
        rpt.Formatting = Formatting.Indented
        rpt.Indentation = 4
        rpt.WriteStartDocument()
        rpt.WriteStartElement(xmlTitle)
        rpt.WriteAttributeString("xmlns", "xsi", Nothing, httpath)
        rpt.WriteAttributeString("xsi", "noNamespaceSchemaLocation", Nothing, xsdpath)
        rpt.WriteStartElement(header)
        rpt.WriteElementString(xmltitleID, LTrim(RTrim(rptname)))
        rpt.WriteElementString(xmlTitleDesc, LTrim(RTrim(rept)))
        rpt.WriteElementString(instID, LTrim(RTrim(bankcode)))
        rpt.WriteElementString(instDesc, LTrim(RTrim(bank)))
        rpt.WriteElementString("AS_AT", LTrim(RTrim(ddateFrom)))
        rpt.WriteEndElement()
        rpt.WriteStartElement("BODY")

        ''looop thorugh breakdown
        Dim Code As String = "" : Dim Customer As String = "" : Dim Demand As String = "" : Dim Savings As String = ""
        Dim Upto90days As String = "" : Dim From91days As String = "" : Dim From181Days As String = "" : Dim Over365days As String = ""
        Dim TotalDep As String = ""
        rpt.WriteStartElement(rptCallrpt)
        For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows

            ''CALLREPORT_DATA
            Code = dr("Code").ToString
            Customer = dr("Customer").ToString
            Demand = dr("Demand").ToString
            Savings = dr("Savings").ToString
            Upto90days = dr("UPTO_90_DAYS_N1000").ToString
            From91days = dr("FROM_91_TO_180_DAYS_N1000").ToString
            From181Days = dr("FROM_181_TO_365_DAYS_N1000").ToString
            Over365days = dr("OVER_365_DAYS_N1000").ToString
            TotalDep = dr("TOTAL_DEP").ToString

            rpt.WriteElementString("SL_NO", LTrim(RTrim(Code)))
            rpt.WriteElementString("CUST_CODE", LTrim(RTrim(Code)))
            rpt.WriteElementString("CUST_NAME", LTrim(RTrim(Customer)))
            rpt.WriteElementString("DEMAND", LTrim(RTrim(Demand)))
            rpt.WriteElementString("SAVINGS", LTrim(RTrim(Savings)))

            rpt.WriteStartElement("TIME")
            rpt.WriteElementString("UPTO_90_DAYS_N1000", LTrim(RTrim(Upto90days)))
            rpt.WriteElementString("FROM_91_TO_180_DAYS_N1000", LTrim(RTrim(From91days)))
            rpt.WriteElementString("FROM_181_TO_365_DAYS_N1000", LTrim(RTrim(From181Days)))
            rpt.WriteElementString("OVER_365_DAYS_N1000", LTrim(RTrim(Over365days)))
            rpt.WriteEndElement()

            rpt.WriteElementString("TOTAL_DEP", LTrim(RTrim(TotalDep)))

        Next



        rpt.WriteEndElement()

        rpt.WriteEndElement()

        rpt.WriteStartElement("FOOTER")
        Dim prepby As String = "" : Dim position As String = ""
        ''    Dim TYPE_OF_FACILITY As String = "" : Dim AMOUNT_AUTHORISED As String = ""
        For Each dr As Data.DataRow In con.SqlDs(footer).Tables(0).Rows
            prepby = dr("PREPARED_BY").ToString
            position = dr("POSITION").ToString
            rpt.WriteStartElement("AUTH_SIGNATORY")
            rpt.WriteElementString("NAME", LTrim(RTrim(prepby)))
            rpt.WriteElementString("POSITION", LTrim(RTrim(position)))
            rpt.WriteElementString("DATE", LTrim(RTrim(ddateFrom)))
            rpt.WriteEndElement()

        Next
        rpt.WriteEndElement()
        rpt.WriteEndDocument()
        rpt.Flush()
        rpt.Close()
        Return 1
    End Function


    Private Const Keysize As Integer = 256
    Private Const DerivationIterations As Integer = 1000

    Function EncryptNew(ByVal plainText As String, ByVal passPhrase As String) As String
        Dim saltStringBytes = Generate256BitsOfRandomEntropy()
        Dim ivStringBytes = Generate256BitsOfRandomEntropy()
        Dim plainTextBytes = Encoding.UTF8.GetBytes(plainText)

        Using password = New Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations)
            Dim keyBytes = password.GetBytes(Keysize / 8)

            Using symmetricKey = New RijndaelManaged()
                symmetricKey.BlockSize = 256
                symmetricKey.Mode = CipherMode.CBC
                symmetricKey.Padding = PaddingMode.PKCS7

                Using encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes)

                    Using memoryStream = New MemoryStream()

                        Using cryptoStream = New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)
                            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
                            cryptoStream.FlushFinalBlock()
                            Dim cipherTextBytes = saltStringBytes
                            cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray()
                            cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray()
                            memoryStream.Close()
                            cryptoStream.Close()
                            Return Convert.ToBase64String(cipherTextBytes)
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Function

    Function DecryptNew(ByVal cipherText As String, ByVal passPhrase As String) As String
        Dim cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText)
        Dim saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray()
        Dim ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray()
        Dim cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray()

        Using password = New Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations)
            Dim keyBytes = password.GetBytes(Keysize / 8)

            Using symmetricKey = New RijndaelManaged()
                symmetricKey.BlockSize = 256
                symmetricKey.Mode = CipherMode.CBC
                symmetricKey.Padding = PaddingMode.PKCS7

                Using decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes)

                    Using memoryStream = New MemoryStream(cipherTextBytes)

                        Using cryptoStream = New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
                            Dim plainTextBytes = New Byte(cipherTextBytes.Length - 1) {}
                            Dim decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
                            memoryStream.Close()
                            cryptoStream.Close()
                            Return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Function

    Private Function Generate256BitsOfRandomEntropy() As Byte()
        Dim randomBytes = New Byte(31) {}

        Using rngCsp = New RNGCryptoServiceProvider()
            rngCsp.GetBytes(randomBytes)
        End Using

        Return randomBytes
    End Function

    Public Function encryptNewest(ByVal encryptString As String) As String
        Dim EncryptionKey As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(encryptString)

        Using encryptor As Aes = Aes.Create()
            Dim pdb As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, &H65, &H64, &H76, &H65, &H64, &H65, &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)

            Using ms As MemoryStream = New MemoryStream()

                Using cs As CryptoStream = New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using

                encryptString = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using

        Return encryptString
    End Function

    Public Function DecryptNewest(ByVal cipherText As String) As String
        Dim EncryptionKey As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        cipherText = cipherText.Replace(" ", "+")
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)

        Using encryptor As Aes = Aes.Create()
            Dim pdb As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, &H65, &H64, &H76, &H65, &H64, &H65, &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)

            Using ms As MemoryStream = New MemoryStream()

                Using cs As CryptoStream = New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using

                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using

        Return cipherText
    End Function
End Class
