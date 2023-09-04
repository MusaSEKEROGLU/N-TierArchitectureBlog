using MyBlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.Business.Abstract
{
    public interface IContactService
    {
        void ContactAdd(Contact contact);
        //List<Contact> GetList();
    }
}
