<%@ Page Title="" Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="DeductionDownload.aspx.vb" Inherits="UCP_Deploy_DeductionDownload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%-- <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>--%>
    
     <link href="../RadGrid.css" rel="stylesheet" />
        <script src="../Scripts.js" type="text/javascript"></script>
     <telerik:RadStyleSheetManager runat="server" ID="RadStyleSheetManager1">
        </telerik:RadStyleSheetManager>
<div class="box box-info">
<div class="box-body">
    <div class="row">
        <div class="col-md-12">
            <div class="box-header">
                  <h3 class="box-title">Deduction Classification</h3></div>
             <div class="box-body">
                  <ul class="todo-list">
                    <li>
                      <!-- drag handle -->
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                <asp:ListItem Value="1">Contributions</asp:ListItem>
                <asp:ListItem Value="2">Loan Repayments</asp:ListItem>
                <asp:ListItem Value="3">Project Financing</asp:ListItem>
                <asp:ListItem Value="4">Purchase of Items</asp:ListItem>
            </asp:CheckBoxList>
                        </li>
                      <li>
                      <!-- drag handle -->
                           <div class="col-md-4">
                                 <div class="form-group"> 
                                      <label>Select Period</label>
             <telerik:RadMonthYearPicker ID="RadMonthYearPicker1" runat="server" AutoPostBack="True">
                 <DateInput AutoPostBack="True" DateFormat="MMMM yyyy" DisplayDateFormat="MMMM yyyy">
                 </DateInput>
                 <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                      </telerik:RadMonthYearPicker>
                                     </div>
                           </div>
                        </li>
                     
                  </ul>
                </div><!-- /.box-body -->
            
            <asp:Panel ID="Contributions" runat="server">
                <div class="box-footer">
                    &nbsp;&nbsp; MEMBERS&#39; CONTRIBUTIONS RECORD<br />
                <asp:Button ID="ButGenerateContib" runat="server" Text="Generate Schedule" 
                                ValidationGroup="mine" CssClass="btn bg-purple btn-flat margin" />
                </div>
            <div id="DIVContributions" class="sprite2" runat="server">
          <telerik:RadGrid ID="RadGrid1" runat="server" PageSize="20" Height="380px" EnableEmbeddedBaseStylesheet="false"
            CssClass="table table-striped table-bordered table-hover"
            EnableEmbeddedSkins="false"
           OnNeedDataSource="RadGrid1_NeedDataSource" 
            AllowAutomaticInserts="true"
            AllowAutomaticUpdates="true"
            AllowAutomaticDeletes="true"
            AllowPaging="true"
            AutoGenerateColumns="false" AllowSorting="true">
            <MasterTableView EditMode="InPlace" CssClass="table table-striped table-hover"  DataKeyNames="EmployeeID"
                InsertItemPageIndexAction="ShowItemOnCurrentPage">
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    
                    
                    <telerik:GridBoundColumn SortExpression="EmployeeID" HeaderText="EmployeeID" HeaderButtonType="TextButton"
                        DataField="EmployeeID" UniqueName="EmployeeID"  ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="customerId" HeaderText="CustomerID" HeaderButtonType="TextButton"
                        DataField="customerId" UniqueName="customerId" ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="EmployeeName" HeaderText="EmployeeName" HeaderButtonType="TextButton"
                        DataField="EmployeeName" UniqueName="EmployeeName" ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="MonthlyContri" HeaderText="Amount" HeaderButtonType="TextButton"
                        DataField="MonthlyContri" UniqueName="MonthlyContri">
                    </telerik:GridBoundColumn>
                    
               
                </Columns>
                
                <PagerStyle AlwaysVisible="True" />
                <PagerTemplate>
                    <div class="rgWrap">
                        <ul class="pagination">
                            <li><a href="#">&laquo;</a></li>
                            <li><a href="#">&raquo;</a></li>
                        </ul>
                    </div>
                    <div class="rgWrap rgInfoPart">
                        <span>Page:</span>
                        <div class="input-group" style="width: 110px;">
                            <input type="text" class="form-control" value="1">
                            <span class="input-group-btn">
                                <button class="btn btn-default" type="button">Go!</button>
                            </span>
                        </div>
                    </div>
                </PagerTemplate>
            </MasterTableView>
            <ClientSettings>
                <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                <ClientEvents OnGridCreated="demo.onGridCreated" />
            </ClientSettings>
            <PagerStyle AlwaysVisible="true" Mode="NextPrevNumericAndAdvanced" />
              <FilterMenu EnableEmbeddedBaseStylesheet="False" EnableEmbeddedSkins="False" EnableImageSprites="False">
              </FilterMenu>
              <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableEmbeddedBaseStylesheet="False" EnableEmbeddedSkins="False">
              </HeaderContextMenu>
        </telerik:RadGrid>
              </div>
                </asp:Panel>
            <asp:Panel ID="DIVLoanRepay" runat="server" Visible="True">
                <div class="box-footer">
                    &nbsp;&nbsp; LOAN REPAYMENTS RECORDS<br />
                <asp:Button ID="ButLonRepay" runat="server" Text="Generate Schedule" 
                                ValidationGroup="mine" CssClass="btn bg-purple btn-flat margin" />
                </div>
            <div id="LoanRepay" class="sprite2" runat="server">
          <telerik:RadGrid ID="RadGrid2" runat="server" PageSize="20" Height="380px" EnableEmbeddedBaseStylesheet="false"
            CssClass="table table-striped table-bordered table-hover"
            EnableEmbeddedSkins="false"
            OnNeedDataSource="RadGrid2_NeedDataSource" 
            AllowAutomaticInserts="true"
            AllowAutomaticUpdates="true"
            AllowAutomaticDeletes="true"
            AllowPaging="true"
            AutoGenerateColumns="false" AllowSorting="true">
            <MasterTableView EditMode="InPlace" CssClass="table table-striped table-hover" DataKeyNames="EmployeeID"
                InsertItemPageIndexAction="ShowItemOnCurrentPage">
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    
                    
                    <telerik:GridBoundColumn SortExpression="EmployeeID" HeaderText="EmployeeID" HeaderButtonType="TextButton"
                        DataField="EmployeeID" UniqueName="EmployeeID"  ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="customerId" HeaderText="CustomerID" HeaderButtonType="TextButton"
                        DataField="customerId" UniqueName="customerId" ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="EmployeeName" HeaderText="EmployeeName" HeaderButtonType="TextButton"
                        DataField="EmployeeName" UniqueName="EmployeeName" ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="MonthlyContri" HeaderText="Amount" HeaderButtonType="TextButton"
                        DataField="MonthlyContri" UniqueName="MonthlyContri">
                    </telerik:GridBoundColumn>
                    
               
                </Columns>
                
                <PagerStyle AlwaysVisible="True" />
                <PagerTemplate>
                    <div class="rgWrap">
                        <ul class="pagination">
                            <li><a href="#">&laquo;</a></li>
                            <li><a href="#">&raquo;</a></li>
                        </ul>
                    </div>
                    <div class="rgWrap rgInfoPart">
                        <span>Page:</span>
                        <div class="input-group" style="width: 110px;">
                            <input type="text" class="form-control" value="1">
                            <span class="input-group-btn">
                                <button class="btn btn-default" type="button">Go!</button>
                            </span>
                        </div>
                    </div>
                </PagerTemplate>
            </MasterTableView>
            <ClientSettings>
                <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                <ClientEvents OnGridCreated="demo.onGridCreated" />
            </ClientSettings>
            <PagerStyle AlwaysVisible="true" Mode="NextPrevNumericAndAdvanced" />
              <FilterMenu EnableEmbeddedBaseStylesheet="False" EnableEmbeddedSkins="False" EnableImageSprites="False">
              </FilterMenu>
              <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableEmbeddedBaseStylesheet="False" EnableEmbeddedSkins="False">
              </HeaderContextMenu>
        </telerik:RadGrid>
              </div>
                </asp:Panel>
            <asp:Panel ID="DIVProjectFinance" runat="server" Visible="True">
                <div class="box-footer">
                    &nbsp;&nbsp;&nbsp; PROJECT FINANCE RECORDS<br />
                <asp:Button ID="ButProjectFinance" runat="server" Text="Generate Schedule" 
                                ValidationGroup="mine" CssClass="btn bg-purple btn-flat margin" />
                </div>
            <div id="ProjectFinance" class="sprite2" runat="server">
          <telerik:RadGrid ID="RadGrid3" runat="server" PageSize="20" Height="380px" EnableEmbeddedBaseStylesheet="false"
            CssClass="table table-striped table-bordered table-hover"
            EnableEmbeddedSkins="false"
          
            AllowAutomaticInserts="true"
            AllowAutomaticUpdates="true"
            AllowAutomaticDeletes="true"
            AllowPaging="true"
            AutoGenerateColumns="false" AllowSorting="true">
            <MasterTableView EditMode="InPlace" CssClass="table table-striped table-hover" DataKeyNames="EmployeeID"
                InsertItemPageIndexAction="ShowItemOnCurrentPage">
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    
                    
                    <telerik:GridBoundColumn SortExpression="EmployeeID" HeaderText="EmployeeID" HeaderButtonType="TextButton"
                        DataField="EmployeeID" UniqueName="EmployeeID"  ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="customerId" HeaderText="CustomerID" HeaderButtonType="TextButton"
                        DataField="customerId" UniqueName="customerId" ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="EmployeeName" HeaderText="EmployeeName" HeaderButtonType="TextButton"
                        DataField="EmployeeName" UniqueName="EmployeeName" ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="MonthlyContri" HeaderText="Amount" HeaderButtonType="TextButton"
                        DataField="MonthlyContri" UniqueName="MonthlyContri">
                    </telerik:GridBoundColumn>
                    
               
                </Columns>
                
                <PagerStyle AlwaysVisible="True" />
                <PagerTemplate>
                    <div class="rgWrap">
                        <ul class="pagination">
                            <li><a href="#">&laquo;</a></li>
                            <li><a href="#">&raquo;</a></li>
                        </ul>
                    </div>
                    <div class="rgWrap rgInfoPart">
                        <span>Page:</span>
                        <div class="input-group" style="width: 110px;">
                            <input type="text" class="form-control" value="1">
                            <span class="input-group-btn">
                                <button class="btn btn-default" type="button">Go!</button>
                            </span>
                        </div>
                    </div>
                </PagerTemplate>
            </MasterTableView>
            <ClientSettings>
                <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                <ClientEvents OnGridCreated="demo.onGridCreated" />
            </ClientSettings>
            <PagerStyle AlwaysVisible="true" Mode="NextPrevNumericAndAdvanced" />
              <FilterMenu EnableEmbeddedBaseStylesheet="False" EnableEmbeddedSkins="False" EnableImageSprites="False">
              </FilterMenu>
              <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableEmbeddedBaseStylesheet="False" EnableEmbeddedSkins="False">
              </HeaderContextMenu>
        </telerik:RadGrid>
              </div>
                </asp:Panel>
            <asp:Panel ID="DIVPurchaseOfItems" runat="server" Visible="True">
                 <div class="box-footer">
                     &nbsp;&nbsp;&nbsp; PURCHASE ITEM RECORDS<br />
                <asp:Button ID="ButPurchaseOfItems" runat="server" Text="Generate Schedule" 
                                ValidationGroup="mine" CssClass="btn bg-purple btn-flat margin" />
                </div>
            <div id="PurchaseOfItems" class="sprite2" runat="server">
          <telerik:RadGrid ID="RadGrid4" runat="server" PageSize="20" Height="380px" EnableEmbeddedBaseStylesheet="false"
            CssClass="table table-striped table-bordered table-hover"
            EnableEmbeddedSkins="false"
          
            AllowAutomaticInserts="true"
            AllowAutomaticUpdates="true"
            AllowAutomaticDeletes="true"
            AllowPaging="true"
            AutoGenerateColumns="false" AllowSorting="true">
            <MasterTableView EditMode="InPlace" CssClass="table table-striped table-hover" DataKeyNames="EmployeeID"
                InsertItemPageIndexAction="ShowItemOnCurrentPage">
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    
                    
                    <telerik:GridBoundColumn SortExpression="EmployeeID" HeaderText="EmployeeID" HeaderButtonType="TextButton"
                        DataField="EmployeeID" UniqueName="EmployeeID"  ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="customerId" HeaderText="CustomerID" HeaderButtonType="TextButton"
                        DataField="customerId" UniqueName="customerId" ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="EmployeeName" HeaderText="EmployeeName" HeaderButtonType="TextButton"
                        DataField="EmployeeName" UniqueName="EmployeeName" ReadOnly="True">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn SortExpression="MonthlyContri" HeaderText="Amount" HeaderButtonType="TextButton"
                        DataField="MonthlyContri" UniqueName="MonthlyContri">
                    </telerik:GridBoundColumn>
                    
               
                </Columns>
                
                <PagerStyle AlwaysVisible="True" />
                <PagerTemplate>
                    <div class="rgWrap">
                        <ul class="pagination">
                            <li><a href="#">&laquo;</a></li>
                            <li><a href="#">&raquo;</a></li>
                        </ul>
                    </div>
                    <div class="rgWrap rgInfoPart">
                        <span>Page:</span>
                        <div class="input-group" style="width: 110px;">
                            <input type="text" class="form-control" value="1">
                            <span class="input-group-btn">
                                <button class="btn btn-default" type="button">Go!</button>
                            </span>
                        </div>
                    </div>
                </PagerTemplate>
            </MasterTableView>
            <ClientSettings>
                <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                <ClientEvents OnGridCreated="demo.onGridCreated" />
            </ClientSettings>
            <PagerStyle AlwaysVisible="true" Mode="NextPrevNumericAndAdvanced" />
              <FilterMenu EnableEmbeddedBaseStylesheet="False" EnableEmbeddedSkins="False" EnableImageSprites="False">
              </FilterMenu>
              <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableEmbeddedBaseStylesheet="False" EnableEmbeddedSkins="False">
              </HeaderContextMenu>
        </telerik:RadGrid>
              </div>
                </asp:Panel>
        </div>
        </div>
</div>
</div>
			<%--</ContentTemplate>
			</asp:UpdatePanel> --%>
</asp:Content>

