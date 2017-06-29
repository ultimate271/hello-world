using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Numerics;
using HelloFSharp;

namespace FSharpEntrypoint {
	class Program {
		static void Main(string[] args) {
			System.Console.WriteLine("Hello World!");
			for (int i = 0; i < 500; i++) {
				System.Console.WriteLine("{0,3}| {1, 20}|{2}.", i, Playground.fib(i), Playground.fibsum(i));
			}
			
			System.Console.ReadLine();
		}
	}
}
