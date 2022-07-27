<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false"   CodeFile="cashwithdrawal.aspx.vb"  Inherits="cashwithdral" title="Untitled Page" %>
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
<div class="panel-body">
   <div class="form-group">
              <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" Width="100%">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover dataTable" Font-Size="Small" PageSize="1" Width="100%">
                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
                <Columns>
                    <asp:TemplateField HeaderText="Account Mandate">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Height="150px" ImageUrl='<%# "Handler.ashx?id=" + cType(Eval("serial"),String) + "&id2=" + Eval("accountnumber") %>' Width="200px" />
                            <asp:Image ID="Image2" runat="server" ImageUrl='<%# "Handler2.ashx?id=" + cType(Eval("serial"),String) + "&id2=" + Eval("accountnumber")  %>' />
                        </ItemTemplate>
                        <HeaderStyle ForeColor="#0000CC" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Account Signatory">
                        <ItemTemplate>
                            <asp:Literal ID="Literal1" runat="server" Text='<%# "Signatory :" + Eval("signatoryname") %>'></asp:Literal>
                            <br />
                            <asp:Literal ID="Literal2" runat="server" Text='<%# "Designatiton :" + Eval("designation") %>'></asp:Literal>
                            <br />
                            <asp:Literal ID="Literal3" runat="server" Text='<%# "Mandate Instruction :" + Eval("mandatedesc1") %>'></asp:Literal>
                            <br />
                        </ItemTemplate>
                        <HeaderStyle ForeColor="#0000CC" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                  </asp:Panel> 
        </div>            
        <div class="col-md-4">
                           <div class="form-group" style="font-size: small"> 
                            <tr>
                                <td style="width: 974px">
                                    Account Number</td>
                                <td style="width: 100px">
                                    <span style="color: #FF0000"><strong>*</strong></span><asp:TextBox ID="txtAcNumber" runat="server" AutoPostBack="True" 
                                        Font-Size="Small" TabIndex="1" CssClass="form-control"></asp:TextBox>
                                    <asp:HyperLink ID="hypAccount" runat="server" Height="7px" 
                                        ImageUrl="~/Images/iconbar_previewtab_on.gif" Visible="False">HyperLink</asp:HyperLink>
                                </td>
                                <td style="width: 100px">
                                    <asp:CheckBox ID="CheckSearch" runat="server" AutoPostBack="True" 
                                        Text="Search Account" />
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="width: 974px">
                                    &nbsp;</td>
                                <td style="width: 100px">
                                    <telerik:RadComboBox ID="RadComboBox2" runat="server" AutoPostBack="True" 
                                       CssClass="form-control"   CanAutocompleteSelectItems="True" OnItemsRequested="RadComboBox2_ItemsRequested"
                OpenDropDownOnFocus="False"
                 EnableVirtualScrolling="true" Height="180px" ItemsPerRequest="10" ShowMoreResultsBox="true" Skin="Sitefinity" Visible="False" Width="100%" EnableLoadOnDemand="True">
                                    </telerik:RadComboBox>
                                </td>
                                <td style="width: 100px">
                                    &nbsp;</td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="width: 974px">
                                    Value Date</td>
                                <span style="color: #FF0000"><strong>*</strong></span>&nbsp;<td style="width: 100px">
                                    <asp:HyperLink ID="hypValueDate" runat="server" ImageUrl="~/Images/pdate.gif">HyperLink</asp:HyperLink>
                                    <asp:TextBox ID="txtValueDate" runat="server" Font-Size="Small" TabIndex="2" 
                                         CssClass="form-control"></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="width: 974px">
                                    Pay Amount</td>
                                <td style="width: 100px">
                                    <span style="color: #FF0000"><strong>*</strong></span><asp:TextBox ID="txtPayAmount" runat="server" AutoPostBack="True" 
                                        Font-Size="Small" TabIndex="3" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="width: 974px">
                                    Voucher No</td>
                                <td style="width: 100px">
                                    <span style="color: #FF0000"><strong>*</strong></span><asp:TextBox ID="txtTellerNo" runat="server" AutoPostBack="True" 
                                        Font-Size="Small" TabIndex="4" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            </div>
                            <div class="form-group" >
                            <tr>
                                <td style="width: 974px">
                                    Narration <span style="color: #FF0000"><strong>*</strong></span><asp:TextBox ID="txtNaration" runat="server" CssClass="form-control" Height="42px" TabIndex="5" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            </div>
                        </div>
                    <div class="box-body">
	                    <div class="col-md-4">
                          <div class="box box-widget widget-user-2">
                <div class="widget-user-header bg-maroon">
                  <h5 align="center">Account Info</h5>
