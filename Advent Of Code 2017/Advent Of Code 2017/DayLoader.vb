Imports System.Windows.Forms

Module DayLoader

    Sub Main()
        Dim dayNo As Integer = -1
        Dim part As String = "?"
        Dim input As String
        Dim _input As String = "."
        Dim useInput As String = "?"
        Dim inputType As String = ""

        Dim day As Day
        Dim key As System.ConsoleKeyInfo
        Dim solution As String

        Try
            Console.WriteLine("The night before Christmas, one of Santa's Elves calls you in a panic. 'The printer's broken! We can't print the Naughty or Nice List!' By the time you make it to sub-basement 17, there are only a few minutes until midnight. 'We have a big problem,' she says; 'there must be almost fifty bugs in this system, but nothing else can print The List. Stand in this square, quick! There's no time to explain; if you can convince them to pay you in stars, you'll be able to--' She pulls a lever and the world goes blurry." + vbCrLf _
                              + "When your eyes can focus again, everything seems a lot more pixelated than before. She must have sent you inside the computer! You check the system clock: 25 milliseconds until midnight. With that much time, you should be able to collect all fifty stars by December 25th.)" + vbCrLf)

            While (True)
                Console.WriteLine("Please enter a day (1-24):")
                While (Not Integer.TryParse(Console.ReadLine(), dayNo) Or dayNo < 0 Or dayNo > 24)
                    Console.WriteLine("Invalid day. Please enter a day between 1 and 24:")
                End While

                Console.WriteLine("Please select a part ([A] or [B]):")
                part = Console.ReadLine().ToLower()

                While (Not part = "a" And Not part = "b")
                    Console.WriteLine("Invalid part (" + part + "). Please choose either part [A] or part [B]:")
                    part = Console.ReadLine().ToLower()
                End While

                'TODO: reflection
                day = New Day5()
                Console.WriteLine()
                Console.WriteLine(day.GetText(part))
                Console.WriteLine()

                Console.WriteLine("Use preset Puzzle Input? [Y]/[N]:")
                useInput = Console.ReadLine().ToLower()

                While (Not useInput = "y" And Not useInput = "n")
                    Console.WriteLine("Invalid input. Do you wish to use the preset Puzzle Input? [Y]/[N]:")
                    useInput = Console.ReadLine().ToLower()
                End While

                input = ""

                If (String.IsNullOrWhiteSpace(day.GetInput(part)) Or useInput = "n") Then
                    Console.WriteLine("Please enter the Puzzle Input:")
                    key = Console.ReadKey(True)

                    If (key.Key = ConsoleKey.V AndAlso (key.Modifiers And ConsoleModifiers.Control) = ConsoleModifiers.Control) Then
                        If Clipboard.ContainsText Then
                            input = Clipboard.GetText
                        Else
                            Console.Write(key.KeyChar)
                        End If
                    Else
                        Console.Write(key.KeyChar)
                    End If

                    If (IsNothing(input) Or input = "v" Or input = "") Then
                        inputType = day.GetInputType(part)

                        If (inputType = "single-line") Then
                            input = Console.ReadLine()
                        ElseIf (inputType = "multiline") Then
                            While (Not String.IsNullOrWhiteSpace(_input))
                                Console.WriteLine("Please enter the next line of puzzle input:")
                                _input = Console.ReadLine()
                                input += _input + vbCrLf
                            End While
                        End If
                    End If
                Else
                    input = day.GetInput(part)
                    'Console.WriteLine("Puzzle Input is " + input)
                End If

                If (part = "a") Then
                    solution = day.PartA(input)
                Else
                    solution = day.PartB(input)
                End If

                Console.WriteLine()
                Console.WriteLine("Puzzle solution is " + solution)
                Console.WriteLine()
            End While


        Catch ex As Exception
            MsgBox("An error occurred: " + ex.Message)
        End Try
    End Sub

End Module
