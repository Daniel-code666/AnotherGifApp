using System.ComponentModel.DataAnnotations;

namespace AnotherGifApp.Models
{
    public class Gif
    {
        [Key]
        public int Id { get; set; }

        public string? GifRoute { get; set; }

        public string? GifTag { get; set; }
    }
}
