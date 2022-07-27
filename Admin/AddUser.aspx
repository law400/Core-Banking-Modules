<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AddUser.aspx.vb" Inherits="Admin_AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add User</title>
        <link href="template/css/style.default.css" rel="stylesheet"/>
        <link href="template/css/morris.css" rel="stylesheet"/>
        <link href="template/css/select2.css" rel="stylesheet" />
        <!-- Theme style -->
     <link rel="stylesheet" href="dist/font-awesome.min.css"/>
        <link rel="stylesheet" href="dist/font-awesome.css"/>

    <!-- Ionicons -->
    <link rel="stylesheet" href="dist/ionicons.min.css"/>
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css"/>
     <link rel="stylesheet" href="dist/font-awesome.min.css"/>
    <!-- Ionicons -->
    <link rel="stylesheet" href="dist/ionicons.min.css"/>
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css"/>
     <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="plugins/jvectormap/jquery-jvectormap-1.2.2.css"/>
   
    <!-- Theme style -->
     <link rel="stylesheet" href="dist/font-awesome.min.css"/>
    <!-- Ionicons -->
    <link rel="stylesheet" href="dist/ionicons.min.css"/>
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css"/>

   <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="plugins/jvectormap/jquery-jvectormap-1.2.2.css"/>
   
    <!-- Theme style -->
     <link rel="stylesheet" href="dist/font-awesome.min.css"/>
    <!-- Ionicons -->
    <link rel="stylesheet" href="dist/ionicons.min.css"/>
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css"/>
     <link  href="css/css/bootstrap-cerulean.css" rel="stylesheet"/>
 

   



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



   
    <link rel="stylesheet" href="dist/css/skins/_all-skins.min.css"/>

 <script src="Assets/toastr.min.js"></script>
        <script src="Assets/script.js"></script>
        <link href="Assets/toastr.min.css" rel="stylesheet" />


     <script src="template/js/jquery-1.11.1.min.js"></script>

    <script type="text/javascript">
            function CloseAndRebind(args)
            {
                GetRadWindow().BrowserWindow.refreshGrid(args);
                GetRadWindow().close();
            }
  
            function GetRadWindow()
            {
                var oWindow = null;
                if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)
  
                return oWindow;
            }
  
            function CancelEdit()
            {
                GetRadWindow().close();
            }
        </script>
</head>
<body>
    <form id="form1" runat="server">
      <asp:ScriptManager runat="server" ID="ScriptManager1">

    </asp:ScriptManager>
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
   
         <div class="panel panel-default">
              <div class="panel-heading">
              </div>
               <div class="panel-body">

                   
