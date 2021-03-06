﻿<Serializable>
Public Class Vec3
    Public Property X As Double
    Public Property Y As Double
    Public Property Z As Double

    ''' <summary>
    ''' Ceates a new vector with x and y values a defined
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="z"></param>
    Sub New(x As Double, y As Double, z As Double)
        Me.X = x
        Me.Y = y
        Me.Z = z
    End Sub

    ''' <summary>
    ''' Creates a vector by using the values of another vector. (copy)
    ''' </summary>
    ''' <param name="v"></param>
    Sub New(v As Vec3)
        Me.X = v.X
        Me.Y = v.Y
        Me.Z = v.Z
    End Sub

    Sub New(v As Vec2, z As Double)
        Me.X = v.X
        Me.Y = v.Y
        Me.Z = z
    End Sub

    ''' <summary>
    ''' Creates a vector from a Point
    ''' </summary>
    ''' <param name="Point"></param>
    Sub New(Point As System.Drawing.Point, Optional z As Double = 0)
        Me.New(Point.X, Point.Y, z)
    End Sub

    ''' <summary>
    ''' Creates a vector from a Size
    ''' </summary>
    ''' <param name="Size"></param>
    Sub New(Size As System.Drawing.Size, Optional z As Double = 0)
        Me.New(Size.Width, Size.Width, z)
    End Sub

    ''' <summary>
    ''' Creates a new vector with (0,0,0)
    ''' </summary>
    Sub New()
        Me.New(0, 0, 0)
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
        Me.Z /= L
    End Sub

    ''' <summary>
    ''' Returns a new normalized vector of this vector
    ''' </summary>
    ''' <returns>new normalized vector</returns>
    Public Function GetNormalized() As Vec3
        Dim copy As New Vec3(Me)
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
    ''' Converts the vector to a System.Drawing.Color
    ''' </summary>
    ''' <returns></returns>
    Public Function ToColor() As System.Drawing.Color
        Return System.Drawing.Color.FromArgb(CInt(X), CInt(Y), CInt(Z))
    End Function

    ''' <summary>
    ''' Component wise addition
    ''' </summary>
    ''' <param name="vec1"></param>
    ''' <param name="vec2"></param>
    ''' <returns></returns>
    Public Shared Operator +(vec1 As Vec3, vec2 As Vec3) As Vec3
        Return New Vec3(vec1.X + vec2.X, vec1.Y + vec2.Y, vec1.Z + vec2.Z)
    End Operator

    ''' <summary>
    ''' Component wise subtraction
    ''' </summary>
    ''' <param name="vec1"></param>
    ''' <param name="vec2"></param>
    ''' <returns></returns>
    Public Shared Operator -(vec1 As Vec3, vec2 As Vec3) As Vec3
        Return New Vec3(vec1.X - vec2.X, vec1.Y - vec2.Y, vec1.Z - vec2.Z)
    End Operator

    ''' <summary>
    ''' Dotprodukt of two vectors. vec1.X * vec2.X + vec1.Y * vec2.Y
    ''' </summary>
    ''' <param name="vec1"></param>
    ''' <param name="vec2"></param>
    ''' <returns></returns>
    Public Shared Operator *(vec1 As Vec3, vec2 As Vec3) As Double
        Return (vec1.X * vec2.X + vec1.Y * vec2.Y + vec1.Z * vec2.Z)
    End Operator

    ''' <summary>
    ''' Component wise multiplication with scalar
    ''' </summary>
    ''' <param name="vec"></param>
    ''' <param name="scalar"></param>
    ''' <returns></returns>
    Public Shared Operator *(vec As Vec3, scalar As Double) As Vec3
        Return New Vec3(vec.X * scalar, vec.Y * scalar, vec.Z * scalar)
    End Operator

    ''' <summary>
    ''' Component wise multiplication with scalar
    ''' </summary>
    ''' <param name="vec"></param>
    ''' <param name="scalar"></param>
    ''' <returns></returns>
    Public Shared Operator *(scalar As Double, vec As Vec3) As Vec3
        Return vec * scalar
    End Operator

    ''' <summary>
    ''' Gets the reflectionvector of this vector reflected at the normal.
    ''' angle(Me,N) = angle(Result,N)
    ''' This means for Light reflections use -1.0*Me.Reflect(Normal)
    ''' </summary>
    ''' <param name="Normal"></param>
    ''' <returns></returns>
    Public Function Reflect(Normal As Vec3) As Vec3
        Return 2.0 * (Normal * Me) * Normal - Me
    End Function

    ''' <summary>
    ''' Gets a vector with (1,0,0)
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetE1() As Vec3
        Return New Vec3(1, 0, 0)
    End Function

    ''' <summary>
    ''' Gets a vector with (0,1,0)
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetE2() As Vec3
        Return New Vec3(0, 1, 0)
    End Function

    ''' <summary>
    ''' Gets a vector with (0,0,1)
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetE3() As Vec3
        Return New Vec3(0, 0, 1)
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
    Public Function GetPartInDirection(Direction As Vec3) As Vec3
        Return (Direction * Me) * Direction
    End Function

    ''' <summary>
    ''' Gets a vector from one point to another
    ''' </summary>
    ''' <param name="FromVec">Starting point</param>
    ''' <param name="ToVec">End point</param>
    ''' <returns></returns>
    Public Shared Function GetVectorFromTo(FromVec As Vec3, ToVec As Vec3) As Vec3
        Return ToVec - FromVec
    End Function

    ''' <summary>
    ''' Gets the distance from this point to another
    ''' </summary>
    ''' <param name="OtherVector"></param>
    ''' <returns></returns>
    Public Function DistanceTo(OtherVector As Vec3) As Double
        Return (Me - OtherVector).Length
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing OrElse Not Me.GetType().Equals(obj.GetType()) Then
            Return False
        End If

        Dim vec2 = CType(obj, Vec3)
        Return vec2.X = Me.X AndAlso vec2.Y = Me.Y AndAlso vec2.Z = Me.Z
    End Function

End Class
