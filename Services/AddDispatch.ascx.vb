Imports System.Data.SqlClient

Partial Class Services_AddDispatch
    Inherits System.Web.UI.UserControl
    Dim bll As New BusinessLayer.BLL
    Protected Sub RDmessage_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RDmessage.SelectedIndexChanged
        checkdetail()
    End Sub
    Sub checkdetail()
        Try
            If Me.RDmessage.SelectedValue = 1 Then
                Panel1.Visible = True
                Panel2.Visible = False
            Else
                Panel2.Visible = True
                Panel1.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            '' smartobj.Clear_Controls(Me.Page)
            'detail2()
            RDmessage.SelectedValue = 1

            Panel1.Visible = True
            Panel2.Visible = False

        End If
    End Sub
    Protected Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click
        Try
            Dim retval As Integer = 0
            Dim retmsg As String = ""

            'If Me.drpdesc.SelectedValue <> "" Then
            ''Membership.GetUser.UserName
            ' ''Dim strins As String = "Proc_insDispatch"

            ' ''Dim ss As String = Me.drpdesc.Text
            ' ''Dim dr As SqlDataReader
            ' ''dr = bll.ParamdrOutput(strins, smartobj.MNS(Me.drpdesc.Text.Trim), _
            ' ''             smartobj.MNS(RDmessage.SelectedValue), 1, _
            ' ''            smartobj.MNS(txtreorder.Text.Trim), _
            ' ''            smartobj.MNS(txtemail.Text.Trim), _
            ' ''            smartobj.MNS(txtphone.Text.Trim), _
            ' ''            smartobj.MNS(txtwebsite.Text.Trim), _
            ' ''            smartobj.MNS(RDUsage.SelectedValue), _
            ' ''            smartobj.MNS(txtgateway.Text.Trim), _
            ' ''            smartobj.MNS(txtdllfile.Text.Trim), _
            ' ''            smartobj.MNS(txtfunction.Text.Trim), _
            ' ''            smartobj.MNS(Me.txtsmstpserver.Text.Trim), _
            ' ''            12, _
            ' ''            0, _
            ' ''            smartobj.MNS(txtusername.Text.Trim), _
            ' ''            smartobj.MNS(txtpassword.Text.Trim), _
            ' ''            smartobj.MNS(txtemail.Text.Trim), 0, _
            ' ''            "admin")


            ' ''While dr.Read
            ' ''    retval = dr.GetValue(0)

            ' ''    retmsg = dr.GetValue(1)
            ' ''End While
            Dim seldesc As String = ""
            If Me.drpdesc.SelectedValue = Nothing Then
                seldesc = Me.drpdesc.Text.Trim
            Else
                seldesc = Me.drpdesc.SelectedItem.Text
            End If

            Dim chkval As Integer
            If Me.chk1.Checked = True Then
                chkval = 1
            Else
                chkval = 0
            End If
            Dim strins As String = "declare @retval int,@retmsg varchar(100) exec Proc_insDispatch "
            strins = strins & "'" & seldesc & " '," _
                     & "'" & RDmessage.SelectedValue & "', 1," _
                       & "'" & txtreorder.Text.Trim & "'," _
                       & "'" & txtemail.Text.Trim & "'," _
                       & "'" & txtphone.Text.Trim & " '," _
                       & "'" & txtwebsite.Text.Trim & "'," _
                       & "'" & RDUsage.SelectedValue & "'," _
                       & "'" & txtgateway.Text.Trim & "'," _
                        & "'" & txtrescode.Text.Trim & " '," _
                       & "'" & txtdllfile.Text.Trim & " '," _
                       & "'" & txtfunction.Text.Trim & " '," _
                       & "'" & Me.txtsmstpserver.Text.Trim & " ','" & Me.txtportno.Text.Trim & "','" & chkval & "'," _
                        & "'" & txtusername.Text.Trim & " '," _
                        & "'" & txtpassword.Text.Trim & " '," _
                       & "'" & txtemail.Text.Trim & "', 0,'" & Profile.Username & "',@retval output,@retmsg output select @retval,@retmsg"

            retmsg = bll.SQLRecordDs(strins).Rows(0).Item(1).ToString

            smartobj.alertwindow(Me.Page, retmsg, "AlertZ")
            'End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        Try

            If txtrescode.Text = "" Then
                smartobj.alertwindow(Me.Page, "Enter Response Code", "AlertZ")
                Exit Sub
            End If
            Dim res As String = SMS(Me.txttestmessage.Text, Me.txttestPhone.Text)
            If res = txtrescode.Text Then
                smartobj.alertwindow(Me.Page, "Gateway OK", "AlertZ")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function SMS(ByVal message As String, ByVal receiverList As String) As String
        Try


            Dim strTitle As String = ""
            Dim strPost As String = Me.txtgateway.Text.Trim
            ''  webClient.DownloadString(strPost)
            ''If (index = strPost.IndexOf("from")) <> -1 Then

            ''End If
            ''Dim i As Integer
            ''While (strPost.IndexOf("{{phone}}") <> -1)
            ''    'strPost = strPost.Substring(strPost.IndexOf("{{phone}}")).Replace(strPost, receiverList)

            ''    i += 1
            ''End While

            For i As Integer = 0 To strPost.Split(" ").Length - 1 Step 1
                If (strPost.Split(" ")(i).ToLower().Contains("{{phone}}")) Then
                    strPost = strPost.Replace("{{phone}}", receiverList)
                End If

                If (strPost.Split(" ")(i).ToLower().Contains("{{msg}}")) Then
                    strPost = strPost.Replace("{{msg}}", message)
                End If
            Next


            Dim wc As New System.Net.WebClient
            Dim sr As New System.IO.StreamReader(wc.OpenRead(strPost))
            Dim strHtml As String
            ''Dim regLink As New System.Text.RegularExpressions.Regex("\""(?<url>[^\""]*)\""")
            ''Dim regTitle As New System.Text.RegularExpressions.Regex(">(.*?)\<")
            ''Dim regHref As New System.Text.RegularExpressions.Regex("\<a href=""(.*?)""\>(.*?)\<\/a\>")


            strHtml = sr.ReadToEnd

            sr.Close()

            wc.Dispose()

            Return strHtml
        Catch ex As Exception

            Dim ss As String = ex.Message
        End Try
    End Function
    Protected Sub btnReset_Click(sender As Object, e As System.EventArgs) Handles btnReset.Click
        smartobj.Clear_Controls(Me.Page)
    End Sub
    'Protected Sub drpdesc_SelectedIndexChanged(o As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles drpdesc.SelectedIndexChanged
    '    Try
    '        detail()
    '    Catch ex As Exception

    '    End Try
    ' End Sub

    
End Class
