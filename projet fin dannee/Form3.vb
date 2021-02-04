Imports System.Data
Imports System.Data.OleDb
Public Class Form3
    Public cnx As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\backup\Nordine\Nouveau dossier (2)\projet fin d annee\PROJET vb\projet fin d annee\projet fin d'annee\projet fin dannee\base donnee banque.accdb")
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox2.Enabled = False



    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
        initialisation()

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
    Sub initialisation()
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        ComboBox2.Text = ""
        TextBox4.Focus()

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

        If ComboBox2.Text = "Dépot" Then
            TextBox9.Text = Val(0).ToString("c")
            TextBox9.MaxLength = 1

        ElseIf ComboBox2.Text = "Retrait" Then
            TextBox7.Text = Val(0).ToString("c")
            TextBox7.MaxLength = 1
        ElseIf ComboBox2.Text = "Versement" Then
            TextBox9.Text = Val(0).ToString("c")
            TextBox9.MaxLength = 1

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox2_Click(sender As Object, e As EventArgs) Handles ComboBox2.Click

    End Sub

    Private Sub TextBox4_Click(sender As Object, e As EventArgs) Handles TextBox4.Click
        Dim num As Integer
        Try
            cnx.Open()

            Dim cmd As New OleDbCommand
            cmd.Connection = cnx
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select max(NOperation) from operation"

            cmd.ExecuteNonQuery()
            If IsDBNull(cmd.ExecuteScalar) Then
                num = 1
                TextBox4.Text = num
            Else
                num = cmd.ExecuteScalar + 1
                TextBox4.Text = num
            End If
            If cnx.State = ConnectionState.Open Then



            End If
        Catch ex As Exception
            MsgBox("erruer s'est produite", vbCritical, "erreur")
            initialisation()
        End Try
        cnx.Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        TextBox8.Text = Date.Now.Date
        GroupBox2.Enabled = True
        TextBox4.Focus()

    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            Dim cmd As New OleDbCommand
            cmd.Connection = cnx
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "Insert into operation values( '" & TextBox4.Text & "',  '" & TextBox5.Text & "','" & ComboBox2.Text & "', '" & TextBox8.Text & "',  '" & TextBox7.Text & "','" & TextBox9.Text & "')"

            cnx.Open()

            If (cmd.ExecuteNonQuery() = 1) Then
                MsgBox("l'ajout avec succes", vbInformation, "ajout")
                initialisation()
            End If
            cnx.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            initialisation()
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cmd As New OleDbCommand
        cmd.Connection = cnx
        cmd.CommandType = CommandType.Text
        cmd.CommandText = " select * from operation where NOperation = " + TextBox4.Text + " "
        cnx.Open()
        Dim dr As OleDbDataReader
        dr = cmd.ExecuteReader
        If dr.Read Then
            TextBox4.Text = dr(0)
            TextBox5.Text = dr(1)
            ComboBox2.Text = dr(2)
            TextBox8.Text = dr(3)
            TextBox7.Text = dr(4)
            TextBox9.Text = dr(5)

        Else
            MsgBox("n'existe pas")
        End If
        cnx.Close()
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Dim cmd As New OleDbCommand
        cmd.Connection = cnx
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "update operation set NCompte= '" & TextBox5.Text & "',Libelle='" & ComboBox2.Text & "',DateOperation= '" & TextBox8.Text & "',MontantCredit= '" & TextBox7.Text & "',MontantDebit= '" & TextBox9.Text & "' where NOperation=" + TextBox4.Text + ""
        cnx.Open()

        If (cmd.ExecuteNonQuery() = 1) Then
            MsgBox("Modifie avec succes", vbInformation, "Modification")
            initialisation()

        End If
        cnx.Close()
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim cmd As New OleDbCommand
            cmd.Connection = cnx
            cmd.CommandType = CommandType.Text
            cmd.CommandText = " DELETE from operation WHERE (((operation.NOperation) like '" + TextBox4.Text + "'))"
            cnx.Open()
            If (cmd.ExecuteNonQuery() = 1) Then
                MsgBox("suppression avec succes", vbInformation, "suppression")
                initialisation()
            Else
                MsgBox("erreur s'est produite", vbCritical, "erreur")
            End If
            cnx.Close()
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub
End Class