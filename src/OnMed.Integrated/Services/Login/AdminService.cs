using Newtonsoft.Json;
using OnMed.Dtos.Constants;
using OnMed.Integrated.Interfaces.Login;
using OnMed.Integrated.Security;
using OnMed.ViewModel.Admin;
using System.Net.Http.Json;

namespace OnMed.Integrated.Services.Login;

public class AdminService : IAdminService
{

    private readonly string BASE_URL = BaseUrlConstants.BASE_URL;

    public async Task<AdminViewModel> GetAdminProfile()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(BASE_URL + "/api/admin/profile");

        var token = IdentitySingelton.GetInstance().Token;
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

        var result = client.GetAsync(client.BaseAddress);
        string response = await result.Result.Content.ReadAsStringAsync();
        var admin = JsonConvert.DeserializeObject<AdminViewModel>(response);
        return admin!;
    }
}
