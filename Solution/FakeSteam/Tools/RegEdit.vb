' ***********************************************************************
' Author   : Elektro
' Modified : 03-May-2015
' ***********************************************************************
' <copyright file="RegEdit.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************



' #########################################################################
'
'    THIS CLASS IS PARTIALLY DEFINED TO MEET THE NEEDS OF THIS PROJECT.
'
' #########################################################################



#Region " Option Statements "

Option Explicit On
Option Strict On
Option Infer Off

#End Region

#Region " Imports "

Imports Microsoft.Win32

#End Region

#Region " RegEdit "

Namespace Tools

    ''' <summary>
    ''' Contains related registry tools.
    ''' </summary>
    Public NotInheritable Class RegEdit

#Region " Public Methods "

#Region " Get ValueData "

        ''' <summary>
        ''' Gets the data of a registry value.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="rootKeyName">The rootkey name.</param>
        ''' <param name="subKeyPath">The subkey path.</param>
        ''' <param name="valueName">The value name.</param>
        ''' <param name="registryValueOptions">The registry value options.</param>
        ''' <returns>The value data</returns>
        ''' <exception cref="System.ArgumentNullException">rootKeyName or subKeyPath</exception>
        Public Shared Function GetValueData(Of T)(ByVal rootKeyName As String,
                                                  ByVal subKeyPath As String,
                                                  ByVal valueName As String,
                                                  Optional ByVal registryValueOptions As RegistryValueOptions =
                                                                 RegistryValueOptions.None) As T

            If String.IsNullOrEmpty(rootKeyName) OrElse String.IsNullOrWhiteSpace(rootKeyName) Then
                Throw New ArgumentNullException("rootKeyName")

            ElseIf String.IsNullOrEmpty(subKeyPath) OrElse String.IsNullOrWhiteSpace(subKeyPath) Then
                Throw New ArgumentNullException("subKeyPath")

            Else
                Dim reg As RegistryKey = Nothing
                Try
                    reg = GetRootKey(rootKeyName)
                    Using reg
                        Return DirectCast(reg.OpenSubKey(GetSubKeyPath(subKeyPath), writable:=False).
                                              GetValue(valueName, defaultValue:=Nothing, options:=registryValueOptions), T)
                    End Using

                Catch ex As Exception
                    Throw

                End Try

            End If

        End Function

        ''' <summary>
        ''' Gets the data of a registry value.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="fullKeyPath">The registry key full path.</param>
        ''' <param name="valueName">The value name.</param>
        ''' <param name="registryValueOptions">The registry value options.</param>
        ''' <returns>The value data</returns>
        Public Shared Function GetValueData(Of T)(ByVal fullKeyPath As String,
                                                  ByVal valueName As String,
                                                  Optional ByVal registryValueOptions As RegistryValueOptions =
                                                                 RegistryValueOptions.None) As T

            Return GetValueData(Of T)(GetRootKeyName(fullKeyPath), GetSubKeyPath(fullKeyPath), valueName, registryValueOptions)

        End Function

#End Region

#Region " Exists ? "

        ''' <summary>
        ''' Determines whether a registry subkey exists.
        ''' </summary>
        ''' <param name="rootKeyName">The rootkey name.</param>
        ''' <param name="subKeyPath">The subkey path.</param>
        ''' <returns><c>true</c> if subkey exist, <c>false</c> otherwise.</returns>
        ''' <exception cref="System.ArgumentNullException">rootKeyName or subKeyPath</exception>
        Public Shared Function ExistSubKey(ByVal rootKeyName As String,
                                           ByVal subKeyPath As String) As Boolean

            If String.IsNullOrEmpty(rootKeyName) OrElse String.IsNullOrWhiteSpace(rootKeyName) Then
                Throw New ArgumentNullException("rootKeyName")

            ElseIf String.IsNullOrEmpty(subKeyPath) OrElse String.IsNullOrWhiteSpace(subKeyPath) Then
                Throw New ArgumentNullException("subKeyPath")

            Else
                Dim reg As RegistryKey = Nothing
                Try
                    reg = GetRootKey(rootKeyName)
                    Using reg
                        Return reg.OpenSubKey(GetSubKeyPath(subKeyPath), writable:=False) IsNot Nothing
                    End Using

                Catch ex As Exception
                    Throw

                End Try
            End If

        End Function

        ''' <summary>
        ''' Determines whether a registry subkey exists.
        ''' </summary>
        ''' <param name="fullKeyPath">The registry key full path.</param>
        ''' <returns><c>true</c> if subkey exist, <c>false</c> otherwise.</returns>
        Public Shared Function ExistSubKey(ByVal fullKeyPath As String) As Boolean

            Return ExistSubKey(GetRootKeyName(fullKeyPath), GetSubKeyPath(fullKeyPath))

        End Function

#End Region

#Region " Registry Path Formatting "

        ''' <summary>
        ''' Gets the root <see cref="RegistryKey"/> of a registry path.
        ''' </summary>
        ''' <returns>The root <see cref="RegistryKey"/> of a registry path.</returns>
        Public Shared Function GetRootKey(ByVal registryPath As String) As RegistryKey

            Select Case registryPath.ToUpper.Split("\"c).First

                Case "HKCR", "HKEY_CLASSES_ROOT"
                    Return Registry.ClassesRoot

                Case "HKCC", "HKEY_CURRENT_CONFIG"
                    Return Registry.CurrentConfig

                Case "HKCU", "HKEY_CURRENT_USER"
                    Return Registry.CurrentUser

                Case "HKLM", "HKEY_LOCAL_MACHINE"
                    Return Registry.LocalMachine

                Case "HKEY_PERFORMANCE_DATA"
                    Return Registry.PerformanceData

                Case Else
                    Return Nothing

            End Select

        End Function

        ''' <summary>
        ''' Gets the root key name of a registry path.
        ''' </summary>
        ''' <returns>The root key name of a registry path.</returns>
        Public Shared Function GetRootKeyName(ByVal registryPath As String) As String

            Select Case registryPath.ToUpper.Split("\"c).FirstOrDefault

                Case "HKCR", "HKEY_CLASSES_ROOT"
                    Return "HKEY_CLASSES_ROOT"

                Case "HKCC", "HKEY_CURRENT_CONFIG"
                    Return "HKEY_CURRENT_CONFIG"

                Case "HKCU", "HKEY_CURRENT_USER"
                    Return "HKEY_CURRENT_USER"

                Case "HKLM", "HKEY_LOCAL_MACHINE"
                    Return "HKEY_LOCAL_MACHINE"

                Case "HKEY_PERFORMANCE_DATA"
                    Return "HKEY_PERFORMANCE_DATA"

                Case Else
                    Return String.Empty

            End Select

        End Function

        ''' <summary>
        ''' Gets the subkey path of a registry path.
        ''' </summary>
        ''' <returns>The root <see cref="RegistryKey"/> of a key-path.</returns>
        Public Shared Function GetSubKeyPath(ByVal registryPath As String) As String

            Select Case String.IsNullOrEmpty(GetRootKeyName(registryPath))

                Case True
                    Return registryPath.TrimStart("\"c).TrimEnd("\"c)

                Case Else
                    Return registryPath.Substring(registryPath.IndexOf("\"c)).TrimStart("\"c).TrimEnd("\"c)

            End Select

        End Function

#End Region

#End Region

    End Class

End Namespace

#End Region