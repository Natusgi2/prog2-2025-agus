namespace Bibliote.Models;

public class Autor
{
    public int? Id { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string Descripcion { get; set; }
    public required string Nacionalidad { get; set; }
    public List<Libro>? Libros {get; set;}
}