using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace SomeNamespace {
	public static class UtilMethods{
		public static string DoesSomethingAwesome(){
			Assembly ass = typeof(UtilMethods).Assembly;
			Assembly baseAss = typeof(int).Assembly;
			var myObject = ass.CreateInstance(string.Format("SomeNamespace.{0}", "MyClass"));
			var myInt = baseAss.CreateInstance("System.Int32");
			var myIEnum = baseAss.CreateInstance("System.Collections.Generic.List<string>");
			System.Collections.Generic.IEnumerable<string> anObj = new List<string>();
			Type t = anObj.GetType();
			//bool x = myInt.GetType().IsValueType;
			myInt = 12;
			
			foreach (PropertyInfo property in myObject.GetType().GetProperties()){

				//Type t = (from att in property.CustomAttributes where att.AttributeType == typeof(MyCustomTagAttribute) select att.AttributeType).SingleOrDefault();
				if (property.ContainsAttribute(typeof(MyCustomTagAttribute))) { property.SetValue(myObject, property.Name.Length); }
				
			}

			return string.Format("{0} {1} {2}", (myObject as MyClass).MyProperty, (myObject as MyClass).MySecondProperty, (myObject as MyClass).MyThirdProperty);
		}

		public static bool ContainsAttribute(this MemberInfo mi, Type t){
			return mi.CustomAttributes.Where(att => att.AttributeType == t).Any();
			//return (from att in mi.CustomAttributes where att.AttributeType == t select att).SingleOrDefault() != null;
		}
	}

	[MyCustomTag]
	public class MyClass{
		[MyCustomTag]
		public int MyProperty { get; set; }
		[MyCustomTag2]
		public int MySecondProperty { get; set; }
		[MyCustomTag]
		[MyCustomTag2]
		public int MyThirdProperty { get; set; }

		public MyClass() { }
	}
	public class Test {

		public static void Main() {
			System.Console.WriteLine(UtilMethods.DoesSomethingAwesome());
			MyClass myObj = new MyClass();
			//System.Console.WriteLine(myObj.GetType().CustomAttributes.Contains() ? "It is" : "It isn't");
		}
	}

	[AttributeUsage(AttributeTargets.All)]
	public class MyCustomTagAttribute : Attribute{ }
	
	[AttributeUsage(AttributeTargets.All)]
	public class MyCustomTag2Attribute : Attribute { }

}

//using System;
//using System.IO;
//using System.Runtime.Serialization;
////using System.Runtime.Serialization.Formatters.Soap;
//using System.Runtime.Serialization.Formatters.Binary;

//public class Test
//{
//	public static void Main()
//	{

//		//Creates a new TestSimpleObject object.
//		TestSimpleObject obj = new TestSimpleObject();

//		Console.WriteLine("Before serialization the object contains: ");
//		obj.Print();

//		//Opens a file and serializes the object into it in binary format.
//		Stream stream = File.Open("data.dat", FileMode.Create);
//		//SoapFormatter formatter = new SoapFormatter();

//		BinaryFormatter formatter = new BinaryFormatter();

//		formatter.Serialize(stream, obj);
//		stream.Close();

//		//Empties obj.
//		obj = null;

//		//Opens file "data.xml" and deserializes the object from it.
//		stream = File.Open("data.dat", FileMode.Open);
//		//formatter = new SoapFormatter();

//		formatter = new BinaryFormatter();

//		obj = (TestSimpleObject)formatter.Deserialize(stream);
//		stream.Close();

//		Console.WriteLine("");
//		Console.WriteLine("After deserialization the object contains: ");
//		obj.Print();

//		var anonObject = new {
//			member1 = 12,
//			member2 = "this",
//			member3 = "is",
//			member4 = 12.0,
//			member5 = "Whack"
//		};
		
//	}
//}


//// A test object that needs to be serialized.
//[Serializable()]
//public class TestSimpleObject
//{

//	public int member1;
//	public string member2;
//	public string member3;
//	public double member4;

//	// A field that is not serialized.
//	[NonSerialized()] public string member5;

//	public TestSimpleObject()
//	{

//		member1 = 11;
//		member2 = "hello";
//		member3 = "hello";
//		member4 = 3.14159265;
//		member5 = "hello world!";
//	}


//	public void Print()
//	{

//		Console.WriteLine("member1 = '{0}'", member1);
//		Console.WriteLine("member2 = '{0}'", member2);
//		Console.WriteLine("member3 = '{0}'", member3);
//		Console.WriteLine("member4 = '{0}'", member4);
//		Console.WriteLine("member5 = '{0}'", member5);
//	}
//}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data;

//namespace hello_world {
//	class Program {
//		const string SERVER_NAME = "Brett-PC\\SQLEXPRESS";
//		const string DB_NAME = "testdb";

//		static void Main(string[] args) {

//			//System.Data.SqlClient.SqlConnectionStringBuilder myBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder();
//			//myBuilder.DataSource = SERVER_NAME;
//			//myBuilder.InitialCatalog = DB_NAME;
//			//myBuilder.IntegratedSecurity = true;
//			//Console.WriteLine(myBuilder.ToString());
//			//System.Data.SqlClient.SqlConnection myConnection = new System.Data.SqlClient.SqlConnection(myBuilder.ToString());
//			//try { myConnection.Open(); }
//			//catch { Console.WriteLine("Connection Failed"); }

//			//testdbDataContext db = new testdbDataContext();

//			//foreach (var obj in db.Customers.Where(c => c.last_name[0] == 'W').Select(c => new { First = c.first_name, Last = c.last_name })) {
//			//	Console.WriteLine("{0} {1}", obj.First, obj.Last);
//			//}
//			//var myQuery = from c in db.Customers
//			//				where c.last_name[0] == 'W'
//			//				select new { First = c.first_name, Last = c.last_name };
//			//var myQuery2 = from i in db.Invoices
//			//				where i.Customer.last_name[0] == 'W'
//			//				select new { First = i.Customer.first_name, Last = i.Customer.last_name, Purchase = i.purchase };
//			//foreach (var obj in myQuery2) {
//			//	Console.WriteLine("{0} {1} {2}", obj.First, obj.Last, obj.Purchase);
//			//}
//			//Console.WriteLine("{0}");
//			//foreach (Invoice i in db.Invoices) {
//			//	Console.WriteLine("{0} {1} {2}", i.Customer.first_name, i.Customer.last_name, i.purchase);
//			//}


//			//Console.WriteLine("This is my first git program");
//			//Console.WriteLine("This is some more stuff");
//			//Console.ReadLine();
//			//Console.WriteLine("Are there Changes now?");
//			//Console.WriteLine("This is a feature");
//			//Console.WriteLine("This is a feature too!");
//			//Console.WriteLine("They are all features!");
//			//Console.WriteLine("So I want to commit something too");
//			//Console.WriteLine("Lets try this again");
//			//hello_world.MyClass myObject = new MyClass(3, 4);
//			//Console.WriteLine("{0}", myObject.Hypotonuse);
//			//Console.ReadLine();
//			//Animal myAnimal = new Horse();
//			//myAnimal.Name = "El Dorado";
//			//Console.WriteLine("My horse's description --- {0}", myAnimal.Description);

//		}
//	}
//}
