<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master"  AutoEventWireup="false"   CodeFile="ManageCheckBook.aspx.vb" Inherits="CustomerService_ManageCheckBook" title="ManageCheckbook Page" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
<div class="box-blue">
        <div class="content">
            <table>
                <tr>
                    <th class="first" style="width: 116px; height: 29px">
                        Account Number</th>
                    <th style="height: 29px; width: 248px;">
                        <asp:TextBox ID="txtAcctNo1" runat="server" AutoPostBack="True" Font-Size="Small"
                            Width="189px"></asp:TextBox>
                        <asp:HyperLink ID="hypAccount" runat="server" Height="17px" 
                            ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink></th>
                    <th style="height: 29px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAcctNo1"
                            Display="Dynamic" ErrorMessage="Enter Accountnumber" ValidationGroup="News3"
                            Width="122px">Enter Accountnumber</asp:RequiredFieldValidator></th>
                    <th style="height: 29px">
                    </th>
                </tr>
                <tr class="row-a">
                    <td class="first" style="width: 116px">
                        Account Name</td>
                    <td style="width: 248px">
                        <asp:Label ID="lblName" runat="server"></asp:Label></td>
                    <td style="color: #0000ff">
                    </td>
                    <td style="color: #0000ff">
                    </td>
                </tr>
                <tr class="row-b" style="color: #0000ff">
                    <td class="first" style="width: 116px; height: 30px;">
                        Account Type</td>
                    <td style="width: 248px; height: 30px">
                        <asp:DropDownList ID="DrpAcctType1" runat="server" Font-Size="Small">
                        </asp:DropDownList></td>
                    <td style="color: #0000ff; height: 30px;">
                        Branch</td>
                    <td style="color: #0000ff; height: 30px;">
                        <asp:DropDownList ID="DrpBranch1" runat="server" AutoPostBack="True" Font-Size="Small">
                        </asp:DropDownList></td>
                </tr>
                <tr class="row-a" style="color: #0000ff">
                    <td class="first" style="width: 116px">
                        ChequeBook Type</td>
                    <td style="width: 248px">
                        <asp:DropDownList ID="DrpChkType1" runat="server" AutoPostBack="True" Font-Size="Small">
                        </asp:DropDownList></td>
                    <td style="color: #0000ff">
                        Branch to Collect</td>
                    <td style="color: #0000ff">
                        <asp:DropDownList ID="DrpBranch2" runat="server" AutoPostBack="True" Font-Size="Small">
                        </asp:DropDownList></td>
                </tr>
                <tr class="row-b" style="color: #0000ff">
                    <td class="first" style="width: 116px">
                        No Of Leaves</td>
                    <td style="width: 248px">
                        <asp:TextBox ID="txtnolv" runat="server" AutoPostBack="True" Font-Size="Small" 
                            Width="83px" ReadOnly="True"></asp:TextBox></td>
                    <td>
                        Cost Of Cheque Book</td>
                    <td>
                        <asp:TextBox ID="txtcost" runat="server" AutoPostBack="True" Font-Size="Small"
                            ReadOnly="True" Width="96px"></asp:TextBox></td>
                </tr>
                <tr class="row-a" style="color: #0000ff">
                    <td class="first" style="width: 116px">
                        Request Date</td>
                    <td style="width: 248px">
                        <asp:TextBox ID="txtReqDate" runat="server" Font-Size="Small" 
                            Width="143px"></asp:TextBox>
                        <asp:HyperLink ID="hypValueDate" runat="server" ImageUrl="~/Images/pdate.gif">HyperLink</asp:HyperLink>
                    </td>
                    <td style="color: #0000ff">
                        Total Cost to Customer</td>
                    <td style="color: #0000ff">
                        <telerik:RadNumericTextBox ID="txttotcost" Runat="server" AutoPostBack="True" 
                            Width="96px">
                        </telerik:RadNumericTextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="txttotcost" ErrorMessage="*Enter total cost" 
                            ValidationGroup="News3"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="row-b" style="color: #0000ff">
                    <td class="first" style="width: 116px">
                        Start Serial No</td>
                    <td style="width: 248px">
                        <telerik:RadNumericTextBox ID="txtstart" Runat="server" AutoPostBack="True">
                            <NumberFormat DecimalDigits="0" GroupSeparator="" />
                        </telerik:RadNumericTextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="txtstart" ErrorMessage="*Enter Start Serial No" 
                            ValidationGroup="News3"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        End Serial No</td>
                    <td>
                        <asp:TextBox ID="txtend" runat="server" AutoPostBack="True" Font-Size="Small" 
                            Width="92px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr class="row-a" style="color: #0000ff">
                    <td class="first" style="width: 116px">
                        Narration</td>
                    <td style="width: 248px">
                        <asp:TextBox ID="txtNarration" runat="server" Font-Size="Small"
                            Height="43px" TextMode="MultiLine" Width="179px"></asp:TextBox></td>
                    <td style="color: #0000ff">
                    </td>
                    <td style="color: #0000ff">
                    </td>
                </tr>
                <tr class="row-b" style="color: #0000ff">
                    <td class="first" style="width: 116px">
                    </td>
                    <td style="width: 248px">
                        <asp:Button ID="btnsubmit" runat="server" BackColor="#C0C0FF" Text="Range" ValidationGroup="News3" /><asp:Button
                            ID="btnreset" runat="server" BackColor="#C0C0FF" Text="Reset" 
                            CausesValidation="False" /><asp:Button ID="Button1"
                                runat="server" BackColor="#C0C0FF" Text="Return" /></td>
                    <td>
                        <asp:Label ID="Label6" runat="server"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
    </div>
                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        Font-Size="Small" PageSize="20" Width="542px">
                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                            NextPageText="Next" PreviousPageText="Previous" />
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <input id="chkAll" runat="server" onclick="javascript:SelectAllCheckboxes(this);"
                                                                type="checkbox" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="Check1" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="SerialNo" HeaderText="SerialNo" SortExpression="SerialNo">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Block/Open" SortExpression="Status">
                                                    <ItemTemplate>
                                                    <%#DisplayBlock(CType(Eval("Status"), Integer))%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" Visible="False">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="trandate" HeaderText="Used Date" SortExpression="trandate" />
                                                    <asp:TemplateField Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="LblDoc1" runat="server" Text='<%#Eval("SerialNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle BackColor="#F7F7DE" />
                                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                            </ContentTemplate> 
                                            </asp:UpdatePanel> 
</asp:Content>

