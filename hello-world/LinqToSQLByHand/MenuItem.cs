using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LinqToSQLByHand {
	[Table(Name = "MenuItem")]
	public class MenuItem {
		private int _id;
		private string _name;
		private const int _nameMaxl = 20;
		private decimal _cost;

		[Column(Name = "[id]", AutoSync = AutoSync.OnInsert, CanBeNull = false,  DbType = "INT NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, Storage = "_id")]
		public int Id {
			get => _id;
			set => _id = value;
		}

		[Column(Name = "[FirstName]",Storage = "_firstName",CanBeNull = false, DbType = "NCHAR(20) NOT NULL")]
		public string Name {
			get => _name;
			set {
				if (value != _name) {
					if (value.Length < _nameMaxl) {
						_name = value;
					}
					else {
						throw new System.Exception($"Tried to set firstname (max bound {_nameMaxl}) in customer to {value} which is {value.Length} characters in length");
					}
				}
			}
		}

		[Column(Name = "[customer_id]",Storage = "_cost",CanBeNull = false, DbType = "DECIMAL(16,2) NOT NULL")]
		public decimal Cost {
			get => _cost;
			set {
				if (value != _cost) {
					_cost = value;
				}
			}
		}

	}
}
