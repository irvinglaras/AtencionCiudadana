Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Runtime.InteropServices

Public Class departamentos


    Private borderRadius As Integer = 20
    Private borderSize As Integer = 2
    Private borderColor As Color = Color.Black

    Private cUt As New Utilerias
    Private connection As New MySqlConnection("Server=" & sServer & ";port=3306; User id=" & sUs & "; Password='" & sCadena & "';Database=" & sDataBase & "; sslmode=none")
    'Private connection As New MySqlConnection("Server=" & sServer & ";User id=" & sUs & ";Password='" & sCadena & "';Database=" & sDataBase & "; sslmode=none")

#Region "AdaptaBotones y formulario redondo"
    Private Sub AdaptaBotones(ByVal boton As Button)
        Dim ellipsedRadius As New Drawing2D.GraphicsPath
        ellipsedRadius.StartFigure()
        ellipsedRadius.AddArc(New Rectangle(0, 0, 10, 10), 180, 90)
        ellipsedRadius.AddLine(10, 0, boton.Width - 20, 0)
        ellipsedRadius.AddArc(New Rectangle(boton.Width - 10, 0, 10, 10), -90, 90)
        ellipsedRadius.AddLine(boton.Width, 20, boton.Width, boton.Height - 10)
        ellipsedRadius.AddArc(New Rectangle(boton.Width - 10, boton.Height - 10, 10, 10), 0, 90)
        ellipsedRadius.AddLine(boton.Width - 10, boton.Height, 20, boton.Height)
        ellipsedRadius.AddArc(New Rectangle(0, boton.Height - 10, 10, 10), 90, 90)
        ellipsedRadius.CloseFigure()
        boton.Region = New Region(ellipsedRadius)
    End Sub

    'Constructor
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Padding = New Padding(borderSize)
        Me.PanelTitleBar.BackColor = borderColor
        'Me.BackColor = borderColor
    End Sub

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private Sub panelTitleBar_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112, &HF012, 0)
    End Sub

    Private Function GetRoundedPath(rect As Rectangle, radius As Single) As GraphicsPath
        Dim path As GraphicsPath = New GraphicsPath()
        Dim curveSize As Single = radius * 2.0F
        path.StartFigure()
        path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90)
        path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90)
        path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90)
        path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Private Sub FormRegionAndBorder(form As Form, radius As Single, graph As Graphics, borderColor As Color, borderSize As Single)
        If Me.WindowState <> FormWindowState.Minimized Then
            Using roundPath As GraphicsPath = GetRoundedPath(form.ClientRectangle, radius)
                Using penBorder As Pen = New Pen(borderColor, borderSize)
                    Using transform As Matrix = New Matrix()
                        graph.SmoothingMode = SmoothingMode.AntiAlias
                        form.Region = New Region(roundPath)
                        If borderSize >= 1 Then
                            Dim rect As Rectangle = form.ClientRectangle
                            Dim scaleX As Single = 1.0F - ((borderSize + 1) / rect.Width)
                            Dim scaleY As Single = 1.0F - ((borderSize + 1) / rect.Height)
                            transform.Scale(scaleX, scaleY)
                            transform.Translate(borderSize / 1.6F, borderSize / 1.6F)
                            graph.Transform = transform
                            graph.DrawPath(penBorder, roundPath)
                        End If
                    End Using
                End Using
            End Using
        End If
    End Sub

    Private Sub ControlRegionAndBorder(control As Control, radius As Single, graph As Graphics, borderColor As Color)
        Using roundPath As GraphicsPath = GetRoundedPath(control.ClientRectangle, radius)
            Using penBorder As Pen = New Pen(borderColor, 1)
                graph.SmoothingMode = SmoothingMode.AntiAlias
                control.Region = New Region(roundPath)
                graph.DrawPath(penBorder, roundPath)
            End Using
        End Using
    End Sub

    Private Sub DrawPath(rectForm As Rectangle, graphics As Graphics, color As Color)
        Using roundPath As GraphicsPath = GetRoundedPath(rectForm, borderRadius)
            Using penBorder As Pen = New Pen(color, 3)
                graphics.DrawPath(penBorder, roundPath)
            End Using
        End Using
    End Sub

    Private Structure FormBoundsColors
        Public TopLeftColor As Color
        Public TopRightColor As Color
        Public BottomLeftColor As Color
        Public BottomRightColor As Color
    End Structure

    Private Function GetFormBoundsColors() As FormBoundsColors
        Dim fbColor = New FormBoundsColors()
        Using bmp = New Bitmap(1, 1)
            Using graph As Graphics = Graphics.FromImage(bmp)
                Dim rectBmp As New Rectangle(0, 0, 1, 1)
                'Top Left
                rectBmp.X = Me.Bounds.X - 1
                rectBmp.Y = Me.Bounds.Y
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size)
                fbColor.TopLeftColor = bmp.GetPixel(0, 0)
                'Top Right
                rectBmp.X = Me.Bounds.Right
                rectBmp.Y = Me.Bounds.Y
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size)
                fbColor.TopRightColor = bmp.GetPixel(0, 0)
                'Bottom Left
                rectBmp.X = Me.Bounds.X
                rectBmp.Y = Me.Bounds.Bottom
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size)
                fbColor.BottomLeftColor = bmp.GetPixel(0, 0)
                'Bottom Right
                rectBmp.X = Me.Bounds.Right
                rectBmp.Y = Me.Bounds.Bottom
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size)
                fbColor.BottomRightColor = bmp.GetPixel(0, 0)
            End Using
        End Using
        Return fbColor
    End Function

    Private Sub departamentos_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        '-> Smooth Outer Border
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rectForm As Rectangle = Me.ClientRectangle
        Dim mWidht As Integer = rectForm.Width / 2
        Dim mHeight As Integer = rectForm.Height / 2
        Dim fbColor = GetFormBoundsColors()

        'Top Left
        DrawPath(rectForm, e.Graphics, fbColor.TopLeftColor)

        'Top Right
        Dim rectTopRight As New Rectangle(rectForm.Right - mWidht, rectForm.Y, mWidht, mHeight)
        DrawPath(rectTopRight, e.Graphics, fbColor.TopRightColor)

        'Bottom Left
        Dim rectBottomLeft As New Rectangle(rectForm.X, rectForm.Bottom - mHeight, mWidht, mHeight)
        DrawPath(rectBottomLeft, e.Graphics, fbColor.BottomLeftColor)

        'Bottom Right
        Dim rectBottomRight As New Rectangle(rectForm.Right - mWidht, rectForm.Bottom - mHeight, mWidht, mHeight)
        DrawPath(rectBottomRight, e.Graphics, fbColor.BottomRightColor)

        '-> Set Rounded Region and Border
        FormRegionAndBorder(Me, borderRadius, e.Graphics, borderColor, borderSize)
    End Sub

    Private Sub PanelContainer_Paint(sender As Object, e As PaintEventArgs) Handles PanelContainer.Paint
        ControlRegionAndBorder(PanelContainer, borderRadius - (borderSize / 2.0F), e.Graphics, borderColor)
    End Sub

    Private Sub departamentos_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        Me.Invalidate()
    End Sub
    Private Sub departamentos_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Me.Invalidate()
    End Sub
    Private Sub departamentos_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.Invalidate()
    End Sub

