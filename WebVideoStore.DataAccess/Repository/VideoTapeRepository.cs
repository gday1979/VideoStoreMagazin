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
            _db.VideoTapes.Update(obj);
        }
    }
}
