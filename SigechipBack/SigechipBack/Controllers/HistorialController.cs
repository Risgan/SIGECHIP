using Microsoft.AspNetCore.Mvc;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Controllers
{
    public class HistorialController : BaseController
    {
        private readonly IHistorialService _service;

        public HistorialController(IHistorialService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Historial>>> GetHistorials()
        {
            var Historials = await _service.GetAllAsync();
            return Ok(Historials);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Historial>> GetHistorial(int id)
        {
            var Response = await _service.GetByIdAsync(id);
            if (Response == null)
            {
                return NotFound();
            }
            return Ok(Response);
        }

        [HttpPost]
        public async Task<ActionResult<Historial>> PostHistorial(Historial Historial)
        {
            await _service.AddAsync(Historial);
            return CreatedAtAction(nameof(GetHistorial), new { id = Historial.Id }, Historial);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorial(int id, Historial Historial)
        {
            if (id != Historial.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(Historial);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorial(int id)
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
