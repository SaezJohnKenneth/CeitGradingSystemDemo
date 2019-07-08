Imports System.Data.SqlClient
Public Class Class_Form
    Public RUNNING_USER As Integer

    Private Sub Class_Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()

    End Sub
    Dim scheds() As String
    Private Sub Class_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim x = 0

        MetroTextBox2.Text = getCurrentActiveSem()
        FilterTable("SELECT Class.ID AS [Class Code],Class.Schedule,Subject.Prefix AS [Subject Code],Subject.SubjectDescription AS [Subject Description],Faculty.Name AS [Assigned Faculty],Class.YearSem AS [Year Sem] FROM Class INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN Faculty ON Class.FacultyID = Faculty.ID", MetroGrid2)
        'Try
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

        cmd = New SqlCommand("SELECT Name from Faculty", sqlcon)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        MetroComboBox1.Items.Clear()
        While reader.Read
            MetroComboBox1.Items.Add(reader(0))
        End While
        reader.Close()
        cmd = New SqlCommand("SELECT Name from Section", sqlcon)
        Dim reader2 As SqlDataReader = cmd.ExecuteReader
        MetroComboBox3.Items.Clear()
        While reader2.Read
            MetroComboBox3.Items.Add(reader2(0))
        End While
        reader2.Close()

        cmd = New SqlCommand("SELECT SubjectDescription from Subject", sqlcon)
        Dim reader3 As SqlDataReader = cmd.ExecuteReader
        MetroComboBox2.Items.Clear()
        While reader3.Read
            MetroComboBox2.Items.Add(reader3(0))
        End While
        reader3.Close()

        cmd = New SqlCommand("Select Prefix from Room", sqlcon)
        Dim reader4 As SqlDataReader = cmd.ExecuteReader
        MetroComboBox4.Items.Clear()
        While reader4.Read
            MetroComboBox4.Items.Add(reader4(0))
        End While
        sqlcon.Close()

        'Catch ex As Exception
        '   MsgBox("Error: " & ex.Message)

        '        End Try
    End Sub
    Private juvy As Integer = 0

    Private Sub MetroButton2_Click_1(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Try
            Dim sqlcon As New SqlConnection(ConnectionString)
            sqlcon.Open()
            Dim sqlcom As New SqlCommand("SELECT Student.Prefix,Student.Name,Course.CourseDescription from Student INNER JOIN Course ON Student.CourseID = Course.ID WHERE Student.Prefix = '" & MetroTextBox3.Text & "'", sqlcon)
            Dim reader As SqlDataReader = sqlcom.ExecuteReader
            reader.Read()
            Dim name As String = reader(1)
            Dim course As String = reader(2)
            Dim prefix As String = reader(0)
            reader.Close()
            sqlcon.Close()
            MetroGrid1.Rows.Add()
            MetroGrid1.Item(0, juvy).Value = prefix
            MetroGrid1.Item(1, juvy).Value = name
            MetroGrid1.Item(2, juvy).Value = course
            juvy = juvy + 1
        Catch ex As Exception
            MsgBox("Student not found")
        End Try
    End Sub

    Private Sub MetroButton3_Click_1(sender As Object, e As EventArgs) Handles MetroButton3.Click
        '

        Dim isAvailable As Boolean = True
        Dim id As Integer
        'Try
        Dim sqlcon As New SqlConnection(ConnectionString)
        sqlcon.Open()

        Dim checkCMD As New SqlCommand("SELECT Class.Schedule,Room.Prefix,Class.ID FROM Class INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN Faculty ON Class.FacultyID = Faculty.ID INNER JOIN Room ON Class.RoomID=Room.ID WHERE Class.YearSem IN ('" & getCurrentActiveSem() & "')", sqlcon)
        Dim rea As SqlDataReader = checkCMD.ExecuteReader
        While rea.Read
            If rea(0) = MetroComboBox5.Text & "/" & MetroComboBox6.Text And rea(1) = MetroComboBox4.Text Then
                isAvailable = False
                id = rea(2)
            End If
        End While
        rea.Close()
        If isAvailable Then

            Dim jinky As Integer = 0
            Dim canBeAdded As Boolean = True
            Dim ree As SqlDataReader
            Dim sqlcom As SqlCommand

            While jinky < juvy
                'Code for checking if the student taken the class
                'MsgBox("Nadaanan")
                Try
                    sqlcom = New SqlCommand("SELECT Subject.SubjectDescription,Student.Name,Student.Prefix FROM StudentTakenClass INNER JOIN Class ON StudentTakenClass.ClassID = Class.ID INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN Student ON StudentTakenClass.StudentID = Student.ID INNER JOIN GradeEntry ON StudentTakenClass.GradeEntry = GradeEntry.ID WHERE Student.Prefix = '" & MetroGrid1.Item(0, jinky).Value & "' AND Subject.SubjectDescription = '" & MetroComboBox2.Text & "' AND Class.YearSem IN ('2017/2S')", sqlcon)
                    ree = sqlcom.ExecuteReader

                    ree.Read()
                    If ree(2) = MetroGrid1.Item(0, jinky).Value Then
                        'MsgBox("Nagconflict")
                        MsgBox("Student " & ree(1) & "(" & ree(2) & ")" & " Already Taken the subject")
                        canBeAdded = False
                    Else
                        MsgBox("Hindi Nagconflict")
                    End If
                Catch ex As Exception
                    'MsgBox(ex.Message)
                End Try
                jinky = jinky + 1
            End While
            ree.Close()
            jinky = 0
            If canBeAdded Then
                sqlcom = New SqlCommand("INSERT INTO Class(Schedule,SectionID,SubjectID,FacultyID,RoomID,YearSem) VALUES(@ched,@sectionid,@subjectid,@facultyid,@roomid,@yrsem)", sqlcon)
                sqlcom.Parameters.AddWithValue("@ched", MetroComboBox5.Text & "/" & MetroComboBox6.Text)
                sqlcom.Parameters.AddWithValue("@sectionid", getTableID("Section", MetroComboBox3.Text, "Name", "ID"))
                sqlcom.Parameters.AddWithValue("@subjectid", getTableID("Subject", MetroComboBox2.Text, "SubjectDescription", "ID"))
                sqlcom.Parameters.AddWithValue("@facultyid", getTableID("Faculty", MetroComboBox1.Text, "Name", "ID"))
                sqlcom.Parameters.AddWithValue("@roomid", getTableID("Room", MetroComboBox4.Text, "Prefix", "ID"))
                sqlcom.Parameters.AddWithValue("@yrsem", MetroTextBox2.Text)
                sqlcom.ExecuteNonQuery()
                While jinky < juvy
                    sqlcom = New SqlCommand("INSERT INTO GradeEntry(Midterm,Final,CMidterm,CFinal,Status,Average,Remarks,DateEncoded) VALUES('0','0','0','0','Active','0','NA','NA')", sqlcon)
                    sqlcom.ExecuteNonQuery()
                    sqlcom = New SqlCommand("SELECT TOP 1 ID from GradeEntry ORDER BY ID desc", sqlcon)
                    Dim reader As SqlDataReader = sqlcom.ExecuteReader
                    reader.Read()
                    Dim geID As Integer = reader(0)
                    reader.Close()
                    sqlcom = New SqlCommand("SELECT TOP 1 ID from Class ORDER BY ID desc", sqlcon)
                    Dim reader2 As SqlDataReader = sqlcom.ExecuteReader
                    reader2.Read()
                    Dim classID As Integer = reader2(0)
                    reader2.Close()

                    sqlcom = New SqlCommand("INSERT INTO StudentTakenClass(ClassID,StudentID,GradeEntry) VALUES(@classid,@studentid,@gradeentry)", sqlcon)

                    sqlcom.Parameters.AddWithValue("@classid", classID)
                    sqlcom.Parameters.AddWithValue("@gradeentry", geID)
                    sqlcom.Parameters.AddWithValue("@studentid", getTableID("Student", MetroGrid1.Item(0, jinky).Value, "Prefix", "ID"))
                    sqlcom.ExecuteNonQuery()

                    jinky = jinky + 1
                End While
                MsgBox("Class Added")
            Else
                ' do nothing
            End If
            sqlcon.Close()
        Else
            MsgBox("There is A Conflict Schedule in Class Code " & id)
        End If

        '        Catch ex As Exception

        '        End Try
    End Sub

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click

        If MetroTextBox4.Text = "" Then
            FilterTable("SELECT Class.ID AS [Class Code],Class.Schedule,Subject.Prefix AS [Subject Code],Subject.SubjectDescription AS [Subject Description],Faculty.Name AS [Assigned Faculty],Class.YearSem AS [Year Sem] FROM Class INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN Faculty ON Class.FacultyID = Faculty.ID", MetroGrid2)
        Else
            FilterTable("SELECT Class.ID AS [Class Code],Class.Schedule,Subject.Prefix AS [Subject Code],Subject.SubjectDescription AS [Subject Description],Faculty.Name AS [Assigned Faculty],Class.YearSem AS [Year Sem] FROM Class INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN Faculty ON Class.FacultyID = Faculty.ID WHERE Class.ID = " & MetroTextBox4.Text, MetroGrid2)
        End If
    End Sub

    Private Sub MetroComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MetroComboBox6.SelectedIndexChanged
        Dim c = 0

        If MetroComboBox6.Text = "07:00a" Then
            c = 26
        ElseIf MetroComboBox6.Text = "07:30a" Then
            c = 25
        ElseIf MetroComboBox6.Text = "08:00a" Then
            c = 24
        ElseIf MetroComboBox6.Text = "08:30a" Then
            c = 23
        ElseIf MetroComboBox6.Text = "09:00a" Then
            c = 22
        ElseIf MetroComboBox6.Text = "09:300a" Then
            c = 21
        ElseIf MetroComboBox6.Text = "10:00a" Then
            c = 20
        ElseIf MetroComboBox6.Text = "10:30a" Then
            c = 19
        ElseIf MetroComboBox6.Text = "11:00a" Then
            c = 18
        ElseIf MetroComboBox6.Text = "11:30a" Then
            c = 17
        ElseIf MetroComboBox6.Text = "12:00p" Then
            c = 16
        ElseIf MetroComboBox6.Text = "12:30p" Then
            c = 15
        ElseIf MetroComboBox6.Text = "01:00p" Then
            c = 14
        ElseIf MetroComboBox6.Text = "01:30p" Then
            c = 13
        ElseIf MetroComboBox6.Text = "02:00p" Then
            c = 12
        ElseIf MetroComboBox6.Text = "02:30p" Then
            c = 11
        ElseIf MetroComboBox6.Text = "03:00p" Then
            c = 10
        ElseIf MetroComboBox6.Text = "03:30p" Then
            c = 9
        ElseIf MetroComboBox6.Text = "04:00p" Then
            c = 8
        ElseIf MetroComboBox6.Text = "04:30p" Then
            c = 7
        ElseIf MetroComboBox6.Text = "05:00p" Then
            c = 6
        ElseIf MetroComboBox6.Text = "05:30p" Then
            c = 5
        ElseIf MetroComboBox6.Text = "06:00p" Then
            c = 4
        ElseIf MetroComboBox6.Text = "06:30p" Then
            c = 3
        ElseIf MetroComboBox6.Text = "07:00p" Then
            c = 2
        ElseIf MetroComboBox6.Text = "07:30p" Then
            c = 1
        Else
        End If
    End Sub

    Private Sub MetroButton7_Click(sender As Object, e As EventArgs) Handles MetroButton7.Click
        MetroGrid1.Rows.Clear()
        juvy = 0
    End Sub
End Class