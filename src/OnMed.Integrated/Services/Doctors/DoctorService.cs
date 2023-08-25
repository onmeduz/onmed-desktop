using Newtonsoft.Json;
using OnMed.Dtos.Doctors;
using OnMed.Integrated.Interfaces.Doctors;
using OnMed.Integrated.Security;
using OnMed.ViewModel.Categories;
using OnMed.ViewModel.Doctors;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace OnMed.Integrated.Services.Doctors;

public class DoctorService : IDoctorService
{
    private readonly string BASE_URL = "http://coursezone.uz/api/";

    public async Task<bool> CreateAsync(DoctorCreateDto createDto)
    {
        using (var client = new HttpClient())
        {
            var request = new Uri(BASE_URL + "admin/doctor");

            //var content = new MultipartFormDataContent();

            var json = JsonConvert.SerializeObject(createDto);
            StringContent cont = new StringContent(json, Encoding.UTF8, "application/json");

            var token = IdentitySingelton.GetInstance().Token;
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var result = await client.PostAsync(request, cont);
            var response = await result.Content.ReadAsStringAsync();

            if (result.IsSuccessStatusCode)
                return true;
            return false;
        }
    }

    public async Task<bool> DeleteAsync(long id)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(BASE_URL + $"admin/doctor/{id}");

        var token = IdentitySingelton.GetInstance().Token;
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

        var result = await client.DeleteAsync(client.BaseAddress);
        string response = await result.Content.ReadAsStringAsync();
        return response == "true";
    }

    public async Task<List<DoctorViewModel>> GetAllAsync(long id)
    {
        var Id = IdentitySingelton.GetInstance().HospitalBranchId;

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(BASE_URL + $"common/hospital/branch/doctors/{Id}?page=1");
        var result = await client.GetAsync(client.BaseAddress);
        string response = await result.Content.ReadAsStringAsync();
        var doctor = JsonConvert.DeserializeObject<List<DoctorViewModel>>(response);
        return doctor!;
    }

    public Task<bool> UpdateAsync(long id, DoctorCreateDto createDto)
    {
        throw new NotImplementedException();
    }
}
