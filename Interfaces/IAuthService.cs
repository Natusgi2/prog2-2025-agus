using Bibliote.Dto;
namespace Bibliote.Interface;

public interface IAuthService
{
    string CreateToken(CreateTokenDto createTokenDto);
    string Login(LoginDto loginDto);
}