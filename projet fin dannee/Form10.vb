﻿Imports System.Data.OleDb
Public Class Form10
    Public cnx As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\backup\Nordine\Nouveau dossier (2)\projet fin d annee\PROJET vb\projet fin d annee\projet fin d'annee\projet fin dannee\base donnee banque.accdb")
    Public da As New OleDbDataAdapter
    Public dt As New DataTable
    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = Date.Now
        Try
            If cnx.State = ConnectionState.Closed Then
                cnx.Open()

            End If
            DataGridView1.Rows.Clear()
            da = New OleDbDataAdapter("select * from compte", cnx)
            da.Fill(dt)
            DataGridView1.DataSource = dt
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If cnx.State = ConnectionState.Closed Then
                cnx.Open()
                dt.Clear()
                da = New OleDbDataAdapter("select * from compte where NCompte = " + TextBox1.Text + "", cnx)
                da.Fill(dt)
                Me.DataGridView1.DataSource = dt
            End If
            If cnx.State = ConnectionState.Open Then
                cnx.Close()
            End If
        Catch EX As Exception
            MsgBox("erreur", vbCritical, "message")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()


    End Sub
    Private bitmap As Bitmap
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim height As Integer = DataGridView1.Height
        DataGridView1.Height = DataGridView1.RowCount * DataGridView1.RowTemplate.Height * 1.5
        Bitmap = New Bitmap(Me.DataGridView1.Width, Me.DataGridView1.Height)
        DataGridView1.DrawToBitmap(Bitmap, New Rectangle(0, 0, Me.DataGridView1.Width, Me.DataGridView1.Height))
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        PrintPreviewDialog1.ShowDialog()
        DataGridView1.Height = height
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        e.Graphics.DrawImage(bitmap, 1, 80)
        Dim rectprint As RectangleF = e.PageSettings.PrintableArea
        If Me.DataGridView1.Height - rectprint.Height > 0 Then
            e.HasMorePages = True

        End If
    End Sub
End Class