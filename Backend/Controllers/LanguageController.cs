using GameAPI.Models;
using GameAPI.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    [ApiController]
    [Route("languages")]
    public class LanguageController : ControllerBase
    {
        private readonly IRepository _persistence;

        public LanguageController(IRepository persistence)
        {
            _persistence = persistence;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_persistence.Languages.List());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var game = _persistence.Languages.Get(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPut]
        public IActionResult Update(Language language)
        {
            return Ok(_persistence.Languages.Update(
                language.Id,
                language.Name));
        }

        [HttpPost]
        public IActionResult Post(Language language)
        {
            return Ok(_persistence.Languages.Create(
                language.Name));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _persistence.Languages.Delete(id);

            return Ok();
        }
    }
}
