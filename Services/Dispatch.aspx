<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Dispatch.aspx.vb" Inherits="Services_Dispatch" %>
<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="EditDispatch.ascx" tagname="editdispatch" tagprefix="uc2" %>
<%@ Register src="AddDispatch.ascx" tagname="adddispatch" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Master.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager runat="server" />

    <asp:ScriptManager ID="ScriptManager1" runat="server">
              </asp:ScriptManager>
   <div class="post boxed" align="left" style="height: 894px">
			<h2 class="title">Dispatch</h2>
            <div class="story">
            <telerik:RadTabStrip runat="server" ID="RadTabStrip1"
                SelectedIndex="0" MultiPageID="RadMultiPage1">
                <Tabs>
                    <telerik:RadTab Text="Edit" Selected="True">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Add">
                    </telerik:RadTab>
                    
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" Height="1000px"
                Width="396px" CssClass="multiPage">
                <telerik:RadPageView runat="server" ID="RadPageView1" 
                    CssClass="corporatePageView">
                   
                   
                
                   
                    <uc2:EditDispatch ID="EditDispatch" runat="server" />
                   
                   
                
                   
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="RadPageView2" 
                    CssClass="productsPageView">
                   
                 
                
                 
                   
                 
                
                    <uc1:AddDispatch ID="AddDispatch" runat="server" />
                   
                 
                
                 
                   
                 
                
                </telerik:RadPageView>
                
                <telerik:RadPageView ID="RadPageView3" runat="server">
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageView4" runat="server">
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageView5" runat="server">
                </telerik:RadPageView>
                
            </telerik:RadMultiPage>
                <br />
                <br />
                <br />
    </div>
    </div>
    </form>
</body>
</html>
