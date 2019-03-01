Module Module1
    ' NullPointer should be set to -1 if using array element with index 0
    Const NULLPOINTER = -1
    ' Declare record type to store data and pointer
    Structure TreeNode
        Dim Data As String
        Dim LeftPointer, RightPointer As Integer
    End Structure


    Dim Tree(7) As TreeNode 'Declare an array of 7 elements of type "TreeNode"
    Dim RootPointer As Integer
    Dim FreePtr As Integer
    Sub InitialiseTree()
        RootPointer = NULLPOINTER ' set start pointer
        FreePtr = 0 ' set starting position of first free element
        For Index = 0 To 7 'link all nodes to make free list
            Tree(Index).LeftPointer = Index + 1  'this value  is used to modify the free list pointer later in the program
            Tree(Index).RightPointer = NULLPOINTER
            Tree(Index).Data = ""
        Next
        Tree(7).LeftPointer = NULLPOINTER 'last node of free list
    End Sub


    Function FindNode(SearchItem) As Integer
        'This function loops through each branch of the tree until it finds the search item
        Dim ThisNodePtr As Integer
        ThisNodePtr = RootPointer 'start at the beginning of the array
        Try  'hacky way around problems of the index falling out of range if the list is empty - This uses the technique of exception handling to cope with the fact that if the list is empty the root pointer is seet to -1, which is out of range for the array.
            Do While ThisNodePtr <> NULLPOINTER And Tree(ThisNodePtr).Data <> SearchItem
                If Tree(ThisNodePtr).Data > SearchItem Then
                    ThisNodePtr = Tree(ThisNodePtr).LeftPointer
                Else
                    ThisNodePtr = Tree(ThisNodePtr).RightPointer
                End If
            Loop
        Catch ex As Exception
        End Try


        Return ThisNodePtr
    End Function


    Sub InsertNode(NewItem)
        Dim NewNodePtr, ThisNodePtr, PreviousNodePtr As Integer
        Dim TurnedLeft As Boolean
        If FreePtr <> NULLPOINTER Then
            ' there is space in the array
            ' take node from free list and store data item
            NewNodePtr = FreePtr
            Tree(NewNodePtr).Data = NewItem
            FreePtr = Tree(FreePtr).LeftPointer 'update this pointer to point to the next free item in the array
            Tree(NewNodePtr).LeftPointer = NULLPOINTER
            ' check if empty tree
            If RootPointer = NULLPOINTER Then
                RootPointer = NewNodePtr
            Else ' find insertion point
                ThisNodePtr = RootPointer
                Do While ThisNodePtr <> NULLPOINTER
                    PreviousNodePtr = ThisNodePtr
                    ' if the new data item is of a lower value than the data currently stored in the node go left
                    If Tree(ThisNodePtr).Data > NewItem Then
                        TurnedLeft = True
                        ThisNodePtr = Tree(ThisNodePtr).LeftPointer  'Set the pointer to point to the node pointed to by the left pointer in the node 
                    Else
                        TurnedLeft = False
                        ThisNodePtr = Tree(ThisNodePtr).RightPointer 'Set the pointer to point to the node pointed to by the right pointer in the node 
                    End If
                Loop
                If TurnedLeft Then
                    Tree(PreviousNodePtr).LeftPointer = NewNodePtr 'set the left pointer of the previous node to point to the new node
                Else
                    Tree(PreviousNodePtr).RightPointer = NewNodePtr 'set the right pointer of the previous node to point to the new node
                End If
            End If
        Else
            Console.WriteLine("no space for more data")
        End If
    End Sub

    'This subroutine uses recursive calls to traverse the tree.  I will go through this example when we cover recursion soon!
    Sub TraverseTree(RootPointer)
        'Console.WriteLine(RootPointer)
        If RootPointer <> NULLPOINTER Then
            TraverseTree(Tree(RootPointer).LeftPointer)
            Console.WriteLine(Tree(RootPointer).Data)
            TraverseTree(Tree(RootPointer).RightPointer)
        End If
    End Sub

    Function GetOption()
        Dim Choice As Char
        Console.WriteLine("1: add data")
        Console.WriteLine("2: find data")
        Console.WriteLine("3: traverse tree")
        Console.WriteLine("4: end program")
        Console.Write("Enter your choice: ")
        Choice = Console.ReadLine()
        Return (Choice)
    End Function


    Sub Main()
        Dim Choice As Char
        Dim Data As String
        Dim ThisNodePtr As Integer
        InitialiseTree()
        Choice = GetOption()
        Do While Choice <> "4"
            Select Case Choice
                Case "1"
                    Console.Write("Enter the value: ")
                    Data = Console.ReadLine()
                    InsertNode(Data)
                    'TraverseTree(RootPointer)
                Case "2"
                    Console.Write("Enter search value: ")
                    Data = Console.ReadLine()
                    ThisNodePtr = FindNode(Data)
                    If ThisNodePtr = NULLPOINTER Then
                        Console.WriteLine("Value not found")
                    Else
                        Console.WriteLine("value found at: " & ThisNodePtr)
                    End If
                    Console.WriteLine(RootPointer & " " & FreePtr)
                    For i = 0 To 7
                        Console.WriteLine(i & " " & Tree(i).LeftPointer & " " & Tree(i).Data & " " & Tree(i).RightPointer)
                    Next
                Case "3"
                    TraverseTree(RootPointer)
            End Select
            Choice = GetOption()
        Loop
    End Sub
End Module
