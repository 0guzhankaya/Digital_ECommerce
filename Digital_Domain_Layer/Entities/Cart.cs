using Digital_Domain_Layer.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital_Domain_Layer.Entities
{
	public class Cart : BaseEntity
	{
		[ForeignKey(nameof(User))]
		public string UserId { get; set; }
		public virtual User User { get; set; }
		public virtual ICollection<Product> Products { get; set; }
	}
}
