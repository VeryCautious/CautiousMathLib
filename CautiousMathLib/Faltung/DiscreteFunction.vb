Public Class DiscreteFunction

    Private ReadOnly Values As New Dictionary(Of Single, Single)

    Public Sub New(DataPoints As IEnumerable(Of (x As Single, y As Single)), Normalize As Boolean, MaxDataPoints As Integer)

        Dim Points = ReduceDataPoints(DataPoints, MaxDataPoints)

        If Normalize Then
            Dim Sum = Points.Sum(Function(P) P.y)
            For Each Point In Points
                Values.Add(Point.x, Point.y / Sum)
            Next
        Else
            For Each Point In Points
                Values.Add(Point.x, Point.y)
            Next
        End If
    End Sub

    Public Function At(x As Single) As Single
        Return If(Values.ContainsKey(x), Values(x), 0)
    End Function

    Public Function CalculateFold(F As DiscreteFunction, Normalize As Boolean, MaxDataPoints As Integer) As DiscreteFunction
        Dim Dict As New Dictionary(Of Single, Single)

        For Each v1 In Me.GetDefinitionSpace
            For Each v2 In F.GetDefinitionSpace
                If Dict.ContainsKey(v1 + v2) Then
                    Dict(v1 + v2) += Me.At(v1) * F.At(v2)
                Else
                    Dict.Add(v1 + v2, Me.At(v1) * F.At(v2))
                End If
            Next
        Next

        Return New DiscreteFunction(Dict.Select(Function(i) (i.Key, i.Value)), Normalize, MaxDataPoints)
    End Function

    Public Function GetDefinitionSpace() As IReadOnlyCollection(Of Single)
        Return Values.Keys
    End Function


    Private Shared Function ReduceDataPoints(Points As IEnumerable(Of (x As Single, y As Single)), ammount As Integer) As IEnumerable(Of (x As Single, y As Single))
        Dim Delta As New List(Of (x As Single, y As Single))

        Dim first = True
        Dim last As (x As Single, y As Single)
        For Each P In Points
            If Not first Then
                Delta.Add(((P.x + last.x) / 2, Math.Abs(P.x - last.x)))
            Else
                first = False
            End If

            last = P
        Next

        If Delta.Count < ammount Then
            Return Points.ToArray
        End If


        Delta.Sort(New Comparison(Of (x As Single, y As Single))(Function(p1, p2) -p1.y.CompareTo(p2.y)))
        Delta = Delta.Take(ammount - 1).ToList
        Delta.Sort(New Comparison(Of (x As Single, y As Single))(Function(p1, p2) p1.x.CompareTo(p2.x)))

        Dim DP = Points.ToList()
        DP.Sort(New Comparison(Of (x As Single, y As Single))(Function(p1, p2) p1.x.CompareTo(p2.x)))

        Dim PointIter = DP.GetEnumerator
        PointIter.MoveNext()

        Dim RetPoints As New List(Of (x As Single, y As Single))
        For Each D In Delta

            Dim Sum As (x As Single, y As Single) = (PointIter.Current.x, PointIter.Current.y)
            Dim count As Single = 1

            While PointIter.MoveNext() AndAlso PointIter.Current.x < D.x
                Sum.x += PointIter.Current.x
                Sum.y += PointIter.Current.y
                count += 1
            End While
            If count = 0 Then Throw New Exception()
            RetPoints.Add((Sum.x / count, Sum.y))
        Next

        Dim Pout = PointIter.Current
        Dim Sumout As (x As Single, y As Single) = (Pout.x, Pout.y)
        Dim countout As Single = 1

        While PointIter.MoveNext()
            Pout = PointIter.Current
            Sumout.x += Pout.x
            Sumout.y += Pout.y
            countout += 1
        End While

        RetPoints.Add((Sumout.x / countout, Sumout.y))

        Return RetPoints
    End Function



End Class
