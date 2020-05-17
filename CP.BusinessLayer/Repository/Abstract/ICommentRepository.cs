using CP.BusinessLayer.Repository.Abstract.Basic;
using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Repository.Abstract
{
    public interface ICommentRepository : IRepository<Comment>
    {
        List<Comment> GetAllUser(int UserId);
        List<Comment> GetAllProduct(int ProductId);
        Comment CommentFind(int CommentId);
    }
}
