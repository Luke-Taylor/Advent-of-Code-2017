Public Class Day6
    Inherits Day

    Public Overrides Function GetInput(Part As String) As String
        Return "10	3	15	10	5	15	5	15	9	2	5	8	5	2	3	6"
    End Function

    Public Overrides Function GetInputType(Part As String) As String
        Return "single-line"
    End Function

    Public Overrides Function GetText(Part As String) As String
        If (Part = "a") Then
            Return "A debugger program here is having an issue: it is trying to repair a memory reallocation routine, but it keeps getting stuck in an infinite loop." + vbCrLf _
                + "In this area, there are sixteen memory banks; each memory bank can hold any number of blocks. The goal of the reallocation routine is to balance the blocks between the memory banks." + vbCrLf _
                + "The reallocation routine operates in cycles. In each cycle, it finds the memory bank with the most blocks (ties won by the lowest-numbered memory bank) and redistributes those blocks among the banks. To do this, it removes all of the blocks from the selected bank, then moves to the next (by index) memory bank and inserts one of the blocks. It continues doing this until it runs out of blocks; if it reaches the last memory bank, it wraps around to the first one." + vbCrLf _
                + "The debugger would like to know how many redistributions can be done before a blocks-in-banks configuration is produced that has been seen before." + vbCrLf _
                + "Given the initial block counts in your puzzle input, how many redistribution cycles must be completed before a configuration is produced that has been seen before?"
        Else
            Return ""
        End If
    End Function

    Public Overrides Function PartA(PuzzleInput As String) As String
        Dim banks As CircularArray
        Dim previous As New List(Of CircularArray)
        Dim done As Boolean = False
        Dim cycles As Integer = 0
        Dim max As Integer = 0
        Dim currBank As Integer = 0
        Dim leftovers As Integer = 0

        Try
            banks = New CircularArray(ParseInputWithTabsOrSpaces(PuzzleInput)(0).Select(Function(f) Integer.Parse(f)).Select(Function(f) CType(f, Object)).ToList)

            While (Not done)
                max = 0
                currBank = 0

                For i As Integer = 0 To banks.Length() - 1
                    If (banks.At(i) > max) Then
                        max = banks.At(i)
                        currBank = i
                    End If
                Next

                leftovers = max Mod (banks.Length() - 2)
                banks.SetValue(currBank, leftovers)

                max = Math.Floor(max / (banks.Length() - 2))

                For i As Integer = 0 To banks.Length() - 1
                    If (Not i = currBank) Then
                        banks.SetValue(i, banks.At(i) + max)
                    End If
                Next

                If (previous.Contains(banks)) Then
                    done = True
                    Exit While
                End If

                previous.Add(New CircularArray(banks.Objects))
                cycles += 1

            End While

            Return cycles
        Catch ex As Exception
            Throw New Exception("Error calculating solution to part A", ex)
        End Try
    End Function

    Public Overrides Function PartB(PuzzleInput As String) As String

    End Function
End Class
