Imports MySql.Data.MySqlClient
Imports System.Net.Mail
Module SQL
    'Caro colega programador:
    '
    'Quando escrevi este código, só Deus e eu sabíamos com funcionava
    'Agora, SÓ Deus o  sabe!
    '
    'Para ti que estás a tentar otimiza-lo e falhaste, por favor, 
    'aumenta o contador para adverter o teu proximo colega:
    '
    'Total_horas_perdidas_aqui = 24
    '
    Dim ligacao As New MySqlConnection("Server=" + My.Settings.SqlDBServer + ";Database=" + My.Settings.SqlDBNome + ";Uid=" + My.Settings.SqlDBUser + ";Pwd=" + My.Settings.SqlDBConPass + ";Connect timeout=30;Convert Zero Datetime=True;") 'MUDAR TALVEZ
    Dim adapter As New MySqlDataAdapter
    ' Dim Comando As MySqlCommand
    Public DetalhesUtilizador As New UtilizadorDetalhes
    Public todaysdate As String = String.Format("{0:yyyy/MM/dd}", DateTime.Now)
    Public Year As String = String.Format("{0:yyyy}", DateTime.Now)
    Public Month As String = String.Format("{0:MM}", DateTime.Now)
    Public Day As String = String.Format("{0:dd}", DateTime.Now)
    Public TabelaSelecionada As String = ""
    Public IDSelecionado As String = ""
    Public TabelaSelecionadaAdmin As String = ""
    Public IDSelecionadoAdmin As String = ""

    Public Function VerificarLigacao() As Boolean
        ligacao = New MySqlConnection(Form1.linhaSQL)
        Dim Comando As MySqlCommand
        Dim ErroDB As Boolean = False
        Try
            ligacao.Open()
            Comando = New MySqlCommand("select * from Utilizador", ligacao)
            Comando.ExecuteScalar()
        Catch ex As Exception
            If ex.Message.Contains("is not allowed to connect to this MySQL server") Or ex.Message.Contains("Unable to connect") Then
                MsgBox("Erro! Adresso do servidor errado ou servidor indisponivel")
                ErroDB = True
            ElseIf ex.Message.Contains("Access denied for user") Then
                MsgBox("Erro! Credeciais para acesso ao servidor erradas")
                ErroDB = True
            ElseIf ex.Message.Contains("Unknown database") Or ex.Message.Contains("No database selected") Or ex.Message.Contains("doesn't exist") Then
                MsgBox("Erro! Base de dados não existe ou é incorreta")
                ErroDB = True
            Else
                MsgBox("Erro!")
                ErroDB = True
            End If
        Finally
            If ligacao.State = ConnectionState.Open Then
                ligacao.Close()
            End If
        End Try

        If ErroDB = True Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Login(ByVal Utilizador As String, ByVal Password As String) As Boolean
        Dim max As MySqlCommand
        Dim ErroDB As Boolean = False
        Dim User As Object
        Dim str As String
        Dim str1 As String = ""

        'CODIGO VERIFICAR LIGAÇAO
        If VerificarLigacao() Then
            Return (False)
        End If

        If Utilizador = "" Then
            Form1.LblUtilizadorLogin.Show()
            Form1.LblUtilizadorLogin.Text = "*Necessita  de Utilizador"
            Return False
            Exit Function
        Else
            If LCase(Utilizador).Contains(LCase("@")) Then
                Try
                    max = New MySqlCommand("select Email from Utilizador where Email ='" + Utilizador + "'", ligacao)
                    ligacao.Open()
                    User = max.ExecuteScalar
                    str = CType(User, String)
                    ligacao.Close()
                    If str <> "" Then
                        max = New MySqlCommand("select Senha from Utilizador where Email ='" + Utilizador + "'", ligacao)
                        ligacao.Open()
                        User = max.ExecuteScalar
                        str = CType(User, String)
                        ligacao.Close()
                        If str = Password Then
                            max = New MySqlCommand("select Nome_Registo from Utilizador where Email ='" + Utilizador + "'", ligacao)
                            ligacao.Open()
                            User = max.ExecuteScalar
                            str = CType(User, String)
                            ligacao.Close()
                            BuscarDadosUtilizador(str)
                            Return (True)
                            Exit Function
                        Else
                            Form1.LblPasswordLogin.Show()
                            Form1.LblPasswordLogin.Text = "*Password Incorreta"
                            Return (False)
                            Exit Function
                        End If
                    Else
                        Form1.LblUtilizadorLogin.Show()
                        Form1.LblUtilizadorLogin.Text = "*Utilizador Inválido"
                        Return (False)
                        Exit Function
                    End If
                Catch ex As Exception
                    MsgBox("ERRO 0")
                    Return (False)
                Finally
                    If ligacao.State = ConnectionState.Open Then
                        ligacao.Close()
                    End If
                End Try
            Else
                Try
                    max = New MySqlCommand("select Nome_Registo from Utilizador where Nome_Registo ='" + Utilizador + "'", ligacao)
                    ligacao.Open()
                    User = max.ExecuteScalar
                    str = CType(User, String)
                    ligacao.Close()
                    If str <> "" Then
                        max = New MySqlCommand("select Senha from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
                        ligacao.Open()
                        User = max.ExecuteScalar
                        str = CType(User, String)
                        ligacao.Close()
                        If str = Password Then
                            BuscarDadosUtilizador(Utilizador)
                            Return (True)
                            Exit Function
                        Else
                            Form1.LblPasswordLogin.Show()
                            Form1.LblPasswordLogin.Text = "*Password Incorreta"
                            Return (False)
                            Exit Function
                        End If
                    Else
                        Form1.LblUtilizadorLogin.Show()
                        Form1.LblUtilizadorLogin.Text = "*Utilizador Inválido"
                        Return (False)
                        Exit Function
                    End If
                Catch ex As Exception
                    MsgBox("ERRO 1")
                    Return (False)
                Finally
                    If ligacao.State = ConnectionState.Open Then
                        ligacao.Close()
                    End If
                End Try
            End If
            Return (False)
        End If
    End Function

    Public Function RegistarUtilizador(ByVal Utilizador As String, ByVal Password1 As String, ByVal Password2 As String, ByVal Email As String, ByVal Nome_Proprio As String, ByVal Apelido As String) As Boolean
        Dim Comando As MySqlCommand
        Dim Objecto As Object

        Dim UtilizadorBD As String = ""
        Dim EmailBD As String = ""
        Dim Validar(3) As Boolean

        'Verificar Email
        If Email = "" Then
            Form1.LblEmailReg.Show()
            Form1.LblEmailReg.Text = "*Necessita de um email"
            Validar(1) = True
        Else
            Try 'Testa se o é email valido
                Dim testAddress = New MailAddress(Email)
            Catch ex As FormatException
                Form1.LblEmailReg.Show()
                Form1.LblEmailReg.Text = "*Email invalido"
                Validar(1) = True
            End Try
            Try 'Vê se o email já exist
                Comando = New MySqlCommand("select email from Utilizador where email='" + Email + "'", ligacao)
                ligacao.Open()
                Objecto = Comando.ExecuteScalar
                EmailBD = CType(Objecto, String)
                ligacao.Close()
            Catch ex As Exception
                MsgBox("ERRO SQL EMAIL 1")
                Return False
                Exit Function
            End Try
            If Email = EmailBD Then 'IDK
                Form1.LblEmailReg.Show()
                Form1.LblEmailReg.Text = "*Email já existe"
                Validar(1) = True
            End If
        End If

        'Verificar Utilizador
        If Utilizador = "" Then
            Form1.LblUtilizadorReg.Show()
            Form1.LblUtilizadorReg.Text = "*Necessita de um Utilizador"
            Validar(2) = True
        Else
            Try
                Comando = New MySqlCommand("select Nome_Registo from Utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
                ligacao.Open()
                Objecto = Comando.ExecuteScalar
                UtilizadorBD = CType(Objecto, String)
                ligacao.Close()
            Catch ex As Exception
                MsgBox("ERRO SQL UTILIZADOR")
                Return False
                Exit Function
            End Try
            If Utilizador = UtilizadorBD Then
                Form1.LblUtilizadorReg.Show()
                Form1.LblUtilizadorReg.Text = "*Utilizador já existe"
                Validar(2) = True
            End If
        End If

        If Password1 = "" Then
            Form1.LblPasswordReg.Show()
            Form1.LblPasswordReg.Text = "*Necessita de Password"
            Validar(3) = True
        Else
            If Password1 <> Password2 Then
                'loadorderchangecolor???
                Form1.LblPasswordReg.Show()
                Form1.LblPasswordReg.Text = "*Passwords Não são iguais"
                Validar(3) = True
            End If
        End If

        If Validar(1) = True Or Validar(2) = True Or Validar(3) = True Then
            Return False
            Exit Function
        End If
        'PILAS
        Try
            Comando = New MySqlCommand("insert into utilizador (Nome_Registo, Senha,Email,Nome_Proprio,Apelido,Genero,Data_Nascimento,Rua,N_Telemovel,CodCi) values ('" + Utilizador + "', '" + HashPassword(Password1) + "', '" + Email + "', '" + Nome_Proprio + "', '" + Apelido + "','Masculino','2017-07-11',' ', '960000000','63')", ligacao)
            ligacao.Open()
            Comando.ExecuteNonQuery()
            ligacao.Close()
            Return (True)
            Exit Function
        Catch ex As Exception
            MsgBox("Erro! Contate o administrador com o seguinte erro:  " + ex.Message, MsgBoxStyle.Critical, "Erro!!!")
        End Try
        Return (False)
    End Function


    Public Function EditarUtilizador(ByVal Utilizador As String, ByVal NomeProprio As String, ByVal Apelido As String, ByVal DataNasc As String, ByVal DataContrat As String, ByVal PagamentoHora As String, ByVal Genero As String, ByVal Habilitacoes As String, ByVal Notas As String)
        Dim Comando As MySqlCommand
        MsgBox("WIP Verificaçoes")
        Try
            'Comando = New MySqlCommand("update Utilizador set Nome_Registo='" + Utilizador + "'where CodUser='" + DetalhesUtilizador.CodUser + "'", ligacao)
            'update utilizador set Nome="LOL", Apelido="1" where cout="1"
            Comando = New MySqlCommand("update Utilizador set Nome_Registo='" + Utilizador + "', Nome_Proprio='" + NomeProprio + "', Apelido='" + Apelido + "', Data_Nascimento='" + DataNasc + "', Data_Contratacao='" + DataContrat + "', Pagamentos_Hora='" + PagamentoHora + "', Genero='" + Genero + "', Habilitacoes='" + Habilitacoes + "', Notas_Contracto='" + Notas + "'where CodUser='" + DetalhesUtilizador.CodUser + "'", ligacao)
            ligacao.Open()
            Comando.ExecuteNonQuery()
            ligacao.Close()
            BuscarDadosUtilizador(Utilizador)
            Return (True)
            Exit Function
        Catch ex As Exception
            MsgBox("ERRO SQL Edit")
            ligacao.Close()
            Return (False)
            Exit Function
        End Try
    End Function

    Public Function UltimoKM() As Decimal
        Dim Max As Double = 0
        Dim KMDespesas As Double = 0
        Dim KMManutencao As Double = 0
        Dim KMAbastecimento As Double = 0
        Dim KM4 As String = 0
        Dim Comando As MySqlCommand
        Dim Objecto As Object
        Try
            Comando = New MySqlCommand("select Max(ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2)) from despesas where efetuada='sim' and Codvei='" + DetalhesUtilizador.CodVeiculo.ToString + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                KMDespesas = 0
                ligacao.Close()
            Else
                KMDespesas = CType(Objecto, Double)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try
        Try
            Comando = New MySqlCommand("select Max(ROUND((Veiculo_km/" + DistanciaConversao.ToString + "),2)) from manutencao where efetuada='sim' and Codvei='" + DetalhesUtilizador.CodVeiculo.ToString + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                KMManutencao = 0
                ligacao.Close()
            Else
                KMManutencao = CType(Objecto, Double)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try
        Try
            Comando = New MySqlCommand("select Max(ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2)) from veiabast where Codvei='" + DetalhesUtilizador.CodVeiculo.ToString + "'", ligacao)
            ligacao.Open()
            Objecto = Comando.ExecuteScalar
            If IsDBNull(Objecto) Then
                KMAbastecimento = 0
                ligacao.Close()
            Else
                KMAbastecimento = CType(Objecto, Double)
                ligacao.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
        End Try
        If KMDespesas > KMManutencao And KMDespesas > KMAbastecimento Then
            Max = KMDespesas
            Return Max
            Exit Function
        ElseIf KMManutencao > KMDespesas And KMManutencao > KMAbastecimento Then
            Max = KMManutencao
            Return Max
            Exit Function
        ElseIf KMAbastecimento > KMDespesas And KMAbastecimento > KMManutencao Then
            Max = KMAbastecimento
            Return Max
            Exit Function
        End If
        Return 0
    End Function


    'Buscar Dados
    Public Sub BuscarDadosUtilizador(ByVal Utilizador As String)
        Dim CampoEmFalta As Boolean = False 'Por Publica 
        Dim Comando As New MySqlCommand
        Dim reader As MySqlDataReader
        'Buscar Dados Utilizador
        Comando.Connection = SQL.ligacao
        Comando.CommandText = ("SELECT * FROM utilizador where Nome_Registo='" + Utilizador + "' ")
        Try
            ligacao.Open()
            reader = Comando.ExecuteReader
            While reader.Read
                'Credenciais
                DetalhesUtilizador.CodUser = reader.GetString("CodUser")
                DetalhesUtilizador.NomeRegisto = reader.GetString("Nome_Registo")
                DetalhesUtilizador.Senha = reader.GetString("Senha")
                DetalhesUtilizador.TipoUtilizadorCod = reader.GetString("CodTipoU")
                DetalhesUtilizador.Email = reader.GetString("Email")
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        Finally
            If ligacao.State = ConnectionState.Open Then
                ligacao.Close()
            End If
        End Try

        'Buscar Dados Secundarios do Utilizador
        Comando = New MySqlCommand("SELECT * FROM utilizador where Nome_Registo='" + Utilizador + "'", ligacao)
        Try
            ligacao.Open()
            reader = Comando.ExecuteReader
            While reader.Read
                'Info Pessoal
                Try
                    DetalhesUtilizador.NomeProprio = reader.GetString("Nome_Proprio")
                Catch ex As Exception
                    CampoEmFalta = True
                End Try
                Try
                    DetalhesUtilizador.Apelido = reader.GetString("Apelido")
                Catch ex As Exception
                    DetalhesUtilizador.Apelido = ""
                    CampoEmFalta = True
                End Try
                Try
                    DetalhesUtilizador.Genero = reader.GetString("Genero")
                Catch ex As Exception
                    CampoEmFalta = True
                End Try
                Try
                    DetalhesUtilizador.DataNasc = reader("Data_Nascimento")
                Catch ex As Exception
                    CampoEmFalta = True
                End Try
                'Info Trabalhador
                Try
                    DetalhesUtilizador.NTelemovel = reader.GetString("N_Telemovel")
                Catch ex As Exception
                    CampoEmFalta = True
                End Try
                'Morada
                Try
                    DetalhesUtilizador.CidadeCod = reader.GetString("CodCi")
                Catch ex As Exception
                    CampoEmFalta = True
                End Try
                Try
                    DetalhesUtilizador.Rua = reader.GetString("Rua")
                Catch ex As Exception
                    CampoEmFalta = True
                End Try
            End While
            ligacao.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If ligacao.State = ConnectionState.Open Then
                ligacao.Close()
            End If
        End Try

        'Buscar Designaçao do Utilizador
        Comando = New MySqlCommand("select Designacao from TipoUser where CodTipoU='" + DetalhesUtilizador.TipoUtilizadorCod.ToString + "'", ligacao)
        Try
            ligacao.Open()
            reader = Comando.ExecuteReader
            While reader.Read
                'Credenciais
                DetalhesUtilizador.TipoUtilizador = reader.GetString("Designacao")
            End While
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox(ex.Message)
            Exit Sub
        End Try

        'Buscar Cidade
        Comando = New MySqlCommand("select Nome,Codpais from Cidade where CodCi='" + DetalhesUtilizador.CidadeCod.ToString + "'", ligacao)
        Try
            ligacao.Open()
            reader = Comando.ExecuteReader
            While reader.Read
                'Morada
                DetalhesUtilizador.Cidade = reader.GetString("Nome")
                DetalhesUtilizador.PaisCod = reader.GetString("Codpais")
            End While
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox(ex.Message)
            Exit Sub
        End Try

        If DetalhesUtilizador.PaisCod <> Nothing Then
            'Buscar Pais
            Comando = New MySqlCommand("select Nome from Pais where Codpais='" + DetalhesUtilizador.PaisCod.ToString + "'", ligacao)
            Try
                ligacao.Open()
                reader = Comando.ExecuteReader
                While reader.Read
                    'Morada
                    DetalhesUtilizador.Pais = reader.GetString("Nome")
                End While
                ligacao.Close()
            Catch ex As Exception
                ligacao.Close()
                MsgBox(ex.Message)
                Exit Sub
            End Try
        Else
            DetalhesUtilizador.PaisCod = 0
            DetalhesUtilizador.Pais = ""
        End If


        'Buscar Código do Veiculo
        Comando = New MySqlCommand("select CodVei from Veicondu where coduser='" + DetalhesUtilizador.CodUser + "' and EmUso='sim'", ligacao)
        Try
            ligacao.Open()
            reader = Comando.ExecuteReader
            While reader.Read
                'Codigo
                Try
                    DetalhesUtilizador.CodVeiculo = reader.GetString("CodVei")
                Catch ex As Exception
                    DetalhesUtilizador.CodVeiculo = ""
                End Try

            End While
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox(ex.Message)
            Exit Sub
        End Try

        'Buscar dados do Veiculo
        Comando = New MySqlCommand("select * from veiculos where codVei='" + DetalhesUtilizador.CodUser + "'", ligacao)
        Try
            ligacao.Open()
            reader = Comando.ExecuteReader
            While reader.Read
                'Dados
                DetalhesUtilizador.VeiMarca = reader.GetString("Marca")
                DetalhesUtilizador.VeiModelo = reader.GetString("Modelo")
                DetalhesUtilizador.VeiMatricula = reader.GetString("Matricula")
                DetalhesUtilizador.VeiCor = reader.GetString("Cor")
            End While
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox(ex.Message)
            Exit Sub
        End Try

        If CampoEmFalta = True Then
            MsgBox("Campos em Falta! Edite o seu perfil.")
            Exit Sub
        End If

        Exit Sub
        'CODIGO TEMPORÀRIO PARA OPRIMIR OS UTILIZADORES QUE NÂO SÂO ADMINISTRADORES
        If DetalhesUtilizador.TipoUtilizadorCod <> 1 Then
            MsgBox("Utilizador Não disponivel")
            Exit Sub
        End If

    End Sub

    Public Sub TabelaVer(ByVal LstV As ListView, ByVal LinhaSql As String, ByVal Tabela As String)
        LstV.Hide()
        Dim Dados As DataSet = New DataSet
        adapter.SelectCommand = New MySqlCommand
        adapter.SelectCommand.Connection = ligacao
        Dim itemcoll(100) As String
        adapter.SelectCommand.CommandText = LinhaSql
        Try
            ligacao.Open()
            adapter.Fill(Dados, Tabela)
            ligacao.Close()
        Catch ex As Exception
            MsgBox("ERRO" + Tabela + "!")
            Exit Sub
        Finally
            If ligacao.State = ConnectionState.Open Then
                ligacao.Close()
            End If
        End Try
        LstV.Font = GetInstance(8, FontStyle.Bold)
        LstV.Clear()
        Dim i As Integer = 0
        Dim j As Integer = 0
        ' adding the columns in ListView
        For i = 0 To Dados.Tables(0).Columns.Count - 1
            LstV.Columns.Add(Dados.Tables(0).Columns(i).ColumnName.ToString())
        Next
        'Now adding the Items in Listview
        For i = 0 To Dados.Tables(0).Rows.Count - 1
            For j = 0 To Dados.Tables(0).Columns.Count - 1
                itemcoll(j) = Dados.Tables(0).Rows(i)(j)
            Next
            Dim lvi As New ListViewItem(itemcoll)
            LstV.Items.Add(lvi)
        Next
        ListViewSize(Tabela)
        LstV.Show()
    End Sub

    ' SELECT * FROM veicondu where emuso="sim" and coduser="1"
    '  Comando = New MySqlCommand("select CodVei from pais where ='" + DetalhesUtilizador.CodUser + "'codpais='" + DetalhesUtilizador.CodUser + "'", ligacao)

    Public Sub DetalhesAbast(ByVal Cod As String) 'Mudar Metodo
        Dim Comando As MySqlCommand
        Dim reader As MySqlDataReader
        Form1.LblAbastCOD.Text = "Codigo: " + Cod
        Comando = New MySqlCommand
        Comando.Connection = ligacao
        Comando.CommandText = ("select CodVeiAbast,Data,notas,concat(Nome_Proprio,' ',Apelido) as Utilizador,concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veiculo,concat(ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "',concat(ROUND((quantidade/" + VolumeConversao().ToString + "),2),' " + VolumeSimbolo() + "') as 'Quantidade',concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',fornecedores.Nome as Fornecedor from veiabast,Utilizador,Veiculos,fornecedores where fornecedores.codforn=Veiabast.codforn and Veiculos.CodVei=Veiabast.CodVei and utilizador.coduser=Veiabast.CoDuser and CodVeiAbast=" + Cod + " ")
        Try
            ligacao.Open()
            reader = Comando.ExecuteReader
            While reader.Read
                Form1.LblAbastData.Text = "Data: " + reader("data")
                Form1.TxtAbastNota.Text = reader.GetString("notas")
                Form1.LblAbastUtilizador.Text = "Utilizador: " + reader.GetString("Utilizador")
                Form1.LblAbastVeiculo.Text = "Veículo: " + reader.GetString("Veiculo")
                Form1.LblAbastKM.Text = "KM: " + reader.GetString(DistanciaDistancia)
                Form1.LblAbastQuantidade.Text = "Quantidade: " + reader.GetString("Quantidade")
                Form1.LblAbastValor.Text = "Valor: " + reader.GetString("Valor")
                Form1.LblAbastFornecedor.Text = "Fornecedores: " + reader.GetString("Fornecedor")
            End While
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox(ex.ToString)
            Exit Sub
        End Try
    End Sub

    Public Sub DetalhesDesp(ByVal Cod As String)
        Dim Comando As MySqlCommand
        Dim reader As MySqlDataReader
        Form1.LblDespCod.Text = "Código: " + Cod
        Comando = New MySqlCommand
        Comando.Connection = ligacao
        Comando.CommandText = ("select CodDesp,nota,Data_Efetuada as Data,tipodesp.Nome as Tipo,concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veiculo,fornecedores.Nome as Fornecedor from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Sim' and CodDesp=" + Cod + " ")
        Try
            ligacao.Open()
            reader = Comando.ExecuteReader
            While reader.Read
                Form1.LblDespData.Text = "Data: " + reader("Data")
                Form1.LblDespTipo.Text = "Tipo: " + reader.GetString("Tipo")
                Form1.LblDespValor.Text = "Valor: " + reader.GetString("Valor")
                Form1.LblDespKM.Text = "KM: " + reader.GetString(DistanciaDistancia)
                Form1.LblDespVeiculo.Text = "Veículo: " + reader.GetString("Veiculo")
                Form1.Label7.Text = "Fornecedor: " + reader.GetString("Fornecedor")
                Form1.TxtDespNota.Text = reader.GetString("Nota")
            End While
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox(ex.ToString)
            Exit Sub
        End Try
    End Sub

    Public Sub DetalhesManu(ByVal Cod As String)
        Dim Comando As MySqlCommand
        Dim reader As MySqlDataReader
        Form1.LblManuCOD.Text = "Código: " + Cod
        Comando = New MySqlCommand
        Comando.Connection = ligacao
        Comando.CommandText = ("select Codmanu,nota,Data_Efetuada as Data,tipomanu.Nome as Tipo,concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veiculo,fornecedores.Nome as Fornecedor from manutencao,Veiculos,Fornecedores,Utilizador,Tipomanu where manutencao.codvei=veiculos.codvei and manutencao.codforn=Fornecedores.codforn and manutencao.coduser=Utilizador.coduser and manutencao.codtipom=tipomanu.codtipom and efetuada='sim' and codmanu=" + Cod + " ")
        Try
            ligacao.Open()
            reader = Comando.ExecuteReader
            While reader.Read
                Form1.LblManuData.Text = "Data: " + reader("Data")
                Form1.LblManuTipo.Text = "Tipo: " + reader.GetString("Tipo")
                Form1.LblManuValor.Text = "Valor: " + reader.GetString("Valor")
                Form1.LblManuKM.Text = "KM: " + reader.GetString(DistanciaDistancia)
                Form1.LblManuVeiculo.Text = "Veículo: " + reader.GetString("Veiculo")
                Form1.LblManuFornecedor.Text = "Fornecedor: " + reader.GetString("Fornecedor")
                Form1.TxtManuNota.Text = reader.GetString("Nota")
            End While
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox(ex.ToString)
            Exit Sub
        End Try
    End Sub

    Public Sub DetalhesUtilizadorAdmin(ByVal Cod As String)
        Dim Comando As MySqlCommand
        Dim reader As MySqlDataReader
        Form1.LblAdminUtilizadorCod.Text = "Código: " + Cod
        Form1.LblAdminUtilizadorNome.Text = "Nome Completo: "
        Form1.LblAdminUtilizadorDataNas.Text = "Data Nascimento: "
        Form1.LblAdminUtilizadorMorada.Text = "Morada: "
        Form1.LblAdminUtilizadorTelem.Text = "Nº Telemovel: "
        Comando = New MySqlCommand
        Comando.Connection = ligacao
        Comando.CommandText = ("select CodUser,Nome_Registo,Nome_Proprio,Apelido,Genero,data_Nascimento,N_Telemovel,Email,Designacao,Rua,Cidade.nome as Cidade, Pais.Nome as Pais from Utilizador,cidade,pais,Tipouser where Utilizador.codci=Cidade.codci and Cidade.codpais=Pais.codpais and Utilizador.codtipoU=TipoUser.codtipoU and codUser=" + Cod + " ")
        Try
            ligacao.Open()
            reader = Comando.ExecuteReader
            While reader.Read
                Form1.LblAdminUtilizadorNome.Text = "Nome Completo: " + reader.GetString("Nome_Proprio") + " " + reader.GetString("Apelido")
                Form1.LblAdminUtilizadorDataNas.Text = "Data Nascimento: " + reader.GetDateTime("data_Nascimento")
                Form1.LblAdminUtilizadorMorada.Text = "Morada: " + reader.GetString("Rua") + ", " + reader.GetString("Cidade") + ", " + reader.GetString("Pais")
                Form1.LblAdminUtilizadorTelem.Text = "Nº Telemovel: " + reader.GetString("N_Telemovel")
                'Form1.LblAdminUtilizadorTelef.Text = "Nº Telefone: " + reader.GetString("N_Telefone")
                'Form1.LblManuVeiculo.Text = "Data Contratacao: " + reader.GetString("Data_contratacao")
                'Form1.LblManuFornecedor.Text = "Pagmamento hora: " + reader.GetString("Pagmamentos_hora")
                ' Form1.TxtAdminUtilizadorNotasContract.Text = reader.GetString("Notas_Contracto")/
                'Form1.TxtAdminUtilizadorNotasContact.Text = reader.GetString("Notas_Contacto")
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        Finally
            If ligacao.State = ConnectionState.Open Then
                ligacao.Close()
            End If
        End Try
    End Sub

    Public Sub DetalhesVeiculosAdmin(ByVal Cod As String)
        Dim Comando As MySqlCommand
        Dim reader As MySqlDataReader
        Form1.LblAdminVeiculoCod.Text = "Código: " + Cod
        Comando = New MySqlCommand
        Comando.Connection = ligacao
        Comando.CommandText = ("select CodVei,Matricula,Marca,Modelo,Cor,Ano,tipocom.Nome as 'Tipo de Combustivel',tipovei.Nome as 'Tipo de Veículo' from veiculos,tipocom,tipovei where veiculos.CodtipoV=TipoVei.CodTipoV and Veiculos.CodtipoC=TipoCom.CodTipoc and codvei=" + Cod + " ")
        Try
            ligacao.Open()
            reader = Comando.ExecuteReader
            While reader.Read
                Form1.LblAdminVeiculoMatricula.Text = "Matricula: " + reader.GetString("Matricula")
                Form1.LblAdminVeiculoMarca.Text = "Marca: " + reader.GetString("Marca")
                Form1.LblAdminVeiculoModelo.Text = "Modelo: " + reader.GetString("Modelo")
                Form1.LblAdminVeiculoAno.Text = "Ano: " + reader.GetString("Ano")
                Form1.LblAdminVeiculoCor.Text = "Cor: " + reader.GetString("Cor")
                Form1.LblAdminVeiculoTipoCom.Text = "Tipo de combustivel: " + reader.GetString("Tipo de Combustivel")
            End While
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox(ex.ToString)
            Exit Sub
        End Try
    End Sub

    Public Sub DetalhesFornecedorAdmin(ByVal Cod As String)
        Dim Comando As MySqlCommand
        Dim reader As MySqlDataReader
        Form1.LblAdminFornecedoresCod.Text = "Código: " + Cod
        Comando = New MySqlCommand
        Comando.Connection = ligacao
        Comando.CommandText = ("select CodForn,Fornecedores.Nome as Nome,Rua,N_Telemovel,N_Telefone,Email,site, tipofor.Nome as 'Tipo de Fornecedor',Cidade.Nome as 'Cidade', Pais.Nome as 'Pais' from Fornecedores,Tipofor,Cidade,Pais where fornecedores.CodtipoF=Tipofor.CodtipoF and Fornecedores.codci=cidade.codci and cidade.codpais=pais.codpais and codforn=" + Cod + " ")
        Try
            ligacao.Open()
            reader = Comando.ExecuteReader
            While reader.Read
                Form1.LblAdminFornecedoresNome.Text = "Nome: " + reader("Nome")
                Form1.LblAdminFornecedoresMorada.Text = "Morada: " + reader("Rua") + ", " + reader("Cidade") + ", " + reader("pais")
                Form1.LblAdminFornecedoresTele.Text = "Telemovel: " + reader.GetString("N_Telemovel")
                Form1.LblAdminFornecedoresTelef.Text = "Telefone: " + reader.GetString("N_Telefone")
                Form1.LblAdminFornecedoresEmail.Text = "Email:: " + reader("Email")
                Form1.LblAdminFornecedoresSite.Text = "Website: " + reader("site")
            End While
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox(ex.ToString)
            Exit Sub
        End Try
    End Sub

    Public Sub DetalhesAgendaDesp(ByVal Cod As String)
        Dim Comando As MySqlCommand
        Dim reader As MySqlDataReader
        Form1.LblAgendaDespCod.Text = "Código: " + Cod
        Comando = New MySqlCommand
        Comando.Connection = ligacao
        Comando.CommandText = ("select Coddesp,nota,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' Matricula:',Matricula) as Veiculo,tipodesp.Nome as Tipo, LembrarPor as 'Lembrar por:' from Despesas,veiculos,fornecedores,tipodesp where Veiculos.Codvei=Despesas.CodVei and fornecedores.Codforn=Despesas.Codforn and tipodesp.CodtipoD=Despesas.CodtipoD and efetuada='Nao' and CodDesp='" + Cod + "'")
        Try
            ligacao.Open()
            reader = Comando.ExecuteReader
            While reader.Read
                Form1.LblAgendaDespDataAgendada.Text = "Data Agendada: " + reader("Data Agendada")
                Form1.LblAgendaDespTipo.Text = "Tipo: " + reader.GetString("Tipo")
                Form1.LblAgendaDespVeiculo.Text = "Veículo: " + reader.GetString("Veiculo")
                Form1.TxtAgendaDespNota.Text = reader.GetString("Nota")
            End While
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox(ex.ToString)
            Exit Sub
        End Try
    End Sub

    Public Sub DetalhesAgendaManu(ByVal Cod As String)
        Dim Comando As MySqlCommand
        Dim reader As MySqlDataReader
        Form1.LblAgendaManuCod.Text = "Código: " + Cod
        Comando = New MySqlCommand
        Comando.Connection = ligacao
        Comando.CommandText = ("select CodManu,nota,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' Matricula:',Matricula) as Veiculo,tipomanu.Nome as Tipo, LembrarPor as 'Lembrar por:' from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=Manutencao.CodVei and fornecedores.Codforn=Manutencao.Codforn and TipoManu.CodtipoM=Manutencao.CodtipoM and efetuada='Nao' and Codmanu='" + Cod + "'")
        Try
            ligacao.Open()
            reader = Comando.ExecuteReader
            While reader.Read
                Form1.LblAgendaManuDataAgendada.Text = "Data Agendada: " + reader("Data Agendada")
                Form1.LblAgendaManuTipo.Text = "Tipo: " + reader.GetString("Tipo")
                Form1.LblAgendaManuVeiculo.Text = "Veículo: " + reader.GetString("Veiculo")
                Form1.TxtAgendaManuNota.Text = reader.GetString("Nota")
            End While
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox(ex.ToString)
            Exit Sub
        End Try
    End Sub

    Public Sub Inserir_EditarTabelaSQL(ByVal Tabela As String, Optional ByVal Id As String = "")
        Dim Data As DataSet = New DataSet
        Dim reader As MySqlDataReader
        Form1.DateTimePicker1.Value = Now
        adapter.SelectCommand = New MySqlCommand
        adapter.SelectCommand.Connection = ligacao
        '
        'Selecionar dados a mostrar na ListBox Tipo
        '
        If Tabela = "ManuInsert" Or Tabela = "ManuEdit" Or Tabela = "AgendaManuExecutar" Or Tabela = "AgendaManuInsert" Then
            Dim Tipo As DataSet = New DataSet
            adapter.SelectCommand = New MySqlCommand
            adapter.SelectCommand.Connection = ligacao
            adapter.SelectCommand.CommandText = ("Select CodTipoM, Nome from TipoManu")
            Try
                ligacao.Open()
                adapter.Fill(Tipo, "TIPOMANU")
                ligacao.Close()
            Catch ex As Exception
                ligacao.Close()
                MsgBox("ERRO Fornecedor")
                Exit Sub
            End Try
            Form1.LstInserirTipo.DataSource = Tipo.Tables(0)
            Form1.LstInserirTipo.DisplayMember = "Nome"
            Form1.LstInserirTipo.ValueMember = "CodTipoM"
        ElseIf Tabela = "DespInsert" Or Tabela = "DespEdit" Or Tabela = "AgendaDespExecutar" Or Tabela = "AgendaDespInsert" Then
            Dim Tipo As DataSet = New DataSet
            adapter.SelectCommand = New MySqlCommand
            adapter.SelectCommand.Connection = ligacao
            adapter.SelectCommand.CommandText = ("Select CodTipoD, Nome from Tipodesp")
            Try
                ligacao.Open()
                adapter.Fill(Tipo, "TIPODESP")
                ligacao.Close()
            Catch ex As Exception
                ligacao.Close()
                MsgBox("ERRO Fornecedor")
                Exit Sub
            End Try
            Form1.LstInserirTipo.DataSource = Tipo.Tables(0)
            Form1.LstInserirTipo.DisplayMember = "Nome"
            Form1.LstInserirTipo.ValueMember = "CodTipoD"
        End If
        '
        'Selecionar dados da ListBox Fornecedor
        '
        adapter.SelectCommand.CommandText = ("Select CodForn, Nome from Fornecedores")
        Try
            ligacao.Open()
            adapter.Fill(Data, "Fornecedor")
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox("ERRO Fornecedor")
            Exit Sub
        End Try
        Form1.LstInserirFornecedor.DataSource = Data.Tables(0)
        Form1.LstInserirFornecedor.DisplayMember = "Nome"
        Form1.LstInserirFornecedor.ValueMember = "CodForn"

        Comando = New MySqlCommand
        Comando.Connection = ligacao
        '
        'Selecionar dados da entrada a editar
        '
        Try
            If Tabela = "AbastEdit" Then
                'Por o tipo de unidade que o form espera nas labels!
                Comando.CommandText = "select ROUND((quantidade/" + VolumeConversao().ToString + "),2) as quantidade,ROUND((valor*" + MoedaConversao().ToString + "),2) as valor,ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2) as Veiculo_Km,Notas,veiabast.CodForn from veiabast,veiculos,fornecedores,Utilizador where Veiculos.Codvei=Veiabast.CodVei and fornecedores.Codforn=Veiabast.Codforn and Utilizador.CodUser=Veiabast.Coduser and CodVeiAbast=" + Id + ""
                ligacao.Open()
                reader = Comando.ExecuteReader
                While reader.Read
                    Form1.TxtInserirQuantidade.Text = reader.GetString("Quantidade")
                    Form1.TxtInserirValor.Text = reader.GetString("Valor")
                    Form1.TxtInserirQuilometros.Text = reader.GetString("Veiculo_KM")
                    Form1.TxtInserirNota.Text = reader.GetString("Notas")
                    Form1.LstInserirFornecedor.SelectedValue = reader.GetString("CodForn")
                End While
                ligacao.Close()
            ElseIf Tabela = "ManuEdit" Then
                Comando.CommandText = "select ROUND((valor*" + MoedaConversao().ToString + "),2) as valor,ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2) as Veiculo_Km,Nota,Manutencao.CodForn,Manutencao.CodTipoM from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and CodManu=" + Id + ""
                ligacao.Open()
                reader = Comando.ExecuteReader
                While reader.Read
                    Form1.TxtInserirValor.Text = reader.GetString("Valor")
                    Form1.TxtInserirQuilometros.Text = reader.GetString("Veiculo_KM")
                    Form1.TxtInserirNota.Text = reader.GetString("Nota")
                    Form1.LstInserirFornecedor.SelectedValue = reader.GetString("CodForn")
                    Form1.LstInserirTipo.SelectedValue = reader.GetString("CodTipoM")
                End While
                ligacao.Close()
            ElseIf Tabela = "DespEdit" Then
                Comando.CommandText = "select ROUND((valor*" + MoedaConversao().ToString + "),2) as valor,ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2) as Veiculo_Km,Nota,despesas.CodForn,despesas.CodTipoD from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and CodDesp=" + Id + ""
                ligacao.Open()
                reader = Comando.ExecuteReader
                While reader.Read
                    Form1.TxtInserirValor.Text = reader.GetString("Valor")
                    Form1.TxtInserirQuilometros.Text = reader.GetString("Veiculo_KM")
                    Form1.TxtInserirNota.Text = reader.GetString("Nota")
                    Form1.LstInserirFornecedor.SelectedValue = reader.GetString("CodForn")
                    Form1.LstInserirTipo.SelectedValue = reader.GetString("CodTipoD")
                End While
                ligacao.Close()
            ElseIf Tabela = "AgendaDespReagendar" Then
                MsgBox("Editar ISTO") 'APAGAR QUANDO TIVER FEITO
                Comando.CommandText = "select * from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and CodDesp=" + Id + ""
                ligacao.Open()
                reader = Comando.ExecuteReader
                While reader.Read
                    Form1.TxtInserirNota.Text = reader.GetString("Nota")
                    Form1.DateTimePicker1.CustomFormat = "yyyy-MM-dd"
                    Form1.DateTimePicker1.Value = reader.GetDateTime("Data_Agendada")
                End While
                ligacao.Close()
            ElseIf Tabela = "AgendaDespExecutar" Then
                Comando.CommandText = "select * from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and CodDesp=" + Id + ""
                ligacao.Open()
                reader = Comando.ExecuteReader
                While reader.Read
                    Form1.LstInserirTipo.SelectedValue = reader.GetString("CodTipoD")
                    Form1.TxtInserirNota.Text = reader.GetString("nota")
                    Form1.DateTimePicker1.CustomFormat = "yyyy-MM-dd"
                    Form1.DateTimePicker1.Value = reader.GetDateTime("Data_Agendada")
                End While
                ligacao.Close()
            ElseIf Tabela = "AgendaManuReagendar" Then
                MsgBox("Editar ISTO") 'APAGAR QUANDO TIVER FEITO
                Comando.CommandText = "select * from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and CodManu=" + Id + ""
                ligacao.Open()
                reader = Comando.ExecuteReader
                While reader.Read
                    Form1.TxtInserirNota.Text = reader.GetString("Nota")
                    Form1.DateTimePicker1.CustomFormat = "yyyy-MM-dd"
                    Form1.DateTimePicker1.Value = reader.GetDateTime("Data_Agendada")
                End While
                ligacao.Close()
            ElseIf Tabela = "AgendaManuExecutar" Then
                Comando.CommandText = "select * from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and CodManu=" + Id + ""
                ligacao.Open()
                reader = Comando.ExecuteReader
                While reader.Read
                    Form1.LstInserirTipo.SelectedValue = reader.GetString("CodTipoM")
                    Form1.TxtInserirNota.Text = reader.GetString("nota")
                End While
                ligacao.Close()
            End If
        Catch ex As Exception
            ligacao.Close()
            MsgBox(ex.ToString)
            Exit Sub
        End Try
        '
        'Selecionar Objetos Uteis a tabela
        '
        MenuInserir_Editar(Tabela)
        '
        'Variavel Global para saber qual o Tabela Selecionada
        '
        TabelaSelecionada = Tabela
        '
        'Variavel Global para saber qual o ID Selecionado
        '
        IDSelecionado = Id
    End Sub



    Public Sub InserirDados(ByVal Tabela As String)
        Dim Comando As New MySqlCommand
        '
        'Variavel Data
        '
        Dim Data As String
        'Data = Form1.CmbInserirAno.Text + "-" + Form1.CmbInserirMes.Text + "-" + Form1.CmbInserirDia.Text
        Data = String.Format("{0:yyyy-MM-dd}", Form1.DateTimePicker1.Value.Date)
        '
        'Selecionar comando para inserir
        '
        If Tabela = "AbastInsert" Then
            Comando = New MySqlCommand("insert into veiabast(Veiculo_KM,Quantidade,Valor,Notas,Codforn,Data,Codvei,Coduser) values ('" + Val(ConverterDistancia(Form1.TxtInserirQuilometros.Text)).ToString + "', '" + Val(ConverterVolume(Form1.TxtInserirQuantidade.Text)).ToString + "', '" + Val(ConverterMoeda(Form1.TxtInserirValor.Text)).ToString + "', '" + Form1.TxtInserirNota.Text.ToString + "','" + Form1.LstInserirFornecedor.SelectedValue.ToString + "', '" + Data + "', '" + DetalhesUtilizador.CodVeiculo.ToString + "', '" + DetalhesUtilizador.CodUser.ToString + "')", ligacao)
        ElseIf Tabela = "ManuInsert" Then
            Comando = New MySqlCommand("insert into manutencao(Veiculo_KM,CodTipoM,Valor,Nota,Codforn,Data_Efetuada,Efetuada,Codvei,CodUser) values ('" + Val(ConverterDistancia(Form1.TxtInserirQuilometros.Text)).ToString + "', '" + Form1.LstInserirTipo.SelectedValue.ToString + "', '" + Val(ConverterMoeda(Form1.TxtInserirValor.Text)).ToString + "', '" + Form1.TxtInserirNota.Text.ToString + "', '" + Form1.LstInserirFornecedor.SelectedValue.ToString + "', '" + Data + "', '" + "Sim" + "', '" + DetalhesUtilizador.CodVeiculo.ToString + "', '" + DetalhesUtilizador.CodUser.ToString + "')", ligacao)
        ElseIf Tabela = "DespInsert" Then
            Comando = New MySqlCommand("insert into Despesas(Veiculo_KM,CodTipoD,Valor,Nota,Codforn,Data_Efetuada,Efetuada,Codvei,CodUser) values ('" + Val(ConverterDistancia(Form1.TxtInserirQuilometros.Text)).ToString + "', '" + Form1.LstInserirTipo.SelectedValue.ToString + "', '" + Val(ConverterMoeda(Form1.TxtInserirValor.Text)).ToString + "', '" + Form1.TxtInserirNota.Text.ToString + "', '" + Form1.LstInserirFornecedor.SelectedValue.ToString + "', '" + Data + "', '" + "Sim" + "', '" + DetalhesUtilizador.CodVeiculo.ToString + "', '" + DetalhesUtilizador.CodUser.ToString + "')", ligacao)
        ElseIf Tabela = "AgendaDespInsert" Then
            Comando = New MySqlCommand("insert into Despesas(Veiculo_KM_Agendado,CodTipoD,Nota,Codforn,Data_Agendada,Efetuada,Codvei,CodUser,lembrarpor) values ('" + "0" + "', '" + Form1.LstInserirTipo.SelectedValue.ToString + "', '" + Form1.TxtInserirNota.Text.ToString + "', '" + "1" + "', '" + Data + "', '" + "Nao" + "', '" + DetalhesUtilizador.CodVeiculo.ToString + "', '" + DetalhesUtilizador.CodUser.ToString + "', '" + "DATA" + "')", ligacao)
        ElseIf Tabela = "AgendaManuInsert" Then
            Comando = New MySqlCommand("insert into Manutencao(Veiculo_KM_Agendado,CodTipoM,Nota,Codforn,Data_Agendada,Efetuada,Codvei,CodUser,lembrarpor) values ('" + "0" + "', '" + Form1.LstInserirTipo.SelectedValue.ToString + "', '" + Form1.TxtInserirNota.Text.ToString + "', '" + "1" + "', '" + Data + "', '" + "Nao" + "', '" + DetalhesUtilizador.CodVeiculo.ToString + "', '" + DetalhesUtilizador.CodUser.ToString + "', '" + "DATA" + "')", ligacao)
        End If
        '
        'Executar comando
        '
        Try
            ligacao.Open()
            Comando.ExecuteNonQuery()
            ligacao.Close()
            MsgBox("Inserido com sucesso")
            Form1.Panel1.Hide()
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
            Exit Sub
        End Try
        'Atualizar Listview
        If Tabela = "AbastInsert" Then
            TabelaVer(LstVAbastecimento, "select CodVeiAbast,Data,Nome as Fornecedor,concat(ROUND((quantidade/" + VolumeConversao().ToString + "),2),' " + VolumeSimbolo() + "') as 'Quantidade',concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "' ,concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador  from VeiCondu,veiabast,veiculos,fornecedores,Utilizador where VeiCondu.Codvei=Veiculos.Codvei and Veiculos.Codvei=Veiabast.CodVei and fornecedores.Codforn=Veiabast.Codforn and Utilizador.CodUser=Veiabast.Coduser and VeiCondu.EmUso='Sim' and Utilizador.CodUser='" + DetalhesUtilizador.CodUser + "'order by CodVeiAbast DESC", "LstVAbastecimento")
        ElseIf Tabela = "ManuInsert" Then
            TabelaVer(LstVManu, "select Codmanu,Data_Efetuada as Data,fornecedores.Nome as Fornecedor,tipoManu.Nome as Tipo,concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao.ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador from Utilizador,VeiCondu,Manutencao,veiculos,fornecedores,tipomanu where VeiCondu.Codvei=Veiculos.Codvei and Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and Utilizador.CodUser=Manutencao.Coduser and efetuada='Sim' and EmUso='Sim' and Manutencao.CodUser='" + DetalhesUtilizador.CodUser + "'", "LstVManu")
        ElseIf Tabela = "DespInsert" Then
            TabelaVer(LstVDesp, "select Coddesp,Data_Efetuada as Data,fornecedores.Nome as Fornecedor,tipodesp.nome as Tipo ,concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Sim'  and Veiculos.CodVei='" + DetalhesUtilizador.CodVeiculo.ToString + "' order by Veiculo_km", "LstVDesp")
        ElseIf Tabela = "AgendaDespInsert" Then
            TabelaVer(LstVAgendaDesp, "select CodDesp,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,TipoDesp.Nome as Tipo, LembrarPor as 'Lembrar por:' from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Nao' and despesas.coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaDesp")
        ElseIf Tabela = "AgendaManuInsert" Then
            TabelaVer(LstVAgendaManu, "select Codmanu,Data_agendada as 'Data Agendada',Veiculo_Km_Agendado as 'KM Agendados',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,tipoManu.Nome as Tipo, LembrarPor as 'Lembrar por:' from Manutencao,veiculos,fornecedores,tipomanu where Veiculos.Codvei=manutencao.CodVei and fornecedores.Codforn=manutencao.Codforn and tipomanu.CodtipoM=manutencao.codtipom and efetuada='Nao' and coduser=" + DetalhesUtilizador.CodUser + "", "LstVAgendaManu")
        End If


    End Sub

    Public Sub EditarDados(ByVal Tabela As String)
        Dim comando As New MySqlCommand
        '
        'Variavel para juntar os campos ano/mes/dia
        '
        Dim data As String
        'data = Form1.CmbInserirAno.Text + "-" + Form1.CmbInserirMes.Text + "-" + Form1.CmbInserirDia.Text
        data = String.Format("{0:yyyy-MM-dd}", Form1.DateTimePicker1.Value.Date)
        '
        'Selecionar comando para editar
        '
        If Tabela = "AbastEdit" Then
            comando = New MySqlCommand("Update veiabast set Veiculo_KM='" + Val(ConverterDistancia(Form1.TxtInserirQuilometros.Text)).ToString + "',Quantidade='" + Val(ConverterVolume(Form1.TxtInserirQuantidade.Text)).ToString + "',Valor='" + Val(ConverterMoeda(Form1.TxtInserirValor.Text)).ToString + "',Notas='" + Form1.TxtInserirNota.Text.ToString + "',Codforn='" + Form1.LstInserirFornecedor.SelectedValue.ToString + "' where CodveiAbast='" + IDSelecionado + "'", ligacao)
        ElseIf Tabela = "ManuEdit" Then
            comando = New MySqlCommand("Update Manutencao set Veiculo_KM='" + Val(ConverterDistancia(Form1.TxtInserirQuilometros.Text)).ToString + "',CodTipoM='" + Form1.LstInserirTipo.SelectedValue.ToString + "',Valor='" + Val(ConverterMoeda(Form1.TxtInserirValor.Text)).ToString + "',Nota='" + Form1.TxtInserirNota.Text.ToString + "',Codforn='" + Form1.LstInserirFornecedor.SelectedValue.ToString + "' where Codmanu='" + IDSelecionado + "'", ligacao)
        ElseIf Tabela = "DespEdit" Then
            comando = New MySqlCommand("Update Despesas set Veiculo_KM='" + Val(ConverterDistancia(Form1.TxtInserirQuilometros.Text)).ToString + "',CodTipoD='" + Form1.LstInserirTipo.SelectedValue.ToString + "',Valor='" + Val(ConverterMoeda(Form1.TxtInserirValor.Text)).ToString + "',Nota='" + Form1.TxtInserirNota.Text.ToString + "',Codforn='" + Form1.LstInserirFornecedor.SelectedValue.ToString + "' where CodDesp='" + IDSelecionado + "'", ligacao)
        ElseIf Tabela = "AgendaDespReagendar" Then
            comando = New MySqlCommand("Update Despesas set Veiculo_KM_Agendado='" + "0" + "',LembrarPor='" + "DATA" + "',Data_agendada='" + data + "',Nota='" + Form1.TxtInserirNota.Text.ToString + "'where CodDesp='" + IDSelecionado + "'", ligacao)
        ElseIf Tabela = "AgendaDespExecutar" Then
            comando = New MySqlCommand("Update Despesas set Veiculo_KM='" + Val(ConverterDistancia(Form1.TxtInserirQuilometros.Text)).ToString + "',CodTipoD='" + Form1.LstInserirTipo.SelectedValue.ToString + "',Valor='" + Val(ConverterMoeda(Form1.TxtInserirValor.Text)).ToString + "',Nota='" + Form1.TxtInserirNota.Text.ToString + "',Codforn='" + Form1.LstInserirFornecedor.SelectedValue.ToString + "', CodUser='" + DetalhesUtilizador.CodUser + "', Data_Efetuada='" + data + "', efetuada='Sim' where CodDesp='" + IDSelecionado + "'", ligacao)
        ElseIf Tabela = "AgendaManuReagendar" Then
            comando = New MySqlCommand("Update Manutencao set Veiculo_KM_Agendado='" + "0" + "',LembrarPor='" + "DATA" + "',Data_agendada='" + data + "',Nota='" + Form1.TxtInserirNota.Text.ToString + "'where Codmanu='" + IDSelecionado + "'", ligacao)
        ElseIf Tabela = "AgendaManuExecutar" Then
            comando = New MySqlCommand("Update Manutencao set Veiculo_KM='" + Val(ConverterDistancia(Form1.TxtInserirQuilometros.Text)).ToString + "',CodTipoM='" + Form1.LstInserirTipo.SelectedValue.ToString + "',Valor='" + Val(ConverterMoeda(Form1.TxtInserirValor.Text)).ToString + "',Nota='" + Form1.TxtInserirNota.Text.ToString + "',Codforn='" + Form1.LstInserirFornecedor.SelectedValue.ToString + "', CodUser='" + DetalhesUtilizador.CodUser + "', Data_Efetuada='" + data + "', efetuada='Sim' where CodManu='" + IDSelecionado + "'", ligacao)
        End If
        '
        'Executar comando
        '
        Try
            ligacao.Open()
            comando.ExecuteNonQuery()
            ligacao.Close()
            MsgBox("Editado com sucesso")
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
            Exit Sub
        End Try
    End Sub

    Public Sub ApagarDados(ByVal Tabela As String, ByVal COD As String)
        Dim NOMECOD As String = ""
        '
        'Selecionar nome do codigo da tabela
        '
        If Tabela.Contains("manu") Then
            NOMECOD = "codmanu"
        ElseIf Tabela.Contains("desp") Then
            NOMECOD = "coddesp"
        Else
            MsgBox("Erro Apagar")
            Exit Sub
        End If
        '
        'Executar comando
        '
        Try
            Comando = New MySqlCommand("Delete from " + Tabela + " where " + NOMECOD + "='" + COD + "'", ligacao)
            ligacao.Open()
            Comando.ExecuteNonQuery()
            ligacao.Close()
            MsgBox("Apagado com sucesso")
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.ToString)
            ligacao.Close()
            Exit Sub
        End Try
    End Sub

    Private Sub VerDadosCMBGRAF(ByVal SQL As String, ByVal Campo As String, ByVal ID As String, ByVal Cmb As ComboBox)
        Dim Dados As DataSet = New DataSet
        adapter.SelectCommand = New MySqlCommand
        adapter.SelectCommand.Connection = ligacao
        adapter.SelectCommand.CommandText = SQL
        Try
            ligacao.Open()
            adapter.Fill(Dados, "CMB")
            ligacao.Close()
        Catch ex As Exception
            MsgBox("ERRO" + "CMB" + "!")
            Exit Sub
        Finally
            If ligacao.State = ConnectionState.Open Then
                ligacao.Close()
            End If
        End Try
        Cmb.DataSource = Dados.Tables(0)
        Cmb.DisplayMember = Campo
        Cmb.ValueMember = ID
        'MAY GOD BE WITH THIS PIECE OF CODE!
    End Sub



    Public RELATORIO As String
    Public Sub RelatorioSelecionado(ByVal Pesquisa As String)
        If Pesquisa.Contains("CodUser") Then
            VerDadosCMBGRAF("select CodUser,concat(Nome_Proprio, ' ', Apelido)as Utilizador from utilizador", "Utilizador", "CodUser", Form1.CmbLista)
        ElseIf Pesquisa.Contains("CodVei") Then
            VerDadosCMBGRAF("Select CodVei,concat(Marca, ' ', Modelo,' ',Ano,' Matricula:',Matricula) as Veiculo from veiculos", "Veiculo", "CodVei", Form1.CmbLista)
        End If
        RELATORIO = Pesquisa
    End Sub


    Public Sub GraficoSelecionado(Optional ByVal Pesquisa As String = "", Optional ByVal Cod As String = "")
        Dim Comando As New MySqlCommand
        Dim reader As MySqlDataReader
        Comando.Connection = SQL.ligacao
        Dim despesaValor As Decimal = 0
        Dim manutencaoValor As Decimal = 0
        Dim AbastecimentoValor As Decimal = 0
        Dim FinalString As String
        FinalString = Pesquisa + Cod
        'Despesa
        Comando.CommandText = "SELECT ROUND(sum(valor*" + MoedaConversao().ToString + "),2) as Despesa FROM despesas " + FinalString
        Try
            ligacao.Open()
            reader = Comando.ExecuteReader
            While reader.Read
                despesaValor = Convert.ToDecimal(reader("Despesa"))
            End While
        Catch ex As Exception
           
        Finally
            If ligacao.State = ConnectionState.Open Then
                ligacao.Close()
            End If
        End Try
        'Manutenção
        Comando.CommandText = " SELECT ROUND(sum(Valor*" + MoedaConversao().ToString + "),2) as Manutencao FROM manutencao " + FinalString
        Try
            ligacao.Open()
            reader = Comando.ExecuteReader
            While reader.Read
                manutencaoValor = Convert.ToDecimal(reader("Manutencao"))
            End While
        Catch ex As Exception
            
        Finally
            If ligacao.State = ConnectionState.Open Then
                ligacao.Close()
            End If
        End Try
        'Abastecimento
        Comando.CommandText = "  SELECT ROUND(sum(Valor*" + MoedaConversao().ToString + "),2) as Abastecimento FROM veiabast " + FinalString
        Try
            ligacao.Open()
            reader = Comando.ExecuteReader
            While reader.Read
                AbastecimentoValor = Convert.ToDecimal(reader("Abastecimento"))
            End While
        Catch ex As Exception

        Finally
            If ligacao.State = ConnectionState.Open Then
                ligacao.Close()
            End If
        End Try
        Grafico(AbastecimentoValor, despesaValor, manutencaoValor)
    End Sub

    Public Function CarroMaisCaro() As String
        Dim Comando As New MySqlCommand
        Dim reader As MySqlDataReader
        Comando.Connection = SQL.ligacao
        Dim valor, veiculo As String
        Comando.CommandText = "SELECT ROUND(sum(Valor*" + MoedaConversao().ToString + "),2) as valor, veiculo FROM veiculomaiorcusto"
        Try
            ligacao.Open()
            reader = Comando.ExecuteReader
            While reader.Read
                valor = reader("Valor")
                veiculo = reader("veiculo")
            End While
        Catch ex As Exception
            MsgBox("erro! " + ex.Message)
        Finally
            If ligacao.State = ConnectionState.Open Then
                ligacao.Close()
            End If
        End Try
        Return (veiculo + " (" + valor + MoedaSimbolo() + ")")
    End Function




    Public Function UtilizadorMaisCaro() As String 'Desativado
        Dim Comando As New MySqlCommand
        Dim reader As MySqlDataReader
        Comando.Connection = SQL.ligacao
        Dim valor, utilizador As String
        Comando.CommandText = "SELECT ROUND(sum(Valor*" + MoedaConversao().ToString + "),2) as valor, utilizador FROM utilizadormaiorvalor"
            Try
                ligacao.Open()
                reader = Comando.ExecuteReader
                While reader.Read
                valor = reader("Valor")
                utilizador = reader("Utilizador")
                End While
            Catch ex As Exception
                MsgBox("erro! " + ex.Message)
            Finally
                If ligacao.State = ConnectionState.Open Then
                    ligacao.Close()
                End If
            End Try
        Return (utilizador + " (" + valor + MoedaSimbolo() + ")")
    End Function

    Public Sub VerAgendaAtrasados()
        '
        'Só a querry tá funcional.... Falta saber como Mostrar
        '

        Dim Tipo As DataSet = New DataSet
        adapter.SelectCommand = New MySqlCommand
        adapter.SelectCommand.Connection = ligacao
        adapter.SelectCommand.CommandText = ("select * from despesas where Efetuada='Nao' and Data_Agendada<=now() order by Data_Agendada")
        Try
            ligacao.Open()
            adapter.Fill(Tipo, "TIPOMANU")
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox("ERRO Fornecedor")
            Exit Sub
        End Try
        Form1.LstInserirTipo.DataSource = Tipo.Tables(0)
        Form1.LstInserirTipo.DisplayMember = "Nome"
        Form1.LstInserirTipo.ValueMember = "CodTipoM"
    End Sub

    Public Sub VerAgendaProxima()
        '
        'Só a querry tá funcional.... Falta saber como Mostrar
        '
        Dim Tipo As DataSet = New DataSet
        adapter.SelectCommand = New MySqlCommand
        adapter.SelectCommand.Connection = ligacao
        adapter.SelectCommand.CommandText = ("select * from despesas where Efetuada='Nao' and Data_Agendada>=now() order by Data_Agendada")
        Try
            ligacao.Open()
            adapter.Fill(Tipo, "TIPOMANU")
            ligacao.Close()
        Catch ex As Exception
            ligacao.Close()
            MsgBox("ERRO Fornecedor")
            Exit Sub
        End Try
        Form1.LstInserirTipo.DataSource = Tipo.Tables(0)
        Form1.LstInserirTipo.DisplayMember = "Nome"
        Form1.LstInserirTipo.ValueMember = "CodTipoM"
    End Sub











    '
    'Admin
    '
    '
    'Mostrar Inserir
    '
    Public Sub Inserir_EditarTabelaSQLAdmin(ByVal Tabela As String, Optional ByVal Id As String = "")
        Dim Data As DataSet = New DataSet
        Dim Tipo As DataSet = New DataSet
        Dim reader As MySqlDataReader
        For Each c As Control In Form1.PnlAdminInserir.Controls
            c.Text = ""
        Next
        '
        'Selecionar dados a mostrar na ListBox Tipos
        '
        If Tabela = "VeiculoInsert" Or Tabela = "VeiculoEdit" Then
            '
            'Tipo de veiculo
            '
            adapter.SelectCommand = New MySqlCommand
            adapter.SelectCommand.Connection = ligacao
            adapter.SelectCommand.CommandText = ("Select CodTipoV, Nome from TipoVei")
            Try
                ligacao.Open()
                adapter.Fill(Tipo, "TipoVei")
                ligacao.Close()
            Catch ex As Exception
                ligacao.Close()
                MsgBox("Erro! Contate o administrador com o seguinte erro:  " + ex.Message, MsgBoxStyle.Critical, "Erro!!!")
                Exit Sub
            End Try
            Form1.LstAdminInserir.DataSource = Tipo.Tables(0)
            Form1.LstAdminInserir.DisplayMember = "Nome"
            Form1.LstAdminInserir.ValueMember = "CodTipoV"
            '
            'Tipo de Combustivel
            '
            adapter.SelectCommand = New MySqlCommand
            adapter.SelectCommand.Connection = ligacao
            adapter.SelectCommand.CommandText = ("Select CodTipoC, Nome from TipoCom")
            Try
                ligacao.Open()
                adapter.Fill(Data, "TipoCom")
            Catch ex As Exception
                MsgBox("Erro! Contate o administrador com o seguinte erro:  " + ex.Message, MsgBoxStyle.Critical, "Erro!!!")
                Exit Sub
            Finally
                ligacao.Close()
            End Try
            Form1.LstAdminInserir2.DataSource = Data.Tables(0)
            Form1.LstAdminInserir2.DisplayMember = "Nome"
            Form1.LstAdminInserir2.ValueMember = "CodTipoC"
            '
            '
            '
        ElseIf Tabela = "FornecedorInsert" Or Tabela = "FornecedorEdit" Then

            '
            'Tipo de Fornecedor
            '
            adapter.SelectCommand = New MySqlCommand
            adapter.SelectCommand.Connection = ligacao
            adapter.SelectCommand.CommandText = ("Select CodTipoF, Nome from Tipofor")
            Try
                adapter.Fill(Tipo, "TipoFor")
                ligacao.Close()
            Catch ex As Exception
                MsgBox("Erro! Contate o administrador com o seguinte erro:  " + ex.Message, MsgBoxStyle.Critical, "Erro!!!")
                Exit Sub
            Finally
                ligacao.Close()
            End Try
            Form1.LstAdminInserir.DataSource = Tipo.Tables(0)
            Form1.LstAdminInserir.DisplayMember = "Nome"
            Form1.LstAdminInserir.ValueMember = "CodTipoF"
            '
            'Pais
            '
            adapter.SelectCommand = New MySqlCommand
            adapter.SelectCommand.Connection = ligacao
            adapter.SelectCommand.CommandText = ("Select codci, Nome from Cidade")
            Try
                ligacao.Open()
                adapter.Fill(Data, "Cidade")
            Catch ex As Exception
                MsgBox("Erro! Contate o administrador com o seguinte erro:  " + ex.Message, MsgBoxStyle.Critical, "Erro!!!")
                Exit Sub
            Finally
                ligacao.Close()
            End Try
            Form1.LstAdminInserir2.DataSource = Data.Tables(0)
            Form1.LstAdminInserir2.DisplayMember = "Nome"
            Form1.LstAdminInserir2.ValueMember = "codci"
            '
            '
            '
        ElseIf Tabela = "UtilizadorInsert" Or Tabela = "UtilizadorEdit" Or Tabela = "UtilizadorAtivar" Then
            '
            'Tipo de Utilizador
            '
            adapter.SelectCommand = New MySqlCommand
            adapter.SelectCommand.Connection = ligacao
            adapter.SelectCommand.CommandText = ("Select CodTipoU, Designacao from TipoUser")
            Try
                ligacao.Open()
                adapter.Fill(Tipo, "TIPOUSER")
            Catch ex As Exception
                MsgBox("Erro! Contate o administrador com o seguinte erro:  " + ex.Message, MsgBoxStyle.Critical, "Erro!!!")
                Exit Sub
            Finally
                ligacao.Close()
            End Try
            Form1.LstAdminInserir.DataSource = Tipo.Tables(0)
            Form1.LstAdminInserir.DisplayMember = "Designacao"
            Form1.LstAdminInserir.ValueMember = "CodTipoU"
            '
            'Pais
            '
            adapter.SelectCommand = New MySqlCommand
            adapter.SelectCommand.Connection = ligacao
            adapter.SelectCommand.CommandText = ("Select CodPais, Nome from Pais")
            Try
                ligacao.Open()
                adapter.Fill(Data, "Pais")
            Catch ex As Exception
                MsgBox("Erro! Contate o administrador com o seguinte erro:  " + ex.Message, MsgBoxStyle.Critical, "Erro!!!")
                Exit Sub
            Finally
                ligacao.Close()
            End Try
            ' Form1.LstAdminInserir2.DataSource = Data.Tables(0)
            'Form1.LstAdminInserir2.DisplayMember = "Nome"
            'Form1.LstAdminInserir2.ValueMember = "CodTipoC"
        End If

        Comando = New MySqlCommand
        Comando.Connection = ligacao
        '
        'Selecionar dados da entrada a editar
        '
        Try

            If Tabela = "VeiculoEdit" Then
                'Por o tipo de unidade que o form espera nas labels!
                Comando.CommandText = "SELECT * FROM veiculos where codvei='" + Id + "'"
                ligacao.Open()
                reader = Comando.ExecuteReader
                While reader.Read
                    Form1.TxtAdminInserir1.Text = reader.GetString("Matricula")
                    Form1.TxtAdminInserir2.Text = reader.GetString("Marca")
                    Form1.TxtAdminInserir3.Text = reader.GetString("Modelo")
                    Form1.TxtAdminInserir4.Text = reader.GetString("Cor")
                    Form1.TxtAdminInserir5.Text = reader.GetString("Ano")
                    Form1.LstAdminInserir.SelectedValue = reader.GetString("CodTipoV")
                    Form1.LstAdminInserir2.SelectedValue = reader.GetString("CodTipoC")
                End While
                ligacao.Close()
            ElseIf Tabela = "UtilizadorEdit" Then
                Comando.CommandText = "Select * from Utilizador where CodUser=" + Id + ""
                ligacao.Open()
                reader = Comando.ExecuteReader
                While reader.Read
                    Form1.TxtAdminInserir1.Text = reader("Nome_Registo")
                    Form1.TxtAdminInserir2.Text = reader("Nome_Proprio")
                    Form1.TxtAdminInserir3.Text = reader("Apelido")
                    Form1.TxtAdminInserir4.Text = reader("Rua")
                    Form1.TxtAdminInserir5.Text = reader("N_Telemovel")
                    Form1.TxtAdminInserir6.Text = reader("Email")
                    Form1.DtpAdminInserir.CustomFormat = "yyyy-MM-dd"
                    Form1.DtpAdminInserir.Value = reader.GetDateTime("Data_Nascimento")
                End While
                ligacao.Close()
            ElseIf Tabela = "UtilizadorAtivar" Then
                Comando.CommandText = "select CodUser, CodTipoU from Utilizador where codUser=" + Id + ""
                ligacao.Open()
                reader = Comando.ExecuteReader
                While reader.Read
                    Form1.LstAdminInserir.SelectedValue = reader.GetString("CodTipoU")
                End While
                ligacao.Close()
            ElseIf Tabela = "FornecedorEdit" Then
                Comando.CommandText = "select * from Fornecedores where CodForn =" + Id + ""
                ligacao.Open()
                reader = Comando.ExecuteReader
                While reader.Read
                    Form1.TxtAdminInserir1.Text = reader("Nome")
                    Form1.TxtAdminInserir2.Text = reader("Rua")
                    Form1.TxtAdminInserir3.Text = reader("N_Telemovel")
                    Form1.TxtAdminInserir4.Text = reader("N_Telefone")
                    Form1.TxtAdminInserir5.Text = reader("Site")
                    Form1.TxtAdminInserir6.Text = reader("Email")
                    Form1.LstAdminInserir.SelectedValue = reader.GetString("CodTipoF")
                    Form1.LstAdminInserir2.SelectedValue = reader.GetString("CodCi")
                End While
            End If
        Catch ex As Exception
            Form1.PnlAdminInserir.Hide()
            MsgBox("Erro! Contate o administrador com o seguinte erro:  " + ex.Message, MsgBoxStyle.Critical, "Erro!!!")
            Exit Sub
        Finally
            ligacao.Close()
        End Try
        '
        'Selecionar Objetos Uteis a tabela
        '
        MenuInserir_EditarAdmin(Tabela)
        '
        'Variavel Global para saber qual o Tabela Selecionada
        '
        TabelaSelecionadaAdmin = Tabela
        '
        'Variavel Global para saber qual o ID Selecionado
        '
        IDSelecionadoAdmin = Id
    End Sub
    '
    'Inserir Dados
    '
    Public Sub InserirDadosAdmin(ByVal Tabela As String)
        Dim Comando As New MySqlCommand
        '
        'Variavel Data
        '
        Dim Data As String
        Data = String.Format("{0:yyyy-MM-dd}", Form1.DateTimePicker1.Value.Date)
        '
        'Selecionar comando para inserir
        '
        If Tabela = "UtilizadorInsert" Then 'Falta os campos(TXT, CMB...)
            'Retirado
            'Comando = New MySqlCommand("insert into Utilizador(Nome_Registo,Senha,Nome_Proprio,Apelidos,Genero,Data_Nascimento,Rua,N_Telemovel,Email,CodTipoU,CodCi) values ('" + Val(ConverterDistancia(Form1.TxtInserirQuilometros.Text)).ToString + "', '" + Val(ConverterVolume(Form1.TxtInserirQuantidade.Text)).ToString + "', '" + Val(ConverterMoeda(Form1.TxtInserirValor.Text)).ToString + "', '" + Form1.TxtInserirNota.Text.ToString + "','" + Form1.LstInserirFornecedor.SelectedValue.ToString + "', '" + Data + "', '" + DetalhesUtilizador.CodVeiculo.ToString + "', '" + DetalhesUtilizador.CodUser.ToString + "')", ligacao)
            '
            MsgBox("Erro! Contate o administrador com o seguinte erro: Sem autorização ", MsgBoxStyle.Critical, "Erro!!!")
        ElseIf Tabela = "FornecedorInsert" Then
            Comando = New MySqlCommand("insert into Fornecedores(Nome,Rua,N_Telemovel,N_Telefone,Site,Email,CodTipoF,CodCi) values ('" + Form1.TxtAdminInserir1.Text.ToString + "', '" + Form1.TxtAdminInserir2.Text.ToString + "', '" + Form1.TxtAdminInserir3.Text.ToString + "', '" + Form1.TxtAdminInserir4.Text.ToString + "', '" + Form1.TxtAdminInserir5.Text.ToString + "', '" + Form1.TxtAdminInserir6.Text.ToString + "', '" + Form1.LstAdminInserir.SelectedValue.ToString + "', '" + Form1.LstAdminInserir2.SelectedValue.ToString + "')", ligacao)
        ElseIf Tabela = "VeiculoInsert" Then
            Comando = New MySqlCommand("insert into Veiculos(matricula,Marca,Modelo,Cor,Ano,CodTipoV,CodTipoC) values ('" + Form1.TxtAdminInserir1.Text.ToString + "', '" + Form1.TxtAdminInserir2.Text.ToString + "', '" + Form1.TxtAdminInserir3.Text.ToString + "', '" + Form1.TxtAdminInserir4.Text.ToString + "', '" + Form1.TxtAdminInserir5.Text.ToString + "', '" + Form1.LstAdminInserir.SelectedValue.ToString + "', '" + Form1.LstAdminInserir2.SelectedValue.ToString + "')", ligacao)
        ElseIf Tabela = "Cidade" Then
            Comando = New MySqlCommand("insert into Cidade(Nome,CodPais) values ('" + Form1.TxtAdminCidade.Text.ToString + "', '" + Form1.LstAdminCidade.SelectedValue.ToString + "')", ligacao)
        End If
        '
        'Executar comando
        '
        Try
            ligacao.Open()
            Comando.ExecuteNonQuery()
            MsgBox("Inserido com sucesso")
            Form1.Panel1.Hide()
        Catch ex As Exception
            MsgBox("Erro! Contate o administrador com o seguinte erro:  " + ex.Message, MsgBoxStyle.Critical, "Erro!!!")
            Exit Sub
        Finally
            ligacao.Close()
        End Try

        'MUDAR ISTO
        'Atualizar Listview
        If Tabela = "AbastInsert" Then
            TabelaVer(Form1.LstVAbastecimento, "select CodVeiAbast,Data,Nome as Fornecedor,concat(ROUND((quantidade/" + VolumeConversao().ToString + "),2),' " + VolumeSimbolo() + "') as 'Quantidade',concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "' ,concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador  from VeiCondu,veiabast,veiculos,fornecedores,Utilizador where VeiCondu.Codvei=Veiculos.Codvei and Veiculos.Codvei=Veiabast.CodVei and fornecedores.Codforn=Veiabast.Codforn and Utilizador.CodUser=Veiabast.Coduser and VeiCondu.EmUso='Sim' and Utilizador.CodUser='" + DetalhesUtilizador.CodUser + "'order by CodVeiAbast DESC", "LstVAbastecimento")
        ElseIf Tabela = "VeiculoInsert" Then
            TabelaVer(Form1.LstVAdminVeiculo, "Select Codvei,Codvei as Codigo, Matricula, TipoVei.Nome as 'Tipo de Veículo' from Veiculos,TipoVei where veiculos.CodtipoV=TipoVei.CodTipoV", "LstVVeiculo")
        ElseIf Tabela = "DespInsert" Then
            TabelaVer(Form1.LstVDesp, "select Coddesp,Data_Efetuada as Data,fornecedores.Nome as Fornecedor,tipodesp.nome as Tipo ,concat(ROUND((valor*" + MoedaConversao().ToString + "),2),' " + MoedaSimbolo() + "') as 'Valor',concat(ROUND((Veiculo_km/" + DistanciaConversao().ToString + "),2),' " + DistanciaSimbolo() + "') as '" + DistanciaDistancia() + "',concat(Marca, ' ', Modelo,' ',Ano,' ',Matricula) as Veículo,Nome_Registo as Utilizador from despesas,Veiculos,Fornecedores,Utilizador,TipoDesp where Despesas.codvei=veiculos.codvei and Despesas.codforn=Fornecedores.codforn and Despesas.coduser=Utilizador.coduser and Despesas.codtipod=tipodesp.codtipod and efetuada='Sim'  and Veiculos.CodVei='" + DetalhesUtilizador.CodVeiculo.ToString + "' order by Veiculo_km", "LstVDesp")
        ElseIf Tabela = "Cidade" Then
            TabelaVerAdmin(Form1.LstAdminCidade, "SELECT * FROM pais", "Pais", "CodPais", "Nome")
        End If
    End Sub


    Public Sub EditarDadosAdmin(ByVal Tabela As String, Optional Cod As String = "")
        Dim comando As New MySqlCommand
        '
        'Variavel para juntar os campos ano/mes/dia
        '
        Dim data As String
        'data = Form1.CmbInserirAno.Text + "-" + Form1.CmbInserirMes.Text + "-" + Form1.CmbInserirDia.Text
        data = String.Format("{0:yyyy-MM-dd}", Form1.DtpAdminInserir.Value.Date)
        '
        'Selecionar comando para editar
        '
        If Tabela = "VeiculoEdit" Then
            comando = New MySqlCommand("Update veiculos set Matricula='" + Form1.TxtAdminInserir1.Text.ToString + "',Marca='" + Form1.TxtAdminInserir2.Text.ToString + "',Modelo='" + Form1.TxtAdminInserir3.Text.ToString + "',Cor='" + Form1.TxtAdminInserir4.Text.ToString + "',Ano='" + Form1.TxtAdminInserir5.Text.ToString + "',CodTipoC='" + Form1.LstAdminInserir2.SelectedValue.ToString + "',CodTipoV='" + Form1.LstAdminInserir.SelectedValue.ToString + "' where CodVei='" + IDSelecionadoAdmin + "'", ligacao)
        ElseIf Tabela = "UtilizadorEdit" Then
            comando = New MySqlCommand("Update Utilizador set data_nascimento='" + data + "',Nome_Registo='" + Form1.TxtAdminInserir1.Text.ToString + "',Nome_Proprio='" + Form1.TxtAdminInserir2.Text.ToString + "',Apelido='" + Form1.TxtAdminInserir3.Text.ToString + "',Rua='" + Form1.TxtAdminInserir4.Text.ToString + "', N_Telemovel='" + Form1.TxtAdminInserir5.Text.ToString + "',Email='" + Form1.TxtAdminInserir6.Text.ToString + "' where CodUser='" + IDSelecionadoAdmin + "'", ligacao)
        ElseIf Tabela = "UtilizadorAtivar" Then
            comando = New MySqlCommand("Update Utilizador set CodTipoU='" + Form1.LstAdminInserir.SelectedValue.ToString + "' where CodUser='" + IDSelecionadoAdmin + "'", ligacao)
        ElseIf Tabela = "FornecedorEdit" Then
            comando = New MySqlCommand("Update Fornecedores set Nome='" + Form1.TxtAdminInserir1.Text.ToString + "',Rua='" + Form1.TxtAdminInserir2.Text.ToString + "',N_Telemovel='" + Form1.TxtAdminInserir3.Text.ToString + "',N_Telefone='" + Form1.TxtAdminInserir4.Text.ToString + "',Site='" + Form1.TxtAdminInserir5.Text.ToString + "',Email='" + Form1.TxtAdminInserir6.Text.ToString + "',CodTipoF='" + Form1.LstAdminInserir.SelectedValue.ToString + "',CodCi='" + Form1.LstAdminInserir2.SelectedValue.ToString + "' where CodForn='" + IDSelecionadoAdmin + "'", ligacao)
        ElseIf Tabela = "VeiculoDesativar" Then
            comando = New MySqlCommand("Update veiculos set codTipoV=4 where Codvei='" + Cod + "'", ligacao)
        ElseIf Tabela = "CidadeEdit" Then
            comando = New MySqlCommand("Update Cidade set Nome='" + Form1.TxtAdminCidadeEdit.Text.ToString + "', CodPais='" + Form1.LstAdminCidadeEditPais.SelectedValue.ToString + "' where CodCi='" + Cod + "'", ligacao)
        End If
        '
        'Executar comando
        '
        Try
            ligacao.Open()
            comando.ExecuteNonQuery()
            ligacao.Close()
            MsgBox("Editado com sucesso")
            Exit Sub
        Catch ex As Exception
            MsgBox("Erro! Contate o administrador com o seguinte erro:  " + ex.Message, MsgBoxStyle.Critical, "Erro!!!")
            ligacao.Close()
            Exit Sub
        End Try
    End Sub


    Public Sub TabelaVerAdmin(ByVal Lst As ListBox, ByVal LinhaSql As String, ByVal Tabela As String, ByVal Cod As String, ByVal display As String)
        Dim Dados As DataSet = New DataSet
        adapter.SelectCommand = New MySqlCommand
        adapter.SelectCommand.Connection = ligacao
        Dim itemcoll(100) As String
        adapter.SelectCommand.CommandText = LinhaSql
        Try
            ligacao.Open()
            adapter.Fill(Dados, Tabela)
            ligacao.Close()
        Catch ex As Exception
            MsgBox("Erro! Contate o administrador com o seguinte erro:  " + ex.Message, MsgBoxStyle.Critical, "Erro!!!")
            Exit Sub
        Finally
            If ligacao.State = ConnectionState.Open Then
                ligacao.Close()
            End If
        End Try
        Lst.Font = GetInstance(8, FontStyle.Bold)
        Lst.DataSource = Dados.Tables(0)
        Lst.DisplayMember = display
        Lst.ValueMember = Cod
    End Sub

    Public Sub SelecionarCidade(ByVal cod As String)
        Comando = New MySqlCommand
        Comando.Connection = ligacao
        'Por o tipo de unidade que o form espera nas labels!
        Try
            Comando.CommandText = "SELECT * FROM Cidade where CodCi='" + cod + "'"
            ligacao.Open()
            reader = Comando.ExecuteReader
            While reader.Read
                Form1.LstAdminCidadeEditPais.SelectedValue = reader.GetString("CodPais")
                Form1.TxtAdminCidadeEdit.Text = reader.GetString("Nome")
            End While
        Catch ex As Exception
            MsgBox("Erro! Contate o administrador com o seguinte erro:  " + ex.Message, MsgBoxStyle.Critical, "Erro!!!")
        Finally
            ligacao.Close()
        End Try
        
    End Sub
End Module
