namespace WebVideoStore.DataAccess.Repository
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using WebVideoStore.DataAccess.Data;
	using WebVideoStore.DataAccess.Repository.IRepository;
	using WebVideoStore.Models;

	public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
	{
		private readonly ApplicationDbContext _db;

		public OrderHeaderRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(OrderHeader obj)
		{
			_db.Update(obj);
		}
	}
	
}
