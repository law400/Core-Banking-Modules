<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ServiceType.aspx.vb" Inherits="Services_ServiceType" %>
<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Master.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
              </asp:ScriptManager>
               <script language=javascript>

                   function SelectAllCheckboxes(spanChk) {

                       // Added as ASPX uses SPAN for checkbox
                       var oItem = spanChk.children;
                       var theBox = (spanChk.type == "checkbox") ?
        spanChk : spanChk.children.item[0];
                       xState = theBox.checked;
                       elm = theBox.form.elements;

                       for (i = 0; i < elm.length; i++)
                           if (elm[i].type == "checkbox" &&
              elm[i].id != theBox.id) {
                               //elm[i].click();
                               if (elm[i].checked != xState)
                                   elm[i].click();
                               //elm[i].checked=xState;
                           }
                   }

                   function SelectAllCheckboxes2(spanChk) {

                       // Added as ASPX uses SPAN for checkbox
                       var oItem = spanChk.children;
                       var theBox = (spanChk.type == "checkbox") ?
        spanChk : spanChk.children.item[0];
                       xState = theBox.checked;
                       elm = theBox.form.elements;

                       for (i = 0; i < elm.length; i++)
                           if (elm[i].type == "checkbox" &&
              elm[i].id != theBox.id) {
                               //elm[i].click();
                               if (elm[i].checked != xState)
                                   elm[i].click();
                               //elm[i].checked=xState;
                           }
                   }
</script>
     <div class="post boxed" align="left" style="height: 894px">
			<h2 class="title">Services</h2>
            <div class="story">
       <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>

			  

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
                                    Discription</td>
                                <td>
                                    <telerik:RadComboBox ID="drpdesc" Runat="server"
                                    AllowCustomText="True" 
                                        AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="description" 
                                        DataValueField="id" Filter="StartsWith" MarkFirstMatch="True" 
                                        MaxHeight="200px">
                                    </telerik:RadComboBox>
                                </td>
                                <td class="style7">
                                    Connection Type</td>
                                <td class="style7">
                                    <asp:RadioButtonList ID="RdConnect" runat="server" RepeatDirection="Horizontal" 
                                        AutoPostBack="True">
                                        <asp:ListItem Value="1">Database</asp:ListItem>
                                        <asp:ListItem Value="2">Webservice</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <strong>Connection String:</strong></td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:TextBox ID="txtconstring" runat="server" Height="38px" 
                                        TextMode="MultiLine" Width="569px" Font-Size="Small"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btntest" runat="server" Text="Test Connection" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    Dispatch Type</td>
                                <td>
                                    <telerik:RadComboBox ID="drpdispatch" Runat="server" AllowCustomText="True" 
                                        AutoPostBack="True" Filter="StartsWith" MarkFirstMatch="True" MaxHeight="200px">
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
                                <td colspan="4">
                                  <ext:Panel ID="Panel5" runat="server" Title="Procedure Details" AutoHeight="true" 
                            FormGroup="true" Width="500px">
                    <Content>
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
                      </Content>
                      </ext:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                  <ext:Panel ID="Panel4" runat="server" Title="Message Details" AutoHeight="true" 
                            FormGroup="true" Width="500px">
                    <Content>
                                        <table class="gridtable">
                                            <tr>
                                                <td>
                                                
                                                    <br />
                                                    <asp:TextBox ID="txtconstring1" runat="server" AutoPostBack="True" 
                                                        Height="39px" TextMode="MultiLine" Width="485px" Font-Size="Small"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                  </Content>
                                  </ext:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Button ID="btnSubmit" runat="server" BackColor="#C0C0FF" Text="Save" 
                                        ValidationGroup="valrule" Width="64px" />
                                    <asp:Button ID="btnReset" runat="server" BackColor="#C0C0FF" Text="Reset" 
                                        Width="71px" />
                                </td>
                                <td>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:AlertZ %>" 
                                        SelectCommand="proc_selservicetype" SelectCommandType="StoredProcedure">
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:AlertZ %>" 
                                        SelectCommand="SELECT [description], [childprocedure] FROM [talertz_Procedure]">
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                        </table>
                                    </td>
                    <td style="width: 100px; height: 200px;" valign="top" align="justify">
        
    
                        <ext:Panel ID="Panel1" runat="server" Title="Database Details" AutoHeight="true" 
                            FormGroup="true" Width="300px">
                    <Content>
                            <table class="hover">
                                <tr>
                                    <td colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        Database:</td>
                                    <td>
                                        <asp:DropDownList ID="drpdatabase" runat="server" AutoPostBack="True" 
                                            Font-Size="XX-Small">
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
                            </table>
                       </Content> 
                       </ext:Panel> 
                       <ext:Panel ID="Panel2" runat="server" Title="Webservice Details" AutoHeight="true" 
                            FormGroup="true" Width="300px">
                    <Content>
                            <table style="font-size: small">
                                <tr>
                                    <td colspan="2" bgcolor="Red">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style4">
                                        Webservice URL:</td>
                                    <td>
                                        <asp:TextBox ID="txturl0" runat="server" Width="227px" style="margin-left: 3px" 
                                            AutoPostBack="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style4">
                                        Function Name:&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                    <td>
                                        <asp:TextBox ID="txtfunction" runat="server" Width="230px" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                       </Content> 
                       </ext:Panel>
           <ext:Panel ID="Panel3" runat="server" Title="Grid Column" AutoHeight="true" 
                            FormGroup="true" Width="300px">
                    <Content>
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
                      </Content>
                      </ext:Panel>
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
