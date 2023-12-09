﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Examen.Data;
using Examen.Models;

namespace Examen.Pages.Alumnos
{
    public class CreateModel : PageModel
    {
        private readonly Examen.Data.ExamenContext _context;

        public CreateModel(Examen.Data.ExamenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Alumno Alumno { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Alumno.Add(Alumno);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}