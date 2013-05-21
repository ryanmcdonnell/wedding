using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OurWedding.Web.ViewModels
{
	public class RsvpViewModel
	{
		[Required(ErrorMessage = "Please indicate if you'll be attending")]
		public bool Accepted { get; set; }

		[Required(ErrorMessage = "Please enter your full name")]
		[Display(Name = "Your full name")]
		public string GuestName { get; set; }

		[Display(Name = "Please enter the full names of any additional guests")]
		public string AdditionalGuestNames { get; set; }

		[Display(Name = "I promise to dance if you play...")]
		public string SongRequest { get; set; }

		[Display(Name = "Any comments or questions?")]
		public string Comments { get; set; }
	}
}