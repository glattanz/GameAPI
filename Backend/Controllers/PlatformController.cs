using GameAPI.Models;
using GameAPI.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    [ApiController]
    [Route("platforms")]
    public class PlatformController : ControllerBase
    {
        private readonly IRepository _persistence;

        public PlatformController(IRepository persistence)
        {
            _persistence = persistence;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_persistence.Platforms.List());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var game = _persistence.Platforms.Get(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPut]
        public IActionResult Update(Platform platform)
        {
            return Ok(_persistence.Platforms.Update(
                platform.Id,
                platform.Name));
        }

        [HttpPost]
        public IActionResult Post(Platform platform)
        {
            return Ok(_persistence.Platforms.Create(
                platform.Name));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _persistence.Platforms.Delete(id);

            return Ok();
        }
    }
}
