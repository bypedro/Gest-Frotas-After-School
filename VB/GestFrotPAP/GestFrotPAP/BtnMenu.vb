Imports System.Windows.Forms
<System.ComponentModel.DefaultEventAttribute("Click")> _
Public Class BtnMenu
    <System.ComponentModel.Category("BtnMenu")> _
    Public Property zEstadoBotao As Boolean = False



    Public Sub resetbtn()
        If zEstadoBotao = True Then
            Me.BackgroundImage = My.Resources.Menu1
            zEstadoBotao = False
        ElseIf zEstadoBotao = False Then
            Me.BackgroundImage = My.Resources.Menu
            zEstadoBotao = True
        End If
    End Sub


    Private Sub BtnMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub


End Class
