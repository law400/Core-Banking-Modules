Imports System.Data.SqlClient
Imports System.Data

Partial Class Services_ServiceType
    Inherits System.Web.UI.Page
    Dim bll As New BusinessLayer.BLL
    Protected Sub RdConnect_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RdConnect.SelectedIndexChanged
        Try
            If Me.RdConnect.SelectedValue = 1 Then
                Panel1.Visible = True
                Panel2.Visible = False
                Panel5.Visible = True

            Else
                Panel2.Visible = True
                Panel1.Visible = False
                Panel5.Visible = False
                Panel4.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            RdConnect.SelectedValue = 1
            ' ''txtconstring.Text = "Data Source=.;Initial Catalog=alertz" _
            ' ''                                  & ";User Id=sa;Password=password;"
            Panel1.Visible = True
            Panel2.Visible = False

            Dim seldetail As String = "exec [proc_selfrequency] "
            smartobj.loadComboValues("--Choose a Frequency--", drpfrequency, seldetail)

            Dim seldetail2 As String = "exec [proc_selDispatchtype] "
            smartobj.loadRadComboValues("--Choose a Dispatch Type--", drpdispatch, seldetail2)
        End If
    End Sub
    Private Sub UpdateParameterDisplay()
        If Me.drpdatabase.SelectedValue = 1 Then
            'Get the parameters for the selected stored procedure
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

            If seldesc = "" Then
                smartobj.alertwindow(Me.Page, "No Service Type Selected", "AlertZ")
                Exit Sub
            End If
            Dim strins As String = "declare @retval int,@retmsg varchar(100) exec Proc_insservicetype "
            strins = strins & "'" & seldesc & " '," _
                     & "'" & RdConnect.SelectedValue & " ', 0," _
                       & "'" & drpdispatch.SelectedValue & " '," _
                        & "'" & Me.txtperiods.Text.Trim & " '," _
                       & "'" & drpfrequency.SelectedValue & " '," _
                       & "'" & Me.txtconstring.Text.Trim & " '," _
                       & "'" & txt_childprocedure.Text.Trim & " '," _
                        & "'" & txt_parentprocedure.Text.Trim & " '," _
                       & "'" & txtconstring1.Text.Trim & " '," _
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

                    Dim strinsphone As String = "exec Proc_inservice_detail '" & seldesc & "','" & newname.Text.Trim & "','" & oldname & "'"
                    bll.SQLRecordDs(strinsphone)
               
                Next

            End If
            'End If
        Catch ex As Exception

        End Try
    End Sub
    Sub dbdetail()
        Try
            bll.sqlDataSource = Me.txtserver.Text.Trim
            bll.sqlUserId = Me.txtusername.Text.Trim
            bll.sqlUserPassword = Me.txtpassword.Text.Trim
            bll.sqlInitialCatalog = Me.txtdatase.Text.Trim
            Me.txtconstring.Text = bll.buildConnectString(Me.drpdatabase.SelectedValue.Trim)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub drpdatabase_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles drpdatabase.SelectedIndexChanged
        dbdetail()
    End Sub

    Protected Sub txtserver_TextChanged(sender As Object, e As System.EventArgs) Handles txtserver.TextChanged
        dbdetail()
    End Sub

    Protected Sub txtusername_TextChanged(sender As Object, e As System.EventArgs) Handles txtusername.TextChanged
        dbdetail()
    End Sub
    Protected Sub txtdatase_TextChanged(sender As Object, e As System.EventArgs) Handles txtdatase.TextChanged
        dbdetail()
    End Sub
    Protected Sub txtpassword_TextChanged(sender As Object, e As System.EventArgs) Handles txtpassword.TextChanged
        dbdetail()
    End Sub

    Protected Sub btntest_Click(sender As Object, e As System.EventArgs) Handles btntest.Click
        Try
            Dim msg As String = ""
            If Me.drpdatabase.SelectedValue = 1 Then
                msg = bll.ConnectMSSQL(Me.txtconstring.Text.Trim)

            ElseIf Me.drpdatabase.SelectedValue = 2 Then

            End If

            smartobj.alertwindow(Me.Page, msg, "AlertZ")
        Catch ex As Exception

        End Try
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

    ''Protected Sub RdList_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RdList.SelectedIndexChanged
    ''    Try
    ''        'txtconstring1.Text += Server.HtmlEncode("<" & Me.RdList.SelectedItem.Text & ">")
    ''        txtconstring1.Text += "{{" & Me.RdList.SelectedItem.Text & "}}"
    ''    Catch ex As Exception

    ''    End Try
    ''End Sub

    Protected Sub btnExecSproc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExecSproc.Click
        Try
            'Show the results
            Panel4.Visible = True
            Panel4.CollapseMode = Ext.Net.CollapseMode.Default
            Panel3.Visible = True
            Panel3.CollapseMode = Ext.Net.CollapseMode.Default

            If Me.drpdesc.SelectedValue <> Nothing Then
                process_sqlparameter()
            Else
                If Me.drpdatabase.SelectedValue = 1 Then
                    process_sqlparameter()

                End If
            End If
            

        Catch ex As Exception

        End Try
    End Sub
    Sub process_sqlparameter()
        Using myConnection As New SqlConnection
            myConnection.ConnectionString = Me.txtconstring.Text.Trim
            Dim myCommand As New SqlCommand
            myCommand.Connection = myConnection
            myCommand.CommandText = txt_childprocedure.Text.Trim
            myCommand.CommandTimeout = 50000
            myCommand.CommandType = Data.CommandType.StoredProcedure

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
            ''RdList.Items.Clear()
            myConnection.Open()
            ''RdList.DataSource = myCommand.ExecuteReader()
            ''RdList.DataBind()
            Dim b1 As New BoundField
            ''Dim inputParamList As New ArrayList

            Dim dt As New DataTable()
            dt.Columns.Add("FieldColumn", Type.GetType("System.String"))


            Dim reader As SqlDataReader = myCommand.ExecuteReader()
            Dim count As Integer = reader.FieldCount
            Dim i As Integer = 0
            While reader.HasRows

                ''Dim b As BoundField = New BoundField()
                Dim ss As String = reader.GetName(i).ToString()
                '' inputParamList.Add(reader.GetName(i).ToString())
                dt.Rows.Add()
                dt.Rows(dt.Rows.Count - 1)("FieldColumn") = reader.GetName(i).ToString()
                ''RdList.Items.Add(reader.GetName(i).ToString())

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
    Sub dbdetail2()
        Try
            bll.sqlDataSource = Me.txturl0.Text.Trim
            bll.sqlInitialCatalog = Me.txtfunction.Text.Trim
            Me.txtconstring.Text = bll.buildConnectString2
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txturl0_TextChanged(sender As Object, e As System.EventArgs) Handles txturl0.TextChanged
        dbdetail2()
    End Sub

    Protected Sub txtfunction_TextChanged(sender As Object, e As System.EventArgs) Handles txtfunction.TextChanged
        dbdetail2()
    End Sub


    Protected Sub drpdesc_SelectedIndexChanged(o As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles drpdesc.SelectedIndexChanged
        detail()
    End Sub

    Sub detail()
        Try
            Dim dr As Data.DataRow
            Dim seldetail As String = "exec proc_selServicetypeid '" & Me.drpdesc.SelectedValue.Trim & "'"
            dr = bll.SQLRecordDs(seldetail).Rows(0)
            Me.drpdesc.SelectedValue = dr.Item("description").ToString
            RdConnect.SelectedValue = dr.Item("datasource").ToString
            drpdispatch.SelectedValue = dr.Item("message_type").ToString
            Me.txtperiods.Text = dr.Item("period").ToString
            drpfrequency.SelectedValue = dr.Item("frequency").ToString
            Me.txtconstring.Text = dr.Item("connectionstring").ToString
            txt_childprocedure.Text = dr.Item("child_procedure").ToString
            Me.txt_parentprocedure.Text = dr.Item("parent_procedure").ToString
            txtconstring1.Text = dr.Item("defaultmsg").ToString
        Catch ex As Exception

        End Try



    End Sub

    Protected Sub btnReset_Click(sender As Object, e As System.EventArgs) Handles btnReset.Click
        Try
            smartobj.Clear_Controls(Me.Page)
            Me.gvFields.Visible = False 
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub txt_childprocedure_TextChanged(sender As Object, e As System.EventArgs) Handles txt_childprocedure.TextChanged
        Try
            Panel3.Visible = False
            Panel4.Visible = False

            UpdateParameterDisplay()
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
End Class
