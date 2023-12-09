using Examen.Data;
using Examen.Models;
using Microsoft.EntityFrameworkCore;

namespace RazorPageMovie.Models
{
    public class SeedDataMateria
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ExamenContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ExamenContext>>()
                ))
            {
                if (context == null || context.Materia == null)
                {
                    throw new ArgumentException("NULL ExamenContext");
                }

                if (context.Materia.Any())
                {                    
                    return;
                }

                context.Materia.AddRange(
                    new Materia
                    {
                        Nombre = "Español",                  
                    },
                    new Materia
                    {
                        Nombre = "Ciencias Natuales",
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
