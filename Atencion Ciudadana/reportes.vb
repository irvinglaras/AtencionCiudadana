Imports MySql.Data.MySqlClient
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices

Public Class reportes

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

    Private Sub AdaptaTexto(ByVal boton As Label)
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

    Private Sub reportes_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
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

    Private Sub reportes_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        Me.Invalidate()
    End Sub
    Private Sub reportes_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Me.Invalidate()
    End Sub
    Private Sub reportes_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.Invalidate()
    End Sub

#End Region

    Private Sub reportes_Load(sender As Object, e As EventArgs) Handles Me.Load
        AdaptaBotones(btnClose) : AdaptaTexto(Label3) : AdaptaTexto(Label2) : AdaptaTexto(Label4) : AdaptaTexto(Label5)
        AdaptaTexto(Label7)
        MuestraTotales()
    End Sub
    Private Sub MuestraTotales()
        lblTotal.Text = BuscaTotales(1)
        lblE.Text = BuscaTotales(3)
        lblNA.Text = BuscaTotales(2)
        lblF.Text = BuscaTotales(4)
        lblC.Text = BuscaTotales(5)
    End Sub

    Private Sub pctClose_Click(sender As Object, e As EventArgs) Handles pctClose.Click
        Me.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function BuscaTotales(ByVal nOpcion As Byte) As Integer
        Try
            Dim sSQl As String

            Select Case nOpcion
                Case 1
                    sSQl = "select count(folio) as total from peticiones "
                Case 2
                    sSQl = "select count(folio) as total from peticiones where estatus='NO ATENDIDO'"
                Case 3
                    sSQl = "select count(folio) as total from peticiones where estatus='EN TRAMITE'"
                Case 4
                    sSQl = "select count(folio) as total from peticiones where estatus='FINALIZADO'"
                Case 5
                    sSQl = "select count(folio) as total from peticiones where estatus='CANCELADO'"
            End Select


            Dim table As New DataTable()
            Dim adapter As New MySqlDataAdapter(sSQl, connection)
            adapter.Fill(table)

            If table.Rows.Count > 0 Then
                For Each dRow In table.Rows
                    Return dRow("total")
                Next
            End If
            Return ""
        Catch ex As Exception
            Return ""
            MessageBox.Show(ex.Message)

        End Try
    End Function
End Class