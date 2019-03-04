' ***********************************************************************
' Author   : Elektro
' Modified : 15-March-2015
' ***********************************************************************
' <copyright file="FormDragger.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Option Statements "

Option Explicit On
Option Strict On
Option Infer Off

#End Region

#Region " Usage Examples "

'Public Class Form1

'    ''' <summary>
'    ''' The <see cref="FormDragger"/> instance that manages the form(s) dragging.
'    ''' </summary>
'    Private formDragger As FormDragger = FormDragger.Empty

'    Private Sub Test() Handles MyBase.Shown
'        Me.InitializeDrag()
'    End Sub

'    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
'    Handles Button1.Click

'        Me.AlternateDragEnabled(Me)

'    End Sub

'    Private Sub InitializeDrag()

'        ' 1st way, using the single-Form constructor:
'        Me.formDragger = New FormDragger(Me, enabled:=True, cursor:=Cursors.SizeAll)

'        ' 2nd way, using the multiple-Forms constructor:
'        ' Me.formDragger = New FormDragger({Me, Form2, form3})

'        ' 3rd way, using the default constructor then adding a Form into the collection:
'        ' Me.formDragger = New FormDragger
'        ' Me.formDragger.AddForm(Me, enabled:=True, cursor:=Cursors.SizeAll)

'    End Sub

'    ''' <summary>
'    ''' Alternates the dragging of the specified form.
'    ''' </summary>
'    ''' <param name="form">The form.</param>
'    Private Sub AlternateDragEnabled(ByVal form As Form)

'        Dim formInfo As FormDragger.FormDragInfo = Me.formDragger.FindFormDragInfo(form)
'        formInfo.Enabled = Not formInfo.Enabled

'    End Sub

'End Class

#End Region

#Region " Imports "

Imports System.ComponentModel

#End Region

#Region " Form Dragger "

Namespace Tools

    ''' <summary>
    ''' Enable or disable drag at runtime on a <see cref="Form"/>.
    ''' </summary>
    Public NotInheritable Class FormDragger : Implements IDisposable

#Region " Properties "

        ''' <summary>
        ''' Gets an <see cref="IEnumerable(Of Form)"/> collection that contains the Forms capables to perform draggable operations.
        ''' </summary>
        ''' <value>The <see cref="IEnumerable(Of Form)"/>.</value>
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public ReadOnly Property Forms As IEnumerable(Of FormDragInfo)
            Get
                Return Me.forms1
            End Get
        End Property
        ''' <summary>
        ''' An <see cref="IEnumerable(Of Form)"/> collection that contains the Forms capables to perform draggable operations.
        ''' </summary>
        Private forms1 As IEnumerable(Of FormDragInfo) = {}

        ''' <summary>
        ''' Represents a <see cref="FormDragger"/> instance that is <c>Nothing</c>.
        ''' </summary>
        ''' <value><c>Nothing</c></value>
        <EditorBrowsable(EditorBrowsableState.Always)>
        Public Shared ReadOnly Property Empty As FormDragger
            Get
                Return Nothing
            End Get
        End Property

#End Region

