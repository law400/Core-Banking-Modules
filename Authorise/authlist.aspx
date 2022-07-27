<%@ Page Language="VB" AutoEventWireup="false" CodeFile="authlist.aspx.vb" Inherits="Authorise_authlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Charge Detail Page</title>
    <link href="../Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="sidebar">
            <ul>
                <li id="search">
                    <h2>
                        batch detail&nbsp;</h2>
                    
                 <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" Font-Size="XX-Small" 
                        Height="59px" PageSize="3" 
                                        Width="339px">
                                        <Columns>
                                            <asp:BoundField DataField="accountnumber" HeaderText="AccountNumber" />
                                            <asp:BoundField DataField="Valuedate" DataFormatString="{0:dd/MM/yyyy}" 
                                                HeaderText="Value Date" HtmlEncode="False">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Narration" HeaderText="Narration" 
                                                HtmlEncode="False">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Amount" DataFormatString="{0:n}" 
                                                HeaderText="Amount" HtmlEncode="False" >
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                        <RowStyle BackColor="White" Font-Size="8pt" ForeColor="#003399" />
                                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    </asp:GridView>
                            <br />
                            <asp:Button ID="BtnReturn" runat="server" Text="Return" Width="59px" />
                </li>
                <li></li>
            </ul>
        </div>
    
    </div>
    </form>
</body>
</html>
