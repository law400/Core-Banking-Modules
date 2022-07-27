<%@ Register TagPrefix="obshow" Namespace="OboutInc.Show" Assembly="obout_Show_Net" %>
<%@ Register TagPrefix="cc1" Namespace="EeekSoft.Web" Assembly="EeekSoft.Web.PopupWin" %>

<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Alertl.ascx.vb" Inherits="Alertl" %>
<%--<obshow:Show ID="Show1" runat="server" Height="50px" ScrollDirection="top" 
                        ScrollingSpeed="20" ShowType="show" TransitionType="QuickScroll" 
                        Width="800">
                        <changer arrowtype="Side1" horizontalalign="Center" position="Bottom" 
                            type="Arrow" verticalalign="Middle" />
                    </obshow:Show>--%>

 <cc1:popupwin id="popupWin" style="Z-INDEX: 124; LEFT: 288px; POSITION: absolute; TOP: 528px" runat="server" width="230px" height="100px" windowsize="300, 200" windowscroll="False" dockmode="BottomLeft" colorstyle="Blue" gradientdark="210, 200, 220" textcolor="0, 0, 3" shadow="125, 90, 160" lightshadow="185, 170, 200" darkshadow="128, 0, 102" visible="False"></cc1:popupwin>