using Microsoft.AspNetCore.Mvc;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Controllers
{
    public class RolController : BaseController
    {
        private readonly IRolService _service;

        public RolController(IRolService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRols()
        {
            var Rols = await _service.GetAllAsync();
            return Ok(Rols);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            var Response = await _service.GetByIdAsync(id);
            if (Response == null)
            {
                return NotFound();
            }
            return Ok(Response);
        }

        [HttpPost]
        public async Task<ActionResult<Rol>> PostRol(Rol Rol)
        {
            await _service.AddAsync(Rol);
            return CreatedAtAction(nameof(GetRol), new { id = Rol.Id }, Rol);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol(int id, Rol Rol)
        {
            if (id != Rol.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(Rol);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
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
