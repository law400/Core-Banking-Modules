Imports Microsoft.VisualBasic

Public Class DBNBankOneResponse
    Private Retval1 As Boolean
    Public Property Retval() As Boolean
        Get
            Return Retval1
        End Get
        Set(ByVal value As Boolean)
            Retval1 = value
        End Set
    End Property
    Private Retmsg1 As String
    Public Property Retmsg() As String
        Get
            Return Retmsg1
        End Get
        Set(ByVal value As String)
            Retmsg1 = value
        End Set
    End Property
    Private TransactionRef1 As String
    Public Property TransactionRef() As String
        Get
            Return TransactionRef1
        End Get
        Set(ByVal value As String)
            TransactionRef1 = value
        End Set
    End Property
    

End Class
