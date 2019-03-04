' ***********************************************************************
' Author   : Elektro
' Modified : 03-May-2015
' ***********************************************************************
' <copyright file="ImageUtil.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Option Statements "

Option Explicit On
Option Strict On
Option Infer Off

#End Region

#Region " Imports "

Imports System.Drawing.Imaging

#End Region

Namespace Tools

    ''' <summary>
    ''' Contains related image tools.
    ''' </summary>
    Public NotInheritable Class ImageUtil

#Region " Public Methods "

        ''' <summary>
        ''' Adjusts the brightness, contrast, and/or the gamma of an image.
        ''' </summary>
        ''' <param name="image">The image.</param>
        ''' <param name="brightness">The brightness.</param>
        ''' <param name="contrast">The contrast.</param>
        ''' <param name="gamma">The gamma.</param>
        ''' <returns>The adjusted image.</returns>
        Public Shared Function AdjustImage(ByVal image As Image,
                                           ByVal brightness As Single,
                                           ByVal contrast As Single,
                                           ByVal gamma As Single) As Image

            brightness -= 1.0F
            Dim result As New Bitmap(image.Width, image.Height)

            Dim ptsArray As Single()() =
                {
                    New Single() {contrast, 0.0F, 0.0F, 0.0F, 0.0F},
                    New Single() {0.0F, contrast, 0.0F, 0.0F, 0.0F},
                    New Single() {0.0F, 0.0F, contrast, 0.0F, 0.0F},
                    New Single() {0.0F, 0.0F, 0.0F, 1.0F, 0.0F},
                    New Single() {brightness, brightness, brightness, 0.0F, 1.0F}
                }

            Using imageAttributes As New ImageAttributes

                imageAttributes.ClearColorMatrix()
                imageAttributes.SetColorMatrix(New ColorMatrix(ptsArray), ColorMatrixFlag.[Default], ColorAdjustType.Bitmap)
                imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap)

                Using g As Graphics = Graphics.FromImage(result)

                    g.DrawImage(image,
                                New Rectangle(0, 0, result.Width, result.Height),
                                0, 0, image.Width, image.Height,
                                GraphicsUnit.Pixel,
                                imageAttributes)

                End Using

            End Using

            Return result

        End Function

        ''' <summary>
        ''' Redraws the background of a <see cref="PictureBox"/>.
        ''' </summary>
        ''' <param name="pcb">The <see cref="PictureBox"/>.</param>
        ''' <param name="bmp">The byreffered <see cref="Bitmap"/> to store the modified background.</param>
        ''' <param name="brightness">The brightness.</param>
        ''' <param name="contrast">The contrast.</param>
        ''' <param name="gamma">The gamma.</param>
        Public Shared Sub RedrawBackground(ByVal pcb As PictureBox,
                                           ByRef bmp As Bitmap,
                                           ByVal brightness As Single,
                                           ByVal contrast As Single,
                                           ByVal gamma As Single)

            If bmp Is Nothing Then
                bmp = New Bitmap(pcb.ClientRectangle.Width, pcb.ClientRectangle.Height)
                pcb.DrawToBitmap(bmp, pcb.ClientRectangle)
            End If

            pcb.BackgroundImage = ImageUtil.AdjustImage(bmp, brightness, contrast, gamma)

        End Sub


        ''' <remarks>
        ''' *****************************************************************
        ''' Snippet Title: Overlay Images
        ''' Code's author: Elektro
        ''' Date Modified: 30-April-2015
        ''' Usage Example: 
        ''' Dim backImg As Image = Image.FromFile("C:\back.jpg")
        ''' Dim topImg As Image = Image.FromFile("C:\top.png")
        ''' Dim overlay As Image = OverlayImages(backImg, topImg, topPosX:=+5, topPosY:=-15)
        ''' overlay.Save("C:\Overlay.jpg", Imaging.ImageFormat.Jpeg)
        ''' Process.Start("C:\Overlay.jpg")
        ''' *****************************************************************
        ''' </remarks>
        ''' <summary>
        ''' Overlay an image over a background image.
        ''' </summary>
        ''' <param name="backImage">The background image.</param>
        ''' <param name="topImage">The topmost image.</param>
        ''' <param name="topPosX">An optional adjustment of the top image's "X" position.</param>
        ''' <param name="topPosY">An optional adjustment of the top image's "Y" position.</param>
        ''' <returns>The overlayed image.</returns>
        ''' <exception cref="ArgumentNullException">backImage or topImage</exception>
        ''' <exception cref="ArgumentException">Image bounds are greater than background image.;topImage</exception>
        Public Shared Function OverlayImages(ByVal backImage As Image,
                                             ByVal topImage As Image,
                                             Optional ByVal topPosX As Integer = 0,
                                             Optional ByVal topPosY As Integer = 0,
                                             Optional ByVal opacity As Single = 1.0F) As Image

            If backImage Is Nothing Then
                Throw New ArgumentNullException(paramName:="backImage")

            ElseIf topImage Is Nothing Then
                Throw New ArgumentNullException(paramName:="topImage")

            ElseIf (topImage.Width > backImage.Width) OrElse
                   (topImage.Height > backImage.Height) Then
                Throw New ArgumentException(message:="Image bounds are greater than background image.", paramName:="topImage")

            Else
                topPosX += CInt((backImage.Width / 2) - (topImage.Width / 2))
                topPosY += CInt((backImage.Height / 2) - (topImage.Height / 2))

                Dim bmp As New Bitmap(backImage.Width, backImage.Height)

                If opacity < 1.0F Then
                    topImage = ImageUtil.SetImageOpacity(topImage, opacity)
                End If

                Using canvas As Graphics = Graphics.FromImage(bmp)

                    canvas.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

                    canvas.DrawImage(image:=backImage,
                                     destRect:=New Rectangle(0, 0, bmp.Width, bmp.Height),
                                     srcRect:=New Rectangle(0, 0, bmp.Width, bmp.Height),
                                     srcUnit:=GraphicsUnit.Pixel)

                    canvas.DrawImage(image:=topImage,
                                     destRect:=New Rectangle(topPosX, topPosY, topImage.Width, topImage.Height),
                                     srcRect:=New Rectangle(0, 0, topImage.Width, topImage.Height),
                                     srcUnit:=GraphicsUnit.Pixel)

                    canvas.Save()

                End Using

                Return bmp

            End If

        End Function

        ''' <remarks>
        ''' *****************************************************************
        ''' Snippet Title: Set Image Opacity
        ''' Code's author: Elektro
        ''' Date Modified: 30-April-2015
        ''' Usage Example: 
        ''' Dim srcImage As Image = Image.FromFile("C:\Image.png")
        ''' Dim modImage As Image = SetImageOpacity(srcImage, opacity:=0.5F)
        ''' modImage.Save("C:\Transparent.png", Imaging.ImageFormat.Png)
        ''' Process.Start("C:\Transparent.png")
        ''' *****************************************************************
        ''' </remarks>
        ''' <summary>
        ''' Sets the opacity of an image.
        ''' </summary>
        ''' <param name="img">The source image.</param>
        ''' <param name="opacity">The target opacity level, from 0.0 to 1.0.</param>
        ''' <returns>The image with the opacity applied.</returns>
        ''' <exception cref="ArgumentNullException">img</exception>
        ''' <exception cref="ArgumentOutOfRangeException">opacity</exception>
        Public Shared Function SetImageOpacity(ByVal img As Image,
                                               ByVal opacity As Single) As Image

            If img Is Nothing Then
                Throw New ArgumentNullException(paramName:="img")

            ElseIf (opacity > 1.0F) OrElse (opacity < 0.0F) Then
                Throw New ArgumentOutOfRangeException(paramName:="opacity")

            Else
                ' Create a Bitmap with the size of the image provided.
                Dim bmp As New Bitmap(img.Width, img.Height)

                ' Create a graphics object from the image.
                Using g As Graphics = Graphics.FromImage(bmp)

                    ' Create a color matrix object.
                    Dim matrix As New ColorMatrix

                    ' Set the opacity.
                    matrix.Matrix33 = opacity

                    ' Create image attributes.
                    Dim attributes As New ImageAttributes

                    ' Set the color (opacity) of the image.
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap)

                    ' Draw the image.
                    g.DrawImage(img,
                                New Rectangle(0, 0, bmp.Width, bmp.Height),
                                0, 0, img.Width, img.Height,
                                GraphicsUnit.Pixel,
                                attributes)

                End Using

                Return bmp

            End If

        End Function

#End Region

    End Class

End Namespace