using System.ComponentModel.DataAnnotations;

namespace BibliotecaUTN.Models
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Nacionalidad { get; set; }
    }
}
