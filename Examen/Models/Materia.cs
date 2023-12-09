using System.ComponentModel.DataAnnotations;

namespace Examen.Models
{
    public class Materia
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Nombre { get; set; }
    }
}
