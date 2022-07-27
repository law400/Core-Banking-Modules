Imports System.Data.SqlClient
Imports System.Data

Partial Class Services_Subscriberdetail
    Inherits System.Web.UI.Page
    Dim bll As New BusinessLayer.BLL
    Dim objDT As System.Data.DataTable
    Dim objDR As System.Data.DataRow
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            ' ''txtconstring.Text = "Data Source=.;Initial Catalog=alertz" _
            ' ''                                  & ";User Id=sa;Password=password;"
            Dim seldetail As String = "exec [proc_selfrequency] "
            smartobj.loadComboValues("--Choose a Frequency--", drpfrequency, seldetail)

            Dim seldetail2 As String = "exec [proc_Accounttype]"
            smartobj.loadComboValues("--Choose Accounttype--", Me.drpaccttype, seldetail2)

            If Request.QueryString("id") <> Nothing Then
                Me.txtkey.Text = Request.QueryString("id")
                showdetail()
            End If

          
            Panel6.Visible = True
        End If
    End Sub
    Sub showdetail()
        Try
            Dim seldetail As String = "exec [proc_selfrequency] "
            smartobj.loadComboValues("--Choose a Frequency--", drpfrequency, seldetail)

            Dim seldetail2 As String = "exec [proc_Accounttype] "
            smartobj.loadComboValues("--Choose Accounttype--", Me.drpaccttype, seldetail2)



            Dim str As String = "exec proc_selSubscriberid '" & Me.txtkey.Text.Trim & "'"
            Dim freq As String = bll.SQLRecordDs(str).Rows(0).Item("Acct_Type").ToString.Trim
            ' Me.txtkey.Text = bll.SQLRecordDs(str).Rows(0).Item("subscriber_key").ToString
            Me.txtacctno.Text = bll.SQLRecordDs(str).Rows(0).Item("Acct_No").ToString.Trim
            Me.txtacctname.Text = bll.SQLRecordDs(str).Rows(0).Item("Account_Title").ToString.Trim
            Me.drpaccttype.SelectedValue = bll.SQLRecordDs(str).Rows(0).Item("Acct_Type").ToString.Trim
            Me.drpdservicetype.SelectedValue = bll.SQLRecordDs(str).Rows(0).Item("Service_Type").ToString
            Me.txtperiods.Text = bll.SQLRecordDs(str).Rows(0).Item("period").ToString.Trim
            Me.drpfrequency.SelectedValue = bll.SQLRecordDs(str).Rows(0).Item("Frequency").ToString.Trim
            Me.txt_childprocedure.Text = bll.SQLRecordDs(str).Rows(0).Item("child_procedure").ToString.Trim
            Me.txt_parentprocedure.Text = bll.SQLRecordDs(str).Rows(0).Item("parent_procedure").ToString.Trim
            Me.txtconstring1.Text = bll.SQLRecordDs(str).Rows(0).Item("custom_msgdesc").ToString.Trim
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UpdateParameterDisplay()

        Using myConnection As New SqlConnection
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings("AlertZ").ConnectionString

            Dim myCommand As New SqlCommand
            myCommand.Connection = myConnection
            myCommand.CommandText = txt_childprocedure.Text.Trim
            myCommand.CommandType = Data.CommandType.StoredProcedure

            myConnection.Open()
            SqlCommandBuilder.DeriveParameters(myCommand)
            myConnection.Close()

            blInputParameters.Items.Clear()
            blOutputParameters.Items.Clear()

            Dim inputParamList As New List(Of SqlParameter)

            For Each param As SqlParameter In myCommand.Parameters
                If param.Direction = Data.ParameterDirection.Input OrElse param.Direction = Data.ParameterDirection.InputOutput Then
                    blInputParameters.Items.Add(param.ParameterName & " - " & param.SqlDbType.ToString())
                    inputParamList.Add(param)
                Else
                    blOutputParameters.Items.Add(param.ParameterName & " - " & param.SqlDbType.ToString())
                End If
            Next

            'Bind the list of input parameters to the GridView
            gvParameters.DataSource = inputParamList
            gvParameters.DataBind()
        End Using


    End Sub





    ''Protected Sub RDmessage_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RDmessage.SelectedIndexChanged
    ''    Try
    ''        Dim seldetail As String = "exec [proc_selDispatchtype_msgtyp] '" & Me.RDmessage.SelectedValue & "'"
    ''        smartobj.loadRadComboValues("--Choose a Dispatch Type--", drpdispatch, seldetail)
    ''    Catch ex As Exception

    ''    End Try
    ''End Sub




    ''Protected Sub ChkList_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ChkList.SelectedIndexChanged
    ''    Try
    ''        txtconstring1.Text += Me.ChkList.SelectedItem.Text
    ''    Catch ex As Exception

    ''    End Try
    ''End Sub

    Protected Sub btnExecSproc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExecSproc.Click
        'Show the results
        Panel4.Visible = True
        Panel3.Visible = True
        Me.Panel3.CollapseMode = Ext.Net.CollapseMode.Default
        Me.Panel4.CollapseMode = Ext.Net.CollapseMode.Default

        Dim constr As String = txtconstring.Text.Trim
        'Execute the sproc w/the parameter values
        Using myConnection As New SqlConnection
            myConnection.ConnectionString = constr
            Dim myCommand As New SqlCommand
            myCommand.Connection = myConnection
            myCommand.CommandText = txt_childprocedure.Text.Trim
            myCommand.CommandTimeout = 50000
            myCommand.CommandType = Data.CommandType.StoredProcedure

            'Get the parameter values from the grid
            For Each gvRow As GridViewRow In gvParameters.Rows
                'Determine the parameter name
                Dim paramName As String = gvParameters.DataKeys(gvRow.RowIndex).Value.ToString()
                Dim paramValue As Object = DBNull.Value

                'Get the TextBox in the row
                Dim paramValueTextBox As TextBox = CType(gvRow.FindControl("ParameterValue"), TextBox)
                If Not String.IsNullOrEmpty(paramValueTextBox.Text) Then
                    paramValue = paramValueTextBox.Text
                End If


                'Add the parameter name/value pair to the SqlCommand
                myCommand.Parameters.AddWithValue(paramName, paramValue)
            Next

            'myConnection.Open()

            '' ''Dim reader As SqlDataReader = myCommand.ExecuteReader()
            '' ''While reader.Read
            '' ''    Dim ss As String = reader.GetName(0).ToString
            '' ''    Dim ss1 As String = reader.GetName(1).ToString
            '' ''End While
            'gvtablecolumn.DataSource = myCommand.ExecuteReader()
            'gvtablecolumn.DataBind()
            'myConnection.Close()

            myConnection.Open()
            ''RdList.DataSource = myCommand.ExecuteReader()
            ''RdList.DataBind()

            Dim dt As New DataTable()
            dt.Columns.Add("FieldColumn", Type.GetType("System.String"))
            Dim b1 As New BoundField
            Dim inputParamList As New ArrayList
            Dim reader As SqlDataReader = myCommand.ExecuteReader()
            Dim count As Integer = reader.FieldCount
            Dim i As Integer = 0
            While reader.HasRows

                Dim ss As String = reader.GetName(i).ToString()
                '' inputParamList.Add(reader.GetName(i).ToString())
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1)("FieldColumn") = reader.GetName(i).ToString()



                i += 1
                If i = count Then
                    Exit While
                End If
            End While

            gvFields.DataSource = dt
            gvFields.DataBind()

            ''GridView1.DataSource = inputParamList
            ''GridView1.DataBind()
            gvFields.Visible = True
            myConnection.Close()

        End Using

    End Sub

    Protected Sub btnReset_Click(sender As Object, e As System.EventArgs) Handles btnReset.Click
        smartobj.Clear_Controls(Me.Page)
        gvFields.Visible = False
    End Sub


    Protected Sub txt_childprocedure_TextChanged(sender As Object, e As System.EventArgs) Handles txt_childprocedure.TextChanged
        Try
            Panel3.Visible = False
            Panel4.Visible = False

            UpdateParameterDisplay()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click

        Try
            Dim retval As Integer = 0
            Dim retmsg As String = ""

            Dim strins As String = "declare @retval int,@retmsg varchar(100) exec Proc_insSubscriber "
            strins = strins & "'" & Me.txtkey.Text.Trim & " '," _
                  & "'" & Me.txtacctno.Text.Trim & " '," _
                     & "'" & Me.txtacctname.Text.Trim & " ', " _
                       & "'" & Me.drpaccttype.SelectedValue.Trim & " '," _
                        & "'" & Me.drpdservicetype.SelectedValue.Trim & " '," _
                          & "'" & Me.txtperiods.Text.Trim & " '," _
                       & "'" & Me.drpfrequency.SelectedValue.Trim & " ',1," _
                         & "'" & Me.txt_childprocedure.Text.Trim & " '," _
                          & "'" & Me.txt_parentprocedure.Text.Trim & " '," _
                            & "'" & Me.txtconstring1.Text.Trim & " '," _
                     & "'" & Profile.Username & "',@retval output,@retmsg output select @retval,@retmsg"

            For Each dr In bll.SQLRecordDs(strins).Rows
                retval = dr.Item(0).ToString
                retmsg = dr.Item(1).ToString
            Next


            smartobj.alertwindow(Me.Page, retmsg, "AlertZ")

            If retval = 0 Then
                Dim i As Int32 = gvFields.Rows.Count

                For Each gvRow As GridViewRow In gvFields.Rows
                    Dim oldname As String = gvFields.DataKeys(gvRow.RowIndex).Value.ToString()
                    Dim newname As TextBox = DirectCast(gvRow.FindControl("FieldValue"), TextBox)
                    'Dim oldname As String = gvFields.Rows(k).Cells(1).Text

                    Dim strinsphone As String = "exec Proc_insubscription_column '" & Me.txtkey.Text.Trim & "','" & newname.Text.Trim & "','" & oldname & "'"
                    bll.SQLRecordDs(strinsphone)

                Next

            End If
        Catch ex As Exception

        End Try

    End Sub
    Sub keygen()
        Me.txtkey.Text = Me.txtacctno.Text.Trim & Me.drpdservicetype.SelectedValue.Trim
    End Sub
    Protected Sub txtacctno_TextChanged(sender As Object, e As System.EventArgs) Handles txtacctno.TextChanged
        Try
            keygen()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub drpdservicetype_SelectedIndexChanged(o As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles drpdservicetype.SelectedIndexChanged
        keygen()
        servicedetail()
    End Sub
    Sub servicedetail()
        Try
            Me.Panel3.CollapseMode = Ext.Net.CollapseMode.Default
            Me.Panel4.CollapseMode = Ext.Net.CollapseMode.Default
            Me.Panel5.CollapseMode = Ext.Net.CollapseMode.Default
            Me.Panel6.CollapseMode = Ext.Net.CollapseMode.Default
            txtconstring.Text = ""
            Dim dr As Data.DataRow
            Dim seldetail As String = "exec proc_selServicetypeid '" & Me.drpdservicetype.SelectedValue.Trim & "'"
            dr = bll.SQLRecordDs(seldetail).Rows(0)
            Me.txtconstring.Text = dr.Item("connectionstring").ToString
            Me.txtperiods.Text = dr.Item("period").ToString
            drpfrequency.SelectedValue = dr.Item("frequency").ToString
            txt_childprocedure.Text = dr.Item("child_procedure").ToString
            Me.txt_parentprocedure.Text = dr.Item("parent_procedure").ToString
            txtconstring1.Text = dr.Item("defaultmsg").ToString
        Catch ex As Exception

        End Try



    End Sub
    Protected Sub SqlDataSource2_Inserted(sender As Object, e As SqlDataSourceStatusEventArgs)
        '  lblMessage.Text = "Record Inserted"
    End Sub
    Protected Sub GridView1_RowUpdated(sender As Object, e As GridViewUpdatedEventArgs)
        'lblMessage.Text = "Record Updated"
    End Sub
    Protected Sub GridView1_RowDeleted(sender As Object, e As GridViewDeletedEventArgs)
        ' lblMessage.Text = "Record Deleted"
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Try
            If e.CommandName = "Add" Then
                Dim itemdesc1 As String = DirectCast(GridView1.FooterRow.FindControl("Fitemdesc"), TextBox).Text
                Dim itemdesc2 As String = DirectCast(GridView1.FooterRow.FindControl("Fdracct"), TextBox).Text
                ''Dim strcategory As String = DirectCast(GridView1.FooterRow.FindControl("fcategories1"), DropDownList).Text


                SqlDataSource2.InsertParameters("subscriber_key").DefaultValue = Me.txtkey.Text.Trim
                SqlDataSource2.InsertParameters("phone").DefaultValue = itemdesc1
                SqlDataSource2.InsertParameters("email").DefaultValue = itemdesc2
                ''SqlDataSource2.InsertParameters("message_type").DefaultValue = strcategory

                SqlDataSource2.Insert()
            ElseIf (e.CommandName = "NoDataInsert") Then
                Dim itemdesc1 As String = DirectCast(GridView1.Controls(0).Controls(0).FindControl("NoCategories1"), TextBox).Text
                Dim itemdesc2 As String = DirectCast(GridView1.Controls(0).Controls(0).FindControl("NoCategories2"), TextBox).Text
                ''Dim strcategory As String = DirectCast(GridView1.Controls(0).Controls(0).FindControl("NoCategories3"), DropDownList).Text

                SqlDataSource2.InsertParameters("subscriber_key").DefaultValue = Me.txtkey.Text.Trim
                SqlDataSource2.InsertParameters("phone").DefaultValue = itemdesc1
                SqlDataSource2.InsertParameters("email").DefaultValue = itemdesc2
                ''SqlDataSource2.InsertParameters("message_type").DefaultValue = strcategory

                SqlDataSource2.Insert()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub gvFields_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvFields.SelectedIndexChanged
        Try

            Dim dd As String = gvFields.SelectedValue

            txtconstring1.Text += "{{" & dd & "}}"
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load1(sender As Object, e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            If Session("Roleid") > 1 Then
                Response.Redirect("Default.aspx")
            End If
        End If
    End Sub
End Class
