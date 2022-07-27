<%@ Page Language="VB" AutoEventWireup="false"   CodeFile="Auth.aspx.vb" Inherits="Authorise_Auth" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Authorise Page</title>
    <link href="../style.css" rel="stylesheet" type="text/css" />

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
<body>
    <form id="form1" runat="server">

          <div class="box box-info">
              <div class="box-body">
                   <div class="box-header">
                  <h3 class="box-title">Unauthorized Transaction</h3>
                </div>
                  <div class="col-mid-10">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"
                            GridLines="Vertical" Width="100%" Font-Size="Medium">
                            <FooterStyle BackColor="#CCCC99" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="AuthoriseDetail" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="authdesc" HeaderText="Auth Desc." SortExpression="authdesc" />
                                <asp:BoundField DataField="Post_User" HeaderText="Posted By" SortExpression="Post_User" />
                                <asp:BoundField DataField="Createdate" DataFormatString="{0: dd/MM/yy hh:mm:ss}"
                                    HeaderText="Posting Date" HtmlEncode="False" SortExpression="Createdate" />
                                <asp:BoundField DataField="latestupdate" DataFormatString="{0: dd/MM/yy hh:mm:ss}"
                                    HeaderText="Remider Date" SortExpression="latestupdate" />
                                <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="AuthDetail.aspx?AuthID={0}"
                                    Text="View Detail" />
                                <asp:TemplateField Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="LabelAuthDetail" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle BackColor="#F7F7DE" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                  </div>
    </div>
  
                <div class="box-body">
        
                    </div>
       <div class="box-footer">
               
                    
               
                        <asp:Button ID="BtnReturn" runat="server" Text="Return" CssClass="btn bg-orange btn-flat margin" Visible="False" />
                    
        </div>
        </div>
    </form>
</body>
</html>
