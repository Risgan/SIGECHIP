using Microsoft.AspNetCore.Mvc;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Controllers
{
    public class ProcedimientoController : BaseController
    {
        private readonly IProcedimientoService _service;

        public ProcedimientoController(IProcedimientoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Procedimiento>>> GetProcedimientos()
        {
            var Procedimientos = await _service.GetAllAsync();
            return Ok(Procedimientos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Procedimiento>> GetProcedimiento(int id)
        {
            var Response = await _service.GetByIdAsync(id);
            if (Response == null)
            {
                return NotFound();
            }
            return Ok(Response);
        }

        [HttpPost]
        public async Task<ActionResult<Procedimiento>> PostProcedimiento(Procedimiento Procedimiento)
        {
            await _service.AddAsync(Procedimiento);
            return CreatedAtAction(nameof(GetProcedimiento), new { id = Procedimiento.Id }, Procedimiento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcedimiento(int id, Procedimiento Procedimiento)
        {
            if (id != Procedimiento.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(Procedimiento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcedimiento(int id)
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
