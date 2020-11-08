Imports CautiousMathLib
Imports Xunit

Namespace XUnitTests
    Public Class MatrixTests
        <Fact>
        Sub TestDeterminante()
            Dim M As New Mat3()
            Assert.Equal(1, M.Determinante)
            Assert.Equal(1 * 2 * 2 * 2, (2 * M).Determinante)

            Dim M2 As New Mat3(Vec3.GetE1 * 2, Vec3.GetE2, 3 * Vec3.GetE3)
            Assert.Equal(1 * 2 * 3, M2.Determinante)

            Assert.Equal(0, New Mat3(Vec3.GetE1, Vec3.GetE1, 3 * Vec3.GetE3).Determinante)

            Assert.Equal(1 * 2 * 3 * 2 * 2 * 2, (2 * M * M2).Determinante) ' det(m1*m2) = det(m1) * det(m2)
        End Sub
    End Class
End Namespace