#Region " Types "

        ''' <summary>
        ''' Defines the draggable info of a <see cref="Form"/>.
        ''' </summary>
        <Serializable>
        Public NotInheritable Class FormDragInfo

#Region " Properties "

            ''' <summary>
            ''' Gets the associated <see cref="Form"/> used to perform draggable operations.
            ''' </summary>
            ''' <value>The associated <see cref="Form"/>.</value>
            <EditorBrowsable(EditorBrowsableState.Always)>
            Public ReadOnly Property Form As Form
                Get
                    Return form1
                End Get
            End Property
            ''' <summary>
            ''' The associated <see cref="Form"/>
            ''' </summary>
            <NonSerialized>
            Private ReadOnly form1 As Form

            ''' <summary>
            ''' Gets the name of the associated <see cref="Form"/>.
            ''' </summary>
            ''' <value>The Form.</value>
            <EditorBrowsable(EditorBrowsableState.Always)>
            Public ReadOnly Property Name As String
                Get
                    If Me.Form IsNot Nothing Then
                        Return Form.Name
                    Else
                        Return String.Empty
                    End If
                End Get
            End Property

            ''' <summary>
            ''' Gets or sets a value indicating whether drag is enabled on the associated <see cref="Form"/>.
            ''' </summary>
            ''' <value><c>true</c> if drag is enabled; otherwise, <c>false</c>.</value>
            <EditorBrowsable(EditorBrowsableState.Always)>
            Public Property Enabled As Boolean

            ''' <summary>
            ''' A <see cref="FormDragger"/> instance instance containing the draggable information of the associated <see cref="Form"/>.
            ''' </summary>
            ''' <value>The draggable information.</value>
            <EditorBrowsable(EditorBrowsableState.Never)>
            Public Property DragInfo As FormDragger = FormDragger.Empty

            ''' <summary>
            ''' Gets or sets the <see cref="Cursor"/> used to drag the associated <see cref="Form"/>.
            ''' </summary>
            ''' <value>The <see cref="Cursor"/>.</value>
            <EditorBrowsable(EditorBrowsableState.Always)>
            Public Property Cursor As Cursor = Cursors.SizeAll

            ''' <summary>
            ''' Gets or sets the old form's cursor to restore it after dragging.
            ''' </summary>
            ''' <value>The old form's cursor.</value>
            <EditorBrowsable(EditorBrowsableState.Never)>
            Public Property OldCursor As Cursor = Nothing

            ''' <summary>
            ''' Gets or sets the initial mouse coordinates, normally <see cref="Form.MousePosition"/>.
            ''' </summary>
            ''' <value>The initial mouse coordinates.</value>
            <EditorBrowsable(EditorBrowsableState.Never)>
            Public Property InitialMouseCoords As Point = Point.Empty

            ''' <summary>
            ''' Gets or sets the initial <see cref="Form"/> location, normally <see cref="Form.Location"/>.
            ''' </summary>
            ''' <value>The initial location.</value>
            <EditorBrowsable(EditorBrowsableState.Never)>
            Public Property InitialLocation As Point = Point.Empty

#End Region

