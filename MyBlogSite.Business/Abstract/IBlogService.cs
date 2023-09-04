using MyBlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.Business.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {             
        List<Blog> GetBlogListWithCategory();	//bloglara ait category leri getir	
        List<Blog> GetBlogListByWriter(int id);   //bloglara ait writer leri getir	id ye göre        

    }
}
