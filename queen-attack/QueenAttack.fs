module QueenAttack

open System

let inRange(x : int) = x < 8 && x > 0

let create ((x, y): int * int) = inRange(x) && inRange(y)

let canAttack ((x1, y1): int * int) ((x2, y2): int * int) = create(x1, y1) && create(x2, y2) && (x1 = x2 || y1 = y2 || Math.Abs(x1 - x2 ) = Math.Abs(y1 - y2))