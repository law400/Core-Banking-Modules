Imports System.Web.UI.WebControls
Partial Class CustomerService_RequestList
    Inherits SessionCheck
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = "CUSTOMER SERVICE"
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
       
        If Page.IsPostBack = False Then
        

            Dim Dstring2 As String = "SELECT cast(ltrim(rtrim(Requestid)) as varchar) Requestid,Requestdesc FROM tbl_Requesttype where status=1"
            smartobj.loadComboValues("--Select a Request Type--- ", Me.DrpReqType, Dstring2)

            Dim Dstring3 As String = "SELECT cast(ltrim(rtrim(typeid)) as varchar) typeid,typedesc FROM tbl_checkbooks where status=1"
            smartobj.loadComboValues("--Select a CheckBook Type--- ", Me.DrpChecktype, Dstring3)

            Dim Dstring5 As String = "SELECT cast(ltrim(rtrim(SupplierID)) as varchar) Supplierid,Suppliername FROM tbl_supplier where status=1"
            smartobj.loadComboValues("--Select a Supplier Type--- ", Me.DrpSupplier, Dstring5)


            If Request.QueryString("ID") <> "" Then
                MultiView1.ActiveViewIndex = 1
                'Else
                '    MultiView1.ActiveViewIndex = 0
            End If

            'If MultiView1.ActiveViewIndex = 0 Then
            '    Me.GridView1.Visible = True
            '    Me.GridView2.Visible = False

            '    bind1()
            'Else
            '    Me.GridView2.Visible = True
            '    Me.GridView1.Visible = False
            '    bind2()
            'End If


        End If
    End Sub
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
    Sub bind2()
        Dim selBind As String = "select accountnumber,b.typedesc,c.branchname 'source',c.branchname 'Destin',numberofleaves,valuedate from tbl_CheqRequest a,tbl_checkbooks b,tbl_branch c where a.chktype=b.typeid and a.sourcebr=c.branchcode and a.destbr=c.branchcode and a.status='" & "A" & "'"
        If con.SqlDs(selBind).Tables(0).Rows.Count > 0 Then
            GridView2.DataSource = con.SqlDs(selBind)
            GridView2.DataBind()
            Me.GridView2.Visible = True
        Else
            Me.GridView2.Visible = False
        End If
       
    End Sub

    Sub bind3()
        Dim selBind As String = "Exec Proc_SupplyRangeDetail '" & Me.txtReceiptid.Text.Trim & "'"
        If con.SqlDs(selBind).Tables(0).Rows.Count > 0 Then
            GridView3.DataSource = con.SqlDs(selBind)
            GridView3.DataBind()
            Me.GridView3.Visible = True
            Me.Btnsubmit1.Enabled = False
        Else
            Me.GridView3.Visible = False
            Me.Btnsubmit1.Enabled = True

        End If
        
    End Sub
    Protected Sub DrpReqType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpReqType.SelectedIndexChanged

        MultiView1.ActiveViewIndex = Me.DrpReqType.SelectedValue.Trim - 1

        If MultiView1.ActiveViewIndex = 0 Then
            Me.GridView1.Visible = True
            Me.GridView2.Visible = False

            bind1()
        ElseIf MultiView1.ActiveViewIndex = 1 Then
            Me.GridView2.Visible = True
            Me.GridView1.Visible = False
            bind2()

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

    Protected Sub Btnsubmit2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsubmit2.Click
        'Response.Redirect("ManageCheckBook.aspx?Chk=" & 1)
    End Sub

    Protected Sub txtReceiptid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReceiptid.TextChanged
        Dim selrecipt As String = "Select * from tbl_Supplyrecord where receiptid='" & Me.txtReceiptid.Text.Trim & "'"
        If con.SqlDs(selrecipt).Tables(0).Rows.Count > 0 Then
            For Each dr As Data.DataRow In con.SqlDs(selrecipt).Tables(0).Rows
                Me.DrpSupplier.SelectedValue = dr!supplyid.ToString.Trim
                Me.txtQty.Text = dr!qty.ToString.Trim
                Me.DrpSupplier.SelectedValue = dr!supplyid.ToString.Trim
                Me.DrpSupplier.Enabled = False
                Me.txtCost.Text = dr!cost.ToString.Trim
                Me.txtStartNo.Text = dr!startno.ToString.Trim
                Me.txtEndNo.Text = dr!endno.ToString.Trim
                Me.txtDateReceived.Text = Format(CDate(dr!valuedate.ToString.Trim), "dd/MM/yyyy")
                Me.txtWayBill.Text = dr!waybill.ToString.Trim
                Me.txtOrder.Text = dr!orderno.ToString.Trim

            Next
            bind3()
            'Me.BtnSubmit1.Enabled = True

        Else
            smartobj.alertwindow(Me.Page, "Supply Receipt Not Valid", "Prime")
            Me.BtnSubmit1.Enabled = False
        End If
    End Sub

    Protected Sub BtnSubmit1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSubmit1.Click
        Try
            'Dim valuedate As String
            latesttime = System.DateTime.Parse(Me.txtDateReceived.Text)
            ' valuedate = Date.Parse(MyTrans1, MyCultureInfo)
            'latesttime = CDate(valuedate)

            If Me.DrpChecktype.SelectedValue = Nothing Or Me.DrpChecktype.SelectedValue = "" Then
                smartobj.alertwindow(Me.Page, "Please Select a Check Book Type", "Prime")
                smartobj.ClearWebPage(Me.Page)
                Exit Sub
            End If
            If IsDate(latesttime) Then
                latesttime = latesttime.AddHours(Now.Hour)
                latesttime = latesttime.AddMinutes(Now.Minute)
                latesttime = latesttime.AddSeconds(Now.Second)
                'latesttime = Format(CDate(latesttime.Date), "MM/dd/yyyy hh:mm:ss")
            End If
            If Me.txtReceiptid.Text = "" Then
                Me.txtReceiptid.Text = 0
            End If

            Dim strval As String = "Declare @retval int,@retmsg varchar(100) Exec Proc_Supplyrange '" & Me.txtReceiptid.Text.Trim & "','" & Profile.Userid & "'," & _
                 "'" & Me.txtStartNo.Text.Trim & "','" & Me.txtEndNo.Text.Trim & "','" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "','" & Me.DrpChecktype.SelectedValue.Trim & "',@retval Output,@retmsg Output Select @retval,@retmsg"
            For Each dr As Data.DataRow In con.SqlDs(strval).Tables(0).Rows
                retval = dr(0).ToString
                retmsg = dr(1).ToString
            Next
            smartobj.alertwindow(Me.Page, retmsg, "Prime")
            smartobj.ClearWebPage(Me.Page)
            Me.Btnsubmit1.Enabled = False
            bind3()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        smartobj.ClearWebPage(Me.Page)
        Me.Btnsubmit1.Enabled = True
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub BtnReturn2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReturn2.Click
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub BtnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReturn.Click

    End Sub
End Class
