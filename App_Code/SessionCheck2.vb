﻿Imports Microsoft.VisualBasic

Public Class SessionCheck2
    Inherits System.Web.UI.Page
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
        MyBase.OnInit(e)
        If Session("UserID") Is Nothing Then
            Response.Redirect("~/PageExpired2.aspx")
            ''  FormsAuthentication.RedirectToLoginPage()
        End If
    End Sub
End Class
