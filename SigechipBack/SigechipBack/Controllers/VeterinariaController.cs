using Microsoft.AspNetCore.Mvc;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Controllers
{
    public class VeterinariaController : BaseController
    {
        private readonly IVeterinariaService _service;

        public VeterinariaController(IVeterinariaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veterinaria>>> GetVeterinarias()
        {
            var Veterinarias = await _service.GetAllAsync();
            return Ok(Veterinarias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Veterinaria>> GetVeterinaria(int id)
        {
            var Response = await _service.GetByIdAsync(id);
            if (Response == null)
            {
                return NotFound();
            }
            return Ok(Response);
        }

        [HttpPost]
        public async Task<ActionResult<Veterinaria>> PostVeterinaria(Veterinaria Veterinaria)
        {
            await _service.AddAsync(Veterinaria);
            return CreatedAtAction(nameof(GetVeterinaria), new { id = Veterinaria.Id }, Veterinaria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeterinaria(int id, Veterinaria Veterinaria)
        {
            if (id != Veterinaria.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(Veterinaria);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeterinaria(int id)
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
