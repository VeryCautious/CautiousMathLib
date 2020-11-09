Imports System
Imports CautiousMathLib

Module Program
    Sub Main(args As String())
        Dim ap2 = StandardPolynomial.GetCubicInterpolatingPolynomial(New Vec2(10, 15), New Vec2(40, 45), 1, 2)
        Stop
    End Sub
End Module
