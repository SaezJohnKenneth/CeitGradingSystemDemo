Imports System.Data.SqlClient

Public Class INC_Form
    Public RUNNING_USER As Integer
    Private MIDTERM As String
    Private FINALS As String
    Private throwableID2 As String

    Private Sub INC_Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub INC_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MetroPanel1.Visible = False
        MetroPanel2.Visible = False
        MetroLabel8.Text = ""
        populateComboboxByCustom("SELECT YearSem FROM Class GROUP BY YearSem", MetroComboBox1)
        'SELECT Student.Prefix AS [Student ID],Student.Name AS [Student Name],Class.ID AS [Class Code],Subject.Prefix AS [Subject Code],Subject.SubjectDescription AS [Subject Description],GradeEntry.Midterm,GradeEntry.Final,GradeEntry.Average
        Try
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
                sqlcon.Close()
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

    Private Sub MetroRadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles MetroRadioButton1.CheckedChanged
        FilterTable("SELECT Student.Prefix AS [Student ID],Student.Name AS [Student Name],Class.ID AS [Class Code],Subject.Prefix AS [Subject Code],Subject.SubjectDescription AS [Subject Description],GradeEntry.Midterm,GradeEntry.Final,GradeEntry.Average,GradeEntry.ID AS [Grade Entry Code] FROM StudentTakenClass INNER JOIN Class ON StudentTakenClass.ClassID = Class.ID INNER JOIN Faculty ON Class.FacultyID = Faculty.ID INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN Student ON StudentTakenClass.StudentID = Student.ID INNER JOIN GradeEntry ON StudentTakenClass.GradeEntry = GradeEntry.ID WHERE Faculty.ID = " & Faculty_Form.RUNNING_USER & " AND GradeEntry.Remarks = 'CONDITIONAL PASSING' AND Class.YearSem = '" & MetroComboBox1.Text & "'", MetroGrid1)
        throwableID2 = -1
        MetroPanel2.BringToFront()
    End Sub

    Private Sub MetroRadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles MetroRadioButton2.CheckedChanged
        FilterTable("SELECT Student.Prefix AS [Student ID],Student.Name AS [Student Name],Class.ID AS [Class Code],Subject.Prefix AS [Subject Code],Subject.SubjectDescription AS [Subject Description],GradeEntry.Midterm,GradeEntry.Final,GradeEntry.Average,GradeEntry.ID AS [Grade Entry Code] FROM StudentTakenClass INNER JOIN Class ON StudentTakenClass.ClassID = Class.ID INNER JOIN Faculty ON Class.FacultyID = Faculty.ID INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN Student ON StudentTakenClass.StudentID = Student.ID INNER JOIN GradeEntry ON StudentTakenClass.GradeEntry = GradeEntry.ID WHERE Faculty.ID = " & Faculty_Form.RUNNING_USER & " AND GradeEntry.Remarks = 'INCOMPLETE'  AND Class.YearSem = '" & MetroComboBox1.Text & "'", MetroGrid1)
        throwableID2 = -1
        MetroPanel3.BringToFront()
    End Sub

    Private Sub MetroGrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles MetroGrid1.CellClick
        throwableID2 = MetroGrid1.Item(8, e.RowIndex).Value.ToString
        MIDTERM = MetroGrid1.Item(5, e.RowIndex).Value.ToString
        FINALS = MetroGrid1.Item(6, e.RowIndex).Value.ToString
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        If throwableID2 = -1 Then
            MsgBox("Please Click On e of the records")
        Else
            MetroPanel2.Visible = True
            MetroPanel1.Visible = True
        End If
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub MetroTextBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MetroButton5_Click_1(sender As Object, e As EventArgs) Handles MetroButton5.Click
        Dim con As New SqlConnection(ConnectionString)
        Dim cmd As SqlCommand
        con.Open()
        If MIDTERM = "0" Then
            cmd = New SqlCommand("UPDATE GradeEntry SET Midterm = '" & MetroLabel8.Text & "', CFinal = '" & MetroTextBox1.Text & "' WHERE ID = " & throwableID2, con)
        cmd.ExecuteNonQuery()
        ElseIf FINALS = "0" Then
            cmd = New SqlCommand("UPDATE GradeEntry SET Final = '" & MetroLabel8.Text & "', CFinal = '" & MetroTextBox1.Text & "' WHERE ID = " & throwableID2, con)
            cmd.ExecuteNonQuery()
        Else
        End If

        cmd = New SqlCommand("SELECT CFinal,CMidterm,Midterm,Final FROM GradeEntry WHERE ID = " & throwableID2, con)
        Dim r As SqlDataReader = cmd.ExecuteReader
        r.Read()
        Dim ae As VariantType = (CInt(r(0)) * 0.6) + (CInt(r(1)) * 0.4)
        Dim incM As String = r(2)
        Dim incF As String = r(3)
        r.Close()
        Dim str As String = ""

        If ae >= 70 And ae <= 74 Then
            str = "4.00"
        ElseIf ae >= 75 And ae <= 77 Then
            str = "3.00"
        ElseIf ae >= 78 And ae <= 79 Then
            str = "2.75"
        ElseIf ae >= 80 And ae <= 82 Then
            str = "2.50"
        ElseIf ae >= 83 And ae <= 84 Then
            str = "2.25"
        ElseIf ae >= 85 And ae <= 87 Then
            str = "2.00"
        ElseIf ae >= 88 And ae <= 90 Then
            str = "1.75"
        ElseIf ae >= 91 And ae <= 93 Then
            str = "1.50"
        ElseIf ae >= 94 And ae <= 96 Then
            str = "1.25"
        ElseIf ae >= 97 And ae <= 100 Then
            str = "1.00"
        ElseIf incM = "0" Or incF = "0" Then
            str = "INC"
        Else
            str = "5.00"
        End If

        cmd = New SqlCommand("UPDATE GradeEntry SET Average = '" & str & "',Remarks = 'Not Finalized' WHERE GradeEntry.ID = " & throwableID2, con)
        cmd.ExecuteNonQuery()

        cmd = New SqlCommand("SELECT Average FROM GradeEntry WHERE ID = " & throwableID2, con)
        Dim r2 As SqlDataReader = cmd.ExecuteReader
        r2.Read()
        Dim l As String = r2(0)
        r2.Close()
        If l = "4.00" Then
            cmd = New SqlCommand("UPDATE GradeEntry SET Remarks = 'CONDITIONAL PASSING',DateEncoded = '" & Date.Now.ToString("yyyy-MM-dd") & "' WHERE ID = " & throwableID2, con)
        ElseIf l = "5.00" Then
            cmd = New SqlCommand("UPDATE GradeEntry SET Remarks = 'FAILED',DateEncoded = '" & Date.Now.ToString("yyyy-MM-dd") & "' WHERE ID = " & throwableID2, con)
        ElseIf l = "INC" Then
            cmd = New SqlCommand("UPDATE GradeEntry SET Remarks = 'INCOMPLETE',DateEncoded = '" & Date.Now.ToString("yyyy-MM-dd") & "' WHERE ID = " & throwableID2, con)
        Else
            cmd = New SqlCommand("UPDATE GradeEntry SET Remarks = 'PASSED',DateEncoded = '" & Date.Now.ToString("yyyy-MM-dd") & "' WHERE ID = " & throwableID2, con)
        End If
        cmd.ExecuteNonQuery()
        con.Close()
        FilterTable("SELECT Student.Prefix AS [Student ID],Student.Name AS [Student Name],Class.ID AS [Class Code],Subject.Prefix AS [Subject Code],Subject.SubjectDescription AS [Subject Description],GradeEntry.Midterm,GradeEntry.Final,GradeEntry.Average,GradeEntry.ID AS [Grade Entry Code] FROM StudentTakenClass INNER JOIN Class ON StudentTakenClass.ClassID = Class.ID INNER JOIN Faculty ON Class.FacultyID = Faculty.ID INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN Student ON StudentTakenClass.StudentID = Student.ID INNER JOIN GradeEntry ON StudentTakenClass.GradeEntry = GradeEntry.ID WHERE Faculty.ID = " & Faculty_Form.RUNNING_USER & " AND GradeEntry.Remarks = 'INCOMPLETE' AND Class.YearSem = '" & getCurrentActiveSem() & "'", MetroGrid1)
    End Sub

    Private Sub MetroButton4_Click_1(sender As Object, e As EventArgs) Handles MetroButton4.Click
        Dim con As New SqlConnection(ConnectionString)
        con.Open()
        If MetroComboBox2.Text = "5.00" Then
            Dim cmd As New SqlCommand("UPDATE GradeEntry SET Average = '" & MetroComboBox2.Text & "',Remarks = 'FAILED' WHERE ID = " & throwableID2, con)
            cmd.ExecuteNonQuery()
        Else
            Dim cmd As New SqlCommand("UPDATE GradeEntry SET Average = '" & MetroComboBox2.Text & "',Remarks = 'PASSED' WHERE ID = " & throwableID2, con)
            cmd.ExecuteNonQuery()
        End If

        con.Close()
        FilterTable("SELECT Student.Prefix AS [Student ID],Student.Name AS [Student Name],Class.ID AS [Class Code],Subject.Prefix AS [Subject Code],Subject.SubjectDescription AS [Subject Description],GradeEntry.Midterm,GradeEntry.Final,GradeEntry.Average FROM StudentTakenClass INNER JOIN Class ON StudentTakenClass.ClassID = Class.ID INNER JOIN Faculty ON Class.FacultyID = Faculty.ID INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN Student ON StudentTakenClass.StudentID = Student.ID INNER JOIN GradeEntry ON StudentTakenClass.GradeEntry = GradeEntry.ID WHERE Faculty.ID = " & Faculty_Form.RUNNING_USER & " AND GradeEntry.Remarks = 'CONDITIONAL PASSING'", MetroGrid1)
        MetroPanel1.Visible = False
        MetroPanel2.Visible = False
        throwableID2 = -1
    End Sub
    Private Sub MetroTextBox1_TextChanged(sender As Object, e As EventArgs) Handles MetroTextBox1.TextChanged
        Try
            If CInt(MetroTextBox1.Text) >= 70 And CInt(MetroTextBox1.Text) <= 74 Then
                MetroLabel8.Text = "4.00"
            ElseIf CInt(MetroTextBox1.Text) >= 75 And CInt(MetroTextBox1.Text) <= 77 Then
                MetroLabel8.Text = "3.00"
            ElseIf CInt(MetroTextBox1.Text) >= 78 And CInt(MetroTextBox1.Text) <= 79 Then
                MetroLabel8.Text = "2.75"
            ElseIf CInt(MetroTextBox1.Text) >= 80 And CInt(MetroTextBox1.Text) <= 82 Then
                MetroLabel8.Text = "2.50"
            ElseIf CInt(MetroTextBox1.Text) >= 83 And CInt(MetroTextBox1.Text) <= 84 Then
                MetroLabel8.Text = "2.25"
            ElseIf CInt(MetroTextBox1.Text) >= 85 And CInt(MetroTextBox1.Text) <= 87 Then
                MetroLabel8.Text = "2.00"
            ElseIf CInt(MetroTextBox1.Text) >= 88 And CInt(MetroTextBox1.Text) <= 90 Then
                MetroLabel8.Text = "1.75"
            ElseIf CInt(MetroTextBox1.Text) >= 91 And CInt(MetroTextBox1.Text) <= 93 Then
                MetroLabel8.Text = "1.50"
            ElseIf CInt(MetroTextBox1.Text) >= 94 And CInt(MetroTextBox1.Text) <= 96 Then
                MetroLabel8.Text = "1.25"
            ElseIf CInt(MetroTextBox1.Text) >= 97 And CInt(MetroTextBox1.Text) <= 100 Then
                MetroLabel8.Text = "1.00"
            Else
                MetroLabel8.Text = "5.00"
            End If
        Catch ex As Exception
            MetroLabel8.Text = ""
        End Try
    End Sub

    Private Sub MetroGrid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles MetroGrid1.CellContentClick

    End Sub

    Private Sub MetroButton6_Click(sender As Object, e As EventArgs) Handles MetroButton6.Click
        MetroPanel1.Visible = False
        MetroPanel2.Visible = False
    End Sub

    Private Sub MetroButton7_Click(sender As Object, e As EventArgs) Handles MetroButton7.Click
        MetroPanel1.Visible = False
        MetroPanel2.Visible = False
    End Sub

    Private Sub MetroComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MetroComboBox1.SelectedIndexChanged

    End Sub
End Class