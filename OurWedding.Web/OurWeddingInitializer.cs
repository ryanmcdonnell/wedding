using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OurWedding.Web
{
	public class OurWeddingContextInitializer : DropCreateDatabaseIfModelChanges<OurWeddingContext>
	{
		protected override void Seed(OurWeddingContext context)
		{
			base.Seed(context);
		}
	}
}