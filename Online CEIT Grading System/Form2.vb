Imports System.Data.SqlClient
Imports Transitions

Public Class Form2
    Private Sub MetroButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton1.Click
        FIND_USER(MetroTextBox1.Text, MetroTextBox2.Text)
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

    End Sub

    Private Sub MetroListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim fade As Double
        For fade = 1.1 To 0 Step -0.01
            Me.Opacity = fade
            Me.Refresh()
        Next
        Me.Dispose()
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MetroButton3_Click_1(sender As Object, e As EventArgs)

    End Sub
End Class