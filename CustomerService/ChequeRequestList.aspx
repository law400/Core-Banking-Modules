<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="ChequeRequestList.aspx.vb" Inherits="CustomerService_ChequeRequestList" title="ChequeReqlist Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
    <br />
    <table style="width: 612px">
        <tr>
            <td colspan="5" style="height: 27px; font-size: medium; color: #0000CC;">
                <b>WAITING CHEQUE REQUEST LIST</b></td>
        </tr>
        <tr>
            <td colspan="5">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Size="Small"
                        ForeColor="Black" GridLines="Vertical" Height="9px" Visible="False" Width="726px">
                        <FooterStyle BackColor="#CCCC99" />
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
                            <asp:HyperLinkField DataNavigateUrlFields="Accountnumber" DataNavigateUrlFormatString="ManageCheckBook.aspx?Chk={0}"
                                DataTextField="Accountnumber" HeaderText="Accountnumber" />
                            <asp:BoundField DataField="typedesc" HeaderText="CheckBook Type" SortExpression="typedesc">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="source" DataFormatString="source" HeaderText="Account Branch" />
                            <asp:BoundField DataField="Destin" HeaderText="Destination Branch" SortExpression="Destin" />
                            <asp:BoundField DataField="numberofleaves" DataFormatString="{0:n}" HeaderText="No Of Leaves"
                                SortExpression="numberofleaves" />
                            <asp:BoundField DataField="valuedate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Request Date"
                                SortExpression="valuedate" />
                        </Columns>
                        <RowStyle BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="5" style="height: 17px">
                <asp:Button ID="Btnsubmit2" runat="server" BackColor="#C0C0FF" Text="Range Check"
                    Visible="False" Width="101px" /><asp:Button ID="BtnReturn2" runat="server" BackColor="#C0C0FF"
                        Text="Return" Width="53px" /></td>
        </tr>
    </table>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>

