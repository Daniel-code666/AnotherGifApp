using AnotherGifApp.Data;
using AnotherGifApp.Models;
using AnotherGifApp.Repository.IRepository;

namespace AnotherGifApp.Repository
{
    public class GifRepository : IGifRepository
    {
        private readonly ApplicationDbContext _db;

        public GifRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool DeleteGif(int Id)
        {
            var gif = _db.Gif.FirstOrDefault(g => g.Id == Id);
            
            if (gif == null)
            {
                return false;
            }

            _db.Gif.Remove(gif);

            return Save();
        }

        public Gif getGifById(int Id)
        {
            return _db.Gif.FirstOrDefault(g => g.Id == Id);
        }

        public ICollection<Gif> GetGifByTag(string gifTag)
        {
            return _db.Gif.Where(g => g.GifTag.ToLower().Trim() == gifTag.ToLower().Trim()).ToList();
        }

        public ICollection<Gif> GetGifs()
        {
            return _db.Gif.OrderBy(x => x.Id).ToList();
        }

        public bool GifAdd(Gif gif)
        {
            _db.Gif.Add(gif);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0;
        }
    }
}
