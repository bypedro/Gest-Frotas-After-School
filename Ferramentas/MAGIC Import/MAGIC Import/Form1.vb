Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DB = InputBox("Nome Base de dados")
        password = InputBox("Password da Base de dados (Deixar em branco se não tiver)")
        ligacao.ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false", "localhost", "root", password, DB)
        Try
            ligacao.Open()
            MsgBox("Connected")
        Catch ex As Exception
            MsgBox(ex.Message)
            End
        End Try
        ligacao.Close()

    End Sub

    Dim password As String
    Dim DB As String
    Dim fich As FileStream

    Dim nomefich As String

    ' Dim ligacao As New MySqlConnection("Server=localhost;Database=" + DB + ";Uid=root;Pwd=" + password + ";Connect timeout=30;")
    Dim ligacao As New MySqlConnection

    Dim adapter As New MySqlDataAdapter
    Dim DS As DataSet = New DataSet
    Dim Comando As New MySqlCommand

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            nomefich = OpenFileDialog1.FileName
            Try
                fich = New FileStream(nomefich, FileMode.Open)
            Catch ex As Exception
                MsgBox("erro na abertura do ficheiro")
                Exit Sub
            End Try
        Else
            MsgBox("não selecionou nenhum ficheiro")
            Exit Sub
        End If
        Dim ler As New StreamReader(fich)

        Dim str As String
        Dim str1 As String = 194

        While (ler.Peek >= 0)
            'Metodo readline serve para ler uma linha de texto do ficheiro
            str = ler.ReadLine()
            Comando.Connection = ligacao
            Comando.CommandText = "insert into cidade (nome, codpais) values ('" + str + "', '" + str1 + "')"
            ligacao.Open()
            Comando.ExecuteNonQuery()
            ligacao.Close()
            ListBox1.Items.Add(str)
        End While
        'metodo close fecha o stream reader
        ler.Close()
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        For a = 0 To 15
            Comando.Connection = ligacao
            Comando.CommandText = "insert into VeiAbast (data, veiculo_km,quantidade,valor,notas,codvei,codforn,coduser) values ('2001-01-01','16','1','1','teste3','1','1','1')"
            ligacao.Open()
            Comando.ExecuteNonQuery()
            ligacao.Close()
        Next
        


    End Sub
End Class
