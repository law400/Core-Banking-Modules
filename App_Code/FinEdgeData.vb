﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Memcos_Reg_table
    Public Property EmployeeID As String
    Public Property Email As String
    Public Property Comfirm_Password As String
    Public Property Password As String
    Public Property Phone As String
    Public Property Location As String
    Public Property Department As String
    Public Property Gender As String
    Public Property MonthlyContri As Decimal
    Public Property create_date As Nullable(Of Date)
    Public Property enforce_pwd As Nullable(Of Integer)
    Public Property status As String
    Public Property AltEmail As String
    Public Property AltPhone As String
    Public Property Address As String
    Public Property DOB As Nullable(Of Date)
    Public Property Piture As String
    Public Property Signatures As String
    Public Property Next_name As String
    Public Property Next_Address As String
    Public Property Occupation As String
    Public Property Bank As String
    Public Property AccountNumber As String
    Public Property AcctName As String
    Public Property FirstName As String
    Public Property LastName As String
    Public Property OtherName As String
    Public Property Bkbalance As Nullable(Of Decimal)
    Public Property EmployeeName As String
    Public Property customerid As Nullable(Of Integer)
    Public Property Photo As Byte()
    Public Property Image_Type As String
    Public Property NewContriAmount As Nullable(Of Decimal)
    Public Property ContiEffectiveDate As Nullable(Of Date)
    Public Property PaymentBank As String
    Public Property PictureUrl As String
    Public Property OracleNumber As String
    Public Property Node_id As Nullable(Of Integer)

End Class
Partial Public Class tbl_bankgl
    Public Property GLNumber As String
    Public Property AcctName As String
    Public Property BranchCode As String
    Public Property Gl_ClassCode As String
    Public Property CurrencyCode As String
    Public Property DateOpened As Nullable(Of Date)
    Public Property DT_Lst_Month As Nullable(Of Date)
    Public Property Last_Month_Balance As Nullable(Of Decimal)
    Public Property Status As Nullable(Of Integer)
    Public Property Last_Night_Balance As Nullable(Of Decimal)
    Public Property BKBalance As Nullable(Of Decimal)
    Public Property TpostDebit As Nullable(Of Decimal)
    Public Property TpostCredit As Nullable(Of Decimal)
    Public Property Blocked As String
    Public Property Closed As String
    Public Property reconLen As Nullable(Of Integer)
    Public Property post As Nullable(Of Integer)
    Public Property BBF As Nullable(Of Decimal)
    Public Property ProdType As String
    Public Property Pointing As Nullable(Of Integer)
    Public Property typeP As String
    Public Property userid As String
    Public Property authid As String
    Public Property createdate As Nullable(Of Date)
    Public Property populate As Nullable(Of Integer)
    Public Property oldGLno As String
    Public Property last_night_balance2 As Nullable(Of Decimal)
    Public Property Swing As Nullable(Of Integer)
    Public Property last_month_balance2 As Nullable(Of Decimal)
    Public Property last_month_balance1 As Nullable(Of Decimal)
    Public Property last_eom2 As Nullable(Of Date)
    Public Property last_eom1 As Nullable(Of Date)
    Public Property currmondiff As Nullable(Of Decimal)
    Public Property lastmondiff As Nullable(Of Decimal)
    Public Property UniqueID As Integer
    Public Property node_id As Nullable(Of Integer)

End Class
Partial Public Class tbl_Inventorycategory
    Public Property inventorycatid As Integer
    Public Property inventorycatdesc As String
    Public Property cracct As String
    Public Property dracct As String
    Public Property createdate As Nullable(Of Date)
    Public Property userid As String
    Public Property transacct As String
    Public Property Node_id As Nullable(Of Integer)

End Class
Partial Public Class tbl_InventorySupply
    Public Property itbid As Integer
    Public Property itemid As Nullable(Of Integer)
    Public Property costprice As Nullable(Of Decimal)
    Public Property qty As Nullable(Of Integer)
    Public Property totalcost As Nullable(Of Decimal)
    Public Property valuedate As Nullable(Of Date)
    Public Property supplydetail As String
    Public Property Datecreated As Nullable(Of Date)
    Public Property userid As String
    Public Property vendor As Nullable(Of Integer)
    Public Property Node_id As Nullable(Of Integer)

End Class
Partial Public Class tbl_InventoryVendors
    Public Property VendorID As Integer
    Public Property CompanyName As String
    Public Property RegistrationNo As String
    Public Property CompanyEmail As String
    Public Property Address As String
    Public Property CreditRating As Nullable(Of Byte)
    Public Property GSM As String
    Public Property BkBalance As Nullable(Of Decimal)
    Public Property VendorCategoryID As Nullable(Of Integer)
    Public Property ContactPerson As String
    Public Property AccPayable As String
    Public Property UserID As String
    Public Property createdate As Nullable(Of Date)
    Public Property node_id As Nullable(Of Integer)

End Class
Partial Public Class tbl_LoanScheduleDetail
    Public Property CustId As Nullable(Of Decimal)
    Public Property AccountNumber As String
    Public Property TotalRepayAmt As Nullable(Of Decimal)
    Public Property PrincipalAmt As Nullable(Of Decimal)
    Public Property InterestAmt As Nullable(Of Decimal)
    Public Property OutstandingBal As Nullable(Of Decimal)
    Public Property intaccrual As Nullable(Of Decimal)
    Public Property InstalDue As Nullable(Of Integer)
    Public Property InstalPay As Nullable(Of Integer)
    Public Property Date_due As Nullable(Of Date)
    Public Property Schedtype As String
    Public Property PaymentStatus As String
    Public Property I_Paid As String
    Public Property P_Paid As String
    Public Property oldrate As Nullable(Of Decimal)
    Public Property intrate As Nullable(Of Decimal)
    Public Property status As Nullable(Of Integer)
    Public Property userid As String
    Public Property authid As String
    Public Property createdate As Nullable(Of Date)
    Public Property currentinstall As Nullable(Of Integer)
    Public Property unpaidinterestamt As Nullable(Of Decimal)
    Public Property paidinterestamt As Nullable(Of Decimal)
    Public Property daysinmonth As Nullable(Of Integer)
    Public Property days_counter As Nullable(Of Integer)
    Public Property monthly_interest_due As Nullable(Of Decimal)
    Public Property daily_interest_due As Nullable(Of Decimal)
    Public Property month_accum_interest As Nullable(Of Decimal)
    Public Property principal_repayment As Nullable(Of Decimal)
    Public Property repayment_method As Nullable(Of Integer)
    Public Property freq As String
    Public Property trandate As Nullable(Of Date)
    Public Property repay_date As Nullable(Of Date)
    Public Property startdate As Nullable(Of Date)
    Public Property totaloutstanding As Nullable(Of Decimal)
    Public Property principal_due As Nullable(Of Decimal)
    Public Property unpaidprinc As Nullable(Of Decimal)
    Public Property paidprinc As Nullable(Of Decimal)
    Public Property bkbalance As Nullable(Of Decimal)
    Public Property UniqueID As Integer
    Public Property node_id As Nullable(Of Integer)

End Class
Partial Public Class Tbl_Vendors
    Public Property ID As Integer
    Public Property VendorCode As String
    Public Property VendorName As String
    Public Property VendorAddress As String
    Public Property Contact_Phone As String
    Public Property Contact_Person As String
    Public Property Contact_Email As String
    Public Property Status As Nullable(Of Integer)
    Public Property Userid As String
    Public Property Node_id As Nullable(Of Integer)

End Class
