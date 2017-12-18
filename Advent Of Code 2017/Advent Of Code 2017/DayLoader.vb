Module DayLoader

    Sub Main()
        Dim day As Integer = -1
        Dim part As String = "?"
        Try
            Console.WriteLine("Please enter a day (1-24):")
            While (Not Integer.TryParse(Console.ReadLine(), day) Or day < 0 Or day > 24)
                Console.WriteLine("Invalid day. Please enter a day between 1 and 24:")
            End While

            Console.WriteLine("Please select a part ([A] or [B]):")
            part = Console.ReadLine().ToLower()

            While (Not part = "a" And Not part = "b")
                Console.WriteLine("Invalid part (" + part + "). Please choose either part [A] or part [B]:")
                part = Console.ReadLine().ToLower()
            End While

        Catch ex As Exception
            MsgBox("An error occurred: " + ex.Message)
        End Try
    End Sub

End Module
