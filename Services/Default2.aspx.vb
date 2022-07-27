Imports System.Data.SqlClient

Partial Class Services_Default2
    Inherits System.Web.UI.Page
    Dim bll As New BusinessLayer.BLL
    Dim objDT As System.Data.DataTable
    Dim objDR As System.Data.DataRow
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
             ' ''txtconstring.Text = "Data Source=.;Initial Catalog=alertz" _
            ' ''                                  & ";User Id=sa;Password=password;"
            makeCart()

            Dim seldetail As String = "exec [proc_selfrequency] "
            smartobj.loadComboValues("--Choose a Frequency--", drpfrequency, seldetail)

            Panel6.Visible = True
        End If
    End Sub
    Function makeCart()
        objDT = New System.Data.DataTable("Cart")
        objDT.Columns.Add("ID", GetType(Integer))
        objDT.Columns("ID").AutoIncrement = True
        objDT.Columns("ID").AutoIncrementSeed = 1

        objDT.Columns.Add("Phone", GetType(Integer))
        objDT.Columns.Add("Email", GetType(String))
        objDT.Columns.Add("Message_type", GetType(String))

        Session("Cart") = objDT
    End Function

    Sub Delete_Item(s As Object, e As DataGridCommandEventArgs)
        objDT = Session("Cart")
        objDT.Rows(e.Item.ItemIndex).Delete()
        Session("Cart") = objDT

        dg.DataSource = objDT
        dg.DataBind()

        ' ''Dim regorder As String = "exec roomorderitemdelete " & Me.DropDownList1.SelectedValue & "," & Me.DropDownList3.SelectedItem.Text & "," & CInt(txtQuantity.Text) & ""
        ' ''con.SqlDs(regorder)



    End Sub

    Sub reset_Item()
        objDT = Nothing


        dg.DataSource = objDT
        dg.DataBind()


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

    Protected Sub RdList_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RdList.SelectedIndexChanged
        Try
            'txtconstring1.Text += Server.HtmlEncode("<" & Me.RdList.SelectedItem.Text & ">")
            txtconstring1.Text += "{{" & Me.RdList.SelectedItem.Text & "}}"
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnExecSproc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExecSproc.Click
        'Show the results
        Panel4.Visible = True
        Panel3.Visible = True

        bll.sqlUserId = "sa"
        bll.sqlUserPassword = "password"
        bll.sqlInitialCatalog = "alertz"
        Dim constr As String = bll.buildConnectString(1)
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
            RdList.Items.Clear()
            myConnection.Open()
            ''RdList.DataSource = myCommand.ExecuteReader()
            ''RdList.DataBind()
            Dim b1 As New BoundField
            Dim inputParamList As New ArrayList
            Dim reader As SqlDataReader = myCommand.ExecuteReader()
            Dim count As Integer = reader.FieldCount
            Dim i As Integer = 0
            While reader.HasRows

                ''Dim b As BoundField = New BoundField()
                Dim ss As String = reader.GetName(i).ToString()
                inputParamList.Add(reader.GetName(i).ToString())

                RdList.Items.Add(reader.GetName(i).ToString())

                i += 1
                If i = count Then
                    Exit While
                End If
            End While

            gvFields.DataSource = inputParamList
            gvFields.DataBind()

            ''GridView1.DataSource = inputParamList
            ''GridView1.DataBind()
            gvFields.Visible = True
            myConnection.Close()

        End Using
   
    End Sub
    
   

    

    

    Protected Sub btnReset_Click(sender As Object, e As System.EventArgs) Handles btnReset.Click
        smartobj.Clear_Controls(Me.Page)
    End Sub


    Protected Sub txt_childprocedure_TextChanged(sender As Object, e As System.EventArgs) Handles txt_childprocedure.TextChanged
        Try
            Panel3.Visible = False
            Panel4.Visible = False

            UpdateParameterDisplay()
        Catch ex As Exception

        End Try
    End Sub

   

    Protected Sub btnAdd_Click(sender As Object, e As System.EventArgs) Handles btnAdd.Click
        objDT = Session("Cart")
        Dim blnMatch As Boolean = False
        Dim msgtype = Me.drpmsgtype.SelectedItem.Text
       


        objDR = objDT.NewRow
        objDR("phone") = Me.txtphone.Text.Trim
        objDR("email") = Me.txtemail.Text.Trim
        objDR("message_type") = msgtype


        objDT.Rows.Add(objDR)

        Session("Cart") = objDT

        dg.DataSource = objDT
        dg.DataBind()
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
              
                Dim i As Integer = dg.Items.Count
                For k = 0 To i - 1
                    Dim id As String = dg.Items(k).Cells(1).Text
                    Dim phone As String = dg.Items(k).Cells(2).Text
                    Dim email As String = dg.Items(k).Cells(3).Text
                    Dim msgtype As Decimal = dg.Items(k).Cells(4).Text

                    Dim strinsphone As String = "exec Proc_insubscription_detail '" & Me.txtkey.Text.Trim & "','" & Profile.Username & "','" & id & "'," & phone & ",'" & email & "','" & msgtype & "'"
                    bll.SQLRecordDs(strinsphone)



                Next
            End If

            'End If
        Catch ex As Exception

        End Try
      
    End Sub
    Sub keygen()
        Me.txtkey.Text = Me.txtacctno.Text & " " & Me.drpdservicetype.SelectedValue.Trim
    End Sub
    Protected Sub txtacctno_TextChanged(sender As Object, e As System.EventArgs) Handles txtacctno.TextChanged
        Try
            keygen()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub drpdservicetype_SelectedIndexChanged(o As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles drpdservicetype.SelectedIndexChanged
        keygen()
    End Sub
End Class
