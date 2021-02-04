Imports System
Imports System.Data.OleDb

Public Class Form12
    Public cnx As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\backup\Nordine\Nouveau dossier (2)\projet fin d annee\PROJET vb\projet fin d annee\projet fin d'annee\projet fin dannee\base donnee banque.accdb")
    Dim cmd As New OleDbCommand

    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        TextBox1.Text = ""

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        cmd.Connection = cnx
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from utilisateur where login = '" + TextBox1.Text + "' and motpasse = '" + TextBox2.Text + "' "
        cnx.Open()
        Dim dr As OleDbDataReader
        dr = cmd.ExecuteReader
        If dr.Read Then
            Form8.ShowDialog()
            Form7.Text = Me.TextBox1.Text
        Else
            MsgBox("login ou mot de passe invalide ", vbCritical, "Message")
        End If
        cnx.Close()

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Focus()

    End Sub
End Class