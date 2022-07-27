<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master"  AutoEventWireup="false"   CodeFile="CloseAccount.aspx.vb" Inherits="CustomerService_CloseAccount" title="Close Account Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	 <script type="text/javascript" src="../js/jquery-1.7.2.min.js"></script>
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

    <div class="box box-info">
        <div class="form-group">
         <tr>
                
                                           
                                                <br />
                
                                           
                                                <asp:Label ID="Label15" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                           
                                        </tr>
                                        <tr>
</div>
<div class="box-body">
    <div class="row">

        <div class="form-group">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="100%">
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
        
        <div class="col-md-6">
                           <div class="form-group" style="font-size: small"> 
                            <tr>
                                <td style="width: 974px">
                                    Account Number<span style="color: #FF0000"><strong>*</strong></span></td>
                                </strong></span>
                                <td style="width: 100px">
                                    &nbsp;
                                    <asp:HyperLink ID="hypAccount" runat="server" Height="27px" ImageUrl="~/Images/iconbar_previewtab_on.gif" Visible="True">HyperLink</asp:HyperLink>
                                    <asp:TextBox ID="txtAcNumber" runat="server" AutoPostBack="True" 
                                        Font-Size="Small" TabIndex="1" CssClass="form-control"></asp:TextBox>
                                </td>
                               
                            </tr>
                            </div>
                            
                            <div class="form-group" >
                            <tr>
                                <td style="width: 974px">
                                    Value Date<span style="color: #FF0000"><strong>*</strong></span></td>
                                </strong></span>
                                <td style="width: 100px">
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
                                    Total Charge<span style="color: #FF0000"><strong>*</strong></span></td>
                                </strong></span>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtcharges" runat="server" AutoPostBack="True" 
                                        Font-Size="Small" TabIndex="3" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            </div>
                            
                            <div class="form-group" >
                            <tr>
                                <td style="width: 974px">
                                    Narration<asp:TextBox ID="txtNaration" runat="server" CssClass="form-control" Height="42px" TabIndex="5" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>

                                <tr>
                                            <td class="first" style="width: 136px">
                                                Balance Moved to</td>
                                            <td style="width: 274px">
                                                <asp:TextBox ID="txtMigrated" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small" TabIndex="6" Visible="False" CssClass="form-control"></asp:TextBox>
                                                <asp:HyperLink ID="HyperLink1" runat="server" Height="22px" 
                                                    ImageUrl="~/Images/iconbar_previewtab_on.gif" Visible="False">HyperLink</asp:HyperLink>
                                                <asp:DropDownList ID="DrpMigrated" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>

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

                        <li><a style="font-size: small">Lien
                        <span id="Lien" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label13" runat="server"></asp:Label></span></a></li>

                       <li><a style="font-size: small">OD/TOD
                        <span id="Span1" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label14" runat="server"></asp:Label></span></a></li>

                    <li><a style="font-size: small">Source Type
                        <span id="SourceType" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label7" runat="server"></asp:Label></span></a></li>

                      <li><a style="font-size: small">Source
                          <span class="pull-right badge bg-teal"><asp:Label ID="Label8" runat="server"></asp:Label></span></a></li>
                    
                        <li><a style="font-size: small">Account Status
                        <span id="AcctStatus" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label9" runat="server"></asp:Label></span></a></li>

                       <li><a style="font-size: small">Dr Interest
                        <span id="Span2" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label10" runat="server"></asp:Label></span></a></li>


                       <li><a style="font-size: small">Cr Interest
                        <span id="Span3" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label11" runat="server"></asp:Label></span></a></li>


                       <li><a style="font-size: small">Pending Charges
                        <span id="Span4" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label12" runat="server"></asp:Label></span></a></li>

                       <li><a style="font-size: small">Closing Charges
                        <span id="Span5" class="pull-right badge bg-teal" runat="server"><asp:Label ID="Label16" runat="server"></asp:Label></span></a></li>
                  </ul>
                         </div>
                </div>
              </div>
                          
           
                            
                        </div>


        </div>

    </div>

       <div class="box-footer">


             <tr>
                                <td colspan="3" style="height: 18px; text-align: center">
                                     <div class="col-md-6"> 
                                    <asp:Button ID="Btnsubmit" runat="server" BackColor="#C0C0FF" Width="100%" Text="Submit" ValidationGroup="News" CssClass="btn bg-purple btn-flat margin" />
                                   </div>
                                     <div class="col-md-6"> 
                                          <asp:Button
                                        ID="btnReset" runat="server" BackColor="#C0C0FF" Text="Reset" Width="100%" CssClass="btn bg-maroon btn-flat margin" />
                                         </div>
                                    </td>
                            </tr>

           </div>
    </div>



