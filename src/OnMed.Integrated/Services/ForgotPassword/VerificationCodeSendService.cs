using OnMed.Dtos.Constants;
using OnMed.Integrated.Interfaces.ForgotPassword;

namespace OnMed.Integrated.Services.ForgotPassword;

public class VerificationCodeSendService : IVerificationCodeSendService
{
    private readonly string BASE_URL = BaseUrlConstants.BASE_URL;

    public async Task<bool> PhoneNumberSendAsync(string phoneNumber)
    {
        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BASE_URL + $"/api/admin/auth/reset/send-code?phone=%2B998{phoneNumber}");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
