<%@ Page Title="" Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="CoopRegAuth.aspx.vb" Inherits="CoopRegAuth" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
   <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>


     <!-- jQuery UI -->
    <script type="text/javascript" src="js/jquery-ui-1.8.21.custom.min.js"></script>
    <!-- transition / effect library -->
    <script type="text/javascript" src="js/bootstrap-transition.js"></script>
    <!-- alert enhancer library -->
    <script type="text/javascript" src="js/bootstrap-alert.js"></script>
    <!-- modal / dialog library -->
    <script type="text/javascript" src="js/bootstrap-modal.js"></script>
    <!-- custom dropdown library -->
    <script type="text/javascript" src="js/bootstrap-dropdown.js"></script>
    <!-- scrolspy library -->
    <script type="text/javascript" src="js/bootstrap-scrollspy.js"></script>
    <!-- library for creating tabs -->
    <script type="text/javascript" src="js/bootstrap-tab.js"></script>
    <!-- library for advanced tooltip -->
    <script type="text/javascript" src="js/bootstrap-tooltip.js"></script>
    <!-- popover effect library -->
    <script type="text/javascript" src="js/bootstrap-popover.js"></script>
    <!-- button enhancer library -->
    <script type="text/javascript" src="js/bootstrap-button.js"></script>
    <!-- accordion library (optional, not used in demo) -->
    <script type="text/javascript" src="js/bootstrap-collapse.js"></script>
    <!-- carousel slideshow library (optional, not used in demo) -->
    <script type="text/javascript" src="js/bootstrap-carousel.js"></script>
    <!-- autocomplete library -->
    <script type="text/javascript" src="js/bootstrap-typeahead.js"></script>
    <!-- tour library -->
    <script type="text/javascript" src="js/bootstrap-tour.js"></script>
    <!-- library for cookie management -->
    <script type="text/javascript" src="js/jquery.cookie.js"></script>
    <!-- calander plugin -->
    <script type="text/javascript" src="js/fullcalendar.min.js"></script>
    <!-- data table plugin -->
<script type="text/javascript"  src="Scripts/jquery.dataTables.min.js"></script>
    <!-- chart libraries start -->
    <script type="text/javascript" src="js/excanvas.js"></script>
    <script type="text/javascript" src="js/jquery.flot.min.js"></script>
    <script type="text/javascript" src="js/jquery.flot.pie.min.js"></script>
    <script type="text/javascript" src="js/jquery.flot.stack.js"></script>
    <script type="text/javascript" src="js/jquery.flot.resize.min.js"></script>
    <!-- chart libraries end -->
    <!-- select or dropdown enhancer -->
    <script type="text/javascript" src="js/jquery.chosen.min.js"></script>
    <!-- checkbox, radio, and file input styler -->
    <script type="text/javascript" src="js/jquery.uniform.min.js"></script>
    <!-- plugin for gallery image view -->
    <script type="text/javascript" src="js/jquery.colorbox.min.js"></script>
    <!-- rich text editor library -->
    <script type="text/javascript" src="js/jquery.cleditor.min.js"></script>
    <!-- notification plugin -->
    <script type="text/javascript" src="js/jquery.noty.js"></script>
    <!-- file manager library -->
    <script type="text/javascript" src="js/jquery.elfinder.min.js"></script>
    <!-- star rating plugin -->
    <script type="text/javascript" src="js/jquery.raty.min.js"></script>
    <!-- for iOS style toggle switch -->
    <script type="text/javascript" src="js/jquery.iphone.toggle.js"></script>
    <!-- autogrowing textarea plugin -->
    <script type="text/javascript" src="js/jquery.autogrow-textarea.js"></script>
    <!-- multiple file upload plugin -->
    <script type="text/javascript" src="js/jquery.uploadify-3.1.min.js"></script>
    <!-- history.js for cross-browser state change on ajax -->
    <script type="text/javascript" src="js/jquery.history.js"></script>
    <!-- application script for Charisma demo -->
    <script type="text/javascript" src="js/charisma.js"></script>




    
 <script type="text/javascript" src="js/dataTables.bootstrap.js"></script>
 <script type="text/javascript" src="js/dataTables.bootstrap.min.js"></script>
 <script type="text/javascript" src="js/dataTables.bootstrap4.js"></script>
 <script type="text/javascript" src="js/dataTables.bootstrap4.min.js"></script>
 <%--<script type="text/javascript" src="../js/dataTables.foundation.js"></script>
 <script type="text/javascript" src="../js/dataTables.foundation.min.js"></script>
 <script type="text/javascript" src="../js/dataTables.jqueryui.js"></script>
 <script type="text/javascript" src="../js/dataTables.jqueryui.min.js"></script>
 <script type="text/javascript" src="../js/dataTables.material.js"></script>--%>
