Imports System.Web.UI.WebControls
Partial Class CustomerService_ReceiptList
    Inherits SessionCheck
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
    Sub bind1()
        Dim selBind As String = "Select * from tbl_supplyrecord where status='" & "U" & "'"

        If con.SqlDs(selBind).Tables(0).Rows.Count > 0 Then
            GridView1.DataSource = con.SqlDs(selBind)
            GridView1.DataBind()
            Me.GridView1.Visible = True
        Else
            Me.GridView1.Visible = False
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = "CUSTOMER SERVICE"
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim

        If Page.IsPostBack = False Then
            
            bind1()
        End If
    End Sub

    Protected Sub BtnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSubmit.Click
        Dim gvIDs As String = ""
        Dim chkBox As Boolean = False
        For Each gv As GridViewRow In GridView1.Rows
            Dim selectedChkBxItem As CheckBox = CType(gv.FindControl("Check1"), CheckBox)
            If selectedChkBxItem.Checked Then
                chkBox = True
                gvIDs = CType(gv.FindControl("LblDoc1"), Label).Text.ToString
                If chkBox Then
                    Try
                        Dim strval As String = "Declare @retval int,@retmsg varchar(100) Exec Proc_ReceiptAuth '" & gvIDs & "','" & Profile.Userid & "'," & _
                            "@retval Output,@retmsg Output Select @retval,@retmsg"
                        For Each dr As Data.DataRow In con.SqlDs(strval).Tables(0).Rows
                            retval = dr(0).ToString
                            retmsg = dr(1).ToString
                        Next
                        smartobj.alertwindow(Me.Page, retmsg, "Prime")
                        smartobj.ClearWebPage(Me.Page)
                        Me.BtnSubmit.Enabled = False
                    Catch ex As Exception
                        smartobj.alertwindow(Me.Page, "Server Error", "Prime")
                        smartobj.ClearWebPage(Me.Page)
                    End Try
                End If
            End If
        Next
        bind1()
    End Sub
End Class
