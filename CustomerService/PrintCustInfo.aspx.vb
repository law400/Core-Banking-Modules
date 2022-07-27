Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Partial Class CustomerService_trying
    Inherits SessionCheck
    Private MyCon As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Prime").ConnectionString)

    Sub search()

        Try
            ' loadlist()
            Dim sql1 As String = "exec Proc_Printdetail '" & Me.txtAcctNo.Text.Trim & "'"
            'Me.txtCustomerid.ReadOnly = True

            If con.SqlDs(sql1).Tables(0).Rows.Count > 0 Then
                'MultiView1.Visible = True
                drx = con.SqlDs(sql1).Tables(0).Rows(0)
                Profile.Custtype = drx.Item("customertype").ToString.Trim

            Else
                Panel6.Visible = False
                Panel7.Visible = False
                Exit Sub
            End If

            If Profile.Custtype = "1" Then
                Panel6.Visible = True
                Panel7.Visible = False
                refresh()
                refresh2()
                drx = con.SqlDs(sql1).Tables(0).Rows(0)

                If drx.Item("title").ToString.Trim <> "" Then
                    Me.Lbl_Title.Text = drx.Item("title").ToString.Trim

                End If

                If drx.Item("sector").ToString.Trim <> "" Then
                    Me.Lbl_Sec.Text = drx.Item("sector").ToString.Trim

                End If
                Me.Lbl_AcctNo.Text = txtAcctNo.Text.Trim
                Me.Lbl_Type.Text = drx.Item("type").ToString.Trim
                Me.Lbl_Product.Text = drx.Item("Product").ToString.Trim
                Me.Lbl_Surname.Text = drx.Item("surname").ToString.Trim
                Me.Lbl_other.Text = drx.Item("othername").ToString.Trim
                Me.Lbl_first.Text = drx.Item("firstname").ToString.Trim
                Me.Lbl_Edu.Text = drx.Item("edulevel").ToString.Trim

                Dim dob As String = drx.Item("dob").ToString
                If dob <> Nothing Then
                    If dob = "01/01/1900 12:00:00" Then
                        Lbl_DOB.Text = ""
                    Else
                        Me.Lbl_DOB.Text = drx.Item("dob").ToString.Trim

                    End If
                End If

                If drx.Item("sex").ToString.Trim <> "" Then
                    Me.Lbl_sex.Text = drx.Item("sex").ToString

                End If

                If drx.Item("nationality").ToString.Trim <> "" Then
                    Me.Lbl_Nat.Text = drx.Item("nationality").ToString

                End If

                If drx.Item("state").ToString.Trim <> "" Then
                    Me.Lbl_Sta.Text = drx.Item("state").ToString.Trim

                End If
                Me.Lbl_Occ.Text = drx.Item("occupation").ToString.Trim.Trim
                Me.Lbl_ResidentAddy.Text = drx.Item("address").ToString.Trim
                Me.Lbl_OfficeAddy.Text = drx.Item("address2").ToString.Trim

                'Me.txtsignacct.Text = drx.Item("signacct").ToString.Trim

                'If txtsignacct.Text <> "" Then
                '    Me.txtsignacct.Visible = True
                '    Me.Label8.Visible = True
                '    Me.Label7.Visible = True
                '    Me.CheckBox2.Checked = True
                'Else
                '    Me.CheckBox2.Checked = False
                '    Me.txtsignacct.Visible = False
                '    Me.Label8.Visible = False
                '    Me.Label7.Visible = False
                'End If

                If drx.Item("residentstatecode").ToString.Trim <> "" Then
                    Me.Lbl_Resstate.Text = drx.Item("residentstatecode").ToString.Trim

                End If

                If drx.Item("residenttowncode").ToString.Trim <> "" Then
                    Me.Lbl_ResTown.Text = drx.Item("residenttowncode").ToString.Trim

                End If
                Me.Lbl_Mob.Text = drx.Item("phone1").ToString.Trim
                Me.Lbl_OfficePho.Text = drx.Item("phone3").ToString.Trim
                Me.Lbl_HomePho.Text = drx.Item("phone4").ToString.Trim
                Me.Lbl_Email.Text = drx.Item("email").ToString.Trim
                Me.Lbl_NextofKin.Text = drx.Item("nextofkin").ToString.Trim
                Me.Lbl_NKinPho.Text = drx.Item("nextofkinphone").ToString.Trim
                Me.Lbl_NextofKinAddy.Text = drx.Item("nextofkinaddr").ToString.Trim
                'Me.txtrefname.Text = drx.Item("refname").ToString.Trim
                'Me.txtrefphone.Text = drx.Item("refphone").ToString.Trim


                If drx.Item("idtype").ToString.Trim <> "" Then
                    Me.Lbl_IDType.Text = drx.Item("idtype").ToString.Trim

                End If

                Dim iss As String = drx.Item("idissuedate").ToString.Trim
                If iss <> Nothing Then
                    If iss = "01/01/1900 12:00:00" Then
                        Lbl_IDDate.Text = ""
                    Else
                        Me.Lbl_IDDate.Text = drx.Item("idissuedate").ToString.Trim
                    End If
                End If
                Me.Lbl_IDNo.Text = drx.Item("idno").ToString.Trim
                Dim exps As String = drx.Item("idexprydate").ToString.Trim
                If exps <> Nothing Then
                    If exps = "01/01/1900 12:00:00" Then
                        Me.Lbl_IDExp.Text = ""
                    Else
                        Me.Lbl_IDExp.Text = drx.Item("idexprydate").ToString.Trim
                    End If
                End If
                'Me.txtOfficer.Text = drx.Item("acctofficer").ToString.Trim
                Dim intro As String = drx.Item("type").ToString.Trim
                'Me.DrpIntro.SelectedValue = intro
                'Me.chksms.Checked = smartobj.encodeCkeckBox(drx("smsalert"))

                'Me.txtIntroID.Text = drx.Item("introducer").ToString.Trim
                Dim dd As String = drx.Item("groupcode").ToString.Trim
                Dim rr As String = drx.Item("relid").ToString.Trim

                'If dd <> "" Or dd <> Nothing Then
                '    Me.ChkGroup.Checked = True
                '    Me.DrpGroup.SelectedValue = dd
                '    Me.DrpGroup.Visible = True
                'Else
                '    Me.ChkGroup.Checked = False
                '    Me.DrpGroup.SelectedValue = Nothing
                '    Me.DrpGroup.Visible = False

                'End If

                'If rr <> "" Or rr <> Nothing Then
                '    Me.CheckBox1.Checked = True
                '    Me.txtcustid.Text = rr
                '    Me.txtcustid.Visible = True
                'Else
                '    Me.CheckBox1.Checked = False
                '    Me.txtcustid.Text = ""
                '    Me.txtcustid.Visible = False

                'End If

                ''Dim selcust As String = "Select Surname+' '+Firstname+' '+ othername 'name' from tbl_customer where customerid='" & intro & "'"
                ''If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                ''    For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                ''        Me.txtIntroID.Text = dr!name.ToString
                ''    Next

                ''    selcust = "Select fullname from tbl_userprofile where userid='" & intro & "'"
                ''    If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                ''        For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                ''            Me.txtIntroID.Text = dr!fullname.ToString
                ''        Next

                ''    End If

                ''End If



            Else
                Panel6.Visible = False
                Panel7.Visible = True
                refreshCorporate()
                refreshCorporate2()
                Me.Lbl_AcctNo0.Text = txtAcctNo.Text.Trim
                Me.Lbl_Type0.Text = drx.Item("type").ToString.Trim
                Me.Lbl_CompName.Text = drx.Item("fullname").ToString.Trim
                Me.Lbl_Product0.Text = drx.Item("Product").ToString.Trim
                'Me.DrpCustType0.SelectedValue = "2"

                Dim dob As Date = drx.Item("dob").ToString
                If dob <> Nothing Then
                    If dob = "01/01/1900" Then
                        Lbl_DOB0.Text = ""
                    Else
                        Me.Lbl_DOB0.Text = drx.Item("dob").ToString.Trim

                    End If
                End If



                If drx.Item("nationality").ToString.Trim <> "" Then
                    Me.Lbl_Nat0.Text = drx.Item("nationality").ToString

                End If

                Me.Lbl_RegNo.Text = drx.Item("rcno").ToString
                Me.Lbl_ContactPerson.Text = drx.Item("contactperson").ToString
                If drx.Item("state").ToString.Trim <> "" Then
                    Me.Lbl_Sta0.Text = drx.Item("state").ToString.Trim

                End If
                Me.Lbl_OfficeAddy0.Text = drx.Item("address").ToString.Trim



                If drx.Item("residenttowncode").ToString.Trim <> "" Then
                    Me.Lbl_ResTown0.Text = drx.Item("residenttowncode").ToString.Trim

                End If
                Me.Lbl_Mob0.Text = drx.Item("phone1").ToString.Trim
                Me.Lbl_OfficePho0.Text = drx.Item("phone2").ToString.Trim
                Me.Lbl_HomePho0.Text = drx.Item("phone3").ToString.Trim
                'Me.txtcomePhone4.Text = drx.Item("phone4").ToString.Trim
                Me.Lbl_Email0.Text = drx.Item("email").ToString.Trim
                'Me.txtcontact.Text = drx.Item("contactperson").ToString.Trim

                'Me.chksms0.Checked = smartobj.encodeCkeckBox(drx("smsalert"))

                'Me.txtCompOffc.Text = drx.Item("acctofficer").ToString.Trim
                'Me.txtCompintro.Text = drx.Item("introducer").ToString.Trim
                'Dim intro As String = drx.Item("type").ToString.Trim
                'Me.drpintro2.SelectedValue = intro

                ''Dim selcust As String = "Select Surname+' '+Firstname+' '+ othername 'name' from tbl_customer where customerid='" & intro2 & "'"
                ''If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                ''    For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                ''        Me.txtCompintro.Text = dr!name.ToString
                ''    Next

                ''    selcust = "Select fullname from tbl_userprofile where userid='" & intro2 & "'"
                ''    If con.SqlDs(selcust).Tables(0).Rows.Count > 0 Then
                ''        For Each dr As Data.DataRow In con.SqlDs(selcust).Tables(0).Rows
                ''            Me.txtCompintro.Text = dr!fullname.ToString
                ''        Next

                ''    End If

                ''End If

            End If

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtAcctNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcctNo.TextChanged
        Try
            Panel6.Visible = False
            Panel7.Visible = False
            search()


        Catch ex As Exception

        End Try
    End Sub
    Private Function FetchAllImagesInfo() As DataTable
        Dim Sql As String = "Exec Proc_SelMandateInfo '" & Me.txtAcctNo.Text.Trim & "'"
        Dim da As SqlDataAdapter = New SqlDataAdapter(Sql, MyCon)
        Dim dt As DataTable = New DataTable()
        da.Fill(dt)
        Return dt

    End Function
    Sub refresh()
        Try
            GridView1.DataSource = FetchAllImagesInfo()
            GridView1.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub refresh2()
        Try
            GridView2.DataSource = FetchAllImagesInfo()
            GridView2.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub refreshCorporate()
        Try
            GridView3.DataSource = FetchAllImagesInfo()
            GridView3.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub refreshCorporate2()
        Try
            GridView4.DataSource = FetchAllImagesInfo()
            GridView4.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        'l.Text = "CUSTOMER SERVICE"
        'Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        'll.Text = "->" & Request.QueryString("menu")
        'Page.Header.Title = ll.Text.Trim


        Me.Hypsearch.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtAcctNo.ClientID.ToString() + "');"
        If Page.IsPostBack = False Then
            If Request.QueryString("id") <> Nothing Then
                Me.txtAcctNo.Text = Request.QueryString("id")

            End If
        End If
    End Sub

    
    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Response.Redirect("Default.aspx")

    End Sub
End Class
