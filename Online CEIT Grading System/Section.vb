Imports System.Data.SqlClient
Public Class Section
    Private Sub Section_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub Section_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populateCombobox(MetroComboBox1, "Course", "CourseDescription")
        MetroComboBox1.Items.Add("Petition")

    End Sub
    Private id As Integer
    Private Sub MetroComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MetroComboBox1.SelectedIndexChanged

        If MetroComboBox1.Text = "Petition" Then
            MetroLabel4.Text = "COMMON" & getCurrentActiveSem()
            id = 1

        Else
            MetroLabel4.Text = getTableID("Course", MetroComboBox1.Text, "CourseDescription", "ID").ToString("00")
            id = getTableID("Course", MetroComboBox1.Text, "CourseDescription", "ID").ToString("00")
        End If
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Try
            Dim con As New SqlConnection(ConnectionString)
            con.Open()
            Dim cmd As New SqlCommand("INSERT INTO Section(Name,CourseID) VALUES(@name,@id)", con)
            cmd.Parameters.AddWithValue("@name", MetroLabel3.Text & "-" & MetroLabel4.Text & "-" & MetroTextBox1.Text)
            cmd.Parameters.AddWithValue("@id", id)
            cmd.ExecuteNonQuery()
            con.Close()
            MsgBox("Section Added Succesfully", vbInformation)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class