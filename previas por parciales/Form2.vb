Imports System.Data.SqlClient

Public Class Form2
    Dim conexion As New Class1

    Private Sub Form2_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        cbautor.Items.Clear()
        cbeditorial.Items.Clear()

        Dim comando As String = "select nombre from autor"

        conexion.addcbautor(comando)

        comando = "select nombre from editorial"

        conexion.addcbeditorial(comando)
    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim atributos As String
        Dim x As Boolean = False

        If GroupBox1.Visible Then
            If txnombre.Text.Trim = String.Empty Then
                MsgBox("Error. Espacios en blanco.")
            Else
                atributos = "VALUES ('" + txnombre.Text.Trim + "')"

                x = True
            End If
        Else
            If txtitulo.Text.Trim = String.Empty Or
                cbautor.Text = String.Empty Or
                cbeditorial.Text = String.Empty Or
                MaskedTextBox1.MaskCompleted = False Then

                MsgBox("Error. Espacios en blanco.")
            Else
                atributos = "VALUES ('" + txtitulo.Text.Trim + "', '" +
                            cbautor.Text + "', '" +
                            cbeditorial.Text + "', '" +
                            MaskedTextBox1.Text + "')"

                x = True
            End If
        End If

        If x Then
            Dim comando As String

            comando = "Insert into " + Form1.ComboBox1.Text + " " + atributos

            conexion.execute(comando)
            Form1.Enabled = True
            Form1.dgvrefresh()
            Me.Hide()
        End If
    End Sub
End Class