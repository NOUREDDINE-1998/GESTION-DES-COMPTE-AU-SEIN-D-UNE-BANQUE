Imports System.Data
Imports System.Data.OleDb
Public Class Form13
    Public cnx As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\backup\Nordine\Nouveau dossier (2)\projet fin d annee\PROJET vb\projet fin d annee\projet fin d'annee\projet fin dannee\base donnee banque.accdb")
    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim cmd As New OleDbCommand
            cmd.Connection = cnx
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from agence '"
            cnx.Open()
            Dim dr As OleDbDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                TextBox1.Text = dr(0)
                TextBox2.Text = dr(1)
                TextBox3.Text = dr(2)
                TextBox4.Text = dr(3)

            Else
                MsgBox("n'existe pas")
            End If

            cnx.Close()
        Catch ex As Exception
            MsgBox("erruer s'est produite", vbCritical, "erreur")

        End Try

        cnx.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim cmd As New OleDbCommand
            cmd.Connection = cnx
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "update agence set Ville ='" & TextBox2.Text & "', Quartier ='" & TextBox3.Text & "', N°Telephone ='" & TextBox4.Text & "' where IdAgence ='" & TextBox1.Text & "'"
            cnx.Open()

            If (cmd.ExecuteNonQuery() = 1) Then
                MsgBox("Modifie avec succes", vbInformation, "Modification")

            End If

        Catch ex As Exception
            MsgBox("erruer s'est produite", vbCritical, "erreur")
            Dim cmd As New OleDbCommand
            cmd.Connection = cnx
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from agence '"

            Dim dr As OleDbDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                TextBox1.Text = dr(0)
                TextBox2.Text = dr(1)
                TextBox3.Text = dr(2)
                TextBox4.Text = dr(3)

            Else
                MsgBox("n'existe pas")
            End If

            cnx.Close()
        End Try
    End Sub
    Sub initialiation()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""

        TextBox1.Focus()
    End Sub
End Class