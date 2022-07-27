Imports System.Net
Imports System.Management
Imports System.Diagnostics
Imports System.Net.NetworkInformation
Imports log4net
Imports log4net.Config

Partial Class _Default
    Inherits System.Web.UI.Page
    Private decl As New vardeclare
    Dim retmsg As String = ""
    Dim retval As Integer
    ''Public GetMacAddressFromIPAddress
    Dim qry As String = ""
    ''    Dim p As System.Security.Principal.WindowsPrincipal = System.Threading.Thread.CurrentPrincipal
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(_Default))

#Region "Declaration"
    Private Structure vardeclare
        Dim qry As String
        Dim ipadd As String
    End Structure
    'Private Function GetMacAddress(ByVal IPAddress As String) As String
    '    Dim strMacAddress As String = String.Empty
    '    Try
    '        Dim strTempMacAddress As String = String.Empty


    '        Dim objProcessStartInfo As ProcessStartInfo = New ProcessStartInfo()

    '        Dim objProcess As Process = New Process()

    '        objProcessStartInfo.FileName = "nbtstat"

    '        objProcessStartInfo.RedirectStandardInput = False

    '        objProcessStartInfo.RedirectStandardOutput = True

    '        objProcessStartInfo.Arguments = "-A " + IPAddress

    '        objProcessStartInfo.UseShellExecute = False

    '        objProcess = Process.Start(objProcessStartInfo)


    '        Dim Counter As Integer = -1

    '        While Counter <= -1
    '            Counter = strTempMacAddress.Trim().ToLower().IndexOf("mac address", 0)

    '            If (Counter > -1) Then
    '                Exit While
    '            End If
    '            strTempMacAddress = objProcess.StandardOutput.ReadLine()


    '        End While

    '        objProcess.WaitForExit()

    '        strMacAddress = strTempMacAddress.Trim()




    '    Catch ex As Exception

    '    End Try
    'End Function
#End Region
#Region "Pageload"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack = False Then
            'Dim LoadTenant As String = "SELECT Node_id,Tenant FROM tbl_Tenants with (nolock)"
            'smartobj.loadComboValues("[--Select a Tenant---] ", Me.DropTenant, LoadTenant)
            'If Me.DropTenant.SelectedValue = 0 Then

            '    smartobj.alertwindow(Me.Page, "[Please select]", "Prime")

            'Else

            '    Dim access As String = "exec proc_LockEOM " & DropTenant.SelectedValue & ""
            '    If con.SqlDs(access).Tables(0).Rows.Count > 0 Then
            '        Me.Login.Enabled = True

            '        Dim sel As String = "select convert(char,sys_date,112) from tbl_system where node_Id = " & DropTenant.SelectedValue & ""
            '        If con.SqlDs(sel).Tables(0).Rows(0).Item(0).ToString.Trim > con.SqlDs(access).Tables(0).Rows(0).Item(0).ToString.Trim Then
            '            Me.Login.Enabled = False
            '            smartobj.alertwindow(Me.Page, "Application Licence has Expired. Pls Contact Software Vendor.", "Prime")
            '            Exit Sub

            '        End If
            '    Else
            '        Me.Login.Enabled = False
            '        smartobj.alertwindow(Me.Page, "Application Not Registered. Pls Contact Software Vendor.", "Prime")
            '        Exit Sub

            '    End If
            '    If Request.QueryString("id") <> Nothing Then
            '        smartobj.alertwindow(Me.Page, Request.QueryString("id"), "Prime")
            '    End If

            '    Session("reportto") = ""
            '    Session("Userid") = ""
            '    Session("sysdate") = ""
            '    'Login.Attributes.Add("onclick", "window.open('./Authwatch.aspx',null,'width=10,height=10,x=2,y=1')")
            '    ''authenticate()
            '    getipmach()
            '    Try
            '        Dim qry As String = "select sys_date,sys_phase from tbl_system where node_id = " & DropTenant.SelectedValue & ""
            '        For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
            '            Session("sysdate") = dr!sys_date
            '            Session("sysphase") = dr!sys_phase
            '        Next

            '    Catch ex As Exception

            '    End Try
            'End If
        End If
    End Sub
