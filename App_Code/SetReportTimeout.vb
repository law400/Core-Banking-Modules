Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Namespace PrimeTableAdapters

    Partial Public Class Proc_RptStatementTableAdapter
        Public Property ConnectionString() As String
            Get
                Return Me.Connection.ConnectionString
            End Get
            Set(ByVal value As String)
                Me.Connection.ConnectionString = value
                Me.Connection.ConnectionString = ConfigurationManager.ConnectionStrings("Prime").ConnectionString

            End Set
        End Property

        Public Sub SetCommandTimeout(ByVal timeout As Integer)
            If Me.Adapter.InsertCommand IsNot Nothing Then
                Me.Adapter.InsertCommand.CommandTimeout = timeout
            End If

            If Me.Adapter.DeleteCommand IsNot Nothing Then
                Me.Adapter.DeleteCommand.CommandTimeout = timeout
            End If

            If Me.Adapter.UpdateCommand IsNot Nothing Then
                Me.Adapter.UpdateCommand.CommandTimeout = timeout
            End If

            For i As Integer = 0 To Me.CommandCollection.Length - 1
                If Me.CommandCollection(i) IsNot Nothing Then
                    Me.CommandCollection(i).CommandTimeout = timeout
                End If
            Next
        End Sub
    End Class
End Namespace
