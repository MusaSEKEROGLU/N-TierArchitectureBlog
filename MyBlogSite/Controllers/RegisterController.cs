using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Concrete;
using MyBlogSite.Business.Validations;
using MyBlogSite.DataAccess.Concrete.EntityFramework;
using MyBlogSite.Entities.Concrete;


namespace MyBlogSite.Controllers
{
	//Writer Register
	public class RegisterController : Controller
	{
		WriterManager _writerManager = new WriterManager(new EfWriterRepository());

		[HttpGet] //sayfa yüklenince çalışır/örnek:getlist gibi örneklerde kullanılabilir
		public IActionResult Index()
		{			
			return View();
		}

		[HttpPost] //sayfada buton tetiklenince çalışır
		public IActionResult Index(Writer writer)
		{
			WriterValidator writerValidator = new WriterValidator();//Business-validations
			ValidationResult result = writerValidator.Validate(writer);//using FluentValidation.Results;
			if (result.IsValid)
			{
				writer.WriterStatus = true;
				writer.WriterAbout = "Deneme Test";
				_writerManager.TAdd(writer);
				return RedirectToAction("Index", "Blog");
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
	}
}
