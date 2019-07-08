Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Data
Imports System.IO
Imports System.Xml
Module Module1
    Public Sub populateComboboxByCustom(Sql As String, cmbBox As MetroFramework.Controls.MetroComboBox)
        Dim sqlcon As New SqlConnection(ConnectionString)
        sqlcon.Open()
        Dim cmd As New SqlCommand(Sql, sqlcon)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        cmbBox.Items.Clear()
        While reader.Read
            cmbBox.Items.Add(reader(0))
        End While
        reader.Close()
        sqlcon.Close()
    End Sub
    Public Sub populateCombobox(ByVal cmbBox As MetroFramework.Controls.MetroComboBox, ByVal table As String, ByVal fieldToBePopulate As String)
        Dim sqlcon As New SqlConnection(ConnectionString)
        sqlcon.Open()
        Dim cmd As New SqlCommand("SELECT " & fieldToBePopulate & " from " & table, sqlcon)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        cmbBox.Items.Clear()
        While reader.Read
            cmbBox.Items.Add(reader(0))
        End While
        reader.Close()
        sqlcon.Close()
    End Sub
    Public Function AppPath() As String
        Return System.AppDomain.CurrentDomain.BaseDirectory.ToString
    End Function
    Public Function GetImageData(ByVal imgFilePath As String) As Byte()
        'Image Initialization Processing
        Dim img As Image = Image.FromFile(imgFilePath)
        Dim memStrm As New MemoryStream
        img.Save(memStrm, img.RawFormat)
        Dim buffer As Byte() = memStrm.GetBuffer
        'End of image intialization
        Return buffer
    End Function
    Public Sub FilterTable(ByVal sql As String, ByVal datagrid As MetroFramework.Controls.MetroGrid)
        Dim sqlcon As New SqlConnection(ConnectionString)
        Dim cmd As New SqlCommand(sql, sqlcon)

        Dim adapteer As New SqlDataAdapter
        Dim table As New DataTable
        Dim bs As New BindingSource

        adapteer.SelectCommand = cmd
        adapteer.Fill(table)
        bs.DataSource = table

        datagrid.DataSource = bs
        adapteer.Update(table)
    End Sub
    Public Sub parseXML(ByVal cmd As String, ByVal path As String)
        Dim adapter As SqlDataAdapter
        Dim ds As New DataSet
        Dim connection As New SqlConnection(ConnectionString)
        Try
            connection.Open()
            adapter = New SqlDataAdapter(cmd, connection)
            adapter.Fill(ds)
            connection.Close()
            ds.WriteXml(path)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Function ConnectionString() As String
        Return "Data Source=.\SQLEXPRESS;AttachDbFilename='" & AppPath() & "OLS.mdf';Integrated Security=True;Connect Timeout=30;User Instance=True"
    End Function
    Public Function GetImageFromByte(ByVal obj() As Byte) As Image
        Dim img() As Byte
        img = obj
        Dim ms As New MemoryStream(img)
        Dim returningImage As Image
        returningImage = Image.FromStream(ms)
        Return returningImage
    End Function
    Public Function GetImageDataFromImage(ByVal imgV As Image) As Byte()
        'Image Initialization Processing
        Dim img As Image = imgV
        Dim memStrm As New MemoryStream
        img.Save(memStrm, img.RawFormat)
        Dim buffer As Byte() = memStrm.GetBuffer
        'End of image intialization
        Return buffer
    End Function
    Public Function getTableID(ByVal tableName As String, ByVal fieldValue As String, ByVal field As String, ByVal idFieldName As String) As Integer
        Dim sqlcon As New SqlConnection(ConnectionString)
        sqlcon.Open()

        Dim cmd As New SqlCommand("SELECT " & idFieldName & " FROM " & tableName & " WHERE " & field & " = '" & fieldValue & "'", sqlcon)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        Dim ID As Integer = 0
        reader.Read()
        ID = reader(0)
        reader.Close()
        Return ID
        sqlcon.Close()

    End Function
    Public Function getDeadlineOfEncoding() As String
        Dim xr As XmlReader
        Dim s As String = ""

        xr = XmlReader.Create("DateEnd.xml", New XmlReaderSettings)
        While xr.Read
            If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "Date" Then
                s = xr.ReadElementString
            End If
        End While
        xr.Close()
        Return s
    End Function

    Public Function getCurrentActiveSem() As String
        Dim xr As XmlReader
        Dim s As String = ""

        xr = XmlReader.Create("Sem.xml", New XmlReaderSettings)
        While xr.Read
            If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "SEM" Then
                s = xr.ReadElementString
            End If
        End While
        xr.Close()
        Return s
    End Function
    Public Sub FIND_USER(ByVal userName As String, ByVal password As String)
        Try
            Dim sqlcon As New SqlConnection(ConnectionString)

            sqlcon.Open()
            Dim sqlcom As New SqlCommand("SELECT * FROM Faculty", sqlcon)
            Dim readr As SqlDataReader = sqlcom.ExecuteReader
            Dim runInt As Integer = 0
            Dim user As String
            Dim pass As String
            Dim id As String
            Dim loginSuccesfull As Boolean = False
            While readr.Read
                id = readr(0)
                user = readr(8)
                pass = readr(9)
                If userName = user And password = pass Then
                    loginSuccesfull = True
                    Exit While
                Else
                End If
            End While
            If loginSuccesfull Then
                'MsgBox("Welcome " & readr(1), vbInformation)
                Welcome_Screen.RUNNING_USER = readr(0)
                Welcome_Screen.ShowDialog()

                Admin_Menu_Form.RUNNING_USER = readr(0)
                Faculty_Form.RUNNING_USER = readr(0)
                Drop_Form.RUNNING_USER = readr(0)
                Subject_Form.RUNNING_USER = readr(0)
                Course_Form.RUNNING_USER = readr(0)
                Room_Form.RUNNING_USER = readr(0)
                Faculty_Menu_Form.RUNNING_USER = readr(0)
                Midterm_Form.RUNNING_USER = readr(0)
                Midterm_Grading_Form.RUNNING_USER = readr(0)
                Final_Form.RUNNING_USER = readr(0)
                Final_Grading_Form.RUNNING_USER = readr(0)
                Student_Form.RUNNING_USER = readr(0)


                If readr(10) = "Admin" Then
                    My.Application.ApplicationContext.MainForm = Admin_Menu_Form
                    Form2.Close()
                    Admin_Menu_Form.Show()

                Else
                    My.Application.ApplicationContext.MainForm = Faculty_Form
                    Form2.Close()
                    Faculty_Menu_Form.Show()

                End If
                readr.Close()
                sqlcon.Close()
                Form2.Close()
            Else
                MsgBox("Login Failed", vbExclamation)
            End If
            sqlcon.Close()

        Catch ex As Exception
            MsgBox("Exceptional Error: " & ex.Message, vbCritical)
        End Try
    End Sub
    Public Sub parseXMLGradeSheet(ByVal sql As String)

        Try
            Dim sqlCOn As New SqlConnection(ConnectionString)
            sqlCOn.Open()
            Dim sqlcmd As New SqlCommand(sql, sqlCOn)
            Dim sqlreader As SqlDataReader = sqlcmd.ExecuteReader
            Dim settings As XmlWriterSettings = New XmlWriterSettings()
            settings.Indent = True
            Using writer As XmlWriter = XmlWriter.Create("C:\Online CEIT Grading System\Online CEIT Grading System\GradeSheet.xml", settings)
                writer.WriteStartDocument()
                Dim total As Integer = 0
                writer.WriteStartElement("Students")
                While sqlreader.Read
                    writer.WriteStartElement("Data")
                    writer.WriteElementString("S_ID", sqlreader(0))
                    writer.WriteElementString("S_Name", sqlreader(1))
                    writer.WriteElementString("Midterm", sqlreader(2))
                    writer.WriteElementString("Final", sqlreader(3))
                    writer.WriteElementString("Remarks", sqlreader(4))
                    writer.WriteElementString("DateEcoded", sqlreader(5))
                    writer.WriteEndElement()
                End While
                writer.WriteEndElement()
                writer.WriteEndDocument()
            End Using
            sqlreader.Close()
            sqlCOn.Close()
        Catch ex As Exception
            MsgBox("Error in XML Reporting: " & ex.Message, vbCritical)

        End Try
    End Sub
    Public Sub parseXMLGradeSheetDetails(ByVal sql As String)

    End Sub
End Module
