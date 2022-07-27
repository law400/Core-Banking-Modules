Imports System.Net
Imports System.Security.Cryptography.X509Certificates

Public Class MyCertificatePolicy
    Public Function CheckValidationResult(ByVal sp As ServicePoint, ByVal cert As X509Certificate, ByVal req As WebRequest, ByVal problem As Integer) As Boolean


        Return True

    End Function
End Class
