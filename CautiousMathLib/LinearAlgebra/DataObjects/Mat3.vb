<Serializable>
Public Class Mat3

    Public Property Row1 As Vec3
    Public Property Row2 As Vec3
    Public Property Row3 As Vec3

    ''' <summary>
    ''' Gets a copy of the first column of the matrix
    ''' or
    ''' Sets the first column of the matrix
    ''' </summary>
    ''' <returns>a copy of the first column</returns>
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

    ''' <summary>
    ''' Gets a copy of the second column of the matrix
    ''' or
    ''' Sets the second column of the matrix
    ''' </summary>
    ''' <returns>a copy of the second column</returns>
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

    ''' <summary>
    ''' Gets a copy of the third column of the matrix
    ''' or
    ''' Sets the third column of the matrix
    ''' </summary>
    ''' <returns>a copy of the third column</returns>
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

    Public ReadOnly Property Determinante As Double
        Get
            Return GetValueAt(1, 1) * GetValueAt(2, 2) * GetValueAt(3, 3) +
                GetValueAt(1, 2) * GetValueAt(2, 3) * GetValueAt(3, 1) +
                GetValueAt(1, 3) * GetValueAt(2, 1) * GetValueAt(3, 2) -
                GetValueAt(3, 1) * GetValueAt(2, 2) * GetValueAt(1, 3) -
                GetValueAt(3, 2) * GetValueAt(2, 3) * GetValueAt(1, 1) -
                GetValueAt(3, 3) * GetValueAt(2, 1) * GetValueAt(1, 2)
        End Get
    End Property

    ''' <summary>
    ''' Creats the matrix rowwise
    ''' </summary>
    ''' <param name="row1"></param>
    ''' <param name="row2"></param>
    ''' <param name="row3"></param>
    Public Sub New(row1 As Vec3, row2 As Vec3, row3 As Vec3)
        Me.Row1 = row1
        Me.Row2 = row2
        Me.Row3 = row3
    End Sub

    ''' <summary>
    ''' Creates the identitymatrix
    ''' </summary>
    Sub New()
        Me.Row1 = Vec3.GetE1
        Me.Row2 = Vec3.GetE2
        Me.Row3 = Vec3.GetE3
    End Sub

    ''' <summary>
    ''' Gets the value by row and column
    ''' </summary>
    ''' <param name="Row"></param>
    ''' <param name="Column"></param>
    ''' <returns>The value at this position</returns>
    Public Function GetValueAt(Row As Integer, Column As Integer) As Double
        Dim rowV As Vec3

        Select Case Row
            Case 1
                rowV = Row1
            Case 2
                rowV = Row2
            Case 3
                rowV = Row3
            Case Else
                Throw New ArgumentException("3x3 Matrix does not have this row")
        End Select

        Select Case Column
            Case 1
                Return rowV.X
            Case 2
                Return rowV.Y
            Case 3
                Return rowV.Z
            Case Else
                Throw New ArgumentException("3x3 Matrix does not have this row")
        End Select
    End Function

    ''' <summary>
    ''' Normal vector matrix produkt (mat*vec)
    ''' </summary>
    ''' <param name="mat"></param>
    ''' <param name="vec"></param>
    ''' <returns></returns>
    Public Shared Operator *(mat As Mat3, vec As Vec3) As Vec3
        Return New Vec3(mat.Row1 * vec, mat.Row2 * vec, mat.Row3 * vec)
    End Operator

    ''' <summary>
    ''' Matrix vector prdukt with returnValue = mat * vec' and vec' = (vec,1)
    ''' </summary>
    ''' <param name="mat"></param>
    ''' <param name="vec"></param>
    ''' <returns>(returnValue.x,returnValue.y)</returns>
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

    ''' <summary>
    ''' Component wise addition
    ''' </summary>
    ''' <param name="mat1"></param>
    ''' <param name="mat2"></param>
    ''' <returns></returns>
    Public Shared Operator +(mat1 As Mat3, mat2 As Mat3) As Mat3
        Return New Mat3(mat1.Row1 + mat2.Row1, mat1.Row2 + mat2.Row2, mat1.Row3 + mat2.Row3)
    End Operator

    ''' <summary>
    ''' Component wise multiplication
    ''' </summary>
    ''' <param name="mat"></param>
    ''' <param name="scalar"></param>
    ''' <returns></returns>
    Public Shared Operator *(mat As Mat3, scalar As Double) As Mat3
        Return New Mat3(mat.Row1 * scalar, mat.Row2 * scalar, mat.Row3 * scalar)
    End Operator

    ''' <summary>
    ''' Component wise multiplication
    ''' </summary>
    ''' <param name="mat"></param>
    ''' <param name="scalar"></param>
    ''' <returns></returns>
    Public Shared Operator *(scalar As Double, mat As Mat3) As Mat3
        Return mat * scalar
    End Operator

    ''' <summary>
    ''' Gets the transposed matrix of this matrix
    ''' For an orthogonal matrix this is also the inverse
    ''' </summary>
    ''' <returns></returns>
    Public Function GetTranspose() As Mat3
        Return New Mat3(Me.Column1, Me.Column2, Me.Column3)
    End Function

    ''' <summary>
    ''' Gets a matrix, that translates a vec2 by (dy,dy)
    ''' </summary>
    ''' <param name="dX"></param>
    ''' <param name="dY"></param>
    ''' <returns></returns>
    Public Shared Function GetTranslationMatrix(dX As Double, dY As Double) As Mat3
        Return New Mat3(New Vec3(1, 0, dX), New Vec3(0, 1, dY), Vec3.GetE3)
    End Function

    ''' <summary>
    ''' Gets a matrix that scales a vector by (sZ,sY,sZ).
    ''' This is a matrix with sZ,sY,sZ on the diagonal
    ''' </summary>
    ''' <param name="sX"></param>
    ''' <param name="sY"></param>
    ''' <param name="sZ"></param>
    ''' <returns></returns>
    Public Shared Function GetScalingMatrix(sX As Double, sY As Double, Optional sZ As Double = 1) As Mat3
        Return New Mat3(New Vec3(sX, 0, 0), New Vec3(0, sY, 0), New Vec3(0, 0, sZ))
    End Function

    ''' <summary>
    ''' Gets a matrix that rotates a vec2 by an angle Phi.
    ''' Phi is measured in radiants.
    ''' </summary>
    ''' <param name="Phi">The angle in radiants</param>
    ''' <returns></returns>
    Public Shared Function Get2DRotationMatrix(Phi As Double) As Mat3
        Return New Mat3(New Vec3(Math.Cos(Phi), -Math.Sin(Phi), 0), New Vec3(Math.Sin(Phi), Math.Cos(Phi), 0), New Vec3(0, 0, 1))
    End Function
End Class
