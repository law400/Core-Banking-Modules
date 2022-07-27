<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master"    AutoEventWireup="false"   CodeFile="RoleEdit.aspx.vb" Inherits="Security_RoleEdit" title="RoleEdit" %>
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
      <div class="panel-heading">
          <h3>ROLE EDIT</h3>
      </div>

<div class="panel-body">
   
                    
    <div class="col-md-4"> 
         
        
                             <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" 
                                 ForeColor="Black" style="color: #FF0000" Width="129px">Selected Role:</asp:Label>
                             <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" 
                                 ForeColor="Black" Width="240px"></asp:Label>
                        
             
           <div class="form-group">
                     
                             <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"
                                 Visible="False" Width="119px">Enter Role Name</asp:Label>
                             <span style="color: #FF0000"><strong>*</strong></span><asp:textbox id="TxtRole_name" runat="server" AutoPostBack="True" CssClass="form-control"></asp:textbox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtRole_name"
                            ErrorMessage="Enter Role Name" Font-Bold="True" SetFocusOnError="True">Enter Function Name</asp:RequiredFieldValidator></th>
                        
               </div>
      
           <div class="form-group">
                    
                             <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" 
                                 ForeColor="Black" Width="117px">Role Description</asp:Label>
                             <span style="color: #FF0000"><strong>*</strong></span><asp:textbox id="TxtRole_name0" runat="server" CssClass="form-control"
                                 AutoPostBack="True" Height="51px" TextMode="MultiLine"></asp:textbox>
                        
               </div>
           <div class="form-group">
                     
                             <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" 
                                 ForeColor="Black" Width="135px">Access Days</asp:Label>
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: #FF0000"><strong>* </strong></span>
                           
          <telerik:RadNumericTextBox ID="txtDays" Runat="server" AutoPostBack="True" CssClass="form-control" Width="100%" EmptyMessage="30">
                            <NumberFormat DecimalDigits="0" GroupSeparator="" />
                        </telerik:RadNumericTextBox>
                        
                        
               </div>
        </div>

   
     
          <div class="col-md-10"> 

                     <tr>
                         <th style="height: 29px">
                             &nbsp;</th>
                         <th colspan="3" style="height: 29px; text-align: left;">
                             <h3 style="color: #CC0000">
                                 DATA CAPTURE PRIVILEGES</h3>
                         </th>
                         <th style="height: 29px">
                             &nbsp;</th>
                     </tr>
                    <table class="table table-bordered table-hover">
                     <tr>
                         <td >
                         </td>
                         <td style="width: 259px">
                             Application Data Capture
                             Privileges</td>
                         <td style="width: 55px">
                         </td>
                         <td style="width: 306px">
                        Assigned Application Data Capture Privileges</td>
                         <td>
                         </td>
                     </tr>
                     <tr  style="color: #0000ff">
                         <td  style="height: 39px">
                         </td>
                         <td style="height: 39px; width: 259px;">
                        <asp:ListBox ID="LstFrom_Menu" runat="server" Height="231px" SelectionMode="Multiple"
                            Width="283px" CssClass="list-group" Font-Size="X-Small"></asp:ListBox></td>
                         <td style="color: #0000ff; height: 39px; width: 55px; text-align: center;">
                        <asp:Button ID="Back" runat="server" Text="<" Width="26px" Font-Size="Small" /><asp:Button ID="nextbln"
                            runat="server" Text=">" Width="24px" Font-Size="Small" /></td>
                         <td style="width: 306px; color: #0000ff; height: 39px">
                        <asp:ListBox ID="LstTo_Menu" runat="server" Height="231px" SelectionMode="Multiple"
                            Width="283px" CssClass="list-group" Font-Size="X-Small"></asp:ListBox></td>
                         <td style="color: #0000ff; height: 39px">
                         </td>
                     </tr>
                     <tr class="row-b" style="color: #0000ff">
                         <td  style="height: 71px">
                         </td>
                         <td style="height: 71px; width: 259px" valign="top">
                                <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Height="27px" 
                                    Text="Can Authorise?" Width="125px" />
                                <asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="True" Height="17px" 
                                    Text="Can Post Operation Transaction?" Width="221px" />
                                <br />
                                <br />
                                <br />
                                <asp:Button ID="Submit" runat="server" CssClass="btn bg-purple btn-flat margin" Font-Size="Small" 
                                    Text="Save Record" Width="103px" />
                         </td>
                         <td style="width: 55px; height: 71px;">
                         </td>
                         <td style="width: 306px; height: 71px;">
                             <asp:Panel ID="panelreport" runat="server" Height="278px" Visible="False">
                                  <table class="table table-bordered table-hover">
                                     <tr>
                                         <td>
                                             Group Reports List</td>
                                     </tr>
                                     <tr>
                                         <td>
                                             <asp:CheckBoxList ID="ChkReportList" runat="server" AutoPostBack="True" 
                                                 Height="127px" Width="159px">
                                                 <asp:ListItem Value="1">CSO</asp:ListItem>
                                                 <asp:ListItem Value="2">Operation</asp:ListItem>
                                                 <asp:ListItem Value="3">Fincon</asp:ListItem>
                                                 <asp:ListItem Value="4">MIS (Management)</asp:ListItem>
                                                 <asp:ListItem Value="5">Internal Control</asp:ListItem>
                                                 <asp:ListItem Value="6">Monthly Report</asp:ListItem>
                                                 <asp:ListItem Value="7">Admin</asp:ListItem>
                                             </asp:CheckBoxList>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td>
                                             &nbsp;</td>
                                     </tr>
                                     <tr>
                                         <td>
                                             &nbsp;</td>
                                     </tr>
                                     <tr>
                                         <td>
                                             &nbsp;</td>
                                     </tr>
                                     <tr>
                                         <td>
                                             &nbsp;</td>
                                     </tr>
                                     <tr>
                                         <td>
                                             &nbsp;</td>
                                     </tr>
                                 </>
                             </asp:Panel>
                             </td>
                         <td style="height: 71px">
                         </td>
                     </tr>
                          </table>
                     <tr class="row-b" style="color: #0000ff">
                         <td >
                             &nbsp;</td>
                         <td colspan="3">
                                <asp:MultiView ID="MultiView2" runat="server">
                             <asp:View ID="View2" runat="server">
                                 <table class="table table-bordered table-hover">
                                     <tr>
                                         <td style="font-size: large; color: #990000; height: 36px;" colspan="2">
                                             <b>AUTHORIZATION PRIVILEDGES</b></td>
                                         <td colspan="1" class="style1" style="height: 36px">
                                         </td>
                                     </tr>
                                     <tr>
                                         <td rowspan="1" style="width: 216px">
                                             <span style="color: #000099"><strong>Un-Assigned Authorization Priviledges</strong></span></td>
                                         <td rowspan="1" style="width: 216px">
                                             <span style="color: #000099"><strong>Assigned Authorization Priviledges</strong></span></td>
                                         <td colspan="1">
                                         </td>
                                     </tr>
                                     <tr>
                                         <td style="width: 216px" rowspan="6"><asp:ListBox ID="ListBox1" runat="server" 
                                                 Height="231px" SelectionMode="Multiple"
                            Width="273px" Font-Size="X-Small" CssClass="list-group"></asp:ListBox></td>
                                         <td style="width: 107px" rowspan="6"><asp:ListBox ID="ListBox2" runat="server" 
                                                 Height="231px" SelectionMode="Multiple"
                            Width="261px" Font-Size="X-Small" CssClass="list-group"></asp:ListBox></td>
                                         <td colspan="1">
                                         </td>
                                     </tr>
                                     <tr>
                                         <td style="width: 100px">
                                         </td>
                                     </tr>
                                     <tr>
                                         <td style="width: 100px">
                                         </td>
                                     </tr>
                                     <tr>
                                         <td style="width: 100px">
                                         </td>
                                     </tr>
                                     <tr>
                                         <td style="width: 100px">
                                         </td>
                                     </tr>
                                     <tr>
                                         <td style="width: 100px">
                                         </td>
                                     </tr>

                                   
                                     <tr>
                                         <td style="text-align: center;" colspan="2">
                                             <asp:Button ID="Button2" runat="server" Font-Size="Small" Text="&lt;" 
                                                 Width="26px" />
                                             <asp:Button ID="Button3" runat="server" Font-Size="Small" Text="&gt;" 
                                                 Width="24px" />
                                         </td>
                                     </tr>

                                     
                                   
                                 </table>
                                 <div class="panel-footer">
                     
                             <asp:Button ID="Submit0" runat="server" CssClass="btn bg-purple btn-flat margin" Font-Size="Small" 
                                 Text="Save Auth Priviledge" ValidationGroup="News" />
                             <asp:Button ID="Close" runat="server" CssClass="btn bg-maroon btn-flat margin" Font-Size="Small" 
                                 Text="Return" />
                        
			</div>
                             </asp:View>
                         </asp:MultiView>
                         </td>
                         <td>
                             &nbsp;</td>
                     </tr>
              </div>

          </div>
      

      </div>
		
		</ContentTemplate> 
		</asp:UpdatePanel> 
            </asp:Content>

