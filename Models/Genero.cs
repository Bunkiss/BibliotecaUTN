using System.ComponentModel.DataAnnotations;

namespace BibliotecaUTN.Models
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}
