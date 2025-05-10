Public Class AboutForm
    Private Sub AboutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "About Stan's Grocery"
        AboutLabel.Text = "Stan's Grocery" & vbCrLf &
                          "Version 1.0" & vbCrLf &
                          "Created for RCET2265"

    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        Me.Close()
    End Sub

    Private Sub AboutLabel_Click(sender As Object, e As EventArgs) Handles AboutLabel.Click

    End Sub
End Class