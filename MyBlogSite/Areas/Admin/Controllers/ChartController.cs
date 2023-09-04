using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Areas.Admin.Models;
using System.Collections.Generic;

namespace MyBlogSite.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
           List<Categorycls> list = new List<Categorycls>();
            list.Add(new Categorycls
            {
                categoryname = "C#",
                categorycount = 5,
            });
            list.Add(new Categorycls
            {
                categoryname = "ASP.NET CORE",
                categorycount = 5,
            });
            list.Add(new Categorycls
            {
                categoryname = "JAVASCRIPT",
                categorycount = 5,
            });
            list.Add(new Categorycls
            {
                categoryname = "ASP.NET MVC",
                categorycount = 5,
            });
            list.Add(new Categorycls
            {
                categoryname = "ASP.NET",
                categorycount = 5,
            });
            return Json(new {jsonlist= list});
        }
    }
}
