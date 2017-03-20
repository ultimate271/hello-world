using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace hello_world {
	class Program {
		const string SERVER_NAME = "Brett-PC\\SQLEXPRESS";
		const string DB_NAME = "testdb";

		static void Main(string[] args) {
			//System.Data.SqlClient.SqlConnectionStringBuilder myBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder();
			//myBuilder.DataSource = SERVER_NAME;
			//myBuilder.InitialCatalog = DB_NAME;
			//myBuilder.IntegratedSecurity = true;
			//Console.WriteLine(myBuilder.ToString());
			//System.Data.SqlClient.SqlConnection myConnection = new System.Data.SqlClient.SqlConnection(myBuilder.ToString());
			//try { myConnection.Open(); }
			//catch { Console.WriteLine("Connection Failed"); }

			testdbDataContext db = new testdbDataContext();

			foreach (var obj in db.Customers.Where(c => c.last_name[0] == 'W').Select(c => new { First = c.first_name, Last = c.last_name })) {
				Console.WriteLine("{0} {1}", obj.First, obj.Last);
			}
			//var myQuery = from c in db.Customers
			//				where c.last_name[0] == 'W'
			//				select new { First = c.first_name, Last = c.last_name };
			//var myQuery2 = from i in db.Invoices
			//				where i.Customer.last_name[0] == 'W'
			//				select new { First = i.Customer.first_name, Last = i.Customer.last_name, Purchase = i.purchase };
			//foreach (var obj in myQuery2) {
			//	Console.WriteLine("{0} {1} {2}", obj.First, obj.Last, obj.Purchase);
			//}
			//Console.WriteLine("{0}");
			//foreach (Invoice i in db.Invoices) {
			//	Console.WriteLine("{0} {1} {2}", i.Customer.first_name, i.Customer.last_name, i.purchase);
			//}


			//Console.WriteLine("This is my first git program");
			//Console.WriteLine("This is some more stuff");
			//Console.ReadLine();
			//Console.WriteLine("Are there Changes now?");
			//Console.WriteLine("This is a feature");
			//Console.WriteLine("This is a feature too!");
			//Console.WriteLine("They are all features!");
			//Console.WriteLine("So I want to commit something too");
			//Console.WriteLine("Lets try this again");
			//hello_world.MyClass myObject = new MyClass(3, 4);
			//Console.WriteLine("{0}", myObject.Hypotonuse);
			//Console.ReadLine();
			//Animal myAnimal = new Horse();
			//myAnimal.Name = "El Dorado";
			//Console.WriteLine("My horse's description --- {0}", myAnimal.Description);

		}
	}
}
