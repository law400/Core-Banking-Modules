<%@ Page Title="" Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="Test2.aspx.vb" Inherits="CustomerService_Test2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <meta charset="utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0"/>
        <meta name="description" content=""/>
        <meta name="author" content=""/>

                <script src="template/js/jquery-1.11.1.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
               <div class="panel-heading">
                                         
         
            </div>
                 <div class="panel-body">
                   <div class="form-group">
                        <asp:RadioButtonList ID="RdBCustType" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">Individual Member</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="form-group">
                      
                      Use custom customer/member id
                    
                         <asp:RadioButtonList ID="RadioBut_CustomerType" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                            <asp:ListItem Value="No" Selected="True">No</asp:ListItem>
                             <asp:ListItem Value="Yes">Yes</asp:ListItem>
                        </asp:RadioButtonList>
                     </div>
                   
                   <div class="col-md-5">
                    <div class="form-group">
                    <telerik:RadNumericTextBox ID="txtCustomerId" Runat="server" AutoPostBack="True" CssClass="form-control" Visible="False" Width="100%" EmptyMessage="Enter Customer/Member ID" >
                            <NumberFormat DecimalDigits="0" GroupSeparator="" />
                        </telerik:RadNumericTextBox>
                        
                    </div>
                    
                    </div>
                    
          
                 </div>
                 </div>
    <asp:MultiView ID="MultiView1" runat="server">
 <asp:View ID="View1" runat="server">
        <div class="panel panel-default">
      <div class="panel-heading">
                                         <h4 class="panel-title">Fill Form</h4>
                                        </div>

            <div class="panel-body">
                
                       <div class="col-md-4">
                            <!-- Title -->
                    <div class="form-group">
                      Title <span style="color: red"><strong>*</strong></span>
                    
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
                                                    Text="Is Customer a Member Of a Group?" Font-Bold="False"/>
           <asp:DropDownList ID="DrpGroup" runat="server" AutoPostBack="True" CssClass="form-control"
                                                    Font-Size="Small" Visible="False">
                                                </asp:DropDownList>
                

    </div>


                           <div class="form-group">
                     <%-- <label >Introducer--%>
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
                                ID Issue Date <span style="color: red"><strong>*</strong></span> 
                     
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
                     <%-- <label >Introducer ID--%>
                    
                         <asp:TextBox ID="txtIntroID" runat="server" Font-Size="Small"  placeholder="Introducer ID" CssClass="form-control" Visible="False"></asp:TextBox>
                         <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                    </div>

                        </div> <!-- end col-md-6 -->

                       <div class="col-md-4">
                          <div class="form-group">
                              Firstname <span style="color: red"><strong>*</strong></span>
                   
                        <asp:TextBox ID="txtFirstname" runat="server" Font-Size="Small" CssClass="form-control" placeholder="First Name"> </asp:TextBox>
                      </div>
                    
                             
                           <div class="form-group">
                               Date Of Birth <span style="color: red"><strong>*</strong></span> 
                     
                       <asp:TextBox ID="txtDOB" runat="server" Font-Size="Small" CssClass="form-control" placeholder="Date of birth"></asp:TextBox>
                   
                    </div>

                           

                           <div class="form-group">
                      Education Level
                      
                       <asp:DropDownList ID="DrpEdu" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    
                    </div>

                               <div class="form-group">
                      Business/Occupation
                 
                       <asp:DropDownList ID="DrpOccupation" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                     
                    </div>

                               <div class="form-group">
                                   Sector <span style="color: red"><strong>*</strong></span>
               
                       <asp:DropDownList ID="Drpsector" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    
                    </div>
                           

                              

                            <div class="form-group">
                      BVN
                   
                        <asp:TextBox ID="Txtphone4" runat="server" Font-Size="Small" Width="100%" placeholder="BVN" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                      
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
                     <asp:HyperLink ID="HypSearch0" runat="server" 
                                                    ImageUrl="~/Images/iconbar_previewtab.gif" Visible="False"></asp:HyperLink>
                 
                        <asp:TextBox ID="txtOfficer" runat="server" Font-Size="Small" Width="100%" placeholder="Account Officer" CssClass="form-control" Visible="False"> </asp:TextBox>
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
                                                    Text="Is Customer a Staff?" Width="221px" Visible="False" />
                           
                           </div>
                           
                           
                           </div>  <!-- end col-md-6 -->

                    
    </div>
             
                    

    <div class="panel-footer">
                   
            
    <asp:TextBox ID="txtnone" runat="server" Visible="False"></asp:TextBox>
         
                                                <asp:Button ID="Btnsubmit" runat="server" CssClass="btn btn-primary" 
                                                    Text="Submit" ValidationGroup="News1"/>
             
                                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-danger" 
                                                    Text="Reset" />

        <asp:Button ID="btnSuccess" runat="server" Text="Submit" CssClass="btn btn-success"
                OnClick="btnSuccess_Click" />
              
             <asp:Button ID="Button3" runat="server" Text="Submit" CssClass="btn btn-success"
                OnClick="btnSuccess_Click" />
            <asp:Button ID="btnDanger" runat="server" Text="Danger" CssClass="btn btn-danger"
                OnClick="btnDanger_Click" />
            <asp:Button ID="btnWarning" runat="server" Text="Warning" CssClass="btn btn-warning"
                OnClick="btnWarning_Click" />
            <asp:Button ID="btnInfo" runat="server" Text="Info" CssClass="btn btn-info"
                OnClick="btnInfo_Click" />
          
           <asp:Button ID="Button4" runat="server" Text="Testing" CssClass="btn btn-info" />
           </div>
                                 
    </div>

            </div>
    
 </asp:View>


     <asp:View ID="View2" runat="server">
          <div class="panel panel-default">
  
              <div class="panel-heading">
                                         
         
