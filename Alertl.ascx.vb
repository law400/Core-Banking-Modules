
Partial Class Alertl
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        ''popupWin.ColorStyle = Switch(clrStyle.SelectedIndex = 0, EeekSoft.Web.PopupColorStyle.Red, clrStyle.SelectedIndex = 1, EeekSoft.Web.PopupColorStyle.Green, clrStyle.SelectedIndex = 2, EeekSoft.Web.PopupColorStyle.Blue, clrStyle.SelectedIndex = 3, EeekSoft.Web.PopupColorStyle.Violet)
        If Page.IsPostBack = False Then
            Dim sTemplate1 As String = "<a href=/XAAS/Authorise/Auth.aspx>{pvehdesc}{pspace}{pbranch}{pspace}{pspace1}{pdesc}{pspace}{prendate}{pspace}{prenewal}{pspace2}</a>"
            'Dim sTemplate2 As String = "<a href=/Prime/Maintenance/WorkorderOp.aspx?docid={pdoc}>{pdoc}</a>{pspace}{pvehdesc}{pspace}{pbranch}{pspace}{pspace1}{pdesc}{pspace}{prendate}{pspace}{prenewal}{pspace2}</div>"
            Dim sTemplate As String = ""
            '' Dim sTemplate3 As String = "<a href={pspace}><img src='{pImage}' />{pdoc}</a>{pspace}{pvehdesc}{pspace}{pbranch}{pspace}{pspace1}{pdesc}{pspace}{prendate}{pspace}{prenewal}{pspace2}</div>"
            Dim sTemplate3 As String = "<a href=/XAAS/News.aspx?id={pdoc}>{pvehdesc}{pspace}{pbranch}{pspace}{pspace1}{pdesc}{pspace}{prendate}{pspace}{prenewal}{pspace2}</a>"

            Dim sTemplate4 As String = "<a href=/XAAS/RejectedTran.aspx?id={pdoc}>{pvehdesc}{pspace}{pbranch}{pspace}{pspace1}{pdesc}{pspace}{prendate}{pspace}{prenewal}{pspace2}</a>"
            Dim sTemplate5 As String = "<a href=/XAAS/Unauthorised.aspx?id={pdoc}>{pvehdesc}{pspace}{pbranch}{pspace}{pspace1}{pdesc}{pspace}{prendate}{pspace}{prenewal}{pspace2}</a>"

            '' Dim sTemplate3 As String = "<table><tr><td><img src='{pImage}' /></td><td><div class='name'>{pdoc}pvehdesc</div><div class='desc'></div><div class='price'></div></td></tr></table>"
            'Response.Write("Renewal Reminders:   " & "<a href=/Prime/Operation/VehicleExpense.aspx?docid=" + doc + ">" + dr!vehicleno.ToString + "</a>" & ": " & dr!eventdesc.ToString & "</div>")
            Dim Dstring5 As String = "Exec [proc_RptReminderAlert] '" & Session("Userid").ToString.Trim & "', " & Session("node_id") & ""
            Dim dr As Data.DataRow
            Dim doc As String = ""
            For Each dr In con.SqlDs(Dstring5).Tables(0).Rows
                ''doc = dr!vehicleno.ToString
                Dim pdoc As String = dr!id.ToString
                Dim pImage As String = "../Images/ico_news.gif"
                Dim pvehdesc As String = UCase(dr!posttype.ToString)
                Dim authstatus As String = dr!authstatus.ToString

                Dim pDesc As String = UCase(dr!authdesc.ToString)
                Dim pbranch As String = "--Posted By " & dr!post_user.ToString
                Dim prenewal As String = dr!createdate.ToString

                Dim pspace As String = "    "
                Dim pspace1 As String = " ["
                Dim pspace2 As String = " ]"

                Dim prendate As String = ""


                ''sTemplate = sTemplate1


                If pvehdesc = "News" Then
                    sTemplate = sTemplate3

                ElseIf pvehdesc = "AUTHORISED" Or pvehdesc = "Authorised" Then
                    If authstatus.Trim = "U" Then
                        sTemplate = sTemplate1

                    Else
                        sTemplate = ""

                    End If
                Else

                    If authstatus.Trim = "U" Then
                        sTemplate = sTemplate5

                    Else
                        sTemplate = sTemplate4

                    End If


                End If

                pvehdesc = UCase(pvehdesc)
                Dim tpl As StringBuilder = New StringBuilder()
                tpl.Append(sTemplate)
                tpl.Replace("{pdoc}", pdoc)
                tpl.Replace("{pdesc}", pDesc)
                tpl.Replace("{pvehdesc}", pvehdesc)
                tpl.Replace("{pImage}", pImage)
                tpl.Replace("{pspace}", pspace)
                tpl.Replace("{pspace1}", pspace1)
                tpl.Replace("{pspace2}", pspace2)
                tpl.Replace("{pbranch}", pbranch)
                tpl.Replace("{prenewal}", prenewal)
                tpl.Replace("{prendate}", prendate)

                '   Show1.AddHtmlPanel(tpl.ToString())

                popupWin.HideAfter = 15000
                popupWin.Visible = True
                popupWin.Title = "UCP Alert !!!"
                popupWin.Message = tpl.ToString()
                popupWin.LinkTarget = tpl.ToString()
                popupWin.Text = ""
                popupWin.DockMode = EeekSoft.Web.PopupDocking.BottomRight
            Next

        End If
    End Sub
End Class
