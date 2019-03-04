Imports FakeSteam.UserControls

Namespace UserInterface

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Main
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
            Me.PictureBox_CloseButton = New System.Windows.Forms.PictureBox()
            Me.PictureBox_MinimizeButton = New System.Windows.Forms.PictureBox()
            Me.PictureBox_Username = New System.Windows.Forms.PictureBox()
            Me.PictureBox_Password = New System.Windows.Forms.PictureBox()
            Me.PictureBox_Remember = New System.Windows.Forms.PictureBox()
            Me.PictureBox_Title = New System.Windows.Forms.PictureBox()
            Me.TrackBar_Brightness = New System.Windows.Forms.TrackBar()
            Me.TrackBar_Contrast = New System.Windows.Forms.TrackBar()
            Me.TrackBar_Gamma = New System.Windows.Forms.TrackBar()
            Me.Label_Brightness = New System.Windows.Forms.Label()
            Me.Label_Gamma = New System.Windows.Forms.Label()
            Me.Label_Contrast = New System.Windows.Forms.Label()
            Me.Label_Brightness_Value = New System.Windows.Forms.Label()
            Me.Label_Contrast_Value = New System.Windows.Forms.Label()
            Me.Label_Gamma_Value = New System.Windows.Forms.Label()
            Me.ElektroCheckBox_Remember = New FakeSteam.UserControls.ElektroCheckBox()
            Me.ElektroTextBox_Password = New FakeSteam.UserControls.ElektroTextBox()
            Me.ElektroTextBox_Username = New FakeSteam.UserControls.ElektroTextBox()
            Me.PictureBox_Cancel = New FakeSteam.UserControls.ElektroPictureBox()
            Me.PictureBox_CreateAccount = New FakeSteam.UserControls.ElektroPictureBox()
            Me.PictureBox_LostAccount = New FakeSteam.UserControls.ElektroPictureBox()
            Me.PictureBox_Login = New FakeSteam.UserControls.ElektroPictureBox()
            CType(Me.PictureBox_CloseButton, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox_MinimizeButton, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox_Username, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox_Password, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox_Remember, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox_Title, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TrackBar_Brightness, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TrackBar_Contrast, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TrackBar_Gamma, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox_Cancel, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox_CreateAccount, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox_LostAccount, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox_Login, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'PictureBox_CloseButton
            '
            Me.PictureBox_CloseButton.BackColor = System.Drawing.Color.Transparent
            Me.PictureBox_CloseButton.Cursor = System.Windows.Forms.Cursors.Default
            Me.PictureBox_CloseButton.Location = New System.Drawing.Point(447, 2)
            Me.PictureBox_CloseButton.Name = "PictureBox_CloseButton"
            Me.PictureBox_CloseButton.Size = New System.Drawing.Size(23, 23)
            Me.PictureBox_CloseButton.TabIndex = 3
            Me.PictureBox_CloseButton.TabStop = False
            '
            'PictureBox_MinimizeButton
            '
            Me.PictureBox_MinimizeButton.BackColor = System.Drawing.Color.Transparent
            Me.PictureBox_MinimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.PictureBox_MinimizeButton.Cursor = System.Windows.Forms.Cursors.Default
            Me.PictureBox_MinimizeButton.Location = New System.Drawing.Point(424, 2)
            Me.PictureBox_MinimizeButton.Name = "PictureBox_MinimizeButton"
            Me.PictureBox_MinimizeButton.Size = New System.Drawing.Size(23, 23)
            Me.PictureBox_MinimizeButton.TabIndex = 4
            Me.PictureBox_MinimizeButton.TabStop = False
            '
            'PictureBox_Username
            '
            Me.PictureBox_Username.BackColor = System.Drawing.Color.Transparent
            Me.PictureBox_Username.Location = New System.Drawing.Point(6, 90)
            Me.PictureBox_Username.Name = "PictureBox_Username"
            Me.PictureBox_Username.Size = New System.Drawing.Size(106, 20)
            Me.PictureBox_Username.TabIndex = 11
            Me.PictureBox_Username.TabStop = False
            '
            'PictureBox_Password
            '
            Me.PictureBox_Password.BackColor = System.Drawing.Color.Transparent
            Me.PictureBox_Password.Location = New System.Drawing.Point(6, 124)
            Me.PictureBox_Password.Name = "PictureBox_Password"
            Me.PictureBox_Password.Size = New System.Drawing.Size(106, 20)
            Me.PictureBox_Password.TabIndex = 12
            Me.PictureBox_Password.TabStop = False
            '
            'PictureBox_Remember
            '
            Me.PictureBox_Remember.BackColor = System.Drawing.Color.Transparent
            Me.PictureBox_Remember.Location = New System.Drawing.Point(137, 154)
            Me.PictureBox_Remember.Name = "PictureBox_Remember"
            Me.PictureBox_Remember.Size = New System.Drawing.Size(310, 20)
            Me.PictureBox_Remember.TabIndex = 13
            Me.PictureBox_Remember.TabStop = False
            '
            'PictureBox_Title
            '
            Me.PictureBox_Title.BackColor = System.Drawing.Color.Transparent
            Me.PictureBox_Title.Location = New System.Drawing.Point(6, 5)
            Me.PictureBox_Title.Name = "PictureBox_Title"
            Me.PictureBox_Title.Size = New System.Drawing.Size(142, 20)
            Me.PictureBox_Title.TabIndex = 14
            Me.PictureBox_Title.TabStop = False
            '
            'TrackBar_Brightness
            '
            Me.TrackBar_Brightness.AutoSize = False
            Me.TrackBar_Brightness.Location = New System.Drawing.Point(154, 5)
            Me.TrackBar_Brightness.Maximum = 2000
            Me.TrackBar_Brightness.Minimum = 1
            Me.TrackBar_Brightness.Name = "TrackBar_Brightness"
            Me.TrackBar_Brightness.Size = New System.Drawing.Size(84, 20)
            Me.TrackBar_Brightness.TabIndex = 0
            Me.TrackBar_Brightness.TickStyle = System.Windows.Forms.TickStyle.None
            Me.TrackBar_Brightness.Value = 1000
            Me.TrackBar_Brightness.Visible = False
            '
            'TrackBar_Contrast
            '
            Me.TrackBar_Contrast.AutoSize = False
            Me.TrackBar_Contrast.Location = New System.Drawing.Point(244, 5)
            Me.TrackBar_Contrast.Maximum = 2000
            Me.TrackBar_Contrast.Minimum = 1
            Me.TrackBar_Contrast.Name = "TrackBar_Contrast"
            Me.TrackBar_Contrast.Size = New System.Drawing.Size(84, 20)
            Me.TrackBar_Contrast.TabIndex = 1
            Me.TrackBar_Contrast.TickStyle = System.Windows.Forms.TickStyle.None
            Me.TrackBar_Contrast.Value = 1000
            Me.TrackBar_Contrast.Visible = False
            '
            'TrackBar_Gamma
            '
            Me.TrackBar_Gamma.AutoSize = False
            Me.TrackBar_Gamma.Location = New System.Drawing.Point(334, 5)
            Me.TrackBar_Gamma.Maximum = 2000
            Me.TrackBar_Gamma.Minimum = 1
            Me.TrackBar_Gamma.Name = "TrackBar_Gamma"
            Me.TrackBar_Gamma.Size = New System.Drawing.Size(84, 20)
            Me.TrackBar_Gamma.TabIndex = 2
            Me.TrackBar_Gamma.TickStyle = System.Windows.Forms.TickStyle.None
            Me.TrackBar_Gamma.Value = 1000
            Me.TrackBar_Gamma.Visible = False
            '
            'Label_Brightness
            '
            Me.Label_Brightness.BackColor = System.Drawing.Color.Transparent
            Me.Label_Brightness.ForeColor = System.Drawing.Color.Silver
            Me.Label_Brightness.Location = New System.Drawing.Point(154, 32)
            Me.Label_Brightness.Name = "Label_Brightness"
            Me.Label_Brightness.Size = New System.Drawing.Size(84, 13)
            Me.Label_Brightness.TabIndex = 3
            Me.Label_Brightness.Text = "Brightness"
            Me.Label_Brightness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.Label_Brightness.Visible = False
            '
            'Label_Gamma
            '
            Me.Label_Gamma.BackColor = System.Drawing.Color.Transparent
            Me.Label_Gamma.ForeColor = System.Drawing.Color.Silver
            Me.Label_Gamma.Location = New System.Drawing.Point(334, 32)
            Me.Label_Gamma.Name = "Label_Gamma"
            Me.Label_Gamma.Size = New System.Drawing.Size(84, 13)
            Me.Label_Gamma.TabIndex = 5
            Me.Label_Gamma.Text = "Gamma"
            Me.Label_Gamma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.Label_Gamma.Visible = False
            '
            'Label_Contrast
            '
            Me.Label_Contrast.BackColor = System.Drawing.Color.Transparent
            Me.Label_Contrast.ForeColor = System.Drawing.Color.Silver
            Me.Label_Contrast.Location = New System.Drawing.Point(244, 32)
            Me.Label_Contrast.Name = "Label_Contrast"
            Me.Label_Contrast.Size = New System.Drawing.Size(84, 13)
            Me.Label_Contrast.TabIndex = 4
            Me.Label_Contrast.Text = "Contrast"
            Me.Label_Contrast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.Label_Contrast.Visible = False
            '
            'Label_Brightness_Value
            '
            Me.Label_Brightness_Value.BackColor = System.Drawing.Color.Transparent
            Me.Label_Brightness_Value.ForeColor = System.Drawing.Color.Silver
            Me.Label_Brightness_Value.Location = New System.Drawing.Point(154, 54)
            Me.Label_Brightness_Value.Name = "Label_Brightness_Value"
            Me.Label_Brightness_Value.Size = New System.Drawing.Size(84, 13)
            Me.Label_Brightness_Value.TabIndex = 6
            Me.Label_Brightness_Value.Text = "1,000"
            Me.Label_Brightness_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.Label_Brightness_Value.Visible = False
            '
            'Label_Contrast_Value
            '
            Me.Label_Contrast_Value.BackColor = System.Drawing.Color.Transparent
            Me.Label_Contrast_Value.ForeColor = System.Drawing.Color.Silver
            Me.Label_Contrast_Value.Location = New System.Drawing.Point(244, 54)
            Me.Label_Contrast_Value.Name = "Label_Contrast_Value"
            Me.Label_Contrast_Value.Size = New System.Drawing.Size(84, 13)
            Me.Label_Contrast_Value.TabIndex = 7
            Me.Label_Contrast_Value.Text = "1,000"
            Me.Label_Contrast_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.Label_Contrast_Value.Visible = False
            '
            'Label_Gamma_Value
            '
            Me.Label_Gamma_Value.BackColor = System.Drawing.Color.Transparent
            Me.Label_Gamma_Value.ForeColor = System.Drawing.Color.Silver
            Me.Label_Gamma_Value.Location = New System.Drawing.Point(334, 54)
            Me.Label_Gamma_Value.Name = "Label_Gamma_Value"
            Me.Label_Gamma_Value.Size = New System.Drawing.Size(84, 13)
            Me.Label_Gamma_Value.TabIndex = 8
            Me.Label_Gamma_Value.Text = "1,000"
            Me.Label_Gamma_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.Label_Gamma_Value.Visible = False
            '
            'ElektroCheckBox_Remember
            '
            Me.ElektroCheckBox_Remember.BackColor = System.Drawing.Color.Transparent
            Me.ElektroCheckBox_Remember.BorderColor = System.Drawing.Color.FromArgb(CType(CType(87, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(87, Byte), Integer))
            Me.ElektroCheckBox_Remember.BoxColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
            Me.ElektroCheckBox_Remember.Location = New System.Drawing.Point(116, 154)
            Me.ElektroCheckBox_Remember.Name = "ElektroCheckBox_Remember"
            Me.ElektroCheckBox_Remember.Size = New System.Drawing.Size(22, 20)
            Me.ElektroCheckBox_Remember.TabIndex = 11
            Me.ElektroCheckBox_Remember.TickColor = System.Drawing.Color.Gainsboro
            Me.ElektroCheckBox_Remember.UseVisualStyleBackColor = False
            '
            'ElektroTextBox_Password
            '
            Me.ElektroTextBox_Password.AutoScrollMargin = New System.Drawing.Size(0, 0)
            Me.ElektroTextBox_Password.AutoScrollMinSize = New System.Drawing.Size(0, 0)
            Me.ElektroTextBox_Password.AutoSize = New System.Drawing.Size(0, 0)
            Me.ElektroTextBox_Password.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.ElektroTextBox_Password.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
            Me.ElektroTextBox_Password.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.ElektroTextBox_Password.BorderColorDefault = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(137, Byte), Integer))
            Me.ElektroTextBox_Password.BorderColorFocused = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(137, Byte), Integer))
            Me.ElektroTextBox_Password.ForeColor = System.Drawing.Color.Silver
            Me.ElektroTextBox_Password.Location = New System.Drawing.Point(118, 124)
            '
            '
            '
            Me.ElektroTextBox_Password.Margins.Left = 4
            Me.ElektroTextBox_Password.Margins.Right = 0
            Me.ElektroTextBox_Password.Name = "ElektroTextBox_Password"
            Me.ElektroTextBox_Password.Padding = New System.Windows.Forms.Padding(0)
            Me.ElektroTextBox_Password.ShowBorder = False
            Me.ElektroTextBox_Password.Size = New System.Drawing.Size(327, 20)
            Me.ElektroTextBox_Password.TabIndex = 10
            '
            '
            '
            Me.ElektroTextBox_Password.TextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ElektroTextBox_Password.TextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
            Me.ElektroTextBox_Password.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.ElektroTextBox_Password.TextBox.ForeColor = System.Drawing.Color.Silver
            Me.ElektroTextBox_Password.TextBox.Location = New System.Drawing.Point(-1, -1)
            Me.ElektroTextBox_Password.TextBox.Name = ""
            Me.ElektroTextBox_Password.TextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
            Me.ElektroTextBox_Password.TextBox.Size = New System.Drawing.Size(425, 20)
            Me.ElektroTextBox_Password.TextBox.TabIndex = 0
            Me.ElektroTextBox_Password.TextBox.UseSystemPasswordChar = True
            '
            'ElektroTextBox_Username
            '
            Me.ElektroTextBox_Username.AutoScrollMargin = New System.Drawing.Size(0, 0)
            Me.ElektroTextBox_Username.AutoScrollMinSize = New System.Drawing.Size(0, 0)
            Me.ElektroTextBox_Username.AutoSize = New System.Drawing.Size(0, 0)
            Me.ElektroTextBox_Username.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.ElektroTextBox_Username.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
            Me.ElektroTextBox_Username.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.ElektroTextBox_Username.BorderColorDefault = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(137, Byte), Integer))
            Me.ElektroTextBox_Username.BorderColorFocused = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(137, Byte), Integer))
            Me.ElektroTextBox_Username.ForeColor = System.Drawing.Color.Silver
            Me.ElektroTextBox_Username.Location = New System.Drawing.Point(118, 90)
            '
            '
            '
            Me.ElektroTextBox_Username.Margins.Left = 4
            Me.ElektroTextBox_Username.Margins.Right = 0
            Me.ElektroTextBox_Username.Name = "ElektroTextBox_Username"
            Me.ElektroTextBox_Username.Padding = New System.Windows.Forms.Padding(0)
            Me.ElektroTextBox_Username.ShowBorder = False
            Me.ElektroTextBox_Username.Size = New System.Drawing.Size(327, 20)
            Me.ElektroTextBox_Username.TabIndex = 9
            '
            '
            '
            Me.ElektroTextBox_Username.TextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ElektroTextBox_Username.TextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(39, Byte), Integer))
            Me.ElektroTextBox_Username.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.ElektroTextBox_Username.TextBox.ForeColor = System.Drawing.Color.Silver
            Me.ElektroTextBox_Username.TextBox.Location = New System.Drawing.Point(-1, -1)
            Me.ElektroTextBox_Username.TextBox.Name = ""
            Me.ElektroTextBox_Username.TextBox.Size = New System.Drawing.Size(425, 20)
            Me.ElektroTextBox_Username.TextBox.TabIndex = 0
            '
            'PictureBox_Cancel
            '
            Me.PictureBox_Cancel.BackColor = System.Drawing.Color.Transparent
            Me.PictureBox_Cancel.Location = New System.Drawing.Point(286, 184)
            Me.PictureBox_Cancel.Name = "PictureBox_Cancel"
            Me.PictureBox_Cancel.Size = New System.Drawing.Size(161, 24)
            Me.PictureBox_Cancel.TabIndex = 13
            '
            'PictureBox_CreateAccount
            '
            Me.PictureBox_CreateAccount.BackColor = System.Drawing.Color.Transparent
            Me.PictureBox_CreateAccount.Location = New System.Drawing.Point(210, 240)
            Me.PictureBox_CreateAccount.Name = "PictureBox_CreateAccount"
            Me.PictureBox_CreateAccount.Size = New System.Drawing.Size(237, 24)
            Me.PictureBox_CreateAccount.TabIndex = 14
            '
            'PictureBox_LostAccount
            '
            Me.PictureBox_LostAccount.BackColor = System.Drawing.Color.Transparent
            Me.PictureBox_LostAccount.Location = New System.Drawing.Point(210, 272)
            Me.PictureBox_LostAccount.Name = "PictureBox_LostAccount"
            Me.PictureBox_LostAccount.Size = New System.Drawing.Size(237, 24)
            Me.PictureBox_LostAccount.TabIndex = 15
            '
            'PictureBox_Login
            '
            Me.PictureBox_Login.BackColor = System.Drawing.Color.Transparent
            Me.PictureBox_Login.Enabled = False
            Me.PictureBox_Login.Location = New System.Drawing.Point(116, 184)
            Me.PictureBox_Login.Name = "PictureBox_Login"
            Me.PictureBox_Login.Size = New System.Drawing.Size(161, 24)
            Me.PictureBox_Login.TabIndex = 12
            '
            'Main
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
            Me.BackgroundImage = Global.FakeSteam.My.Resources.Resources.en_US_Main
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.ClientSize = New System.Drawing.Size(470, 310)
            Me.Controls.Add(Me.Label_Gamma_Value)
            Me.Controls.Add(Me.Label_Contrast_Value)
            Me.Controls.Add(Me.Label_Brightness_Value)
            Me.Controls.Add(Me.Label_Contrast)
            Me.Controls.Add(Me.Label_Gamma)
            Me.Controls.Add(Me.Label_Brightness)
            Me.Controls.Add(Me.TrackBar_Gamma)
            Me.Controls.Add(Me.TrackBar_Contrast)
            Me.Controls.Add(Me.TrackBar_Brightness)
            Me.Controls.Add(Me.ElektroCheckBox_Remember)
            Me.Controls.Add(Me.ElektroTextBox_Password)
            Me.Controls.Add(Me.ElektroTextBox_Username)
            Me.Controls.Add(Me.PictureBox_Cancel)
            Me.Controls.Add(Me.PictureBox_CloseButton)
            Me.Controls.Add(Me.PictureBox_CreateAccount)
            Me.Controls.Add(Me.PictureBox_LostAccount)
            Me.Controls.Add(Me.PictureBox_MinimizeButton)
            Me.Controls.Add(Me.PictureBox_Password)
            Me.Controls.Add(Me.PictureBox_Remember)
            Me.Controls.Add(Me.PictureBox_Title)
            Me.Controls.Add(Me.PictureBox_Username)
            Me.Controls.Add(Me.PictureBox_Login)
            Me.DoubleBuffered = True
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.MaximizeBox = False
            Me.Name = "Main"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Steam"
            CType(Me.PictureBox_CloseButton, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox_MinimizeButton, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox_Username, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox_Password, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox_Remember, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox_Title, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TrackBar_Brightness, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TrackBar_Contrast, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TrackBar_Gamma, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox_Cancel, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox_CreateAccount, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox_LostAccount, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox_Login, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ElektroCheckBox_Remember As ElektroCheckBox
        Friend WithEvents ElektroTextBox_Password As ElektroTextBox
        Friend WithEvents ElektroTextBox_Username As ElektroTextBox
        Friend WithEvents PictureBox_Cancel As FakeSteam.UserControls.ElektroPictureBox
        Friend WithEvents PictureBox_CloseButton As System.Windows.Forms.PictureBox
        Friend WithEvents PictureBox_CreateAccount As FakeSteam.UserControls.ElektroPictureBox
        Friend WithEvents PictureBox_Login As FakeSteam.UserControls.ElektroPictureBox
        Friend WithEvents PictureBox_LostAccount As FakeSteam.UserControls.ElektroPictureBox
        Friend WithEvents PictureBox_MinimizeButton As System.Windows.Forms.PictureBox
        Friend WithEvents PictureBox_Password As System.Windows.Forms.PictureBox
        Friend WithEvents PictureBox_Remember As System.Windows.Forms.PictureBox
        Friend WithEvents PictureBox_Title As System.Windows.Forms.PictureBox
        Friend WithEvents PictureBox_Username As System.Windows.Forms.PictureBox
        Friend WithEvents TrackBar_Brightness As System.Windows.Forms.TrackBar
        Friend WithEvents TrackBar_Contrast As System.Windows.Forms.TrackBar
        Friend WithEvents TrackBar_Gamma As System.Windows.Forms.TrackBar
        Friend WithEvents Label_Brightness As System.Windows.Forms.Label
        Friend WithEvents Label_Gamma As System.Windows.Forms.Label
        Friend WithEvents Label_Contrast As System.Windows.Forms.Label
        Friend WithEvents Label_Brightness_Value As System.Windows.Forms.Label
        Friend WithEvents Label_Contrast_Value As System.Windows.Forms.Label
        Friend WithEvents Label_Gamma_Value As System.Windows.Forms.Label

    End Class

End Namespace