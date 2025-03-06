using BookWorm_Dotnet.Models;
using BookWorm_Dotnet.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookWorm_Dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreMasterController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreMasterController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // GET: api/GenreMaster
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreMaster>>> GetAllGenres()
        {
            var genres = await _genreService.GetAllGenres();
            return Ok(genres);
        }

        // GET: api/GenreMaster/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreMaster>> GetGenreById(int id)
        {
            var genre = await _genreService.GetGenreById(id);
            if (genre == null)
            {
                return NotFound(new { message = "Genre not found" });
            }
            return Ok(genre);
        }

        // POST: api/GenreMaster
        [HttpPost]
        public async Task<ActionResult<GenreMaster>> AddGenre(GenreMaster genre)
        {
            if (genre == null)
            {
                return BadRequest(new { message = "Invalid genre data" });
            }

            var newGenre = await _genreService.AddGenre(genre);
            return CreatedAtAction(nameof(GetGenreById), new { id = newGenre.GenreId }, newGenre);
        }
    }
}
