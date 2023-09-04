using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Models;
using System.Collections.Generic;

namespace MyBlogSite.ViewComponents
{
	public class CommentList : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			//var commentValues = new List<UserComment>
			//{
			//	new UserComment
			//	{
			//		ID = 1,
			//		UserName = "Musa",
			//	},
			//	new UserComment
			//	{
			//		ID = 2,
			//		UserName = "Ayse",
			//	},
			//	new UserComment
			//	{
			//		ID = 3,
			//		UserName = "DerenTamay",
			//	}
			//};
			return View();
		}
	}
}
//PartialView ler için, kullanmadık deneme amaçlıydı
