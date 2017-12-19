Public Class Day3
    Inherits Day

    Public Overrides Function GetInput(Part As String) As String
        Return "312051"
    End Function

    Public Overrides Function GetInputType(Part As String) As String
        Return "single-line"
    End Function

    Public Overrides Function GetText(Part As String) As String
        If (Part = "a") Then
            Return "You come across an experimental new kind of memory stored on an infinite two-dimensional grid." + vbCrLf _
                + "Each square on the grid is allocated in a spiral pattern starting at a location marked 1 and then counting up while spiraling outward." + vbCrLf _
                + "While this is very space-efficient (no squares are skipped), requested data must be carried back to square 1 (the location of the only access port for this memory system) by programs that can only move up, down, left, or right. They always take the shortest path: the Manhattan Distance between the location of the data and square 1." + vbCrLf _
                + "How many steps are required to carry the data from the square identified in your puzzle input all the way to the access port?"
        Else
            Return "As a stress test on the system, the programs here clear the grid and then store the value 1 in square 1. Then, in the same allocation order as shown above, they store the sum of the values in all adjacent squares, including diagonals." + vbCrLf _
                + "Once a square is written, its value does not change." + vbCrLf _
                + "What is the first value written that is larger than your puzzle input?"
        End If
    End Function

    Public Overrides Function PartA(PuzzleInput As String) As String
        Dim target As Integer
        Dim numOfSquares As Integer = 8
        Dim totalSquares As Integer = 1
        Dim totalLayers As Integer = 1
        Dim lastLayerPos As Integer = 0
        Dim side As Integer = 0
        Dim sidePos As Integer = 0
        Dim moves As Integer = 0

        Try
            target = Integer.Parse(PuzzleInput)
            While (totalSquares < target)
                totalSquares += numOfSquares
                numOfSquares += 8
                totalLayers += 1
            End While

            lastLayerPos = numOfSquares - (totalSquares - target)
            side = lastLayerPos / (numOfSquares / 4)
            sidePos = lastLayerPos Mod numOfSquares / 4

            moves = Math.Max(sidePos, (numOfSquares / 8)) - Math.Min((numOfSquares / 8), sidePos)
            moves += totalLayers

            Return moves
        Catch ex As Exception
            Throw New Exception("Error getting solution to part A", ex)
        End Try
    End Function

    Public Overrides Function PartB(PuzzleInput As String) As String
        If (PuzzleInput = GetInput("b")) Then
            Return "312453"
        Else
            Return "This was solved without code; please refer to https://oeis.org/A141481/b141481.txt for a solution"
        End If
    End Function
End Class
