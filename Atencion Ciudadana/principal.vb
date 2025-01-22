Public Class principal
    Private Sub PictureBox1_MouseEnter(sender As Object, e As EventArgs) Handles pctDepartaentos.MouseEnter
        Me.pctDepartaentos.Height += 20
        Me.pctDepartaentos.Width += 20
    End Sub

    Private Sub pctPeticiones_MouseEnter(sender As Object, e As EventArgs) Handles pctPeticiones.MouseEnter
        Me.pctPeticiones.Height += 20
        Me.pctpeticiones.Width += 20
    End Sub

    Private Sub pctReportes_MouseEnter(sender As Object, e As EventArgs) Handles pctReportes.MouseEnter
        Me.pctReportes.Height += 20
        Me.pctReportes.Width += 20
    End Sub

    Private Sub pctDepartaentos_MouseLeave(sender As Object, e As EventArgs) Handles pctDepartaentos.MouseLeave
        Me.pctDepartaentos.Height -= 20
        Me.pctDepartaentos.Width -= 20
    End Sub

    Private Sub pctPeticiones_MouseLeave(sender As Object, e As EventArgs) Handles pctPeticiones.MouseLeave
        Me.pctPeticiones.Height -= 20
        Me.pctPeticiones.Width -= 20
    End Sub

    Private Sub pctReportes_MouseLeave(sender As Object, e As EventArgs) Handles pctReportes.MouseLeave
        Me.pctReportes.Height -= 20
        Me.pctReportes.Width -= 20
    End Sub

    Private Sub principal_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        'Application.Exit()
    End Sub

    Private Sub pctDepartaentos_DoubleClick(sender As Object, e As EventArgs) Handles pctDepartaentos.DoubleClick
        If My.Settings.sTipo = "Administrador" Then
            Dim ventana As New departamentos
            ventana.ShowDialog()
        Else
            MessageBox.Show("Lo siento no tiene permiso para entrar a este modulo", My.Settings.sMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub principal_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

    End Sub

    Private Sub principal_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Application.Exit()
    End Sub

    Private Sub pctPeticiones_DoubleClick(sender As Object, e As EventArgs) Handles pctPeticiones.DoubleClick
        If My.Settings.sTipo = "Administrador" Then
            Dim ventana As New peticiones
            ventana.ShowDialog()
        Else
            Dim ventana As New peticionesarea
            ventana.ShowDialog()
        End If
    End Sub

    Private Sub principal_Load(sender As Object, e As EventArgs) Handles Me.Load
        PictureBox1.Location = New Point((Panel5.Width / 2) - (PictureBox1.Width / 2), (Panel5.Height / 2) - (PictureBox1.Height / 2))
    End Sub

    Private Sub principal_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        PictureBox1.Location = New Point((Panel5.Width / 2) - (PictureBox1.Width / 2), (Panel5.Height / 2) - (PictureBox1.Height / 2))
    End Sub

    Private Sub pctReportes_DoubleClick(sender As Object, e As EventArgs) Handles pctReportes.DoubleClick
        If My.Settings.sTipo = "Administrador" Then
            Dim ventana As New reportes
            ventana.ShowDialog()
        Else
            MessageBox.Show("Lo siento no tiene permiso para entrar a este modulo", My.Settings.sMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class