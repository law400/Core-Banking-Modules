Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Diagnostics

Imports System
Imports System.Configuration

Namespace DataAceessLayer
  
    Public Class DAL
        Public Shared sqldb As String = ConfigurationManager.ConnectionStrings("Prime").ConnectionString
       
        Private sqlDataReader As SqlDataReader
       
#Region "server1"
        ''----------------------------------------
        ''----------------------------------------
        ' ''        Private Sub AddsqlParam(ByVal parmsDataTable As DataTable, ByVal cmd As SqlCommand, ByVal ParamArray cols As String())
        ' ''            Try
        ' ''                Dim parmName As String = ""
        ' ''                Dim parmType As String = ""
        ' ''                Dim parmNameDataColumn As DataColumn = parmsDataTable.Columns("PARAMETER_NAME")
        ' ''                Dim parmTypeDataColumn As DataColumn = parmsDataTable.Columns("DATA_TYPE")
        ' ''                Dim i As Integer = 0


        ' ''                For Each parmRow As DataRow In parmsDataTable.Rows

        ' ''                    parmName = parmRow(parmNameDataColumn).ToString()
        ' ''                    parmType = parmRow(parmTypeDataColumn).ToString()

        ' ''                    If parmName = "@retval" OrElse parmName = "@remsg" Then
        ' ''                        GoTo 80
        ' ''                    End If
        ' ''                    cmd.Parameters.Add(parmName, parmType).Value = cols(i)
        ' ''80:
        ' ''                    i += 1
        ' ''                Next


        ' ''                ''Dim i As Integer
        ' ''                ''For i = 0 To UBound(cols)


        ' ''                ''    ''If IsNumeric(cols(i)) Then
        ' ''                ''    ''    cmd.Parameters.Add(parmName, SqlDbType.Decimal).Value = cols(i)

        ' ''                ''    ''ElseIf IsDate(cols(i)) Then
        ' ''                ''    ''    cmd.Parameters.Add(parmName, SqlDbType.DateTime).Value = cols(i)
        ' ''                ''    ''    'ElseIf IsDate(cols(i)) Then
        ' ''                ''    ''    '    cmd.Parameters.Add(paramval, OracleClient.OracleType.DateTime).Value = cols(i)
        ' ''                ''    ''Else
        ' ''                ''    ''    cmd.Parameters.Add(parmName, SqlDbType.VarChar).Value = cols(i)
        ' ''                ''    ''End If
        ' ''                ''Next

        ' ''            Catch ex As Exception
        ' ''                Throw New Exception(ex.Message)
        ' ''            End Try
        ' ''        End Sub
        Private Sub AddSqlParameters(ByVal myCommand As SqlCommand, ByVal ParamArray cols As String())
            Try
                Dim paramval As String = ""
                Dim i As Integer
                For i = 0 To UBound(cols)
                    paramval = "@param" & (i + 1)
                    Dim dd As String = paramval
                    myCommand.Parameters.AddWithValue(paramval, cols(i))
                  
                Next
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
        Private Sub AddsqlParam(ByVal cmd As SqlCommand, ByVal ParamArray cols As String())
            Try
               
                Dim paramval As String = ""
                Dim i As Integer = 0

                For i = 0 To UBound(cols)
                    '' Dim ss As String = cmd.Parameters.Contains(0)
                    paramval = "param" & (i + 1)
                    Dim dd As String = paramval
                    If IsNumeric(cols(i)) Then
                        cmd.Parameters.Add(paramval, SqlDbType.Decimal).Value = cols(i)

                    ElseIf IsDate(cols(i)) Then
                        cmd.Parameters.Add(paramval, SqlDbType.DateTime).Value = cols(i)

                    Else
                        cmd.Parameters.Add(paramval, SqlDbType.VarChar).Value = cols(i)
                    End If
                    'cmd.Parameters(i).Value = cols(i)
                Next
                ''Dim inputParamList As New ArrayList
                ''inputParamList.Clear()

                ''Dim i As Integer = 0
                ''Dim count As Integer = UBound(cols)

                ' ''For Each param As SqlParameter In cmd.Parameters
                ' ''    If param.Direction = Data.ParameterDirection.Input OrElse param.Direction = Data.ParameterDirection.InputOutput Then

                ' ''        inputParamList.Add(Convert.ToString(param))
                ' ''    Else

                ' ''    End If
                ' ''Next
                ' ''Dim items As Object

                ' '' ''Dim strings As String() = DirectCast(inputParamList.ToArray(GetType(String)), String())

                ' ''For Each items In inputParamList
                ' ''    ''Dim ss As String = items(i)
                ' ''    If IsNumeric(cols(i)) Then
                ' ''        cmd.Parameters.Add(items(i), SqlDbType.Decimal).Value = cols(i)

                ' ''    ElseIf IsDate(cols(i)) Then
                ' ''        cmd.Parameters.Add(items(i), SqlDbType.DateTime).Value = cols(i)

                ' ''    Else
                ' ''        cmd.Parameters.Add(items(i), SqlDbType.VarChar).Value = cols(i)
                ' ''    End If

                ' ''    i += 1

                ' ''    If count < i Then
                ' ''        Exit For
                ' ''    End If
                ' ''Next

            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
        Public Function Paramdrnon(ByVal procname As String, ByVal ParamArray cols As String()) As Boolean 
            Dim ds As DataSet = New DataSet()
            Dim dr As SqlDataReader
            Try
                Dim conn As New SqlConnection(DAL.sqldb)
                ' ''Dim da As DataReaderAdapter = New DataReaderAdapter()

                Dim cmd As SqlCommand = New SqlCommand()
                cmd.Connection = conn
                cmd.CommandText = procname
                cmd.CommandType = CommandType.StoredProcedure
                AddsqlParam(cmd, cols)
                ''cmd.Parameters.Add("ret_val", SqlDbType.VarChar).Direction = ParameterDirection.Output
                ''cmd.Parameters.Add("ret_msg", SqlDbType.VarChar).Direction = ParameterDirection.Output
                conn.Open()
                cmd.ExecuteNonQuery()

                Return True
                conn.Close()

            Catch ex As SqlClient.SqlException
            End Try

        End Function

        Public Function Paramdr(ByVal procname As String, ByVal ParamArray cols As String()) As SqlDataReader
            Dim ds As DataSet = New DataSet()
            Dim dr As SqlDataReader
            Try
                Dim conn As New SqlConnection(DAL.sqldb)
                ' ''Dim da As DataReaderAdapter = New DataReaderAdapter()
             
                Dim cmd As New SqlCommand()
                cmd.Connection = conn
                cmd.CommandText = procname
                cmd.CommandType = CommandType.StoredProcedure
                ''conn.Open()
                ''''SqlCommandBuilder.DeriveParameters(cmd)
                ''conn.Close()

                conn.Open()
                AddsqlParam(cmd, cols)
                ''cmd.Parameters.Add("ret_val", SqlDbType.VarChar).Direction = ParameterDirection.Output
                ''cmd.Parameters.Add("ret_msg", SqlDbType.VarChar).Direction = ParameterDirection.Output

                dr = cmd.ExecuteReader()

                Return dr
                conn.Close()

            Catch ex As SqlClient.SqlException

                Dim msg As String = ex.Message
                Dim i As Integer = ex.Number
                ''ex.ErrorCode 
            End Try

        End Function

        Public Function Paramds(ByVal procname As String, ByVal ParamArray cols As String()) As DataTable
            Dim ds As DataSet = New DataSet()
            Dim dr As SqlDataReader
            Dim dt As DataTable
            Try
                Dim conn As New SqlConnection(DAL.sqldb)
                ' ''Dim da As DataReaderAdapter = New DataReaderAdapter()

                Dim cmd As SqlCommand = New SqlCommand()
                cmd.Connection = conn
                cmd.CommandText = procname
                cmd.CommandType = CommandType.StoredProcedure
                AddsqlParam(cmd, cols)
                ''cmd.Parameters.Add("ret_val", SqlDbType.VarChar).Direction = ParameterDirection.Output
                ''cmd.Parameters.Add("ret_msg", SqlDbType.VarChar).Direction = ParameterDirection.Output
                conn.Open()
                dr = cmd.ExecuteReader()

                ds.Load(dr, LoadOption.OverwriteChanges, "Result")
                dt = ds.Tables(0)
                Return dt
                conn.Close()

            Catch ex As SqlClient.SqlException
            End Try

        End Function

        Public Function ParamdrOutput(ByVal procname As String, ByVal ParamArray cols As String()) As SqlDataReader
            Dim ds As DataSet = New DataSet()
            Dim dr As SqlDataReader
            Try
                Dim conn As New SqlConnection(DAL.sqldb)
                ' ''Dim da As DataReaderAdapter = New DataReaderAdapter()
                Dim cmd As SqlCommand = New SqlCommand()
                cmd.Connection = conn
                cmd.CommandText = procname
                cmd.CommandType = CommandType.StoredProcedure
                conn.Open()
                ''''SqlCommandBuilder.DeriveParameters(cmd)
                AddsqlParam(cmd, cols)

                cmd.Parameters.Add("@retval", SqlDbType.Int).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@retmsg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output

                dr = cmd.ExecuteReader

                Return dr
                conn.Close()

            Catch ex As SqlClient.SqlException
            End Try

        End Function

        Public Function SQLRecordDs(ByVal SqlString As String) As DataTable
            Using theCons As New SqlConnection(sqldb)
                theCons.Open()
                Dim ds As New Data.DataSet
                ''Dim tran As SqlTransaction = theCons.BeginTransaction
                Try
                    ''Dim cmd As New System.Data.SqlClient.SqlCommand(SqlString, theCons, tran)
                    Dim cmd As New System.Data.SqlClient.SqlCommand(SqlString, theCons)

                  
                    Dim dt As DataTable
                    Dim dr As SqlDataReader = cmd.ExecuteReader()
                    ''  = dr.GetSchemaTable
                    '
                    ''da.FillFromReader(dt, dr); 
                    ds.Load(dr, LoadOption.OverwriteChanges, "Result")
                    dt = ds.Tables(0)
                    Return dt
                    theCons.Close()

                Catch ex As Exception

                End Try


            End Using



        End Function

     

        
        ''----------------------------------------
        ''----------------------------------------
#End Region


    End Class

End Namespace
