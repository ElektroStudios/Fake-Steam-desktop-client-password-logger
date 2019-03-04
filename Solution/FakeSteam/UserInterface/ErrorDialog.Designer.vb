Namespace UserInterface

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ErrorDialog
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
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
            Me.PictureBox_Title = New System.Windows.Forms.PictureBox()
            Me.PictureBox_Hyperlink = New System.Windows.Forms.PictureBox()
            Me.PictureBox_Ok = New System.Windows.Forms.PictureBox()
            CType(Me.PictureBox_Title, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox_Hyperlink, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox_Ok, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'PictureBox_Title
            '
            Me.PictureBox_Title.BackColor = System.Drawing.Color.Transparent
            Me.PictureBox_Title.Location = New System.Drawing.Point(6, 5)
            Me.PictureBox_Title.Name = "PictureBox_Title"
            Me.PictureBox_Title.Size = New System.Drawing.Size(142, 22)
            Me.PictureBox_Title.TabIndex = 0
            Me.PictureBox_Title.TabStop = False
            '
            'PictureBox_Hyperlink
            '
            Me.PictureBox_Hyperlink.BackColor = System.Drawing.Color.Transparent
            Me.PictureBox_Hyperlink.Location = New System.Drawing.Point(1, 112)
            Me.PictureBox_Hyperlink.Name = "PictureBox_Hyperlink"
            Me.PictureBox_Hyperlink.Size = New System.Drawing.Size(452, 20)
            Me.PictureBox_Hyperlink.TabIndex = 1
            Me.PictureBox_Hyperlink.TabStop = False
            '
            'PictureBox_Ok
            '
            Me.PictureBox_Ok.BackColor = System.Drawing.Color.Transparent
            Me.PictureBox_Ok.Location = New System.Drawing.Point(1, 149)
            Me.PictureBox_Ok.Name = "PictureBox_Ok"
            Me.PictureBox_Ok.Size = New System.Drawing.Size(452, 25)
            Me.PictureBox_Ok.TabIndex = 0
            Me.PictureBox_Ok.TabStop = False
            '
            'ErrorDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
            Me.BackgroundImage = Global.FakeSteam.My.Resources.Resources.en_US_ErrorDialog
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.ClientSize = New System.Drawing.Size(455, 190)
            Me.Controls.Add(Me.PictureBox_Ok)
            Me.Controls.Add(Me.PictureBox_Hyperlink)
            Me.Controls.Add(Me.PictureBox_Title)
            Me.DoubleBuffered = True
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ErrorDialog"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "ErrorBox"
            CType(Me.PictureBox_Title, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox_Hyperlink, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox_Ok, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PictureBox_Title As System.Windows.Forms.PictureBox
        Friend WithEvents PictureBox_Hyperlink As System.Windows.Forms.PictureBox
        Friend WithEvents PictureBox_Ok As System.Windows.Forms.PictureBox
    End Class

End Namespace
