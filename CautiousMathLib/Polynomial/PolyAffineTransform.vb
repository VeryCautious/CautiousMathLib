Public Class PolyAffineTransform
    Inherits Polynomial

    Private Property Parent As Polynomial
    Private ReadOnly StartX As Double, EndX As Double

    ''' <summary>
    ''' Creates a polynomial from a parent, that maps the [0,1] interval from the parent to [startX,endX] in a linear transform.
    ''' </summary>
    ''' <param name="Parent">The original polynomial</param>
    ''' <param name="StartX">Me.GetValueAt(StartX) = Parent.GetValueAt(0)</param>
    ''' <param name="EndX">Me.GetValueAt(EndX) = Parent.GetValueAt(1)</param>
    Public Sub New(Parent As Polynomial, StartX As Double, EndX As Double)
        Me.Parent = Parent
        Me.StartX = StartX
        Me.EndX = EndX
    End Sub

    Public Overrides ReadOnly Property Degree As Integer
        Get
            Return Me.Parent.Degree
        End Get
    End Property

    Public Overrides Function GetValueAt(X As Double) As Double
        Return Parent.GetValueAt((X - StartX) / (EndX - StartX))
    End Function

    Public Overrides Function GetDirivitive() As Polynomial
        Return New PolyAffineTransform(Parent.GetDirivitive, StartX, EndX)
    End Function
End Class
