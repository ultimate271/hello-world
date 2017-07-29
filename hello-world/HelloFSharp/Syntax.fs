module Tester


type State = 
 | Nonaccept of int
 | Accept of int 
 static member (=) ((left, right) : (State * State)) : bool =
  match (left, right) with
  | (Nonaccept i, Nonaccept j)
  | (Accept i, Accept j) ->
   i = j
  | _ -> false