Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Services
Imports log4net
Imports log4net.Config

Partial Class Dashboard
    Inherits SessionCheck
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(Dashboard))
    Public Shared NodeId As String = "1"

    'Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    Dim menuname As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("lbldisplay"), System.Web.UI.WebControls.Label)
    '    menuname.Text = "DASHBOARD"

    '    NodeId = Session("node_id")


    '    If NodeId = 3 Then
    '        Get_CFAN_Dashboard_Data()
    '        Div_CFAN.Visible = True
    '        Div_All.Visible = False
    '        Panel_PaymentChart.Visible = True
    '        Div_CWG_Pane.Visible = False
    '        Div_Donor_Panel.Visible = False

    '    ElseIf NodeId = 4 Then
    '        Get_CWG_Dashboard_Data()
    '        Div_CFAN.Visible = False
    '        Div_All.Visible = False
    '        Div_CWG_Pane.Visible = True
    '        Panel_PaymentChart.Visible = True
    '        Div_Donor_Panel.Visible = False

    '    ElseIf NodeId = 5 Then

    '        Get_DONOR_Dashboard_Data()
    '        Div_CFAN.Visible = False
    '        Div_All.Visible = False
    '        Div_CWG_Pane.Visible = False
    '        Div_Donor_Panel.Visible = True
    '        'Panel_cwg_PaymentChart.Visible = True
    '        Panel_PaymentChart.Visible = False

    '    ElseIf NodeId = 1 Then
    '        Get_Dashboard_Data()
    '        Div_CFAN.Visible = False
    '        Div_All.Visible = True
    '        Panel_PaymentChart.Visible = True
    '        Div_CWG_Pane.Visible = False
    '        Div_Donor_Panel.Visible = False

    '    Else

    '        Get_Dashboard_Data()
    '        Div_CFAN.Visible = False
    '        Div_All.Visible = True
    '        Panel_PaymentChart.Visible = False
    '        Div_CWG_Pane.Visible = False
    '        Div_Donor_Panel.Visible = False
    '    End If

    '    'If NodeId = 1 Then
    '    '    Panel_PaymentChart.Visible = True
    '    'Else
    '    '    Panel_PaymentChart.Visible = False
    '    'End If



    'End Sub

    'Sub Get_Dashboard_Data()

    '    Try
    '        Dim selExist As String = "Exec proc_Fetch_DashboardData " & Session("node_id") & ""
    '        If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then
    '            'Dim seltyp As String = "Select apptype from tbl_bankproduct a,tbl_casaaccount b where a.productcode=b.productcode and b.accountnumber='" & Me.txtAcNumber.Text.Trim & "'"
    '            'For Each dr As Data.DataRow In con.SqlDs(seltyp).Tables(0).Rows
    '            '    app = dr!apptype.ToString.Trim
    '            'Next
    '            'If app = "CK" Then
    '            '    smartobj.alertwindow(Me.Page, "Transaction is Not Allowed On Checking Account.", "Prime")
    '            '    Exit Sub
    '            'End If
    '            drx = con.SqlDs(selExist).Tables(0).Rows(0)
    '            Me.lbl_No_Of_Cooperators.InnerText = drx.Item("No_of_Cooperators")
    '            Me.Lbl_No_Cooperators_1.InnerText = drx.Item("No_of_Cooperators")
    '            Me.lbl_No_Of_Cooperators_Yest.InnerText = drx.Item("No_of_Cooperators_Yest")
    '            Me.lbl_No_Of_Cooperators_Week.InnerText = drx.Item("No_of_Cooperators_Week")

    '            Me.lbl_No_of_Txn.InnerText = drx.Item("No_of_Txn")

    '            Me.lbl_No_of_Txn_Yest.InnerText = drx.Item("No_of_Txn_Yest")
    '            Me.lbl_No_of_Txn_Week.InnerText = drx.Item("No_of_Txn_Week")


    '            Me.lbl_No_of_Loan.InnerText = drx.Item("No_of_Loan")
    '            Me.Lbl_loan_Accounts_No.InnerText = drx.Item("No_of_Loan")
    '            Me.lbl_No_of_Loan_Yest.InnerText = drx.Item("No_of_Loan_Yest")
    '            Me.lbl_No_of_Loan_Week.InnerText = drx.Item("No_of_Loan_Week")
    '            Dim Total_Loan_Portfolio_Amt As Decimal = drx.Item("Total_Loan_Portfolio_Amt")
    '            If Total_Loan_Portfolio_Amt <> 0 Then
    '                Me.lbl_Loan_Portfolio_Amt.InnerText = "₦" + String.Format("{0:#,#.00}", drx.Item("Total_Loan_Portfolio_Amt"))
    '            Else
    '                Me.lbl_Loan_Portfolio_Amt.InnerText = "₦" + Total_Loan_Portfolio_Amt.ToString
    '            End If
    '            Me.lbl_Contributions_Amt.InnerText = "₦" + String.Format("{0:#,#.00}", drx.Item("Total_Contributions_Amt"))
    '            Me.lbl_Repay_Due_Today_Count.InnerText = drx.Item("Loan_Repay_Due_Today_Count")
    '            Me.lbl_Repayment_This_Week_Count.InnerText = drx.Item("Total_Repayment_This_Week_Count")
    '            Dim Total_Repayment_this_Week_amt As Decimal = drx.Item("Total_Repayment_This_Week_Amt")
    '            If Total_Repayment_this_Week_amt <> 0 Then
    '                Me.lbl_Repayment_This_Week_Amt.InnerText = "₦" + String.Format("{0:#,#.00}", drx.Item("Total_Repayment_This_Week_Amt"))

    '            Else
    '                Me.lbl_Repayment_This_Week_Amt.InnerText = "₦" + Total_Repayment_this_Week_amt.ToString
    '            End If
    '            Dim Repay_due_today_Amt As Decimal = drx.Item("Loan_Repay_Due_Today_amt")
    '            If Repay_due_today_Amt <> 0 Then
    '                Me.lbl_Repay_Due_Today_Amt.InnerText = "₦" + String.Format("{0:#,#.00}", drx.Item("Loan_Repay_Due_Today_amt"))

    '            Else
    '                Me.lbl_Repay_Due_Today_Amt.InnerText = "₦" + Repay_due_today_Amt.ToString
    '            End If


    '            Exit Sub
    '        End If
    '    Catch ex As Exception
    '        logger.Info("DASHBOARD.aspx: Get_Dashboard_Data'" _
    '       & vbNewLine & "   <<<<Direction: OUTPUT" _
    '       & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
    '       & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
    '       & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
    '       & vbNewLine & "*******************************************************************************************************************************************************************")
    '    End Try

    'End Sub


    'Sub Get_CFAN_Dashboard_Data()

    '    Try
    '        Dim TotalCooperators As String = "select count(*) TotalCoop from tbl_customer with (nolock) where status  = 1 and Node_id not in (1,250,251,253)"
    '        If con.SqlDs(TotalCooperators).Tables(0).Rows.Count > 0 Then
    '            drx = con.SqlDs(TotalCooperators).Tables(0).Rows(0)
    '            Me.lblTotalnumberOfCooprators.InnerText = drx.Item("TotalCoop")

    '        End If

    '        Dim TotalNoofCoop As String = "select count(*) TotalNoOfCoop from tbl_Bank with (nolock) where Node_id not in (1,250,251,253)"
    '        If con.SqlDs(TotalNoofCoop).Tables(0).Rows.Count > 0 Then
    '            drx = con.SqlDs(TotalNoofCoop).Tables(0).Rows(0)
    '            Me.lbltotatalNoOfCoop.InnerText = drx.Item("TotalNoOfCoop")

    '        End If


    '        Dim selExist As String = "Exec proc_Fetch_DashboardData " & Session("node_id") & ""
    '        If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then
    '            'Dim seltyp As String = "Select apptype from tbl_bankproduct a,tbl_casaaccount b where a.productcode=b.productcode and b.accountnumber='" & Me.txtAcNumber.Text.Trim & "'"
    '            'For Each dr As Data.DataRow In con.SqlDs(seltyp).Tables(0).Rows
    '            '    app = dr!apptype.ToString.Trim
    '            'Next
    '            'If app = "CK" Then
    '            '    smartobj.alertwindow(Me.Page, "Transaction is Not Allowed On Checking Account.", "Prime")
    '            '    Exit Sub
    '            'End If
    '            drx = con.SqlDs(selExist).Tables(0).Rows(0)
    '            Me.lbl_CFAN_No_Of_Cooperators.InnerText = drx.Item("No_of_Cooperators")
    '            Me.Lbl_CFANNo_Cooperators_1.InnerText = drx.Item("No_of_Cooperators")
    '            Me.lbl_CFANNo_Of_Cooperators_Yest.InnerText = drx.Item("No_of_Cooperators_Yest")
    '            Me.lbl_CFANNo_Of_Cooperators_Week.InnerText = drx.Item("No_of_Cooperators_Week")


    '            Me.Lbl_CFAN_loan_Accounts_No.InnerText = drx.Item("No_of_Loan")
    '            'Me.lbl_No_of_Loan_Yest.InnerText = drx.Item("No_of_Loan_Yest")
    '            'Me.lbl_No_of_Loan_Week.InnerText = drx.Item("No_of_Loan_Week")

    '            Dim Total_CFAN_Loan_Portfolio_Amt As Decimal = drx.Item("Total_Loan_Portfolio_Amt")
    '            If Total_CFAN_Loan_Portfolio_Amt <> 0 Then
    '                Me.lbl_Loan_Portfolio_Amt.InnerText = "₦" + String.Format("{0:#,#.00}", drx.Item("Total_Loan_Portfolio_Amt"))
    '            Else


    '                Me.lbl_Loan_Portfolio_Amt.InnerText = "₦" + Total_CFAN_Loan_Portfolio_Amt.ToString
    '            End If
    '            Me.lbl_CFANContributions_Amt.InnerText = "₦" + String.Format("{0:#,#.00}", drx.Item("Total_Contributions_Amt"))
    '            Me.lbl_Repay_Due_Today_Count.InnerText = drx.Item("Loan_Repay_Due_Today_Count")
    '            Me.lbl_CFANRepayment_This_Week_Count.InnerText = drx.Item("Total_Repayment_This_Week_Count")

    '            Dim Total_CFANRepayment_this_Week_amt As Decimal = drx.Item("Total_Repayment_This_Week_Amt")

    '            If Total_CFANRepayment_this_Week_amt <> 0 Then
    '                Me.lbl_CFANRepayment_This_Week_Amt.InnerText = "₦" + String.Format("{0:#,#.00}", drx.Item("Total_Repayment_This_Week_Amt"))

    '            Else
    '                Me.lbl_CFANRepayment_This_Week_Amt.InnerText = "₦" + Total_CFANRepayment_this_Week_amt.ToString
    '            End If

    '            Dim Repay_CFANdue_today_Amt As Decimal = drx.Item("Loan_Repay_Due_Today_amt")
    '            If Repay_CFANdue_today_Amt <> 0 Then
    '                Me.lbl_CFANRepay_Due_Today_Amt.InnerText = "₦" + String.Format("{0:#,#.00}", drx.Item("Loan_Repay_Due_Today_amt"))

    '            Else
    '                Me.lbl_CFANRepay_Due_Today_Amt.InnerText = "₦" + Repay_CFANdue_today_Amt.ToString
    '            End If


    '            Exit Sub
    '        End If


    '    Catch ex As Exception
    '        logger.Info("DASHBOARD.aspx: Get_Dashboard_Data'" _
    '       & vbNewLine & "   <<<<Direction: OUTPUT" _
    '       & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
    '       & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
    '       & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
    '       & vbNewLine & "*******************************************************************************************************************************************************************")
    '    End Try

    'End Sub


    'Sub Get_CWG_Dashboard_Data()

    '    Try

    '        Dim Coopstatus As String = "exec proc_TenantStatus"
    '        Me.GridView1.DataSource = con.SqlDs(Coopstatus)
    '        Me.GridView1.DataBind()

    '        Dim TotalCooperators As String = "select count(*) TotalCoop from tbl_customer with (nolock) where status  = 1 and Node_id not in (1,250,251,253)"
    '        If con.SqlDs(TotalCooperators).Tables(0).Rows.Count > 0 Then
    '            drx = con.SqlDs(TotalCooperators).Tables(0).Rows(0)
    '            Me.lbl_cwg_total_no_cooperator.InnerText = drx.Item("TotalCoop")
    '            'Me.lbl_cwg_total_no_cooperator.InnerText = smartobj.FormatMoney(Me.lbl_cwg_total_no_cooperator.InnerText)

    '        End If

    '        Dim CoopBalance As String = "select  isnull(sum(BKBalance),0) BKBalance from tbl_casaaccount with (nolock) where Node_id not in (1,250,251,253)"
    '        If con.SqlDs(CoopBalance).Tables(0).Rows.Count > 0 Then
    '            drx = con.SqlDs(CoopBalance).Tables(0).Rows(0)
    '            Me.lbl_cwg_total_contri.InnerText = drx.Item("BKBalance")

    '            Me.lbl_cwg_total_contri.InnerText = smartobj.FormatMoney(Me.lbl_cwg_total_contri.InnerText)
    '            Me.lbl_cwg_total_contri.InnerText = "₦" + Me.lbl_cwg_total_contri.InnerText


    '        End If



    '        Dim TotalNoofCoop As String = "select count(*) TotalNoOfCoop from tbl_Bank with (nolock) where Node_id not in (1,250,251,253)"
    '        If con.SqlDs(TotalNoofCoop).Tables(0).Rows.Count > 0 Then
    '            drx = con.SqlDs(TotalNoofCoop).Tables(0).Rows(0)
    '            Me.lbl_cwg_total_No_of_Cooperatives.InnerText = drx.Item("TotalNoOfCoop")

    '        End If

    '        Dim LoanBal As String = "select isnull(sum(abs(currentbalance)),0) currentbalance from tbl_loanaccount with (nolock) where Node_id not in (1,250,251,253)"
    '        If con.SqlDs(LoanBal).Tables(0).Rows.Count > 0 Then
    '            drx = con.SqlDs(LoanBal).Tables(0).Rows(0)
    '            Me.lblLoanPortfolio.InnerText = drx.Item("currentbalance")
    '            Me.lblLoanPortfolio.InnerText = smartobj.FormatMoney(Me.lblLoanPortfolio.InnerText)
    '            Me.lblLoanPortfolio.InnerText = "₦" + Me.lblLoanPortfolio.InnerText

    '        End If



    '        Dim ThismonthLoanBal As String = "select isnull(sum(abs(currentbalance)),0) currentbalance from tbl_loanaccount with (nolock) where Node_id not in (1,250,251,253) and FORMAT(posting_dt, 'yyyyMM') =  FORMAT(getdate(), 'yyyyMM')"
    '        If con.SqlDs(ThismonthLoanBal).Tables(0).Rows.Count > 0 Then
    '            drx = con.SqlDs(ThismonthLoanBal).Tables(0).Rows(0)
    '            Me.lblThismonth.InnerText = drx.Item("currentbalance")
    '            Me.lblThismonth.InnerText = smartobj.FormatMoney(Me.lblThismonth.InnerText)
    '            Me.lblThismonth.InnerText = "₦" + Me.lblThismonth.InnerText

    '        End If

    '        Dim ThismonthTotalcontribution As String = "select isnull(sum(abs(TranAmount)),0) TranAmount from tbl_transactions with (nolock) where len(AccountNumber) = 11  and TranAmount >0 and FORMAT(TranDate, 'yyyyMM') =  FORMAT(getdate(), 'yyyyMM')  and Node_id not in (1,250,251,253)"
    '        If con.SqlDs(ThismonthTotalcontribution).Tables(0).Rows.Count > 0 Then
    '            drx = con.SqlDs(ThismonthTotalcontribution).Tables(0).Rows(0)
    '            Me.lblTotalcontribution.InnerText = drx.Item("TranAmount")
    '            Me.lblTotalcontribution.InnerText = smartobj.FormatMoney(Me.lblTotalcontribution.InnerText)
    '            Me.lblTotalcontribution.InnerText = "₦" + Me.lblTotalcontribution.InnerText

    '        End If



    '        Dim SubstriptionBalance As String = "select isnull(sum(Outstanding_Bal),0) Outstanding_Bal from Reg_table with (nolock)"
    '        If con.SqlDs(LoanBal).Tables(0).Rows.Count > 0 Then
    '            drx = con.SqlDs(SubstriptionBalance).Tables(0).Rows(0)
    '            Me.lblSubstriptionBalance.InnerText = drx.Item("Outstanding_Bal")
    '            Me.lblSubstriptionBalance.InnerText = smartobj.FormatMoney(Me.lblSubstriptionBalance.InnerText)
    '            Me.lblSubstriptionBalance.InnerText = "₦" + Me.lblSubstriptionBalance.InnerText

    '        End If


    '        Dim selExist As String = "Exec proc_Fetch_DashboardData " & Session("node_id") & ""
    '        If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then
    '            'Dim seltyp As String = "Select apptype from tbl_bankproduct a,tbl_casaaccount b where a.productcode=b.productcode and b.accountnumber='" & Me.txtAcNumber.Text.Trim & "'"
    '            'For Each dr As Data.DataRow In con.SqlDs(seltyp).Tables(0).Rows
    '            '    app = dr!apptype.ToString.Trim
    '            'Next
    '            'If app = "CK" Then
    '            '    smartobj.alertwindow(Me.Page, "Transaction is Not Allowed On Checking Account.", "Prime")
    '            '    Exit Sub
    '            'End If
    '            drx = con.SqlDs(selExist).Tables(0).Rows(0)
    '            Me.lbl_CFAN_No_Of_Cooperators.InnerText = drx.Item("No_of_Cooperators")
    '            Me.Lbl_CFANNo_Cooperators_1.InnerText = drx.Item("No_of_Cooperators")
    '            Me.lbl_CFANNo_Of_Cooperators_Yest.InnerText = drx.Item("No_of_Cooperators_Yest")
    '            Me.lbl_CFANNo_Of_Cooperators_Week.InnerText = drx.Item("No_of_Cooperators_Week")


    '            Me.Lbl_CFAN_loan_Accounts_No.InnerText = drx.Item("No_of_Loan")
    '            'Me.lbl_No_of_Loan_Yest.InnerText = drx.Item("No_of_Loan_Yest")
    '            'Me.lbl_No_of_Loan_Week.InnerText = drx.Item("No_of_Loan_Week")

    '            Dim Total_CFAN_Loan_Portfolio_Amt As Decimal = drx.Item("Total_Loan_Portfolio_Amt")
    '            If Total_CFAN_Loan_Portfolio_Amt <> 0 Then
    '                Me.lbl_Loan_Portfolio_Amt.InnerText = "₦" + String.Format("{0:#,#.00}", drx.Item("Total_Loan_Portfolio_Amt"))
    '            Else


    '                Me.lbl_Loan_Portfolio_Amt.InnerText = "₦" + Total_CFAN_Loan_Portfolio_Amt.ToString
    '            End If
    '            Me.lbl_CFANContributions_Amt.InnerText = "₦" + String.Format("{0:#,#.00}", drx.Item("Total_Contributions_Amt"))
    '            Me.lbl_Repay_Due_Today_Count.InnerText = drx.Item("Loan_Repay_Due_Today_Count")
    '            Me.lbl_CFANRepayment_This_Week_Count.InnerText = drx.Item("Total_Repayment_This_Week_Count")

    '            Dim Total_CFANRepayment_this_Week_amt As Decimal = drx.Item("Total_Repayment_This_Week_Amt")

    '            If Total_CFANRepayment_this_Week_amt <> 0 Then
    '                Me.lbl_CFANRepayment_This_Week_Amt.InnerText = "₦" + String.Format("{0:#,#.00}", drx.Item("Total_Repayment_This_Week_Amt"))

    '            Else
    '                Me.lbl_CFANRepayment_This_Week_Amt.InnerText = "₦" + Total_CFANRepayment_this_Week_amt.ToString
    '            End If

    '            Dim Repay_CFANdue_today_Amt As Decimal = drx.Item("Loan_Repay_Due_Today_amt")
    '            If Repay_CFANdue_today_Amt <> 0 Then
    '                Me.lbl_CFANRepay_Due_Today_Amt.InnerText = "₦" + String.Format("{0:#,#.00}", drx.Item("Loan_Repay_Due_Today_amt"))

    '            Else
    '                Me.lbl_CFANRepay_Due_Today_Amt.InnerText = "₦" + Repay_CFANdue_today_Amt.ToString
    '            End If


    '            Exit Sub
    '        End If


    '    Catch ex As Exception
    '        logger.Info("DASHBOARD.aspx: Get_Dashboard_Data'" _
    '       & vbNewLine & "   <<<<Direction: OUTPUT" _
    '       & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
    '       & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
    '       & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
    '       & vbNewLine & "*******************************************************************************************************************************************************************")
    '    End Try

    'End Sub

    'Sub Get_DONOR_Dashboard_Data()

    '    Try
    '        Dim TotalCooperators As String = "select count(*) TotalCoop from tbl_customer with (nolock) where status  = 1 and Node_id not in (1,250,251,253)"
    '        If con.SqlDs(TotalCooperators).Tables(0).Rows.Count > 0 Then
    '            drx = con.SqlDs(TotalCooperators).Tables(0).Rows(0)
    '            Me.lbl_donor_total_no_cooperator.InnerText = drx.Item("TotalCoop")
    '            'Me.lbl_cwg_total_no_cooperator.InnerText = smartobj.FormatMoney(Me.lbl_cwg_total_no_cooperator.InnerText)

    '        End If

    '        Dim CoopBalance As String = "select  isnull(sum(BKBalance),0) BKBalance from tbl_casaaccount with (nolock) where Node_id not in (1,250,251,253)"
    '        If con.SqlDs(CoopBalance).Tables(0).Rows.Count > 0 Then
    '            drx = con.SqlDs(CoopBalance).Tables(0).Rows(0)
    '            Me.lbl_donor_total_contri.InnerText = drx.Item("BKBalance")

    '            Me.lbl_donor_total_contri.InnerText = smartobj.FormatMoney(Me.lbl_donor_total_contri.InnerText)
    '            Me.lbl_donor_total_contri.InnerText = "₦" + Me.lbl_donor_total_contri.InnerText


    '        End If



    '        Dim TotalNoofCoop As String = "select count(*) TotalNoOfCoop from Reg_table with (nolock)"
    '        If con.SqlDs(TotalNoofCoop).Tables(0).Rows.Count > 0 Then
    '            drx = con.SqlDs(TotalNoofCoop).Tables(0).Rows(0)
    '            Me.lbl_Donor_total_No_of_Cooperatives.InnerText = drx.Item("TotalNoOfCoop")

    '        End If

    '        'Dim TotalNoofMaleCoop As String = "select count(*) TotalNoOfMaleCoop from Memcos_Reg_table with (nolock) where Gender = 'Male' and status = 'Approved' "
    '        'If con.SqlDs(TotalNoofMaleCoop).Tables(0).Rows.Count > 0 Then
    '        '    drx = con.SqlDs(TotalNoofMaleCoop).Tables(0).Rows(0)
    '        '    Me.lblMalecoop.InnerText = drx.Item("TotalNoOfMaleCoop")

    '        'End If

    '        'Dim TotalNoofFeMaleCoop As String = "select count(*) TotalNoOfFeMaleCoop from Memcos_Reg_table with (nolock) where Gender = 'Female' and status = 'Approved'"
    '        'If con.SqlDs(TotalNoofFeMaleCoop).Tables(0).Rows.Count > 0 Then
    '        '    drx = con.SqlDs(TotalNoofFeMaleCoop).Tables(0).Rows(0)
    '        '    Me.lblFemaleCount.InnerText = drx.Item("TotalNoOfFeMaleCoop")

    '        'End If


    '        'Dim LoanBal As String = "select isnull(sum(abs(currentbalance)),0) currentbalance from tbl_loanaccount with (nolock) where Node_id not in (1,250,251,253)"
    '        'If con.SqlDs(LoanBal).Tables(0).Rows.Count > 0 Then
    '        '    drx = con.SqlDs(LoanBal).Tables(0).Rows(0)
    '        '    Me.lbl_loan_disbursed_donor.InnerText = drx.Item("currentbalance")
    '        '    Me.lbl_loan_disbursed_donor.InnerText = smartobj.FormatMoney(Me.lbl_loan_disbursed_donor.InnerText)
    '        '    Me.lbl_loan_disbursed_donor.InnerText = "₦" + Me.lbl_loan_disbursed_donor.InnerText

    '        'End If



    '        Dim ThismonthLoanBal As String = "select isnull(sum(abs(currentbalance)),0) currentbalance from tbl_loanaccount with (nolock) where Node_id not in (1,250,251,253) and FORMAT(posting_dt, 'yyyyMM') =  FORMAT(getdate(), 'yyyyMM')"
    '        If con.SqlDs(ThismonthLoanBal).Tables(0).Rows.Count > 0 Then
    '            drx = con.SqlDs(ThismonthLoanBal).Tables(0).Rows(0)
    '            Me.lblThismonth.InnerText = drx.Item("currentbalance")
    '            Me.lblThismonth.InnerText = smartobj.FormatMoney(Me.lblThismonth.InnerText)
    '            Me.lblThismonth.InnerText = "₦" + Me.lblThismonth.InnerText

    '        End If

    '        Dim ThismonthTotalcontribution As String = "select isnull(sum(abs(TranAmount)),0) TranAmount from tbl_transactions with (nolock) where len(AccountNumber) = 11  and TranAmount >0 and FORMAT(TranDate, 'yyyyMM') =  FORMAT(getdate(), 'yyyyMM')  and Node_id not in (1,250,251,253)"
    '        If con.SqlDs(ThismonthTotalcontribution).Tables(0).Rows.Count > 0 Then
    '            drx = con.SqlDs(ThismonthTotalcontribution).Tables(0).Rows(0)
    '            Me.lblTotalcontribution.InnerText = drx.Item("TranAmount")
    '            Me.lblTotalcontribution.InnerText = smartobj.FormatMoney(Me.lblTotalcontribution.InnerText)
    '            Me.lblTotalcontribution.InnerText = "₦" + Me.lblTotalcontribution.InnerText

    '        End If



    '        'Dim SubstriptionBalance As String = "select isnull(sum(Outstanding_Bal),0) Outstanding_Bal from Reg_table with (nolock)"
    '        'If con.SqlDs(LoanBal).Tables(0).Rows.Count > 0 Then
    '        '    drx = con.SqlDs(SubstriptionBalance).Tables(0).Rows(0)
    '        '    Me.lblSubstriptionBalance.InnerText = drx.Item("Outstanding_Bal")
    '        '    Me.lblSubstriptionBalance.InnerText = smartobj.FormatMoney(Me.lblSubstriptionBalance.InnerText)
    '        '    Me.lblSubstriptionBalance.InnerText = "₦" + Me.lblSubstriptionBalance.InnerText

    '        'End If


    '        Dim selExist As String = "Exec proc_Fetch_DashboardData " & Session("node_id") & ""
    '        If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then
    '            'Dim seltyp As String = "Select apptype from tbl_bankproduct a,tbl_casaaccount b where a.productcode=b.productcode and b.accountnumber='" & Me.txtAcNumber.Text.Trim & "'"
    '            'For Each dr As Data.DataRow In con.SqlDs(seltyp).Tables(0).Rows
    '            '    app = dr!apptype.ToString.Trim
    '            'Next
    '            'If app = "CK" Then
    '            '    smartobj.alertwindow(Me.Page, "Transaction is Not Allowed On Checking Account.", "Prime")
    '            '    Exit Sub
    '            'End If
    '            drx = con.SqlDs(selExist).Tables(0).Rows(0)
    '            Me.lbl_CFAN_No_Of_Cooperators.InnerText = drx.Item("No_of_Cooperators")
    '            Me.Lbl_CFANNo_Cooperators_1.InnerText = drx.Item("No_of_Cooperators")
    '            Me.lbl_CFANNo_Of_Cooperators_Yest.InnerText = drx.Item("No_of_Cooperators_Yest")
    '            Me.lbl_CFANNo_Of_Cooperators_Week.InnerText = drx.Item("No_of_Cooperators_Week")


    '            Me.Lbl_CFAN_loan_Accounts_No.InnerText = drx.Item("No_of_Loan")
    '            'Me.lbl_No_of_Loan_Yest.InnerText = drx.Item("No_of_Loan_Yest")
    '            'Me.lbl_No_of_Loan_Week.InnerText = drx.Item("No_of_Loan_Week")

    '            Dim Total_CFAN_Loan_Portfolio_Amt As Decimal = drx.Item("Total_Loan_Portfolio_Amt")
    '            If Total_CFAN_Loan_Portfolio_Amt <> 0 Then
    '                Me.lbl_Loan_Portfolio_Amt.InnerText = "₦" + String.Format("{0:#,#.00}", drx.Item("Total_Loan_Portfolio_Amt"))
    '            Else


    '                Me.lbl_Loan_Portfolio_Amt.InnerText = "₦" + Total_CFAN_Loan_Portfolio_Amt.ToString
    '            End If
    '            Me.lbl_CFANContributions_Amt.InnerText = "₦" + String.Format("{0:#,#.00}", drx.Item("Total_Contributions_Amt"))
    '            Me.lbl_Repay_Due_Today_Count.InnerText = drx.Item("Loan_Repay_Due_Today_Count")
    '            Me.lbl_CFANRepayment_This_Week_Count.InnerText = drx.Item("Total_Repayment_This_Week_Count")

    '            Dim Total_CFANRepayment_this_Week_amt As Decimal = drx.Item("Total_Repayment_This_Week_Amt")

    '            If Total_CFANRepayment_this_Week_amt <> 0 Then
    '                Me.lbl_CFANRepayment_This_Week_Amt.InnerText = "₦" + String.Format("{0:#,#.00}", drx.Item("Total_Repayment_This_Week_Amt"))

    '            Else
    '                Me.lbl_CFANRepayment_This_Week_Amt.InnerText = "₦" + Total_CFANRepayment_this_Week_amt.ToString
    '            End If

    '            Dim Repay_CFANdue_today_Amt As Decimal = drx.Item("Loan_Repay_Due_Today_amt")
    '            If Repay_CFANdue_today_Amt <> 0 Then
    '                Me.lbl_CFANRepay_Due_Today_Amt.InnerText = "₦" + String.Format("{0:#,#.00}", drx.Item("Loan_Repay_Due_Today_amt"))

    '            Else
    '                Me.lbl_CFANRepay_Due_Today_Amt.InnerText = "₦" + Repay_CFANdue_today_Amt.ToString
    '            End If


    '            Exit Sub
    '        End If


    '    Catch ex As Exception
    '        logger.Info("DASHBOARD.aspx: Get_Dashboard_Data'" _
    '       & vbNewLine & "   <<<<Direction: OUTPUT" _
    '       & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
    '       & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
    '       & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
    '       & vbNewLine & "*******************************************************************************************************************************************************************")
    '    End Try

    'End Sub



    '<WebMethod()>
    'Public Shared Function GetPieChart() As String

    '    Dim constr As String = ConfigurationManager.ConnectionStrings("Prime").ConnectionString
    '    Using con As New SqlConnection(constr)
    '        Dim query As String = "select case isnull(sex,0) when 1 then 'Male' when 2 then 'Female' when 0 then 'Not Available' else 'Corporate Entity' end as Gender,  count (isnull(sex,0)) [Count]   from tbl_customer with(nolock) where nodE_id = " & NodeId & "group by sex "
    '        '' Dim query As String = String.Format("Select shipcity, count(orderid) from orders where shipcountry = '{0}' group by shipcity", country)
    '        Using cmd As New SqlCommand()
    '            cmd.CommandText = query
    '            cmd.CommandType = CommandType.Text
    '            cmd.Connection = con
    '            con.Open()
    '            Using sdr As SqlDataReader = cmd.ExecuteReader()
    '                Dim sb As New StringBuilder()
    '                sb.Append("[")
    '                While sdr.Read()
    '                    sb.Append("{")
    '                    System.Threading.Thread.Sleep(50)
    '                    Dim color As String = [String].Format("#{0:X6}", New Random().Next(&H1000000))
    '                    sb.Append(String.Format("text :'{0}', value:{1}, color: '{2}',label: '{3}', highlight: '{4}'", sdr(0), sdr(1), color, sdr(0), color))
    '                    sb.Append("},")
    '                End While
    '                sb = sb.Remove(sb.Length - 1, 1)
    '                sb.Append("]")
    '                con.Close()
    '                Return sb.ToString()
    '            End Using
    '        End Using
    '    End Using
    'End Function
    '<WebMethod()>
    'Public Shared Function GetPaymentChartDataMonth3() As List(Of Object)
    '    'Dim query As String = "SELECT ShipCity, COUNT(orderid) TotalOrders"
    '    'query += " FROM Orders WHERE ShipCountry = 'USA' GROUP BY ShipCity"
    '    '' Dim query As String = "select  convert(char,getdate(),106) 'Date', isnull(sum (isnull(Payment_Amt,0)),0) 'Amount'  from Tbl_UCP_PaymentLog with(nolock) where ltrim(rtrim(Status))  in  ('00' , '01') and pay_type='Coop_Signup_Reg_Fee'union all select  convert(char,getdate(),106) 'Date', isnull(sum (isnull(Fee_Amt,0)),0) 'Amount'  from Tbl_UCP_PaymentLog with(nolock) where ltrim(rtrim(Status))  in  ('00' , '01') "
    '    Dim query As String = "exec FetchSubscriptionDashMonth 11"
    '    Dim constr As String = ConfigurationManager.ConnectionStrings("Prime").ConnectionString
    '    Dim chartData As New List(Of Object)()
    '    chartData.Add(New Object() {"PaymentDate", "RevenueAmt"})
    '    Using con As New SqlConnection(constr)
    '        Using cmd As New SqlCommand(query)
    '            cmd.CommandType = CommandType.Text
    '            cmd.Connection = con
    '            con.Open()
    '            Using sdr As SqlDataReader = cmd.ExecuteReader()
    '                While sdr.Read()
    '                    chartData.Add(New Object() {sdr("PaymentDate"), sdr("RevenueAmt")})

    '                End While
    '            End Using
    '            con.Close()
    '            Return chartData
    '        End Using
    '    End Using
    'End Function
    '<WebMethod()>
    'Public Shared Function GetPaymentChartDataMonth2() As List(Of Object)
    '    'Dim query As String = "SELECT ShipCity, COUNT(orderid) TotalOrders"
    '    'query += " FROM Orders WHERE ShipCountry = 'USA' GROUP BY ShipCity"
    '    '' Dim query As String = "select  convert(char,getdate(),106) 'Date', isnull(sum (isnull(Payment_Amt,0)),0) 'Amount'  from Tbl_UCP_PaymentLog with(nolock) where ltrim(rtrim(Status))  in  ('00' , '01') and pay_type='Coop_Signup_Reg_Fee'union all select  convert(char,getdate(),106) 'Date', isnull(sum (isnull(Fee_Amt,0)),0) 'Amount'  from Tbl_UCP_PaymentLog with(nolock) where ltrim(rtrim(Status))  in  ('00' , '01') "
    '    Dim query As String = "exec FetchSubscriptionDashMonth 5"
    '    Dim constr As String = ConfigurationManager.ConnectionStrings("Prime").ConnectionString
    '    Dim chartData As New List(Of Object)()
    '    chartData.Add(New Object() {"PaymentDate", "RevenueAmt"})
    '    Using con As New SqlConnection(constr)
    '        Using cmd As New SqlCommand(query)
    '            cmd.CommandType = CommandType.Text
    '            cmd.Connection = con
    '            con.Open()
    '            Using sdr As SqlDataReader = cmd.ExecuteReader()
    '                While sdr.Read()
    '                    chartData.Add(New Object() {sdr("PaymentDate"), sdr("RevenueAmt")})

    '                End While
    '            End Using
    '            con.Close()
    '            Return chartData
    '        End Using
    '    End Using
    'End Function
    '<WebMethod()>
    'Public Shared Function GetPaymentChartDataMonth() As List(Of Object)
    '    'Dim query As String = "SELECT ShipCity, COUNT(orderid) TotalOrders"
    '    'query += " FROM Orders WHERE ShipCountry = 'USA' GROUP BY ShipCity"
    '    '' Dim query As String = "select  convert(char,getdate(),106) 'Date', isnull(sum (isnull(Payment_Amt,0)),0) 'Amount'  from Tbl_UCP_PaymentLog with(nolock) where ltrim(rtrim(Status))  in  ('00' , '01') and pay_type='Coop_Signup_Reg_Fee'union all select  convert(char,getdate(),106) 'Date', isnull(sum (isnull(Fee_Amt,0)),0) 'Amount'  from Tbl_UCP_PaymentLog with(nolock) where ltrim(rtrim(Status))  in  ('00' , '01') "
    '    Dim query As String = "exec FetchSubscriptionDashMonth 2"
    '    Dim constr As String = ConfigurationManager.ConnectionStrings("Prime").ConnectionString
    '    Dim chartData As New List(Of Object)()
    '    chartData.Add(New Object() {"PaymentDate", "RevenueAmt"})
    '    Using con As New SqlConnection(constr)
    '        Using cmd As New SqlCommand(query)
    '            cmd.CommandType = CommandType.Text
    '            cmd.Connection = con
    '            con.Open()
    '            Using sdr As SqlDataReader = cmd.ExecuteReader()
    '                While sdr.Read()
    '                    chartData.Add(New Object() {sdr("PaymentDate"), sdr("RevenueAmt")})

    '                End While
    '            End Using
    '            con.Close()
    '            Return chartData
    '        End Using
    '    End Using
    'End Function
    '<WebMethod()>
    'Public Shared Function GetPaymentChartDataWeek() As List(Of Object)
    '    'Dim query As String = "SELECT ShipCity, COUNT(orderid) TotalOrders"
    '    'query += " FROM Orders WHERE ShipCountry = 'USA' GROUP BY ShipCity"
    '    '' Dim query As String = "select  convert(char,getdate(),106) 'Date', isnull(sum (isnull(Payment_Amt,0)),0) 'Amount'  from Tbl_UCP_PaymentLog with(nolock) where ltrim(rtrim(Status))  in  ('00' , '01') and pay_type='Coop_Signup_Reg_Fee'union all select  convert(char,getdate(),106) 'Date', isnull(sum (isnull(Fee_Amt,0)),0) 'Amount'  from Tbl_UCP_PaymentLog with(nolock) where ltrim(rtrim(Status))  in  ('00' , '01') "
    '    Dim query As String = "exec FetchSubscriptionDash 30"
    '    Dim constr As String = ConfigurationManager.ConnectionStrings("Prime").ConnectionString
    '    Dim chartData As New List(Of Object)()
    '    chartData.Add(New Object() {"PaymentDate", "RevenueAmt"})
    '    Using con As New SqlConnection(constr)
    '        Using cmd As New SqlCommand(query)
    '            cmd.CommandType = CommandType.Text
    '            cmd.Connection = con
    '            con.Open()
    '            Using sdr As SqlDataReader = cmd.ExecuteReader()
    '                While sdr.Read()
    '                    chartData.Add(New Object() {sdr("PaymentDate"), sdr("RevenueAmt")})

    '                End While
    '            End Using
    '            con.Close()
    '            Return chartData
    '        End Using
    '    End Using
    'End Function
    '<WebMethod()>
    'Public Shared Function GetPaymentChartData() As List(Of Object)
    '    'Dim query As String = "SELECT ShipCity, COUNT(orderid) TotalOrders"
    '    'query += " FROM Orders WHERE ShipCountry = 'USA' GROUP BY ShipCity"
    '    '' Dim query As String = "select  convert(char,getdate(),106) 'Date', isnull(sum (isnull(Payment_Amt,0)),0) 'Amount'  from Tbl_UCP_PaymentLog with(nolock) where ltrim(rtrim(Status))  in  ('00' , '01') and pay_type='Coop_Signup_Reg_Fee'union all select  convert(char,getdate(),106) 'Date', isnull(sum (isnull(Fee_Amt,0)),0) 'Amount'  from Tbl_UCP_PaymentLog with(nolock) where ltrim(rtrim(Status))  in  ('00' , '01') "
    '    Dim query As String = "select  'Subscription' 'Date', isnull(sum (isnull(Payment_Amt,0)),0) 'Amount'  from Tbl_UCP_PaymentLog with(nolock) where ltrim(rtrim(Status))  in  ('00' , '01', 'MP') and pay_type='Coop_Signup_Reg_Fee'union all select  'Fees' 'Date', isnull(sum (isnull(Fee_Amt,0)),0) 'Amount'  from Tbl_UCP_PaymentLog with(nolock) where ltrim(rtrim(Status))  in  ('00' , '01') "
    '    Dim constr As String = ConfigurationManager.ConnectionStrings("Prime").ConnectionString
    '    Dim chartData As New List(Of Object)()
    '    chartData.Add(New Object() {"Date", "Amount"})
    '    Using con As New SqlConnection(constr)
    '        Using cmd As New SqlCommand(query)
    '            cmd.CommandType = CommandType.Text
    '            cmd.Connection = con
    '            con.Open()
    '            Using sdr As SqlDataReader = cmd.ExecuteReader()
    '                While sdr.Read()
    '                    chartData.Add(New Object() {sdr("Date"), sdr("Amount")})

    '                End While
    '            End Using
    '            con.Close()
    '            Return chartData
    '        End Using
    '    End Using
    'End Function
    '<WebMethod()>
    'Public Shared Function GetChartData() As List(Of Object)
    '    'Dim query As String = "SELECT ShipCity, COUNT(orderid) TotalOrders"
    '    'query += " FROM Orders WHERE ShipCountry = 'USA' GROUP BY ShipCity"
    '    Dim query As String = "select productname, sum(bkbalance) Monthlycontribution from tbl_bankproduct a with(nolock), tbl_bankgl b with(nolock) where a.liabilityBal = substring(b.GLNumber,4,14) and a. node_id = " & NodeId & "and b.node_id = " & NodeId & " and productclass= 1 group by productname,BKBalance "
    '    Dim constr As String = ConfigurationManager.ConnectionStrings("Prime").ConnectionString
    '    Dim chartData As New List(Of Object)()
    '    chartData.Add(New Object() {"productname", "Monthlycontribution"})
    '    Using con As New SqlConnection(constr)
    '        Using cmd As New SqlCommand(query)
    '            cmd.CommandType = CommandType.Text
    '            cmd.Connection = con
    '            con.Open()
    '            Using sdr As SqlDataReader = cmd.ExecuteReader()
    '                While sdr.Read()
    '                    chartData.Add(New Object() {sdr("productname"), sdr("Monthlycontribution")})
    '                End While
    '            End Using
    '            con.Close()
    '            Return chartData
    '        End Using
    '    End Using
    'End Function
    '<WebMethod()>
    'Public Shared Function GetBarChartProduct() As String

    '    Dim constr As String = ConfigurationManager.ConnectionStrings("Prime").ConnectionString
    '    Using con As New SqlConnection(constr)
    '        Dim query As String = "select productname, sum(bkbalance) Monthlycontribution from tbl_bankproduct a with(nolock), tbl_bankgl b with(nolock) where a.liabilityBal = substring(b.GLNumber,4,14) and a. node_id = " & NodeId & "and b.node_id = " & NodeId & " and productclass= 1 group by productname,BKBalance "
    '        '' Dim query As String = String.Format("Select shipcity, count(orderid) from orders where shipcountry = '{0}' group by shipcity", country)
    '        Using cmd As New SqlCommand()
    '            cmd.CommandText = query
    '            cmd.CommandType = CommandType.Text
    '            cmd.Connection = con
    '            con.Open()
    '            Using sdr As SqlDataReader = cmd.ExecuteReader()
    '                Dim sb As New StringBuilder()
    '                sb.Append("[")
    '                While sdr.Read()
    '                    sb.Append("{")
    '                    System.Threading.Thread.Sleep(50)
    '                    Dim color As String = [String].Format("#{0:X6}", New Random().Next(&H1000000))
    '                    sb.Append(String.Format("text :'{0}', value:{1}, color: '{2}'", sdr(0), sdr(1), color))
    '                    sb.Append("},")
    '                End While
    '                sb = sb.Remove(sb.Length - 1, 1)
    '                sb.Append("]")
    '                con.Close()
    '                Return sb.ToString()
    '            End Using
    '        End Using
    '    End Using
    'End Function
    'Protected Sub DropDowwn_PaymentChart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDowwn_PaymentChart.SelectedIndexChanged
    '    If Me.DropDowwn_PaymentChart.SelectedValue = 1 Then
    '        PanelToday.Visible = True
    '        Panel30Days.Visible = False
    '    ElseIf Me.DropDowwn_PaymentChart.SelectedValue = 2 Then
    '        PanelToday.Visible = False
    '        Panel30Days.Visible = True
    '    ElseIf Me.DropDowwn_PaymentChart.SelectedValue = 3 Then
    '        PanelToday.Visible = True
    '        Panel30Days.Visible = False
    '    Else
    '        PanelToday.Visible = True
    '        Panel30Days.Visible = False
    '    End If
    'End Sub
End Class