#End Region

    Private Sub departamentos_Load(sender As Object, e As EventArgs) Handles Me.Load
        AdaptaBotones(btnNuevo) : AdaptaBotones(btnGuardar) : AdaptaBotones(btnEliminar) : AdaptaBotones(btnCancelar) : AdaptaBotones(btnClose)
        CargaDatos(1)
    End Sub

    Private Sub CargaDatos(ByVal nOpcion As Byte)
        Try
            Dim sSQL As String
            If nOpcion = 1 Then
                sSQL = "SELECT areaid as Folio, area as Departamento, Responsable FROM areas "
            Else
                sSQL = "SELECT areaid as Folio, area as Departamento, Responsable FROM areas WHERE area like '%" & txtBuscar.Text & "%' order by areaid "
            End If

            cUt.LlenaGrid(sSQL, dtgvD)
            FormateaGrid()
            lblTotal.Text = dtgvD.Rows.Count.ToString + " encontrados"
            If dtgvD.Rows.Count > 0 Then
                MuestraDatos()
            End If
            HabilitaBotones()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FormateaGrid()
        With dtgvD.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Black
            .Font = New Font("Century Gothic", 9, FontStyle.Bold)
            .ForeColor = Color.White
        End With

        dtgvD.DefaultCellStyle.BackColor = Color.White
        dtgvD.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)

        dtgvD.Columns.Item(0).Width = 70
        dtgvD.Columns.Item(1).Width = 350
        dtgvD.Columns.Item(2).Width = 300

        'dtgvP.Columns(3).DefaultCellStyle.Format = "dd/MM/yyyy"

        dtgvD.Columns.Item(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dtgvD.Columns.Item(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dtgvD.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

    End Sub


    Private Sub MuestraDatos()
        Try
            Dim sSQL As String
            sSQL = "SELECT * FROM areas WHERE areaid='" & Me.dtgvD.Rows(Me.dtgvD.CurrentRow.Index).Cells(0).Value.ToString & "'"
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter(sSQL, connection)
            adapter.Fill(table)

            If table.Rows.Count > 0 Then
                For Each dRow In table.Rows

                    txtFolio.Text = dRow("areaid")
                    txtDepartamento.Text = dRow("area")
                    txtResponsable.Text = dRow("responsable")

                    txtExt.Text = dRow("ext")
                    txtUsuario.Text = dRow("usuario")
                    txtClave.Text = dRow("pass")

                Next
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub HabilitaBotones()
        If dtgvD.Rows.Count > 0 Then
            btnNuevo.Enabled = True : btnGuardar.Enabled = True : btnEliminar.Enabled = True
            txtFolio.ReadOnly = True
        Else
            btnNuevo.Enabled = True : btnGuardar.Enabled = False : btnEliminar.Enabled = False
            txtFolio.Enabled = True
        End If
    End Sub




    'Private Sub CargaTransportistas()
    '    Try
    '        Dim sSQL As String
    '        sSQL = "select * from choferes order by cvecho"
    '        Dim table As New DataTable()
    '        Dim adapter As New MySqlDataAdapter(sSQL, connection)
    '        adapter.Fill(table)

    '        If table.Rows.Count > 0 Then
    '            cboTrasnportista.DataSource = Nothing
    '            cboTrasnportista.Items.Clear()
    '            With cboTrasnportista
    '                .DataSource = table
    '                .DisplayMember = "transportista"
    '                .ValueMember = "cvetra"
    '            End With
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Private Sub dtgvD_KeyUp(sender As Object, e As KeyEventArgs) Handles dtgvD.KeyUp
        If dtgvD.Rows.Count > 0 Then
            MuestraDatos()
        End If
    End Sub

    Private Sub dtgvD_MouseUp(sender As Object, e As MouseEventArgs) Handles dtgvD.MouseUp
        If dtgvD.Rows.Count > 0 Then
            MuestraDatos()
        End If
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                CargaDatos(2)
        End Select
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        dtgvD.Enabled = False
        btnNuevo.Enabled = False : btnGuardar.Enabled = True : btnEliminar.Enabled = False
        txtFolio.Clear()
        txtDepartamento.Clear() : txtResponsable.Clear() : txtExt.Clear() :
        txtUsuario.Clear() : txtClave.Clear()

        txtFolio.Text = BuscaUltimoU("areas", "areaid")
        txtDepartamento.Focus()
    End Sub

    Private Function BuscaUltimo(ByVal sNombretabla As String, ByVal sNombreCampo As String) As Long
        Dim sSQL As String
        Dim nMaximo As Long
        sSQL = "SELECT IFNULL(MAX(" & sNombreCampo & "),0) As Tot FROM " & sNombretabla & ""
        nMaximo = cUt.MaxValue(sSQL)
        Return nMaximo
    End Function


    Private Function BuscaUltimoU(ByVal sNombretabla As String, ByVal sNombreCampo As String) As String
        Dim sSQL As String
        Dim nMaximo As Long
        Dim sMaximo As String = ""
        sSQL = "SELECT COALESCE(CAST(MAX(" & sNombreCampo & ") AS INT),0) As Tot FROM " & sNombretabla & ""
        nMaximo = cUt.MaxValue(sSQL)
        Select Case nMaximo.ToString.Length
            Case 1
                sMaximo = "0" + nMaximo.ToString
            Case 2
                sMaximo = nMaximo.ToString
        End Select

        Return sMaximo

    End Function


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim sSQL As String = ""
            If txtFolio.Text.Length = 0 Then
                MessageBox.Show("La clave del departamento no puede quedar vacia", My.Settings.sMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtFolio.Focus()
                Exit Sub
            End If
            If txtDepartamento.Text.Length = 0 Then
                MessageBox.Show("El nombre del departamento no puede quedar vacio", My.Settings.sMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDepartamento.Focus()
                Exit Sub
            End If
            If txtResponsable.Text.Length = 0 Then
                MessageBox.Show("El nombre del responsable no puede quedar vacio", My.Settings.sMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtResponsable.Focus()
                Exit Sub
            End If
            If txtExt.Text.Length = 0 Then
                MessageBox.Show("El numero de extensión no puede quedar vacio", My.Settings.sMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtExt.Focus()
                Exit Sub
            End If
            If txtUsuario.Text.Length = 0 Then
                MessageBox.Show("El nombre del usuario no puede quedar vacio", My.Settings.sMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtUsuario.Focus()
                Exit Sub
            End If
            If txtClave.Text.Length = 0 Then
                MessageBox.Show("La clave de acceso del usuario no puede quedar vacio", My.Settings.sMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtClave.Focus()
                Exit Sub
            End If

            'Dim nconsecutivo As Integer = BuscaUltimo("user", "userid")
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            cmd.Connection = con
            If btnNuevo.Enabled Then
                sSQL = "update areas set area=@area, responsable=@responsable, ext=@ext, usuario=@usuario, pass=@pass WHERE areaid='" & txtFolio.Text & "'"
            Else
                sSQL = "insert into areas (areaid, area, responsable, ext, usuario, pass) values (@areaid, @area, @responsable, @ext, @usuario, @pass)"
                cmd.Parameters.AddWithValue("@areaid", txtFolio.Text)
            End If

            cmd.CommandText = sSQL

            cmd.Parameters.AddWithValue("@area", txtDepartamento.Text)
            cmd.Parameters.AddWithValue("@responsable", txtResponsable.Text)
            cmd.Parameters.AddWithValue("@ext", txtExt.Text)
            cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text)
            cmd.Parameters.AddWithValue("@pass", txtClave.Text)


            result = cmd.ExecuteNonQuery
            con.Close()

            If result > 0 Then
                MessageBox.Show("Departamento guardado exitosamente....", My.Settings.sMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            dtgvD.Enabled = True
            CargaDatos(1)
            HabilitaBotones()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            cmd.Parameters.Clear()
            cmd.Dispose()
            con.Close()
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            Dim sSQL As String = ""
            Dim nresp As Byte = MessageBox.Show("Estas seguro de eliminar este departamento?", My.Settings.sMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If nresp = 6 Then
                'Dim nconsecutivo As Integer = BuscaUltimo("user", "userid")
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                cmd.Connection = con

                sSQL = "delete from areas WHERE areaid='" & txtFolio.Text & "'"
                cmd.CommandText = sSQL

                result = cmd.ExecuteNonQuery
                con.Close()

                If result > 0 Then
                    MessageBox.Show("Departamento eliminado exitosamente....", My.Settings.sMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                dtgvD.Enabled = True
                CargaDatos(1)
                HabilitaBotones()
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            cmd.Parameters.Clear()
            cmd.Dispose()
            con.Close()
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        CargaDatos(1)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub pctClose_Click(sender As Object, e As EventArgs) Handles pctClose.Click
        Me.Close()
    End Sub
End Class