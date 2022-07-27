<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master"    AutoEventWireup="false"   CodeFile="ManageCustomer.aspx.vb" Inherits="CustomerService_ManageCustomer" title="ManageCustomer Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <script src="template/js/jquery-1.11.1.min.js"></script>

    <asp:UpdatePanel id="updatePanel" runat="server">
<ContentTemplate>
 <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
            AssociatedUpdatePanelID="updatePanel">
        <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #D7D7FF; opacity: 0.7;">
            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." style="padding: 10px;position:fixed;top:45%;left:50%;" />
        </div>
    </ProgressTemplate>
        </asp:UpdateProgress>
       <div class="panel panel-default">

    <tr>
            <td style="width: 113px; height: 29px;" valign="top">
                Enter Customer/Member ID</td>
            <td colspan="2" style="height: 29px">
                <asp:HyperLink ID="Hypsearch" runat="server" ImageUrl="~/Images/iconbar_previewtab_on.gif">HyperLink</asp:HyperLink>
                <asp:TextBox ID="txtCustomerid" runat="server" AutoPostBack="True" 
                    Font-Size="Small" Width="100%" CssClass="form-control"></asp:TextBox>
                </td>
            <td style="width: 95px; height: 29px;">
            </td>
        </tr>                  
     <tr>
                                                        <td colspan="4" style="height: 27px">
                                                            <div class="box-blue">
                                                                <h2>
                                                                    <span style="color: #ffffff"><strong>Edit Customer</strong></span></h2>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                       
                                                        <td style="width: 136px; height: 19px">
                                                            <asp:DropDownList ID="DrpCustType" runat="server" AutoPostBack="True" 
                                                                Font-Size="Small" CssClass="form-control" Enabled="False" Visible="false">
                                                                <asp:ListItem Selected="True" Value="0">--Select Customer Type</asp:ListItem>
                                                                <asp:ListItem Value="1">Individual</asp:ListItem>
                                                                <asp:ListItem Value="2">Corporate</asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;
                                                            <td style="width: 149px; height: 19px"></td>
                                                            <td style="width: 100px; height: 19px"></td>
                                                        </td>
                                                    </tr>
    
                  </tr>
   
     </tr>
     </tr>
     </tr>
     </tr>
     </tr>
           </div>
     <asp:MultiView ID="MultiView1" runat="server">
 <asp:View ID="View1" runat="server">

      <div class="panel panel-default">
               <div class="panel-heading">
                                         
        
            </div>
                 <div class="panel-body">
       
  
    
               
                       <div class="col-md-4">
                            <!-- Title -->
                    <div class="form-group">
                      Title
                    
                        <asp:DropDownList ID="DrpTitle" runat="server" Font-Size="Small" AutoPostBack="True" placeholder="Title" CssClass="form-control">
                                                </asp:DropDownList>
                    
                    </div>
 
                   <div class="form-group">
                      Middle Name
                    
                         <asp:TextBox ID="txtOthername" runat="server" Font-Size="Small" placeholder="Middle Name" CssClass="form-control"></asp:TextBox>
                    
                    </div>

                           

                            <div class="form-group">
                                Nationality <span style="color: red"><strong>*</strong></span>
                    
                       <asp:DropDownList ID="DrpNational" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                     
                    </div>

                            

                             <div class="form-group">
                                 Resident State <span style="color: red"><strong>*</strong></span>
                    
                       <asp:DropDownList ID="DrpResState" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    
                    </div>

                            <div class="form-group">
                                Resident Address <span style="color: red"><strong>*</strong></span>
                     
                        <asp:TextBox ID="txtAddress" runat="server" Font-Size="Medium" Height="47px" 
                                                    TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    
                    </div>
                           <div class="form-group">
                               Mobile Phone1 <span style="color: red"><strong>*</strong></span>
                     
                        <asp:TextBox ID="txtphone1" runat="server" Font-Size="Small" Width="100%" placeholder="Mobile Phone" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                     
                    </div>

                             <div class="form-group">
                      Mobile Phone2
                     
                        <asp:TextBox ID="Txtphone2" runat="server" Font-Size="Small" Width="100%" placeholder="Mobile Phone" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                     
                    </div>

       
                           <div class="form-group">
                      Name Of Next Of Kin
                     
                        <asp:TextBox ID="txtnextofKin" runat="server" Font-Size="Small" Width="100%" placeholder="Name Of Next Of Kin" CssClass="form-control" > </asp:TextBox>
                    
                    </div>     
                              
                              
                           <div class="form-group">
                               ID No <span style="color: red"><strong>*</strong></span>
                     
                        <asp:TextBox ID="txtIdNo" runat="server" Font-Size="Small" Width="100%" placeholder="ID No" CssClass="form-control" > </asp:TextBox>
                    
                    </div>              

                                 
    <div class="form-group">
                      Referrer Name
                 
                        <asp:TextBox ID="txtrefname" runat="server" Font-Size="Small" Width="100%" placeholder="Referrer Name" CssClass="form-control"> </asp:TextBox>
                   
                    </div>
