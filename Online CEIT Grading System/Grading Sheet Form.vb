Imports System.Data.SqlClient
Public Class Grading_Sheet_Form

    Private Sub Grading_Sheet_Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()

    End Sub

    Private Sub Grading_Sheet_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'FilterTable("SELECT Student.Prefix AS [Student ID],Student.Name AS [Student Name],GradeEntry.Midterm,GradeEntry.Final,GradeEntry.Remarks FROM StudentTakenClass INNER JOIN Class ON StudentTakenClass.ClassID = Class.ID INNER JOIN GradeEntry ON StudentTakenClass.GradeEntry = GradeEntry.ID INNER JOIN Student ON StudentTakenClass.StudentID = Student.ID INNER JOIN Faculty ON Class.FacultyID = Faculty.ID WHERE Class.ID = " & MetroComboBox1.Text, MetroGrid1)
        MetroLabel3.Text = ""
        MetroLabel4.Text = ""
        MetroLabel6.Text = ""
        MetroLabel8.Text = ""
        MetroLabel16.Text = ""
        MetroLabel14.Text = ""
        MetroLabel10.Text = ""
        MetroLabel18.Text = ""
        MetroLabel12.Text = ""
        Try

            Dim con As New SqlConnection(ConnectionString)
            con.Open()
            Dim cmd As New SqlCommand("SELECT Class.ID FROM Class INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN Faculty ON Class.FacultyID = Faculty.ID WHERE Faculty.ID = " & Faculty_Menu_Form.RUNNING_USER, con)
            Dim s As SqlDataReader = cmd.ExecuteReader
            MetroComboBox1.Items.Clear()
            While s.Read
                MetroComboBox1.Items.Add(s(0))
            End While
            s.Close()
            con.Close()
        Catch ex As Exception
            MsgBox("Error : " & ex.Message)
        End Try

    End Sub

    Private Sub MetroComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroComboBox1.SelectedIndexChanged
        Try
            FilterTable("SELECT Student.Prefix AS [Student ID],Student.Name AS [Student Name],GradeEntry.Midterm,GradeEntry.Final,GradeEntry.Remarks,GradeEntry.DateEncoded FROM StudentTakenClass INNER JOIN Class ON StudentTakenClass.ClassID = Class.ID INNER JOIN GradeEntry ON StudentTakenClass.GradeEntry = GradeEntry.ID INNER JOIN Student ON StudentTakenClass.StudentID = Student.ID INNER JOIN Faculty ON Class.FacultyID = Faculty.ID WHERE Class.ID = " & MetroComboBox1.Text & " AND GradeEntry.Status = 'Active'", MetroGrid1)
            parseXMLGradeSheet("SELECT Student.Prefix AS [Student ID],Student.Name AS [Student Name],GradeEntry.Midterm,GradeEntry.Final,GradeEntry.Remarks,GradeEntry.DateEncoded FROM StudentTakenClass INNER JOIN Class ON StudentTakenClass.ClassID = Class.ID INNER JOIN GradeEntry ON StudentTakenClass.GradeEntry = GradeEntry.ID INNER JOIN Student ON StudentTakenClass.StudentID = Student.ID INNER JOIN Faculty ON Class.FacultyID = Faculty.ID WHERE Class.ID = " & MetroComboBox1.Text & " AND GradeEntry.Status = 'Active'")
        Catch ex As Exception

        End Try
        Try
            Dim con As New SqlConnection(ConnectionString)
            con.Open()
            Dim cmd As New SqlCommand("SELECT Subject.Prefix,Subject.SubjectDescription,Subject.Units,Class.YearSem,Section.Name,Class.Schedule,Faculty.ID,Faculty.Name,Room.Prefix FROM Subject INNER JOIN Class ON Class.SubjectID = Subject.ID INNER JOIN Faculty ON Class.FacultyID = Faculty.ID INNER JOIN Section ON Class.SectionID = Section.ID  INNER JOIN Room ON Class.RoomID = Room.ID WHERE Class.ID =  " & MetroComboBox1.Text, con)
            Dim s As SqlDataReader = cmd.ExecuteReader
            s.Read()
            MetroLabel3.Text = s(0)
            MetroLabel4.Text = s(1)
            MetroLabel6.Text = s(2)
            MetroLabel8.Text = s(3)
            MetroLabel16.Text = s(4)
            MetroLabel14.Text = s(5)
            MetroLabel10.Text = s(6)
            MetroLabel18.Text = s(7)
            MetroLabel12.Text = s(8)
            s.Close()

        Catch ex As Exception
            MsgBox("Error : " & ex.Message)
        End Try

    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        PrintForm.Text = "Print Grade Sheet"
        PrintForm.CrystalReportViewer1.ReportSource = "C:\Online CEIT Grading System\Online CEIT Grading System\GradeSheet.rpt"
        PrintForm.ShowDialog()
    End Sub
End Class