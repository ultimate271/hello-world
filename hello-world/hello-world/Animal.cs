using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hello_world {
	abstract class Animal {
		public string Name { get; set; }
		public abstract string Description { get; }
	}
}
