<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StansGroceryForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SearchTextBox = New System.Windows.Forms.TextBox()
        Me.SearchButton = New System.Windows.Forms.Button()
        Me.FilterGroupBox = New System.Windows.Forms.GroupBox()
        Me.FilterByCategoryRadioButton = New System.Windows.Forms.RadioButton()
        Me.FilterByAisleRadioButton = New System.Windows.Forms.RadioButton()
        Me.FilterComboBox = New System.Windows.Forms.ComboBox()
        Me.DisplayListBox = New System.Windows.Forms.ListBox()
        Me.DisplayLabel = New System.Windows.Forms.Label()
        Me.TopMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ContextSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterGroupBox.SuspendLayout()
        Me.TopMenuStrip.SuspendLayout()
        Me.MainContextMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'SearchTextBox
        '
        Me.SearchTextBox.Location = New System.Drawing.Point(0, 31)
        Me.SearchTextBox.Name = "SearchTextBox"
        Me.SearchTextBox.Size = New System.Drawing.Size(323, 22)
        Me.SearchTextBox.TabIndex = 0
        '
        'SearchButton
        '
        Me.SearchButton.Location = New System.Drawing.Point(329, 30)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(91, 23)
        Me.SearchButton.TabIndex = 1
        Me.SearchButton.Text = "Search"
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'FilterGroupBox
        '
        Me.FilterGroupBox.Controls.Add(Me.FilterByCategoryRadioButton)
        Me.FilterGroupBox.Controls.Add(Me.FilterByAisleRadioButton)
        Me.FilterGroupBox.Location = New System.Drawing.Point(0, 61)
        Me.FilterGroupBox.Name = "FilterGroupBox"
        Me.FilterGroupBox.Size = New System.Drawing.Size(420, 53)
        Me.FilterGroupBox.TabIndex = 2
        Me.FilterGroupBox.TabStop = False
        Me.FilterGroupBox.Text = "Filter Options"
        '
        'FilterByCategoryRadioButton
        '
        Me.FilterByCategoryRadioButton.AutoSize = True
        Me.FilterByCategoryRadioButton.Location = New System.Drawing.Point(197, 20)
        Me.FilterByCategoryRadioButton.Name = "FilterByCategoryRadioButton"
        Me.FilterByCategoryRadioButton.Size = New System.Drawing.Size(133, 20)
        Me.FilterByCategoryRadioButton.TabIndex = 1
        Me.FilterByCategoryRadioButton.TabStop = True
        Me.FilterByCategoryRadioButton.Text = "Filter by Category"
        Me.FilterByCategoryRadioButton.UseVisualStyleBackColor = True
        '
        'FilterByAisleRadioButton
        '
        Me.FilterByAisleRadioButton.AutoSize = True
        Me.FilterByAisleRadioButton.Checked = True
        Me.FilterByAisleRadioButton.Location = New System.Drawing.Point(64, 21)
        Me.FilterByAisleRadioButton.Name = "FilterByAisleRadioButton"
        Me.FilterByAisleRadioButton.Size = New System.Drawing.Size(108, 20)
        Me.FilterByAisleRadioButton.TabIndex = 0
        Me.FilterByAisleRadioButton.TabStop = True
        Me.FilterByAisleRadioButton.Text = "Filter by Aisle"
        Me.FilterByAisleRadioButton.UseVisualStyleBackColor = True
        '
        'FilterComboBox
        '
        Me.FilterComboBox.FormattingEnabled = True
        Me.FilterComboBox.Location = New System.Drawing.Point(0, 120)
        Me.FilterComboBox.Name = "FilterComboBox"
        Me.FilterComboBox.Size = New System.Drawing.Size(420, 24)
        Me.FilterComboBox.TabIndex = 3
        '
        'DisplayListBox
        '
        Me.DisplayListBox.FormattingEnabled = True
        Me.DisplayListBox.ItemHeight = 16
        Me.DisplayListBox.Location = New System.Drawing.Point(0, 160)
        Me.DisplayListBox.Name = "DisplayListBox"
        Me.DisplayListBox.Size = New System.Drawing.Size(420, 260)
        Me.DisplayListBox.Sorted = True
        Me.DisplayListBox.TabIndex = 4
        '
        'DisplayLabel
        '
        Me.DisplayLabel.AutoSize = True
        Me.DisplayLabel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DisplayLabel.Location = New System.Drawing.Point(0, 437)
        Me.DisplayLabel.Name = "DisplayLabel"
        Me.DisplayLabel.Size = New System.Drawing.Size(32, 16)
        Me.DisplayLabel.TabIndex = 5
        Me.DisplayLabel.Text = "Item"
        '
        'TopMenuStrip
        '
        Me.TopMenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.TopMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.TopMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.TopMenuStrip.Name = "TopMenuStrip"
        Me.TopMenuStrip.Size = New System.Drawing.Size(432, 28)
        Me.TopMenuStrip.TabIndex = 6
        Me.TopMenuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(46, 24)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(136, 26)
        Me.SearchToolStripMenuItem.Text = "&Search"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(136, 26)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(55, 24)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(133, 26)
        Me.AboutToolStripMenuItem.Text = "Abo&ut"
        '
        'MainContextMenuStrip
        '
        Me.MainContextMenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MainContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.ContextSearch, Me.ContextExit})
        Me.MainContextMenuStrip.Name = "MainContextMenuStrip"
        Me.MainContextMenuStrip.Size = New System.Drawing.Size(123, 58)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(119, 6)
        '
        'ContextSearch
        '
        Me.ContextSearch.Name = "ContextSearch"
        Me.ContextSearch.Size = New System.Drawing.Size(122, 24)
        Me.ContextSearch.Text = "Search"
        '
        'ContextExit
        '
        Me.ContextExit.Name = "ContextExit"
        Me.ContextExit.Size = New System.Drawing.Size(122, 24)
        Me.ContextExit.Text = "Exit"
        '
        'StansGroceryForm
        '
        Me.AcceptButton = Me.SearchButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 453)
        Me.ContextMenuStrip = Me.MainContextMenuStrip
        Me.Controls.Add(Me.DisplayLabel)
        Me.Controls.Add(Me.DisplayListBox)
        Me.Controls.Add(Me.FilterComboBox)
        Me.Controls.Add(Me.FilterGroupBox)
        Me.Controls.Add(Me.SearchButton)
        Me.Controls.Add(Me.SearchTextBox)
        Me.Controls.Add(Me.TopMenuStrip)
        Me.MainMenuStrip = Me.TopMenuStrip
        Me.Name = "StansGroceryForm"
        Me.Text = "Stan's Grocery"
        Me.FilterGroupBox.ResumeLayout(False)
        Me.FilterGroupBox.PerformLayout()
        Me.TopMenuStrip.ResumeLayout(False)
        Me.TopMenuStrip.PerformLayout()
        Me.MainContextMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SearchTextBox As TextBox
    Friend WithEvents SearchButton As Button
    Friend WithEvents FilterGroupBox As GroupBox
    Friend WithEvents FilterByCategoryRadioButton As RadioButton
    Friend WithEvents FilterByAisleRadioButton As RadioButton
    Friend WithEvents FilterComboBox As ComboBox
    Friend WithEvents DisplayListBox As ListBox
    Friend WithEvents DisplayLabel As Label
    Friend WithEvents TopMenuStrip As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MainContextMenuStrip As ContextMenuStrip
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ContextSearch As ToolStripMenuItem
    Friend WithEvents ContextExit As ToolStripMenuItem
End Class
