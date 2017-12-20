Public MustInherit Class Day

    Public MustOverride Function PartA(PuzzleInput As String) As String
    Public MustOverride Function PartB(PuzzleInput As String) As String

    Public MustOverride Function GetText(Part As String) As String
    Public MustOverride Function GetInputType(Part As String) As String
    Public MustOverride Function GetInput(Part As String) As String

    Protected Function ParseInput(Input As String) As List(Of String)
        Dim lines As New List(Of String)
        Dim currLine As String()

        Try
            currLine = Input.Split(ControlChars.CrLf.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

            For i As Integer = 0 To currLine.Count - 1
                lines.Add(currLine(i))
            Next

            Return lines
        Catch ex As Exception
            Throw New Exception("Error parsing input", ex)
        End Try
    End Function

    Protected Function ParseInputWithTabsOrSpaces(Input As String) As List(Of List(Of String))
        Dim lines As New List(Of List(Of String))
        Dim currLine As String()
        Dim current As String()
        Dim items As List(Of String)

        Try
            currLine = Input.Split(ControlChars.CrLf.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

            For i As Integer = 0 To currLine.Count - 1
                items = New List(Of String)
                current = currLine(i).Split(New Char() {" ", vbTab}, StringSplitOptions.RemoveEmptyEntries)
                items.AddRange(current)
                lines.Add(items)
            Next

            Return lines
        Catch ex As Exception
            Throw New Exception("Error parsing input", ex)
        End Try
    End Function

    Protected Function LoadInputFromFile(File As String) As String
        Dim reader As String
        Try
            reader = My.Computer.FileSystem.ReadAllText("../../Inputs/" + File)
            Return reader
        Catch ex As Exception
            Throw New Exception("Error getting Puzzle Input", ex)
        End Try
    End Function
End Class
