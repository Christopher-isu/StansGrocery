Public Class AboutForm
    Private Sub AboutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the form's properties
        Me.Text = "About Stan's Grocery"
        AboutLabel.Text = "Stan's Grocery" & vbCrLf &
                          "Version 1.0" & vbCrLf &
                          "Created for RCET2265"

        ' Set location same as main form
        If StansGroceryForm IsNot Nothing Then
            Me.StartPosition = FormStartPosition.Manual ' Set to manual to control location
            Me.Location = StansGroceryForm.Location ' Center the form on the screen
        End If
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles okButton.Click
        ' Close the About form
        Me.Close()
    End Sub
End Class
