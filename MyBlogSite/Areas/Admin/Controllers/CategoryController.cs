using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlogSite.Business.Concrete;
using MyBlogSite.Business.Validations;
using MyBlogSite.DataAccess.Concrete.Contexts;
using MyBlogSite.DataAccess.Concrete.EntityFramework;
using MyBlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using X.PagedList;
namespace MyBlogSite.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        BlogContext blogContext = new BlogContext();
        public IActionResult Index(int page=1)
        {
            var values = categoryManager.GetList().ToPagedList(page,5);
            return View(values);
        }
      
        [HttpGet]
        public IActionResult CategoryAdd()
        {     
            return View();
        }   
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {         
            CategoryValidator categoryValidator = new CategoryValidator();//Business-validations
            ValidationResult result = categoryValidator.Validate(p);
            if (result.IsValid)
            {
                p.CategoryStatus = true;                        
                categoryManager.TAdd(p);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

      //Pasif Yapma
        public IActionResult CategoryDelete(int id)
        {
         var value = categoryManager.TGetById(id);
            categoryManager.TDelete(value);
            return RedirectToAction("Index", "Category");
        }    
    }
}
