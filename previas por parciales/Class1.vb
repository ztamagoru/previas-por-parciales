Imports System.Data.SqlClient

Public Class Class1
    Public conn As New SqlConnection
    Public cmd As New SqlCommand
    Public dataadapter As New SqlDataAdapter
    Public dataser As New DataSet
    Public connerror As String

    Sub New()
        Try
            conn.ConnectionString = "Server=;"
        Catch ex As Exception

        End Try
    End Sub
End Class
