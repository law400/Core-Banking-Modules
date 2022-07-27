<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Datatables.test.aspx.vb" Inherits="Datatables_test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="plugins/jvectormap/jquery-jvectormap-1.2.2.css"/>
   
    <!-- Theme style -->
     <link rel="stylesheet" href="dist/font-awesome.min.css"/>
    <!-- Ionicons -->
    <link rel="stylesheet" href="dist/ionicons.min.css"/>
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css"/>
    <%-- <link  href="css/bootstrap.css" rel="stylesheet"/>--%>
     <link  href="css/css/bootstrap-cerulean.css" rel="stylesheet"/>
   <link href="css/jquery.dataTables_themeroller.css" rel="stylesheet"/>
    <link href="css/jquery.dataTables.min.css" rel="stylesheet"/>
    <link href="css/jquery.dataTables.css" rel="stylesheet"/>


    <%--<link href="css/dataTables.bootstrap.css" rel="stylesheet"/>
<link href="css/dataTables.bootstrap.min.css" rel="stylesheet"/>
<link href="css/dataTables.bootstrap4.css" rel="stylesheet"/>
<link href="css/dataTables.bootstrap4.min.css" rel="stylesheet"/>--%>
<link href="css/dataTables.foundation.css" rel="stylesheet"/>
<link href="css/dataTables.foundation.min.css" rel="stylesheet"/>
    <link href="css/dataTables.jqueryui.css" rel="stylesheet"/>
 <link href="css/dataTables.jqueryui.min.css " rel="stylesheet"/>
 <%--<link href="css/dataTables.material.css " rel="stylesheet"/>
 <link href="css/dataTables.material.min.css " rel="stylesheet"/>
 <link href="css/dataTables.semanticui.css " rel="stylesheet"/>
 <link href="css/dataTables.semanticui.min.css " rel="stylesheet"/>
 <link href="css/dataTables.uikit.css " rel="stylesheet"/>
 <link href="css/dataTables.uikit.min.css " rel="stylesheet"/>--%>



    <link rel="stylesheet" href="dist/font-awesome.css"/>
    <link href="css/bootstrap-responsive.css" rel="stylesheet"/>
    <link href="css/charisma-app.css" rel="stylesheet"/>
    <link href="css/jquery-ui-1.8.21.custom.css" rel="stylesheet"/>
    
    <link href="css/uniform.default.css" rel="stylesheet"/>
    <link href="css/colorbox.css" rel="stylesheet"/>
    <link href="css/jquery.cleditor.css" rel="stylesheet"/>
    <link href="css/jquery.noty.css" rel="stylesheet"/>
    <link href="css/noty_theme_default.css" rel="stylesheet"/>
    <link href="css/elfinder.min.css" rel="stylesheet"/>
    
    <link href="css/opa-icons.css" rel="stylesheet"/>
    <link href="css/uploadify.css" rel="stylesheet"/>
    <!-- AdminLTE Skins. Choose a skin from the css/skins
         folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="dist/css/skins/_all-skins.min.css"/>
