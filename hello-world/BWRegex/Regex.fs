#indent "off"

namespace BWRegex

module Helper = begin
	let stupid = fun y -> y*3;;

	let rec subset l g =
		match l with
		| [] -> true
		| x::xs -> (List.contains x g) && (subset xs g)


	let rec distinct l =
		match l with
		| [] -> true
		| x::xs -> not (List.contains x xs) && (distinct xs)

	let explode (input:string) : char list =
		[for c in input -> c]
end

module DFA = begin
	type State = 
		| Sink
		| Nonaccept of int
		| Accept of int 
		with
			static member (=) ((left, right) : State * State) : bool =
				match (left, right) with
				| (Nonaccept i, Nonaccept j)
				| (Accept i, Accept j) ->
					i = j
				| _ -> false
			static member (<>) (left, right) =
				not <| left = right
		end
	
	type TransFun = TransFun of (State -> char -> State)
		with
			static member buildTransFun (transList : (State * char * State) list) : TransFun =
			// Takes f as the current transFun, and returns a new transFun with values (x, y, z) added to f
				let rec buildTransFunRec (l : (State * char * State) list) : TransFun =
					let update (TransFun f) (x:State) (y:char) (z:State) = 
						TransFun <| fun i j -> 
							if i = x && j = y then 
								z 
							else 
								f i j 
					in
					match l with
					| [] -> 
						TransFun <| fun _ _ -> Sink
					| (Sink _, c, s')::ts ->
						buildTransFunRec ts
					| (s, c, s')::ts ->
						update (buildTransFunRec ts) s c s'
				in
				buildTransFunRec transList
		end
	
	type DFA = {
		start:State;
		transFun:TransFun;
	}

	//let rec buildTransFun (l : (State * char * State) list) : transFun =
	//	// Takes f as the current transFun, and returns a new transFun with values (x, y, z) added to f
	//	let update (f:transFun) (x:State) (y:char) (z:State) = 
	//		fun i j -> 
	//			if i = x && j = y then 
	//				z 
	//			else 
	//				f i j 
	//	in
	//	match l with
	//	| [] -> 
	//		fun _ _ -> Sink
	//	| (s, c, s')::ts ->
	//		update (buildTransFun ts) s c s'
			
	let myTransFun = TransFun.buildTransFun [(Nonaccept 0, 'a', Nonaccept 0); (Nonaccept 0, 'b', Accept 0); (Accept 0, 'a', Nonaccept 0); (Accept 0, 'b', Accept 0)]
	let myDFA = {start=Nonaccept 0; transFun=myTransFun}

	let eval (dfa:DFA) (input:string) : bool =
		let rec evalRec (dfa:DFA) (input:char list) (currentState:State) : bool =
			match input with
			| [] ->
				(match currentState with
				| Accept _ -> true
				| Nonaccept _ -> false
				| Sink _ -> false)
			| c::cs -> 
				(match dfa.transFun with
				| (TransFun f) -> 
					f currentState c |> evalRec dfa cs)
		in
		evalRec dfa (Helper.explode input) dfa.start

	let test s = eval myDFA s
	//type transFun = State -> char -> State
	
	//type dfa = {
	//	states:State list;
	//	start:State;
	//	finals:State list;
	//	transition:transFun
	//}

	//let buildTransFun (tupleList:(State*char*State)list) : transFun =
	//	let rec loop tl acc =
	//		match tl with
	//		| [] ->
	//			acc
	//		| (s,c,s')::xs -> 
	//			fun s c -> s'
	//	in
	//	loop tupleList (fun _ -> fun _ -> State.Sink)

	//type InformativeBool =
	//	True |
	//	False of string

	//let InformativeBool2Bool (ib:InformativeBool) =
	//	match ib with
	//		| True -> true
	//		| False _ -> false

	//let verifyDFA ({states = states; start = s; finals = f}:dfa) : InformativeBool =
	//	if not <| Helper.distinct states then 
	//		False "States not distinct"
	//	else if not <| List.contains s states then
	//		False "start State not a State"
	//	else if not <| Helper.subset f states then
	//		False "some final States aren't a State"
	//	else
	//		True

	//let testDFA = {
	//	states = [0,1,2];
	//	start = 0;
	//	finals = [2];
	//	transFun = buildTransistionFunction []
	//}

end

module NFA = begin
	type Regchar =
	| Epsilon
	| Regchar of char
	with
		static member (=) (left, right) =
			match (left, right) with
			| (Epsilon, Epsilon) -> true
			| (Regchar a, Regchar b) -> a = b
			| _ -> false
		static member explode (s:string) : Regchar list =
			[for c in s -> Regchar c]
	end

	type State =
	| Sink
	| Start
	| Nonaccept of int
	| Accept of int
	with
		static member (=) (left, right) =
			match (left, right) with
			| (Sink, Sink) -> true
			| (Start, Start) -> true
			| (Nonaccept x, Nonaccept y)
			| (Accept x, Accept y) ->
				x = y
			| _ -> false
	end

	type Delta = Delta of (State -> Regchar -> Set<State>)
	with
		static member nil : Delta =
			Delta <| fun s c ->
				match (s, c) with
				| (Sink, _) -> Set.singleton Sink
				| (s, Epsilon) -> Set [s; Sink]
				| (s, Regchar _) -> Set.singleton Sink

		static member build (tupleList:(State*Regchar*State) list) : Delta = 
			let rec loop tupleList : Delta = 
				let update (Delta f) s1 c1 s2 : Delta = 
					match (s1, c1, s2) with
					| (Sink, _, _) -> 
						Delta f
					| (Start, Regchar _, _) -> 
						Delta f
					| (s1, c1, s2) ->
						Delta <| fun x y ->
							if x = s1 && y = c1 then
								Set.add s2 (f x y)
							else
								f x y
				in
				match tupleList with
				| [] -> 
					Delta.nil
				| (s1, c1, s2)::ts ->
					(update (loop ts) s1 c1 s2)
			in
			loop tupleList

		static member union (Delta f) (Delta g) : Delta =
			let mapEven = fun (s:State) ->
				match s with
				| Sink -> Sink
				| Start -> Nonaccept 0
				| Nonaccept i -> Nonaccept (i * 2 + 2)
				| Accept i -> Accept (i * 2)
			in
			let mapOdd = fun (s:State) ->
				match s with
				| Sink -> Sink
				| Start -> Nonaccept 1
				| Nonaccept i -> Nonaccept (i * 2 + 3)
				| Accept i -> Accept (i * 2 + 1)
			in
			let isEven i = ((i%2) = 0) in
			Delta <| fun s c ->
				match (s, c) with
				| (Sink, _) ->
					Set.singleton Sink
				| (Start, Epsilon) ->
					Set [Nonaccept 0; Nonaccept 1]
				| (Start, _) ->
					Set.singleton Sink
				| (Nonaccept 0, c) ->
					f Start c |> Set.map mapEven
				| (Nonaccept 1, c) ->
					g Start c |> Set.map mapOdd
				| (Nonaccept i, c) ->
					if isEven i then
						f (Nonaccept (i/2 - 1)) c |> Set.map mapEven
					else
						g (Nonaccept ((i-1)/2 - 1)) c |> Set.map mapOdd
				| (Accept i, c) ->
					if isEven i then
						f (Accept (i/2)) c |> Set.map mapEven
					else
						g (Accept ((i-1)/2)) c |> Set.map mapOdd
		
		static member concat (Delta f) (Delta g) : Delta =
			let mapLeft (s:State) : State =
				match s with
				| Sink -> Sink
				| Start -> Start
				| Nonaccept i -> Nonaccept <| i * 3
				| Accept i -> Nonaccept <| i * 3 + 2
			in
			let mapRight (s:State) : State =
				match s with
				| Sink -> Sink
				| Start -> Nonaccept 1
				| Nonaccept i -> Nonaccept <| i * 3 + 4
				| Accept i -> Accept i
			in
			let mod0 x = (x%3) = 0 in
			let mod1 x = (x%3) = 1 in
			Delta <| fun s c ->
				match (s, c) with
				| (Sink, _) -> 
					Set.singleton Sink
				| (Start, c) ->
					f Start c |> Set.map mapLeft
				| (Nonaccept 1, c) ->
					g Start c |> Set.map mapRight
				| (Nonaccept i, c) ->
					if mod0 i then
						f (Nonaccept <| i/3) c |> Set.map mapLeft
					else if mod1 i then
						g (Nonaccept <| (i-1)/3 - 1) c |> Set.map mapRight
					else
						let returnedSet = f (Accept <| (i-2)/3) c |> Set.map mapLeft in
						(match c with
						| Epsilon ->
							returnedSet |> Set.add (Nonaccept 1)
						| Regchar _ ->
							returnedSet)
				| (Accept i, c) ->
					g (Accept i) c |> Set.map mapRight

		static member kleene (Delta f) : Delta =
			let mapF (s : State) : State =
				match s with
				| Sink -> Sink
				| Start -> Nonaccept 0
				| Nonaccept i -> Nonaccept (i + 1)
				| Accept i -> Accept (i + 1)
			in
			Delta <| fun s c ->
				match (s, c) with
				| (Sink, _) -> 
					Set.singleton Sink
				| (Start, Epsilon) ->
					Set [Nonaccept 0; Accept 0; Sink]
				| (Start, _) ->
					Set.singleton Sink
				| (Nonaccept 0, c) ->
					f Start c |> Set.map mapF
				| (Nonaccept i, c) ->
					f (Nonaccept <| i-1) c |> Set.map mapF
				| (Accept 0, Epsilon) ->
					Set [Start; Sink]
				| (Accept i, c) ->
					let returnedSet = f (Accept <| i-1) c in
					(match c with
					| Epsilon ->
						returnedSet |> Set.add Start
					| Regchar _ ->
						returnedSet)		
	end	

	type Regex =
	| Nil
	| Singleton of Regchar
	| Union of (Regex * Regex)
	| Concat of (Regex * Regex)
	| Kleene of Regex
	with
		static member buildNFA (r:Regex) : Delta =
			let rec loop (r:Regex) : Delta =
				match r with
				| Nil -> Delta.nil
				| Singleton c -> Delta.build [(Start, Epsilon, Nonaccept 0); (Nonaccept 0, c, Accept 0)]
				| Union (r1, r2) -> Delta.union (loop r1) (loop r2)
				| Concat (r1, r2) -> Delta.concat (loop r1) (loop r2)
				| Kleene r' -> Delta.kleene (loop r')
			in
			loop r
	end

	let endWithB = Delta.build [
		(Start, Epsilon, Nonaccept 0);
		(Nonaccept 0, Regchar 'A', Nonaccept 0);
		(Nonaccept 0, Regchar 'B', Accept 0)
	]

	let endWithC = Delta.build [
		(Start, Epsilon, Nonaccept 0);
		(Nonaccept 0, Regchar 'A', Nonaccept 0);
		(Nonaccept 0, Regchar 'C', Accept 0)
	]

	let endWithBorC = Delta.union endWithB endWithC
	let concatTest = Delta.concat endWithB endWithC
	let kleeneTest = Delta.kleene endWithB
	
	let myRegex = Concat (Concat (Singleton (Regchar 'A'), Kleene (Union (Singleton (Regchar 'A'), Singleton (Regchar 'B')))), Singleton (Regchar 'A')) 
	let regexTest = Regex.buildNFA myRegex


	let myDelta = Delta.build [
		(Start, Epsilon, Nonaccept 0);
		(Nonaccept 0, Regchar 'a', Nonaccept 0);
		(Nonaccept 0, Regchar 'b', Nonaccept 0); 
		(Nonaccept 0, Regchar 'b', Accept 0)
	]

	let epsilonClosure (Delta f) (states: Set<State>) : Set<State> =
		let epsilonClosureSingle (Delta f) (state: State) : Set<State> =	//Figure it out for a single state
			let rec loop (Delta f) (state: State) (visited: Set<State>) : Set<State> =
				let visited = Set.add state visited in						//Probably some sketchy ass syntax, but I'm binding a new visited here
				let directlyEpsilon = f state Epsilon in
				let setsToUnion = 
					let mapFunction s =
						if Set.contains s visited |> not then				//if s has not been visited
							loop (Delta f) s (Set.add s visited)			//recursively get the epsilon closure of s, and let the call know we've visited s
						else
							Set.empty										//else, we've already visited, 
					in
					Set.map mapFunction directlyEpsilon						//returns the set of all sets that epsilon points to that haven't been visited
				in
				Set.union directlyEpsilon (Set.unionMany setsToUnion)
			in
			loop (Delta f) state (Set.singleton state)
		in
		Set.map (epsilonClosureSingle (Delta f)) states |> Set.unionMany<State>		//Map each state in states to its epsilon closure, then union those sets
	

	let step (Delta f) (initStates:Set<State>) (character: Regchar) : Set<State> =
		let reversedf c s = f s c in
			Set.map (reversedf character) (epsilonClosure (Delta f) initStates) |> Set.unionMany<State>

	let evalNFA (delta:Delta) (input:string) : bool =
		let epsilonClosure = epsilonClosure delta in
		let rec loop (delta:Delta) (input: Regchar list) (currentStates: Set<State>) : Set<State> =
			match input with
			| [] ->
				epsilonClosure currentStates
			| c::cs ->
				step delta currentStates c |> loop delta cs
		in
		loop delta (Regchar.explode input) (Set.singleton Start) |> Set.exists (fun s -> match s with Accept _ -> true | _ -> false)

end