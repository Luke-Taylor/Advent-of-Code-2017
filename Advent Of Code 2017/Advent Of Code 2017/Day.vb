Public MustInherit Class Day

    Public MustOverride Function PartA(PuzzleInput As String) As String
    Public MustOverride Function PartB(PuzzleInput As String) As String

    Public MustOverride Function GetText(Part As String) As String
    Public MustOverride Function GetInput(Part As String) As String

End Class
