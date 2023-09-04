using MyBlogSite.DataAccess.Abstract;
using MyBlogSite.DataAccess.Repositories;
using MyBlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryRepository : GenericRepository<Category>, ICategoryDal
    {

    }
}
