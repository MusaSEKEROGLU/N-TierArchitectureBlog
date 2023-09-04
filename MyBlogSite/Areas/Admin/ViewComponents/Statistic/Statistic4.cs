using Microsoft.AspNetCore.Mvc;
using MyBlogSite.DataAccess.Concrete.Contexts;
using System.Linq;

namespace MyBlogSite.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        BlogContext blogContext = new BlogContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.admin = blogContext.Admins.Where(x => x.AdminID == 1)
                .Select(y => y.Name).FirstOrDefault();

            ViewBag.ımage = blogContext.Admins.Where(x => x.AdminID == 1)
                .Select(y => y.ImageURL).FirstOrDefault();

            ViewBag.description = blogContext.Admins.Where(x => x.AdminID == 1)
               .Select(y => y.ShortDescription).FirstOrDefault();

            return View();
        }
    }
}
