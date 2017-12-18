Public Class Day1
    Inherits Day


    Public Overrides Function PartA(PuzzleInput As String) As String
        Dim total As Integer = 0
        Dim current As Integer
        Dim previous As Integer = -1

        Dim chars As Char()
        Try
            chars = PuzzleInput.ToCharArray()

            For i As Integer = 0 To chars.Length - 1
                If (Integer.TryParse(chars(i).ToString(), current)) Then
                    If current = previous Then
                        total += current
                    End If
                End If
            Next

            If (chars(chars.Length - 1) = chars(0)) Then
                total += Integer.Parse(chars(0))
            End If

            Return total.ToString()
        Catch ex As Exception
            Throw New Exception("Error calculating answer to part A", ex)
        End Try
    End Function

    Public Overrides Function PartB(PuzzleInput As String) As String
        Return ""
    End Function
End Class
