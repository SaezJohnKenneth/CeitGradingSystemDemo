Imports System.Data.SqlClient

Public Class Midterm_Grading_Form
    Public RUNNING_USER As Integer
    Private throwedID As Integer


    Private Sub Midterm_Grading_Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()

    End Sub
    Private Sub visibleAllSavePanelContent(ByVal t As Boolean)
        MetroLabel5.Visible = t
        MetroTextBox1.Visible = t
        MetroButton2.Visible = t
        MetroLabel6.Visible = t
        MetroLabel7.Visible = t
        throwedID = -1
        MetroButton4.Visible = t
    End Sub
    Private Sub Midterm_Grading_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        visibleAllSavePanelContent(False)
        MetroLabel7.Text = ""
        MetroButton3.Enabled = False
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
                MetroLabel1.Text = name2
                MetroLabel2.Text = access
                MetroPanel1.BackgroundImage = GetImageFromByte(readr(2))
            End While
            readr.Close()
            sqlcon.Close()

        Catch ex As Exception

        End Try
        FilterTable("SELECT Subject.Prefix AS [Subject CODE], Subject.SubjectDescription AS [Subject Description], Student.Prefix AS [Student ID], Student.Name AS [Student Name], Class.YearSem AS [Year / Sem], GradeEntry.Midterm AS [Midterm Grade],GradeEntry.ID FROM StudentTakenClass INNER JOIN Student ON Student.ID = StudentTakenClass.StudentID INNER JOIN Class ON StudentTakenClass.ClassID = Class.ID INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN GradeEntry ON StudentTakenClass.GradeEntry = GradeEntry.ID WHERE Class.ID = " & Midterm_Form.throwedID & " AND GradeEntry.Status = 'Active'", MetroGrid1)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        MetroLabel1.Text = Format(Now, "MMMM , dd , yyyy")
        MetroLabel2.Text = Format(TimeOfDay, "hh : mm : ss tt")

    End Sub
    Private GE_ID As Integer
    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        If throwedID = -1 Then
            MsgBox("Please Click one of the records")
        Else
            Try

                Dim sqlcon As New SqlConnection(ConnectionString)
                sqlcon.Open()
                Dim cmd As New SqlCommand("SELECT GradeEntry.ID FROM StudentTakenClass INNER JOIN Student ON Student.ID = StudentTakenClass.StudentID INNER JOIN Class ON StudentTakenClass.ClassID = Class.ID INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN GradeEntry ON StudentTakenClass.GradeEntry = GradeEntry.ID WHERE Student.Prefix = '" & MetroGrid1.Item(2, throwedID).Value & "'" & " AND Class.ID = " & Midterm_Form.throwedID, sqlcon)
                Dim r As SqlDataReader = cmd.ExecuteReader
                r.Read()
                GE_ID = r(0)
                r.Close()
                sqlcon.Close()
                visibleAllSavePanelContent(True)
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub MetroGrid1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MetroGrid1.CellClick
        throwedID = e.RowIndex
        If MetroGrid1.Item(5, e.RowIndex).Value = "0" Then
            MetroButton3.Enabled = True
        Else
            MetroButton3.Enabled = False
        End If
    End Sub

    Private Sub MetroGrid1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MetroGrid1.CellContentClick

    End Sub

    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        Try
            Dim sqlcon As New SqlConnection(ConnectionString)
            sqlcon.Open()
            Dim cmd As New SqlCommand("UPDATE GradeEntry SET Midterm = '" & MetroLabel7.Text & "', CMidterm = '" & MetroTextBox1.Text & "' WHERE GradeEntry.ID = " & GE_ID, sqlcon)
            cmd.ExecuteNonQuery()
            sqlcon.Close()
            MsgBox("Updated Succesfully")
            FilterTable("SELECT Subject.Prefix AS [Subject CODE], Subject.SubjectDescription AS [Subject Description], Student.Prefix AS [Student ID], Student.Name AS [Student Name], Class.YearSem AS [Year / Sem], GradeEntry.Midterm AS [Midterm Grade],GradeEntry.ID FROM StudentTakenClass INNER JOIN Student ON Student.ID = StudentTakenClass.StudentID INNER JOIN Class ON StudentTakenClass.ClassID = Class.ID INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN GradeEntry ON StudentTakenClass.GradeEntry = GradeEntry.ID WHERE Class.ID = " & Midterm_Form.throwedID & " AND GradeEntry.Status = 'Active'", MetroGrid1)
            visibleAllSavePanelContent(False)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub MetroTextBox1_Click(sender As Object, e As EventArgs) Handles MetroTextBox1.Click

    End Sub

    Private Sub MetroTextBox1_ControlAdded(sender As Object, e As ControlEventArgs) Handles MetroTextBox1.ControlAdded


    End Sub

    Private Sub MetroTextBox1_TextChanged(sender As Object, e As EventArgs) Handles MetroTextBox1.TextChanged
        Try
            Dim g As VariantType
            g = CInt(MetroTextBox1.Text) * 0.4
            If CInt(MetroTextBox1.Text) >= 70 And CInt(MetroTextBox1.Text) <= 74 Then
                MetroLabel7.Text = "4.00"
            ElseIf CInt(MetroTextBox1.Text) >= 75 And CInt(MetroTextBox1.Text) <= 77 Then
                MetroLabel7.Text = "3.00"
            ElseIf CInt(MetroTextBox1.Text) >= 78 And CInt(MetroTextBox1.Text) <= 79 Then
                MetroLabel7.Text = "2.75"
            ElseIf CInt(MetroTextBox1.Text) >= 80 And CInt(MetroTextBox1.Text) <= 82 Then
                MetroLabel7.Text = "2.50"
            ElseIf CInt(MetroTextBox1.Text) >= 83 And CInt(MetroTextBox1.Text) <= 84 Then
                MetroLabel7.Text = "2.25"
            ElseIf CInt(MetroTextBox1.Text) >= 85 And CInt(MetroTextBox1.Text) <= 87 Then
                MetroLabel7.Text = "2.00"
            ElseIf CInt(MetroTextBox1.Text) >= 88 And CInt(MetroTextBox1.Text) <= 90 Then
                MetroLabel7.Text = "1.75"
            ElseIf CInt(MetroTextBox1.Text) >= 91 And CInt(MetroTextBox1.Text) <= 93 Then
                MetroLabel7.Text = "1.50"
            ElseIf CInt(MetroTextBox1.Text) >= 94 And CInt(MetroTextBox1.Text) <= 96 Then
                MetroLabel7.Text = "1.25"
            ElseIf CInt(MetroTextBox1.Text) >= 97 And CInt(MetroTextBox1.Text) <= 100 Then
                MetroLabel7.Text = "1.00"
            Else
                MetroLabel7.Text = "5.00"
            End If
        Catch ex As Exception
            ' MsgBox(ex.Message)
            MetroLabel7.Text = ""
        End Try
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        visibleAllSavePanelContent(False)
    End Sub
End Class