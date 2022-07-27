<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GroupReport.aspx.vb" Inherits="Reports_GroupReport" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css"/>
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css"/>
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css"/>
    <!-- Theme style -->
     <link rel="stylesheet" href="dist/font-awesome.min.css"/>
    <!-- Ionicons -->
    <link rel="stylesheet" href="dist/ionicons.min.css"/>
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css"/>
    <!-- AdminLTE Skins. Choose a skin from the css/skins
         folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="dist/css/skins/_all-skins.min.css"/>
    <!-- iCheck -->
    <link rel="stylesheet" href="plugins/iCheck/flat/blue.css"/>
   
    <!-- jvectormap -->
    <link rel="stylesheet" href="plugins/jvectormap/jquery-jvectormap-1.2.2.css"/>
    <!-- Date Picker -->
    <link rel="stylesheet" href="plugins/datepicker/datepicker3.css"/>
    <!-- Daterange picker -->
    <link rel="stylesheet" href="plugins/daterangepicker/daterangepicker-bs3.css"/>
    <!-- bootstrap wysihtml5 - text editor -->
    <link rel="stylesheet" href="plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   <%-- <telerik:RadComboBox ID="RadComboBox2" runat="server" Width="250px" Height="150px"
                EmptyMessage="Select a Company" EnableLoadOnDemand="True" ShowMoreResultsBox="true"
                EnableVirtualScrolling="true" OnItemsRequested="RadComboBox2_ItemsRequested">
            </telerik:RadComboBox>--%>

          <asp:Button ID="btnreturn" runat="server" Text="Return" />
        <br />

          <br />
<%-- <asp:LinqDataSource runat="server" ID="LinqDataSource1" ContextTypeName="LinqToSql.NorthwindDataContext"
 OrderBy="Accounttitle" Select="new (Accounttitle,AccounNumber)" TableName="tbl_casaaccount">
    </asp:LinqDataSource>--%>

  <!-- START ACCORDION & CAROUSEL-->
          <h2 class="page-header">Bootstrap Accordion & Carousel</h2>
          <div class="row">
            <div class="col-md-10">
              <div class="box box-solid">
                <div class="box-header with-border">
                  <h3 class="box-title">Group Report</h3>
                </div><!-- /.box-header -->
                <div class="box-body">
                  <div class="box-group" id="accordion">
                    <!-- we are adding the .panel class so bootstrap.js collapse plugin detects it -->
                    <div class="panel box box-primary">
                      <div class="box-header with-border">
                        <h4 class="box-title">
                          <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">
                            Member Service Report
                          </a>
                        </h4>
                      </div>
                      <div id="collapseOne" class="panel-collapse collapse in">
                        <div class="box-body">
                         <asp:Panel ID="panel1" runat="server" Width="900px" Height="150px">
        <table style="width: 864px; height: 45px; font-size: small; font-family: Verdana;">
            <tr>
                <td>
                    <asp:LinkButton ID="Csa1" runat="server" Font-Size="Small" Width="84px">Statement</asp:LinkButton>
                </td>
                <td >
                    <asp:LinkButton ID="csa2" runat="server" Font-Size="Small" 
                        Width="131px">Account Enquiry</asp:LinkButton>
                </td>
               
                <td >
                    <asp:LinkButton ID="csa3" runat="server" Font-Size="Small">Account Opened 
                    </asp:LinkButton>
                </td>
                <td >
                     <asp:LinkButton ID="csa4" runat="server" Font-Size="Small" 
                        Width="124px">Member Balance</asp:LinkButton>
                         </td>
                <td style="width: 100px; height: 25px">
                 <asp:LinkButton ID="csa5" runat="server" Width="118px">Member Enquiry</asp:LinkButton>
</td>
            </tr>
            <tr>
                <td >
                                     <asp:LinkButton ID="csa6" runat="server" Width="140px">Officer 
                    Performance</asp:LinkButton>
                </td>
                <td >
               <asp:LinkButton ID="csa7" runat="server" Width="139px">Cheque Book Status</asp:LinkButton>

                </td>
               
                <td >
                                  <asp:LinkButton ID="csa8" runat="server" Width="118px">Check Book List</asp:LinkButton>
                </td>
                <td >
                                  <asp:LinkButton ID="csa9" runat="server" Width="118px">Member Detail</asp:LinkButton>
                         </td>
                <td style="width: 100px; height: 25px">
                                  <asp:LinkButton ID="csa10" runat="server" Width="118px">Account Hold</asp:LinkButton>
</td>
            </tr>
            <tr>
                <td >
                                  <asp:LinkButton ID="csa11" runat="server" Width="118px">Standing 
                    Order</asp:LinkButton>

</td>
                <td >
                                  <asp:LinkButton ID="csa12" runat="server" Width="118px" Height="16px">Account 
                                  Rate</asp:LinkButton>
</td>
                <td >
                                  <asp:LinkButton ID="csa13" runat="server" Width="130px" Height="16px">Scanned 
                                  Mandate</asp:LinkButton>
                </td>
                <td >
                                  <asp:LinkButton ID="csa14" runat="server" Width="118px">Dormant Account</asp:LinkButton>
                </td>
                <td style="width: 100px; height: 25px">
                                  <asp:LinkButton ID="csa15" runat="server" Width="118px">Active Accounts</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td >
                                  <asp:LinkButton ID="csa16" runat="server" Width="142px" 
                        Height="16px">Reactivated Account</asp:LinkButton>

