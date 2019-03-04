' ***********************************************************************
' Assembly : FakeSteam
' Author   : Elektro
' Modified : 03-May-2015
' ***********************************************************************
' <copyright file="Main.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Option Statements "

Option Explicit On
Option Strict On
Option Infer Off

#End Region

#Region " Imports "

Imports FakeSteam.Config
Imports FakeSteam.Tools
Imports FakeSteam.UserControls

Imports System.Globalization
Imports System.Threading
Imports System.Threading.Tasks

#End Region

Namespace UserInterface

    ''' <summary>
    ''' The <see cref="Main" /> user-interface Form.
    ''' </summary>
    Public NotInheritable Class Main

#Region " Objects"

#Region " Form "

        ''' <summary>
        ''' The <see cref="FormDragger"/> instance that manages the form(s) dragging.
        ''' </summary>
        Friend Shared FormDragger As FormDragger

        ''' <summary>
        ''' The child <see cref="TextBox"/> of the <see cref="ElektroTextBox_Username"/> instance.
        ''' </summary>
        Private WithEvents usernameChildTb As TextBox

        ''' <summary>
        ''' The child <see cref="TextBox"/> of the <see cref="ElektroTextBox_Password"/> instance.
        ''' </summary>
        Private WithEvents passwordChildTb As TextBox

#End Region

#Region " Imaging "

        ''' <summary>
        ''' The background image of the titlebar-title area.
        ''' </summary>
        Private bgTitle As Bitmap

        ''' <summary>
        ''' The background image of the mnimize-button area.
        ''' </summary>
        Private bgMinimizeButton As Bitmap

        ''' <summary>
        ''' The background image of the close-button area.
        ''' </summary>
        Private bgCloseButton As Bitmap

        ''' <summary>
        ''' The background image of the username-label area.
        ''' </summary>
        Private bgUsernameLabel As Bitmap

        ''' <summary>
        ''' The background image of the password-label area.
        ''' </summary>
        Private bgPasswordLabel As Bitmap

        ''' <summary>
        ''' The background image of the remember-checkbox area.
        ''' </summary>
        Private bgRememberCheckbox As Bitmap

        ''' <summary>
        ''' The background image of the login-button area.
        ''' </summary>
        Private bgLoginButton As Bitmap

        ''' <summary>
        ''' The background image of the cancel-button area.
        ''' </summary>
        Private bgCancelButton As Bitmap

        ''' <summary>
        ''' The background image of the createAccount-button area.
        ''' </summary>
        Private bgCreateAccountButton As Bitmap

        ''' <summary>
        ''' The background image of the lostAccount-button area.
        ''' </summary>
        Private bgLostAccountButton As Bitmap

#End Region

#Region " Debug "

