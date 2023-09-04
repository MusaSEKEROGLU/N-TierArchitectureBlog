using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Concrete;
using MyBlogSite.DataAccess.Concrete.EntityFramework;
using MyBlogSite.Entities.Concrete;

namespace MyBlogSite.Controllers
{
	[AllowAnonymous]
	public class NewsLetterController : Controller
	{//Abone Olma
		NewsLetterManager letterManager = new NewsLetterManager(new EfNewsLetterRepository());

		[HttpGet]
		public PartialViewResult SubscribeMail()
		{
			return PartialView();
		}

		[HttpPost]
		public IActionResult SubscribeMail(NewsLetter newsLetter)
		{
			newsLetter.MailStatus = true;
			letterManager.AddNewsLetter(newsLetter);
			return PartialView();
		}
	}
}