<div class="form-group">
<asp:CheckBox ID="ChkGroup" runat="server" AutoPostBack="True" 
                                                    Text="Is Customer a Member Of a Group?"/>
           <asp:DropDownList ID="DrpGroup" runat="server" AutoPostBack="True" CssClass="form-control"
                                                    Font-Size="Small" Visible="False">
                                                </asp:DropDownList>
                

    </div>


                           <div class="form-group">
                               <asp:DropDownList ID="DrpIntro" runat="server" AutoPostBack="True" CssClass="form-control" 
                                                    Font-Size="Small" Visible="False">
                                                    <asp:ListItem Selected="True" Value="0">--Select Introducer--</asp:ListItem>
                                                    <asp:ListItem Value="1">Staff</asp:ListItem>
                                                    <asp:ListItem Value="2">Customer</asp:ListItem>
                                                    <asp:ListItem Value="3">Others</asp:ListItem>
                                                </asp:DropDownList>
                    
                    
                    </div>

                             <div class="form-group">
                           <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                                                    Text="Is Customer Related to another Customer in the Bank?" Visible="False"  />
                                 <asp:Label ID="Label5" runat="server" Text="CustomerID" Visible="False"></asp:Label>
                                                <asp:TextBox ID="txtcustid" runat="server" AutoPostBack="True" CssClass="form-control" MaxLength="10" 
                                                    Visible="False"></asp:TextBox><asp:Label ID="Label6" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label><asp:DropDownList ID="DrpRela" runat="server" AutoPostBack="True" 
                                                    CssClass="form-control" Font-Size="Small" Visible="False">
                                                </asp:DropDownList>

                                 </div>
                       </div>  <!-- end col-md-6 -->
                     
                        <div class="col-md-4">
                            <div class="form-group">
                                Surname <span style="color: red"><strong>*</strong></span>
                    
                         <asp:TextBox ID="txtSurname" runat="server" Font-Size="Small"  placeholder="Surname" CssClass="form-control"></asp:TextBox>
                  
                    </div>

                            <div class="form-group">
                                Sex <span style="color: red"><strong>*</strong></span>
                     
                       <asp:DropDownList ID="DrpSex" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                   
                    </div>

                            <div class="form-group">
                                State Of Origin <span style="color: red"><strong>*</strong></span>
                     
                       <asp:DropDownList ID="DrpState" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    
                    </div>

                            <div class="form-group">
                                Resident City/Town <span style="color: red"><strong>*</strong></span>
                  
                       <asp:DropDownList ID="DrpTown" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                     
                    </div>

                            <div class="form-group">
                      Office Address
                   
                        <asp:TextBox ID="txtAddress0" runat="server" Font-Size="Medium" Height="47px" 
                                                    TextMode="MultiLine" Width="100%" CssClass="form-control"></asp:TextBox>
                   
                    </div>

                       
                            <div class="form-group">
                      Office Phone
                     
                        <asp:TextBox ID="txtphone3" runat="server" Font-Size="Small" Width="100%" placeholder="Office Phone" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                      
                    </div>

                            <div class="form-group">
                      Email Address
                    
                        <asp:TextBox ID="txtemail" runat="server" Font-Size="Small" Width="100%" placeholder="Email" CssClass="form-control"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                    ControlToValidate="txtemail" Display="Dynamic" 
                                                    ErrorMessage="enter email correctly" 
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                    Width="176px" SetFocusOnError="True">enter email correctly</asp:RegularExpressionValidator>
               
                    </div>

                                 <div class="form-group">
                      Next Of Kin Phone
                     
                        <asp:TextBox ID="Txtkinphone" runat="server" Font-Size="Small" Width="100%" placeholder="Next Of Kin Phone" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                    
                    </div>

                            
                             


                            <div class="form-group">
                                ID Issue Date <span style="color: red"><strong>*</strong></span> <asp:HyperLink ID="imgdate2" runat="server" ImageUrl="~/Images/pdate.gif" 
                                                    Width="17px">HyperLink</asp:HyperLink>
                     
                        <asp:TextBox ID="txtIssue" runat="server" Font-Size="Small" Width="100%" placeholder="ID Issue Date" CssClass="form-control"></asp:TextBox>
                                               
                                                <asp:CompareValidator ID="CompareValidator11" runat="server" 
                                                    ControlToValidate="txtIssue" Display="Dynamic" 
                                                    ErrorMessage="Date Format Incorrect" Operator="DataTypeCheck" Type="Date" 
                                                    ValidationGroup="News1" Width="147px" SetFocusOnError="True">Date Format Incorrect</asp:CompareValidator>
                     
                    </div>
                              
                            <div class="form-group">
                      Referrer Phone
               
                        <asp:TextBox ID="txtRefphone" runat="server" Font-Size="Small" Width="100%" placeholder="Referrer Name" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                   
                    </div>

                           
                            <div class="form-group">
                            <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" 
                                                    Text="Is Customer a Signatory to Another Account?" Visible="False"/>

                                <asp:Label ID="Label7" runat="server" Text="Account Number" Visible="False"></asp:Label>
                    
                         <asp:TextBox ID="txtsignacct" runat="server" Font-Size="Small"  placeholder="Account Number" CssClass="form-control" Visible="False"></asp:TextBox>
                                <asp:Label ID="Label8" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                                </div>
                             <div class="form-group">
                                 &nbsp;<asp:TextBox ID="txtIntroID" runat="server" Font-Size="Small"  placeholder="Introducer ID" CssClass="form-control" Visible="False"></asp:TextBox>
                         <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                    </div>

                        </div> <!-- end col-md-6 -->

                       <div class="col-md-4">
                          <div class="form-group">
                              Firstname <span style="color: red"><strong>*</strong></span>
                   
                        <asp:TextBox ID="txtFirstname" runat="server" Font-Size="Small" CssClass="form-control" placeholder="First Name"> </asp:TextBox>
                      </div>
                    
                             
                           <div class="form-group">
                               Date Of Birth <span style="color: red"><strong>*</strong></span> <asp:HyperLink ID="imgdate1" runat="server" ImageUrl="~/Images/pdate.gif" Width="17px">HyperLink</asp:HyperLink>
                     
                       <asp:TextBox ID="txtDOB" runat="server" Font-Size="Small" CssClass="form-control" placeholder="Date of birth"></asp:TextBox>
                   
                    </div>

                           

                           <div class="form-group">
                      Education Level
                      
                       <asp:DropDownList ID="DrpEdu" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    
                    </div>

                               <div class="form-group">
                      Business/Ocupation
                 
                       <asp:DropDownList ID="DrpOccupation" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                     
                    </div>

                               <div class="form-group">
                      Sector
               
                       <asp:DropDownList ID="Drpsector" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    
                    </div>
                           

                              

                            <div class="form-group">
                      Home Phone
                   
                        <asp:TextBox ID="Txtphone4" runat="server" Font-Size="Small" Width="100%" placeholder="Home Phone" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                      
                    </div>
                             <div class="form-group">
                      Next Of Kin Address
                   
                        <asp:TextBox ID="txtKinAddress" runat="server" Font-Size="Medium" Height="47px" 
                                                    TextMode="MultiLine" Width="100%" CssClass="form-control"></asp:TextBox>
                   
                    </div>

                           <div class="form-group">
                               ID Type <span style="color: red"><strong>*</strong></span>
                     
                       <asp:DropDownList ID="DrpIdType" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    
                    </div>

                           <div class="form-group">
                               ID Expiry Date <span style="color: red"><strong>*</strong></span>   <asp:HyperLink ID="imgdate3" runat="server" ImageUrl="~/Images/pdate.gif" 
                                                    Width="17px">HyperLink</asp:HyperLink>
                     
                       <asp:TextBox ID="txtExpirydate" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small" Width="100%" placeholder="ID Expiry Date" CssClass="form-control"> </asp:TextBox>
                                              
                                                <asp:CompareValidator ID="CompareValidator10" runat="server" 
                                                    ControlToValidate="txtExpirydate" Display="Dynamic" 
                                                    ErrorMessage="Date Format Incorrect" Operator="DataTypeCheck" Type="Date" 
                                                    ValidationGroup="News1" Width="147px" SetFocusOnError="True">Date Format Incorrect</asp:CompareValidator>
                     
                    </div>

