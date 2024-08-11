using Microsoft.AspNetCore.Mvc;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Controllers
{
    public class PacienteController : BaseController
    {
        private readonly IPacienteService _service;

        public PacienteController(IPacienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
        {
            var Pacientes = await _service.GetAllAsync();
            return Ok(Pacientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPaciente(int id)
        {
            var Response = await _service.GetByIdAsync(id);
            if (Response == null)
            {
                return NotFound();
            }
            return Ok(Response);
        }

        [HttpPost]
        public async Task<ActionResult<Paciente>> PostPaciente(Paciente Paciente)
        {
            await _service.AddAsync(Paciente);
            return CreatedAtAction(nameof(GetPaciente), new { id = Paciente.Id }, Paciente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(int id, Paciente Paciente)
        {
            if (id != Paciente.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(Paciente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaciente(int id)
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
