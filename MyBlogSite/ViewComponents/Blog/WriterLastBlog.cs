using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Concrete;
using MyBlogSite.DataAccess.Concrete.EntityFramework;

namespace MyBlogSite.ViewComponents.Blog
{
	public class WriterLastBlog : ViewComponent
	{
		BlogManager blogManager = new BlogManager(new EfBlogRepository());
		public IViewComponentResult Invoke()
		{
			var values = blogManager.GetBlogListByWriter(1);
			return View(values);
		}
	}
}

//PartialView ler için
