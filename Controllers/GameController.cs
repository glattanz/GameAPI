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
            return Ok(_persistence.Games.Update(game));
        }

        [HttpPost]
        public IActionResult Post(Game game)
        {
            return Ok(_persistence.Games.Create(game));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _persistence.Games.Delete(id);

            return Ok();
        }
    }
}