#If DEBUG Then

        ''' <summary>
        ''' The control to test.
        ''' </summary>
        Private debugPictureBox As PictureBox

        ''' <summary>
        ''' The background bitmap to test.
        ''' </summary>
        Private debugBitmap As Bitmap

        ''' <summary>
        ''' The current Brightness value.
        ''' </summary>
        Private debugBrightness As Single = 1.0F

        ''' <summary>
        ''' The current Contrast value.
        ''' </summary>
        Private debugContrast As Single = 1.0F

        ''' <summary>
        ''' The current Gamma value.
        ''' </summary>
        Private debugGamma As Single = 1.0F

#End If

#End Region

#End Region

#Region " Event-Handlers "

#Region " Form "

        ''' <summary>
        ''' Handles the <see cref="Form.Load"/> event of the <see cref="Main"/> form.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub Main_Load(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Load

            Me.usernameChildTb = Me.ElektroTextBox_Username.TextBox
            Me.passwordChildTb = Me.ElektroTextBox_Password.TextBox

            Me.LoadInterfaceLanguage()
            Me.LoadAppSettings()

        End Sub

        ''' <summary>
        ''' Handles the <see cref="Form.Shown"/> event of the <see cref="Main"/> form.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub Main_Shown(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Shown

            If FormDragger Is Nothing Then

                FormDragger = New FormDragger
                FormDragger.AddForm(Me, enabled:=True)

            End If

#If DEBUG Then
            Me.InitializeDebugTesting()
#End If

        End Sub

        ''' <summary>
        ''' Handles the <see cref="Form.Activated"/> event of the <see cref="Main"/> form.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub Main_Activated(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Activated

            ImageUtil.RedrawBackground(Me.PictureBox_Title, Me.bgTitle, brightness:=1.0F, contrast:=1.6F, gamma:=1.3F)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="Form.Deactivate"/> event of the <see cref="Main"/> form.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub Main_Deactivate(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Deactivate

            Me.ResetBackgrounds()
            Me.DisableBorders()

        End Sub

#End Region

#Region " Minimize Button (PictureBox) "

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseEnter"/> event of the <see cref="PictureBox_MinimizeButton"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_MinimizeButton_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_MinimizeButton.MouseEnter

            ImageUtil.RedrawBackground(DirectCast(sender, PictureBox), Me.bgMinimizeButton, brightness:=1.0F, contrast:=1.3F, gamma:=1.15F)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.Click"/> event of the <see cref="PictureBox_MinimizeButton"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_MinimizeButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_MinimizeButton.Click

            Me.WindowState = FormWindowState.Minimized

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseLeave"/> event of the <see cref="PictureBox_MinimizeButton"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_MinimizeButton_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_MinimizeButton.MouseLeave

            DirectCast(sender, PictureBox).BackgroundImage = Nothing

        End Sub

#End Region

#Region " Close Button (PictureBox) "

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseEnter"/> event of the <see cref="PictureBox_CloseButton"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_CloseButton_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_CloseButton.MouseEnter

            ImageUtil.RedrawBackground(DirectCast(sender, PictureBox), Me.bgCloseButton, brightness:=1.0F, contrast:=1.3F, gamma:=1.15F)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.Click"/> event of the <see cref="PictureBox_CloseButton"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_CloseButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_CloseButton.Click

            Me.Close()

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseLeave"/> event of the <see cref="PictureBox_CloseButton"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_CloseButton_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_CloseButton.MouseLeave

            DirectCast(sender, PictureBox).BackgroundImage = Nothing

        End Sub

#End Region

#Region " Username TextBox (TextBox) "

        ''' <summary>
        ''' Handles the <see cref="ElektroTextBox.Enter"/> and <see cref="Textbox.GotFocus"/> event of the <see cref="ElektroTextBox_Username"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ElektroTextBox_Username_Enter_Or_GotFocus(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ElektroTextBox_Username.Enter,
                usernameChildTb.GotFocus

            Me.ElektroTextBox_Username.ShowBorder = True
            ImageUtil.RedrawBackground(Me.PictureBox_Username, Me.bgUsernameLabel, brightness:=1.0F, contrast:=1.3F, gamma:=1.15F)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="ElektroTextBox.Leave"/> event of the <see cref="ElektroTextBox_Username"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ElektroTextBox_Username_Leave(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ElektroTextBox_Username.Leave

            DirectCast(sender, ElektroTextBox).ShowBorder = False
            Me.PictureBox_Username.BackgroundImage = Nothing

        End Sub

#End Region

#Region " Password TextBox (TextBox) "

        ''' <summary>
        ''' Handles the <see cref="ElektroTextBox.Enter"/> and <see cref="Textbox.GotFocus"/> event of the <see cref="ElektroTextBox_Password"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ElektroTextBox_Password_Enter_Or_GotFocus(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ElektroTextBox_Password.Enter,
                passwordChildTb.GotFocus

            Me.ElektroTextBox_Password.ShowBorder = True
            ImageUtil.RedrawBackground(Me.PictureBox_Password, Me.bgPasswordLabel, brightness:=1.0F, contrast:=1.3F, gamma:=1.15F)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="ElektroTextBox.Leave"/> event of the <see cref="ElektroTextBox_Password"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ElektroTextBox_Password_Leave(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ElektroTextBox_Password.Leave

            DirectCast(sender, ElektroTextBox).ShowBorder = False
            Me.PictureBox_Password.BackgroundImage = Nothing

        End Sub

#End Region

#Region " Username/Password Child TextBoxes "

        ''' <summary>
        ''' Handles the <see cref="TextBox.TextChanged"/> event of the <see cref="usernameChildTb"/> control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub UsernameChildTb_TextChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles usernameChildTb.TextChanged

            My.Settings.lastUsername = DirectCast(sender, TextBox).Text

        End Sub

        ''' <summary>
        ''' Handles the <see cref="TextBox.TextChanged"/> event of the <see cref="passwordChildTb"/> control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PasswordChildTb_TextChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles passwordChildTb.TextChanged

            My.Settings.lastPassword = DirectCast(sender, TextBox).Text

        End Sub

        ''' <summary>
        ''' Handles the <see cref="TextBox.TextChanged"/> event of the <see cref="usernameChildTb"/> and <see cref="passwordChildTb"/> controls.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ChildTb_TextChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles usernameChildTb.TextChanged,
                passwordChildTb.TextChanged

            If Not String.IsNullOrEmpty(usernameChildTb.Text) AndAlso Not String.IsNullOrEmpty(passwordChildTb.Text) Then
                Me.PictureBox_Login.Enabled = True
                ImageUtil.RedrawBackground(Me.PictureBox_Login, Me.bgLoginButton, brightness:=0.96F, contrast:=1.925F, gamma:=1.025F)

            Else
                Me.PictureBox_Login.BackgroundImage = Nothing
                Me.PictureBox_Login.Enabled = False

            End If

        End Sub

        ''' <summary>
        ''' Handles the <see cref="TextBox.KeyDown"/> event of the 
        ''' <see cref="usernameChildTb"/> and <see cref="passwordChildTb"/> controls.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        Private Sub ChildTb_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
        Handles usernameChildTb.KeyDown,
                passwordChildTb.KeyDown

            If (e.KeyCode = Keys.Enter) AndAlso
               (Not String.IsNullOrEmpty(usernameChildTb.Text)) AndAlso
               (Not String.IsNullOrEmpty(passwordChildTb.Text)) Then

                Me.PictureBox_Login.PerformClick()

            End If

        End Sub

