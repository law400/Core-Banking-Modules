<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="ChequeRequest.aspx.vb"  Inherits="CustomerService_ChequeRequest" title="ChequeRequest Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
<asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" 
                    Orientation="Horizontal" StaticEnableDefaultPopOutImage="False" Width="183px">
                    <Items>
                        <asp:MenuItem ImageUrl="~/Images/pic2.gif" Text="Add New" Value="0">
                        </asp:MenuItem>
                        <asp:MenuItem ImageUrl="~/images/pic1.gif" Text="Edit" Value="1"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="~/images/pic1.gif" Text="List" Value="2"></asp:MenuItem>
                    </Items>
                </asp:Menu>
    <table>
      
        <tr>
            <th class="first" style="height: 29px">
                Account Number</th>
            <th style="height: 29px">
                <asp:TextBox ID="txtAcctNo1" runat="server" AutoPostBack="True" 
                    Font-Size="Small" Width="163px"></asp:TextBox>
                <asp:HyperLink ID="hypAccount" runat="server" Height="22px" 
                    ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink>
            </th>
            <th style="height: 29px; width: 176px;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtAcctNo1" Display="Dynamic" 
                    ErrorMessage="Enter Accountnumber" ValidationGroup="News2" Width="150px">Enter 
                Accountnumber</asp:RequiredFieldValidator>
            </th>
            <th style="height: 29px">
            </th>
        </tr>
        <tr class="row-a">
            <td class="first" style="height: 29px">
                AccountName</td>
            <td style="height: 29px">
                <asp:Label ID="lblName" runat="server"></asp:Label></td>
            <td style="color: #0000ff; width: 176px; height: 29px;">
            </td>
            <td style="color: #0000ff; height: 29px;">
            </td>
        </tr>
        <tr class="row-b" style="color: #0000ff">
            <td class="first">
                Account Type</td>
            <td>
                <asp:DropDownList ID="DrpAcctType1" runat="server" Font-Size="Small">
                </asp:DropDownList></td>
            <td style="color: #0000ff; width: 176px;">
                Branch</td>
            <td style="color: #0000ff">
                <asp:DropDownList ID="DrpBranch1" runat="server" AutoPostBack="True" Font-Size="Small">
                </asp:DropDownList></td>
        </tr>
        <tr class="row-a" style="color: #0000ff">
            <td class="first">
                ChequeBook Type</td>
            <td>
                <asp:DropDownList ID="DrpChkType1" runat="server" AutoPostBack="True" Font-Size="Small">
                </asp:DropDownList></td>
            <td style="color: #0000ff; width: 176px;">
                Branch to Collect</td>
            <td style="color: #0000ff">
                <asp:DropDownList ID="DrpBranch2" runat="server" AutoPostBack="True" Font-Size="Small">
                </asp:DropDownList></td>
        </tr>
        <tr class="row-b" style="color: #0000ff">
            <td class="first">
                No Of Cheque Leaves</td>
            <td>
                <asp:TextBox ID="txtnolv" runat="server" AutoPostBack="True" Font-Size="Small"
                    ReadOnly="True" Width="166px"></asp:TextBox></td>
            <td style="width: 176px">
                Unit Cost to Customer</td>
            <td>
                <asp:TextBox ID="txtunitpr" runat="server" AutoPostBack="True" Font-Size="Small"
                    ReadOnly="True" Width="180px"></asp:TextBox></td>
        </tr>
        <tr class="row-a" style="color: #0000ff">
            <td class="first" style="height: 30px">
                Request Date</td>
            <td style="height: 30px">
                <asp:TextBox ID="txtReqDate" runat="server" Font-Size="Small" Width="167px"></asp:TextBox><asp:HyperLink
                    ID="HyperLink1" runat="server" ImageUrl="~/Images/pdate.gif" Width="13px">HyperLink</asp:HyperLink></td>
            <td style="color: #0000ff; width: 176px; height: 30px;">
                Total Cost to Costomer</td>
            <td style="color: #0000ff; height: 30px;">
                <asp:TextBox ID="txttotcost" runat="server" AutoPostBack="True" Font-Size="Small"
                    ReadOnly="True" Width="181px"></asp:TextBox></td>
        </tr>
        <tr class="row-b" style="color: #0000ff">
            <td class="first">
                Narration</td>
            <td>
                <asp:TextBox ID="txtNarration" runat="server" AutoPostBack="True" Font-Size="Small"
                    Height="43px" TextMode="MultiLine" Width="166px"></asp:TextBox></td>
            <td style="width: 176px">
            </td>
            <td>
            </td>
        </tr>
        <tr class="row-a" style="color: #0000ff">
            <td class="first">
            </td>
            <td>
            </td>
            <td style="color: #0000ff; width: 176px;">
            </td>
            <td style="color: #0000ff">
                &nbsp;</td>
        </tr>
        <tr class="row-b" style="color: #0000ff">
            <td class="first">
            </td>
            <td>
                <asp:Button ID="btnsubmit" runat="server" BackColor="#C0C0FF" Text="Submit" ValidationGroup="News2" /><asp:Button
                    ID="btnreset" runat="server" BackColor="#C0C0FF" Text="Reset" /><asp:Button
                    ID="Button1" runat="server" BackColor="#C0C0FF" Text="Return" /></td>
            <td style="width: 176px">
            </td>
            <td>
            </td>
        </tr>
        <tr class="row-b" style="color: #0000ff">
            <td class="first" colspan="4">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" CellPadding="4" CssClass="th" 
                            DataKeyNames="id" ForeColor="#333333" GridLines="None" Width="565px">
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:BoundField DataField="typedesc" HeaderText="Cheque Type" ReadOnly="True" 
                                    SortExpression="typedesc">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="numberofleaves" HeaderText="No Of Leaves" 
                                    SortExpression="numberofleaves">
                                </asp:BoundField>
                                <asp:BoundField DataField="daterec" DataFormatString="{0:dd/MM/yyyy}" 
                                    HeaderText="Request Date" SortExpression="daterec" />
                                <asp:BoundField DataField="source" HeaderText="Request Branch" 
                                    SortExpression="source">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Destin" HeaderText="Destination Branch" 
                                    SortExpression="Destin" />
                                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            </Columns>
                            <RowStyle BackColor="#EFF3FB" />
                            <EditRowStyle BackColor="#2461BF" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        <asp:ObjectDataSource ID="Smartobj1" runat="server" SelectMethod="SqlDs" 
                            TypeName="smartcon" OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="txtAcctNo1" 
                                    DefaultValue="exec proc_Accountcheque @acctno" Name="SqlString" 
                                    PropertyName="Text" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>

