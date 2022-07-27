<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="ReceiptList.aspx.vb" Inherits="CustomerService_ReceiptList" title="ReceiptList Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
    <table style="width: 562px">
        <tr>
            <td colspan="4" style="height: 13px">
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
                        <asp:HyperLinkField DataTextField="ReceiptID" HeaderText="ReceiptID" />
                        <asp:BoundField DataField="SupplyID" HeaderText="SupplyID" SortExpression="SupplyID">
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
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 130px; height: 13px">
            </td>
            <td style="width: 100px; height: 13px">
            </td>
            <td style="width: 177px; height: 13px">
            </td>
            <td style="width: 100px; height: 13px">
            </td>
        </tr>
        <tr>
            <td colspan="4" style="height: 13px; text-align: center">
                <asp:Button ID="BtnSubmit" runat="server" BackColor="#C0C0FF" Text="Authorise" Width="76px" /><asp:Button
                    ID="BtnReturn" runat="server" BackColor="#C0C0FF" Text="Reject" Width="53px" /></td>
        </tr>
    </table>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>

