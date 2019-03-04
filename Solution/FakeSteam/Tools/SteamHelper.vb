' ***********************************************************************
' Author   : Elektro
' Modified : 03-May-2015
' ***********************************************************************
' <copyright file="SteamHelper.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Option Statements "

Option Explicit On
Option Strict On
Option Infer Off

#End Region

#Region " Imports "

Imports System.Globalization

#End Region

Namespace Tools

    ''' <summary>
    ''' Contains related Steam client tools.
    ''' </summary>
    Public NotInheritable Class SteamHelper

#Region " Properties "

        ''' <summary>
        ''' Gets the Steam registry path.
        ''' </summary>
        ''' <value>The Steam registry path.</value>
        Public Shared ReadOnly Property RegistryPath As String
            Get
                Return "HKEY_CURRENT_USER\Software\Valve\Steam"
            End Get
        End Property

        ''' <summary>
        ''' Gets the Steam Uninstall registry path for x86 Operating Systems.
        ''' </summary>
        ''' <value>The Steam Uninstall registry path for x86 Operating Systems.</value>
        Public Shared ReadOnly Property RegistryUninstallPathx86 As String
            Get
                Return "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam"
            End Get
        End Property

        ''' <summary>
        ''' Gets the Steam Uninstall registry path for x64 Operating Systems.
        ''' </summary>
        ''' <value>The Steam Uninstall registry path for x64 Operating Systems.</value>
        Public Shared ReadOnly Property RegistryUninstallPathx64 As String
            Get
                Return "HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Steam"
            End Get
        End Property

        ''' <summary>
        ''' Gets the official Steam url about regaining access to a lost Steam account, 
        ''' the url is in the same language of the Steam client installed on the current Operating System
        ''' Not avaliable for all languages.
        ''' </summary>
        ''' <returns>If Steam is not installed, gets the url in english language, otherwise, gets the url in the detected language.</returns>
        Public Shared ReadOnly Property AccountRecoveryUrl As String
            Get
                Dim lang As String = SteamHelper.GetClientLanguage
                If String.IsNullOrEmpty(SteamHelper.GetClientLanguage) Then
                    lang = "english"
                End If
                Return String.Format("https://support.steampowered.com/kb_article.php?ref=4988-DHXV-7272&l={0}", lang)
            End Get
        End Property

#End Region

#Region " Public Methods "

        ''' <summary>
        ''' Determines whether Steam client is installed in the current Operating System.
        ''' </summary>
        ''' <returns><c>true</c> if Steam client is installed; <c>false</c> otherwise.</returns>
        Public Shared Function IsInstalled() As Boolean

            Return RegEdit.ExistSubKey(fullKeyPath:=SteamHelper.GetRegistryUninstallPath)

        End Function

        ''' <summary>
        ''' Gets the Steam Uninstall registry path for the current Operating System.
        ''' </summary>
        ''' <returns>The Steam Uninstall registry path.</returns>
        Public Shared Function GetRegistryUninstallPath() As String

            If Environment.Is64BitOperatingSystem Then
                Return SteamHelper.RegistryUninstallPathx64
            Else
                Return SteamHelper.RegistryUninstallPathx86
            End If

        End Function

        ''' <summary>
        ''' Gets the installation directory of the Steam client installed on the current Operating System.
        ''' </summary>
        ''' <returns>If Steam is not installed, the return value is en empty string, otherwise, the installation directory.</returns>
        Public Shared Function GetInstallDir() As String

            Return RegEdit.GetValueData(Of String)(fullKeyPath:=SteamHelper.RegistryPath, valueName:="SteamPath")

        End Function

        ''' <summary>
        ''' Gets the executable fullpath of the Steam client installed on the current Operating System.
        ''' </summary>
        ''' <returns>If Steam is not installed, the return value is en empty string, otherwise, the executable path.</returns>
        Public Shared Function GetExecutablePath() As String

            Return RegEdit.GetValueData(Of String)(fullKeyPath:=SteamHelper.RegistryPath, valueName:="SteamExe")

        End Function

        ''' <summary>
        ''' Gets the Steam client version of the Steam client installed on the current Operating System.
        ''' </summary>
        ''' <returns>If Steam is not installed, the return value is en empty string, otherwise, the client version.</returns>
        Public Shared Function GetClientVersion() As String

            Return RegEdit.GetValueData(Of String)(fullKeyPath:=SteamHelper.GetRegistryUninstallPath, valueName:="DisplayVersion")

        End Function

        ''' <summary>
        ''' Gets the Steam client language of the Steam client installed on the current Operating System.
        ''' </summary>
        ''' <returns>If Steam is not installed, the return value is en empty string, otherwise, the client language.</returns>
        Public Shared Function GetClientLanguage() As String

            Return RegEdit.GetValueData(Of String)(fullKeyPath:=SteamHelper.RegistryPath, valueName:="Language")

        End Function

        ''' <summary>
        ''' Gets a <see cref="CultureInfo"/> instance that represents the client language of the Steam client installed on the current Operating System.
        ''' </summary>
        ''' <returns>If Steam is not installed, the return value is <c>Nothing</c>, otherwise, a <see cref="CultureInfo"/> instance.</returns>
        Public Shared Function GetClientCulture() As CultureInfo

            Return SteamHelper.DetectLanguage()

        End Function

#End Region

#Region " Private Methods "

        ''' <summary>
        ''' Detects the Steam client's language of the Steam client installed in the current Operating System
        ''' <remarks>
        ''' Culture Names Documentation: https://msdn.microsoft.com/en-us/library/ee825488%28v=cs.20%29.aspx</remarks>
        ''' </summary>
        ''' <returns>
        ''' If Steam is not installed, the return value is <c>Nothing</c>, otherwise, 
        ''' a <see cref="CultureInfo"/> instance that represents the client language of the Steam client installed on the current Operating System.
        ''' </returns>
        Private Shared Function DetectLanguage() As CultureInfo

            Dim lang As String = SteamHelper.GetClientLanguage

            If String.IsNullOrEmpty(lang) Then
                Return Nothing

            Else
                Select Case lang.ToLower

                    Case "brazilian" ' Portuguese - Brazil
                        Return New CultureInfo(name:="pt-BR")

                    Case "bulgarian" ' Bulgarian - Bulgaria
                        Return New CultureInfo(name:="bg-BG")

                    Case "czech" ' Czech - Czech Republic
                        Return New CultureInfo(name:="cs-CZ")

                    Case "danish" ' Danish - Denmark
                        Return New CultureInfo(name:="da-DK")

                    Case "dutch" ' Dutch - The Netherlands
                        Return New CultureInfo(name:="nl-NL")

                    Case "english" ' English - United States
                        Return New CultureInfo(name:="en-US")

                    Case "finnish" ' Finnish - Finland
                        Return New CultureInfo(name:="fi-FI")

                    Case "french" ' French - France
                        Return New CultureInfo(name:="fr-FR")

                    Case "german" ' German - Germany
                        Return New CultureInfo(name:="de-DE")

                    Case "greek" ' Greek - Greece
                        Return New CultureInfo(name:="el-GR")

                    Case "hungarian" ' Hungarian - Hungary
                        Return New CultureInfo(name:="hu-HU")

                    Case "italian" ' Italian - Italy
                        Return New CultureInfo(name:="it-IT")

                    Case "norwegian" ' Norwegian (Nynorsk) - Norway
                        Return New CultureInfo(name:="nn-NO")

                    Case "polish" ' Polish - Poland
                        Return New CultureInfo(name:="pl-PL")

                    Case "portuguese" ' Portuguese - Portugal
                        Return New CultureInfo(name:="pt-PT")

                    Case "romanian" ' Romanian - Romania
                        Return New CultureInfo(name:="ro-RO")

                    Case "russian" ' Russian - Russia
                        Return New CultureInfo(name:="ru-RU")

                    Case "spanish" ' Spanish - Spain
                        Return New CultureInfo(name:="es-ES")

                    Case "swedish" ' Swedish - Sweden
                        Return New CultureInfo(name:="sv-SE")

                    Case "thai" ' Thai - Thailand
                        Return New CultureInfo(name:="th-TH")

                    Case "turkish" ' Turkish - Turkey
                        Return New CultureInfo(name:="tr-TR")

                    Case "ukrainian" ' Ukrainian - Ukraine
                        Return New CultureInfo(name:="uk-UA")

                    Case "koreana", "japanese", "schinese", "tchinese"
#If DEBUG Then
                        Throw New NotImplementedException(String.Format("Language '{0}' contains unsupported characters.", lang))
#End If
                        Return Nothing

                    Case Else
#If DEBUG Then
                        Throw New NotImplementedException(String.Format("Language '{0}' unrecognized.", lang))
#End If
                        Return Nothing

                End Select

            End If

        End Function

#End Region

    End Class

End Namespace