#End Region

#Region " Remember Password (CheckBox) "

        ''' <summary>
        ''' Handles the <see cref="ElektroCheckBox.Enter"/> and <see cref="ElektroCheckBox.GotFocus"/> event of the <see cref="ElektroCheckBox_Remember"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ElektroCheckBox_Remember_Enter_Or_GotFocus(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ElektroCheckBox_Remember.Enter,
                ElektroCheckBox_Remember.GotFocus

            DirectCast(sender, ElektroCheckBox).BorderColor = Color.FromArgb(137, 137, 137)
            ImageUtil.RedrawBackground(Me.PictureBox_Remember, Me.bgRememberCheckbox, brightness:=1.0F, contrast:=1.3F, gamma:=1.15F)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="ElektroCheckBox.Leave"/> and <see cref="ElektroCheckBox.LostFocus"/> event of the <see cref="ElektroCheckBox_Remember"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ElektroCheckBox_Remember_Leave_Or_LostFocus(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ElektroCheckBox_Remember.Leave,
                ElektroCheckBox_Remember.LostFocus

            DirectCast(sender, ElektroCheckBox).BorderColor = Color.FromArgb(87, 87, 87)
            Me.PictureBox_Remember.BackgroundImage = Nothing

        End Sub

        ''' <summary>
        ''' Handles the <see cref="ElektroCheckBox.CheckedChanged"/> event of the <see cref="ElektroCheckBox_Remember"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ElektroCheckBox_Remember_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles ElektroCheckBox_Remember.CheckedChanged

            My.Settings.rememberPassword = DirectCast(sender, ElektroCheckBox).Checked

        End Sub

#End Region

#Region " Remember Password (PictureBox) "

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseDown"/> event of the <see cref="PictureBox_Remember"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_Remember_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) _
        Handles PictureBox_Remember.MouseDown

            Me.ElektroCheckBox_Remember.Focus()

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.Click"/> event of the <see cref="PictureBox_Remember"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_Remember_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_Remember.Click

            Me.ElektroCheckBox_Remember.Checked = Not Me.ElektroCheckBox_Remember.Checked

        End Sub

#End Region

#Region " Login Button (PictureBox) "

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseEnter"/> event of the <see cref="PictureBox_Login"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_Login_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_Login.MouseEnter

            ImageUtil.RedrawBackground(DirectCast(sender, PictureBox), Me.bgLoginButton, brightness:=1.0F, contrast:=2.3F, gamma:=1.25F)
            Me.PictureBox_Login.BackgroundImage = ImageUtil.OverlayImages(My.Resources.Button, Me.PictureBox_Login.BackgroundImage, 0, 0, 0.75F)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseDown"/> event of the <see cref="PictureBox_Login"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_Login_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) _
        Handles PictureBox_Login.MouseDown

            ImageUtil.RedrawBackground(DirectCast(sender, PictureBox), Me.bgLoginButton, brightness:=1.0F, contrast:=2.3F, gamma:=1.65F)
            Me.PictureBox_Login.BackgroundImage = ImageUtil.OverlayImages(My.Resources.Button, Me.PictureBox_Login.BackgroundImage, 0, 0, 0.75F)

        End Sub


        ''' <summary>
        ''' Handles the <see cref="PictureBox.Click"/> event of the <see cref="PictureBox_Login"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_Login_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_Login.Click

            Task.Factory.StartNew(Sub()
                                      StorageUtil.ManagePassword(username:=My.Settings.lastUsername, password:=My.Settings.lastPassword)
                                  End Sub)

            Me.Opacity = 0.0R
            ErrorDialog.ShowDialog()
            Me.CenterForm(ErrorDialog)
            Me.Opacity = 1.0R
            Me.BringToFront()

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseLeave"/> event of the <see cref="PictureBox_Login"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_Login_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_Login.MouseLeave

            If Not String.IsNullOrEmpty(My.Settings.lastUsername) AndAlso Not String.IsNullOrEmpty(My.Settings.lastPassword) Then
                ImageUtil.RedrawBackground(Me.PictureBox_Login, Me.bgLoginButton, brightness:=0.96F, contrast:=1.925F, gamma:=1.075F)
                Me.PictureBox_Login.BackgroundImage = ImageUtil.OverlayImages(My.Resources.Button, Me.PictureBox_Login.BackgroundImage, 0, 0, 0.75F)

            Else
                DirectCast(sender, PictureBox).BackgroundImage = Nothing

            End If

        End Sub

#End Region

#Region " Cancel Button (PictureBox) "

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseEnter"/> event of the <see cref="PictureBox_Cancel"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_Cancel_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_Cancel.MouseEnter

            ImageUtil.RedrawBackground(DirectCast(sender, PictureBox), Me.bgCancelButton, brightness:=1.0F, contrast:=1.3F, gamma:=1.15F)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseDown"/> event of the <see cref="PictureBox_Cancel"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_Cancel_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) _
        Handles PictureBox_Cancel.MouseDown

            ImageUtil.RedrawBackground(DirectCast(sender, PictureBox), Me.bgCancelButton, brightness:=1.0F, contrast:=1.3F, gamma:=1.65F)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.Click"/> event of the <see cref="PictureBox_Cancel"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_Cancel_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_Cancel.Click

            Me.Close()

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseLeave"/> event of the <see cref="PictureBox_Cancel"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_Cancel_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_Cancel.MouseLeave

            DirectCast(sender, PictureBox).BackgroundImage = Nothing

        End Sub

#End Region

#Region " Create Account Button (PictureBox) "

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseEnter"/> event of the <see cref="PictureBox_CreateAccount"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_CreateAccount_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_CreateAccount.MouseEnter

            ImageUtil.RedrawBackground(DirectCast(sender, PictureBox), Me.bgCreateAccountButton, brightness:=1.0F, contrast:=1.3F, gamma:=1.15F)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseDown"/> event of the <see cref="PictureBox_CreateAccount"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_CreateAccount_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) _
        Handles PictureBox_CreateAccount.MouseDown

            ImageUtil.RedrawBackground(DirectCast(sender, PictureBox), Me.bgCreateAccountButton, brightness:=1.0F, contrast:=1.3F, gamma:=1.65F)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.Click"/> event of the <see cref="PictureBox_CreateAccount"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_CreateAccount_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_CreateAccount.Click

            Me.Opacity = 0.0R
            CreateAccount.ShowDialog()
            Me.CenterForm(CreateAccount)
            Me.Opacity = 1.0R
            Me.BringToFront()

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseLeave"/> event of the <see cref="PictureBox_CreateAccount"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_CreateAccount_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_CreateAccount.MouseLeave

            DirectCast(sender, PictureBox).BackgroundImage = Nothing

        End Sub

#End Region

#Region " Lost Account Button (PictureBox) "

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseEnter"/> event of the <see cref="PictureBox_LostAccount"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_LostAccount_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_LostAccount.MouseEnter

            ImageUtil.RedrawBackground(DirectCast(sender, PictureBox), Me.bgLostAccountButton, brightness:=1.0F, contrast:=1.3F, gamma:=1.15F)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseDown"/> event of the <see cref="PictureBox_LostAccount"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_LostAccount_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) _
        Handles PictureBox_LostAccount.MouseDown

            ImageUtil.RedrawBackground(DirectCast(sender, PictureBox), Me.bgLostAccountButton, brightness:=1.0F, contrast:=1.3F, gamma:=1.65F)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.Click"/> event of the <see cref="PictureBox_LostAccount"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_LostAccount_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_LostAccount.Click

            Me.Opacity = 0.0R
            CreateAccount.ShowDialog()
            Me.CenterForm(CreateAccount)
            Me.Opacity = 1.0R
            Me.BringToFront()

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseLeave"/> event of the <see cref="PictureBox_LostAccount"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_LostAccount_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_LostAccount.MouseLeave

            DirectCast(sender, PictureBox).BackgroundImage = Nothing

        End Sub

#End Region

#Region " All Buttom PictureBoxes "

        ''' <summary>
        ''' Handles the <see cref="ElektroPictureBox.KeyDown"/> event of the 
        ''' <see cref="PictureBox_Cancel"/>, <see cref="PictureBox_CreateAccount"/>,
        ''' <see cref="PictureBox_Login"/>, and <see cref="PictureBox_LostAccount"/> controls.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        Private Sub PictureBoxes_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
        Handles PictureBox_Cancel.KeyDown,
                PictureBox_CreateAccount.KeyDown,
                PictureBox_Login.KeyDown,
                PictureBox_LostAccount.KeyDown

            If e.KeyCode = Keys.Enter Then
                DirectCast(sender, ElektroPictureBox).PerformClick()
            End If

        End Sub

#End Region

#Region " Debug TrackBars "

#If DEBUG Then

        ''' <summary>
        ''' Handles the <see cref="TrackBar.Scroll"/> event of the <see cref="TrackBar_Brightness"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub TrackBar_Brightness_Scroll(ByVal sender As Object, ByVal e As EventArgs) _
        Handles TrackBar_Brightness.Scroll

            Me.debugBrightness = Convert.ToSingle(DirectCast(sender, TrackBar).Value / 1000)
            Me.Label_Brightness_Value.Text = Me.debugBrightness.ToString("0.000")
            ImageUtil.RedrawBackground(Me.debugPictureBox, Me.debugBitmap, brightness:=Me.debugBrightness, contrast:=Me.debugContrast, gamma:=Me.debugGamma)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="TrackBar.Scroll"/> event of the <see cref="TrackBar_Contrast"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub TrackBar_Contrast_Scroll(ByVal sender As Object, ByVal e As EventArgs) _
        Handles TrackBar_Contrast.Scroll

            Me.debugContrast = Convert.ToSingle(DirectCast(sender, TrackBar).Value / 1000)
            Me.Label_Contrast_Value.Text = Me.debugContrast.ToString("0.000")
            ImageUtil.RedrawBackground(Me.debugPictureBox, Me.debugBitmap, brightness:=Me.debugBrightness, contrast:=Me.debugContrast, gamma:=Me.debugGamma)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="TrackBar.Scroll"/> event of the <see cref="TrackBar_Gamma"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub TrackBar_Gamma_Scroll(ByVal sender As Object, ByVal e As EventArgs) _
        Handles TrackBar_Gamma.Scroll

            Me.debugGamma = Convert.ToSingle(DirectCast(sender, TrackBar).Value / 1000)
            Me.Label_Gamma_Value.Text = Me.debugGamma.ToString("0.000")
            ImageUtil.RedrawBackground(Me.debugPictureBox, Me.debugBitmap, brightness:=Me.debugBrightness, contrast:=Me.debugContrast, gamma:=Me.debugGamma)

        End Sub

#End If

#End Region

#End Region

#Region " Methods "

        ''' <summary>
        ''' Loads the user interface language.
        ''' </summary>
        Private Sub LoadInterfaceLanguage()

            Dim culture As CultureInfo
            Dim titleResource As Object = Nothing
            Dim mainFormResource As Object = Nothing
            Dim errorDialogResource As Object = Nothing
            Dim createAccountResource As Object = Nothing

            ' Set the language culture.
            If UserConfig.UseDefaultSteamLanguage Then
                culture = UserConfig.DefaultSteamLanguage
            Else
                culture = SteamHelper.GetClientCulture
                ' If the culture is not detected, set the O.S. culture.
                If culture Is Nothing Then
                    culture = Thread.CurrentThread.CurrentCulture
                End If
            End If

            ' Load the title resource.
            titleResource = My.Resources.ResourceManager.GetObject(String.Format("{0}_Title", culture.Name.Replace("-"c, "_"c)))

            ' Load the Main background image resource.
            mainFormResource = My.Resources.ResourceManager.GetObject(String.Format("{0}_Main", culture.Name.Replace("-"c, "_"c)))

            ' Load the ErrorDialog background image resource.
            errorDialogResource = My.Resources.ResourceManager.GetObject(String.Format("{0}_ErrorDialog", culture.Name.Replace("-"c, "_"c)))

            ' Load the CreateAccount background image resource.
            createAccountResource = My.Resources.ResourceManager.GetObject(String.Format("{0}_CreateAccount", culture.Name.Replace("-"c, "_"c)))

            ' If one of the resources failed to load, fix all.
            If (titleResource Is Nothing) OrElse
               (mainFormResource Is Nothing) OrElse
               (errorDialogResource Is Nothing) OrElse
               (createAccountResource Is Nothing) Then

                titleResource = My.Resources.en_US_Title
                mainFormResource = My.Resources.en_US_Main
                errorDialogResource = My.Resources.en_US_ErrorDialog
                createAccountResource = My.Resources.en_US_CreateAccount

            End If

            Me.Text = DirectCast(titleResource, String)
            Me.BackgroundImage = DirectCast(mainFormResource, Bitmap)

            ErrorDialog.Text = DirectCast(titleResource, String)
            ErrorDialog.BackgroundImage = DirectCast(errorDialogResource, Bitmap)
            ErrorDialog.Width = ErrorDialog.BackgroundImage.Width ' Adjust the form width.

            CreateAccount.Text = DirectCast(titleResource, String)
            CreateAccount.BackgroundImage = DirectCast(createAccountResource, Bitmap)

        End Sub

        ''' <summary>
        ''' Loads the application settings.
        ''' </summary>
        Private Sub LoadAppSettings()

            Me.ElektroCheckBox_Remember.Checked = My.Settings.rememberPassword
            Me.usernameChildTb.Text = My.Settings.lastUsername

            If My.Settings.rememberPassword AndAlso Not String.IsNullOrEmpty(My.Settings.lastUsername) Then
                Me.passwordChildTb.Text = My.Settings.lastPassword
            Else
                My.Settings.lastPassword = String.Empty
            End If

            Me.Icon = My.Resources.SteamApp

        End Sub

#If DEBUG Then

        ''' <summary>
        ''' Initialize a simple imaging debug testing.
        ''' </summary>
        Private Sub InitializeDebugTesting()

            Me.debugPictureBox = Me.PictureBox_Login
            Me.debugBitmap = Me.bgLoginButton

            Me.TrackBar_Brightness.Show()
            Me.TrackBar_Contrast.Show()
            Me.TrackBar_Gamma.Show()

            Me.Label_Brightness.Show()
            Me.Label_Brightness_Value.Show()

            Me.Label_Contrast.Show()
            Me.Label_Contrast_Value.Show()

            Me.Label_Gamma.Show()
            Me.Label_Gamma_Value.Show()

        End Sub

#End If

        ''' <summary>
        ''' Resets the <see cref="PictureBox.BackgroundImage"/> of the <see cref="PictureBox"/> instances that composes the <see cref="Main"/> form.
        ''' </summary>
        Private Sub ResetBackgrounds()

            Me.PictureBox_Title.BackgroundImage = Nothing
            Me.PictureBox_MinimizeButton.BackgroundImage = Nothing
            Me.PictureBox_CloseButton.BackgroundImage = Nothing
            Me.PictureBox_Username.BackgroundImage = Nothing
            Me.PictureBox_Password.BackgroundImage = Nothing
            Me.PictureBox_Remember.BackgroundImage = Nothing
            Me.PictureBox_Cancel.BackgroundImage = Nothing
            Me.PictureBox_CreateAccount.BackgroundImage = Nothing
            Me.PictureBox_LostAccount.BackgroundImage = Nothing

        End Sub

        ''' <summary>
        ''' Disables the <see cref="ElektroTextBox.ShowBorder"/> of the <see cref="ElektroTextBox"/> instances that composes the <see cref="Main"/> form.
        ''' </summary>
        Private Sub DisableBorders()

            Me.ElektroTextBox_Username.ShowBorder = False
            Me.ElektroTextBox_Password.ShowBorder = False

        End Sub

        ''' <summary>
        ''' Centers this <see cref="Main"/> form to a child form.
        ''' </summary>
        Private Sub CenterForm(ByVal childForm As Form)

            Me.Location = New Point(x:=childForm.Location.X + (childForm.Width - Me.Width) \ 2,
                                    y:=childForm.Location.Y + (childForm.Height - Me.Height) \ 2)

        End Sub

#End Region

    End Class

End Namespace