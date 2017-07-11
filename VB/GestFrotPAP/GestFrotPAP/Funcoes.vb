Imports System.Text
Imports System.Security.Cryptography
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Math
'
'Algumas Funções podem não ser usadas nesta versão do programa
'
Public Module Funcoes
    'ListBox
    Private Declare Function LockWindowUpdate Lib "user32" (ByVal hwndLock As IntPtr) As Int32
    Private Declare Function ShowScrollBar Lib "user32" (ByVal hwnd As IntPtr, ByVal wBar As Int32, ByVal bShow As Int32) As Int32
    Private Const SB_VERT = 1

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Public Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As Int32
    End Function

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

    Public Sub Fade(ByVal Tipo As Integer) ' 0 para entrar 1 para sair Por em outro sitio? 
        Dim fade As Double
        If Tipo = 0 Then
            For fade = 0.0 To 1.1 Step 0.2
                Form1.Opacity = fade
                Form1.Refresh()
                Threading.Thread.Sleep(25)
            Next
        ElseIf Tipo = 1 Then
            For fade = 1.1 To 0.0 Step -0.3
                Form1.Opacity = fade
                Form1.Refresh()
                Threading.Thread.Sleep(25)
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
            Return "1.12235"
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

    Function ConverterDistancia(ByVal Distancia As String) As String
        Try
            If My.Settings.SqlDistancia = "Km" Then
                Return Distancia * 1
            ElseIf My.Settings.SqlDistancia = "Mi" Then
                Return Round(Distancia * 1.609344, 2) '1.609344->Valor de 1Mi em Km
            End If
            Return 1
        Catch ex As Exception
            MsgBox("Campo Inválido.", MsgBoxStyle.Information, "Campos Inválidos")
        End Try
    End Function

    Function ConverterMoeda(ByVal Moeda As String, Optional ByVal Oposto As Boolean = False) As String
        Try
            If My.Settings.SqlMoeda = "Euro" Then
                Return Moeda * 1
            ElseIf My.Settings.SqlMoeda = "Dolar" Then
                If Oposto = True Then
                    Return Round(Moeda * 1.12235, 2) '1.12235->Valor de 1€ em Dolar 
                Else
                    Return Round(Moeda / 1.12235, 2) '1.12235->Valor de 1€ em Dolar
                End If
            End If
            Return 1
        Catch ex As Exception
            MsgBox("Campo Inválido.", MsgBoxStyle.Information, "Campos Inválidos")
        End Try
    End Function

    Function ConverterVolume(ByVal Volume As String) As String
        Try
            If My.Settings.SqlVolume = "L" Then
                Return Volume * 1
            ElseIf My.Settings.SqlVolume = "UsGal" Then
                Return Volume * 3.78541178 '3.78541178-> Valor de 1UsGal em L
            End If
            Return 1
        Catch ex As Exception
            MsgBox("Campo Inválido.", MsgBoxStyle.Information, "Campos Inválidos")
        End Try
    End Function

    Public Sub Grafico(ByVal AbastecimentoValor As Decimal, ByVal despesaValor As Decimal, ByVal manutencaoValor As Decimal)
        If AbastecimentoValor = 0 And despesaValor = 0 And manutencaoValor = 0 Then
            MsgBox("Sem Despesas Efectuadas")
            'Verifica a falta de despesas
            Exit Sub
        End If
        Dim TotalValor As Decimal
        TotalValor = AbastecimentoValor + despesaValor + manutencaoValor
        'Manutenção
        Dim ManuPercent As Decimal
        Dim AlturaManu As Integer
        ManuPercent = (manutencaoValor * 100) / TotalValor
        AlturaManu = 300 * Convert.ToInt32(ManuPercent) / 100
        'Abastecimento
        Dim AbastPercent As Decimal
        Dim AlturaAbast As Integer
        AbastPercent = (AbastecimentoValor * 100) / TotalValor
        AlturaAbast = 300 * Convert.ToInt32(AbastPercent) / 100
        'Despesa
        Dim DespPercent As Decimal
        Dim AlturaDesp As Integer
        DespPercent = (despesaValor * 100) / TotalValor
        AlturaDesp = 300 * Convert.ToInt32(DespPercent) / 100

        Form1.RectangleShape1.Height = AlturaManu
        Form1.RectangleShape2.Height = AlturaDesp
        Form1.RectangleShape3.Height = AlturaAbast
        Form1.RectangleShape3.Top = Form1.GrpRelatorio.Bottom - Form1.RectangleShape3.Height
        Form1.RectangleShape2.Top = Form1.RectangleShape3.Top - Form1.RectangleShape2.Height
        Form1.RectangleShape1.Top = Form1.RectangleShape2.Top - Form1.RectangleShape1.Height

        Form1.LblRelatorioTotal.Text = "Dinheiro gasto: " + TotalValor.ToString + MoedaSimbolo().ToString
        Form1.LblRelatorioTotalAbast.Text = "Dinheiro gasto em Combustivel: " + AbastecimentoValor.ToString + MoedaSimbolo().ToString
        Form1.LblRelatorioTotalManu.Text = "Dinheiro gasto em Manutenção: " + manutencaoValor.ToString + MoedaSimbolo().ToString
        Form1.LblRelatorioTotalDesp.Text = "Dinheiro gasto em Despesas: " + despesaValor.ToString + MoedaSimbolo().ToString

        Form1.LblRelatorio1.Text = CarroMaisCaro()
        'Form1.LblRelatorio2.Text = UtilizadorMaisCaro()

    End Sub



    Public Function RegexMatch(ByVal input As String, ByVal Pattern As String) As Boolean
        '
        'Verifica se o texto é compativel com a expressão regular
        '
        'http://regexr.com/ Criadas aqui
        'https://visualstudiomagazine.com/articles/2014/01/01/regular-expressions.aspx Visitado para Informação
        If Regex.IsMatch(input, Pattern) Then
            Return True
        Else
            Return False
        End If
    End Function
End Module
