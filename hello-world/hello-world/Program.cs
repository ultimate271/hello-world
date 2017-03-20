using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hello_world {
	class Program {
		static void Main(string[] args) {
			System.Console.WriteLine("This is my first git program");
			System.Console.WriteLine("This is some more stuff");
			System.Console.ReadLine();
			Console.WriteLine("Are there Changes now?");
			Console.WriteLine("This is a feature");
			Console.WriteLine("This is a feature too!");
			Console.WriteLine("They are all features!");
			Console.WriteLine("So I want to commit something too");
			Console.WriteLine("Lets try this again");
			hello_world.MyClass myObject = new MyClass(3, 4);
			Console.WriteLine("{0}", myObject.Hypotonuse);
			Console.ReadLine();
			Animal myAnimal = new Horse();
			myAnimal.Name = "El Dorado";
			Console.WriteLine("My horse's description --- {0}", myAnimal.Description);
		}
	}
}
