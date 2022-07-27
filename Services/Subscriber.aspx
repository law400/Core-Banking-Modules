<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Subscriber.aspx.vb" Inherits="Services_Subscriber" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
       <title></title>
   
    <script type="text/javascript">
        function onRequestStart(sender, args) {
            if (args.get_eventTarget().indexOf("ExportToPdfButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToCsvButton") >= 0) {

                args.set_enableAjax(false);
            }
        }
        </script>
    <style type="text/css">
                    
.RadComboBox *
{
	margin: 0;
	padding: 0;
}

        .style3
        {
            width: 100%;
        }
        .style4
        {
            width: 158px;
        }

    </style>
       <link href="../Master.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form2" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
     <div class="post boxed" align="left" style="height: 894px">
			<h2 class="title">Subscriber</h2>
            <div class="story">

    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AlertZ %>" 
        SelectCommand="proc_selSubscriberlist" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
        <br />
        <table class="style3">
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td>
                    <table class="style7">
        <tr>
            <td>


                Subscriber List<br />
                  </td>
        </tr>
        <tr>
            <td>
                 <div class="module" style="height: 58px; width: 101%">
            <asp:CheckBox ID="CheckBox1" Text="Export only data" runat="server"></asp:CheckBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="CheckBox2" Text="Ignore paging (exports all pages)" runat="server">
            </asp:CheckBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="CheckBox3" Text="Open exported data in new browser window" runat="server">
            </asp:CheckBox>
            <br />
            <asp:Button ID="Button1" CssClass="button" Width="150px" Text="Export to Excel" runat="server">
            </asp:Button>
            <asp:Button ID="Button2" CssClass="button" Width="150px" Text="Export to Word" runat="server">
            </asp:Button>
            <asp:Button ID="Button3" CssClass="button" Width="150px" Text="Export to CSV" runat="server">
            </asp:Button>
                     <br />
            <asp:Button ID="Button4" CssClass="button" Width="150px" Text="Add New Subscriber" 
                         runat="server">
            </asp:Button>
        </div>
</td>
        </tr>
    </table>
     <script type="text/javascript">
         function onRequestStart(sender, args) {
             if (args.get_eventTarget().indexOf("ExportToPdfButton") >= 0 ||
                    args.get_eventTarget().indexOf("ExportToCsvButton") >= 0) {

                 args.set_enableAjax(false);
             }
         }
        </script>

    &nbsp;<br />

 </div>
                <telerik:RadGrid AutoGenerateColumns="False" ID="RadGrid1"
            AllowFilteringByColumn="True" AllowSorting="True" PageSize="20"
            ShowFooter="True" AllowPaging="True" runat="server" GridLines="None"
            EnableLinqExpressions="False" Font-Size="XX-Small" 
        DataSourceID="SqlDataSource1" Skin="Default" Width="792px">
            <PagerStyle Mode="NextPrevAndNumeric" />
             <GroupingSettings CaseSensitive="false" />
            <MasterTableView AutoGenerateColumns="false" CommandItemDisplay="Top" 
                    EditMode="InPlace" AllowFilteringByColumn="True" Font-Size="XX-Small"
                ShowFooter="True" TableLayout="Auto" DataKeyNames="Subscriber_Key" 
                        DataSourceID="SqlDataSource1">
           
                     <Columns>
                          <telerik:GridHyperLinkColumn DataTextField="Subscriber_key" HeaderText="SUBSCRIBER KEY"  
                             DataNavigateUrlFormatString ="Subscriberdetail.aspx?id={0}" 
                             DataNavigateUrlFields="Subscriber_key"> 
                         </telerik:GridHyperLinkColumn>
                         <telerik:GridBoundColumn DataField="Acct_No" DefaultInsertValue="" 
                             HeaderText="ACCOUNT NO" SortExpression="Acct_No" UniqueName="Acct_No">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="Account_Title" DefaultInsertValue="" 
                             HeaderText="ACCOUNT TITLE" SortExpression="Account_Title" 
                             UniqueName="Account_Title">
                         </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="Acct_Type" DefaultInsertValue="" 
                             HeaderText="ACCOUNT TYPE" SortExpression="Acct_Type" UniqueName="Acct_Type">
                         </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="service_Type" DefaultInsertValue="" 
                             HeaderText="SERVICE TYPE" SortExpression="service_Type" UniqueName="service_Type">
                         </telerik:GridBoundColumn>
                        
                        </Columns>
           
                     <CommandItemTemplate>
                     <br />
<asp:Label ID="lblDisplay" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" />
   <br />
                </CommandItemTemplate>

                
            </MasterTableView>
            <ClientSettings>
                <Scrolling AllowScroll="false" />
            </ClientSettings>
        </telerik:RadGrid></td>
            </tr>
        </table>
        </div> 
 </form>
</body>
</html>
