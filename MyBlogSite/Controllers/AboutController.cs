using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Concrete;
using MyBlogSite.DataAccess.Concrete.EntityFramework;

namespace MyBlogSite.Controllers
{

	public class AboutController : Controller
	{
		AboutManager aboutManager = new AboutManager(new EfAboutRepository());
		public IActionResult Index()
		{
            var values = aboutManager.GetList();
            return View(values);
		}

		public PartialViewResult SocialMediaAbout()
		{			
			return PartialView();
		}
	}
}
