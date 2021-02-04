Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing.Printing
Public Class Form4
    Public cnx As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\backup\Nordine\Nouveau dossier (2)\projet fin d annee\PROJET vb\projet fin d annee\projet fin d'annee\projet fin dannee\base donnee banque.accdb")
    Public da As OleDbDataAdapter
    Public dt As New DataTable
    Public cmd As New OleDbCommand



    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If cnx.State = ConnectionState.Closed Then
            cnx.Open()
            cmd.Connection = cnx
            cmd.CommandType = CommandType.Text
            cmd.CommandText = (" select * from totaux_total_credt_debit")
            Dim dr As OleDbDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                TextBox2.Text = dr(0).ToString
                TextBox3.Text = dr(1).ToString
            End If

        End If
        TextBox4.Text = Val(TextBox2.Text) - Val(TextBox3.Text)

        Label5.Text = Date.Now
        da = New OleDbDataAdapter("select * from requete", cnx)
        da.Fill(dt)
        Me.DataGridView1.DataSource = dt
        If cnx.State = ConnectionState.Open Then
            cnx.Close()
        End If

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Me.Close()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If cnx.State = ConnectionState.Closed Then
                cnx.Open()
                dt.Clear()
                da = New OleDbDataAdapter("select * from requete where NCompte = " + TextBox1.Text + "", cnx)
                da.Fill(dt)
                Me.DataGridView1.DataSource = dt
            End If

            cmd.Connection = cnx
            cmd.CommandType = CommandType.Text
            cmd.CommandText = (" select * from total_credit_debit where NCompte=" + TextBox1.Text + "")
            Dim dr As OleDbDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                TextBox2.Text = dr(1).ToString
                TextBox3.Text = dr(2).ToString
            End If
            If cnx.State = ConnectionState.Open Then
                cnx.Close()

            End If
            TextBox4.Text = Val(TextBox2.Text) - Val(TextBox3.Text)
            Button1.Enabled = False
        Catch es As Exception
            MsgBox("erreur s'est produite!", vbCritical, "message")
        End Try
        If Me.DataGridView1.Rows.Count = 0 Then
            TextBox2.Text = Nothing
            TextBox3.Text = Nothing
            TextBox4.Text = Nothing

        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick


    End Sub



    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint


    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
    Private bitmap As Bitmap
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim height As Integer = DataGridView1.Height
            DataGridView1.Height = DataGridView1.RowCount * DataGridView1.RowTemplate.Height * 1.5
            bitmap = New Bitmap(Me.DataGridView1.Width, Me.DataGridView1.Height)
            DataGridView1.DrawToBitmap(bitmap, New Rectangle(0, 0, Me.DataGridView1.Width, Me.DataGridView1.Height))
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
            PrintPreviewDialog1.ShowDialog()
            DataGridView1.Height = height

        Catch es As Exception
            MsgBox("erreur s'est produite!", vbCritical, "message")
        End Try




    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        e.Graphics.DrawImage(bitmap, 1, 80)
        Dim rectprint As RectangleF = e.PageSettings.PrintableArea
        If Me.DataGridView1.Height - rectprint.Height > 0 Then
            e.HasMorePages = True

        End If


    End Sub


    Private Sub PrintDocument1_EndPrint(sender As Object, e As PrintEventArgs) Handles PrintDocument1.EndPrint


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button1.Enabled = True
        dt.Clear()
        TextBox1.Text = ""

        If cnx.State = ConnectionState.Closed Then
            cnx.Open()
            cmd.Connection = cnx
            cmd.CommandType = CommandType.Text
            cmd.CommandText = (" select * from totaux_total_credt_debit")
            Dim dr As OleDbDataReader
            dr = cmd.ExecuteReader
            If dr.Read Then
                TextBox2.Text = dr(0).ToString
                TextBox3.Text = dr(1).ToString
            End If

        End If
        TextBox4.Text = Val(TextBox2.Text) - Val(TextBox3.Text)

        Label5.Text = Date.Now
        da = New OleDbDataAdapter("select * from requete", cnx)
        da.Fill(dt)
        Me.DataGridView1.DataSource = dt
        If cnx.State = ConnectionState.Open Then
            cnx.Close()
        End If
    End Sub

    Private Sub PrintPreviewDialog1_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog1.Load

    End Sub
End Class