Imports System.Data
Imports System.Web.UI.WebControls

Partial Class CustomerService_CustomerBalance
    Inherits SessionCheck
    Dim qry As String = ""
    Dim retmsg As String = ""
    Dim retval As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim l As Label = CType(Page.Master.FindControl("Label3"), Label)
        l.Text = ""
        Dim ll As Label = CType(Page.Master.FindControl("Label4"), Label)
        ll.Text = "ACCOUNT BALANCE" & Request.QueryString("menu")
        Page.Header.Title = ll.Text.Trim
        Dim menuname As System.Web.UI.WebControls.Label = CType(Page.Master.FindControl("lbldisplay"), System.Web.UI.WebControls.Label)

        menuname.Text = Request.QueryString("XXX")
        If menuname.Text = "" Then
            Response.Redirect("~/Unauthorize.aspx")
        End If

        If Validate_Access(menuname.Text) = 0 Then
            Response.Redirect("~/Unauthorize.aspx")
        End If
        If Page.IsPostBack = False Then
            hypAccount.NavigateUrl = "javascript:accountPicker('document.aspnetForm." + txtAccountno.ClientID.ToString() + "');"

        End If
    End Sub
    Function Validate_Access(ByVal MenuName As String) As Integer

        qry = " declare @retVal int " & vbNewLine
        qry = qry & "execute Proc_RM_Validate "
        qry = qry & smartobj.EncoteWithSingleQuote(Session("Roleid")) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(MenuName) & ","
        qry = qry & smartobj.EncoteWithSingleQuote(Session("Userid")) & ",@retVal OUTPUT," & Session("node_ID") & " "
        qry = qry & " select @retVal"

        For Each dr As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
            retval = dr(0).ToString
        Next
        Return retval
    End Function
    Dim ds As New DataSet
    Dim da As SqlClient.SqlDataAdapter
    Dim ds2 As New DataSet
    Dim da2 As SqlClient.SqlDataAdapter
    Dim strSQL As String
    '<asp:ImageField DataImageUrlField="imgFile" HeaderText="Photo"></asp:ImageField>
    ''da = New SqlClient.SqlDataAdapter(strSQL, myConnection)
    ''        da.Fill(ds)
    ''        ds.Tables(0).Columns.Add("imgFile")
    ''        For Each tempRow As DataRow In ds.Tables(0).Rows
    ''            tempRow.Item("imgFile") = ("getimg2.aspx?id=" & tempRow.Item("mandateid"))

    ''        Next

    ''        GridView1.DataSource = ds
    ''        GridView1.DataBind()
    Protected Sub chkEnableMultiple_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEnableMultiple.CheckedChanged
        If chkEnableMultiple.Checked = True Then
            Me.txtAccountno.TextMode = TextBoxMode.MultiLine
            Me.Label1.Visible = True
            txtAccountno.AutoPostBack = False
            Me.chkEnableMultiple0.Enabled = False

        Else
            Me.txtAccountno.TextMode = TextBoxMode.SingleLine
            Me.Label1.Visible = False
            txtAccountno.AutoPostBack = True
            Me.chkEnableMultiple0.Enabled = True


        End If
    End Sub
    Function FormatURL(ByVal strArgument As String) As String
        Return ("getimg.aspx?id=" & strArgument)
    End Function
    'Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        Dim idval As Integer
    '        idval = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "mandateid"))
    '        If idval <> 0 Then

    '            Image1.Visible = True
    '            Image1.ImageUrl = FormatURL(idval)
    '        Else
    '            Image1.Visible = False

    '        End If
    '    End If

    'End Sub
    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        If chkEnableMultiple.Checked = True Then
            Dim selmain As String = "exec [Proc_multiCustAcctDetail] '" & Me.txtAccountno.Text.Trim & "', " & Session("node_ID") & ""
            Me.GridMain1.DataSource = con.SqlDs(selmain).Tables(0)
            Me.GridMain1.DataBind()
            Me.GridMain1.Visible = True
            ''Me.GridMain1.Visible = False

            txtAccountno.AutoPostBack = False


        Else
            If Me.chkEnableMultiple0.Checked = True Then
                Dim selmain As String = "exec [Proc_oneCustIDDetail] '" & Me.txtAccountno.Text.Trim & "', " & Session("node_ID") & ""
                Me.GridMain1.DataSource = con.SqlDs(selmain).Tables(0)
                Me.GridMain1.DataBind()
                Me.GridMain1.Visible = True
                txtAccountno.AutoPostBack = True
            Else
                Dim selmain As String = "exec [Proc_oneCustAcctDetail] '" & Me.txtAccountno.Text.Trim & "', " & Session("node_ID") & ""
                Me.GridMain1.DataSource = con.SqlDs(selmain).Tables(0)
                Me.GridMain1.DataBind()
                Me.GridMain1.Visible = True
                txtAccountno.AutoPostBack = True
            End If


        End If

    End Sub

    Protected Sub txtAccountno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountno.TextChanged
        Try


            If Me.txtAccountno.TextMode = TextBoxMode.SingleLine Then
                If Me.chkEnableMultiple0.Checked = True Then
                    Dim selExist As String = "Exec Proc_CustIDDetail '" & Me.txtAccountno.Text.Trim & "'," & Session("node_ID") & ""
                    If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then

                    Else
                        smartobj.alertwindow(Me.Page, "CustomerID Does Not Exist", "Prime")

                        Exit Sub
                    End If
                Else
                    Dim retval As Integer
                    Dim retmsg As String = ""
                    Dim selfind As String = "declare @retval int,@retmsg varchar(22) exec proc_ValidOldAcct '" & Me.txtAccountno.Text.Trim & "',@retval output,@retmsg output, " & Session("node_ID") & " select @retval,@retmsg"
                    For Each dr As Data.DataRow In con.SqlDs(selfind).Tables(0).Rows
                        retval = dr(0).ToString
                        retmsg = dr(1).ToString
                    Next

                    If retval = "0" Then
                        Me.txtAccountno.Text = retmsg
                    End If

                    Dim selExist As String = "Exec Proc_CustAcctDetail '" & Me.txtAccountno.Text.Trim & "', " & Session("node_ID") & ""
                    If con.SqlDs(selExist).Tables(0).Rows.Count > 0 Then

                    Else
                        smartobj.alertwindow(Me.Page, "Account Number Does Not Exist", "Prime")

                        Exit Sub
                    End If
                End If

                txtAccountno.AutoPostBack = True
            Else
                txtAccountno.AutoPostBack = False

            End If

        Catch ex As Exception

        End Try
        Me.GridMain1.Visible = False

    End Sub

    Protected Sub chkEnableMultiple0_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEnableMultiple0.CheckedChanged
        If chkEnableMultiple0.Checked = False Then
            txtAccountno.AutoPostBack = False
            Me.chkEnableMultiple.Enabled = False

        Else
            txtAccountno.AutoPostBack = True
            Me.chkEnableMultiple0.Enabled = True

        End If
    End Sub
    Sub Clear()
        txtAccountno.Text = ""
        GridMain1.DataSource = Nothing
        GridMain1.DataBind()
    End Sub
    Protected Sub btnreset0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnreset0.Click
        Me.chkEnableMultiple.Enabled = True
        Me.chkEnableMultiple0.Enabled = True
        Clear()
    End Sub

    'Protected Sub btnReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReturn.Click
    '    Response.Redirect("Default.aspx")
    'End Sub


    'Protected Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
    '    If Session("node_ID") = Nothing Then
    '        Response.Redirect("../PageExpire.aspx")
    '    Else
    '        Me.MasterPageFile = "~/Tenant" + Session("node_ID").ToString + "/Tenant.master"

    '    End If
    'End Sub
End Class
