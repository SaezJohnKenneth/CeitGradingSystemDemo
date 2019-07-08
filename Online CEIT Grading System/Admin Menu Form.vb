Imports System.Data.SqlClient
Public Class Admin_Menu_Form
    Public RUNNING_USER As Integer
    Private Sub MetroTile1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile1.Click
        Faculty_Form.ShowDialog()
    End Sub

    Private Sub Admin_Menu_Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Application.ApplicationContext.MainForm = Form2
        Me.Dispose()
        Form2.ShowDialog()
    End Sub

    Private Sub Admin_Menu_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sqlcon As New SqlConnection(ConnectionString)

        sqlcon.Open()
        Dim cmd As New SqlCommand("SELECT * FROM [Faculty] where id = " & RUNNING_USER, sqlcon)
        Dim readr As SqlDataReader = cmd.ExecuteReader
        Dim runInt As Integer = 0
        Dim name2 As String
        Dim id As String
        Dim access As String
        While readr.Read
            id = readr(0)
            name2 = readr(1)
            access = readr(10)
            MetroLabel1.Text = name2
            MetroLabel2.Text = access
            MetroPanel1.BackgroundImage = GetImageFromByte(readr(2))
        End While
        readr.Close()
        sqlcon.Close()


    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        MetroLabel3.Text = Format(Now, "MMMM , dd , yyyy")
        MetroLabel4.Text = Format(TimeOfDay, "hh : mm : ss tt")
    End Sub

    Private Sub MetroTile4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile4.Click
        Drop_Form.ShowDialog()

    End Sub

    Private Sub MetroTile5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Subject_Form.ShowDialog()

    End Sub

    Private Sub MetroTile6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Course_Form.ShowDialog()

    End Sub

    Private Sub MetroTile7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Room_Form.ShowDialog()

    End Sub

    Private Sub MetroTile2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile2.Click
        Student_Form.ShowDialog()

    End Sub

    Private Sub MetroTile3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile3.Click
        Class_Form.ShowDialog()
    End Sub

    Private Sub MetroPanel2_Paint(sender As Object, e As PaintEventArgs) Handles MetroPanel2.Paint

    End Sub

    Private Sub MetroButton7_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub MetroButton7_Click_1(sender As Object, e As EventArgs) Handles MetroButton7.Click
        MetroPanel2.Focus()
        Dim anim As New Transitions.Transition(New Transitions.TransitionType_EaseInEaseOut(300))
        If MetroButton7.Text = ">>" Then
            anim.add(MetroPanel2, "Width", 263)
            Application.DoEvents()
            anim.run()
            MetroButton7.Text = "<<"
        Else
            anim.add(MetroPanel2, "Width", 26)
            Application.DoEvents()
            anim.run()
            MetroButton7.Text = ">>"
        End If
    End Sub

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click
        SetActiveSem.ShowDialog()
    End Sub

    Private Sub MetroButton6_Click(sender As Object, e As EventArgs) Handles MetroButton6.Click
        SetFinalEncoding.ShowDialog()
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Room_Form.ShowDialog()
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Course_Form.ShowDialog()
    End Sub

    Private Sub MetroButton8_Click(sender As Object, e As EventArgs) Handles MetroButton8.Click
        Subject_Form.ShowDialog()
    End Sub

    Private Sub MetroButton9_Click(sender As Object, e As EventArgs) Handles MetroButton9.Click
        GradeSlip.ShowDialog()
    End Sub

    Private Sub MetroButton10_Click(sender As Object, e As EventArgs) Handles MetroButton10.Click
        Section.ShowDialog()
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        BackupDB.ShowDialog()
    End Sub
End Class