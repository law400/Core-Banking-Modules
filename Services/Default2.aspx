<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default2.aspx.vb" Inherits="Services_Default2" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
              </asp:ScriptManager>
    <div>
       <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>

			  

			  <table class="style1">
    <tr>
        <td >
            <h2>
                SUBSCRIBER TYPE</h2>
</td>
</tr>
</table>
             <fieldset class="changePassword"  style="width: 920px">
                    <legend>Create/Edit Service</legend>
                   
      <table style="width: 847px; font-size: small;" border="0" bordercolor="#0000cc" >
                <tr>
                    <td style="width: 100px; height: 200px;" align="left" valign="top">
                        <table class="gridtable" style="font-size: small">
                            <tr>
                                <td colspan="4">
                                    <strong>Service Setting</strong></td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" 
                                        HeaderText="Error Messages" style="color: #FF0000; font-weight: 700" 
                                        ValidationGroup="valrule" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    Subscriber Key</td>
                                <td>
                                    <asp:TextBox ID="txtkey" runat="server" AutoPostBack="True" ReadOnly="True" 
                                        Width="154px"></asp:TextBox>
                                </td>
                                <td class="style7">
                                    Account No</td>
                                <td class="style7">
                                    <asp:TextBox ID="txtacctno" runat="server" AutoPostBack="True" Width="154px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    Service Type</td>
                                <td>
                                    <telerik:RadComboBox ID="drpdservicetype" Runat="server" AllowCustomText="True" 
                                        AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="description" 
                                        DataValueField="id" Filter="StartsWith" Height="16px" MarkFirstMatch="True" 
                                        MaxHeight="200px">
                                    </telerik:RadComboBox>
                                </td>
                                <td class="style7">
                                    Frequency</td>
                                <td class="style7">
                                    <asp:TextBox ID="txtperiods" runat="server" AutoPostBack="True" Width="54px"></asp:TextBox>
                                    <asp:DropDownList ID="drpfrequency" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    Account Type</td>
                                <td>
                                    <telerik:RadComboBox ID="drpaccttype" Runat="server" AllowCustomText="True" 
                                        AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="productname" 
                                        DataValueField="productcode" Filter="StartsWith" MarkFirstMatch="True" 
                                        MaxHeight="200px">
                                    </telerik:RadComboBox>
                                </td>
                                <td class="style7">
                                    Account Title</td>
                                <td class="style7">
                                    <asp:TextBox ID="txtacctname" runat="server" AutoPostBack="True" Width="204px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="style7">
                                    &nbsp;</td>
                                <td class="style7">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style7" colspan="4">
                                    <asp:Panel ID="Panel6" runat="server" Font-Bold="True" Font-Size="Small" 
                                        GroupingText="Receipient Detail" Width="567px">
                                        <table class="gridtable">
                                            <tr>
                                                <td>
                                                    Phone No<br />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtphone" runat="server" AutoPostBack="True" Width="154px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    Email</td>
                                                <td>
                                                    <asp:TextBox ID="txtemail" runat="server" AutoPostBack="True" Width="154px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Message Type</td>
                                                <td>
                                                    <asp:DropDownList ID="drpmsgtype" runat="server" AutoPostBack="True">
                                                        <asp:ListItem Selected="True" Value="1">SMS</asp:ListItem>
                                                        <asp:ListItem Value="2">Email</asp:ListItem>
                                                        <asp:ListItem Value="3">Both</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnAdd" runat="server" Text="Add Receipient" />
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:DataGrid ID="dg" runat="server" CellPadding="4" Font-Size="Small" 
                                                        ForeColor="#333333" GridLines="None" ondeletecommand="Delete_Item" 
                                                        Width="535px">
                                                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                        <columns>
                                                            <asp:buttoncolumn buttontype="LinkButton" commandname="Delete" 
                                                                text="Remove Item" />
                                                        </columns>
                                                        <EditItemStyle BackColor="#999999" />
                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Panel ID="Panel5" runat="server" Font-Bold="True" Font-Size="Small" 
                                        GroupingText="Procedure" Width="569px">
                                        <table class="gridtable">
                                            <tr>
                                                <td>
                                                    Column Procedure Name:
                                                    <asp:TextBox ID="txt_childprocedure" runat="server" AutoPostBack="True" 
                                                        Width="308px"></asp:TextBox>
                                                    <br />
                                                    Alertz Procedure Name:&nbsp;&nbsp;
                                                    <asp:TextBox ID="txt_parentprocedure" runat="server" AutoPostBack="True" 
                                                        Width="307px"></asp:TextBox>
                                                    <br />
                                                    <table cellpadding="8" style="width: 484px">
                                                        <tr>
                                                            <td style="width:50%; vertical-align: top;">
                                                                <b>Input Parameters:</b>
                                                                <asp:BulletedList ID="blInputParameters" runat="server">
                                                                </asp:BulletedList>
                                                            </td>
                                                            <td style="vertical-align: top;" class="style1">
                                                                <b>Output Parameters:</b>
                                                                <asp:BulletedList ID="blOutputParameters" runat="server">
                                                                </asp:BulletedList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:GridView ID="gvParameters" runat="server" AutoGenerateColumns="False" 
                                                        CssClass="mGrid" DataKeyNames="ParameterName" Width="482px">
                                                        <Columns>
                                                            <asp:BoundField DataField="ParameterName" HeaderText="Parameter" />
                                                            <asp:TemplateField HeaderText="Value">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="ParameterValue" runat="server" Columns="40"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <asp:Button ID="btnExecSproc" runat="server" Font-Size="Small" 
                                                        Text="Execute Stored Procedure" Width="189px" />
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Panel ID="Panel4" runat="server" Font-Bold="True" Font-Size="Small" 
                                        GroupingText="Default Message" Visible="false" Width="567px">
                                        <table class="gridtable">
                                            <tr>
                                                <td>
                                                    <asp:RadioButtonList ID="RdList" runat="server" AppendDataBoundItems="True" 
                                                        AutoPostBack="True" RepeatColumns="5" RepeatDirection="Horizontal">
                                                    </asp:RadioButtonList>
                                                    <br />
                                                    <asp:TextBox ID="txtconstring1" runat="server" AutoPostBack="True" 
                                                        Height="39px" TextMode="MultiLine" Width="485px" Font-Size="Small"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Button ID="btnSubmit" runat="server" BackColor="#C0C0FF" Text="Save" 
                                        ValidationGroup="valrule" Width="64px" />
                                    <asp:Button ID="btnReset" runat="server" BackColor="#C0C0FF" Text="Reset" />
                                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:AlertZ %>" 
                                        SelectCommand="proc_Accounttype" SelectCommandType="StoredProcedure">
                                    </asp:SqlDataSource>
                                </td>
                                <td>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:AlertZ %>" 
                                        SelectCommand="proc_selservicetype" SelectCommandType="StoredProcedure">
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                        </table>
                                    </td>
                    <td style="width: 100px; height: 200px;" valign="top" align="justify">
        
    
                        <asp:Panel ID="Panel3" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="#FF3300" GroupingText="Column Data" Visible="false" 
                            Width="331px" Height="390px">
                            <table style="height: 107px; width: 321px;">
                                <tr>
                                    <td bgcolor="Red">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvFields" runat="server" CssClass="mGrid" Width="314px">
                                            <Columns>
                                                    <asp:TemplateField HeaderText="New Value">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="FieldValue" runat="server" Columns="10"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="Red" class="style9">
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </fieldset>
   
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
