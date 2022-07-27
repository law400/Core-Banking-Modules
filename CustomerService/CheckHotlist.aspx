<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="CheckHotlist.aspx.vb" Inherits="CustomerService_CheckHotlist" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td>
                &nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                <div style="text-align: left">
                                    <table style="width: 647px">
                                        <tr>
                                            <td colspan="5" style="height: 27px">
                                                <div class="box-blue">
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 16px" colspan="2">
                                                <asp:RadioButtonList ID="RDBHotList" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="2" Selected="True">HotListed</asp:ListItem>
                                                    <asp:ListItem Value="1">De-HotListed</asp:ListItem>
                                                </asp:RadioButtonList></td>
                                            <td style="width: 37px; height: 16px">
                                            </td>
                                            <td style="width: 94px; height: 16px">
                                            </td>
                                            <td style="width: 100px; height: 16px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 109px; height: 16px">
                                                AccountNumber</td>
                                            <td style="height: 16px" colspan="2">
                                                <asp:TextBox ID="txtAcctNo" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small" Width="169px"></asp:TextBox>
                        <asp:HyperLink ID="hypAccount" runat="server" Height="17px" 
                            ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink></td>
                                            <td style="width: 94px; height: 16px">
                                                AccountName</td>
                                            <td style="width: 100px; height: 16px">
                                                <asp:TextBox ID="txtAcctName" runat="server" Font-Size="Small" Width="173px" 
                                                    ReadOnly="True"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 109px; height: 16px">
                                                ChequeBook Type</td>
                                            <td style="width: 119px; height: 16px"><asp:DropDownList ID="DrpChkBook1" runat="server" AutoPostBack="True">
                                            </asp:DropDownList></td>
                                            <td style="width: 37px; height: 16px">
                                            </td>
                                            <td style="width: 94px; height: 16px">
                                                Value Date</td>
                                            <td style="width: 100px; height: 16px">
                                                <asp:TextBox ID="txtValueDate" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small" Width="116px"></asp:TextBox><asp:HyperLink
                                                    ID="hypValueDate" runat="server" ImageUrl="~/Images/pdate.gif" 
                                                    Width="17px">HyperLink</asp:HyperLink></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 109px; height: 16px">
                                                StartNo</td>
                                            <td style="width: 119px; height: 16px">
                                                <asp:TextBox ID="txtStart2" runat="server" AutoPostBack="True" Font-Size="Small" Width="87px"></asp:TextBox></td>
                                            <td style="width: 37px; height: 16px">
                                            </td>
                                            <td style="width: 94px; height: 16px">
                                                EndNo</td>
                                            <td style="width: 100px; height: 16px">
                                                <asp:TextBox ID="txtEnd2" runat="server" AutoPostBack="True" Font-Size="Small" Width="87px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 109px; height: 16px" valign="top">
                                                Reason</td>
                                            <td style="width: 119px; height: 16px">
                                                <asp:TextBox ID="txtReason" runat="server" AutoPostBack="True" Font-Size="Small"
                                                    Height="43px" TextMode="MultiLine" Width="156px"></asp:TextBox></td>
                                            <td style="width: 37px; height: 16px">
                                            </td>
                                            <td style="width: 94px; height: 16px">
                                            </td>
                                            <td style="width: 100px; height: 16px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 109px; height: 16px">
                                            </td>
                                            <td style="width: 119px; height: 16px">
                                            </td>
                                            <td style="width: 37px; height: 16px">
                                            </td>
                                            <td style="width: 94px; height: 16px">
                                            </td>
                                            <td style="width: 100px; height: 16px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" style="height: 16px" align="center">
                        <asp:Button ID="Btnsubmit" runat="server" Font-Size="Small" Text="Submit" Width="58px" BackColor="#C0C0FF" /><asp:Button ID="Btncancel" runat="server" Font-Size="Small" Text="Reset" Width="62px" BackColor="#C0C0FF" /></td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
        </tr>
    </table>
</asp:Content>

