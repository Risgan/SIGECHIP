using Microsoft.AspNetCore.Mvc;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Controllers
{
    public class RecomendacionController : BaseController
    {
        private readonly IRecomendacionService _service;

        public RecomendacionController(IRecomendacionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recomendacion>>> GetRecomendacions()
        {
            var Recomendacions = await _service.GetAllAsync();
            return Ok(Recomendacions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recomendacion>> GetRecomendacion(int id)
        {
            var Response = await _service.GetByIdAsync(id);
            if (Response == null)
            {
                return NotFound();
            }
            return Ok(Response);
        }

        [HttpPost]
        public async Task<ActionResult<Recomendacion>> PostRecomendacion(Recomendacion Recomendacion)
        {
            await _service.AddAsync(Recomendacion);
            return CreatedAtAction(nameof(GetRecomendacion), new { id = Recomendacion.Id }, Recomendacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecomendacion(int id, Recomendacion Recomendacion)
        {
            if (id != Recomendacion.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(Recomendacion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecomendacion(int id)
        {
            var Response = await _service.GetByIdAsync(id);
            if (Response == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
