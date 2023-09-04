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
    public class AdminManager : IAdminService
    {
        IAdmintDal _adminDal;
        public AdminManager(IAdmintDal adminDal)
        {
            _adminDal = adminDal;
        }

        public List<Admin> GetList()
        {
            return _adminDal.GetList();
        }

        public void TAdd(Admin t)
        {
            _adminDal.Insert(t);
        }

        public void TDelete(Admin t)
        {
            _adminDal.Delete(t);
        }

        public Admin TGetById(int id)
        {
            return _adminDal.GetById(id);
        }

        public void TUpdate(Admin t)
        {
            _adminDal.Update(t);
        }
    }
}
