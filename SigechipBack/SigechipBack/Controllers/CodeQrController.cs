using Microsoft.AspNetCore.Mvc;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Controllers
{
    public class CodeQrController : BaseController
    {
        private readonly ICodeQRService _service;

        public CodeQrController(ICodeQRService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CodeQR>>> GetCodeQRs()
        {
            var CodeQRs = await _service.GetAllAsync();
            return Ok(CodeQRs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CodeQR>> GetCodeQR(int id)
        {
            var Response = await _service.GetByIdAsync(id);
            if (Response == null)
            {
                return NotFound();
            }
            return Ok(Response);
        }

        [HttpPost]
        public async Task<ActionResult<CodeQR>> PostCodeQR(CodeQR CodeQR)
        {
            await _service.AddAsync(CodeQR);
            return CreatedAtAction(nameof(GetCodeQR), new { id = CodeQR.Id }, CodeQR);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCodeQR(int id, CodeQR CodeQR)
        {
            if (id != CodeQR.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(CodeQR);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCodeQR(int id)
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
