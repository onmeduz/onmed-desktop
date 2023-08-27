using Newtonsoft.Json;
using OnMed.Dtos.ForgotPassword;
using OnMed.Dtos.Login;
using OnMed.Integrated.Interfaces.ForgotPassword;
using OnMed.Integrated.Security;

namespace OnMed.Integrated.Services.ForgotPassword;

public class PasswordUpdateService : IPasswordUpdateService
{
    private readonly string BASE_URL = "http://coursezone.uz/api/";

    public async Task<bool> UpdatePassword(UpdatePasswordDto dto)
    {
        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BASE_URL + "admin/auth/reset/update");
            var content = new StringContent(JsonConvert.SerializeObject(dto), null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode && response.Content.ToString() == "true")
            {
                return true;
            }
            return false;
        }
    }
}
