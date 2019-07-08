Imports System.Data.SqlClient

Public Class Course_Form
    Public RUNNING_USER As Integer

    Private Sub Course_Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()

    End Sub
    Private Sub Course_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FilterTable("SELECT ID AS [Course ID],CourseDescription AS [Course Description],Prefix FROM Course", MetroGrid1)
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
        If MetroButton2.Text = "Add" Then
            MetroButton2.Text = "Save"
            MetroTextBox1.Text = ""
            MetroTextBox2.Text = ""
            MetroTextBox1.Enabled = True
            MetroTextBox2.Enabled = True
            MetroButton5.Enabled = True
        Else
            Try
                Dim sqlcon As New SqlConnection(ConnectionString)
                sqlcon.Open()
                Dim sqlcom As New SqlCommand("INSERT INTO Course(CourseDescription,Prefix) VALUES(@description,@prefix)", sqlcon)
                sqlcom.Parameters.AddWithValue("@description", MetroTextBox1.Text)
                sqlcom.Parameters.AddWithValue("@prefix", MetroTextBox2.Text)
                sqlcom.ExecuteNonQuery()
                sqlcon.Close()
                MsgBox("Successful")
                FilterTable("SELECT ID AS [Course ID],CourseDescription AS [Course Description],Prefix FROM Course", MetroGrid1)
                MetroTextBox1.Text = ""
                MetroTextBox2.Text = ""
                MetroButton2.Text = "Add"
                MetroTextBox1.Enabled = False
                MetroTextBox2.Enabled = False
                MetroButton5.Enabled = False
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click
        MetroButton2.Text = "Add"
        MetroTextBox1.Enabled = False
        MetroTextBox2.Enabled = False
        MetroButton5.Enabled = False
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        If MetroButton3.Text = "Update" Then
            MetroButton3.Text = "Save"
            MetroTextBox1.Enabled = True
            MetroTextBox2.Enabled = True
            MetroButton4.Enabled = True
        Else
            Try
                Dim sqlcon As New SqlConnection(ConnectionString)
                sqlcon.Open()

                Dim sqlcom As New SqlCommand("UPDATE Course SET CourseDescription = @description,Prefix = @prefix WHERE ID = " & throwableID & "", sqlcon)
                sqlcom.Parameters.AddWithValue("@description", MetroTextBox1.Text)
                sqlcom.Parameters.AddWithValue("@prefix", MetroTextBox2.Text)
                sqlcom.ExecuteNonQuery()
                sqlcon.Close()
                MsgBox("Successful")
                FilterTable("SELECT ID AS [Course ID],CourseDescription AS [Course Description],Prefix FROM Course", MetroGrid1)
                MetroTextBox1.Text = ""
                MetroTextBox2.Text = ""
                MetroButton3.Text = "Update"
                MetroTextBox1.Enabled = False
                MetroTextBox2.Enabled = False
                MetroButton4.Enabled = False
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        MetroButton3.Text = "Update"
        MetroTextBox1.Enabled = False
        MetroTextBox2.Enabled = False
        MetroButton4.Enabled = False
    End Sub

    Private Sub MetroGrid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles MetroGrid1.CellContentClick

    End Sub
    Private throwableID As Integer
    Private Sub MetroGrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles MetroGrid1.CellClick
        throwableID = MetroGrid1.Item(0, e.RowIndex).Value
        MetroTextBox1.Text = MetroGrid1.Item(1, e.RowIndex).Value
        MetroTextBox2.Text = MetroGrid1.Item(2, e.RowIndex).Value
    End Sub
End Class