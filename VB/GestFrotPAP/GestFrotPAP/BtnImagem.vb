Imports System.Drawing.Text
Imports System.Drawing
'Define evento primário->
<System.ComponentModel.DefaultEventAttribute("ButtonClickMasterRace")> _
Public Class BtnImagem
    Private _CorSelecionado As Color = Color.SteelBlue
    Private _CorFundo As Color = Color.SlateGray
    Private _CorHover As Color = Color.LightSlateGray
    Private _CorTexto As Color = Color.White
    Private _TamanhoLetra As Integer = 10
    Private _Texto As String = "Teste"
    Private _Imagem As System.Drawing.Bitmap
    Private _EstadoBotao As Boolean = False


    <System.ComponentModel.Category("BtnImagem")> _
    Public Property CorSelecionado As Color
        Get
            Return _CorSelecionado
        End Get
        Set(ByVal value As Color)
            _CorSelecionado = value
            If _EstadoBotao = False Then
                Me.BackColor = _CorFundo
            Else
                Me.BackColor = _CorSelecionado
            End If
        End Set
    End Property
    <System.ComponentModel.Category("BtnImagem")> _
    Public Property CorFundo As Color
        Get
            Return _CorFundo
        End Get
        Set(ByVal value As Color)
            _CorFundo = value
            If _EstadoBotao = False Then
                Me.BackColor = _CorFundo
            Else
                Me.BackColor = _CorSelecionado
            End If
        End Set
    End Property
    <System.ComponentModel.Category("BtnImagem")> _
    Public Property CorHover As Color
        Get
            Return _CorHover
        End Get
        Set(ByVal value As Color)
            _CorHover = value
        End Set
    End Property
    <System.ComponentModel.Category("BtnImagem")> _
    Public Property CorTexto As Color
        Get
            Return _CorTexto
        End Get
        Set(ByVal value As Color)
            _CorTexto = value
            LblTexto.ForeColor = _CorTexto
        End Set
    End Property
    <System.ComponentModel.Category("BtnImagem")> _
    Public Property EstadoBotao As Boolean
        Get
            Return _EstadoBotao
        End Get
        Set(ByVal value As Boolean)
            _EstadoBotao = value
            If _EstadoBotao = False Then
                Me.BackColor = _CorFundo
            Else
                Me.BackColor = _CorSelecionado
            End If
        End Set
    End Property
    <System.ComponentModel.Category("BtnImagem")> _
    Public Property Imagem As System.Drawing.Bitmap
        Get
            Return _Imagem
        End Get
        Set(ByVal value As System.Drawing.Bitmap)
            _Imagem = value
            PctImagem.Image = _Imagem
        End Set
    End Property
    <System.ComponentModel.Category("BtnImagem")> _
    Public Property TamanhoLetra As Integer
        Get
            Return _TamanhoLetra
        End Get
        Set(ByVal value As Integer)
            _TamanhoLetra = value
            LblTexto.Font = Fonte.GetInstance(_TamanhoLetra, FontStyle.Bold)
        End Set
    End Property
    <System.ComponentModel.Category("BtnImagem")> _
    Public Property Texto As String
        Get
            Return _Texto
        End Get
        Set(ByVal value As String)
            _Texto = value
            LblTexto.Text = _Texto
        End Set
    End Property





    Private Sub BtnImagem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TESTE
        'Dim p As New Drawing2D.GraphicsPath()
        ' p.StartFigure()
        'p.AddArc(New Rectangle(0, 0, 5, 5), 180, 90)
        'p.AddLine(5, 0, Me.Width - 5, 0)
        'p.AddArc(New Rectangle(Me.Width - 5, 0, 5, 5), -90, 90)
        'p.AddLine(Me.Width, 5, Me.Width, Me.Height - 5)
        ' p.AddArc(New Rectangle(Me.Width - 5, Me.Height - 5, 5, 5), 0, 90)
        ' p.AddLine(Me.Width - 5, Me.Height, 5, Me.Height)
        'p.AddArc(New Rectangle(0, Me.Height - 5, 5, 5), 90, 90)
        ' p.CloseFigure()
        'Me.Region = New Region(p)
        'TESTE
    End Sub

    Public Sub VerificarEstadoBotao()
        If _EstadoBotao = False Then
            Me.BackColor = CorFundo
            _EstadoBotao = False
        End If
        If _EstadoBotao = True Then
            Me.BackColor = CorSelecionado
            _EstadoBotao = True
        End If
    End Sub

    Public Sub EventoClick()
        If _EstadoBotao = False Then
            Me.BackColor = CorSelecionado
            Me._EstadoBotao = True
        End If
        VerificarEstadoBotao()
    End Sub

    Public Event ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs)

    Private Sub Objetos(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PctImagem.Click, LblTexto.Click, Me.Click
        EventoClick()
        RaiseEvent ButtonClickMasterRace(Me, EventArgs.Empty)
    End Sub


    Private Sub Btnhover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.MouseEnter, LblTexto.MouseEnter, PctImagem.MouseEnter
        If _EstadoBotao = False Then
            Me.BackColor = _CorHover
        End If
    End Sub
    Private Sub Btnleave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.MouseLeave, PctImagem.MouseLeave, LblTexto.MouseLeave
        If _EstadoBotao = False Then
            Me.BackColor = CorFundo
        End If
    End Sub
End Class