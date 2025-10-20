using Digital_Domain_Layer.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital_Domain_Layer.Entities
{
	public class ProductImage : BaseEntity
	{
		[ForeignKey(nameof(Product))]
		public Guid ProductId { get; set; }
		public virtual Product Product { get; set; }
	}
}
