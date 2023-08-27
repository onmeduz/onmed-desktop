using OnMed.Dtos.ForgotPassword;

namespace OnMed.Integrated.Interfaces.ForgotPassword;

public interface IRegisterService
{
    public Task<bool> RegisterAsync(VerifyRegisterDto dto);
}
