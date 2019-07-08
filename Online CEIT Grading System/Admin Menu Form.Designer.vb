<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Menu_Form
    Inherits MetroFramework.Forms.MetroForm

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
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel4 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTile1 = New MetroFramework.Controls.MetroTile()
        Me.MetroTile2 = New MetroFramework.Controls.MetroTile()
        Me.MetroTile3 = New MetroFramework.Controls.MetroTile()
        Me.MetroTile4 = New MetroFramework.Controls.MetroTile()
        Me.MetroLabel5 = New MetroFramework.Controls.MetroLabel()
        Me.MetroPanel1 = New MetroFramework.Controls.MetroPanel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MetroPanel2 = New MetroFramework.Controls.MetroPanel()
        Me.MetroButton7 = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel6 = New MetroFramework.Controls.MetroLabel()
        Me.MetroButton6 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton5 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton4 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton3 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton2 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton1 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton8 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton9 = New MetroFramework.Controls.MetroButton()
        Me.MetroButton10 = New MetroFramework.Controls.MetroButton()
        Me.MetroPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall
        Me.MetroLabel1.Location = New System.Drawing.Point(142, 28)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(58, 25)
        Me.MetroLabel1.TabIndex = 1
        Me.MetroLabel1.Text = "Name"
        Me.MetroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(142, 53)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(80, 19)
        Me.MetroLabel2.TabIndex = 2
        Me.MetroLabel2.Text = "Access Level"
        Me.MetroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.Location = New System.Drawing.Point(721, 28)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(74, 19)
        Me.MetroLabel3.TabIndex = 3
        Me.MetroLabel3.Text = "Date Today"
        Me.MetroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroLabel4
        '
        Me.MetroLabel4.AutoSize = True
        Me.MetroLabel4.Location = New System.Drawing.Point(721, 47)
        Me.MetroLabel4.Name = "MetroLabel4"
        Me.MetroLabel4.Size = New System.Drawing.Size(76, 19)
        Me.MetroLabel4.TabIndex = 4
        Me.MetroLabel4.Text = "Time Today"
        Me.MetroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroTile1
        '
        Me.MetroTile1.ActiveControl = Nothing
        Me.MetroTile1.Location = New System.Drawing.Point(77, 150)
        Me.MetroTile1.Name = "MetroTile1"
        Me.MetroTile1.Size = New System.Drawing.Size(170, 144)
        Me.MetroTile1.Style = MetroFramework.MetroColorStyle.Teal
        Me.MetroTile1.TabIndex = 5
        Me.MetroTile1.Text = "Faculty and Access Users"
        Me.MetroTile1.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroTile1.UseSelectable = True
        '
        'MetroTile2
        '
        Me.MetroTile2.ActiveControl = Nothing
        Me.MetroTile2.Location = New System.Drawing.Point(253, 150)
        Me.MetroTile2.Name = "MetroTile2"
        Me.MetroTile2.Size = New System.Drawing.Size(168, 144)
        Me.MetroTile2.Style = MetroFramework.MetroColorStyle.Green
        Me.MetroTile2.TabIndex = 0
        Me.MetroTile2.Text = "Students"
        Me.MetroTile2.UseSelectable = True
        '
        'MetroTile3
        '
        Me.MetroTile3.ActiveControl = Nothing
        Me.MetroTile3.Location = New System.Drawing.Point(427, 150)
        Me.MetroTile3.Name = "MetroTile3"
        Me.MetroTile3.Size = New System.Drawing.Size(168, 144)
        Me.MetroTile3.TabIndex = 0
        Me.MetroTile3.Text = "Class"
        Me.MetroTile3.UseSelectable = True
        '
        'MetroTile4
        '
        Me.MetroTile4.ActiveControl = Nothing
        Me.MetroTile4.Location = New System.Drawing.Point(601, 150)
        Me.MetroTile4.Name = "MetroTile4"
        Me.MetroTile4.Size = New System.Drawing.Size(170, 144)
        Me.MetroTile4.Style = MetroFramework.MetroColorStyle.Orange
        Me.MetroTile4.TabIndex = 0
        Me.MetroTile4.Text = "Drop / Withdraw"
        Me.MetroTile4.UseSelectable = True
        '
        'MetroLabel5
        '
        Me.MetroLabel5.AutoSize = True
        Me.MetroLabel5.BackColor = System.Drawing.Color.Transparent
        Me.MetroLabel5.Location = New System.Drawing.Point(286, 424)
        Me.MetroLabel5.Name = "MetroLabel5"
        Me.MetroLabel5.Size = New System.Drawing.Size(278, 19)
        Me.MetroLabel5.TabIndex = 6
        Me.MetroLabel5.Text = "© Online Grading System. All Rights Reserved"
        Me.MetroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroPanel1
        '
        Me.MetroPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MetroPanel1.HorizontalScrollbarBarColor = True
        Me.MetroPanel1.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.HorizontalScrollbarSize = 10
        Me.MetroPanel1.Location = New System.Drawing.Point(77, 28)
        Me.MetroPanel1.Name = "MetroPanel1"
        Me.MetroPanel1.Size = New System.Drawing.Size(59, 55)
        Me.MetroPanel1.TabIndex = 34
        Me.MetroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroPanel1.VerticalScrollbarBarColor = True
        Me.MetroPanel1.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.VerticalScrollbarSize = 10
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'MetroPanel2
        '
        Me.MetroPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MetroPanel2.Controls.Add(Me.MetroButton10)
        Me.MetroPanel2.Controls.Add(Me.MetroButton9)
        Me.MetroPanel2.Controls.Add(Me.MetroButton8)
        Me.MetroPanel2.Controls.Add(Me.MetroButton7)
        Me.MetroPanel2.Controls.Add(Me.MetroLabel6)
        Me.MetroPanel2.Controls.Add(Me.MetroButton6)
        Me.MetroPanel2.Controls.Add(Me.MetroButton5)
        Me.MetroPanel2.Controls.Add(Me.MetroButton4)
        Me.MetroPanel2.Controls.Add(Me.MetroButton3)
        Me.MetroPanel2.Controls.Add(Me.MetroButton2)
        Me.MetroPanel2.Controls.Add(Me.MetroButton1)
        Me.MetroPanel2.HorizontalScrollbarBarColor = True
        Me.MetroPanel2.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel2.HorizontalScrollbarSize = 10
        Me.MetroPanel2.Location = New System.Drawing.Point(0, 7)
        Me.MetroPanel2.Name = "MetroPanel2"
        Me.MetroPanel2.Size = New System.Drawing.Size(26, 454)
        Me.MetroPanel2.TabIndex = 35
        Me.MetroPanel2.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroPanel2.UseCustomBackColor = True
        Me.MetroPanel2.VerticalScrollbarBarColor = True
        Me.MetroPanel2.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel2.VerticalScrollbarSize = 10
        '
        'MetroButton7
        '
        Me.MetroButton7.Location = New System.Drawing.Point(0, 0)
        Me.MetroButton7.Name = "MetroButton7"
        Me.MetroButton7.Size = New System.Drawing.Size(26, 454)
        Me.MetroButton7.TabIndex = 9
        Me.MetroButton7.Text = ">>"
        Me.MetroButton7.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroButton7.UseCustomBackColor = True
        Me.MetroButton7.UseSelectable = True
        '
        'MetroLabel6
        '
        Me.MetroLabel6.AutoSize = True
        Me.MetroLabel6.BackColor = System.Drawing.Color.Transparent
        Me.MetroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall
        Me.MetroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Bold
        Me.MetroLabel6.Location = New System.Drawing.Point(96, 18)
        Me.MetroLabel6.Name = "MetroLabel6"
        Me.MetroLabel6.Size = New System.Drawing.Size(81, 25)
        Me.MetroLabel6.TabIndex = 8
        Me.MetroLabel6.Text = "Settings"
        Me.MetroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroLabel6.UseCustomBackColor = True
        '
        'MetroButton6
        '
        Me.MetroButton6.Location = New System.Drawing.Point(32, 256)
        Me.MetroButton6.Name = "MetroButton6"
        Me.MetroButton6.Size = New System.Drawing.Size(206, 23)
        Me.MetroButton6.TabIndex = 7
        Me.MetroButton6.Text = "Encoding Deadline"
        Me.MetroButton6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MetroButton6.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroButton6.UseCustomBackColor = True
        Me.MetroButton6.UseSelectable = True
        '
        'MetroButton5
        '
        Me.MetroButton5.Location = New System.Drawing.Point(32, 227)
        Me.MetroButton5.Name = "MetroButton5"
        Me.MetroButton5.Size = New System.Drawing.Size(206, 23)
        Me.MetroButton5.TabIndex = 6
        Me.MetroButton5.Text = "Set Active Sem"
        Me.MetroButton5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MetroButton5.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroButton5.UseCustomBackColor = True
        Me.MetroButton5.UseSelectable = True
        '
        'MetroButton4
        '
        Me.MetroButton4.Location = New System.Drawing.Point(32, 198)
        Me.MetroButton4.Name = "MetroButton4"
        Me.MetroButton4.Size = New System.Drawing.Size(206, 23)
        Me.MetroButton4.TabIndex = 5
        Me.MetroButton4.Text = "Restore Database"
        Me.MetroButton4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MetroButton4.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroButton4.UseCustomBackColor = True
        Me.MetroButton4.UseSelectable = True
        '
        'MetroButton3
        '
        Me.MetroButton3.Location = New System.Drawing.Point(32, 169)
        Me.MetroButton3.Name = "MetroButton3"
        Me.MetroButton3.Size = New System.Drawing.Size(206, 23)
        Me.MetroButton3.TabIndex = 4
        Me.MetroButton3.Text = "Backup Database"
        Me.MetroButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MetroButton3.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroButton3.UseCustomBackColor = True
        Me.MetroButton3.UseSelectable = True
        '
        'MetroButton2
        '
        Me.MetroButton2.Location = New System.Drawing.Point(32, 117)
        Me.MetroButton2.Name = "MetroButton2"
        Me.MetroButton2.Size = New System.Drawing.Size(206, 23)
        Me.MetroButton2.TabIndex = 3
        Me.MetroButton2.Text = "Courses"
        Me.MetroButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MetroButton2.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroButton2.UseCustomBackColor = True
        Me.MetroButton2.UseSelectable = True
        '
        'MetroButton1
        '
        Me.MetroButton1.Location = New System.Drawing.Point(32, 89)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(206, 23)
        Me.MetroButton1.TabIndex = 2
        Me.MetroButton1.Text = "Rooms"
        Me.MetroButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MetroButton1.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroButton1.UseCustomBackColor = True
        Me.MetroButton1.UseSelectable = True
        '
        'MetroButton8
        '
        Me.MetroButton8.Location = New System.Drawing.Point(32, 144)
        Me.MetroButton8.Name = "MetroButton8"
        Me.MetroButton8.Size = New System.Drawing.Size(206, 23)
        Me.MetroButton8.TabIndex = 10
        Me.MetroButton8.Text = "Subjects"
        Me.MetroButton8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MetroButton8.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroButton8.UseCustomBackColor = True
        Me.MetroButton8.UseSelectable = True
        '
        'MetroButton9
        '
        Me.MetroButton9.Location = New System.Drawing.Point(30, 285)
        Me.MetroButton9.Name = "MetroButton9"
        Me.MetroButton9.Size = New System.Drawing.Size(206, 23)
        Me.MetroButton9.TabIndex = 11
        Me.MetroButton9.Text = "Student Grade Slip"
        Me.MetroButton9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MetroButton9.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroButton9.UseCustomBackColor = True
        Me.MetroButton9.UseSelectable = True
        '
        'MetroButton10
        '
        Me.MetroButton10.Location = New System.Drawing.Point(32, 61)
        Me.MetroButton10.Name = "MetroButton10"
        Me.MetroButton10.Size = New System.Drawing.Size(206, 23)
        Me.MetroButton10.TabIndex = 12
        Me.MetroButton10.Text = "Section"
        Me.MetroButton10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MetroButton10.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroButton10.UseCustomBackColor = True
        Me.MetroButton10.UseSelectable = True
        '
        'Admin_Menu_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(843, 462)
        Me.Controls.Add(Me.MetroPanel2)
        Me.Controls.Add(Me.MetroPanel1)
        Me.Controls.Add(Me.MetroLabel5)
        Me.Controls.Add(Me.MetroTile4)
        Me.Controls.Add(Me.MetroTile3)
        Me.Controls.Add(Me.MetroTile2)
        Me.Controls.Add(Me.MetroTile1)
        Me.Controls.Add(Me.MetroLabel4)
        Me.Controls.Add(Me.MetroLabel3)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Name = "Admin_Menu_Form"
        Me.Style = MetroFramework.MetroColorStyle.Green
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroPanel2.ResumeLayout(False)
        Me.MetroPanel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel3 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel4 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroTile1 As MetroFramework.Controls.MetroTile
    Friend WithEvents MetroTile2 As MetroFramework.Controls.MetroTile
    Friend WithEvents MetroTile3 As MetroFramework.Controls.MetroTile
    Friend WithEvents MetroTile4 As MetroFramework.Controls.MetroTile
    Friend WithEvents MetroLabel5 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroPanel1 As MetroFramework.Controls.MetroPanel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MetroPanel2 As MetroFramework.Controls.MetroPanel
    Friend WithEvents MetroButton5 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton4 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton3 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton2 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton1 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroLabel6 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroButton6 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton7 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton8 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton9 As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButton10 As MetroFramework.Controls.MetroButton
End Class
