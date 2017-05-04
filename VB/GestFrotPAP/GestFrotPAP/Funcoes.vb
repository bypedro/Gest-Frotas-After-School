Imports System.Text
Imports System.Security.Cryptography
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions

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

    Function VerificarEspaco(ByVal StringToCheck As String)
        For i = 0 To StringToCheck.Length - 1
            If StringToCheck.Chars(i) = " " Then
                Return True
            End If
        Next
        Return False
    End Function

    Function VerificarKmString(ByVal StringToCheck As String) As Boolean
        Dim Valido(StringToCheck - 1) As Boolean

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

    Function DistanciaConversao() As String
        If My.Settings.SqlDistancia = "Km" Then
            Return "1"
        ElseIf My.Settings.SqlDistancia = "Mi" Then
            Return "1.609344"
        End If
        Return 1
    End Function
    Function DistanciaSimbolo() As String
        If My.Settings.SqlDistancia = "Km" Then
            Return "KM"
        ElseIf My.Settings.SqlDistancia = "Mi" Then
            Return "Mi"
        End If
        Return ""
    End Function
    Function DistanciaDistancia() As String
        If My.Settings.SqlDistancia = "Km" Then
            Return "Quilometros"
        ElseIf My.Settings.SqlDistancia = "Mi" Then
            Return "Milhas"
        End If
        Return ""
    End Function

    Function MoedaConversao() As String
        If My.Settings.SqlMoeda = "Euro" Then
            Return "1"
        ElseIf My.Settings.SqlMoeda = "Dolar" Then
            Return "0.913673313"
        End If
        Return 1
    End Function
    Function MoedaSimbolo() As String
        If My.Settings.SqlMoeda = "Euro" Then
            Return "€"
        ElseIf My.Settings.SqlMoeda = "Dolar" Then
            Return "US$"
        End If
        Return 1
    End Function

    Function MoedaMoeda() As String
        If My.Settings.SqlMoeda = "Euro" Then
            Return "Euro"
        ElseIf My.Settings.SqlMoeda = "Dolar" Then
            Return "Dolar"
        End If
        Return 1
    End Function

    Function VolumeConversao() As String
        If My.Settings.SqlVolume = "L" Then
            Return "1"
        ElseIf My.Settings.SqlVolume = "UsGal" Then
            Return "3.78541178"
        End If
        Return 1
    End Function
    Function VolumeSimbolo() As String
        If My.Settings.SqlVolume = "L" Then
            Return "L"
        ElseIf My.Settings.SqlVolume = "UsGal" Then
            Return "US Gal"
        End If
        Return 1
    End Function

    Function VolumeVolume() As String
        If My.Settings.SqlVolume = "Euro" Then
            Return "Litros"
        ElseIf My.Settings.SqlVolume = "Dolar" Then
            Return "Galões"
        End If
        Return 1
    End Function

End Module
