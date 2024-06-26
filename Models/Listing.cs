﻿using System.ComponentModel.DataAnnotations.Schema;
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


		[Required]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
		public DateTime STARTTIME { get; set; }

		[Required]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
		public DateTime ENDTIME { get; set; }


		[StringLength(255)]
		public string? ESTABIMAGEPATH { get; set; }

		[NotMapped]
		public IFormFile? ESTABIMG { get; set; }

	}

}