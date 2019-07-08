Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class BackupDB
    Private pass As String
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            MetroTextBox1.Text = FolderBrowserDialog1.SelectedPath
        Else
            'do nothing
        End If
    End Sub

    Private Sub BackupDB_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BackupDB_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click

        Dim con As New SqlConnection(ConnectionString)
        con.Open()
        Dim sql As New SqlCommand("SELECT Password FROM Faculty WHERE ID = " & Admin_Menu_Form.RUNNING_USER, con)
        Dim r As SqlDataReader = sql.ExecuteReader
        r.Read()
        pass = r(0)
        r.Close()
        con.Close()
        If pass = MetroTextBox2.Text Then
            BackgroundWorker1.RunWorkerAsync()
            MetroProgressSpinner1.Visible = True
            MetroLabel3.Visible = True
        Else
            MsgBox("Wrong Password")
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim con As New SqlConnection(ConnectionString)
            con.Open()
            Dim DBNAME As String = "[" & System.AppDomain.CurrentDomain.BaseDirectory.ToString & "OLS.mdf]"
            Dim sql1 As New SqlCommand("BACKUP DATABASE " & DBNAME & " TO DISK = '" & MetroTextBox1.Text & "\OLS.bak' ", con)
            sql1.ExecuteNonQuery()
            con.Close()
            MsgBox("Backup Success!" & vbNewLine & "Backup Location: " & MetroTextBox1.Text & vbNewLine & "Date: " & Date.Now.ToString, vbInformation)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        MetroProgressSpinner1.Visible = False
        MetroLabel3.Visible = False
    End Sub
End Class