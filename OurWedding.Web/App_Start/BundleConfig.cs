using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace OurWedding.Web
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle("~/Content/foundation/all")
				.Include("~/Content/foundation/normalize.css")
				.Include("~/Content/foundation/foundation.css")
				.Include("~/Content/foundation/foundation.mvc.css")
				.Include("~/Content/foundation/union.css")
				.Include("~/Content/foundation/nav.css")
				.Include("~/Content/foundation/app.css")
				);

			bundles.Add(new ScriptBundle("~/bundles/jquery")
				.Include("~/Scripts/jquery-{version}.js")
				);

			bundles.Add(new ScriptBundle("~/bundles/modernizr")
				.Include("~/Scripts/modernizr-{version}.js")
				);

			bundles.Add(new ScriptBundle("~/bundles/foundation")
				.Include("~/Scripts/foundation/foundation.js")
				.Include("~/Scripts/foundation/foundation.*")
				);
		}
	}
}