using GameAPI.Models;
using GameAPI.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    [ApiController]
    [Route("developers")]
    public class DeveloperControler : ControllerBase
    {
        private readonly IRepository _persistence;

        public DeveloperControler(IRepository persistence)
        {
            _persistence = persistence;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_persistence.Developers.List());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var game = _persistence.Developers.Get(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPut]
        public IActionResult Update(Developer developer)
        {
            return Ok(_persistence.Developers.Update(
                developer.Id,
                developer.Name));
        }

        [HttpPost]
        public IActionResult Post(Developer developer)
        {
            return Ok(_persistence.Developers.Create(
                developer.Name));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _persistence.Developers.Delete(id);

            return Ok();
        }
    }
}