</td>
                <td >
                                  <asp:LinkButton ID="csa17" runat="server" Width="139px" Height="16px">Account 
                                  Concession</asp:LinkButton>
</td>
                <td >
                                  <asp:LinkButton ID="csa18" runat="server" Width="130px" Height="16px">Last 
                                  Account No</asp:LinkButton>
                </td>
                 <td >
                                  <asp:LinkButton ID="csa20" runat="server" Width="130px" Height="16px">Old/New Acct</asp:LinkButton>
                </td>
                <td >
                                   <asp:LinkButton ID="csa19" runat="server" Width="130px" Height="16px"> 
                                  Clearing Items</asp:LinkButton></td>
                <td style="width: 100px; height: 25px">
                                  &nbsp;</td>
                                  
            </tr>
            <tr>
                <td >
                                  <asp:LinkButton ID="csa99" runat="server" Width="142px" 
                        Height="16px">Account Tier Report</asp:LinkButton>

</td>
                
                <td style="width: 100px; height: 25px">
                                  &nbsp;</td>
                                  
            </tr>
        </table>
    </asp:Panel>
                        </div>
                      </div>
                    </div>
                    <div class="panel box box-danger">
                      <div class="box-header with-border">
                        <h4 class="box-title">
                          <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">
                           Operational Report
                          </a>
                        </h4>
                      </div>
                      <div id="collapseTwo" class="panel-collapse collapse">
                        <div class="box-body">
                          <asp:Panel id="panel2" runat="server" Width="900px" Height="150px">
                                 <table style="width: 864px; height: 45px; font-size: small; font-family: Verdana;">
            <tr>
                <td class="style2">
                    <asp:LinkButton ID="LnkOp1" runat="server" Font-Size="Small" Width="84px">Statement</asp:LinkButton>
                </td>
                <td class="style4">
                    <asp:LinkButton ID="LnkOp2" runat="server" Font-Size="Small" 
                        Width="131px">Account Enquiry</asp:LinkButton>
                </td>
               
                <td class="style3">
                     <asp:LinkButton ID="Lnk2" runat="server" Font-Size="Small" 
                        Width="124px">Member Balance</asp:LinkButton>
                </td>
                <td class="style1">
                     <asp:LinkButton ID="Lnk3" runat="server" Font-Size="Small" 
                        Width="124px">Teller Summary</asp:LinkButton>
                </td>
                <td style="width: 100px; height: 25px">
                 <asp:LinkButton ID="Lnk4" runat="server" Width="118px">Member Enquiry</asp:LinkButton>
</td>
            </tr>
            <tr>
                <td class="style2">
               <asp:LinkButton ID="Lnk5" runat="server" Width="139px">Cheque Book Status</asp:LinkButton>

                </td>
                <td class="style4">
                                  <asp:LinkButton ID="Lnk6" runat="server" Width="118px">Check Book List</asp:LinkButton>

                </td>
               
                <td class="style3">
                                  <asp:LinkButton ID="Lnk7" runat="server" Width="118px">Member Detail</asp:LinkButton>
                         </td>
                <td class="style1">
                                  <asp:LinkButton ID="Lnkop8" runat="server" Width="118px">Account Hold</asp:LinkButton>
                </td>
                <td style="width: 100px; height: 25px">
                                  <asp:LinkButton ID="LnkOp9" runat="server" Width="118px">Dormant Account</asp:LinkButton>
</td>
            </tr>
            <tr>
                <td class="style2">
                                  <asp:LinkButton ID="Lnkop10" runat="server" Width="118px" Height="16px">Account 
                                  Rate</asp:LinkButton>

</td>
                <td class="style4">
                                  <asp:LinkButton ID="Lnk11" runat="server" Width="142px" 
                        Height="16px">InFlow/OutFlow</asp:LinkButton>

                </td>
                <td class="style3">
                                  <asp:LinkButton ID="Lnk12" runat="server" Width="142px" 
                        Height="16px">Clearing Item</asp:LinkButton>

                </td>
                <td class="style1">
                                  <asp:LinkButton ID="Lnk13" runat="server" Width="142px" 
                        Height="16px">Posting Journal</asp:LinkButton>

                </td>
                <td style="width: 100px; height: 25px">
                                 
</td>
            </tr>
            <tr>
                <td class="style2">
                                  &nbsp;</td>
                <td class="style4">
                                  &nbsp;</td>
                <td class="style3">
                                  &nbsp;</td>
                <td class="style1">
                                  &nbsp;</td>
                <td style="width: 100px; height: 25px">
                                  &nbsp;</td>
            </tr>
        </table>
                  </asp:Panel>
                        </div>
                      </div>
                    </div>
                      <div class="panel box box-success">
                      <div class="box-header with-border">
                        <h4 class="box-title">
                          <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree">
                            Financial Reports
                          </a>
                        </h4>
                      </div>
                      <div id="collapseThree" class="panel-collapse collapse">
                        <div class="box-body">
                        <asp:Panel id="panel3" runat="server" Width="1000px" Height="300px">
                       <table style="width: 864px; height: 45px; font-size: small; font-family: Verdana;">
            <tr>
                <td class="style2">
                    <asp:LinkButton ID="Fin1" runat="server" Font-Size="Small" Width="84px">Statement</asp:LinkButton>
                </td>
                <td class="style4">
                    <asp:LinkButton ID="Fin2" runat="server" Font-Size="Small" 
                        Width="131px">Account Enquiry</asp:LinkButton>
                </td>
                <td class="style4">
                    <asp:LinkButton ID="balancesheet1" runat="server" Font-Size="Small" 
                        Width="131px">Balance Sheet Mapped</asp:LinkButton>
                </td>
               <td class="style4">
                    <asp:LinkButton ID="ProfitLoss" runat="server" Font-Size="Small" 
                        Width="131px">Profit and Loss</asp:LinkButton>
                </td>
                <td class="style3">
                                  <asp:LinkButton ID="Fin3" runat="server" Width="118px" Height="16px">Account 
                                  Rate</asp:LinkButton>
                </td>
                <td class="style1">
                     <asp:LinkButton ID="Fin4" runat="server" Font-Size="Small" 
                        Width="124px">Member Balance</asp:LinkButton>
                         </td>
               
