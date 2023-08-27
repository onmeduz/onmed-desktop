namespace OnMed.Integrated.Interfaces.ForgotPassword;

public interface IVerificationCodeSendService
{
    public Task<bool> PhoneNumber(string phoneNumber);
}
