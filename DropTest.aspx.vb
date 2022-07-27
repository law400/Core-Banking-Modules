Imports Telerik.Web.UI

Partial Class DropTest
    Inherits System.Web.UI.Page

    Protected Sub RadComboBox2_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBox2.SelectedIndexChanged
        Me.RadTextBox1.Text = RadComboBox2.SelectedValue
    End Sub
End Class
