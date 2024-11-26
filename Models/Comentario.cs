using System.ComponentModel.DataAnnotations;

namespace HermanosK.Models
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El autor no puede exceder 100 caracteres.")]
        public string Autor { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "El texto no puede exceder 500 caracteres.")]
        public string Texto { get; set; }

        [Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5 estrellas.")]
        public int Estrellas { get; set; } // Nueva propiedad
    }
}