<div class="form-group">
                 
                        <asp:TextBox ID="txtOfficer" runat="server" Font-Size="Small" Width="100%" placeholder="Account Officer" CssClass="form-control" Visible="False"></asp:TextBox>
                   <asp:Label ID="Label2" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                    </div>

                           <div class="form-group">
                           <asp:CheckBox ID="chksms2" runat="server" AutoPostBack="True" 
                                                    Text="Requires EMail Alert" />

                                 </div>
                            <div class="form-group">
                           <asp:CheckBox ID="chksms" runat="server" AutoPostBack="True" 
                                                    Text="Requires SMS Alert" />

                                </div>
                           <div class="form-group">
                           <asp:CheckBox ID="chkStaffType" runat="server" AutoPostBack="True" 
                                                    Text="Is Customer a Staff?" Width="160px" Visible="False" />
                           
                           </div>
                           
                           
                           </div>  <!-- end col-md-6 -->

                     

</div>

    <div class="panel-footer">
                   
            
    <asp:TextBox ID="txtnone" runat="server" Visible="False"></asp:TextBox>
                                                          <asp:Button ID="Btnsubmit" runat="server" CssClass="btn btn-primary" 
                                                    Text="Update" ValidationGroup="News1" />
             
         
                                                <asp:Button ID="But_Reset" runat="server" CssClass="btn btn-danger" 
                                                    Text="Reset" />
              
    </div>
    
          </div>

