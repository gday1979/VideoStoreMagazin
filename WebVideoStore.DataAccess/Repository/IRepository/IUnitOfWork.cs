namespace WebVideoStore.DataAccess.Repository.IRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }

        IVideoTapeRepository VideoTape { get; }

        ICompanyRepository Company { get; }

        IShoppingCardRepository ShoppingCart { get; }

        IApplicationUserRepository ApplicationUser { get; }

        IOrderHeaderRepository OrderHeader { get; }

        IOrderDetailRepository OrderDetail { get; }
        void Save();
    }
}