<%--                  <h5 class="widget-user-desc">Lead Developer</h5>--%>
                </div>
                <div class="box-footer no-padding"> 
                     <div class="col-md-12">
                  <ul class="nav nav-stacked">
                    <li><a style="font-size: small">Account Name
                        <span class="pull-right badge bg-teal"><asp:Label ID="Label1" runat="server"></asp:Label></span></a></li>
                      <li><a style="font-size: small">Product Name
                          <span class="pull-right badge bg-teal"><asp:Label ID="Label2" runat="server"></asp:Label></span></a></li>
                    <li><a style="font-size: small">Branch
                        <span id="Branch" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label3" runat="server"></asp:Label></span></a></li>

                     <li><a style="font-size: small">Book Balance
                        <span id="BookBalance" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label4" runat="server"></asp:Label></span></a></li>

                      <li><a style="font-size: small">Effective Balance
                        <span id="EffectiveBal" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label5" runat="server"></asp:Label></span></a></li>

                       <li><a style="font-size: small">Usable Balance
                        <span id="UsableBal" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label6" runat="server"></asp:Label></span></a></li>

                    <li><a style="font-size: small">Source Type
                        <span id="SourceType" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label7" runat="server"></asp:Label></span></a></li>

                      <li><a style="font-size: small">Source
                          <span class="pull-right badge bg-teal"><asp:Label ID="Label8" runat="server"></asp:Label></span></a></li>
                    
                        <li><a style="font-size: small">Account Status
                        <span id="AcctStatus" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label9" runat="server"></asp:Label></span></a></li>

                       <li><a style="font-size: small">Total Charge
                        <span id="Span1" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label12" runat="server"></asp:Label></span></a></li>

                      <li><a style="font-size: small">
                        <span id="Span2" class="pull-right badge bg-teal" runat="server"><asp:HyperLink ID="LnkCharge0" runat="server">HISTORY</asp:HyperLink></span></a></li>
                       <li><a style="font-size: small">
                       <span id="Span3" class="pull-right badge bg-teal" runat="server"><asp:HyperLink ID="LnkCharge" runat="server" Visible="False">View Charge Detail</asp:HyperLink></span></a></li>
                  </ul>
                         </div>
                </div>
              </div>
                        </div>
                        <div class="col-md-4">
			            <div class="box box-widget widget-user-2">
                <div class="widget-user-header bg-yellow">
                  <h5 align="center">Payment Info</h5>
<%--                  <h5 class="widget-user-desc">Lead Developer</h5>--%>
                </div>
                <div class="box-footer no-padding"> 
                     <div class="col-md-12">
                  <ul class="nav nav-stacked">
                   
                      <li><a style="font-size: small">Currency
                          <span><asp:DropDownList ID="drpCurrency" runat="server" AutoPostBack="True" CssClass="form-control" Font-Size="Small">
                                    </asp:DropDownList></span></a></li>
                    
                        <li><a style="font-size: small">Rate
                        <span id="Span8" runat="server"><asp:TextBox ID="txtRate" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox></span></a></li>

                       <li><a style="font-size: small">Tran Amount
                        <span id="Span9" runat="server"><asp:TextBox ID="txtTransAmount" runat="server" Font-Size="Small" ReadOnly="True"
                                        CssClass="form-control"></asp:TextBox></span></a></li>

                  </ul>
                         </div>
                </div>
              </div>
                    </div>
 </div>                
        </div>
    </div>
                <div class="panel-footer">
                            
                              
                            <asp:Button ID="btnSubmit" runat="server" BackColor="#C0C0FF" Text="Submit" 
                                ValidationGroup="News"  CssClass="btn bg-purple btn-flat margin"  />
                                 
                            <asp:Button ID="btnReset" runat="server" BackColor="#C0C0FF" Text="Reset" CssClass="btn bg-maroon btn-flat margin" />
                                  
                            <asp:Button ID="btnAppoff" runat="server" BackColor="#C0C0FF" Enabled="False" Visible="False"
                                Text="Forward to Approving Officer" ValidationGroup="News" CssClass="btn bg-green btn-flat margin" />
                               
                           <asp:Label ID="Label10" runat="server" Visible="False" Width="100px"></asp:Label>
                      
                            <asp:Label ID="Label11" runat="server" Visible="False" Width="213px"></asp:Label>
                       
                            <asp:TextBox ID="txtNoRow" runat="server" AutoPostBack="True" Font-Size="Small" 
                                TabIndex="4" Visible="False" Width="94px"></asp:TextBox>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Prime %>" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [AccountNumber],[Accounttitle] + ' ('+Accountnumber+')' Accounttitle from [tbl_casaaccount] where node_id = @Node_id ORDER By [Accounttitle ]"
                             OldValuesParameterFormatString="original_{0}" ConflictDetection="CompareAllValues">
                             <SelectParameters>
                <asp:ProfileParameter Name="Node_id" PropertyName="Node_id" Type="int16" />
             </SelectParameters>        
                            </asp:SqlDataSource>
                       
                            <asp:HyperLink ID="HypAuth" runat="server" Visible="False">Override</asp:HyperLink>
                    <tr>
                        <td colspan="3" style="height: 18px; text-align: center">
                                 <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="100%">
                            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" Font-Size="Small" Height="86px" PageSize="1" 
                                Width="100%" CssClass="table table-bordered table-hover dataTable">
                                <Columns>
                                    <asp:BoundField DataField="Tillaccountno" HeaderText="Till Account" />
                                    <asp:BoundField DataField="TranDate" DataFormatString="{0:dd/MM/yyyy}" 
                                        HeaderText="TranDate" HtmlEncode="False">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DRtotal" DataFormatString="{0:n}" HeaderText="Debit" 
                                        HtmlEncode="False">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DRcount" HeaderText="Total DR" />
                                    <asp:BoundField DataField="CRtotal" DataFormatString="{0:n}" 
                                        HeaderText="Credit" />
                                    <asp:BoundField DataField="CRcount" HeaderText="Total CR" />
                                    <asp:BoundField DataField="total" DataFormatString="{0:n}" HeaderText="Balance">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                                <RowStyle BackColor="White" Font-Size="8pt" ForeColor="#003399" />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                            </asp:GridView>
                                     </asp:Panel> 
                            <br />
                        </td>
                    </tr>
                </div>
              
       
    </div>
    </ContentTemplate> 
    </asp:UpdatePanel> </asp:Content>

