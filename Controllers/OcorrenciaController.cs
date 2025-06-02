using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ColdConnectNET.API.Data;
using ColdConnectNET.API.Models;
using ColdConnectNET.API.DTOs; // importa o DTO

[ApiController]
[Route("api/[controller]")]
public class OcorrenciaController : ControllerBase
{
    private readonly ColdContext _context;

    public OcorrenciaController(ColdContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var ocorrencias = await _context.Ocorrencias
            .Include(o => o.Abrigo)
            .ToListAsync();
        return Ok(ocorrencias);
    }

    [HttpPost]
    public async Task<IActionResult> Post(OcorrenciaCreateDTO dto)
    {
        var abrigo = await _context.Abrigos.FindAsync(dto.AbrigoId);
        if (abrigo == null)
            return BadRequest(new { message = $"Abrigo com ID {dto.AbrigoId} não encontrado." });

        var ocorrencia = new Ocorrencia
        {
            Tipo = dto.Tipo,
            Data = dto.Data,
            AbrigoId = dto.AbrigoId,
            Abrigo = abrigo
        };

        _context.Ocorrencias.Add(ocorrencia);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Post), new { id = ocorrencia.Id }, ocorrencia);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, OcorrenciaCreateDTO dto)
    {
        var ocorrencia = await _context.Ocorrencias.FindAsync(id);
        if (ocorrencia == null)
            return NotFound();

        var abrigo = await _context.Abrigos.FindAsync(dto.AbrigoId);
        if (abrigo == null)
            return BadRequest(new { message = $"Abrigo com ID {dto.AbrigoId} não encontrado." });

        ocorrencia.Tipo = dto.Tipo;
        ocorrencia.Data = dto.Data;
        ocorrencia.AbrigoId = dto.AbrigoId;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ocorrencia = await _context.Ocorrencias.FindAsync(id);
        if (ocorrencia == null)
            return NotFound();

        _context.Ocorrencias.Remove(ocorrencia);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}