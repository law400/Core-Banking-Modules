<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false"   CodeFile="MandateDetail.aspx.vb" Inherits="CustomerService_MandateDetail" title="MandateInfo Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <script src="template/js/jquery-1.11.1.min.js"></script>

<asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
            AssociatedUpdatePanelID="updatePanel">
        <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #D7D7FF; opacity: 0.7;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
    </ProgressTemplate>
        </asp:UpdateProgress>

    <div class="panel panel-default">
        <div class="panel-heading">

        </div>
<div class="panel-body">
  

        <div class="form-group">
            <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="100%">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover dataTable" Font-Size="Small" PageSize="1" Width="99.4%">
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
         <div class="col-md-6">

             <div class="form-group"> 
                            <tr>
                                <td style="width: 974px">
                                    Account Number<strong><span style="color: #FF0000"> *</span></strong></td>
                                </span></strong>
                                <td style="width: 100px">
                                    &nbsp;
                                    <asp:HyperLink ID="hypAccount" runat="server" Height="27px" ImageUrl="~/Images/iconbar_previewtab_on.gif" Visible="True">HyperLink</asp:HyperLink>
                                    <asp:TextBox ID="txtAcNumber" runat="server" AutoPostBack="True" 
                                        Font-Size="Small" TabIndex="1" CssClass="form-control"></asp:TextBox>
                                </td>
                               
                            </tr>
                            </div>

               </div>



        <div class="col-md-5">
                           
                            <div class="box box-widget widget-user-2">
                <div class="widget-user-header bg-maroon">
                  <h3 class="widget-user-username" align="center">Account Info</h3>
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
                  </ul>
                         </div>
                </div>
              </div>
                        </div>


       </div>

    </div>

       <div class="panel-footer">
        
                                          <asp:Button
                                        ID="btnReset" runat="server" BackColor="#C0C0FF" Text="Reset" CssClass="btn bg-maroon btn-flat margin" />
                                        

           </div>

          </div>


    <%--<div class="box-blue">
        <h2>
            &nbsp;</h2>
        <div class="content">
            <table border="2" bordercolor="#330099">
                <tr>
                    <td style="width: 100px">
                        <table border="0" bordercolor="#0000cc" style="width: 573px; height: 91px">
                            <tr>
                                <td colspan="2" valign="top">
                                    <table>
                                        <tr>
                                            <td style="width: 100px">
                                    Account Number*<br />
                                            </td>
                                            <td style="width: 100px">
                                                <asp:TextBox ID="txtAcNumber" runat="server" AutoPostBack="True" Font-Size="Small"
                                                    TabIndex="1" Width="193px"></asp:TextBox></td>
                                            <td style="width: 100px">
                                                <asp:HyperLink ID="hypAccount" runat="server" Height="7px" ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px">
                                            </td>
                                            <td style="width: 100px">
                                            </td>
                                            <td style="width: 100px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px">
                                            </td>
                                            <td style="width: 100px">
                                            </td>
                                            <td style="width: 100px">
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        Font-Size="Small" PageSize="1" Width="357px">
                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                            NextPageText="Next" PreviousPageText="Previous" />
                                        <Columns>
                                            <asp:TemplateField> 
                                            <ItemTemplate> 
                                              <asp:Image ID="Image1" runat="server" ImageUrl='<%# "Handler.ashx?id=" + cType(Eval("serial"),String) + "&id2=" + Eval("accountnumber") %>' /> 
                                            <asp:Image ID="Image2" runat="server" ImageUrl='<%# "Handler2.ashx?id=" + cType(Eval("serial"),String) + "&id2=" + Eval("accountnumber")  %>' /> 
                                        </ItemTemplate> 
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Literal ID="Literal1" runat="server" Text='<%# "Signatory :" + Eval("signatoryname") %>'></asp:Literal>
                                <br />
                                <asp:Literal ID="Literal2" runat="server" Text='<%# "Designatiton :" + Eval("designation") %>'></asp:Literal>
                                <br />
                                 <asp:Literal ID="Literal3" runat="server" Text='<%# "Mandate Instruction :" + Eval("mandatedesc1") %>'></asp:Literal>
                                <br />
                               
                            </ItemTemplate>
                            </asp:TemplateField> 
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td align="left" style="font-weight: bold; width: 100px; color: #ffff00"
                                    valign="bottom">
                                    <span style="color: #000000"><span style="color: #000000"></span>
                                        <table style="width: 241px; color: #000000; background-color: #ccccff">
                                            <tr>
                                                <td colspan="2" style="height: 22px; background-color: #FF9E0D">
                                                    <span style="font-weight: bold; font-size: 12pt; color: #000099">Account Info: </span></td>
                                            </tr>
                                            <tr style="color: #000000">
                                                <td style="font-weight: bold; width: 222px; color: black; height: 15px">
                                                    Account Name:&nbsp;</td>
                                                <td style="width: 100px; height: 15px">
                                                    <asp:Label ID="Label1" runat="server" ForeColor="Black" Width="124px"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 222px">
                                                    <span style="color: #000000">Product Name &nbsp;:&nbsp;</span></td>
                                                <td style="width: 100px">
                                                    <asp:Label ID="Label2" runat="server" ForeColor="Black" Width="128px"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 222px">
                                                    <span style="color: #000000">Branch:&nbsp;</span></td>
                                                <td style="width: 100px">
                                                    <asp:Label ID="Label3" runat="server" ForeColor="Black" Width="126px"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 222px">
                                                    Book Balance:&nbsp;</td>
                                                <td style="width: 100px">
                                                    <asp:Label ID="Label4" runat="server" ForeColor="Black" Width="125px"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 222px; height: 18px">
                                                    Effective Balance:&nbsp;</td>
                                                <td style="width: 100px; height: 18px">
                                                    <asp:Label ID="Label5" runat="server" ForeColor="Black" Width="126px"></asp:Label></td>
                                            </tr>
                                            <tr style="color: #ffff00">
                                                <td style="width: 222px; height: 18px">
                                                    <span style="font-weight: bold; color: black">Usable Balance:</span></td>
                                                <td style="width: 100px; height: 18px">
                                                    <asp:Label ID="Label6" runat="server" ForeColor="Black" Width="125px"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                    Source Type:</td>
                                                <td style="width: 100px; height: 18px">
                                                    <asp:Label ID="Label7" runat="server" ForeColor="Black" Width="123px"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                    Source:</td>
                                                <td style="width: 100px; height: 18px">
                                                    <asp:Label ID="Label8" runat="server" ForeColor="Black" Width="122px"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                    Account Status:</td>
                                                <td style="width: 100px; height: 18px">
                                                    <asp:Label ID="Label9" runat="server" ForeColor="Black" Width="122px"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 283px; height: 18px" valign="top">
                                    <asp:Label ID="Label10" runat="server" Width="100px"></asp:Label></td>
                                <td style="width: 224px; height: 18px" valign="top">
                                </td>
                                <td align="left" style="width: 100px" valign="bottom">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 18px; text-align: center">
                                    <asp:Button ID="btnReturn" runat="server" BackColor="#C0C0FF" Text="Return" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>--%>
    </ContentTemplate>
    </asp:UpdatePanel> 
</asp:Content>