<tr>
    <td style="width: 100px; height: 25px">
        <asp:LinkButton ID="Fin5" runat="server" Width="118px">Member Enquiry</asp:LinkButton>
    </td>
    <td class="style2">
        <asp:LinkButton ID="Fin6" runat="server" Height="16px" Width="130px">Clearing 
                                   Item</asp:LinkButton>
    </td>
    <td class="style4">
        <asp:LinkButton ID="Fin7" runat="server" Height="16px" Width="130px">Turn 
                                  Over</asp:LinkButton>
    </td>
    <td class="style3">
        <asp:LinkButton ID="Fin8" runat="server" Height="16px" Width="130px">Last 
                                  Account No</asp:LinkButton>
    </td>
    <td class="style1">
        <asp:LinkButton ID="Fin9" runat="server" Width="118px">Dormant Account</asp:LinkButton>
    </td>
    <td style="width: 100px; height: 25px">
        <asp:LinkButton ID="Fin10" runat="server" Width="118px">Active Accounts</asp:LinkButton>
    </td>
</tr>
                <tr>
                    <td class="style2">
                        <asp:LinkButton ID="Fin11" runat="server" Height="16px" Width="130px">Inflow/Outflow</asp:LinkButton>
                    </td>
                    <td class="style4">
                        <asp:LinkButton ID="Fin12" runat="server" Height="16px" Width="139px">Account 
                                  Concession</asp:LinkButton>
                    </td>
                    <td class="style3">
                        <asp:LinkButton ID="Fin13" runat="server" Height="16px" Width="161px">Cash 
                                  Summary</asp:LinkButton>
                    </td>
                    <td class="style1">
                        <asp:LinkButton ID="Fin14" runat="server" Height="16px" Width="161px">Member 
                                  Average Bal.</asp:LinkButton>
                    </td>
                    <td style="width: 100px; height: 25px">
                        <asp:LinkButton ID="Fin15" runat="server" Height="16px" Width="130px">Account 
                                  Statistic</asp:LinkButton>
                    </td>
                    <td class="style2">
                        <asp:LinkButton ID="Fin16" runat="server" Height="16px" Width="158px">Product 
                                  Summary</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:LinkButton ID="Fin17" runat="server" Height="32px" Width="158px">Product 
                                  Summary By Date</asp:LinkButton>
                    </td>
                    <td class="style3">
                        <asp:LinkButton ID="Fin18" runat="server" Height="30px" Width="164px">Account Performance By Officer 
                                 </asp:LinkButton>
                    </td>
                    <td class="style1">
                        <asp:LinkButton ID="Fin19" runat="server" Height="16px" Width="130px">Staff 
                                   List</asp:LinkButton>
                    </td>
                    <td style="width: 100px; height: 25px">
                        <asp:LinkButton ID="Fin20" runat="server" Height="16px" Width="130px">Un-Authorised 
                                   Item</asp:LinkButton>
                    </td>
                    <td class="style2">
                        <asp:LinkButton ID="Fin21" runat="server" Height="16px" Width="158px">Trial 
                                  Balance By Date</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:LinkButton ID="Fin22" runat="server" Height="16px" Width="153px">Trial 
                                  Balance Current</asp:LinkButton>
                    </td>
                    <td class="style3">
                        <asp:LinkButton ID="Fin23" runat="server" Height="33px" Width="156px">Consolidated 
                                  Trial Bal. By Date</asp:LinkButton>
                    </td>
                    <td class="style1">
                        <asp:LinkButton ID="Fin24" runat="server" Height="35px" Width="152px">Consolidated 
                                   Trial Bal. Current</asp:LinkButton>
                    </td>
                    <td style="width: 100px; height: 25px">
                        <asp:LinkButton ID="Fin25" runat="server" Height="16px" Width="130px">OverDraft</asp:LinkButton>
                    </td>
                    <td class="style2">
                        <asp:LinkButton ID="Fin26" runat="server" Height="16px" Width="130px">P and 
                                  L</asp:LinkButton>
                    </td>
                    <td class="style4">
                        <asp:LinkButton ID="Fin27" runat="server" Height="16px" Width="130px">Balance 
                                  Sheet</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:LinkButton ID="Fin28" runat="server" Height="16px" Width="130px">Risk 
                                  Summary</asp:LinkButton>
                    </td>
                    <td class="style1">
                        <asp:LinkButton ID="Fin29" runat="server" Height="16px" Width="130px">TD 
                                   Summary</asp:LinkButton>
                    </td>
                    <td style="width: 100px; height: 25px">
                        <asp:LinkButton ID="Fin30" runat="server" Height="16px" Width="130px">Accrual 
                                  To Date</asp:LinkButton>
                    </td>
                    <td class="style2">
                        <asp:LinkButton ID="Fin31" runat="server" Height="16px" Width="130px">Outstanding 
                                  Loan</asp:LinkButton>
                    </td>
                    <td class="style4">
                        <asp:LinkButton ID="Fin32" runat="server" Height="16px" Width="130px">Loan 
                                  Disbursed</asp:LinkButton>
                    </td>
                    <td class="style3">
                        <asp:LinkButton ID="Fin33" runat="server" Height="16px" Width="130px">Loan 
                                  Payment Due</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:LinkButton ID="Fin34" runat="server" Height="16px" Width="130px">Loan 
                                   Balance</asp:LinkButton>
                    </td>
                    <td class="style2">
                        <asp:LinkButton ID="Fin36" runat="server" Height="16px" Width="130px">Chart Of Account</asp:LinkButton>
                    </td>
                    <td class="style3">
                        <asp:LinkButton ID="Fin38" runat="server" Height="42px" Width="142px">Active Loan Schedule</asp:LinkButton>
                    </td>
                    <td class="style1">
                        <asp:LinkButton ID="Fin39" runat="server" Height="42px" Width="142px">Loan Repayment Due</asp:LinkButton>
                    </td>
                    <td style="width: 100px; height: 25px">
                        <asp:LinkButton ID="Fin40" runat="server" Height="42px" Width="142px">Past Due Obligation</asp:LinkButton>
                    </td>
                    <td style="width: 100px; height: 25px">
                        <asp:LinkButton ID="Fin41" runat="server" Height="42px" Width="142px">Loan Accruals</asp:LinkButton>
                    </td>
                </tr>
            </tr>
           
        </table>                
                  </asp:Panel>
                        </div>
                      </div>
                          <div class="panel box box-success">
                      <div class="box-header with-border">
                        <h4 class="box-title">
                          <a data-toggle="collapse" data-parent="#accordion" href="#collapseFour">
                           Management Information System Reports
                          </a>
                        </h4>
                      </div>
                      <div id="collapseFour" class="panel-collapse collapse">
                        <div class="box-body">
                         <asp:Panel id="panel4" runat="server"  Width="900px" Height="300px">
                          <table style="width: 864px; height: 45px; font-size: small; font-family: Verdana;">
            <tr>
                <td class="style2">
                    <asp:LinkButton ID="Mis1" runat="server" Font-Size="Small" Width="84px">Statement</asp:LinkButton>
                </td>
                <td class="style4">
                    <asp:LinkButton ID="Mis2" runat="server" Font-Size="Small" 
                        Width="131px">Account Enquiry</asp:LinkButton>
                </td>
               
                <td class="style3">
                                  <asp:LinkButton ID="Mis3" runat="server" Width="118px" Height="16px">Account 
                                  Rate</asp:LinkButton>
                </td>
                <td class="style1">
                     <asp:LinkButton ID="Mis4" runat="server" Font-Size="Small" 
                        Width="124px">Member Balance</asp:LinkButton>
                         </td>
                <td style="width: 100px; height: 25px">
                 <asp:LinkButton ID="Mis5" runat="server" Width="118px">Member Enquiry</asp:LinkButton>
