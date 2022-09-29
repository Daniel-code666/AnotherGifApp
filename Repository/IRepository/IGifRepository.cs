using AnotherGifApp.Models;

namespace AnotherGifApp.Repository.IRepository
{
    public interface IGifRepository
    {
        ICollection<Gif> GetGifs();

        ICollection<Gif> GetGifByTag(string gifTag);

        bool DeleteGif(int Id);

        Gif getGifById(int Id);

        bool GifAdd(Gif gif);

        bool Save();
    }
}
