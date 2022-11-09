Public Class Form2
    Dim conexion As New Class1

    Private Sub Form2_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim atributos As String
        Dim x As Boolean = False

        If ComboBox1.Visible Then
            If txnombre.Text.Trim = String.Empty Then
                MsgBox("Error. Espacios en blanco.")
            Else
                atributos = "VALUES ('" + txnombre.Text.Trim + "')"

                x = True
            End If
        Else
            If txtitulo.Text.Trim = String.Empty Or
                ComboBox1.Text = String.Empty Or
                ComboBox2.Text = String.Empty Or
                MaskedTextBox1.MaskCompleted = False Then

                MsgBox("Error. Espacios en blanco.")
            Else
                atributos = "VALUES ('" + txtitulo.Text.Trim + "', '" +
                            ComboBox1.Text + "', '" +
                            ComboBox2.Text + "', '" +
                            MaskedTextBox1.Text + "')"

                x = True
            End If
        End If

        If x Then
            Dim comando As String

            comando = "Insert into " + Form1.ComboBox1.Text + " " + atributos

            conexion.execute(comando)
            Form1.dgvrefresh()
        End If
    End Sub
End Class