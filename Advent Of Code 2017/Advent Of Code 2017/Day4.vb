Public Class Day4
    Inherits Day

    Public Overrides Function GetInput(Part As String) As String
        Return LoadInputFromFile("Day4.txt")
    End Function

    Public Overrides Function GetInputType(Part As String) As String
        Return "multiline"
    End Function

    Public Overrides Function GetText(Part As String) As String
        If (Part = "a") Then
            Return "A new system policy has been put in place that requires all accounts to use a passphrase instead of simply a password. A passphrase consists of a series of words (lowercase letters) separated by spaces." + vbCrLf _
                + "To ensure security, a valid passphrase must contain no duplicate words." + vbCrLf _
                + "The system's full passphrase list is available as your puzzle input. How many passphrases are valid?"
        Else
            Return "For added security, yet another system policy has been put in place. Now, a valid passphrase must contain no two words that are anagrams of each other - that is, a passphrase is invalid if any word's letters can be rearranged to form any other word in the passphrase." + vbCrLf _
                + "Under this new system policy, how many passphrases are valid?"
        End If
    End Function

    Public Overrides Function PartA(PuzzleInput As String) As String
        Dim valid As New List(Of List(Of String))
        Dim phrases As List(Of List(Of String))
        Dim failed As Boolean

        Try
            phrases = ParseInputWithTabsOrSpaces(PuzzleInput)

            For Each line As List(Of String) In phrases
                failed = False

                For i As Integer = 0 To line.Count - 1
                    For x As Integer = i + 1 To line.Count - 1
                        If (line(i) = line(x)) Then
                            failed = True
                            Exit For
                        End If
                    Next

                    If (failed) Then
                        Exit For
                    End If

                Next

                If (Not failed) Then
                    valid.Add(line)
                End If
            Next

            Return valid.Count()
        Catch ex As Exception
            Throw New Exception("Error getting solution for Part A", ex)
        End Try
    End Function

    Public Overrides Function PartB(PuzzleInput As String) As String
        Dim valid As New List(Of List(Of String))
        Dim phrases As List(Of List(Of String))
        Dim failed As Boolean

        Dim word1 As Char()
        Dim word2 As Char()

        Try
            phrases = ParseInputWithTabsOrSpaces(PuzzleInput)

            For Each line As List(Of String) In phrases
                failed = False

                For i As Integer = 0 To line.Count - 1
                    For x As Integer = i + 1 To line.Count - 1
                        If (line(i) = line(x)) Then
                            failed = True
                            Exit For
                        ElseIf (Len(line(i)) = Len(line(x))) Then
                            word1 = line(i).ToCharArray()
                            word2 = line(x).ToCharArray()

                            System.Array.Sort(word1)
                            System.Array.Sort(word2)

                            If (word1 = word2) Then
                                failed = True
                                Exit For
                            End If
                        End If
                    Next

                    If (failed) Then
                        Exit For
                    End If

                Next

                If (Not failed) Then
                    valid.Add(line)
                End If
            Next

            Return valid.Count()
        Catch ex As Exception
            Throw New Exception("Error getting solution for Part B", ex)
        End Try
    End Function
End Class
