Imports FakeSteam.UserControls

Namespace UserInterface

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CreateAccount
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateAccount))
            Me.PictureBox_CreateAccount = New FakeSteam.UserControls.ElektroPictureBox()
            Me.PictureBox_LoginAccount = New FakeSteam.UserControls.ElektroPictureBox()
            Me.PictureBox_MinimizeButton = New System.Windows.Forms.PictureBox()
            Me.PictureBox_CloseButton = New System.Windows.Forms.PictureBox()
            Me.PictureBox_Title = New System.Windows.Forms.PictureBox()
            CType(Me.PictureBox_CreateAccount, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox_LoginAccount, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox_MinimizeButton, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox_CloseButton, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox_Title, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'PictureBox_CreateAccount
            '
            Me.PictureBox_CreateAccount.BackColor = System.Drawing.Color.Transparent
            Me.PictureBox_CreateAccount.Location = New System.Drawing.Point(80, 284)
            Me.PictureBox_CreateAccount.Name = "PictureBox_CreateAccount"
            Me.PictureBox_CreateAccount.Size = New System.Drawing.Size(275, 24)
            Me.PictureBox_CreateAccount.TabIndex = 0
            '
            'PictureBox_LoginAccount
            '
            Me.PictureBox_LoginAccount.BackColor = System.Drawing.Color.Transparent
            Me.PictureBox_LoginAccount.Location = New System.Drawing.Point(80, 322)
            Me.PictureBox_LoginAccount.Name = "PictureBox_LoginAccount"
            Me.PictureBox_LoginAccount.Size = New System.Drawing.Size(275, 24)
            Me.PictureBox_LoginAccount.TabIndex = 1
            '
            'PictureBox_MinimizeButton
            '
            Me.PictureBox_MinimizeButton.BackColor = System.Drawing.Color.Transparent
            Me.PictureBox_MinimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.PictureBox_MinimizeButton.Cursor = System.Windows.Forms.Cursors.Default
            Me.PictureBox_MinimizeButton.Location = New System.Drawing.Point(385, 2)
            Me.PictureBox_MinimizeButton.Name = "PictureBox_MinimizeButton"
            Me.PictureBox_MinimizeButton.Size = New System.Drawing.Size(23, 23)
            Me.PictureBox_MinimizeButton.TabIndex = 6
            Me.PictureBox_MinimizeButton.TabStop = False
            '
            'PictureBox_CloseButton
            '
            Me.PictureBox_CloseButton.BackColor = System.Drawing.Color.Transparent
            Me.PictureBox_CloseButton.Cursor = System.Windows.Forms.Cursors.Default
            Me.PictureBox_CloseButton.Location = New System.Drawing.Point(408, 2)
            Me.PictureBox_CloseButton.Name = "PictureBox_CloseButton"
            Me.PictureBox_CloseButton.Size = New System.Drawing.Size(23, 23)
            Me.PictureBox_CloseButton.TabIndex = 5
            Me.PictureBox_CloseButton.TabStop = False
            '
            'PictureBox_Title
            '
            Me.PictureBox_Title.BackColor = System.Drawing.Color.Transparent
            Me.PictureBox_Title.Location = New System.Drawing.Point(6, 5)
            Me.PictureBox_Title.Name = "PictureBox_Title"
            Me.PictureBox_Title.Size = New System.Drawing.Size(142, 20)
            Me.PictureBox_Title.TabIndex = 15
            Me.PictureBox_Title.TabStop = False
            '
            'CreateAccount
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
            Me.ClientSize = New System.Drawing.Size(432, 438)
            Me.Controls.Add(Me.PictureBox_Title)
            Me.Controls.Add(Me.PictureBox_MinimizeButton)
            Me.Controls.Add(Me.PictureBox_CloseButton)
            Me.Controls.Add(Me.PictureBox_LoginAccount)
            Me.Controls.Add(Me.PictureBox_CreateAccount)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "CreateAccount"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
            Me.Text = "Steam"
            CType(Me.PictureBox_CreateAccount, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox_LoginAccount, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox_MinimizeButton, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox_CloseButton, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox_Title, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PictureBox_CreateAccount As ElektroPictureBox
        Friend WithEvents PictureBox_LoginAccount As ElektroPictureBox
        Friend WithEvents PictureBox_MinimizeButton As System.Windows.Forms.PictureBox
        Friend WithEvents PictureBox_CloseButton As System.Windows.Forms.PictureBox
        Friend WithEvents PictureBox_Title As System.Windows.Forms.PictureBox
    End Class

End Namespace