</asp:View>

     <asp:View ID="View2" runat="server">
          <div class="panel panel-default">
               <div class="panel-heading">
                                         
        
            </div>

         <tr>
                                                        <td colspan="4" style="height: 27px">
                                                            <div class="box-blue">
                                                                <h2>
                                                                    <span style="color: #ffffff"><strong>Corporate Customer</strong></span></h2>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 350px; height: 16px">
                                                            Customer Type</td>
                                                        <td style="width: 119px; height: 16px">
                                                            <asp:DropDownList ID="DrpCustType0" runat="server" AutoPostBack="True" 
                                                                Font-Size="Small" CssClass="form-control">
                                                                <asp:ListItem Selected="True" Value="0">--Select Customer Type</asp:ListItem>
                                                                <asp:ListItem Value="1">Individual</asp:ListItem>
                                                                <asp:ListItem Value="2">Corporate</asp:ListItem>
                                                            </asp:DropDownList>
                                                            (Choose to Change Customer&nbsp; Type)</td>
                                                        <td style="width: 335px; height: 16px">
                                                            &nbsp;</td>
                                                        <td style="width: 100px; height: 16px">
                                                            &nbsp;</td>
                                                    </tr>
         <div class="panel-body">
                       <div class="col-md-4">
                            <!-- Title -->
                    <div class="form-group">

                         Company RegNo *
                    
                         <asp:TextBox ID="txtcompRegno" runat="server" Font-Size="Small" placeholder="Company RegNo" CssClass="form-control"></asp:TextBox>
                    

                        </div>
                           <div class="form-group">
                            Country Of Incorporation
                     
                       <asp:DropDownList ID="DrpcompCountry" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    

                               </div>

                           <div class="form-group">
                            Company Sector
                     
                       <asp:DropDownList ID="DrpcompSector" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    

                               </div>

                           <div class="form-group">

                         Office Phone1 *
                    
                         <asp:TextBox ID="Txtcomephone1" runat="server" Font-Size="Small" placeholder="Office Phone1" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"></asp:TextBox>
                    

                        </div>


                            <div class="form-group">

                         Office Phone4
                    
                         <asp:TextBox ID="Txtcomephone4" runat="server" Font-Size="Small" placeholder="Office Phone4" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"></asp:TextBox>
                    

                        </div>

                            <div class="form-group">
                      Introducer
                               <asp:DropDownList ID="drpintro2" runat="server" AutoPostBack="True" CssClass="form-control" 
                                                    Font-Size="Small">
                                                    <asp:ListItem Selected="True" Value="0">--Select Introducer--</asp:ListItem>
                                                    <asp:ListItem Value="1">Staff</asp:ListItem>
                                                    <asp:ListItem Value="2">Customer</asp:ListItem>
                                                    <asp:ListItem Value="3">Others</asp:ListItem>
                                                </asp:DropDownList>
                    
                    
                    </div>

                           <div class="form-group">
