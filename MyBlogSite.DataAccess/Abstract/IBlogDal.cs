using MyBlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DataAccess.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        //Blog hangi category ye bağlı ise o category i getir
        List<Blog> GetListWithCategory();
        List<Blog> GetListWithCategoryByWriter(int id); //yazar ıd ye göre categorilerin adını getirmek   BlogListByWriter.cshtml
    }
}
