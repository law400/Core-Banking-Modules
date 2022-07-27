<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="AccountHold_Bulk.aspx.vb" Inherits="CustomerService_AccountHold_Bulk" title="Untitled Page" %>
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
                <asp:DropDownList ID="DrpExcelType" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="0">--Choose Office Type--</asp:ListItem>
                    <asp:ListItem Value="1">MS- Office Excel 2003</asp:ListItem>
                    <asp:ListItem Value="2">MS- Office Excel 2007</asp:ListItem>
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
                <asp:Button ID="Button1" runat="server" Text="Post" 
                    Width="65px" Enabled="False" />
                <asp:TextBox ID="txtBatch" runat="server" Visible="False"></asp:TextBox>
                <br />
                <br />
                <br />
            </td>
            <td colspan="2" style="height: 25px">
                <asp:ListBox ID="ListBox1" runat="server" Visible="False" Width="317px">
                </asp:ListBox>
            </td>
        </tr>
        <tr>
            <td style="width: 6587px; height: 25px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Large" 
                    ForeColor="#FF9900"></asp:Label>
            </td>
            <td colspan="2" style="height: 25px">
                </td>
        </tr>
        <tr>
            <td style="width: 6587px; height: 25px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtTotal" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
            </td>
            <td colspan="2" style="height: 25px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 6587px; height: 25px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td colspan="2" style="height: 25px">
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                        <br />
                        <br />
                        <asp:GridView ID="GridView1" runat="server" 
            AutoGenerateColumns="False" 
            ShowFooter="True" CellPadding="4" Font-Size="X-Small"
                            Width="968px" GridLines="None" ForeColor="#333333">
                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                             <Columns>
                               
                                <asp:BoundField DataField="Accountnumber" HeaderText="Accountnumber">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="Effective_dt" HeaderText="Effective Date" />
                                <asp:BoundField DataField="End_dt" HeaderText="End Date"
                                    HtmlEncode="False">
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Font-Size="Larger" />
                                </asp:BoundField>
                                <asp:BoundField DataField="HoldAmount" HeaderText="HoldAmount" 
                                     DataFormatString="{0:n}">
                                </asp:BoundField>
                                <asp:BoundField DataField="HoldReason" HeaderText="HoldReason">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="lientype" HeaderText="Lien Type">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <%--<asp:BoundField DataField="ValueDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="ValueDate"
                                    HtmlEncode="False">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Narration" HeaderText="Narration">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TellerNo" HeaderText="TellerNo">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>--%>
                                
                            </Columns>
                            <RowStyle BackColor="#F7F6F3" Font-Size="8pt" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                Font-Names="Verdana" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                        <asp:Panel ID="PaneValidate" runat="server" Font-Bold="True" 
                            Font-Size="XX-Small">
                            <asp:Label ID="LblAccountvalidate0" runat="server" Font-Bold="True" 
                                Font-Size="Large" ForeColor="#FF9900" 
                                
                                Text="Unable to Place lien on the Account(s) displayed below.Please check if:  "></asp:Label>
                            <br />
                            <asp:Label ID="LblAccountvalidate" runat="server" Font-Bold="True" 
                                Font-Size="Large" ForeColor="#FF9900" 
                                Text=" Account numbers are invalid"></asp:Label>
                            <br />
                            <asp:Label ID="LblHoldAmount" runat="server" Font-Bold="True" Font-Size="Large" 
                                ForeColor="#FF9900" Text=" Lien Amount is negative"></asp:Label>
                            <br />
                            <asp:Label ID="LblAccountLien" runat="server" Font-Bold="True" 
                                Font-Size="Large" ForeColor="#FF9900" 
                                Text=" Lien type is not in  this Option (1,4,5,6)"></asp:Label>
                            <br />
                            <br />
                            <br />
                        </asp:Panel>
                        <br />
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                            CellPadding="3" Font-Size="X-Small" GridLines="None" 
                            ShowFooter="True" Width="968px" BackColor="White" BorderColor="White" 
                            BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1">
                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                            <Columns>
                                <asp:BoundField DataField="Accountnumber" HeaderText="Accountnumber">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Effective_dt" HeaderText="Effective Date" />
                                <asp:BoundField DataField="End_dt" HeaderText="End Date" HtmlEncode="False">
                                    <HeaderStyle Font-Bold="True" Font-Size="Larger" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="HoldAmount" DataFormatString="{0:n}" 
                                    HeaderText="HoldAmount" />
                                <asp:BoundField DataField="HoldReason" HeaderText="HoldReason">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="lientype" HeaderText="Lien Type">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            </Columns>
                            <RowStyle BackColor="#DEDFDE" Font-Size="8pt" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" Font-Names="Verdana" 
                                ForeColor="#E7E7FF" />
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

