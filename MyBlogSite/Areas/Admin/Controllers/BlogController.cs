using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Areas.Admin.Models;
using MyBlogSite.DataAccess.Concrete.Contexts;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyBlogSite.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class BlogController : Controller
    {
        //verileri excel'e çekmek-Static değer vererek
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var worksSheet = workBook.Worksheets.Add("Blog Listesi"); //sayfa başlığı excel
                worksSheet.Cell(1,1).Value = "Blog ID";    //1.satır 1.sütün excel
                worksSheet.Cell(1,2).Value = "Blog Name"; //1.satır 2.sütün excel
                int blogRowCount = 2;  //2.satırdan itibaren yaz
                foreach (var item in GetBlogList())
                {
                    worksSheet.Cell(blogRowCount, 1).Value = item.ID;
                    worksSheet.Cell(blogRowCount, 2).Value = item.BlogName;
                    blogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                        ,"BlogCalisma.xlsx"); //excel adresi
                }
            }          
        }
        List<BlogModelExcel> GetBlogList()
        {
            List<BlogModelExcel> bME = new List<BlogModelExcel>
            {
                new BlogModelExcel{ID=1,BlogName="Asp.Net Core"},
                new BlogModelExcel{ID=2,BlogName="Asp.Net"},
                new BlogModelExcel{ID=3,BlogName="C#"}
            };
            return bME;
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }


        //verileri db den excel'e çekme-Dynamic otomatik database den 
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workBook2 = new XLWorkbook())
            {
                var worksSheet2 = workBook2.Worksheets.Add("Blog Listesi Database"); 
                worksSheet2.Cell(1, 1).Value = "BlogID";    
                worksSheet2.Cell(1, 2).Value = "BlogTitle";
                worksSheet2.Cell(1, 3).Value = "BlogContent"; 
                worksSheet2.Cell(1, 4).Value = "BlogThumbnailImage"; 
                worksSheet2.Cell(1, 5).Value = "BlogImage"; 
                worksSheet2.Cell(1, 6).Value = "BlogCreateDate"; 
                worksSheet2.Cell(1, 7).Value = "BlogStatus"; 

                int blogRowCount2 = 2;  
                foreach (var item in GetBlogListDb())
                {
                    worksSheet2.Cell(blogRowCount2, 1).Value = item.BlogID;
                    worksSheet2.Cell(blogRowCount2, 2).Value = item.BlogTitle;
                    worksSheet2.Cell(blogRowCount2, 3).Value = item.BlogContent;
                    worksSheet2.Cell(blogRowCount2, 4).Value = item.BlogThumbnailImage;
                    worksSheet2.Cell(blogRowCount2, 5).Value = item.BlogImage;
                    worksSheet2.Cell(blogRowCount2, 6).Value = item.BlogCreateDate;
                    worksSheet2.Cell(blogRowCount2, 7).Value = item.BlogStatus;                 
                    blogRowCount2++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook2.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                        , "BlogCalisma.xlsx");
                }
            }       
        }
        List<BlogModelExcelDb> GetBlogListDb()
        {
            List<BlogModelExcelDb> bME2 = new List<BlogModelExcelDb>();
            using (var context = new BlogContext())
            {
                bME2 = context.Blogs.Select(x => new BlogModelExcelDb
                {
                    BlogID = x.BlogID,
                    BlogTitle = x.BlogTitle,
                    BlogContent = x.BlogContent,
                    BlogThumbnailImage = x.BlogThumbnailImage,
                    BlogImage = x.BlogImage,
                    BlogCreateDate = x.BlogCreateDate,
                    BlogStatus = x.BlogStatus
                }).ToList();
            }
            return bME2;
        }
        public IActionResult BlogListExcelDb()
        {
            return View();
        }
    }  
}
