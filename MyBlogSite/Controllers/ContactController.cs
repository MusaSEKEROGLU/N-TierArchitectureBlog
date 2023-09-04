using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Concrete;
using MyBlogSite.DataAccess.Concrete.EntityFramework;
using MyBlogSite.Entities.Concrete;
using System;

namespace MyBlogSite.Controllers
{
    [AllowAnonymous]
	public class ContactController : Controller
    {
        ContactManager contactManager= new ContactManager(new EfContactRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            contact.ContactStatus = true;
            contactManager.ContactAdd(contact);
            return RedirectToAction("Index","Blog");
        }
    }
}
