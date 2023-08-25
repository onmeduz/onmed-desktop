using Newtonsoft.Json;
using OnMed.Integrated.Interfaces.Login;
using OnMed.Integrated.Security;
using OnMed.ViewModel.Admin;
using System.Net.Http.Json;

namespace OnMed.Integrated.Services.Login;

public class AdminService : IAdminService
{

    private readonly string BASE_URL = "http://coursezone.uz/api/";

    public async Task<AdminViewModel> GetAdminProfile()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(BASE_URL + "admin/profile");

        var token = IdentitySingelton.GetInstance().Token;
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

        var result = client.GetAsync(client.BaseAddress);
        string response = await result.Result.Content.ReadAsStringAsync();
        var admin = JsonConvert.DeserializeObject<AdminViewModel>(response);
        return admin!;
    }
}
