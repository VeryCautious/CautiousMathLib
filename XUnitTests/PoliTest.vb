Imports CautiousMathLib
Imports Xunit

Namespace XUnitTests
    Public Class PoliTest
        <Fact>
        Sub TestPoliInterpol()

            Dim p = StandardPolynomial.GetCubicInterpolatingPolynomial(2, 5, 0, 0)
            Dim dp = p.GetDirivitive

            Assert.Equal(2, p.GetValueAt(0))
            Assert.Equal(5, p.GetValueAt(1))

            Assert.Equal(0, dp.GetValueAt(0))
            Assert.Equal(0, dp.GetValueAt(1))
        End Sub

        <Fact>
        Sub TestOperators()
            Dim p1 As New StandardPolynomial({1, 2, 3, 4})
            Dim p2 As New StandardPolynomial({2, 5, 7, 3})

            Assert.Equal(New StandardPolynomial({3, 7, 10, 7}), p1 + p2)
            Assert.Equal(New StandardPolynomial({5, 10, 15, 20}), 5 * p1)
        End Sub

    End Class
End Namespace
