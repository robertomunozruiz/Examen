using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Examen.Models;

namespace Examen.Data
{
    public class ExamenContext : DbContext
    {
        public ExamenContext (DbContextOptions<ExamenContext> options)
            : base(options)
        {
        }

        public DbSet<Examen.Models.Profesor> Profesor { get; set; } = default!;
        public DbSet<Examen.Models.Alumno> Alumno { get; set; } = default!;
        public DbSet<Examen.Models.Materia> Materia { get; set; } = default!;
        public DbSet<Examen.Models.Asignacion> Asignacion { get; set; } = default!;
        public DbSet<Examen.Models.Calificacion> Calificacion { get; set; } = default!;
    }
}
