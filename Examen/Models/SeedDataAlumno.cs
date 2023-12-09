using Examen.Data;
using Examen.Models;
using Microsoft.EntityFrameworkCore;

namespace RazorPageMovie.Models
{
    public class SeedDataAlumno
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ExamenContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ExamenContext>>()
                ))
            {
                if (context == null || context.Alumno == null)
                {
                    throw new ArgumentException("NULL ExamenContext");
                }

                if (context.Alumno.Any())
                {                    
                    return;
                }

                context.Alumno.AddRange(
                    new Alumno
                    {
                        Nombre = "Juan",
                        Apellidos = "Ruiz",
                        FechaNacimiento = DateTime.Parse("1994-10-29"),                   
                    },
                    new Alumno
                    {
                        Nombre = "Maria",
                        Apellidos = "López",
                        FechaNacimiento = DateTime.Parse("1980-12-01"),
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