<%-- <script type="text/javascript" src="../js/dataTables.material.min.js"></script>
 <script type="text/javascript" src="../js/dataTables.semanticui.js"></script>
 <script type="text/javascript" src="../js/dataTables.semanticui.min.js"></script>
 <script type="text/javascript" src="../js/dataTables.uikit.js"></script>
 <script type="text/javascript" src="../js/dataTables.uikit.min.js"></script>--%>
<%-- <script type="text/javascript" src="../js/jquery.dataTables.js"></script>
 <script type="text/javascript" src="../js/jquery.dataTables.min.js"></script>--%>
 
    <%--<script type="text/javascript">

        $(document).ready(function () {
            $('#Radgrid1').DataTable({
                "pagingType": "full_numbers"
            });
        });
    </script>--%>

                     
   <div class="panel panel-default">
         <div class="panel-heading">
                                         
        
            </div>

		<div class="panel-body">
		
     <asp:Panel ID="Panel3" runat="server" Height="100%" Width="100%">
   


          <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
        <style type="text/css">
            .orderText {
                font: normal 12px Arial,Verdana;
                margin-top: 6px;
            }


        </style>
    </telerik:RadCodeBlock>
          <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" Skin="Simple" Visible="False" />
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
          <%--  function ShowEditForm(id, rowIndex) {
                var grid = $find("<%= RadGrid1.ClientID%>");

                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);

                window.radopen("ViewPicture.aspx?ApplicationNo=" + id, "UserListDialog");
                return false;
            }--%>

         function ShowRegDetail(id, rowIndex) {
               

                window.radopen("ViewCoopReqDetail.aspx?UniqueID=" + id, "UserListDialog");
                return false;
            }
         function ResendAccessLink(id, rowIndex) {
             window.radopen("ResendEmail.aspx?UniqueID=" + id, "UserListDialog2");
             return false;
         }
            //function ShowInsertForm() {
            //    window.radopen("AddReg.aspx", "UserListDialog");
            //    return false;
            //}


<%--            function refreshGrid() {
            
                $("#<%#Button1.ClientID %>").click();
        }--%>
            
 function RefreshParentPage()//function in parent page
{
document.location.reload();
}
        
            $(document).ready(function () {
                $(".gvdatatable").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                    "lengthMenu": [[10, 15, 25, 50, -1], [10, 15, 25, 50, "All"]] //value:item pair
                });
            });
        </script>
    </telerik:RadCodeBlock>

       <%--   <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="gridLoadingPanel"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>--%>
   
         <asp:Panel ID="Panel1" runat="server" Visible="False">
                      <div class="alert alert-success alert-dismissable">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    <h4>	<i class="icon fa fa-check"></i> Alert!</h4>
                          <asp:Label ID="Label_success" runat="server" Text=""></asp:Label>
                  </div>
                </asp:Panel>

         <asp:Panel ID="Panel2" runat="server" Visible="False">
                    <div class="alert alert-danger alert-dismissable">
                        <button aria-hidden="true" class="close" data-dismiss="alert" type="button">
                            ×
                        </button>
                        <h4><i class="icon fa fa-ban"></i>Alert!</h4>
                        <asp:Label ID="Label_error" runat="server" Text=""></asp:Label>
                    </div>
                </asp:Panel>

        
        
 
       <telerik:RadAjaxLoadingPanel runat="server" ID="gridLoadingPanel"></telerik:RadAjaxLoadingPanel>

    
            <div class="form-group">
