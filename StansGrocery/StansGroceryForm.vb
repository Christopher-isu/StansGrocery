Option Strict On
Option Explicit On

Imports System.IO

Public Class StansGroceryForm

    ' Global data storage
    Dim food$(,) : Dim fileName As String = "Grocery.txt"
    Dim splashScreen As SplashScreenForm

    Private Sub StansGroceryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Center the form on the screen
        Dim screenWidth As Integer = Screen.PrimaryScreen.WorkingArea.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.WorkingArea.Height
        Dim formWidth As Integer = Me.Width
        Dim formHeight As Integer = Me.Height
        Me.Location = New Point((screenWidth - formWidth) \ 2, (screenHeight - formHeight) \ 2)

        ' Show splash screen
        splashScreen = New SplashScreenForm()
        splashScreen.Show()
        splashScreen.Refresh()
        Application.DoEvents() ' Allow splash to render and timers to start

        ' Wait 2 seconds without freezing the UI
        Dim sw As New Stopwatch()
        sw.Start()
        Do While sw.ElapsedMilliseconds < 2000
            Application.DoEvents()
        Loop

        ' Proceed with loading main form data
        LoadGroceryData()
        PopulateFilterComboBox()
        PopulateDisplayListBox()
        FilterByAisleRadioButton.Checked = True
        FilterComboBox.SelectedIndex = 0
        SearchTextBox.Text = ""

        ' Close splash screen
        splashScreen.Close()
        splashScreen.Dispose()
    End Sub

    Private Sub StansGroceryForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If splashScreen IsNot Nothing Then
            splashScreen.Close()
            splashScreen.Dispose()
        End If
    End Sub

    Sub LoadGroceryData()
        Try
            If Not File.Exists(fileName) Then
                MsgBox("Data file not found: " & fileName)
                food = Nothing
                Return
            End If

            Dim lines() As String = File.ReadAllLines(fileName)
            If lines.Length = 0 Then
                MsgBox("The grocery file is empty.")
                food = Nothing
                Return
            End If

            ReDim food(lines.Length - 1, 2)

            For i = 0 To lines.Length - 1
                Dim parts = lines(i).Split(","c)
                If parts.Length >= 3 Then
                    food(i, 0) = parts(0).Replace("""", "").Replace("$$ITM", "").Trim()
                    food(i, 1) = parts(1).Replace("""", "").Replace("##LOC", "").Trim()
                    food(i, 2) = parts(2).Replace("""", "").Replace("%%CAT", "").Trim()
                End If
            Next
        Catch ex As Exception
            MsgBox("Error loading grocery data: " & ex.Message)
            food = Nothing
        End Try
    End Sub

    Sub PopulateFilterComboBox()
        Try
            If food Is Nothing Then Exit Sub

            FilterComboBox.Items.Clear()
            FilterComboBox.Items.Add("Show All")

            Dim values As New List(Of String)

            If FilterByAisleRadioButton.Checked Then
                For i = 0 To food.GetUpperBound(0)
                    If Not values.Contains(food(i, 1)) Then values.Add(food(i, 1))
                Next
                values.Sort(Function(x, y) y.CompareTo(x))
            ElseIf FilterByCategoryRadioButton.Checked Then
                For i = 0 To food.GetUpperBound(0)
                    If Not values.Contains(food(i, 2)) Then values.Add(food(i, 2))
                Next
                values.Sort()
            End If

            For Each value In values
                FilterComboBox.Items.Add(value)
            Next

            FilterComboBox.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Error populating filter combo box: " & ex.Message)
        End Try
    End Sub

    Sub PopulateDisplayListBox()
        Try
            If food Is Nothing OrElse FilterComboBox.SelectedItem Is Nothing Then Exit Sub

            DisplayListBox.Items.Clear()
            Dim filterValue As String = FilterComboBox.SelectedItem.ToString()
            Dim filteredItems As New List(Of String)

            For i = 0 To food.GetUpperBound(0)
                Dim includeItem As Boolean = False

                If filterValue = "Show All" Then
                    includeItem = True
                ElseIf FilterByAisleRadioButton.Checked AndAlso food(i, 1) = filterValue Then
                    includeItem = True
                ElseIf FilterByCategoryRadioButton.Checked AndAlso food(i, 2) = filterValue Then
                    includeItem = True
                End If

                If includeItem AndAlso Not filteredItems.Contains(food(i, 0)) Then
                    filteredItems.Add(food(i, 0))
                End If
            Next

            filteredItems.Sort()
            For Each item In filteredItems
                DisplayListBox.Items.Add(item)
            Next
        Catch ex As Exception
            MsgBox("Error displaying items: " & ex.Message)
        End Try
    End Sub

    Private Sub FilterChanged(sender As Object, e As EventArgs) Handles FilterByAisleRadioButton.CheckedChanged, FilterByCategoryRadioButton.CheckedChanged
        PopulateFilterComboBox()
        PopulateDisplayListBox()
    End Sub

    Private Sub FilterComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilterComboBox.SelectedIndexChanged
        PopulateDisplayListBox()
    End Sub

    Private Sub DisplayListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DisplayListBox.SelectedIndexChanged
        Try
            If food Is Nothing Then Exit Sub
            Dim selectedItem As String = TryCast(DisplayListBox.SelectedItem, String)
            If String.IsNullOrWhiteSpace(selectedItem) Then Return

            For i = 0 To food.GetUpperBound(0)
                If food(i, 0) = selectedItem Then
                    DisplayLabel.Text = $"You will find {food(i, 0)} on aisle {food(i, 1)} with the {food(i, 2)}"
                    Exit Sub
                End If
            Next
        Catch ex As Exception
            MsgBox("Error showing item details: " & ex.Message)
        End Try
    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        Try
            If food Is Nothing Then Exit Sub
            Dim searchString As String = SearchTextBox.Text.Trim()

            If searchString.ToLower() = "zzz" Then
                Me.Close()
                Return
            End If

            DisplayListBox.Items.Clear()
            FilterComboBox.Items.Clear()
            FilterComboBox.Items.Add("Show All")

            Dim foundItems As New List(Of String)
            Dim filterValues As New HashSet(Of String)

            For i = 0 To food.GetUpperBound(0)
                If food(i, 0).IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 _
                   OrElse food(i, 1).IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 _
                   OrElse food(i, 2).IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 Then

                    If Not foundItems.Contains(food(i, 0)) Then
                        foundItems.Add(food(i, 0))
                        DisplayListBox.Items.Add(food(i, 0))
                    End If

                    If FilterByAisleRadioButton.Checked Then
                        filterValues.Add(food(i, 1))
                    ElseIf FilterByCategoryRadioButton.Checked Then
                        filterValues.Add(food(i, 2))
                    End If
                End If
            Next

            ' Update the FilterComboBox with matched values only
            Dim sortedValues = filterValues.ToList()
            If FilterByAisleRadioButton.Checked Then
                sortedValues.Sort(Function(x, y) y.CompareTo(x))
            Else
                sortedValues.Sort()
            End If

            For Each value In sortedValues
                FilterComboBox.Items.Add(value)
            Next

            FilterComboBox.SelectedIndex = 0

            If foundItems.Count = 0 Then
                DisplayLabel.Text = $"Sorry no matches for {searchString}"
            Else
                DisplayLabel.Text = ""
            End If

            FilterByAisleRadioButton.Checked = True
            PopulateFilterComboBox()
            FilterComboBox.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("Error searching items: " & ex.Message)
        End Try
    End Sub

    ' Menu/context handlers
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutForm.ShowDialog()
    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click
        SearchButton.PerformClick()
    End Sub

    Private Sub ContextSearch_Click(sender As Object, e As EventArgs) Handles ContextSearch.Click
        SearchButton.PerformClick()
    End Sub

    Private Sub ContextExit_Click(sender As Object, e As EventArgs) Handles ContextExit.Click
        Me.Close()
    End Sub

End Class
