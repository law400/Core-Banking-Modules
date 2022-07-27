<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="CloseAccount_Bulk.aspx.vb" Inherits="CustomerService_CloseAccount_Bulk" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
 <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
            AssociatedUpdatePanelID="updatePanel">
        <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #D7D7FF;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
    </ProgressTemplate>
        </asp:UpdateProgress>
<div class="post boxed">
			<div class="story">
			<table style="width: 452px; font-size: 8pt;">
        <tr>
            <td colspan="3">
                <asp:Label ID="Label1" runat="server" 
                    style="font-size: large; font-weight: 700; color: #FF0000"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 22px;" colspan="3">
                Select Ms Office Excel Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DrpExcelType" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="0">--Choose Office Type--</asp:ListItem>
                   <%-- <asp:ListItem Value="1">MS- Office Excel 2003</asp:ListItem>--%>
                    <asp:ListItem Value="2">MS- Office Excel 2007</asp:ListItem>
                    <asp:ListItem Value="3">MS- Office Excel 2010</asp:ListItem>
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
                    Width="65px" Enabled="False" /></td>
            <td colspan="2" style="height: 25px">
                <asp:ListBox ID="ListBox1" runat="server" Visible="False" Width="317px">
                </asp:ListBox>
            </td>
        </tr>
        <tr>
            <td style="width: 6587px; height: 25px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td colspan="2" style="height: 25px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 6587px; height: 25px;">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td colspan="2" style="height: 25px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 6587px; height: 25px;">
                Batch No&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtBatch" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td colspan="2" style="height: 25px">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                        <asp:GridView ID="GridView1" runat="server" 
            AutoGenerateColumns="False" BackColor="White"
                           BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
            ShowFooter="True" CellPadding="4" Font-Size="X-Small"
                            Width="719px">
                             <Columns>
                               
                                <asp:BoundField DataField="AccountNumber" HeaderText="AccountNumber">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Narration" HeaderText="Narration">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                
                                 <asp:BoundField DataField="Charges" HeaderText="Charges" />
                                
                            </Columns>
                            <RowStyle BackColor="White" Font-Size="8pt" ForeColor="#003399" />
                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        </asp:GridView>
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

