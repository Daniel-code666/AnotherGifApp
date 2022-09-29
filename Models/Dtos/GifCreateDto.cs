namespace AnotherGifApp.Models.Dtos
{
    public class GifCreateDto
    {
        public string? GifRoute { get; set; }

        public IFormFile? GifImg { get; set; }

        public string? GifTag { get; set; }
    }
}
