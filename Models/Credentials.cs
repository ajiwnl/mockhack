using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace TestCRUD.Models
{
	public class Credentials
	{
		[Key, Column(Order = 0)]
		[Required]
		[StringLength(20)]
		public string? Username { get; set; }

		[Required]
		[StringLength(20)]
		public string? Password { get; set; }
	}
}