<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master"  AutoEventWireup="false" CodeFile="Receipt.aspx.vb" Inherits="CustomerService_Receipt" title="Receipt Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
    <table style="width: 593px">
        <tr>
            <td style="height: 18px">
                <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" 
                    Orientation="Horizontal" StaticEnableDefaultPopOutImage="False" Width="183px">
                    <Items>
                        <asp:MenuItem ImageUrl="~/Images/pic2.gif" Text="Add New" Value="0">
                        </asp:MenuItem>
                        <asp:MenuItem ImageUrl="~/images/pic1.gif" Text="Edit" Value="1"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="~/images/pic1.gif" Text="List" Value="2"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </td>
        </tr>
    </table>
    <table style="width: 678px">
        <tr>
            <th class="first" style="width: 144px; height: 29px">
                <asp:Label ID="Label1" runat="server" Text="Receipt ID"></asp:Label></th>
            <th style="width: 152px; height: 29px">
                <asp:TextBox ID="txtReceiptid" runat="server" AutoPostBack="True" 
                    Font-Size="Small" Width="171px"></asp:TextBox></th>
            <th style="height: 29px">
                Supplier</th>
            <th style="height: 29px">
                <asp:DropDownList ID="DrpSupplier" runat="server" AutoPostBack="True">
                </asp:DropDownList></th>
        </tr>
        <tr class="row-a">
            <td class="first" style="width: 144px">
                Quantity</td>
            <td style="width: 152px">
                <asp:TextBox ID="txtQty" runat="server" AutoPostBack="True" Font-Size="Small" Width="171px"></asp:TextBox></td>
            <td style="color: #0000ff">
                Order No</td>
            <td style="color: #0000ff">
                <asp:TextBox ID="txtOrder" runat="server" AutoPostBack="True" Font-Size="Small" Width="167px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtOrder"
                    Display="Dynamic" ErrorMessage="Enter Order No" ValidationGroup="News" Width="122px">Enter Order No</asp:RequiredFieldValidator></td>
        </tr>
        <tr class="row-b" style="color: #0000ff">
            <td class="first" style="width: 144px">
                Total Cost</td>
            <td style="width: 152px">
                <asp:TextBox ID="txtCost" runat="server" AutoPostBack="True" Font-Size="Small" Width="170px"></asp:TextBox></td>
            <td style="color: #0000ff">
                Way Bill No</td>
            <td style="color: #0000ff">
                <asp:TextBox ID="txtWayBill" runat="server" AutoPostBack="True" Font-Size="Small"
                    Width="167px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtWayBill"
                    Display="Dynamic" ErrorMessage="Enter WayBill ID" ValidationGroup="News" Width="122px">Enter WayBill ID</asp:RequiredFieldValidator></td>
        </tr>
        <tr class="row-a" style="color: #0000ff">
            <td class="first" style="width: 144px">
                Start SerialNo</td>
            <td style="width: 152px">
                <asp:TextBox ID="txtStartNo" runat="server" AutoPostBack="True" Font-Size="Small"
                    Width="170px"></asp:TextBox></td>
            <td style="color: #0000ff">
                Unit Price</td>
            <td style="color: #0000ff">
                <asp:TextBox ID="txtUnitPr" runat="server" AutoPostBack="True" Font-Size="Small"
                    Width="167px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr class="row-b" style="color: #0000ff">
            <td class="first" style="width: 144px">
                End SerialNo</td>
            <td style="width: 152px">
                <asp:TextBox ID="txtEndNo" runat="server" Font-Size="Small" ReadOnly="True" Width="169px"></asp:TextBox></td>
            <td>
                Variance</td>
            <td>
                <asp:TextBox ID="txtvariance" runat="server" AutoPostBack="True" Font-Size="Small"
                    Width="167px"></asp:TextBox></td>
        </tr>
        <tr class="row-a" style="color: #0000ff">
            <td class="first" style="width: 144px">
                Cheque Book Type</td>
            <td style="width: 152px">
                <asp:DropDownList ID="DrpChecktype" runat="server" AutoPostBack="True" Font-Size="Small">
                </asp:DropDownList></td>
            <td style="color: #0000ff">
                Date Received</td>
            <td style="color: #0000ff">
                <asp:TextBox ID="txtDateReceived" runat="server" AutoPostBack="True" Font-Size="Small"
                    Width="145px"></asp:TextBox><asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/Images/pdate.gif"
                        Width="17px">HyperLink</asp:HyperLink></td>
        </tr>
        <tr class="row-b" style="color: #0000ff">
            <td class="first" style="width: 144px">
            </td>
            <td style="width: 152px">
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr class="row-a" style="color: #0000ff">
            <td class="first" style="width: 144px">
            </td>
            <td style="width: 152px">
            </td>
            <td style="color: #0000ff">
            </td>
            <td style="color: #0000ff">
            </td>
        </tr>
        <tr class="row-b" style="color: #0000ff">
            <td class="first" style="width: 144px">
            </td>
            <td colspan="2">
                <asp:Button ID="BtnSubmit" runat="server" BackColor="#C0C0FF" Font-Size="Small" Text="Submit"
                    ValidationGroup="News" Width="63px" />
                <asp:Button ID="BtnReset" runat="server" BackColor="#C0C0FF" Font-Size="Small" Text="Reset"
                    Width="63px" /><asp:Button ID="Btncancel" runat="server" BackColor="#C0C0FF" Font-Size="Small"
                        Text="Return" Width="63px" /></td>
            <td>
            </td>
        </tr>
        <tr class="row-b" style="color: #0000ff">
            <td class="first" style="width: 144px">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr class="row-b" style="color: #0000ff">
            <td class="first" colspan="4">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        &nbsp;<asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" CellPadding="4" CssClass="th" 
                            DataKeyNames="Receiptid" DataSourceID="Smartobj1" ForeColor="#333333" 
                            GridLines="None" Width="565px">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <Columns>
                             <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="suppliername" HeaderText="Supplier" SortExpression="suppliername">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OrderNo" DataFormatString="OrderNo" HeaderText="Order No" />
                        <asp:BoundField DataField="WayBill" HeaderText="Way Bill" SortExpression="WayBill" />
                        <asp:BoundField DataField="Qty" DataFormatString="{0:n}" HeaderText="Quantity" />
                        <asp:BoundField DataField="valuedate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Placement Date"
                            SortExpression="valuedate" />
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="LblDoc1" runat="server" Text='<%#Eval("Receiptid") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                            </Columns>
                            <RowStyle BackColor="#EFF3FB" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        <asp:ObjectDataSource ID="Smartobj1" runat="server" SelectMethod="SqlDs" 
                            TypeName="smartcon">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="exec proc_chequedetail" 
                                    Name="SqlString" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        &nbsp;
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
    <br />
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>

