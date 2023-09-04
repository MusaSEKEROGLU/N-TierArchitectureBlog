using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Concrete;
using MyBlogSite.DataAccess.Concrete.Contexts;
using MyBlogSite.DataAccess.Concrete.EntityFramework;
using System.Linq;
using System.Xml.Linq;

namespace MyBlogSite.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        BlogContext blogContext = new BlogContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.toplamBlog = blogManager.GetList().Count();
            ViewBag.toplamMesaj = blogContext.Contacts.Count();
            ViewBag.toplamYorum = blogContext.Comments.Count();

            //APİ'den hava durumu bilgisi almak
            string api = "992d2a6c3cf7609bbafefe3d3fe3a057";
            string url = "https://api.openweathermap.org/data/2.5/weather?q=ankara&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(url);
            ViewBag.havadurumu = document.Descendants("temperature")
                .ElementAt(0).Attribute("value").Value; 

            return View();
        }
    }
}
