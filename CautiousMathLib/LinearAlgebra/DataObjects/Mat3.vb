Public Class Mat3

    Public Property Row1 As Vec3
    Public Property Row2 As Vec3
    Public Property Row3 As Vec3

    Public Property Column1 As Vec3
        Get
            Return New Vec3(Row1.X, Row2.X, Row3.X)
        End Get
        Set(value As Vec3)
            Row1.X = value.X
            Row2.X = value.Y
            Row3.X = value.Z
        End Set
    End Property

    Public Property Column2 As Vec3
        Get
            Return New Vec3(Row1.Y, Row2.Y, Row3.Y)
        End Get
        Set(value As Vec3)
            Row1.Y = value.X
            Row2.Y = value.Y
            Row3.Y = value.Z
        End Set
    End Property

    Public Property Column3 As Vec3
        Get
            Return New Vec3(Row1.Z, Row2.Z, Row3.Z)
        End Get
        Set(value As Vec3)
            Row1.Z = value.X
            Row2.Z = value.Y
            Row3.Z = value.Z
        End Set
    End Property

    Public Sub New(row1 As Vec3, row2 As Vec3, row3 As Vec3)
        Me.Row1 = row1
        Me.Row2 = row2
        Me.Row3 = row3
    End Sub

    Sub New()
        Me.Row1 = Vec3.GetE1
        Me.Row2 = Vec3.GetE2
        Me.Row3 = Vec3.GetE3
    End Sub

    Public Shared Operator *(mat As Mat3, vec As Vec3) As Vec3
        Return New Vec3(mat.Row1 * vec, mat.Row2 * vec, mat.Row3 * vec)
    End Operator

    Public Shared Operator *(mat As Mat3, vec As Vec2) As Vec2
        Dim vec3 As New Vec3(vec, 1)
        Dim zwi = mat * vec3
        Return New Vec2(zwi.X, zwi.Y)
    End Operator

    Public Shared Operator *(mat1 As Mat3, mat2 As Mat3) As Mat3
        Dim M As New Mat3 With {
            .Column1 = mat1 * mat2.Column1,
            .Column2 = mat1 * mat2.Column2,
            .Column3 = mat1 * mat2.Column3
        }
        Return M
    End Operator
End Class