<div class="col-md-6">
              <div class="form-group"> 
			  <asp:Label ID="Label1" style="text-align:left; font-weight:bold" runat="server" Text="Staff/User ID"></asp:Label>
                  &nbsp;<span style="color: #FF0000">*</span>
                   <asp:TextBox ID="txtStaffid" runat="server" Font-Size="Small" MaxLength="20" AutoPostBack="True" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStaffid"
                        Display="Dynamic" ErrorMessage="Enter Staff ID" ValidationGroup="News" Width="139px">Enter Staff ID</asp:RequiredFieldValidator>
			   </div>
               <div class="form-group"> 
                    <label style="text-align:left; width:200px">Staff Name <span style="color: #FF0000">*</span></label>
                <asp:TextBox ID="txtStaffName" runat="server" CssClass="form-control" Font-Size="Small" MaxLength="100" TabIndex="0"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtStaffName" Display="Dynamic" ErrorMessage="Enter Staff Name" ValidationGroup="News" Width="139px">Enter Staff Name</asp:RequiredFieldValidator>
               </div>
               <div class="form-group"> 
                    <label style="text-align:left; width:200px">Branch<span style="color: #FF0000">*</span></label>
                             <asp:DropDownList ID="DrpBranch" runat="server" AutoPostBack="True" CssClass="form-control" Font-Size="Small" TabIndex="0">
                         </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DrpBranch" Display="Dynamic" ErrorMessage="Select a Branch" ValidationGroup="News" Width="139px">Select a Branch</asp:RequiredFieldValidator>
               </div>
    <div class="form-group"> 
                    <label style="text-align:left; width:200px">Department<span style="color: #FF0000">*</span></label>
                            <asp:DropDownList ID="DrpDept" runat="server" AutoPostBack="True" 
                        Font-Size="Small" CssClass="form-control">
                    </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DrpDept" Display="Dynamic" ErrorMessage="Select a Dept" ValidationGroup="News" Width="139px">Select a Dept</asp:RequiredFieldValidator>
               </div>
     <div class="form-group"> 
                    <label style="text-align:left; width:200px">Role<span style="color: #FF0000">*</span></label>
                            <asp:DropDownList ID="DrpFunction1" runat="server" AutoPostBack="True" Font-Size="Small" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="DrpFunction1"
                        Display="Dynamic" ErrorMessage="Select a Functional Role" ValidationGroup="News"
                        Width="390px">Select a Functional Role</asp:RequiredFieldValidator>
               </div>

               <div class="form-group"> 
                    <label style="text-align:left; width:200px">Email <span style="color: #FF0000">*</span></label>
                            <asp:TextBox ID="txtemail" runat="server" TabIndex="3" Width="100%" CssClass="form-control"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                ControlToValidate="txtemail" Display="Dynamic" 
                                ErrorMessage="Enter Email" ValidationGroup="News" SetFocusOnError="True">Enter Email</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="txtemail" Display="Dynamic" 
                                ErrorMessage="enter email correctly" SetFocusOnError="True" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                Width="108px" ValidationGroup="news">enter email correctly</asp:RegularExpressionValidator>
               </div>
               <div class="form-group"> 
                    <label style="text-align:left; width:200px">Mobile Phone No <span style="color: #FF0000">*</span></label>
                           <asp:TextBox ID="txtPhone" runat="server" Font-Size="Small" 
                        MaxLength="15" CssClass="form-control"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtPhone"
                        Display="Dynamic" ErrorMessage="CompareValidator" Operator="DataTypeCheck" Type="Integer"
                        ValueToCompare="News" Width="370px">Phone Number Must be in Digit</asp:CompareValidator>
               </div>
               <div class="form-group"> 
                    <label style="text-align:left; width:200px">User Status <span style="color: #FF0000">*</span></label>
                            <asp:DropDownList ID="DrpStatus1" runat="server" AutoPostBack="True" Font-Size="Small" CssClass="form-control">
                    </asp:DropDownList>
                           
               </div>
    <div class="form-group">
 <label style="text-align:left; width:200px">Does this Staff Supervise Other Staff ?</label>
         <asp:CheckBox ID="ChkAuth" runat="server" AutoPostBack="True" />
         </div>
     <div class="form-group">
         <label style="text-align:left; width:200px">Report To?</label>
         <asp:DropDownList ID="DrpReport" runat="server" AutoPostBack="True" CssClass="form-control" Font-Size="Small">
                         </asp:DropDownList>
         </div>

      <div class="form-group"> 
           <asp:Label ID="Label7" runat="server" Text="Password" Visible="False"></asp:Label>
          <asp:TextBox ID="txtNewPassword" runat="server" 
                                 TextMode="Password" Visible="False"  CssClass="form-control"></asp:TextBox>
          </div>
      <div class="form-group"> 
           <asp:Label ID="Label8" runat="server" Text="Confirm Password" Visible="False"></asp:Label>
         <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" 
                                 Visible="False" CssClass="form-control"></asp:TextBox>

           <asp:CompareValidator ID="CompareValidator3" runat="server" 
                                 ControlToCompare="txtNewPassword" ControlToValidate="txtPassword" 
                                 Display="Dynamic" 
                                 ErrorMessage="Your Password are not the Same.Pls Re-enter Password" 
                                 Width="426px"></asp:CompareValidator>
          </div>

     
      <div class="form-group">
          <asp:Label ID="Label5" runat="server" Text="Till Acc/No." Visible="False"></asp:Label>
           <asp:TextBox ID="txttillaccno" runat="server" AutoPostBack="True" 
                                  Visible="False" CssClass="form-control"></asp:TextBox>
                             <asp:Label ID="Label6" runat="server" Width="100px"></asp:Label>
          </div>
      
	</div>

	<div class="col-md-6">
           <asp:Panel ID="Panel3" runat="server" ScrollBars="Auto" Width="100%">
           <tr>
                         <td colspan="4" style="text-align: left">
                             <br />
                             <asp:Label ID="Label9" runat="server" style="font-size: large" ForeColor="Red"></asp:Label>
                         </td>
                     </tr>
                     <tr>
                         <td colspan="4" style="text-align: left">
                             <asp:CheckBoxList ID="chkmenu" runat="server" AutoPostBack="True" 
                                 DataValueField="menu_id" RepeatColumns="6" RepeatDirection="Horizontal" ForeColor="#0099FF" CssClass="CssClass=&quot;table table-bordered table-hover dataTable&quot;" 
                                 >
                             </asp:CheckBoxList>
                         </td>
                     </tr>
                  </asp:Panel>
         </div>


               </div>

                <div class="panel-footer">

                    <asp:Button ID="BtnSubmit" runat="server" Font-Size="Small" Text="Submit" 
                         ValidationGroup="News" CssClass="btn btn-primary" />
                     
                   <asp:Button ID="BtnReset" runat="server" Font-Size="Small" Text="Reset"  CssClass="btn btn-danger" />

               </div>


             </div>
</ContentTemplate> 
</asp:UpdatePanel> 
    </form>
</body>
</html>
