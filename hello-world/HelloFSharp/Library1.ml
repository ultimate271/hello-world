module HelloFSharp.Playground

let x = 12;;

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


