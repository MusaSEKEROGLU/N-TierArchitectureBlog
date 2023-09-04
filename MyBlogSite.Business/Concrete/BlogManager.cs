using MyBlogSite.Business.Abstract;
using MyBlogSite.DataAccess.Abstract;
using MyBlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.Business.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }                 
     
		public List<Blog> GetLast3Blog() //footer daki son gönderiler için
		{
			return _blogDal.GetList().Take(3).ToList();
		}
		public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }
        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetListAll(x => x.WriterID == id);
        }
        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.GetListAll(x => x.BlogID == id);
        }


        public List<Blog> GetList()
        {
           return _blogDal.GetList();
        }
        public Blog TGetById(int id)
        {
            return _blogDal.GetById(id);
        }
        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id); //categorilerin adını getirmek   BlogListByWriter.cshtml
        }
    }
}
