using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSQLByHand {
	class Program {
		static void Main(string[] args) {
			ByHandDBContext dc = new ByHandDBContext();

			foreach (Customer c in dc.Customers) {
				c.FirstName = c.FirstName.Trim() + "F";
				//c.FirstName = c.FirstName.Substring(0, c.FirstName.Trim().Length - 1);
			}

			var query = from Customer c in dc.Customers select new { firstname = c.FirstName, lastname = c.LastName };
			foreach (var record in query) {
				System.Console.WriteLine("{0} {1}", record.firstname.Trim(), record.lastname.Trim());
			}
			IEnumerable<Customer> q2 = from Customer c in dc.Customers select c;
			foreach (Customer c in q2) {
				System.Console.WriteLine("{0} {1}", c.FirstName.Trim(), c.LastName.Trim());
			}

			//dc.SubmitChanges();

			System.Console.WriteLine("Hello World");
			System.Console.ReadLine();

		}
	}
}
