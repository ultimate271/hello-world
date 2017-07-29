using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Numerics;
using HelloFSharp;
using BWRegex;

namespace FSharpEntrypoint {
	class Program {
		static void Main(string[] args) {
			System.Console.WriteLine("Hello World!");
			//for (int i = 0; i < 500; i++) {
			//	System.Console.WriteLine("{0,3}| {1, 20}|{2}.", i, Playground.fib(i), Playground.fibsum(i));
			//}

			//System.Console.WriteLine("Stupid: {0}", BWRegex.Helpers.stupid(12));
			//System.Console.WriteLine(BWRegex.DFA.test(12));
			//System.Console.WriteLine("{0} {1} {2}", Playground.boolCompare, Playground.stateCompareFalse, Playground.stateCompareTrue);
			System.Console.Write("Input a value: ");
			string input = System.Console.ReadLine();
			System.Console.WriteLine("Input: {0}\nResult for endWithB:{1}\nResult for endWithC:{2}\nResult for Union: {3}\nResult for Concat: {4}\nResult for Kleene: {5}\nResult for regex: {6}",
				input,
				NFA.evalNFA(NFA.endWithB, input),
				NFA.evalNFA(NFA.endWithC, input),
				NFA.evalNFA(NFA.endWithBorC, input),
				NFA.evalNFA(NFA.concatTest, input),
				NFA.evalNFA(NFA.kleeneTest, input),
				NFA.evalNFA(NFA.regexTest, input));
			BWRegex.NFA.Delta delta;
			System.Console.ReadLine();
		}
	}
}
