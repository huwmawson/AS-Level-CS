Module Module1
    Dim CallNumber 'declare the global variable (available throughout the program) callNumber

    Function Factorial(n) As Integer 'This is the function taking the parameter n s it's argument - it returns an integer

        Dim Result As Integer

        CallNumber += 1 ' incremnet the callNumber variable each time we run through the function

        Console.WriteLine("The current call number is " & CallNumber & " " & "and the value of the number is " & n) ' output the callnumber and the current value f n as iti is passed to the function, to the console each time the function is called


        If n = 0 Then
            Result = 1 'The base case will return 1 (the factorial of 0)
        Else
            'the function will iterate through recursively until it reaches the base case as each parameter passed is the previous n value decremented by 1

            Result = n * Factorial(n - 1) 'here is where the recursive call takes place, calling the function Factorial(n-1) from within the Factorial function
        End If


        Console.WriteLine("Return value: " & Result)

        Return (Result)

    End Function

    Sub Main()

        Dim result As Integer
        Dim num As Integer = 4
        CallNumber = 0 'initialise the callNumber to 0

        'call the function pasing an integer as the parameter n, in this case 4


        result = Factorial(num) 'This is the function call.
        Console.WriteLine(vbCrLf & "The factorial of " & num & " is " & result) 'output the result ot the console


        Console.ReadKey()

    End Sub


End Module

