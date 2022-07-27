<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="CustAccountInfo.aspx.vb" Inherits="CustomerService_CustAccountInfo" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <script src="template/js/jquery-1.11.1.min.js"></script>

    <asp:UpdatePanel id="updatePanel1" runat="server">
<ContentTemplate>

     <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
            AssociatedUpdatePanelID="updatePanel1">
        <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #D7D7FF; opacity: 0.5;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
    </ProgressTemplate>
        </asp:UpdateProgress>

    
         <div class="panel panel-default">
                <div class="panel-header">

                    </div>

                    <div class="panel-body">
             <div class="col-md-5">
                            <div class="form-group">
                                <label>Account Number<span style="color: #FF0000">*</span> <asp:HyperLink ID="hypsearch" runat="server" Height="25px" 
                                ImageUrl="~/Images/iconbar_previewtab_on.gif" Width="25px">HyperLink</asp:HyperLink></label>
                                 <asp:TextBox ID="txtaccountnumber" runat="server" AutoPostBack="True" 
                                Font-Size="Small" TabIndex="4" CssClass="form-control"></asp:TextBox>
                            </div>
                 
             <div class="form-group">
                 <label>Account Title</label>
                 <asp:TextBox ID="txttitle" runat="server" Font-Size="Small" ReadOnly="True" 
                                TabIndex="4" CssClass="form-control"></asp:TextBox>


                 </div>

                 <div class="form-group">
                   <label>Address</label>

                     <asp:TextBox ID="txtaddress" runat="server" Font-Size="Small" Height="52px" 
                                ReadOnly="True" TabIndex="4" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>

                 </div>
             
                  <div class="form-group">
                         <label>Phone No</label>
                        <asp:TextBox ID="txtphone" runat="server" Font-Size="Small" ReadOnly="True" 
                                TabIndex="4" CssClass="form-control"></asp:TextBox>
                      
                 </div>
             
             </div>




                        </div>

                    <div class="box-footer">
                          
                                                <asp:Button ID="BtnReset" runat="server" CssClass="btn bg-maroon btn-flat margin" 
                                                    Text="Reset"  />


                         

                                </div>

                 </div>

     <div class="col-sm-12">
          <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="100%">
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="4" Font-Size="XX-Small" Height="147px" ShowFooter="True" 
                    Width="100%" CssClass="table table-bordered table-hover dataTable">
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" Font-Size="Small" />
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="Accountnumber" 
                            DataNavigateUrlFormatString="#" 
                            DataTextField="Accountnumber" HeaderText="Account Number" />
                        <asp:BoundField DataField="accounttitle" HeaderText="Account Name">
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="prodname" HeaderText="Product Name">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="bkbal" HeaderText="Book Balance">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="effbal" HeaderText="Effective Balance" 
                            ReadOnly="True">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="usebal" HeaderText="Usable Balance">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="acctstatus" HeaderText="Account Status" />
                    </Columns>
                    <RowStyle BackColor="White" Font-Size="Small" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" Font-Size="Small" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" Font-Size="Small" />
                </asp:GridView>

              </asp:Panel> 
         </div>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>



