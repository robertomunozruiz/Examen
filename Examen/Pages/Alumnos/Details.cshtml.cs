using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Examen.Data;
using Examen.Models;

namespace Examen.Pages.Alumnos
{
    public class DetailsModel : PageModel
    {
        private readonly Examen.Data.ExamenContext _context;

        public DetailsModel(Examen.Data.ExamenContext context)
        {
            _context = context;
        }

        public Alumno Alumno { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumno.FirstOrDefaultAsync(m => m.Id == id);
            if (alumno == null)
            {
                return NotFound();
            }
            else
            {
                Alumno = alumno;
            }
            return Page();
        }
    }
}
