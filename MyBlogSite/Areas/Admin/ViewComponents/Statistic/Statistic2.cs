using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Concrete;
using MyBlogSite.DataAccess.Concrete.Contexts;
using MyBlogSite.DataAccess.Concrete.EntityFramework;
using System.Linq;

namespace MyBlogSite.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {       
        BlogContext blogContext = new BlogContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.sonEklenenBlog = blogContext.Blogs
                .OrderByDescending(x => x.BlogID).Select(x => x.BlogTitle).Take(1).FirstOrDefault();         
            return View();
        }
    }
}
