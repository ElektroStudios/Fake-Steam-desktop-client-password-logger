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

Imports System.ComponentModel

#End Region

Namespace UserControls

    ''' <summary>
    ''' An extended <see cref="PictureBox"/> control.
    ''' </summary>
    Public NotInheritable Class ElektroPictureBox : Inherits PictureBox

#Region " Properties "

        ''' <summary>
        ''' Gets or sets a value that indicates the index in the TAB order that this control will occupy.
        ''' </summary>
        ''' <value>A value that indicates the index in the TAB order that this control will occupy.</value>
        <Browsable(True),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        <Description("Determines the index in the TAB order that this control will occupy.")>
        Public Shadows Property TabIndex As Integer
            Get
                Return MyBase.TabIndex
            End Get
            Set(ByVal value As Integer)
                MyBase.TabIndex = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets a value that indicates whether the user can give the focus to this control by using the TAB key.
        ''' </summary>
        ''' <value><c>true</c> if tabstop is enabled; <c>false</c> otherwise.</value>
        ''' <PermissionSet>
        '''   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        '''   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        '''   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        '''   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ''' </PermissionSet>
        <Browsable(True),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        <Description("Indicates whether the user can use the TAB key to give focus to the control.")>
        Public Shadows Property TabStop As Boolean
            Get
                Return MyBase.TabStop
            End Get
            Set(ByVal value As Boolean)
                MyBase.TabStop = value
            End Set
        End Property

#End Region

#Region " Constructors "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ElektroPictureBox"/> class.
        ''' </summary>
        Public Sub New()

            Me.SuspendLayout()
            Me.SetStyle(ControlStyles.Selectable, True)
            Me.TabStop = True
            Me.ResumeLayout(performLayout:=False)

        End Sub

#End Region

#Region " Events "

        ''' <summary>
        ''' Raises the <see cref="E:Control.MouseDown"/> event.
        ''' </summary>
        ''' <param name="e">A <see cref="T:Forms.MouseEventArgs"/> that contains the event data.</param>
        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)

            Me.Focus()
            MyBase.OnMouseDown(e)

        End Sub

        ''' <summary>
        ''' Raises the <see cref="E:Control.Enter"/> event.
        ''' </summary>
        ''' <param name="e">An <see cref="T:EventArgs"/> that contains the event data.</param>
        Protected Overrides Sub OnEnter(ByVal e As EventArgs)

            Me.Invalidate()
            MyBase.OnEnter(e)

        End Sub

        ''' <summary>
        ''' Raises the <see cref="E:Control.Leave"/> event.
        ''' </summary>
        ''' <param name="e">An <see cref="T:EventArgs"/> that contains the event data.</param>
        Protected Overrides Sub OnLeave(ByVal e As EventArgs)

            Me.Invalidate()
            MyBase.OnLeave(e)

        End Sub

        ''' <summary>
        ''' Raises the <see cref="E:Control.Paint"/> event.
        ''' </summary>
        ''' <param name="pe">A <see cref="T:Forms.PaintEventArgs"/> that contains the event data.</param>
        Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)

            MyBase.OnPaint(pe)
            If Me.Focused Then
                Dim rc As Rectangle = Me.ClientRectangle
                rc.Inflate(-2, -2)
                ControlPaint.DrawFocusRectangle(pe.Graphics, rc)
            End If

        End Sub

#End Region

#Region " Events "

        ''' <summary>
        ''' Generates a <see cref="E:Control.Click"/> event for this control.
        ''' </summary>
        Public Sub PerformClick()

            MyBase.InvokeOnClick(Me, Nothing)

        End Sub

        ' ''' <summary>
        ' ''' Generates a <see cref="E:Control.Click"/> event for this control.
        ' ''' </summary>
        ' ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        'Private Sub PerformClick(ByVal e As EventArgs)

        '    MyBase.InvokeOnClick(Me, e)

        'End Sub

        ' ''' <summary>
        ' ''' Raises the <see cref="E:System.Windows.Forms.Control.KeyDown" /> event.
        ' ''' </summary>
        ' ''' <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        'Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)

        '    If e.KeyCode = Keys.Enter Then
        '        Me.PerformClick(e)
        '    End If

        '    MyBase.OnKeyDown(e)

        'End Sub

#End Region

    End Class

End Namespace