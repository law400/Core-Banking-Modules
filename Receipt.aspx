<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Receipt.aspx.vb" Inherits="Receipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Receipt</title>
    <link href="css/animate.css" rel="stylesheet" type="text/css" media="all"/>
    <link rel="shortcut icon" href="Homepage/_images/uploads/fav.png"/>
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

    <script type="text/javascript">
function printdiv(printpage)
{
var headstr = "<html><head></head><body>";
var footstr = "</body>";
var newstr = document.all.item(printpage).innerHTML;
var oldstr = document.body.innerHTML;
document.body.innerHTML = headstr+newstr+footstr;
window.print();
document.body.innerHTML = oldstr;
return false;
}
</script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="panel panel-default">
        <div class="text-center btn-invoice" runat="server" id="PrintReceipt2" visible ="false">
<%--                                    <button class="btn btn-primary btn-lg mr5"><i class="fa fa-dollar mr5"></i> Make A Payment</button>--%>
                                    <button class="btn btn-danger btn-lg" onclick="printdiv('Panel_Success');"><i class="fa fa-print mr5"></i>Please Kindly Print Your Receipt Here</button>
                                </div>
                            <div class="panel-body" runat="server" id="Panel_Success" visible ="False">
                                <div class="row">
                                    <div class="col-sm-6">
                                        
                                        <h5 class="lg-title mb10">&nbsp;&nbsp; From</h5>
                                        <img src="images/logo.png" class="img-responsive mb10" alt="" />
                                        <address>
                                            <strong>&nbsp;&nbsp; CWG PLC.</strong><br/>
                                            &nbsp;&nbsp;
                                            Block 54A Plot 10, Off Rufus Giwa Street<br/>
                                            &nbsp;&nbsp;
                                            Off Adebayo Doherty Road<br/>
                                            &nbsp;&nbsp;
                                            Off Admiralty Way, Lekki Phase 1, <br/>
                                            &nbsp;&nbsp;
                                            Lagos, Nigeria<br/>
                                            &nbsp;&nbsp;
                                            Copyright © 2019 UCP.<br/>
                                            <abbr title="Email">&nbsp;&nbsp; E:</abbr> UCP.Support@cwg-plc.com
                                        </address>
                                        
                                    </div><!-- col-sm-6 -->
                                    
                                    <div class="col-sm-6 text-right">
                                        <h5 class="subtitle mb10">Transaction #</h5>
                                        <h4 class="text-primary">#-<asp:Label ID="lblTransactionId" runat="server" Text=""></asp:Label></h4>
                                         <h4 class="text-primary">RRR-<asp:Label ID="lblrrr" runat="server" Text=""></asp:Label></h4>
                                        <h5 class="subtitle mb10">To</h5>
                                        <address>
                                            <strong><asp:Label ID="lblCoopName" runat="server" Text=""></asp:Label></strong><br/>
                                            
                                            <abbr title="Email">E:</abbr> <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label> <br />
                                            <abbr title="Phone">P:</abbr> <asp:Label ID="lblMobileNo" runat="server" Text=""></asp:Label>
                                        </address>
                                        
<%--                                        <p><strong>Invoic Date:</strong> January 20, 2014</p>--%>
                                        <p><strong>Payment Date:</strong> <asp:Label ID="lbldate" runat="server" Text=""></asp:Label></p>
                                        <p><strong>Next Subscription Payment Due:</strong> <asp:Label ID="lblnextDate" runat="server" Text=""></asp:Label></p>
                                    </div>
                                </div><!-- row -->
                                
                                <div class="table-responsive">
                                <table class="table table-bordered table-dark table-invoice">
                                <thead>
                                  <tr>
                                    <th style="width: 40%">Description</th>
                                    <th style="width: 30%">Number of Member(s)</th>
                                    <th style="width: 15%">Duration</th>
                                    <th style="width: 15%">Amount</th>
                                  </tr>
                                </thead>
                                <tbody>
                                  <tr>
                                    <td>
                                        
                                        <p>Payment for UCP Subscription.</p>
                                    </td>
                                    <td><asp:Label ID="Lbl_MemberStrength" runat="server" Text=""></asp:Label></td>
                                    <td>1 Year</td>
                                    <td>?<asp:Label ID="LblAmount" runat="server" Text=""></asp:Label></td>
                                  </tr>
                                  
                                  
                                 <%-- <tr>
                                    <td>
                                        <h5><a href="">Wordpress Theme Development</a></h5>
                                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam</p>
                                    </td>
                                    <td>1</td>
                                    <td>$230.00</td>
                                    <td>$230.00</td>
                                  </tr>--%>
                                </tbody>
                              </table>
                              </div><!-- table-responsive -->
                              
                                <table class="table table-total">
                                    <tbody>
                                        <tr>
                                            <td>Sub Total:</td>
                                            <td>?<asp:Label ID="lblsubamount" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Convenience Fee:</td>
                                            <td>?<asp:Label ID="lblcharge" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>TOTAL PAID:</td>
                                            <td>?<asp:Label ID="lblTotalamount" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                    </tbody>
                                </table>
                                
                                
                                
                                <div class="mb30"></div>
                                
                                
                                
                                
                            </div><!-- panel-body -->
                       
         <div class="panel-body" runat="server" id="Panel_Failed" visible ="false" >
             <h3 class="subtitle mb10">Transaction Failed for Transaction #: <asp:Label ID="lblTransactionID2" runat="server" Text=""></asp:Label> </h3>
             </div>
        <div class="text-right btn-invoice" runat="server" id="PrintReceipt" visible ="false">
<%--                                    <button class="btn btn-primary btn-lg mr5"><i class="fa fa-dollar mr5"></i> Make A Payment</button>--%>
                                    <button class="btn btn-primary btn-lg" onclick="printdiv('Panel_Success');"><i class="fa fa-print mr5"></i> Print Receipt</button>
                                </div>
        <div class="well nomargin">
                                    Thank you for using the online payment. Please click <strong><a href="http://ucp.cooplatform.com.ng/"> here</a></strong> to return to home page.
                                </div>
         </div><!-- panel -->  
    </form>
</body>
</html>
