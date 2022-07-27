<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master"    AutoEventWireup="false"   CodeFile="CashEnquiry.aspx.vb" Inherits="AccountCustomerServices_Enquiry_CashEnquiry" title="CashEnquiry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
<div class="box box-info">
<div class="box-body">
    <div class="row">
			<h2 class="title">Till Account Balance Enquiry</h2>
        <div class="form-group" >
        <tr>
            <td style="width: 18px; text-align: center">
                Userid</td>
            <td style="width: 200px; text-align: left">
                <asp:TextBox ID="txtUserid" runat="server" AutoPostBack="True" ReadOnly="True" CssClass="form-control" Width="20%"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="View" CssClass="btn bg-purple btn-flat margin" OnClientClick="DisplayLoadingDiv()" /></td>
        </tr>
        </div>
        <div class="box-footer">
        <tr>
            <td colspan="7" style="width: 381px">
                &nbsp; &nbsp;
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="DBApp"
                    GridLines="Horizontal" Width="100%">
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <Columns>
                        <asp:BoundField DataField="cashaccount" HeaderText="Cash Account" SortExpression="cashaccount" />
                        <asp:BoundField DataField="acctname" HeaderText="Account Name" SortExpression="acctname" />
                        <asp:BoundField DataField="branchname" HeaderText="Branch Name" SortExpression="branchname" />
                        <asp:BoundField DataField="last_night_balance" HeaderText="Last Night Balance" SortExpression="last_night_balance" />
                        <asp:BoundField DataField="bkbalance" HeaderText="Book Balance" SortExpression="bkbalance" />
                    </Columns>
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                </asp:GridView>
                <asp:SqlDataSource ID="DBApp" runat="server" ConnectionString="<%$ ConnectionStrings:EasyBankerCon1 %>"
                    SelectCommand="GetTillBal" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ProfileParameter DefaultValue="" Name="role" PropertyName="Roleid" Type="Int32" />
                        <asp:ProfileParameter DefaultValue="" Name="branchcode" PropertyName="BranchCode"
                            Type="String" />
                        <asp:ProfileParameter DefaultValue="" Name="userid" PropertyName="Userid" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        </div>
        </div>
		</div>
        </div>
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>

