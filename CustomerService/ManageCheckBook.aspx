<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master"  AutoEventWireup="false"   CodeFile="ManageCheckBook.aspx.vb" Inherits="CustomerService_ManageCheckBook" title="ManageCheckbook Page" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
       <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
            AssociatedUpdatePanelID="updatePanel">
        <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #D7D7FF; opacity: 0.5;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
    </ProgressTemplate>
        </asp:UpdateProgress>                                     
    <div class="box box-info">
                <div class="box-header">


                    <div class="box-body">
             <div class="col-md-3">
                            <div class="form-group">
                                 <label>Account Number <asp:HyperLink ID="hypAccount" runat="server" Height="17px" 
                            ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink></label>
                                <asp:TextBox ID="txtAcctNo1" runat="server" AutoPostBack="True" Font-Size="Small"
                            CssClass="form-control"  placeholder="Account Number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAcctNo1"
                            Display="Dynamic" ErrorMessage="Enter Accountnumber" ValidationGroup="News3"
                            Width="122px">Enter Accountnumber</asp:RequiredFieldValidator>
                            </div>

                 <div class="form-group">
                     <label>ChequeBook Type</label>
                     <asp:DropDownList ID="DrpChkType1" runat="server" AutoPostBack="True" Font-Size="Small" CssClass="form-control">
                        </asp:DropDownList>

                 </div>


                  <div class="form-group">
                     <label>Branch to Collect</label>

                      <asp:DropDownList ID="DrpBranch2" runat="server" AutoPostBack="True" Font-Size="Small" CssClass="form-control">
                        </asp:DropDownList>
                 </div>

                    <div class="form-group">
                     <label>Request Date <asp:HyperLink ID="hypValueDate" runat="server" ImageUrl="~/Images/pdate.gif">HyperLink</asp:HyperLink></label>

                        <asp:TextBox ID="txtReqDate" runat="server" Font-Size="Small" 
                           CssClass="form-control" placeholder="Request Date"></asp:TextBox>
                        </div>

                     <div class="form-group">
                             <label>Narration</label>

                         <asp:TextBox ID="txtNarration" runat="server" Font-Size="Small"
                            Height="43px" TextMode="MultiLine" placeholder="Narration" CssClass="form-control"></asp:TextBox>

                         </div>

                 </div>

 <div class="col-md-3">
     <div class="form-group">
     <label>Account Name</label>

     <asp:Label ID="lblName" runat="server"></asp:Label>
       </div>
     <div class="form-group">
         <label>No Of Leaves</label>

         <asp:TextBox ID="txtnolv" runat="server" AutoPostBack="True" Font-Size="Small"  CssClass="form-control"
                            ReadOnly="True"></asp:TextBox>
         </div>
     <div class="form-group">
         <label>Cost Of Cheque Book</label>
         <asp:TextBox ID="txtcost" runat="server" AutoPostBack="True" Font-Size="Small"
                            ReadOnly="True" CssClass="form-control"></asp:TextBox>
         </div>


      <div class="form-group">
         <label>Start Serial No</label>

          <telerik:RadNumericTextBox ID="txtstart" Runat="server" AutoPostBack="True" CssClass="form-control">
                            <NumberFormat DecimalDigits="0" GroupSeparator="" />
                        </telerik:RadNumericTextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="txtstart" ErrorMessage="*Enter Start Serial No" 
                            ValidationGroup="News3"></asp:RequiredFieldValidator>
          </div>
                 
                        </div>


                        <div class="col-md-3">
                             <div class="form-group">
                                   <label>Account Type</label>
                                 <asp:DropDownList ID="DrpAcctType1" runat="server" Font-Size="Small" CssClass="form-control">
                        </asp:DropDownList>
                                 </div>

                             <div class="form-group">

                                <label>Branch</label>
                                 <asp:DropDownList ID="DrpBranch1" runat="server" AutoPostBack="True" Font-Size="Small" CssClass="form-control">
                        </asp:DropDownList>

                                 </div>

                             <div class="form-group">

                                <label>Total Cost to Customer</label>

                                 <telerik:RadNumericTextBox ID="txttotcost" Runat="server" AutoPostBack="True" 
                           CssClass="form-control">
                        </telerik:RadNumericTextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="txttotcost" ErrorMessage="*Enter total cost" 
                            ValidationGroup="News3"></asp:RequiredFieldValidator>
                                 </div>


                             <div class="form-group">

                                <label>End Serial No</label>

                                  <asp:TextBox ID="txtend" runat="server" AutoPostBack="True" Font-Size="Small" 
                            ReadOnly="True" CssClass="form-control"></asp:TextBox>

                                 </div>

                        </div>

                                </div>


                    <div class="box-footer">
                               <div class="col-md-6"> 
                          <asp:Button ID="Btnsubmit" runat="server" CssClass="btn bg-purple btn-flat margin" 
                                                    Text="Range"  ValidationGroup="News3" Width="100%"/>
                                   </div>
                               <div class="col-md-6"> 
                                                <asp:Button ID="BtnReset" runat="server" CssClass="btn bg-maroon btn-flat margin" 
                                                    Text="Reset" Width="100%" CausesValidation="False" />
                                   </div>
                                              
                        <asp:Label ID="Label6" runat="server"></asp:Label>
                          </div>

                       <div class="col-sm-12">

                           <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        Font-Size="Small" PageSize="20" Width="542px" CssClass="table table-bordered table-hover dataTable">
                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                            NextPageText="Next" PreviousPageText="Previous" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <input id="chkAll" runat="server" onclick="javascript: SelectAllCheckboxes(this);"
                                                                type="checkbox" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="Check1" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="SerialNo" HeaderText="SerialNo" SortExpression="SerialNo">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Block/Open" SortExpression="Status">
                                                    <ItemTemplate>
                                                    <%#DisplayBlock(CType(Eval("Status"), Integer))%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" Visible="False">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="trandate" HeaderText="Used Date" SortExpression="trandate" />
                                                    <asp:TemplateField Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LblDoc1" runat="server" Text='<%#Eval("SerialNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle BackColor="#F7F7DE" />
                                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                           </div>

                    </div>

    </div>


                                            </ContentTemplate> 
                                            </asp:UpdatePanel> 
</asp:Content>