#End Region
#Region "Task"
    Protected Sub Login_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Try


            'If Me.DropTenant.SelectedValue = 0 Then
            If Me.txtCoopID.Text = "" Then

                smartobj.alertwindow(Me.Page, "[Please Enter Coop ID]", "Prime")
                Exit Sub
            Else
                Dim TenantId As String = Nothing

                ''   TenantId = Me.txtCoopID.Text.Substring(3, 25)
                TenantId = Me.txtCoopID.Text.Trim
                Dim qry1 As String
                qry1 = ""

                qry1 = "select * from tbl_userprofile where userid='" & Me.txtuserid.Text.Trim & "' and userpassword='" & con.EncryptText(Me.txtpassword.Text.Trim) & "' and node_id = " & TenantId & ""

                Session("keep") = ""
                Session("parentid") = 1
                Session("Userid") = Nothing

                Dim contlen, pwd As Integer
                contlen = CInt(Me.txtpassword.Text.Length)

                Dim passlen As String = "select passlen from tbl_bank where node_id=" & TenantId & ""
                If con.SqlDs(passlen).Tables(0).Rows.Count <= 0 Then
                    smartobj.alertwindow(Me.Page, "Tenant does not exists", "Prime")
                    Exit Sub
                End If

                pwd = con.SqlDs(passlen).Tables(0).Rows(0).Item("passlen").ToString
                If contlen < pwd Then
                    ' smartobj.alertwindow (me.Page ,"Data Warnning error...", MsgBoxStyle.SystemModal,"Prime") "Password Lenght must not be less than " & pwd & " Characters. Contact the System Administrator for further Detail", "Prime")
                    smartobj.alertwindow(Me.Page, "Password Length must not be less than " & pwd & " Characters. Contact the System Administrator for further Detail", "Prime")

                    Exit Sub
                End If

                Session("AppStatus") = ""
                Dim idvv As String
                Dim sessid As Guid
                sessid = Guid.NewGuid
                idvv = sessid.ToString & "|" & txtuserid.Text.Trim
                Dim password As String = con.EncryptText(Me.txtpassword.Text.Trim)
                Session("AppStatus") = idvv.Trim
                Session("SessionID") = HttpContext.Current.Session.SessionID
                getipmach()
                qry = ""
                qry = "declare @retval int,@retmsg varchar(100) exec Proc_Validatelogin '" & Me.txtuserid.Text.Trim & "','" & password & "','" & Session("AppStatus") & "','" & Session("ipaddress").Trim & "','" & Session("Computername").Trim & "','" & Session("MacAddress").Trim & "','" & Session("SessionID") & "',@retval Output,@retmsg Output ," & TenantId & " select @retval,@retmsg"

                ' ''For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                'retval = con.SqlDs(qry).Tables(0).Rows(0).Item(0)
                'retmsg = con.SqlDs(qry).Tables(0).Rows(0).Item(1).ToString
                ' ''Next

                For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                    retval = dr(0).ToString
                    retmsg = dr(1).ToString
                Next

                If retval = -12 Then
                    Session("Pay_Node_id") = TenantId
                    Session("Userid") = txtuserid.Text.Trim
                    If con.SqlDs(qry1).Tables(0).Rows.Count <= 0 Then
                        smartobj.alertwindow(Me.Page, "User does not Exists", "Prime")
                        Exit Sub
                    End If
                    ''For Each dr As Data.DataRow In con.SqlDs(qry1).Tables(0).Rows
                    Session("fullname") = con.SqlDs(qry1).Tables(0).Rows(0).Item("fullname").ToString
                    Session("Authori") = con.SqlDs(qry1).Tables(0).Rows(0).Item("authoriser").ToString
                    Session("status") = con.SqlDs(qry1).Tables(0).Rows(0).Item("staff_status").ToString
                    Session("BranchCode") = con.SqlDs(qry1).Tables(0).Rows(0).Item("branchcode").ToString
                    Session("Roleid") = con.SqlDs(qry1).Tables(0).Rows(0).Item("Role_id").ToString
                    Session("loginstate") = con.SqlDs(qry1).Tables(0).Rows(0).Item("loginstatus").ToString
                    Session("Userid") = con.SqlDs(qry1).Tables(0).Rows(0).Item("userid").ToString
                    Session("node_ID") = con.SqlDs(qry1).Tables(0).Rows(0).Item("node_id").ToString
                    Dim multi As Integer = con.SqlDs(qry1).Tables(0).Rows(0).Item("multilogin").ToString
                    Dim reptto As String = con.SqlDs(qry1).Tables(0).Rows(0).Item("reportlevel").ToString
                    'Session.Abandon()
                    'Session.RemoveAll()

                    'Session("UserID") = Session("Userid")
                    'Session("node_ID") = TenantId

                    'Dim strsessionKill As String = "exec sessionKll '" & Session("Userid") & "', " & Session("node_ID") & ""
                    'con.SqlDs(strsessionKill)
                    'Dim selSession As String = "Update tbl_userprofile set sessionid=0,loginstatus=0,logincount=0 where userid ='" & Session("Userid") & "' and node_id = " & Session("node_ID") & ""
                    'con.SqlDs(selSession)
                    'Dim TrackLogOut As String = "Exec Proc_LoginTrack '" & Session("Userid") & "','" & Session("SessionID") & "'," & Session("node_ID") & ""
                    'con.SqlDs(TrackLogOut)
                    'Profile.AuthRemote = ""
                    'Profile.AuthLocal = ""

                    ''''  Session("SessionID") = HttpContext.Current.Session.SessionID


                    Dim selrepto As String = "Select isnull(fullname,'None') fullname from tbl_userprofile where userid='" & reptto & "' and node_id=" & Session("node_ID") & ""
                    '' Next
                    If con.SqlDs(selrepto).Tables(0).Rows.Count > 0 Then
                        Session("reportto") = con.SqlDs(selrepto).Tables(0).Rows(0).Item("fullname").ToString

                    End If


                    If multi > 0 Then
                        Dim qrylogin As String = "update tbl_userprofile set logincount=0 where userid='" & Session("Userid").Trim & "' and node_id=" & Session("node_ID") & ""
                        con.SqlDs(qrylogin)

                    Else
                        Dim qrylogin As String = "update tbl_userprofile set logincount=isnull(logincount,0)+1 where userid='" & Session("Userid").Trim & "' and node_id=" & Session("node_ID") & ""
                        con.SqlDs(qrylogin)

                    End If

                    ''' Dim url As String = "~/Tenant" + Session("node_ID").ToString + "/Home.aspx"


                    ''   Response.Redirect("~/Home.aspx")



                    Dim UpdateSystemdate As String = "Update tbl_system set sys_date ='" & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & "' where node_id  = '" & Session("node_ID") & "' "
                    con.SqlDs(UpdateSystemdate)





                    Dim qry2 As String = "select sys_date,sys_phase from tbl_system where node_id = " & Session("node_ID") & ""
                    For Each dr As Data.DataRow In con.SqlDs(qry2).Tables(0).Rows
                        Session("sysdate") = dr!sys_date
                        Session("sysphase") = dr!sys_phase
                    Next


                    'Dim url As String = "~/Dashboard.aspx"
                    'FormsAuthentication.SetAuthCookie(txtuserid.Text, False)
                    'Response.Redirect(url, False)

                    'If Not String.IsNullOrEmpty(Request.QueryString("ReturnUrl")) Then
                    '    FormsAuthentication.SetAuthCookie(txtuserid.Text, False)
                    '    Response.Redirect(Request.QueryString("ReturnUrl"))
                    'Else
                    '    FormsAuthentication.RedirectFromLoginPage(txtuserid.Text, False)
                    'End If

                    FormsAuthentication.SetAuthCookie(txtuserid.Text, False)
                    Response.Redirect("~/Admin/LoginSubscriptionPay2.aspx", False)

                ElseIf retval = -11 Then
                    Session("Pay_Node_id") = TenantId
                    Session("Userid") = txtuserid.Text.Trim
                    FormsAuthentication.SetAuthCookie(txtuserid.Text, False)
                    Response.Redirect("~/Admin/LoginSubscriptionPay.aspx", False)

                ElseIf retval = -60 Or retval = -70 Then
                    Session("node_ID") = TenantId
                    Session("Userid") = txtuserid.Text.Trim
                    FormsAuthentication.SetAuthCookie(txtuserid.Text, False)
                    Response.Redirect("~/Admin/ChangePassword.aspx?pwd=" & Me.txtuserid.Text.Trim & "&msg=" & retmsg, False)

                ElseIf retval = 0 Then
                    If con.SqlDs(qry1).Tables(0).Rows.Count <= 0 Then
                        smartobj.alertwindow(Me.Page, "User does not Exists", "Prime")
                        Exit Sub
                    End If
                    ''For Each dr As Data.DataRow In con.SqlDs(qry1).Tables(0).Rows
                    Session("fullname") = con.SqlDs(qry1).Tables(0).Rows(0).Item("fullname").ToString
                    Session("Authori") = con.SqlDs(qry1).Tables(0).Rows(0).Item("authoriser").ToString
                    Session("status") = con.SqlDs(qry1).Tables(0).Rows(0).Item("staff_status").ToString
                    Session("BranchCode") = con.SqlDs(qry1).Tables(0).Rows(0).Item("branchcode").ToString
                    Session("Roleid") = con.SqlDs(qry1).Tables(0).Rows(0).Item("Role_id").ToString
                    Session("loginstate") = con.SqlDs(qry1).Tables(0).Rows(0).Item("loginstatus").ToString
                    Session("Userid") = con.SqlDs(qry1).Tables(0).Rows(0).Item("userid").ToString
                    Session("node_ID") = con.SqlDs(qry1).Tables(0).Rows(0).Item("node_id").ToString
                    Dim multi As Integer = con.SqlDs(qry1).Tables(0).Rows(0).Item("multilogin").ToString
                    Dim reptto As String = con.SqlDs(qry1).Tables(0).Rows(0).Item("reportlevel").ToString
                    'Session.Abandon()
                    'Session.RemoveAll()

                    'Session("UserID") = Session("Userid")
                    'Session("node_ID") = TenantId

                    'Dim strsessionKill As String = "exec sessionKll '" & Session("Userid") & "', " & Session("node_ID") & ""
                    'con.SqlDs(strsessionKill)
                    'Dim selSession As String = "Update tbl_userprofile set sessionid=0,loginstatus=0,logincount=0 where userid ='" & Session("Userid") & "' and node_id = " & Session("node_ID") & ""
                    'con.SqlDs(selSession)
                    'Dim TrackLogOut As String = "Exec Proc_LoginTrack '" & Session("Userid") & "','" & Session("SessionID") & "'," & Session("node_ID") & ""
                    'con.SqlDs(TrackLogOut)
                    'Profile.AuthRemote = ""
                    'Profile.AuthLocal = ""

                    ''''  Session("SessionID") = HttpContext.Current.Session.SessionID


                    Dim selrepto As String = "Select isnull(fullname,'None') fullname from tbl_userprofile where userid='" & reptto & "' and node_id=" & Session("node_ID") & ""
                    '' Next
                    If con.SqlDs(selrepto).Tables(0).Rows.Count > 0 Then
                        Session("reportto") = con.SqlDs(selrepto).Tables(0).Rows(0).Item("fullname").ToString

                    End If


                    If multi > 0 Then
                        Dim qrylogin As String = "update tbl_userprofile set logincount=0 where userid='" & Session("Userid").Trim & "' and node_id=" & Session("node_ID") & ""
                        con.SqlDs(qrylogin)

                    Else
                        Dim qrylogin As String = "update tbl_userprofile set logincount=isnull(logincount,0)+1 where userid='" & Session("Userid").Trim & "' and node_id=" & Session("node_ID") & ""
                        con.SqlDs(qrylogin)

                    End If

                    ''' Dim url As String = "~/Tenant" + Session("node_ID").ToString + "/Home.aspx"


                    ''   Response.Redirect("~/Home.aspx")



                    Dim UpdateSystemdate As String = "Update tbl_system set sys_date ='" & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & "' where node_id  = '" & Session("node_ID") & "' "
                    con.SqlDs(UpdateSystemdate)





                    Dim qry2 As String = "select sys_date,sys_phase from tbl_system where node_id = " & Session("node_ID") & ""
                    For Each dr As Data.DataRow In con.SqlDs(qry2).Tables(0).Rows
                        Session("sysdate") = dr!sys_date
                        Session("sysphase") = dr!sys_phase
                    Next


                    Dim url As String = "~/Dashboard.aspx"
                    FormsAuthentication.SetAuthCookie(txtuserid.Text, False)
                    Response.Redirect(url, False)

                    If Not String.IsNullOrEmpty(Request.QueryString("ReturnUrl")) Then
                        FormsAuthentication.SetAuthCookie(txtuserid.Text, False)
                        Response.Redirect(Request.QueryString("ReturnUrl"))
                    Else
                        FormsAuthentication.RedirectFromLoginPage(txtuserid.Text, False)
                    End If


                Else

                    smartobj.alertwindow(Me.Page, retmsg, "Prime")
                End If
            End If
        Catch ex As Exception
            '''    smartobj.alertwindow(Me.Page, ex.Message, "Prime")

            smartobj.alertwindow(Me.Page, "Error occurred...", "Prime")
            logger.Info("Default.aspx: Login_Click" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")

        End Try


    End Sub
    Sub getipmach()
        Dim ip As String = HttpContext.Current.Request.UserHostAddress
        'Dim compname As String = HttpContext.Current.Request.UserAgent


        Try
            'Dim nic As NetworkInterface = Nothing
            'Dim mac_Address As String = ""
            'For Each nic In NetworkInterface.GetAllNetworkInterfaces
            '    mac_Address = nic.GetPhysicalAddress().ToString
            '    If mac_Address <> "" Then
            '        Session("MacAddress") = mac_Address

            '    End If
            'Next
            'nic = Nothing
            Dim i As Integer = 0

            For Each nic As System.Net.NetworkInformation.NetworkInterface In System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()

                If nic.Name = "Local Area Connection" Then
                    Session("MacAddress") = nic.GetPhysicalAddress().ToString

                Else
                    Session("MacAddress") = ""
                End If

            Next
            Session("ipaddress") = ip
            Session("Computername") = ""
            ''Session("Computername") = p.Identity.Name ''host.HostName

            ''      Session("Computername") = System.Net.Dns.GetHostEntry(Request.UserHostAddress).HostName
            Dim LocalIp As String = String.Empty
            Dim Domain As String = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName
            Dim Host__1 As String = System.Net.Dns.GetHostName()
            If Not System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() Then
                '    Return Nothing
            End If
            Dim host__2 As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
            For Each ip2 As System.Net.IPAddress In host__2.AddressList
                If ip2.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                    LocalIp = ip2.ToString()
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



    End Sub

    'Sub authenticate()
    '    'txtuserid.Text = ""
    '    'Dim comp As String = ""
    '    'If decl.ipadd = "127.0.0.1" Then
    '    '    'ipadd = Request.UserHostAddress
    '    '    Dim local As IPHostEntry = Dns.Resolve(Dns.GetHostName())
    '    '    For Each ip As IPAddress In local.AddressList
    '    '        decl.ipadd = CType(local.AddressList.GetValue(0), IPAddress).ToString
    '    '        decl.ipadd = ip.ToString
    '    '        Session("ipaddress") = decl.ipadd

    '    '    Next
    '    'Else
    '    '    decl.ipadd = Request.ServerVariables("REMOTE_ADDR") 'Request.UserHostAddress()
    '    '    Session("ipaddress") = decl.ipadd
    '    '    Session("Computername") = Environment.UserName

    '    'End If

    '    Dim host As System.Net.IPHostEntry
    '    host = System.Net.Dns.GetHostEntry(Request.ServerVariables.Item("REMOTE_HOST"))

    '    decl.ipadd = Request.ServerVariables("REMOTE_ADDR") 'Request.UserHostAddress()
    '    Dim mc As System.Management.ManagementClass
    '    Dim mo As ManagementObject
    '    mc = New ManagementClass("Win32_NetworkAdapterConfiguration")
    '    Dim moc As ManagementObjectCollection = mc.GetInstances()
    '    For Each mo In moc
    '        If mo.Item("IPEnabled") = True Then
    '            ''Session("ipaddress") = "MAC address " & mo.Item("MacAddress").ToString()
    '            Session("ipaddress") = decl.ipadd
    '            Session("MacAddress") = mo.Item("MacAddress").ToString()
    '            Session("Computername") = p.Identity.Name ''host.HostName

    '        End If
    '    Next
    'End Sub
#End Region

    'Protected Sub DropTenant_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropTenant.SelectedIndexChanged

    '    If Me.DropTenant.SelectedValue = 0 Then

    '        smartobj.alertwindow(Me.Page, "[Please select Tenant]", "Prime")
    '        Exit Sub
    '    Else

    '        Dim access As String = "exec proc_LockEOM " & DropTenant.SelectedValue & ""
    '        If con.SqlDs(access).Tables(0).Rows.Count > 0 Then
    '            Me.Login.Enabled = True

    '            Dim sel As String = "select convert(char,sys_date,112) from tbl_system where node_Id = " & DropTenant.SelectedValue & ""
    '            If con.SqlDs(sel).Tables(0).Rows(0).Item(0).ToString.Trim > con.SqlDs(access).Tables(0).Rows(0).Item(0).ToString.Trim Then
    '                Me.Login.Enabled = False
    '                smartobj.alertwindow(Me.Page, "Application License has Expired. Pls Contact Software Vendor.", "Prime")
    '                Exit Sub

    '            End If
    '        Else
    '            Me.Login.Enabled = False
    '            smartobj.alertwindow(Me.Page, "Application Not Registered. Pls Contact Software Vendor.", "Prime")
    '            Exit Sub

    '        End If
    '        If Request.QueryString("id") <> Nothing Then
    '            smartobj.alertwindow(Me.Page, Request.QueryString("id"), "Prime")
    '        End If

    '        Session("reportto") = ""
    '        Session("Userid") = ""
    '        Session("sysdate") = ""
    '        'Login.Attributes.Add("onclick", "window.open('./Authwatch.aspx',null,'width=10,height=10,x=2,y=1')")
    '        ''authenticate()
    '        getipmach()
    '        Try
    '            Dim qry As String = "select sys_date,sys_phase from tbl_system where node_Id = " & DropTenant.SelectedValue & ""
    '            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
    '                Session("sysdate") = dr!sys_date
    '                Session("sysphase") = dr!sys_phase
    '            Next

    '        Catch ex As Exception

    '        End Try
    '    End If
    'End Sub
    Sub Check_Login()
        Dim TenantId As String = Nothing

        '' TenantId = Me.txtCoopID.Text.Substring(3, 25)

        TenantId = Me.txtCoopID.Text.Trim
        'Dim access As String = "exec proc_LockEOM " & TenantId & ""
        'If con.SqlDs(access).Tables(0).Rows.Count > 0 Then
        '    Me.Login.Enabled = True

        '    Dim sel As String = "select convert(char,sys_date,112) from tbl_system where node_Id = " & TenantId & ""
        '    If con.SqlDs(sel).Tables(0).Rows(0).Item(0).ToString.Trim > con.SqlDs(access).Tables(0).Rows(0).Item(0).ToString.Trim Then
        '        Me.Login.Enabled = False
        '        smartobj.alertwindow(Me.Page, "Application License has Expired. Pls Contact Software Vendor.", "Prime")
        '        Exit Sub

        '    End If
        'Else
        '    Me.Login.Enabled = False
        '    smartobj.alertwindow(Me.Page, "Application Not Registered. Pls Contact Software Vendor.", "Prime")
        '    Exit Sub

        'End If
        If Request.QueryString("id") <> Nothing Then
            smartobj.alertwindow(Me.Page, Request.QueryString("id"), "Prime")
        End If

        Session("reportto") = ""
        Session("Userid") = ""
        Session("sysdate") = ""
        'Login.Attributes.Add("onclick", "window.open('./Authwatch.aspx',null,'width=10,height=10,x=2,y=1')")
        ''authenticate()
        getipmach()
        Try
            Dim qry As String = "select sys_date,sys_phase from tbl_system where node_Id = " & TenantId & ""
            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                Session("sysdate") = dr!sys_date
                Session("sysphase") = dr!sys_phase
            Next

        Catch ex As Exception

            smartobj.alertwindow(Me.Page, "Error occurred...", "Prime")
            logger.Info("Default.aspx: Check_Login()" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
        End Try
    End Sub

    'Protected Sub txtCoopID_TextChanged(sender As Object, e As EventArgs) Handles txtCoopID.TextChanged
    '    If Me.txtCoopID.Text = "" Then

    '        smartobj.alertwindow(Me.Page, "[Please select a Tenant]", "Prime")
    '        Exit Sub
    '    Else
    '        Dim TenantId As String = Nothing

    '        ''   TenantId = Me.txtCoopID.Text.Substring(3, 25)
    '        TenantId = Me.txtCoopID.Text.Trim
    '        ''Dim access As String = "exec proc_LockEOM " & TenantId & ""
    '        ''If con.SqlDs(access).Tables(0).Rows.Count > 0 Then
    '        ''    Me.Login.Enabled = True

    '        ''    Dim sel As String = "select convert(char,sys_date,112) from tbl_system where node_Id = " & TenantId & ""
    '        ''    If con.SqlDs(sel).Tables(0).Rows(0).Item(0).ToString.Trim > con.SqlDs(access).Tables(0).Rows(0).Item(0).ToString.Trim Then
    '        ''        Me.Login.Enabled = False
    '        ''        smartobj.alertwindow(Me.Page, "Application License has Expired. Pls Contact Software Vendor.", "Prime")
    '        ''        Exit Sub

    '        ''    End If
    '        ''Else
    '        ''    Me.Login.Enabled = False
    '        ''    smartobj.alertwindow(Me.Page, "Application Not Registered. Pls Contact Software Vendor.", "Prime")
    '        ''    Exit Sub

    '        ''End If
    '        If Request.QueryString("id") <> Nothing Then
    '            smartobj.alertwindow(Me.Page, Request.QueryString("id"), "Prime")
    '        End If

    '        Session("reportto") = ""
    '        Session("Userid") = ""
    '        Session("sysdate") = ""
    '        'Login.Attributes.Add("onclick", "window.open('./Authwatch.aspx',null,'width=10,height=10,x=2,y=1')")
    '        ''authenticate()
    '        getipmach()
    '        Try
    '            Dim qry As String = "select sys_date,sys_phase from tbl_system where node_Id = " & TenantId & ""
    '            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
    '                Session("sysdate") = dr!sys_date
    '                Session("sysphase") = dr!sys_phase
    '            Next

    '        Catch ex As Exception

    '            smartobj.alertwindow(Me.Page, "Error occurred...", "Prime")
    '            logger.Info("Default.aspx: txtCoopID_TextChanged" _
    '& vbNewLine & "   <<<<Direction: OUTPUT" _
    '& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
    '& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
    '& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
    '& vbNewLine & "******************************************************************************************************")
    '        End Try
    '    End If
    'End Sub
End Class
