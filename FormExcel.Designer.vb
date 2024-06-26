<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormExcel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormExcel))
        Panel1 = New Panel()
        rBtnFinalizado = New RadioButton()
        rBtnTodo = New RadioButton()
        rBtnPendiente = New RadioButton()
        Label1 = New Label()
        btnExportar = New Button()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(rBtnFinalizado)
        Panel1.Controls.Add(rBtnTodo)
        Panel1.Controls.Add(rBtnPendiente)
        Panel1.Location = New Point(12, 45)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(263, 27)
        Panel1.TabIndex = 2
        ' 
        ' rBtnFinalizado
        ' 
        rBtnFinalizado.AutoSize = True
        rBtnFinalizado.Location = New Point(103, 3)
        rBtnFinalizado.Name = "rBtnFinalizado"
        rBtnFinalizado.Size = New Size(78, 19)
        rBtnFinalizado.TabIndex = 2
        rBtnFinalizado.TabStop = True
        rBtnFinalizado.Text = "Finalizado"
        rBtnFinalizado.UseVisualStyleBackColor = True
        ' 
        ' rBtnTodo
        ' 
        rBtnTodo.AutoSize = True
        rBtnTodo.Location = New Point(208, 3)
        rBtnTodo.Name = "rBtnTodo"
        rBtnTodo.Size = New Size(51, 19)
        rBtnTodo.TabIndex = 3
        rBtnTodo.TabStop = True
        rBtnTodo.Text = "Todo"
        rBtnTodo.UseVisualStyleBackColor = True
        ' 
        ' rBtnPendiente
        ' 
        rBtnPendiente.AutoCheck = False
        rBtnPendiente.AutoSize = True
        rBtnPendiente.Location = New Point(3, 3)
        rBtnPendiente.Name = "rBtnPendiente"
        rBtnPendiente.Size = New Size(83, 19)
        rBtnPendiente.TabIndex = 1
        rBtnPendiente.TabStop = True
        rBtnPendiente.Text = "Pendientes"
        rBtnPendiente.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(133, 21)
        Label1.TabIndex = 3
        Label1.Text = "Elija una opción"
        ' 
        ' btnExportar
        ' 
        btnExportar.Location = New Point(12, 85)
        btnExportar.Name = "btnExportar"
        btnExportar.Size = New Size(260, 35)
        btnExportar.TabIndex = 4
        btnExportar.Text = "Exportar a Escritorio"
        btnExportar.UseVisualStyleBackColor = True
        ' 
        ' FormExcel
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(287, 138)
        Controls.Add(btnExportar)
        Controls.Add(Label1)
        Controls.Add(Panel1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "FormExcel"
        Text = "FormExcel"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rBtnPendiente As RadioButton
    Friend WithEvents rBtnTodo As RadioButton
    Friend WithEvents rBtnFinalizado As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents btnExportar As Button
End Class
