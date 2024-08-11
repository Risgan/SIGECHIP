using Microsoft.AspNetCore.Mvc;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var Usuarios = await _service.GetAllAsync();
            return Ok(Usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var Response = await _service.GetByIdAsync(id);
            if (Response == null)
            {
                return NotFound();
            }
            return Ok(Response);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario Usuario)
        {
            await _service.AddAsync(Usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = Usuario.Id }, Usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario Usuario)
        {
            if (id != Usuario.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(Usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
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
