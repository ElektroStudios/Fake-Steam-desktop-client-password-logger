' ***********************************************************************
' Author   : Elektro
' Modified : 03-May-2015
' ***********************************************************************
' <copyright file="ElektroTextBox.vb" company="Elektro Studios">
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
Imports System.Runtime.InteropServices

#End Region

Namespace UserControls

    ''' <summary>
    ''' An extended <see cref="TextBox"/> control.
    ''' </summary>
    Public NotInheritable Class ElektroTextBox : Inherits UserControl

#Region " P/Invoke "

        ''' <summary>
        ''' Platform Invocation methods (P/Invoke), access unmanaged code.
        ''' This class suppresses stack walks for unmanaged code permission. 
        ''' <see cref="System.Security.SuppressUnmanagedCodeSecurityAttribute"/> is applied to this class.
        ''' This class is for methods that are safe for anyone to call. 
        ''' Callers of these methods are not required to perform a full security review to make sure that the 
        ''' usage is secure because the methods are harmless for any caller.
        ''' MSDN Documentation: http://msdn.microsoft.com/en-us/library/ms182161.aspx
        ''' </summary>
        Private NotInheritable Class SafeNativeMethods

#Region " Functions "

            ''' <summary>
            ''' Sends the specified message to a window or windows. 
            ''' The <see cref="SendMessage"/> function calls the window procedure for the specified window and 
            ''' does not return until the window procedure has processed the message.
            ''' MSDN Documentation: http://msdn.microsoft.com/en-us/library/windows/desktop/ms644950%28v=vs.85%29.aspx
            ''' </summary>
            ''' <param name="hWnd">A handle to the window whose window procedure will receive the message.</param>
            ''' <param name="msg">The windows message to be sent.</param>
            ''' <param name="wParam">Additional message-specific information.</param>
            ''' <param name="lParam">Additional message-specific information.</param>
            ''' <returns>The result of the message processing; it depends on the message sent.</returns>
            <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=False)>
            Friend Shared Function SendMessage(
                ByVal hWnd As IntPtr,
                ByVal msg As SafeNativeMethods.WindowsMessages,
                ByVal wParam As IntPtr,
                ByVal lParam As IntPtr
            ) As IntPtr
            End Function

#End Region

#Region " Enumerations "

            ''' <summary>
            ''' Specifies a System-Defined Message.
            ''' MSDN Documentation: http://msdn.microsoft.com/en-us/library/windows/desktop/ms644927%28v=vs.85%29.aspx#system_defined
            ''' </summary>
            Friend Enum WindowsMessages As Integer

                ''' <summary>
                ''' Sets the widths of the left and right margins for an edit control. 
                ''' The message redraws the control to reflect the new margins. 
                ''' You can send this message to either an edit control or a rich edit control.
                ''' MSDN Documentation: https://msdn.microsoft.com/en-us/library/windows/desktop/bb761649%28v=vs.85%29.aspx
                ''' </summary>
                EM_SETMARGINS = &HD3UI

                ''' <summary>
                ''' Sets the font that a control is to use when drawing text.
                ''' MSDN Documentation: https://msdn.microsoft.com/en-us/library/windows/desktop/ms632642%28v=vs.85%29.aspx
                ''' </summary>
                WM_SETFONT = &H30

            End Enum

            ''' <summary>
            ''' Specifies additional message-specific information for a System-Defined Message.
            ''' MSDN Documentation: http://msdn.microsoft.com/en-us/library/windows/desktop/ms644927%28v=vs.85%29.aspx#system_defined
            ''' </summary>
            Friend Enum WParams As Integer

                ''' <summary>
                ''' Sets the left margin for an edit control. 
                ''' MSDN Documentation: https://msdn.microsoft.com/en-us/library/windows/desktop/bb761649%28v=vs.85%29.aspx
                ''' </summary>
                EC_LEFTMARGIN = &H3

                ''' <summary>
                ''' Sets the right margin for an edit control. 
                ''' MSDN Documentation: https://msdn.microsoft.com/en-us/library/windows/desktop/bb761649%28v=vs.85%29.aspx
                ''' </summary>
                EC_RIGHTMARGIN = &H2

            End Enum

#End Region

        End Class

#End Region

#Region " Properties "

#Region " Visible "

        ''' <summary>
        ''' Gets the child <see cref="TextBox"/>.
        ''' </summary>
        ''' <value>The child <see cref="TextBox"/>.</value>
        <Browsable(True),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        <Description("The child textbox control.")>
        Public ReadOnly Property TextBox As TextBox
            Get
                Return Me.textbox1
            End Get
        End Property

        ''' <summary>
        ''' The child <see cref="TextBox"/>.
        ''' </summary>
        <Browsable(False),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        <Description("The child textbox control")>
        Private WithEvents textbox1 As New TextBox With
            {
                .BorderStyle = BorderStyle.FixedSingle,
                .Location = New Point(-1, -1),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
            }

        ''' <summary>
        ''' Gets or sets the background color of the control.
        ''' </summary>
        ''' <value>The background color of the control.</value>
        <Browsable(True),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        <Description("The background color of the control.")>
        Public Shadows Property BackColor As Color
            Get
                Return Me.backColor1
            End Get
            Set(ByVal value As Color)
                Me.backColor1 = value
                Me.textbox1.BackColor = value
            End Set
        End Property
        ''' <summary>
        ''' The background color of the control.
        ''' </summary>
        Private backColor1 As Color = SystemColors.Control

        ''' <summary>
        ''' Gets or sets the foreground color of the control.
        ''' </summary>
        ''' <value>The foreground color of the control.</value>
        <Browsable(True),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        <Description("The foreground color of the control.")>
        Public Overrides Property ForeColor As Color
            Get
                Return MyBase.ForeColor
            End Get
            Set(ByVal value As Color)
                MyBase.ForeColor = value
                Me.textbox1.ForeColor = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the font of the text displayed by the control.
        ''' </summary>
        ''' <value>The font.</value>
        <Browsable(True),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overrides Property Font As Font
            Get
                Return MyBase.Font
            End Get
            Set(ByVal value As Font)
                MyBase.Font = value
                Me.textbox1.Font = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the font of the text displayed by the control.
        ''' </summary>
        ''' <value>The font.</value>
        <Browsable(True),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overrides Property Cursor As Cursor
            Get
                Return MyBase.Cursor
            End Get
            Set(ByVal value As Cursor)
                MyBase.Cursor = value
                Me.textbox1.Cursor = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the border color to use when the control is not focused.
        ''' </summary>
        ''' <value>The border color.</value>
        <Browsable(True),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        <Description("The border color to use when the control is not focused.")>
        Public Property BorderColorDefault() As Color
            Get
                Return Me.borderColorDefault1
            End Get
            Set(ByVal value As Color)
                If Me.showBorder1 Then
                    MyBase.BackColor = value
                End If
                Me.borderColorDefault1 = value
            End Set
        End Property
        ''' <summary>
        ''' The border color to use when the control is not focused.
        ''' </summary>
        Private borderColorDefault1 As Color = SystemColors.ControlDark

        ''' <summary>
        ''' Gets or sets the border color to use when the control is focused.
        ''' </summary>
        ''' <value>The border color.</value>
        <Browsable(True),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        <Description("The border color to use when the control is focused.")>
        Public Property BorderColorFocused() As Color
            Get
                Return Me.borderColorFocused1
            End Get
            Set(ByVal value As Color)
                Me.borderColorFocused1 = value
            End Set
        End Property
        ''' <summary>
        ''' The border color to use when the control is focused.
        ''' </summary>
        Private borderColorFocused1 As Color = SystemColors.ControlLight

        ''' <summary>
        ''' Gets or sets a value indicating whether the border is shown.
        ''' </summary>
        ''' <value><c>true</c> if the border is shown; otherwise <c>false</c>.</value>
        <Browsable(True),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        <Description("A value indicating whether the border is shown.")>
        Public Property ShowBorder() As Boolean
            Get
                Return Me.showBorder1
            End Get
            Set(ByVal value As Boolean)
                Me.showBorder1 = value

                Select Case value

                    Case True
                        MyBase.BackColor = Me.borderColorDefault1

                    Case Else
                        MyBase.BackColor = Me.backColor1

                End Select

            End Set
        End Property
        ''' <summary>
        ''' A value indicating whether the border is shown.
        ''' </summary>
        Private showBorder1 As Boolean = True

        ''' <summary>
        ''' Gets or sets the text of the control.
        ''' </summary>
        ''' <value>The text of the control.</value>
        <Browsable(True),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overrides Property Text As String
            Get
                Return MyBase.Text
            End Get
            Set(ByVal value As String)
                MyBase.Text = value
                Me.textbox1.Text = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the text margins of the control.
        ''' </summary>
        ''' <value>The text margins of the control.</value>
        <Browsable(True),
        EditorBrowsable(EditorBrowsableState.Always),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        <Description("The text margins of the control.")>
        Public ReadOnly Property Margins As MarginsLayout
            Get
                Return Me.margins1
            End Get
        End Property
        ''' <summary>
        ''' The text margins of the control.
        ''' </summary>
        Private ReadOnly margins1 As MarginsLayout

#End Region

#Region " Hidden "

        ''' <summary>
        ''' Gets or sets the size of the automatic.
        ''' </summary>
        ''' <value>The size of the automatic.</value>
        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
        Public Shadows Property AutoScroll As Boolean

        ''' <summary>
        ''' Gets or sets the size of the automatic.
        ''' </summary>
        ''' <value>The size of the automatic.</value>
        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
        Public Shadows Property AutoScrollMargin As Size

        ''' <summary>
        ''' Gets or sets the size of the automatic.
        ''' </summary>
        ''' <value>The size of the automatic.</value>
        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
        Public Shadows Property AutoScrollMinSize As Size

        ''' <summary>
        ''' Gets or sets the size of the automatic.
        ''' </summary>
        ''' <value>The size of the automatic.</value>
        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
        Public Shadows Property AutoSize As Size

        ''' <summary>
        ''' Gets or sets how the control will resize itself.
        ''' </summary>
        ''' <value>The automatic size mode.</value>
        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
        Public Shadows Property AutoSizeMode As AutoSizeMode

        ''' <summary>
        ''' Gets or sets the background image displayed in the control.
        ''' </summary>
        ''' <value>The background image.</value>
        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
        Public Shadows Property BackgroundImage As Image

        ''' <summary>
        ''' Gets or sets the background image layout as defined in the <see cref="T:System.Windows.Forms.ImageLayout"/> enumeration.
        ''' </summary>
        ''' <value>The background image layout.</value>
        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
        Public Shadows Property BackgroundImageLayout As ImageLayout

        ''' <summary>
        ''' Gets or sets the border style of the user control.
        ''' </summary>
        ''' <value>The border style.</value>
        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
        Public Shadows Property BorderStyle As BorderStyle

        ''' <summary>
        ''' Gets or sets the space between controls.
        ''' </summary>
        ''' <value>The margin.</value>
        <Browsable(False),
        EditorBrowsable(EditorBrowsableState.Never)>
        Public Shadows Property Margin As Padding

        ''' <summary>
        ''' Gets or sets padding within the control.
        ''' </summary>
        ''' <value>The padding.</value>
        <Browsable(False),
        EditorBrowsable(EditorBrowsableState.Never)>
        Public Shadows Property Padding As Padding

        ''' <summary>
        ''' Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.
        ''' </summary>
        ''' <value>The right to left.</value>
        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
        Public Shadows Property RightToLeft As RightToLeft

#End Region

#End Region

#Region " Types "

        ''' <summary>
        ''' The Margins Component layout.
        ''' </summary>
        <ToolboxItem(False)>
        Public NotInheritable Class MarginsLayout : Inherits Component

            ''' <summary>
            ''' Initializes a new instance of the <see cref="MarginsLayout"/> class.
            ''' </summary>
            ''' <param name="instance">The <see cref="ElektroTextBox"/> instance.</param>
            Public Sub New(ByVal instance As ElektroTextBox)
                Me.instance1 = instance
            End Sub

            ''' <summary>
            ''' Gets the <see cref="ElektroTextBox"/> instance.
            ''' </summary>
            ''' <value>The <see cref="ElektroTextBox"/> instance.</value>
            <Browsable(False)>
            Public ReadOnly Property Instance() As ElektroTextBox
                Get
                    Return Me.instance1
                End Get
            End Property
            ''' <summary>
            ''' The <see cref="ElektroTextBox"/> instance.
            ''' </summary>
            Private ReadOnly instance1 As ElektroTextBox

            ''' <summary>
            ''' Gets or sets the left margin.
            ''' </summary>
            ''' <value>The left margin.</value>
            <Description("The left margin.")>
            Public Property Left As Integer
                Get
                    Return Me.left1
                End Get
                Set(ByVal value As Integer)
                    If (value <> Me.left1) Then
                        Me.left1 = value
                    End If
                End Set
            End Property
            ''' <summary>
            ''' The left margin.
            ''' </summary>
            Private left1 As Integer

            ''' <summary>
            ''' Gets or sets the right margin.
            ''' </summary>
            ''' <value>The right margin.</value>
            <Description("The right margin.")>
            Public Property Right As Integer
                Get
                    Return Me.right1
                End Get
                Set(ByVal value As Integer)
                    If (value <> Me.right1) Then
                        Me.right1 = value
                    End If
                End Set
            End Property
            ''' <summary>
            ''' The right margin.
            ''' </summary>
            Private right1 As Integer

        End Class

#End Region

#Region " Constructors "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="ElektroTextBox"/> class.
        ''' </summary>
        Public Sub New()

            Me.SuspendLayout()

            Me.margins1 = New MarginsLayout(Me)

            With Me.textbox1
                .BorderStyle = BorderStyle.FixedSingle
                .Location = New Point(-1, -1)
                .Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
            End With

            Dim container As New ContainerControl With
                {
                 .Dock = DockStyle.Fill,
                 .Padding = New Padding(-1)
                }

            container.Controls.Add(Me.textbox1)
            Me.Controls.Add(container)

            MyBase.Padding = New Padding(1)
            MyBase.Size = Me.textbox1.Size

            Me.ResumeLayout(performLayout:=False)

        End Sub

