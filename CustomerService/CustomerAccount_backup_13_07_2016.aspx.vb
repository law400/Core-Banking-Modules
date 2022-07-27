Imports System.Web.UI.WebControls
Imports log4net
Imports log4net.Config

Partial Class CustomerService_CustomerAccount
    Inherits System.Web.UI.Page
    Dim retmsg As String = ""
    Dim retval As Integer
    Dim qry As String = ""
    Dim logger As ILog = log4net.LogManager.GetLogger(GetType(CustomerService_CustomerAccount))
#Region "Pageload"


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Hypsearch.NavigateUrl = "javascript:customer('document.aspnetForm." + txtCustomerid.ClientID.ToString() + "');"
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = "CUSTOMER SERVICE"
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "->" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        If Page.IsPostBack = False Then
            
            Dim Dstring1 As String = "SELECT cast(ltrim(rtrim(titlecode)) as varchar) titleid,titlename FROM tbl_title where status=1"
            smartobj.loadComboValues("--Select a Title--- ", Me.DrpTitle, Dstring1)

            Dim Dstring3 As String = "SELECT cast(ltrim(rtrim(branchcode)) as varchar) branchcode,branchname FROM tbl_branch where status=1"
            smartobj.loadComboValues("--Select a Branch--- ", Me.DrpBranch, Dstring3)


            Dim Dstring4 As String = "SELECT cast(ltrim(rtrim(productcode))as varchar) productcode,productname FROM tbl_BankProduct where status=1 and productclass=1"
            smartobj.loadComboValues("--Select a Product--- ", Me.DrpProduct, Dstring4)

            Dim Dstring2 As String = "SELECT cast(ltrim(rtrim(sexcode)) as varchar) sexid,sexname FROM tbl_sex where status=1"
            smartobj.loadComboValues("--Select a Gender--- ", Me.DrpSex, Dstring2)


            Dim Daccounttier As String = "SELECT cast(ltrim(rtrim(Tier_id)) as varchar) Tier_id,Tier_name FROM tbl_Account_Tier where status=1"
            smartobj.loadComboValues("--Select an Account Tier--- ", Me.DrpAccountTier, Daccounttier)

            Dim sel As String = "select isnull(cutover,0) from tbl_bank"
            Dim val As String = con.SqlDs(sel).Tables(0).Rows(0).Item(0).ToString

            If val = "1" Then
                Me.Label15.Visible = True
                Me.txtold.Visible = True
            Else
                Me.Label15.Visible = False
                Me.txtold.Visible = False
            End If
            If Request.QueryString("id") <> "" Then
                Me.txtCustomerid.Text = Request.QueryString("id")
                Me.Hypsearch.Visible = False
                search()
            Else
                Me.Hypsearch.Visible = True

                Me.txtCustomerid.ReadOnly = False

            End If
        End If
    End Sub
