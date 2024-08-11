using Microsoft.AspNetCore.Mvc;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Controllers
{
    public class VacunasController : BaseController
    {
        private readonly IVacunasService _service;

        public VacunasController(IVacunasService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacunas>>> GetVacunass()
        {
            var Vacunass = await _service.GetAllAsync();
            return Ok(Vacunass);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vacunas>> GetVacunas(int id)
        {
            var Response = await _service.GetByIdAsync(id);
            if (Response == null)
            {
                return NotFound();
            }
            return Ok(Response);
        }

        [HttpPost]
        public async Task<ActionResult<Vacunas>> PostVacunas(Vacunas Vacunas)
        {
            await _service.AddAsync(Vacunas);
            return CreatedAtAction(nameof(GetVacunas), new { id = Vacunas.Id }, Vacunas);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacunas(int id, Vacunas Vacunas)
        {
            if (id != Vacunas.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(Vacunas);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacunas(int id)
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
