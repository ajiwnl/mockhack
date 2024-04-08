using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestCRUD.Models
{
	public class Listing
	{
		[Key]
		[Required]
		[StringLength(50)]
		public string? ESTABNAME { get; set; }

		[Required]
		[StringLength(255)]
		public string? ESTABDESC { get; set; }

		[Required]
		[StringLength(50)]
		public string? ESTABADD { get; set; }

		[Required]
		public int? ACCOMODATION { get; set; }

		public int? ESTABHRPRICE { get; set; }

		public int? ESTABDAYPRICE { get; set; }

		public int? ESTABWKPRICE { get; set; }

		public int? ESTABMONPRICE { get; set; }

		public string OwnerUsername { get; set; }

		public string Actvity1 { get; set; }

		public string Actvity2 { get; set; }

		public string Actvity3 { get; set; }

		public string Actvity4 { get; set; }

		[Required]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
		public DateTime STARTTIME { get; set; }

		[Required]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
		public DateTime ENDTIME { get; set; }


		//<---For Photo Verification--->
		[StringLength(255)]
		public string? ESTABIMAGEPATH { get; set; }

		[NotMapped]
		public IFormFile? ESTABIMG { get; set; }

		//<---For Photo Verificaiton--->
		[StringLength(255)]
		public string? VERIMAGEPATH { get; set; }

		[NotMapped]
		public IFormFile? VERIMG { get; set; }

	}

}
