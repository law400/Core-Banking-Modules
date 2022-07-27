<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false"   CodeFile="ManageCheck.aspx.vb" Inherits="CustomerService_ManageCheck" title="Manage Cheques Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
<div class="box-blue">
        <div class="content">
            <table border="0" style="width: 298px; height: 187px; font-size: 8pt;" id="TABLE1" >
        
        <caption style="text-align: left;" >
            <span style="color: #000099"><span style="font-size: 12pt">
        <strong><span></span></strong>
            </span></span>
        </caption>
        <tr>
            <td colspan="4" style="height: 13px; width: 619px;">
                <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal"
                    StaticEnableDefaultPopOutImage="False" Width="315px">
                    <Items>
                        <asp:MenuItem ImageUrl="~/Images/pic2.gif" Text="Receipt" Value="0"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="~/images/pic1.gif" Text="Cheque Request" Value="1"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="~/images/pic1.gif" Text="HotList" Value="2"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </td>
        </tr>
                <tr>
                    <td colspan="4" style="height: 29px; width: 619px;">
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                <div style="text-align: left">
                                    <table style="width: 593px">
                                        <tr>
                                            <td colspan="5" style="height: 27px">
                                                <div class="box-blue">
                                                    <h2>
                                                        <span style="color: #ffffff"><strong>Receipt</strong></span></h2>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="height: 18px">
                                                <asp:RadioButtonList ID="RDBOption" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Value="1">Create New Receipt</asp:ListItem>
                                                    <asp:ListItem Value="2">Modify Existing Receipt</asp:ListItem>
                                                </asp:RadioButtonList></td>
                                            <td style="width: 23px; height: 18px">
                                            </td>
                                            <td style="width: 92px; height: 18px">
                                            </td>
                                            <td style="width: 100px; height: 18px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 85px; height: 18px">
                                                <asp:Label ID="Label1" runat="server" Text="Receipt ID" Visible="False"></asp:Label></td>
                                            <td style="width: 122px; height: 18px">
                                                <asp:TextBox ID="txtReceiptid" runat="server" AutoPostBack="True" Font-Size="Small" Width="87px" Visible="False"></asp:TextBox></td>
                                            <td style="width: 23px; height: 18px">
                                            </td>
                                            <td style="width: 92px; height: 18px">
                                            </td>
                                            <td style="width: 100px; height: 18px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 85px; height: 6px">
                                                Supplier</td>
                                            <td style="width: 122px; height: 6px">
                                                <asp:DropDownList ID="DrpSupplier" runat="server" AutoPostBack="True">
                                                </asp:DropDownList></td>
                                            <td style="width: 23px; height: 6px">
                                            </td>
                                            <td style="width: 92px; height: 6px">
                                                Order No</td>
                                            <td style="width: 100px; height: 6px">
                                                <asp:TextBox ID="txtOrder" runat="server" AutoPostBack="True" Font-Size="Small" Width="87px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtOrder"
                                                    Display="Dynamic" ErrorMessage="Enter Order No" ValidationGroup="News" Width="122px">Enter Order No</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 85px; height: 18px">
                                                Quantity</td>
                                            <td style="width: 122px; height: 18px">
                                                <asp:TextBox ID="txtQty" runat="server" AutoPostBack="True" Font-Size="Small" Width="87px"></asp:TextBox>
                                                </td>
                                            <td style="width: 23px; height: 18px">
                                            </td>
                                            <td style="width: 92px; height: 18px">
                                                Way Bill No</td>
                                            <td style="width: 100px; height: 18px">
                                                <asp:TextBox ID="txtWayBill" runat="server" AutoPostBack="True" Font-Size="Small" Width="87px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtWayBill"
                                                    Display="Dynamic" ErrorMessage="Enter WayBill ID" ValidationGroup="News" Width="122px">Enter WayBill ID</asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 85px; height: 18px">
                                                Cost</td>
                                            <td style="width: 122px; height: 18px">
                                                <asp:TextBox ID="txtCost" runat="server" AutoPostBack="True" Font-Size="Small" Width="87px"></asp:TextBox>
                                                </td>
                                            <td style="width: 23px; height: 18px">
                                            </td>
                                            <td style="width: 92px; height: 18px">
                                                Date Received</td>
                                            <td style="width: 100px; height: 18px">
                                                <asp:TextBox ID="txtDateReceived" runat="server" AutoPostBack="True" Font-Size="Small" Width="73px"></asp:TextBox><asp:HyperLink
                                                    ID="HyperLink2" runat="server" ImageUrl="~/Images/pdate.gif" Width="17px">HyperLink</asp:HyperLink></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 85px; height: 18px">
                                                Start SerialNo</td>
                                            <td style="width: 122px; height: 18px">
                                                <asp:TextBox ID="txtStartNo" runat="server" AutoPostBack="True" Font-Size="Small" Width="87px"></asp:TextBox>
                                                </td>
                                            <td style="width: 23px; height: 18px">
                                            </td>
                                            <td style="width: 92px; height: 18px">
                                                End SerialNo</td>
                                            <td style="width: 100px; height: 18px">
                                                <asp:TextBox ID="txtEndNo" runat="server" Font-Size="Small" Width="87px" ReadOnly="True"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 85px; height: 18px">
                                            </td>
                                            <td style="width: 122px; height: 18px">
                                            </td>
                                            <td style="width: 23px; height: 18px">
                                            </td>
                                            <td style="width: 92px; height: 18px">
                                            </td>
                                            <td style="width: 100px; height: 18px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 18px; text-align: center;" colspan="5">
                                                <asp:Button ID="BtnSubmit1" runat="server" Text="Submit" ValidationGroup="News" BackColor="#C0C0FF" /><asp:Button ID="BtnReset" runat="server" Text="Reset" BackColor="#C0C0FF" /></td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:View>
                            &nbsp;&nbsp;
                            <asp:View ID="View2" runat="server">
                                <div style="text-align: left">
                                    <table style="width: 594px">
                                        <tr>
                                            <td colspan="5" style="height: 27px">
                                                <div class="box-blue">
                                                    <h2>
                                                        <span style="color: #ffffff"><strong>Cheque Request</strong></span></h2>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 278px; height: 16px">
                                                Accountnumber</td>
                                            <td style="width: 167px; height: 16px">
                                                <asp:TextBox ID="txtAcctNo1" runat="server" AutoPostBack="True" Font-Size="Small" Width="158px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAcctNo1"
                                                    Display="Dynamic" ErrorMessage="Enter Accountnumber" ValidationGroup="News2"
                                                    Width="122px">Enter Accountnumber</asp:RequiredFieldValidator></td>
                                            <td style="width: 175px; height: 16px">
                                                <asp:HyperLink ID="hypAccount" runat="server" Height="7px" ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink></td>
                                            <td style="width: 292px; height: 16px">
                                                AccountName</td>
                                            <td style="width: 100px; height: 16px">
                                                <asp:TextBox ID="txtAcctName2" runat="server" AutoPostBack="True" Font-Size="Small" Width="175px" ReadOnly="True"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 278px; height: 17px">
                                                Account Type</td>
                                            <td style="width: 167px; height: 17px"><asp:DropDownList ID="DrpAcctType1" runat="server">
                                            </asp:DropDownList></td>
                                            <td style="width: 175px; height: 17px">
                                            </td>
                                            <td style="width: 292px; height: 17px">
                                                Account Branch</td>
                                            <td style="width: 100px; height: 17px"><asp:DropDownList ID="DrpBranch1" runat="server" AutoPostBack="True">
                                            </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 278px; height: 16px">
                                                ChequeBook Type</td>
                                            <td style="width: 167px; height: 16px"><asp:DropDownList ID="DrpChkType1" runat="server" AutoPostBack="True">
                                            </asp:DropDownList></td>
                                            <td style="width: 175px; height: 16px">
                                            </td>
                                            <td style="width: 292px; height: 16px">
                                                Collection Branch</td>
                                            <td style="width: 100px; height: 16px"><asp:DropDownList ID="DrpBranch2" runat="server" AutoPostBack="True">
                                            </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 278px; height: 16px" valign="top">
                                                Narrartion</td>
                                            <td style="width: 167px; height: 16px">
                                                <asp:TextBox ID="txtNarration" runat="server" AutoPostBack="True" Font-Size="Small" Height="43px"
                                                    TextMode="MultiLine" Width="156px"></asp:TextBox></td>
                                            <td style="width: 175px; height: 16px">
                                            </td>
                                            <td style="width: 292px; height: 16px" valign="top">
                                                Request Date</td>
                                            <td style="width: 100px; height: 16px" valign="top">
                                                <asp:TextBox ID="txtReqDate" runat="server" Font-Size="Small" Width="74px"></asp:TextBox><asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/Images/pdate.gif" Width="17px">HyperLink</asp:HyperLink></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 278px; height: 16px">
                                                </td>
                                            <td style="width: 167px; height: 16px">
                                            </td>
                                            <td style="width: 175px; height: 16px">
                                            </td>
                                            <td style="width: 292px; height: 16px">
                                            </td>
                                            <td style="width: 100px; height: 16px">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 278px; height: 16px">
                                            </td>
                                            <td style="width: 167px; height: 16px">
                                            </td>
                                            <td style="width: 175px; height: 16px">
                                            </td>
                                            <td style="width: 292px; height: 16px">
                                            </td>
                                            <td style="width: 100px; height: 16px">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 16px" colspan="5" align="center"><asp:Button ID="Button1" runat="server" Text="Submit" ValidationGroup="News2" BackColor="#C0C0FF" /><asp:Button ID="Button2" runat="server" Text="Reset" BackColor="#C0C0FF" /></td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:View>
                            <asp:View ID="View3" runat="server">
                                <div style="text-align: left">
                                    <table style="width: 594px">
                                        <tr>
                                            <td colspan="5" style="height: 27px">
                                                <div class="box-blue">
                                                    <h2>
                                                        <span style="color: #ffffff"><strong>HotList</strong></span></h2>
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
                                            <td style="width: 119px; height: 16px">
                                                <asp:TextBox ID="txtAcctNo3" runat="server" AutoPostBack="True" Font-Size="Small" Width="156px"></asp:TextBox></td>
                                            <td style="width: 37px; height: 16px">
                                            </td>
                                            <td style="width: 94px; height: 16px">
                                                AccountName</td>
                                            <td style="width: 100px; height: 16px">
                                                <asp:TextBox ID="txtAcctName" runat="server" AutoPostBack="True" Font-Size="Small" Width="173px"></asp:TextBox></td>
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
                                                <asp:TextBox ID="txtValueDate" runat="server" AutoPostBack="True" Font-Size="Small" Width="74px"></asp:TextBox><asp:HyperLink
                                                    ID="imgdate3" runat="server" ImageUrl="~/Images/pdate.gif" Width="17px">HyperLink</asp:HyperLink></td>
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
                            </asp:View>
                        </asp:MultiView></td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 29px; width: 619px;">
                        &nbsp;<asp:Button ID="Button3" runat="server" Font-Size="Small" Text="Return" Width="62px" BackColor="#C0C0FF" /></td>
                </tr>
            </table>
        </div>
    </div>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>

