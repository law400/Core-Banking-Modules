<%@ Page Title="" Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="ItemRequestApproval.aspx.vb" Inherits="Admin_ItemRequestApproval" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
  <link href="Style.css" rel="stylesheet" />

    <div class="form-grids row widget-shadow" data-example-id="basic-forms"> 
                        <div class="form-title">
							<h4>Items Request Approval</h4>
						</div>
    <div class="panel panel-widget">
        <%--</div>--%>

		<div class="panel-body">
		<!-- status -->
		    <div class="contain">	
		        <div class="gantt">
 <div class="box-body">
          <!-- SELECT2 EXAMPLE -->
     <asp:Panel ID="Panel3" runat="server" Height="100%" Width="100%">
    <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;&nbsp;&nbsp;<br />
        <div align="center" style="background-color: #E6F2FF">
        </div>
    </div>
   <%-- <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
        Skin="Vista" ToolTip="Loading" BackgroundPosition="Top">
    </telerik:RadAjaxLoadingPanel>--%>
        <br />

         


    <%--<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" height="100%" 
        HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1" 
        width="100%" ClientEvents-OnRequestStart="requestStart">
     --%>  
        
         <asp:Panel ID="Panel1" runat="server" Visible="False">
                      <div class="alert alert-success alert-dismissable">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                    <h4>	<i class="icon fa fa-check"></i> Alert!</h4>
                          <asp:Label ID="Label_success" runat="server" Text=""></asp:Label>
                  </div>
                </asp:Panel>

         <asp:Panel ID="Panel2" runat="server" Visible="False">
                    <div class="alert alert-danger alert-dismissable">
                        <button aria-hidden="true" class="close" data-dismiss="alert" type="button">
                            ×
                        </button>
                        <h4><i class="icon fa fa-ban"></i>Alert!</h4>
                        <asp:Label ID="Label_error" runat="server" Text=""></asp:Label>
                    </div>
                </asp:Panel>

        
        
        <asp:Panel ID="Panel6" runat="server" Height="100%" Visible="False" 
            Width="100%" >
           
            
            
            
    <div class="forms">
					
        <div class="form-grids row widget-shadow" data-example-id="basic-forms"> 
  
            <div class="grids">
        
					        <div class="progressbar-heading grids-heading">
					        </div>
					        <div class="forms-grids">
                        
						        <div class="col-md-6">
							        <div class="panel panel-widget">
								        <div class="my-div">
                                            <form method="post" action="" class="valida" autocomplete="off" novalidate="novalidate">
									
										        <%--<div class="input-info">
											        <h3>Input Texts:</h3>
										        </div>--%>
										        <label for="field-1"> &nbsp;<span class="at-required-highlight"></span></label>
										        <div class="form-group">
											       
                                                    <asp:Label ID="Label1" runat="server" Text="Cooperator Name:"></asp:Label>
                       
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label6" runat="server" Text="Cooperator Name:"></asp:Label>
                       
                                                </div>

										        <div class="form-group">
											         <asp:Label ID="Label2" runat="server" Text="Account Number:"></asp:Label>
                       
                                                     &nbsp;&nbsp;&nbsp;&nbsp;
                                                     <asp:Label ID="Label7" runat="server" Text="Account Number:"></asp:Label>
                       
                                                </div>

										        <div class="form-group">
                       
                                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            
                                                </div>
										        <div class="form-group">
                       
                                                     &nbsp;&nbsp;&nbsp;&nbsp;
                                                     <asp:Label ID="LblID" runat="server" Text=" " Visible="false"></asp:Label>
                       
                                                </div>
										        <div class="form-group">
                       
                                                    <asp:TextBox ID="TxtReason" runat="server" Height="79px" TextMode="MultiLine" Visible="False" Width="419px" placeholder="Add reason why you reject request "></asp:TextBox>
                       
                                                </div>
                                                <br />
        <%--											<input type="submit" name="sub-1" value="Submit" class="btn btn-primary">--%>
											
                                                <%--<input type="reset" name="res-1" id="res-1" value="Reset" class="btn btn-danger">--%>
										

            <asp:Button ID="AddItem" runat="server" Text="Approve" class="btn btn-primary"  Font-Bold="True" ForeColor="White"  BackColor="#009933"/>
<%--            <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-primary"  Font-Bold="True" ForeColor="White" Width="100%" />--%>
            <asp:ImageButton ID="Image_add" runat="server" Height="23px" 
                ImageUrl="~/Images/Add2.png" ToolTip="Add" ValidationGroup="Church" 
                Width="29px" />
            &nbsp;&nbsp;&nbsp;



                                                <asp:ImageButton ID="Image_update" runat="server" Height="23px" 
                ImageUrl="~/Images/Update.gif" ToolTip="Update" ValidationGroup="Church" 
                Width="29px" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButCancel" runat="server" Text="Not Approve" class="btn btn-danger"  Font-Bold="True" ForeColor="White" />
            <asp:ImageButton ID="Image_cancel" runat="server" Height="22px" 
                ImageUrl="~/Images/Delete.png" ToolTip="Cancel" Width="26px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           
                                    
                                            </form>
								        </div>
							        </div>
						        </div>

						        <div class="col-md-6">

                             <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/WebPortal/images/00110100148p.jpg" />--%>
					<div class="demo-container" id="demo-container1">	        

                        <asp:Image ID="Image1" runat="server" />
                                
                                </div>

                      </div>
						
						        <div class="clearfix"> </div>
					        </div>

        </div>
        </div>
