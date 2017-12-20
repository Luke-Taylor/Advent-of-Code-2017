Public Class Day5
    Inherits Day

    Public Overrides Function GetInput(Part As String) As String
        Return LoadInputFromFile("Day5.txt")
    End Function

    Public Overrides Function GetInputType(Part As String) As String
        Return "multiline"
    End Function

    Public Overrides Function GetText(Part As String) As String
        If (Part = "a") Then
            Return "An urgent interrupt arrives from the CPU: it's trapped in a maze of jump instructions, and it would like assistance from any programs with spare cycles to help find the exit." + vbCrLf _
                + "The message includes a list of the offsets for each jump. Jumps are relative: -1 moves to the previous instruction, and 2 skips the next one. Start at the first instruction in the list. The goal is to follow the jumps until one leads outside the list." + vbCrLf _
                + "In addition, these instructions are a little strange; after each jump, the offset of that instruction increases by 1. So, if you come across an offset of 3, you would move three instructions forward, but change it to a 4 for the next time it is encountered." + vbCrLf _
                + "Positive jumps ('forward') move downward; negative jumps move upward." + vbCrLf _
                + "How many steps does it take to reach the exit?"
        Else
            Return "Now, the jumps are even stranger: after each jump, if the offset was three or more, instead decrease it by 1. Otherwise, increase it by 1 as before." + vbCrLf _
                + "How many steps does it now take to reach the exit?"
        End If
    End Function

    Public Overrides Function PartA(PuzzleInput As String) As String
        Dim jumps As List(Of Integer)
        Dim done As Boolean = False
        Dim count As Integer = 0
        Dim pos As Integer = 0
        Dim current As Integer

        Try
            jumps = ParseInput(PuzzleInput).Select(Function(x) Integer.Parse(x)).ToList()

            While (pos >= 0 And pos < jumps.Count)
                count += 1
                current = jumps(pos)
                jumps(pos) = current + 1
                pos += current
            End While

            Return count
        Catch ex As Exception
            Throw New Exception("Error calculating solution to part A", ex)
        End Try
    End Function

    Public Overrides Function PartB(PuzzleInput As String) As String
        Dim jumps As List(Of Integer)
        Dim done As Boolean = False
        Dim count As Integer = 0
        Dim pos As Integer = 0
        Dim current As Integer

        Try
            jumps = ParseInput(PuzzleInput).Select(Function(x) Integer.Parse(x)).ToList()

            While (pos >= 0 And pos < jumps.Count)
                count += 1
                current = jumps(pos)

                If (current >= 3) Then
                    jumps(pos) = current - 1
                Else
                    jumps(pos) = current + 1
                End If

                pos += current
            End While

            Return count
        Catch ex As Exception
            Throw New Exception("Error calculating solution to part A", ex)
        End Try
    End Function
End Class
