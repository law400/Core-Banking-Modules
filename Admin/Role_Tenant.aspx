<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master"    AutoEventWireup="false"   CodeFile="Role_Tenant.aspx.vb" Inherits="Security_Role_Tenant" title="Role" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <script  type="text/javascript" language="javascript" src="../Scripts/jquery-1.11.1.js"></script>
<script type="text/javascript" language="javascript" src="../Scripts/jquery.dataTables.min.js"></script>
    <link type="text/css" href="../css/jquery.dataTables.min.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $(".gvdatatable").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                "lengthMenu": [[3, 5, 10, 25, -1], [3, 5, 10, 25, "All"]] //value:item pair
            });
        });
    </script>
  <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>

      <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
            AssociatedUpdatePanelID="updatePanel">
        <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #D7D7FF; opacity: 0.7;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
    </ProgressTemplate>
        </asp:UpdateProgress>
  <div class="panel panel-default">
      <div class="panel-heading">
          <h3>ROLE TENANT(s)</h3>
      </div>
<div class="panel-body">
  
                    <tr class="row-b" style="color: #0000ff">
                        <td >
                <asp:Button ID="Button1" runat="server" Text="Add New Tenant" Width="150px" Font-Size="Small"  CssClass="btn bg-purple btn-flat margin" BackColor="#C0C0FF" /><asp:Button ID="Delete" runat="server" Text="Delete" Width="65px" Font-Size="Small" CssClass="btn bg-red btn-flat margin" BackColor="#C0C0FF" />
                           <%-- <asp:Button ID="Btncancel" runat="server" BackColor="#C0C0FF" Font-Size="Small" 
                                ForeColor="Black" Text="Return" Width="62px" />--%>
                        </td>
                    </tr>
                    <tr  style="color: #0000ff">
                        <td >
                            <br />
                              <br />
                            <br />
                            <div>

                            </div>
                            &nbsp;<div class="col-md-12">
                                
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                DataKeyNames="node_id" Width="100%" CssClass="gvdatatable" CellPadding="4" ForeColor="#333333" 
                                GridLines="None">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                    <Columns>
                        <asp:TemplateField Visible="False">
            <ItemTemplate>
                <asp:CheckBox runat="server" ID="RowLevelCheckBox" />
            </ItemTemplate>
        </asp:TemplateField>

                        <asp:HyperLinkField DataNavigateUrlFields="node_id" DataNavigateUrlFormatString="roleedit_global.aspx?roleid={0}"
                            DataTextField="Tenant" HeaderText="Tenant Name">
                           <HeaderStyle HorizontalAlign="Left" />
                        </asp:HyperLinkField>

                        <%--<asp:BoundField DataField="roledesc" HeaderText="Role Description" />--%>

                        <%--<asp:BoundField DataField="access_days" HeaderText="Access Days" SortExpression="access_days" Visible="False">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>--%>
                         <asp:TemplateField Visible="False">
            <ItemTemplate>
                <asp:Label  runat="server" ID="LabelRole" Text='<%#Eval("node_id")%>' />
            </ItemTemplate>
        </asp:TemplateField>
				
                    </Columns>
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                                </div>
                        </td>
                    </tr>
                </table>
			</div>

      <div class="panel-footer">

      </div>
		</div> 
		</ContentTemplate> 
		</asp:UpdatePanel> 
    </asp:Content>

