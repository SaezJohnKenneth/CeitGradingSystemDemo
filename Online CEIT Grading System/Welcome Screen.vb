Imports System.Data.SqlClient
Imports Transitions
Public Class Welcome_Screen
    Public RUNNING_USER As Integer

    Private Sub Welcome_Screen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim fade As Double
        For fade = 0.00 To 1.1 Step 0.01
            Me.Opacity = fade
            Me.Refresh()
        Next
        MetroLabel1.Text = ""
        MetroLabel2.Text = ""
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
        Me.Refresh()
        Me.Update()
        Threading.Thread.Sleep(2350)
        Me.Refresh()
        Me.Close()
    End Sub

    Private Sub MetroLabel3_Click(sender As Object, e As EventArgs) Handles MetroLabel3.Click

    End Sub

    Private Sub MetroLabel1_Click(sender As Object, e As EventArgs) Handles MetroLabel1.Click

    End Sub

    Private Sub MetroLabel2_Click(sender As Object, e As EventArgs) Handles MetroLabel2.Click

    End Sub

    Private Sub Welcome_Screen_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim fade As Double
        For fade = 1.1 To 0 Step -0.01
            Me.Opacity = fade
            Me.Refresh()
        Next
    End Sub

    Private Sub Welcome_Screen_MarginChanged(sender As Object, e As EventArgs) Handles Me.MarginChanged

    End Sub
End Class