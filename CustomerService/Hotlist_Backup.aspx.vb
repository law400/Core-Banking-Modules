Imports System.Web.UI.WebControls
Partial Class CustomerService_Hotlist
    Inherits System.Web.UI.Page
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
    Protected Sub Btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsubmit.Click
        'Dim valuedate As String
        latesttime = system.DateTime.Parse(Me.txtValueDate.Text)
        ' valuedate = Date.Parse(MyTrans1, MyCultureInfo)
        'latesttime = CDate(valuedate)
        Try

            If IsDate(latesttime) Then
                latesttime = latesttime.AddHours(Now.Hour)
                latesttime = latesttime.AddMinutes(Now.Minute)
                latesttime = latesttime.AddSeconds(Now.Second)
                'latesttime = Format(CDate(latesttime.Date), "MM/dd/yyyy hh:mm:ss")
            End If
            Dim strval As String = ""
            If Me.RDBHotList.SelectedValue = "2" Then
                strval = "Declare @retval int,@retmsg varchar(100) Exec Proc_addHotList '" & Me.txtAcctNo3.Text.Trim.Replace("'", " ") & "'," & _
                          "'" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "','" & Me.txtStart2.Text.Trim.Replace("'", " ") & "'," & _
                          "'" & Me.txtEnd2.Text.Trim.Replace("'", " ") & "','" & Me.txtReason.Text.Trim.Replace("'", " ") & "','" & Profile.Userid.Trim & "',@retval Output,@retmsg Output Select @retval,@retmsg"

            ElseIf Me.RDBHotList.SelectedValue = "1" Then
                strval = "Declare @retval int,@retmsg varchar(100) Exec Proc_remHotList '" & Me.txtAcctNo3.Text.Trim.Replace("'", " ") & "'," & _
                          "'" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "','" & Me.txtStart2.Text.Trim.Replace("'", " ") & "'," & _
                          "'" & Me.txtEnd2.Text.Trim.Replace("'", " ") & "','" & Me.txtReason.Text.Trim.Replace("'", " ") & "','" & Profile.Userid.Trim & "',@retval Output,@retmsg Output Select @retval,@retmsg"

            End If

            For Each dr As Data.DataRow In con.SqlDs(strval).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next

            smartobj.alertwindow(Me.Page, retmsg, "Prime")
            smartobj.ClearWebPage(Me.Page)
            clear()
            Me.Btnsubmit.Enabled = False
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btncancel.Click
        smartobj.ClearWebPage(Me.Page)
        Me.Btnsubmit.Enabled = True
    End Sub
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        imgdate3.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtValueDate.ClientID.ToString() + "');"
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = "CUSTOMER SERVICE"
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        If Page.IsPostBack = False Then
            Me.txtValueDate.Text = Format(Now, "dd/MM/yyyy")
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("Default.aspx")
    End Sub
    Sub clear()
        Me.txtEnd2.Text = ""
        Me.txtStart2.Text = ""
        Me.txtReason.Text = ""
        Me.txtValueDate.Text = ""

    End Sub
    Sub search()
        Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtAcctNo3.Text.Trim & "',@retval output,@retmsg output select @retval,@retmsg"
        For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
            retval = dr(0).ToString
            retmsg = dr(1).ToString
        Next

        If retval = "0" Then
            Me.txtAcctNo3.Text = retmsg
        End If
        Dim sel As String = "Exec proc_lstcheques '" & Me.txtAcctNo3.Text.Trim & "'"
        If con.SqlDs(sel).Tables(0).Rows.Count > 0 Then
            Me.txtAcctName.Text = con.SqlDs(sel).Tables(0).Rows(0).Item("accounttitle").ToString
            Me.txtStart2.Text = con.SqlDs(sel).Tables(0).Rows(0).Item("startid").ToString
            Me.txtEnd2.Text = con.SqlDs(sel).Tables(0).Rows(0).Item("endid").ToString

        Else
            smartobj.alertwindow(Me.Page, "Account Cheque Range Not Found", "Prime")
            clear()

        End If

    End Sub
   
    Protected Sub txtAcctNo3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcctNo3.TextChanged
        search()
    End Sub
End Class
