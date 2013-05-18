using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OurWedding.Web.Models
{
	public class Rsvp : Entity
	{
		public bool Accepted { get; set; }
		public DateTimeOffset ReceivedOn { get; set; }
		public string GuestName { get; set; }
		public string AdditionalGuestNames { get; set; }
		public string SongRequest { get; set; }
		public string Comments { get; set; }
	}
}