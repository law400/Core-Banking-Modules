<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="Lift_Bulk_Lien.aspx.vb" Inherits="CustomerService_Lift_Bulk_Lien" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
<div class="post boxed">
			<div class="story">
			<table style="width: 1029px; font-size: 8pt;" align="center">
        <tr>
            <td colspan="3">
                <asp:Label ID="Label1" runat="server" 
                    style="font-size: large; font-weight: 700; color: #FF0000" 
                    Font-Size="Large" ForeColor="#FF9900"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 22px;" colspan="3">
                Select Ms Office Excel Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DrpExcelType" runat="server" AutoPostBack="True" 
                    Height="22px" Width="167px">
                    <asp:ListItem Value="0">--Choose Office Type--</asp:ListItem>
                    <asp:ListItem Value="1">MS- Office Excel 2007</asp:ListItem>
                    <asp:ListItem Value="2">MS- Office Excel 2010</asp:ListItem>
                </asp:DropDownList>
                                                                                </td>
        </tr>
        <tr>
            <td style="height: 22px;" colspan="3">
                Locate File to Upload&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:FileUpload ID="Myfile" runat="server" Width="219px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label6" runat="server"></asp:Label>
                                                                                </td>
        </tr>
                <tr>
                    <td style="width: 6587px; height: 25px;">
                        <asp:Button ID="upload" runat="server" Text="upload" Width="74px" />
                        <asp:Button ID="Button1" runat="server" Enabled="False" Text="Post" 
                            Width="65px" />
                        <asp:TextBox ID="txtBatch" runat="server" Visible="False"></asp:TextBox>
                        <asp:TextBox ID="txtTotal" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
                        <br />
                        <br />
                    </td>
                    <td colspan="2" style="height: 25px">
                        &nbsp;</td>
                </tr>
        <tr>
            <td style="width: 6587px; height: 25px;">
               
                <asp:Label ID="Legend1" runat="server" Text="HOLD TYPE:" Font-Size="Large" 
                    ForeColor="Red" Font-Bold="True"></asp:Label><br />
                <asp:Label ID="Legend2" runat="server" Text="1: Lien on an Amount" Font-Size="Large" 
                    ForeColor="Red" Font-Bold="True"></asp:Label><br />
                <asp:Label ID="Legend3" runat="server" Text="4: Post No Debit Lien" Font-Size="Large" 
                    ForeColor="Red" Font-Bold="True"></asp:Label><br />
                <asp:Label ID="Legend4" runat="server" Text="5: Post No Credit Lien" Font-Size="Large" 
                    ForeColor="Red" Font-Bold="True"></asp:Label><br />
                <asp:Label ID="Legend5" runat="server" Text="6: Post No transaction Lien" Font-Size="Large" 
                    ForeColor="Red" Font-Bold="True"></asp:Label>
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Large" 
                    ForeColor="#FF9900"></asp:Label>
            </td>
            <td colspan="2" style="height: 25px">
                </td>
        </tr>
        <tr>
            <td colspan="3">
                        <asp:GridView ID="GridView1" runat="server" 
            AutoGenerateColumns="False" 
            ShowFooter="True" CellPadding="3" Font-Size="X-Small"
                            Width="912px" GridLines="Horizontal" BackColor="White" 
                            BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                             <Columns>
                               
                                <asp:BoundField DataField="Accountnumber" HeaderText="Account Number">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="HoldAmount" HeaderText="Hold Amount" 
                                     DataFormatString="{0:n}">
                                </asp:BoundField>
                                <asp:BoundField DataField="HoldType" HeaderText="Hold Type">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                     <asp:TemplateField>
                                   <HeaderTemplate>
                                   <asp:CheckBox ID="chkboxSelectAll" runat="server" AutoPostBack="True" 
                                           OnCheckedChanged="chkboxSelectAll_CheckedChanged" BackColor="Yellow" 
                                           BorderColor="Yellow" BorderWidth="1px" 
                                           ToolTip="Check this Box Before Posting" />
                                 </HeaderTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkLien" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                                 </asp:TemplateField>
                                
                            </Columns>
                            <RowStyle BackColor="#E7E7FF" Font-Size="8pt" ForeColor="#4A3C8C" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" 
                                Font-Names="Verdana" Font-Size="XX-Small" />
                            <AlternatingRowStyle BackColor="#F7F7F7" />
                        </asp:GridView>
                        <asp:Panel ID="PaneValidate" runat="server" Font-Bold="True" 
                            Font-Size="XX-Small">
                            <asp:Label ID="LblAccountvalidate0" runat="server" Font-Bold="True" 
                                Font-Size="Large" ForeColor="#FF9900" 
                                
                                Text="Unable to Release lien on the Account(s) displayed below.Please check if:  "></asp:Label>
                            <br />
                            <asp:Label ID="LblAccountvalidate" runat="server" Font-Bold="True" 
                                Font-Size="Large" ForeColor="#FF9900" 
                                Text=" Account numbers are invalid"></asp:Label>
                            <br />
                            <asp:Label ID="LblHoldAmount" runat="server" Font-Bold="True" Font-Size="Large" 
                                ForeColor="#FF9900" Text=" Lien Amount is negative"></asp:Label>
                            <br />
                            <br />
                            <br />
                            <br />
                        </asp:Panel>
                        <br />
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                            CellPadding="3" Font-Size="X-Small" GridLines="Horizontal" 
                            ShowFooter="True" Width="968px" BackColor="White" BorderColor="#E7E7FF" 
                            BorderStyle="None" BorderWidth="1px">
                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <Columns>
                                <asp:BoundField DataField="Accountnumber" HeaderText="Account Number">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="HoldAmount" DataFormatString="{0:n}" 
                                    HeaderText="Hold Amount" />
                                <asp:BoundField DataField="LienType" HeaderText="Hold Type">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>

                               <asp:BoundField DataField="ErrorReason" HeaderText="Error Reason">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            </Columns>
                            <RowStyle BackColor="#E7E7FF" Font-Size="8pt" ForeColor="#4A3C8C" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" Font-Names="Verdana" 
                                ForeColor="#F7F7F7" Font-Size="Medium" />
                            <AlternatingRowStyle BackColor="#F7F7F7" />
                        </asp:GridView>
                        <br />
                        <br />
            </td>
        </tr>
        <tr>
            <td style="width: 6587px; height: 25px;"></td>
            <td style="width: 100px; height: 25px;">
            </td>
            <td style="width: 100px; height: 25px;">
            </td>
        </tr>
    </table>	
			</div>
			<div class="meta">
			</div>
		</div>
	</ContentTemplate> 
	 <Triggers>
         <asp:PostBackTrigger ControlID="upload" />
                  <asp:PostBackTrigger ControlID="button1" />

     </Triggers>
	</asp:UpdatePanel> 
</asp:Content>

