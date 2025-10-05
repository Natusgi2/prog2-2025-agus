namespace Bibliote.Dto;

public record LoginDto(string NombreUsuario, string Contraseña);
public record LoginResponseDto(string Token, string Rol, string NombreUsuario);
public record CreateTokenDto(string NombreUsuario, int Id, string Nombre, string Rol);

