using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ColdConnectNET.API.Data;
using ColdConnectNET.API.Models;

namespace ColdConnectNET.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbrigoApiController : ControllerBase
    {
        private readonly ColdContext _context;

        public AbrigoApiController(ColdContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Abrigo>>> GetAbrigos()
        {
            var abrigos = await _context.Abrigos.Include(a => a.Ocorrencias).ToListAsync();
            return Ok(abrigos);
        }

        [HttpPost]
        public async Task<ActionResult<Abrigo>> CreateAbrigo(Abrigo abrigo)
        {
            _context.Abrigos.Add(abrigo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAbrigos), new { id = abrigo.Id }, abrigo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAbrigo(int id, Abrigo updatedAbrigo)
        {
            if (id != updatedAbrigo.Id)
                return BadRequest(new { message = "ID da URL não bate com o do objeto." });

            var abrigo = await _context.Abrigos.FindAsync(id);
            if (abrigo == null)
                return NotFound();

            abrigo.Nome = updatedAbrigo.Nome;
            abrigo.Endereco = updatedAbrigo.Endereco;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbrigo(int id)
        {
            var abrigo = await _context.Abrigos.FindAsync(id);
            if (abrigo == null)
                return NotFound();

            _context.Abrigos.Remove(abrigo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
