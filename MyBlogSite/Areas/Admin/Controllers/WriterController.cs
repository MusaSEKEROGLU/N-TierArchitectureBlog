using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Areas.Admin.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.Collections.Generic;
using System.Linq;

namespace MyBlogSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //Tüm Yazarlar
        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        //ID'ye Yazarlar
        public IActionResult GetWriterByID(int writerid)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == writerid);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }

        //Yazar Ekleme
        [HttpPost]
        public IActionResult AddWriter(WriterCls w)
        {
            writers.Add(w);
            var jsonWriters = JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
        }

        //Yazar Güncelleme
        public IActionResult UpdateWriter(WriterCls w)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == w.Id);
            findWriter.Name = w.Name;
            var jsonWriters = JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
        }

        //Yazar Silme
        public IActionResult DeleteWriter(int id)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(findWriter);
            return Json(findWriter);

        }

        public static List<WriterCls> writers = new List<WriterCls>
        {
            new WriterCls
            {
                Id = 1,
                Name = "Musa ŞEKEROĞLU"
            },
             new WriterCls
            {
                Id = 2,
                Name = "Ayşe ŞEKEROĞLU"
            },
             new WriterCls
            {
                Id = 3,
                Name = "Elif Deren ŞEKEROĞLU"
            },
             new WriterCls
            {
                Id = 4,
                Name = "Tamay Lina ŞEKEROĞLU"
            },
        };
    }
}
