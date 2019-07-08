Imports System.Data.SqlClient
Public Class GradeSlip
    Public studentID As String
    Private Sub GradeSlip_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
    Private Sub GradeSlip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = 110

    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Try
            Dim con As New SqlConnection(ConnectionString)
            con.Open()
            Dim cmd As New SqlCommand("SELECT Student.Prefix,Student.Name,Course.CourseDescription FROM Student INNER JOIN Course ON Student.CourseID = Course.ID WHERE Student.Prefix = '" & MetroTextBox1.Text & "'", con)
            Dim r As SqlDataReader = cmd.ExecuteReader
            r.Read()
            MetroLabel2.Text = r(0)
            MetroLabel3.Text = r(1)
            MetroLabel5.Text = r(2)
            r.Close()
            con.Close()
            Dim q As New Transitions.Transition(New Transitions.TransitionType_EaseInEaseOut(300))
            q.add(Me, "Height", 443)
            Application.DoEvents()
            q.run()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            FilterTable("SELECT Subject.Prefix AS [Subject Code],Subject.SubjectDescription AS [Subject Description],Subject.Units,GradeEntry.Average,Faculty.Name AS [Faculty] FROM StudentTakenClass INNER JOIN Student ON StudentTakenClass.StudentID = Student.ID INNER JOIN Class ON StudentTakenClass.ClassID = Class.ID INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN GradeEntry ON StudentTakenClass.GradeEntry = GradeEntry.ID INNER JOIN Faculty ON Class.FacultyID = Faculty.ID WHERE Student.Prefix = '" & MetroTextBox1.Text & "' AND Class.YearSem = '" & getCurrentActiveSem() & "'", MetroGrid1)
        Catch ex As Exception
            MsgBox("Student Not Found")
        End Try
        parseXML("SELECT Student.Prefix,Student.Name,Course.CourseDescription FROM Student INNER JOIN Course ON Student.CourseID = Course.ID WHERE Student.Prefix = '" & MetroTextBox1.Text & "'", System.AppDomain.CurrentDomain.BaseDirectory.ToString & "StudentDeatilsGrade.xml")
        parseXML("SELECT Subject.Prefix AS [Subject Code],Subject.SubjectDescription AS [Subject Description],Subject.Units,GradeEntry.Average,Faculty.Name AS [Faculty] FROM StudentTakenClass INNER JOIN Student ON StudentTakenClass.StudentID = Student.ID INNER JOIN Class ON StudentTakenClass.ClassID = Class.ID INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN GradeEntry ON StudentTakenClass.GradeEntry = GradeEntry.ID INNER JOIN Faculty ON Class.FacultyID = Faculty.ID WHERE Student.Prefix = '" & MetroTextBox1.Text & "' AND Class.YearSem = '" & getCurrentActiveSem() & "'", System.AppDomain.CurrentDomain.BaseDirectory.ToString & "StudentGradeSlip.xml")
    End Sub

    Private Sub MetroTextBox1_Click(sender As Object, e As EventArgs) Handles MetroTextBox1.Click
        Dim q As New Transitions.Transition(New Transitions.TransitionType_EaseInEaseOut(300))
        q.add(Me, "Height", 110)
        Application.DoEvents()
        q.run()
    End Sub
End Class