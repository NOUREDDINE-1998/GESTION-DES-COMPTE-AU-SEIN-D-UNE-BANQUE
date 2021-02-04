Imports System.Threading

Public Class Form1

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim th As New Thread(Sub() demarrer())
        th.Start()


    End Sub
    Sub demarrer()
        Thread.Sleep(2000)
        Form12.ShowDialog()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)






    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub
End Class
