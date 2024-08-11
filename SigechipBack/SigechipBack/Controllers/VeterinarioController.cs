using Microsoft.AspNetCore.Mvc;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Controllers
{
    public class VeterinarioController : BaseController
    {
        private readonly IVeterinarioService _service;

        public VeterinarioController(IVeterinarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veterinario>>> GetVeterinarios()
        {
            var Veterinarios = await _service.GetAllAsync();
            return Ok(Veterinarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Veterinario>> GetVeterinario(int id)
        {
            var Veterinario = await _service.GetByIdAsync(id);
            if (Veterinario == null)
            {
                return NotFound();
            }
            return Ok(Veterinario);
        }

        [HttpPost]
        public async Task<ActionResult<Veterinario>> PostVeterinario(Veterinario Veterinario)
        {
            await _service.AddAsync(Veterinario);
            return CreatedAtAction(nameof(GetVeterinario), new { id = Veterinario.Id }, Veterinario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeterinario(int id, Veterinario Veterinario)
        {
            if (id != Veterinario.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(Veterinario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeterinario(int id)
        {
            var Veterinario = await _service.GetByIdAsync(id);
            if (Veterinario == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
