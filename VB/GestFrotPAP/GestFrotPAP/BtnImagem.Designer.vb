﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BtnImagem
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LblTexto = New System.Windows.Forms.Label()
        Me.PctImagem = New System.Windows.Forms.PictureBox()
        CType(Me.PctImagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTexto
        '
        Me.LblTexto.AutoSize = True
        Me.LblTexto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTexto.Location = New System.Drawing.Point(47, 15)
        Me.LblTexto.Name = "LblTexto"
        Me.LblTexto.Size = New System.Drawing.Size(42, 16)
        Me.LblTexto.TabIndex = 0
        Me.LblTexto.Text = "Texto"
        '
        'PctImagem
        '
        Me.PctImagem.BackColor = System.Drawing.Color.Transparent
        Me.PctImagem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PctImagem.Location = New System.Drawing.Point(2, 6)
        Me.PctImagem.Name = "PctImagem"
        Me.PctImagem.Size = New System.Drawing.Size(32, 32)
        Me.PctImagem.TabIndex = 1
        Me.PctImagem.TabStop = False
        '
        'BtnImagem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PctImagem)
        Me.Controls.Add(Me.LblTexto)
        Me.Name = "BtnImagem"
        Me.Size = New System.Drawing.Size(200, 44)
        CType(Me.PctImagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents LblTexto As System.Windows.Forms.Label
    Public WithEvents PctImagem As System.Windows.Forms.PictureBox

End Class
