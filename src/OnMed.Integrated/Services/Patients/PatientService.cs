using Newtonsoft.Json;
using OnMed.Dtos.Constants;
using OnMed.Integrated.Interfaces.Patients;
using OnMed.Integrated.Security;
using OnMed.ViewModel.Categories;

namespace OnMed.Integrated.Services.Patients;

public class PatientService : IPatientService
{
    private readonly string BASE_URL = BaseUrlConstants.BASE_URL;

    public async Task<long> GetCount(long id)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(BASE_URL + $"/api/admin/user/patient/count/{id}");

        var token = IdentitySingelton.GetInstance().Token;
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

        var result = await client.GetAsync(client.BaseAddress);
        string response = await result.Content.ReadAsStringAsync();
        long count = JsonConvert.DeserializeObject<long>(response);
        return count!;
    }
}