<asp:CheckBox ID="ChkGroup0" runat="server" AutoPostBack="True" 
                                                    Text="Is Customer a Member Of a Group?"/>
           <asp:DropDownList ID="DrpGroup0" runat="server" AutoPostBack="True" CssClass="form-control"
                                                    Font-Size="Small" Visible="False">
                                                </asp:DropDownList>
                

    </div>

                           </div>  <!-- end col-md-6 -->


                     <div class="col-md-4">

                          <div class="form-group">

                         Company Name *
                    
                         <asp:TextBox ID="txtCompname" runat="server" Font-Size="Small" placeholder="Company Name" CssClass="form-control"></asp:TextBox>
                    

                        </div>

                          <div class="form-group">
                            State Of Incorporation
                     
                       <asp:DropDownList ID="DrpcompStateInc" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    

                               </div>

                          <div class="form-group">
                      Company Address *
                     
                        <asp:TextBox ID="txtCompaddr" runat="server" Font-Size="Medium" Height="47px" placeholder="Company Address"
                                                    TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    
                    </div>

                          
                          <div class="form-group">

                         Office Phone2
                    
                         <asp:TextBox ID="Txtcomephone2" runat="server" Font-Size="Small" placeholder="Office Phone2" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"></asp:TextBox>
                    

                        </div>

                          <div class="form-group">

                              Email Address
                               <asp:TextBox ID="txtcompemail" runat="server" Font-Size="Small" placeholder="Email Address" CssClass="form-control"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                                    ControlToValidate="txtcompemail" Display="Dynamic" 
                                                    ErrorMessage="Enter Email Correctly" 
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                    ValidationGroup="News2" Width="176px" SetFocusOnError="True">Enter Email Correctly</asp:RegularExpressionValidator>

                              </div>

                         <div class="form-group">
                      Introducer ID
                    
                         <asp:TextBox ID="txtCompintro" runat="server" Font-Size="Small"  placeholder="Introducer ID" CssClass="form-control"></asp:TextBox>
                         <asp:Label ID="Label3" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                    </div>

                     </div>   <!-- end col-md-6 -->




    <div class="col-md-4">

               <div class="form-group">
 
                    Date Of Registration * <asp:HyperLink
                                                    ID="HyperLink1" runat="server" ImageUrl="~/Images/pdate.gif" Width="17px">HyperLink</asp:HyperLink>
             <asp:TextBox ID="txtcompDateReg" runat="server" Font-Size="Small" placeholder="Date of Registration" CssClass="form-control"></asp:TextBox>
                                                <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="txtcompDateReg"
                                                    Display="Dynamic" ErrorMessage="Date Format Incorrect" Operator="DataTypeCheck"
                                                    Type="Date" ValidationGroup="News1">Date Format Incorrect</asp:CompareValidator>
        

                   </div>


        <div class="form-group">
                            Company Town
                     
                       <asp:DropDownList ID="DrpCompTown" runat="server" Font-Size="Small" placeholder="Company Town" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    

                               </div>

        <div class="form-group">

                         Contact Person
                    
                         <asp:TextBox ID="txtcontact" runat="server" Font-Size="Small" placeholder="Contact Person" CssClass="form-control"></asp:TextBox>
                    

                        </div>


        <div class="form-group">

                         Office Phone3
                    
                         <asp:TextBox ID="Txtcomephone3" runat="server" Font-Size="Small" placeholder="Office Phone3" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"></asp:TextBox>
                    

                        </div>


        <div class="form-group">
                      &nbsp;<asp:TextBox ID="txtCompOffc" runat="server" Font-Size="Small" Width="100%" placeholder="Account Officer" CssClass="form-control" Visible="False"></asp:TextBox>
                        <asp:Label ID="Label4" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                   
                    </div>

         <div class="form-group">
                           <asp:CheckBox ID="chksms1" runat="server" AutoPostBack="True" 
                                                    Text="Requires EMail Alert" />

                                 </div>
                            <div class="form-group">
                           <asp:CheckBox ID="chksms0" runat="server" AutoPostBack="True" 
                                                    Text="Requires SMS Alert" />

                                </div>

         </div>   <!-- end col-md-6 -->       
                    </div>  <!-- end box-body -->

         </div>

     <div class="panel-footer">
                   
            
    <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
          
                                                <asp:Button ID="BtnSubmit2" runat="server" CssClass="btn btn-primary" 
                                                    Text="Update" ValidationGroup="News2" />
                
                                                <asp:Button ID="But_Reset2" runat="server" CssClass="btn btn-danger" 
                                                    Text="Reset"/>
                </div>
      </asp:View>
    

                        </asp:MultiView>

     

    </ContentTemplate> 
    </asp:UpdatePanel> 
     <script type="text/javascript">
     function ValidateText(obj)
    {
        if(obj.value.length>0)
        {
             obj.value = obj.value.replace(/[^\d]+/g, '');
        }
    }
   </script>
</asp:Content>

