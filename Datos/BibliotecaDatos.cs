using BibliotecaUTN.Models;
using System.Data.SqlClient;
using System.Runtime.Intrinsics.X86;


namespace BibliotecaUTN.Datos
{
    public class BibliotecaDatos
    {
        string connectionString = "Data Source=DESKTOP-KSI7QHT\\SQLEXPRESS;Initial Catalog=BibliotecaUTN;User ID=sa;Password=42785122";
        //Borrar el trust verificated y agregar el password si la verificacion es de sql
        //string connectionString = "Data Source=ACADEMICA-23;Initial Catalog=BibliotecaUTN;User ID=sa;Password=utn;";
        //Si no te recomienda con control + . la instalación ir a herramientas>Administrados de paquetes Nuget>administrador>buscar "System.Data.SqlClient"
        public string EjecutarQueryCED(string query)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery(); // Eliminamos el SqlDataReader reader ya que no estamos leyendo datos como en el SELECT
                    return ""; //Ya que el metodo es de tipo strig debe devolver alguno
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //------------------------------------------------------- AUTOR -------------------------------------------------------
        public List<Autor> ListAutores(int id)
        {
            List<Autor> lista = new List<Autor>();
            //Si con el crtl+. no sugiere instalar la extensión ir a
            //herramientas>administrador de paquetes nuget>administrar paquetes nuget para solucion>
            //en examinar System.Data.SqlClient
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Autor "; //debe ir el espacio final para conectar con la sentencia del if
                if (id > 0)
                {
                    query += $"WHERE id_autor = {id}";
                }

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Autor()
                    {
                        Id = (int)reader["id_autor"],
                        Nombre = reader["Nombre"].ToString(),
                        Nacionalidad = reader["Nacionalidad"].ToString()
                    });
                }
            }
            return lista;
        }
        public string CreateAutor(Autor autor)
        {
            string query = $"INSERT INTO Autor (Nombre, Nacionalidad) VALUES " +
                        $"( '{autor.Nombre}', '{autor.Nacionalidad}')";
            return EjecutarQueryCED(query);
        }
        public string EditAutor(Autor autor)
        {
            string query = $"UPDATE Autor SET Nombre = '{autor.Nombre}', Nacionalidad = '{autor.Nacionalidad}' WHERE id_autor = {autor.Id}";
            return EjecutarQueryCED(query);
        }
        public string DeleteAutor(int id)
        {
            string query = $"DELETE FROM Autor WHERE id_autor = {id}";
            return EjecutarQueryCED(query);
        }

        //------------------------------------------------------- EDITORIAL -------------------------------------------------------
        public List<Editorial> ListEditorial(int id)
        {
            List<Editorial> lista = new List<Editorial>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Editorial "; 
                if (id > 0)
                {
                    query += $"WHERE id_editorial = {id}";
                }

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Editorial()
                    {
                        Id = (int)reader["id_editorial"],
                        Nombre = reader["Nombre"].ToString(),
                    });
                }
            }
            return lista;
        }
        public string CreateEditorial(Editorial editorial)
        {
            string query = $"INSERT INTO Editorial (Nombre) VALUES ('{editorial.Nombre}')";
            return EjecutarQueryCED(query);
        }
        public string EditEditorial(Editorial editorial)
        {
            string query = $"UPDATE Editorial SET Nombre = '{editorial.Nombre}' WHERE id_editorial = {editorial.Id}";
            return EjecutarQueryCED(query);
        }
        public string DeleteEditorial(int id)
        {
            string query = $"DELETE FROM Editorial WHERE id_editorial = {id}";
            return EjecutarQueryCED(query);
        }

        //------------------------------------------------------- GENERO -------------------------------------------------------
        public List<Genero> ListGenero(int id)
        {
            List<Genero> lista = new List<Genero>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Genero ";
                if (id > 0)
                {
                    query += $"WHERE id_genero = {id}";
                }

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Genero()
                    {
                        Id = (int)reader["id_genero"],
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                    });
                }
            }
            return lista;
        }
        public string CreateGenero(Genero genero)
        {
            string query = $"INSERT INTO Genero (Nombre, Descripcion) VALUES ('{genero.Nombre}', '{genero.Descripcion}')";
            return EjecutarQueryCED(query);
        }
        public string EditGenero(Genero genero)
        {
            string query = $"UPDATE Genero SET Nombre = '{genero.Nombre}', Descripcion = '{genero.Descripcion}' WHERE id_genero = {genero.Id}";
            return EjecutarQueryCED(query);
        }
        public string DeleteGenero(int id)
        {
            string query = $"DELETE FROM Genero WHERE id_genero = {id}";
            return EjecutarQueryCED(query);
        }

        //------------------------------------------------------- UBICACION -------------------------------------------------------
        public List<Ubicacion> ListUbicacion(int id)
        {
            List<Ubicacion> lista = new List<Ubicacion>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Ubicacion ";
                if (id > 0)
                {
                    query += $"WHERE id_ubicacion = {id}";
                }

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Ubicacion()
                    {
                        Id = (int)reader["id_ubicacion"],
                        Nombre = reader["Nombre"].ToString()
                    });
                }
            }
            return lista;
        }
        public string CreateUbicacion(Ubicacion ubicacion)
        {
            string query = $"INSERT INTO Ubicacion (Nombre) VALUES ('{ubicacion.Nombre}')";
            return EjecutarQueryCED(query);
        }
        public string EditUbicacion(Ubicacion ubicacion)
        {
            string query = $"UPDATE Ubicacion SET Nombre = '{ubicacion.Nombre}' WHERE id_ubicacion = {ubicacion.Id}";
            return EjecutarQueryCED(query);
        }
        public string DeleteUbicacion(int id)
        {
            string query = $"DELETE FROM Ubicacion WHERE id_ubicacion = {id}";
            return EjecutarQueryCED(query);
        }

        //------------------------------------------------------- LIBRO -------------------------------------------------------
        public List<Libro> ListLibro(int id)
        {
            List<Libro> lista = new List<Libro>();
            using (SqlConnection con = new SqlConnection(connectionString)) //Se requieren los tags (as) para cada uno. No agregar saltos de linea
            {
                string query = "SELECT l.id_Libro AS id, l.Titulo AS titulo, l.CantidadCopias AS copias, " +
                            $"e.id_editorial AS idEditorial, e.Nombre AS nombreEditorial, " +
                            $"a.id_autor AS idAutor, a.Nombre AS nombreAutor, a.Nacionalidad AS nacionalidadAutor, " +
                            $"g.id_genero AS idGenero, g.Nombre AS nombreGenero, g.Descripcion AS descripcionGenero, " +
                            $"u.id_ubicacion AS idUbicacion, u.Nombre AS nombreUbicacion " +
                            $"FROM Libro l " +
                            $"JOIN Editorial e ON l.id_editorial = e.id_editorial " +
                            $"JOIN Autor a ON l.id_autor = a.id_autor " +
                            $"JOIN Genero g ON l.id_genero = g.id_genero " +
                            $"JOIN Ubicacion u ON l.id_ubicacion = u.id_ubicacion ";
                if (id > 0)
                {
                    query += $"WHERE id_Libro = {id}";
                }

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Libro()
                    {
                        Id = (int)reader["id"],
                        Nombre = reader["titulo"].ToString(),
                        CantidadCopias = (int)reader["copias"],
                        id_autor = (int)reader["idAutor"],
                        Autor = new Autor()
                        {
                            Id = (int)reader["idAutor"],
                            Nombre = reader["nombreAutor"].ToString(),
                            Nacionalidad = reader["nacionalidadAutor"].ToString()
                        },
                        id_editorial = (int)reader["idEditorial"],
                        Editorial = new Editorial()
                        {
                            Id = (int)reader["idEditorial"],
                            Nombre = reader["nombreEditorial"].ToString()
                        },
                        id_genero = (int)reader["idGenero"],
                        Genero = new Genero()
                        {
                            Id = (int)reader["idGenero"],
                            Nombre = reader["nombreGenero"].ToString(),
                            Descripcion = reader["descripcionGenero"].ToString()
                        },
                        id_ubicacion = (int)reader["idUbicacion"],
                        Ubicacion = new Ubicacion()
                        {
                            Id = (int)reader["idUbicacion"],
                            Nombre = reader["nombreUbicacion"].ToString()
                        }
                    });
                }
            }
            return lista;
        }
        public string CreateLibro(Libro libro)
        {
            string query = $"INSERT INTO Libro (Titulo, CantidadCopias, id_editorial, id_autor, id_genero, id_ubicacion) " +
                $"VALUES ('{libro.Nombre}', {libro.CantidadCopias}, {libro.id_editorial}, {libro.id_autor}, {libro.id_genero}, {libro.id_ubicacion})";
            return EjecutarQueryCED(query);
        }
        public string EditLibro(Libro libro)
        {
            string query = $"UPDATE Libro SET Titulo = '{libro.Nombre}', CantidadCopias = {libro.CantidadCopias}, id_editorial = {libro.id_editorial}, " +
                $"id_autor = {libro.id_autor}, id_genero = {libro.id_genero}, id_ubicacion = {libro.id_ubicacion} WHERE id_Libro = {libro.Id}";
            return EjecutarQueryCED(query);
        }
        public string DeleteLibro(int id)
        {
            string query = $"DELETE FROM Libro WHERE id_Libro = {id}";
            return EjecutarQueryCED(query);
        }
    }
}
