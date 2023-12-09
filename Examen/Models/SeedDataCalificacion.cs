using Examen.Data;
using Examen.Models;
using Microsoft.EntityFrameworkCore;

namespace RazorPageMovie.Models
{
    public class SeedDataCalificacion
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ExamenContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ExamenContext>>()
                ))
            {
                if (context == null || context.Calificacion == null)
                {
                    throw new ArgumentException("NULL ExamenContext");
                }

                if (context.Calificacion.Any())
                {                    
                    return;
                }

                context.Calificacion.AddRange(
                    new Calificacion
                    {
                        IdMateria = 1,
                        IdAlumno = 1,
                        Calificacion_ = 100,
                    },
                    new Calificacion
                    {
                        IdMateria = 2,
                        IdAlumno = 2,
                        Calificacion_ = 90,
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
