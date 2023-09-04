using MyBlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.Business.Abstract
{
	public interface ICommentService
	{
		List<Comment> GetList(int id);
		//Comment GetByIdComment(int id);
		void CommentAdd(Comment comment);
		//void CommentDelete(Comment comment);
		//void CommentUpdate(Comment comment);
	}
}
