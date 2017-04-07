

Public Class Form1
    Private Declare Function LockWindowUpdate Lib "user32" (ByVal hwndLock As IntPtr) As Int32
    Private Declare Function ShowScrollBar Lib "user32" (ByVal hwnd As IntPtr, ByVal wBar As Int32, ByVal bShow As Int32) As Int32

    Private Const SB_VERT = 1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ListBox1.DrawMode = DrawMode.OwnerDrawFixed
        Me.ListBox2.DrawMode = DrawMode.OwnerDrawFixed
        Me.ListBox3.DrawMode = DrawMode.OwnerDrawFixed
        Me.ListBox1.Tag = Me.ListBox2
        Me.ListBox2.Tag = Me.ListBox1
        Me.ListBox3.Tag = Me.ListBox1
        AddHandler Me.ListBox1.DrawItem, AddressOf ListBox_DrawItem
        AddHandler Me.ListBox2.DrawItem, AddressOf ListBox_DrawItem
        AddHandler Me.ListBox3.DrawItem, AddressOf ListBox_DrawItem
    End Sub

    Private Sub ListBox_DrawItem(sender As Object, e As DrawItemEventArgs)
        Dim parentListBox As ListBox = DirectCast(sender, ListBox)
        Dim childListBox As ListBox = DirectCast(parentListBox.Tag, ListBox)
        e.DrawBackground()
        e.DrawFocusRectangle()
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            e.Graphics.FillRectangle(Brushes.Gray, e.Bounds)
        End If
        Dim brsh As New SolidBrush(Color.Black)

        If String.Compare(e.State.ToString, DrawItemState.Selected.ToString) > 0 Then brsh.Color = Color.White

        e.Graphics.DrawString(CStr(parentListBox.Items(e.Index)), e.Font, brsh, New RectangleF(e.Bounds.Location, e.Bounds.Size))

        childListBox.TopIndex = parentListBox.TopIndex

        ShowScrollBar(ListBox1.Handle, SB_VERT, False)
        ShowScrollBar(ListBox2.Handle, SB_VERT, False)
        LockWindowUpdate(IntPtr.Zero)
    End Sub

   
End Class