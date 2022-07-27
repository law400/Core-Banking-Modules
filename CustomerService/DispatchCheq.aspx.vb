Imports System.Web.UI.WebControls
Partial Class CustomerService_DispatchCheq
    Inherits SessionCheck
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = "CUSTOMER SERVICE"
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        If Page.IsPostBack = False Then

            bind2()
        End If


    End Sub
    Sub bind2()
        Dim selBind As String = "select accountnumber,b.typedesc,c.branchname 'source',c.branchname 'Destin',a.numberofleaves,valuedate from tbl_CheqRequest a,tbl_checkbooks b,tbl_branch c where a.chktype=b.typeid and a.sourcebr=c.branchcode and a.destbr=c.branchcode and a.status=2"
        If con.SqlDs(selBind).Tables(0).Rows.Count > 0 Then
            GridView2.DataSource = con.SqlDs(selBind)
            GridView2.DataBind()
            Me.GridView2.Visible = True
        Else
            Me.GridView2.Visible = False
        End If

    End Sub

    Protected Sub BtnReturn2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReturn2.Click
        Response.Redirect("Default.aspx")
    End Sub
 
    Protected Sub Btnsubmit2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsubmit2.Click
        Dim gvIDs As String = ""
        Dim chkBox As Boolean = False
        Try

            Dim qry As String = "select cast(sys_date as datetime)sys_date,sys_phase from tbl_system"
            For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                latesttime = CDate(dr!sys_date)
            Next

        Catch
            smartobj.alertwindow(Me.Page, "Data Warnning error...", "Prime")
            Exit Sub
        End Try
        If IsDate(latesttime) Then
            latesttime = latesttime.AddHours(Now.Hour)
            latesttime = latesttime.AddMinutes(Now.Minute)
            latesttime = latesttime.AddSeconds(Now.Second)
            'latesttime = Format(CDate(latesttime.Date), "MM/dd/yyyy hh:mm:ss")
        End If

        For Each gv As GridViewRow In GridView2.Rows
            Dim selectedChkBxItem As CheckBox = CType(gv.FindControl("Check1"), CheckBox)
            If selectedChkBxItem.Checked Then
                chkBox = True
                gvIDs = CType(gv.FindControl("LblDoc1"), Label).Text.ToString
                If chkBox Then
                    Try
                        Dim updMicr As String = "Update tbl_CheqRequest set status=4,dispatchdate='" & latesttime & "' where accountnumber='" & gvIDs & "'"
                        con.SqlDs(updMicr)

                    Catch ex As Exception

                    End Try
                End If
            End If
        Next

        smartobj.alertwindow(Me.Page, "Cheque Dispatched to Branches", "Prime")
        smartobj.ClearWebPage(Me.Page)


        bind2()
    End Sub
End Class
