Public Class CircularArray
    Public Objects As List(Of Object)

    Public Sub New(items As List(Of Object))
        Objects = items
    End Sub

    Public Sub New()

    End Sub

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

    Public Sub SetValue(index As Integer, value As Object)
        Try
            While (index >= Objects.Count)
                index -= Objects.Count
            End While

            Objects(index) = value
        Catch ex As Exception
            Throw New Exception("Error setting element in circular array", ex)
        End Try
    End Sub

    Public Function Length() As Integer
        Return Objects.Count()
    End Function
End Class
