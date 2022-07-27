<%@ Page Language="VB" AutoEventWireup="false"   CodeFile="CustEnquiry.aspx.vb" Inherits="CustEnquiry" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
   <head id="Head1" runat="server">
    <title>Customer Enquiry Page</title>

       <style type="text/css">
           .style1
           {
               height: 21px;
           }
           .style2
           {
               height: 10px;
           }
       </style>

        <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="initial-scale=1.0, width=device-width"/>
     <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>
    <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="../bootstrap/css/bootstrap.min.css"/>
    <!-- Font Awesome -->
   
    <!-- Theme style -->
     <link rel="stylesheet" href="../dist/font-awesome.min.css"/>
    <!-- Ionicons -->
    <link rel="stylesheet" href="../dist/ionicons.min.css"/>
    <link rel="stylesheet" href="../dist/css/AdminLTE.min.css"/>
    <!-- AdminLTE Skins. Choose a skin from the css/skins
         folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="../dist/css/skins/_all-skins.min.css"/>
      <link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
       <script type="text/javascript">
           function DisplayLoadingDiv() {


               document.getElementById("loading").style.display = ''; //displays the div



               /*Inside this div place a loading.gif image*/

           }

           function HideLoadingDiv() {

               document.getElementById("loading").style.display = 'none';

               //Hide the div

           }


       </script>


</head>
<body onload='HideLoadingDiv()'>
    <form id="CustEnquiry" runat="server">
         <div id="loading" style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #D7D7FF; opacity:0.5 ">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
  <%--<div class="post boxed">--%>
			<%--<h2 class="style3">
                Account Enquiry</h2>--%>
		
            <div class="box box-info">
                <div class="box-header">
                  <h3 class="box-title"> ACCOUNT ENQUIRY</h3>
                </div>
                <div class="box-body">
                <div class="form-group" >
        <tr>
            <td style="text-align: left;" class="style2">
                MAXIMUM 50 CUSTOMERS IN LIST</td>
        </tr>
        </div>
                 <div class="form-group" >
                <tr>
                    <td class="style3" colspan="3" style="text-align: left">
                        <asp:Label ID="Label1" runat="server" ForeColor="Red" style="font-weight: 700; font-size: x-small;" 
                            
                            
                            Text="Note: Enter Any Short Form Of the Customer, Then Click Search To Find. Check the Box in Front Of the Name and Click Return to Go Back."></asp:Label>
                    </td>
                </tr>
                </div>
                <div class="form-group" >
                <tr>
                    <td class="style1" colspan="2" style="text-align: left">
                        &nbsp;Customer Name</td>
                    <td style="width: 300px; text-align: left; height: 1px;">
                <asp:TextBox ID="txtAccountName" runat="server" Width="255px" Font-Size="Small"></asp:TextBox></td>
                </tr>
                </div>
                
                &nbsp;
        <div class="box-footer">
        <tr>
                    <td style="width: 1px; height: 1px; text-align: left">
                    </td>
                    <td style="text-align: left; width: 83px;" class="style1">
                        </td>
                    <td style="width: 300px; height: 1px; text-align: left">
                        <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn bg-purple btn-flat margin" OnClientClick="DisplayLoadingDiv()" />
                        <asp:Button ID="Button2" runat="server" Text="Return" CssClass="btn bg-orange btn-flat margin" />
                    </td>
                </tr>
        <tr>
            <td style="width: 650px"><div style="overflow-y: scroll; height: 300px">
                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    Font-Size="Small" Height="74px" Visible="False" Width="565px">
                    <Columns>
                    
                                           <asp:BoundField DataField="CustomerID" HeaderText="CustomerID">
                            <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                               <ItemStyle Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="accountnumber" HeaderText="Account #">
                            <HeaderStyle HorizontalAlign="Left" Width="80px" />
                            <ItemStyle Width="40px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Fullname" HeaderText="Customer Name">
                            <HeaderStyle HorizontalAlign="Left" Width="40px" />
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Address" HeaderText="Address">
                            <HeaderStyle HorizontalAlign="Left" Width="200px" />
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                                           <asp:BoundField DataField="Officercode" HeaderText="Officer Code" />
                        <asp:TemplateField HeaderText="SELECT">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="Searchid" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="Searchid" runat="server" />
                            </EditItemTemplate>
                            <ItemStyle Width="10px" />
                        </asp:TemplateField>
                        <asp:TemplateField Visible="False">
                                       <ItemTemplate>
                        <asp:Label  runat="server" ID="Customerid" Text='<%#Eval("Customerid") %>' />
                                       </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
 
           </div> 
                &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp;
                &nbsp;&nbsp;
            </td>
        </tr>
        </div>
 </div>
         
    </div>
  
    </form>
</body>
</html>