#Region " Constructors "

            ''' <summary>
            ''' Initializes a new instance of the <see cref="FormDragInfo"/> class.
            ''' </summary>
            ''' <param name="form">The form.</param>
            Public Sub New(ByVal form As Form)
                Me.form1 = form
                Me.Cursor = form.Cursor
            End Sub

            ''' <summary>
            ''' Prevents a default instance of the <see cref="FormDragInfo"/> class from being created.
            ''' </summary>
            Private Sub New()
            End Sub

#End Region

#Region " Hidden Methods "

            ''' <summary>
            ''' Serves as a hash function for a particular type.
            ''' </summary>
            <EditorBrowsable(EditorBrowsableState.Never)>
            Public Shadows Function GetHashCode() As Integer
                Return MyBase.GetHashCode
            End Function

            ''' <summary>
            ''' Gets the System.Type of the current instance.
            ''' </summary>
            ''' <returns>The exact runtime type of the current instance.</returns>
            <EditorBrowsable(EditorBrowsableState.Never)>
            Public Shadows Function [GetType]() As Type
                Return MyBase.GetType
            End Function

            ''' <summary>
            ''' Determines whether the specified System.Object instances are considered equal.
            ''' </summary>
            <EditorBrowsable(EditorBrowsableState.Never)>
            Public Shadows Function Equals(ByVal obj As Object) As Boolean
                Return MyBase.Equals(obj)
            End Function

            ''' <summary>
            ''' Determines whether the specified System.Object instances are the same instance.
            ''' </summary>
            <EditorBrowsable(EditorBrowsableState.Never)>
            Private Shadows Sub ReferenceEquals()
            End Sub

            ''' <summary>
            ''' Returns a String that represents the current object.
            ''' </summary>
            <EditorBrowsable(EditorBrowsableState.Never)>
            Public Shadows Function ToString() As String
                Return MyBase.ToString
            End Function

#End Region

        End Class

#End Region

#Region " Constructors "

        ''' <summary>
        ''' Initializes a new instance of the <see cref="FormDragger"/> class.
        ''' </summary>
        Public Sub New()
            Me.forms1 = {}
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="FormDragger"/> class.
        ''' </summary>
        ''' <param name="form">The <see cref="Form"/> used to perform draggable operations.</param>
        ''' <param name="enabled">If set to <c>true</c>, enable dragging on the <see cref="Form"/>.</param>
        ''' <param name="cursor">The <see cref="Cursor"/> used to drag the specified <see cref="Form"/>.</param>
        Public Sub New(ByVal form As Form,
                       Optional enabled As Boolean = False,
                       Optional cursor As Cursor = Nothing)

            Me.forms1 =
                {
                    New FormDragInfo(form) With
                             {
                                 .Enabled = enabled,
                                 .Cursor = cursor
                             }
                }

            Me.AssocHandlers(form)

        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="FormDragger"/> class.
        ''' </summary>
        ''' <param name="forms">The <see cref="Forms"/> used to perform draggable operations.</param>
        Public Sub New(ByVal forms As IEnumerable(Of Form))

            Me.forms1 = (From form As Form In forms
                         Select New FormDragInfo(form)).ToArray

            For Each form As Form In forms
                Me.AssocHandlers(form)
            Next form

        End Sub

        ''' <summary>
        ''' Initializes a new instance of the <see cref="FormDragger"/> class.
        ''' </summary>
        ''' <param name="formInfo">
        ''' The <see cref="FormDragInfo"/> instance 
        ''' that contains the <see cref="Form"/> reference and its draggable info.
        ''' </param>
        ''' <param name="mouseCoordinates">The current mouse coordinates.</param>
        ''' <param name="location">The current location.</param>
        Private Sub New(ByVal formInfo As FormDragInfo,
                        ByVal mouseCoordinates As Point,
                        ByVal location As Point)

            formInfo.InitialMouseCoords = mouseCoordinates
            formInfo.InitialLocation = location

        End Sub

#End Region

#Region " Public Methods "

        ''' <summary>
        ''' Adds the specified <see cref="Form"/> into the draggable <see cref="Forms"/> collection.
        ''' </summary>
        ''' <param name="form">The <see cref="Form"/>.</param>
        ''' <param name="enabled">If set to <c>true</c>, enable dragging on the <see cref="Form"/>.</param>
        ''' <param name="cursor">The <see cref="Cursor"/> used to drag the specified <see cref="Form"/>.</param>
        ''' <exception cref="System.ArgumentException">The specified form is already added.;form</exception>
        Public Function AddForm(ByVal form As Form,
                                Optional enabled As Boolean = False,
                                Optional cursor As Cursor = Nothing) As FormDragInfo

            For Each formInfo As FormDragInfo In Me.forms1

                If formInfo.Form.Equals(form) Then
                    Throw New ArgumentException("The specified form is already added.", "form")
                    Exit Function
                End If

            Next formInfo

            Dim newFormInfo As New FormDragInfo(form) With {.Enabled = enabled, .Cursor = cursor}
            Me.forms1 = Me.forms1.Concat({newFormInfo})
            Me.AssocHandlers(form)

            Return newFormInfo

        End Function

        ''' <summary>
        ''' Removes the specified <see cref="Form"/> from the draggable <see cref="Forms"/> collection.
        ''' </summary>
        ''' <param name="form">The form.</param>
        ''' <exception cref="System.ArgumentException">The specified form is not found.;form</exception>
        Public Sub RemoveForm(ByVal form As Form)

            Dim formInfoToRemove As FormDragInfo = Nothing

            For Each formInfo As FormDragInfo In Me.forms1

                If formInfo.Form.Equals(form) Then
                    formInfoToRemove = formInfo
                    Exit For
                End If

            Next formInfo

            If formInfoToRemove IsNot Nothing Then

                Me.forms1 = From formInfo As FormDragInfo In Me.forms1
                            Where Not formInfo Is formInfoToRemove

                formInfoToRemove.Enabled = False
                Me.DeassocHandlers(formInfoToRemove.Form)

            Else
                Throw New ArgumentException("The specified form is not found.", "form")

            End If

        End Sub

        ''' <summary>
        ''' Finds the <see cref="FormDragInfo"/> instance that is associated with the specified <see cref="Form"/> reference.
        ''' </summary>
        ''' <param name="form">The <see cref="Form"/>.</param>
        ''' <returns>The <see cref="FormDragInfo"/> instance that is associated with the specified <see cref="Form"/> reference.</returns>
        Public Function FindFormDragInfo(ByVal form As Form) As FormDragInfo

            Return (From formInfo As FormDragger.FormDragInfo In Me.forms1
                    Where formInfo.Form Is form).FirstOrDefault

        End Function

        ''' <summary>
        ''' Finds the <see cref="FormDragInfo"/> instance that is associated with the specified <see cref="Form"/> reference.
        ''' </summary>
        ''' <param name="name">The <see cref="Form"/> name.</param>
        ''' <returns>The <see cref="FormDragInfo"/> instance that is associated with the specified <see cref="Form"/> reference.</returns>
        Public Function FindFormDragInfo(ByVal name As String,
                                         Optional stringComparison As StringComparison =
                                                  StringComparison.OrdinalIgnoreCase) As FormDragInfo

            Return (From formInfo As FormDragger.FormDragInfo In Me.forms1
                    Where formInfo.Name.Equals(name, stringComparison)).FirstOrDefault

        End Function

#End Region

#Region " Private Methods "

        ''' <summary>
        ''' Associates the <see cref="Form"/> handlers to enable draggable operations.
        ''' </summary>
        ''' <param name="form">The form.</param>
        Private Sub AssocHandlers(ByVal form As Form)

            AddHandler form.MouseDown, AddressOf Me.Form_MouseDown
            AddHandler form.MouseUp, AddressOf Me.Form_MouseUp
            AddHandler form.MouseMove, AddressOf Me.Form_MouseMove
            AddHandler form.MouseEnter, AddressOf Me.Form_MouseEnter
            AddHandler form.MouseLeave, AddressOf Me.Form_MouseLeave

        End Sub

        ''' <summary>
        ''' Deassociates the <see cref="Form"/> handlers to disable draggable operations.
        ''' </summary>
        ''' <param name="form">The form.</param>
        Private Sub DeassocHandlers(ByVal form As Form)

            If Not form.IsDisposed AndAlso Not form.Disposing Then

                RemoveHandler form.MouseDown, AddressOf Me.Form_MouseDown
                RemoveHandler form.MouseUp, AddressOf Me.Form_MouseUp
                RemoveHandler form.MouseMove, AddressOf Me.Form_MouseMove
                RemoveHandler form.MouseEnter, AddressOf Me.Form_MouseEnter
                RemoveHandler form.MouseLeave, AddressOf Me.Form_MouseLeave

            End If

        End Sub

        ''' <summary>
        ''' Return the new location.
        ''' </summary>
        ''' <param name="formInfo">
        ''' The <see cref="FormDragInfo"/> instance 
        ''' that contains the <see cref="Form"/> reference and its draggable info.
        ''' </param>
        ''' <param name="mouseCoordinates">The current mouse coordinates.</param>
        ''' <returns>The new location.</returns>
        Private Function GetNewLocation(ByVal formInfo As FormDragInfo,
                                        ByVal mouseCoordinates As Point) As Point

            Return New Point(formInfo.InitialLocation.X + (mouseCoordinates.X - formInfo.InitialMouseCoords.X),
                             formInfo.InitialLocation.Y + (mouseCoordinates.Y - formInfo.InitialMouseCoords.Y))

        End Function

