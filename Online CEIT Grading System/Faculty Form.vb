Imports System.Data.SqlClient
Public Class Faculty_Form
    Public RUNNING_USER As Integer
    Private s As Integer
    Private id As Integer = 1000
    Private Sub MetroButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton2.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
        Else

        End If
    End Sub

    Private Sub MetroButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MetroButton3.Click

        If MetroButton3.Text = "Save" Then
            Try
                'Create Connection
                Dim SQLCON As New SqlConnection(ConnectionString)
                SQLCON.Open()

                'Create command
                Dim cmd As New SqlCommand("INSERT INTO Faculty(Name,Thumbnail,Address,ContactNo,Email,Status,Gender,Username,Password,AcccessLevel) VALUES(@name,@thumbnail,@address,@contact,@email,@status,@gender,@uname,@pword,@access)", SQLCON)

                cmd.Parameters.AddWithValue("@name", MetroTextBox1.Text)
                cmd.Parameters.AddWithValue("@uname", MetroTextBox3.Text)
                cmd.Parameters.AddWithValue("@pword", MetroTextBox2.Text)
                cmd.Parameters.AddWithValue("@gender", MetroComboBox2.Text)
                cmd.Parameters.AddWithValue("@status", MetroComboBox1.Text)
                cmd.Parameters.AddWithValue("@address", MetroTextBox4.Text)
                cmd.Parameters.AddWithValue("@contact", MetroTextBox5.Text)
                cmd.Parameters.AddWithValue("@email", MetroTextBox7.Text)
                cmd.Parameters.AddWithValue("@access", MetroComboBox3.Text)
                cmd.Parameters.AddWithValue("@thumbnail", GetImageData(OpenFileDialog1.FileName))
                cmd.ExecuteNonQuery()
                SQLCON.Close()
                MsgBox("Succesfull")
                MetroButton3.Text = "Add"
                MetroButton4.Enabled = False
                FilterTable("SELECT ID AS [Faculty ID],Name,Address,ContactNo AS [Contact No.],Email,Gender,Username,Password,AcccessLevel AS [Access Level] FROM Faculty", MetroGrid1)
            Catch ex As Exception
                MsgBox("Error" & ex.Message)
            End Try
        Else
            MetroButton3.Text = "Save"
            MetroButton4.Enabled = True
            MetroTextBox1.Text = ""
            MetroTextBox2.Text = ""
            MetroTextBox3.Text = ""
            MetroTextBox4.Text = ""
            MetroTextBox5.Text = ""
            MetroTextBox7.Text = ""
            MetroComboBox1.Text = ""
            MetroComboBox2.Text = ""
            MetroComboBox3.Text = ""
            validateContents(True)
        End If

    End Sub
    Private Sub validateContents(ByVal l As Boolean)


        MetroTextBox1.Enabled = l
        MetroTextBox2.Enabled = l
        MetroTextBox3.Enabled = l
        MetroTextBox4.Enabled = l
        MetroTextBox5.Enabled = l
        MetroTextBox7.Enabled = l
        MetroComboBox1.Enabled = l
        MetroComboBox2.Enabled = l
        MetroComboBox3.Enabled = l
        MetroButton2.Enabled = l
    End Sub
    Private Sub Faculty_Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()

    End Sub

    Private Sub Faculty_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FilterTable("SELECT ID AS [Faculty ID],Name,Address,ContactNo AS [Contact No.],Email,Gender,Username,Password,AcccessLevel AS [Access Level] FROM Faculty", MetroGrid1)

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
            MetroLabel12.Text = name2
            MetroLabel13.Text = access
            MetroPanel1.BackgroundImage = GetImageFromByte(readr(2))
        End While
        readr.Close()
        sqlcon.Close()
    End Sub

    Private Sub MetroTextBox6_Click(sender As Object, e As EventArgs) Handles MetroTextBox6.Click

    End Sub

    Private Sub MetroRadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles MetroRadioButton1.CheckedChanged
        FilterTable("SELECT ID AS [Faculty ID],Name,Address,ContactNo AS [Contact No.],Email,Gender,Username,Password,AcccessLevel AS [Access Level] FROM Faculty", MetroGrid1)
        MetroTextBox6.WaterMark = "Enter Faculty ID.."
        MetroTextBox6.Enabled = True
    End Sub

    Private Sub MetroRadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles MetroRadioButton2.CheckedChanged
        FilterTable("SELECT ID AS [Faculty ID],Name,Address,ContactNo AS [Contact No.],Email,Gender,Username,Password,AcccessLevel AS [Access Level] FROM Faculty", MetroGrid1)
        MetroTextBox6.WaterMark = "Enter Name.."
        MetroTextBox6.Enabled = True
    End Sub

    Private Sub MetroRadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles MetroRadioButton3.CheckedChanged
        FilterTable("SELECT ID AS [Faculty ID],Name,Address,ContactNo AS [Contact No.],Email,Gender,Username,Password,AcccessLevel AS [Access Level] FROM Faculty WHERE AcccessLevel = 'Faculty'", MetroGrid1)
        MetroTextBox6.WaterMark = ""
        MetroTextBox6.Enabled = False
    End Sub

    Private Sub MetroRadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles MetroRadioButton4.CheckedChanged
        FilterTable("SELECT ID AS [Faculty ID],Name,Address,ContactNo AS [Contact No.],Email,Gender,Username,Password,AcccessLevel AS [Access Level] FROM Faculty WHERE AcccessLevel = 'Admin'", MetroGrid1)
        MetroTextBox6.Enabled = False
    End Sub

    Private Sub MetroGrid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles MetroGrid1.CellContentClick

    End Sub

    Private Sub MetroGrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles MetroGrid1.CellClick
        id = MetroGrid1.Item(0, e.RowIndex).Value
        Dim con As New SqlConnection(ConnectionString)
        con.Open()
        Dim cmd As New SqlCommand("SELECT Name,Address,ContactNo AS [Contact No.],Email,Gender,Username,Password,AcccessLevel AS [Access Level],Thumbnail FROM Faculty WHERE ID = " & MetroGrid1.Item(0, e.RowIndex).Value, con)
        Dim r As SqlDataReader = cmd.ExecuteReader

        r.Read()
        MetroTextBox1.Text = r(0)
        MetroTextBox4.Text = r(1)
        MetroTextBox5.Text = r(2)
        MetroTextBox7.Text = r(3)
        MetroComboBox2.Text = r(4)
        MetroTextBox3.Text = r(5)
        MetroTextBox2.Text = r(6)
        MetroComboBox3.Text = r(7)
        PictureBox1.BackgroundImage = GetImageFromByte(r(8))
        r.Close()
        con.Close()
    End Sub


    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click

        If MetroButton5.Text = "Update" Then
            MetroButton5.Text = "Save"
            MetroButton6.Enabled = True
            validateContents(True)
        Else
            MetroButton5.Text = "Update"
            Try
                Dim con As New SqlConnection(ConnectionString)
                con.Open()
                Dim cmd As New SqlCommand("UPDATE Faculty SET Name = @name,Address = @address,ContactNo = @contact,Email = @email,Gender = @gender WHERE ID = " & id, con)
                cmd.Parameters.AddWithValue("@name", MetroTextBox1.Text)
                cmd.Parameters.AddWithValue("@uname", MetroTextBox3.Text)
                cmd.Parameters.AddWithValue("@pword", MetroTextBox2.Text)
                cmd.Parameters.AddWithValue("@gender", MetroComboBox2.Text)
                cmd.Parameters.AddWithValue("@status", MetroComboBox1.Text)
                cmd.Parameters.AddWithValue("@address", MetroTextBox4.Text)
                cmd.Parameters.AddWithValue("@contact", MetroTextBox5.Text)
                cmd.Parameters.AddWithValue("@email", MetroTextBox7.Text)
                cmd.Parameters.AddWithValue("@access", MetroComboBox3.Text)
                cmd.Parameters.AddWithValue("@thumbnail", GetImageDataFromImage(PictureBox1.BackgroundImage))
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("Updated Succesfully", vbInformation)
                FilterTable("SELECT ID AS [Faculty ID],Name,Address,ContactNo AS [Contact No.],Email,Gender,Username,Password,AcccessLevel AS [Access Level] FROM Faculty", MetroGrid1)
                validateContents(False)
                MetroButton3.Enabled = True

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        validateContents(False)
        MetroButton4.Enabled = False
        MetroButton3.Text = "Add"
    End Sub

    Private Sub MetroButton6_Click(sender As Object, e As EventArgs) Handles MetroButton6.Click
        validateContents(False)
        MetroButton6.Enabled = False
        MetroButton5.Text = "Update"

    End Sub

    Private Sub MetroTextBox6_TextChanged(sender As Object, e As EventArgs) Handles MetroTextBox6.TextChanged
        If MetroRadioButton1.Checked Then
            FilterTable("SELECT ID AS [Faculty ID],Name,Address,ContactNo AS [Contact No.],Email,Gender,Username,Password,AcccessLevel AS [Access Level] FROM Faculty WHERE ID = " & MetroTextBox6.Text, MetroGrid1)
        ElseIf MetroRadioButton2.Checked Then
            FilterTable("SELECT ID AS [Faculty ID],Name,Address,ContactNo AS [Contact No.],Email,Gender,Username,Password,AcccessLevel AS [Access Level] FROM Faculty WHERE Name LIKE  '" & MetroTextBox6.Text & "%'", MetroGrid1)
        Else
        End If

    End Sub
End Class