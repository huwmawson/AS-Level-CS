man(adam).
man(peter).
man(paul).
 
woman(mary).
woman(eve).

parent(adam,peter). % means adam is parent of peter
parent(eve,peter).
parent(adam,paul).
parent(marry,paul).

father(F,C):-man(F),parent(F,C).
mother(M,C):-woman(M),parent(M,C).

