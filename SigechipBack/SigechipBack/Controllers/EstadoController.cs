using Microsoft.AspNetCore.Mvc;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Controllers
{
    public class EstadoController : BaseController
    {
        private readonly IEstadoService _service;

        public EstadoController(IEstadoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstados()
        {
            var Estados = await _service.GetAllAsync();
            return Ok(Estados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estado>> GetEstado(int id)
        {
            var Response = await _service.GetByIdAsync(id);
            if (Response == null)
            {
                return NotFound();
            }
            return Ok(Response);
        }

        [HttpPost]
        public async Task<ActionResult<Estado>> PostEstado(Estado Estado)
        {
            await _service.AddAsync(Estado);
            return CreatedAtAction(nameof(GetEstado), new { id = Estado.Id }, Estado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstado(int id, Estado Estado)
        {
            if (id != Estado.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(Estado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstado(int id)
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
