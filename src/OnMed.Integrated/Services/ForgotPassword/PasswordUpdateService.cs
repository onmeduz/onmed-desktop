using Newtonsoft.Json;
using OnMed.Dtos.ForgotPassword;
using OnMed.Dtos.Login;
using OnMed.Integrated.Interfaces.ForgotPassword;
using OnMed.Integrated.Security;

namespace OnMed.Integrated.Services.ForgotPassword;

public class PasswordUpdateService : IPasswordUpdateService
{
    private readonly string BASE_URL = "https://localhost:7229/api/";

    public async Task<bool> UpdatePassword(UpdatePasswordDto dto)
    {
        //using (var client = new HttpClient())
        //{
        //    var request = new HttpRequestMessage(HttpMethod.Post, BASE_URL + "admin/auth/reset/update");
        //    var content = new StringContent(JsonConvert.SerializeObject(dto), null, "application/json");
        //    request.Content = content;
        //    var response = await client.SendAsync(request);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        var token = IdentitySingelton.GetInstance().Token;
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Put, BASE_URL + "admin/auth/reset/update");
        request.Headers.Add("Authorization", $"Bearer {token}");
        var content = new MultipartFormDataContent();
        content.Add(new StringContent(dto.PhoneNumber), "PhoneNumber");
        content.Add(new StringContent(dto.Password), "Password");
        request.Content = content;
        var response = await client.SendAsync(request);
        var res = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }
}
