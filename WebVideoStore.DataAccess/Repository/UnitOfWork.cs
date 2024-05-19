namespace WebVideoStore.DataAccess.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WebVideoStore.DataAccess.Data;
    using WebVideoStore.DataAccess.Repository.IRepository;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public ICategoryRepository Category { get; private set; }
        public IVideoTapeRepository VideoTape { get; private set; }

        public ICompanyRepository Company { get; private set; }

        public IShoppingCardRepository ShoppingCart { get; private set; }

        public IApplicationUserRepository ApplicationUser { get; private set; }
        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Company = new CompanyRepository(_db);
            Category = new CategoryRepository(_db);
            VideoTape = new VideoTapeRepository(_db);
            ShoppingCart = new ShoppingCardRepository(_db);
           ApplicationUser = new ApplicationUserRepository(_db);
        }

        public void Save()
        {
           _db.SaveChanges();
        }
    }

}
