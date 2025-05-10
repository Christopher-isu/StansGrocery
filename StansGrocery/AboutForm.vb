Public Class AboutForm
    Private Sub AboutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "About Stan's Grocery"
        AboutLabel.Text = "Stan's Grocery" & vbCrLf &
                          "Version 1.0" & vbCrLf &
                          "Created for RCET2265"

        ' Set location same as main form
        If StansGroceryForm IsNot Nothing Then
            Me.StartPosition = FormStartPosition.Manual
            Me.Location = StansGroceryForm.Location
        End If
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles okButton.Click
        Me.Close()
    End Sub
End Class
