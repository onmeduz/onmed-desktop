using Newtonsoft.Json;
using OnMed.Dtos.Login;
using OnMed.Integrated.Interfaces.ForgotPassword;
using OnMed.Integrated.Security;

namespace OnMed.Integrated.Services.ForgotPassword;

public class VerificationCodeSendService : IVerificationCodeSendService
{
    private readonly string BASE_URL = "http://157.230.45.112:4040/api/";

    public async Task<bool> PhoneNumberSendAsync(string phoneNumber)
    {
        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BASE_URL + $"admin/auth/reset/send-code?phone=%2B998{phoneNumber}");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
