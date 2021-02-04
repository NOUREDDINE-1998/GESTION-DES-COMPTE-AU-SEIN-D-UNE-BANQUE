Imports System.Data
Imports System.Data.OleDb

Public Class Form7
    Public cnx As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\backup\Nordine\Nouveau dossier (2)\projet fin d annee\PROJET vb\projet fin d annee\projet fin d'annee\projet fin dannee\base donnee banque.accdb")
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TextBox4.Text = Date.Now.Date
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        initialisation()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim cmd As New OleDbCommand
            cmd.Connection = cnx
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Insert into compte values( '" & TextBox1.Text & "', '" & TextBox3.Text & "', '" & TextBox2.Text & "', '" & ComboBox1.Text & "', '" & TextBox4.Text & "')"
            cnx.Open()

            If (cmd.ExecuteNonQuery() = 1) Then
                MsgBox("l'ajout avec succes", vbInformation, "ajout")
                initialisation()
            Else
                MsgBox("erreur s'est produite", vbCritical, "message")
            End If

            cnx.Close()
        Finally
        End Try



    End Sub
    Sub initialisation()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
        TextBox1.Focus()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim cmd As New OleDbCommand
        cmd.Connection = cnx
        cmd.CommandType = CommandType.Text
        cmd.CommandText = " DELETE from compte WHERE (((compte.NCompte) like '" + TextBox1.Text + "'))"
        cnx.Open()
        If (cmd.ExecuteNonQuery() = 1) Then
            MsgBox("suppression avec succes", vbInformation, "suppression")
            initialisation()
        Else
            MsgBox("erreur s'est produite", vbCritical, "erreur")
        End If
        cnx.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim cmd As New OleDbCommand
            cmd.Connection = cnx
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "update compte set IdAgence ='" & TextBox3.Text & "',NCin= '" & TextBox2.Text & "',TypeCompte='" & ComboBox1.Text & "',DateOuverture= '" & TextBox4.Text & "' where NCompte=" & TextBox1.Text & ""
            cnx.Open()

            If (cmd.ExecuteNonQuery() = 1) Then
                MsgBox("Modifie avec succes", vbInformation, "Modification")
                initialisation()

            End If
            cnx.Close()
        Catch ex As Exception
            MsgBox("erruer s'est produite", vbCritical, "erreur")
            initialisation()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If cnx.State = ConnectionState.Closed Then
                cnx.Open()
            End If
            Dim cmd As New OleDbCommand
            cmd.Connection = cnx
            cmd.CommandType = CommandType.Text
            cmd.CommandText = " select * from compte where NCompte=" + TextBox1.Text + ""

            Dim dr As OleDbDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                TextBox1.Text = dr(0)
                TextBox2.Text = dr(2)
                TextBox3.Text = dr(1)
                TextBox4.Text = dr(4)
                ComboBox1.Text = dr(3)

            Else
                MsgBox("n'existe pas")
            End If
            If cnx.State = ConnectionState.Open Then
                cnx.Close()

            End If


        Catch ex As Exception
            MsgBox("erruer s'est produite", vbCritical, "erreur")

        End Try
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)





    End Sub
    Sub auto()
        If cnx.State = ConnectionState.Closed Then

            cnx.Open()

        End If
        Dim num As Integer
        Dim cmd As New OleDbCommand
        cmd.Connection = cnx
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select max(NCompte) from compte"

        cmd.ExecuteNonQuery()
        If IsDBNull(cmd.ExecuteScalar) Then
            num = 1
            TextBox1.Text = num
        Else
            num = cmd.ExecuteScalar + 1
            TextBox1.Text = num
        End If
        If cnx.State = ConnectionState.Open Then

            cnx.Close()

        End If
    End Sub

    Private Sub Form7_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        Dim num As Integer
        Try
            cnx.Open()

            Dim cmd As New OleDbCommand
            cmd.Connection = cnx
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select max(NCompte) from compte"

            cmd.ExecuteNonQuery()
            If IsDBNull(cmd.ExecuteScalar) Then
                num = 1
                TextBox1.Text = num
            Else
                num = cmd.ExecuteScalar + 1
                TextBox1.Text = num
            End If
            If cnx.State = ConnectionState.Open Then



            End If
        Catch ex As Exception
            MsgBox("erruer s'est produite", vbCritical, "erreur")
            initialisation()
        End Try
        cnx.Close()
    End Sub

    Private Sub TextBox3_Click(sender As Object, e As EventArgs) Handles TextBox3.Click
        Try

            Dim cmd As New OleDbCommand
            cmd.Connection = cnx
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select * from agence '"
            cnx.Open()
            Dim dr As OleDbDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                TextBox3.Text = dr(0)
            Else
                MsgBox("n'existe pas")
            End If

            cnx.Close()
        Catch ex As Exception
            MsgBox("erruer s'est produite", vbCritical, "erreur")

        End Try

        cnx.Close()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub
End Class