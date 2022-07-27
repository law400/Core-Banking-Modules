<%@ Page Title="" Language="VB" MasterPageFile="~/PrimeApp.master" AutoEventWireup="false" CodeFile="DepositRequest.aspx.vb" Inherits="DepositRequest" %>


<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
  <link href="Style.css" rel="stylesheet" />

    <div class="form-grids row widget-shadow" data-example-id="basic-forms"> 
                        <div class="form-title">
							<h4>Deposit Request Approval</h4>
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
            Width="70%"  HorizontalAlign="Center">
           
            
            
            
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
                                                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButCancel" runat="server" Text="Not Approve" class="btn btn-danger"  Font-Bold="True" ForeColor="White" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           
                                    
                                            </form>
								        </div>
							        </div>
						        </div>

						        <div class="col-md-6">

                             <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/WebPortal/images/00110100148p.jpg" />--%>
					<div class="demo-container" id="demo-container1">	        

                        <asp:Image ID="Image1" runat="server" />

                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered table-hover dataTable" Font-Size="Small" PageSize="1" Width="99.4%">
                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
                <Columns>
                    <asp:TemplateField >
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Height="150px" ImageUrl='<%# "Handler.ashx?id=" + cType(Eval("serial"),String) + "&id2=" + Eval("accountnumber") %>' Width="200px" />
                            <asp:Image ID="Image2" runat="server" ImageUrl='<%# "Handler2.ashx?id=" + cType(Eval("serial"),String) + "&id2=" + Eval("accountnumber")  %>' />
                        </ItemTemplate>
                        <HeaderStyle ForeColor="#0000CC" />
                    </asp:TemplateField>
                  
                </Columns>
            </asp:GridView>
            
                                
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
             <telerik:radgrid ID="RadGrid1" runat="server" PageSize="5" Height="380px" EnableEmbeddedBaseStylesheet="false"
            CssClass="table table-striped table-bordered table-hover"
            EnableEmbeddedSkins="false" OnNeedDataSource="RadGrid1_NeedDataSource"
          
            AllowPaging="true"
            AutoGenerateColumns="false"  Font-Size="Medium">
            <MasterTableView EditMode="InPlace" CssClass="table table-striped table-hover"  DataKeyNames="ID"
                InsertItemPageIndexAction="ShowItemOnCurrentPage">
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
  <Columns>

               <telerik:GridBoundColumn DataField="Employeeid" HeaderText="Account Number" 
                        UniqueName="column2" EmptyDataText="-">
                        <HeaderStyle Font-Bold="True"  />
                    </telerik:GridBoundColumn>

                
               <telerik:GridBoundColumn DataField="Employeename" HeaderText="Employee Name" 
                        UniqueName="column2" EmptyDataText="-">
                        <HeaderStyle Font-Bold="True" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="RequestAmount" EmptyDataText="-" HeaderText="Credit (N)" 
                        UniqueName="column3" DataFormatString="{0:###,##0.00}">
                        <HeaderStyle Font-Bold="True" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Createdate" EmptyDataText="-" HeaderText="Date Applied" 
                        UniqueName="column4" >
                        <HeaderStyle Font-Bold="True" />
                    </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn DataField="ApproveDate" EmptyDataText="-" HeaderText="Date Approved" 
                        UniqueName="column4" >
                        <HeaderStyle Font-Bold="True" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Status" EmptyDataText="-" 
                        HeaderText="Status" UniqueName="column5" 
                       >
                        <HeaderStyle Font-Bold="True" />
                    </telerik:GridBoundColumn>



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
                    <EditColumn CancelImageUrl="Cancel.gif" EditImageUrl="Edit.gif" FilterControlAltText="Filter EditCommandColumn column" InsertImageUrl="Update.gif" UpdateImageUrl="Update.gif">
                    </EditColumn>
                </EditFormSettings>
                <PagerStyle AlwaysVisible="True" />
                <PagerTemplate>
                    <div class="rgWrap">
                        <ul class="pagination">
                            <li><a href="#">&laquo;</a></li>
                            <li><a href="#">&raquo;</a></li>
                        </ul>
                    </div>
                    <div class="rgWrap rgInfoPart">
                        <span>Page:</span>
                        <div class="input-group" style="width: 110px;">
                            <input type="text" class="form-control" value="1">
                            <span class="input-group-btn">
                                <button class="btn btn-default" type="button">Go!</button>
                            </span>
                        </div>
                    </div>
                </PagerTemplate>
            </MasterTableView>
        <%--    <ClientSettings>
                <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                <ClientEvents OnGridCreated="demo.onGridCreated" />
            </ClientSettings>--%>
            <PagerStyle AlwaysVisible="true" Mode="NextPrevNumericAndAdvanced" />
              <FilterMenu EnableEmbeddedBaseStylesheet="False" EnableEmbeddedSkins="False" EnableImageSprites="False">
              </FilterMenu>
              <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" EnableEmbeddedBaseStylesheet="False" EnableEmbeddedSkins="False">
              </HeaderContextMenu>
        </telerik:radgrid>
            
            
            
            
            
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

