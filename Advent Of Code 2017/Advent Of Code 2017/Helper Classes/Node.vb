Public Class Node

    Public Parent As Node
    Public Children As List(Of Node)
    Public Name As String
    Public Weight As Integer

    Public Sub New()
        Children = New List(Of Node)
    End Sub

End Class
