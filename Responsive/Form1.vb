Imports ClassSql
Imports System.Data.SqlClient
Public Class Form1
    Dim dt As New DataTable
    Dim id As String

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        UcHome1.BringToFront()
    End Sub

    Private Sub btnResources_Click(sender As Object, e As EventArgs) Handles btnResources.Click
        UcResources1.BringToFront()
    End Sub

End Class
