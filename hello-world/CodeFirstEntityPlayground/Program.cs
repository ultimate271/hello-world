using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeFirstEntityPlayground {
	class Program {
		static void Main(string[] args) {
			using (MyContext db = new MyContext()) {
				db.Parents.Add(new Daughter() { Name = "Susy", Knees = 4 });
				db.Parents.Add(new Son() { Name = "Jimmy", Elbows = 6, Arms = 3 });
				db.SaveChanges();
			}
		}
	}
	public class Parent {
		public int ParentID { get; set; }
		public string Name { get; set; }
	}
	public class Son : Parent{
		public int Elbows { get; set; }
		public int Arms { get; set; }
		public bool Penis { get; set; }
	}
	public class Daughter : Parent {
		public int Knees { get; set; }
		public int Legs { get; set; }
	}
	public class MyContext : DbContext {
		public virtual DbSet<Parent> Parents { get; set; }
	}
}
