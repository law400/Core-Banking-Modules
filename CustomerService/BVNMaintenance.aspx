<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false"   CodeFile="BVNMaintenance.aspx.vb"  Inherits="BVNMaintenance" title="Cash Deposit Page" %>
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
<div class="box-blue">
        <div class="content">
            &nbsp;
            <table border="2" bordercolor="#330099">
                <tr>
                    <td style="width: 100px">
            <table border="0" bordercolor="#0000cc" style="width: 573px; height: 422px;">
                <tr>
                    <td valign="bottom">
                        <table style="width: 336px; height: 216px;">
                            <tr>
                                <td style="width: 974px; height: 30px;">
                                    <asp:Literal ID="Literal17" runat="server" Text="Account Number" /></td>
                                <td style="width: 100px; height: 30px;">
                        <asp:TextBox ID="txtAcNumber" runat="server" Width="188px" AutoPostBack="True" TabIndex="1" Font-Size="Small"></asp:TextBox></td>
                                <td style="width: 100px; height: 30px;">
                                    <asp:HyperLink
                                        ID="hypAccount" runat="server" Height="23px" 
                                        ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink></td>
                            </tr>
                            <tr>
                                <td style="width: 974px">
                                    BVN </td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtBVNNumber" runat="server" Font-Size="Small" TabIndex="2" 
                                        Width="144px"></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 974px">
                                    <asp:Literal ID="Literal18" runat="server" 
                                        Text="D.O.B" />
                                </td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtValueDate" runat="server" Font-Size="Small" TabIndex="2" 
                                        Width="144px"></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                    <asp:HyperLink ID="hypValueDate" runat="server" ImageUrl="~/Images/pdate.gif">HyperLink</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 974px">
                                    &nbsp;</td>
                                <td style="width: 100px">
                                    &nbsp;</td>
                                <td style="width: 100px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 974px">
                                    &nbsp;</td>
                                <td style="width: 100px">
                                    &nbsp;</td>
                                <td style="width: 100px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 974px">
                                    &nbsp;</td>
                                <td style="width: 100px">
                                    &nbsp;</td>
                                <td style="width: 100px">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" style="width: 100px;" valign="top">
                        &nbsp;<table style="width: 241px; background-color: #ccccff">
                            <tr>
                                <td colspan="2" style="height: 22px; background-color: #FF9E0D;">
                                    <span style="font-weight: bold; font-size: 12pt; color: #000099">Account Info</span></td>
                            </tr>
                            <tr>
                                <td style="width: 222px; height: 15px; font-weight: bold; color: black;">Account Name :&nbsp;</td>
                                <td style="width: 100px; height: 15px">
                                    <asp:Label ID="Label1" runat="server" ForeColor="Black" Width="124px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 222px">
                                    <strong><span style="color: #000000">Product Name
                                    &nbsp;:&nbsp;</span></strong></td>
                                <td style="width: 100px">
                                    <asp:Label ID="Label2" runat="server" ForeColor="Black" Width="128px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 222px">
                                    <strong><span style="color: #000000">Branch :&nbsp;</span></strong></td>
                                <td style="width: 100px">
                                    <asp:Label ID="Label3" runat="server" ForeColor="Black" Width="126px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 222px">
                                    <strong style="font-weight: bold; color: black">Book Balance :&nbsp;</strong></td>
                                <td style="width: 100px">
                                    <asp:Label ID="Label4" runat="server" ForeColor="Black" Width="125px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 222px; height: 18px">
                                    <strong style="font-weight: bold; color: black">Effective Balance :&nbsp;</strong></td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label5" runat="server" ForeColor="Black" Width="126px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 222px; height: 18px">
                                    <strong><span style="color: black; font-weight: bold;">Usable Balance :</span></strong></td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label6" runat="server" ForeColor="Black" Width="125px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 222px; height: 18px; font-weight: bold; color: black;">Account 
                                    Type :</td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label7" runat="server" ForeColor="Black" Width="123px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 222px; height: 18px; font-weight: bold; color: black;">Profile :</td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label8" runat="server" ForeColor="Black" Width="122px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">Account Status :</td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label9" runat="server" ForeColor="Black" Width="122px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; width: 222px; color: black; height: 18px">BVN :</td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label10" runat="server" ForeColor="Black" Width="122px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 18px" valign="top">
                        <asp:TextBox ID="txtNoRow" runat="server" AutoPostBack="True" Font-Size="Small" 
                            TabIndex="4" Visible="False" Width="94px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 18px; text-align: center">
                                    <asp:HyperLink ID="HypAuth" runat="server" Visible="False">Override</asp:HyperLink>
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="68px" ValidationGroup="News" BackColor="#C0C0FF" />
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="68px" ValidationGroup="News" BackColor="#C0C0FF" />
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" BackColor="#C0C0FF" /><asp:Button ID="btnReturn" runat="server" Text="Return" Width="68px" BackColor="#C0C0FF" />
                                    <asp:Button ID="btnAppoff" runat="server" BackColor="#C0C0FF" Enabled="False" 
                                        Text="Forward to Approving Officer" ValidationGroup="News" Width="179px" 
                                        Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 18px; text-align: center">
                        &nbsp;</td>
                </tr>
            </table>
                    </td>
                </tr>
            </table>
        </div>
       
    </div>
    </ContentTemplate> 
    </asp:UpdatePanel> </asp:Content>

