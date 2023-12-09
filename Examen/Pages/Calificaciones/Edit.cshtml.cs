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

namespace Examen.Pages.Calificaciones
{
    public class EditModel : PageModel
    {
        private readonly Examen.Data.ExamenContext _context;

        public EditModel(Examen.Data.ExamenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Calificacion Calificacion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calificacion =  await _context.Calificacion.FirstOrDefaultAsync(m => m.Id == id);
            if (calificacion == null)
            {
                return NotFound();
            }
            Calificacion = calificacion;
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

            _context.Attach(Calificacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificacionExists(Calificacion.Id))
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

        private bool CalificacionExists(int id)
        {
            return _context.Calificacion.Any(e => e.Id == id);
        }
    }
}
