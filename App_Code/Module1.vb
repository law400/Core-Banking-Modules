Imports System.Globalization
Imports System.Data
Imports System.Data.SqlClient

Imports System.Threading
Imports System.Web.UI.WebControls
Public Module Module1
    Public con As New smartcon
    Public conobj As New smartobj
    Public drow1 As DataRow
    Public dr As DataRow
    Public drx As DataRow
    Public behav As New Integer
    Public latesttime As Date
    Dim Character As String
    'Private _retmsg As String = ""
    'Private _retval As Integer = -1

    'Public qry As String = ""
    ''Public constring As String = String.Format(ConfigurationManager.AppSettings("Fleet"),"Snow","managermc!12","Fleet")
    Public constring As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Prime").ConnectionString)

    
End Module