#End Region

#Region " Hidden Methods "

        ''' <summary>
        ''' Serves as a hash function for a particular type.
        ''' </summary>
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public Shadows Function GetHashCode() As Integer
            Return MyBase.GetHashCode
        End Function

        ''' <summary>
        ''' Gets the System.Type of the current instance.
        ''' </summary>
        ''' <returns>The exact runtime type of the current instance.</returns>
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public Shadows Function [GetType]() As Type
            Return MyBase.GetType
        End Function

        ''' <summary>
        ''' Determines whether the specified System.Object instances are considered equal.
        ''' </summary>
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public Shadows Function Equals(ByVal obj As Object) As Boolean
            Return MyBase.Equals(obj)
        End Function

        ''' <summary>
        ''' Determines whether the specified System.Object instances are the same instance.
        ''' </summary>
        <EditorBrowsable(EditorBrowsableState.Never)>
        Private Shadows Sub ReferenceEquals()
        End Sub

        ''' <summary>
        ''' Returns a String that represents the current object.
        ''' </summary>
        <EditorBrowsable(EditorBrowsableState.Never)>
        Public Shadows Function ToString() As String
            Return MyBase.ToString
        End Function

#End Region

#Region " Event Handlers "

        ''' <summary>
        ''' Handles the MouseEnter event of the Form.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub Form_MouseEnter(ByVal sender As Object, ByVal e As EventArgs)

            Dim formInfo As FormDragInfo = FindFormDragInfo(DirectCast(sender, Form))

            formInfo.OldCursor = formInfo.Form.Cursor

            If formInfo.Enabled Then
                formInfo.Form.Cursor = formInfo.Cursor
                ' Optional:
                ' formInfo.Form.BringToFront() 
            End If

        End Sub

        ''' <summary>
        ''' Handles the MouseLeave event of the Form.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        Private Sub Form_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)

            Dim formInfo As FormDragInfo = FindFormDragInfo(DirectCast(sender, Form))

            formInfo.Form.Cursor = formInfo.OldCursor

        End Sub

        ''' <summary>
        ''' Handles the MouseDown event of the Form.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        Private Sub Form_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)

            Dim formInfo As FormDragInfo = FindFormDragInfo(DirectCast(sender, Form))

            If formInfo.Enabled Then
                formInfo.DragInfo = New FormDragger(formInfo, Form.MousePosition, formInfo.Form.Location)
            End If

        End Sub

        ''' <summary>
        ''' Handles the MouseMove event of the Form.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        Private Sub Form_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)

            Dim formInfo As FormDragInfo = FindFormDragInfo(DirectCast(sender, Form))

            If formInfo.Enabled AndAlso (formInfo.DragInfo IsNot FormDragger.Empty) Then
                formInfo.Form.Location = formInfo.DragInfo.GetNewLocation(formInfo, Form.MousePosition)
            End If

        End Sub

        ''' <summary>
        ''' Handles the MouseUp event of the Form.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        Private Sub Form_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)

            Dim formInfo As FormDragInfo = FindFormDragInfo(DirectCast(sender, Form))

            formInfo.DragInfo = FormDragger.Empty

        End Sub

