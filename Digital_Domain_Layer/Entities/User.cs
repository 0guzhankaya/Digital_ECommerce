using Microsoft.AspNetCore.Identity;

namespace Digital_Domain_Layer.Entities
{
	public class User : IdentityUser
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public virtual Cart UserCart { get; set; }
		public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
		public virtual ICollection<Checkout> Checkouts { get; set; } = new List<Checkout>();
	}
}
