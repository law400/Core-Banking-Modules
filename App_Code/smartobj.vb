Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Web.UI
Imports System.Net
Imports System.IO
Imports System.Net.Mail
Public Class smartobj
    Public Shared deFaultDb As String
    Public Shared DeductionType() As String
    Public Shared DeductionMode() As String
    Public Shared RadWindowCode As String
    Public Shared RadWindowMsg As String
    Private CurrErrMsg As String
    Dim i As Integer
    Public Enum ToastType
        Success
        Info
        Warning
        [Error] 'Reserved word
    End Enum
    Public Enum ToastPosition
        TopRight
        TopLeft
        TopCenter
        TopStretch
        BottomRight
        BottomLeft
        BottomCenter
        BottomStretch
    End Enum
    Public Sub InitErrMsg()
        CurrErrMsg = ""
    End Sub
   
    Public Sub SetErrMsg(ByVal errs As String)
        InitErrMsg()
        CurrErrMsg = errs
    End Sub
    Public Function getErrMsg() As String
        Return CurrErrMsg
    End Function
    Public Shared Function sendemail(ByVal useremail As String, ByVal toaddress As String, ByVal subject As String, ByVal body As String) As String
        Dim mm As New MailMessage(useremail, toaddress)

        mm.Subject = subject
        mm.Body = body
        mm.IsBodyHtml = False

        Dim smtp As New SmtpClient

        smtp.Send(mm)

        Return True
    End Function
   
    'Private _retval As Integer
    'Public Property retval() As Integer
    '    Get
    '        Return _retval
    '    End Get
    '    Set(ByVal value As Integer)
    '        _retval = value
    '    End Set
    'End Property
    'Public Structure retMsgObj
    '    Dim retVal As Boolean
    '    Dim retMsg As String
    'End Structure
    Public Structure LowerRecord
        Dim RowAmt As String
        Dim RowFloor As String
        Dim RowCeil As String
        Dim rNo As Integer
    End Structure
    Public Shared Function FormatMoney(ByVal Dmoney As String) As String
        Dim ticno As String = ""
        Dim NamePath As String = Dmoney.Trim
        Dim NameLength1 As Integer
         Dim amount As Double
        Dim Nmoney As Double

        If NamePath <> "" Then
            Dim curval1 As String = ""
            Dim curval12 As String
            NameLength1 = InStr(1, StrReverse(NamePath), "h")

            If NameLength1 = 0 Then
                NameLength1 = InStr(1, StrReverse(NamePath), "t")
            End If

            If NameLength1 = 0 Then
                NameLength1 = InStr(1, StrReverse(NamePath), "m")
            End If

            If NameLength1 <> 0 Then
                curval1 = Mid(StrReverse(NamePath), NameLength1, 1)
                curval12 = Mid(Dmoney, 1, Len(Dmoney) - 1)
                amount = CDec(curval12)

                If curval1 = "h" Or curval1 = "H" Then
                    Nmoney = amount * 100
                ElseIf curval1 = "t" Or curval1 = "T" Then
                    Nmoney = amount * 1000
                ElseIf curval1 = "m" Or curval1 = "M" Then
                    Nmoney = amount * 1000000

                End If
            Else
                Nmoney = CDbl(Dmoney)
            End If


        End If
        Nmoney = CDbl(Nmoney)
        Return Format(CDec(Nmoney), "#,##0.00")

    End Function

    Public Shared Function FormatMoney2(ByVal Dmoney As String) As String
        Dim ticno As String = ""
        Dim NamePath As String = Dmoney.Trim
        Dim NameLength1 As Integer
        Dim amount As Double
        Dim Nmoney As Double

        If NamePath <> "" Then
            Dim curval1 As String = ""
            Dim curval12 As String
            NameLength1 = InStr(1, StrReverse(NamePath), "h")

            If NameLength1 = 0 Then
                NameLength1 = InStr(1, StrReverse(NamePath), "t")
            End If

            If NameLength1 = 0 Then
                NameLength1 = InStr(1, StrReverse(NamePath), "m")
            End If

            If NameLength1 <> 0 Then
                curval1 = Mid(StrReverse(NamePath), NameLength1, 1)
                curval12 = Mid(Dmoney, 1, Len(Dmoney) - 1)
                amount = CDec(curval12)

                If curval1 = "h" Or curval1 = "H" Then
                    Nmoney = amount * 100
                ElseIf curval1 = "t" Or curval1 = "T" Then
                    Nmoney = amount * 1000
                ElseIf curval1 = "m" Or curval1 = "M" Then
                    Nmoney = amount * 1000000

                End If
            Else
                Nmoney = CDbl(Dmoney)
            End If


        End If
        Nmoney = CDbl(Nmoney)
        Return Format(CDec(Nmoney), "#,##0")

    End Function
    Public Structure UpperRecord
        Dim tCode As String
        Dim tDesc As String
        Dim tType As String
        Dim tFloor As String
        Dim tCeiling As String
        Dim theTier() As LowerRecord
        Dim theTier2 As System.Collections.ArrayList
    End Structure
    Public BeforeEdit As UpperRecord
    Public AfterEdit As UpperRecord
    Public theArrObj As System.Collections.ArrayList
    Public Shared Sub CreateConfirmBox(ByRef btn As WebControls.Button, _
                                           ByVal strMessage As String)
        btn.Attributes.Add("onclick", "return confirm('" & strMessage & "');")
    End Sub
    Public Shared Sub popup(ByRef Pname As System.Web.UI.Page, ByVal Plink As String, ByVal header As String, ByVal height As Integer, ByVal width As Integer, Optional ByVal Action As String = "window.open")

        Dim s As String = "<script type='text/javascript'>"
        s += Action & "('" & Plink & "','Search','height=" & height & ",width=" & width & ",resizable=no,scrollbars=yes,status=no,toolbar=no,menubar=no,location=no')"
        s += "</script>"
        Dim csType As Type = Pname.GetType()
        ScriptManager.RegisterStartupScript(Pname, csType, Guid.NewGuid().ToString(), s, False)

    End Sub
    Public Shared Function ShowToast(ByVal aspxpage As System.Web.UI.Page, Type As ToastType, Msg As String, Optional Title As String = "",
                                            Optional Position As ToastPosition = ToastPosition.BottomRight,
                                            Optional ShowCloseButton As Boolean = True) As String
        Dim strType = "", strPosition = ""

        Select Case Type
            Case ToastType.Success
                strType = "success"
            Case ToastType.Info
                strType = "info"
            Case ToastType.Warning
                strType = "warning"
            Case ToastType.Error
                strType = "error"
        End Select

        'Set the position based on selected and change value to match toastr plugin
        Select Case Position
            Case ToastPosition.TopRight
                strPosition = "toast-top-right"
            Case ToastPosition.TopLeft
                strPosition = "toast-top-left"
            Case ToastPosition.TopCenter
                strPosition = "toast-top-center"
            Case ToastPosition.TopStretch
                strPosition = "toast-top-full-width"
            Case ToastPosition.BottomRight
                strPosition = "toast-bottom-right"
            Case ToastPosition.BottomLeft
                strPosition = "toast-bottom-left"
            Case ToastPosition.BottomCenter
                strPosition = "toast-bottom-center"
            Case ToastPosition.BottomStretch
                strPosition = "toast-bottom-full-width"
        End Select

        'Call the toastify() function in script.js
        Dim script = "toastify('" & strType & "', '" & CleanStr(Msg) & "', '" & CleanStr(Title) & "', '" & strPosition & "', '" & ShowCloseButton.ToString.ToLower & "');"
        'Page.ClientScript.RegisterStartupScript(Page.GetType(), "toastedMsg", script, True)

        ScriptManager.RegisterStartupScript(aspxpage, GetType(Page), "toastedMsg", script, True)

        Return True
    End Function
    Private Shared Function CleanStr(Text As String) As String
        'This function replaces ' with its html code equiv
        'in order not to terminate the js statement string
        Return Text.Replace("'", "&#39;")
    End Function
    Public Shared Function alertwindow(ByVal aspxpage As System.Web.UI.Page, ByVal Msgger As String, ByVal desc As String) As String
        'Msgger = """" & Msgger & """"
        'Dim javastring As System.Text.StringBuilder
        'javastring = New System.Text.StringBuilder
        'javastring.Append("<script language='Javascript'>")
        'javastring.Append("Information(" & Msgger & ");")
        'javastring.Append("windows.location='")
        'javastring.Append("Urlstring:")
        'javastring.Append("';")
        'javastring.Append("</script>")

        'If Not aspxpage.ClientScript.IsClientScriptBlockRegistered(desc) Then
        '    aspxpage.ClientScript.RegisterClientScriptBlock(aspxpage.GetType(), desc, javastring.ToString)
        'End If

        'Dim strScript As String = "<script language=JavaScript>"
        'strScript += "alert(""" & Msgger & """);"
        'strScript += "</script>"

        'If (Not aspxpage.ClientScript.IsStartupScriptRegistered("clientScript")) Then
        '    aspxpage.ClientScript.RegisterClientScriptBlock(aspxpage.GetType(), desc, strScript)

        'End If


        Dim script As String = "alert('" + Msgger + "');"
        ScriptManager.RegisterStartupScript(aspxpage, GetType(Page), "UserSecurity", script, True)
        Return True


        'Response.Write("<script type=""text/javascript"">Information(" & "'" & Msgger & "'" & ");</script>")

    End Function
    Public Shared Function alertwindow2(ByVal aspxpage As System.Web.UI.Page, ByVal Msgger As String, ByVal desc As String) As String

        'Msgger = """" & Msgger & """"

        'Dim javastring As System.Text.StringBuilder
        'javastring = New System.Text.StringBuilder
        'javastring.Append("<script language='Javascript'>")
        'javastring.Append("Information(" & Msgger & ");")
        'javastring.Append("windows.location='")
        'javastring.Append("Urlstring:")
        'javastring.Append("';")
        'javastring.Append("</script>")

        'If Not aspxpage.ClientScript.IsClientScriptBlockRegistered(desc) Then
        '    aspxpage.ClientScript.RegisterClientScriptBlock(aspxpage.GetType(), desc, javastring.ToString)
        'End If

        Dim strScript As String = "<script language=JavaScript>"
        strScript += "alert(""" & Msgger & """);"
        strScript += "</script>"

        If (Not aspxpage.ClientScript.IsStartupScriptRegistered("clientScript")) Then
            aspxpage.ClientScript.RegisterClientScriptBlock(aspxpage.GetType(), desc, strScript)

        End If

        Return True

        'Response.Write("<script type=""text/javascript"">Information(" & "'" & Msgger & "'" & ");</script>")

    End Function

    Public Shared Function alertwindownoajax(ByVal aspxpage As System.Web.UI.Page, ByVal Msgger As String, ByVal desc As String) As String
        Msgger = """" & Msgger & """"
        Dim javastring As System.Text.StringBuilder
        javastring = New System.Text.StringBuilder
        javastring.Append("<script language='Javascript'>")
        javastring.Append("Information(" & Msgger & ");")
        javastring.Append("windows.location='")
        javastring.Append("Urlstring:")
        javastring.Append("';")
        javastring.Append("</script>")

        If Not aspxpage.ClientScript.IsClientScriptBlockRegistered(desc) Then
            aspxpage.ClientScript.RegisterClientScriptBlock(aspxpage.GetType(), desc, javastring.ToString)
        End If

        'Dim strScript As String = "<script language=JavaScript>"
        'strScript += "alert(""" & Msgger & """);"
        'strScript += "</script>"

        'If (Not aspxpage.ClientScript.IsStartupScriptRegistered("clientScript")) Then
        '    aspxpage.ClientScript.RegisterClientScriptBlock(aspxpage.GetType(), desc, strScript)

        'End If


        'Dim script As String = "alert('" + Msgger + "');"
        'ScriptManager.RegisterStartupScript(aspxpage, GetType(Page), "UserSecurity", script, True)
        'Return True


        ''Response.Write("<script type=""text/javascript"">Information(" & "'" & Msgger & "'" & ");</script>")

    End Function
    Public Shared Sub SmartMsgBox(ByVal F As Object, ByVal sMsg As String)
        Dim sb As New StringBuilder()
        Dim oFormObject As System.Web.UI.Control = Nothing
        Try
            sMsg = sMsg.Replace("'", "\'")
            sMsg = sMsg.Replace(Chr(34), "\" & Chr(34))
            sMsg = sMsg.Replace(vbCrLf, "\n")
            sMsg = "<script language='javascript'>alert('" & sMsg & "');</script>"
            sb = New StringBuilder()
            sb.Append(sMsg)
            For Each oFormObject In F.Controls
                If TypeOf oFormObject Is HtmlForm Then
                    Exit For
                End If
            Next
            oFormObject.Controls.AddAt(oFormObject.Controls.Count, New LiteralControl(sb.ToString()))
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub loadListBox(ByVal combo As ListBox, ByVal sqlStr As String)


        For Each drow1 As Data.DataRow In con.SqlDs(sqlStr).Tables(0).Rows
            Dim newListItem As New System.Web.UI.WebControls.ListItem()
            newListItem.Text = drow1(1)
            newListItem.Value = drow1(0)
            combo.Items.Add(newListItem)
        Next



    End Sub

    Public Shared Function Confirmwindow(ByVal aspxpage As System.Web.UI.Page, ByVal desc As String) As String




        Dim javastring As System.Text.StringBuilder
        javastring = New System.Text.StringBuilder
        javastring.Append("<script language='javascript'>")
        javastring.Append("var res=confirm("" Are you Sure?"");")
        javastring.Append("if (res==1){}")
        javastring.Append("else{history.go(-1);}")
        javastring.Append("</script>")

        If Not aspxpage.ClientScript.IsClientScriptBlockRegistered(desc) Then
            aspxpage.ClientScript.RegisterClientScriptBlock(aspxpage.GetType(), desc, javastring.ToString)
        End If

        Return True
    End Function
    Public Shared Function IIFF(ByVal TestCondition As Boolean, ByVal ResultWhenTrue As Object, ByVal ResultWhenFalse As Object) As Object
        Dim rs As Object
        If TestCondition Then
            rs = ResultWhenTrue
        Else
            rs = ResultWhenFalse
        End If
        Return rs
    End Function


    Public Shared Function DecodeCkeckBox(ByVal mbox As System.Web.UI.WebControls.CheckBox) As String
        If mbox.Checked = False Then Return 0
        If mbox.Checked = True Then Return 1
        Return 0
    End Function

    Public Shared Function encodeCkeckBox(ByVal i As Integer) As String
        If i = 0 Then Return False
        If i = 1 Then Return True
        Return False
    End Function

    Public Shared Function DecodeCkeckBox(ByVal mbox As System.Web.UI.WebControls.CheckBox, ByVal ValueForFalse As Int32, ByVal ValueForTrue As Int32) As String
        If mbox.Checked = False Then
            Return ValueForFalse
        ElseIf mbox.Checked = True Then
            Return ValueForTrue
        Else : Return ValueForFalse
        End If
    End Function

    Public Shared Sub FlagCkeckBox(ByVal val As Int32, ByVal mbox As System.Web.UI.WebControls.CheckBox)
        If val = 0 Then mbox.Checked = False
        If val = 1 Then mbox.Checked = True
    End Sub

    Public Shared Sub FlagCkeckBox(ByVal val As String, ByVal mbox As System.Web.UI.WebControls.CheckBox, ByVal ValueForFalse As Int32, ByVal ValueForTrue As Int32)
        If val <> "" Then
            If CInt(val) = ValueForFalse Then
                mbox.Checked = False
            ElseIf CInt(val) = ValueForTrue Then
                mbox.Checked = True
            Else : mbox.Checked = False
            End If
        Else
            mbox.Checked = False
        End If
    End Sub

    Public Shared Function ClearWebPage(ByRef mPage As System.Web.UI.Page) As Boolean
        Dim oForm As Control = mPage.Form
        Dim ctl As Control

        For Each ctl In oForm.Controls
            doControl(ctl)
            If ctl.HasControls Then
                Dim ctx As Control
                For Each ctx In ctl.Controls
                    doControl(ctx)
                    'Dim ID As String = ctx.ID
                Next
            End If
        Next
        Return True
    End Function

    Public Shared Function invisibleWebPage(ByRef mPage As System.Web.UI.Page) As Boolean
        Dim oForm As Control = mPage.Form
        Dim ctl As Control

        For Each ctl In oForm.Controls
            invisibleControl(ctl)
            If ctl.HasControls Then
                Dim ctx As Control
                For Each ctx In ctl.Controls
                    doControl(ctx)
                    'Dim ID As String = ctx.ID
                Next
            End If
        Next
        Return True
    End Function
    Public Shared Sub invisibleControl(ByRef ctl As Control)
        If ctl.GetType.ToString.Equals("System.Web.UI.WebControls.TextBox") Then
            Dim xx As TextBox = CType(ctl, TextBox)
            xx.Visible = False
        End If


        If ctl.GetType.ToString.Equals("System.Web.UI.WebControls.Fileupload") Then
            Dim xx1 As FileUpload = CType(ctl, FileUpload)
            xx1.Visible = False
        End If

        If ctl.GetType.ToString.Equals("System.Web.UI.WebControls.CheckBox") Then
            'System.Web.UI.WebControls.RadioButton()
            Dim xx2 As System.Web.UI.WebControls.CheckBox = CType(ctl, System.Web.UI.WebControls.CheckBox)
            xx2.Visible = False
        End If

        If ctl.GetType.ToString.Equals("System.Web.UI.WebControls.RadioButton") Then
            'System.Web.UI.WebControls.RadioButton()
            Dim xx3 As RadioButton = CType(ctl, RadioButton)
            xx3.Visible = False
        End If
    End Sub

    Public Shared Function disableWebPage(ByRef mPage As System.Web.UI.Page) As Boolean
        Dim oForm As Control = mPage.Form
        Dim ctl As Control

        For Each ctl In oForm.Controls
            disableControl(ctl)
            If ctl.HasControls Then
                Dim ctx As Control
                For Each ctx In ctl.Controls
                    doControl(ctx)
                    'Dim ID As String = ctx.ID
                Next
            End If
        Next
        Return True
    End Function
    Public Shared Sub disableControl(ByRef ctl As Control)
        If ctl.GetType.ToString.Equals("System.Web.UI.WebControls.TextBox") Then
            Dim xx As TextBox = CType(ctl, TextBox)
            xx.ReadOnly = True
        End If


        If ctl.GetType.ToString.Equals("System.Web.UI.WebControls.Fileupload") Then
            Dim xx1 As FileUpload = CType(ctl, FileUpload)
            xx1.Enabled = False
        End If

        If ctl.GetType.ToString.Equals("System.Web.UI.WebControls.CheckBox") Then
            'System.Web.UI.WebControls.RadioButton()
            Dim xx2 As System.Web.UI.WebControls.CheckBox = CType(ctl, System.Web.UI.WebControls.CheckBox)
            xx2.Enabled = False
        End If

        If ctl.GetType.ToString.Equals("System.Web.UI.WebControls.RadioButton") Then
            'System.Web.UI.WebControls.RadioButton()
            Dim xx3 As RadioButton = CType(ctl, RadioButton)
            xx3.Enabled = False
        End If
    End Sub
    Public Shared Function ClearWebPage(ByRef mPage As System.Web.UI.Page, ByVal ParamArray mloopthru() As Control) As Boolean
        Dim oForm As Control = mPage.Form
        Dim ctl As Control

        For Each ctl In oForm.Controls
            If Not smartobj.ItemEqualsOneInLoop(ctl.ID, mloopthru) Then
                doControl(ctl)
            End If

            If ctl.HasControls Then
                Dim ctx As Control
                For Each ctx In ctl.Controls
                    If Not smartobj.ItemEqualsOneInLoop(ctx.ID, mloopthru) Then
                        doControl(ctx)
                    End If
                    'Dim ID As String = ctx.ID
                Next
            End If
        Next
        Return True
    End Function
    Public Shared Sub loadCheckBoxList(ByVal combo As CheckBoxList, ByVal sqlStr As String)
        combo.Items.Clear()
        Dim blankListItem As New System.Web.UI.WebControls.ListItem()

        For Each drow1 As Data.DataRow In con.SqlDs(sqlStr).Tables(0).Rows
            Dim newListItem As New System.Web.UI.WebControls.ListItem()
            Dim status As Integer
            Dim lastIndex As Integer
            newListItem.Text = drow1(1)
            newListItem.Value = drow1(0)
            status = CInt(drow1(0).ToString)
            combo.Items.Add(newListItem)
            lastIndex = combo.Items.Count - 1
            If status = 1 Then
                combo.Items(lastIndex).Selected = True
                combo.Items(lastIndex).Text.ToUpper()
            Else
                combo.Items(lastIndex).Text.ToLower()
            End If

        Next

    End Sub
    Public Shared Function ClearWebPage(ByRef mPage As System.Web.UI.Page, ByRef mloopthru As System.Collections.ArrayList) As Boolean
        Dim oForm As Control = mPage.Form
        Dim ctl As Control

        For Each ctl In oForm.Controls
            If Not smartobj.ItemEqualsOneInLoop(ctl.ID, mloopthru) Then
                doControl(ctl)
            End If

            If ctl.HasControls Then
                Dim ctx As Control
                For Each ctx In ctl.Controls
                    If Not smartobj.ItemEqualsOneInLoop(ctx.ID, mloopthru) Then
                        doControl(ctx)
                    End If
                    'Dim ID As String = ctx.ID
                Next
            End If
        Next
        Return True
    End Function

    Public Shared Function ValidateWebPage(ByRef mLoopThru As System.Collections.ArrayList, _
                                ByRef mPage As System.Web.UI.Page) As Boolean
        Dim oForm As Control = mPage.Form
        Dim ctl As Control

        For Each ctl In oForm.Controls
            If Not ItemEqualsOneInLoop(ctl.ID, mLoopThru) Then
                If doControl2(ctl) = False Then
                    Beep()
                    ctl.Focus()
                    smartobj.alertwindow(mPage, "All required inputs must be filled", "Information Message")
                    Return False
                End If
                If ctl.HasControls Then
                    Dim ctx As Control
                    For Each ctx In ctl.Controls
                        If Not ItemEqualsOneInLoop(ctx.ID, mLoopThru) Then
                            If doControl2(ctx) = False Then
                                Beep()
                                ctx.Focus()
                                smartobj.alertwindow(mPage, "All required inputs must be filled", "Information Message")
                                Return False
                            End If
                        End If
                        'Dim ID As String = ctx.ID
                    Next
                End If

                'If ctl.GetType.ToString.Equals("System.Web.UI.WebControls.TextBox") Then
                '    Dim xx As TextBox = CType(ctl, TextBox)
                '    If Not doControl2(xx) Then
                '        Beep()
                '        ctl.Focus()
                '        Return False
                '    End If
                'End If

                'If ctl.GetType.ToString.Equals("System.Web.UI.WebControls.DropDownList") Then
                '    Dim xx1 As DropDownList = CType(ctl, DropDownList)
                '    If Not doControl2(xx1) Then
                '        Beep()
                '        ctl.Focus()
                '        Return False
                '    End If
                'End If
            End If


        Next
        Return True
    End Function

    Private Shared Function ItemEqualsOneInLoop(ByVal OneItem As String, _
                      ByRef TheLoop As System.Collections.ArrayList) As Boolean
        Dim retVal As Boolean = False
        Dim i As Integer

        If TheLoop.Count = 0 Then Return True
        If OneItem = vbNullString Then Return True

        For i = 0 To TheLoop.Count - 1
            If OneItem.Equals(TheLoop.Item(i).ToString) Then
                retVal = True
                Exit For
            End If
        Next
        Return retVal
    End Function

    Private Shared Function ItemEqualsOneInLoop(ByVal OneItem As String, _
                                                ByRef TheLoop() As Control) As Boolean
        Dim retVal As Boolean = False
        Dim i As Integer

        If TheLoop.Length = 0 Then Return True
        If OneItem = vbNullString Then Return True

        For i = 0 To TheLoop.Length - 1
            If OneItem.Equals(TheLoop(i).ID) Then
                retVal = True
                Exit For
            End If
        Next
        Return retVal
    End Function
    Public Shared Function doControl2(ByRef ctl As Control) As Boolean
        Dim retVal As Boolean = True
        If ctl.GetType.ToString.Equals("System.Web.UI.WebControls.TextBox") Then
            Dim xx As TextBox = CType(ctl, TextBox)
            If xx.Text = vbNullString Then
                retVal = False
            End If
        End If


        If ctl.GetType.ToString.Equals("System.Web.UI.WebControls.DropDownList") Then
            Dim xx1 As DropDownList = CType(ctl, DropDownList)
            If xx1.SelectedIndex < 0 Or xx1.SelectedValue = "" Then
                retVal = False
            End If
        End If

        If ctl.GetType.ToString.Equals("System.Web.UI.WebControls.CheckBox") Then
            'System.Web.UI.WebControls.RadioButton()
            Dim xx2 As System.Web.UI.WebControls.CheckBox = CType(ctl, System.Web.UI.WebControls.CheckBox)
            If xx2.Checked = False Then
                retVal = False
            End If
        End If

        If ctl.GetType.ToString.Equals("System.Web.UI.WebControls.RadioButton") Then
            'System.Web.UI.WebControls.RadioButton()
            Dim xx3 As RadioButton = CType(ctl, RadioButton)
            If xx3.Checked = False Then
                retVal = False
            End If
        End If
        'If ctl.HasControls Then
        '    Dim ctx As Control
        '    For Each ctx In ctl.Controls
        '        If Not smartobj.ItemEqualsOneInLoop(ctx.ID, mLoopThru) Then
        '            doControl2(ctx)
        '        End If
        '        'Dim ID As String = ctx.ID
        '    Next
        'End If


        Return retVal
    End Function
    Public Shared Sub doControl(ByRef ctl As Control)
        If ctl.GetType.ToString.Equals("System.Web.UI.WebControls.TextBox") Then
            Dim xx As TextBox = CType(ctl, TextBox)
            xx.Text = vbNullString
        End If


        If ctl.GetType.ToString.Equals("System.Web.UI.WebControls.DropDownList") Then
            Dim xx1 As DropDownList = CType(ctl, DropDownList)
            xx1.SelectedIndex = -1
        End If

        If ctl.GetType.ToString.Equals("System.Web.UI.WebControls.CheckBox") Then
            'System.Web.UI.WebControls.RadioButton()
            Dim xx2 As System.Web.UI.WebControls.CheckBox = CType(ctl, System.Web.UI.WebControls.CheckBox)
            xx2.Checked = False
        End If

        If ctl.GetType.ToString.Equals("System.Web.UI.WebControls.RadioButton") Then
            'System.Web.UI.WebControls.RadioButton()
            Dim xx3 As RadioButton = CType(ctl, RadioButton)
            xx3.Checked = False
        End If
    End Sub


    Public Shared Function EncoteWithSingleQuote(ByVal inputString As String) As String
        Return "'" & inputString & "'"
    End Function
    'End Class
    Private Function FillDeductionType() As Integer
        Dim strstr As String = ""
        strstr = ConfigurationManager.AppSettings("Deductionmode")
        DeductionMode = Split(strstr, ",")
        Return UBound(DeductionMode)
    End Function
    Private Function FillDeductionMode() As Integer
        Dim strstr As String = ""
        strstr = ConfigurationManager.AppSettings("DeductionType")
        DeductionType = Split(strstr, ",")
        Return UBound(DeductionType)
    End Function
    'Public Function clear() As String
    '    'Dim frm As Control = indControl("Form1")
    '    Dim ctl As Control

    '    For Each ctl In frm.Controls
    '        Dim tb As TextBox
    '        If TypeOf ctl Is TextBox Then
    '            tb = CType(ctl, TextBox)
    '            tb.Text = String.Empty
    '        End If
    '    Next

    'End Function

    'End Class
    Public Shared Sub loadComboValues(ByVal DefaultVal As String, ByVal combo As DropDownList, ByVal tablename As String)
        Dim qry As String = ""

        Try
            qry = tablename
            '' Dim drow1 As Data.DataRow
            combo.Items.Clear()
            'add a blank record
            Dim blankListItem As New System.Web.UI.WebControls.ListItem()
            blankListItem.Text = DefaultVal
            blankListItem.Value = 0
            combo.Items.Add(blankListItem)
            For Each dro As Data.DataRow In con.SqlDs(qry).Tables(0).Rows
                Dim newListItem As New System.Web.UI.WebControls.ListItem()
                newListItem.Text = dro(1)
                ' Dim a As String = drow1.GetString(2)
                newListItem.Value = dro(0)
                combo.Items.Add(newListItem)
            Next
        Catch ex As Exception

        End Try


    End Sub
    Public Sub RunFirst()
        FillDeductionType()
        FillDeductionMode()
    End Sub


    Public Shared Sub setIndex(ByVal strVal As String, ByVal drcombo As DropDownList)
        Dim i As Integer = drcombo.Items.Count
        Dim j As Integer
        For j = 0 To i - 1
            If drcombo.Items(j).Value = strVal Then
                drcombo.SelectedIndex = j
            End If
        Next
    End Sub

  
    Public Shared Function MakeInvisible(ByVal ParamArray theObj() As Control) As Boolean
        Dim ctl As Control
        Dim i As Integer = theObj.Length
        Dim j As Integer
        Dim newList As New System.Collections.ArrayList

        For j = 0 To i - 1
            ctl = theObj(j)
            ctl.Visible = False
        Next
        Return (False)
    End Function
    Public Shared Function CheckDigit(ByVal BasicNumber As String, ByVal producttype As String, ByVal brchcode As String) As String

        Dim PAN As String
        Dim ProdDigit As Integer, ContCheckDigit As Integer, i As Integer, j As Integer
        Dim SumProdDigit As Integer, TopSumProdValue As Integer

        PAN = GeneratePan(BasicNumber, producttype, brchcode)


        For i = Len(PAN) To 1 Step -2
            ProdDigit = 2 * Val(Mid(PAN, i, 1))

            For j = 1 To Len(ProdDigit)
                SumProdDigit = SumProdDigit + Val(Mid(ProdDigit, j, 1))
            Next j
        Next i

        For i = Len(PAN) - 1 To 1 Step -2
            SumProdDigit = SumProdDigit + Val(Mid(PAN, i, 1))
        Next i



        If (Right(CStr(SumProdDigit), 1) <> "0") Then

            TopSumProdValue = (Int(SumProdDigit / 10) + 1) * 10
        Else
            TopSumProdValue = SumProdDigit
        End If

        ContCheckDigit = TopSumProdValue - SumProdDigit
        CheckDigit = CStr(PAN) + CStr(ContCheckDigit)

    End Function

    Public Shared Function GeneratePan(ByVal BasicNumber As String, ByVal producttype As String, ByVal Brchcode As String) As String
        Dim PIN As String

        PIN = Brchcode + producttype + Right("000000" + BasicNumber, 5)

        GeneratePan = PIN


    End Function

    Public Shared Function IFF(ByVal TestCondition As Boolean, ByVal ResultWhenTrue As Object, ByVal ResultWhenFalse As Object) As Object
        Dim rs As Object
        If TestCondition Then
            rs = ResultWhenTrue
        Else
            rs = ResultWhenFalse
        End If
        Return rs
    End Function

    Public Shared Function GetnoDays(ByVal trm As String, ByVal valTenor As Integer) As Int32
        Dim tenor As Int32
        If trm = "1" Then
            tenor = valTenor
        ElseIf trm = "2" Then
            tenor = valTenor * 7
        ElseIf trm = "3" Then
            tenor = valTenor * 14
        ElseIf trm = "4" Then
            tenor = valTenor * 30
        ElseIf trm = "5" Then
            tenor = valTenor * 365
        ElseIf trm = "6" Then
            tenor = valTenor * 90
        End If
        Return tenor
    End Function

    Public Shared Function Getnomonths(ByVal trm As String, ByVal valTenor As Integer) As Int32
        Dim tnconvert As Double
        Dim tenor As Int32
        If trm = "1" Then
            tnconvert = Math.Round(valTenor, 1)
        ElseIf trm = "2" Then
            tnconvert = Math.Round((valTenor / 7), 1)
        ElseIf trm = "3" Then
            tnconvert = Math.Round((valTenor / 14), 1)
        ElseIf trm = "4" Then
            tnconvert = Math.Round((valTenor / 30), 1)
        ElseIf trm = "5" Then
            tnconvert = Math.Round((valTenor / 365), 1)
        ElseIf trm = "6" Then
            tnconvert = Math.Round((valTenor / 90), 1)
        End If
        Dim post As Integer = InStr(1, tnconvert.ToString, ".")

        If post <> 0 Then
            Dim val As String = Mid(tnconvert, post + 1, 1)

            If val <> "0" Or val <> "1" Then
                tnconvert = tnconvert + 1
            End If
        End If
        tenor = CInt(tnconvert)
        Return tenor
    End Function



    Public Shared Function Getloanterm(ByVal trm As String) As Int32
        Dim tenor As Int32
        If trm = "1" Then
            tenor = 365
        ElseIf trm = "2" Then
            tenor = 52
        ElseIf trm = "3" Then
            tenor = 26
        ElseIf trm = "4" Then
            tenor = 12
        ElseIf trm = "5" Then
            tenor = 1
        ElseIf trm = "6" Then
            tenor = 4
        End If
        Return tenor
    End Function

    Public Shared Function Getloantermdesc(ByVal trm As String) As String
        Dim tenor As String = ""
        If trm = "1" Then
            tenor = "Days"
        ElseIf trm = "2" Then
            tenor = "Weeks"
        ElseIf trm = "3" Then
            tenor = "ForthNight"
        ElseIf trm = "4" Then
            tenor = "Months"
        ElseIf trm = "5" Then
            tenor = "Years"
        ElseIf trm = "6" Then
            tenor = "Quarterly"
        End If
        Return tenor
    End Function


End Class
