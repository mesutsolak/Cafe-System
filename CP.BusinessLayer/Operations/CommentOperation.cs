using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Operations
{
    public class CommentOperation : BaseOperation
    {
        //ProductId && UserId List<Comment>  CommentId 

        public static int CommentAdd(Comment comment)
        {
            _data.CommentRepository.Add(comment);
            return _data.Complete();
        }

        public static Comment CommentById(int CommentId)
        {
            return _data.CommentRepository.CommentFind(CommentId);
        }

        public static int CommentUpdate(Comment comment)
        {
            _data.CommentRepository.Update(comment);
            return _data.Complete();
        }
        public static int CommentRemove(int id)
        {
            _data.CommentRepository.Remove(id);
            return _data.Complete();
        }
        public static List<Comment> CommentUserAll(int UserId)
        {
            return _data.CommentRepository.GetAllUser(UserId);
        }
        public static List<Comment> CommentProductAll(int ProductId)
        {
            return _data.CommentRepository.GetAllProduct(ProductId);
        }
    }
}
