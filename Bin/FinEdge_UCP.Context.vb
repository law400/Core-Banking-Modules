﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.Core.Objects
Imports System.Linq

Partial Public Class XAAS_230Entities1
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=XAAS_230Entities1")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property Tbl_Vendors() As DbSet(Of Tbl_Vendors)
    Public Overridable Property tbl_LoanScheduleDetail() As DbSet(Of tbl_LoanScheduleDetail)
    Public Overridable Property Memcos_Reg_table() As DbSet(Of Memcos_Reg_table)

    Public Overridable Function proc_insVendor(vendorCode As String, vendorname As String, vendoraddress As String, contact_Person As String, contact_phoneno As String, contact_email As String, userid As String, retval As ObjectParameter, retmsg As ObjectParameter) As Integer
        Dim vendorCodeParameter As ObjectParameter = If(vendorCode IsNot Nothing, New ObjectParameter("VendorCode", vendorCode), New ObjectParameter("VendorCode", GetType(String)))

        Dim vendornameParameter As ObjectParameter = If(vendorname IsNot Nothing, New ObjectParameter("Vendorname", vendorname), New ObjectParameter("Vendorname", GetType(String)))

        Dim vendoraddressParameter As ObjectParameter = If(vendoraddress IsNot Nothing, New ObjectParameter("Vendoraddress", vendoraddress), New ObjectParameter("Vendoraddress", GetType(String)))

        Dim contact_PersonParameter As ObjectParameter = If(contact_Person IsNot Nothing, New ObjectParameter("Contact_Person", contact_Person), New ObjectParameter("Contact_Person", GetType(String)))

        Dim contact_phonenoParameter As ObjectParameter = If(contact_phoneno IsNot Nothing, New ObjectParameter("Contact_phoneno", contact_phoneno), New ObjectParameter("Contact_phoneno", GetType(String)))

        Dim contact_emailParameter As ObjectParameter = If(contact_email IsNot Nothing, New ObjectParameter("Contact_email", contact_email), New ObjectParameter("Contact_email", GetType(String)))

        Dim useridParameter As ObjectParameter = If(userid IsNot Nothing, New ObjectParameter("Userid", userid), New ObjectParameter("Userid", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("proc_insVendor", vendorCodeParameter, vendornameParameter, vendoraddressParameter, contact_PersonParameter, contact_phonenoParameter, contact_emailParameter, useridParameter, retval, retmsg)
    End Function

    Public Overridable Function proc_updVendor(iD As Nullable(Of Integer), vendorname As String, vendoraddress As String, contact_Person As String, contact_phoneno As String, contact_email As String, userid As String, retval As ObjectParameter, retmsg As ObjectParameter) As Integer
        Dim iDParameter As ObjectParameter = If(iD.HasValue, New ObjectParameter("ID", iD), New ObjectParameter("ID", GetType(Integer)))

        Dim vendornameParameter As ObjectParameter = If(vendorname IsNot Nothing, New ObjectParameter("Vendorname", vendorname), New ObjectParameter("Vendorname", GetType(String)))

        Dim vendoraddressParameter As ObjectParameter = If(vendoraddress IsNot Nothing, New ObjectParameter("Vendoraddress", vendoraddress), New ObjectParameter("Vendoraddress", GetType(String)))

        Dim contact_PersonParameter As ObjectParameter = If(contact_Person IsNot Nothing, New ObjectParameter("Contact_Person", contact_Person), New ObjectParameter("Contact_Person", GetType(String)))

        Dim contact_phonenoParameter As ObjectParameter = If(contact_phoneno IsNot Nothing, New ObjectParameter("Contact_phoneno", contact_phoneno), New ObjectParameter("Contact_phoneno", GetType(String)))

        Dim contact_emailParameter As ObjectParameter = If(contact_email IsNot Nothing, New ObjectParameter("Contact_email", contact_email), New ObjectParameter("Contact_email", GetType(String)))

        Dim useridParameter As ObjectParameter = If(userid IsNot Nothing, New ObjectParameter("Userid", userid), New ObjectParameter("Userid", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("proc_updVendor", iDParameter, vendornameParameter, vendoraddressParameter, contact_PersonParameter, contact_phonenoParameter, contact_emailParameter, useridParameter, retval, retmsg)
    End Function

    Public Overridable Function proc_delVendor(iD As Nullable(Of Integer), userid As String, retval As ObjectParameter, retmsg As ObjectParameter) As Integer
        Dim iDParameter As ObjectParameter = If(iD.HasValue, New ObjectParameter("ID", iD), New ObjectParameter("ID", GetType(Integer)))

        Dim useridParameter As ObjectParameter = If(userid IsNot Nothing, New ObjectParameter("Userid", userid), New ObjectParameter("Userid", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("proc_delVendor", iDParameter, useridParameter, retval, retmsg)
    End Function

End Class
