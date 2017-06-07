Imports System.Drawing
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
    'Total_horas_perdidas_aqui = 6
    '
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

    Private Sub Botao(ByVal c As BtnImagem)
        If c.EstadoBotao = True Then
            c.EstadoBotao = False
            c.VerificarEstadoBotao()
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        Fade(1) 'VEr
    End Sub
    ' VEr

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

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'Area de teste
        CarroMaisCaro()
        '
        '
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
        'Adiciona evento a todos os objetos do programa

        'Arrays de Objetos
        '
        'Menu definições 
        '
        panelMenuDefUtilizador(0) = PnlDefUtilizadorInfo
        panelMenuDefUtilizador(1) = PnlDefUtilizadorContato
        BtnImagemMenuDefUtilizador1(0) = BtnImagemDefUtilizadorInfo
        BtnImagemMenuDefUtilizador1(1) = BtnImagemDefUtilizadorContato
        '
        'Menu Principal
        '
        panelMenuPrincipal(0) = PnlHome
        panelMenuPrincipal(1) = Panel2
        panelMenuPrincipal(2) = Panel3
        panelMenuPrincipal(3) = Panel4
        panelMenuPrincipal(4) = Panel5
        panelMenuPrincipal(5) = Panel6
        panelMenuPrincipal(6) = Panel7
        panelMenuPrincipal(7) = Panel9
        BtnImagemMenuPrincipal(0) = BtnImagem1
        BtnImagemMenuPrincipal(1) = BtnImagem2
        BtnImagemMenuPrincipal(2) = BtnImagem3
        BtnImagemMenuPrincipal(3) = BtnImagem4
        BtnImagemMenuPrincipal(4) = BtnImagem5
        BtnImagemMenuPrincipal(5) = BtnImagem6
        BtnImagemMenuPrincipal(6) = BtnImagem7
        BtnImagemMenuPrincipal(7) = BtnImagem11
        '
        'Menu Agenda
        '
        BtnImagemMenuAgenda(0) = BtnImagemAgendaManu
        BtnImagemMenuAgenda(1) = BtnImagemAgendaDesp
        panelMenuAgenda(0) = PnlAgendaManu
        panelMenuAgenda(1) = PnlAgendaDesp
        '
        'Menu Admin
        '
        BtnImagemMenuAdmin(0) = BtnImagemAdminUtilizador
        BtnImagemMenuAdmin(1) = BtnImagemAdminVeiculos
        BtnImagemMenuAdmin(2) = BtnImagemAdminFornecedores
        BtnImagemMenuAdmin(3) = BtnImagemAdminMisc
        panelMenuAdmin(0) = PnlAdminUtilizador
        panelMenuAdmin(1) = PnlAdminVeiculos
        panelMenuAdmin(2) = PnlAdminFornecedores
        panelMenuAdmin(3) = PnlAdminMisc

        Dim a As Integer
        For a = 0 To NMenuPrincipal
            For Each c As Control In panelMenuPrincipal(a).Controls
                AddHandler c.MouseDown, AddressOf c_MouseDown
            Next
        Next

        'Arrays de Objetos

        'Panel1.Location = New Point((Me.DisplayRectangle.Width - Panel1.Width) / 2 + 100, (Me.DisplayRectangle.Height - Panel1.Height) / 2) 'Código para por no centro do ecrâ

        LblPnlHome.Font = Fonte.GetInstance(15, FontStyle.Bold)
        LblPnlHome.ForeColor = Color.White

        'IDK yet
        Fechar.Font = Fonte.GetInstance(12, FontStyle.Bold)
        Fechar.Text = "X"
        Fechar.ForeColor = Color.White
        Fechar.Left = PnlBarraTop.Right - 25
        Fechar.Top = (PnlBarraTop.Height - Fechar.Height) / 2

        LoadOrder.LoginPage() 'Aparencia
        Fade(0)
    End Sub



    Private Sub BtnImagem1_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagem1.ButtonClickMasterRace
        MenuPrincipal(0, False, True)
    End Sub
    Private Sub BtnImagem2_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagem2.ButtonClickMasterRace
        MenuPrincipal(1, True)
        TabelaVer(LstVAbastecimento, "select CodVeiAbast,Data,Nome as Fornecedor,concat(ROUND((quantidade/" + VolumeConversao().ToString + "),2),' " + VolumeSimbolo() + "') as 'Quantidade',concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "' ,concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador  from VeiCondu,veiabast,veiculos,fornecedores,Utilizador where VeiCondu.Codvei=Veiculos.Codvei and Veiculos.Codvei=Veiabast.CodVei and fornecedores.Codforn=Veiabast.Codforn and Utilizador.CodUser=Veiabast.Coduser and VeiCondu.EmUso='Sim' and Utilizador.CodUser='" + DetalhesUtilizador.CodUser + "'order by CodVeiAbast DESC", "LstVAbastecimento")
        LblAbast.Font = GetInstance(12, FontStyle.Bold)
        GrpAbast.Font = GetInstance(12, FontStyle.Bold)
        GrpAbastNotas.Font = GetInstance(8, FontStyle.Bold)
    End Sub
    Private Sub BtnImagem3_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagem3.ButtonClickMasterRace
        MenuPrincipal(2, True)
        TabelaVer(LstVManu, "select Codmanu,Data_Efetuada as Data,fornecedores.Nome as Fornecedor,tipoManu.Nome as Tipo,concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao.ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador from Utilizador,VeiCondu,Manutencao,veiculos,fornecedores,tipomanu where VeiCondu.Codvei=Veiculos.Codvei and Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and Utilizador.CodUser=Manutencao.Coduser and efetuada='Sim' and EmUso='Sim' and Manutencao.CodUser='" + DetalhesUtilizador.CodUser + "'", "LstVManu")
        LblManu.Font = GetInstance(12, FontStyle.Bold)
        GrpManu.Font = GetInstance(12, FontStyle.Bold)
        GrpManuNota.Font = GetInstance(8, FontStyle.Bold)
    End Sub
    Private Sub BtnImagem4_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagem4.ButtonClickMasterRace
        MenuPrincipal(3, True)
        TabelaVer(LstVDesp, "select Coddesp,Data_Efetuada as Data,fornecedores.Nome as Fornecedor,tipodesp.nome as Tipo ,concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Sim'  and Veiculos.CodVei='" + DetalhesUtilizador.CodVeiculo.ToString + "' order by Veiculo_km", "LstVDesp")
        LblDesp.Font = GetInstance(12, FontStyle.Bold)
        GrpDesp.Font = GetInstance(12, FontStyle.Bold)
        GrpDespNota.Font = GetInstance(8, FontStyle.Bold)
    End Sub

    Private Sub BtnImagem5_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagem5.ButtonClickMasterRace
        MenuPrincipal(4, True)
        TabelaVer(LstVAgendaDesp, "select CodDesp,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,TipoDesp.Nome as Tipo, LembrarPor as 'Lembrar por:' from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Nao' and despesas.coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaDesp")
        TabelaVer(LstVAgendaManu, "select Codmanu,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,tipoManu.Nome as Tipo, LembrarPor as 'Lembrar por:' from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Nao' and coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaManu")


        BtnImagemAgendaManu.EstadoBotao = True
        MenuAgenda(0)

        GrpAgendaDesp.Font = GetInstance(12, FontStyle.Bold)
        GrpAgendaDespNota.Font = GetInstance(8, FontStyle.Bold)

        GrpAgendaManu.Font = GetInstance(12, FontStyle.Bold)
        GrpAgendaManuNota.Font = GetInstance(8, FontStyle.Bold)
    End Sub

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

        MsgBox("TODO: Quilometros->Milhas,Litros->Galões, Linguagem, Aspeto, Etc")
    End Sub

    Private Sub BtnImagem7_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagem7.ButtonClickMasterRace
        MenuPrincipal(6, True)
        BtnImagemAdminUtilizador.EstadoBotao = True
        MenuAdmin(0)
        TabelaVer(LstVAdminUtilizador, "Select CodUser,CodUser as 'Codigo',Nome_Registo as 'Nome de Registo',Designacao as 'Designação' from utilizador, TipoUser where Utilizador.CodtipoU=TipoUser.CodTipoU order by CodUser", "LstVUtilizador")
        TabelaVer(LstVAdminVeiculo, "Select Codvei,Codvei as Codigo, Matricula, TipoVei.Nome as 'Tipo de Veículo' from Veiculos,TipoVei where veiculos.CodtipoV=TipoVei.CodTipoV", "LstVVeiculo")
        TabelaVer(LstVAdminFornecedores, "Select Codforn,Codforn as Codigo, Fornecedores.Nome ,tipoFor.Nome as 'Tipo de Fornecedor' from fornecedores,Tipofor where fornecedores.Codtipof=tipoFor.Codtipof", "LstVAdminFornecedores")
    End Sub

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
                Else
                    BtnImagemMenuPrincipal(6).Hide()
                End If
            Next
        End If
        BtnMenu1.zEstadoBotao = True
        BtnMenu1.resetbtn()
    End Sub

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
                Else
                    BtnImagemMenuPrincipal(6).Hide()
                End If
            Next
        End If
        BtnMenu1.zEstadoBotao = False
        BtnMenu1.resetbtn()
    End Sub

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

    Private Sub fechar_click(ByVal sender As Object, ByVal e As EventArgs) Handles Fechar.Click
        Close()
    End Sub

    Private Sub BtnImagemLogin_ButtonClickMasterRace(ByVal sender As Object, ByVal e As EventArgs) Handles BtnImagemLogin.ButtonClickMasterRace
        Botao(BtnImagemLogin)
        linhaSQL = "Server=" + My.Settings.SqlDBServer + ";Database=" + My.Settings.SqlDBNome + ";Uid=" + My.Settings.SqlDBUser + ";Pwd=" + My.Settings.SqlDBConPass + ";Connect timeout=30;Convert Zero Datetime=True;"
        If Login(TxtUserLogin.Text, HashPassword(TxtPwdLogin.Text)) = True Then
            If DetalhesUtilizador.TipoUtilizadorCod = 1 Then 'Só Admin
                LoadOrder.MenuPrincipalPage()
                BtnImagem2.Show()
                BtnImagem3.Show()
                BtnImagem4.Show()
                BtnImagem5.Show()
                BtnImagem6.Show()
                BtnImagem7.Show()
                BtnImagem7.Show()
            ElseIf DetalhesUtilizador.TipoUtilizadorCod = 2 Then
                MsgBox("WIP")

                LoadOrder.MenuPrincipalPage()
                BtnImagem2.Hide()
                BtnImagem3.Hide()
                BtnImagem4.Hide()
                BtnImagem5.Hide()
                BtnImagem6.Hide()
                BtnImagem7.Hide()
            Else
                MsgBox("WIP")
                LoadOrder.MenuPrincipalPage()
                BtnImagem2.Show()
                BtnImagem3.Show()
                BtnImagem4.Show()
                BtnImagem5.Show()
                BtnImagem6.Show()
                BtnImagem7.Hide()
            End If
        Else
            Exit Sub
        End If
        MenuPrincipal(0)
        PnlMenu.Show()

        'LoadOrder.l2()
    End Sub

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub Panel2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PnlBarraTop.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub
    Private Sub Panel2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PnlBarraTop.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub
    Private Sub Panel2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PnlBarraTop.MouseUp
        drag = False
    End Sub


    Private Sub BtnImagemRegistarEntrar_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemRegistarEntrar.ButtonClickMasterRace
        Botao(BtnImagemRegistarEntrar)
        LoadOrder.RegistarPage()
    End Sub

    Private Sub BtnImagemCancelar_ButtonClickMasterRace_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemCancelar.ButtonClickMasterRace
        Botao(BtnImagemCancelar)
        LoadOrder.LoginPage()
        TxtEmailReg.Text = ""
        TxtUserReg.Text = ""
        TxtPwdReg1.Text = ""
        TxtPwdReg2.Text = ""


    End Sub

    Private Sub BtnImagemRegistar_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemRegistar.ButtonClickMasterRace
        Botao(BtnImagemRegistar)
        'Por codigo
        If RegistarUtilizador(TxtUserReg.Text, TxtPwdReg1.Text, TxtPwdReg2.Text, TxtEmailReg.Text) = True Then
            MsgBox("INSERIDO COM SUCESSO")
        End If

    End Sub

    Private Sub LblUserName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblUtilzadorMenu.Click
        If PnlUser.Visible = True Then
            PnlUser.Hide()
        Else
            PnlUser.Show()
            PnlUser.BringToFront()
        End If
    End Sub

    Private Sub LblUserName_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblUtilzadorMenu.MouseEnter
        LblUtilzadorMenu.ForeColor = Color.White 'No futuro Opção para mudar?
    End Sub

    Private Sub LblUserName_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblUtilzadorMenu.MouseLeave
        LblUtilzadorMenu.ForeColor = Color.DarkGray 'No futuro Opção para mudar?
    End Sub

    Sub Label1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Label1.Click
        AboutBox1.Show()
    End Sub

    Private Sub Label3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Label3.Click
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
        'Limpar Utilizador Anterior
        DetalhesUtilizador = New UtilizadorDetalhes

    End Sub


    'Menu Utilizaqdor
    Private Sub Label2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Label2.Click
        If PnlDefUtilizador.Visible = False Then
            MenuUtilizador()
            PnlDefUtilizador.Visible = True
            PnlDefUtilizador.BringToFront()
            PnlUser.Hide()
        Else
            PnlDefUtilizador.Visible = False
        End If
    End Sub


    'Editar Utilizador
    Private Sub BtnDefUtilizadorInfoEdit_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDefUtilizadorInfoEdit.ButtonClickMasterRace
        Botao(BtnDefUtilizadorInfoEdit)
        If TxtUtilizadorUserDef.Enabled = False Then
            TxtUtilizadorUserDef.Enabled = True
            TxtUtilizadorNomePDef.Enabled = True
            TxtUtilizadorApelidoDef.Enabled = True
            TxtUtilizadorDataNascDef.Enabled = True
            TxtUtilizadorDataContratDef.Enabled = True
            TxtUtilizadorGeneroDef.Enabled = True
            TxtUtilizadorPagmentoDef.Enabled = True
            TxtUtilizadorHabilitacoesDef.Enabled = True
            TxtUtilizadorNotasDef.Enabled = True
            BtnDefUtilizadorInfoEdit.Texto = "Guardar"
        Else
            TxtUtilizadorUserDef.Enabled = False
            TxtUtilizadorNomePDef.Enabled = False
            TxtUtilizadorApelidoDef.Enabled = False
            TxtUtilizadorDataNascDef.Enabled = False
            TxtUtilizadorDataContratDef.Enabled = False
            TxtUtilizadorGeneroDef.Enabled = False
            TxtUtilizadorPagmentoDef.Enabled = False
            TxtUtilizadorHabilitacoesDef.Enabled = False
            TxtUtilizadorNotasDef.Enabled = False
            EditarUtilizador(TxtUtilizadorUserDef.Text.ToString, TxtUtilizadorNomePDef.Text.ToString, TxtUtilizadorApelidoDef.Text.ToString, TxtUtilizadorDataNascDef.Text.ToString, TxtUtilizadorDataContratDef.Text.ToString, TxtUtilizadorPagmentoDef.Text.ToString, TxtUtilizadorGeneroDef.Text.ToString, TxtUtilizadorHabilitacoesDef.Text.ToString, TxtUtilizadorNotasDef.Text.ToString)
            LoadOrder.MenuPrincipalPage()
            BtnDefUtilizadorInfoEdit.Texto = "Editar"
        End If
    End Sub

    'SubMenus
    '
    'Definições de Utilizador
    '
    Private Sub BtnImagemDefUtilizadorInfo_ButtonClickMasterRace(ByVal sender As Object, ByVal e As EventArgs) Handles BtnImagemDefUtilizadorInfo.ButtonClickMasterRace
        MenuDefUtilizador(0)
    End Sub

    Private Sub BtnImagemDefUtilizadorContato_ButtonClickMasterRace(ByVal sender As Object, ByVal e As EventArgs) Handles BtnImagemDefUtilizadorContato.ButtonClickMasterRace
        MenuDefUtilizador(1)
    End Sub
    '
    'Agenda
    '
    Private Sub BtnImagemAgendaManu_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemAgendaManu.ButtonClickMasterRace
        MenuAgenda(0)
    End Sub

    Private Sub BtnImagemAgendaDesp_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemAgendaDesp.ButtonClickMasterRace
        MenuAgenda(1)
    End Sub


    Private Sub LstVAbastecimento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVAbastecimento.Click
        DetalhesAbast(LstVAbastecimento.SelectedItems(0).Text)
    End Sub

    Private Sub LstVManu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVManu.Click
        DetalhesManu(LstVManu.SelectedItems(0).Text)
    End Sub

    Private Sub LstVDesp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVDesp.Click
        DetalhesDesp(LstVDesp.SelectedItems(0).Text)
    End Sub

    Private Sub LstVAgendaDesp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVAgendaDesp.Click
        DetalhesAgendaDesp(LstVAgendaDesp.SelectedItems(0).Text)
    End Sub

    Private Sub LstVAgendaManu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVAgendaManu.Click
        DetalhesAgendaManu(LstVAgendaManu.SelectedItems(0).Text)
    End Sub

    Private Sub LstVUtilizador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVAdminUtilizador.Click
        BtnImagemAdminUtilizadorAtivar.EstadoBotao = True
        Try
            DetalhesUtilizadorAdmin(LstVAdminUtilizador.SelectedItems(0).Text)
        Catch ex As Exception
        End Try

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

    Private Sub LstVAdminVeiculoClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVAdminVeiculo.Click
        DetalhesVeiculosAdmin(LstVAdminVeiculo.SelectedItems(0).Text)
    End Sub

    Private Sub LstVAdminFornecedoresClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstVAdminFornecedores.Click
        DetalhesFornecedorAdmin(LstVAdminFornecedores.SelectedItems(0).Text)
    End Sub

    Private Sub BtnImagemAbastInsert_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemAbastInsert.ButtonClickMasterRace
        Botao(BtnImagemAbastInsert)
        Panel1.Show()
        Panel1.BringToFront()
        Inserir_EditarTabelaSQL("AbastInsert")
    End Sub

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

    Private Sub BtnImagemManuInsert_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemManuInsert.ButtonClickMasterRace
        Botao(BtnImagemManuInsert)
        Panel1.Show()
        Panel1.BringToFront()
        Inserir_EditarTabelaSQL("ManuInsert")
    End Sub

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

    Private Sub BtnImagemDespInsert_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemDespInsert.ButtonClickMasterRace
        Botao(BtnImagemDespInsert)
        Panel1.Show()
        Panel1.BringToFront()
        Inserir_EditarTabelaSQL("DespInsert")
    End Sub

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
    'PANEL DE EDITAR E INSERIR
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
        CmbInserirAno.Invalidate()
        CmbInserirDia.Invalidate()
        CmbInserirMes.Invalidate()
    End Sub

    Private Sub BtnImagemInserirInserir_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemInserirInserir.ButtonClickMasterRace
        Botao(BtnImagemInserirInserir)
        'AREA DE TESTE
        MsgBox(String.Format("{0:yyyy-MM-dd}", DateTimePicker1.Value.Date))
        Exit Sub
        'FIM DE AREA
        If SQL.TabelaSelecionada = "AbastInsert" Then
            InserirDados("AbastInsert")
            TabelaVer(LstVAbastecimento, "select CodVeiAbast,Data,Nome as Fornecedor,concat(ROUND((quantidade/" + VolumeConversao().ToString + "),2),' " + VolumeSimbolo() + "') as 'Quantidade',concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "' ,concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador  from VeiCondu,veiabast,veiculos,fornecedores,Utilizador where VeiCondu.Codvei=Veiculos.Codvei and Veiculos.Codvei=Veiabast.CodVei and fornecedores.Codforn=Veiabast.Codforn and Utilizador.CodUser=Veiabast.Coduser and VeiCondu.EmUso='Sim' and Utilizador.CodUser='" + DetalhesUtilizador.CodUser + "'order by CodVeiAbast DESC", "LstVAbastecimento")
        ElseIf SQL.TabelaSelecionada = "AbastEdit" Then
            EditarDados("AbastEdit")
            TabelaVer(LstVAbastecimento, "select CodVeiAbast,Data,Nome as Fornecedor,concat(ROUND((quantidade/" + VolumeConversao().ToString + "),2),' " + VolumeSimbolo() + "') as 'Quantidade',concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "' ,concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador  from VeiCondu,veiabast,veiculos,fornecedores,Utilizador where VeiCondu.Codvei=Veiculos.Codvei and Veiculos.Codvei=Veiabast.CodVei and fornecedores.Codforn=Veiabast.Codforn and Utilizador.CodUser=Veiabast.Coduser and VeiCondu.EmUso='Sim' and Utilizador.CodUser='" + DetalhesUtilizador.CodUser + "'order by CodVeiAbast DESC", "LstVAbastecimento")
        ElseIf SQL.TabelaSelecionada = "ManuInsert" Then
            InserirDados("ManuInsert")
            TabelaVer(LstVManu, "select Codmanu,Data_Efetuada as Data,fornecedores.Nome as Fornecedor,tipoManu.Nome as Tipo,concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao.ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador from Utilizador,VeiCondu,Manutencao,veiculos,fornecedores,tipomanu where VeiCondu.Codvei=Veiculos.Codvei and Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and Utilizador.CodUser=Manutencao.Coduser and efetuada='Sim' and EmUso='Sim' and Manutencao.CodUser='" + DetalhesUtilizador.CodUser + "'", "LstVManu")
        ElseIf SQL.TabelaSelecionada = "ManuEdit" Then
            EditarDados("ManuEdit")
            TabelaVer(LstVManu, "select Codmanu,Data_Efetuada as Data,fornecedores.Nome as Fornecedor,tipoManu.Nome as Tipo,concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao.ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador from Utilizador,VeiCondu,Manutencao,veiculos,fornecedores,tipomanu where VeiCondu.Codvei=Veiculos.Codvei and Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and Utilizador.CodUser=Manutencao.Coduser and efetuada='Sim' and EmUso='Sim' and Manutencao.CodUser='" + DetalhesUtilizador.CodUser + "'", "LstVManu")
        ElseIf SQL.TabelaSelecionada = "DespInsert" Then
            InserirDados("DespInsert")
            TabelaVer(LstVDesp, "select Coddesp,Data_Efetuada as Data,fornecedores.Nome as Fornecedor,tipodesp.nome as Tipo ,concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Sim'  and Veiculos.CodVei='" + DetalhesUtilizador.CodVeiculo.ToString + "' order by Veiculo_km", "LstVDesp")
        ElseIf SQL.TabelaSelecionada = "DespEdit" Then
            EditarDados("DespEdit")
            TabelaVer(LstVDesp, "select Coddesp,Data_Efetuada as Data,fornecedores.Nome as Fornecedor,tipodesp.nome as Tipo ,concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Sim'  and Veiculos.CodVei='" + DetalhesUtilizador.CodVeiculo.ToString + "' order by Veiculo_km", "LstVDesp")
        ElseIf SQL.TabelaSelecionada = "AgendaDespInsert" Then
            InserirDados("AgendaDespInsert")
            TabelaVer(LstVAgendaDesp, "select CodDesp,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,TipoDesp.Nome as Tipo, LembrarPor as 'Lembrar por:' from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Nao' and despesas.coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaDesp")
            TabelaVer(LstVAgendaManu, "select Codmanu,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,tipoManu.Nome as Tipo, LembrarPor as 'Lembrar por:' from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Nao' and coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaManu")
        ElseIf SQL.TabelaSelecionada = "AgendaDespReagendar" Then
            EditarDados("AgendaDespReagendar")
            TabelaVer(LstVAgendaDesp, "select CodDesp,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,TipoDesp.Nome as Tipo, LembrarPor as 'Lembrar por:' from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Nao' and despesas.coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaDesp")
            TabelaVer(LstVAgendaManu, "select Codmanu,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,tipoManu.Nome as Tipo, LembrarPor as 'Lembrar por:' from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Nao' and coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaManu")
        ElseIf SQL.TabelaSelecionada = "AgendaDespExecutar" Then
            EditarDados("AgendaDespExecutar")
            TabelaVer(LstVAgendaDesp, "select CodDesp,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,TipoDesp.Nome as Tipo, LembrarPor as 'Lembrar por:' from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Nao' and despesas.coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaDesp")
            TabelaVer(LstVAgendaManu, "select Codmanu,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,tipoManu.Nome as Tipo, LembrarPor as 'Lembrar por:' from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Nao' and coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaManu")
        ElseIf SQL.TabelaSelecionada = "AgendaManuReagendar" Then
            EditarDados("AgendaManuReagendar")
            TabelaVer(LstVAgendaDesp, "select CodDesp,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,TipoDesp.Nome as Tipo, LembrarPor as 'Lembrar por:' from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Nao' and despesas.coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaDesp")
            TabelaVer(LstVAgendaManu, "select Codmanu,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,tipoManu.Nome as Tipo, LembrarPor as 'Lembrar por:' from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Nao' and coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaManu")
        ElseIf SQL.TabelaSelecionada = "AgendaManuExecutar" Then
            EditarDados("AgendaManuExecutar")
            TabelaVer(LstVAgendaDesp, "select CodDesp,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,TipoDesp.Nome as Tipo, LembrarPor as 'Lembrar por:' from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Nao' and despesas.coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaDesp")
            TabelaVer(LstVAgendaManu, "select Codmanu,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,tipoManu.Nome as Tipo, LembrarPor as 'Lembrar por:' from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Nao' and coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaManu")
        ElseIf SQL.TabelaSelecionada = "AgendaManuInsert" Then
            InserirDados("AgendaManuInsert")
            TabelaVer(LstVAgendaDesp, "select CodDesp,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,TipoDesp.Nome as Tipo, LembrarPor as 'Lembrar por:' from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Nao' and despesas.coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaDesp")
            TabelaVer(LstVAgendaManu, "select Codmanu,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,tipoManu.Nome as Tipo, LembrarPor as 'Lembrar por:' from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Nao' and coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaManu")
        End If
        Panel1.Hide()
        TxtInserirQuilometros.Text = ""
        TxtInserirQuantidade.Text = ""
        TxtInserirValor.Text = ""
        TxtInserirNota.Text = ""
        LblInserirDataAgendada.Text = "Data Efetuada:"
        LblInserirQuilometros.Text = "Quilometros:"
        TxtInserirQuilometros.Enabled = True
        CmbInserirAno.Invalidate()
        CmbInserirDia.Invalidate()
        CmbInserirMes.Invalidate()
    End Sub

    Private Sub BtnImagemAgendaDespInsert_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAgendaDespInsert.ButtonClickMasterRace
        Botao(BtnImagemAgendaDespInsert)
        Panel1.Show()
        Panel1.BringToFront()
        Inserir_EditarTabelaSQL("AgendaDespInsert")
    End Sub

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

    Private Sub BtnImagemAgendaManuApagar_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAgendaManuApagar.ButtonClickMasterRace
        Botao(BtnImagemAgendaManuApagar)
        If LstVAgendaManu.SelectedItems.Count > 0 Then
            ApagarDados("manutencao", LstVAgendaManu.SelectedItems(0).Text.ToString)
            TabelaVer(LstVAgendaDesp, "select CodDesp,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,TipoDesp.Nome as Tipo, LembrarPor as 'Lembrar por:' from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Nao' and despesas.coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaDesp")
            TabelaVer(LstVAgendaManu, "select Codmanu,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,tipoManu.Nome as Tipo, LembrarPor as 'Lembrar por:' from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Nao' and coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaManu")
        Else
            MsgBox("Selecione a despesa")
        End If
    End Sub

    Private Sub BtnImagemAgendaManuReagemdar_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAgendaManuReagendar.ButtonClickMasterRace
        Botao(BtnImagemAgendaManuReagendar)
        If LstVAgendaManu.SelectedItems.Count > 0 Then
            Panel1.Show()
            Panel1.BringToFront()
            Inserir_EditarTabelaSQL("AgendaManuReagendar", LstVAgendaManu.SelectedItems(0).Text.ToString)
        Else
            MsgBox("Selecione a despesa")
        End If
    End Sub

    Private Sub BtnImagemAgendaManuInsert_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAgendaManuInsert.ButtonClickMasterRace
        Botao(BtnImagemAgendaManuInsert)
        Panel1.Show()
        Panel1.BringToFront()
        Inserir_EditarTabelaSQL("AgendaManuInsert")
    End Sub

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
    End Sub


    Private Sub BtnImagemAdminUtilizadorAtivar_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAdminUtilizadorAtivar.ButtonClickMasterRace
        Botao(BtnImagemAdminUtilizadorAtivar)
    End Sub

    Private Sub BtnImagemAdminUtilizadorEdit_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAdminUtilizadorEdit.ButtonClickMasterRace
        Botao(BtnImagemAdminUtilizadorEdit)
    End Sub

    Private Sub BtnImagemAdminUtilizadorInsert_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAdminUtilizadorInsert.ButtonClickMasterRace
        Botao(BtnImagemAdminUtilizadorInsert)
    End Sub

    Private Sub BtnImagemAdminVeiculosInsert_ButtonClickMasterRace(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImagemAdminVeiculosInsert.ButtonClickMasterRace
        Botao(BtnImagemAdminVeiculosInsert)
    End Sub

    Private Sub BtnImagem10_ButtonClickMasterRace_1(sender As Object, e As EventArgs) Handles BtnImagem10.ButtonClickMasterRace
        PnlBDDef.Show()
        PnlBDDef.BringToFront()
        TxtBDDef.Text = My.Settings.SqlDBServer
        TxtBDDef1.Text = My.Settings.SqlDBUser
        TxtBDDef2.Text = My.Settings.SqlDBConPass
        TxtBDDef3.Text = My.Settings.SqlDBNome
    End Sub

    Private Sub BtnImagemBDDefCancel_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemBDDefCancel.ButtonClickMasterRace
        PnlBDDef.Hide()
        PnlBDDef.SendToBack()
    End Sub

    Private Sub BtnImagemBDDefSave_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagemBDDefSave.ButtonClickMasterRace
        My.Settings.SqlDBServer = TxtBDDef.Text
        My.Settings.SqlDBUser = TxtBDDef1.Text
        My.Settings.SqlDBConPass = TxtBDDef2.Text
        My.Settings.SqlDBNome = TxtBDDef3.Text
        PnlBDDef.Hide()
        PnlBDDef.SendToBack()
    End Sub

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

    Private Sub BtnImagem11_ButtonClickMasterRace(sender As Object, e As EventArgs) Handles BtnImagem11.ButtonClickMasterRace
        MenuPrincipal(7, True)
        RectangleShape3.Top = GrpRelatorio.Bottom - RectangleShape3.Height
        RectangleShape2.Top = RectangleShape3.Top - RectangleShape2.Height
        RectangleShape1.Top = RectangleShape2.Top - RectangleShape1.Height
        EscolherGrafDados(ChkGraf1)
        GrpRelatorio.Font = GetInstance(12, FontStyle.Bold)
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
            Button1.Enabled = False
            LblRelatorio1.Show()
            LblRelatorio2.Hide() 'Desativado
            GraficoSelecionado()
        ElseIf ChkGraf2.Checked = True Then
            CmbLista.Enabled = True
            Button1.Enabled = True
            LblRelatorio1.Hide()
            LblRelatorio2.Hide()
            RelatorioSelecionado("Where CodUser=")
        ElseIf ChkGraf3.Checked = True Then
            CmbLista.Enabled = True
            Button1.Enabled = True
            LblRelatorio1.Hide()
            LblRelatorio2.Hide()
            RelatorioSelecionado("Where CodVei=")
        End If

    End Sub

    Private Sub ChkGraf1_Click(sender As Object, e As EventArgs) Handles ChkGraf1.Click
        EscolherGrafDados(ChkGraf1)
    End Sub

    Private Sub ChkGraf2_Click(sender As Object, e As EventArgs) Handles ChkGraf2.Click
        EscolherGrafDados(ChkGraf2)
    End Sub

    Private Sub ChkGraf3_Click(sender As Object, e As EventArgs) Handles ChkGraf3.Click
        EscolherGrafDados(ChkGraf3)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RELATORIO <> "" Then
            GraficoSelecionado(RELATORIO, CmbLista.SelectedValue.ToString)
        End If
    End Sub
End Class