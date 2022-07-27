<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="Hotlist.aspx.vb" Inherits="CustomerService_Hotlist" title="HotList Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
    <table style="width: 594px">
        <tr>
            <td colspan="4" style="height: 27px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 16px">
                <asp:RadioButtonList ID="RDBHotList" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="2">HotListed</asp:ListItem>
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
            <td colspan="4" style="height: 16px">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="#FF3300" 
                    Text="Enter a Range of Cheque number to be hotlisted Or Dehotlisted. If you have 1 Cheque, Pls enter the same Cheque Number as the SatrtNo and EndNo." 
                    Width="600px"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <th class="first" style="width: 161px; height: 29px">
                Accounnt Number</th>
            <th style="height: 29px">
                <asp:TextBox ID="txtAcctNo3" runat="server" AutoPostBack="True" Font-Size="Small"
                    Width="188px"></asp:TextBox></th>
            <th style="height: 29px">
            </th>
            <th style="height: 29px">
            </th>
        </tr>
        <tr class="row-a">
            <td class="first" style="width: 161px">
                Account Name</td>
            <td>
                <asp:TextBox ID="txtAcctName" runat="server" AutoPostBack="True" Font-Size="Small"
                    Width="191px" Height="56px" TextMode="MultiLine" ReadOnly="True"></asp:TextBox></td>
            <td style="color: #0000ff">
            </td>
            <td style="color: #0000ff">
            </td>
        </tr>
        <tr class="row-b" style="color: #0000ff">
            <td class="first" style="width: 161px">
                Start No</td>
            <td>
                <asp:TextBox ID="txtStart2" runat="server" AutoPostBack="True" Font-Size="Small"
                    Width="190px"></asp:TextBox></td>
            <td style="color: #0000ff">
                End No</td>
            <td style="color: #0000ff">
                &nbsp;<asp:TextBox ID="txtEnd2" runat="server" AutoPostBack="True" Font-Size="Small" Width="171px"></asp:TextBox></td>
        </tr>
        <tr class="row-a" style="color: #0000ff">
            <td class="first" style="width: 161px">
                Reason</td>
            <td>
                <asp:TextBox ID="txtReason" runat="server" AutoPostBack="True" Font-Size="Small"
                    Height="43px" TextMode="MultiLine" Width="188px"></asp:TextBox></td>
            <td style="color: #0000ff">
                Value Date</td>
            <td style="color: #0000ff">
                <asp:TextBox ID="txtValueDate" runat="server" AutoPostBack="True" Font-Size="Small"
                    Width="174px"></asp:TextBox><asp:HyperLink ID="imgdate3" runat="server" ImageUrl="~/Images/pdate.gif"
                        Width="17px">HyperLink</asp:HyperLink></td>
        </tr>
        <tr class="row-b" style="color: #0000ff">
            <td class="first" style="width: 161px">
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr class="row-a" style="color: #0000ff">
            <td class="first" style="width: 161px">
            </td>
            <td>
            </td>
            <td style="color: #0000ff">
            </td>
            <td style="color: #0000ff">
            </td>
        </tr>
        <tr class="row-b" style="color: #0000ff">
            <td class="first" style="width: 161px">
            </td>
            <td>
                <asp:Button ID="Btnsubmit" runat="server" BackColor="#C0C0FF" Font-Size="Small" Text="Submit"
                    Width="58px" /><asp:Button ID="Btncancel" runat="server" BackColor="#C0C0FF" Font-Size="Small"
                        Text="Reset" Width="62px" />
                <asp:Button ID="Button1" runat="server" BackColor="#C0C0FF" Font-Size="Small"
                        Text="Return" Width="62px" /></td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>

