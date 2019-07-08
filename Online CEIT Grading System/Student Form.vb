Imports System.Data.SqlClient

Public Class Student_Form
    Public RUNNING_USER As Integer
    Private Sub Student_Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()

    End Sub

    Private Sub Student_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fieldToFilter = "Student.Prefix"
        populateCombobox(MetroComboBox1, "Course", "CourseDescription")
        populateCombobox(MetroComboBox2, "Course", "CourseDescription")
        MetroTextBox3.Text = Date.Now.ToString("yyyy")
        Try
            FilterTable("SELECT Student.Prefix AS [Student ID],Student.Name,Student.Address,Student.ContactNo,Student.CivilStatus,Student.Email,Course.CourseDescription AS Course FROM Student INNER JOIN Course ON Student.CourseID = Course.ID", MetroGrid1)
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
            MsgBox("Successful")

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
            enableContentsForEdit(True)
            clearContents()
            MetroTextBox3.Text = Date.Now.ToString("yyyy")
            MetroButton5.Enabled = True
        Else
            MetroButton2.Text = "Add"
            enableContents(False)
            Try
                Dim sqlcon As New SqlConnection(ConnectionString)
                sqlcon.Open()
                Dim cmd As New SqlCommand("INSERT INTO Student(Batch,Name,CourseID,Prefix,Address,ContactNo,CivilStatus,Email) Values(@batch,@name,@courseid,@prefix,@address,@contact,@status,@email)", sqlcon)
                cmd.Parameters.AddWithValue("@name", MetroTextBox2.Text)
                cmd.Parameters.AddWithValue("@courseid", getTableID("Course", MetroComboBox1.Text, "CourseDescription", "ID"))
                cmd.Parameters.AddWithValue("@address", MetroTextBox4.Text)
                cmd.Parameters.AddWithValue("@batch", MetroTextBox3.Text)
                cmd.Parameters.AddWithValue("@contact", MetroTextBox5.Text)
                cmd.Parameters.AddWithValue("@status", MetroTextBox6.Text)
                cmd.Parameters.AddWithValue("@email", MetroTextBox7.Text)
                cmd.Parameters.AddWithValue("@prefix", "TEMP")
                cmd.ExecuteNonQuery()
                cmd = New SqlCommand("SELECT TOP 1 ID FROM Student ORDER BY ID DESC", sqlcon)
                Dim r As SqlDataReader = cmd.ExecuteReader
                r.Read()
                Dim JUVY_ROSE_DI_NAMAN_MAGANDA_HEHEHEHE_xD As Integer = r(0)
                r.Close()
                cmd = New SqlCommand("UPDATE Student SET Prefix = '" & Date.Now.ToString("yyyy") & "-" & JUVY_ROSE_DI_NAMAN_MAGANDA_HEHEHEHE_xD & "' WHERE ID = " & JUVY_ROSE_DI_NAMAN_MAGANDA_HEHEHEHE_xD, sqlcon)
                cmd.ExecuteNonQuery()
                sqlcon.Close()
                MsgBox("Student Added Succesfully")
                FilterTable("SELECT Student.Prefix AS [Student ID],Student.Name,Student.Address,Student.ContactNo,Student.CivilStatus,Student.Email,Course.CourseDescription AS Course FROM Student INNER JOIN Course ON Student.CourseID = Course.ID", MetroGrid1)
                enableContents(False)
                MetroButton5.Enabled = False
            Catch ex As Exception
                MsgBox("Error: Student Can't Be add" & ex.Message)
            End Try
        End If

    End Sub

    Private Sub MetroTextBox8_Click(sender As Object, e As EventArgs) Handles MetroTextBox8.Click

    End Sub

    Private Sub MetroTextBox8_TextChanged(sender As Object, e As EventArgs) Handles MetroTextBox8.TextChanged
        FilterTable("SELECT Student.Prefix AS [Student ID],Student.Name,Student.Address,Student.ContactNo,Student.CivilStatus,Student.Email,Course.CourseDescription AS Course FROM Student INNER JOIN Course ON Student.CourseID = Course.ID WHERE  " & fieldToFilter & " LIKE '" & MetroTextBox8.Text & "%'", MetroGrid1)
    End Sub
    Private fieldToFilter As String
    Private Sub MetroRadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles MetroRadioButton1.CheckedChanged
        fieldToFilter = "Student.Prefix"
        MetroTextBox8.WaterMark = "Enter Student ID to Filter"
    End Sub

    Private Sub MetroRadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles MetroRadioButton2.CheckedChanged
        fieldToFilter = "Student.Name"
        MetroTextBox8.WaterMark = "Enter Student Name to Filter"
    End Sub

    Private Sub MetroComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MetroComboBox2.SelectedIndexChanged
        FilterTable("SELECT Student.Prefix AS [Student ID],Student.Name,Student.Address,Student.ContactNo,Student.CivilStatus,Student.Email,Course.CourseDescription AS Course FROM Student INNER JOIN Course ON Student.CourseID = Course.ID WHERE Course.CourseDescription = '" & MetroComboBox2.Text & "'", MetroGrid1)
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        If MetroButton3.Text = "Update" Then
            MetroButton3.Text = "Save"
            enableContentsForEdit(True)
            MetroButton4.Enabled = True
        Else
            MetroButton3.Text = "Update"
            enableContentsForEdit(False)
            MetroButton4.Enabled = False
            Try
                Dim co As New SqlConnection(ConnectionString)
                co.Open()
                Dim cmd As New SqlCommand("UPDATE Student SET Student.Name = @name,Student.CourseID=@courseid,Student.Address=@address,Student.ContactNo=@contact,Student.CivilStatus=@status,Student.Email=@email WHERE Student.Prefix = '" & MetroTextBox1.Text & "'", co)
                cmd.Parameters.AddWithValue("@name", MetroTextBox2.Text)
                cmd.Parameters.AddWithValue("@courseid", getTableID("Course", MetroComboBox1.Text, "CourseDescription", "ID"))
                cmd.Parameters.AddWithValue("@address", MetroTextBox4.Text)
                cmd.Parameters.AddWithValue("@batch", MetroTextBox3.Text)
                cmd.Parameters.AddWithValue("@contact", MetroTextBox5.Text)
                cmd.Parameters.AddWithValue("@status", MetroTextBox6.Text)
                cmd.Parameters.AddWithValue("@email", MetroTextBox7.Text)
                cmd.Parameters.AddWithValue("@prefix", "TEMP")
                cmd.ExecuteNonQuery()
                co.Close()
                MsgBox("Student Updated Succesfully")
                FilterTable("SELECT Student.Prefix AS [Student ID],Student.Name,Student.Address,Student.ContactNo,Student.CivilStatus,Student.Email,Course.CourseDescription AS Course FROM Student INNER JOIN Course ON Student.CourseID = Course.ID", MetroGrid1)
                enableContents(False)
            Catch ex As Exception
                MsgBox("Update Error : " & ex.Message)
            End Try
        End If
    End Sub
    Private throwableID As String
    Private Sub MetroGrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles MetroGrid1.CellClick

        Dim con As New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand("SELECT Student.Prefix,Student.Name,Student.Batch,Course.CourseDescription,Student.Address,Student.ContactNo,Student.CivilStatus,Student.Email FROM Student INNER JOIN COurse ON Student.CourseID = Course.ID WHERE Student.Prefix = '" & MetroGrid1.Item(0, e.RowIndex).Value & "'", con)
        con.Open()
        Dim re As SqlDataReader = cmd.ExecuteReader
        re.Read()
        MetroTextBox1.Text = re(0)
        MetroTextBox2.Text = re(1)
        MetroTextBox3.Text = re(2)
        MetroComboBox1.Text = re(3)
        MetroTextBox4.Text = re(4)
        MetroTextBox5.Text = re(5)
        MetroTextBox6.Text = re(6)
        MetroTextBox7.Text = re(7)
        re.Close()
        con.Close()
    End Sub
    Private Sub clearContents()
        MetroTextBox1.Text = ""
        MetroTextBox2.Text = ""
        MetroTextBox3.Text = ""
        MetroComboBox1.Text = ""
        MetroTextBox4.Text = ""
        MetroTextBox5.Text = ""
        MetroTextBox6.Text = ""
        MetroTextBox7.Text = ""
    End Sub
    Private Sub enableContents(ByVal t As Boolean)
        MetroTextBox1.Enabled = t
        MetroTextBox2.Enabled = t
        MetroTextBox3.Enabled = t
        MetroComboBox1.Enabled = t
        MetroTextBox4.Enabled = t
        MetroTextBox5.Enabled = t
        MetroTextBox6.Enabled = t
        MetroTextBox7.Enabled = t
    End Sub
    Private Sub enableContentsForEdit(ByVal t As Boolean)
        MetroTextBox2.Enabled = t
        MetroComboBox1.Enabled = t
        MetroTextBox4.Enabled = t
        MetroTextBox5.Enabled = t
        MetroTextBox6.Enabled = t
        MetroTextBox7.Enabled = t
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        MetroButton3.Text = "Update"
        enableContentsForEdit(False)
        MetroButton4.Enabled = False
        enableContents(False)
    End Sub

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click
        MetroButton2.Text = "Add"
        enableContentsForEdit(False)
        MetroButton5.Enabled = False
        enableContents(False)
    End Sub

    Private Sub MetroGrid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles MetroGrid1.CellContentClick

    End Sub
End Class