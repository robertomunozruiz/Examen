using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Examen.Data;
using Examen.Models;

namespace Examen.Pages.Calificaciones
{
    public class IndexModel : PageModel
    {
        private readonly Examen.Data.ExamenContext _context;

        public IndexModel(Examen.Data.ExamenContext context)
        {
            _context = context;
        }

        public IList<Calificacion> Calificacion { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Calificacion = await _context.Calificacion.ToListAsync();
        }
    }
}
