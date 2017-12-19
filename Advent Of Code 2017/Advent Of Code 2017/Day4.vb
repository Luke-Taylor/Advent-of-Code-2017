Public Class Day4
    Inherits Day

    Public Overrides Function GetInput(Part As String) As String
        Dim reader As String
        Try
            reader = My.Computer.FileSystem.ReadAllText("../../Day4.txt")
            Return reader
        Catch ex As Exception
            Throw New Exception("Error getting Puzzle Input", ex)
        End Try
    End Function

    Public Overrides Function GetInputType(Part As String) As String

    End Function

    Public Overrides Function GetText(Part As String) As String
        If (Part = "a") Then
            Return "A new system policy has been put in place that requires all accounts to use a passphrase instead of simply a password. A passphrase consists of a series of words (lowercase letters) separated by spaces." + vbCrLf _
                + "To ensure security, a valid passphrase must contain no duplicate words." + vbCrLf _
                + "The system's full passphrase list is available as your puzzle input. How many passphrases are valid?"
        End If
    End Function

    Public Overrides Function PartA(PuzzleInput As String) As String

    End Function

    Public Overrides Function PartB(PuzzleInput As String) As String

    End Function
End Class
