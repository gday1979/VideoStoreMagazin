namespace WebVideoStore.DataAccess.Repository.IRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WebVideoStore.Models;

    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company obj);
    }
}
