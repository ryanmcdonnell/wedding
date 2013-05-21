using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using OurWedding.Web.Models;
using OurWedding.Web.ViewModels;

namespace OurWedding.Web.Controllers
{
	public class HomeController : Controller
	{
		//
		// GET: /Home/

		public ActionResult Index()
		{
			return View(new RsvpViewModel());
		}


		[HttpPost]
		public PartialViewResult Rsvp(RsvpViewModel model)
		{
			if (ModelState.IsValid)
			{
				using (var context = new OurWeddingContext())
				{
					var rsvp = new Rsvp
						{
							Accepted = model.Accepted,
							GuestName = model.GuestName,
							AdditionalGuestNames = model.AdditionalGuestNames,
							SongRequest = model.SongRequest,
							Comments = model.Comments,
							ReceivedOn = DateTimeOffset.UtcNow
						};
					context.Rsvps.Add(rsvp);
					context.SaveChanges();

					SendEmail(rsvp);

					return new PartialViewResult { ViewName = "RsvpSuccess" };
				}
			}

			return new PartialViewResult { ViewName = "RsvpError" };
		}

		private static void SendEmail(Rsvp rsvp)
		{
			using (var message = new MailMessage())
			{
				message.To.Add(new MailAddress(ConfigurationManager.AppSettings["RsvpEmailRecipient"]));
				message.From = new MailAddress(ConfigurationManager.AppSettings["RsvpEmailSender"]);
				message.Subject = "RSVP received from " + rsvp.GuestName;

				var sb = new StringBuilder();
				sb.AppendLine(String.Format("ID: {0}", rsvp.Id));
				sb.AppendLine(String.Format("Received on {0:d} {0:t}", rsvp.ReceivedOn));
				sb.AppendLine(rsvp.Accepted ? "Accepted" : "Declined");
				sb.AppendLine(String.Format("Guest name: {0}", rsvp.GuestName));
				sb.AppendLine(String.Format("Additional Guest(s): {0}", rsvp.AdditionalGuestNames));
				sb.AppendLine(String.Format("Song request: {0}", rsvp.SongRequest));
				sb.AppendLine(String.Format("Comments or questions: {0}", rsvp.Comments));
				message.Body = sb.ToString();

				using (var smtp = new SmtpClient())
				{
					smtp.Host = ConfigurationManager.AppSettings["SmtpServer"];
					smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
					smtp.EnableSsl = (ConfigurationManager.AppSettings["SmtpUseSSL"] == "true");
					smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SmtpUsername"],
															 ConfigurationManager.AppSettings["SmtpPassword"]);

					smtp.Send(message);
				}
			}
		}
	}
}
