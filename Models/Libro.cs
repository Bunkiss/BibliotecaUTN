using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaUTN.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "El valor debe ser mayor o igual que 0")]
        [DisplayName("Cantidad de copias")]
        public int CantidadCopias { get; set; }
        [Required]
        public int id_editorial { get; set; }
        [Required]
        public int id_autor { get; set; }
        [Required]
        public int id_genero { get; set; }
        [Required]
        public int id_ubicacion { get; set; }

        public Editorial? Editorial { get; set; }
        public Autor? Autor { get; set; }
        public Genero? Genero { get; set; }
        public Ubicacion? Ubicacion { get; set; }
    }
}
