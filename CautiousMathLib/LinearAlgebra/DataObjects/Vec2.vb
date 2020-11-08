<Serializable>
Public Class Vec2

    Public Property X As Double
    Public Property Y As Double

    ''' <summary>
    ''' Ceates a new vector with x and y values a defined
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    Sub New(x As Double, y As Double)
        Me.X = x
        Me.Y = y
    End Sub

    ''' <summary>
    ''' Creates a vector by using the values of another vector. (copy)
    ''' </summary>
    ''' <param name="v"></param>
    Sub New(v As Vec2)
        Me.X = v.X
        Me.Y = v.Y
    End Sub

    ''' <summary>
    ''' Creates a vector from a Point
    ''' </summary>
    ''' <param name="Point"></param>
    Sub New(Point As System.Drawing.Point)
        Me.New(Point.X, Point.Y)
    End Sub

    ''' <summary>
    ''' Creates a vector from a Size
    ''' </summary>
    ''' <param name="Size"></param>
    Sub New(Size As System.Drawing.Size)
        Me.New(Size.Width, Size.Width)
    End Sub

    ''' <summary>
    ''' Creates a new vector with (0,0)
    ''' </summary>
    Sub New()
        Me.New(0, 0)
    End Sub

    ''' <summary>
    ''' Gets the Length of this vector. (Math.Sqrt(Me.LengthSquare))
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Length As Double
        Get
            Return Math.Sqrt(Me.LengthSquare)
        End Get
    End Property

    ''' <summary>
    ''' Gets the lenght squared (Me * Me)
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property LengthSquare As Double
        Get
            Return Me * Me
        End Get
    End Property

    ''' <summary>
    ''' Normalizes this vector
    ''' </summary>
    Public Sub Normalize()
        Dim L = Me.Length
        Me.X /= L
        Me.Y /= L
    End Sub

    ''' <summary>
    ''' Returns a new normalized vector of this vector
    ''' </summary>
    ''' <returns>new normalized vector</returns>
    Public Function GetNormalized() As Vec2
        Dim copy As New Vec2(Me)
        copy.Normalize()
        Return copy
    End Function

    ''' <summary>
    ''' Converts the Vector to a System.Drawing.Point
    ''' </summary>
    ''' <returns></returns>
    Public Function ToSysDrawingPoint() As System.Drawing.Point
        Return New System.Drawing.Point(CInt(X), CInt(Y))
    End Function

    ''' <summary>
    ''' Converts the vector to a System.Drawing.Size
    ''' </summary>
    ''' <returns></returns>
    Public Function ToSysDrawingSize() As System.Drawing.Size
        Return New System.Drawing.Size(CInt(X), CInt(Y))
    End Function

    ''' <summary>
    ''' Component wise addition
    ''' </summary>
    ''' <param name="vec1"></param>
    ''' <param name="vec2"></param>
    ''' <returns></returns>
    Public Shared Operator +(vec1 As Vec2, vec2 As Vec2) As Vec2
        Return New Vec2(vec1.X + vec2.X, vec1.Y + vec2.Y)
    End Operator

    ''' <summary>
    ''' Component wise subtraction
    ''' </summary>
    ''' <param name="vec1"></param>
    ''' <param name="vec2"></param>
    ''' <returns></returns>
    Public Shared Operator -(vec1 As Vec2, vec2 As Vec2) As Vec2
        Return New Vec2(vec1.X - vec2.X, vec1.Y - vec2.Y)
    End Operator

    ''' <summary>
    ''' Dotprodukt of two vectors. vec1.X * vec2.X + vec1.Y * vec2.Y
    ''' </summary>
    ''' <param name="vec1"></param>
    ''' <param name="vec2"></param>
    ''' <returns></returns>
    Public Shared Operator *(vec1 As Vec2, vec2 As Vec2) As Double
        Return (vec1.X * vec2.X + vec1.Y * vec2.Y)
    End Operator

    ''' <summary>
    ''' Component wise multiplication with scalar
    ''' </summary>
    ''' <param name="vec"></param>
    ''' <param name="scalar"></param>
    ''' <returns></returns>
    Public Shared Operator *(vec As Vec2, scalar As Double) As Vec2
        Return New Vec2(vec.X * scalar, vec.Y * scalar)
    End Operator

    ''' <summary>
    ''' Component wise multiplication with scalar
    ''' </summary>
    ''' <param name="vec"></param>
    ''' <param name="scalar"></param>
    ''' <returns></returns>
    Public Shared Operator *(scalar As Double, vec As Vec2) As Vec2
        Return vec * scalar
    End Operator

    ''' <summary>
    ''' Gets the reflectionvector of this vector reflected at the normal.
    ''' angle(Me,N) = angle(Result,N)
    ''' This means for Light reflections use -1.0*Me.Reflect(Normal)
    ''' </summary>
    ''' <param name="Normal"></param>
    ''' <returns></returns>
    Public Function Reflect(Normal As Vec2) As Vec2
        Return 2.0 * (Normal * Me) * Normal - Me
    End Function

    ''' <summary>
    ''' Gets a vector with (1,0)
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetE1() As Vec2
        Return New Vec2(1, 0)
    End Function

    ''' <summary>
    ''' Gets a vector with (0,1)
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetE2() As Vec2
        Return New Vec2(0, 1)
    End Function

    ''' <summary>
    ''' Gets a vector orthogonal to this one
    ''' </summary>
    ''' <returns>(Y , -X)</returns>
    Public Function GetOrthogonalVector() As Vec2
        Return New Vec2(Y, -X)
    End Function

    ''' <summary>
    ''' Gets the portion of the vector that points in a direction
    ''' </summary>
    ''' <param name="Direction">A normalized vector that represents a direction</param>
    ''' <returns>(Direction * Me) * Direction</returns>
    Public Function GetPartInDirection(Direction As Vec2) As Vec2
        Return (Direction * Me) * Direction
    End Function

    ''' <summary>
    ''' Gets a vector from one point to another
    ''' </summary>
    ''' <param name="FromVec">Starting point</param>
    ''' <param name="ToVec">End point</param>
    ''' <returns></returns>
    Public Shared Function GetVectorFromTo(FromVec As Vec2, ToVec As Vec2) As Vec2
        Return ToVec - FromVec
    End Function

    ''' <summary>
    ''' Gets the distance from this point to another
    ''' </summary>
    ''' <param name="OtherVector"></param>
    ''' <returns></returns>
    Public Function DistanceTo(OtherVector As Vec2) As Double
        Return (Me - OtherVector).Length
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing OrElse Not Me.GetType().Equals(obj.GetType()) Then
            Return False
        End If

        Dim vec2 = CType(obj, Vec2)
        Return vec2.X = Me.X AndAlso vec2.Y = Me.Y
    End Function

End Class
