using CP.BusinessLayer.Repository.Abstract;
using CP.BusinessLayer.Repository.Concrete.Basic;
using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Repository.Concrete
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext dbContext) : base(dbContext)
        {

        }

        //ProductId && UserId List<Comment>  CommentId 


        public CafeProjectModel CafeDB => _context as CafeProjectModel; //bu cast işlemine sürekli ihtiyac duyacağız.



        public List<Comment> GetAllUser(int UserId)
        {
            return CafeDB.Comment.Include(x => x.Product).Include(x => x.User).Where(y => y.UserId == UserId).ToList();
        }

        public List<Comment> GetAllProduct(int ProductId)
        {
            return CafeDB.Comment.Include(x => x.Product).Include(x => x.User).Where(y => y.ProductId == ProductId).ToList();
        }

        public Comment CommentFind(int CommentId)
        {
            return CafeDB.Comment.Include(x => x.Product).Include(x => x.User).FirstOrDefault(y => y.Id == CommentId);
        }
    }
}
