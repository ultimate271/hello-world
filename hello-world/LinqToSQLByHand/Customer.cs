using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LinqToSQLByHand {
	[Table(Name = "[dbo].[Customer]")]
	public class Customer {
		private int _id;
		private string _firstName;
		private const int _firstNameMaxl = 20;
		private string _lastName;
		private const int _lastNameMaxl = 20;


		[Column(Name = "[id]", AutoSync = AutoSync.OnInsert, CanBeNull = false,  DbType = "INT NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, Storage = "_id")]
		public int Id {
			get => _id;
			set => _id = value;
		}

		[Column(Name = "[FirstName]",Storage = "_firstName",CanBeNull = false, DbType = "NCHAR(20) NOT NULL")]
		public string FirstName {
			get => _firstName;
			set {
				if (value != _firstName) {
					if (value.Length < _firstNameMaxl) {
						_firstName = value;
					}
					else {
						throw new System.Exception($"Tried to set firstname (max bound {_firstNameMaxl}) in customer to {value} which is {value.Length} characters in length");
					}
				}
			}
		}

		[Column(Name = "[LastName]",Storage = "_lastName",CanBeNull = false, DbType = "NCHAR(20) NOT NULL")]
		public string LastName {
			get => _lastName;
			set {
				if(value != _lastName) {
					if (value.Length <= _lastNameMaxl) {
						_lastName = value;
					}
					else {
						throw new System.Exception($"Tried to set lastname (max bound {_lastNameMaxl}) in customer to {value} which is {value.Length} characters in length");
					}
				}
			}
		}
	}
}
