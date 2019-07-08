Imports System.Data.SqlClient

Public Class Final_Grading_Form
    Public RUNNING_USER As Integer
    Private throwedID As Integer

    Private Sub Final_Grading_Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()

    End Sub

    Private Sub Final_Grading_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MetroLabel7.Text = ""
        throwedID = -1
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
                MetroLabel3.Text = name2
                MetroLabel4.Text = access
                MetroPanel1.BackgroundImage = GetImageFromByte(readr(2))
                sqlcon.Close()
            End While
            readr.Close()
            sqlcon.Close()

        Catch ex As Exception

        End Try
        FilterTable("SELECT Subject.Prefix AS [Subject CODE], Subject.SubjectDescription AS [Subject Description], Student.Prefix AS [Student ID], Student.Name AS [Student Name], Class.YearSem AS [Year / Sem], GradeEntry.Final AS [Final Grade],GradeEntry.Remarks FROM StudentTakenClass INNER JOIN Student ON Student.ID = StudentTakenClass.StudentID INNER JOIN Class ON StudentTakenClass.ClassID = Class.ID INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN GradeEntry ON StudentTakenClass.GradeEntry = GradeEntry.ID WHERE Class.ID = " & Final_Form.throwedID & " AND GradeEntry.Status = 'Active' ORDER BY Student.Name ASC", MetroGrid1)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        MetroLabel1.Text = Format(Now, "MMMM , dd , yyyy")
        MetroLabel2.Text = Format(TimeOfDay, "hh : mm : ss tt")

    End Sub

    Private GE_ID As Integer
    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click

        If throwedID = -1 Then
            MsgBox("Please click one of the records")
        Else

            MetroLabel5.Visible = True
            MetroTextBox1.Visible = True
            MetroButton4.Visible = True
            MetroButton5.Visible = True
            MetroButton2.Visible = True
            MetroLabel6.Visible = True
            MetroLabel7.Visible = True
            Try
                Dim sqlcon As New SqlConnection(ConnectionString)
                sqlcon.Open()
                Dim cmd As New SqlCommand("SELECT GradeEntry.ID FROM StudentTakenClass INNER JOIN Student ON Student.ID = StudentTakenClass.StudentID INNER JOIN Class ON StudentTakenClass.ClassID = Class.ID INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN GradeEntry ON StudentTakenClass.GradeEntry = GradeEntry.ID WHERE Student.Prefix = '" & MetroGrid1.Item(2, throwedID).Value & "'" & " AND Class.ID = " & Final_Form.throwedID & " AND GradeEntry.Status = 'Active'", sqlcon)
                Dim r As SqlDataReader = cmd.ExecuteReader
                r.Read()
                GE_ID = r(0)
                r.Close()
                sqlcon.Close()

            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        If MetroLabel7.Text = "" Then
            MsgBox("Please enter Valid Grade")
        Else
            Try
                Dim sqlcon As New SqlConnection(ConnectionString)
                sqlcon.Open()
                Dim cmd As New SqlCommand("UPDATE GradeEntry SET Final = '" & MetroLabel7.Text & "' , CFinal = '" & MetroTextBox1.Text & "' WHERE GradeEntry.ID = " & GE_ID, sqlcon)
                cmd.ExecuteNonQuery()

                'compute now for the total grade
                cmd = New SqlCommand("SELECT CFinal,CMidterm,Midterm,Final FROM GradeEntry WHERE ID = " & GE_ID, sqlcon)
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

                cmd = New SqlCommand("UPDATE GradeEntry SET Average = '" & str & "',Remarks = 'Not Finalized' WHERE GradeEntry.ID = " & GE_ID, sqlcon)
                cmd.ExecuteNonQuery()
                sqlcon.Close()
                MsgBox("Updated Succesfully")
                FilterTable("SELECT Subject.Prefix AS [Subject CODE], Subject.SubjectDescription AS [Subject Description], Student.Prefix AS [Student ID], Student.Name AS [Student Name], Class.YearSem AS [Year / Sem], GradeEntry.Final AS [Final Grade] FROM StudentTakenClass INNER JOIN Student ON Student.ID = StudentTakenClass.StudentID INNER JOIN Class ON StudentTakenClass.ClassID = Class.ID INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN GradeEntry ON StudentTakenClass.GradeEntry = GradeEntry.ID WHERE Class.ID = " & Final_Form.throwedID & " AND GradeEntry.Status = 'Active' ORDER BY Student.Name ASC", MetroGrid1)
                throwedID = -1
                MetroLabel5.Visible = False
                MetroTextBox1.Visible = False
                MetroButton4.Visible = False
                MetroButton5.Visible = False
                MetroButton2.Visible = False
                MetroLabel6.Visible = False
                MetroLabel7.Visible = False
                MetroButton3.Enabled = False
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            End Try
        End If


    End Sub

    Private Sub MetroGrid1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MetroGrid1.CellClick
        throwedID = e.RowIndex
        If MetroGrid1.Item(6, e.RowIndex).Value = "NA" Then
            MetroButton3.Enabled = True
        Else
            MetroButton3.Enabled = False
        End If
    End Sub

    Private Sub MetroGrid1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MetroGrid1.CellContentClick

    End Sub

    Private Sub MetroTextBox1_Click(sender As Object, e As EventArgs) Handles MetroTextBox1.Click

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
            MetroLabel7.Text = "0"
        End Try

    End Sub

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click
        Try
            Dim con As New SqlConnection(ConnectionString)
            con.Open()
            Dim cmd As New SqlCommand("SELECT Average FROM GradeEntry WHERE ID = " & GE_ID, con)
            Dim r As SqlDataReader = cmd.ExecuteReader
            r.Read()
            Dim l As String = r(0)
            r.Close()
            If l = "4.00" Then
                cmd = New SqlCommand("UPDATE GradeEntry SET Remarks = 'CONDITIONAL PASSING',DateEncoded = '" & Date.Now.ToString("yyyy-MM-dd") & "' WHERE ID = " & GE_ID, con)
            ElseIf l = "5.00" Then
                cmd = New SqlCommand("UPDATE GradeEntry SET Remarks = 'FAILED',DateEncoded = '" & Date.Now.ToString("yyyy-MM-dd") & "' WHERE ID = " & GE_ID, con)
            ElseIf l = "INC" Then
                cmd = New SqlCommand("UPDATE GradeEntry SET Remarks = 'INCOMPLETE',DateEncoded = '" & Date.Now.ToString("yyyy-MM-dd") & "' WHERE ID = " & GE_ID, con)
            Else
                cmd = New SqlCommand("UPDATE GradeEntry SET Remarks = 'PASSED',DateEncoded = '" & Date.Now.ToString("yyyy-MM-dd") & "' WHERE ID = " & GE_ID, con)
            End If
            cmd.ExecuteNonQuery()
            MsgBox("The Grade is now finalized")
            throwedID = -1
            MetroLabel5.Visible = False
            MetroTextBox1.Visible = False
            MetroButton4.Visible = False
            MetroButton5.Visible = False
            MetroButton2.Visible = False
            MetroLabel6.Visible = False
            MetroLabel7.Visible = False
            MetroButton3.Enabled = False
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            MetroLabel7.Text = ""
        End Try
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        MetroButton3.Enabled = False
        throwedID = -1
        MetroLabel5.Visible = False
        MetroTextBox1.Visible = False
        MetroButton4.Visible = False
        MetroButton5.Visible = False
        MetroButton2.Visible = False
        MetroLabel6.Visible = False
        MetroLabel7.Visible = False
    End Sub
End Class