<%--      <link href="bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />--%>

    <link rel="stylesheet" type="text/css" href="css/jquery.dataTables.min.css"  />


        <link rel="stylesheet" type="text/css" href="css/buttons.jqueryui.min.css"  />
            <link rel="stylesheet" type="text/css" href="css/buttons.jqueryui.css"  />


    
        <link rel="stylesheet" type="text/css" href="css/buttons.semanticui.css"  />
            <link rel="stylesheet" type="text/css" href="css/buttons.semanticui.min.css"  />

    
        <link rel="stylesheet" type="text/css" href="css/buttons.foundation.css"  />
            <link rel="stylesheet" type="text/css" href="css/buttons.foundation.min.css"  />

    
        <link rel="stylesheet" type="text/css" href="css/buttons.dataTables.css"  />
            <link rel="stylesheet" type="text/css" href="css/buttons.dataTables.min.css"  />

    
        <link rel="stylesheet" type="text/css" href="css/buttons.bootstrap.css"  />
            <link rel="stylesheet" type="text/css" href="css/buttons.bootstrap.min.css"  />

    
        <link rel="stylesheet" type="text/css" href="css/buttons.bootstrap4.css"  />
            <link rel="stylesheet" type="text/css" href="css/buttons.bootstrap4.min.css"  />



    <script type="text/javascript" src="../js/jquery-1.7.2.min.js"></script>


     <!-- jQuery UI -->
    <script type="text/javascript" src="../js/jquery-ui-1.8.21.custom.min.js"></script>
    <!-- transition / effect library -->
    <script type="text/javascript" src="../js/bootstrap-transition.js"></script>
    <!-- alert enhancer library -->
    <script type="text/javascript" src="../js/bootstrap-alert.js"></script>
    <!-- modal / dialog library -->
    <script type="text/javascript" src="../js/bootstrap-modal.js"></script>
    <!-- custom dropdown library -->
    <script type="text/javascript" src="../js/bootstrap-dropdown.js"></script>
    <!-- scrolspy library -->
    <script type="text/javascript" src="../js/bootstrap-scrollspy.js"></script>
    <!-- library for creating tabs -->
    <script type="text/javascript" src="../js/bootstrap-tab.js"></script>
    <!-- library for advanced tooltip -->
    <script type="text/javascript" src="../js/bootstrap-tooltip.js"></script>
    <!-- popover effect library -->
    <script type="text/javascript" src="../js/bootstrap-popover.js"></script>
    <!-- button enhancer library -->
    <script type="text/javascript" src="../js/bootstrap-button.js"></script>
    <!-- accordion library (optional, not used in demo) -->
    <script type="text/javascript" src="../js/bootstrap-collapse.js"></script>
    <!-- carousel slideshow library (optional, not used in demo) -->
    <script type="text/javascript" src="../js/bootstrap-carousel.js"></script>
    <!-- autocomplete library -->
    <script type="text/javascript" src="../js/bootstrap-typeahead.js"></script>
    <!-- tour library -->
    <script type="text/javascript" src="../js/bootstrap-tour.js"></script>
    <!-- library for cookie management -->
    <script type="text/javascript" src="../js/jquery.cookie.js"></script>
    <!-- calander plugin -->
    <script type="text/javascript" src="../js/fullcalendar.min.js"></script>
    <!-- data table plugin -->
    <script type="text/javascript" src="../js/jquery.dataTables.min.js"></script>
    <!-- chart libraries start -->
    <script type="text/javascript" src="../js/excanvas.js"></script>
    <script type="text/javascript" src="../js/jquery.flot.min.js"></script>
    <script type="text/javascript" src="../js/jquery.flot.pie.min.js"></script>
    <script type="text/javascript" src="../js/jquery.flot.stack.js"></script>
    <script type="text/javascript" src="../js/jquery.flot.resize.min.js"></script>
    <!-- chart libraries end -->
    <!-- select or dropdown enhancer -->
    <script type="text/javascript" src="../js/jquery.chosen.min.js"></script>
    <!-- checkbox, radio, and file input styler -->
    <script type="text/javascript" src="../js/jquery.uniform.min.js"></script>
    <!-- plugin for gallery image view -->
    <script type="text/javascript" src="../js/jquery.colorbox.min.js"></script>
    <!-- rich text editor library -->
    <script type="text/javascript" src="../js/jquery.cleditor.min.js"></script>
    <!-- notification plugin -->
    <script type="text/javascript" src="../js/jquery.noty.js"></script>
    <!-- file manager library -->
    <script type="text/javascript" src="../js/jquery.elfinder.min.js"></script>
    <!-- star rating plugin -->
    <script type="text/javascript" src="../js/jquery.raty.min.js"></script>
    <!-- for iOS style toggle switch -->
    <script type="text/javascript" src="../js/jquery.iphone.toggle.js"></script>
    <!-- autogrowing textarea plugin -->
    <script type="text/javascript" src="../js/jquery.autogrow-textarea.js"></script>
    <!-- multiple file upload plugin -->
    <script type="text/javascript" src="../js/jquery.uploadify-3.1.min.js"></script>
    <!-- history.js for cross-browser state change on ajax -->
    <script type="text/javascript" src="../js/jquery.history.js"></script>
    <!-- application script for Charisma demo -->
    <script type="text/javascript" src="../js/charisma.js"></script>




    
 <script type="text/javascript" src="../js/dataTables.bootstrap.js"></script>
 <script type="text/javascript" src="../js/dataTables.bootstrap.min.js"></script>
 <script type="text/javascript" src="../js/dataTables.bootstrap4.js"></script>
 <script type="text/javascript" src="../js/dataTables.bootstrap4.min.js"></script>
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

