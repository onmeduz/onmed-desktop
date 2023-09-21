using Newtonsoft.Json;
using OnMed.Integrated.Interfaces.Patients;
using OnMed.Integrated.Security;
using OnMed.ViewModel.Categories;

namespace OnMed.Integrated.Services.Patients;

public class PatientService : IPatientService
{
    private readonly string BASE_URL = "http://157.230.45.112:4040/api/";

    public async Task<long> GetCount(long id)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(BASE_URL + $"admin/user/patient/{id}");

        var token = IdentitySingelton.GetInstance().Token;
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

        var result = await client.GetAsync(client.BaseAddress);
        string response = await result.Content.ReadAsStringAsync();
        long count = JsonConvert.DeserializeObject<long>(response);
        return count!;
    }
}
