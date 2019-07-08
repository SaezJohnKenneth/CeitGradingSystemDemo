Imports System.Data.SqlClient
Public Class Subject_Form
    Public RUNNING_USER As Integer

    Private Sub Subject_Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()

    End Sub
    Private Sub Subject_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FilterTable("SELECT Subject.Prefix AS [Subject Code],Subject.SubjectDescription AS [Subject Description],Subject.Units,Course.CourseDescription AS [For Course] FROM Subject INNER JOIN Course ON Subject.CourseID = Course.ID", MetroGrid1)
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

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        MetroLabel1.Text = Format(Now, "MMMM , dd , yyyy")
        MetroLabel2.Text = Format(TimeOfDay, "hh : mm : ss tt")

    End Sub

    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        If MetroButton2.Text = "Add" Then
            MetroButton2.Text = "Save"
            MetroComboBox1.Text = ""
            MetroTextBox1.Text = ""
            MetroTextBox2.Text = ""
            MetroComboBox1.Enabled = True
            MetroTextBox1.Enabled = True
            MetroTextBox2.Enabled = True
            MetroButton5.Enabled = True
            populateCombobox(MetroComboBox1, "Course", "Prefix")
        Else
            Dim sqlcon As New SqlConnection(ConnectionString)
            sqlcon.Open()
            Dim cmd As New SqlCommand("SELECT TOP 1 ID FROM Subject ORDER BY ID DESC", sqlcon)
            Dim r As SqlDataReader = cmd.ExecuteReader
            r.Read()
            Dim x As Integer = CInt(r(0)) + 1
            r.Close()

            cmd = New SqlCommand("INSERT INTO Subject(SubjectDescription,CourseID,Units,Prefix) Values(@description,@courseid,@units,@prefix)", sqlcon)
            cmd.Parameters.AddWithValue("@description", MetroTextBox1.Text)
            cmd.Parameters.AddWithValue("@courseid", getTableID("Course", MetroComboBox1.Text, "Prefix", "ID"))
            cmd.Parameters.AddWithValue("@units", CInt(MetroTextBox2.Text))
            cmd.Parameters.AddWithValue("@prefix", MetroComboBox1.Text & "-" & x)
            cmd.ExecuteNonQuery()
            sqlcon.Close()
            FilterTable("SELECT Subject.Prefix AS [Subject Code],Subject.SubjectDescription AS [Subject Description],Subject.Units,Course.CourseDescription AS [For Course] FROM Subject INNER JOIN Course ON Subject.CourseID = Course.ID", MetroGrid1)
            MsgBox("Added Succesfully")
            MetroComboBox1.Text = ""
            MetroTextBox1.Text = ""
            MetroTextBox2.Text = ""
            MetroButton2.Text = "Add"
            MetroComboBox1.Enabled = False
            MetroTextBox1.Enabled = False
            MetroTextBox2.Enabled = False
            MetroButton5.Enabled = False
        End If

    End Sub
    Private Sub MetroGrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles MetroGrid1.CellClick
        Try
            throwableID = MetroGrid1.Item(0, e.RowIndex).Value
            Dim con As New SqlConnection(ConnectionString)
            con.Open()
            Dim cmd As New SqlCommand("SELECT Subject.SubjectDescription AS [Subject Description],Subject.Units,Course.Prefix FROM Subject INNER JOIN Course ON Subject.CourseID = Course.ID WHERE Subject.Prefix = '" & throwableID & "'", con)
            Dim r As SqlDataReader = cmd.ExecuteReader
            r.Read()
            MetroTextBox1.Text = r(0)
            MetroTextBox2.Text = r(1)
            MetroComboBox1.Text = r(2)
            r.Close()
            con.Close()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub MetroGrid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles MetroGrid1.CellContentClick

    End Sub
    Private throwableID As String

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        If MetroButton3.Text = "Update" Then
            MetroButton3.Text = "Save"
            MetroTextBox1.Enabled = True
            MetroTextBox2.Enabled = True
            MetroButton4.Enabled = True
            populateCombobox(MetroComboBox1, "Course", "Prefix")
        Else
            Try
                Dim sqlcon As New SqlConnection(ConnectionString)
                sqlcon.Open()

                Dim cmd As New SqlCommand("UPDATE Subject SET SubjectDescription = @description,Units=@units WHERE Prefix = '" & throwableID & "'", sqlcon)
                cmd.Parameters.AddWithValue("@description", MetroTextBox1.Text)
                cmd.Parameters.AddWithValue("@units", CInt(MetroTextBox2.Text))
                cmd.ExecuteNonQuery()
                sqlcon.Close()
                FilterTable("SELECT Subject.Prefix AS [Subject Code],Subject.SubjectDescription AS [Subject Description],Subject.Units,Course.CourseDescription AS [For Course] FROM Subject INNER JOIN Course ON Subject.CourseID = Course.ID", MetroGrid1)
                MsgBox("Subject Updated Succesfully")
                MetroButton3.Text = "Update"
                MetroComboBox1.Enabled = False
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
        MetroComboBox1.Enabled = False
        MetroTextBox1.Enabled = False
        MetroTextBox2.Enabled = False
        MetroButton4.Enabled = False
    End Sub

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click
        MetroButton2.Text = "Add"
        MetroComboBox1.Enabled = False
        MetroTextBox1.Enabled = False
        MetroTextBox2.Enabled = False
        MetroButton5.Enabled = False
    End Sub
End Class