</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager runat="server" ID="ScriptManager1">

    </asp:ScriptManager>
    <div>
    <telerik:radgrid ID="RadGrid1" runat="server"  Height="380px" EnableEmbeddedBaseStylesheet="false" ClientDataKeyNames="Employeeid" OnItemCreated="RadGrid1_ItemCreated"
            EnableEmbeddedSkins="false" OnNeedDataSource="RadGrid1_NeedDataSource"
            AutoGenerateColumns="false"  Font-Size="Small" GridLines="None" >

            <MasterTableView EditMode="InPlace"  CssClass="table table-striped table-bordered bootstrap-datatable datatable"  DataKeyNames="Employeeid" CommandItemDisplay="Top"
                InsertItemPageIndexAction="ShowItemOnCurrentPage">
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>

                  <Columns>

                <telerik:GridBoundColumn DataField="EmployeeID" HeaderText="Employee Number " SortExpression="EmployeeID"
                    UniqueName="EmployeeID">
<HeaderStyle Width="10px" />
                </telerik:GridBoundColumn>

                 <telerik:GridBoundColumn DataField="EmployeeName" HeaderText="Full Name " SortExpression="EmployeeName"
                    UniqueName="EmployeeName">
<HeaderStyle Width="10px" />
                </telerik:GridBoundColumn>
                             
                 <telerik:GridBoundColumn DataField="Monthlycontri" HeaderText="Monthlycontri" SortExpression="Monthlycontri"
                    UniqueName="Monthlycontri">
<HeaderStyle Width="10px" />
                </telerik:GridBoundColumn>


 
                <telerik:GridBoundColumn DataField="create_date" HeaderText="Date Applied" SortExpression="create_date"
                    UniqueName="create_date">
<HeaderStyle Width="15px" />
                </telerik:GridBoundColumn>
                  
    
                
                <telerik:GridBoundColumn DataField="Status" HeaderText="Status" SortExpression="Status"
                    UniqueName="Status">
<HeaderStyle Width="10px" />
                </telerik:GridBoundColumn>



                  
                      <telerik:GridTemplateColumn UniqueName="TemplateEditColumn">
                    <ItemTemplate>
                        

<asp:ImageButton runat="server" CssClass="btn btn-primary" ID="editLinkDetail" ToolTip="View Registration Detail" AlternateText="View Records"></asp:ImageButton>


                    </ItemTemplate>
<HeaderStyle Width="10px" />
                </telerik:GridTemplateColumn>

            </Columns>

   <CommandItemTemplate>
                <a href="#" onclick="return ShowInsertForm();" class="btn btn-success">Add New Portal User</a>
            </CommandItemTemplate>
            
            </MasterTableView>
          <%--  <ClientSettings>
                <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                <ClientEvents OnGridCreated="demo.onGridCreated" />
            </ClientSettings>--%>
           
        </telerik:RadGrid>
    </div>
    </form>
</body>
</html>
