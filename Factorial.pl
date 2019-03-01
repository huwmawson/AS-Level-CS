factorial(0,1).
factorial(N,Result):-
M is N-1,
factorial(M,PartResult),
Result is PartResult*N.