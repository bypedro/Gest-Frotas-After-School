﻿Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Runtime.InteropServices

Public Class Form1
    'Caro colega programador:
    '
    'Quando escrevi este código, só Deus e eu sabíamos com funcionava
    'Agora, SÓ Deus o  sabe!
    '
    'Para ti que estás a tentar otimiza-lo e falhaste, por favor, 
    'aumenta o contador para adverter o teu proximo colega:
    '
    'Total_horas_perdidas_aqui = 38
    '
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Public linhaSQL As String

    Dim NMenuPrincipal As Integer = 7 'Nº butões
    Dim BtnImagemMenuPrincipal(NMenuPrincipal) As BtnImagem
    Dim panelMenuPrincipal(NMenuPrincipal) As Panel

    Dim NMenuDefutilizador As Integer = 1 '  'Nº butões
    Dim BtnImagemMenuDefUtilizador1(NMenuDefutilizador) As BtnImagem
    Dim panelMenuDefUtilizador(NMenuDefutilizador) As Panel

    Dim NMenuAgenda As Integer = 1 '  'Nº butões
    Dim BtnImagemMenuAgenda(NMenuAgenda) As BtnImagem
    Dim panelMenuAgenda(NMenuAgenda) As Panel

    Dim NMenuAdmin As Integer = 3 '  'Nº butões
    Dim BtnImagemMenuAdmin(NMenuAdmin) As BtnImagem
    Dim panelMenuAdmin(NMenuAdmin) As Panel
    '
    'Função para mostrar cada panel associado ao botão(Programa Principal)
    '
    Private Sub MenuPrincipal(ByVal c As Integer, Optional ByVal MenuDefault As Boolean = False, Optional ByVal MenuHome As Boolean = False)
        Dim a As Integer
        For a = 0 To NMenuPrincipal
            If BtnImagemMenuPrincipal(a).EstadoBotao = True And a <> c Then
                BtnImagemMenuPrincipal(a).EstadoBotao = False
                BtnImagemMenuPrincipal(a).VerificarEstadoBotao()
                panelMenuPrincipal(a).Hide()
            End If
            panelMenuPrincipal(c).Show()
        Next
        If MenuDefault = True Then
            If PnlMenu.Right = 200 Then
                BtnMenu1.resetbtn()
                For a = 0 To NMenuPrincipal
                    BtnImagemMenuPrincipal(a).Hide()
                Next
                TmrSlide1.Enabled = True
            End If
        End If
        If MenuHome = True Then
            If PnlMenu.Right = 36 Then
                BtnMenu1.resetbtn()
                For a = 0 To NMenuPrincipal
                    BtnImagemMenuPrincipal(a).Hide()
                Next
                TmrSlide2.Enabled = True
                BtnMenu1.zEstadoBotao = False
                BtnMenu1.resetbtn()
            End If
        End If
    End Sub
    '
    'Função para mostrar cada panel associado ao botão(Menu com os detalhes do Utilizador)
    '
    Private Sub MenuDefUtilizador(ByVal d As Integer)
        Dim a As Integer
        For a = 0 To NMenuDefutilizador
            If BtnImagemMenuDefUtilizador1(a).EstadoBotao = True And a <> d Then
                BtnImagemMenuDefUtilizador1(a).EstadoBotao = False
                BtnImagemMenuDefUtilizador1(a).VerificarEstadoBotao()
                panelMenuDefUtilizador(a).Hide()
            End If
            panelMenuDefUtilizador(d).Show()
        Next
    End Sub
    '
    'Função para mostrar cada panel associado ao botão(Menu da Agenda)
    '
    Private Sub MenuAgenda(ByVal d As Integer)
        Dim a As Integer
        For a = 0 To NMenuAgenda
            If BtnImagemMenuAgenda(a).EstadoBotao = True And a <> d Then
                BtnImagemMenuAgenda(a).EstadoBotao = False
                BtnImagemMenuAgenda(a).VerificarEstadoBotao()
                panelMenuAgenda(a).Hide()
            End If
            panelMenuAgenda(d).Show()
        Next
    End Sub
    '
    'Função para mostrar cada panel associado ao botão(Menu de Adminitração)
    '
    Private Sub MenuAdmin(ByVal d As Integer)
        Dim a As Integer
        For a = 0 To NMenuAdmin
            If BtnImagemMenuAdmin(a).EstadoBotao = True And a <> d Then
                BtnImagemMenuAdmin(a).EstadoBotao = False
                BtnImagemMenuAdmin(a).VerificarEstadoBotao()
                panelMenuAdmin(a).Hide()
            End If
            panelMenuAdmin(d).Show()
        Next
    End Sub
    '
    'Tranforma os Botões do menu é Botões "Normais"(Aspecto)
    '
    Private Sub Botao(ByVal c As BtnImagem)
        If c.EstadoBotao = True Then
            c.EstadoBotao = False
            c.VerificarEstadoBotao()
        End If
    End Sub
    '
    'Efeito Fade no Fechar
    '
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        Fade(1) 'VEr
    End Sub
    '
    'Botão para Fechar
    '
    Private Sub fechar_click(ByVal sender As Object, ByVal e As EventArgs) Handles Fechar.Click
        Close()
    End Sub
    Private Sub fechar_enter(ByVal sender As Object, ByVal e As EventArgs) Handles Fechar.MouseEnter
        Fechar.ForeColor = Color.Red
    End Sub
    Private Sub fechar_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles Fechar.MouseLeave
        Fechar.ForeColor = Color.White
    End Sub
    '
    'Ações para mover o Form
    '
    Private Sub PnlBarraTop_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PnlBarraTop.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub
    Private Sub PnlBarraTop_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PnlBarraTop.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub
    Private Sub PnlBarraTop_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PnlBarraTop.MouseUp
        drag = False
    End Sub
    '
    'Função para detetar um Click em determinado Objeto
    '
    Public Sub c_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If sender Is LblUtilzadorMenu And PnlUser.Visible = True Then
            PnlUser.Hide()
        Else
            If sender Is LblUtilzadorMenu Or sender Is PnlUser Then
                PnlUser.Show()
            Else
                PnlUser.Hide()
            End If
        End If
    End Sub
    '
    'Timer/Funcção para a animação do menu
    '
    Private Sub TmrSlide1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TmrSlide1.Tick
        PnlMenu.Left = PnlMenu.Left - 2
        For a = 0 To NMenuPrincipal
            BtnImagemMenuPrincipal(a).Left = BtnImagemMenuPrincipal(a).Left + 2
        Next
        If PnlMenu.Right = 36 Then
            TmrSlide1.Enabled = False
            For a = 0 To NMenuPrincipal
                BtnImagemMenuPrincipal(a).Show()
                If DetalhesUtilizador.TipoUtilizadorCod = 1 Then
                    BtnImagemMenuPrincipal(6).Show()
                    BtnImagemMenuPrincipal(7).Show()
                Else
                    BtnImagemMenuPrincipal(6).Hide()
                    BtnImagemMenuPrincipal(7).Hide()
                End If
            Next
        End If
        BtnMenu1.zEstadoBotao = True
        BtnMenu1.resetbtn()
    End Sub
    '
    'Timer/Funcção para a animação do menu
    '
    Private Sub TmrSlide2_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TmrSlide2.Tick
        PnlMenu.Left = PnlMenu.Left + 2
        Dim a As Integer
        For a = 0 To NMenuPrincipal
            BtnImagemMenuPrincipal(a).Left = BtnImagemMenuPrincipal(a).Left - 2
        Next
        If PnlMenu.Right = 200 Then
            TmrSlide2.Enabled = False
            For a = 0 To NMenuPrincipal
                BtnImagemMenuPrincipal(a).Show()
                If DetalhesUtilizador.TipoUtilizadorCod = 1 Then
                    BtnImagemMenuPrincipal(6).Show()
                    BtnImagemMenuPrincipal(7).Show()
                Else
                    BtnImagemMenuPrincipal(6).Hide()
                    BtnImagemMenuPrincipal(7).Hide()
                End If
            Next
        End If
        BtnMenu1.zEstadoBotao = False
        BtnMenu1.resetbtn()
    End Sub
    '
    'Botão para maximizar/minimizar o Menu
    '
    Private Sub BtnMenu1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnMenu1.Click
        If BtnImagemMenuPrincipal(0).EstadoBotao <> True Then
            BtnMenu1.resetbtn()
            For a = 0 To NMenuPrincipal
                BtnImagemMenuPrincipal(a).Hide()
            Next
            If PnlMenu.Right = 200 Then
                TmrSlide1.Enabled = True
            ElseIf PnlMenu.Right = 36 Then
                TmrSlide2.Enabled = True
            End If
        End If
    End Sub
    '
    'Load
    '
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'Area de teste

        'Adiciona evento a todos os objetos do programa(Associados ao form1)(Objetos dentro de paneis necessitao de ser adicionados)
        AddHandler Me.MouseDown, AddressOf c_MouseDown
        For Each c As Control In Me.Controls
            AddHandler c.MouseDown, AddressOf c_MouseDown
        Next
        For Each c As Control In PnlLogin.Controls
            AddHandler c.MouseDown, AddressOf c_MouseDown
        Next
        For Each c As Control In PnlMenu.Controls
            AddHandler c.MouseDown, AddressOf c_MouseDown
        Next
        AddHandler LblNomeProjeto.MouseDown, AddressOf c_MouseDown
        'Deixa o form com os cantos arredondados
        Dim p As New Drawing2D.GraphicsPath()
        p.StartFigure()
        p.AddArc(New Rectangle(0, 0, 5, 5), 180, 90)
        p.AddLine(5, 0, Me.Width - 5, 0)
        p.AddArc(New Rectangle(Me.Width - 5, 0, 5, 5), -90, 90)
        p.AddLine(Me.Width, 5, Me.Width, Me.Height - 5)
        p.AddArc(New Rectangle(Me.Width + 5, Me.Height - 5, 5, 5), 90, 90)
        p.AddLine(Me.Width - 5, Me.Height, 5, Me.Height)
        p.AddArc(New Rectangle(0, Me.Height - 5, 5, 5), 90, 90)
        p.CloseFigure()
        Me.Region = New Region(p)
        'Arrays de Objetos
        'Menu definições 
        panelMenuDefUtilizador(0) = PnlDefUtilizadorInfo
        panelMenuDefUtilizador(1) = PnlDefUtilizadorContato
        BtnImagemMenuDefUtilizador1(0) = BtnImagemDefUtilizadorInfo
        BtnImagemMenuDefUtilizador1(1) = BtnImagemDefUtilizadorContato
        'Menu Principal
        panelMenuPrincipal(0) = PnlHome
        panelMenuPrincipal(1) = Panel2
        panelMenuPrincipal(2) = Panel3
        panelMenuPrincipal(3) = Panel4
        panelMenuPrincipal(4) = Panel5
        panelMenuPrincipal(5) = Panel6
        panelMenuPrincipal(6) = Panel7
        panelMenuPrincipal(7) = Panel8
        BtnImagemMenuPrincipal(0) = BtnImagem1
        BtnImagemMenuPrincipal(1) = BtnImagem2
        BtnImagemMenuPrincipal(2) = BtnImagem3
        BtnImagemMenuPrincipal(3) = BtnImagem4
        BtnImagemMenuPrincipal(4) = BtnImagem5
        BtnImagemMenuPrincipal(5) = BtnImagem6
        BtnImagemMenuPrincipal(6) = BtnImagem7
        BtnImagemMenuPrincipal(7) = BtnImagem8
        'Menu Agenda
        BtnImagemMenuAgenda(0) = BtnImagemAgendaManu
        BtnImagemMenuAgenda(1) = BtnImagemAgendaDesp
        panelMenuAgenda(0) = PnlAgendaManu
        panelMenuAgenda(1) = PnlAgendaDesp
        'Menu Admin
        BtnImagemMenuAdmin(0) = BtnImagemAdminUtilizador
        BtnImagemMenuAdmin(1) = BtnImagemAdminVeiculos
        BtnImagemMenuAdmin(2) = BtnImagemAdminFornecedores
        BtnImagemMenuAdmin(3) = BtnImagemAdminMisc
        panelMenuAdmin(0) = PnlAdminUtilizador
        panelMenuAdmin(1) = PnlAdminVeiculos
        panelMenuAdmin(2) = PnlAdminFornecedores
        panelMenuAdmin(3) = PnlAdminMisc
        'Adiciona evento a objetos(Botões)
        Dim a As Integer
        For a = 0 To NMenuPrincipal
            For Each c As Control In panelMenuPrincipal(a).Controls
                AddHandler c.MouseDown, AddressOf c_MouseDown
            Next
        Next

        'Panel1.Location = New Point((Me.DisplayRectangle.Width - Panel1.Width) / 2 + 100, (Me.DisplayRectangle.Height - Panel1.Height) / 2) 'Código para por no centro do ecrâ
        LblPnlHome.Font = Fonte.GetInstance(15, FontStyle.Bold)
        LblPnlHome.ForeColor = Color.White
        GrpHomeInfo.Font = Fonte.GetInstance(12, FontStyle.Bold)
        GrpHomeInfo.ForeColor = Color.White

        'IDK yet
        Fechar.Font = Fonte.GetInstance(12, FontStyle.Bold)
        Fechar.Text = "X"
        Fechar.ForeColor = Color.White
        Fechar.Left = PnlBarraTop.Right - 25
        Fechar.Top = (PnlBarraTop.Height - Fechar.Height) / 2

        LoadOrder.LoginPage() 'Aparencia
        Fade(0)
    End Sub
    '
    '
    ''''''''''''''''''''Pagina Principal
    '
    '
    'Pagina Principal
    '
    Private Sub BtnImagem1_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagem1.ButtonClickMasterRace
        MenuPrincipal(0, False, True)
        If DetalhesUtilizador.CodVeiculo = 0 Then
            LblHomeServico.Text = "EM SERVIÇO     NÂO"
            LblHomeConcluido.Text = "CONCLUIDOS     " + DetalhesUtilizador.ServicosCompletos + ""
            LblHomeDespesas.Text = "DESPESAS     " + DetalhesUtilizador.Despesas + " " + MoedaSimbolo() + ""
        Else
            LblHomeServico.Text = "EM SERVIÇO     SIM"
            LblHomeConcluido.Text = "CONCLUIDOS     " + DetalhesUtilizador.ServicosCompletos + ""
            LblHomeDespesas.Text = "DESPESAS     " + DetalhesUtilizador.Despesas + ""
        End If
    End Sub
    '
    '
    ''''''''''''''''''''Pagina de Abastecimentos
    '
    '
    'Abastecimentos
    '
    Private Sub BtnImagem2_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagem2.ButtonClickMasterRace
        MenuPrincipal(1, True)
        If DetalhesUtilizador.TipoUtilizadorCod = 1 Then
            TabelaVer(LstVAbastecimento, "select CodVeiAbast,Data,Nome as Fornecedor,concat(ROUND((quantidade/" + VolumeConversao().ToString + "),2),' " + VolumeSimbolo() + "') as 'Quantidade',concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "' ,concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador  from VeiCondu,veiabast,veiculos,fornecedores,Utilizador where VeiCondu.Codvei=Veiculos.Codvei and Veiculos.Codvei=Veiabast.CodVei and fornecedores.Codforn=Veiabast.Codforn and Utilizador.CodUser=Veiabast.Coduser and VeiCondu.EmUso='Sim' order by CodVeiAbast DESC", "LstVAbastecimento")
        Else
            TabelaVer(LstVAbastecimento, "select CodVeiAbast,Data,Nome as Fornecedor,concat(ROUND((quantidade/" + VolumeConversao().ToString + "),2),' " + VolumeSimbolo() + "') as 'Quantidade',concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "' ,concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador  from VeiCondu,veiabast,veiculos,fornecedores,Utilizador where VeiCondu.Codvei=Veiculos.Codvei and Veiculos.Codvei=Veiabast.CodVei and fornecedores.Codforn=Veiabast.Codforn and Utilizador.CodUser=Veiabast.Coduser and VeiCondu.EmUso='Sim' and Utilizador.CodUser='" + DetalhesUtilizador.CodUser + "'order by CodVeiAbast DESC", "LstVAbastecimento")
        End If

        LblAbast.Font = GetInstance(12, FontStyle.Bold)
        GrpAbast.Font = GetInstance(12, FontStyle.Bold)
        GrpAbastNotas.Font = GetInstance(8, FontStyle.Bold)
    End Sub
    '
    'Detalhes Abastecimento
    '
    Private Sub LstVAbastecimento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVAbastecimento.Click
        DetalhesAbast(LstVAbastecimento.SelectedItems(0).Text)
    End Sub
    '
    'Inserir Abastecimento
    '
    Private Sub BtnImagemAbastInsert_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemAbastInsert.ButtonClickMasterRace
        Botao(BtnImagemAbastInsert)
        Panel1.Show()
        Panel1.BringToFront()
        Inserir_EditarTabelaSQL("AbastInsert")
    End Sub

    Private Sub BtnImagemHomeAbast_buttonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemHomeAbast.ButtonClickMasterRace
        Botao(BtnImagemHomeAbast)
        Panel1.Show()
        Panel1.BringToFront()
        Inserir_EditarTabelaSQL("AbastInsert")
    End Sub

    '
    'Editar Abastecimento
    '
    Private Sub BtnImagemAbastEdit_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemAbastEdit.ButtonClickMasterRace
        Botao(BtnImagemAbastEdit)
        If LstVAbastecimento.SelectedItems.Count > 0 Then
            Panel1.Show()
            Panel1.BringToFront()
            Inserir_EditarTabelaSQL("AbastEdit", LstVAbastecimento.SelectedItems(0).Text.ToString)
        Else
            MsgBox("Selecione um abastecimento")
        End If
    End Sub
    '
    '
    ''''''''''''''''''''Pagina de Manutenção
    '
    '
    'Manutenção
    '
    Private Sub BtnImagem3_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagem3.ButtonClickMasterRace
        MenuPrincipal(2, True)
        If DetalhesUtilizador.TipoUtilizadorCod = 1 Then
            TabelaVer(LstVManu, "select Codmanu,Data_Efetuada as Data,fornecedores.Nome as Fornecedor,tipoManu.Nome as Tipo,concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao.ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador from Utilizador,VeiCondu,Manutencao,veiculos,fornecedores,tipomanu where VeiCondu.Codvei=Veiculos.Codvei and Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and Utilizador.CodUser=Manutencao.Coduser and efetuada='Sim' and EmUso='Sim'", "LstVManu")
        Else
            TabelaVer(LstVManu, "select Codmanu,Data_Efetuada as Data,fornecedores.Nome as Fornecedor,tipoManu.Nome as Tipo,concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao.ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador from Utilizador,VeiCondu,Manutencao,veiculos,fornecedores,tipomanu where VeiCondu.Codvei=Veiculos.Codvei and Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and Utilizador.CodUser=Manutencao.Coduser and efetuada='Sim' and EmUso='Sim' and Manutencao.CodUser='" + DetalhesUtilizador.CodUser + "'", "LstVManu")
        End If

        LblManu.Font = GetInstance(12, FontStyle.Bold)
        GrpManu.Font = GetInstance(12, FontStyle.Bold)
        GrpManuNota.Font = GetInstance(8, FontStyle.Bold)
    End Sub
    '
    'Detalhes Manutenção
    '
    Private Sub LstVManu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVManu.Click
        DetalhesManu(LstVManu.SelectedItems(0).Text)
    End Sub
    '
    'Inserir Manutenção
    '
    Private Sub BtnImagemManuInsert_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemManuInsert.ButtonClickMasterRace
        Botao(BtnImagemManuInsert)
        Panel1.Show()
        Panel1.BringToFront()
        Inserir_EditarTabelaSQL("ManuInsert")
    End Sub
    Private Sub BtnImagemHomeManu_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemHomeManu.ButtonClickMasterRace
        Botao(BtnImagemHomeManu)
        Panel1.Show()
        Panel1.BringToFront()
        Inserir_EditarTabelaSQL("ManuInsert")
    End Sub
    '
    'Editar Manutenção
    '
    Private Sub BtnImagemManuEdit_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemManuEdit.ButtonClickMasterRace
        Botao(BtnImagemManuEdit)
        If LstVManu.SelectedItems.Count > 0 Then
            Panel1.Show()
            Panel1.BringToFront()
            Inserir_EditarTabelaSQL("ManuEdit", LstVManu.SelectedItems(0).Text.ToString)
        Else
            MsgBox("Selecione um abastecimento")
        End If
    End Sub
    '
    '
    ''''''''''''''''''''Pagina de Despesas
    '
    '
    'Despesas
    '
    Private Sub BtnImagem4_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagem4.ButtonClickMasterRace
        MenuPrincipal(3, True)
        If DetalhesUtilizador.TipoUtilizadorCod = 1 Then
            TabelaVer(LstVDesp, "select Coddesp,Data_Efetuada as Data,fornecedores.Nome as Fornecedor,tipodesp.nome as Tipo ,concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Sim' order by Veiculo_km", "LstVDesp")
        Else
            TabelaVer(LstVDesp, "select Coddesp,Data_Efetuada as Data,fornecedores.Nome as Fornecedor,tipodesp.nome as Tipo ,concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Sim'  and Utilizador.coduser='" + DetalhesUtilizador.CodUser.ToString + "' order by Veiculo_km", "LstVDesp")
        End If
        LblDesp.Font = GetInstance(12, FontStyle.Bold)
        GrpDesp.Font = GetInstance(12, FontStyle.Bold)
        GrpDespNota.Font = GetInstance(8, FontStyle.Bold)
    End Sub
    '
    'Detalhes despesas
    '
    Private Sub LstVDesp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVDesp.Click
        DetalhesDesp(LstVDesp.SelectedItems(0).Text)
    End Sub
    '
    'Inserir Despesas
    '
    Private Sub BtnImagemDespInsert_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemDespInsert.ButtonClickMasterRace
        Botao(BtnImagemDespInsert)
        Panel1.Show()
        Panel1.BringToFront()
        Inserir_EditarTabelaSQL("DespInsert")
    End Sub
    Private Sub BtnImagemHomeDesep_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemHomeDesep.ButtonClickMasterRace
        Botao(BtnImagemHomeDesep)
        Panel1.Show()
        Panel1.BringToFront()
        Inserir_EditarTabelaSQL("DespInsert")
    End Sub
    '
    'Editar Despesas
    '
    Private Sub BtnImagemDespEdit_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemDespEdit.ButtonClickMasterRace
        Botao(BtnImagemDespEdit)
        If LstVDesp.SelectedItems.Count > 0 Then
            Panel1.Show()
            Panel1.BringToFront()
            Inserir_EditarTabelaSQL("DespEdit", LstVDesp.SelectedItems(0).Text.ToString)
        Else
            MsgBox("Selecione um abastecimento")
        End If
    End Sub
    '
    '
    ''''''''''''''''''''Pagina de Agenda
    '
    '
    'Agenda
    '
    Private Sub BtnImagem5_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagem5.ButtonClickMasterRace
        MenuPrincipal(4, True)
        If DetalhesUtilizador.TipoUtilizadorCod = 1 Then
            TabelaVer(LstVAgendaDesp, "select CodDesp,Data_agendada as 'Data Agendada',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,TipoDesp.Nome as Tipo from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Nao'", "LstVAgendaDesp")
            TabelaVer(LstVAgendaManu, "select Codmanu,Data_agendada as 'Data Agendada',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,tipoManu.Nome as Tipo from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Nao'", "LstVAgendaManu")
        Else
            TabelaVer(LstVAgendaDesp, "select CodDesp,Data_agendada as 'Data Agendada',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,TipoDesp.Nome as Tipo from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Nao' and despesas.coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaDesp")
            TabelaVer(LstVAgendaManu, "select Codmanu,Data_agendada as 'Data Agendada',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,tipoManu.Nome as Tipo from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Nao' and coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaManu")
        End If
        
        BtnImagemAgendaManu.EstadoBotao = True
        MenuAgenda(0)
        GrpAgendaDesp.Font = GetInstance(12, FontStyle.Bold)
        GrpAgendaDespNota.Font = GetInstance(8, FontStyle.Bold)
        GrpAgendaManu.Font = GetInstance(12, FontStyle.Bold)
        GrpAgendaManuNota.Font = GetInstance(8, FontStyle.Bold)
    End Sub
    '
    'Menu Agenda
    '
    Private Sub BtnImagemAgendaManu_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemAgendaManu.ButtonClickMasterRace
        MenuAgenda(0)
    End Sub
    Private Sub BtnImagemAgendaDesp_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemAgendaDesp.ButtonClickMasterRace
        MenuAgenda(1)
    End Sub
    '
    'Detalhes da Agenda
    '
    Private Sub LstVAgendaDesp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVAgendaDesp.Click
        If LstVAgendaDesp.SelectedItems.Count > 0 Then
            DetalhesAgendaDesp(LstVAgendaDesp.SelectedItems(0).Text)
        End If

    End Sub
    Private Sub LstVAgendaManu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVAgendaManu.Click
        If LstVAgendaManu.SelectedItems.Count > 0 Then
            DetalhesAgendaManu(LstVAgendaManu.SelectedItems(0).Text)
        End If
    End Sub
    '
    'Inserir Agenda nas despesas
    '
    Private Sub BtnImagemAgendaDespInsert_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAgendaDespInsert.ButtonClickMasterRace
        Botao(BtnImagemAgendaDespInsert)
        Panel1.Show()
        Panel1.BringToFront()

        Inserir_EditarTabelaSQL("AgendaDespInsert")
    End Sub
    '
    'Apagar Despesa Agendada
    '
    Private Sub BtnImagemAgendaDespApagar_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemAgendaDespApagar.ButtonClickMasterRace
        Botao(BtnImagemAgendaDespApagar)
        If LstVAgendaDesp.SelectedItems.Count > 0 Then
            ApagarDados("despesas", LstVAgendaDesp.SelectedItems(0).Text.ToString)
            TabelaVer(LstVAgendaDesp, "select CodDesp,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,TipoDesp.Nome as Tipo, LembrarPor as 'Lembrar por:' from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Nao' and despesas.coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaDesp")
            TabelaVer(LstVAgendaManu, "select Codmanu,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,tipoManu.Nome as Tipo, LembrarPor as 'Lembrar por:' from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Nao' and coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaManu")
        Else
            MsgBox("Selecione a despesa")
        End If
    End Sub
    '
    'Reagendar Despesa
    '
    Private Sub BtnImagemAgendaDespReagendar_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAgendaDespReagendar.ButtonClickMasterRace
        Botao(BtnImagemAgendaDespReagendar)
        If LstVAgendaDesp.SelectedItems.Count > 0 Then
            Panel1.Show()
            Panel1.BringToFront()
            Inserir_EditarTabelaSQL("AgendaDespReagendar", LstVAgendaDesp.SelectedItems(0).Text.ToString)
        Else
            MsgBox("Selecione a despesa")
        End If
    End Sub
    '
    'Agenda Executada Despesa
    '
    Private Sub BtnImagemAgendaDespExecutar_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAgendaDespExecutar.ButtonClickMasterRace
        Botao(BtnImagemAgendaDespExecutar)
        If LstVAgendaDesp.SelectedItems.Count > 0 Then
            Panel1.Show()
            Panel1.BringToFront()
            Inserir_EditarTabelaSQL("AgendaDespExecutar", LstVAgendaDesp.SelectedItems(0).Text.ToString)
        Else
            MsgBox("Selecione a despesa")
        End If
    End Sub
    '
    'Apagar Manutenção Agendada
    '
    Private Sub BtnImagemAgendaManuApagar_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAgendaManuApagar.ButtonClickMasterRace
        Botao(BtnImagemAgendaManuApagar)
        If LstVAgendaManu.SelectedItems.Count > 0 Then
            ApagarDados("manutencao", LstVAgendaManu.SelectedItems(0).Text.ToString)
            TabelaVer(LstVAgendaDesp, "select CodDesp,Data_agendada as 'Data Agendada',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,TipoDesp.Nome as Tipo from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Nao' and despesas.coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaDesp")
            TabelaVer(LstVAgendaManu, "select Codmanu,Data_agendada as 'Data Agendada',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,tipoManu.Nome as Tipo from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Nao' and coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaManu")
        Else
            MsgBox("Selecione a despesa")
        End If
    End Sub
    '
    'Reagendar Manutenão
    '
    Private Sub BtnImagemAgendaManuReagemdar_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAgendaManuReagendar.ButtonClickMasterRace
        Botao(BtnImagemAgendaManuReagendar)
        If LstVAgendaManu.SelectedItems.Count > 0 Then
            Panel1.Show()
            Panel1.BringToFront()
            Inserir_EditarTabelaSQL("AgendaManuReagendar", LstVAgendaManu.SelectedItems(0).Text.ToString)
        Else
            MsgBox("Selecione a Manutenão")
        End If
    End Sub
    '
    'Inserir Agenda Manutenção
    '
    Private Sub BtnImagemAgendaManuInsert_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAgendaManuInsert.ButtonClickMasterRace
        Botao(BtnImagemAgendaManuInsert)
        Panel1.Show()
        Panel1.BringToFront()
        Inserir_EditarTabelaSQL("AgendaManuInsert")
    End Sub
    '
    'Agenda Executada Manutenção
    '
    Private Sub BtnImagemAgendaManuExecutar_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAgendaManuExecutar.ButtonClickMasterRace
        Botao(BtnImagemAgendaManuExecutar)
        If LstVAgendaManu.SelectedItems.Count > 0 Then
            Panel1.Show()
            Panel1.BringToFront()
            Inserir_EditarTabelaSQL("AgendaManuExecutar", LstVAgendaManu.SelectedItems(0).Text.ToString)
        Else
            MsgBox("Selecione a despesa")
        End If
    End Sub
    '
    '
    ''''''''''''''''''''Pagina de Definições
    '
    '
    'Definições
    '
    Private Sub BtnImagem6_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagem6.ButtonClickMasterRace
        MenuPrincipal(5, True)
        LblDef.Font = GetInstance(12, FontStyle.Bold)
        If My.Settings.SqlDistancia = "Km" Then
            BtnImagemDistancia.Texto = "Km"
            BtnImagemDistancia.Left = 5
            BtnImagemDistanciaOff.Texto = "Mi"
            BtnImagemDistanciaOff.Left = 100 - 5
        ElseIf My.Settings.SqlDistancia = "Mi" Then
            BtnImagemDistancia.Left = 100 - 5
            BtnImagemDistancia.Texto = "Mi"
            BtnImagemDistanciaOff.Texto = "Km"
            BtnImagemDistanciaOff.Left = 5
        End If
        If My.Settings.SqlMoeda = "Euro" Then
            BtnImagemDinheiro.Texto = "€"
            BtnImagemDinheiro.Left = 5
            BtnImagemDinheiroOff.Texto = "US$"
            BtnImagemDinheiroOff.Left = 100 - 5
        ElseIf My.Settings.SqlMoeda = "Dolar" Then
            BtnImagemDinheiro.Left = 100 - 5
            BtnImagemDinheiro.Texto = "US$"
            BtnImagemDinheiroOff.Texto = "€"
            BtnImagemDinheiroOff.Left = 5
        End If
        If My.Settings.SqlVolume = "L" Then
            BtnImagemVolume.Texto = "L"
            BtnImagemVolume.Left = 5
            BtnImagemVolumeOff.Texto = "Us Gal"
            BtnImagemVolumeOff.Left = 100 - 5
        ElseIf My.Settings.SqlVolume = "UsGal" Then
            BtnImagemVolume.Texto = "Us Gal"
            BtnImagemVolume.Left = 100 - 5
            BtnImagemVolumeOff.Texto = "L"
            BtnImagemVolumeOff.Left = 5
        End If
    End Sub
    '
    'Definições do Programa
    '
    Private Sub BtnDistancia()
        If My.Settings.SqlDistancia = "Km" Then
            My.Settings.SqlDistancia = "Mi"
            BtnImagemDistancia.Texto = "Mi"
            BtnImagemDistancia.Left = 100 - 5
            BtnImagemDistanciaOff.Texto = "Km"
            BtnImagemDistanciaOff.Left = 5
        ElseIf My.Settings.SqlDistancia = "Mi" Then
            My.Settings.SqlDistancia = "Km"
            BtnImagemDistancia.Texto = "Km"
            BtnImagemDistancia.Left = 5
            BtnImagemDistanciaOff.Texto = "Mi"
            BtnImagemDistanciaOff.Left = 100 - 5
        End If
    End Sub
    Private Sub BtnDinheiro()
        If My.Settings.SqlMoeda = "Euro" Then
            My.Settings.SqlMoeda = "Dolar"
            BtnImagemDinheiro.Texto = "US$"
            BtnImagemDinheiro.Left = 100 - 5
            BtnImagemDinheiroOff.Texto = "€"
            BtnImagemDinheiroOff.Left = 5
        ElseIf My.Settings.SqlMoeda = "Dolar" Then
            My.Settings.SqlMoeda = "Euro"
            BtnImagemDinheiro.Texto = "€"
            BtnImagemDinheiro.Left = 5
            BtnImagemDinheiroOff.Texto = "US$"
            BtnImagemDinheiroOff.Left = 100 - 5
        End If
    End Sub
    Private Sub BtnVolume()
        If My.Settings.SqlVolume = "L" Then
            My.Settings.SqlVolume = "UsGal"
            BtnImagemVolume.Texto = "Us Gal"
            BtnImagemVolume.Left = 100 - 5
            BtnImagemVolumeOff.Texto = "L"
            BtnImagemVolumeOff.Left = 5
        ElseIf My.Settings.SqlVolume = "UsGal" Then
            My.Settings.SqlVolume = "L"
            BtnImagemVolume.Texto = "L"
            BtnImagemVolume.Left = 5
            BtnImagemVolumeOff.Texto = "Us Gal"
            BtnImagemVolumeOff.Left = 100 - 5
        End If
    End Sub
    Private Sub BtnImagemDistanciaOff_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemDistanciaOff.ButtonClickMasterRace
        Botao(BtnImagemDistanciaOff)
        BtnDistancia()
    End Sub
    Private Sub BtnImagemDinheiroOff_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemDinheiroOff.ButtonClickMasterRace
        Botao(BtnImagemDinheiroOff)
        BtnDinheiro()
    End Sub
    Private Sub BtnImagemVolume_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemVolume.ButtonClickMasterRace
        Botao(BtnImagemVolume)
        BtnVolume()
    End Sub
    Private Sub BtnImagemVolumeOff_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemVolumeOff.ButtonClickMasterRace
        Botao(BtnImagemVolumeOff)
        BtnVolume()
    End Sub
    Private Sub BtnImagemDistancia_ButtonClickMasterRace_1(sender As Object, e As EventArgs) Handles BtnImagemDistancia.ButtonClickMasterRace
        Botao(BtnImagemDistancia)
        BtnDistancia()
    End Sub
    Private Sub BtnImagemDinheiro_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemDinheiro.ButtonClickMasterRace
        Botao(BtnImagemDinheiro)
        BtnDinheiro()
    End Sub
    '
    '
    ''''''''''''''''''''Pagina de Administração
    '
    '
    'Área de Administração
    '
    Private Sub BtnImagem7_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagem7.ButtonClickMasterRace
        MenuPrincipal(6, True)
        BtnImagemAdminUtilizador.EstadoBotao = True
        MenuAdmin(0)
        TabelaVer(LstVAdminUtilizador, "Select CodUser,CodUser as 'Codigo',Nome_Registo as 'Nome de Registo',Designacao as 'Designação' from utilizador, TipoUser where Utilizador.CodtipoU=TipoUser.CodTipoU order by CodUser", "LstVUtilizador")
        TabelaVer(LstVAdminVeiculo, "Select Codvei,Codvei as Codigo, Matricula, TipoVei.Nome as 'Tipo de Veículo' from Veiculos,TipoVei where veiculos.CodtipoV=TipoVei.CodTipoV", "LstVVeiculo")
        TabelaVer(LstVAdminFornecedores, "Select Codforn,Codforn as Codigo, Fornecedores.Nome ,tipoFor.Nome as 'Tipo de Fornecedor' from fornecedores,Tipofor where fornecedores.Codtipof=tipoFor.Codtipof", "LstVAdminFornecedores")
    End Sub
    '
    'Detalhes Utilizador 
    '
    Private Sub LstVUtilizador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVAdminUtilizador.Click
        BtnImagemAdminUtilizadorAtivar.EstadoBotao = True
        If LstVAdminUtilizador.SelectedItems.Count > 0 Then
            DetalhesUtilizadorAdmin(LstVAdminUtilizador.SelectedItems(0).Text)
        End If
        If LstVAdminUtilizador.SelectedItems.Count > 0 Then
            If LstVAdminUtilizador.SelectedItems(0).SubItems(3).Text() = "Admin" Then
                BtnImagemAdminUtilizadorAtivar.Texto = "Editar"
                BtnImagemAdminUtilizadorAtivar.Enabled = False
            ElseIf LstVAdminUtilizador.SelectedItems(0).SubItems(3).Text() = "Guest" Or LstVAdminUtilizador.SelectedItems(0).SubItems(3).Text() = "Desativado" Then
                BtnImagemAdminUtilizadorAtivar.Texto = "Ativar"
                BtnImagemAdminUtilizadorAtivar.Enabled = True
                BtnImagemAdminUtilizadorAtivar.EstadoBotao = False
            Else
                BtnImagemAdminUtilizadorAtivar.Texto = "Editar"
                BtnImagemAdminUtilizadorAtivar.Enabled = True
                BtnImagemAdminUtilizadorAtivar.EstadoBotao = False
            End If
        End If
    End Sub
    '
    'Detalhes Veiculos
    '
    Private Sub LstVAdminVeiculoClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVAdminVeiculo.Click
        Try
            DetalhesVeiculosAdmin(LstVAdminVeiculo.SelectedItems(0).Text)
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub
    '
    'Detalhes Fornecedores
    '
    Private Sub LstVAdminFornecedoresClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVAdminFornecedores.Click
        If LstVAdminFornecedores.SelectedItems.Count > 0 Then
            DetalhesFornecedorAdmin(LstVAdminFornecedores.SelectedItems(0).Text)
        End If

    End Sub
    '
    'Inserir Fornecedores
    '
    Private Sub BtnImagemAdminFornecedoresInserir_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemAdminFornecedoresInserir.ButtonClickMasterRace
        Botao(BtnImagemAdminFornecedoresInserir)
        PnlAdminInserir.Show()
        PnlAdminInserir.BringToFront()
        Inserir_EditarTabelaSQLAdmin("FornecedorInsert")
    End Sub
    '
    'Ativar Utizador
    '
    Private Sub BtnImagemAdminUtilizadorAtivar_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAdminUtilizadorAtivar.ButtonClickMasterRace
        Botao(BtnImagemAdminUtilizadorAtivar)
        If LstVAdminUtilizador.SelectedItems.Count > 0 Then
            PnlAdminInserir.Show()
            PnlAdminInserir.BringToFront()
            Inserir_EditarTabelaSQLAdmin("UtilizadorAtivar", LstVAdminUtilizador.SelectedItems(0).Text.ToString)
        Else
            MsgBox("Selecione um utilizador")
        End If
    End Sub
    '
    'Editar Utilizador
    '
    Private Sub BtnImagemAdminUtilizadorEdit_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAdminUtilizadorEdit.ButtonClickMasterRace
        Botao(BtnImagemAdminUtilizadorEdit)
        If LstVAdminUtilizador.SelectedItems.Count > 0 Then
            PnlAdminInserir.Show()
            PnlAdminInserir.BringToFront()
            Inserir_EditarTabelaSQLAdmin("UtilizadorEdit", LstVAdminUtilizador.SelectedItems(0).Text.ToString)
        Else
            MsgBox("Selecione um utilizador")
        End If
    End Sub
    '
    'Inserir Utilizador
    '
    Private Sub BtnImagemAdminUtilizadorInsert_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAdminUtilizadorInsert.ButtonClickMasterRace
        Botao(BtnImagemAdminUtilizadorInsert)
        PnlAdminInserir.Show()
        PnlAdminInserir.BringToFront()
        Inserir_EditarTabelaSQLAdmin("")
    End Sub
    '
    'Inserir Veiculos
    '
    Private Sub BtnImagemAdminVeiculosInsert_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAdminVeiculosInsert.ButtonClickMasterRace
        Botao(BtnImagemAdminVeiculosInsert)
        PnlAdminInserir.Show()
        PnlAdminInserir.BringToFront()
        Inserir_EditarTabelaSQLAdmin("VeiculoInsert")
    End Sub
    '
    'Menu
    '
    Private Sub BtnImagemAdminUtilizador_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAdminUtilizador.ButtonClickMasterRace
        MenuAdmin(0)
    End Sub
    Private Sub BtnImagemAdminVeiculos_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAdminVeiculos.ButtonClickMasterRace
        MenuAdmin(1)
    End Sub
    Private Sub BtnImagemAdminFornecedores_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAdminFornecedores.ButtonClickMasterRace
        MenuAdmin(2)
    End Sub
    Private Sub BtnImagemAdminMisc_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAdminMisc.ButtonClickMasterRace
        MenuAdmin(3)
        TabelaVerAdmin(LstAdminCidade, "SELECT * FROM pais", "Pais", "CodPais", "Nome")
        TabelaVerAdmin(LstAdminCidadeEditPais, "SELECT * FROM pais", "Pais", "CodPais", "Nome")
        TabelaVerAdmin(LstAdminCidadeEdit, "SELECT * FROM Cidade", "Cidade", "CodCi", "Nome")
    End Sub
    '
    'Botoes Inserir/Editar
    '


    '
    '
    ''''''''''''''''''''Pagina de Login/Registar
    '
    '
    'Entrar Pagina de Registar
    '
    Private Sub BtnImagemRegistarEntrar_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemRegistarEntrar.ButtonClickMasterRace
        Botao(BtnImagemRegistarEntrar)
        LoadOrder.RegistarPage()
    End Sub
    '
    'Sair da Pagina de Registar
    '
    Private Sub BtnImagemCancelar_ButtonClickMasterRace_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemCancelar.ButtonClickMasterRace
        Botao(BtnImagemCancelar)
        LoadOrder.LoginPage()
        TxtEmailReg.Text = ""
        TxtUserReg.Text = ""
        TxtPwdReg1.Text = ""
        TxtPwdReg2.Text = ""
    End Sub
    '
    'Registar Utilizador
    '
    Private Sub BtnImagemRegistar_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemRegistar.ButtonClickMasterRace
        Botao(BtnImagemRegistar)
        'Por codigo
        If RegistarUtilizador(TxtUserReg.Text, TxtPwdReg1.Text, TxtPwdReg2.Text, TxtEmailReg.Text, TxtNomeProprioReg.Text, TxtApelidoReg.Text) = True Then
            MsgBox("Utilizador registado com sucesso!", MsgBoxStyle.Information, "Registar Utilizador")
        End If
    End Sub
    '
    'Login
    '
    Private Sub BtnImagemLogin_ButtonClickMasterRace(ByVal sender As Object, ByVal e As EventArgs) Handles BtnImagemLogin.ButtonClickMasterRace
        Botao(BtnImagemLogin)
        linhaSQL = "Server=" + My.Settings.SqlDBServer + ";Database=" + My.Settings.SqlDBNome + ";Uid=" + My.Settings.SqlDBUser + ";Pwd=" + My.Settings.SqlDBConPass + ";Connect timeout=30;Convert Zero Datetime=True;"
        If Login(TxtUserLogin.Text, HashPassword(TxtPwdLogin.Text)) = True Then
            If DetalhesUtilizador.TipoUtilizadorCod = 1 Then 'Só Admin
                LoadOrder.MenuPrincipalPage()
                If DetalhesUtilizador.CodVeiculo = 0 Then
                    LblHomeServico.Text = "EM SERVIÇO     NÂO"
                    LblHomeConcluido.Text = "CONCLUIDOS     " + DetalhesUtilizador.ServicosCompletos + ""
                    LblHomeDespesas.Text = "DESPESAS     " + DetalhesUtilizador.Despesas + " " + MoedaSimbolo() + ""
                    lblHomeVeiculo.Text = ""
                    BtnImagemHomeAbast.Enabled = False
                    BtnImagemHomeManu.Enabled = False
                    BtnImagemHomeDesep.Enabled = False
                    BtnImagemHomeTerminar.Enabled = False

                    BtnImagemDespInsert.Enabled = False
                    BtnImagemDespEdit.Enabled = False
                    BtnImagemManuInsert.Enabled = False
                    BtnImagemManuEdit.Enabled = False
                    BtnImagemAbastEdit.Enabled = False
                    BtnImagemAbastInsert.Enabled = False

                 

                Else
                    LblHomeServico.Text = "EM SERVIÇO     SIM"
                    LblHomeConcluido.Text = "CONCLUIDOS     " + DetalhesUtilizador.ServicosCompletos + ""
                    LblHomeDespesas.Text = "DESPESAS     " + DetalhesUtilizador.Despesas + ""
                    lblHomeVeiculo.Text = DetalhesUtilizador.VeiMarca + " " + DetalhesUtilizador.VeiModelo + " " + DetalhesUtilizador.VeiMatricula
                    BtnImagemHomeAbast.Enabled = False
                    BtnImagemHomeManu.Enabled = False
                    BtnImagemHomeDesep.Enabled = False
                    BtnImagemHomeTerminar.Enabled = False

                    BtnImagemDespInsert.Enabled = False
                    BtnImagemDespEdit.Enabled = False
                    BtnImagemManuInsert.Enabled = False
                    BtnImagemManuEdit.Enabled = False
                    BtnImagemAbastEdit.Enabled = False
                    BtnImagemAbastInsert.Enabled = False


                    BtnImagemAgendaDespApagar.Enabled = False
                    BtnImagemAgendaDespReagendar.Enabled = False
                    BtnImagemAgendaDespInsert.Enabled = False
                    BtnImagemAgendaDespExecutar.Enabled = False

                    BtnImagemAgendaManuApagar.Enabled = False
                    BtnImagemAgendaManuReagendar.Enabled = False
                    BtnImagemAgendaManuInsert.Enabled = False
                    BtnImagemAgendaManuExecutar.Enabled = False
                End If
                BtnImagem2.Show()
                BtnImagem3.Show()
                BtnImagem4.Show()
                BtnImagem5.Show()
                BtnImagem6.Show()
                BtnImagem7.Show()
                BtnImagem8.Show()
            ElseIf DetalhesUtilizador.TipoUtilizadorCod = 2 Then
                MsgBox("Este Utilizador está a ser validado pela Administração", MsgBoxStyle.Information, "Acesso Negado")
                Exit Sub
            ElseIf DetalhesUtilizador.TipoUtilizadorCod = 5 Then
                MsgBox("Este Utilizador foi desativado pela Administração", MsgBoxStyle.Information, "Acesso Negado")
                Exit Sub
            Else
                If DetalhesUtilizador.CodVeiculo = 0 Then
                    LblHomeServico.Text = "EM SERVIÇO     NÂO"
                    LblHomeConcluido.Text = "CONCLUIDOS     " + DetalhesUtilizador.ServicosCompletos + ""
                    LblHomeDespesas.Text = "DESPESAS     " + DetalhesUtilizador.Despesas + " " + MoedaSimbolo() + ""
                    BtnImagemHomeAbast.Enabled = False
                    BtnImagemHomeManu.Enabled = False
                    BtnImagemHomeDesep.Enabled = False
                    BtnImagemHomeTerminar.Enabled = False

                    BtnImagemDespInsert.Enabled = False
                    BtnImagemDespEdit.Enabled = False
                    BtnImagemManuInsert.Enabled = False
                    BtnImagemManuEdit.Enabled = False
                    BtnImagemAbastEdit.Enabled = False
                    BtnImagemAbastInsert.Enabled = False


                    BtnImagemAgendaDespApagar.Enabled = False
                    BtnImagemAgendaDespReagendar.Enabled = False
                    BtnImagemAgendaDespInsert.Enabled = False
                    BtnImagemAgendaDespExecutar.Enabled = False

                    BtnImagemAgendaManuApagar.Enabled = False
                    BtnImagemAgendaManuReagendar.Enabled = False
                    BtnImagemAgendaManuInsert.Enabled = False
                    BtnImagemAgendaManuExecutar.Enabled = False
                Else
                    LblHomeServico.Text = "EM SERVIÇO     SIM"
                    LblHomeConcluido.Text = "CONCLUIDOS     " + DetalhesUtilizador.ServicosCompletos + ""
                    LblHomeDespesas.Text = "DESPESAS     " + DetalhesUtilizador.Despesas + ""
                    BtnImagemHomeAbast.Enabled = True
                    BtnImagemHomeManu.Enabled = True
                    BtnImagemHomeDesep.Enabled = True
                    BtnImagemHomeTerminar.Enabled = True

                    BtnImagemDespInsert.Enabled = True
                    BtnImagemDespEdit.Enabled = True
                    BtnImagemManuInsert.Enabled = True
                    BtnImagemManuEdit.Enabled = True
                    BtnImagemAbastEdit.Enabled = True
                    BtnImagemAbastInsert.Enabled = True

                    BtnImagemAgendaDespApagar.Enabled = True
                    BtnImagemAgendaDespReagendar.Enabled = True
                    BtnImagemAgendaDespInsert.Enabled = True
                    BtnImagemAgendaDespExecutar.Enabled = True

                    BtnImagemAgendaManuApagar.Enabled = True
                    BtnImagemAgendaManuReagendar.Enabled = True
                    BtnImagemAgendaManuInsert.Enabled = True
                    BtnImagemAgendaManuExecutar.Enabled = True
                End If
                LoadOrder.MenuPrincipalPage()
                BtnImagem2.Show()
                BtnImagem3.Show()
                BtnImagem4.Show()
                BtnImagem5.Show()
                BtnImagem6.Show()
                BtnImagem7.Hide()
                BtnImagem8.Hide()
            End If
        Else
            Exit Sub
        End If
        TmrHome.Enabled = True
        MenuPrincipal(0)
        PnlMenu.Show()
        'LoadOrder.l2()
    End Sub
    '
    'Abrir Página de Conexão á BD
    '
    Private Sub BtnImagemMenuConnect_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemMenuConnect.ButtonClickMasterRace
        PnlBDDef.Show()
        PnlBDDef.BringToFront()
        Botao(BtnImagemMenuConnect)
        TxtBDDef.Text = My.Settings.SqlDBServer
        TxtBDDef1.Text = My.Settings.SqlDBUser
        TxtBDDef2.Text = My.Settings.SqlDBConPass
        TxtBDDef3.Text = My.Settings.SqlDBNome

        LblServer1.Text = "Servidor:"
        LblServer2.Text = "Utilizador:"
        LblServer3.Text = "Password:"
        LblServer4.Text = "Base de Dados:"

        LblDefServer.Font = GetInstance(12, FontStyle.Bold)
        TxtBDDef.Font = GetInstance(8, FontStyle.Bold)
        TxtBDDef1.Font = GetInstance(8, FontStyle.Bold)
        TxtBDDef2.Font = GetInstance(8, FontStyle.Bold)
        TxtBDDef3.Font = GetInstance(8, FontStyle.Bold)

        LblServer1.Font = GetInstance(8, FontStyle.Bold)
        LblServer2.Font = GetInstance(8, FontStyle.Bold)
        LblServer3.Font = GetInstance(8, FontStyle.Bold)
        LblServer4.Font = GetInstance(8, FontStyle.Bold)
    End Sub
    '
    'Fechar Página
    '
    Private Sub BtnImagemBDDefCancel_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemBDDefCancel.ButtonClickMasterRace
        Botao(BtnImagemBDDefCancel)
        PnlBDDef.Hide()
        PnlBDDef.SendToBack()
    End Sub
    '
    'Guardar Configurações de Conexão
    '
    Private Sub BtnImagemBDDefSave_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemBDDefSave.ButtonClickMasterRace
        Botao(BtnImagemBDDefSave)
        My.Settings.SqlDBServer = TxtBDDef.Text
        My.Settings.SqlDBUser = TxtBDDef1.Text
        My.Settings.SqlDBConPass = TxtBDDef2.Text
        My.Settings.SqlDBNome = TxtBDDef3.Text
        PnlBDDef.Hide()
        PnlBDDef.SendToBack()
    End Sub
    '
    '
    ''''''''''''''''''''Menu do Utilizador
    '
    '
    'Abrir Menu Utilizador
    '
    Private Sub LblUserName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblUtilzadorMenu.Click
        If PnlUser.Visible = True Then
            PnlUser.Hide()
        Else
            PnlUser.Show()
            PnlUser.BringToFront()
        End If
    End Sub
    '
    'HighLight do Menu de Utilizador
    '
    Private Sub LblUserName_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblUtilzadorMenu.MouseEnter
        LblUtilzadorMenu.ForeColor = Color.White 'No futuro Opção para mudar?
    End Sub
    '
    'HighLight do Menu de Utilizador
    '
    Private Sub LblUserName_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblUtilzadorMenu.MouseLeave
        LblUtilzadorMenu.ForeColor = Color.DarkGray 'No futuro Opção para mudar?
    End Sub
    '
    'Sobre o Programa
    '
    Sub LblAboutUs_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LblAboutUs.Click
        AboutBox1.Show()
    End Sub
    '
    'Logout do Programa
    '
    Private Sub LblLogOut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LblLogOut.Click
        If PnlMenu.Right = 36 Then
            PnlMenu.Left = 200
            For a = 0 To NMenuPrincipal
                BtnImagemMenuPrincipal(a).Left = 0
            Next
            BtnMenu1.zEstadoBotao = False
            BtnMenu1.resetbtn()
        End If
        BtnImagem1.EstadoBotao = True
        LoadOrder.LoginPage()
        PnlLogin.Show()
        PnlHome.Hide()
        LblUtilzadorMenu.Hide()
        PnlUser.Hide()
        PnlDefUtilizador.Hide()
        TmrHome.Enabled = False
        'Limpar Utilizador Anterior

        DetalhesUtilizador = New UtilizadorDetalhes
    End Sub
    '
    'Abrir Menu Utilizador
    '
    Private Sub LblConta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LblConta.Click
        If PnlDefUtilizador.Visible = False Then
            MenuUtilizador()
            PnlDefUtilizador.Visible = True
            PnlDefUtilizador.BringToFront()
            PnlUser.Hide()
        Else
            PnlDefUtilizador.Visible = False
        End If
    End Sub
    '
    '
    ''''''''''''''''''''Menu Detalhes do Utilizador
    '
    '
    'Editar Utilizador
    '
    Private Sub BtnDefUtilizadorInfoEdit_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDefUtilizadorInfoEdit.ButtonClickMasterRace
        Botao(BtnDefUtilizadorInfoEdit)
        PnlAdminInserir.BringToFront()
        PnlAdminInserir.Show()
        Inserir_EditarTabelaSQLAdmin("UtilizadorEdit", DetalhesUtilizador.CodUser)
        TxtAdminInserir1.Hide()
        TxtAdminInserir6.Hide()
        LblAdminInserir1.Hide()
        LblAdminInserir7.Hide()
    End Sub
    '
    'Menu Definições de Utilizador
    '
    Private Sub BtnImagemDefUtilizadorInfo_ButtonClickMasterRace(ByVal sender As Object, ByVal e As EventArgs) Handles BtnImagemDefUtilizadorInfo.ButtonClickMasterRace
        MenuDefUtilizador(0)
    End Sub
    Private Sub BtnImagemDefUtilizadorContato_ButtonClickMasterRace(ByVal sender As Object, ByVal e As EventArgs) Handles BtnImagemDefUtilizadorContato.ButtonClickMasterRace
        MenuDefUtilizador(1)
    End Sub
    '
    '
    ''''''''''''''''''''PANEL DE EDITAR E INSERIR
    '
    '
    'Cancelar Inserir/Editar
    '
    Private Sub BtnImagemInserirCancelar_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemInserirCancelar.ButtonClickMasterRace
        Botao(BtnImagemInserirCancelar)
        TxtInserirQuilometros.Text = ""
        TxtInserirQuantidade.Text = ""
        TxtInserirValor.Text = ""
        LblInserirQuilometros.Text = "Quilometros:"
        TxtInserirNota.Text = ""
        TxtInserirQuilometros.Enabled = True
        Panel1.Hide()
    End Sub
    '
    'Inserir/Editar
    '
    Private Sub BtnImagemInserirInserir_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemInserirInserir.ButtonClickMasterRace
        Botao(BtnImagemInserirInserir)
        'AREA DE TESTE

        'FIM DE AREA
        If SQL.TabelaSelecionada = "AbastInsert" Then
            '
            'Inserir Abastecimento 
            '
            If TxtInserirQuilometros.Text <> "" And TxtInserirQuantidade.Text <> "" And TxtInserirValor.Text <> "" And LstInserirFornecedor.SelectedItems.Count > 0 Then
                If RegexMatch(TxtInserirQuilometros.Text, "(?:\d*\.*)?\d+") And RegexMatch(TxtInserirQuilometros.Text, "[,.]") = False And RegexMatch(TxtInserirQuilometros.Text, "[a-zA-Z]+") = False And RegexMatch(TxtInserirQuantidade.Text, "(?:\d*\.*)?\d+") And RegexMatch(TxtInserirQuantidade.Text, "[a-zA-Z]+") = False And RegexMatch(TxtInserirValor.Text, "(?:\d*\.*)?\d+") And RegexMatch(TxtInserirValor.Text, "[a-zA-Z]+") = False Then
                    If TxtInserirQuilometros.Text > UltimoKM() Then
                        InserirDados("AbastInsert")
                    Else
                        MsgBox("Campos Inválidos.", MsgBoxStyle.Information, "Campos Inválidos")
                        Exit Sub
                    End If
                Else
                    MsgBox("Campos Inválidos.", MsgBoxStyle.Information, "Campos Inválidos")
                    Exit Sub
                End If
            Else
                MsgBox("Preencha todos os campos.", MsgBoxStyle.Information, "Campos Inválidos")
                Exit Sub
            End If
        ElseIf SQL.TabelaSelecionada = "AbastEdit" Then
            '
            'Editar Abastecimento 
            '
            If TxtInserirQuilometros.Text <> "" And TxtInserirQuantidade.Text <> "" And TxtInserirValor.Text <> "" And LstInserirFornecedor.SelectedItems.Count > 0 Then
                If RegexMatch(TxtInserirQuantidade.Text, "(?:\d*\.*)?\d+") And RegexMatch(TxtInserirQuantidade.Text, "[a-zA-Z]+") = False And RegexMatch(TxtInserirValor.Text, "(?:\d*\.*)?\d+") And RegexMatch(TxtInserirValor.Text, "[a-zA-Z]+") = False Then
                    EditarDados("AbastEdit")
                Else
                    MsgBox("Campos Inválidos.", MsgBoxStyle.Information, "Campos Inválidos")
                    Exit Sub
                End If
            Else
                MsgBox("Preencha todos os campos.", MsgBoxStyle.Information, "Campos Inválidos")
                Exit Sub
            End If
            TabelaVer(LstVAbastecimento, "select CodVeiAbast,Data,Nome as Fornecedor,concat(ROUND((quantidade/" + VolumeConversao().ToString + "),2),' " + VolumeSimbolo() + "') as 'Quantidade',concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "' ,concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador  from VeiCondu,veiabast,veiculos,fornecedores,Utilizador where VeiCondu.Codvei=Veiculos.Codvei and Veiculos.Codvei=Veiabast.CodVei and fornecedores.Codforn=Veiabast.Codforn and Utilizador.CodUser=Veiabast.Coduser and VeiCondu.EmUso='Sim' and Utilizador.CodUser='" + DetalhesUtilizador.CodUser + "'order by CodVeiAbast DESC", "LstVAbastecimento")
        ElseIf SQL.TabelaSelecionada = "ManuInsert" Then
            '
            'Inserir manutenção
            '
            If TxtInserirQuilometros.Text <> "" And TxtInserirValor.Text <> "" And LstInserirFornecedor.SelectedItems.Count > 0 And LstInserirTipo.SelectedItems.Count > 0 Then
                If RegexMatch(TxtInserirQuilometros.Text, "(?:\d*\.*)?\d+") And RegexMatch(TxtInserirQuilometros.Text, "[,.]") = False And RegexMatch(TxtInserirQuilometros.Text, "[a-zA-Z]+") = False And RegexMatch(TxtInserirValor.Text, "(?:\d*\.*)?\d+") And RegexMatch(TxtInserirValor.Text, "[a-zA-Z]+") = False Then
                    If TxtInserirQuilometros.Text > UltimoKM() Then
                        InserirDados("ManuInsert")
                    Else
                        MsgBox("Campos Inválidos.", MsgBoxStyle.Information, "Campos Inválidos")
                        Exit Sub
                    End If
                Else
                    MsgBox("Campos Inválidos.", MsgBoxStyle.Information, "Campos Inválidos")
                    Exit Sub
                End If
            Else
                MsgBox("Preencha todos os campos.", MsgBoxStyle.Information, "Campos Inválidos")
                Exit Sub
            End If
        ElseIf SQL.TabelaSelecionada = "ManuEdit" Then
            '
            'Editar manutenção
            '
            If TxtInserirQuilometros.Text <> "" And TxtInserirValor.Text <> "" And LstInserirFornecedor.SelectedItems.Count > 0 And LstInserirTipo.SelectedItems.Count > 0 Then
                If RegexMatch(TxtInserirValor.Text, "(?:\d*\.*)?\d+") And RegexMatch(TxtInserirValor.Text, "[a-zA-Z]+") = False Then
                    EditarDados("ManuEdit")
                Else
                    MsgBox("Campos Inválidos.", MsgBoxStyle.Information, "Campos Inválidos")
                    Exit Sub
                End If
            Else
                MsgBox("Preencha todos os campos.", MsgBoxStyle.Information, "Campos Inválidos")
                Exit Sub
            End If
            TabelaVer(LstVManu, "select Codmanu,Data_Efetuada as Data,fornecedores.Nome as Fornecedor,tipoManu.Nome as Tipo,concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao.ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador from Utilizador,VeiCondu,Manutencao,veiculos,fornecedores,tipomanu where VeiCondu.Codvei=Veiculos.Codvei and Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and Utilizador.CodUser=Manutencao.Coduser and efetuada='Sim' and EmUso='Sim' and Manutencao.CodUser='" + DetalhesUtilizador.CodUser + "'", "LstVManu")
        ElseIf SQL.TabelaSelecionada = "DespInsert" Then
            '
            'Inserir Despesa
            '
            If TxtInserirQuilometros.Text <> "" And TxtInserirValor.Text <> "" And LstInserirFornecedor.SelectedItems.Count > 0 And LstInserirTipo.SelectedItems.Count > 0 Then
                If RegexMatch(TxtInserirQuilometros.Text, "(?:\d*\.*)?\d+") And RegexMatch(TxtInserirQuilometros.Text, "[,.]") = False And RegexMatch(TxtInserirQuilometros.Text, "[a-zA-Z]+") = False And RegexMatch(TxtInserirValor.Text, "(?:\d*\.*)?\d+") And RegexMatch(TxtInserirValor.Text, "[a-zA-Z]+") = False Then
                    If TxtInserirQuilometros.Text > UltimoKM() Then
                        InserirDados("DespInsert")
                    Else
                        MsgBox("Campos Inválidos.", MsgBoxStyle.Information, "Campos Inválidos")
                        Exit Sub
                    End If
                Else
                    MsgBox("Campos Inválidos.", MsgBoxStyle.Information, "Campos Inválidos")
                    Exit Sub
                End If
            Else
                MsgBox("Preencha todos os campos.", MsgBoxStyle.Information, "Campos Inválidos")
                Exit Sub
            End If

        ElseIf SQL.TabelaSelecionada = "DespEdit" Then
            '
            'Editar Despesa
            '
            If TxtInserirQuilometros.Text <> "" And TxtInserirValor.Text <> "" And LstInserirFornecedor.SelectedItems.Count > 0 And LstInserirTipo.SelectedItems.Count > 0 Then
                If RegexMatch(TxtInserirValor.Text, "(?:\d*\.*)?\d+") And RegexMatch(TxtInserirValor.Text, "[a-zA-Z]+") = False Then
                    EditarDados("DespEdit")
                Else
                    MsgBox("Campos Inválidos.", MsgBoxStyle.Information, "Campos Inválidos")
                    Exit Sub
                End If
            Else
                MsgBox("Preencha todos os campos.", MsgBoxStyle.Information, "Campos Inválidos")
                Exit Sub
            End If
            TabelaVer(LstVDesp, "select Coddesp,Data_Efetuada as Data,fornecedores.Nome as Fornecedor,tipodesp.nome as Tipo ,concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Sim'  and Veiculos.CodVei='" + DetalhesUtilizador.CodVeiculo.ToString + "' order by Veiculo_km", "LstVDesp")
        ElseIf SQL.TabelaSelecionada = "AgendaDespInsert" Then
            '
            'Inserir Agenda Despesa
            '
            If LstInserirTipo.SelectedItems.Count > 0 Then
                If DateTimePicker1.Value > Date.Now Then
                    InserirDados("AgendaDespInsert")
                Else
                    MsgBox("Campos Inválidos.", MsgBoxStyle.Information, "Campos Inválidos")
                    Exit Sub
                End If
            Else
                MsgBox("Preencha todos os campos.", MsgBoxStyle.Information, "Campos Inválidos")
                Exit Sub
            End If
            TabelaVer(LstVAgendaDesp, "select CodDesp,Data_agendada as 'Data Agendada',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,TipoDesp.Nome as Tipo from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Nao' and despesas.coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaDesp")
            TabelaVer(LstVAgendaManu, "select Codmanu,Data_agendada as 'Data Agendada',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,tipoManu.Nome as Tipo from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Nao' and coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaManu")
        ElseIf SQL.TabelaSelecionada = "AgendaDespReagendar" Then
            '
            'Reagendar Data Despesa
            '
            If DateTimePicker1.Value > Date.Now Then
                EditarDados("AgendaDespReagendar")
            Else
                MsgBox("Campos Inválidos.", MsgBoxStyle.Information, "Campos Inválidos")
                Exit Sub
            End If
            TabelaVer(LstVAgendaDesp, "select CodDesp,Data_agendada as 'Data Agendada',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,TipoDesp.Nome as Tipo from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Nao' and despesas.coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaDesp")
            TabelaVer(LstVAgendaManu, "select Codmanu,Data_agendada as 'Data Agendada',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,tipoManu.Nome as Tipo from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Nao' and coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaManu")
        ElseIf SQL.TabelaSelecionada = "AgendaDespExecutar" Then
            '
            'Criar Despesa Agendada
            '
            If TxtInserirQuilometros.Text <> "" And TxtInserirValor.Text <> "" And LstInserirFornecedor.SelectedItems.Count > 0 And LstInserirTipo.SelectedItems.Count > 0 Then
                If RegexMatch(TxtInserirQuilometros.Text, "(?:\d*\.*)?\d+") And RegexMatch(TxtInserirQuilometros.Text, "[,.]") = False And RegexMatch(TxtInserirQuilometros.Text, "[a-zA-Z]+") = False And RegexMatch(TxtInserirValor.Text, "(?:\d*\.*)?\d+") And RegexMatch(TxtInserirValor.Text, "[a-zA-Z]+") = False Then
                    If TxtInserirQuilometros.Text > UltimoKM() Then
                        EditarDados("AgendaDespExecutar")
                    Else
                        MsgBox("Campos Inválidos.", MsgBoxStyle.Information, "Campos Inválidos")
                        Exit Sub
                    End If
                Else
                    MsgBox("Campos Inválidos.", MsgBoxStyle.Information, "Campos Inválidos")
                    Exit Sub
                End If
            Else
                MsgBox("Preencha todos os campos.", MsgBoxStyle.Information, "Campos Inválidos")
                Exit Sub
            End If
            TabelaVer(LstVAgendaDesp, "select CodDesp,Data_agendada as 'Data Agendada',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,TipoDesp.Nome as Tipo from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Nao' and despesas.coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaDesp")
            TabelaVer(LstVAgendaManu, "select Codmanu,Data_agendada as 'Data Agendada',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,tipoManu.Nome as Tipo from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Nao' and coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaManu")
        ElseIf SQL.TabelaSelecionada = "AgendaManuReagendar" Then
            '
            'Reagendar Data Manutenção
            '
            If DateTimePicker1.Value > Date.Now Then
                EditarDados("AgendaManuReagendar")
            Else
                MsgBox("Campos Inválidos.", MsgBoxStyle.Information, "Campos Inválidos")
                Exit Sub
            End If
            TabelaVer(LstVAgendaDesp, "select CodDesp,Data_agendada as 'Data Agendada',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,TipoDesp.Nome as Tipo from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Nao' and despesas.coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaDesp")
            TabelaVer(LstVAgendaManu, "select Codmanu,Data_agendada as 'Data Agendada',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,tipoManu.Nome as Tipo from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Nao' and coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaManu")
        ElseIf SQL.TabelaSelecionada = "AgendaManuExecutar" Then
            If TxtInserirQuilometros.Text <> "" And TxtInserirValor.Text <> "" And LstInserirFornecedor.SelectedItems.Count > 0 And LstInserirTipo.SelectedItems.Count > 0 Then
                If RegexMatch(TxtInserirQuilometros.Text, "(?:\d*\.*)?\d+") And RegexMatch(TxtInserirQuilometros.Text, "[,.]") = False And RegexMatch(TxtInserirQuilometros.Text, "[a-zA-Z]+") = False And RegexMatch(TxtInserirValor.Text, "(?:\d*\.*)?\d+") And RegexMatch(TxtInserirValor.Text, "[a-zA-Z]+") = False Then
                    If TxtInserirQuilometros.Text > UltimoKM() Then
                        EditarDados("AgendaManuExecutar")
                    Else
                        MsgBox("Campos Inválidos.", MsgBoxStyle.Information, "Campos Inválidos")
                        Exit Sub
                    End If
                Else
                    MsgBox("Campos Inválidos.", MsgBoxStyle.Information, "Campos Inválidos")
                    Exit Sub
                End If
            Else
                MsgBox("Preencha todos os campos.", MsgBoxStyle.Information, "Campos Inválidos")
                Exit Sub
            End If
            TabelaVer(LstVAgendaDesp, "select CodDesp,Data_agendada as 'Data Agendada',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,TipoDesp.Nome as Tipo from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Nao' and despesas.coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaDesp")
            TabelaVer(LstVAgendaManu, "select Codmanu,Data_agendada as 'Data Agendada',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,tipoManu.Nome as Tipo from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Nao' and coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaManu")
        ElseIf SQL.TabelaSelecionada = "AgendaManuInsert" Then
            '
            'Inserir Agenda Manutenção
            '
            If LstInserirTipo.SelectedItems.Count > 0 Then
                If DateTimePicker1.Value > Date.Now Then
                    InserirDados("AgendaManuInsert")
                Else
                    MsgBox("Campos Inválidos.", MsgBoxStyle.Information, "Campos Inválidos")
                    Exit Sub
                End If
            Else
                MsgBox("Preencha todos os campos.", MsgBoxStyle.Information, "Campos Inválidos")
                Exit Sub
            End If
            TabelaVer(LstVAgendaDesp, "select CodDesp,Data_agendada as 'Data Agendada',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,TipoDesp.Nome as Tipo from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Nao' and despesas.coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaDesp")
            TabelaVer(LstVAgendaManu, "select Codmanu,Data_agendada as 'Data Agendada',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,tipoManu.Nome as Tipo from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Nao' and coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaManu")
        End If
        Panel1.Hide()
        TxtInserirQuilometros.Text = ""
        TxtInserirQuantidade.Text = ""
        TxtInserirValor.Text = ""
        TxtInserirNota.Text = ""
        LblInserirDataAgendada.Text = "Data Efetuada:"
        LblInserirQuilometros.Text = "Quilometros:"
        TxtInserirQuilometros.Enabled = True
    End Sub
    '
    'Graficos
    '
    Private Sub BtnImagem11_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagem8.ButtonClickMasterRace
        MenuPrincipal(7, True)
        RectangleShape3.Top = GrpRelatorio.Bottom - RectangleShape3.Height
        RectangleShape2.Top = RectangleShape3.Top - RectangleShape2.Height
        RectangleShape1.Top = RectangleShape2.Top - RectangleShape1.Height
        EscolherGrafDados(ChkGraf1)
        LblRelatorioTitulo.Text = ChkGraf1.Text
        LblRelatorioTitulo.Font = GetInstance(12, FontStyle.Bold)
        GrpRelatorio.Font = GetInstance(12, FontStyle.Bold)
        LblRelatorio.Font = GetInstance(12, FontStyle.Bold)
        For Each c As Control In GrpRelatorio.Controls
            c.Font = GetInstance(8, FontStyle.Bold)
        Next
    End Sub

    Public Where As String = ""

    Private Sub EscolherGrafDados(ByVal CheckSelect As CheckBox)
        ChkGraf1.Checked = False
        ChkGraf2.Checked = False
        ChkGraf3.Checked = False
        CheckSelect.Checked = True
        If ChkGraf1.Checked = True Then
            CmbLista.Enabled = False
            BtnImagemProcurar.Enabled = False
            LblRelatorio1.Show()
            LblRelatorio2.Hide() 'Desativado
            GraficoSelecionado()
        ElseIf ChkGraf2.Checked = True Then
            CmbLista.Enabled = True
            BtnImagemProcurar.Enabled = True
            LblRelatorio1.Hide()
            LblRelatorio2.Hide()
            RelatorioSelecionado("Where CodUser=")
        ElseIf ChkGraf3.Checked = True Then
            CmbLista.Enabled = True
            BtnImagemProcurar.Enabled = True
            LblRelatorio1.Hide()
            LblRelatorio2.Hide()
            RelatorioSelecionado("Where CodVei=")
        End If
    End Sub

    Private Sub ChkGraf1_Click(sender As Object, e As EventArgs) Handles ChkGraf1.Click
        EscolherGrafDados(ChkGraf1)
        LblRelatorioTitulo.Text = ChkGraf1.Text
    End Sub

    Private Sub ChkGraf2_Click(sender As Object, e As EventArgs) Handles ChkGraf2.Click
        EscolherGrafDados(ChkGraf2)
        LblRelatorioTitulo.Text = ChkGraf2.Text
    End Sub

    Private Sub ChkGraf3_Click(sender As Object, e As EventArgs) Handles ChkGraf3.Click
        EscolherGrafDados(ChkGraf3)
        LblRelatorioTitulo.Text = ChkGraf3.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        If RELATORIO <> "" Then
            GraficoSelecionado(RELATORIO, CmbLista.SelectedValue.ToString)
        End If
    End Sub
    '
    'Adnmin
    '
    Private Sub BtnImagemInserirAdmin_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemInserirAdmin.ButtonClickMasterRace
        Botao(BtnImagemInserirAdmin)
        If SQL.TabelaSelecionadaAdmin = "VeiculoInsert" Then
            If TxtAdminInserir1.Text <> "" And TxtAdminInserir2.Text <> "" And TxtAdminInserir3.Text <> "" And TxtAdminInserir4.Text <> "" And TxtAdminInserir5.Text <> "" And LstAdminInserir.SelectedItems.Count > 0 And LstAdminInserir2.SelectedItems.Count > 0 Then
                If RegexMatch(TxtAdminInserir1.Text.ToString, "\b\d{2}[-.]?[a-zA-Z]{2}[-.]?\d{2}\b") = True Or RegexMatch(TxtAdminInserir1.Text.ToString, "\b[a-zA-Z]{2}[-.]?\d{2}[-.]?\d{2}\b") = True Or RegexMatch(TxtAdminInserir1.Text.ToString, "\b\d{2}[-.]?\d{2}[-.]?[a-zA-Z]{2}\b") = True And RegexMatch(TxtAdminInserir5.Text.ToString, "\b\d{4}\b") = True Then ' Verifica se a Matricula é portuguesa, Ano é 4 digitos 
                    InserirDadosAdmin("VeiculoInsert")
                Else
                    MsgBox("Campos Inválidos.", MsgBoxStyle.Information, "Campos Inválidos")
                    Exit Sub
                End If
            Else
                MsgBox("Preencha todos os campos.", MsgBoxStyle.Information, "Campos Inválidos")
                Exit Sub
            End If
        ElseIf SQL.TabelaSelecionadaAdmin = "VeiculoEdit" Then
            If TxtAdminInserir1.Text <> "" And TxtAdminInserir2.Text <> "" And TxtAdminInserir3.Text <> "" And TxtAdminInserir4.Text <> "" And TxtAdminInserir5.Text <> "" And LstAdminInserir.SelectedItems.Count > 0 And LstAdminInserir2.SelectedItems.Count > 0 Then
                If RegexMatch(TxtAdminInserir1.Text.ToString, "\b\d{2}[-.]?[a-zA-Z]{2}[-.]?\d{2}\b") = True Or RegexMatch(TxtAdminInserir1.Text.ToString, "\b[a-zA-Z]{2}[-.]?\d{2}[-.]?\d{2}\b") = True Or RegexMatch(TxtAdminInserir1.Text.ToString, "\b\d{2}[-.]?\d{2}[-.]?[a-zA-Z]{2}\b") = True And RegexMatch(TxtAdminInserir5.Text.ToString, "\b\d{4}\b") = True Then ' Verifica se a Matricula é portuguesa, Ano é 4 digitos 
                    EditarDadosAdmin("VeiculoEdit")
                Else
                    MsgBox("Campos Inválidos.", MsgBoxStyle.Information, "Campos Inválidos")
                    Exit Sub
                End If
            Else
                MsgBox("Preencha todos os campos.", MsgBoxStyle.Information, "Campos Inválidos")
                Exit Sub
            End If
            'ATUALIZADORLISTVIEW
        ElseIf SQL.TabelaSelecionadaAdmin = "FornecedorInsert" Then
            If TxtAdminInserir1.Text <> "" And TxtAdminInserir2.Text <> "" And TxtAdminInserir3.Text <> "" And TxtAdminInserir4.Text <> "" And TxtAdminInserir5.Text <> "" And TxtAdminInserir6.Text <> "" And LstAdminInserir.SelectedItems.Count > 0 And LstAdminInserir2.SelectedItems.Count > 0 Then
                'If RegexMatch(TxtAdminInserir1.Text.ToString, "\b\d{2}[-.]?[a-zA-Z]{2}[-.]?\d{2}\b") = True Or RegexMatch(TxtAdminInserir1.Text.ToString, "\b[a-zA-Z]{2}[-.]?\d{2}[-.]?\d{2}\b") = True Or RegexMatch(TxtAdminInserir1.Text.ToString, "\b\d{2}[-.]?\d{2}[-.]?[a-zA-Z]{2}\b") = True And RegexMatch(TxtAdminInserir5.Text.ToString, "\b\d{4}\b") = True Then ' Verifica se a Matricula é portuguesa, Ano é 4 digitos 
                InserirDadosAdmin("FornecedorInsert")
                'Else
                'MsgBox("Campos Inválidos.", MsgBoxStyle.Information, "Campos Inválidos")
                'Exit Sub
                'End If
        Else
            MsgBox("Preencha todos os campos.", MsgBoxStyle.Information, "Campos Inválidos")
            Exit Sub
        End If
        ElseIf SQL.TabelaSelecionadaAdmin = "FornecedorEdit" Then
            EditarDadosAdmin("FornecedorEdit")
            'AtualiadroLIstview
        ElseIf SQL.TabelaSelecionadaAdmin = "UtilizadorInsert" Then
            '
            'Desativado
            '
            MsgBox("Erro! Contate o administrador com o seguinte erro: Sem autorização ", MsgBoxStyle.Critical, "Erro!!!")
            Exit Sub
            InserirDados("UtilizadorInsert")
            TabelaVer(LstVAdminUtilizador, "Select CodUser,CodUser as 'Codigo',Nome_Registo as 'Nome de Registo',Designacao as 'Designação' from utilizador, TipoUser where Utilizador.CodtipoU=TipoUser.CodTipoU order by CodUser", "LstVUtilizador")
        ElseIf SQL.TabelaSelecionadaAdmin = "UtilizadorEdit" Then
            If TxtAdminInserir1.Text <> "" And TxtAdminInserir2.Text <> "" And TxtAdminInserir3.Text <> "" And TxtAdminInserir4.Text <> "" And TxtAdminInserir5.Text <> "" And TxtAdminInserir6.Text <> "" Then
                If RegexMatch(TxtAdminInserir5.Text.ToString, "9[1236][0-9]{7}|2[1-9][0-9]{7}") = True And RegexMatch(TxtAdminInserir6.Text.ToString, "([a-z0-9][-a-z0-9_\+\.]*[a-z0-9])@([a-z0-9][-a-z0-9\.]*[a-z0-9]\.(arpa|root|aero|biz|cat|com|coop|edu|gov|info|int|jobs|mil|mobi|museum|name|net|org|pro|tel|travel|ac|ad|ae|af|ag|ai|al|am|an|ao|aq|ar|as|at|au|aw|ax|az|ba|bb|bd|be|bf|bg|bh|bi|bj|bm|bn|bo|br|bs|bt|bv|bw|by|bz|ca|cc|cd|cf|cg|ch|ci|ck|cl|cm|cn|co|cr|cu|cv|cx|cy|cz|de|dj|dk|dm|do|dz|ec|ee|eg|er|es|et|eu|fi|fj|fk|fm|fo|fr|ga|gb|gd|ge|gf|gg|gh|gi|gl|gm|gn|gp|gq|gr|gs|gt|gu|gw|gy|hk|hm|hn|hr|ht|hu|id|ie|il|im|in|io|iq|ir|is|it|je|jm|jo|jp|ke|kg|kh|ki|km|kn|kr|kw|ky|kz|la|lb|lc|li|lk|lr|ls|lt|lu|lv|ly|ma|mc|md|mg|mh|mk|ml|mm|mn|mo|mp|mq|mr|ms|mt|mu|mv|mw|mx|my|mz|na|nc|ne|nf|ng|ni|nl|no|np|nr|nu|nz|om|pa|pe|pf|pg|ph|pk|pl|pm|pn|pr|ps|pt|pw|py|qa|re|ro|ru|rw|sa|sb|sc|sd|se|sg|sh|si|sj|sk|sl|sm|sn|so|sr|st|su|sv|sy|sz|tc|td|tf|tg|th|tj|tk|tl|tm|tn|to|tp|tr|tt|tv|tw|tz|ua|ug|uk|um|us|uy|uz|va|vc|ve|vg|vi|vn|vu|wf|ws|ye|yt|yu|za|zm|zw)|([0-9]{1,3}\.{3}[0-9]{1,3}))") Then
                    EditarDadosAdmin("UtilizadorEdit")
                Else
                    MsgBox("Campos Inválidos.", MsgBoxStyle.Information, "Campos Inválidos")
                    Exit Sub
                End If
            Else
                MsgBox("Preencha todos os campos.", MsgBoxStyle.Information, "Campos Inválidos")
                Exit Sub
            End If
            TabelaVer(LstVAdminUtilizador, "Select CodUser,CodUser as 'Codigo',Nome_Registo as 'Nome de Registo',Designacao as 'Designação' from utilizador, TipoUser where Utilizador.CodtipoU=TipoUser.CodTipoU order by CodUser", "LstVUtilizador")
        ElseIf SQL.TabelaSelecionadaAdmin = "UtilizadorAtivar" Then
            If LstAdminInserir.SelectedItems.Count > 0 Then
                EditarDadosAdmin("UtilizadorAtivar")
            Else
                MsgBox("Preencha todos os campos.", MsgBoxStyle.Information, "Campos Inválidos")
                Exit Sub
            End If
            TabelaVer(LstVAdminUtilizador, "Select CodUser,CodUser as 'Codigo',Nome_Registo as 'Nome de Registo',Designacao as 'Designação' from utilizador, TipoUser where Utilizador.CodtipoU=TipoUser.CodTipoU order by CodUser", "LstVUtilizador")
        ElseIf SQL.TabelaSelecionadaAdmin = "AssociarCarro" Then
            If LstAdminInserir3.SelectedItems.Count > 0 Then
                EditarDadosAdmin("AssociarCarro", LstVAdminUtilizador.SelectedItems(0).Text)
            Else
                MsgBox("Preencha todos os campos.", MsgBoxStyle.Information, "Campos Inválidos")
                Exit Sub
            End If


        End If
        PnlAdminInserir.Hide()
    End Sub

    Private Sub BtnImagemInserirCancelarAdmin_ButtonClickMasterRace_1(sender As Object, e As EventArgs) Handles BtnImagemInserirCancelarAdmin.ButtonClickMasterRace
        Botao(BtnImagemInserirCancelarAdmin)
        PnlAdminInserir.Hide()
    End Sub

    Private Sub BtnImagemAdminUtilizadorCarro_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemAdminUtilizadorCarro.ButtonClickMasterRace
        Botao(BtnImagemAdminUtilizadorCarro)
        If LstVAdminUtilizador.SelectedItems.Count > 0 Then
            PnlAdminInserir.Show()
            PnlAdminInserir.BringToFront()
            Inserir_EditarTabelaSQLAdmin("AssociarCarro", LstVAdminUtilizador.SelectedItems(0).Text.ToString)
        Else
            MsgBox("Selecione um utilizador")
        End If
    End Sub

    Private Sub BtnImagem10_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemAdminCidade.ButtonClickMasterRace
        Botao(BtnImagemAdminCidade)
        If MsgBox("Confirme a cidade a Inserir.", MsgBoxStyle.OkCancel, "Inserir Cidade") = MsgBoxResult.Cancel Then
            Exit Sub
        Else
            InserirDadosAdmin("Cidade")
            TxtAdminCidade.Text = ""
        End If
    End Sub

    Private Sub BtnImagem9_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemAdminDesativar.ButtonClickMasterRace
        Botao(BtnImagemAdminDesativar)
        If LstVAdminVeiculo.SelectedItems.Count > 0 Then
            EditarDadosAdmin("VeiculoDesativar", LstVAdminVeiculo.SelectedItems(0).Text)
        Else
            MsgBox("Selecione um Veiculo")
        End If
    End Sub


    Private Sub BtnImagemAdminVeiculoEdit_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemAdminVeiculoEdit.ButtonClickMasterRace
        Botao(BtnImagemAdminVeiculoEdit)
        If LstVAdminVeiculo.SelectedItems.Count > 0 Then
            PnlAdminInserir.Show()
            PnlAdminInserir.BringToFront()
            Inserir_EditarTabelaSQLAdmin("VeiculoEdit", LstVAdminVeiculo.SelectedItems(0).Text)
        Else
            MsgBox("Selecione um Veiculo")
        End If
    End Sub

    Private Sub BtnImagemAdminFornecedorEdit_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemAdminFornecedorEdit.ButtonClickMasterRace
        Botao(BtnImagemAdminFornecedorEdit)
        If LstVAdminFornecedores.SelectedItems.Count > 0 Then
            PnlAdminInserir.Show()
            PnlAdminInserir.BringToFront()
            Inserir_EditarTabelaSQLAdmin("FornecedorEdit", LstVAdminFornecedores.SelectedItems(0).Text)
        Else
            MsgBox("Selecione um Fornecedor")
        End If
    End Sub

    Private Sub BtnImagemCidadeEdit_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemCidadeEdit.ButtonClickMasterRace
        Botao(BtnImagemCidadeEdit)
        If MsgBox("Confirme a cidade a editar.", MsgBoxStyle.OkCancel, "Editar Cidade") = MsgBoxResult.Cancel Then
            Exit Sub
        Else
            EditarDadosAdmin("CidadeEdit", LstAdminCidadeEdit.SelectedValue.ToString)
        End If
        TxtAdminCidadeEdit.Text = ""
        TabelaVerAdmin(LstAdminCidadeEditPais, "SELECT * FROM pais", "Pais", "CodPais", "Nome")
        TabelaVerAdmin(LstAdminCidadeEdit, "SELECT * FROM Cidade", "Cidade", "CodCi", "Nome")
    End Sub

    Private Sub LstAdminCidadeEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstAdminCidadeEdit.SelectedIndexChanged
        SelecionarCidade(LstAdminCidadeEdit.SelectedValue.ToString)
    End Sub

    Private Sub BtnImagemDefUtilizador_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemDefUtilizador.ButtonClickMasterRace
        Botao(BtnImagemDefUtilizador)
        If PnlDefUtilizador.Visible = False Then
            MenuUtilizador()
            PnlDefUtilizador.Visible = True
            PnlDefUtilizador.BringToFront()
            PnlUser.Hide()
        Else
            PnlDefUtilizador.Visible = False
        End If
    End Sub


    Private Sub BtnImagemProcurar_ButtonClickMasterRace_1(sender As Object, e As EventArgs) Handles BtnImagemProcurar.ButtonClickMasterRace
        Botao(BtnImagemProcurar)
        If RELATORIO <> "" Then
            GraficoSelecionado(RELATORIO, CmbLista.SelectedValue.ToString)
        End If
    End Sub

    Private Sub GrpHomeInfo_Enter(sender As Object, e As EventArgs) Handles GrpHomeInfo.HandleCreated
        For Each c As Control In GrpHomeInfo.Controls
            If c.Name.Contains("BtnImagem") Then

            Else
                c.Font = Fonte.GetInstance(10, FontStyle.Bold)
                c.ForeColor = Color.White
            End If
        Next
    End Sub

    Private Sub BtnImagemHomeTerminar_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemHomeTerminar.ButtonClickMasterRace
        Botao(BtnImagemHomeTerminar)
        If DetalhesUtilizador.CodVeiculo <> 0 Then
            If MsgBox("Confirme se o Serviço está completo.", MsgBoxStyle.YesNo, "Serviço Completo") = MsgBoxResult.No Then
                Exit Sub
            Else
                EditarDadosAdmin("TerminarServico", DetalhesUtilizador.CodVeiculo)
            End If
        Else
            MsgBox("Não tem um serviço ativo.", MsgBoxStyle.Information, "Sem Serviço")
        End If
    End Sub

    Private Sub BtnImagem8_ButtonClickMasterRace(sender As Object, e As EventArgs)

    End Sub
    Private Sub BtnImagem9_ButtonClickMasterRace_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub TmrHome_Tick(sender As Object, e As EventArgs) Handles TmrHome.Tick
        BuscarDadosUtilizador(DetalhesUtilizador.NomeRegisto)
        If DetalhesUtilizador.CodVeiculo = 0 Then
            LblHomeServico.Text = "EM SERVIÇO     NÂO"
            LblHomeConcluido.Text = "CONCLUIDOS     " + DetalhesUtilizador.ServicosCompletos + ""
            LblHomeDespesas.Text = "DESPESAS     " + DetalhesUtilizador.Despesas + " " + MoedaSimbolo() + ""
            lblHomeVeiculo.Text = ""
        Else
            LblHomeServico.Text = "EM SERVIÇO     SIM"
            LblHomeConcluido.Text = "CONCLUIDOS     " + DetalhesUtilizador.ServicosCompletos + ""
            LblHomeDespesas.Text = "DESPESAS     " + DetalhesUtilizador.Despesas + ""
            lblHomeVeiculo.Text = DetalhesUtilizador.VeiMarca + " " + DetalhesUtilizador.VeiModelo + " " + DetalhesUtilizador.VeiMatricula
        End If
    End Sub
End Class