#End Region
#Region "task"
    Sub search()
        Dim sql1 As String = "exec Proc_Custdetail '" & Me.txtCustomerid.Text.Trim & "'"
        'Me.txtCustomerid.ReadOnly = True
        If con.SqlDs(sql1).Tables(0).Rows.Count > 0 Then
            Me.MultiView1.ActiveViewIndex = 0
            MultiView1.Visible = True
            Me.Btnsubmit.Enabled = True
            For Each dr As Data.DataRow In con.SqlDs(sql1).Tables(0).Rows
                Me.DrpTitle.SelectedValue = dr!title.ToString.Trim
                Me.txtCustomerid.Text = dr!customerid.ToString.Trim
                Me.txtFullname.Text = dr!fullname.ToString.Trim
                Me.txtOthername.Text = dr!othername.ToString.Trim
                Me.DrpSex.SelectedValue = dr!sex.ToString.Trim
            Next
        Else
            MultiView1.Visible = False
            Me.Btnsubmit.Enabled = False

        End If
        

    End Sub
    
    
    Protected Sub txtCustomerid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustomerid.TextChanged
        Me.txtold.Text = ""
        search()
    End Sub

    Protected Sub DrpProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpProduct.SelectedIndexChanged
        Dim selExist As String = "Exec Proc_ProdDetail '" & Me.DrpProduct.SelectedValue.Trim & "'"
        If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then
             drx = con.SqlDs(selExist).Tables(0).Rows(0)
            Me.Label1.Text = drx.Item("productname").ToString
            Me.Label3.Text = drx.Item("productexpire").ToString
            Me.Label2.Text = drx.Item("productstart").ToString
            Me.Label4.Text = drx.Item("currencymne").ToString
            Me.Label5.Text = drx.Item("minbalance").ToString
            Me.Label6.Text = drx.Item("apptype").ToString
            Me.Label11.Text = drx.Item("crrate").ToString
            Me.Label10.Text = drx.Item("drrate").ToString
            Dim frt As String = drx.Item("sweepin").ToString
            Me.Label8.Text = drx.Item("closecharge").ToString
            Me.Label7.Text = drx.Item("openbalance").ToString
            Me.Label9.Text = drx.Item("mininterest").ToString
            Me.txtodamt.Text = drx.Item("penalrate").ToString

            If frt = "1" Then
                Me.txtsweep.Visible = True
                Me.Label12.Visible = True
            Else
                Me.Label12.Visible = False

                Me.txtsweep.Visible = False

            End If

            Dim prod As String = drx.Item("producttype").ToString
            If prod = "13" Then
                Me.BtnTarget.Visible = True
            Else
                Me.BtnTarget.Visible = False

            End If
            Dim fetchstaff As String = "exec proc_validStaffAcct '" & Me.DrpProduct.SelectedValue.Trim & "'"

            If con.SqlDs(fetchstaff).Tables(0).Rows.Count > 0 Then
                Me.Label13.Visible = True
                Me.txtstaffID.Visible = True
            Else
                Me.Label13.Visible = False
                Me.txtstaffID.Visible = False
            End If
           

            Me.txtcrint.Text = drx.Item("crrate").ToString
            Me.txtdrint.Text = drx.Item("drrate").ToString
            rebind1()
            rebind2()

        Else
            Me.Label1.Text = ""
            Me.Label2.Text = ""
            Me.Label3.Text = ""
            Me.Label4.Text = ""
            Me.Label5.Text = ""
            Me.Label6.Text = ""
            Me.Label7.Text = ""
            Me.Label8.Text = ""
            Me.Label9.Text = ""
            Me.Label10.Text = ""
            Me.Label11.Text = ""
            'Image1.Visible = False
            smartobj.alertwindow(Me.Page, "Product Type Does Not Exist", "Prime")

            Exit Sub
        End If

    End Sub

    Protected Sub Btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsubmit.Click
        If Me.txtdrint.Text = "" Then
            smartobj.alertwindow(Me.Page, "Please Enter a Debit interest Rate", "Prime")
            txtdrint.Focus()
            Exit Sub
        End If

        If Me.txtcrint.Text = "" Then
            smartobj.alertwindow(Me.Page, "Please Enter a Credit interest Rate", "Prime")
            txtcrint.Focus()
            Exit Sub
        End If

        If (Me.txtold.Text = "" And txtold.Visible = True) Then
            smartobj.alertwindow(Me.Page, "Enter Old Account Number", "Prime")
            txtold.Focus()
            Exit Sub
        End If

        If Me.txtodamt.Text = "" Then
            Me.txtodamt.Text = "0.0"
        End If
        If Not IsNumeric(Me.txtdrint.Text) Then
            smartobj.alertwindow(Me.Page, "Please Enter a Number Value for Debit interest Rate", "Prime")
            txtdrint.Focus()
            Exit Sub
        End If

        If Not IsNumeric(Me.txtcrint.Text) Then
            smartobj.alertwindow(Me.Page, "Please Enter a Number Value for Credit interest Rate", "Prime")
            txtcrint.Focus()
            Exit Sub
        End If

        If Me.DrpAccountTier.SelectedIndex = 0 Then
            smartobj.alertwindow(Me.Page, "Please select an Account Tier", "Prime")
            DrpAccountTier.Focus()
            Exit Sub
        End If

        Dim insacc As String = "Declare @retval int,@retmsg varchar(100) exec Proc_InsCASAAccount '" & Me.DrpBranch.SelectedValue.Trim & "'," & _
        "'" & Me.DrpProduct.SelectedValue.Trim & "','" & Me.txtCustomerid.Text.Trim & "','" & Me.txtacctdesc.Text.Trim & "','" & Me.txtdrint.Text.Trim & "'," & _
        "'" & Me.txtcrint.Text.Trim & "','" & Me.DrpSubBranch.SelectedValue.Trim & "','" & Me.txtsweep.Text.Trim & "','" & Me.txtstaffID.Text.Trim & "'," & _
        "" & smartobj.DecodeCkeckBox(Me.chkview) & "," & CDec(Me.txtodamt.Text.Trim) & ",'" & Me.txtold.Text.Trim & "','" & Profile.Userid.Trim & "',NULL,'" & Me.DrpAccountTier.SelectedValue & "',@retVal Output,@retmsg Output select @retval 'retval' ,@retmsg 'retmsg'"

        retval = 0
        retmsg = ""

        For Each dr As Data.DataRow In con.SqlDs(insacc).Tables(0).Rows
            retval = dr(0).ToString
            retmsg = dr(1).ToString
        Next


        smartobj.alertwindow(Me.Page, retmsg, "Prime")

        If retval = "0" Then
            charg(Me.txtCustomerid.Text.Trim, Me.DrpProduct.SelectedValue.Trim)
        End If

        clear()
        Me.Btnsubmit.Enabled = False
        smartobj.ClearWebPage(Me.Page)
        clear()


    End Sub
    Sub charg(ByVal custid As String, ByVal prod As String)
        Dim sqlStr As String = ""
        Dim acct_no As String = ""
       
        Dim selacct As String = "Select accountnumber from tbl_casaaccount where customerid='" & custid & "' and productcode='" & prod & "'"
        If con.SqlDs(selacct).Tables(0).Rows.Count > 0 Then
            acct_no = con.SqlDs(selacct).Tables(0).Rows(0).Item("accountnumber").ToString

        End If

        Dim prodchg As String = ""

        
        sqlStr = " declare @retval int,@retmsg varchar(150) " & vbNewLine
        sqlStr = sqlStr & "execute [Proc_Pendingcharge] "
        sqlStr = sqlStr & smartobj.EncoteWithSingleQuote(acct_no.Trim) & ","
        sqlStr = sqlStr & smartobj.EncoteWithSingleQuote(prod) & ","
        sqlStr = sqlStr & smartobj.EncoteWithSingleQuote("801") & ","
        sqlStr = sqlStr & smartobj.EncoteWithSingleQuote("100") & ","
        sqlStr = sqlStr & smartobj.EncoteWithSingleQuote(Format(CDate(Profile.sysdate), "MM-dd-yyyy")) & ","
        sqlStr = sqlStr & "'" & "001" & "',"
        sqlStr = sqlStr & smartobj.EncoteWithSingleQuote("1") & ","
        sqlStr = sqlStr & smartobj.EncoteWithSingleQuote("Sys") & ",@retVal OUTPUT,@retmsg OUTPUT "
        sqlStr = sqlStr & " select @retval,@retmsg"

        For Each dr2 As Data.DataRow In con.SqlDs(sqlStr).Tables(0).Rows
            retval = dr2(0).ToString
            retmsg = dr2(1).ToString
        Next

    End Sub
    Sub clear()
        Me.txtcrint.Text = 0
        Me.txtDRint.Text = 0
        Me.txtacctdesc.Text = ""
    End Sub
    Protected Sub BtnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReset.Click
        Me.txtCustomerid.ReadOnly = False
        Me.txtCustomerid.Text = ""
        Me.DrpBranch.SelectedValue = Nothing
        Me.DrpProduct.SelectedValue = Nothing
        Me.DrpSex.SelectedValue = Nothing
        Me.DrpTitle.SelectedValue = Nothing

        smartobj.ClearWebPage(Me.Page)
        clear()

        Me.Btnsubmit.Enabled = True
    End Sub

    'Protected Sub Btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btncancel.Click
    '    Response.Redirect("Default.aspx")
    'End Sub
