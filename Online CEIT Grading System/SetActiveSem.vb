Imports System.IO
Imports System.Xml
Public Class SetActiveSem
    Private Sub SetActiveSem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MetroLabel5.Text = Date.Now.ToString("yyyy")
        Dim xr As XmlReader
        Dim s As String = ""

        xr = XmlReader.Create("Sem.xml", New XmlReaderSettings)
        While xr.Read
            If xr.NodeType = XmlNodeType.Element AndAlso xr.Name = "SEM" Then
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
            Using writer As XmlWriter = XmlWriter.Create(System.AppDomain.CurrentDomain.BaseDirectory.ToString & "Sem.xml", settings)
                writer.WriteStartDocument()
                writer.WriteStartElement("ActiveSem")
                writer.WriteElementString("SEM", MetroLabel5.Text & "/" & MetroComboBox1.Text)
                writer.WriteEndElement()
                writer.WriteEndDocument()
                writer.Close()
            End Using
            MsgBox("Deadline Changed")

        Else

        End If
    End Sub

    Private Sub SetActiveSem_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
End Class