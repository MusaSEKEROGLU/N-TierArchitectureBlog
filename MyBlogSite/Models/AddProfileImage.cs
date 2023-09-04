using Microsoft.AspNetCore.Http;
using MyBlogSite.DataAccess.Migrations;

namespace MyBlogSite.Models
{
    public class AddProfileImage
    {
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public IFormFile WriterImage { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public bool WriterStatus { get; set; }
    }
}
//entities.concrete den farklı olarak =>  public IFormFile WriterImage { get; set; }
//Yazar fotoğraf ekleme class'ı