#End Region

#Region "acctdoc"
    Sub rebind2()
        qry = "Exec proc_docreq1 '" & Me.DrpProduct.SelectedValue & "','" & Me.txtCustomerid.Text.Trim & "'"
        Me.GridView2.DataSource = con.SqlDs(qry).Tables(0)
        Me.GridView2.DataBind()
        If GridView2.Rows.Count > 0 Then
            Me.Btnsave1.Enabled = True
        Else
            smartobj.alertwindow(Me.Page, "No Document Attached to customer's Account", "Prime")

            Me.Btnsave1.Enabled = False

        End If
    End Sub
    Sub rebind1()

        qry = "Exec proc_docreq2 '" & Me.DrpProduct.SelectedValue & "','" & Me.txtCustomerid.Text.Trim & "'"
        Me.GridView1.DataSource = con.SqlDs(qry).Tables(0)
        Me.GridView1.DataBind()
        If GridView1.Rows.Count > 0 Then
            Me.Btnsave1.Enabled = True
        Else
            smartobj.alertwindow(Me.Page, "No Document Attached to customer's Account", "Prime")

            Me.Btnsave1.Enabled = False

        End If
    End Sub
#Region "Declaration"
    Dim chkrel As Integer
    Dim gvIDs As String = ""
    Dim chkBox As Boolean = False

