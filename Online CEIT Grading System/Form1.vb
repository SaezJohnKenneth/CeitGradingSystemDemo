Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim t As New Transitions.Transition(New Transitions.TransitionType_Acceleration(520))
        Dim q As New Transitions.Transition(New Transitions.TransitionType_Acceleration(520))


        t.add(MetroPanel1, "Width", 200)
        t.add(MetroPanel1, "Height", 200)
        Application.DoEvents()
        t.run()
        Threading.Thread.Sleep(220)
        q.add(MetroPanel2, "Width", 200)
        q.add(MetroPanel2, "Height", 200)
        Application.DoEvents()
        q.run()

    End Sub
End Class
