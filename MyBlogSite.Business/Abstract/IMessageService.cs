using MyBlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.Business.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        List<Message> GetInBoxListByWriter(string p);
    }
}
