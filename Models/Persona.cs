namespace Bibliote.Models;
using System.ComponentModel.DataAnnotations;


public class Persona
{
    public int? Id { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required DateTime FechaNacimiento { get; set; }
    public required string DNI { get; set; }

    public required string Email { get; set; }
}