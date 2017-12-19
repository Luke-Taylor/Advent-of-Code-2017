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
                    previous = current
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
        Dim total As Integer = 0
        Dim current As Integer

        Dim data As New CircularArray
        Dim chars As Char()
        Dim intermediate As List(Of Char)

        Try
            chars = PuzzleInput.ToCharArray()
            intermediate = New List(Of Char)
            intermediate.AddRange(chars)
            data.Objects = intermediate.Select(Function(f) CType(f, Object)).ToList

            For i As Integer = 0 To data.Length
                If (Integer.TryParse(data.At(i).ToString(), current)) Then
                    If (current = Integer.Parse(data.At(i + (data.Length / 2)))) Then
                        total += current
                    End If
                End If
            Next

            Return total.ToString()
        Catch ex As Exception
            Throw New Exception("Error calculating answer to part B", ex)
        End Try
    End Function

    Public Overrides Function GetText(Part As String) As String
        Part = Part.ToLower()

        If (Part = "a") Then
            Return "You're standing in a room with 'digitization quarantine' written in LEDs along one wall. The only door is locked, but it includes a small interface. 'Restricted Area - Strictly No Digitized Users Allowed.'" + vbCrLf _
                + "It goes on to explain that you may only leave by solving a captcha to prove you're not a human. Apparently, you only get one millisecond to solve the captcha: too fast for a normal human, but it feels like hours to you." + vbCrLf _
                + "The captcha requires you to review a sequence of digits (your puzzle input) and find the sum of all digits that match the next digit in the list. The list is circular, so the digit after the last digit is the first digit in the list." + vbCrLf _
                + "What is the solution to your captcha?"
        Else
            Return "You notice a progress bar that jumps to 50% completion. Apparently, the door isn't yet satisfied, but it did emit a star as encouragement. The instructions change:" + vbCrLf _
            + "Now, instead of considering the next digit, it wants you to consider the digit halfway around the circular list. That is, if your list contains 10 items, only include a digit in your sum if the digit 10/2 = 5 steps forward matches it. Fortunately, your list has an even number of elements." + vbCrLf _
            + "What is the solution to your new captcha?"
        End If
    End Function

    Public Overrides Function GetInput(Part As String) As String
        Return "5994521226795838486188872189952551475352929145357284983463678944777228139398117649129843853837124228353689551178129353548331779783742915361343229141538334688254819714813664439268791978215553677772838853328835345484711229767477729948473391228776486456686265114875686536926498634495695692252159373971631543594656954494117149294648876661157534851938933954787612146436571183144494679952452325989212481219139686138139314915852774628718443532415524776642877131763359413822986619312862889689472397776968662148753187767793762654133429349515324333877787925465541588584988827136676376128887819161672467142579261995482731878979284573246533688835226352691122169847832943513758924194232345988726741789247379184319782387757613138742817826316376233443521857881678228694863681971445442663251423184177628977899963919997529468354953548612966699526718649132789922584524556697715133163376463256225181833257692821331665532681288216949451276844419154245423434141834913951854551253339785533395949815115622811565999252555234944554473912359674379862182425695187593452363724591541992766651311175217218144998691121856882973825162368564156726989939993412963536831593196997676992942673571336164535927371229823236937293782396318237879715612956317715187757397815346635454412183198642637577528632393813964514681344162814122588795865169788121655353319233798811796765852443424783552419541481132132344487835757888468196543736833342945718867855493422435511348343711311624399744482832385998592864795271972577548584967433917322296752992127719964453376414665576196829945664941856493768794911984537445227285657716317974649417586528395488789946689914972732288276665356179889783557481819454699354317555417691494844812852232551189751386484638428296871436139489616192954267794441256929783839652519285835238736142997245189363849356454645663151314124885661919451447628964996797247781196891787171648169427894282768776275689124191811751135567692313571663637214298625367655969575699851121381872872875774999172839521617845847358966264291175387374464425566514426499166813392768677233356646752273398541814142523651415521363267414564886379863699323887278761615927993953372779567675"
    End Function

    Public Overrides Function GetInputType(Part As String) As String
        Return "single-line"
    End Function
End Class
