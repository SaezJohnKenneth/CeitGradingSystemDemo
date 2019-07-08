Imports System.Data.SqlClient
Public Class Room_Form
    Public RUNNING_USER As Integer

    Private Sub Room_Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()

    End Sub

    Private Sub Room_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FilterTable("SELECT ID AS [Room ID],Unit AS [Room Unit],Story AS Storey,Prefix FROM Room", MetroGrid1)
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

    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        Try
            Dim sqlcon As New SqlConnection(ConnectionString)
            sqlcon.Open()
            Dim cmd As New SqlCommand("INSERT INTO Room(Unit,Story,Prefix) VALUES(@unit,@story,@prefix)", sqlcon)
            cmd.Parameters.AddWithValue("@unit", MetroTextBox1.Text)
            cmd.Parameters.AddWithValue("@story", MetroTextBox2.Text)
            cmd.Parameters.AddWithValue("@prefix", MetroTextBox3.Text)
            cmd.ExecuteNonQuery()
            sqlcon.Close()
            MsgBox("Succesful")
            FilterTable("SELECT ID AS [Room ID],Unit AS [Room Unit],Story AS Storey,Prefix FROM Room", MetroGrid1)
        Catch ex As Exception

        End Try
    End Sub
End Class