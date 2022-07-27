<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="News.aspx.vb" Inherits="News" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
 function toggleDivState(divName)
 {
  var ctl=window.document.getElementById(divName);
  if (ctl.style.display == "none")
   ctl.style.display = "";
  else
   ctl.style.display = "none";
  }
</script>
  <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
   <div class="box-blue">
			 <div class="content">
                 &nbsp;</div>
			<div class="meta">
                <table>
                    <tr class="row-b" style="color: #0000ff">
                        <td >
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
                                BorderWidth="0" DataKeyNames="bulletinid" ShowHeader="false" Width="454px">
                                <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <img src="Images/ico_1.gif" />
                        <a href="javascript:toggleDivState('bulletinid<%# Eval("bulletinid") %>');"><%#Eval("bulletintitle")%>
                        </a><small>(Published on <%#Eval("bulletinDate", "{0:dd/MM/yyy}")%>) 
                        Click to View Detail)</small>  
                        <div ID='bulletinid<%# Eval("bulletinid") %>' style="display: none;">
                            <asp:Label ID="view" runat="server" Text='<%# Eval("bulletindetail")%>' />
                            <p class="readmore">
   <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/News/" + Eval("url") %>'>Download Pdf</asp:HyperLink>

                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr  style="color: #0000ff">
                        <td >
                            &nbsp;</td>
                    </tr>
                    <tr style="color: #0000ff">
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
			</div>
		</div> 
		</ContentTemplate> 
		</asp:UpdatePanel> 
    </asp:Content>



