Public Class SplashScreenForm

    Private fadeInTimer As New Timer()
    Private fadeDurationTimer As New Timer()

    Private Sub SplashScreenForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Manually center the form on the screen
        Dim screenWidth As Integer = Screen.PrimaryScreen.WorkingArea.Width 'find the screen width
        Dim screenHeight As Integer = Screen.PrimaryScreen.WorkingArea.Height 'find the screen height
        Dim formWidth As Integer = Me.Width 'find the form width
        Dim formHeight As Integer = Me.Height '

        ' Calculate the top-left corner of the form to center it on the screen
        Me.Location = New Point((screenWidth - formWidth) \ 2, (screenHeight - formHeight) \ 2)

        ' Prepare the splash screen appearance
        Me.Opacity = 0.0 'set initial opacity to 0
        Me.TopMost = True

        ' Set label text with line breaks between the two lines
        SplashLabel.Text = "Stan's Grocery: The One and Only" & Environment.NewLine & "Super Duper Grocery Locator"

        ' Center the text in the label
        SplashLabel.TextAlign = ContentAlignment.MiddleCenter

        ' Customize label font and color
        SplashLabel.Font = New Font("Arial", 9, FontStyle.Bold)
        SplashLabel.ForeColor = Color.Blue

        ' Start fade-in effect
        fadeInTimer.Interval = 50  'Set the interval for fade-in effect
        AddHandler fadeInTimer.Tick, AddressOf FadeIn 'attach the event handler
        fadeInTimer.Start() 'start the timer
    End Sub

    Private Sub FadeIn(sender As Object, e As EventArgs)
        ' Increment the opacity of the form
        If Me.Opacity < 1.0 Then 'until the form is fully visible
            Me.Opacity += 0.05 'increase the opacity by 0.05
        Else
            fadeInTimer.Stop()

            ' Once fully faded in, start timer to keep splash visible briefly
            fadeDurationTimer.Interval = 2000 ' 2 seconds
            AddHandler fadeDurationTimer.Tick, AddressOf FadeDurationComplete
            fadeDurationTimer.Start()
        End If
    End Sub

    Private Sub FadeDurationComplete(sender As Object, e As EventArgs)
        fadeDurationTimer.Stop() 'this will stop the timer
        Me.Close() ' Let main form proceed, do NOT create or show any form here
    End Sub

End Class
