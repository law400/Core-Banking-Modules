<%@ Page Title="" Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="DeductionDownload.aspx.vb" Inherits="UCP_Deploy_DeductionDownload" %>

<%@ Register assembly="Aspose.Excel.GridViewExport" namespace="Aspose.Excel.GridViewExport" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%-- <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>--%>
    
     <link href="../RadGrid.css" rel="stylesheet" />
                            <script src="template/js/jquery-1.11.1.min.js"></script>

     <telerik:RadStyleSheetManager runat="server" ID="RadStyleSheetManager1">
        </telerik:RadStyleSheetManager>
 <div class="panel panel-default">
               <div class="panel-heading">
                  <h3 class="box-title">Deduction Download</h3>                       
        
            </div>
                 <div class="panel-body">
    <div class="row">
        <div class="col-md-12">
            
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select Period&nbsp;&nbsp;&nbsp;&nbsp;
                  <telerik:RadMonthYearPicker ID="RadMonthYearPicker1" runat="server" AutoPostBack="True">
                      <DateInput AutoPostBack="True" DateFormat="MMMM yyyy" DisplayDateFormat="MMMM yyyy">
                      </DateInput>
                      <DatePopupButton HoverImageUrl="" ImageUrl="" />
                  </telerik:RadMonthYearPicker>
            
            <asp:Panel ID="Contributions" runat="server">
                <div class="box-footer">
                    &nbsp;&nbsp; Batch Number&nbsp;
                    <asp:TextBox ID="TxtBatch" runat="server" ReadOnly="True"></asp:TextBox>
                    <br />
                    <asp:Button ID="ButGenerateContib0" runat="server" CssClass="btn bg-purple btn-flat margin" Text="Download Schedule" />
                    <asp:Button ID="ButCompleteValidation" runat="server" CssClass="btn bg-orange btn-flat margin" Text="Complete Validation"  Enabled="False" OnClientClick="OnClientClick=&quot;return confirm('Are you sure ?');&quot;" />
                    <br />
                    <br />
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-hover" Width="100%" Font-Size="7pt" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                          <Columns>
                            <asp:BoundField HeaderText="S/N" DataField="Row" SortExpression="Row"/>
                            <asp:BoundField HeaderText="Employee ID" DataField="EmployeeID" SortExpression ="EmployeeID" />
                            <asp:BoundField HeaderText="Employee Surname" DataField="Surname" SortExpression="Surname" />
                            <asp:BoundField HeaderText="Employee First Name" DataField="First_Name" SortExpression="First_Name"/>
                              <asp:BoundField HeaderText="Period" DataField="Period" SortExpression="Period"/>
                            <asp:BoundField HeaderText="Normal Deduction" DataField="Normal_Contribution" DataFormatString="{0:n}" SortExpression="Normal_Contribution"/>
                            <asp:BoundField HeaderText="Loan Deduction" DataField="Loan_Repayment" DataFormatString="{0:n}" SortExpression="Loan_Repayment" />
                            <asp:BoundField HeaderText="Project Finance" DataField="Project_Finance" DataFormatString="{0:n}" SortExpression="Project_Finance" />
                            <asp:BoundField HeaderText="Total Amount" DataField="Total_Amt" SortExpression="Total_Amt" DataFormatString="{0:n}" />
                            <asp:BoundField DataField="Approved_Total_Amt" HeaderText="Approved Amount" DataFormatString="{0:n}" SortExpression="Approved_Total_Amt" />
                             <asp:BoundField HeaderText="Approval Note" DataField="Approval_Note" SortExpression="Approval Note"/>
                            <asp:BoundField HeaderText="Batch ID" DataField="Batch" SortExpression="Batch"/>
                            <asp:BoundField HeaderText="Company" DataField="Company" SortExpression="Company"/>
							<asp:BoundField HeaderText="Customer ID" DataField="CustomerId" SortExpression="CustomerId"/>
                        </Columns>
                          <FooterStyle BackColor="White" ForeColor="#000066" />
                          <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="Black" />
                          <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                          <RowStyle ForeColor="#000066" />
                          <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                          <SortedAscendingCellStyle BackColor="#F1F1F1" />
                          <SortedAscendingHeaderStyle BackColor="#007DBB" />
                          <SortedDescendingCellStyle BackColor="#CAC9C9" />
                          <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                    <br />
                </div>
            <div id="DIVContributions" class="sprite2"  runat="server">

                


                
          
              </div>
                </asp:Panel>
        </div>
        </div>

</div>
     <div class="panel-footer">

     </div>
</div>
			<%--</ContentTemplate>
			</asp:UpdatePanel> --%>
</asp:Content>

