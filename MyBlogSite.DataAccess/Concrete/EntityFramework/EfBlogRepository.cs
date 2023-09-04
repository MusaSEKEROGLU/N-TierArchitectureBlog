using Microsoft.EntityFrameworkCore;
using MyBlogSite.DataAccess.Abstract;
using MyBlogSite.DataAccess.Concrete.Contexts;
using MyBlogSite.DataAccess.Repositories;
using MyBlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DataAccess.Concrete.EntityFramework
{

    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        //Blog hangi category ye bağlı ise o category i getir
        public List<Blog> GetListWithCategory()
        {
            using (var context = new BlogContext())
            {
                return context.Blogs.Include(x => x.Category).ToList();

            }
        }
         
        //yazar ıd ye göre categorilerin adını getirmek   BlogListByWriter.cshtml
        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var context = new BlogContext())
            {
                return context.Blogs.Include(x => x.Category).Where(x=>x.WriterID == id).ToList();

            }
        }
    }
}