</td>
            </tr>
            <tr>
                <td class="style2">
                                   <asp:LinkButton ID="Mis6" runat="server" Width="130px" Height="16px">Clearing 
                                   Item</asp:LinkButton>

</td>
                <td class="style4">
                                   <asp:LinkButton ID="Mis7" runat="server" Width="130px" Height="16px">Turn 
                                  Over</asp:LinkButton>
</td>
                <td class="style3">
                                  <asp:LinkButton ID="Mis8" runat="server" Width="130px" Height="16px">Last 
                                  Account No</asp:LinkButton>
                </td>
                <td class="style1">
                                  <asp:LinkButton ID="Mis9" runat="server" Width="118px">Dormant Account</asp:LinkButton>
                </td>
                <td style="width: 100px; height: 25px">
                                  <asp:LinkButton ID="Mis10" runat="server" Width="118px">Active Accounts</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="style2">
                                   <asp:LinkButton ID="Mis11" runat="server" Width="130px" Height="16px">Inflow/Outflow</asp:LinkButton>

</td>
                <td class="style4">
                                  <asp:LinkButton ID="Mis12" runat="server" Width="139px" Height="16px">Account 
                                  Concession</asp:LinkButton>
</td>
                <td class="style3">
                                   <asp:LinkButton ID="Mis13" runat="server" Width="161px" Height="16px">Cash 
                                  Summary</asp:LinkButton>
                </td>
                <td class="style1">
                                   <asp:LinkButton ID="Mis14" runat="server" Width="161px" Height="16px">Member 
                                  Average Bal.</asp:LinkButton>

                </td>
                <td style="width: 100px; height: 25px">
                                   <asp:LinkButton ID="Mis15" runat="server" Width="130px" Height="16px">Account 
                                  Statistic</asp:LinkButton></td>
            </tr>
            <tr>
                <td class="style2">
                                   <asp:LinkButton ID="Mis16" runat="server" Width="158px" Height="16px">Product 
                                  Summary</asp:LinkButton>

</td>
                <td class="style4">
                                   <asp:LinkButton ID="Mis17" runat="server" Width="158px" Height="32px">Product 
                                  Summary By Date</asp:LinkButton>

                </td>
                <td class="style3">
                                   <asp:LinkButton ID="Mis18" runat="server" Width="164px" Height="30px">Account Performance By Officer 
                                 </asp:LinkButton>

                </td>
                <td class="style1">
                                   <asp:LinkButton ID="Mis19" runat="server" Width="130px" Height="16px">Staff 
                                   List</asp:LinkButton>
                </td>
                <td style="width: 100px; height: 25px">
                                   <asp:LinkButton ID="Mis20" runat="server" Width="130px" Height="16px">Un-Authorised 
                                   Item</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="style2">
                                   <asp:LinkButton ID="Mis21" runat="server" Width="158px" Height="16px">Trial 
                                  Balance By Date</asp:LinkButton>

