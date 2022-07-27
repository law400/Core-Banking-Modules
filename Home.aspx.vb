Imports Ext.Net
Imports Ext.Net.Utilities
Imports System.Data
Imports System.Net
Imports System.Xml

Imports System.IO
Imports System.Xml.Serialization
Imports System.Data.SqlClient

Imports log4net
Imports log4net.Config

Partial Class Home
    Inherits System.Web.UI.Page
    Dim bll As New BusinessLayer.BLL
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(Home))

    Public Shared Sub ShowAlertMessage(ByVal Page As Page, ByVal Msg As String, ByVal PageToRedirect As String)
        Dim sbJavascript As New StringBuilder()

        Dim Value As String = "alert('" & Msg & "');"
        Value = Value & "window.location.href='" & PageToRedirect & "';"
        sbJavascript.Append(Value)
        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "ShowAlert", sbJavascript.ToString(), True)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ReferrerName As String = Nothing
        ''Btn_login.Attributes.Add("onclick", "hideLayer();")
        If Not IsPostBack Then

         If Session("UserID") = Nothing Then
            Response.Redirect("~/PageExpired.aspx")
          End If
        End If

        If Profile.node_ID = Nothing Then
            Response.Redirect("~/PageExpired.aspx")
        End If
        If Request.UrlReferrer IsNot Nothing Then
            ReferrerName = Request.UrlReferrer.Segments(Request.UrlReferrer.Segments.Length - 1)
        End If

        If ReferrerName = "" Then
             Response.Redirect("~/PageExpired.aspx")
        End If
        'If Not IsPostBack Then
        '    'set DisplaySessionTimeout() as the startup script of this page
        '    Page.ClientScript.RegisterStartupScript(Me.[GetType](), "onLoad", "DisplaySessionTimeout()", True)
        'End If

        If Session("UserID") = Nothing Then
           Response.Redirect("~/PageExpired.aspx")
        End If
        ''Dim EODCheck As String = "Select isnull(EODProcess,0)'EODProcess' from tbl_system with (nolock)"
        Dim EODCheck As String = "Select isnull(EODProcess,0)'EODProcess' from tbl_system with (nolock) where node_id = " & Profile.node_ID
        Dim EODValue As String = ""
        Dim KillUser As String = "Exec SessionKll '" & Profile.Userid & "', " & Profile.node_ID & ""
        '' Dim KillUser As String = "Exec SessionKll '" & Profile.Userid & "'"
        'If con.SqlDs(EODCheck).Tables(0).Rows.Count > 0 Then
        '    EODValue = 
        'End If
        For Each drx As System.Data.DataRow In con.SqlDs(EODCheck).Tables(0).Rows
            EODValue = drx!EODProcess.ToString
        Next
        If EODValue = 1 Then
            con.SqlDs(KillUser)
            ShowAlertMessage(Me.Page, "Please EOD is in Process, kindly wait for some time or contact system administrator.", "Default.aspx")
            Exit Sub

        ElseIf EODValue = 2 Then
            con.SqlDs(KillUser)
            ShowAlertMessage(Me.Page, "Please EOM is in Process, kindly wait for some time or contact system administrator.", "Default.aspx")
            Exit Sub
        ElseIf EODValue = 3 Then
            con.SqlDs(KillUser)
            ShowAlertMessage(Me.Page, "Please EOY is in Process, kindly wait for some time or contact system administrator.", "Default.aspx")
            Exit Sub

        Else

            ''Btn_login.Attributes.Add("onclick", "hideLayer();")
            Dim QryCheck As String = "Select Userid from SessionTable with (nolock) where ltrim(rtrim(userid))='" & Profile.Userid & "' and node_id = " & Profile.node_ID & " "
            If con.SqlDs(QryCheck).Tables(0).Rows.Count < 1 Then
                Response.Redirect("~/PageExpired.aspx")
            End If





            Dim rtval As Integer

            ''Dim selexist As String = "Declare @retmsg int exec sessionlogin '" & Profile.AppStatus.Trim & "','" & Profile.Userid.Trim & "',@retmsg output select @retmsg"
            Dim selexist As String = "Declare @retmsg int exec sessionlogin '" & Profile.AppStatus.Trim & "','" & Profile.Userid.Trim & "',@retmsg output, " & Profile.node_ID & " select @retmsg"
            rtval = con.SqlDs(selexist).Tables(0).Rows(0).Item(0)


            If (rtval > 1 Or rtval < 1) Then
                'Dim qrylogin As String = "update tbl_userprofile set logincount=1 where userid='" & Profile.Userid.Trim & "'"
                'con.SqlDs(qrylogin)

                Response.Redirect("~/default.aspx?id=" & "Multiple login not Permitted")
            End If


            If Profile.AppStatus.Trim = "" Then

                Response.Redirect("~/default.aspx?id=" & "User Session Inactive")
            End If


            If Profile.sysphase = "3" Then

                '' Dim userid As String = "Select sys_phase from tbl_system with (nolock) where userid='" & Profile.Userid.Trim & "'"
                Dim userid As String = "Select sys_phase from tbl_system with (nolock) where userid='" & Profile.Userid.Trim & "' and node_id = " & Profile.node_ID & ""
                If con.SqlDs(userid).Tables(0).Rows.Count > 0 Then

                Else
                    Response.Redirect("~/default.aspx?id=" & "EOD Prcoessing")

                End If


            End If
        End If

        'Catch ex As Exception
        '    smartobj.alertwindow(Me.Page, ex.Message, "Prime")

        'End Try
        If Page.IsPostBack = False Then
            'If Request.IsAuthenticated = False Then
            '    Response.Redirect("~/default.aspx")

            'End If

            If bll.country = Nothing Then
                ShowGeoLocation()

            End If
        End If
        '''   lblDate.Text = DateTime.Now.ToLongDateString().ToString() & "."

        'If Request.IsAuthenticated = False Then
        '    Response.Redirect("~/login.aspx")
        'End If

        Me.AddSplitButton()
        ''   Me.lblLocation0.Text = bll.city
        ''   Me.lblLocation1.Text = bll.country
        LblSystemDate.Text = UCase("System Date: ") + Profile.sysdate
        lblUsername.Text = UCase("Login Userid: ") + Profile.Userid
        Lbluser.Text = UCase("Login Username: ") + Profile.fullname
        LblReportTo.Text = UCase("Approving Officer: ") + Profile.reportto


        ''DynamicMenu()
    End Sub

    Private Sub AddSplitButton()

        Try
            Dim count1 As Integer = 0
            Dim count2 As Integer = 0
            Dim panelitm As New Ext.Net.Panel

            Dim mitem As MenuItem = Nothing
            Dim mseparate As MenuSeparator = Nothing
            'Dim TriggerField As Ext.Net.TriggerField = New Ext.Net.TriggerField
            'TriggerField.Flex = 1
            'TriggerField.EmptyText = "Filter Menu"
            'TriggerField.EnableKeyEvents = True


            'Dim ToolBar As Ext.Net.Toolbar = New Ext.Net.Toolbar
            'ToolBar.Items.Add(TriggerField)
            Dim topmenu As String = "exec [Proc_TopMenuList] '" & Profile.Roleid & "','" & Profile.Userid & "'," & Profile.node_ID & ""

            Dim mpanel As Ext.Net.MenuPanel = New Ext.Net.MenuPanel
            '' mpanel.Items.Add(New Ext.Net.Toolbar)

            For Each dr As Data.DataRow In bll.SQLRecordDs(topmenu).Rows
                Dim parent As Integer = dr.Item("menu_id")
                mpanel = New Ext.Net.MenuPanel
                mpanel.ID = parent
                mpanel.Width = "200"
                mpanel.AutoHeight = True
                ' mpanel.Height = "500"


                mpanel.Title = dr.Item("menu_name").ToString
                Select Case dr.Item("ICON").ToString
                    Case "Laptop"
                        ''   mpanel.Icon = dr.Item("ICON")
                        mpanel.Icon = Icon.Laptop
                    Case "HouseStar"
                        mpanel.Icon = Icon.HouseStar
                    Case "HouseGo"
                        mpanel.Icon = Icon.HouseGo
                    Case "HouseConnect"
                        mpanel.Icon = Icon.HouseConnect
                    Case "Report"
                        mpanel.Icon = Icon.Report
                    Case "UserAdd"
                        mpanel.Icon = Icon.UserAdd
                    Case "UserEdit"
                        mpanel.Icon = Icon.UserEdit
                    Case "User"
                        mpanel.Icon = Icon.User
                    Case "UserKey"
                        mpanel.Icon = Icon.UserKey
                    Case "LockEdit"
                        mpanel.Icon = Icon.LockEdit
                    Case "Group"
                        mpanel.Icon = Icon.Group
                    Case "Layers"
                        mpanel.Icon = Icon.Layers
                    Case "LayoutAdd"
                        mpanel.Icon = Icon.LayoutAdd
                    Case "MapAdd"
                        mpanel.Icon = Icon.MapAdd
                    Case "BookmarkAdd"
                        mpanel.Icon = Icon.BookmarkAdd
                    Case "VcardAdd"
                        mpanel.Icon = Icon.VcardAdd
                    Case "TransmitAdd"
                        mpanel.Icon = Icon.TransmitAdd
                    Case "ApplicationFormEdit"
                        mpanel.Icon = Icon.ApplicationFormEdit
                    Case "Mail"
                        mpanel.Icon = Icon.Mail
                    Case "WorldConnect"
                        mpanel.Icon = Icon.WorldConnect
                    Case "Mail"
                        mpanel.Icon = Icon.Mail
                    Case "WorldConnect"
                        mpanel.Icon = Icon.WorldConnect
                    Case "LightningAdd"
                        mpanel.Icon = Icon.LightningAdd
                    Case "TransmitBlue"
                        mpanel.Icon = Icon.TransmitBlue
                    Case "BrickAdd"
                        mpanel.Icon = Icon.BrickAdd
                    Case "GroupGear"
                        mpanel.Icon = Icon.GroupGear
                    Case "Money"
                        mpanel.Icon = Icon.Money
                    Case "Building"
                        mpanel.Icon = Icon.Building
                    Case "MoneyAdd"
                        mpanel.Icon = Icon.MoneyAdd
                    Case "Overlays"
                        mpanel.Icon = Icon.Overlays
                    Case "PackageAdd"
                        mpanel.Icon = Icon.PackageAdd
                    Case "Add"
                        mpanel.Icon = Icon.Add
                    Case "ArrowUndo"
                        mpanel.Icon = Icon.ArrowUndo
                    Case "CogAdd"
                        mpanel.Icon = Icon.CogAdd
                    Case "BuildingAdd"
                        mpanel.Icon = Icon.BuildingAdd
                    Case "PageAdd"
                        mpanel.Icon = Icon.PageAdd
                    Case "MoneyAdd"
                        mpanel.Icon = Icon.MoneyAdd
                    Case ""
                        mpanel.Icon = Icon.Application
                End Select

                '' mpanel.Icon = Icon.Application
                count1 += 1
                Dim detailmenu As String = "exec [Proc_UserMenu] '" & Profile.Roleid & "'," & parent & ",'" & Profile.Userid & "'," & Profile.node_ID & ""
                For Each dr1 As Data.DataRow In bll.SQLRecordDs(detailmenu).Rows
                    mitem = New Ext.Net.MenuItem()
                    Dim child As Integer = dr1.Item("menu_id")
                    Dim url As String = dr1.Item("url")
                    url = url.Remove(0, 2)
                    Dim menuname As String = dr1.Item("menu_name")
                    mitem.ID = child
                    mitem.Text = dr1.Item("menu_name")

                    Select Case dr1.Item("ICON").ToString
                        Case "Laptop"
                            mitem.Icon = Icon.Laptop
                        Case "HouseStar"
                            mitem.Icon = Icon.HouseStar
                        Case "HouseGo"
                            mitem.Icon = Icon.HouseGo
                        Case "HouseConnect"
                            mitem.Icon = Icon.HouseConnect
                        Case "Report"
                            mitem.Icon = Icon.Report
                        Case "UserAdd"
                            mitem.Icon = Icon.UserAdd
                        Case "UserEdit"
                            mitem.Icon = Icon.UserEdit
                        Case "User"
                            mitem.Icon = Icon.User
                        Case "UserKey"
                            mitem.Icon = Icon.UserKey
                        Case "LockEdit"
                            mitem.Icon = Icon.LockEdit
                        Case "Group"
                            mitem.Icon = Icon.Group
                        Case "Layers"
                            mitem.Icon = Icon.Layers
                        Case "LayoutAdd"
                            mitem.Icon = Icon.LayoutAdd
                        Case "MapAdd"
                            mitem.Icon = Icon.MapAdd
                        Case "BookmarkAdd"
                            mitem.Icon = Icon.BookmarkAdd
                        Case "VcardAdd"
                            mitem.Icon = Icon.VcardAdd
                        Case "TransmitAdd"
                            mitem.Icon = Icon.TransmitAdd
                        Case "ApplicationFormEdit"
                            mitem.Icon = Icon.ApplicationFormEdit
                        Case "Mail"
                            mitem.Icon = Icon.Mail
                        Case "WorldConnect"
                            mitem.Icon = Icon.WorldConnect
                        Case "LightningAdd"
                            mitem.Icon = Icon.LightningAdd
                        Case "TransmitBlue"
                            mitem.Icon = Icon.TransmitBlue
                        Case "BrickAdd"
                            mitem.Icon = Icon.BrickAdd
                        Case "GroupGear"
                            mitem.Icon = Icon.GroupGear
                        Case "Money"
                            mitem.Icon = Icon.Money
                        Case "Building"
                            mitem.Icon = Icon.Building
                        Case "MoneyAdd"
                            mitem.Icon = Icon.MoneyAdd
                        Case "Overlays"
                            mitem.Icon = Icon.Overlays
                        Case "PackageAdd"
                            mitem.Icon = Icon.PackageAdd
                        Case "Add"
                            mitem.Icon = Icon.Add
                        Case "ArrowUndo"
                            mitem.Icon = Icon.ArrowUndo
                        Case "CogAdd"
                            mitem.Icon = Icon.CogAdd
                        Case "BuildingAdd"
                            mitem.Icon = Icon.BuildingAdd
                        Case "PageAdd"
                            mitem.Icon = Icon.PageAdd
                        Case "MoneyAdd"
                            mitem.Icon = Icon.MoneyAdd
                        Case ""
                            mitem.Icon = Icon.Tick
                    End Select




                    mitem.Listeners.Click.Handler = "addTab(#{TabPanel1},'" & child & "', '" & url & "','" & menuname & "');"
                    'menu.Items.Add(mitem)


                    mpanel.Menu.Add(mitem)


                    count2 += 1
                    'mseparate.DataBind()
                Next
                ''    mpanel.Items.Add(TriggerField)
                If mpanel.Menu.Items.Count > 0 Then
                    Panel1.Items.Add(mpanel)

                End If
            Next






            'mpanel.Menu.Add(menu)


        Catch ex As Exception

            logger.Info("Home Page: Sub Add SplitButton'" _
          & vbNewLine & "   <<<<Direction: OUTPUT" _
          & vbNewLine & "      OUTPUT PARAMETERS LIST & " _
          & vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
          & vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
          & vbNewLine & "******************************************************************************************************")

        End Try





    End Sub

    Private Function GetGeoLocation(ipaddress As String) As DataTable
        'Create a WebRequest
        Dim gateway As String = "http://ws.cdyne.com/ip2geo/ip2geo.asmx/ResolveIP?ipAddress="

        '' ''http://ws.cdyne.com/ip2geo/ip2geo.asmx/ResolveIP?ipAddress=41.189.29.75&licenseKey=0
        '' '' "http://ipinfodb.com/ip_query.php?ip="
        '' ''"http://freegeoip.appspot.com/xml/"


        Dim rssReq As WebRequest = WebRequest.Create(gateway + ipaddress & "&licenseKey=0")
        'Create a Proxy
        Dim px As New WebProxy(gateway + ipaddress, True)

        'Assign the proxy to the WebRequest
        rssReq.Proxy = px

        'Set the timeout in Seconds for the WebRequest
        rssReq.Timeout = 2000
        Try
            'Get the WebResponse
            Dim rep As WebResponse = rssReq.GetResponse()

            'Read the Response in a XMLTextReader
            Dim xtr As New XmlTextReader(rep.GetResponseStream())

            'Create a new DataSet
            Dim ds As New DataSet()

            'Read the Response into the DataSet
            ds.ReadXml(xtr)
            Return ds.Tables(0)
        Catch
            Return Nothing
        End Try
    End Function
    Protected Sub ShowGeoLocation()
        Dim sIpaddress As String
        'sIpaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        'If sIpaddress = "" OrElse sIpaddress Is Nothing Then
        '    sIpaddress = Request.ServerVariables("REMOTE_ADDR")
        'End If
        sIpaddress = Request.UserHostAddress
        If sIpaddress = "" OrElse sIpaddress Is Nothing Then
            sIpaddress = Request.UserHostAddress
        End If

        If sIpaddress = "127.0.0.1" Then
            Exit Sub
        End If

        'call the function to consume web service and store result into datatable
        Dim odtGeoLocation As DataTable = GetGeoLocation(sIpaddress)
        If odtGeoLocation IsNot Nothing Then
            If odtGeoLocation.Rows.Count > 0 Then
                '' bll.city = odtGeoLocation.Rows(0)("City").ToString()
                'lblRegion.Text = odtGeoLocation.Rows(0)("RegionName").ToString()
                bll.country = odtGeoLocation.Rows(0)("Country").ToString()
                bll.organization = odtGeoLocation.Rows(0)("Organization").ToString()
            Else
                'lblError = "Sorry,no data found!!"
            End If
        End If
    End Sub


    ''Function list() As String
    ''    Dim str As String = ""
    ''    str = "<Items>"
    ''    str = str & "<ext:MenuPanel ID=""MenuPanel1"" runat=""server"" Width=""200""  Title=""ADMIN"" Icon=""Application"" >"
    ''    str = str & "<Menu ID=""Menu1"" runat=""server"">"
    ''    str = str & "<Items>"
    ''    str = str & "<ext:MenuItem ID=""mnu901"" runat=""server"" Text=""MANAGE ROLES"" Icon=""Money"">"
    ''    str = str & "<Listeners>"
    ''    str = str & "<Click Handler=""addTab(#{TabPanel1}, 'Balance Enquiry', '');"" />"
    ''    str = str & "</Listeners>"
    ''    str = str & "</ext:MenuItem>"

    ''    str = str & "<ext:MenuSeparator />"

    ''    str = str & "<ext:MenuItem ID=""mnu902"" runat=""server"" Text=""MANAGE USERS"" Icon=""Monitor"">"
    ''    str = str & "<Listeners>"
    ''    str = str & "<Click Handler=""addTab(#{TabPanel1}, 'Mini Statement', '');"" />"
    ''    str = str & "</Listeners>"
    ''    str = str & "</ext:MenuItem>"

    ''    str = str & "<ext:MenuSeparator />"

    ''    str = str & "<ext:MenuItem ID=""mnu903"" runat=""server"" Text=""ONLINE USERS"" Icon=""MagifierZoomOut"">"
    ''    str = str & "<Listeners>"
    ''    str = str & "<Click Handler=""addTab(#{TabPanel1}, 'Full Statement', '');"" />"
    ''    str = str & "</Listeners>"
    ''    str = str & "</ext:MenuItem>"

    ''    str = str & "</Items>"
    ''    str = str & "</Menu>"
    ''    str = str & "</ext:MenuPanel>"
    ''    str = str & "</Items>"
    ''    Return str
    ''End Function
    ''Public Sub DynamicMenu()
    ''    Try
    ''        Dim listaelementimenu As String() = New String() {"item1", "item2", "item3"}


    ''        Dim subMenu As New Ext.Net.Menu()

    ''        Dim i As Integer = 0
    ''        For Each item As String In listaelementimenu

    ''            Dim subItem As New Ext.Net.MenuItem()
    ''            subItem.ID = "m_" + i.ToString()
    ''            subItem.Text = ""
    ''            'subItem.DirectEvents.Click.[Event] += ItemClick1
    ''            Dim prm As New Ext.Net.Parameter()
    ''            prm.Name = "Prm"
    ''            prm.Value = i.ToString()
    ''            '' subItem.DirectEvents.Click.ExtraParams.Add(prm)
    ''            subMenu.Items.Add(subItem)
    ''            i += 1
    ''        Next

    ''        Dim item1 As New Ext.Net.MenuItem("Folder Name")

    ''        item1.Menu.Add(subMenu)

    ''        Panel1.Items.Add(item1)
    ''    Catch generatedExceptionName As Exception
    ''        Throw
    ''    End Try
    ''End Sub
    ''Public Sub AddMenuAndItems()
    ''    Dim mnuFileMenu As New Menu()
    ''    Dim myMenuItemFile As New MenuItem("&File")
    ''    Dim myMenuItemNew As New MenuItem("&New")
    ''    Dim myMenuItemFolder As New MenuItem("&Options")

    ''    Dim sb As StringBuilder = New StringBuilder()
    ''    sb.Append("Hello ")
    ''    sb.Append("World ")
    ''    sb.ToString()
    ''    ' ''add menu item
    ''    ''mnuFileMenu.Add(myMenuItemFile)
    ''    ''myMenuItemFile.Menu.Add(myMenuItemNew)

    ''    ' ''another method
    ''    ''mnuFileMenu.Add("Save &As")


    ''    ' ''add submenu item
    ''    ''myMenuItemNew.Menu.Add(myMenuItemFolder)


    ''    ''Panel1.Items.Add(mnuFileMenu)

    ''End Sub

    Private Function GetData(parentMenuId As Integer) As DataTable
        Dim query As String = "SELECT [MenuId], [Title], [Description], [Url] FROM [Menus] WHERE ParentMenuId = @ParentMenuId"
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Using con As New SqlConnection(constr)
            Dim dt As New DataTable()
            Using cmd As New SqlCommand(query)
                Using sda As New SqlDataAdapter()
                    cmd.Parameters.AddWithValue("@ParentMenuId", parentMenuId)
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    sda.Fill(dt)
                End Using
            End Using
            Return dt
        End Using
    End Function

    'Private Sub PopulateMenu(dt As DataTable, parentMenuId As Integer, parentMenuItem As MenuItem)
    '    Dim currentPage As String = Path.GetFileName(Request.Url.AbsolutePath)
    '    For Each row As DataRow In dt.Rows
    '        Dim menuItem As New MenuItem() With { _
    '         .Value = row("MenuId").ToString(), _
    '         .Text = row("Title").ToString(), _
    '          .NavigateUrl = row("Url").ToString(), _
    '         .Selected = row("Url").ToString().EndsWith(currentPage, StringComparison.CurrentCultureIgnoreCase) _
    '        }
    '        If parentMenuId = 0 Then
    '            Menu1.Items.Add(menuItem)
    '            Dim dtChild As DataTable = Me.GetData(Integer.Parse(menuItem.Value))
    '            PopulateMenu(dtChild, Integer.Parse(menuItem.Value), menuItem)
    '        Else
    '            parentMenuItem.ChildItems.Add(menuItem)
    '        End If
    '    Next
    'End Sub

    Public Sub Redirect(ByVal url As String)

        Ext.Net.X.Redirect(url)
    End Sub
	 Protected Sub But_Refresh_Click(sender As Object, e As EventArgs) Handles But_Refresh.Click
        ' Response.Redirect(Request.RawUrl)
        'Page.IsPostBack
        But_Refresh.Attributes.Add("onclick", "<script language=javascript1.2>window.location.reload(true);</script>")
        Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
    End Sub

    'Protected Sub But_Refresh_Load(sender As Object, e As EventArgs) Handles But_Refresh.Load
    '    ''  Response.Redirect(Request.RawUrl)
    '    'Page.IsPostBack
    '    ' But_Refresh.Attributes.Add("onclick", "<script language=javascript1.2>window.location.reload(true);</script>")
    '    '  Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
    'End Sub

End Class
