using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hello_world {
	class Horse : Animal {
		public override string Description {
			get {
				return string.Format("This is a horse with name {0}.", base.Name);
			}
		}
	}
}