#End Region
    Protected Sub Btnsave2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave2.Click
        Try
            For Each gv As GridViewRow In GridView1.Rows
                Dim selectedChkBxItem As CheckBox = CType(gv.FindControl("Check2"), CheckBox)
                If selectedChkBxItem.Checked Then
                    chkBox = True
                    gvIDs += CType(gv.FindControl("LblDoc2"), Label).Text.ToString + ","


                End If
            Next

            If chkBox Then
                Dim lt As Integer = 0

                Dim position, lposition As Integer : Dim lentrimmsg As String
                Dim InstVal(100) As String
                lposition = 0
                position = 1
                lentrimmsg = Len(gvIDs)
                Do While position <> 0

                    position = InStr(position + 1, (gvIDs), ",")
                    If position = 0 Then
                        Exit Do
                    End If
                    lentrimmsg = gvIDs.Substring(lposition, ((position - lposition) - 1))
                    lposition = position

                    Dim insval As String = "Insert into tbl_accountreq(customerid,reqid) Values ('" & Me.txtCustomerid.Text.Trim & "','" & lentrimmsg & "')"
                    con.SqlDs(insval)



                Loop
            End If
            'For Each gv As GridViewRow In GridView1.Rows
            '    Dim selectedChkBxItem As CheckBox = CType(gv.FindControl("Check2"), CheckBox)
            '    If selectedChkBxItem.Checked Then
            '        chkBox = True
            '        gvIDs += CType(gv.FindControl("LblDoc2"), Label).Text.ToString
            '        Dim insval As String = "Insert into tbl_accountreq(customerid,reqid) Values ('" & Me.txtCustomerid.Text.Trim & "','" & gvIDs & "')"
            '        con.SqlDs(insval)

            '    End If
            'Next

            smartobj.alertwindow(Me.Page, "Record Added", "Prime")
            rebind1()
            rebind2()

        Catch ex As Exception

            logger.Info("CUSTOMER SERVICE: CustomerAccount Btnsave2_Click" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
            smartobj.alertwindow(Me.Page, "Data Warning error...", "Prime")

        End Try
    End Sub

    Protected Sub Btnsave1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave1.Click
        Try
            For Each gv As GridViewRow In GridView2.Rows
                Dim selectedChkBxItem As CheckBox = CType(gv.FindControl("Check1"), CheckBox)
                If selectedChkBxItem.Checked Then
                    chkBox = True
                    gvIDs += CType(gv.FindControl("LblDoc1"), Label).Text.ToString
                    Dim insval As String = "Delete from tbl_accountreq where reqid='" & gvIDs & "' and accountnumber='" & Me.txtCustomerid.Text.Trim & "'"
                    con.SqlDs(insval)

                End If
            Next

            smartobj.alertwindow(Me.Page, "Record Removed", "Prime")
            rebind1()
            rebind2()
        Catch ex As Exception


            logger.Info("CUSTOMER SERVICE: CustomerAccount Btnsave1_Click" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
            smartobj.alertwindow(Me.Page, "Error has Occurred...", "Prime")
        End Try
    End Sub

    'Protected Sub btnreturn2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnreturn2.Click
    '    Response.Redirect("Default.aspx")
    'End Sub

    'Protected Sub Btnreturn1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreturn1.Click
    '    Response.Redirect("Default.aspx")

    'End Sub
#End Region
    
    Protected Sub DrpBranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpBranch.SelectedIndexChanged
        Try
            Dim selbranch As String = "Select subbranchcode from tbl_subbranch where mbranchcode='" & Me.DrpBranch.SelectedValue.Trim & "'"

            If con.SqlDs(selbranch).Tables(0).Rows.Count > 0 Then
                Dim Dstring33 As String = "SELECT cast(ltrim(rtrim(subbranchcode)) as varchar) subbranchcode,subbranchname FROM tbl_subbranch where mbranchcode='" & Me.DrpBranch.SelectedValue.Trim & "'"
                smartobj.loadComboValues("--Select a Sub Branch--- ", Me.DrpSubBranch, Dstring33)
                Me.DrpSubBranch.Enabled = True

            Else
                Me.DrpSubBranch.Enabled = False
            End If
           
        Catch ex As Exception
            logger.Info("CUSTOMER SERVICE: CustomerAccount DrpBranch_SelectedIndexChanged" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
            smartobj.alertwindow(Me.Page, "Error has Occurred...", "Prime")
        End Try
    End Sub

    Protected Sub txtsweep_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsweep.TextChanged
        Try
            Dim selacct As String = "select accountnumber from tbl_casaaccount where accountnumber='" & Me.txtsweep.Text.Trim & "' and status=1"
            If con.SqlDs(selacct).Tables(0).Rows.Count > 0 Then
                Dim strv As String = con.SqlDs(selacct).Tables(0).Rows(0).Item(0)
                Me.Btnsubmit.Enabled = True
            Else
                Me.Btnsubmit.Enabled = False

                smartobj.alertwindow(Me.Page, "Invalid Account Number", "Prime")
                Exit Sub
            End If
            
        Catch ex As Exception

            logger.Info("CUSTOMER SERVICE: CustomerAccount txtsweep_TextChanged" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
            smartobj.alertwindow(Me.Page, "Error has Occurred...", "Prime")
        End Try
    End Sub

    Protected Sub txtstaffID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtstaffID.TextChanged
        Try
            qry = "exec proc_Officers '" & Me.txtstaffID.Text.Trim & "'"
            Dim drprept As String = ""
            Dim hh As String = ""
            If con.SqlDs(qry).Tables(0).Rows.Count > 0 Then
                Me.Label14.Visible = True
                Me.Label14.Text = con.SqlDs(qry).Tables(0).Rows(0).Item(0).ToString
            Else
                Me.Label14.Visible = False
                Me.Label14.Text = ""
                clear()
                smartobj.alertwindow(Me.Page, "Invalid Staff ID", "Prime")
                Exit Sub
            End If
        Catch ex As Exception
            logger.Info("CUSTOMER SERVICE: CustomerAccount txtstaffID_TextChanged" _
& vbNewLine & "   <<<<Direction: OUTPUT" _
& vbNewLine & "      OUTPUT PARAMETERS LIST & " _
& vbNewLine & "           ERROR MESSAGE: '" & ex.Message & "'" _
& vbNewLine & "       OUTPUT PARAMETERS LIST END----------'" _
& vbNewLine & "******************************************************************************************************")
            smartobj.alertwindow(Me.Page, "Error has Occurred...", "Prime")
        End Try
    End Sub

    Protected Sub BtnTarget_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTarget.Click
        Response.Redirect("TargetAccount.aspx?id=" & Me.txtCustomerid.Text.Trim)
    End Sub

    Protected Sub DrpAccountTier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpAccountTier.SelectedIndexChanged
        If Me.DrpAccountTier.SelectedIndex <> 0 Then
            Dim QryString As String = "Select isnull(MaxDepositAmt,0)'MaxDepositAmt',isnull(MaxCummulativeBal,0)'MaxCummulativeBal' from tbl_Account_Tier where Tier_id = '" & Me.DrpAccountTier.SelectedValue & "'"
            If con.SqlDs(QryString).Tables(0).Rows.Count > 0 Then
                For Each dr As Data.DataRow In con.SqlDs(QryString).Tables(0).Rows
                    Me.LabelDepAmt.Visible = True
                    Me.LabelMaxCum.Visible = True
                    Me.lblMaxDepAmt.Visible = True
                    Me.lblMaxCumBal.Visible = True
                    Me.lblMaxDepAmt.Text = dr("MaxDepositAmt")
                    Me.lblMaxCumBal.Text = dr("MaxCummulativeBal")

                Next

            Else
                Me.LabelDepAmt.Visible = False
                Me.LabelMaxCum.Visible = False
                Me.lblMaxDepAmt.Visible = False
                Me.lblMaxCumBal.Visible = False
            End If
        Else
            Me.LabelDepAmt.Visible = False
            Me.LabelMaxCum.Visible = False
            Me.lblMaxDepAmt.Visible = False
            Me.lblMaxCumBal.Visible = False
        End If
    End Sub
End Class
