﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class peticionesarea
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(peticionesarea))
        Me.PanelContainer = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.mskFT = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.mskFI = New System.Windows.Forms.MaskedTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboEstatus = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboarea = New System.Windows.Forms.ComboBox()
        Me.mskTelefono = New System.Windows.Forms.MaskedTextBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.txtResponsable = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPeticion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSolicitante = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtgvD = New System.Windows.Forms.DataGridView()
        Me.PanelTitleBar = New System.Windows.Forms.Panel()
        Me.pctClose = New System.Windows.Forms.PictureBox()
        Me.lblArea = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblNA = New System.Windows.Forms.Label()
        Me.lblE = New System.Windows.Forms.Label()
        Me.lblF = New System.Windows.Forms.Label()
        Me.lblC = New System.Windows.Forms.Label()
        Me.PanelContainer.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgvD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTitleBar.SuspendLayout()
        CType(Me.pctClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelContainer
        '
        Me.PanelContainer.BackColor = System.Drawing.Color.White
        Me.PanelContainer.Controls.Add(Me.lblC)
        Me.PanelContainer.Controls.Add(Me.lblF)
        Me.PanelContainer.Controls.Add(Me.lblE)
        Me.PanelContainer.Controls.Add(Me.lblNA)
        Me.PanelContainer.Controls.Add(Me.Label15)
        Me.PanelContainer.Controls.Add(Me.Label14)
        Me.PanelContainer.Controls.Add(Me.Label13)
        Me.PanelContainer.Controls.Add(Me.Label6)
        Me.PanelContainer.Controls.Add(Me.Label12)
        Me.PanelContainer.Controls.Add(Me.txtObservaciones)
        Me.PanelContainer.Controls.Add(Me.PictureBox1)
        Me.PanelContainer.Controls.Add(Me.mskFT)
        Me.PanelContainer.Controls.Add(Me.Label11)
        Me.PanelContainer.Controls.Add(Me.mskFI)
        Me.PanelContainer.Controls.Add(Me.Label10)
        Me.PanelContainer.Controls.Add(Me.Label1)
        Me.PanelContainer.Controls.Add(Me.cboEstatus)
        Me.PanelContainer.Controls.Add(Me.Label9)
        Me.PanelContainer.Controls.Add(Me.cboarea)
        Me.PanelContainer.Controls.Add(Me.mskTelefono)
        Me.PanelContainer.Controls.Add(Me.lblTotal)
        Me.PanelContainer.Controls.Add(Me.btnClose)
        Me.PanelContainer.Controls.Add(Me.btnCancelar)
        Me.PanelContainer.Controls.Add(Me.btnEliminar)
        Me.PanelContainer.Controls.Add(Me.btnGuardar)
        Me.PanelContainer.Controls.Add(Me.btnNuevo)
        Me.PanelContainer.Controls.Add(Me.txtResponsable)
        Me.PanelContainer.Controls.Add(Me.Label8)
        Me.PanelContainer.Controls.Add(Me.txtPeticion)
        Me.PanelContainer.Controls.Add(Me.Label7)
        Me.PanelContainer.Controls.Add(Me.txtCorreo)
        Me.PanelContainer.Controls.Add(Me.Label5)
        Me.PanelContainer.Controls.Add(Me.Label4)
        Me.PanelContainer.Controls.Add(Me.txtSolicitante)
        Me.PanelContainer.Controls.Add(Me.Label3)
        Me.PanelContainer.Controls.Add(Me.txtFolio)
        Me.PanelContainer.Controls.Add(Me.Label2)
        Me.PanelContainer.Controls.Add(Me.dtgvD)
        Me.PanelContainer.Controls.Add(Me.PanelTitleBar)
        Me.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelContainer.Location = New System.Drawing.Point(0, 0)
        Me.PanelContainer.Name = "PanelContainer"
        Me.PanelContainer.Size = New System.Drawing.Size(637, 643)
        Me.PanelContainer.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 532)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(82, 13)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Observaciones"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.ForeColor = System.Drawing.Color.Navy
        Me.txtObservaciones.Location = New System.Drawing.Point(7, 552)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(614, 46)
        Me.txtObservaciones.TabIndex = 10
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(589, 494)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 31
        Me.PictureBox1.TabStop = False
        '
        'mskFT
        '
        Me.mskFT.Location = New System.Drawing.Point(91, 504)
        Me.mskFT.Mask = "00/00/0000"
        Me.mskFT.Name = "mskFT"
        Me.mskFT.Size = New System.Drawing.Size(78, 20)
        Me.mskFT.TabIndex = 9
        Me.mskFT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mskFT.ValidatingType = GetType(Date)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(86, 488)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Fecha termino"
        '
        'mskFI
        '
        Me.mskFI.Location = New System.Drawing.Point(7, 504)
        Me.mskFI.Mask = "00/00/0000"
        Me.mskFI.Name = "mskFI"
        Me.mskFI.ReadOnly = True
        Me.mskFI.Size = New System.Drawing.Size(78, 20)
        Me.mskFI.TabIndex = 8
        Me.mskFI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.mskFI.ValidatingType = GetType(Date)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(2, 488)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Fecha solicitud"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(478, 442)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Estatus"
        '
        'cboEstatus
        '
        Me.cboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstatus.FormattingEnabled = True
        Me.cboEstatus.Items.AddRange(New Object() {"NO ATENDIDO", "EN TRAMITE", "FINALIZADO", "CANCELADO"})
        Me.cboEstatus.Location = New System.Drawing.Point(481, 458)
        Me.cboEstatus.Name = "cboEstatus"
        Me.cboEstatus.Size = New System.Drawing.Size(140, 21)
        Me.cboEstatus.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(233, 442)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Responsable"
        '
        'cboarea
        '
        Me.cboarea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboarea.FormattingEnabled = True
        Me.cboarea.Location = New System.Drawing.Point(7, 459)
        Me.cboarea.Name = "cboarea"
        Me.cboarea.Size = New System.Drawing.Size(223, 21)
        Me.cboarea.TabIndex = 6
        '
        'mskTelefono
        '
        Me.mskTelefono.Location = New System.Drawing.Point(339, 305)
        Me.mskTelefono.Mask = "(999) 000-0000"
        Me.mskTelefono.Name = "mskTelefono"
        Me.mskTelefono.ReadOnly = True
        Me.mskTelefono.Size = New System.Drawing.Size(91, 20)
        Me.mskTelefono.TabIndex = 2
        Me.mskTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTotal
        '
        Me.lblTotal.Location = New System.Drawing.Point(436, 74)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(187, 22)
        Me.lblTotal.TabIndex = 21
        Me.lblTotal.Text = "-"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Location = New System.Drawing.Point(543, 604)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(78, 27)
        Me.btnClose.TabIndex = 20
        Me.btnClose.Text = "Cerrar"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.ForeColor = System.Drawing.Color.Black
        Me.btnCancelar.Location = New System.Drawing.Point(308, 604)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 27)
        Me.btnCancelar.TabIndex = 19
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        Me.btnCancelar.Visible = False
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.ForeColor = System.Drawing.Color.Black
        Me.btnEliminar.Location = New System.Drawing.Point(228, 604)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(78, 27)
        Me.btnEliminar.TabIndex = 18
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = False
        Me.btnEliminar.Visible = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.ForeColor = System.Drawing.Color.Black
        Me.btnGuardar.Location = New System.Drawing.Point(7, 604)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 27)
        Me.btnGuardar.TabIndex = 11
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.ForeColor = System.Drawing.Color.Black
        Me.btnNuevo.Location = New System.Drawing.Point(397, 604)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 27)
        Me.btnNuevo.TabIndex = 16
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = False
        Me.btnNuevo.Visible = False
        '
        'txtResponsable
        '
        Me.txtResponsable.Location = New System.Drawing.Point(236, 458)
        Me.txtResponsable.Name = "txtResponsable"
        Me.txtResponsable.ReadOnly = True
        Me.txtResponsable.Size = New System.Drawing.Size(239, 20)
        Me.txtResponsable.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(4, 442)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Asignado a"
        '
        'txtPeticion
        '
        Me.txtPeticion.ForeColor = System.Drawing.Color.Red
        Me.txtPeticion.Location = New System.Drawing.Point(7, 355)
        Me.txtPeticion.Multiline = True
        Me.txtPeticion.Name = "txtPeticion"
        Me.txtPeticion.ReadOnly = True
        Me.txtPeticion.Size = New System.Drawing.Size(614, 73)
        Me.txtPeticion.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(4, 339)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Petición"
        '
        'txtCorreo
        '
        Me.txtCorreo.Location = New System.Drawing.Point(436, 305)
        Me.txtCorreo.MaxLength = 100
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.ReadOnly = True
        Me.txtCorreo.Size = New System.Drawing.Size(185, 20)
        Me.txtCorreo.TabIndex = 3
        Me.txtCorreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(433, 289)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Correo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(334, 289)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Telefono"
        '
        'txtSolicitante
        '
        Me.txtSolicitante.Location = New System.Drawing.Point(67, 305)
        Me.txtSolicitante.MaxLength = 100
        Me.txtSolicitante.Name = "txtSolicitante"
        Me.txtSolicitante.ReadOnly = True
        Me.txtSolicitante.Size = New System.Drawing.Size(266, 20)
        Me.txtSolicitante.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(64, 289)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Nombre"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(7, 305)
        Me.txtFolio.MaxLength = 2
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.ReadOnly = True
        Me.txtFolio.Size = New System.Drawing.Size(54, 20)
        Me.txtFolio.TabIndex = 0
        Me.txtFolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 289)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Folio"
        '
        'dtgvD
        '
        Me.dtgvD.AllowUserToAddRows = False
        Me.dtgvD.AllowUserToDeleteRows = False
        Me.dtgvD.AllowUserToResizeRows = False
        Me.dtgvD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgvD.Location = New System.Drawing.Point(7, 99)
        Me.dtgvD.Name = "dtgvD"
        Me.dtgvD.ReadOnly = True
        Me.dtgvD.RowHeadersVisible = False
        Me.dtgvD.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgvD.RowTemplate.Height = 25
        Me.dtgvD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgvD.Size = New System.Drawing.Size(614, 178)
        Me.dtgvD.TabIndex = 3
        '
        'PanelTitleBar
        '
        Me.PanelTitleBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PanelTitleBar.Controls.Add(Me.pctClose)
        Me.PanelTitleBar.Controls.Add(Me.lblArea)
        Me.PanelTitleBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTitleBar.Location = New System.Drawing.Point(0, 0)
        Me.PanelTitleBar.Name = "PanelTitleBar"
        Me.PanelTitleBar.Size = New System.Drawing.Size(637, 62)
        Me.PanelTitleBar.TabIndex = 0
        '
        'pctClose
        '
        Me.pctClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pctClose.Image = CType(resources.GetObject("pctClose.Image"), System.Drawing.Image)
        Me.pctClose.Location = New System.Drawing.Point(590, 12)
        Me.pctClose.Name = "pctClose"
        Me.pctClose.Size = New System.Drawing.Size(35, 35)
        Me.pctClose.TabIndex = 162
        Me.pctClose.TabStop = False
        '
        'lblArea
        '
        Me.lblArea.AutoEllipsis = True
        Me.lblArea.BackColor = System.Drawing.Color.Transparent
        Me.lblArea.Font = New System.Drawing.Font("Nirmala UI", 25.0!)
        Me.lblArea.ForeColor = System.Drawing.Color.White
        Me.lblArea.Location = New System.Drawing.Point(3, 9)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Size = New System.Drawing.Size(453, 46)
        Me.lblArea.TabIndex = 161
        Me.lblArea.Text = "Area"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "No atendidos"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(109, 65)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 13)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "En tramite"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(211, 65)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 13)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "Finalizados"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(321, 65)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(66, 13)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Cancelados"
        '
        'lblNA
        '
        Me.lblNA.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNA.ForeColor = System.Drawing.Color.Red
        Me.lblNA.Location = New System.Drawing.Point(12, 79)
        Me.lblNA.Name = "lblNA"
        Me.lblNA.Size = New System.Drawing.Size(65, 13)
        Me.lblNA.TabIndex = 38
        Me.lblNA.Text = "0"
        Me.lblNA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblE
        '
        Me.lblE.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblE.Location = New System.Drawing.Point(109, 78)
        Me.lblE.Name = "lblE"
        Me.lblE.Size = New System.Drawing.Size(65, 13)
        Me.lblE.TabIndex = 39
        Me.lblE.Text = "0"
        Me.lblE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblF
        '
        Me.lblF.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblF.Location = New System.Drawing.Point(211, 79)
        Me.lblF.Name = "lblF"
        Me.lblF.Size = New System.Drawing.Size(65, 13)
        Me.lblF.TabIndex = 40
        Me.lblF.Text = "0"
        Me.lblF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblC
        '
        Me.lblC.Font = New System.Drawing.Font("Nirmala UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblC.ForeColor = System.Drawing.Color.Navy
        Me.lblC.Location = New System.Drawing.Point(322, 78)
        Me.lblC.Name = "lblC"
        Me.lblC.Size = New System.Drawing.Size(65, 13)
        Me.lblC.TabIndex = 41
        Me.lblC.Text = "0"
        Me.lblC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'peticionesarea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(637, 643)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelContainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "peticionesarea"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelContainer.ResumeLayout(False)
        Me.PanelContainer.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgvD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTitleBar.ResumeLayout(False)
        CType(Me.pctClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelContainer As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents mskFT As MaskedTextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents mskFI As MaskedTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboEstatus As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cboarea As ComboBox
    Friend WithEvents mskTelefono As MaskedTextBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents txtResponsable As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPeticion As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtSolicitante As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtFolio As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dtgvD As DataGridView
    Friend WithEvents PanelTitleBar As Panel
    Friend WithEvents pctClose As PictureBox
    Friend WithEvents lblArea As Label
    Friend WithEvents lblC As Label
    Friend WithEvents lblF As Label
    Friend WithEvents lblE As Label
    Friend WithEvents lblNA As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label6 As Label
End Class
