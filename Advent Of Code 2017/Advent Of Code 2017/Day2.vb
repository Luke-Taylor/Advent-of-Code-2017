Public Class Day2
    Inherits Day


    Public Overrides Function GetInput(Part As String) As String
        Return "104	240	147	246	123	175	372	71	116	230	260	118	202	270	277	292" + vbCrLf _
            + "740	755	135	205	429	822	844	90	828	115	440	805	526	91	519	373" + vbCrLf _
            + "1630	991	1471	1294	52	1566	50	1508	1367	1489	55	547	342	512	323	51" + vbCrLf _
            + "1356	178	1705	119	1609	1409	245	292	1434	694	405	1692	247	193	1482	1407" + vbCrLf _
            + "2235	3321	3647	212	1402	3711	3641	1287	2725	692	1235	3100	123	144	104	101" + vbCrLf _
            + "1306	1224	1238	186	751	734	1204	1275	366	149	1114	166	1118	239	153	943" + vbCrLf _
            + "132	1547	1564	512	2643	2376	2324	2159	1658	107	1604	145	2407	131	2073	1878" + vbCrLf _
            + "1845	91	1662	108	92	1706	1815	1797	1728	1150	1576	83	97	547	1267	261" + vbCrLf _
            + "78	558	419	435	565	107	638	173	93	580	338	52	633	256	377	73" + vbCrLf _
            + "1143	3516	4205	3523	148	401	3996	3588	300	1117	2915	1649	135	134	182	267" + vbCrLf _
            + "156	2760	1816	2442	2985	990	2598	1273	167	821	138	141	2761	2399	1330	1276" + vbCrLf _
            + "3746	3979	2989	161	4554	156	3359	173	3319	192	3707	264	762	2672	4423	2924" + vbCrLf _
            + "3098	4309	4971	5439	131	171	5544	595	154	571	4399	4294	160	6201	4329	5244" + vbCrLf _
            + "728	249	1728	305	2407	239	691	2241	2545	1543	55	2303	1020	753	193	1638" + vbCrLf _
            + "260	352	190	877	118	77	1065	1105	1085	1032	71	87	851	56	1161	667" + vbCrLf _
            + "1763	464	182	1932	1209	640	545	931	1979	197	1774	174	2074	1800	939	161" + vbCrLf
    End Function

    Public Overrides Function GetInputType(Part As String) As String
        Return "multiline"
    End Function

    Public Overrides Function GetText(Part As String) As String
        If (Part = "a") Then
            Return "As you walk through the door, a glowing humanoid shape yells in your direction. 'You there! Your state appears to be idle. Come help us repair the corruption in this spreadsheet - if we take another millisecond, we'll have to display an hourglass cursor'" + vbCrLf _
                + "The spreadsheet consists of rows of apparently-random numbers. To make sure the recovery process is on the right track, they need you to calculate the spreadsheet's checksum. For each row, determine the difference between the largest value and the smallest value; the checksum is the sum of all of these differences." + vbCrLf _
                + "What is the checksum for the spreadsheet in your puzzle input?"
        Else
            Return "'Great work; looks like we're on the right track after all. Here's a star for your effort.' However, the program seems a little worried. Can programs be worried?" + vbCrLf _
                + "'Based on what we're seeing, it looks like all the User wanted is some information about the evenly divisible values in the spreadsheet. Unfortunately, none of us are equipped for that kind of calculation - most of us specialize in bitwise operations.'" + vbCrLf _
                + "It sounds like the goal is to find the only two numbers in each row where one evenly divides the other - that is, where the result of the division operation is a whole number. They would like you to find those numbers on each line, divide them, and add up each line's result." + vbCrLf _
                + "What is the sum of each row's result in your puzzle input?"
        End If
        End Function

    Public Overrides Function PartA(PuzzleInput As String) As String
        Dim lines As List(Of List(Of String))

        Dim total As Integer = 0
        Dim highest As Integer = -1
        Dim lowest As Integer = Integer.MaxValue

        Try
            lines = ParseInput(PuzzleInput)

            For i As Integer = 0 To lines.Count - 1
                highest = lines(i)(0)
                lowest = lines(i)(0)

                For n As Integer = 0 To lines(i).Count - 1
                    If (lines(i)(n) > highest) Then

                        If (highest < lowest) Then
                            lowest = highest
                        End If

                        highest = lines(i)(n)
                    ElseIf (lines(i)(n) < lowest) Then

                        If (lowest > highest) Then
                            highest = lowest
                        End If

                        lowest = lines(i)(n)
                    End If
                Next

                total += (highest - lowest)

            Next

            Return total.ToString()
        Catch ex As Exception
            Throw New Exception("Error getting solution for part A", ex)
        End Try
    End Function

    Public Overrides Function PartB(PuzzleInput As String) As String
        Dim lines As List(Of List(Of String))

        Dim total As Integer = 0
        Dim lineDone As Boolean

        Try
            lines = ParseInput(PuzzleInput)

            For i As Integer = 0 To lines.Count - 1
                lineDone = False

                For n As Integer = 0 To lines(i).Count - 1

                    For x As Integer = n + 1 To lines(i).Count - 1

                        If (lines(i)(n) Mod lines(i)(x) = 0) Then
                            total += lines(i)(n) / lines(i)(x)
                            lineDone = True
                        ElseIf (lines(i)(x) Mod lines(i)(n) = 0) Then
                            total += lines(i)(x) / lines(i)(n)
                            lineDone = True
                        End If

                        If (lineDone) Then
                            Exit For
                        End If
                    Next

                    If (lineDone) Then
                        Exit For
                    End If

                Next

            Next

            Return total.ToString()
        Catch ex As Exception
            Throw New Exception("Error getting solution for part B", ex)
        End Try
    End Function

    Protected Function ParseInput(Input As String) As List(Of List(Of String))
        Dim lines As New List(Of List(Of String))
        Dim currLine As String()
        Dim current As String()
        Dim items As List(Of String)

        Try
            currLine = Input.Split(ControlChars.CrLf.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

            For i As Integer = 0 To currLine.Count - 1
                items = New List(Of String)
                current = currLine(i).Split(New Char() {" ", vbTab}, StringSplitOptions.RemoveEmptyEntries)
                items.AddRange(current)
                lines.Add(items)
            Next

            Return lines
        Catch ex As Exception
            Throw New Exception("Error parsing input", ex)
        End Try
    End Function
End Class
