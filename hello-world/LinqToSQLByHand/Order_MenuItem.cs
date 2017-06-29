using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LinqToSQLByHand {
	[Table(Name = "Order_MenuItem")]
	public class Order_MenuItem {
		private int _order_id;
		private int _menuItem_id;

		[Column(Name = "[order_id]",Storage = "_order_id",CanBeNull = false, DbType = "INT NOT NULL")]
		public int Order_Id {
			get => _order_id;
			set {
				if (value != _order_id) {
					_order_id = value;
				}
			}
		}
		[Column(Name = "[menuItem_id]",Storage = "_menuItem_id",CanBeNull = false, DbType = "INT NOT NULL")]
		public int MenuItem_id {
			get => _menuItem_id;
			set {
				if (value != _menuItem_id) {
					_menuItem_id = value;
				}
			}
		}
	}
}
