Imports Microsoft.VisualBasic

Public Class SmartItems
    Private LnPrincipal As Double
    Private LnInterest As Double
    Private LnEMI As Double
    Private LnOutstdPrincipal As Double
    Private LnNOOfPaymtsOutstd As Int32
    Private LnNOOfPaidScheds As Int32
    Private LnScheduleType As String
    Private LnScheduleDate As String
    Private lnInnerDate As String
    'Private Shared lnPCounter As Int32
    Public Sub New()
        'lnPCounter = 0
    End Sub

    Public Sub setValues(ByVal lnP As Double, ByVal lnI As Double, ByVal lnEmi As Double, _
                      ByVal lnOutP As Double, ByVal lnSO As Int32, ByVal lnSP As Int32, _
                      ByVal sType As String, ByVal lnsDate As String, ByVal Innerd As String)
        'MyBase.New()
        Me.LnPrincipal = lnP
        Me.LnInterest = lnI
        Me.LnEMI = lnEmi
        Me.LnOutstdPrincipal = lnOutP
        Me.LnNOOfPaymtsOutstd = lnSO
        Me.LnNOOfPaidScheds = lnSP
        Me.LnScheduleType = sType
        Me.LnScheduleDate = lnsDate
        Me.lnInnerDate = Innerd
        'LoanItem.lnPCounter = LoanItem.lnPCounter + 1
    End Sub

    Public Property Principal() As Double
        Get
            Return LnPrincipal
        End Get
        Set(ByVal Value As Double)
            LnPrincipal = Value
        End Set
    End Property

    Public Property Interest() As Double
        Get
            Return LnInterest
        End Get
        Set(ByVal Value As Double)
            LnInterest = Value
        End Set
    End Property

    Public Property LoanEMI() As Double
        Get
            Return LnEMI
        End Get
        Set(ByVal Value As Double)
            LnEMI = Value
        End Set
    End Property

    Public Property OutsdPrincp() As Double
        Get
            Return LnOutstdPrincipal
        End Get
        Set(ByVal Value As Double)
            LnOutstdPrincipal = Value
        End Set
    End Property

    Public Property NoOfPaymtsDue() As Int32
        Get
            Return LnNOOfPaymtsOutstd
        End Get
        Set(ByVal Value As Int32)
            LnNOOfPaymtsOutstd = Value
        End Set
    End Property

    Public Property NoOfSchedPaid() As Double
        Get
            Return LnNOOfPaidScheds
        End Get
        Set(ByVal Value As Double)
            LnNOOfPaidScheds = Value
        End Set
    End Property

    Public Property SchedType() As String
        Get
            Return LnScheduleType
        End Get
        Set(ByVal Value As String)
            LnScheduleType = Value
        End Set
    End Property

    Public Property SchedDate() As String
        Get
            Return LnScheduleDate
        End Get
        Set(ByVal Value As String)
            LnScheduleDate = Value
        End Set
    End Property

    Public Property InnerDate() As String
        Get
            Return lnInnerDate
        End Get
        Set(ByVal Value As String)
            lnInnerDate = Value
        End Set
    End Property
End Class
