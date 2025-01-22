Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

Public Class peticiones

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

    Private Sub peticiones_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
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

    Private Sub peticiones_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        Me.Invalidate()
    End Sub
    Private Sub peticiones_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Me.Invalidate()
    End Sub
    Private Sub peticiones_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.Invalidate()
    End Sub

#End Region

    Private Sub peticiones_Load(sender As Object, e As EventArgs) Handles Me.Load
        AdaptaBotones(btnNuevo) : AdaptaBotones(btnGuardar) : AdaptaBotones(btnEliminar) : AdaptaBotones(btnCancelar) : AdaptaBotones(btnClose)
        ''Ut.CargaCombo("areas", "areaid", "area", cboarea, 1, "")
        CargaAreas()
        CargaDatos(1)
    End Sub

    Private Sub CargaAreas()
        Try
            Dim sSQL As String
            sSQL = "select areaid, area from areas  "
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter(sSQL, connection)
            adapter.Fill(table)

            If table.Rows.Count > 0 Then
                cboarea.DataSource = Nothing
                cboarea.Items.Clear()
                With cboarea
                    .DataSource = table
                    .DisplayMember = "area"
                    .ValueMember = "areaid"
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CargaDatos(ByVal nOpcion As Byte)
        Try
            Dim sSQL As String = ""
            If nOpcion = 1 Then
                sSQL = "SELECT p.Folio, p.Nombre, p.Peticion, p.Telefono, p.estatus, a.area, p.fecha as FechaInicio FROM peticiones as p inner join areas as a on a.areaid=p.areaid ORDER BY folio DESC"
            Else
                ' sSQL = "SELECT p.Folio, p.Nombre, p.Peticion, p.Telefono, p.estatus, a.area, p.fecha as [Fecha Inicio], p.fechatermino as [Fecha Termino] FROM peticiones as p inner join areas as a on a.areaid=p.areaid WHERE peticion like '%" & txtBuscar.Text & "%' order by areaid "
            End If

            cUt.LlenaGrid(sSQL, dtgvD)
            FormateaGrid()
            lblTotal.Text = dtgvD.Rows.Count.ToString + " peticiones encontradas"
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
            .Font = New Font("Century Gothic", 8, FontStyle.Bold)
            .ForeColor = Color.White
        End With

        dtgvD.DefaultCellStyle.BackColor = Color.White
        dtgvD.DefaultCellStyle.Font = New Font("Century Gothic", 8, FontStyle.Regular)

        dtgvD.Columns.Item(0).Width = 70
        dtgvD.Columns.Item(1).Width = 350
        dtgvD.Columns.Item(2).Width = 600
        dtgvD.Columns.Item(3).Width = 100
        dtgvD.Columns.Item(4).Width = 200
        dtgvD.Columns.Item(5).Width = 300
        dtgvD.Columns.Item(6).Width = 120
        ' dtgvD.Columns.Item(7).Width = 120




        'dtgvP.Columns(3).DefaultCellStyle.Format = "dd/MM/yyyy"

        dtgvD.Columns.Item(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dtgvD.Columns.Item(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dtgvD.Columns.Item(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dtgvD.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dtgvD.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dtgvD.Columns.Item(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        'dtgvD.Columns.Item(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft


    End Sub


    Private Sub MuestraDatos()
        Try
            Dim sSQL As String
            sSQL = "SELECT * FROM peticiones WHERE folio=" & Me.dtgvD.Rows(Me.dtgvD.CurrentRow.Index).Cells(0).Value.ToString & ""
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter(sSQL, connection)
            adapter.Fill(table)

            If table.Rows.Count > 0 Then
                For Each dRow In table.Rows

                    txtFolio.Text = dRow("folio")
                    txtPeticion.Text = dRow("peticion")
                    txtSolicitante.Text = dRow("nombre")

                    mskTelefono.Text = dRow("telefono")
                    txtCorreo.Text = dRow("correo")
                    cboarea.SelectedValue = dRow("areaid")
                    txtResponsable.Text = GetResponsable()
                    cboEstatus.Text = dRow("estatus")
                    mskFI.Text = dRow("fecha")
                    mskFT.Text = dRow("fechatermino")
                    txtObservaciones.Text = dRow("observaciones")


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

    'Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
    '    Select Case e.KeyCode
    '        Case Keys.Enter
    '            CargaDatos(2)
    '    End Select
    'End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        dtgvD.Enabled = False
        btnNuevo.Enabled = False : btnGuardar.Enabled = True : btnEliminar.Enabled = False
        txtFolio.Clear()
        txtSolicitante.Clear() : txtPeticion.Clear() : mskTelefono.Clear() : txtCorreo.Clear() : cboarea.SelectedIndex = 0
        cboEstatus.SelectedIndex = 0 : mskFI.Text = Format(Now.Date, "dd/MM/yyyy") : mskFT.Clear()
        txtObservaciones.Text = "-"

        txtFolio.Text = BuscaUltimo("peticiones", "folio")
        txtSolicitante.Focus()
    End Sub

    Private Function BuscaUltimo(ByVal sNombretabla As String, ByVal sNombreCampo As String) As Long
        Dim sSQL As String
        Dim nMaximo As Long
        sSQL = "SELECT IFNULL(MAX(" & sNombreCampo & "),0) As Tot FROM " & sNombretabla & ""
        nMaximo = cUt.MaxValue(sSQL)
        Return nMaximo
    End Function


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim sSQL As String = ""
            If txtFolio.Text.Length = 0 Then
                MessageBox.Show("El folio de la petición no puede quedar vacia", My.Settings.sMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtFolio.Focus()
                Exit Sub
            End If
            If txtPeticion.Text.Length = 0 Then
                MessageBox.Show("La petición no puede quedar vacia", My.Settings.sMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtPeticion.Focus()
                Exit Sub
            End If
            If txtSolicitante.Text.Length = 0 Then
                MessageBox.Show("El nombre del solicitante no puede quedar vacio", My.Settings.sMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtSolicitante.Focus()
                Exit Sub
            End If
            If txtObservaciones.Text.Length = 0 Then
                txtObservaciones.Text = "-"
            End If
            If txtCorreo.Text.Length = 0 Then
                txtCorreo.Text = "-"
            End If


            'Dim nconsecutivo As Integer = BuscaUltimo("user", "userid")
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            cmd.Connection = con
            If btnNuevo.Enabled Then
                sSQL = "update peticiones set nombre=@nombre, peticion=@peticion, telefono=@telefono, correo=@correo, areaid=@areaid, estatus=@estatus, fecha=@fecha, fechatermino=@fechatermino, observaciones=@observaciones WHERE folio=" & txtFolio.Text & ""
            Else
                sSQL = "insert into peticiones (folio, nombre, peticion, telefono, correo, areaid, estatus, fecha, fechatermino, observaciones) values (@folio, @nombre, @peticion, @telefono, @correo, @areaid, @estatus, @fecha, @fechatermino, @observaciones)"
                cmd.Parameters.AddWithValue("@folio", txtFolio.Text)
            End If

            cmd.CommandText = sSQL

            cmd.Parameters.AddWithValue("@nombre", txtSolicitante.Text)
            cmd.Parameters.AddWithValue("@peticion", txtPeticion.Text)
            cmd.Parameters.AddWithValue("@telefono", mskTelefono.Text)
            cmd.Parameters.AddWithValue("@correo", txtCorreo.Text)
            cmd.Parameters.AddWithValue("@areaid", cboarea.SelectedValue)
            cmd.Parameters.AddWithValue("@estatus", cboEstatus.Text)
            cmd.Parameters.AddWithValue("@fecha", mskFI.Text)
            cmd.Parameters.AddWithValue("@fechatermino", mskFT.Text)
            cmd.Parameters.AddWithValue("@observaciones", txtObservaciones.Text)

            result = cmd.ExecuteNonQuery
            con.Close()

            If result > 0 Then
                MessageBox.Show("Petición guardado exitosamente....", My.Settings.sMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            Dim nresp As Byte = MessageBox.Show("Estas seguro de eliminar esta peticion?", My.Settings.sMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If nresp = 6 Then
                'Dim nconsecutivo As Integer = BuscaUltimo("user", "userid")
                If con.State = ConnectionState.Closed Then
                    con.Open()
                End If
                cmd.Connection = con

                sSQL = "update peticiones set estatus='CANCELADO' WHERE folio=" & txtFolio.Text & ""
                cmd.CommandText = sSQL

                result = cmd.ExecuteNonQuery
                con.Close()

                If result > 0 Then
                    MessageBox.Show("Perición cancelada exitosamente....", My.Settings.sMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        dtgvD.Enabled = True

        CargaDatos(1)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub pctClose_Click(sender As Object, e As EventArgs) Handles pctClose.Click
        Me.Close()
    End Sub

    Private Sub cboarea_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboarea.SelectedValueChanged
        Try
            txtResponsable.Text = GetResponsable()
        Catch ex As Exception

        End Try
    End Sub

    Private Function GetResponsable() As String
        Try

            Dim sSQL As String
            Dim sResponsable As String = ""

            sSQL = "SELECT responsable FROM areas WHERE areaid='" & cboarea.SelectedValue & "'"
            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter(sSQL, connection)
            adapter.Fill(table)

            If table.Rows.Count > 0 Then

                For Each dRow In table.Rows
                    sResponsable = dRow("responsable")
                Next
                Return sResponsable
            Else
                Return ""
            End If
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
            Return ""
        End Try
    End Function
End Class