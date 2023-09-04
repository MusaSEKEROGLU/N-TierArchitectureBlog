using MyBlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DataAccess.Abstract
{
    public interface IMessage2Dal : IGenericDal<Message2>
    {
        List<Message2> GetInBoxWithMessageByWriter(int id); //yazar ıd ye göre mesaj atanın adını getirmek
        List<Message2> GetSendBoxWithMessageByWriter(int id);
    }
}
