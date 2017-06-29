using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LinqToSQLByHand {
	[Table(Name = "Order")]
	public class Order {
		private int _id;
		private int _customer_id;

		[Column(Name = "[id]", AutoSync = AutoSync.OnInsert, CanBeNull = false,  DbType = "INT NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, Storage = "_id")]
		public int Id {
			get => _id;
			set => _id = value;
		}

		[Column(Name = "[customer_id]",Storage = "_customer_id",CanBeNull = false, DbType = "INT NOT NULL")]
		[Association(Name = "FK_Order_Customer", IsForeignKey = true, ThisKey = "Customer_Id", OtherKey = "id", Storage = "_customer_id", IsUnique = false)]
		public int Customer_Id {
			get => _customer_id;
			set {
				if (value != _customer_id) {
					_customer_id = value;
				}
			}
		}
	}
}
