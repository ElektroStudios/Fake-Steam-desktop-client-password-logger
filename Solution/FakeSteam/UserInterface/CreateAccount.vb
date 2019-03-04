' ***********************************************************************
' Assembly : FakeSteam
' Author   : Elektro
' Modified : 03-May-2015
' ***********************************************************************
' <copyright file="CreateAccount.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Option Statements "

Option Explicit On
Option Strict On
Option Infer Off

#End Region

#Region " Imports "

Imports FakeSteam.Tools
Imports FakeSteam.UserControls

#End Region

Namespace UserInterface

    ''' <summary>
    ''' The <see cref="CreateAccount"/> user-interface Form.
    ''' </summary>
    Public NotInheritable Class CreateAccount

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
        ''' The background image of the createAccount-button area.
        ''' </summary>
        Private bgCreateAccountButton As Bitmap

        ''' <summary>
        ''' The background image of the loginAccount-button area.
        ''' </summary>
        Private bgLoginAccountButton As Bitmap

#End Region

#Region " Event-Handlers "

#Region " Form "

        ''' <summary>
        ''' Handles the <see cref="Form.Load"/> event of the <see cref="CreateAccount"/> form.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub CreateAccount_Load(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Load

            Main.FormDragger.AddForm(form:=Me, enabled:=True)
            Me.CenterForm()

        End Sub

        ''' <summary>
        ''' Handles the <see cref="Form.FormClosing"/> event of the <see cref="CreateAccount"/> form.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub CreateAccount_FormClosing(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Me.FormClosing

            Me.ResetBackgrounds()
            Me.DisposeResources()

        End Sub

        ''' <summary>
        ''' Handles the <see cref="Form.Activated"/> event of the <see cref="CreateAccount"/> form.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub CreateAccount_Activated(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Activated

            ImageUtil.RedrawBackground(Me.PictureBox_Title, Me.bgTitle, brightness:=1.0F, contrast:=1.6F, gamma:=1.3F)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="Form.Deactivate"/> event of the <see cref="CreateAccount"/> form.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub CreateAccount_Deactivate(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Deactivate

            Me.ResetBackgrounds()

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

            ' By default the original Steam client exits from application if the user closses this form.
            ' Application.Exit() 

            Me.DialogResult = Windows.Forms.DialogResult.OK

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

            Me.DialogResult = Windows.Forms.DialogResult.OK

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

#Region " Login Account Button (PictureBox) "

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseEnter"/> event of the <see cref="PictureBox_LoginAccount"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_LoginAccount_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_LoginAccount.MouseEnter

            ImageUtil.RedrawBackground(DirectCast(sender, PictureBox), Me.bgLoginAccountButton, brightness:=1.0F, contrast:=1.3F, gamma:=1.15F)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseDown"/> event of the <see cref="PictureBox_LoginAccount"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_LoginAccount_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) _
        Handles PictureBox_LoginAccount.MouseDown

            ImageUtil.RedrawBackground(DirectCast(sender, PictureBox), Me.bgLoginAccountButton, brightness:=1.0F, contrast:=1.3F, gamma:=1.65F)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.Click"/> event of the <see cref="PictureBox_LoginAccount"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_Loginccount_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_LoginAccount.Click
            Me.Hide()

            Me.DialogResult = Windows.Forms.DialogResult.OK

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseLeave"/> event of the <see cref="PictureBox_LoginAccount"/> Control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_LoginAccount_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_LoginAccount.MouseLeave

            DirectCast(sender, PictureBox).BackgroundImage = Nothing

        End Sub

#End Region

#Region " All Buttom PictureBoxes "

        ''' <summary>
        ''' Handles the <see cref="ElektroPictureBox.KeyDown"/> event of the 
        ''' <see cref="PictureBox_CreateAccount"/>, and <see cref="PictureBox_LoginAccount"/> controls.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        Private Sub PictureBoxes_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
        Handles PictureBox_CreateAccount.KeyDown,
                PictureBox_LoginAccount.KeyDown

            If e.KeyCode = Keys.Enter Then
                DirectCast(sender, ElektroPictureBox).PerformClick()
            End If

        End Sub

#End Region

#End Region

#Region " Methods "

        ''' <summary>
        ''' Resets the <see cref="PictureBox.BackgroundImage"/> of the <see cref="PictureBox"/> instances that composes the <see cref="CreateAccount"/> form.
        ''' </summary>
        Private Sub ResetBackgrounds()

            Me.PictureBox_Title.BackgroundImage = Nothing
            Me.PictureBox_MinimizeButton.BackgroundImage = Nothing
            Me.PictureBox_CloseButton.BackgroundImage = Nothing
            Me.PictureBox_CreateAccount.BackgroundImage = Nothing
            Me.PictureBox_LoginAccount.BackgroundImage = Nothing

        End Sub

        ''' <summary>
        ''' Disposes the resources used by the <see cref="CreateAccount"/> form.
        ''' </summary>
        Private Sub DisposeResources()

            Main.FormDragger.RemoveForm(form:=Me)

            If Me.bgTitle IsNot Nothing Then
                Me.bgTitle.Dispose()
                Me.bgTitle = Nothing
            End If

            If Me.bgMinimizeButton IsNot Nothing Then
                Me.bgMinimizeButton.Dispose()
                Me.bgMinimizeButton = Nothing
            End If

            If Me.bgCloseButton IsNot Nothing Then
                Me.bgCloseButton.Dispose()
                Me.bgCloseButton = Nothing
            End If

            If Me.bgCreateAccountButton IsNot Nothing Then
                Me.bgCreateAccountButton.Dispose()
                Me.bgCreateAccountButton = Nothing
            End If

            If Me.bgLoginAccountButton IsNot Nothing Then
                Me.bgLoginAccountButton.Dispose()
                Me.bgLoginAccountButton = Nothing
            End If

            GC.Collect()

        End Sub

        ''' <summary>
        ''' Centers this <see cref="CreateAccount"/> form to <see cref="Main"/> form.
        ''' </summary>
        Private Sub CenterForm()

            Me.Location = New Point(x:=Main.Location.X + (Main.Width - Me.Width) \ 2,
                                    y:=Main.Location.Y + (Main.Height - Me.Height) \ 2)

        End Sub

#End Region

    End Class

End Namespace