</div>

        
            
        </asp:Panel>


      
       
        <asp:Panel ID="Panel4" runat="server" Visible="true" Width="100%" ScrollBars="Auto">
             <table class="style8">
            <tr>
                <td class="style16">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td class="style17">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>

            <asp:Panel ID="Panel5" runat="server" Width="100%" ScrollBars="Auto">
             <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" 
            GridLines="None" OnNeedDataSource="RadGrid1_NeedDataSource" Skin="Telerik" 
            style="margin-left: 14px" Width="97%">
            <PagerStyle Mode="NextPrevAndNumeric" />
            <MasterTableView AutoGenerateColumns="false"
                 CommandItemDisplay="Top" 
                DataKeyNames="ID" Width="100%">
                <CommandItemTemplate>
                    <div style="padding: 5px 5px;">
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="butadd" runat="server" CommandName="mycommand"><img alt="" 
                            src="~/WebPortal/Images/Add1.ico" style="border:0px;vertical-align:middle;" />Add 
                        Item</asp:LinkButton>
                        <%--                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="edit"><img style="border:0px;vertical-align:middle;" alt="" src="Images/Edit.gif" />Edit</asp:LinkButton>
--%><%--                        <asp:LinkButton ID="btnEditSelected" runat="server" CommandName="EditSelected" Visible='<%# RadGrid1.EditIndexes.Count = 0 %>'><img style="border:0px;vertical-align:middle;" alt="" src="Images/Edit.gif" />Edit selected</asp:LinkButton>&nbsp;&nbsp;
--%>
                        <asp:LinkButton ID="btnUpdateEdited" runat="server" CommandName="UpdateEdited" 
                            Visible="<%# RadGrid1.EditIndexes.Count > 0 %>"><img alt="" 
                            src="WebPortal/Images/Update.gif" style="border:0px;vertical-align:middle;" />Update</asp:LinkButton>
                        &nbsp;&nbsp;
                        <asp:LinkButton ID="btnCancel" runat="server" CommandName="CancelAll" 
                            Visible="<%# RadGrid1.EditIndexes.Count > 0 Or RadGrid1.MasterTableView.IsItemInserted %>"><img 
                            alt="" src="WebPortal/Images/Cancel.gif" style="border:0px;vertical-align:middle;" />Cancel 
                        editing</asp:LinkButton>
                        &nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton4" runat="server" CommandName="RebindGrid"><img 
                            alt="" src="WebPortal/Images/Refresh.gif" style="border:0px;vertical-align:middle;" />Refresh</asp:LinkButton>
                    </div>
                </CommandItemTemplate>
                <CommandItemSettings AddNewRecordText="Add new role" />
               
            <Columns>

                <telerik:GridBoundColumn DataField="Accountnumber" HeaderText="Account Number" 
                    SortExpression="Accountnumber" UniqueName="Accountnumber">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="Employeename" HeaderText="Employee Name" 
                    SortExpression="Employeename" UniqueName="Employeename">
                </telerik:GridBoundColumn>


                 <telerik:GridBoundColumn DataField="Itemcode" HeaderText="Item Requested" 
                    SortExpression="Itemcode" UniqueName="Itemcode">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"
                    UniqueName="Quantity">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="Status" HeaderText="Status" SortExpression="Status"
                    UniqueName="Status">
                </telerik:GridBoundColumn>

                <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" 
                        ConfirmDialogType="RadWindow" ConfirmText="Delete Item?" ConfirmTitle="Delete" 
                        HeaderText="Delete" Text="Delete" UniqueName="Delete">
                </telerik:GridButtonColumn>

                 <telerik:GridButtonColumn CommandName="SelectData" HeaderText="Request" 
                        Text="View Request" UniqueName="column">
                    </telerik:GridButtonColumn>
              
                <%--<telerik:GridTemplateColumn UniqueName="TemplateEditColumn">
                    <ItemTemplate>
                        <asp:HyperLink ID="EditLink" runat="server" Text="Edit"></asp:HyperLink>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>--%>
            </Columns>
            <EditFormSettings>
                    <EditColumn ButtonType="ImageButton" />
                </EditFormSettings>
            </MasterTableView>
            <%-- <ClientSettings>
                <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
            </ClientSettings>--%>
            <SelectedItemStyle BackColor="Olive" Font-Bold="False" Font-Italic="False" 
                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                Wrap="True" />
            <ClientSettings EnableRowHoverStyle="True">
            </ClientSettings>
        </telerik:RadGrid>
            
            
            
            
            
            
            </asp:Panel>
        </asp:Panel>
      
  <%--  </telerik:RadAjaxPanel>--%>
</asp:Panel>

     
                </div>
              </div>
                     </div>
              </div>
             </div>
        </div>
              <%--</div>--%>
       <%-- </section>--%>


       
        </asp:Content>

