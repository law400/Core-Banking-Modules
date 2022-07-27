<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="CustomerBalance.aspx.vb" Inherits="CustomerService_CustomerBalance" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <script src="template/js/jquery-1.11.1.min.js"></script>

    <script type="text/javascript">
 function toggleDivState(divName)
 {
  var ctl=window.document.getElementById(divName);
  if (ctl.style.display == "none")
   ctl.style.display = "";
  else
   ctl.style.display = "none";
  }
</script>
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

     <div class="panel panel-default">
          <h4 style="color: #FF9900">
                                           &nbsp;&nbsp;&nbsp;
                                           Enter a CustomerId or AccountNumber to search for Customer Account Detail</h4>
                <div class="panel-heading">
                 <%-- <h3 class="box-title"> MEMBERS&#39; BALANCE</h3>--%>
                </div>
                <div class="panel-body">
                   
                      

                         <div class="col-md-8">

                               <%-- <div class="form-group">--%>


                                    <%--</div>--%>

                             <div class="form-group">
                                 <label>Account Number(s)&nbsp; / CustomerID</label>
                                 <asp:TextBox ID="txtAccountno" runat="server" AutoPostBack="True" placeholder="Account Number" width="100%" CssClass="form-control"></asp:TextBox>
                                    <asp:HyperLink ID="hypAccount" runat="server" Height="23px" 
                                        ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink>
                                    <span class="auto-style1"><strong>Search Account</strong></span>
                                    <asp:CheckBox ID="chkEnableMultiple" runat="server" AutoPostBack="True" 
                                        Text="Multiple Account Number" />
                                    &nbsp;&nbsp;
                                    <asp:CheckBox ID="chkEnableMultiple0" runat="server" AutoPostBack="True" 
                                        Text="Search By CustomerID" /> <br />
                                  <asp:Label ID="Label1" runat="server" 
                                        Text="Please Ensure that you place a comma (,) after every account number." 
                                        Visible="False" style="color: #000000; font-weight: 700"></asp:Label>
                             </div>
                             </div>
                       

                        </div>
                    </div>
             <div class="panel-footer">
                 
                             <asp:Button ID="btnsearch" runat="server"  Text="Search" CssClass="btn bg-purple btn-flat margin" OnClientClick="DisplayLoadingDiv()"/>
                   
                                    <asp:Button ID="btnreset0" runat="server" Text="Reset" CssClass="btn bg-maroon btn-flat margin" OnClientClick="DisplayLoadingDiv()"/>
                    
                    </div>
                        <div class="form-group">
                                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="100%">
                            <asp:GridView ID="GridMain1" runat="server" BorderWidth="0" 
        DataKeyNames="accountnumber" ShowHeader="false" AutoGenerateColumns="false" 
        Width="671px" CssClass="table table-bordered table-hover dataTable"  >
    <Columns >
    <asp:TemplateField>
    <ItemTemplate>
    <a href ="javascript:toggleDivState('acctno<%# Eval("accountnumber") %>');"><%#Eval("accountnumber")%> -Click View Detail
    </a> - <%#Eval("accounttitle")%>  <%#Eval("proddesc")%><br />
     <a href="../Reports/Postingjournal.aspx?custdetail=<%#Eval("accountnumber")%>"> Available Balance:<%#Eval("usebal")%>-Click View History</a> 
    <div class="lret" id="acctno<%# Eval("accountnumber") %>">
          <asp:Image ID="Image1" runat="server" ImageUrl='<%# "Handler.ashx?id=" + cType(Eval("serial"),String) + "&id2=" + Eval("accountnumber") %>' /> 
          <asp:Image ID="Image2" runat="server" ImageUrl='<%# "Handler2.ashx?id=" + cType(Eval("serial"),String) + "&id2=" + Eval("accountnumber")  %>' /> 
                                           
<br />
Address: <%#Eval("address")%><br />Phone No: <%#Eval("phone")%><br />Account Officer: <%#Eval("source")%><br /><br />Ledger Balance=<%#Eval("bkbal")%><br />Available Balance=<%#Eval("usebal")%><br />Pending Charges=<%#Eval("pendingc")%><br />Clearing Balance=<%#Eval("clearingbal")%><br />OD Limit=<%#Eval("odlimit")%><br />Lien Amount=<%#Eval("amountheld")%><br /><br /></div>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
                                    </asp:Panel> 
                        </div>
            
            <div class="form-group">  



 </div>

 </div>  
      
    </ContentTemplate> 
    </asp:UpdatePanel> 
</asp:Content>



