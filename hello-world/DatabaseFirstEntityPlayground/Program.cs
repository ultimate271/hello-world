using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DatabaseFirstEntityPlayground {
	class Program {
		static void Main(string[] args) {
			using (WLDataModel myModel = new WLDataModel()) {
				//myModel.WLMovements.Add(new WLMovementAir() { movementType_id = 1, movement_id = 1, reps = 50 });
			}
		}
	}
}
