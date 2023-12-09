using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Examen.Data;
using Examen.Models;

namespace Examen.Pages.Asignaciones
{
    public class EditModel : PageModel
    {
        private readonly Examen.Data.ExamenContext _context;

        public EditModel(Examen.Data.ExamenContext context)
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

            var asignacion =  await _context.Asignacion.FirstOrDefaultAsync(m => m.Id == id);
            if (asignacion == null)
            {
                return NotFound();
            }
            Asignacion = asignacion;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Asignacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignacionExists(Asignacion.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AsignacionExists(int id)
        {
            return _context.Asignacion.Any(e => e.Id == id);
        }
    }
}
