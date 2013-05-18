using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OurWedding.Web.ViewModels
{
	public class RsvpViewModel
	{
		[Required]
		public bool Accepted { get; set; }

		[Required]
		[Display(Name = "Your name")]
		public string GuestName { get; set; }

		public string AdditionalGuestNames { get; set; }
		public string SongRequest { get; set; }
		public string Comments { get; set; }
	}
}