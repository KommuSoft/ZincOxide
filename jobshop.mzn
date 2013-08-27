% (square) job shop scheduling in MiniZinc
int: size;                                   % size of problem
array [1..size,1..size] of int : d;          % task durations
int : total = sum(i,j in 1..size) (d[i,j]);  % total duration
array [1..size,1..size] of var 0..total : s; % start times
var 0..total : end;                          % total end time

predicate no_overlap (var int:s1, int:d1, var int:s2, int:d2) =
    s1 + d1 <= s2 \/ s2 + d2 <= s1;

constraint
    forall(i in 1..size) (
        forall(j in 1..size-1) (s[i,j] + d[i,j]) <= s[i,j+1]) /\
        s[i,size] + d[i,size] <= end /\
        forall(j,k in 1..size where j < k) (
            no_overlap(s[j,i], d[j,i], s[k,i], d[k,i])
        )
    );

solve minimize end;