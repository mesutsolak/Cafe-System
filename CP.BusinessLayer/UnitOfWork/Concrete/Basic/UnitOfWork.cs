using CP.BusinessLayer.Repository.Abstract;
using CP.BusinessLayer.Repository.Concrete;
using CP.BusinessLayer.UnitOfWork.Abstract.Basic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.UnitOfWork.Concrete.Basic
{
    public class UnitOfWork : IUnitOfWork
    {

        public IUserRepository UserRepository { get; private set; }


        private DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
        }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
