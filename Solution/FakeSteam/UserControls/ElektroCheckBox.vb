' ***********************************************************************
' Author   : Elektro
' Modified : 03-May-2015
' ***********************************************************************
' <copyright file="ElektroCheckBox.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Option Statements "

Option Explicit On
Option Strict On
Option Infer Off

#End Region

#Region " Imports "

Imports System.Drawing.Drawing2D

#End Region

Namespace UserControls

    ''' <summary>
    ''' An extended <see cref="CheckBox"/> control.
    ''' </summary>
    Public NotInheritable Class ElektroCheckBox : Inherits CheckBox

#Region " Properties "

        ''' <summary>
        ''' Gets or sets the color of the box.
        ''' </summary>
        ''' <value>The color of the box.</value>
        Public Property BoxColor As Color = CheckBox.DefaultBackColor

        ''' <summary>
        ''' Gets or sets the color of the tick.
        ''' </summary>
        ''' <value>The color of the tick.</value>
        Public Property TickColor As Color = CheckBox.DefaultForeColor

        ''' <summary>
        ''' Gets or sets the color of the border.
        ''' </summary>
        ''' <value>The color of the border.</value>
        Public Property BorderColor As Color = SystemColors.ControlLight

#End Region

#Region " Constructors "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ElektroCheckBox"/> class.
        ''' </summary>
        Public Sub New()

            Me.SuspendLayout()
            Me.SetStyle(ControlStyles.DoubleBuffer, True)
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.ResizeRedraw, True)
            Me.SetStyle(ControlStyles.UserPaint, True)
            Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
            Me.ResumeLayout(performLayout:=False)

        End Sub

#End Region

#Region " Events "

        ''' <summary>
        ''' Raises the <see cref="E:Control.Paint"/> event.
        ''' </summary>
        ''' <param name="e">A <see cref="T:Forms.PaintEventArgs"/> that contains the event data.</param>
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

            MyBase.OnPaint(e)
            Me.DrawCheckBox(e.Graphics, rect:=Me.GetBoxRectangle, drawCheckHot:=False, checkState:=Me.CheckState)

        End Sub

#End Region

