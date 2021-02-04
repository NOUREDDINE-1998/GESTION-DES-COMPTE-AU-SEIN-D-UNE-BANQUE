Imports System.Data
Imports System.Data.OleDb
Public Class Form2
    Public cnx As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\backup\Nordine\Nouveau dossier (2)\projet fin d annee\PROJET vb\projet fin d annee\projet fin d'annee\projet fin dannee\base donnee banque.accdb")

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Text = "physique"

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        initialiation()


    End Sub
    Sub initialiation()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        ComboBox1.Text = ""

        TextBox1.Focus()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        Try
            If DateValue(TextBox8.Text).ToString("dd/MM/yyyy") > Date.Now.ToString("dd/MM/yyyy") Then
                MsgBox("la date invalide", vbCritical, "message")
                Me.Close()


            End If
            Dim cmd As New OleDbCommand
            cmd.Connection = cnx

            cmd.CommandType = CommandType.Text
                cmd.CommandText = "Insert into client values( '" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + TextBox8.Text + "', '" + TextBox4.Text + "', '" + TextBox5.Text + "', '" + TextBox6.Text + "','" + ComboBox1.Text + "', '" + TextBox7.Text + "')"
                cnx.Open()

                If (cmd.ExecuteNonQuery() = 1) Then
                    MsgBox("ajout avec succes", vbInformation, "ajout")
                    initialiation()
                End If
                cnx.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            initialiation()

        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim cmd As New OleDbCommand
            cmd.Connection = cnx
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "update client set Nom='" & TextBox2.Text & "',Prenom= '" & TextBox3.Text & "',DateNaissance='" & TextBox8.Text & "',Adresse= '" & TextBox4.Text & "',Tel= '" & TextBox5.Text & "',CodePostal= '" & TextBox6.Text & "', TypeClient='" & ComboBox1.Text & "',Ville= '" & TextBox7.Text & "' where NCin='" & TextBox1.Text & "'"
            cnx.Open()

            If (cmd.ExecuteNonQuery() = 1) Then
                MsgBox("Modifie avec succes", vbInformation, "Modification")
                initialiation()

            End If
            cnx.Close()
        Catch ex As Exception
            MsgBox("erruer s'est produite", vbCritical, "erreur")
            initialiation()
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim cmd As New OleDbCommand
            cmd.Connection = cnx
            cmd.CommandType = CommandType.Text
            cmd.CommandText = " select * from client where NCin like'" & TextBox1.Text & "'"
            cnx.Open()
            Dim dr As OleDbDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                TextBox1.Text = dr(0)
                TextBox2.Text = dr(1)
                TextBox3.Text = dr(2)
                TextBox8.Text = dr(3)
                TextBox4.Text = dr(4)
                TextBox5.Text = dr(5)
                TextBox6.Text = dr(6)
                ComboBox1.Text = dr(7)
                TextBox7.Text = dr(8)
            Else
                MsgBox("n'existe pas")
            End If

            cnx.Close()
        Catch ex As Exception
            MsgBox("erruer s'est produite", vbCritical, "erreur")

        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim cmd As New OleDbCommand
            cmd.Connection = cnx
            cmd.CommandType = CommandType.Text
            cmd.CommandText = " DELETE from client WHERE (((client.NCin) like '" + TextBox1.Text + "'))"
            cnx.Open()
            If (cmd.ExecuteNonQuery() = 1) Then
                MsgBox("suppression avec succes", vbInformation, "suppression")
                initialiation()
            Else
                MsgBox("erreur s'est produite", vbCritical, "erreur")
            End If
            cnx.Close()
        Catch ex As Exception
            MsgBox("erruer s'est produite", vbCritical, "erreur")
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub
End Class