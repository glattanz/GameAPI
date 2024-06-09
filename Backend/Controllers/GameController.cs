using GameAPI.Models;
using GameAPI.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    [ApiController]
    [Route("games")]
    public class GameController : ControllerBase
    {
        private readonly IRepository _persistence;

        public GameController(IRepository persistence)
        {
            _persistence = persistence;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_persistence.Games.List());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var game = _persistence.Games.Get(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPut]
        public IActionResult Update(Game game)
        {
            return Ok(_persistence.Games.Update(
                game.Id,
                game.Title,
                game.Description,
                game.GenreId,
                game.DeveloperId,
                game.PublisherId,
                game.Rating,
                game.ReleaseDate,
                game.IsAvaliable));
        }

        [HttpPost]
        public IActionResult Post(Game game)
        {
            return Ok(_persistence.Games.Create(
                game.Title,
                game.Description,
                game.GenreId,
                game.DeveloperId,
                game.PublisherId,
                game.Rating,
                game.ReleaseDate,
                game.IsAvaliable));
        }

        [HttpDelete("{id}")]
        public IActionResult Disable(int id)
        {
            _persistence.Games.Disable(id);

            return Ok();
        }
    }
}
