Public Class Day7
    Inherits Day


    Public Overrides Function GetInput(Part As String) As String
        Return LoadInputFromFile("Day7.txt")
    End Function

    Public Overrides Function GetInputType(Part As String) As String
        Return "multiline"
    End Function

    Public Overrides Function GetText(Part As String) As String
        If (Part = "a") Then
            Return "Wandering further through the circuits of the computer, you come upon a tower of programs that have gotten themselves into a bit of trouble. A recursive algorithm has gotten out of hand, and now they're balanced precariously in a large tower." + vbCrLf _
                + "One program at the bottom supports the entire tower. It's holding a large disc, and on the disc are balanced several more sub-towers. At the bottom of these sub-towers, standing on the bottom disc, are other programs, each holding their own disc, and so on. At the very tops of these sub-sub-sub-...-towers, many programs stand simply keeping the disc below them balanced but with no disc of their own." + vbCrLf _
                + "You offer to help, but first you need to understand the structure of these towers. You ask each program to yell out their name, their weight, and (if they're holding a disc) the names of the programs immediately above them balancing on that disc. You write this information down (your puzzle input). Unfortunately, in their panic, they don't do this in an orderly fashion; by the time you're done, you're not sure which program gave which information."
        Else
            Return "The programs explain the situation: they can't get down. Rather, they could get down, if they weren't expending all of their energy trying to keep the tower balanced. Apparently, one program has the wrong weight, and until it's fixed, they're stuck here." + vbCrLf _
                + "For any program holding a disc, each program standing on that disc forms a sub-tower. Each of those sub-towers are supposed to be the same weight, or the disc itself isn't balanced. The weight of a tower is the sum of the weights of the programs in that tower." + vbCrLf _
                + "Given that exactly one program is the wrong weight, what would its weight need to be to balance the entire tower?"
        End If
    End Function

    Public Overrides Function PartA(PuzzleInput As String) As String
        Dim nodes As List(Of Node)

        Try
            nodes = CreateNodeTree(PuzzleInput)
            Return nodes(0).Name
        Catch ex As Exception
            Throw New Exception("Error solving part A", ex)
        End Try
    End Function

    Public Overrides Function PartB(PuzzleInput As String) As String
        Dim nodes As List(Of Node)
        Dim currNode As Node

        Dim targetWeight As Integer = 0
        Dim weightDiff As Integer = 0

        Try
            nodes = CreateNodeTree(PuzzleInput)
            currNode = nodes(0)

            While (Not currNode.IsBalanced())
                targetWeight = currNode.GetUnbalancedChildTargetWeight(currNode)
            End While

            weightDiff = targetWeight - currNode.GetTotalWeight()

            Return (currNode.Weight + weightDiff)

        Catch ex As Exception
            Throw New Exception("Error solving part B", ex)
        End Try
    End Function

    
    Private Function CreateNodeTree(PuzzleInput As String) As List(Of Node)
        Dim fileData As List(Of String)
        Dim lines As New List(Of List(Of String))
        Dim nodes As New List(Of Node)
        Dim currNode As Node
        Dim tmpNode As Node

        Try
            fileData = ParseInput(PuzzleInput)

            For i As Integer = 0 To fileData.Count - 1
                lines.Add(ParseLine(fileData(i)))

                currNode = New Node()
                currNode.Name = lines(i)(0)
                currNode.Weight = Integer.Parse(lines(i)(1))

                nodes.Add(currNode)
            Next

            'lines = lines.Select(Function(x) x.Where(Function(y) y.Count >= 2).ToList()).ToList()

            For Each line As List(Of String) In lines
                currNode = nodes.Where(Function(x) x.Name = line(0)).First()

                For i As Integer = 2 To line.Count - 1
                    tmpNode = nodes.Where(Function(x) x.Name = line(i)).First()
                    tmpNode.Parent = currNode
                    currNode.Children.Add(tmpNode)
                Next

            Next

            For Each n As Node In nodes.Where(Function(x) Not x.Parent Is Nothing).ToList()
                nodes.Remove(n)
            Next


            currNode = nodes.Where(Function(x) x.Parent Is Nothing).First()

            Return nodes

        Catch ex As Exception
            Throw New Exception("Error creating node tree", ex)
        End Try
    End Function

    Private Function ParseLine(Line As String) As List(Of String)
        Dim data As New List(Of String)
        Dim parts As String()

        Dim name As String
        Dim weight As String
        Dim children As String()
        Try
            Line = Line.Replace(" ", "")

            parts = Line.Split("(")
            name = parts(0)
            data.Add(name)

            parts = parts(1).Split(")")
            weight = parts(0)
            data.Add(weight)

            If Not (String.IsNullOrWhiteSpace(parts(1))) Then
                parts = parts(1).Split(">")
                children = parts(1).Split(",")
                data.AddRange(children)
            End If

            Return data
        Catch ex As Exception
            Throw New Exception("Error parsing line", ex)
        End Try
    End Function
End Class
