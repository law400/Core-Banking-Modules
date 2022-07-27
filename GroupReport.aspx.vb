
Partial Class Reports_GroupReport
    Inherits System.Web.UI.Page
    Sub disablepanell()
        Me.panel1.Visible = False
        Me.panel2.Visible = False
        Me.panel3.Visible = False
        Me.panel4.Visible = False
        Me.panel5.Visible = False
        Me.panel6.Visible = False
        Me.panel7.Visible = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim l As Literal = CType(Page.Master.FindControl("Label3"), Literal)
        'l.Text = "REPORTS"
        'Dim ll As Literal = CType(Page.Master.FindControl("LitMenuTitle"), Literal)
        'll.Text = "->" & Request.QueryString("menu")
        'Page.Header.Title = ll.Text.Trim
        Dim dr40 As Data.DataRow
        If Page.IsPostBack = False Then

            If Session("logrpt") = "" Then
                Session("logrpt") = Profile.Userid.Trim
            End If

            If Profile.Userid = "" Then
                Profile.Userid = Session("logrpt")
            End If

            'Me.LinkButton10.Visible = False
            'Me.LinkButton46.Visible = False

            disablepanell()

            Dim replist As String = "Exec proc_Rolereport '" & Profile.Roleid & "'"
            For Each dr40 In con.SqlDs(replist).Tables(0).Rows
                Dim reportid As String = dr40.Item(0).ToString

                If reportid = "1" Then
                    Me.panel1.Visible = True
                ElseIf reportid = "2" Then
                    Me.panel2.Visible = True
                ElseIf reportid = "3" Then
                    Me.panel3.Visible = True
                ElseIf reportid = "4" Then
                    Me.panel4.Visible = True
                ElseIf reportid = "5" Then
                    Me.panel5.Visible = True
                ElseIf reportid = "6" Then
                    Me.panel6.Visible = True
                ElseIf reportid = "7" Then
                    Me.panel7.Visible = True
                End If

            Next

        End If

    End Sub
    Protected Sub Int1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int1.Click
        Response.Redirect("Statement.aspx")
    End Sub
    Protected Sub csa1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Csa1.Click
        Response.Redirect("Statement.aspx")
    End Sub
    Protected Sub lnkop1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkOp1.Click
        Response.Redirect("Statement.aspx")
    End Sub
    Protected Sub fin1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin1.Click
        Response.Redirect("Statement.aspx")
    End Sub
    Protected Sub mis1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis1.Click
        Response.Redirect("Statement.aspx")
    End Sub
    Protected Sub Int2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int2.Click
        Response.Redirect("Customerbalance.aspx")
    End Sub
    Protected Sub lnkop2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkOp2.Click
        Response.Redirect("Customerbalance.aspx")
    End Sub
    Protected Sub csa2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csa2.Click
        Response.Redirect("Customerbalance.aspx")
    End Sub
    Protected Sub fin2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin2.Click
        Response.Redirect("Customerbalance.aspx")
    End Sub

    Protected Sub mis2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis2.Click
        Response.Redirect("Customerbalance.aspx")
    End Sub
    Protected Sub Int3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int3.Click
        Response.Redirect("AccountOpening.aspx")
    End Sub
    Protected Sub csa3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csa3.Click
        Response.Redirect("AccountOpening.aspx")
    End Sub
    Protected Sub Int4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int4.Click
        Response.Redirect("Cabal.aspx")
    End Sub
    Protected Sub lnk2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnk2.Click
        Response.Redirect("Cabal.aspx")
    End Sub
    Protected Sub lnk3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnk3.Click
        Response.Redirect("TellerSumm.aspx")
    End Sub
    Protected Sub lnk4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnk4.Click
        Response.Redirect("CustDetail.aspx")
    End Sub
    Protected Sub fin4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin4.Click
        Response.Redirect("Cabal.aspx")
    End Sub
    Protected Sub mis4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis4.Click
        Response.Redirect("Cabal.aspx")
    End Sub
    Protected Sub csa4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csa4.Click
        Response.Redirect("Cabal.aspx")
    End Sub
    Protected Sub Int5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int5.Click
        Response.Redirect("CustDetail.aspx")
    End Sub
    Protected Sub csa5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csa5.Click
        Response.Redirect("CustDetail.aspx")
    End Sub
    Protected Sub fin5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin5.Click
        Response.Redirect("CustDetail.aspx")
    End Sub
    Protected Sub mis5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis5.Click
        Response.Redirect("CustDetail.aspx")
    End Sub
    Protected Sub csa6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csa6.Click
        Response.Redirect("OfficerCust.aspx")
    End Sub
    Protected Sub Int6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int6.Click
        Response.Redirect("OfficerCust.aspx")
    End Sub
    Protected Sub Int7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int7.Click
        Response.Redirect("chequebookstatus.aspx")
    End Sub
    Protected Sub csa7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csa7.Click
        Response.Redirect("chequebookstatus.aspx")
    End Sub
    Protected Sub lnk5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnk5.Click
        Response.Redirect("chequebookstatus.aspx")
    End Sub
    Protected Sub Int8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int8.Click
        Response.Redirect("ChqStatus.aspx")
    End Sub
    Protected Sub csa8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csa8.Click
        Response.Redirect("ChqStatus.aspx")
    End Sub
    Protected Sub lnk6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnk6.Click
        Response.Redirect("ChqStatus.aspx")
    End Sub
    Protected Sub csa9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csa9.Click
        Response.Redirect("AccountDetail.aspx")
    End Sub
    Protected Sub Int9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int9.Click
        Response.Redirect("AccountDetail.aspx")
    End Sub
    Protected Sub lnk7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnk7.Click
        Response.Redirect("AccountDetail.aspx")
    End Sub
    Protected Sub csa10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csa10.Click
        Response.Redirect("HoldTran.aspx")
    End Sub
    Protected Sub Int10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int10.Click
        Response.Redirect("HoldTran.aspx")
    End Sub
    Protected Sub lnkop8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnkop8.Click
        Response.Redirect("HoldTran.aspx")
    End Sub
    Protected Sub Int11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int11.Click
        Response.Redirect("SITran.aspx")
    End Sub
    Protected Sub csa11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csa11.Click
        Response.Redirect("SITran.aspx")
    End Sub
    Protected Sub Int12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int12.Click
        Response.Redirect("Customerrate.aspx")
    End Sub
    Protected Sub fin3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin3.Click
        Response.Redirect("Customerrate.aspx")
    End Sub
    Protected Sub mis3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis3.Click
        Response.Redirect("Customerrate.aspx")
    End Sub
    Protected Sub csa12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csa12.Click
        Response.Redirect("Customerrate.aspx")
    End Sub
    Protected Sub lnkop10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnkop10.Click
        Response.Redirect("Customerrate.aspx")
    End Sub
    Protected Sub Int13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int13.Click
        Response.Redirect("rptmandate.aspx")
    End Sub
    Protected Sub Int14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int14.Click
        Response.Redirect("Dormant.aspx")
    End Sub
    Protected Sub lnkop9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkOp9.Click
        Response.Redirect("Dormant.aspx")
    End Sub
    Protected Sub Int15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int15.Click
        Response.Redirect("Activeacct.aspx")
    End Sub
    Protected Sub Int16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int16.Click
        Response.Redirect("Reactivated.aspx")
    End Sub
    Protected Sub csa13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csa13.Click
        Response.Redirect("rptmandate.aspx")
    End Sub
    Protected Sub csa14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csa14.Click
        Response.Redirect("Dormant.aspx")
    End Sub
    Protected Sub csa15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csa15.Click
        Response.Redirect("Activeacct.aspx")
    End Sub

    Protected Sub csa16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csa16.Click
        Response.Redirect("Reactivated.aspx")
    End Sub
    Protected Sub fin9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin9.Click
        Response.Redirect("Dormant.aspx")
    End Sub
    Protected Sub mis9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis9.Click
        Response.Redirect("Dormant.aspx")
    End Sub
    Protected Sub fin10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin10.Click
        Response.Redirect("Activeacct.aspx")
    End Sub
    Protected Sub fin11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin11.Click
        Response.Redirect("CasaInflow.aspx")
    End Sub
    Protected Sub fin12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin12.Click
        Response.Redirect("ConcessionList.aspx")
    End Sub
    Protected Sub mis10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis10.Click
        Response.Redirect("Activeacct.aspx")
    End Sub
    Protected Sub mis11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis11.Click
        Response.Redirect("CasaInflow.aspx")
    End Sub
    Protected Sub mis12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis12.Click
        Response.Redirect("ConcessionList.aspx")
    End Sub
    Protected Sub Int17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int17.Click
        Response.Redirect("ConcessionList.aspx")
    End Sub
    Protected Sub Int18_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int18.Click
        Response.Redirect("rptmaxacctno.aspx")
    End Sub
    Protected Sub Int19_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int19.Click
        Response.Redirect("ClearingItem.aspx")
    End Sub
    Protected Sub fin6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin6.Click
        Response.Redirect("ClearingItem.aspx")
    End Sub
    Protected Sub lnk12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnk12.Click
        Response.Redirect("ClearingItem.aspx")
    End Sub
    Protected Sub lnk13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnk13.Click
        Response.Redirect("PostingJournal.aspx")
    End Sub
    Protected Sub mis6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis6.Click
        Response.Redirect("ClearingItem.aspx")
    End Sub
    Protected Sub csa17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csa17.Click
        Response.Redirect("ConcessionList.aspx")
    End Sub
    Protected Sub csa18_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csa18.Click
        Response.Redirect("rptmaxacctno.aspx")
    End Sub
    Protected Sub fin8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin8.Click
        Response.Redirect("rptmaxacctno.aspx")
    End Sub
    Protected Sub mis8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis8.Click
        Response.Redirect("rptmaxacctno.aspx")
    End Sub
    Protected Sub csa19_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csa19.Click
        Response.Redirect("ClearingItem.aspx")
    End Sub
    Protected Sub csa99_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csa99.Click
        Response.Redirect("RptAccountTier.aspx")
    End Sub
    Protected Sub Int20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int20.Click
        Response.Redirect("Turnover.aspx")
    End Sub
    Protected Sub fin7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin7.Click
        Response.Redirect("Turnover.aspx")
    End Sub
    Protected Sub Int21_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int21.Click
        Response.Redirect("PostingJournal.aspx")
    End Sub
    Protected Sub Int22_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int22.Click
        Response.Redirect("Backposting.aspx")
    End Sub
    Protected Sub lnk11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnk11.Click
        '' Response.Redirect("Inoutflow.aspx")
        Response.Redirect("CasaInflow.aspx")

    End Sub
    Protected Sub Int23_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int23.Click
        ''Response.Redirect("Inoutflow.aspx")
        Response.Redirect("CasaInflow.aspx")

    End Sub
    Protected Sub Int24_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int24.Click
        Response.Redirect("Withholdingtax.aspx")
    End Sub
    Protected Sub Int25_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int25.Click
        Response.Redirect("rptbatchpostingbydate.aspx")
    End Sub

    Protected Sub Int26_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int26.Click
        Response.Redirect("Averagebalance.aspx")
    End Sub
    Protected Sub fin14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin14.Click
        Response.Redirect("Averagebalance.aspx")
    End Sub
    Protected Sub mis14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis14.Click
        Response.Redirect("Averagebalance.aspx")
    End Sub
    Protected Sub Int27_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int27.Click
        Response.Redirect("Cashsummary.aspx")
    End Sub
  
    Protected Sub Int28_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int28.Click
        Response.Redirect("Callover.aspx")
    End Sub
    Protected Sub Int29_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int29.Click
        Response.Redirect("AcMovementRpt.aspx")
    End Sub
    Protected Sub Int30_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int30.Click
        Response.Redirect("AccountStatistic.aspx")
    End Sub
    Protected Sub fin15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin15.Click
        Response.Redirect("AccountStatistic.aspx")
    End Sub
    Protected Sub fin18_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin18.Click
        Response.Redirect("Officerperf.aspx")
    End Sub
    Protected Sub mis15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis15.Click
        Response.Redirect("AccountStatistic.aspx")
    End Sub
    Protected Sub mis18_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis18.Click
        Response.Redirect("Officerperf.aspx")
    End Sub
    Protected Sub Int31_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int31.Click
        Response.Redirect("amortiseitem.aspx")
    End Sub
    Protected Sub Int32_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int32.Click
        '  Response.Redirect("Fixedasset.aspx")
    End Sub
    'Protected Sub Int33_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int33.Click
    '    ' Response.Redirect("vaultlist.aspx")
    'End Sub
    'Protected Sub Int34_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int34.Click
    '    ' Response.Redirect("withdrawuncleared.aspx")
    'End Sub
    Protected Sub Int35_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int35.Click
        Response.Redirect("counterchq.aspx")
    End Sub
    Protected Sub Int36_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int36.Click
        Response.Redirect("TellerSumm.aspx")
    End Sub
    'Protected Sub Int37_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int37.Click
    '    Response.Redirect("AccountProfitability.aspx")
    'End Sub
    Protected Sub Int38_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int38.Click
        Response.Redirect("officerperf.aspx")
    End Sub
    Protected Sub fin16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin16.Click
        Response.Redirect("perfAnalysis.aspx")
    End Sub
    Protected Sub fin17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin17.Click
        Response.Redirect("Productsummary.aspx")
    End Sub
    Protected Sub mis16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis16.Click
        Response.Redirect("perfAnalysis.aspx")
    End Sub
    Protected Sub mis17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis17.Click
        Response.Redirect("Productsummary.aspx")
    End Sub
    Protected Sub Int39_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int39.Click
        Response.Redirect("RptStaffList.aspx")
    End Sub
    Protected Sub Int40_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int40.Click
        Response.Redirect("authtrans.aspx")
    End Sub
    Protected Sub fin19_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin19.Click
        Response.Redirect("RptStaffList.aspx")
    End Sub
    Protected Sub fin20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin20.Click
        Response.Redirect("authtrans.aspx")
    End Sub
    Protected Sub mis19_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis19.Click
        Response.Redirect("RptStaffList.aspx")
    End Sub
    Protected Sub mis20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis20.Click
        Response.Redirect("authtrans.aspx")
    End Sub
    Protected Sub Int41_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int41.Click
        Response.Redirect("TrialBalanceMove.aspx")
    End Sub
    Protected Sub Int42_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int42.Click
        Response.Redirect("TrialBalanceMaster.aspx")
    End Sub
    Protected Sub Int43_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int43.Click
        Response.Redirect("Consolidated.aspx")
    End Sub
    Protected Sub Int44_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int44.Click
        Response.Redirect("Consolidated2.aspx")
    End Sub
    Protected Sub Int45_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int45.Click
        Response.Redirect("Overdraft.aspx")
    End Sub
    Protected Sub Fin21_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin21.Click
        Response.Redirect("TrialBalanceMove.aspx")
    End Sub
    Protected Sub Fin22_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin22.Click
        Response.Redirect("TrialBalanceMaster.aspx")
    End Sub
    Protected Sub Fin23_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin23.Click
        Response.Redirect("Consolidated.aspx")
    End Sub
    Protected Sub Fin24_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin24.Click
        Response.Redirect("Consolidated2.aspx")
    End Sub
    Protected Sub Fin25_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin25.Click
        Response.Redirect("Overdraft.aspx")
    End Sub
    Protected Sub Mis21_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis21.Click
        Response.Redirect("TrialBalanceMove.aspx")
    End Sub
    Protected Sub Mis22_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis22.Click
        Response.Redirect("TrialBalanceMaster.aspx")
    End Sub
    Protected Sub Mis23_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis23.Click
        Response.Redirect("Consolidated.aspx")
    End Sub
    Protected Sub Mis24_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis24.Click
        Response.Redirect("Consolidated2.aspx")
    End Sub
    Protected Sub Mis25_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis25.Click
        Response.Redirect("Overdraft.aspx")
    End Sub
    Protected Sub Int46_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int46.Click
        Response.Redirect("PandL2.aspx")
    End Sub
    Protected Sub Int47_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int47.Click
        Response.Redirect("BalanceSheet2.aspx")
    End Sub
    Protected Sub Int48_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int48.Click
        Response.Redirect("Risksummary.aspx")
    End Sub
    Protected Sub Int49_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int49.Click
        Response.Redirect("TDSummary.aspx")
    End Sub
    Protected Sub Int50_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int50.Click
        Response.Redirect("accrualHistory.aspx")
    End Sub
    Protected Sub Fin26_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin26.Click
        Response.Redirect("PandL2.aspx")
    End Sub
    Protected Sub Fin27_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin27.Click
        Response.Redirect("BalanceSheet2.aspx")
    End Sub
    Protected Sub Fin28_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin28.Click
        Response.Redirect("Risksummary.aspx")
    End Sub
    Protected Sub Fin29_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin29.Click
        Response.Redirect("TDSummary.aspx")
    End Sub
    Protected Sub Fin30_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin30.Click
        Response.Redirect("AccrualHistory.aspx")
    End Sub

    Protected Sub Mis26_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis26.Click
        Response.Redirect("PandL2.aspx")
    End Sub
    Protected Sub Mis27_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis27.Click
        Response.Redirect("BalanceSheet2.aspx")
    End Sub
    Protected Sub Mis28_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis28.Click
        Response.Redirect("Risksummary.aspx")
    End Sub
    Protected Sub Mis29_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis29.Click
        Response.Redirect("TDSummary.aspx")
    End Sub
    Protected Sub Mis30_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis30.Click
        Response.Redirect("accrualHistory.aspx")
    End Sub
    Protected Sub Int51_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int51.Click
        Response.Redirect("Perfanalysis.aspx")
    End Sub
    Protected Sub Int52_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int52.Click
        Response.Redirect("Productsummary.aspx")
    End Sub
    Protected Sub Int53_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int53.Click
        Response.Redirect("Loanschedule.aspx")
    End Sub
    Protected Sub Int54_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int54.Click
        Response.Redirect("DealCert.aspx")
    End Sub
    'Protected Sub Int55_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int55.Click
    '    Response.Redirect("GapAnalysis.aspx")
    'End Sub
    Protected Sub Int56_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int56.Click
        Response.Redirect("RptOutstandingloans.aspx")
    End Sub
    Protected Sub Int57_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int57.Click
        Response.Redirect("rptloandisstat.aspx")
    End Sub
    'Protected Sub Int58_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int58.Click
    '    Response.Redirect("RptLoansopened.aspx")
    'End Sub
    'Protected Sub Int60_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int60.Click
    '    Response.Redirect("RiskClassification.aspx")
    'End Sub
    Protected Sub Int66_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int66.Click
        Response.Redirect("RptAccountUnfunded.aspx")
    End Sub
    Protected Sub Fin31_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin31.Click
        Response.Redirect("RptOutstandingloans.aspx")
    End Sub
    Protected Sub Fin32_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin32.Click
        Response.Redirect("rptloandisstat.aspx")
    End Sub

    'Protected Sub Fin33_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin33.Click
    '    Response.Redirect("RptLoansopened.aspx")
    'End Sub

    'Protected Sub Fin34_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin34.Click
    '    Response.Redirect("FacilityAgging.aspx")
    'End Sub

    'Protected Sub Fin35_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin35.Click
    '    Response.Redirect("RiskClassification.aspx")
    'End Sub

    Protected Sub Int61_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int61.Click
        Response.Redirect("RiskClassification.aspx")
    End Sub

    Protected Sub Int62_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int62.Click
        Response.Redirect("Efas.aspx")
    End Sub

    Protected Sub Fin36_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin36.Click
        'LinkButton50.Attributes.Add("onclick", "window.open('./DemoRpt/Customer_statement.mhtml')")
        Response.Redirect("ChartOfAccount.aspx")
    End Sub

    Protected Sub int65_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles int65.Click
        'LinkButton50.Attributes.Add("onclick", "window.open('./DemoRpt/Customer_statement.mhtml')")
        Response.Redirect("ChartOfAccount.aspx")
    End Sub
    Protected Sub it3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IT3.Click
        'LinkButton50.Attributes.Add("onclick", "window.open('./DemoRpt/Customer_statement.mhtml')")
        Response.Redirect("AuditLog.aspx")
    End Sub

    Protected Sub it2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IT2.Click
        Response.Redirect("Tracker.aspx")
    End Sub
    Protected Sub it99_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IT99.Click
        Response.Redirect("RptUserStatus.aspx")
    End Sub
    Protected Sub lnk69_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnk69.Click
        Response.Redirect("creditbureau.aspx")
    End Sub

    Protected Sub it1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IT1.Click
        Response.Redirect("setup.aspx")
    End Sub

    'Protected Sub LinkButton11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton11.Click
    '    Try
    '        Response.Redirect("NDICList.aspx")
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub btnreturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnreturn.Click
        Profile.Userid = Session("logrpt")
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub LinkButton71_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton71.Click
        Response.Redirect("PeriodicTrialBal.aspx")
    End Sub

    Protected Sub LinkButton72_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton72.Click
        Response.Redirect("PeriodicTrialBalConsolid.aspx")
    End Sub

    'Protected Sub Fin37_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin37.Click
    '    Response.Redirect("LoanByGroup.aspx")
    'End Sub

    Protected Sub int67_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles int67.Click
        Response.Redirect("LoanByGroup.aspx")
    End Sub
    Protected Sub int68_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles int67.Click
        Response.Redirect("LoanscheduleAll.aspx")
    End Sub
    Protected Sub Fin38_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin38.Click
        Response.Redirect("LoanscheduleAll.aspx")
    End Sub
    Protected Sub Lnk68_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnk68.Click
        Response.Redirect("LoanscheduleAll.aspx")
    End Sub
    Protected Sub Mis31_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis31.Click
        Response.Redirect("LoanscheduleAll.aspx")
    End Sub
    Protected Sub Fin33_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin33.Click
        Response.Redirect("Loanpaydue.aspx")
    End Sub
    Protected Sub Fin34_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin34.Click
        Response.Redirect("loanbalance.aspx")
    End Sub
    Protected Sub Fin13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin13.Click
        Response.Redirect("cashsummary.aspx")
    End Sub
    Protected Sub Mis13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mis13.Click
        Response.Redirect("cashsummary.aspx")
    End Sub
   
    Protected Sub int58_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int58.Click
        Response.Redirect("Loanpaydue.aspx")
    End Sub
    Protected Sub int59_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int59.Click
        Response.Redirect("loanbalance.aspx")
    End Sub

    Protected Sub LinkButton73_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton73.Click
        Response.Redirect("sbu.aspx")

    End Sub

    Protected Sub Lnkperiod1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnkperiod1.Click
        Response.Redirect("TrialbalCallover.aspx")
    End Sub
    Protected Sub Lnkperiod2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkperiod2.Click
        Response.Redirect("TrialbalCallover2.aspx")
    End Sub

    Protected Sub Lnkperiod3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkperiod3.Click
        Response.Redirect("GLBreakDown.aspx")
    End Sub


    Protected Sub lnkmanage1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkmanage1.Click
        Response.Redirect("Incomebreakdown.aspx")
    End Sub

 
    Protected Sub Fin39_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin39.Click
        Response.Redirect("LoanRepaymentdue.aspx")
    End Sub

    Protected Sub Fin40_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin40.Click
        Response.Redirect("LoanPastdue.aspx")
    End Sub

    Protected Sub Lnk70_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnk70.Click
        Response.Redirect("LoanRepaymentdue.aspx")
    End Sub

    Protected Sub lnkmanage2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkmanage2.Click
        Response.Redirect("CustomBLPL.aspx")
    End Sub
    Protected Sub lnk71_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnk71.Click
        Response.Redirect("PAR.aspx")
    End Sub
    Protected Sub lnk72_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnk72.Click
        Response.Redirect("PARAgeingReport.aspx")
    End Sub
    Protected Sub lnk73_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnk73.Click
        Response.Redirect("Detailageing1.aspx")
    End Sub
    Protected Sub lnk74_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnk74.Click
        Response.Redirect("Loancustomer.aspx")
    End Sub
    ''Detailageing1.aspx

    Protected Sub Int63_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Int63.Click
        Response.Redirect("NDLEA.aspx")
    End Sub

    Protected Sub IT4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IT4.Click
        Response.Redirect("Audit.aspx")
    End Sub

    Protected Sub balancesheet1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles balancesheet1.Click
        Response.Redirect("BalanceSheetMapped.aspx")
    End Sub

    Protected Sub ProfitLoss_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProfitLoss.Click
        Response.Redirect("PandLMapped.aspx")
    End Sub

    Protected Sub csa20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles csa20.Click
        Response.Redirect("OldNew.aspx")
    End Sub

    Protected Sub Fin41_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Fin41.Click
        Response.Redirect("RptLoanAccrual.aspx")
    End Sub

    Protected Sub Lnk75_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lnk75.Click
        Response.Redirect("RptLoanAccrual.aspx")
    End Sub
End Class
