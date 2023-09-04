using MyBlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.Business.Abstract
{
    public interface IGenericService<T>
    {
        List<T> GetList();
        T TGetById(int id);
        void TAdd(T t);
        void TDelete(T t);
        void TUpdate(T t);
    }
}