<%--         <a href="#" onclick="return ShowInsertForm();" class="btn btn-success"><span class="glyphicon glyphicon-plus"/>Add New Portal User</a>--%>
      <asp:LinkButton ID="Refresh" CssClass="btn btn-warning" CommandName="Refresh" runat="server"><span class="glyphicon glyphicon-refresh"/>Refresh</asp:LinkButton>
                  <asp:Button ID="Export_To_Word" runat="server" Text="Word" Visible="false"  CssClass="" />
               <asp:Button ID="Export_To_Excel" runat="server" Text="Excel" Visible="false" />
               <asp:Button ID="Export_To_CSV" runat="server" Text="CSV" Visible="false"  />
               <asp:Button ID="Export_To_PDF" runat="server" Text="PDF" Visible="false" />
                <asp:Button ID="Button1" runat="server" Text="Reload" Visible="false" />
        </div>
            <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                DataKeyNames="UniqueID" Width="100%" CssClass="gvdatatable" CellPadding="3" onrowcommand="GridView1_RowCommand"  OnRowDataBound="GridView1_RowDataBound" Font-Size="Small" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <RowStyle ForeColor="#000066" HorizontalAlign="Left" />
              
                    <Columns>
                      <asp:BoundField HeaderText="UniqueID"  Visible="false" 
                 DataField="UniqueID" 
                 SortExpression="UniqueID" ></asp:BoundField>
                         <asp:BoundField DataField="Org_name" HeaderText="Cooperative Name" SortExpression="Org_name"
                    >

               </asp:BoundField>

                           <asp:BoundField DataField="CoopId" HeaderText="Coop ID" SortExpression="CoopId"
                    >

                </asp:BoundField>

<%--                <asp:BoundField  DataField="Statename" HeaderText="State" SortExpression="State"
                    >

                </asp:BoundField>--%>
                             
                <asp:BoundField  DataField="Email" HeaderText="Email" SortExpression="Email"
                    >

               </asp:BoundField>


 
             
                  
      <asp:BoundField DataField="Create_date" HeaderText="Date Created" SortExpression="Createdate"
                    >

                </asp:BoundField>
                  
                
                 <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"
                   >

                </asp:BoundField>
                         <asp:TemplateField Visible="False" HeaderText="Email" >
                               <ItemTemplate>
                                   
                           <asp:Label ID="Label_Status" runat="server" Text='<%# Eval("Status") %>' ></asp:Label>
                          

                                    </ItemTemplate>
        </asp:TemplateField>

                         <asp:TemplateField Visible="True" HeaderText="Action">
            <ItemTemplate>
                              <asp:LinkButton ID="editLinkDetail" CssClass="btn btn-primary" ToolTip="View Registration" runat="server"><span class="glyphicon glyphicon-list-alt"/>View Request</asp:LinkButton>
              <asp:LinkButton ID="ResendEmailLink"  CssClass="btn btn-warning btn-sm" CommandName="select" ToolTip="Resend Approval Email Link" runat="server"><span class="glyphicon glyphicon-envelope"/>Resend Approval Mail</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
				
                    </Columns>
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                </div>
                    
            
        

      <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" Modal="False" KeepInScreenBounds="True" AutoSize="False" AutoSizeBehaviors="Default" VisibleStatusbar="False" Animation="FlyIn" OnClientClose="RefreshParentPage" >
           <Windows>
            <telerik:RadWindow RenderMode="Lightweight" ID="UserListDialog" runat="server"  Height="600px"
                Width="720px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                Modal="true">
            </telerik:RadWindow>
                <telerik:RadWindow RenderMode="Lightweight" ID="UserListDialog2" runat="server"  Height="200px"
                Width="420px" Left="150px" ReloadOnShow="true" ShowContentDuringLoad="false"
                Modal="true">
            </telerik:RadWindow>
          </Windows>
    </telerik:RadWindowManager>  
           
      
         
           
      
           
      
         
           
      
</asp:Panel>

     
                </div>
              </div>
                  
       
        </asp:Content>