<%--<div class="box-blue">
        <div class="content">
            <table border="2" bordercolor="#330099">
                <tr>
                    <td style="width: 100px">
                        <table border="0" bordercolor="#0000cc" style="width: 573px; height: 422px">
                            <tr>
                                <td colspan="2" valign="bottom">
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" Font-Size="Small" PageSize="1" Width="357px">
                                        <PagerSettings FirstPageText="First" LastPageText="Last" 
                                            Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Image ID="Image1" runat="server" 
                                                        ImageUrl='<%# "Handler.ashx?id=" + cType(Eval("mandateid"),String)  %>' />
                                                    <asp:Image ID="Image2" runat="server" 
                                                        ImageUrl='<%# "Handler2.ashx?id=" + cType(Eval("mandateid"),String)  %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Literal ID="Literal1" runat="server" 
                                                        Text='<%# "Signatory :" + Eval("signatoryname") %>'></asp:Literal>
                                                    <br />
                                                    <asp:Literal ID="Literal2" runat="server" 
                                                        Text='<%# "Designatiton :" + Eval("designation") %>'></asp:Literal>
                                                    <br />
                                                    <asp:Literal ID="Literal3" runat="server" 
                                                        Text='<%# "Mandate Instruction :" + Eval("mandatedesc1") %>'></asp:Literal>
                                                    <br />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    &nbsp;
                                    <table style="width: 371px">
                                        <tr>
                                            <th class="first" style="height: 29px" colspan="2">
                                                <asp:Label ID="Label15" runat="server" ForeColor="Red"></asp:Label>
                                            </th>
                                        </tr>
                                        <tr>
                                            <th class="first" style="width: 136px; height: 29px">
                                                Account Number*</th>
                                            <th style="width: 274px; height: 29px">
                                                <asp:TextBox ID="txtAcNumber" runat="server" AutoPostBack="True" 
                                                    Font-Size="X-Small" TabIndex="1" Width="154px"></asp:TextBox>
                                                <asp:HyperLink ID="hypAccount" runat="server" Height="16px" 
                                                    ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink>
                                            </th>
                                        </tr>
                                        <tr class="row-a">
                                            <td class="first" style="width: 136px">
                                                Value Date*</td>
                                            <td style="width: 274px">
                                                <asp:TextBox ID="txtValueDate" runat="server" Font-Size="X-Small" TabIndex="2" 
                                                    Width="151px"></asp:TextBox>
                                                <asp:HyperLink ID="hypValueDate" runat="server" ImageUrl="~/Images/pdate.gif">HyperLink</asp:HyperLink></td>
                                        </tr>
                                        <tr class="row-b" style="color: #0000ff">
                                            <td class="first" style="width: 136px">
                                                Total Charge*</td>
                                            <td style="width: 274px">
                                                <asp:TextBox ID="txtCharges" runat="server" Font-Size="X-Small" TabIndex="2" 
                                                    Width="149px"></asp:TextBox></td>
                                        </tr>
                                        <tr class="row-a" style="color: #0000ff">
                                            <td class="first" style="width: 136px">
                                                Naration</td>
                                            <td style="width: 274px">
                                                <asp:TextBox ID="txtNaration" runat="server" Height="42px" TabIndex="5" 
                                                    TextMode="MultiLine" Width="160px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="row-a" style="color: #0000ff">
                                            <td class="first" style="width: 136px">
                                                &nbsp;</td>
                                            <td style="width: 274px">
                                                <asp:TextBox ID="txtMigrated" runat="server" AutoPostBack="True" 
                                                    Font-Size="X-Small" TabIndex="1" Visible="False" Width="149px"></asp:TextBox>
                                                <asp:HyperLink ID="HyperLink1" runat="server" Height="16px" 
                                                    ImageUrl="~/Images/iconbar_previewtab_on.gif" Visible="False">HyperLink</asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr class="row-b" style="color: #0000ff">
                                            <td class="first" style="width: 136px">
                                                &nbsp;</td>
                                            <td style="width: 274px">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="left" style="width: 100px" valign="bottom">
                                    &nbsp;<table style="width: 284px; background-color: #ccccff">
                                        <tr>
                                            <td colspan="2" style="height: 22px; background-color: #FF9E0D;">
                                                <span style="font-weight: bold; font-size: 12pt; color: #000099">Account Info</span></td>
                                        </tr>
                                        <tr>
                                            <td style="font-weight: bold; width: 222px; color: black; height: 15px">
                                                Account Name:&nbsp;</td>
                                            <td style="width: 100px; height: 15px">
                                                <asp:Label ID="Label1" runat="server" ForeColor="Black" Width="124px"></asp:Label></td>
                                        </tr>
                                        <tr style="font-weight: bold; color: #000000">
                                            <td style="width: 222px; height: 1px;">
                                                <span style="color: #000000">Product Name &nbsp;:&nbsp;</span></td>
                                            <td style="width: 100px; height: 1px;">
                                                <asp:Label ID="Label2" runat="server" ForeColor="Black" Width="128px"></asp:Label></td>
                                        </tr>
                                        <tr style="color: #000000">
                                            <td style="width: 222px; height: 11px;">
                                                <span style="color: #000000"><strong style="font-weight: bold; color: black">Branch:&nbsp;</strong></span></td>
                                            <td style="width: 100px; height: 11px;">
                                                <asp:Label ID="Label3" runat="server" ForeColor="Black" Width="126px"></asp:Label></td>
                                        </tr>
                                        <tr style="font-weight: bold; color: #000000">
                                            <td style="width: 222px; height: 5px;">
                                                Book Balance:&nbsp;</td>
                                            <td style="width: 100px; height: 5px;">
                                                <asp:Label ID="Label4" runat="server" ForeColor="Black" Width="125px"></asp:Label></td>
                                        </tr>
                                        <tr style="font-weight: bold; color: #000000">
                                            <td style="width: 222px; height: 19px;">
                                                Lien:</td>
                                            <td style="width: 100px; height: 19px;">
                                                <asp:Label ID="Label13" runat="server" ForeColor="Black" Width="125px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="font-weight: bold; color: #000000">
                                            <td style="width: 222px; height: 13px;">
                                                OD/TOD:</td>
                                            <td style="width: 100px; height: 13px;">
                                                <asp:Label ID="Label14" runat="server" ForeColor="Black" Width="125px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 222px; height: 18px">
                                                <strong style="font-weight: bold; color: black">Effective Balance:&nbsp;</strong></td>
                                            <td style="width: 100px; height: 18px">
                                                <asp:Label ID="Label5" runat="server" ForeColor="Black" Width="126px"></asp:Label></td>
                                        </tr>
                                        <tr style="font-weight: bold; color: #ffff00">
                                            <td style="width: 222px; height: 18px">
                                                <span style="font-weight: bold; color: black">Usable Balance:</span></td>
                                            <td style="width: 100px; color: #ffffff; height: 18px">
                                                <asp:Label ID="Label6" runat="server" ForeColor="Black" Width="125px"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                <span>Source Type:</span></td>
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
                                        <tr>
                                            <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                        Dr Interest:</td>
                                            <td style="width: 100px; height: 18px">
                                                <asp:Label ID="Label10" runat="server" ForeColor="Black" Width="122px"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                        Cr Interest:</td>
                                            <td style="width: 100px; height: 18px">
                                                <asp:Label ID="Label11" runat="server" ForeColor="Black" Width="122px"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                        Pending Charges:</td>
                                            <td style="width: 100px; height: 18px">
                                                <asp:Label ID="Label12" runat="server" ForeColor="Black" Width="122px"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                Closing Charges:</td>
                                            <td style="width: 100px; height: 18px">
                                                <asp:Label ID="Label16" runat="server" ForeColor="Black" Width="122px"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 18px" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 18px; text-align: center">
                                    <asp:Button ID="Btnsubmit" runat="server" BackColor="#C0C0FF" Text="Submit" ValidationGroup="News" /><asp:Button
                                        ID="btnReset" runat="server" BackColor="#C0C0FF" Text="Reset" /><asp:Button ID="btnReturn"
                                            runat="server" BackColor="#C0C0FF" Text="Return" /></td>
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

