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

            Dim ap As New PolyAffineTransform(p, 10, 200)

            Assert.Equal(2, ap.GetValueAt(10))
            Assert.Equal(5, ap.GetValueAt(200))

            Dim ap2 = StandardPolynomial.GetCubicInterpolatingPolynomial(New Vec2(10, 15), New Vec2(40, 45), 1, 2)
            Dim dp2 = ap2.GetDirivitive

            Assert.Equal(15, ap2.GetValueAt(10))
            Assert.Equal(45, ap2.GetValueAt(40))

            Assert.Equal(1, dp2.GetValueAt(10))
            Assert.Equal(2, dp2.GetValueAt(40))
        End Sub

        <Fact>
        Sub TestOperators()
            Dim p1 As New StandardPolynomial({1, 2, 3, 4})
            Dim p2 As New StandardPolynomial({2, 5, 7, 3, 8})

            Assert.Equal(New StandardPolynomial({3, 7, 10, 7, 8}), p1 + p2)
            Assert.Equal(New StandardPolynomial({-1, -3, -4, 1, -8}), p1 - p2)
            Assert.Equal(New StandardPolynomial({1, 3, 4, -1, 8}), p2 - p1)
            Assert.Equal(New StandardPolynomial({0}), p2 - p2)
            Assert.Equal(New StandardPolynomial({5, 10, 15, 20}), 5 * p1)
        End Sub

    End Class
End Namespace
