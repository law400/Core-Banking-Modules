<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Service.aspx.vb" Inherits="Services_Service" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="Addservice.ascx" tagname="Addservice" tagprefix="uc1" %>
<%@ Register src="EditService.ascx" tagname="EditService" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
  <link href="../Master.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .title
        {
            height: 41px;
        }
    </style>
  

</head>
<body>
    <form id="form1" runat="server">
     <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
              </asp:ScriptManager>
               
     <div class="post boxed" align="left" style="height: 894px">
			<h2 class="title">Services</h2>
            <div class="story">
            <br />
        <div class="exampleWrapper">
            <telerik:RadTabStrip runat="server" ID="RadTabStrip1"
                SelectedIndex="0" MultiPageID="RadMultiPage1">
                <Tabs>
                    <telerik:RadTab Text="Edit" Selected="True">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Add">
                    </telerik:RadTab>
                    
                </Tabs>
            </telerik:RadTabStrip>
             <asp:UpdatePanel id="updatePanel1" runat="server">
<ContentTemplate>
            <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" Height="1000px"
                Width="396px" CssClass="multiPage">
                <telerik:RadPageView runat="server" ID="RadPageView1" CssClass="corporatePageView">
                   
                   
                
                   
                    <uc2:EditService ID="EditService1" runat="server" />
                   
                   
                
                   
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="RadPageView2" CssClass="productsPageView">
                   
                 
                
                 
                   
                 
                
                    <uc1:Addservice ID="Addservice1" runat="server" />
                   
                 
                
                 
                   
                 
                
                </telerik:RadPageView>
                
            </telerik:RadMultiPage>
              </ContentTemplate>
                  </asp:UpdatePanel>
      
    </div>
    </div>
    </div>
    </form>
</body>
</html>
