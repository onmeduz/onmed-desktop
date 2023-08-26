using Newtonsoft.Json;
using OnMed.Integrated.Interfaces.Appointments;
using OnMed.Integrated.Security;
using OnMed.ViewModel.Appointments;
using OnMed.ViewModel.Categories;

namespace OnMed.Integrated.Services.Appoinments;

public class AppointmentService : IAppointmentService
{
    private readonly string BASE_URL = "http://coursezone.uz/api/";

    public async Task<List<AppointmentViewModel>> GetAsync(int id)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(BASE_URL + $"admin/user/patient?moment={id}");

        var token = IdentitySingelton.GetInstance().Token;
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

        var result = await client.GetAsync(client.BaseAddress);
        string response = await result.Content.ReadAsStringAsync();
        var users = JsonConvert.DeserializeObject<List<AppointmentViewModel>>(response);
        return users!;
    }
}
