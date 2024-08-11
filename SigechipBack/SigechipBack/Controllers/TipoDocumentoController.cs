using Microsoft.AspNetCore.Mvc;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Controllers
{
    public class TipoDocumentoController : BaseController
    {
        private readonly ITipoDocumentoService _service;

        public TipoDocumentoController(ITipoDocumentoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDocumento>>> GetTipoDocumentos()
        {
            var TipoDocumentos = await _service.GetAllAsync();
            return Ok(TipoDocumentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDocumento>> GetTipoDocumento(int id)
        {
            var Response = await _service.GetByIdAsync(id);
            if (Response == null)
            {
                return NotFound();
            }
            return Ok(Response);
        }

        [HttpPost]
        public async Task<ActionResult<TipoDocumento>> PostTipoDocumento(TipoDocumento TipoDocumento)
        {
            await _service.AddAsync(TipoDocumento);
            return CreatedAtAction(nameof(GetTipoDocumento), new { id = TipoDocumento.Id }, TipoDocumento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoDocumento(int id, TipoDocumento TipoDocumento)
        {
            if (id != TipoDocumento.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(TipoDocumento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoDocumento(int id)
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
