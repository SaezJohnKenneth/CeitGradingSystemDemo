Imports System.Data.SqlClient
Public Class Final_Form
    Public RUNNING_USER As Integer
    Public throwedID As Integer
    Private stringFIeld As String
    Private Sub Final_Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()

    End Sub

    Private Sub Final_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        stringFIeld = "Class.ID"
        Dim runInt As Integer = 0
        Dim name2 As String
        Dim id As String
        Dim access As String
        Try
            Dim sqlcon As New SqlConnection(ConnectionString)
            sqlcon.Open()
            Dim cmd As New SqlCommand("SELECT * FROM [Faculty] where id = " & RUNNING_USER, sqlcon)
            Dim readr As SqlDataReader = cmd.ExecuteReader
            
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

        Catch ex As Exception

        End Try
        FilterTable("SELECT Class.ID AS [Class ID], Class.Schedule, Subject.Prefix AS [Subject ID], Subject.SubjectDescription, Section.Name AS [Section Name], Class.YearSem AS [Year Sem], Faculty.ID AS [Faculty ID], Faculty.Name AS [Faculty Name] FROM  Class  INNER JOIN Section ON Class.SectionID = Section.ID INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN Faculty ON Class.FacultyID = Faculty.ID WHERE Faculty.ID = " & Faculty_Menu_Form.RUNNING_USER, MetroGrid1)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        MetroLabel1.Text = Format(Now, "MMMM , dd , yyyy")
        MetroLabel2.Text = Format(TimeOfDay, "hh : mm : ss tt")

    End Sub

    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click
        Final_Grading_Form.ShowDialog()
    End Sub

    Private Sub MetroGrid1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MetroGrid1.CellClick
        throwedID = MetroGrid1.Item(0, e.RowIndex).Value
    End Sub

    Private Sub MetroGrid1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MetroGrid1.CellContentClick

    End Sub

    Private Sub MetroRadioButton1_CheckedChanged(sender As Object, e As EventArgs)
        stringFIeld = "Class.ID"
    End Sub

    Private Sub MetroRadioButton2_CheckedChanged(sender As Object, e As EventArgs)
        stringFIeld = "Subject.SubjectDescription"
    End Sub

    Private Sub MetroTile1_Click(sender As Object, e As EventArgs) Handles MetroTile1.Click
        If MetroTextBox1.Text = "" Then
            FilterTable("SELECT Class.ID AS [Class ID], Class.Schedule, Subject.Prefix AS [Subject ID], Subject.SubjectDescription, Section.Name AS [Section Name], Class.YearSem AS [Year Sem], Faculty.ID AS [Faculty ID], Faculty.Name AS [Faculty Name] FROM  Class  INNER JOIN Section ON Class.SectionID = Section.ID INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN Faculty ON Class.FacultyID = Faculty.ID WHERE Faculty.ID = " & Faculty_Menu_Form.RUNNING_USER, MetroGrid1)
        Else

            Try
                FilterTable("SELECT Class.ID AS [Class ID], Class.Schedule, Subject.Prefix AS [Subject ID], Subject.SubjectDescription, Section.Name AS [Section Name], Class.YearSem AS [Year Sem], Faculty.ID AS [Faculty ID], Faculty.Name AS [Faculty Name] FROM  Class  INNER JOIN Section ON Class.SectionID = Section.ID INNER JOIN Subject ON Class.SubjectID = Subject.ID INNER JOIN Faculty ON Class.FacultyID = Faculty.ID WHERE Faculty.ID = " & Faculty_Menu_Form.RUNNING_USER & " AND Class.ID = " & MetroTextBox1.Text, MetroGrid1)
            Catch ex As Exception
                MsgBox("Class Code Not Found")
            End Try

        End If
    End Sub

    Private Sub MetroTextBox1_Click(sender As Object, e As EventArgs) Handles MetroTextBox1.Click

    End Sub
End Class