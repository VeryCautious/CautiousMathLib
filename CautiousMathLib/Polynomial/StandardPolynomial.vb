Public Class StandardPolynomial
    Inherits Polynomial

    Private Property Coefficents As Double()


    ''' <summary>
    ''' Create a polinomila with the coefficients
    ''' c0 + c1*x + c2*x*x...
    ''' </summary>
    ''' <param name="Coefficents"></param>
    Public Sub New(Coefficents As Double())
        Me.Coefficents = Coefficents
    End Sub

    ''' <summary>
    ''' Gets a cubic polinomial that interpolates two point
    ''' </summary>
    ''' <param name="StartY">p(0)=StartY</param>
    ''' <param name="EndY">p(1)=EndY</param>
    ''' <param name="StartSlope">p'(0)=StartSlope</param>
    ''' <param name="EndSlope">p'(1)=EndSlope</param>
    ''' <returns></returns>
    Public Shared Function GetCubicInterpolatingPolynomial(StartY As Double, EndY As Double, StartSlope As Double, EndSlope As Double) As StandardPolynomial
        Dim d = StartY
        Dim c = StartSlope
        Dim b = 3 * (EndY - StartY) - EndSlope - 2 * StartSlope
        Dim a = (StartSlope + EndSlope) - 2 * (EndY - StartY)

        Return New StandardPolynomial({d, c, b, a})
    End Function

    ''' <summary>
    ''' Gets a cubic polinomial that interpolates two point
    ''' </summary>
    ''' <param name="StartP">p(StartP.X)=StartP.Y</param>
    ''' <param name="EndP">p(EndP.X)=EndP.Y</param>
    ''' <param name="StartSlope">p'(StartP.X)=StartSlope</param>
    ''' <param name="EndSlope">p'(EndP.X)=EndSlope</param>
    ''' <returns></returns>
    Public Shared Function GetCubicInterpolatingPolynomial(StartP As Vec2, EndP As Vec2, StartSlope As Double, EndSlope As Double) As Polynomial
        Return New PolyAffineTransform(GetCubicInterpolatingPolynomial(StartP.Y, EndP.Y, StartSlope, EndSlope), StartP.X, EndP.X)
    End Function

    Public Overrides Function GetDirivitive() As Polynomial
        Dim NewCoefficients(0 To Coefficents.Length - 2) As Double

        For I As Integer = 1 To Coefficents.Length - 1
            NewCoefficients(I - 1) = Coefficents(I) * I
        Next

        Return New StandardPolynomial(NewCoefficients)
    End Function

    Public Overrides ReadOnly Property Degree As Integer
        Get
            For I As Integer = Coefficents.Length - 1 To 0 Step -1
                If Coefficents(I) <> 0 Then
                    Return I
                End If
            Next
            Return 0
        End Get
    End Property

    Public Overrides Function GetValueAt(X As Double) As Double
        Dim v As Double = 0

        For I As Integer = 0 To Coefficents.Length - 1
            v += Coefficents(I) * Math.Pow(X, I)
        Next

        Return v
    End Function

    Public Shared Operator +(Poly1 As StandardPolynomial, Poly2 As StandardPolynomial) As StandardPolynomial
        Dim BiggerPoly = If(Poly1.Degree > Poly2.Degree, Poly1, Poly2)
        Dim SmallerPoly = If(Poly1.Degree <= Poly2.Degree, Poly1, Poly2)

        Dim coeff(0 To BiggerPoly.Degree) As Double

        For I As Integer = 0 To BiggerPoly.Degree
            If I <= SmallerPoly.Degree Then
                coeff(I) = BiggerPoly.Coefficents(I) + SmallerPoly.Coefficents(I)
            Else
                coeff(I) = BiggerPoly.Coefficents(I)
            End If
        Next

        Return New StandardPolynomial(coeff)
    End Operator

    Public Shared Operator *(Scalar As Double, Poly As StandardPolynomial) As StandardPolynomial
        Dim coeff(0 To Poly.Degree) As Double

        For I As Integer = 0 To Poly.Degree
            coeff(I) = Scalar * Poly.Coefficents(I)
        Next

        Return New StandardPolynomial(coeff)
    End Operator

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing OrElse Not Me.GetType().Equals(obj.GetType()) Then
            Return False
        End If

        Dim pol = CType(obj, StandardPolynomial)

        If pol.Degree <> Me.Degree Then
            Return False
        End If

        For i As Integer = 0 To pol.Degree
            If pol.Coefficents(i) <> Me.Coefficents(i) Then
                Return False
            End If
        Next

        Return True
    End Function

End Class
