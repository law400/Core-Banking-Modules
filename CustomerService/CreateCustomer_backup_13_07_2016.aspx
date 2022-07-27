<%@ Page Language="VB" MasterPageFile="~/PrimeApp.master"    AutoEventWireup="false"   CodeFile="CreateCustomer.aspx.vb" Inherits="CustomerService_CreateCustomer" title="CustomerCreation Page" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
  
            
             <div class="box box-info">
                <div class="box-header">
                        <asp:RadioButtonList ID="RdBCustType" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">Individual Customer</asp:ListItem>
                        </asp:RadioButtonList></td>
              
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Search Customer
                        <asp:HyperLink ID="hypsearch" runat="server" Height="20px" 
                            ImageUrl="~/Images/iconbar_previewtab_on.gif" Width="27px">HyperLink</asp:HyperLink>
                   
                        <asp:MultiView ID="MultiView1" runat="server">
 <asp:View ID="View1" runat="server">

    
                  <div class="box-body">
                       <div class="col-md-4">
                            <!-- Title -->
                    <div class="form-group">
                      <label>Title</label>
                    
                        <asp:DropDownList ID="DrpTitle" runat="server" Font-Size="Small" AutoPostBack="True" placeholder="Title" CssClass="form-control">
                                                </asp:DropDownList>
                    
                    </div>
 
                   <div class="form-group">
                      <label>Middle Name</label>
                    
                         <asp:TextBox ID="txtOthername" runat="server" Font-Size="Small" placeholder="Middle Name" CssClass="form-control"></asp:TextBox>
                    
                    </div>

                           

                            <div class="form-group">
                      <label> Nationality*</label>
                    
                       <asp:DropDownList ID="DrpNational" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                     
                    </div>

                            

                             <div class="form-group">
                      <label >Resident State*</label>
                    
                       <asp:DropDownList ID="DrpResState" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    
                    </div>

                            <div class="form-group">
                      <label>Resident Address*</label>
                     
                        <asp:TextBox ID="txtAddress" runat="server" Font-Size="Medium" Height="47px" 
                                                    TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    
                    </div>
                           <div class="form-group">
                      <label>Mobile Phone1*</label>
                     
                        <asp:TextBox ID="txtphone1" runat="server" Font-Size="Small" Width="100%" placeholder="Mobile Phone" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                     
                    </div>

                             <div class="form-group">
                      <label>Mobile Phone2</label>
                     
                        <asp:TextBox ID="Txtphone2" runat="server" Font-Size="Small" Width="100%" placeholder="Mobile Phone" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                     
                    </div>

       
                           <div class="form-group">
                      <label >Name Of Next Of Kin</label>
                     
                        <asp:TextBox ID="txtnextofKin" runat="server" Font-Size="Small" Width="100%" placeholder="Name Of Next Of Kin" CssClass="form-control" > </asp:TextBox>
                    
                    </div>     
                              
                              
                           <div class="form-group">
                      <label >ID No*</label>
                     
                        <asp:TextBox ID="txtIdNo" runat="server" Font-Size="Small" Width="100%" placeholder="ID No" CssClass="form-control" > </asp:TextBox>
                    
                    </div>              

                                 
    <div class="form-group">
                      <label>Referrer Name</label>
                 
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
                      <label >Introducer</label>
                               <asp:DropDownList ID="DrpIntro" runat="server" AutoPostBack="True" CssClass="form-control" 
                                                    Font-Size="Small">
                                                    <asp:ListItem Selected="True" Value="0">--Select Introducer--</asp:ListItem>
                                                    <asp:ListItem Value="1">Staff</asp:ListItem>
                                                    <asp:ListItem Value="2">Customer</asp:ListItem>
                                                    <asp:ListItem Value="3">Others</asp:ListItem>
                                                </asp:DropDownList>
                    
                    
                    </div>

                             <div class="form-group">
                           <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                                                    Text="Is Customer Related to another Customer in the Bank?"  />
                                 <asp:Label ID="Label5" runat="server" Text="CustomerID" Visible="False"></asp:Label>
                                                <asp:TextBox ID="txtcustid" runat="server" AutoPostBack="True" CssClass="form-control" MaxLength="10" 
                                                    Visible="False"></asp:TextBox><asp:Label ID="Label6" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label><asp:DropDownList ID="DrpRela" runat="server" AutoPostBack="True" 
                                                    CssClass="form-control" Font-Size="Small" Visible="False">
                                                </asp:DropDownList>

                                 </div>
                       </div>  <!-- end col-md-6 -->
                     
                        <div class="col-md-4">
                            <div class="form-group">
                      <label >Surname*</label>
                    
                         <asp:TextBox ID="txtSurname" runat="server" Font-Size="Small"  placeholder="Surname" CssClass="form-control"></asp:TextBox>
                  
                    </div>

                            <div class="form-group">
                      <label >Sex*</label>
                     
                       <asp:DropDownList ID="DrpSex" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                   
                    </div>

                            <div class="form-group">
                      <label >State Of Origin*</label>
                     
                       <asp:DropDownList ID="DrpState" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    
                    </div>

                            <div class="form-group">
                      <label >Resident City/Town*</label>
                  
                       <asp:DropDownList ID="DrpTown" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                     
                    </div>

                            <div class="form-group">
                      <label >Office Address</label>
                   
                        <asp:TextBox ID="txtAddress0" runat="server" Font-Size="Medium" Height="47px" 
                                                    TextMode="MultiLine" Width="100%" CssClass="form-control"></asp:TextBox>
                   
                    </div>

                       
                            <div class="form-group">
                      <label >Office Phone</label>
                     
                        <asp:TextBox ID="txtphone3" runat="server" Font-Size="Small" Width="100%" placeholder="Office Phone" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                      
                    </div>

                            <div class="form-group">
                      <label>Email Address</label>
                    
                        <asp:TextBox ID="txtemail" runat="server" Font-Size="Small" Width="100%" placeholder="Email" CssClass="form-control"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                    ControlToValidate="txtemail" Display="Dynamic" 
                                                    ErrorMessage="enter email correctly" 
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                    Width="176px" SetFocusOnError="True">enter email correctly</asp:RegularExpressionValidator>
               
                    </div>

                                 <div class="form-group">
                      <label >Next Of Kin Phone</label>
                     
                        <asp:TextBox ID="Txtkinphone" runat="server" Font-Size="Small" Width="100%" placeholder="Next Of Kin Phone" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                    
                    </div>

                            
                             


                            <div class="form-group">
                      <label>ID Issue Date* <asp:HyperLink ID="imgdate2" runat="server" ImageUrl="~/Images/pdate.gif" 
                                                    Width="17px">HyperLink</asp:HyperLink></label>
                     
                        <asp:TextBox ID="txtIssue" runat="server" Font-Size="Small" Width="100%" placeholder="ID Issue Date" CssClass="form-control"></asp:TextBox>
                                               
                                                <asp:CompareValidator ID="CompareValidator11" runat="server" 
                                                    ControlToValidate="txtIssue" Display="Dynamic" 
                                                    ErrorMessage="Date Format Incorrect" Operator="DataTypeCheck" Type="Date" 
                                                    ValidationGroup="News1" Width="147px" SetFocusOnError="True">Date Format Incorrect</asp:CompareValidator>
                     
                    </div>
                              
                            <div class="form-group">
                      <label>Referrer Phone</label>
               
                        <asp:TextBox ID="txtRefphone" runat="server" Font-Size="Small" Width="100%" placeholder="Referrer Name" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                   
                    </div>

                           
                            <div class="form-group">
                            <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" 
                                                    Text="Is Customer a Signatory to Another Account?"/>

                                <asp:Label ID="Label7" runat="server" Text="Account Number" Visible="False"></asp:Label>
                    
                         <asp:TextBox ID="txtsignacct" runat="server" Font-Size="Small"  placeholder="Account Number" CssClass="form-control" Visible="False"></asp:TextBox>
                                <asp:Label ID="Label8" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                                </div>
                             <div class="form-group">
                      <label >Introducer ID</label>
                    
                         <asp:TextBox ID="txtIntroID" runat="server" Font-Size="Small"  placeholder="Introducer ID" CssClass="form-control"></asp:TextBox>
                         <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                    </div>

                        </div> <!-- end col-md-6 -->

                       <div class="col-md-4">
                          <div class="form-group">
                      <label>Firstname</label>
                   
                        <asp:TextBox ID="txtFirstname" runat="server" Font-Size="Small" CssClass="form-control" placeholder="First Name"> </asp:TextBox>
                      </div>
                    
                             
                           <div class="form-group">
                      <label>Date Of Birth* <asp:HyperLink ID="imgdate1" runat="server" ImageUrl="~/Images/pdate.gif" Width="17px">HyperLink</asp:HyperLink></label>
                     
                       <asp:TextBox ID="txtDOB" runat="server" Font-Size="Small" CssClass="form-control" placeholder="Date of birth"></asp:TextBox>
                   
                    </div>

                           

                           <div class="form-group">
                      <label >Education Level</label>
                      
                       <asp:DropDownList ID="DrpEdu" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    
                    </div>

                               <div class="form-group">
                      <label >Business/Ocupation</label>
                 
                       <asp:DropDownList ID="DrpOccupation" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                     
                    </div>

                               <div class="form-group">
                      <label >Sector</label>
               
                       <asp:DropDownList ID="Drpsector" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    
                    </div>
                           

                              

                            <div class="form-group">
                      <label >Home Phone</label>
                   
                        <asp:TextBox ID="Txtphone4" runat="server" Font-Size="Small" Width="100%" placeholder="Home Phone" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"> </asp:TextBox>
                      
                    </div>
                             <div class="form-group">
                      <label >Next Of Kin Address</label>
                   
                        <asp:TextBox ID="txtKinAddress" runat="server" Font-Size="Medium" Height="47px" 
                                                    TextMode="MultiLine" Width="100%" CssClass="form-control"></asp:TextBox>
                   
                    </div>

                           <div class="form-group">
                      <label > ID Type*</label>
                     
                       <asp:DropDownList ID="DrpIdType" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    
                    </div>

                           <div class="form-group">
                      <label>ID Expiry Date*   <asp:HyperLink ID="imgdate3" runat="server" ImageUrl="~/Images/pdate.gif" 
                                                    Width="17px">HyperLink</asp:HyperLink></label>
                     
                       <asp:TextBox ID="txtExpirydate" runat="server" AutoPostBack="True" 
                                                    Font-Size="Small" Width="100%" placeholder="ID Expiry Date" CssClass="form-control"> </asp:TextBox>
                                              
                                                <asp:CompareValidator ID="CompareValidator10" runat="server" 
                                                    ControlToValidate="txtExpirydate" Display="Dynamic" 
                                                    ErrorMessage="Date Format Incorrect" Operator="DataTypeCheck" Type="Date" 
                                                    ValidationGroup="News1" Width="147px" SetFocusOnError="True">Date Format Incorrect</asp:CompareValidator>
                     
                    </div>

