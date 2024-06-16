using GameAPI.Models;
using GameAPI.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    [ApiController]
    [Route("publishers")]
    public class PublisherControler : ControllerBase
    {
        private readonly IRepository _persistence;

        public PublisherControler(IRepository persistence)
        {
            _persistence = persistence;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_persistence.Publishers.List());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var game = _persistence.Publishers.Get(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPut]
        public IActionResult Update(Publisher publisher)
        {
            return Ok(_persistence.Publishers.Update(
                publisher.Id,
                publisher.Name));
        }

        [HttpPost]
        public IActionResult Post(Publisher publisher)
        {
            return Ok(_persistence.Publishers.Create(
                publisher.Name));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _persistence.Publishers.Delete(id);

            return Ok();
        }
    }
}
