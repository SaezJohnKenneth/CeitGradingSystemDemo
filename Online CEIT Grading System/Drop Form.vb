Imports System.Data.SqlClient
Public Class Drop_Form
    Public RUNNING_USER As Integer

    Private Sub Drop_Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
    Private Sub Drop_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Try
            Dim sqlcon As New SqlConnection(ConnectionString)
            sqlcon.Open()
            Dim cmd As New SqlCommand("SELECT Student.Name,Student.Prefix,Course.CourseDescription FROM Student INNER JOIN Course ON Student.CourseID = Course.ID WHERE Student.Prefix = '" & MetroTextBox1.Text & "'", sqlcon)
            Dim rea As SqlDataReader = cmd.ExecuteReader
            rea.Read()
            MetroLabel7.Text = rea(0)
            MetroLabel6.Text = rea(1)
            MetroLabel9.Text = rea(2)
            MetroLabel11.Text = getCurrentActiveSem()
            rea.Close()
            sqlcon.Close()
        Catch ex As Exception
            MsgBox("Error : " & ex.Message)
        End Try
        Try
            FilterTable("SELECT Subject.Prefix AS [Subject Code], Subject.SubjectDescription AS [Subject Desccription], Faculty.Name AS [Faculty Name],GradeEntry.Status,GradeEntry.ID FROM StudentTakenClass INNER JOIN Student ON StudentTakenClass.StudentID = Student.ID INNER JOIN Class ON StudentTakenClass.ClassID = Class.ID INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN Faculty ON Class.FacultyID = Faculty.ID INNER JOIN GradeEntry ON StudentTakenClass.GradeEntry = GradeEntry.ID WHERE (Class.YearSem = '" & getCurrentActiveSem() & "') AND (Student.Prefix = '" & MetroTextBox1.Text & "')", MetroGrid1)
        Catch ex As Exception
            MsgBox("Student Not Found", vbExclamation)
        End Try

    End Sub

    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        If MsgBox("You Are going to Drop the Subject Selected." & vbNewLine & "Are you sure you want to do this?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            For i As Integer = 0 To MetroGrid1.Rows.Count - 1
                If CBool(DirectCast(MetroGrid1.Rows(i).Cells(0), DataGridViewCheckBoxCell).Value) = True Then
                    Try
                        Dim con As New SqlConnection(ConnectionString)
                        con.Open()
                        Dim cmd As New SqlCommand("UPDATE GradeEntry SET Status = 'Dropped',Remarks = '',Average='DRP' WHERE GradeEntry.ID = " & MetroGrid1.Item(5, i).Value, con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        MsgBox("Error : " & ex.Message)
                    End Try
                    FilterTable("SELECT Subject.Prefix AS [Subject Code], Subject.SubjectDescription AS [Subject Desccription], Faculty.Name AS [Faculty Name],GradeEntry.Status,GradeEntry.ID FROM StudentTakenClass INNER JOIN Student ON StudentTakenClass.StudentID = Student.ID INNER JOIN Class ON StudentTakenClass.ClassID = Class.ID INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN Faculty ON Class.FacultyID = Faculty.ID INNER JOIN GradeEntry ON StudentTakenClass.GradeEntry = GradeEntry.ID WHERE (Class.YearSem = '2017/2S') AND (Student.Prefix = '" & MetroTextBox1.Text & "')", MetroGrid1)
                End If
            Next
        Else
        End If
    End Sub

    Private Sub MetroButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton4.Click
        If MsgBox("You Are going to Widraw the Subject Selected." & vbNewLine & "Are you sure you want to do this?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            For i As Integer = 0 To MetroGrid1.Rows.Count - 1
                If CBool(DirectCast(MetroGrid1.Rows(i).Cells(0), DataGridViewCheckBoxCell).Value) = True Then
                    Try
                        Dim con As New SqlConnection(ConnectionString)
                        con.Open()
                        Dim cmd As New SqlCommand("UPDATE GradeEntry SET Status = 'Widrawn',Remarks='',Average='W' WHERE GradeEntry.ID = " & MetroGrid1.Item(5, i).Value, con)
                        cmd.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        MsgBox("Error : " & ex.Message)
                    End Try
                    FilterTable("SELECT Subject.Prefix AS [Subject Code], Subject.SubjectDescription AS [Subject Desccription], Faculty.Name AS [Faculty Name],GradeEntry.Status,GradeEntry.ID FROM StudentTakenClass INNER JOIN Student ON StudentTakenClass.StudentID = Student.ID INNER JOIN Class ON StudentTakenClass.ClassID = Class.ID INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN Faculty ON Class.FacultyID = Faculty.ID INNER JOIN GradeEntry ON StudentTakenClass.GradeEntry = GradeEntry.ID WHERE (Class.YearSem = '2017/2S') AND (Student.Prefix = '" & MetroTextBox1.Text & "')", MetroGrid1)
                End If
            Next
        Else

        End If
    End Sub
End Class