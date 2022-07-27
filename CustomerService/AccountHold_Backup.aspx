<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master"  AutoEventWireup="false"   CodeFile="AccountHold.aspx.vb" Inherits="CustomerService_AccountHold" title="AccountHold Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
<div class="box-blue">
    <p>
        <span style="color: yellow"><strong>
            <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Horizontal"
                StaticEnableDefaultPopOutImage="False" Width="351px">
                <Items>
                    <asp:MenuItem ImageUrl="~/Images/pic2.gif" Text="Add Lien" Value="0"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="~/images/pic1.gif" Text="Release Lien" Value="1"></asp:MenuItem>
                    <asp:MenuItem ImageUrl="~/images/pic1.gif" Text="List" Value="2"></asp:MenuItem>
                </Items>
            </asp:Menu>
            &nbsp;</strong></span>&nbsp;<table>
                <tr>
                    <th class="first" style="height: 29px">
                        Account Number*</th>
                    <th style="height: 29px">
                        <asp:TextBox ID="Txtaccountnumber" runat="server" Font-Size="Small"
                            Width="182px" AutoPostBack="True"></asp:TextBox><asp:HyperLink ID="Hypsearch" runat="server" ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink></th>
                    <th style="height: 29px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Txtaccountnumber"
                            Display="Dynamic" ErrorMessage="Enter AccountNumber" ValidationGroup="News" Width="167px">Enter AccountNumber</asp:RequiredFieldValidator></th>
                    <th style="height: 29px">
                    </th>
                </tr>
                <tr class="row-a">
                    <td class="first">
                        Account Name</td>
                    <td>
                        <asp:TextBox ID="txtAccountName" runat="server" ReadOnly="True" Width="184px" Height="44px" TextMode="MultiLine"></asp:TextBox></td>
                    <td style="color: #0000ff">
                        Seq No</td>
                    <td style="color: #0000ff">
                        <asp:DropDownList ID="DrpSerial" runat="server" AutoPostBack="True" 
                            Visible="False">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtSeqNo" runat="server" Font-Size="Small" Width="90px"></asp:TextBox>
                    </td>
                </tr>
                <tr class="row-b" style="color: #0000ff">
                    <td class="first">
                        Amount</td>
                    <td>
                        <asp:TextBox ID="txtAmount" runat="server" Font-Size="Small" Width="183px" 
                            AutoPostBack="True">0.00</asp:TextBox></td>
                    <td style="color: #0000ff">
                        Start Date</td>
                    <td style="color: #0000ff">
                        <asp:TextBox ID="TxtStartDate" runat="server" Font-Size="Small" Width="182px"></asp:TextBox>
                        <asp:HyperLink ID="ImgDate" runat="server" ImageUrl="~/Images/pdate.gif">HyperLink</asp:HyperLink>
                    </td>
                </tr>
                <tr class="row-a" style="color: #0000ff">
                    <td class="first">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td style="color: #0000ff">
                        End Date</td>
                    <td style="color: #0000ff">
                        <asp:TextBox ID="TxtEnddate" runat="server" Font-Size="Small" Width="184px"></asp:TextBox>
                        <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/Images/pdate.gif">HyperLink</asp:HyperLink>
                    </td>
                </tr>
                <tr class="row-b" style="color: #0000ff">
                    <td class="first" valign="top">
                        Narration*</td>
                    <td valign="top">
                        <asp:TextBox ID="Txtnarration" runat="server" Height="54px" TextMode="MultiLine" Width="179px"></asp:TextBox>
                        </td>
                    <td valign="top">
                        Choose a Lien Option<asp:RadioButtonList ID="RDBLien" runat="server" 
                            AutoPostBack="True" Width="195px">
                            <asp:ListItem Selected="True" Value="0">--Choose a Lien Option</asp:ListItem>
                            <asp:ListItem Value="1">Lien On Balance
                            </asp:ListItem>
                            <asp:ListItem Value="4">Lien On DR Transactions</asp:ListItem>
                            <asp:ListItem Value="5">Lien On CR Transactions</asp:ListItem>
                            <asp:ListItem Value="6">Lien On all Transaction
                            </asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr class="row-a" style="color: #0000ff">
                    <td class="first">
                    </td>
                    <td>
                    </td>
                    <td style="color: #0000ff">
                    </td>
                    <td style="color: #0000ff">
                    </td>
                </tr>
                <tr class="row-b" style="color: #0000ff">
                    <td class="first">
                    </td>
                    <td>
                        <asp:Button ID="BtnSubmit" runat="server" BackColor="#C0C0FF" Font-Size="Small"
                            Text="Submit" ValidationGroup="News" Width="64px" /><asp:Button ID="BtnReset" runat="server"
                                BackColor="#C0C0FF" Font-Size="Small" Text="Reset" Width="51px" /><asp:Button ID="btnReturn"
                                    runat="server" BackColor="#C0C0FF" Font-Size="Small" Text="Return" 
                            Width="62px" /></td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
    </p>
        <div class="content">
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                &nbsp;<asp:ObjectDataSource ID="Smartobj1" runat="server" SelectMethod="SqlDs" TypeName="smartcon">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="Select accountnumber,HoldAmount,effective_dt,End_dt, case status when 1 then 'Active' when 2 then 'Suspended' else 'Closed' end as Status  from tbl_Holdtrans"
                                            Name="SqlString" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    CellPadding="4" DataSourceID="Smartobj1" CssClass="th" ForeColor="#333333" GridLines="None"
                                    Width="565px">
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="AccountNumber" HeaderText="AccountNumber">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Holdamount" DataFormatString="{0:g}" HeaderText="Lien Amount">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="effective_dt" HeaderText="Value Date">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="End_dt" HeaderText="End Date" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" />
                                    </Columns>
                                    <RowStyle BackColor="#EFF3FB" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                                &nbsp; &nbsp;&nbsp;
                            </asp:View>
                        </asp:MultiView>&nbsp;</div>
    </div>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>

