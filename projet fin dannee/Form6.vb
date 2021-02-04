Imports System.Data
Imports System.Data.OleDb


Public Class Form6
    Public cnx As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\backup\Nordine\Nouveau dossier (2)\projet fin d annee\PROJET vb\projet fin d annee\projet fin d'annee\projet fin dannee\base donnee banque.accdb")
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cmd As New OleDbCommand
            cmd.Connection = cnx
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from agence '"
            cnx.Open()
            Dim dr As OleDbDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                Label6.Text = dr(0)
                Label7.Text = dr(1)
                Label8.Text = dr(2)
                Label9.Text = dr(3)

            Else
                MsgBox("n'existe pas")
            End If

            cnx.Close()
        Catch ex As Exception
            MsgBox("erruer s'est produite", vbCritical, "erreur")

        End Try

        cnx.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub



    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Form13.ShowDialog()
        Me.Hide()

    End Sub
End Class