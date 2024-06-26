<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        DataGridView1 = New DataGridView()
        Cliente = New DataGridViewTextBoxColumn()
        Expediente = New DataGridViewTextBoxColumn()
        DNI = New DataGridViewTextBoxColumn()
        Email = New DataGridViewTextBoxColumn()
        Peticion = New DataGridViewTextBoxColumn()
        Usuario = New DataGridViewTextBoxColumn()
        Fecha = New DataGridViewTextBoxColumn()
        FechaFin = New DataGridViewTextBoxColumn()
        IdCliente = New DataGridViewTextBoxColumn()
        Borrado = New DataGridViewCheckBoxColumn()
        ConexionBDBindingSource = New BindingSource(components)
        btnBorrar = New Button()
        btnExcel = New Button()
        btnActualizar = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(ConexionBDBindingSource, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {Cliente, Expediente, DNI, Email, Peticion, Usuario, Fecha, FechaFin, IdCliente, Borrado})
        DataGridView1.Location = New Point(12, 10)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect
        DataGridView1.Size = New Size(761, 187)
        DataGridView1.TabIndex = 0
        ' 
        ' Cliente
        ' 
        Cliente.DataPropertyName = "Cliente"
        Cliente.HeaderText = "Cliente"
        Cliente.Name = "Cliente"
        Cliente.ReadOnly = True
        Cliente.Resizable = DataGridViewTriState.False
        Cliente.Width = 80
        ' 
        ' Expediente
        ' 
        Expediente.DataPropertyName = "Expediente"
        Expediente.HeaderText = "Expediente"
        Expediente.Name = "Expediente"
        Expediente.ReadOnly = True
        Expediente.Resizable = DataGridViewTriState.False
        Expediente.Width = 80
        ' 
        ' DNI
        ' 
        DNI.DataPropertyName = "DNI"
        DNI.HeaderText = "DNI"
        DNI.Name = "DNI"
        DNI.ReadOnly = True
        DNI.Resizable = DataGridViewTriState.False
        DNI.Width = 70
        ' 
        ' Email
        ' 
        Email.DataPropertyName = "Email"
        Email.HeaderText = "Email"
        Email.Name = "Email"
        Email.ReadOnly = True
        Email.Width = 125
        ' 
        ' Peticion
        ' 
        Peticion.DataPropertyName = "Peticion"
        Peticion.HeaderText = "Petición"
        Peticion.Name = "Peticion"
        Peticion.ReadOnly = True
        Peticion.Resizable = DataGridViewTriState.False
        Peticion.Width = 125
        ' 
        ' Usuario
        ' 
        Usuario.DataPropertyName = "Usuario"
        Usuario.HeaderText = "Usuario"
        Usuario.Name = "Usuario"
        Usuario.ReadOnly = True
        Usuario.Resizable = DataGridViewTriState.False
        Usuario.Width = 70
        ' 
        ' Fecha
        ' 
        Fecha.DataPropertyName = "FechaInicio"
        Fecha.HeaderText = "Fecha"
        Fecha.Name = "Fecha"
        Fecha.ReadOnly = True
        Fecha.Resizable = DataGridViewTriState.False
        ' 
        ' FechaFin
        ' 
        FechaFin.DataPropertyName = "FechaFin"
        FechaFin.HeaderText = "FechaFin"
        FechaFin.Name = "FechaFin"
        FechaFin.ReadOnly = True
        FechaFin.Resizable = DataGridViewTriState.False
        FechaFin.Visible = False
        ' 
        ' IdCliente
        ' 
        IdCliente.DataPropertyName = "IdCliente"
        IdCliente.HeaderText = "IdCliente"
        IdCliente.Name = "IdCliente"
        IdCliente.ReadOnly = True
        IdCliente.Resizable = DataGridViewTriState.False
        IdCliente.Visible = False
        ' 
        ' Borrado
        ' 
        Borrado.DataPropertyName = "Borrado"
        Borrado.HeaderText = "Borrar"
        Borrado.Name = "Borrado"
        Borrado.Resizable = DataGridViewTriState.False
        Borrado.SortMode = DataGridViewColumnSortMode.Automatic
        Borrado.Width = 50
        ' 
        ' ConexionBDBindingSource
        ' 
        ConexionBDBindingSource.DataSource = GetType(ConexionBD)
        ' 
        ' btnBorrar
        ' 
        btnBorrar.Location = New Point(673, 203)
        btnBorrar.Name = "btnBorrar"
        btnBorrar.Size = New Size(100, 33)
        btnBorrar.TabIndex = 1
        btnBorrar.Text = "Borrar Petición"
        btnBorrar.UseVisualStyleBackColor = True
        ' 
        ' btnExcel
        ' 
        btnExcel.Image = My.Resources.Resources.sobresalir1
        btnExcel.Location = New Point(12, 203)
        btnExcel.Name = "btnExcel"
        btnExcel.Size = New Size(33, 33)
        btnExcel.TabIndex = 2
        btnExcel.UseVisualStyleBackColor = True
        ' 
        ' btnActualizar
        ' 
        btnActualizar.Image = CType(resources.GetObject("btnActualizar.Image"), Image)
        btnActualizar.Location = New Point(634, 203)
        btnActualizar.Name = "btnActualizar"
        btnActualizar.Size = New Size(33, 32)
        btnActualizar.TabIndex = 3
        btnActualizar.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(794, 248)
        Controls.Add(btnActualizar)
        Controls.Add(btnExcel)
        Controls.Add(btnBorrar)
        Controls.Add(DataGridView1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form1"
        Text = "Peticiones a Back Office"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(ConexionBDBindingSource, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ConexionBDBindingSource As BindingSource
    Friend WithEvents btnBorrar As Button
    Friend WithEvents btnExcel As Button
    Friend WithEvents btnActualizar As Button
    Friend WithEvents Cliente As DataGridViewTextBoxColumn
    Friend WithEvents Expediente As DataGridViewTextBoxColumn
    Friend WithEvents DNI As DataGridViewTextBoxColumn
    Friend WithEvents Email As DataGridViewTextBoxColumn
    Friend WithEvents Peticion As DataGridViewTextBoxColumn
    Friend WithEvents Usuario As DataGridViewTextBoxColumn
    Friend WithEvents Fecha As DataGridViewTextBoxColumn
    Friend WithEvents FechaFin As DataGridViewTextBoxColumn
    Friend WithEvents IdCliente As DataGridViewTextBoxColumn
    Friend WithEvents Borrado As DataGridViewCheckBoxColumn

End Class
