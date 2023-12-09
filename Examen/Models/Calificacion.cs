using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen.Models
{
    public class Calificacion
    {
        public int Id { get; set; }
        public int IdMateria { get; set; }
        public int IdAlumno { get; set; }

        [Display(Name = "Calificación")]
        [Range(0, 100, ErrorMessage = "La calificación debe estar entre 0 y 100.")]        
        [Column(TypeName = "decimal(5,1)")]
        public decimal Calificacion_ { get; set; }
    }
}
