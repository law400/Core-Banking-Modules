<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WebUserControl.ascx.vb" Inherits="Services_WebUserControl" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        height: 21px;
    }
</style>
<link href="../idefault.css" rel="stylesheet" type="text/css" />
  <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
<table class="style1">
    <tr>
        <td>
              <fieldset class="row2">
                <legend>Basic Information
                </legend>
                
                    <table>
                    <tr>
                                <td class="style7">
                                    Discription</td>
                                <td>
                                    <asp:TextBox ID="txtdesc" runat="server" Width="153px"></asp:TextBox>
                                </td>
                                <td class="style7">
                                    &nbsp;</td>
                                <td class="style7">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    Default
                                    SMS
                                    Dispatch Type</td>
                                <td>
                                    <telerik:RadComboBox ID="drpdispatch" Runat="server" AllowCustomText="True" 
                                        AutoPostBack="True" Filter="StartsWith" MarkFirstMatch="True" 
                                        MaxHeight="200px">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    Frequency</td>
                                <td>
                                    <asp:TextBox ID="txtperiods" runat="server" AutoPostBack="True" Width="54px"></asp:TextBox>
                                    <asp:DropDownList ID="drpfrequency" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Default
                                    Email Dispatch Type</td>
                                <td>
                                    <telerik:RadComboBox ID="drpdispatch0" Runat="server" AllowCustomText="True" 
                                        AutoPostBack="True" Filter="StartsWith" MarkFirstMatch="True" 
                                        MaxHeight="200px">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    Frequency</td>
                                <td>
                                    <asp:TextBox ID="txtperiods0" runat="server" AutoPostBack="True" Width="54px"></asp:TextBox>
                                    <asp:DropDownList ID="drpfrequency0" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                   Connection Type:</td>
                                <td>
                                    <asp:RadioButtonList ID="RdConnect" runat="server" RepeatDirection="Horizontal" 
                                        AutoPostBack="True">
                                        <asp:ListItem Value="1" Selected="True">Database</asp:ListItem>
                                        <asp:ListItem Value="2">Webservice</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                   <asp:Panel ID="Panel1" runat="server">
                                       <table>
                                           <tr>
                                               <td class="style2">
                                                   Database:</td>
                                               <td>
                                                   <asp:DropDownList ID="drpdatabase" runat="server" AutoPostBack="True" 
                                            Font-Size="XX-Small" Height="18px" Width="230px">
                                                       <asp:ListItem Selected="True" Value="0">--Database Type--</asp:ListItem>
                                                       <asp:ListItem Value="1">MS SQL </asp:ListItem>
                                                       <asp:ListItem Value="2">Sybase</asp:ListItem>
                                                       <asp:ListItem Value="3">Oracle</asp:ListItem>
                                                       <asp:ListItem Value="4">MySql</asp:ListItem>
                                                   </asp:DropDownList>
                                               </td>
                                           </tr>
                                           <tr>
                                               <td class="style2">
                                                   Server Name/IP:</td>
                                               <td>
                                                   <asp:TextBox ID="txtserver" runat="server" AutoPostBack="True" Width="230px"></asp:TextBox>
                                               </td>
                                           </tr>
                                           <tr>
                                               <td class="style2">
                                                   Username:</td>
                                               <td>
                                                   <asp:TextBox ID="txtusername" runat="server" AutoPostBack="True" Width="230px"></asp:TextBox>
                                               </td>
                                           </tr>
                                           <tr>
                                               <td class="style2">
                                                   Password:</td>
                                               <td>
                                                   <asp:TextBox ID="txtpassword" runat="server" AutoPostBack="True" Width="230px"></asp:TextBox>
                                               </td>
                                           </tr>
                                           <tr>
                                               <td class="style2">
                                                   Database:</td>
                                               <td>
                                                   <asp:TextBox ID="txtdatase" runat="server" AutoPostBack="True" Width="230px"></asp:TextBox>
                                               </td>
                                           </tr>
                                           <tr>
                                               <td class="style2">
                                                   &nbsp;</td>
                                               <td>
                                                   <asp:Button ID="btntest" runat="server" Text="Test Connection" />
                                               </td>
                                           </tr>
                                           <tr>
                                               <td class="style2">
                                                   &nbsp;</td>
                                               <td>
                                                   &nbsp;</td>
                                           </tr>
                                           <tr>
                                               <td class="style2">
                                                   Column Procedure</td>
                                               <td>
                                                   <asp:TextBox ID="txt_childprocedure" runat="server" AutoPostBack="True" 
                                                       Width="219px"></asp:TextBox>
                                               </td>
                                           </tr>
                                           <tr>
                                               <td class="style2">
                                                   Service Procedure</td>
                                               <td>
                                                   <asp:TextBox ID="txt_parentprocedure" runat="server" AutoPostBack="True" 
                                                       Width="221px"></asp:TextBox>
                                               </td>
                                           </tr>
                                           <tr>
                                               <td class="style2">
                                                   Input</td>
                                               <td>
                                                   <asp:BulletedList ID="blInputParameters" runat="server">
                                                   </asp:BulletedList>
                                               </td>
                                           </tr>
                                           <tr>
                                               <td class="style2">
                                                   Output</td>
                                               <td>
                                                   <asp:BulletedList ID="blOutputParameters" runat="server">
                                                   </asp:BulletedList>
                                               </td>
                                           </tr>
                                           <tr>
                                               <td class="style2" colspan="2">
                                                   <asp:GridView ID="gvParameters" runat="server" AutoGenerateColumns="False" 
                                                       CssClass="mGrid" DataKeyNames="ParameterName" Width="304px">
                                                       <Columns>
                                                           <asp:BoundField DataField="ParameterName" HeaderText="Parameter" />
                                                           <asp:TemplateField HeaderText="Value">
                                                               <ItemTemplate>
                                                                   <asp:TextBox ID="ParameterValue" runat="server" Columns="40"></asp:TextBox>
                                                               </ItemTemplate>
                                                           </asp:TemplateField>
                                                       </Columns>
                                                   </asp:GridView>
                                               </td>
                                           </tr>
                                           <tr>
                                               <td class="style2" colspan="2">
                                                   <asp:Button ID="btnExecSproc" runat="server" Font-Size="Small" 
                                                       Text="Execute Stored Procedure" Width="189px" />
                                               </td>
                                           </tr>
                                           <tr>
                                               <td class="style2">
                                                   &nbsp;</td>
                                               <td>
                                                   &nbsp;</td>
                                           </tr>
                                           <tr>
                                               <td class="style2">
                                                   Webservice URL:</td>
                                               <td>
                                                   <asp:TextBox ID="txturl0" runat="server" AutoPostBack="True" Width="230px"></asp:TextBox>
                                               </td>
                                           </tr>
                                           <tr>
                                               <td class="style2">
                                                   Function Name:</td>
                                               <td>
                                                   <asp:TextBox ID="txtfunction" runat="server" AutoPostBack="True" Width="230px"></asp:TextBox>
                                               </td>
                                           </tr>
                                           <tr>
                                               <td class="style2" colspan="2">
                                                   &nbsp;</td>
                                           </tr>
                                       </table>
                                   </asp:Panel>
                                   </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Button ID="btnSubmit" runat="server" BackColor="#C0C0FF" Text="Save" 
                                        ValidationGroup="valrule" Width="64px" />
                                    <asp:Button ID="btnReset" runat="server" BackColor="#C0C0FF" Text="Reset" 
                                        Width="71px" />
                                    <asp:TextBox ID="txthidden" runat="server" Visible="False"></asp:TextBox>
                                   </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                    </table>
               </fieldset></td>
        <td valign="top">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        <td valign="top">
                                                <fieldset class="row2">
                                                    <legend>Message Detail Information </legend>
                                                    <table style="width: 347px">
                                                        <tr>
                                                            <td class="style7">
                                                                Custom SMS Message </td>
                                                            <td>
                                                    <asp:TextBox ID="txtconstring1" runat="server" AutoPostBack="True" 
                                                        Height="39px" TextMode="MultiLine" Width="232px" Font-Size="Small"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style7">
                                                                &nbsp;</td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style7" valign="top">
                                                                Custom Email Message:</td>
                                                            <td>
                                                    <asp:TextBox ID="txtconstring2" runat="server" AutoPostBack="True" 
                                                        Height="214px" TextMode="MultiLine" Width="232px" Font-Size="Small"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style7">
                                                                Attachment File Format:</td>
                                                            <td>
                <asp:DropDownList ID="drpdatabase0" runat="server" AutoPostBack="True" 
                                            Font-Size="XX-Small" Height="18px" Width="230px">
                    <asp:ListItem Selected="True" Value="0">--File Format--</asp:ListItem>
                    <asp:ListItem Value="1">Excel csv</asp:ListItem>
                    <asp:ListItem Value="2">PDF</asp:ListItem>
                    <asp:ListItem Value="3">XML</asp:ListItem>
                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style7">
                                                                File Name Format:</td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                        </table>
                                                </fieldset><fieldset class="row3">
                                                    <legend>Report Column </legend>
                                       
                                                         <table style="height: 107px; width: 321px;">
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                       <asp:GridView ID="gvFields" runat="server" CssClass="mGrid" Width="314px" 
                                            DataKeyNames="FieldColumn">
                                            <Columns>
                                                                                     
                                                    <asp:TemplateField HeaderText="New Value">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="FieldValue" runat="server" Text='<%#Eval("FieldColumn") %>' Columns="10"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 
                                                    <asp:CommandField ShowSelectButton="True" />
                                                 
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                                             
                                                    
                                                </fieldset></td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>

</ContentTemplate>
</asp:UpdatePanel>