</td>
                <td class="style4">
                                   <asp:LinkButton ID="Mis22" runat="server" Width="153px" Height="16px">Trial 
                                  Balance Current</asp:LinkButton>
</td>
                <td class="style3">
                                   <asp:LinkButton ID="Mis23" runat="server" Width="156px" Height="33px">Consolidated 
                                  Trial Bal. By Date</asp:LinkButton>
                </td>
                <td class="style1">
                                   <asp:LinkButton ID="Mis24" runat="server" Width="152px" Height="35px">Consolidated 
                                   Trial Bal. Current</asp:LinkButton></td>
                <td style="width: 100px; height: 25px">
                                   <asp:LinkButton ID="Mis25" runat="server" Width="130px" Height="16px">OverDraft</asp:LinkButton></td>
            </tr>
            <tr>
                <td class="style2">
                                   <asp:LinkButton ID="Mis26" runat="server" Width="130px" Height="16px">P and 
                                  L</asp:LinkButton>

</td>
                <td class="style4">
                                   <asp:LinkButton ID="Mis27" runat="server" Width="130px" Height="16px">Balance 
                                  Sheet</asp:LinkButton>
</td>
                <td class="style3">
                                   <asp:LinkButton ID="Mis28" runat="server" Width="130px" Height="16px">Risk 
                                  Summary</asp:LinkButton>
                </td>
                <td class="style1">
                                   <asp:LinkButton ID="Mis29" runat="server" Width="130px" Height="16px">TD 
                                   Summary</asp:LinkButton></td>
                <td style="width: 100px; height: 25px">
                                   <asp:LinkButton ID="Mis30" runat="server" Width="130px" Height="16px">Accrual 
                                  To Date</asp:LinkButton></td>
            </tr>
            <tr>
                <td class="style2">
                                      <asp:LinkButton ID="Mis31" runat="server" Width="142px" 
                        Height="30px">Active Loan Schedule</asp:LinkButton></td>
                <td class="style4">
                                   &nbsp;</td>
                <td class="style3">
                                   &nbsp;</td>
                <td class="style1">
                                   &nbsp;</td>
                <td style="width: 100px; height: 25px">
                                  &nbsp;</td>
            </tr>
        </table>             
                  </asp:Panel>
                        </div>
                      </div>
                              <div class="panel box box-success">
                      <div class="box-header with-border">
                        <h4 class="box-title">
                          <a data-toggle="collapse" data-parent="#accordion" href="#collapseFive">
                           Internal Audit  Reports
                          </a>
                        </h4>
                      </div>
                      <div id="collapseFive" class="panel-collapse collapse">
                        <div class="box-body">
                         <asp:Panel ID="panel5" runat="server"  Width="900px" Height="500px">
                        <table style="width: 864px; height: 45px; font-size: small; font-family: Verdana;">
            <tr>
                <td class="style2">
                    <asp:LinkButton ID="Int1" runat="server" Font-Size="Small" Width="84px">Statement</asp:LinkButton>
                </td>
                <td class="style4">
                    <asp:LinkButton ID="Int2" runat="server" Font-Size="Small" 
                        Width="131px">Account Enquiry</asp:LinkButton>
                </td>
               
                <td class="style3">
                    <asp:LinkButton ID="Int3" runat="server" Font-Size="Small">Account Opened 
                    </asp:LinkButton>
                </td>
                <td class="style1">
                     <asp:LinkButton ID="Int4" runat="server" Font-Size="Small" 
                        Width="124px">Member Balance</asp:LinkButton>
                         </td>
                <td style="width: 100px; height: 25px">
                 <asp:LinkButton ID="Int5" runat="server" Width="118px">Member Enquiry</asp:LinkButton>
</td>
            </tr>
            <tr>
                <td class="style2">
                                     <asp:LinkButton ID="Int6" runat="server" Width="140px">Officer 
                    Performance</asp:LinkButton>
                </td>
                <td class="style4">
               <asp:LinkButton ID="Int7" runat="server" Width="139px">Cheque Book Status</asp:LinkButton>

                </td>
               
                <td class="style3">
                                  <asp:LinkButton ID="Int8" runat="server" Width="118px">Check Book List</asp:LinkButton>
                </td>
                <td class="style1">
                                  <asp:LinkButton ID="Int9" runat="server" Width="118px">Member Detail</asp:LinkButton>
                         </td>
                <td style="width: 100px; height: 25px">
                                  <asp:LinkButton ID="Int10" runat="server" Width="118px">Account Hold</asp:LinkButton>
</td>
            </tr>
            <tr>
                <td class="style2">
                                  <asp:LinkButton ID="Int11" runat="server" Width="118px">Standing 
                    Order</asp:LinkButton>

</td>
                <td class="style4">
                                  <asp:LinkButton ID="Int12" runat="server" Width="118px" Height="16px">Account 
                                  Rate</asp:LinkButton>
