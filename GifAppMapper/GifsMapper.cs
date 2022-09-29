using AnotherGifApp.Models;
using AnotherGifApp.Models.Dtos;
using AutoMapper;

namespace AnotherGifApp.GifAppMapper
{
    public class GifsMapper : Profile
    {
        public GifsMapper()
        {
            CreateMap<Gif, GifDtos>().ReverseMap();
        }
    }
}
