using MyBlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.Business.Abstract
{
    public interface IMessage2Service : IGenericService<Message2>
    {
        List<Message2> GetInBoxListByWriter(int id);
        List<Message2> GetSendBoxWithMessageByWriter(int id);   //yazarlara ait mesaj atan writer ların adını getir  
    }
}
