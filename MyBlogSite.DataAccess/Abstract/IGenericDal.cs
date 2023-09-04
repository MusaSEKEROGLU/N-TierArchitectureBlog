using MyBlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DataAccess.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        List<T> GetList();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

        List<T> GetListAll(Expression<Func<T, bool>> filter);
    }
}
