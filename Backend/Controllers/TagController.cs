using GameAPI.Models;
using GameAPI.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    [ApiController]
    [Route("tags")]
    public class TagController : ControllerBase
    {
        private readonly IRepository _persistence;

        public TagController(IRepository persistence)
        {
            _persistence = persistence;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_persistence.Tags.List());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var game = _persistence.Tags.Get(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPut]
        public IActionResult Update(Platform platform)
        {
            return Ok(_persistence.Tags.Update(
                platform.Id,
                platform.Name));
        }

        [HttpPost]
        public IActionResult Post(Platform platform)
        {
            return Ok(_persistence.Tags.Create(
                platform.Name));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _persistence.Tags.Delete(id);

            return Ok();
        }
    }
}
