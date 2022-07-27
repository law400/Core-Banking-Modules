Imports System.Web.UI.WebControls
Partial Class CustomerService_Receipt
    Inherits SessionCheck
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
    Protected Sub Menu1_MenuItemClick(ByVal sender As Object, _
              ByVal e As MenuEventArgs) Handles Menu1.MenuItemClick
        Try
            Dim i As Integer
            For i = 0 To Menu1.Items.Count - 1
                If i = e.Item.Value Then
                    Menu1.Items(i).ImageUrl = "~/Images/pic2.gif"
                Else
                    Menu1.Items(i).ImageUrl = "~/Images/pic1.gif"
                End If
            Next

            If e.Item.Text = "Add New" Then
                showadd()
            ElseIf e.Item.Text = "Edit" Then

                showedit()
            Else
                showlist()
            End If
        Catch ex As Exception
            smartobj.alertwindow(Me.Page, "Data Server Error....", "Prime")
        End Try
    End Sub

    Sub showadd()
        Me.BtnSubmit.Text = "Submit"
        smartobj.ClearWebPage(Me.Page)
        clear()
        Me.MultiView1.Visible = False
        BtnSubmit.Enabled = True

    End Sub
    Sub showedit()
        Me.BtnSubmit.Text = "Update"
        smartobj.ClearWebPage(Me.Page)
        clear()
        Me.MultiView1.Visible = False
        BtnSubmit.Enabled = True

    End Sub
    Sub clear()
        Me.txtReceiptid.Text = ""
        Me.DrpSupplier.SelectedValue = 0
        Me.txtOrder.Text = ""
        Me.txtQty.Text = ""
        Me.txtWayBill.Text = ""
        Me.txtCost.Text = ""
        Me.txtStartNo.Text = ""
        Me.txtEndNo.Text = ""
        Me.txtUnitPr.Text = ""
        Me.txtvariance.Text = ""

    End Sub
    Sub showlist()
        Me.MultiView1.Visible = True
        MultiView1.ActiveViewIndex = 0
        BtnSubmit.Enabled = False
    End Sub

    Protected Sub BtnSubmit1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSubmit.Click
        Try
            'Dim valuedate As String
            If Me.txtDateReceived.Text <> "" Then
                latesttime = System.DateTime.Parse(Me.txtDateReceived.Text)

            End If

            ' valuedate = Date.Parse(MyTrans1, MyCultureInfo)
            'latesttime = CDate(valuedate)

            If IsDate(latesttime) Then
                latesttime = latesttime.AddHours(Now.Hour)
                latesttime = latesttime.AddMinutes(Now.Minute)
                latesttime = latesttime.AddSeconds(Now.Second)
                'latesttime = Format(CDate(latesttime.Date), "MM/dd/yyyy hh:mm:ss")
            End If

            If Me.txtReceiptid.Text = "" Then
                Me.txtReceiptid.Text = 0
            End If

            If Me.BtnSubmit.Text = "Submit" Then
                Dim strval As String = "Declare @retval int,@retmsg varchar(100) Exec Proc_insReceipt '" & Me.txtReceiptid.Text.Trim.Replace("'", " ") & "'," & _
                       "'" & Me.DrpSupplier.SelectedValue.Trim & "','" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "','" & Me.txtOrder.Text.Trim.Replace("'", " ") & "','" & Me.txtQty.Text.Trim.Replace("'", " ") & "'," & _
                       "'" & Me.txtWayBill.Text.Trim.Replace("'", " ") & "','" & Me.txtCost.Text.Trim.Replace("'", " ") & "','" & Me.txtStartNo.Text.Trim.Replace("'", " ") & "'," & _
                       "'" & Me.txtEndNo.Text.Trim.Replace("'", " ") & "','" & Me.txtUnitPr.Text.Trim & "','" & Me.txtvariance.Text.Trim & "','" & Me.DrpChecktype.SelectedValue.Trim & "','" & Profile.Userid.Trim & "',NULL,@retVal Output,@retmsg Output Select @retval,@retmsg"
                For Each dr As Data.DataRow In con.SqlDs(strval).Tables(0).Rows
                    retval = dr(0).ToString
                    retmsg = dr(1).ToString
                Next


                smartobj.alertwindow(Me.Page, retmsg, "Prime")
                smartobj.ClearWebPage(Me.Page)
                clear()
                Me.BtnSubmit.Enabled = False

            Else
                Dim strval As String = "Declare @retval int,@retmsg varchar(100) Exec Proc_updReceipt '" & Me.txtReceiptid.Text.Trim.Replace("'", " ") & "'," & _
                       "'" & Me.DrpSupplier.SelectedValue.Trim & "','" & Format(CDate(latesttime), "MM/dd/yyyy hh:mm:ss") & "','" & Me.txtOrder.Text.Trim.Replace("'", " ") & "','" & Me.txtQty.Text.Trim.Replace("'", " ") & "'," & _
                       "'" & Me.txtWayBill.Text.Trim.Replace("'", " ") & "','" & Me.txtCost.Text.Trim.Replace("'", " ") & "','" & Me.txtStartNo.Text.Trim.Replace("'", " ") & "'," & _
                       "'" & Me.txtEndNo.Text.Trim.Replace("'", " ") & "','" & Me.txtUnitPr.Text.Trim & "','" & Me.txtvariance.Text.Trim & "','" & Me.DrpChecktype.SelectedValue.Trim & "','" & Profile.Userid.Trim & "',@retval Output,@retmsg Output Select @retval,@retmsg"

                For Each dr As Data.DataRow In con.SqlDs(strval).Tables(0).Rows
                    retval = dr(0).ToString
                    retmsg = dr(1).ToString
                Next
                smartobj.alertwindow(Me.Page, retmsg, "Prime")
                smartobj.ClearWebPage(Me.Page)
                clear()
                Me.BtnSubmit.Enabled = False

            End If
        Catch ex As Exception

        End Try

    End Sub
    Sub serchdt()
        Dim selrecipt As String = "Select * from tbl_Supplyrecord where receiptid='" & Me.txtReceiptid.Text.Trim & "'"
        If con.SqlDs(selrecipt).Tables(0).Rows.Count > 0 Then

            Dim Dstring3 As String = "SELECT cast(ltrim(rtrim(typeid)) as varchar) typeid,typedesc FROM tbl_checkbooks where status=1"
            smartobj.loadComboValues("--Select a CheckBook Type--- ", Me.DrpChecktype, Dstring3)

            For Each dr As Data.DataRow In con.SqlDs(selrecipt).Tables(0).Rows
                Me.DrpSupplier.SelectedValue = dr!SupplierID.ToString.Trim
                Me.txtQty.Text = dr!qty.ToString.Trim
                Me.txtCost.Text = CInt(dr!cost.ToString.Trim)
                Me.txtStartNo.Text = dr!startno.ToString.Trim
                Me.txtUnitPr.Text = dr!unitpr.ToString.Trim
                Me.txtvariance.Text = dr!variance.ToString.Trim
                Me.txtEndNo.Text = dr!endno.ToString.Trim
                Me.txtDateReceived.Text = Format(CDate(dr!valuedate.ToString.Trim), "dd/MM/yyyy")
                Me.txtWayBill.Text = dr!waybill.ToString.Trim
                Me.txtOrder.Text = dr!orderno.ToString.Trim
                Me.DrpChecktype.SelectedValue = dr!chktype.ToString.Trim

            Next
            Me.BtnSubmit.Enabled = True

        Else
            smartobj.alertwindow(Me.Page, "Supply Receipt Not Valid", "Prime")
            Me.BtnSubmit.Enabled = False
        End If
    End Sub
    Protected Sub txtReceiptid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReceiptid.TextChanged

        If Me.Menu1.SelectedItem.Text <> "Add New" Then
            serchdt()
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'hypAccount.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtAcctNo1.ClientID.ToString() + "');"
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = "CUSTOMER SERVICE"
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        If Page.IsPostBack = False Then
          
            Me.HyperLink2.NavigateUrl = "javascript:calendarPicker('document.aspnetForm." + txtDateReceived.ClientID.ToString() + "');"
            Dim Dstring3 As String = "SELECT cast(ltrim(rtrim(typeid)) as varchar) typeid,typedesc FROM tbl_checkbooks where status=1"
            smartobj.loadComboValues("--Select a CheckBook Type--- ", Me.DrpChecktype, Dstring3)

            Me.txtvariance.Text = 0


            Dim Dstring5 As String = "SELECT cast(ltrim(rtrim(SupplierID)) as varchar) Supplierid,Suppliername FROM tbl_supplier where status=1 and supplyitem=1"
            smartobj.loadComboValues("--Select a Supplier Type--- ", Me.DrpSupplier, Dstring5)

            

        End If
    End Sub

    Protected Sub txtCost_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCost.TextChanged
        Try
            Me.txtUnitPr.Text = Format(CDec((Me.txtCost.Text.Trim) / (Me.txtQty.Text.Trim)), "###.00")
        Catch ex As Exception

        End Try
    End Sub

   
    Protected Sub txtStartNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStartNo.TextChanged
        Me.txtEndNo.Text = (CInt(Me.txtStartNo.Text.Trim) + CInt(Me.txtQty.Text.Trim)) - 1

    End Sub


    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Me.txtReceiptid.Text = Me.GridView1.SelectedValue
        serchdt()
    End Sub


    
    Protected Sub Btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btncancel.Click
        Response.Redirect("Default.aspx")

    End Sub

    Protected Sub BtnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReset.Click
        smartobj.ClearWebPage(Me.Page)
        clear()
    End Sub
    Protected Sub txtQty_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQty.TextChanged
        Try
            Me.txtUnitPr.Text = Format(CDec((Me.txtCost.Text.Trim) / (Me.txtQty.Text.Trim)), "###.00")
        Catch ex As Exception

        End Try
    End Sub
End Class
