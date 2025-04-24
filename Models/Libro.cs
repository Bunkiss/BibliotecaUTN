namespace BibliotecaUTN.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CantidadCopias { get; set; }
        
        public int id_editorial { get; set; }
        public int id_autor { get; set; }
        public int id_genero { get; set; }
        public int id_ubicacion { get; set; }

        public Editorial? Editorial { get; set; }
        public Autor? Autor { get; set; }
        public Genero? Genero { get; set; }
        public Ubicacion? Ubicacion { get; set; }
    }
}
