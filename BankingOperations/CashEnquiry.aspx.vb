Imports System.Web.UI.WebControls
Imports log4net
Imports log4net.Config
Partial Class AccountCustomerServices_Enquiry_CashEnquiry
    Inherits SessionCheck
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(AccountCustomerServices_Enquiry_CashEnquiry))
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Me.txtUserid.Text = Session("Userid").ToString
        End If
    End Sub

    'Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim selPass As String = "select a.branchcode,b.userid from tbl_userProfile a,tabTellerAccount b where a.userid='" & Me.txtUserid.text.trim & "' and a.userid=b.userid"
    '    If con.SqlDs(selPass).Tables(0).Rows.Count > 0 Then
    '        For Each dr As Data.DataRow In con.SqlDs(selPass).Tables(0).Rows
    '            Profile.BranchCode = dr!branchcode.ToString
    '        Next
    '        GridView1.Visible = True

    '    Else
    '        GridView1.Visible = False
    '        smartobj.alertwindow (me.Page ,"Data Warnning error...", MsgBoxStyle.SystemModal,"Prime") "Till Account No Specified For User", "Prime")
    '    End If

    'End Sub
End Class
