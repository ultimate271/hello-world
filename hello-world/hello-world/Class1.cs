using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hello_world {
	class MyClass {
		public int Number1 { get; set; }
		public int Number2 { get; set; }
		public int Hypotonuse { get { return Number1 * Number1 + Number2 * Number2; } }

		public MyClass(int number1, int number2) {
			Number1 = number1;
			Number2 = number2;
		}
		public int GetHypotonuse() {
			return Number1 * Number1 + Number2 * Number2;
		}
	}
}
