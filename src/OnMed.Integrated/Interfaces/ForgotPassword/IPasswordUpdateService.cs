using OnMed.Dtos.ForgotPassword;

namespace OnMed.Integrated.Interfaces.ForgotPassword;

public interface IPasswordUpdateService
{
    public Task<bool> UpdatePassword(UpdatePasswordDto dto);
}
