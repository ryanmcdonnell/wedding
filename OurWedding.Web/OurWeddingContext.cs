using System.Data.Entity;
using OurWedding.Web.Models;

namespace OurWedding.Web
{
	public class OurWeddingContext : DbContext
	{
		public OurWeddingContext() : base("name=OurWeddingContext") { }

		public DbSet<Rsvp> Rsvps { get; set; }
	}
}