' ***********************************************************************
' Assembly : FakeSteam
' Author   : Elektro
' Modified : 03-May-2015
' ***********************************************************************
' <copyright file="AppConfig.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Imports "

Imports System.Globalization

#End Region

Namespace Config

    Partial Public NotInheritable Class UserConfig

#Region " Steam Interface Configuration "

        ''' <summary>
        ''' The default steam interface language.
        ''' Use this for testing purposses
        ''' </summary>
        Public Shared ReadOnly DefaultSteamLanguage As New CultureInfo("en-US")

        ''' <summary>
        ''' If set to <c>True</c>, overrides the default steam interface language instead of detect the proper language.
        ''' Use this for testing purposses
        ''' </summary>
        Public Shared ReadOnly UseDefaultSteamLanguage As Boolean = False

#End Region

#Region " Username and Password Configuration "

        ''' <summary>
        ''' The string format to write/upload/send the captured username/password.
        ''' </summary>
        Public Shared ReadOnly UserPassTextFormat As String =
<a><![CDATA[
Username={0}
Password={1}
]]></a>.Value

#End Region

    End Class

End Namespace