using CP.BusinessLayer.Repository.Abstract;
using CP.BusinessLayer.Repository.Concrete;
using CP.BusinessLayer.UnitOfWork.Abstract.Basic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.UnitOfWork.Concrete.Basic
{
    public class UnitOfWork : IUnitOfWork
    {

        public IUserRepository UserRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }

        public ICategoryRepository CategoryRepository { get; private set; }

        public IRoleRepository RoleRepository { get; private set; }

        public ICartRepository CartRepository { get; private set; }

        public ITableRepository TableRepository { get; private set; }

        public IHomePageRepository HomePageRepository { get; private set; }

        public ISliderRepository SliderRepository { get; private set; }

        public ICommentRepository CommentRepository { get; private set; }

        public IRateRepository RateRepository { get; private set; }

        public IMusicListRepository MusicListRepository { get; private set; }

        public ICampaignRepository CampaignRepository { get; private set; }

        public ICampProductRepository CampProductRepository { get; private set; }

        public ICompanyRepository CompanyRepository { get; private set; }

        public IContactRepository ContactRepository { get; private set; }

        private DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            ProductRepository = new ProductRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
            RoleRepository = new RoleRepository(_context);
            CartRepository = new CartRepository(_context);
            TableRepository = new TableRepository(_context);
            HomePageRepository = new HomePageRepository(_context);
            SliderRepository = new SliderRepository(_context);
            CommentRepository = new CommentRepository(_context);
            RateRepository = new RateRepository(_context);
            MusicListRepository = new MusicListRepository(_context);
            CampaignRepository = new CampaignRepository(_context);
            CampProductRepository = new CampProductRepository(_context);
            CompanyRepository = new CompanyRepository(_context);
            ContactRepository = new ContactRepository(_context);
        }


        public int Complete()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