#End Region

#Region " Events "

        ''' <summary>
        ''' Raises the <see cref="E:System.Windows.Forms.UserControl.Load"/> event.
        ''' </summary>
        ''' <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        Protected Overrides Sub OnLoad(e As EventArgs)

            If Me.showBorder1 Then
                MyBase.BackColor = Me.borderColorDefault1
            End If

            Me.SetTextMargins()

            MyBase.OnLoad(e)

        End Sub

        ''' <summary>
        ''' Raises the <see cref="E:System.Windows.Forms.Control.Enter"/> event.
        ''' </summary>
        ''' <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        Protected Overrides Sub OnEnter(ByVal e As EventArgs)

            If Me.showBorder1 Then
                MyBase.BackColor = Me.borderColorFocused1
            End If

            MyBase.OnEnter(e)

        End Sub

        ''' <summary>
        ''' Raises the <see cref="E:System.Windows.Forms.Control.Leave"/> event.
        ''' </summary>
        ''' <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        Protected Overrides Sub OnLeave(ByVal e As EventArgs)

            If Me.showBorder1 Then
                MyBase.BackColor = Me.borderColorDefault1
            End If

            MyBase.OnLeave(e)

        End Sub

        ''' <summary>
        ''' Performs the work of setting the specified bounds of this control.
        ''' </summary>
        ''' <param name="x">The new <see cref="P:System.Windows.Forms.Control.Left"/> property value of the control.</param>
        ''' <param name="y">The new <see cref="P:System.Windows.Forms.Control.Top"/> property value of the control.</param>
        ''' <param name="width">The new <see cref="P:System.Windows.Forms.Control.Width"/> property value of the control.</param>
        ''' <param name="height">The new <see cref="P:System.Windows.Forms.Control.Height"/> property value of the control.</param>
        ''' <param name="specified">A bitwise combination of the <see cref="T:System.Windows.Forms.BoundsSpecified"/> values.</param>
        Protected Overrides Sub SetBoundsCore(ByVal x As Integer,
                                              ByVal y As Integer,
                                              ByVal width As Integer,
                                              ByVal height As Integer,
                                              ByVal specified As BoundsSpecified)

            MyBase.SetBoundsCore(x, y, width, Me.textbox1.PreferredHeight, specified)

        End Sub

