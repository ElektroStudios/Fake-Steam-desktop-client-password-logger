' ***********************************************************************
' Assembly : FakeSteam
' Author   : Elektro
' Modified : 03-May-2015
' ***********************************************************************
' <copyright file="ErrorDialog.vb" company="Elektro Studios">
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

#End Region

#Region " Error Dialog "

Namespace UserInterface

    ''' <summary>
    ''' The <see cref="ErrorDialog"/> user-interface form.
    ''' </summary>
    Public NotInheritable Class ErrorDialog

#Region " Objects "

#Region " Imaging "

        ''' <summary>
        ''' The background image of the titlebar-title area.
        ''' </summary>
        Private bgTitle As Bitmap

        ''' <summary>
        ''' The background image of the hyperlink area.
        ''' </summary>
        Private bgHyperlink As Bitmap

        ''' <summary>
        ''' The background image of the ok-button area.
        ''' </summary>
        Private bgOkButton As Bitmap

#End Region

#End Region

#Region " Event-Handlers "

#Region " Form "

        ''' <summary>
        ''' Handles the <see cref="Form.Load"/> event of the <see cref="ErrorDialog"/> form.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ErrorBox_Load(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Load

            Main.FormDragger.AddForm(form:=Me, enabled:=True)
            Me.CenterForm()

        End Sub

        ''' <summary>
        ''' Handles the <see cref="Form.FormClosing"/> event of the <see cref="ErrorDialog"/> form.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ErrorBox_FormClosing(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Me.FormClosing

            Me.ResetBackgrounds()
            Me.DisposeResources()

        End Sub

        ''' <summary>
        ''' Handles the <see cref="Form.Activated"/> event of the <see cref="ErrorDialog"/> form.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ErrorBox_Activated(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Activated

            ImageUtil.RedrawBackground(Me.PictureBox_Title, Me.bgTitle, brightness:=1.0F, contrast:=1.6F, gamma:=1.3F)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="Form.Deactivate"/> event of the <see cref="ErrorDialog"/> form.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub ErrorBox_Deactivate(ByVal sender As Object, ByVal e As EventArgs) _
        Handles MyBase.Deactivate

            Me.ResetBackgrounds()

        End Sub

        ''' <summary>
        ''' Handles the <see cref="Form.KeyDown"/> event of the <see cref="ErrorDialog"/> form.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        Private Sub ErrorDialog_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
        Handles MyBase.KeyDown

            Me.DialogResult = Windows.Forms.DialogResult.OK

        End Sub

#End Region

#Region " Hyperlink (PictureBox) "

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseEnter"/> event of the <see cref="PictureBox_Hyperlink"/> control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_Hyperlink_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_Hyperlink.MouseEnter

            ImageUtil.RedrawBackground(DirectCast(sender, PictureBox), Me.bgHyperlink, brightness:=1.0F, contrast:=1.3F, gamma:=1.15F)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseDown"/> event of the <see cref="PictureBox_Hyperlink"/> control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_Hyperlink_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) _
        Handles PictureBox_Hyperlink.MouseDown

            Try
                Process.Start(SteamHelper.AccountRecoveryUrl)

            Catch ex As Exception
                ' Do Nothing.

            End Try

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseLeave"/> event of the <see cref="PictureBox_Hyperlink"/> control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_Hyperlink_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_Hyperlink.MouseLeave

            DirectCast(sender, PictureBox).BackgroundImage = Nothing

        End Sub

#End Region

#Region " Ok Button (PictureBox) "

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseEnter"/> event of the <see cref="PictureBox_Ok"/> control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_Ok_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_Ok.MouseEnter

            ImageUtil.RedrawBackground(DirectCast(sender, PictureBox), Me.bgOkButton, brightness:=1.0F, contrast:=1.3F, gamma:=1.15F)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseDown"/> events of the <see cref="PictureBox_Ok"/> control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_Ok_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) _
        Handles PictureBox_Ok.MouseDown

            ImageUtil.RedrawBackground(DirectCast(sender, PictureBox), Me.bgOkButton, brightness:=1.0F, contrast:=1.3F, gamma:=1.15F)

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.Click"/> event of the <see cref="PictureBox_Ok"/> control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_Ok_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_Ok.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK

        End Sub

        ''' <summary>
        ''' Handles the <see cref="PictureBox.MouseLeave"/> event of the <see cref="PictureBox_Ok"/> control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub PictureBox_Ok_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) _
        Handles PictureBox_Ok.MouseLeave

            DirectCast(sender, PictureBox).BackgroundImage = Nothing

        End Sub

#End Region

#End Region

#Region " Methods "

        ''' <summary>
        ''' Resets the <see cref="PictureBox.BackgroundImage"/> of the <see cref="PictureBox"/> instances that composes the <see cref="ErrorDialog"/> form.
        ''' </summary>
        Private Sub ResetBackgrounds()

            Me.PictureBox_Title.BackgroundImage = Nothing
            Me.PictureBox_Hyperlink.BackgroundImage = Nothing
            Me.PictureBox_Ok.BackgroundImage = Nothing

        End Sub

        ''' <summary>
        ''' Disposes the resources used by the <see cref="ErrorDialog"/> form.
        ''' </summary>
        Private Sub DisposeResources()

            Main.FormDragger.RemoveForm(form:=Me)

            If Me.bgTitle IsNot Nothing Then
                Me.bgTitle.Dispose()
                Me.bgTitle = Nothing
            End If

            If Me.bgHyperlink IsNot Nothing Then
                Me.bgHyperlink.Dispose()
                Me.bgHyperlink = Nothing
            End If

            If Me.bgOkButton IsNot Nothing Then
                Me.bgOkButton.Dispose()
                Me.bgOkButton = Nothing
            End If

            GC.Collect()

        End Sub

        ''' <summary>
        ''' Centers this <see cref="ErrorDialog"/> form to <see cref="Main"/> form.
        ''' </summary>
        Private Sub CenterForm()

            Me.Location = New Point(x:=Main.Location.X + (Main.Width - Me.Width) \ 2,
                                    y:=Main.Location.Y + (Main.Height - Me.Height) \ 2)

        End Sub

#End Region

    End Class

End Namespace

#End Region