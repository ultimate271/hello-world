using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace LinqToSQLPlayground {
	class Program {
		static void Main(string[] args) {
			LinqPlaygroundDataContext dc = new LinqPlaygroundDataContext();
			//IEnumerable<Customer> query = from Customer c in dc.Customers select c;

			//var q2 = from Order o in dc.Orders select new { CusName = o.Customer.FirstName, OrderNo = o.id } ;
			////This is a comment
			//foreach (var x in q2) {
			//	Console.WriteLine("{0} {1}", x.OrderNo, x.CusName);
			//}
			//foreach (Customer c in dc.Customers) {
			//	c.FirstName = c.FirstName.Substring(0, c.FirstName.Trim().Length - 1);
			//	Console.WriteLine("{0}", c.FirstName);
			//}
			////dc.SubmitChanges();

			var q3 = from Customer customer in dc.Customers
					 join Order order in dc.Orders on customer.id equals order.Customer.id
					 join Order_MenuItem o_mi in dc.Order_MenuItems on order.id equals o_mi.Order.id
					 join MenuItem mi in dc.MenuItems on o_mi.MenuItem.id equals mi.id
					 select new {
						 firstname = customer.FirstName,
						 lastname = customer.LastName,
						 orderno = order.id,
						 menuItem = mi.Name
					 };
			foreach (var record in q3) {
				System.Console.WriteLine(record.RecordToString());
				//System.Console.WriteLine("{0} {1} {2} {3}", record.firstname, record.lastname, record.orderno, record.menuItem);
			}
			Console.ReadLine();
		}
	}
	public static class MyExtensions {
		public static string RecordHeaderToString(this object record) {
			string retVal = "";
			foreach (PropertyInfo pi in record.GetType().GetProperties()) {
				retVal += pi.Name + " ";
			}
			return retVal;
		}
		public static string RecordToString(this object record) {
			string retVal = "";
			foreach (PropertyInfo pi in record.GetType().GetProperties()) {
				retVal += pi.GetValue(record).ToString() + " ";
			}
			return retVal;
		}
	}

	partial class Customer {
		partial void OnFirstNameChanged() {
			System.Console.WriteLine("Customer::OnFirstNameChanged");
		}
	}
}
