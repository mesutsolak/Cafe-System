using CP.BusinessLayer.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.UnitOfWork.Abstract.Basic
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IRoleRepository RoleRepository { get; }
        ICartRepository CartRepository { get; }
        ITableRepository TableRepository { get; }
        IHomePageRepository HomePageRepository { get; }
        ISliderRepository SliderRepository { get; }
        ICommentRepository CommentRepository { get; }
        IRateRepository RateRepository { get; }
        IMusicListRepository MusicListRepository { get; }
        ICampaignRepository CampaignRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        IContactRepository ContactRepository { get; }
        IGeneralRepository GeneralRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        IGenderRepository GenderRepository { get; }

        int Complete();
        Task<int> CompleteAsync();
    }
}
