Imports System
Imports CautiousMathLib

Module Program
    Sub Main(args As String())
        Dim p = StandardPolynomial.GetCubicInterpolatingPolynomial(2, 5, 0, 0)
        Dim dp = p.GetDirivitive
        Stop
    End Sub
End Module
