Module Module1

    Function Factorial(n) As Integer

        Dim Result As Integer
        'The base case will return 1
        If n = 0 Then
            Result = 1
        Else
            'the function will iterate through recursively until it reaches the base case
            Result = n * Factorial(n - 1)
        End If
        Return (Result)

    End Function

    Sub Main()

        Dim result As Integer

        'call the function pasing an integer as the parameter n
        result = Factorial(4)


        Console.WriteLine(result)
        Console.ReadKey()

    End Sub


End Module
