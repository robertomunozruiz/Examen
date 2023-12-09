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
    public class DetailsModel : PageModel
    {
        private readonly Examen.Data.ExamenContext _context;

        public DetailsModel(Examen.Data.ExamenContext context)
        {
            _context = context;
        }

        public Calificacion Calificacion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacion = await _context.Calificacion.FirstOrDefaultAsync(m => m.Id == id);
            if (calificacion == null)
            {
                return NotFound();
            }
            else
            {
                Calificacion = calificacion;
            }
            return Page();
        }
    }
}
