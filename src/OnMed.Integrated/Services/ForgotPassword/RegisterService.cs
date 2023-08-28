using Newtonsoft.Json;
using OnMed.Dtos.ForgotPassword;
using OnMed.Dtos.Login;
using OnMed.Integrated.Interfaces.ForgotPassword;
using OnMed.Integrated.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMed.Integrated.Services.ForgotPassword;

public class RegisterService : IRegisterService
{
    private readonly string BASE_URL = "http://coursezone.uz/api/";

    public async Task<bool> RegisterAsync(VerifyRegisterDto dto)
    {
        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BASE_URL + "admin/auth/reset/verify");
            var content = new StringContent(JsonConvert.SerializeObject(dto), null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            string responseContent = await response.Content.ReadAsStringAsync();
            dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent)!;

            if (response.IsSuccessStatusCode && jsonResponse.result == true)
            {
                var token = IdentitySingelton.GetInstance();
                token.Token = jsonResponse.token.ToString();
                return true;
            }
            return false;
        }
    }
}
