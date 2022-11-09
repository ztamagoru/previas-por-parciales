Public Class Form2
    Dim conexion As New Class1

    Private Sub Form2_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Visible Then

        End If

        Dim atributos As String

        If GroupBox1.Visible Then
            atributos = "VALUES ('" + txnombre.Text.Trim + "')"
        Else
            atributos = "VALUES ('" + txtitulo.Text.Trim + "', '" +
                        ComboBox1.Text + "', '" +
                        ComboBox2.Text + "', '" +
                        MaskedTextBox1.Text + "')"
        End If

        Dim comando As String

        comando = "Insert into " + Form1.ComboBox1.Text + " " + atributos

        conexion.execute(comando)
        Form1.dgvrefresh()
    End Sub
End Class