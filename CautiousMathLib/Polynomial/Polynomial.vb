﻿Public MustInherit Class Polynomial

    Public MustOverride Function GetValueAt(X As Double) As Double
    Public MustOverride ReadOnly Property Degree As Integer
    Public MustOverride Function GetDirivitive() As Polynomial
End Class
