<%@ Page Language="VB" AutoEventWireup="false"   CodeFile="Mandate.aspx.vb" Inherits="Mandate" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
   <head id="Head1" runat="server">
    <title>View Mandate Page</title>
        <link href="../style.css" rel="stylesheet" type="text/css" />

       <style type="text/css">
           .style2
           {
               height: 10px;
           }
       </style>

</head>
<body>
    <form id="Mandate" runat="server">

  <div class="post boxed">
			<h2 class="title">
                Customer Mandate
                <asp:Label ID="cust" runat="server"></asp:Label>
&nbsp;<asp:Label ID="lbl_AcctNo" runat="server"></asp:Label>
            </h2>
			<div class="story">

     <table style="width: 392px">
        <tr>
            <td style="height: 25px; text-align: left;">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:Label ID="lbl_customerid" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; color: #FF3300; font-size: medium;" class="style2">
                :<asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="#000066" 
                    Text="CUSTOMER NAME:"></asp:Label>
&nbsp;&nbsp;
                <asp:Label ID="lbl_Customer" runat="server" Font-Size="Large" 
                    ForeColor="#000066"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="height: 25px; text-align: left">&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 590px">
 <div style="overflow-y: scroll; height: 200px">
                         <telerik:RadGrid ID="RadGrid1" runat="server" Width="599px" GridLines="None">
<HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>

<MasterTableView>
<CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>

<RowIndicatorColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn>
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>
    <Columns>
        <telerik:GridBinaryImageColumn DataField="customerImage" ImageHeight="" 
            ImageWidth="" UniqueName="column1">
        </telerik:GridBinaryImageColumn>
        <telerik:GridBinaryImageColumn DataField="signatureImage" ImageHeight="" 
            ImageWidth="" UniqueName="column">
        </telerik:GridBinaryImageColumn>
    </Columns>
</MasterTableView>
                         </telerik:RadGrid>
 
           </div> 
            </td>
        </tr>
    </table>
                     
    </div>
    </div> 
    </form>
</body>
</html>
