using Microsoft.EntityFrameworkCore;
using MyBlogSite.DataAccess.Abstract;
using MyBlogSite.DataAccess.Concrete.Contexts;
using MyBlogSite.DataAccess.Repositories;
using MyBlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DataAccess.Concrete.EntityFramework
{
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetInBoxWithMessageByWriter(int id)
        {
            using (var context = new BlogContext())
            {
                return context.Message2s.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToList();
            }
        }
        public List<Message2> GetSendBoxWithMessageByWriter(int id)
        {
            using (var context = new BlogContext())
            {
                return context.Message2s.Include(x => x.ReceiverUser).Where(x => x.SenderID == id).ToList();

            }
        }
    }
}
