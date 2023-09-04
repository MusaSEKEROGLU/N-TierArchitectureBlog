using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlogSite.Business.Concrete;
using MyBlogSite.DataAccess.Concrete.Contexts;
using MyBlogSite.DataAccess.Concrete.EntityFramework;
using MyBlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlogSite.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager messageManager = new Message2Manager(new EfMessage2Repository());
        BlogContext blogContext = new BlogContext();
        public IActionResult InBox() //gelen mesaj
        {
            var username = User.Identity.Name;
            var userMail = blogContext.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = blogContext.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault(); 
            var values = messageManager.GetInBoxListByWriter(writerID);
            return View(values);
        }

        public IActionResult SendBox() //gelen mesaj
        {
            var username = User.Identity.Name;
            var userMail = blogContext.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = blogContext.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var values = messageManager.GetSendBoxWithMessageByWriter(writerID);
            return View(values);
        }
        //mesaj detayları     
        public IActionResult MesajDetails(int id)
        {
            var mesajValue = messageManager.TGetById(id);      
            return View(mesajValue);
        }

        [HttpGet]
        public IActionResult NewMesajSend()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewMesajSend(Message2 p)
        {
            var username = User.Identity.Name;
            var userMail = blogContext.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = blogContext.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault(); 
            p.SenderID = writerID;
            p.ReceiverID = 3;
            p.MessageStatus = true;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            messageManager.TAdd(p);
            return RedirectToAction("InBox","Message");
        }
    }
}
