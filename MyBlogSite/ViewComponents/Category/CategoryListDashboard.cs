using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Concrete;
using MyBlogSite.DataAccess.Concrete.EntityFramework;

namespace MyBlogSite.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var values = categoryManager.GetList();
            return View(values);
        }
    }
}
