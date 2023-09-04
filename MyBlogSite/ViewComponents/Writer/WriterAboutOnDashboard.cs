using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Concrete;
using MyBlogSite.DataAccess.Concrete.Contexts;
using MyBlogSite.DataAccess.Concrete.EntityFramework;
using MyBlogSite.Entities.Concrete;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogSite.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        BlogContext blogContext = new BlogContext();
		public IViewComponentResult Invoke()
        {         
            var username = User.Identity.Name;
            ViewBag.username = username;
            var userMail = blogContext.Users.Where(x => x.UserName == username)
                  .Select(y => y.Email).FirstOrDefault();
            var writerID = blogContext.Writers.Where(x => x.WriterMail == userMail)
                .Select(y => y.WriterID).FirstOrDefault();         
            var values = writerManager.GetWriterById(writerID);
            return View(values);
        }
    }
}
