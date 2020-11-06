Public Class Vec2

    Public Property X As Double
    Public Property Y As Double

    Sub New(x As Double, y As Double)
        Me.X = x
        Me.Y = y
    End Sub

    Sub New(v As Vec2)
        Me.X = v.X
        Me.Y = v.Y
    End Sub

    Public Function ToSysDrawingPoint() As System.Drawing.Point
        Return New System.Drawing.Point(CInt(X), CInt(Y))
    End Function

    Public Function ToSysDrawingSize() As System.Drawing.Size
        Return New System.Drawing.Size(CInt(X), CInt(Y))
    End Function

    Public Shared Operator +(vec1 As Vec2, vec2 As Vec2) As Vec2
        Return New Vec2(vec1.X + vec2.X, vec1.Y + vec2.Y)
    End Operator

    Public Shared Operator *(vec1 As Vec2, vec2 As Vec2) As Double
        Return (vec1.X * vec2.X + vec1.Y * vec2.Y)
    End Operator

    Public Shared Operator *(vec As Vec2, scalar As Double) As Vec2
        Return New Vec2(vec.X * scalar, vec.Y * scalar)
    End Operator

    Public Shared Operator *(scalar As Double, vec As Vec2) As Vec2
        Return vec * scalar
    End Operator

End Class
