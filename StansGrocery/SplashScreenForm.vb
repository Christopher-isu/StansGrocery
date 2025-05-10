Public Class SplashScreenForm

    Private fadeInTimer As New Timer()
    Private fadeDurationTimer As New Timer()

    Private Sub SplashScreenForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Manually center the form on the screen
        Dim screenWidth As Integer = Screen.PrimaryScreen.WorkingArea.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.WorkingArea.Height
        Dim formWidth As Integer = Me.Width
        Dim formHeight As Integer = Me.Height

        ' Calculate the top-left corner of the form to center it on the screen
        Me.Location = New Point((screenWidth - formWidth) \ 2, (screenHeight - formHeight) \ 2)

        ' Prepare the splash screen appearance
        Me.Opacity = 0.0
        Me.TopMost = True

        ' Set label text with line breaks between the two lines
        SplashLabel.Text = "Stan's Grocery: The One and Only" & Environment.NewLine & "Super Duper Grocery Locator"

        ' Center the text in the label
        SplashLabel.TextAlign = ContentAlignment.MiddleCenter

        ' Customize label font and color
        SplashLabel.Font = New Font("Arial", 9, FontStyle.Bold)
        SplashLabel.ForeColor = Color.Blue

        ' Start fade-in effect
        fadeInTimer.Interval = 50
        AddHandler fadeInTimer.Tick, AddressOf FadeIn
        fadeInTimer.Start()
    End Sub

    Private Sub FadeIn(sender As Object, e As EventArgs)
        If Me.Opacity < 1.0 Then
            Me.Opacity += 0.05
        Else
            fadeInTimer.Stop()

            ' Once fully faded in, start timer to keep splash visible briefly
            fadeDurationTimer.Interval = 2000 ' 2 seconds
            AddHandler fadeDurationTimer.Tick, AddressOf FadeDurationComplete
            fadeDurationTimer.Start()
        End If
    End Sub

    Private Sub FadeDurationComplete(sender As Object, e As EventArgs)
        fadeDurationTimer.Stop()
        Me.Close() ' Let main form proceed, do NOT create or show any form here
    End Sub

End Class
