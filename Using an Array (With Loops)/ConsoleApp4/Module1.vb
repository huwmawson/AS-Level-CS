Module Module1
    Dim Task(3) As Integer ' declare an array containing 4 elements (remember indexing starts at 0)

    Sub Main()
        For i = 0 To 3 'This loops throught the statement on te nest line 4 times(0, 1,2,3)
            Task(i) = i + 1 ' This line assigns the value i+1 (0+1 on the first iteration, etc) to the i'th element of the list
        Next

        For i = 0 To 3 'this loop outputs the values of each of the elements in the array
            Console.WriteLine(Task(i))
        Next

        Console.ReadLine()


    End Sub

End Module