</td>
                <td class="style3">
                                  <asp:LinkButton ID="Int13" runat="server" Width="130px" Height="16px">Scanned 
                                  Mandate</asp:LinkButton>
                </td>
                <td class="style1">
                                  <asp:LinkButton ID="Int14" runat="server" Width="118px">Dormant Account</asp:LinkButton>
                </td>
                <td style="width: 100px; height: 25px">
                                  <asp:LinkButton ID="Int15" runat="server" Width="118px">Active Accounts</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="style2">
                                  <asp:LinkButton ID="Int16" runat="server" Width="142px" 
                        Height="16px">Reactivated Account</asp:LinkButton>

</td>
                <td class="style4">
                                  <asp:LinkButton ID="Int17" runat="server" Width="139px" Height="16px">Account 
                                  Concession</asp:LinkButton>
</td>
                <td class="style3">
                                  <asp:LinkButton ID="Int18" runat="server" Width="130px" Height="16px">Last 
                                  Account No</asp:LinkButton>
                </td>
                <td class="style1">
                                   <asp:LinkButton ID="Int19" runat="server" Width="130px" Height="16px">Clearing 
                                   Item</asp:LinkButton></td>
                <td style="width: 100px; height: 25px">
                                   <asp:LinkButton ID="Int20" runat="server" Width="130px" Height="16px">Turn 
                                  Over</asp:LinkButton></td>
            </tr>
            <tr>
                <td class="style2">
                                   <asp:LinkButton ID="Int21" runat="server" Width="130px" Height="16px">Posting 
                                  Journal</asp:LinkButton>

</td>
                <td class="style4">
                                   <asp:LinkButton ID="Int22" runat="server" Width="130px" Height="16px">Back 
                                  Office</asp:LinkButton>
</td>
                <td class="style3">
                                   <asp:LinkButton ID="Int23" runat="server" Width="130px" Height="16px">Inflow/Outflow</asp:LinkButton>
                </td>
                <td class="style1">
                                   <asp:LinkButton ID="Int24" runat="server" Width="130px" Height="16px">WithHolding 
                                   Tax</asp:LinkButton></td>
                <td style="width: 100px; height: 25px">
                                   <asp:LinkButton ID="Int25" runat="server" Width="130px" Height="16px">Bulk/Batch 
                                  Posting</asp:LinkButton></td>
            </tr>
            <tr>
                <td class="style2">
                                   <asp:LinkButton ID="Int26" runat="server" Width="161px" Height="16px">Member 
                                  Average Bal.</asp:LinkButton>

</td>
                <td class="style4">
                                   <asp:LinkButton ID="Int27" runat="server" Width="161px" Height="16px">Cash 
                                  Summary</asp:LinkButton>
</td>
                <td class="style3">
                                   <asp:LinkButton ID="Int28" runat="server" Width="130px" Height="16px">Call 
                                  Over</asp:LinkButton>
                </td>
                <td class="style1">
                                   <asp:LinkButton ID="Int29" runat="server" Width="130px" Height="16px">Account 
                                   Movement</asp:LinkButton></td>
                <td style="width: 100px; height: 25px">
                                   <asp:LinkButton ID="Int30" runat="server" Width="130px" Height="16px">Account 
                                  Statistic</asp:LinkButton></td>
            </tr>
            <tr>
                <td class="style2">
                                   <asp:LinkButton ID="Int31" runat="server" Width="130px" Height="16px">Amortised Items</asp:LinkButton>

</td>
                <td class="style4">
                                   <asp:LinkButton ID="Int32" runat="server" Width="130px" Height="16px">Fixed 
                                   Asset </asp:LinkButton>

                </td>
                <%--<td class="style3">
                                   <asp:LinkButton ID="Int33" runat="server" Width="130px" Height="16px">Vault 
                                   Transfer</asp:LinkButton>

                </td>--%>
                <%--<td class="style1">
                                   <asp:LinkButton ID="Int34" runat="server" Width="130px" Height="41px">Withdrawal 
                                   Toward Uncleared Effect</asp:LinkButton>

                </td>--%>
                <td style="width: 100px; height: 25px">
                                   <asp:LinkButton ID="Int35" runat="server" Width="130px" Height="16px">Counter 
                                   Cheque </asp:LinkButton>

                </td>
                <td class="style2">
                                   <asp:LinkButton ID="Int36" runat="server" Width="130px" Height="16px">Teller 
                                  Summary</asp:LinkButton>

</td>
 <td class="style3">
                                   <asp:LinkButton ID="Int38" runat="server" Width="164px" Height="30px">Account Performance By Officer 
                                 </asp:LinkButton>

                </td>
            </tr>
            <tr>
                
                <%--<td class="style4">
                                   <asp:LinkButton ID="Int37" runat="server" Width="154px" Height="29px">Account Profitability 
                                  </asp:LinkButton>

                </td>--%>
               
                <td class="style1">
                                   <asp:LinkButton ID="Int39" runat="server" Width="130px" Height="16px">Staff 
                                   List</asp:LinkButton>
                </td>
                <td style="width: 100px; height: 25px">
                                   <asp:LinkButton ID="Int40" runat="server" Width="130px" Height="16px">Un-Authorised 
                                   Item</asp:LinkButton>
                </td>
                 <td class="style2">
                                   <asp:LinkButton ID="Int41" runat="server" Width="158px" Height="16px">Trial 
                                  Balance By Date</asp:LinkButton>

</td>
                <td class="style4">
                                   <asp:LinkButton ID="Int42" runat="server" Width="153px" Height="16px">Trial 
                                  Balance Current</asp:LinkButton>
