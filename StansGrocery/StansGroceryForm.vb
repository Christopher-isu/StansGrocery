'ChristopherZ
'Spring 2025
'RCET2265
'Stans Grocery Store
'https://github.com/Christopher-isu/StansGrocery.git

Option Strict On
Option Explicit On

Imports System.IO   ' System.IO needed to open the text file provided for this assignment

Public Class StansGroceryForm

    ' Declaring vaialbles for global data storage 
    Dim food$(,) : Dim fileName As String = "Grocery.txt"
    Dim splashScreen As SplashScreenForm

    Private Sub StansGroceryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Center the form on the screen
        Dim screenWidth As Integer = Screen.PrimaryScreen.WorkingArea.Width 'for the screen width
        Dim screenHeight As Integer = Screen.PrimaryScreen.WorkingArea.Height 'for the screen height
        Dim formWidth As Integer = Me.Width     'for the form width
        Dim formHeight As Integer = Me.Height   'for the form height
        'calculate the center of the screen
        Me.Location = New Point((screenWidth - formWidth) \ 2, (screenHeight - formHeight) \ 2)

        ' Show splash screen
        splashScreen = New SplashScreenForm() 'create a new instance of the splash screen
        splashScreen.Show() ' Show the splash screen
        splashScreen.Refresh() ' ' Refresh the splash screen to ensure it is displayed immediately
        Application.DoEvents() ' Allow splash to render and timers to start

        ' Wait 2 seconds without freezing the UI
        Dim sw As New Stopwatch() 'declare a new stopwatch
        sw.Start() ' Start the stopwatch
        Do While sw.ElapsedMilliseconds < 2000 'wait for 2 seconds
            Application.DoEvents() ' Allow the application to process other events
        Loop

        ' Proceed with loading main form data
        LoadGroceryData() ' Load the grocery data from the file
        PopulateFilterComboBox() ' Populate the filter combo box with unique values
        PopulateDisplayListBox(SearchTextBox.Text) ' Pass the empty text box string initially
        FilterByAisleRadioButton.Checked = True ' Set the default filter to Aisle
        FilterComboBox.SelectedIndex = 0 '  Set the default filter combo box to "Show All"
        SearchTextBox.Text = "" ' Clear the search text box

        ' Close splash screen
        splashScreen.Close() ' Close the splash screen
        splashScreen.Dispose() ' Dispose of the splash screen to free up resources
    End Sub

    Private Sub StansGroceryForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Show the splash screen again when closing the main form <--- I am aware that this is not working properly and needs more work
        If splashScreen IsNot Nothing Then
            splashScreen.Close() ' Close the splash screen
            splashScreen.Dispose() ' Dispose of the splash screen to free up resources
        End If
    End Sub

    Sub LoadGroceryData() 'loads the grocery data from the file
        Try
            If Not File.Exists(fileName) Then ' if the file does not exist
                MsgBox("Data file not found: " & fileName) ' Show error message
                food = Nothing ' Set food to Nothing
                Return
            End If

            Dim lines() As String = File.ReadAllLines(fileName) ' Read all lines from the file
            If lines.Length = 0 Then ' if the file is empty
                MsgBox("The grocery file is empty.") ' Show error message
                food = Nothing ' Set food to Nothing
                Return
            End If

            ReDim food(lines.Length - 1, 2) ' Resize the food array to match the number of lines in the file

            For i = 0 To lines.Length - 1 'set the food array to the values in the file
                Dim parts = lines(i).Split(","c) ' Split the line into parts
                If parts.Length >= 3 Then
                    ' Assign values to the food array, removing unwanted characters <-- this is a very crude method of doing this.
                    food(i, 0) = parts(0).Replace("""", "").Replace("$$ITM", "").Trim() ' Remove quotes and $$ITM
                    food(i, 1) = parts(1).Replace("""", "").Replace("##LOC", "").Trim() ' Remove quotes and ##LOC
                    food(i, 2) = parts(2).Replace("""", "").Replace("%%CAT", "").Trim() ' Remove quotes and %%CAT
                End If
            Next
        Catch ex As Exception ' Handle any exceptions that occur during file reading
            MsgBox("Error loading grocery data: " & ex.Message) ' Show error message
            food = Nothing
        End Try
    End Sub

    Sub PopulateFilterComboBox() ' Populates the filter combo box with unique values
        Try
            If food Is Nothing Then Exit Sub ' If food is not loaded, exit the sub

            FilterComboBox.Items.Clear() ' Clear the existing items in the combo box
            FilterComboBox.Items.Add("Show All") ' Add "Show All" option

            Dim values As New List(Of String) ' Create a new list to store unique values

            If FilterByAisleRadioButton.Checked Then ' Check if the Aisle filter is selected
                For i = 0 To food.GetUpperBound(0) ' Loop through the food array
                    If Not values.Contains(food(i, 1)) Then values.Add(food(i, 1)) ' Add unique aisles
                Next
                values.Sort(Function(x, y) y.CompareTo(x)) ' Sort aisles in descending order
            ElseIf FilterByCategoryRadioButton.Checked Then ' Check if the Category filter is selected
                For i = 0 To food.GetUpperBound(0)  ' Loop through the food array
                    If Not values.Contains(food(i, 2)) Then values.Add(food(i, 2)) ' Add unique categories
                Next
                values.Sort() ' Sort categories in alphabetical order
            End If

            For Each value In values 'for each value in the list
                FilterComboBox.Items.Add(value) 'add the value to the combo box
            Next

            FilterComboBox.SelectedIndex = 0
        Catch ex As Exception ' Handle any exceptions that occur during filter population
            MsgBox("Error populating filter combo box: " & ex.Message) ' Show error message
        End Try
    End Sub

    Sub PopulateDisplayListBox(searchString As String) ' Populates the display list box with filtered items
        Try
            If food Is Nothing OrElse FilterComboBox.SelectedItem Is Nothing Then Exit Sub
            ' If the food array is not loaded or no filter is selected, exit the sub
            DisplayListBox.Items.Clear()
            Dim filterValue As String = FilterComboBox.SelectedItem.ToString() ' Get the selected filter value
            Dim filteredItems As New List(Of String) ' Create a new list to store filtered items

            For i = 0 To food.GetUpperBound(0) ' Loop through the food array
                Dim includeItem As Boolean = False ' Initialize includeItem to False

                If filterValue = "Show All" Then
                    ' if Show all items is selected
                    includeItem = True
                ElseIf FilterByAisleRadioButton.Checked AndAlso food(i, 1) = filterValue Then
                    ' if the Aisle filter is selected
                    includeItem = True
                ElseIf FilterByCategoryRadioButton.Checked AndAlso food(i, 2) = filterValue Then
                    ' if the Category filter is selected
                    includeItem = True
                End If

                If includeItem AndAlso (food(i, 0).IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 _ 'check if the item matches the search string
                    OrElse food(i, 1).IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 _ 'check if the aisle matches the search string
                    OrElse food(i, 2).IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0) _ 'chec if the category matches the search string
                    AndAlso Not filteredItems.Contains(food(i, 0)) Then ' Check for duplicates <-- I had no ida AndAlso method existed, cool.
                    filteredItems.Add(food(i, 0)) ' Add the item to the filtered list
                End If
            Next

            filteredItems.Sort() ' Sort the filtered list alphabetically
            For Each item In filteredItems
                DisplayListBox.Items.Add(item) ' Add the item to the display list box
            Next
        Catch ex As Exception ' Handle any exceptions that occur during display population
            MsgBox("Error displaying items: " & ex.Message)
        End Try
    End Sub

    Private Sub FilterChanged(sender As Object, e As EventArgs) Handles FilterByAisleRadioButton.CheckedChanged, FilterByCategoryRadioButton.CheckedChanged
        PopulateFilterComboBox() ' Populate the filter combo box with unique values
        PopulateDisplayListBox(SearchTextBox.Text) ' Pass the current search text
    End Sub

    Private Sub FilterComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FilterComboBox.SelectedIndexChanged
        PopulateDisplayListBox(SearchTextBox.Text) ' Pass the current search text
    End Sub

    Private Sub DisplayListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DisplayListBox.SelectedIndexChanged
        ' Show the selected item details
        Try
            If food Is Nothing Then Exit Sub ' If food is not loaded, exit the sub
            Dim selectedItem As String = TryCast(DisplayListBox.SelectedItem, String) ' Get the selected item
            If String.IsNullOrWhiteSpace(selectedItem) Then Return ' If the selected item is empty, exit the sub

            For i = 0 To food.GetUpperBound(0) ' Loop through the food array
                If food(i, 0) = selectedItem Then ' If the item matches the selected item
                    DisplayLabel.Text = $"You will find {food(i, 0)} on aisle {food(i, 1)} with the {food(i, 2)}"
                    ' Show the item details
                    Exit Sub
                End If
            Next
        Catch ex As Exception ' Handle any exceptions that occur during item selection
            MsgBox("Error showing item details: " & ex.Message)
        End Try
    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        ' Search for items based on the search text
        Try
            If food Is Nothing Then Exit Sub ' If food is not loaded, exit the sub
            Dim searchString As String = SearchTextBox.Text.Trim() ' Get the search text

            DisplayListBox.Items.Clear() ' Clear the display list box
            FilterComboBox.Items.Clear() ' Clear the filter combo box
            FilterComboBox.Items.Add("Show All") ' Add "Show All" option

            Dim foundItems As New List(Of String) ' Create a new list to store found items
            Dim filterValues As New HashSet(Of String) ' Create a new hash set to store filter values

            For i = 0 To food.GetUpperBound(0)
                ' Check if the item matches the search string
                If food(i, 0).IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 _ 'check if the item matches the search string
                   OrElse food(i, 1).IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 _ 'check if the aisle matches the search string
                   OrElse food(i, 2).IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 Then '

                    If Not foundItems.Contains(food(i, 0)) Then 'if the item is not already in the list
                        foundItems.Add(food(i, 0)) 'then add the item to the list
                        DisplayListBox.Items.Add(food(i, 0)) 'and add it to the display list box
                    End If

                    ' Add filter values based on aisle or category
                    If FilterByAisleRadioButton.Checked Then
                        filterValues.Add(food(i, 1)) ' aisle filter
                    ElseIf FilterByCategoryRadioButton.Checked Then
                        filterValues.Add(food(i, 2)) ' category filter
                    End If
                End If
            Next

            ' If no items were found, display a message
            If foundItems.Count = 0 Then
                DisplayLabel.Text = $"Sorry no matches for '{searchString}'"
            Else
                DisplayLabel.Text = ""
            End If

            ' Update the FilterComboBox based on the results
            Dim sortedFilterValues = filterValues.ToList()

            If FilterByAisleRadioButton.Checked Then    'if the aisle filter is selected
                sortedFilterValues.Sort(Function(x, y) y.CompareTo(x)) ' Sort aisle in descending order
            Else
                sortedFilterValues.Sort() ' Sort category in ascending order
            End If

            For Each value In sortedFilterValues '  for each value in the sorted filter values
                FilterComboBox.Items.Add(value) '   add the value to the filter combo box
            Next

            ' Reset filter combo box and radio button state
            FilterComboBox.SelectedIndex = 0 ' Set the default filter combo box to "Show All"
            FilterByAisleRadioButton.Checked = True

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
