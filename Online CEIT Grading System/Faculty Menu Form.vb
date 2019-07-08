Imports System.Data.SqlClient

Public Class Faculty_Menu_Form
    Public RUNNING_USER As Integer

    Private Sub Faculty_Menu_Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Application.ApplicationContext.MainForm = Form2
        Me.Dispose()
        Form2.ShowDialog()
    End Sub

    Private Sub Faculty_Menu_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'OY Juvy eto nga pala ung animation. Masyado kang spoiled brat hehehe
        Dim t As New Transitions.Transition(New Transitions.TransitionType_Acceleration(520))
        Dim q As New Transitions.Transition(New Transitions.TransitionType_Acceleration(520))
        Dim t1 As New Transitions.Transition(New Transitions.TransitionType_Acceleration(520))
        Dim q1 As New Transitions.Transition(New Transitions.TransitionType_Acceleration(520))
        Dim q2 As New Transitions.Transition(New Transitions.TransitionType_Acceleration(520))

        MetroTile1.Height = 1
        MetroTile1.Width = 1
        MetroTile2.Height = 1
        MetroTile2.Width = 1
        MetroTile3.Height = 1
        MetroTile3.Width = 1
        MetroTile4.Height = 1
        MetroTile4.Width = 1
        MetroPanel2.Height = 1

        t.add(MetroTile1, "Width", 170)
        t.add(MetroTile1, "Height", 144)
        Application.DoEvents()
        t.run()

        q.add(MetroTile2, "Width", 170)
        q.add(MetroTile2, "Height", 144)
        Application.DoEvents()
        q.run()

        t1.add(MetroTile3, "Width", 170)
        t1.add(MetroTile3, "Height", 144)
        Application.DoEvents()
        t1.run()

        q1.add(MetroTile4, "Width", 170)
        q1.add(MetroTile4, "Height", 144)
        Application.DoEvents()
        q1.run()

        q2.add(MetroPanel2, "Height", 90)
        Application.DoEvents()
        q2.run()


        'bading

        Try
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
                MetroLabel3.Text = name2
                MetroLabel4.Text = access
                MetroPanel1.BackgroundImage = GetImageFromByte(readr(2))
            End While
            readr.Close()
            sqlcon.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        MetroLabel1.Text = Format(Now, "MMMM , dd , yyyy")
        MetroLabel2.Text = Format(TimeOfDay, "hh : mm : ss tt")
    End Sub

    Private Sub MetroTile2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile2.Click
        Midterm_Form.ShowDialog()

    End Sub

    Private Sub MetroTile3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile3.Click
        Final_Form.ShowDialog()

    End Sub

    Private Sub MetroTile4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile4.Click
        Grading_Sheet_Form.ShowDialog()

    End Sub

    Private Sub MetroTile1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroTile1.Click
        INC_Form.ShowDialog()

    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs)

    End Sub
End Class