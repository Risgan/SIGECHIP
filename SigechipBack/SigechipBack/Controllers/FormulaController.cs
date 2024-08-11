using Microsoft.AspNetCore.Mvc;
using SigechipBack.Interface.IServices;
using SigechipBack.Models;

namespace SigechipBack.Controllers
{
    public class FormulaController : BaseController
    {
        private readonly IFormulaService _service;

        public FormulaController(IFormulaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Formula>>> GetFormulas()
        {
            var Formulas = await _service.GetAllAsync();
            return Ok(Formulas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Formula>> GetFormula(int id)
        {
            var Response = await _service.GetByIdAsync(id);
            if (Response == null)
            {
                return NotFound();
            }
            return Ok(Response);
        }

        [HttpPost]
        public async Task<ActionResult<Formula>> PostFormula(Formula Formula)
        {
            await _service.AddAsync(Formula);
            return CreatedAtAction(nameof(GetFormula), new { id = Formula.Id }, Formula);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormula(int id, Formula Formula)
        {
            if (id != Formula.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(Formula);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormula(int id)
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
