Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

Public Class loginA

    Private connection As New MySqlConnection("Server=" & sServer & ";port=3306; User id=" & sUs & "; Password='" & sCadena & "';Database=" & sDataBase & "; sslmode=none")

    Private borderRadius As Integer = 30
    Private borderSize As Integer = 2
    Private borderColor As Color = Color.Orange

    Private cUt As New Utilerias
    'Private sConexion As String = cUt.CadenaConexion

    'CONSTRUCTOR
    Public Sub New()
        'Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Padding = New Padding(borderSize)
        Me.PanelTitleBar.BackColor = borderColor
        Me.BackColor = Color.White
    End Sub

#Region "AdaptaBotones"


    'METODO MOVER/ARRASTRAR FORMULARIO
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    Private Sub panelTitleBar_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PanelTitleBar.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112, &HF012, 0)
    End Sub

    'MINIMIZAR FORMULARIO SIN BORDES DESDE LA BARRA DE TAREAS
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.Style = cp.Style Or &H20000 '<--- Minimize borderless form from taskbar
            Return cp
        End Get
    End Property


    'METODOS PRIVADOS
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


    'ESTABLECER REGION Y BORDE REDONDEADO - FORMULARIO
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

    'ESTABLECER REGION Y BORDE REDEONDEADO - PANEL CONTENEDOR
    Private Sub ControlRegionAndBorder(control As Control, radius As Single, graph As Graphics, borderColor As Color)
        Using roundPath As GraphicsPath = GetRoundedPath(control.ClientRectangle, radius)
            Using penBorder As Pen = New Pen(borderColor, 1)
                graph.SmoothingMode = SmoothingMode.AntiAlias
                control.Region = New Region(roundPath)
                graph.DrawPath(penBorder, roundPath)
            End Using
        End Using
    End Sub

    'DIBUJAR RUTAS  - ESQUINA DEL FORMULARIO
    Private Sub DrawPath(rectForm As Rectangle, graphics As Graphics, color As Color)
        Using roundPath As GraphicsPath = GetRoundedPath(rectForm, borderRadius)
            Using penBorder As Pen = New Pen(color, 3)
                graphics.DrawPath(penBorder, roundPath)
            End Using
        End Using
    End Sub

    'OBTENER COLORES DE LOS LIMITES EXTERIORES DEL FORMULARIO
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

    'ESTABLECER REGION REDONDEADO Y DIBUJAR FINO (PANEL CONTENEDOR)
    Private Sub PanelTitleBar_Paint(sender As Object, e As PaintEventArgs) Handles PanelTitleBar.Paint

    End Sub



    'ESTABLECER REGION REDEONDEADO Y DIBUJAR BORDE + SAUVIZADO (FORMULARIO)
    Private Sub loginA_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
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

    Private Sub loginA_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        Me.Invalidate()
    End Sub

    Private Sub loginA_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Me.Invalidate()
    End Sub

    Private Sub loginA_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.Invalidate()
    End Sub

    Private Sub PanelContainer_Paint(sender As Object, e As PaintEventArgs) Handles PanelContainer.Paint

    End Sub

    Private Sub pctClose_Click(sender As Object, e As EventArgs) Handles pctClose.Click
        Application.Exit()
    End Sub



#End Region

    Private Sub loginA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AdaptaBotones(btnIngresar)
    End Sub



    Private Sub txtClave_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClave.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                BuscarUsuario(txtUsuario.Text, txtClave.Text)
        End Select
    End Sub



    Public Shared Function CuentaVacia(ByVal sUsuario As String, ByVal sClave As String) As Boolean
        Try
            If String.IsNullOrEmpty(sUsuario) Or String.IsNullOrWhiteSpace(sUsuario) Or
                String.IsNullOrEmpty(sClave) Or String.IsNullOrWhiteSpace(sClave) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function


    Private Sub Label6_MouseDown(sender As Object, e As MouseEventArgs) Handles Label6.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112, &HF012, 0)
    End Sub

    Private Sub BuscarUsuario(ByVal sUsuario As String, ByVal sClave As String)
        Try
            Dim sSQl As String = "select count(*) as total from areas where usuario='" & txtUsuario.Text & "' and pass='" & txtClave.Text & "'"

            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter(sSQl, connection)
            adapter.Fill(table)

            If table.Rows.Count > 0 Then
                For Each dRow In table.Rows
                    If dRow("total") > 0 Then

                        'MessageBox.Show("Entrando.....listo", My.Settings.sMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        My.Settings.sUser = txtUsuario.Text
                        My.Settings.sAreaID = BuscaAreaID()
                        My.Settings.sTipo = "Areas"
                        Me.Hide()
                        Dim ventana As New principal
                        ventana.ShowDialog()
                    Else
                        MessageBox.Show("La informción proporcionada esta incorrecta, por favor verifiquela", My.Settings.sMsg, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Function BuscaNombreUsuario() As String
        Try
            Dim sSQl As String = "select nombre + ' ' + apellidos AS NombreC from usuarios where usuario='" & txtUsuario.Text & "'"

            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter(sSQl, connection)
            adapter.Fill(table)

            If table.Rows.Count > 0 Then
                For Each dRow In table.Rows
                    Return dRow("NombreC")
                Next
            End If
            Return ""
        Catch ex As Exception
            Return ""
            MessageBox.Show(ex.Message)

        End Try
    End Function

    Private Function BuscaTipoUsuario() As String
        Try
            Dim sSQl As String = "select tipo from usuarios where usuario='" & txtUsuario.Text & "'"

            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter(sSQl, connection)
            adapter.Fill(table)

            If table.Rows.Count > 0 Then
                For Each dRow In table.Rows
                    Return dRow("tipo")
                Next
            End If
            Return ""
        Catch ex As Exception
            Return ""
            MessageBox.Show(ex.Message)

        End Try
    End Function

    Private Function BuscaAreaID() As String
        Try
            Dim sSQl As String = "select areaID from areas where usuario='" & txtUsuario.Text & "'"

            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter(sSQl, connection)
            adapter.Fill(table)

            If table.Rows.Count > 0 Then
                For Each dRow In table.Rows
                    Return dRow("areaid")
                Next
            End If
            Return "00"
        Catch ex As Exception
            Return "00"
            MessageBox.Show(ex.Message)

        End Try
    End Function

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        BuscarUsuario(txtUsuario.Text, txtClave.Text)
    End Sub

End Class