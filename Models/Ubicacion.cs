using System.ComponentModel.DataAnnotations;

namespace BibliotecaUTN.Models
{
    public class Ubicacion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