</td>
                <td class="style3">
                                   <asp:LinkButton ID="Int43" runat="server" Width="156px" Height="33px">Consolidated 
                                  Trial Bal. By Date</asp:LinkButton>
                </td>
            </tr>
            <tr>
               
                <td class="style1">
                                   <asp:LinkButton ID="Int44" runat="server" Width="152px" Height="35px">Consolidated 
                                   Trial Bal. Current</asp:LinkButton></td>
                <td style="width: 100px; height: 25px">
                                   <asp:LinkButton ID="Int45" runat="server" Width="130px" Height="16px">OverDraft</asp:LinkButton></td>
            <td class="style2">
                                   <asp:LinkButton ID="Int46" runat="server" Width="130px" Height="16px">P and 
                                  L</asp:LinkButton>

</td>
                <td class="style4">
                                   <asp:LinkButton ID="Int47" runat="server" Width="130px" Height="16px">Balance 
                                  Sheet</asp:LinkButton>
</td>
                <td class="style3">
                                   <asp:LinkButton ID="Int48" runat="server" Width="130px" Height="16px">Risk 
                                  Summary</asp:LinkButton>
                </td>
            </tr>
            <tr>
                
                <td class="style1">
                                   <asp:LinkButton ID="Int49" runat="server" Width="130px" Height="16px">TD 
                                   Summary</asp:LinkButton></td>
                <td style="width: 100px; height: 25px">
                                   <asp:LinkButton ID="Int50" runat="server" Width="130px" Height="16px">Accrual 
                                  To Date</asp:LinkButton></td>
                                  <td class="style2">
                                   <asp:LinkButton ID="Int51" runat="server" Width="158px" Height="16px">Product 
                                  Summary</asp:LinkButton>

</td>
                <td class="style4">
                                   <asp:LinkButton ID="Int52" runat="server" Width="158px" Height="32px">Product 
                                  Summary By Date</asp:LinkButton>
</td>
                <td class="style3">
                                   <asp:LinkButton ID="Int53" runat="server" Width="130px" Height="16px">Loan 
                                  Schedule</asp:LinkButton>
                </td>
            </tr>
            <tr>
                
                <td class="style1">
                                   <asp:LinkButton ID="Int54" runat="server" Width="130px" Height="16px">Deal 
                                   Certificate</asp:LinkButton></td>
               <%-- <td style="width: 100px; height: 25px">
                                   <asp:LinkButton ID="Int55" runat="server" Width="130px" Height="16px">Loan Deposit Ratio
                                  </asp:LinkButton></td>--%>
                                  <td class="style2">
                                   <asp:LinkButton ID="Int56" runat="server" Width="130px" Height="16px">Outstanding 
                                  Loan</asp:LinkButton>

</td>
                <td class="style4">
                                   <asp:LinkButton ID="Int57" runat="server" Width="130px" Height="16px">Loan 
                                  Disbursed</asp:LinkButton>
</td>
                <td class="style3">
                                   <asp:LinkButton ID="Int58" runat="server" Width="130px" Height="16px">Loan 
                                  Payment Due</asp:LinkButton>
                </td>
                <td class="style1">
                                   <asp:LinkButton ID="Int59" runat="server" Width="130px" Height="16px">Loan 
                                   Balance</asp:LinkButton></td>
            </tr>
            
            <tr>
                <td class="style2">
                                   <asp:LinkButton ID="Int61" runat="server" Width="130px" Height="16px">Loan 
                                  Classification</asp:LinkButton>

</td>
                <td class="style4">
                                   <asp:LinkButton ID="Int62" runat="server" Width="130px" Height="16px">EFASS</asp:LinkButton>

                </td>
                <td class="style3">
                                   <asp:LinkButton ID="Int63" runat="server" Width="130px" Height="16px">NDLEA</asp:LinkButton>
                </td>
               <%-- <td class="style1">
                                   <asp:LinkButton ID="Int64" runat="server" Width="130px" Height="16px">NDIC</asp:LinkButton>
                </td>--%>
                <td style="width: 100px; height: 25px">
        <asp:LinkButton ID="int65" runat="server" Width="130px" Height="16px">Chart Of Account</asp:LinkButton>
</td>
            </tr>
            <tr>
                <td class="style2">
                                          <asp:LinkButton ID="Int66" runat="server" Width="130px" Height="16px">Unfunded Account</asp:LinkButton>
</td>
                <td class="style4">
                                  <asp:LinkButton ID="int67" runat="server" Width="130px" Height="30px">Loan Report By Group</asp:LinkButton>
