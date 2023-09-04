using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Concrete;
using MyBlogSite.DataAccess.Concrete.EntityFramework;
using MyBlogSite.Entities.Concrete;
using System;
using System.Linq;

namespace MyBlogSite.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository());  
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }

        [HttpPost]		
		public PartialViewResult PartialAddComment(Comment comment)
		{
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            comment.BlogID = 3;
            commentManager.CommentAdd(comment);
			return PartialView();
		}

		public PartialViewResult CommentListByBlog(int id)
        {         
            var values = commentManager.GetList(id);
            return PartialView(values);
        }
    }
}
