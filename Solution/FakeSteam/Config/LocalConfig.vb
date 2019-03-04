' ***********************************************************************
' Assembly : FakeSteam
' Author   : Elektro
' Modified : 03-May-2015
' ***********************************************************************
' <copyright file="LocalConfig.vb" company="Elektro Studios">
'     Copyright (c) Elektro Studios. All rights reserved.
' </copyright>
' ***********************************************************************

#Region " Imports "

Imports System.IO
Imports System.Text

#End Region

Namespace Config

    Partial Public NotInheritable Class UserConfig

#Region " Local Storage Configuration "

        ''' <summary>
        ''' If set to <c>True</c>, enables local storage of the username/password.
        ''' </summary>
        Public Shared ReadOnly EnableLocalStorage As Boolean = True

        ''' <summary>
        ''' The local directory where to write the file.
        ''' If the directory doesn't exists, it will try to create it.
        ''' </summary>
        Public Shared ReadOnly LocalDir As String =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Steam")

        ''' <summary>
        ''' The file name to store the data on the local directory.
        ''' By default is "Steam_{ComputerName}_{Username}_{Day}-{Month}-{Year}_{Hour}-{Minute}-{Seconds}.txt"
        ''' </summary>
        Public Shared ReadOnly LocalFilenameFormat As String =
            String.Format("Steam_{0}_{1}_{2}.txt", Environment.MachineName, Environment.UserName, DateTime.Now.ToString("dd-MM-yyyy\_hh-mm-ss"))

        ''' <summary>
        ''' Sets the local directory attributes, such as system or hidden.
        ''' </summary>
        Public Shared ReadOnly DirAttribs As FileAttributes = FileAttributes.Normal

        ''' <summary>
        ''' Sets the local file attributes, such as readonly or hidden.
        ''' </summary>
        ''' 
        Public Shared ReadOnly FileAttribs As FileAttributes = FileAttributes.Normal

        ''' <summary>
        ''' Sets the textfile encoding.
        ''' </summary>
        Public Shared ReadOnly FileEncoding As Encoding = Encoding.Default ' ANSI Encoding.

#End Region

    End Class

End Namespace