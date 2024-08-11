using Microsoft.AspNetCore.Mvc;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Controllers
{
    public class EvidenciasController : BaseController
    {
        private readonly IEvidenciasService _service;

        public EvidenciasController(IEvidenciasService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evidencias>>> GetEvidenciass()
        {
            var Evidenciass = await _service.GetAllAsync();
            return Ok(Evidenciass);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evidencias>> GetEvidencias(int id)
        {
            var Response = await _service.GetByIdAsync(id);
            if (Response == null)
            {
                return NotFound();
            }
            return Ok(Response);
        }

        [HttpPost]
        public async Task<ActionResult<Evidencias>> PostEvidencias(Evidencias Evidencias)
        {
            await _service.AddAsync(Evidencias);
            return CreatedAtAction(nameof(GetEvidencias), new { id = Evidencias.Id }, Evidencias);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvidencias(int id, Evidencias Evidencias)
        {
            if (id != Evidencias.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(Evidencias);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvidencias(int id)
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
