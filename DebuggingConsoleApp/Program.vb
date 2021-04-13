Imports System
Imports CautiousMathLib

Module Program
    Sub Main(args As String())

        Dim f As New DiscreteFunction({(30, 0.5), (40, 0.5)}, True, 10)
        Dim g As New DiscreteFunction({(30, 0.3), (100, 0.7)}, True, 10)

        Dim fold As DiscreteFunction = f.CalculateFold(g, True, 10)

        For Each x In fold.GetDefinitionSpace()
            Console.WriteLine(x.ToString + " -> " + fold.At(x).ToString)
        Next
        Console.ReadLine()
    End Sub
End Module