#Region " Private Methods"

        ''' <summary>
        ''' Draws the parts of the CheckBox.
        ''' </summary>
        ''' <param name="g">The drawing surface.</param>
        ''' <param name="rect">The drawing rectangle.</param>
        ''' <param name="drawCheckHot">If set to <c>true</c> draws a check hot icon.</param>
        ''' <param name="checkState">The checkbox state.</param>
        Private Sub DrawCheckBox(ByVal g As Graphics,
                                 ByVal rect As Rectangle,
                                 ByVal drawCheckHot As Boolean,
                                 ByVal checkState As CheckState)

            Me.DrawCheckBackground(g, rect)

            If drawCheckHot Then
                Me.DrawCheckHot(g, rect)
            End If

            Me.DrawTick(g, rect, checkState)

        End Sub

        ''' <summary>
        ''' Draws the parts of the CheckBox.
        ''' </summary>
        ''' <param name="g">The drawing surface.</param>
        ''' <param name="rect">The drawing rectangle.</param>
        Private Sub DrawCheckBackground(ByVal g As Graphics,
                                        ByVal rect As Rectangle)

            Using fillBrush As New SolidBrush(Me.BoxColor) ' New LinearGradientBrush(rect, SystemColors.ControlLightLight, SystemColors.ControlDark, LinearGradientMode.ForwardDiagonal)

                ' fillBrush.SetSigmaBellShape(0, 0.5F)

                Using borderPen As New Pen(Me.BorderColor, 1)

                    g.FillRectangle(fillBrush, rect)
                    g.DrawRectangle(borderPen, rect)

                End Using

            End Using

        End Sub

        Private Sub DrawCheckHot(ByVal g As Graphics,
                                 ByVal rect As Rectangle)

            Dim fillBrush As LinearGradientBrush
            Dim hotPen As Pen

            fillBrush = New LinearGradientBrush(rect, SystemColors.ControlLight, SystemColors.ControlDark, LinearGradientMode.ForwardDiagonal)

            Dim relativeIntensities As Single() = {0.0F, 0.7F, 1.0F}
            Dim relativePositions As Single() = {0.0F, 0.5F, 1.0F}

            Dim blend As New Blend
            blend.Factors = relativeIntensities
            blend.Positions = relativePositions
            fillBrush.Blend = blend

            hotPen = New Pen(fillBrush, 1)

            Dim rect1 As New Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2)
            Dim rect2 As New Rectangle(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height - 4)

            g.DrawRectangles(hotPen, New Rectangle() {rect1, rect2})

            fillBrush.Dispose()
            hotPen.Dispose()

        End Sub

        ''' <summary>
        ''' Draws the checkbox tick.
        ''' </summary>
        ''' <param name="g">The drawing surface.</param>
        ''' <param name="rect">The box rectangle.</param>
        ''' <param name="checkState">The checkbox state.</param>
        Private Sub DrawTick(ByVal g As Graphics,
                             ByVal rect As Rectangle,
                             ByVal checkState As CheckState)

            Select Case checkState

                Case checkState.Checked

                    Dim scaleFactor As Single = Convert.ToSingle(rect.Width / 12.0)
                    Dim points As PointF() =
                        New PointF() {
                            New PointF(rect.X + scaleFactor * 3, rect.Y + scaleFactor * 5),
                            New PointF(rect.X + scaleFactor * 5, rect.Y + scaleFactor * 7),
                            New PointF(rect.X + scaleFactor * 9, rect.Y + scaleFactor * 3),
                            New PointF(rect.X + scaleFactor * 9, rect.Y + scaleFactor * 4),
                            New PointF(rect.X + scaleFactor * 5, rect.Y + scaleFactor * 8),
                            New PointF(rect.X + scaleFactor * 3, rect.Y + scaleFactor * 6),
                            New PointF(rect.X + scaleFactor * 3, rect.Y + scaleFactor * 7),
                            New PointF(rect.X + scaleFactor * 5, rect.Y + scaleFactor * 9),
                            New PointF(rect.X + scaleFactor * 9, rect.Y + scaleFactor * 5)
                        }

                    Using checkPen As New Pen(Me.TickColor, 1)
                        g.DrawLines(checkPen, points)
                    End Using

                Case checkState.Indeterminate

                    Using checkBrush As New SolidBrush(Me.TickColor)

                        g.FillRectangle(checkBrush, New Rectangle(rect.X + 3,
                                                                  rect.Y + 3,
                                                                  rect.Width - 5,
                                                                  rect.Height - 5))
                    End Using

                Case checkState.Unchecked
                    ' Do Nothing.

            End Select

        End Sub

        ''' <summary>
        ''' Gets the box rectangle.
        ''' </summary>
        ''' <returns>The box rectangle.</returns>
        Private Function GetBoxRectangle() As Rectangle

            Dim x As Integer = 0
            Dim y As Integer = 2
            Dim width As Integer = 14

            Select Case Me.CheckAlign

                Case ContentAlignment.BottomCenter
                    x = Decimal.ToInt32(Decimal.Floor(New Decimal((Me.Width - width) / 2) - 1))
                    y = Me.Height - width - 2

                Case ContentAlignment.BottomLeft
                    y = Me.Height - width - 2

                Case ContentAlignment.BottomRight
                    x = Me.Width - width - 2
                    y = Me.Height - width - 2

                Case ContentAlignment.MiddleCenter
                    x = Decimal.ToInt32(Decimal.Floor(New Decimal((Me.Width - width) / 2) - 1))
                    y = Decimal.ToInt32(Decimal.Floor(New Decimal((Me.Height - width) / 2) - 1))

                Case ContentAlignment.MiddleLeft
                    y = Decimal.ToInt32(Decimal.Floor(New Decimal((Me.Height - width) / 2) - 1))

                Case ContentAlignment.MiddleRight
                    x = Me.Width - width - 2
                    y = Decimal.ToInt32(Decimal.Floor(New Decimal((Me.Height - width) / 2) - 1))

                Case ContentAlignment.TopCenter
                    x = Decimal.ToInt32(Decimal.Floor(New Decimal((Me.Width - width) / 2) - 1))

                Case ContentAlignment.TopRight
                    x = Me.Width - width - 2

                Case ContentAlignment.TopLeft
                    ' Do Nothing.

            End Select

            Return New Rectangle(x, y, width, width)

        End Function

#End Region

    End Class

End Namespace