using System.ComponentModel.DataAnnotations;

namespace BibliotecaUTN.Models
{
    public class Editorial
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
