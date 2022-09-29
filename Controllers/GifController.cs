using AnotherGifApp.Models;
using AnotherGifApp.Models.Dtos;
using AnotherGifApp.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnotherGifApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GifController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IGifRepository _gifRepo;

        public GifController(IMapper mapper, IWebHostEnvironment webHostEnvironment, IGifRepository gifRepo)
        {
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _gifRepo = gifRepo;
        }

        [HttpGet(Name = "GetGifs")]
        public IActionResult GetGifs()
        {
            try
            {
                var gifList = _gifRepo.GetGifs();
                var gifListDto = new List<GifDtos>();

                foreach (var gif in gifList)
                {
                    gifListDto.Add(_mapper.Map<GifDtos>(gif));
                }

                return Ok(gifListDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{gifTag}", Name = "GetGifsByTag")]
        public IActionResult GetGifsByTag(string gifTag)
        {
            try
            {
                var gifList = _gifRepo.GetGifByTag(gifTag);
                var gifListDto = new List<GifDtos>();

                foreach (var gif in gifList)
                {
                    gifListDto.Add(_mapper.Map<GifDtos>(gif));
                }

                return Ok(gifListDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id:int}", Name = "GetGifById")]
        public IActionResult GetGifById(int Id)
        {
            try
            {
                var gif = _gifRepo.getGifById(Id);

                if (gif == null) return NotFound();

                var gifDto = _mapper.Map<GifDtos>(gif);

                return Ok(gifDto);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "GifAdd")]
        public IActionResult GifAdd([FromBody] Gif gif)
        {
            try
            {
                _gifRepo.GifAdd(gif);

                return Ok(gif);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id:int}", Name = "GifDelete")]
        public IActionResult GifDelete(int Id)
        {
            try
            {
                return Ok(_gifRepo.DeleteGif(Id));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
