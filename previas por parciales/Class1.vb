Imports System.Data.SqlClient

Public Class Class1
    Public conn As New SqlConnection
    Public cmd As New SqlCommand
    Public dataadapter As New SqlDataAdapter
    Public dataset As New DataSet
    Public connerror As String

    Public Sub New()
        Try
            conn.ConnectionString = "Server=(Localdb)\servidormaria;Database=Biblioteca;Integrated Security=true;User Id=prueba;Password=12345678;"
            conn.Open()

            cmd.Connection = conn

            'MsgBox("conexion exitosa")

            connerror = String.Empty
        Catch ex As Exception
            connerror = ex.Message
        End Try
    End Sub

    Public Sub execute(comando As String)
        Try
            cmd.CommandText = comando
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, vbOK)
        End Try
    End Sub
End Class
