Imports System.Data.SqlClient
Imports System.Xml

Public Class SetFinalEncoding
    Private Sub SetFinalEncoding_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MetroLabel2.Text = Date.Now.ToString("yyyy")
        Dim xr As XmlReader
        Dim s As String = ""

        xr = XmlReader.Create("DateEnd.xml", New XmlReaderSettings)
        While xr.Read
            If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "Date" Then
                s = xr.ReadElementString
            End If
        End While
        xr.Close()
        MetroLabel2.Text = s
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        If MsgBox("Are you sure you want to set the new Deadline of Encoding?", vbYesNo) = MsgBoxResult.Yes Then
            Dim settings As XmlWriterSettings = New XmlWriterSettings()
            settings.Indent = True
            Using writer As XmlWriter = XmlWriter.Create(System.AppDomain.CurrentDomain.BaseDirectory.ToString & "DateEnd.xml", settings)
                writer.WriteStartDocument()
                writer.WriteStartElement("DateEnd")
                writer.WriteElementString("Date", MetroDateTime1.Value.ToString("yyyy-MM-dd"))
                writer.WriteEndElement()
                writer.WriteEndDocument()
                writer.Close()
            End Using
            MsgBox("Deadline Changed")

        Else
        End If
    End Sub

    Private Sub SetFinalEncoding_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
End Class