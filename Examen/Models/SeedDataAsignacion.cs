using Examen.Data;
using Examen.Models;
using Microsoft.EntityFrameworkCore;

namespace RazorPageMovie.Models
{
    public class SeedDataAsignacion
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ExamenContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ExamenContext>>()
                ))
            {
                if (context == null || context.Asignacion == null)
                {
                    throw new ArgumentException("NULL ExamenContext");
                }

                if (context.Asignacion.Any())
                {                    
                    return;
                }

                context.Asignacion.AddRange(
                    new Asignacion
                    {
                        IdMateria = 1,
                        IdProfesor = 1,
                    },
                    new Asignacion
                    {
                        IdMateria = 2,
                        IdProfesor = 2,
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
