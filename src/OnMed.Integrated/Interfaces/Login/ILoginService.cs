using OnMed.Dtos.Login;

namespace OnMed.Integrated.Interfaces.Login;

public interface ILoginService
{
    Task<bool> Login(LoginDto loginDto);
}
