using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ColdConnectNET.API.Data;
using ColdConnectNET.API.Models;

namespace ColdConnectNET.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)] // <- ISSO OCULTA DO SWAGGER
    public class OcorrenciaViewController : Controller
    {
        private readonly ColdContext _context;

        public OcorrenciaViewController(ColdContext context)
        {
            _context = context;
        }

        [HttpGet("/ocorrencias")]
        public async Task<IActionResult> Index()
        {
            var ocorrencias = await _context.Ocorrencias.Include(o => o.Abrigo).ToListAsync();
            return View("Views/OcorrenciaView/Index.cshtml", ocorrencias);
        }
    }
}
