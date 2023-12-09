using System.ComponentModel.DataAnnotations;

namespace Examen.Models
{
    public class Profesor
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Nombre { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Apellidos { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
    }
}
