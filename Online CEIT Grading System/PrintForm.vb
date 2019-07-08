Public Class PrintForm
    Private Sub PrintForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub PrintForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class