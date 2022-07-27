<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="Chargeconc.aspx.vb" Inherits="CustomerService_Chargeconc" title="Charge Concession Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
<div class="box-blue">
        <h2>
            <span style="color: yellow"><strong>Charge Concession</strong></span></h2>
        <div class="content">
            &nbsp;
            <table border="2" bordercolor="#330099">
                <tr>
                    <td style="width: 100px">
            <table border="0" bordercolor="#0000cc" style="width: 573px; height: 422px;">
                <tr>
                    <td valign="bottom" colspan="2" rowspan="5">
                        <table style="width: 336px">
                            <tr>
                                <td style="width: 1485px">
                        Account Number*</td>
                                <td style="width: 100px">
                        <asp:TextBox ID="txtAcNumber" runat="server" Width="188px" AutoPostBack="True" TabIndex="1" Font-Size="Small"></asp:TextBox></td>
                                <td style="width: 162px">
                                    <asp:HyperLink
                                        ID="hypAccount" runat="server" Height="7px" ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink></td>
                            </tr>
                            <tr>
                                <td style="width: 1485px">
                                    Charge Type</td>
                                <td style="width: 100px">
                                    <asp:DropDownList ID="drpchargetype" runat="server" AutoPostBack="True" Font-Size="Small">
                                    </asp:DropDownList></td>
                                <td style="width: 162px">
                                    </td>
                            </tr>
                            <tr>
                                <td style="width: 1485px">
                                    Charge Rate</td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtPayAmount" runat="server" AutoPostBack="True" TabIndex="3" Width="95px" Font-Size="Small" ReadOnly="True"></asp:TextBox></td>
                                <td style="width: 162px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 1485px">
                                    Concession amount</td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtTellerNo" runat="server" TabIndex="4" Width="94px" Font-Size="Small" AutoPostBack="True"></asp:TextBox></td>
                                <td style="width: 162px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 1485px">
                                    Narration1*</td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtNaration" runat="server" TextMode="MultiLine" Height="42px" Width="160px" TabIndex="5"></asp:TextBox></td>
                                <td style="width: 162px">
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" style="width: 100px;" rowspan="5" valign="top">
                        &nbsp;<table style="width: 241px; background-color: #ccccff">
                            <tr>
                                <td colspan="2" style="height: 22px; background-color: #000099;">
                                    <span style="font-weight: bold; font-size: 12pt; color: #ffff00">Account Info</span></td>
                            </tr>
                            <tr>
                                <td style="width: 222px; height: 15px; font-weight: bold; color: black;">
                                    Account Name:&nbsp;</td>
                                <td style="width: 100px; height: 15px">
                                    <asp:Label ID="Label1" runat="server" ForeColor="Black" Width="124px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 222px">
                                    <strong><span style="color: #000000">Product Name &nbsp;:&nbsp;</span></strong></td>
                                <td style="width: 100px">
                                    <asp:Label ID="Label2" runat="server" ForeColor="Black" Width="128px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 222px">
                                    <strong><span style="color: #000000">Branch:&nbsp;</span></strong></td>
                                <td style="width: 100px">
                                    <asp:Label ID="Label3" runat="server" ForeColor="Black" Width="126px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 222px">
                                    <strong style="font-weight: bold; color: black">Book Balance:&nbsp;</strong></td>
                                <td style="width: 100px">
                                    <asp:Label ID="Label4" runat="server" ForeColor="Black" Width="125px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 222px; height: 18px">
                                    <strong style="font-weight: bold; color: black">Effective Balance:&nbsp;</strong></td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label5" runat="server" ForeColor="Black" Width="126px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 222px; height: 18px">
                                    <strong><span style="color: black; font-weight: bold;">Usable Balance:</span></strong></td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label6" runat="server" ForeColor="Black" Width="125px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 222px; height: 18px; font-weight: bold; color: black;">
                                    Source Type:</td>
                                <td style="width: 100px; height: 18px">
                                    <asp:Label ID="Label7" runat="server" ForeColor="Black" Width="123px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 222px; height: 18px; font-weight: bold; color: black;">
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
                    </td>
                </tr>
                <tr>
                </tr>
                <tr>
                </tr>
                <tr>
                </tr>
                <tr>
                </tr>
                <tr>
                    <td colspan="3" style="height: 18px" valign="top">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 18px; text-align: center">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="News" BackColor="#C0C0FF" /><asp:Button ID="btnReset" runat="server" Text="Reset" BackColor="#C0C0FF" /><asp:Button ID="btnReturn" runat="server" Text="Return" BackColor="#C0C0FF" /></td>
                </tr>
            </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>

