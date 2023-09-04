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

namespace MyBlogSite.Controllers
{
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        BlogContext blogContext = new BlogContext();
        //blog detay sayfasında kategorileri listelemek

        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }
        //blog detay sayfasına anasayfada tıklanan bloğu getirmek

        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.usernamegetir = id;
            var values = blogManager.GetBlogByID(id);
            return View(values);
        }

        //yazar ıd ye göre hem blogları getirmek hemde kategorileri isimleriyle birlikte getirmek
        public IActionResult BlogListByWriter()
        {
            //GİRİŞ YAPAN KİŞİNİN BLOGLARINI LİSTELER
            var username = User.Identity.Name;
            var userMail = blogContext.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = blogContext.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = blogManager.GetListWithCategoryByWriter(writerID);
            return View(values);
        }

        [HttpGet] //kategorileri dropdown'a getirme
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryValues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.category = categoryValues;
            return View();
        }

        [HttpPost] //Blog ekleme
        public IActionResult BlogAdd(Blog blog)
        {
            //BLOG EKLEME İŞLEMİNDE ID LERİ OTOMATİK GİRİŞ YAPAN KİŞİYE GÖRE EKLER
            var username = User.Identity.Name;
            var userMail = blogContext.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = blogContext.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            BlogValidator blogValidator = new BlogValidator();//Business-validations
            ValidationResult result = blogValidator.Validate(blog);//using FluentValidation.Results;
            if (result.IsValid)
            {
                blog.BlogStatus = true;
                blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());              
                blog.WriterID = writerID;
                blogManager.TAdd(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
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

		//Blog silme
		public IActionResult BlogDelete(int id)
        {
            var blogValue = blogManager.TGetById(id);
            blogManager.TDelete(blogValue);
			return RedirectToAction("BlogListByWriter");
		}

        //Blog güncelleme-kategorileri dropdown'a getirme
        [HttpGet]
		public IActionResult EditBlog(int id)
		{
            var blogValue = blogManager.TGetById(id);
            List<SelectListItem> categoryValues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.category = categoryValues;
            return View(blogValue);
		}

		[HttpPost]
		public IActionResult EditBlog(Blog blog)
		{
            var username = User.Identity.Name;
            var userMail = blogContext.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = blogContext.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault(); ;
            blog.WriterID = writerID;        
            blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            blogManager.TUpdate(blog);
            return RedirectToAction("BlogListByWriter");
		}
	}
}
