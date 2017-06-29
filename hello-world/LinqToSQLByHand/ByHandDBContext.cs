using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Data;

namespace LinqToSQLByHand {
	[Database(Name = "LinqPlayground")]
	public class ByHandDBContext : DataContext {
		public ByHandDBContext() : base(System.Configuration.ConfigurationManager.ConnectionStrings["LinqToSQLByHand.Properties.Settings.LinqPlaygroundConnectionString"].ConnectionString) {
		}

		public ByHandDBContext(string fileOrServerOrConnection) : base(fileOrServerOrConnection) {
		}

		public ByHandDBContext(IDbConnection connection) : base(connection) {
		}

		public ByHandDBContext(string fileOrServerOrConnection, MappingSource mapping) : base(fileOrServerOrConnection, mapping) {
		}

		public ByHandDBContext(IDbConnection connection, MappingSource mapping) : base(connection, mapping) {
		}

		public Table<Customer> Customers {
			get => this.GetTable<Customer>();
		}
		public Table<Order> Orders {
			get => this.GetTable<Order>();
		}
		public Table<MenuItem> MenuItems {
			get => this.GetTable<MenuItem>();
		}
		public Table<Order_MenuItem> Order_MenuItem {
			get => this.GetTable<Order_MenuItem>();
		}
	}
}
