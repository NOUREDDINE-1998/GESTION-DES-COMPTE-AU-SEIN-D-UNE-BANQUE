Imports System.Data.OleDb


Public Class Form11
    Public cnx As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\backup\Nordine\Nouveau dossier (2)\projet fin d annee\PROJET vb\projet fin d annee\projet fin d'annee\projet fin dannee\base donnee banque.accdb")
    Public cmd As New OleDbCommand
    Public dr As OleDbDataReader
    Private Sub Button3_Click(sender As Object, e As EventArgs) 
        initialisation()
        TextBox1.Focus()

    End Sub
    Sub initialisation()
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) 
        Me.Close()
        initialisation()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        initialisation()

        Me.Close()


    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If cnx.State = ConnectionState.Closed Then
            cnx.Open()

        End If
        cmd.Connection = cnx
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select * from Soldetrue where NCompte like '" + TextBox1.Text + "'"
        dr = cmd.ExecuteReader()
        If dr.Read Then
            TextBox1.Text = dr(0)
            TextBox3.Text = dr(1)
            TextBox4.Text = dr(2)
            TextBox5.Text = dr(5)

        End If
        If cnx.State = ConnectionState.Open Then
            cnx.Close()

        End If
        Me.TextBox5.Text = FormatCurrency(Me.TextBox5.Text)
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        initialisation()

    End Sub
End Class