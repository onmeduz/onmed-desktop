using Newtonsoft.Json;
using OnMed.Integrated.Interfaces.Doctors;
using OnMed.ViewModel.Categories;
using OnMed.ViewModel.Doctors;

namespace OnMed.Integrated.Services.Doctors;

public class DoctorService : IDoctorService
{
    private readonly string BASE_URL = "http://coursezone.uz/api/";

    public async Task<List<DoctorViewModel>> GetAllAsync(long id)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(BASE_URL + "common/hospital/branch/doctors" + $"{id}");
        var result = await client.GetAsync(client.BaseAddress);
        string response = await result.Content.ReadAsStringAsync();
        var doctor = JsonConvert.DeserializeObject<List<DoctorViewModel>>(response);
        return doctor!;
    }
}
