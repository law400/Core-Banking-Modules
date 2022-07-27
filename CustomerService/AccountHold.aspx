<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master"  AutoEventWireup="false"   CodeFile="AccountHold.aspx.vb" Inherits="CustomerService_AccountHold" title="AccountHold Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <script src="template/js/jquery-1.11.1.min.js"></script>

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
   <div class="panel panel-default">
                <div class="panel-heading">
                    </div>
                    <div class="form-group">
                    <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal"
                StaticEnableDefaultPopOutImage="False" Width="30%">
                <Items>
                    <asp:MenuItem ImageUrl="~/Images/pic2.gif" Text="Add Lien" Value="0"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="~/images/pic1.gif" Text="Release Lien" Value="1"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="~/images/pic1.gif" Text="List" Value="2"></asp:MenuItem>
                </Items>
            </asp:Menu>
                        <br />
                    </div> 
 <div class="panel-body">
             <div class="col-md-5">
                            <div class="form-group">

 <label>Account Number<span style="color: #FF0000"> *</span> <asp:HyperLink ID="Hypsearch" runat="server" ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink></label>
                    
                         <asp:TextBox ID="Txtaccountnumber" runat="server" AutoPostBack="True" Font-Size="Small" placeholder="Account Number" CssClass="form-control"></asp:TextBox>
                            
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Txtaccountnumber"
                            Display="Dynamic" ErrorMessage="Enter AccountNumber" ValidationGroup="News" Width="167px">Enter AccountNumber</asp:RequiredFieldValidator>
                            </div>

                  <div class="form-group">
                      <label>Amount <span style="color: #FF0000">*</span></label>
                      <telerik:RadNumericTextBox ID="txtAmount" runat="server" AutoPostBack="True" CssClass="form-control" EmptyMessage="0.00"></telerik:RadNumericTextBox>
                        </div>

   <div class="form-group">
        <label>Start Date <span style="color: #FF0000">*</span> <asp:HyperLink ID="ImgDate" runat="server" ImageUrl="~/Images/pdate.gif">HyperLink</asp:HyperLink></label>
        <asp:TextBox ID="TxtStartDate" runat="server" Font-Size="Small" placeholder="Start Date" CssClass="form-control"></asp:TextBox>


       </div>

 <div class="form-group">

                                <label>Narration<span style="color: #FF0000">*</span></label>
                    
                         <asp:TextBox ID="Txtnarration" runat="server" Height="56px" TextMode="MultiLine"  Font-Size="Small" placeholder="Narration" CssClass="form-control"></asp:TextBox>
                            </div>

                 </div>


      <div class="col-md-5">
                            <div class="form-group">

                                <label>Account Name</label>
                    
                         <asp:TextBox ID="txtAccountName" runat="server" AutoPostBack="True" Height="56px" TextMode="MultiLine" ReadOnly="True" Font-Size="Small" placeholder="Account Name" CssClass="form-control"></asp:TextBox>
                            </div>


          <div class="form-group">

                                <label>Seq No</label>
                    <asp:DropDownList ID="DrpSerial" runat="server" AutoPostBack="True"  CssClass="form-control"
                            Visible="False">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtSeqNo" runat="server" placeholder="Seq No"  Font-Size="Small" CssClass="form-control"></asp:TextBox>
                            </div>

           <div class="form-group">
        <label>End Date <span style="color: #FF0000">*</span> <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/Images/pdate.gif">HyperLink</asp:HyperLink></label>
        <asp:TextBox ID="TxtEnddate" runat="server" Font-Size="Small" placeholder="End Date" CssClass="form-control"></asp:TextBox>


       </div>


          <div class="form-group">
               <label>Choose a Lien Option <span style="color: #FF0000">*</span></label>
              <asp:RadioButtonList ID="RDBLien" runat="server" 
                            AutoPostBack="True" Width="195px">
                            <asp:ListItem Selected="True" Value="0">--Choose a Lien Option</asp:ListItem>
                            <asp:ListItem Value="1">Lien On Balance
                            </asp:ListItem>
                            <asp:ListItem Value="4">Lien On DR Transactions</asp:ListItem>
                            <asp:ListItem Value="5">Lien On CR Transactions</asp:ListItem>
                            <asp:ListItem Value="6">Lien On all Transaction
                            </asp:ListItem>
                        </asp:RadioButtonList>
          </div>


                 </div>


      </div>


                        <div class="panel-footer">
                                                          
                          <asp:Button ID="Btnsubmit" runat="server" CssClass="btn bg-purple btn-flat margin" 
                                                    Text="Submit"  ValidationGroup="News" />
                              
                        
                                                <asp:Button ID="BtnReset" runat="server" CssClass="btn bg-maroon btn-flat margin" 
                                                    Text="Reset"  />
                                                           
                           

                                
                          </div>


                    <div class="col-sm-12">

                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                &nbsp;
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Prime %>" SelectCommand="Select accountnumber,HoldAmount,effective_dt,End_dt, case status when 1 then 'Active' when 2 then 'Suspended' else 'Closed' end as Status  from tbl_Holdtrans where Node_id = @Node_id "
            OldValuesParameterFormatString="original_{0}" ConflictDetection="CompareAllValues">
             <SelectParameters>
                <asp:ProfileParameter Name="Node_id" PropertyName="Node_id" Type="int16" />
             </SelectParameters>             
           
                          </asp:SqlDataSource>
                                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="100%">
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    CellPadding="4" DataSourceID="SqlDataSource1" CssClass="table table-bordered table-hover dataTable" ForeColor="#333333" GridLines="None"
                                    Width="100%">
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="AccountNumber" HeaderText="AccountNumber">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Holdamount" DataFormatString="{0:g}" HeaderText="Lien Amount">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="effective_dt" HeaderText="Value Date">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="End_dt" HeaderText="End Date" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" />
                                    </Columns>
                                    <RowStyle BackColor="#EFF3FB" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                                        </asp:Panel> 
                                &nbsp; &nbsp;&nbsp;
                            </asp:View>
                        </asp:MultiView>&nbsp;</div>


                    </div>



    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>

