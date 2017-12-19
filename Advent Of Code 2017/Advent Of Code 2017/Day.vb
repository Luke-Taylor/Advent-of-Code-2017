Public MustInherit Class Day

    Public MustOverride Function PartA(PuzzleInput As String) As String
    Public MustOverride Function PartB(PuzzleInput As String) As String

    Public MustOverride Function GetText(Part As String) As String
    Public MustOverride Function GetInputType(Part As String) As String
    Public MustOverride Function GetInput(Part As String) As String

    Protected Overridable Function ParseInput(Input As String) As List(Of String)
        Dim lines As New List(Of String)
        Dim currLine As String()

        Try
            currLine = Input.Split(ControlChars.CrLf.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

            For i As Integer = 0 To currLine.Count - 1
                lines.AddRange(currLine)
            Next

            Return lines
        Catch ex As Exception
            Throw New Exception("Error parsing input", ex)
        End Try
    End Function
End Class
