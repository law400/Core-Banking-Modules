Imports System.Drawing
Imports System.Drawing.Bitmap
Imports System.Web.UI
Imports Ext.Net
Imports Ext.Net.Utilities
Partial Class PrimeApp
    Inherits System.Web.UI.MasterPage
    Private _userName As String = ""

    Private _enablepersonalization As Boolean = False
    'Private _lable2 As Label

    Public Property enablepersonalization() As Boolean

        Get

            Return _enablepersonalization

        End Get

        Set(ByVal Value As Boolean)

            _enablepersonalization = Value

        End Set

    End Property
    Public Shared Sub ShowAlertMessage(ByVal Page As Page, ByVal Msg As String, ByVal PageToRedirect As String)
        Dim sbJavascript As New StringBuilder()

        Dim Value As String = "alert('" & Msg & "');"
        Value = Value & "window.location.href='" & PageToRedirect & "';"
        sbJavascript.Append(Value)
        ScriptManager.RegisterStartupScript(Page, Page.[GetType](), "ShowAlert", sbJavascript.ToString(), True)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '' Try

        'If Page.User.Identity.IsAuthenticated = False Then
        '    Response.Redirect("Default.aspx")
        'End If
        Dim ReferrerName As String = Nothing
        ''Btn_login.Attributes.Add("onclick", "hideLayer();")
        If Not IsPostBack Then

            If Session("UserID") = Nothing Then
                ' Response.Redirect("~/PageExpire.aspx")


                Ext.Net.X.Js.Call("parent.Ext.net.DirectMethods.Redirect", "~/PageExpire.aspx")
            End If
        End If
        If Request.UrlReferrer IsNot Nothing Then
            ReferrerName = Request.UrlReferrer.Segments(Request.UrlReferrer.Segments.Length - 1)
        End If

        If ReferrerName = "" Then
            ''   Response.Redirect("~/PageExpire2.aspx")
        End If
        'If Not IsPostBack Then
        '    'set DisplaySessionTimeout() as the startup script of this page
        '    Page.ClientScript.RegisterStartupScript(Me.[GetType](), "onLoad", "DisplaySessionTimeout()", True)
        'End If
       
        If Session("UserID") = Nothing Then
            '' Response.Redirect("~/PageExpire.aspx")

            Ext.Net.X.Js.Call("parent.Ext.net.DirectMethods.Redirect", "~/PageExpire.aspx")
        End If
        'Dim EODCheck As String = "Select isnull(EODProcess,0)'EODProcess' from tbl_system with (nolock) where node_id = " & Profile.node_ID & ""
        'Dim EODValue As String = ""
        'Dim KillUser As String = "Exec SessionKll '" & Profile.Userid & "', " & Profile.node_ID & ""
        ''If con.SqlDs(EODCheck).Tables(0).Rows.Count > 0 Then
        ''    EODValue = 
        ''End If
        'For Each drx As System.Data.DataRow In con.SqlDs(EODCheck).Tables(0).Rows
        '    EODValue = drx!EODProcess.ToString
        'Next
        'If EODValue = "1" Then
        '    con.SqlDs(KillUser)
        '    ShowAlertMessage(Me.Page, "Please EOD is in Process, kindly wait for some time or contact system administrator.", "Default.aspx")
        '    Exit Sub

        'ElseIf EODValue = "2" Then
        '    con.SqlDs(KillUser)
        '    ShowAlertMessage(Me.Page, "Please EOM is in Process, kindly wait for some time or contact system administrator.", "Default.aspx")
        '    Exit Sub
        'ElseIf EODValue = "3" Then
        '    con.SqlDs(KillUser)
        '    ShowAlertMessage(Me.Page, "Please EOY is in Process, kindly wait for some time or contact system administrator.", "Default.aspx")
        '    Exit Sub

        'Else

        ''Btn_login.Attributes.Add("onclick", "hideLayer();")
        Dim QryCheck As String = "Select Userid from SessionTable with (nolock) where ltrim(rtrim(userid))='" & Profile.Userid & "' and node_id = " & Profile.node_ID & " "
        'If con.SqlDs(QryCheck).Tables(0).Rows.Count < 1 Then
        '    Response.Redirect("~/PageExpire.aspx")
        'End If

        If Response.IsClientConnected Then
            If Page.IsPostBack = "False" Then
                ' ''Me.BtnLogin.Attributes.Add("onclick", "showLayer();")
                Dim tt As String = "0"
                '  HypCalc.NavigateUrl = "javascript:calculator('document.aspnetForm." + tt.ToString() + "');"
                Me.Label1.Text = UCase(Profile.Userid)
                'Profile.sysdate = "2011-06-30"
                'Dim objdate As Object
                'objdate = Profile.sysdate
                'Me.Label2.Text = objdate.ToString

                Me.Label2.Text = Profile.sysdate
                Me.Label5.Text = UCase(Profile.reportto)
                Me.Label6.Text = UCase(Profile.fullname)


            End If



            If Request.QueryString("id") <> "" Then
                Select Case Request.QueryString("id")
                    Case 1
                        Me.Label3.Text = "SETUP"
                    Case 2
                        Me.Label3.Text = "ADMIN TASK"
                    Case 3
                        Me.Label3.Text = "CUSTOMER SERVICE"
                    Case 4
                        Me.Label3.Text = "BANKING ENTRY"
                    Case 5
                        Me.Label3.Text = "DEPOSITS"
                    Case 6
                        Me.Label3.Text = "LOANS"
                    Case 7
                        Me.Label3.Text = "REPORTS"
                    Case 140
                        Me.Label3.Text = "PLACEMENTS"

                End Select
            Else
                ''Me.Label3.Text = ""
                '' Request.QueryString("id") = Profile.parentid.ToString.Trim
            End If

            ''Dim outdata As String = ""
            ''Dim selReturnRange As String = "Select retTranmins from tbl_bank where retTranmins<>0"
            'Dim retResult As String = "Declare @retval int exec AuthorElapse '" & Profile.Userid.ToString & "',@retval Output select @retval"
            'If con.SqlDs(selReturnRange).Tables(0).Rows.Count > 0 Then

            '    Dim retran As String = "SELECT post_user FROM tabAuthorise WHERE Authorised ='" & "N" & "' AND post_user ='" & Profile.Userid.ToString & "'"
            '    If con.SqlDs(retran).Tables(0).Rows.Count > 0 Then
            '        ''retmsg from proc
            '        For Each dr As Data.DataRow In con.SqlDs(retResult).Tables(0).Rows
            '            outdata = dr(0).ToString
            '        Next

            '    End If

            '    If outdata = "0" Then
            '        smartobj.alertwindow(Me.Page, "You have Transactions Returned UnAuthorised!. Waiting Time Elaspse. Please Forward Transaction to a New Authoriser", "Prime")

            '    End If

            'End If



            Dim rtval As Integer

            Dim selexist As String = "Declare @retmsg int exec sessionlogin '" & Profile.AppStatus.Trim & "','" & Profile.Userid.Trim & "',@retmsg output, " & Profile.node_ID & " select @retmsg"
            rtval = con.SqlDs(selexist).Tables(0).Rows(0).Item(0)


            If (rtval > 1 Or rtval < 1) Then
                'Dim qrylogin As String = "update tbl_userprofile set logincount=1 where userid='" & Profile.Userid.Trim & "'"
                'con.SqlDs(qrylogin)

                'Response.Redirect("~/default.aspx?id=" & "Multiple login not Permitted")
            End If


            ''If Profile.AppStatus.Trim = "" Then

            ''    Response.Redirect("~/default.aspx?id=" & "User Session Inactive")
            ''End If


            If Profile.sysphase = "3" Then

                Dim userid As String = "Select sys_phase from tbl_system with (nolock) where userid='" & Profile.Userid.Trim & "' and node_id = " & Profile.node_ID & ""
                If con.SqlDs(userid).Tables(0).Rows.Count > 0 Then

                Else
                    ' Response.Redirect("~/default.aspx?id=" & "EOD Processing")

                End If


            End If
        End If
        ''  End If
        'Catch ex As Exception
        '    smartobj.alertwindow(Me.Page, ex.Message, "Prime")

        'End Try

    End Sub
    'Sub LoadLiteral2()
    '    Dim x As String
    '    x = "<Marquee OnMouseOver='this.stop();' OnMouseOut='this.start();' scrollamount='2'  width='80%'>"
    '    x += "&nbsp;||&nbsp;"

    '    'x += "<a href='#' OnClick=Openpopup(" + sqlRdr("Id").ToString() & ")>"

    '    x += "NEWS FLASH: PROMO! PROMO! PROMO! BUY ONE CAR GET THREE CARS"
    '    x += "BANK WITH US TO GET GOOD BENEFITS"

    '    x += "</a> &nbsp;||&nbsp; "


    '    x += "</Marquee>"


    '    Literal2.Text = x
    'End Sub
    Sub Btn_logindetail()
        Me.Label1.Text = "0"
    End Sub
End Class

