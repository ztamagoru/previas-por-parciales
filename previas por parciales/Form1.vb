Imports System.Text.RegularExpressions

Public Class Form1
    Dim conexion As New Class1

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            dgvrefresh()
        Catch ex As Exception
            MsgBox(conexion.connerror)
        End Try
    End Sub

    Public Sub dgvrefresh()
        Dim comando As String

        conexion.dataset = New DataSet

        Try
            comando = "Select * from " + ComboBox1.Text

            conexion.execute(comando)

            conexion.dataadapter = New System.Data.SqlClient.SqlDataAdapter(conexion.cmd)
            conexion.dataadapter.Fill(conexion.dataset)

            DataGridView1.DataSource = conexion.dataset.Tables(0).DefaultView
        Catch ex As Exception
            MsgBox("Error." + vbCrLf + ex.Message, vbOK)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = String.Empty Then
            MsgBox("No hay ninguna tabla seleccionada.")
        Else
            Form2.Label1.Text = "Ingresando a la tabla: " + ComboBox1.Text

            If ComboBox1.Text = "Libro" Then
                Form2.GroupBox2.Visible = True
                Form2.GroupBox1.Visible = False
            Else
                Form2.GroupBox2.Visible = False
                Form2.GroupBox1.Visible = True
            End If

            Form2.Show()
            Me.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text.Trim = String.Empty Then
            MsgBox("La consulta se encuentra vacía.")

            'ElseIf ComboBox1.Text = String.Empty Then
            '    MsgBox("No hay ninguna tabla seleccionada.")

        ElseIf Not regex.IsMatch(TextBox1.Text.Trim, "^(?:Select)(?:.{1,})", RegexOptions.IgnoreCase) Then
            MsgBox("El texto escrito no es una consulta")

        Else
            Try
                Dim comando As String

                comando = TextBox1.Text.Trim

                ejecutarComando(comando)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Sub ejecutarComando(comando As String)
        Try
            conexion.execute(comando)

            conexion.dataset = New DataSet

            conexion.dataadapter = New System.Data.SqlClient.SqlDataAdapter(conexion.cmd)
            conexion.dataadapter.Fill(conexion.dataset)

            DataGridView1.DataSource = conexion.dataset.Tables(0).DefaultView
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
