#indent "off"

namespace HelloFSharp
module Playground = begin

	let x = 12;;

	let nonZero x =
		match x with
		| 0 -> None
		| _ -> Some x

	type State = 
		Nonaccept of int |
		Accept of int 
		with 
		static member (=) ((left, right) : (State * State)) : bool =
			match (left, right) with
			| (Nonaccept i, Nonaccept j)
			| (Accept i, Accept j) ->
				i = j
			| _ -> false
		end

	let boolCompare = 2 = 2
	let stateCompareTrue = Accept 12 = Accept 12
	let stateCompareFalse = Accept 12 = Nonaccept 12

	let fib n =
		let rec loop i (a:bigint) (b:bigint) = 
			if i = n
			then a
			else loop (i+1) b (a + b) in
		loop 0 (bigint 0) (bigint 1);;
	
	let fibsum n =
		let rec loop i (a:bigint) (b:bigint) (acc:bigint) =
			if i = n
			then acc + a
			else loop (i+1) b (a + b) (acc + a) in
		loop 0 (bigint 0) (bigint 1) (bigint 0);;

end
