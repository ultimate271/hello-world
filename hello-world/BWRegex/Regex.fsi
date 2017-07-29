#indent "off"

namespace BWRegex
module NFA = begin
	type Regchar =
	| Epsilon
	| Regchar of char

	type State =
	| Sink
	| Start
	| Nonaccept of int
	| Accept of int
	type Delta = Delta of (State -> Regchar -> Set<State>)
	val endWithB : Delta
	val endWithC : Delta
	val endWithBorC : Delta
	val concatTest : Delta
	val kleeneTest : Delta
	val regexTest : Delta
	val evalNFA : Delta -> string -> bool
end
