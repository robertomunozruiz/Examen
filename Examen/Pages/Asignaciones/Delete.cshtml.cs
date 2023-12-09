using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Examen.Data;
using Examen.Models;

namespace Examen.Pages.Asignaciones
{
    public class DeleteModel : PageModel
    {
        private readonly Examen.Data.ExamenContext _context;

        public DeleteModel(Examen.Data.ExamenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Asignacion Asignacion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignacion.FirstOrDefaultAsync(m => m.Id == id);

            if (asignacion == null)
            {
                return NotFound();
            }
            else
            {
                Asignacion = asignacion;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignacion.FindAsync(id);
            if (asignacion != null)
            {
                Asignacion = asignacion;
                _context.Asignacion.Remove(Asignacion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