</div>
         <div class="panel-body">
                       <div class="col-md-4">
                            <!-- Title -->
                    <div class="form-group">

                         Company RegNo *
                    
                         <asp:TextBox ID="txtcompRegno" runat="server" Font-Size="Small" placeholder="Company RegNo" CssClass="form-control"></asp:TextBox>
                    

                        </div>
                           <div class="form-group">
                            <label >Country Of Incorporation
                     
                       <asp:DropDownList ID="DrpcompCountry" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    

                               </div>

                           <div class="form-group">
                            <label >Company Sector
                     
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
                      <label >Introducer
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
                            <label >State Of Incorporation
                     
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
                      <label >Introducer ID
                    
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
                            <label >Company Town
                     
                       <asp:DropDownList ID="DrpCompTown" runat="server" Font-Size="Small" placeholder="Company Town" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    

                               </div>

        <div class="form-group">

                         Contact Person
                    
                         <asp:TextBox ID="txtcontactperson" runat="server" Font-Size="Small" placeholder="Contact Person" CssClass="form-control"></asp:TextBox>
                    

                        </div>


        <div class="form-group">

                         Office Phone3
                    
                         <asp:TextBox ID="Txtcomephone3" runat="server" Font-Size="Small" placeholder="Office Phone3" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"></asp:TextBox>
                    

                        </div>


        <div class="form-group">
                      Account Officer <asp:HyperLink ID="HypSearch1" runat="server" 
                                                    ImageUrl="~/Images/iconbar_previewtab.gif"></asp:HyperLink>
                 
                        <asp:TextBox ID="txtCompOffc" runat="server" Font-Size="Small" Width="100%" placeholder="Account Officer" CssClass="form-control"> </asp:TextBox>
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


     <div class="panel-footer">
                   
            
    <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                                                  
                                                <asp:Button ID="BtnSubmit2" runat="server" CssClass="btn btn-primary" 
                                                    Text="Submit" ValidationGroup="News2" />
                                                    
          
                                                <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" 
                                                    Text="Reset" />
            
                                               
    </div>
    
              </div>
    </asp:View>

                        </asp:MultiView>
        </ContentTemplate> 
    </asp:UpdatePanel>  
  
</asp:Content>
