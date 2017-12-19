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
        End If
    End Function

    Public Overrides Function PartA(PuzzleInput As String) As String

    End Function

    Public Overrides Function PartB(PuzzleInput As String) As String

    End Function
End Class
