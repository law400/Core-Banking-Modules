<%@ WebHandler Language="VB" Class="Handler" %>
Imports System
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Public Class Handler : Implements IHttpHandler
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
       
        Dim myConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Prime").ConnectionString)

        myConnection.close()
        Dim param As Data.SqlClient.SqlParameter
        Dim param1 As Data.SqlClient.SqlParameter
                       
        Try
            Dim sqlv As String = "Select * from tbl_mandatepicts where serial=@manid and accountnumber=@acctno"
            '' If con.SqlDs(sqlv).Tables(0).Rows.Count > 0 Then
      
            Dim cmd As SqlCommand = New SqlCommand(sqlv, myConnection)
            param = New Data.SqlClient.SqlParameter("@manid", Data.SqlDbType.VarChar)
            param.Value = context.Request.QueryString("id")
            param1 = New Data.SqlClient.SqlParameter("@acctno", Data.SqlDbType.VarChar)
            param1.Value = context.Request.QueryString("id2")
            
            cmd.Parameters.Add(param)
            cmd.Parameters.Add(param1)
            myConnection.Open()
            
            ''myConnection.Close()
            ''cmd.Parameters.Add("@acctno",SqlDbType.Text).Value = context.Request.QueryString("id")
            ''cmd.Prepare()
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            dr.Read()
            context.Response.ContentType = dr("Image_Type").ToString()
            If Not IsDBNull(dr.Item("customerimage")) Then
                context.Response.BinaryWrite(CType(dr.Item("customerimage"), Byte()))
            End If
        
            dr.Close()
            myConnection.Close()
            ''Else
            Exit Sub
            ''End If
        Catch ex As Exception
        
        End Try

    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class