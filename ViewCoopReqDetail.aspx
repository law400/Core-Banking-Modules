<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ViewCoopReqDetail.aspx.vb" Inherits="ViewCoopReqDetail" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

     <title>View Details</title>
<link href="css/bootstrap.css" rel='stylesheet' type='text/css' />
    <style>
    .divModalBackground

{

filter: alpha(opacity=50); -moz-opacity:0.5; opacity: 0.5;

width:100%;

height:100%;
background-color: #CCCCFF;

position: absolute;

top: 0px; 

left: 0px;

z-index: 800;


}
    .centerBlock {
    position: fixed;
    top: 50%;
    left: 50%;
    width: 50%;
    height: 200px;
    margin: -100px 0 0 -1%;
}
    .field {
        width : 100%;
        height: 5%;
        color: #606060;
        padding: 2%;
        margin: 2% 0;
    }
     
 #dvLoading
{
   background:#000 url(./images/loading.gif) no-repeat center center;
   height: 100px;
   width: 100px;
   position: fixed;
   z-index: 1000;
   left: 50%;
   top: 50%;
   margin: -25px 0 0 -25px;

}

        .auto-style3 {
            height: 35px;
        }
        .auto-style5 {
            height: 49px;
        }
        .auto-style6 {
            height: 47px;
        }

    </style>
   <script  type="text/javascript" >
         function calendarPicker(strTxtRef) {
             window.open('./Controls/Calendar.aspx?field=' + strTxtRef + '', 'calendarPopup', 'titlebar=no,left=50,top=100,width=300,height=250,resizable=no');
         }

         //$(document).ready(function () {
         //    $('body').append('<div id="loading"><img src="./images/loading.gif" /></div>');
         //});
         //$(window).load(function () {
         //    $('#loading').fadeOut(600, function () {
         //        $("#wrap").fadeIn(1000);
         //        $("#footer").fadeIn(1000);
         //    });
         //});

         $(window).load(function () {
             $('#dvLoading').fadeOut(2000);
         });
       
        <%-- function init() 

{ 

var objdiv=document.getElementById('<%=Panel5.ClientID%>') 

if(objdiv) 

{

objdiv.style.visibility = 'hidden'; 

} 

} 

  

init(); --%>


         function ShowProgressBar() {
             if (Page_ClientValidate())
             document.getElementById('dvProgressBar').style.visibility = 'visible';
         }

         function HideProgressBar() {
             document.getElementById('dvProgressBar').style.visibility = "hidden";
         }
    </script>
 </head>
   
    <body>
        <form id="form1" runat="server">
       
   
   
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
                </Scripts>
            </telerik:RadScriptManager>

    <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
 <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
            AssociatedUpdatePanelID="updatePanel">
        <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #D7D7FF; opacity: 0.5;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
    </ProgressTemplate>
        </asp:UpdateProgress>
    <div class="panel panel-widget">
      

		<div class="panel-body">
		
     <%-- <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" BackgroundPosition="Top" Transparency="1" IsSticky="True">
        </telerik:RadAjaxLoadingPanel>--%>
