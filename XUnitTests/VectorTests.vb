Imports CautiousMathLib
Imports Xunit

Namespace XUnitTests
    Public Class VectorTests
        <Fact>
        Sub TestVectorAddition()
            Dim v1 As New Vec3()
            Dim v2 As New Vec3(1, 2, 3)
            Dim v3 As New Vec3(4, 1, 3)

            Dim erg1 = v1 + v2 + v3
            Dim erg2 = v1 + v3 + v2
            Dim erg3 = v1 + (v2 + v3)

            Dim shouldBe As New Vec3(5, 3, 6)

            Assert.Equal(shouldBe, erg1)
            Assert.Equal(shouldBe, erg2)
            Assert.Equal(shouldBe, erg3)
        End Sub

        <Fact>
        Sub TestVectorSubtraction()
            Dim v1 As New Vec3()
            Dim v2 As New Vec3(1, 2, 3)
            Dim v3 As New Vec3(4, 1, 3)

            Dim erg1 = v2 - v1
            Dim erg2 = v1 + v3 - v2
            Dim erg3 = v3 - (v2 - v1)

            Assert.Equal(v2, erg1)
            Assert.Equal(New Vec3(3, -1, 0), erg2)
            Assert.Equal(v3 - v2, erg3)
        End Sub

        <Fact>
        Sub TestVectorSkalarProduktAndMult()
            Dim v1 As New Vec3()
            Dim v2 As New Vec3(1, 2, 3)
            Dim v3 As New Vec3(4, 1, 3)

            Assert.Equal(0, v1 * v2)
            Assert.Equal(15, v3 * v2)
            Assert.Equal(15, v2 * v3)
            Assert.Equal(2 * 15, 2 * v3 * v2)
            Assert.Equal(2 * 15, 2 * (v3 * v2))
            Assert.Equal(2 * 15, 2 * (v2 * v3))
        End Sub

    End Class
End Namespace

