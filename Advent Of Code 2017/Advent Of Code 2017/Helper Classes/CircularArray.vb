Public Class CircularArray
    Public Objects As List(Of Object)

    Public Function At(index As Integer) As Object
        Try
            While (index >= Objects.Count)
                index -= Objects.Count
            End While

            Return Objects(index)
        Catch ex As Exception
            Throw New Exception("Error getting element from circular array", ex)
        End Try
    End Function

    Public Function Length() As Integer
        Return Objects.Count
    End Function
End Class
