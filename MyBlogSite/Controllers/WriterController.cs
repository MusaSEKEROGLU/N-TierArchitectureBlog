using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Concrete;
using MyBlogSite.Business.Validations;
using MyBlogSite.DataAccess.Concrete.EntityFramework;
using MyBlogSite.Entities.Concrete;
using System.Reflection.Metadata;
using System;
using MyBlogSite.Models;
using System.IO;
using MyBlogSite.DataAccess.Concrete.Contexts;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace MyBlogSite.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        BlogContext blogContext = new BlogContext();
        UserManager um = new UserManager(new EfUserRepository());
        private readonly UserManager<AppUser> _userManager;
        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            //login olan yazarın mail ve adını getirme
            var userMail = User.Identity.Name; 
            ViewBag.useremail = userMail;

            var writerName = blogContext.Writers.Where(x => x.WriterMail == userMail)
                .Select(y => y.WriterName).FirstOrDefault();
            ViewBag.userename = writerName;

            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }

       
        public IActionResult Test()
        {
            return View();
        }

    
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

  
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

  
        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {         
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.namesurname = value.NameSurname;
            model.mail = value.Email;
            model.imageurl = value.ImageUrl;
            model.username = value.UserName;           
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            value.NameSurname = model.namesurname;
            value.Email = model.mail;
            value.ImageUrl = model.imageurl;
            value.UserName = model.username;
            value.PasswordHash = _userManager.PasswordHasher.HashPassword(value, model.password);
            var result = await _userManager.UpdateAsync(value);
            return RedirectToAction("Index", "Dashboard");                      
        }

      
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
      
        [HttpPost] //Dosyadan Resim Ekleme
        public IActionResult WriterAdd(AddProfileImage writer)
        {
            Writer wtr = new Writer();
            if (writer != null)
            {
                var extension = Path.GetExtension(writer.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location =Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                writer.WriterImage.CopyTo(stream);
                wtr.WriterImage =newimagename;
            }
            wtr.WriterMail = writer.WriterMail;
            wtr.WriterName = writer.WriterName;
            wtr.WriterPassword = writer.WriterPassword;
            wtr.WriterStatus = true;
            wtr.WriterAbout = writer.WriterAbout;
            writerManager.TAdd(wtr);
            return RedirectToAction("Index", "Dashboard");
        }       
    }
}
