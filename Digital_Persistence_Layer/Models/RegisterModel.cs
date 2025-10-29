using System.ComponentModel.DataAnnotations;

namespace Digital_Persistence_Layer.Models
{
	public class RegisterModel
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		[Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
		public string ConfirmPassword { get; set; }
	}
}
