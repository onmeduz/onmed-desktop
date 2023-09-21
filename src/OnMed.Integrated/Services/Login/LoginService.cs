using Newtonsoft.Json;
using OnMed.Dtos.Login;
using OnMed.Integrated.Interfaces.Login;
using OnMed.Integrated.Security;

namespace OnMed.Integrated.Services.Login;

public class LoginService : ILoginService
{
    private readonly string BASE_URL = "http://157.230.45.112:4040/api/";
    public async Task<bool> Login(LoginDto loginDto)
    {
        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BASE_URL + "admin/auth/login");
            var content = new StringContent(JsonConvert.SerializeObject(loginDto), null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var token = IdentitySingelton.GetInstance();

                string responseContent = await response.Content.ReadAsStringAsync();
                dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent)!;
                token.Token = jsonResponse.token.ToString();

                return true;
            }
            return false;
        }
    }
}
