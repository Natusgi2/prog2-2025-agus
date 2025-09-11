namespace Bibliote.Models;

public class Autor
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Descripción { get; set; }
    public string Nacionalidad { get; set; }
    public List<Libro> Libros {get; set;}
}