<%--           <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">     --%>
          <!-- SELECT2 EXAMPLE -->

     <asp:Panel ID="Panel3" runat="server" Height="100%" Width="100%">
    <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;&nbsp;&nbsp;<br />
        <div align="center" style="background-color: #E6F2FF">
        </div>
    </div>
          
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <div class="alert alert-success alert-dismissable">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button><h4><i class="icon fa fa-check"></i>Alert!</h4><asp:Label ID="Label_success" runat="server" Text=""></asp:Label></div>

        </asp:Panel>
         <asp:Panel ID="Panel2" runat="server" Visible="false">
             <div class="alert alert-danger alert-dismissable">
                 <button aria-hidden="true" class="close" data-dismiss="alert" type="button">×</button>
                 <h4><i class="icon fa fa-ban"></i>Alert!</h4>
                 <asp:Label ID="Label_error" runat="server" Text=""></asp:Label>

             </div>

         </asp:Panel>
         <asp:Panel ID="Panel6" runat="server" Height="100%" Visible="true" 
            Width="100%" >
          <div class="panel panel-default">      
                                
                                
                   <div class="panel-footer">
                   
                                <div class="form-group"> 
                                    <asp:Label ID="LblID" runat="server" Text=" " Visible="true"></asp:Label>

                                </div>
                                <br />




                                <asp:Button ID="ButAccept" runat="server" BackColor="#009933" class="btn btn-primary" Font-Bold="True" ForeColor="White" Text="Approve"   />
                                <asp:Button ID="ButCancel" runat="server" Text="Reject" class="btn btn-danger"  Font-Bold="True" ForeColor="White"  />
                                <asp:Label ID="lbl_id" runat="server" Text="Label" Visible="False"></asp:Label>
                                &nbsp;&nbsp;
                                <asp:Label ID="lbl_id0" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#FF3300" Text="Please kinldy hold on, record processing" Visible="False"></asp:Label>
                          

                        </div>

                 
                               
                                
         
              <div class="panel-body">  
                  <div class="form-group">
                                <asp:TextBox ID="TxtReason" runat="server" Height="79px" placeholder="Add reason why you reject request " TextMode="MultiLine" Visible="False" Width="100%" BorderColor="#FF3300"></asp:TextBox>
                                </div>    
   <table >
               
                 <tr>
                    <td >  Coop ID:</td>
                    <td >&nbsp;</td>
                     <td >
                         <asp:Label ID="LblCoopID" runat="server" Font-Bold="True"></asp:Label>
                     </td>
                     <td >&nbsp;</td>
                </tr>
                 <tr>
                     <td >Name of Cooperative:</td>
                     <td >&nbsp;</td>
                     <td >
                         <asp:Label ID="LblCoopName" runat="server" Font-Bold="True"></asp:Label>
                     </td>
                     <td>&nbsp;</td>
                 </tr>
                    <tr>
                     <td >Cooperative Email:</td>
                     <td >&nbsp;</td>
                     <td >
                         <asp:Label ID="LblEmail" runat="server" Font-Bold="True"></asp:Label>
                     </td>
                     <td >&nbsp;</td>
                 </tr>
                     <tr>
                     <td >Cooperative Phone:</td>
                     <td >&nbsp;</td>
                     <td >
                         <asp:Label ID="LblPhone" runat="server" Font-Bold="True"></asp:Label>
                     </td>
                     <td >&nbsp;</td>
                 </tr>
                 <tr>
                     <td >Cooperative Contact Person:</td>
                     <td >&nbsp;</td>
                     <td>
                         <asp:Label ID="LblContactPerson" runat="server" Font-Bold="True"></asp:Label>
                     </td>
                     <td >&nbsp;</td>
                 </tr>
                 <tr>
                     <td >Cooperative Contact Person Designation:</td>
                     <td >&nbsp;</td>
                     <td >
                         <asp:Label ID="LblContactDesig" runat="server" Font-Bold="True"></asp:Label>
                     </td>
                     <td >&nbsp;</td>
                 </tr>
          <tr>
                     <td >
                         Cooperative Address:</td>
                     <td >&nbsp;</td>
                     <td >
                         <asp:Label ID="LblCoopAddress" runat="server" Font-Bold="True"></asp:Label>
                     </td>
                     <td >&nbsp;</td>
                     <td>&nbsp;</td>
                 </tr>
                 <tr>
                     <td >State</td>
                     <td >&nbsp;</td>
                     <td >
                        <asp:DropDownList ID="DrpState" runat="server" AutoPostBack="True" class="form-control input-lg" Width="300px" Enabled="false" >
                        </asp:DropDownList>
                     </td>
                     <td >&nbsp;</td>
                 </tr>
                 
                 <tr>
                     <td class="auto-style3" >Number of Members</td>
                     <td class="auto-style3" ></td>
                     <td class="auto-style3" >
                       <asp:Label ID="Lbl_NoOfMembers" runat="server" Font-Bold="True"></asp:Label>
                     </td>
                     <td class="auto-style3" ></td>
                 </tr>
                 <tr>
                     <td class="auto-style5">Amount to be Paid</td>
                     <td class="auto-style5" ></td>
                     <td class="auto-style5" >
                       <asp:Label ID="Lbl_AmountPaid" runat="server" Font-Bold="True"></asp:Label>
                       <asp:Label ID="LblTransactionID" runat="server" Font-Bold="True" Visible ="false" ></asp:Label>

                     </td>
                     <td class="auto-style5" ></td>
                 </tr>
                
                 
        <tr>
                     <td></td>
                     <td></td>
                     <td>
                          <asp:RadioButtonList ID="RadioButPartial" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" Width="225px">
                             <asp:ListItem Selected="True">Default</asp:ListItem>
                             <asp:ListItem>Discount</asp:ListItem>
                             <asp:ListItem>Partial</asp:ListItem>
                         </asp:RadioButtonList>
                     </td>
                     <td></td>
                 </tr>

       <tr runat ="server"  id="Discount_Section" visible ="false" >
                     <td>Discount (%)</td>
                     <td></td>
                     <td>
                          <telerik:RadNumericTextBox ID="txtdiscount" CssClass="form-control"   Width="100%" Runat="server" AutoPostBack="True" EmptyMessage="0">
                              <NumberFormat DecimalDigits="2" GroupSeparator="" KeepNotRoundedValue="false"   />
                      </telerik:RadNumericTextBox>
                     </td>
                     <td></td>
                 </tr>
       <tr runat="server" id="Partial_Section" visible ="false" >
                     <td>Apply Partial Payment?</td>
                     <td></td>
                     <td>
                         
                          <telerik:RadNumericTextBox ID="txtPartialPayment" CssClass="form-control"   Width="100%" Runat="server" AutoPostBack="True" EmptyMessage="0" Visible="False">
                              <NumberFormat DecimalDigits="2" GroupSeparator="" KeepNotRoundedValue="false"    />
                      </telerik:RadNumericTextBox>
                     </td>
                     <td></td>
                 </tr>
                 <tr>
                     <td class="auto-style6">Total Amount Payable</td>
                     <td class="auto-style6"></td>
                     <td class="auto-style6">
                         <asp:Label ID="Lbl_TotalAmount" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                         <asp:Label ID="Lbl_TotalAmount2" runat="server" Font-Bold="True" Visible="False" ForeColor="Red"></asp:Label>
                          <br />
                          <asp:Label ID="LblOutstanding0" runat="server" Font-Bold="True" Visible="False" ForeColor="Red">Outstanding: </asp:Label>
                         <asp:Label ID="LblOutstanding" runat="server" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                         <asp:Label ID="LblOutstandingWord" runat="server" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                     </td>
                     <td class="auto-style6"></td>
                 </tr>
                
             </table>        
                                                                                                                                                                                   </div>

                        </div>

                  

             

         </asp:Panel>
      
        
</asp:Panel>

<%--      </telerik:RadAjaxPanel>--%>
                </div>
                    
              </div>

        </ContentTemplate> 
    </asp:UpdatePanel>             
  
    
    </form>
</body>
</html>
