using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.DataAccess.Concrete.Contexts;
using System.Linq;

namespace MyBlogSite.Controllers
{   
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            BlogContext blogContext = new BlogContext();

            var username = User.Identity.Name;  
            
            var userMail = blogContext.Users.Where(x => x.UserName == username)
                  .Select(y => y.Email).FirstOrDefault();

            var witerID = blogContext.Writers.Where(x => x.WriterMail == userMail)
                .Select(y => y.WriterID).FirstOrDefault();

            ViewBag.ToplamBlogSayısı = blogContext.Blogs.Count().ToString();

            ViewBag.SizinBlogSayınız = blogContext.Blogs.Where(x => x.WriterID == witerID).Count();

            ViewBag.ToplamKategoriSayısı = blogContext.Categories.Count().ToString();
            return View();
        }
    }
}
