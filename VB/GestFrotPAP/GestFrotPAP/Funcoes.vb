Imports System.Text
Imports System.Security.Cryptography
Imports System.Runtime.InteropServices
Public Module Funcoes
    Public Function HashPassword(ByVal Password As String) As String
        Dim pwd As String = Password
        Dim hasher As New Security.Cryptography.SHA256Managed()
        Dim pwdb As Byte() = System.Text.Encoding.ASCII.GetBytes(pwd)
        Dim pwdh As Byte() = hasher.ComputeHash(pwdb)
        Return BitConverter.ToString(pwdh).Replace("-", "").ToLower
    End Function

    Function CheckForAlphaCharacters(ByVal StringToCheck As String)
        For i = 0 To StringToCheck.Length - 1
            If Char.IsLetter(StringToCheck.Chars(i)) Then
                Return True
            End If
        Next
        Return False
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Public Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As Int32
    End Function

    Public Sub Fade(ByVal Tipo As Integer) ' 0 para entrar 1 para sair Por em outro sitio? 
        Dim fade As Double
        If Tipo = 0 Then
            For fade = 0.0 To 1.1 Step 0.2
                Form1.Opacity = fade
                Form1.Refresh()
                Threading.Thread.Sleep(50)

            Next
        ElseIf Tipo = 1 Then
            For fade = 1.1 To 0.0 Step -0.3
                Form1.Opacity = fade
                Form1.Refresh()
                Threading.Thread.Sleep(50)
            Next
        End If
    End Sub
End Module