<div class="form-group">
                      <label>Account Officer <asp:HyperLink ID="HypSearch0" runat="server" 
                                                    ImageUrl="~/Images/iconbar_previewtab.gif"></asp:HyperLink></label>
                 
                        <asp:TextBox ID="txtOfficer" runat="server" Font-Size="Small" Width="100%" placeholder="Account Officer" CssClass="form-control"> </asp:TextBox>
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
                                                    Text="Is Customer a Staff?" Width="160px" />
                           
                           </div>
                           
                           
                           </div>  <!-- end col-md-6 -->

                     


                      </div>  <!-- end box-body -->

    <div class="box-footer">
                   
            
    <asp:TextBox ID="txtnone" runat="server" Visible="False"></asp:TextBox>
          <div class="col-md-6"> 
                                                <asp:Button ID="Btnsubmit" runat="server" CssClass="btn bg-purple btn-flat margin" 
                                                    Text="Submit" ValidationGroup="News1" Width="100%"/>
              </div>
          <div class="col-md-6"> 
                                                <asp:Button ID="Button1" runat="server" CssClass="btn bg-maroon btn-flat margin" 
                                                    Text="Reset" Width="100%" />
              </div>
                                              
    </div>
    

</asp:View>

     <asp:View ID="View2" runat="server">

         <div class="box-body">
                       <div class="col-md-4">
                            <!-- Title -->
                    <div class="form-group">

                         <label>Company RegNo *</label>
                    
                         <asp:TextBox ID="txtcompRegno" runat="server" Font-Size="Small" placeholder="Company RegNo" CssClass="form-control"></asp:TextBox>
                    

                        </div>
                           <div class="form-group">
                            <label >Country Of Incorporation</label>
                     
                       <asp:DropDownList ID="DrpcompCountry" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    

                               </div>

                           <div class="form-group">
                            <label >Company Sector</label>
                     
                       <asp:DropDownList ID="DrpcompSector" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    

                               </div>

                           <div class="form-group">

                         <label>Office Phone1 *</label>
                    
                         <asp:TextBox ID="Txtcomephone1" runat="server" Font-Size="Small" placeholder="Office Phone1" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"></asp:TextBox>
                    

                        </div>


                            <div class="form-group">

                         <label>Office Phone4</label>
                    
                         <asp:TextBox ID="Txtcomephone4" runat="server" Font-Size="Small" placeholder="Office Phone4" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"></asp:TextBox>
                    

                        </div>

                            <div class="form-group">
                      <label >Introducer</label>
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

                         <label>Company Name *</label>
                    
                         <asp:TextBox ID="txtCompname" runat="server" Font-Size="Small" placeholder="Company Name" CssClass="form-control"></asp:TextBox>
                    

                        </div>

                          <div class="form-group">
                            <label >State Of Incorporation</label>
                     
                       <asp:DropDownList ID="DrpcompStateInc" runat="server" Font-Size="Small" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    

                               </div>

                          <div class="form-group">
                      <label>Company Address *</label>
                     
                        <asp:TextBox ID="txtCompaddr" runat="server" Font-Size="Medium" Height="47px" placeholder="Company Address"
                                                    TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    
                    </div>

                          
                          <div class="form-group">

                         <label>Office Phone2</label>
                    
                         <asp:TextBox ID="Txtcomephone2" runat="server" Font-Size="Small" placeholder="Office Phone2" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"></asp:TextBox>
                    

                        </div>

                          <div class="form-group">

                              <label>Email Address</label>
                               <asp:TextBox ID="txtcompemail" runat="server" Font-Size="Small" placeholder="Email Address" CssClass="form-control"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                                    ControlToValidate="txtcompemail" Display="Dynamic" 
                                                    ErrorMessage="Enter Email Correctly" 
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                    ValidationGroup="News2" Width="176px" SetFocusOnError="True">Enter Email Correctly</asp:RegularExpressionValidator>

                              </div>

                         <div class="form-group">
                      <label >Introducer ID</label>
                    
                         <asp:TextBox ID="txtCompintro" runat="server" Font-Size="Small"  placeholder="Introducer ID" CssClass="form-control"></asp:TextBox>
                         <asp:Label ID="Label3" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                    </div>

                     </div>   <!-- end col-md-6 -->




    <div class="col-md-4">

               <div class="form-group">
 
                    <label>Date Of Registration * <asp:HyperLink
                                                    ID="HyperLink1" runat="server" ImageUrl="~/Images/pdate.gif" Width="17px">HyperLink</asp:HyperLink></label>
             <asp:TextBox ID="txtcompDateReg" runat="server" Font-Size="Small" placeholder="Date of Registration" CssClass="form-control"></asp:TextBox>
                                                <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="txtcompDateReg"
                                                    Display="Dynamic" ErrorMessage="Date Format Incorrect" Operator="DataTypeCheck"
                                                    Type="Date" ValidationGroup="News1">Date Format Incorrect</asp:CompareValidator>
        

                   </div>


        <div class="form-group">
                            <label >Company Town</label>
                     
                       <asp:DropDownList ID="DrpCompTown" runat="server" Font-Size="Small" placeholder="Company Town" AutoPostBack="True" CssClass="form-control">
                                                </asp:DropDownList>
                    

                               </div>

        <div class="form-group">

                         <label>Contact Person</label>
                    
                         <asp:TextBox ID="txtcontactperson" runat="server" Font-Size="Small" placeholder="Contact Person" CssClass="form-control"></asp:TextBox>
                    

                        </div>


        <div class="form-group">

                         <label>Office Phone3</label>
                    
                         <asp:TextBox ID="Txtcomephone3" runat="server" Font-Size="Small" placeholder="Office Phone3" CssClass="form-control" onkeyup="ValidateText(this);"  onpaste = "return false;"></asp:TextBox>
                    

                        </div>


        <div class="form-group">
                      <label>Account Officer <asp:HyperLink ID="HypSearch1" runat="server" 
                                                    ImageUrl="~/Images/iconbar_previewtab.gif"></asp:HyperLink></label>
                 
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


     <div class="box-footer">
                   
            
    <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
                                                  <div class="col-md-6"> 
                                                <asp:Button ID="BtnSubmit2" runat="server" CssClass="btn bg-purple btn-flat margin" 
                                                    Text="Submit" ValidationGroup="News2" Width="100%"/>
                                                      </div>
           <div class="col-md-6"> 
                                                <asp:Button ID="Button2" runat="server" CssClass="btn bg-maroon btn-flat margin" 
                                                    Text="Reset" Width="100%" />
               </div>
                                               
    </div>
    

    </asp:View>

                        </asp:MultiView>

     </div>
                 </div>
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

