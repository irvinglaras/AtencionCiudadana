<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class principal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(principal))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pctReportes = New System.Windows.Forms.PictureBox()
        Me.pctPeticiones = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pctDepartaentos = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.pctReportes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctPeticiones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.pctDepartaentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 564)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1179, 26)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1179, 564)
        Me.Panel2.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.PictureBox1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(178, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(801, 564)
        Me.Panel5.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(6, 107)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(789, 295)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.pctReportes)
        Me.Panel4.Controls.Add(Me.pctPeticiones)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(979, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(200, 564)
        Me.Panel4.TabIndex = 1
        '
        'pctReportes
        '
        Me.pctReportes.Image = CType(resources.GetObject("pctReportes.Image"), System.Drawing.Image)
        Me.pctReportes.Location = New System.Drawing.Point(35, 153)
        Me.pctReportes.Name = "pctReportes"
        Me.pctReportes.Size = New System.Drawing.Size(143, 109)
        Me.pctReportes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctReportes.TabIndex = 2
        Me.pctReportes.TabStop = False
        '
        'pctPeticiones
        '
        Me.pctPeticiones.Image = CType(resources.GetObject("pctPeticiones.Image"), System.Drawing.Image)
        Me.pctPeticiones.Location = New System.Drawing.Point(35, 27)
        Me.pctPeticiones.Name = "pctPeticiones"
        Me.pctPeticiones.Size = New System.Drawing.Size(143, 109)
        Me.pctPeticiones.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctPeticiones.TabIndex = 1
        Me.pctPeticiones.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.pctDepartaentos)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(178, 564)
        Me.Panel3.TabIndex = 0
        '
        'pctDepartaentos
        '
        Me.pctDepartaentos.Image = CType(resources.GetObject("pctDepartaentos.Image"), System.Drawing.Image)
        Me.pctDepartaentos.Location = New System.Drawing.Point(11, 27)
        Me.pctDepartaentos.Name = "pctDepartaentos"
        Me.pctDepartaentos.Size = New System.Drawing.Size(143, 109)
        Me.pctDepartaentos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctDepartaentos.TabIndex = 0
        Me.pctDepartaentos.TabStop = False
        '
        'principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1179, 590)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "principal"
        Me.Text = "Sistema de Atención Ciudadana"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.pctReportes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctPeticiones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.pctDepartaentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pctDepartaentos As PictureBox
    Friend WithEvents pctPeticiones As PictureBox
    Friend WithEvents pctReportes As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
