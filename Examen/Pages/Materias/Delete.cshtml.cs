using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Examen.Data;
using Examen.Models;

namespace Examen.Pages.Materias
{
    public class DeleteModel : PageModel
    {
        private readonly Examen.Data.ExamenContext _context;

        public DeleteModel(Examen.Data.ExamenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Materia Materia { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.Materia.FirstOrDefaultAsync(m => m.Id == id);

            if (materia == null)
            {
                return NotFound();
            }
            else
            {
                Materia = materia;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.Materia.FindAsync(id);
            if (materia != null)
            {
                Materia = materia;
                _context.Materia.Remove(Materia);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
