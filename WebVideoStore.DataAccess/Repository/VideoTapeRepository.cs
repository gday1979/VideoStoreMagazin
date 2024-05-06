namespace WebVideoStore.DataAccess.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using WebVideoStore.DataAccess.Data;
    using WebVideoStore.DataAccess.Repository.IRepository;
    using WebVideoStore.Models;

    public class VideoTapeRepository : Repository<VideoTape>, IVideoTapeRepository
    {
        private ApplicationDbContext _db;
        public VideoTapeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(VideoTape obj)
        {
           var objFromDb = _db.VideoTapes.FirstOrDefault(s => s.Id == obj.Id);
            if(objFromDb !=null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Director = obj.Director;
                objFromDb.Year = obj.Year;
                objFromDb.PriceRent = obj.PriceRent;
                objFromDb.PriceBuy = obj.PriceBuy;
                objFromDb.CategoryId = obj.CategoryId;
                if(obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }

            }
        }
    }
}
