using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Concrete;
using MyBlogSite.DataAccess.Concrete.EntityFramework;

namespace MyBlogSite.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager manager = new CategoryManager(new EfCategoryRepository());   
        public IActionResult Index()
        {
            var values = manager.GetList();
            return View(values);
        }
    }
}