#End Region

#Region " IDisposable "

        ''' <summary>
        ''' To detect redundant calls when disposing.
        ''' </summary>
        Private isDisposed As Boolean = False

        ''' <summary>
        ''' Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        ''' </summary>
        Public Sub Dispose() Implements IDisposable.Dispose
            Me.Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

        ''' <summary>
        ''' Releases unmanaged and - optionally - managed resources.
        ''' </summary>
        ''' <param name="IsDisposing">
        ''' <c>true</c> to release both managed and unmanaged resources; 
        ''' <c>false</c> to release only unmanaged resources.
        ''' </param>
        Protected Sub Dispose(ByVal isDisposing As Boolean)

            If Not Me.isDisposed Then

                If isDisposing Then

                    For Each formInfo As FormDragInfo In Me.forms1

                        With formInfo

                            .Enabled = False
                            .OldCursor = Nothing
                            .DragInfo = FormDragger.Empty
                            .InitialMouseCoords = Point.Empty
                            .InitialLocation = Point.Empty

                            Me.DeassocHandlers(.Form)

                        End With ' form

                    Next formInfo

                    Me.forms1 = Nothing

                End If ' IsDisposing

            End If ' Not Me.IsDisposed

            Me.isDisposed = True

        End Sub

#End Region

    End Class

End Namespace

#End Region