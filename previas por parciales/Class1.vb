Imports System.Data.SqlClient

Public Class Class1
    Public conn As New SqlConnection
    Public cmd As New SqlCommand
    Public reader As SqlDataReader
    Public dataadapter As New SqlDataAdapter
    Public dataset As New DataSet
    Public connerror As String

    Public Sub New()
        Try
            conn.ConnectionString = "Server=DESKTOP-ULVBESH\SQLEXPRESS;Database=Biblioteca;Integrated Security=true;User Id=prueba;Password=12345678;"
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

    Public Sub addcbautor(comando As String)
        Dim result As String

        Try
            Dim i As Integer = 0

            cmd.CommandText = comando

            reader = cmd.ExecuteReader()

            Do While reader.Read()
                result = reader.GetString(0)
                Form2.cbautor.Items.Add(result)
            Loop

            reader.Close()

        Catch ex As Exception
            MsgBox(ex.Message, vbOK)
        End Try
    End Sub

    Public Sub addcbeditorial(comando As String)
        Dim result As String

        Try
            Dim i As Integer = 0
            cmd.CommandText = comando

            reader = cmd.ExecuteReader()

            Do While reader.Read()
                result = reader.GetString(0)
                Form2.cbeditorial.Items.Add(result)
            Loop

            reader.Close()

        Catch ex As Exception
            MsgBox(ex.Message, vbOK)
        End Try
    End Sub
End Class
