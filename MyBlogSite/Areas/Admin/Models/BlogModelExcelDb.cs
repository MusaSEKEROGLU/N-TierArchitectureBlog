using System;

namespace MyBlogSite.Areas.Admin.Models
{
    //db den excel'e çekme Dynamic database den çek
    public class BlogModelExcelDb
    {
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus{ get; set; }
    }
}
