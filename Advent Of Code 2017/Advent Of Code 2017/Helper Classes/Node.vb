Public Class Node

    Public Parent As Node
    Public Children As List(Of Node)
    Public Name As String
    Public Weight As Integer
    Public TowerWeight As Integer

    Public Checked As Boolean

    Public Sub New()
        Children = New List(Of Node)
        Checked = False
    End Sub

    Public Function GetTotalWeight() As Integer
        Dim total As Integer

        Try
            total = Children.Sum(Function(x) x.GetTotalWeight())
            Return total + Weight
        Catch ex As Exception
            Throw New Exception("Error adding child disks", ex)
        End Try
    End Function

    Public Function GetUnbalancedChildTargetWeight(ByRef Node As Node)
        Dim groups As List(Of Linq.IGrouping(Of Integer, Node))
        Dim targetWeight As Integer
        Dim unbalancedChild As Node

        Try
            groups = Children.GroupBy(Function(x) x.GetTotalWeight()).ToList()
            targetWeight = groups(0).Key
            unbalancedChild = groups(1)(0)

            Node = unbalancedChild
            Return targetWeight
        Catch ex As Exception
            Throw New Exception("Error getting unbalanced child", ex)
        End Try
    End Function

    Public Function IsBalanced() As Boolean
        Dim groups = Children.GroupBy(Function(x) x.GetTotalWeight())
        Return (groups.Count() = 1)
    End Function

End Class
