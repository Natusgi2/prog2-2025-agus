namespace Bibliote.Models;
using System.Text.Json.Serialization;

public class Libro
{
    public int? Id { get; set; }
    public required int IdAutor { get; set; }
    public required string Titulo { get; set; }
    public required string Descripcion { get; set; }
    public required string Genero { get; set; }
    public required string ISBN { get; set; }
    public required DateTime FechaPublicacion { get; set; }
    public required DateTime FechaEdicion { get; set; }
    public required string Edicion { get; set; }
    [JsonIgnore]
    public Autor? Autor { get; set; }
}