<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master"    AutoEventWireup="false"   CodeFile="RoleEdit_Global.aspx.vb" Inherits="Security_RoleEdit_Global" title="RoleEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                                <script src="template/js/jquery-1.11.1.min.js"></script>

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
      <div class="panel-heading ">
           <h3>GLOBAL ROLE EDIT</h3>
      </div>
<div class="panel-body">
   
                    
    <div class="col-md-4"> 
        <div class="form-group">
                             <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
                                 ForeColor="Black" style="color: #FF0000" Width="129px">Selected Tenant:</asp:Label>
                             <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" 
                                 ForeColor="Black" Width="479px"></asp:Label>
                        </div>
                    <div class="form-group">
                             <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
                                 ForeColor="Black" Width="124px">Tenant Description</asp:Label>
                             <asp:textbox id="TxtRole_name0" runat="server"  
                                 AutoPostBack="True" Height="51px" TextMode="MultiLine" CssClass="form-control"></asp:textbox>
                        </div>
           </div>

   
     
          <div class="col-md-10">            
                     <tr>
                         <th style="height: 29px">
                             &nbsp;</th>
                         <th colspan="3" style="height: 29px; text-align: left;">
                             <h3 style="color: #CC0000">
                                 GLOBAL DATA CAPTURE PRIVILEDGES</h3>
                         </th>
                         <th style="height: 29px">
                             &nbsp;</th>
                     </tr>
                   <table class="table table-bordered table-hover">
                     <tr>
                         <td >
                         </td>
                         <td style="width: 259px">
                             Application Data Capture Privilege</td>
                         <td style="width: 55px">
                         </td>
                         <td style="width: 306px">
                        Assigned Application Data Capture Privilege</td>
                         <td>
                         </td>
                     </tr>
                     <tr  style="color: #0000ff">
                         <td  style="height: 39px">
                         </td>
                         <td style="height: 39px; width: 259px;">
                        <asp:ListBox ID="LstFrom_Menu" runat="server" Height="231px" SelectionMode="Multiple"
                            Width="283px" CssClass="list-group"> </asp:ListBox></td>
                         <td style="color: #0000ff; height: 39px; width: 55px; text-align: center;">
                        <asp:Button ID="Back" runat="server" Text="<" Width="26px" Font-Size="Small" /><asp:Button ID="nextbln"
                            runat="server" Text=">" Width="24px" Font-Size="Small" /></td>
                         <td style="width: 306px; color: #0000ff; height: 39px">
                        <asp:ListBox ID="LstTo_Menu" runat="server" Height="231px" SelectionMode="Multiple"
                            Width="283px" CssClass="list-group"></asp:ListBox></td>
                         <td style="color: #0000ff; height: 39px">
                         </td>
                     </tr>
                     <tr class="row-b" style="color: #0000ff">
                         <td  style="height: 71px">
                         </td>
                       
                         <td style="width: 55px; height: 71px;">
                         </td>
                         <td style="width: 306px; height: 71px;">
                             <asp:Panel ID="panelreport" runat="server" Height="278px" Visible="False">
                             </asp:Panel>
                             </td>
                         <td style="height: 71px">
                         </td>
                     </tr>
                    
                    
                 </table>
			</div>
		</div>

      <div class="panel-footer">
          <asp:Button ID="Submit" runat="server" BackColor="#C0C0FF" Font-Size="Small" 
                                    Text="Save Record" CssClass="btn bg-purple btn-flat margin" ValidationGroup="News"  />
                                <asp:Button ID="Close" runat="server" BackColor="#C0C0FF" Font-Size="Small" Text="Return"  CssClass="btn bg-maroon btn-flat margin"/>
      </div>
		</div>
      </ContentTemplate> 
		</asp:UpdatePanel> 
            </asp:Content>

