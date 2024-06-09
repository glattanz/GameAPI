using GameAPI.Models;
using GameAPI.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    [ApiController]
    [Route("genres")]
    public class GenreController : ControllerBase
    {
        private readonly IRepository _persistence;

        public GenreController(IRepository persistence)
        {
            _persistence = persistence;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_persistence.Genres.List());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var game = _persistence.Genres.Get(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPut]
        public IActionResult Update(Genre genre)
        {
            return Ok(_persistence.Genres.Update(
                genre.Id,
                genre.Name));
        }

        [HttpPost]
        public IActionResult Post(Genre genre)
        {
            return Ok(_persistence.Genres.Create(
                genre.Name));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _persistence.Genres.Delete(id);

            return Ok();
        }
    }
}