</td>
                <td class="style3">
                                      <asp:LinkButton ID="Lnk68" runat="server" Width="142px" 
                        Height="30px">Active Loan Schedule</asp:LinkButton></td>
                <td class="style1">
                                <asp:LinkButton ID="Lnk69" runat="server" Width="142px" 
                        Height="30px">Data Credit Bureau Report</asp:LinkButton></td>
                <td style="width: 100px; height: 25px">
                                   <asp:LinkButton ID="Lnk70" runat="server" Width="142px" 
                        Height="42px">Loan Repayment Due</asp:LinkButton></td>
            </tr>
            <tr>
             <td style="width: 100px; height: 25px">
                                   <asp:LinkButton ID="lnk71" runat="server" Width="142px" 
                        Height="42px">PAR (Portfolio at Risk)</asp:LinkButton></td>
                                 <td style="width: 100px; height: 25px">
                                   <asp:LinkButton ID="Lnk72" runat="server" Width="142px" 
                        Height="42px">PAR Agging</asp:LinkButton></td>
                                 <td style="width: 100px; height: 25px">
                                   <asp:LinkButton ID="Lnk73" runat="server" Width="142px" 
                        Height="42px">PAR Loan Performance</asp:LinkButton></td>
                                 <td style="width: 100px; height: 25px">
                                   <asp:LinkButton ID="Lnk74" runat="server" Width="142px" 
                        Height="42px">Loan Member Detail</asp:LinkButton></td>
                                 <td style="width: 100px; height: 25px">
                                   <asp:LinkButton ID="Lnk75" runat="server" Width="142px" 
                        Height="42px">Loan Accruals</asp:LinkButton></td>
            </tr>
        </table>
                    </asp:Panel>
                        </div>
                      </div>
                                  <div class="panel box box-success">
                      <div class="box-header with-border">
                        <h4 class="box-title">
                          <a data-toggle="collapse" data-parent="#accordion" href="#collapseSix">
                            Monthly Management Reports
                          </a>
                        </h4>
                      </div>
                      <div id="collapseSix" class="panel-collapse collapse">
                        <div class="box-body">
                         <asp:Panel ID="panel6" runat="server"  Width="900px" Height="150px">
                        <table style="width: 864px; height: 45px; font-size: small; font-family: Verdana;">
            <tr>
                <td class="style2">
                    <asp:LinkButton ID="LinkButton71" runat="server" Font-Size="Small" 
                        Width="149px">Period Trail Balance</asp:LinkButton>
                </td>
                <td class="style4">
                    <asp:LinkButton ID="LinkButton72" runat="server" Font-Size="Small" 
                        Width="233px">Consolidated Periodic Trial Balance</asp:LinkButton>
                </td>
               <td class="style4">
                    <asp:LinkButton ID="LinkButton73" runat="server" Font-Size="Small" 
                        Width="233px">SBU Performance</asp:LinkButton>
                </td>
             
            </tr>
            <tr>
                
                 <td class="style2">
                    <asp:LinkButton ID="Lnkperiod1" runat="server" Font-Size="Small" 
                        Width="149px">TrialBalance Movement By Branch</asp:LinkButton>
                </td>
                <td class="style2">
                    <asp:LinkButton ID="lnkperiod2" runat="server" Font-Size="Small" 
                        Width="149px">TrialBalance Movement Consolidated</asp:LinkButton>
                </td>
                <td style="width: 100px; height: 25px">
                                  <asp:LinkButton ID="lnkperiod3" runat="server" Font-Size="Small" 
                        Width="149px">GL History</asp:LinkButton></td>
            </tr>
            <tr>
                
                 <td class="style2">
                    <asp:LinkButton ID="lnkmanage1" runat="server" Font-Size="Small" 
                        Width="149px">Income History</asp:LinkButton>
                </td>
                <td class="style2">
                   <asp:LinkButton ID="lnkmanage2" runat="server" Font-Size="Small" 
                        Width="149px">Management Trialbalance</asp:LinkButton>
                </td>
                <td style="width: 100px; height: 25px">
                             </td>
            </tr>
            </table>
                    </asp:Panel>
                        </div>
                      </div>
                    <div class="panel box box-success">
                      <div class="box-header with-border">
                        <h4 class="box-title">
                          <a data-toggle="collapse" data-parent="#accordion" href="#collapseSeven">
                            Administrative/Audit  Reports
                          </a>
                        </h4>
                      </div>
                      <div id="collapseSeven" class="panel-collapse collapse">
                        <div class="box-body">
                         <asp:Panel ID="panel7" runat="server"  Width="900px" Height="150px">
                        <table style="width: 303px; height: 12px; font-size: small;">
                            <tr>
                                <td colspan="5" style="height: 4px">
                                    &nbsp;</td>
                                <td style="height: 4px">
                                    &nbsp;</td>
                                <td style="height: 4px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 84px; height: 20px">
                                    <asp:LinkButton ID="IT1" runat="server" Width="113px">SETUP REPORTS</asp:LinkButton>
                                </td>
                                <td style="width: 84px; height: 20px">
                            <asp:LinkButton ID="IT2" runat="server" Width="113px">USER LOGIN (BY DATE)</asp:LinkButton>

                                   </td>
                                   <td style="width: 84px; height: 20px">
                            <asp:LinkButton ID="IT99" runat="server" Width="113px">LOGIN STATUS REPORT</asp:LinkButton>

                                   </td>
                                <td style="width: 84px; height: 20px">
                                                               <asp:LinkButton ID="IT3" runat="server" Width="113px">AUDIT LOG</asp:LinkButton>
</td>
                                <td style="width: 84px; height: 20px">
                                     <asp:LinkButton ID="IT4" runat="server" Width="113px">AUDIT TRAIL</asp:LinkButton></td>
                                <td style="width: 100px; height: 20px">
                                    &nbsp;</td>
                                <td style="width: 100px; height: 20px">
                                    &nbsp;</td>
                                <td style="width: 100px; height: 20px">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                        </div>
                      </div>
                    </div>
                  </div>
                </div><!-- /.box-body -->
              </div><!-- /.box -->
            </div><!-- /.col -->
              </div>

    </form>
      <!-- jQuery 2.1.4 -->
    <script src="plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <!-- Bootstrap 3.3.5 -->
    <script src="../../bootstrap/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <script src="../../plugins/fastclick/fastclick.min.js"></script>
    <!-- AdminLTE App -->
    <script src="../../dist/js/app.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="../../dist/js/demo.js"></script>
</body>
</html>
