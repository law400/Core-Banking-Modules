<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="Amortise.aspx.vb" Inherits="BankingOperations_Amortise" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
<div class="box-body">
    <div class="row">

         <h2><span style="color: #99CCFF"><strong>&nbsp; Amortise</strong></span></h2>
     

             <p>
                 &nbsp;</p>

         <div class="col-md-4">

              <div class="form-group"> 
                                                <tr>
                                                    <td style="width: 974px">
                                                        <span>Account To Debit (DR)*</span></td>
                                                    <td style="width: 100px; color: #ffff00">
                                                        &nbsp;
                                                        <asp:HyperLink ID="HyperLink2" runat="server" Height="21px" ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink>
                                                        <asp:TextBox ID="txtAcNumber" runat="server" AutoPostBack="True" Font-Size="Small"
                                                            TabIndex="1" CssClass="form-control" ></asp:TextBox>
                                                    </td>
                                                    <td style="width: 100px">
                                                        </td>
                                                </tr>
                                              </div>
                                              <div class="form-group"> 
                                                <tr>
                                                    <td style="width: 974px">
                                                        Account To Credit (CR)*</td>
                                                    <td style="width: 100px">
                                                        &nbsp;<asp:HyperLink ID="HyperLink3" runat="server" Height="25px" ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink>
                                                        <asp:TextBox ID="txtAccountNo2" runat="server" AutoPostBack="True" Font-Size="Small"
                                                            TabIndex="1" CssClass="form-control" ></asp:TextBox>
                                                    </td>
                                                    <td style="width: 100px">
                                                        </td>
                                                </tr>
                                            </div>
                                            <div class="form-group"> 
                                                <tr>
                                                    <td style="width: 974px; height: 23px">
                        Start Date*</td>
                                                    <td style="width: 100px; height: 23px">
                                                        &nbsp;
                                                        <asp:HyperLink ID="hypValueDate" runat="server" ImageUrl="~/Images/pdate.gif">HyperLink</asp:HyperLink>
                                                        <asp:TextBox ID="txtStartdate" runat="server" Font-Size="Small" TabIndex="2" CssClass="form-control" ></asp:TextBox>
                                                    </td>
                                                    <td style="width: 100px; height: 23px">
                                                        </td>
                                                </tr>
                                            </div>
                                            <div class="form-group"> 
                                                <tr>
                                                    <td style="width: 974px; height: 17px">
                        End Date*</td>
                                                    <td style="width: 100px; height: 17px">
                                                        &nbsp;&nbsp;
                                                        <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/Images/pdate.gif">HyperLink</asp:HyperLink>
                                                        <asp:TextBox ID="txtEnddate" runat="server" Font-Size="Small" TabIndex="2" CssClass="form-control" ></asp:TextBox></td>
                                                    <td style="width: 100px; height: 17px">
                                                        </td>
                                                </tr>
                                            </div>
                                            <div class="form-group"> 
                                                <tr>
                                                    <td style="width: 974px">
                                                        Amount*</td>
                                                    <td style="width: 100px">
                                                        <asp:TextBox ID="txtPayAmount" runat="server" AutoPostBack="True" TabIndex="3" CssClass="form-control" ></asp:TextBox></td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                                            </div>
                                            <div class="form-group"> 
                                                <tr>
                                                    <td style="width: 974px">
                                                        Period*</td>
                                                    <td style="width: 100px">
                                                        <asp:DropDownList ID="DDaccrualfreq" runat="server" AutoPostBack="True" CssClass="form-control">
                                                        </asp:DropDownList></td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                                            </div>
                                            <div class="form-group"> 
                                                <tr>
                                                    <td style="width: 974px">
                                                        Narration*</td>
                                                    <td style="width: 100px">
                                                        <asp:TextBox ID="txtNaration" runat="server" Height="53px" TabIndex="5" CssClass="form-control" TextMode="MultiLine"
                                                            ></asp:TextBox></td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                                            </div>
                                            <div class="form-group"> 
                                                <tr>
                                                    <td style="width: 974px">
                                                        Status</td>
                                                    <td style="width: 100px">
                                                        <asp:DropDownList ID="DDaccrualfreq0" runat="server" AutoPostBack="True" CssClass="form-control">
                                                            <asp:ListItem Value="0">--Choose a Status--</asp:ListItem>
                                                            <asp:ListItem Value="1">Active</asp:ListItem>
                                                            <asp:ListItem Value="3">Close</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 100px">
                                                    </td>
                                                </tr>
                                            </div>


             </div>
     
                   <div class="col-md-3" style=" color: #000000; background-color: #ccccff; font-size:11px; height: 391px;">
                                <div class="form-group"> 
                                                <tr>
                                                    <td colspan="2" style="height: 23px; background-color: #FF9E0D;">
                                                        <span style="font-weight: bold; font-size: 12pt; color: #000099">Debit Account 
                                                        Info</span></td>
                                                </tr>
                                    </div>
                                    <div class="form-group"> 
                                                <tr style="color: #000000">
                                                    <td style="font-weight: bold; width: 222px; color: black; height: 15px">
                                                        <span style="color: #000000">Account Name:&nbsp;</span></td>
                                                    <td style="width: 100px; color: #003399; height: 15px">
                                                        <asp:Label ID="Label1" runat="server" ForeColor="Black" Width="170px"></asp:Label>
                                                    </td>
                                                </tr>
                                      </div>
                                      <div class="form-group"> 
                                      <tr style="color: #000000">
                                                    <td style="width: 222px">
                                                        <span style="color: #000000">Product Name &nbsp;:&nbsp;</span></td>
                                                    <td style="width: 100px">
                                                        <asp:Label ID="Label2" runat="server" ForeColor="Black" Width="170px"></asp:Label>
                                                    </td>
                                                </tr>
                                        </div>
                                        <div class="form-group"> 
                                                <tr style="color: #003399">
                                                    <td style="width: 222px">
                                                        <span style="color: #000000">Branch:&nbsp;</span></td>
                                                    <td style="width: 100px; color: #003399">
                                                        <asp:Label ID="Label3" runat="server" ForeColor="Black" Width="170px"></asp:Label>
                                                    </td>
                                                </tr>
                                        </div>
                                        <div class="form-group"> 
                                                <tr>
                                                    <td style="width: 222px">
                                                        <span style="color: #000000">Book Balance:&nbsp;</span></td>
                                                    <td style="width: 100px; color: #003399">
                                                        <asp:Label ID="Label4" runat="server" ForeColor="Black" Width="125px"></asp:Label>
                                                    </td>
                                                </tr>
                                        </div>
                                        <div class="form-group"> 
                                                <tr>
                                                    <td style="width: 222px; height: 18px">
                                                        <span style="color: #000000">Effective Balance:&nbsp;</span></td>
                                                    <td style="width: 100px; color: #000000; height: 18px">
                                                        <asp:Label ID="Label5" runat="server" ForeColor="Black" Width="126px"></asp:Label>
                                                    </td>
                                                </tr>
                                        </div>
                                        <div class="form-group"> 
                                                <tr>
                                                    <td style="width: 222px; height: 18px">
                                                        <span>Usable Balance:</span></td>
                                                    <td style="width: 100px; color: #ffff00; height: 18px">
                                                        <asp:Label ID="Label6" runat="server" ForeColor="Black" Width="125px"></asp:Label>
                                                    </td>
                                                </tr>
                                        </div>
                                        <div class="form-group"> 
                                                <tr style="color: #ffff00">
                                                    <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                        <span style="color: #000000">Source Type:</span></td>
                                                    <td style="width: 100px; color: #003399; height: 18px">
                                                        <asp:Label ID="Label7" runat="server" ForeColor="Black" Width="170px"></asp:Label>
                                                    </td>
                                                </tr>
                                            </div>
                                            <div class="form-group"> 
                                                <tr>
                                                    <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                        <span>Source:</span></td>
                                                    <td style="width: 100px; color: #ffffff; height: 18px">
                                                        <asp:Label ID="Label8" runat="server" ForeColor="Black" Width="170px"></asp:Label>
                                                    </td>
                                                </tr>
                                            </div>
                                            <div class="form-group"> 
                                                <tr>
                                                    <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                        <span>Account Status:</span></td>
                                                    <td style="width: 100px; color: #ffffff; height: 18px">
                                                        <asp:Label ID="Label9" runat="server" ForeColor="Black" Width="122px"></asp:Label>
                                                    </td>
                                                </tr>
                                            </div>
                                            <div class="form-group"> 
                                                <tr>
                                                    <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                        Total Charge:</td>
                                                    <td style="width: 100px; color: #ffffff; height: 18px">
                                                        <asp:Label ID="Label22" runat="server" ForeColor="Black" Width="122px"></asp:Label>
                                                    </td>
                                                </tr>
                                            </div>
                                            <div class="form-group"> 
                                                <tr>
                                                    <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                        &nbsp;</td>
                                                    <td style="width: 100px; color: #ffffff; height: 18px">
                                                        <asp:HyperLink ID="LnkCharge" runat="server" Visible="False">View Charge Detail</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </div>

                                         </div>
                    
                        <div class="col-md-2" style="background-color: #ccccff; font-size:11px; height: 391px;">
                                <div class="form-group"> 
                                                <tr>
                                                    <td colspan="2" style="color: #000099; height: 23px; background-color: #FF9E0D">
                                                        <span style="font-weight: bold; font-size: 12pt; color: #000099">Payment Info</span>
                                                     </td>
                                                </tr>
                                        </div>
                                    <div class="form-group"> 
                                                <tr>
                                                    <td style="width: 79px; height: 15px">
                                                        <span style="font-weight: bold; color: #003399">Currency</span></td>
                                                    <td style=" color: #003399; height: 15px;">
                                                        <asp:DropDownList ID="drpCurrency" runat="server" AutoPostBack="True" CssClass="form-control">
                                                        </asp:DropDownList></td>
                                                </tr>
                                        </div>
                                        <div class="form-group"> 
                                                <tr>
                                                    <td style="width: 79px">
                                                        <span style="font-weight: bold; color: #003399">Rate</span></td>
                                                    <td style="width: 100px; color: #003399">
                                                        <asp:TextBox ID="txtRate" runat="server" ReadOnly="True"  CssClass="form-control"></asp:TextBox></td>
                                                </tr>
                                        </div>
                                        <div class="form-group"> 
                                                <tr style="color: #003399">
                                                    <td style="width: 79px">
                                                        <span style="font-weight: bold; color: #808080">Tran
                        Amount</span></td>
                                                    <td style="width: 100px; color: #808080"> 
                                                        <asp:TextBox ID="txtTransAmount" runat="server" Font-Size="Small" ReadOnly="True" CssClass="form-control"
                                                            ></asp:TextBox></td>
                                                </tr>
                                                </div>
                                            
                                            
                                         </div>
                        
                         <div class="col-md-3" style="background-color: #ccccff; font-size: 11px; top: 0px; left: 0px; height: 391px;">
                                    <div class="form-group"> 
                                                <tr>
                                                    <td colspan="2" style="height: 23px; background-color: #FF9E0D;">
                                                        <span style="font-weight: bold; font-size: 12pt; color: #000099">Credit Account 
                                                        Info</span></td>
                                                </tr>
                                        </div>
                                        <div class="form-group"> 
                                                <tr style="color: #000000">
                                                    <td style="font-weight: bold; width: 222px; color: black; height: 15px">
                                                        <span style="color: #000000">Account Name:&nbsp;</span></td>
                                                    <td style="width: 100px; color: #003399; height: 15px">
                                                        <asp:Label ID="Label10" runat="server" ForeColor="Black" Width="170px"></asp:Label>
                                                    </td>
                                                </tr>
                                            </div>
                                            <div class="form-group"> 
                                                <tr style="color: #000000">
                                                    <td style="width: 222px">
                                                        <span style="color: #000000">Product Name &nbsp;:&nbsp;</span></td>
                                                    <td style="width: 100px">
                                                        <asp:Label ID="Label11" runat="server" ForeColor="Black" Width="170px"></asp:Label>
                                                    </td>
                                                </tr>
                                            </div>
                                            <div class="form-group"> 
                                                <tr style="color: #000000">
                                                    <td style="width: 222px">
                                                        <span>Branch:&nbsp;</span></td>
                                                    <td style="width: 100px; color: #ffffff">
                                                        <asp:Label ID="Label12" runat="server" ForeColor="Black" Width="170px"></asp:Label>
                                                    </td>
                                                </tr>
                                            </div>
                                            <div class="form-group"> 
                                                <tr>
                                                    <td style="width: 222px">
                                                        <span style="color: #000000">Book Balance:&nbsp;</span></td>
                                                    <td style="width: 100px; color: #000000">
                                                        <asp:Label ID="Label13" runat="server" ForeColor="Black" Width="125px"></asp:Label>
                                                    </td>
                                                </tr>
                                            </div>
                                            <div class="form-group"> 
                                                <tr>
                                                    <td style="width: 222px; height: 18px">
                                                        <span>Effective Balance:&nbsp;</span></td>
                                                    <td style="width: 100px; color: #ffffff; height: 18px">
                                                        <asp:Label ID="Label14" runat="server" ForeColor="Black" Width="126px"></asp:Label>
                                                    </td>
                                                </tr>
                                            </div>
                                            <div class="form-group"> 
                                                <tr>
                                                    <td style="width: 222px; height: 18px">
                                                        <span>Usable Balance:</span></td>
                                                    <td style="width: 100px; color: #ffff00; height: 18px">
                                                        <asp:Label ID="Label15" runat="server" ForeColor="Black" Width="125px"></asp:Label>
                                                    </td>
                                                </tr>
                                            </div>
                                            <div class="form-group"> 
                                                <tr>
                                                    <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                        <span>Source Type:</span></td>
                                                    <td style="width: 100px; color: #ffff00; height: 18px">
                                                        <asp:Label ID="Label16" runat="server" ForeColor="Black" Width="170px"></asp:Label>
                                                    </td>
                                                </tr>
                                            </div>
                                            <div class="form-group"> 
                                                <tr>
                                                    <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                        <span>Source:</span></td>
                                                    <td style="width: 100px; color: #ffffff; height: 18px">
                                                        <asp:Label ID="Label17" runat="server" ForeColor="Black" Width="170px"></asp:Label>
                                                    </td>
                                                </tr>
                                            </div>
                                            <div class="form-group"> 
                                                <tr>
                                                    <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                        <span>Account Status:</span></td>
                                                    <td style="width: 100px; color: #ffffff; height: 18px">
                                                        <asp:Label ID="Label18" runat="server" ForeColor="Black" Width="122px"></asp:Label>
                                                    </td>
                                                </tr>
                                            </div>
                                            <div class="form-group"> 
                                                <tr>
                                                    <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                        Total Charge:</td>
                                                    <td style="width: 100px; color: #ffffff; height: 18px">
                                                        <asp:Label ID="Label21" runat="server" ForeColor="Black" Width="122px"></asp:Label>
                                                    </td>
                                                </tr>
                                            </div>
                                            <div class="form-group"> 
                                                <tr>
                                                    <td style="font-weight: bold; width: 222px; color: black; height: 18px">
                                                        &nbsp;</td>
                                                    <td style="width: 100px; color: #ffffff; height: 18px">
                                                        <asp:HyperLink ID="LnkCharge2" runat="server" Visible="False">View Charge Detail</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </div>
                            </div>
                    </div>
          
</div>     
                      
                 <div class="box-footer">
                    <tr>
                     <td colspan="4" style="height: 18px; text-align: center">
                           <div class="col-md-6">
                                            <asp:Button ID="btnSubmit" runat="server" BackColor="#C0C0FF" Width="100%" Text="Submit" CssClass="btn bg-purple btn-flat margin"  ValidationGroup="News" />
                               </div>
                           <div class="col-md-6">
                         <asp:Button
                                                ID="btnReset" runat="server" BackColor="#C0C0FF" Text="Reset" Width="100%" CssClass="btn bg-maroon btn-flat margin" />
                               </div>
                     </td>
                     </tr>
                  </div>
    
</div>
    
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>