#End Region

#Region " Private Methods "

        ''' <summary>
        ''' Invokes the default window procedure associated with this window to process messages.
        ''' </summary>
        ''' <param name="m">
        ''' A <see cref="T:System.Windows.Forms.Message"/> that is associated with the current Windows message.
        ''' </param>
        Protected Overrides Sub WndProc(ByRef m As Message)

            Select Case m.Msg
                Case SafeNativeMethods.WindowsMessages.WM_SETFONT
                    Me.SetTextMargins()
                    Return
            End Select

            MyBase.WndProc(m)

        End Sub

        ''' <summary>
        ''' Sets the left and right margins of the text area.
        ''' </summary>
        Private Sub SetTextMargins()

            SafeNativeMethods.SendMessage(Me.textbox1.Handle,
                                          SafeNativeMethods.WindowsMessages.EM_SETMARGINS,
                                          New IntPtr(SafeNativeMethods.WParams.EC_LEFTMARGIN),
                                          New IntPtr(Me.Margins.Left))

            SafeNativeMethods.SendMessage(Me.textbox1.Handle,
                                          SafeNativeMethods.WindowsMessages.EM_SETMARGINS,
                                          New IntPtr(SafeNativeMethods.WParams.EC_RIGHTMARGIN),
                                          New IntPtr((100 + Me.Margins.Right) << 16))

        End Sub

#End Region

    End Class

End Namespace