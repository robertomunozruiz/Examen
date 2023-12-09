using Examen.Data;
using Examen.Models;
using Microsoft.EntityFrameworkCore;

namespace RazorPageMovie.Models
{
    public class SeedDataProfesor
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ExamenContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ExamenContext>>()
                ))
            {
                if (context == null || context.Profesor == null)
                {
                    throw new ArgumentException("NULL ExamenContext");
                }

                if (context.Profesor.Any())
                {                    
                    return;
                }

                context.Profesor.AddRange(
                    new Profesor
                    {
                        Nombre = "Luis",
                        Apellidos = "Flores",
                        FechaNacimiento = DateTime.Parse("2000-01-19"),                   
                    },
                    new Profesor
                    {
                        Nombre = "Ricardo",
                        Apellidos = "Casillas",
                        FechaNacimiento = DateTime.Parse("2001-12-10"),
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
