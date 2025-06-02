using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ColdConnectNET.API.Data;

namespace ColdConnectNET.API.Controllers
{
    public class AbrigoController : Controller
    {
        private readonly ColdContext _context;

        public AbrigoController(ColdContext context)
        {
            _context = context;
        }

        // Rota padrão: /Abrigo ou /Abrigo/Index
        public async Task<IActionResult> Index()
        {
            var abrigos = await _context.Abrigos.ToListAsync();
            return View(abrigos); // Vai usar Views/Abrigo/Index.cshtml
        }
    }
}
