using Newtonsoft.Json;
using OnMed.Dtos.Doctors;
using OnMed.Integrated.Interfaces.Doctors;
using OnMed.ViewModel.Categories;
using OnMed.ViewModel.Doctors;
using System.Net.Http;

namespace OnMed.Integrated.Services.Doctors;

public class DoctorService : IDoctorService
{
    private readonly string BASE_URL = "http://coursezone.uz/api/";

    public async Task<bool> CreateAsync(DoctorCreateDto createDto)
    {
        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BASE_URL + "admin/doctor");

            var content = new MultipartFormDataContent();

            content.Add(new StringContent(createDto.FirstName), "FirstName");
            content.Add(new StringContent(createDto.LastName), "LastName");
            content.Add(new StringContent(createDto.MiddleName), "MiddleName");
            content.Add(new StringContent(createDto.PhoneNumber), "PhoneNumber");
            content.Add(new StringContent(createDto.Password), "Password");
            content.Add(new ByteArrayContent(createDto.Image), "Image");

            request.Content = content;

            var result = await client.SendAsync(request);

            if (result.IsSuccessStatusCode)
                return true;
            return false;
        }
    }
    
    public async Task<List<DoctorViewModel>> GetAllAsync(long id)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(BASE_URL + "common/hospital/branch/doctors?hospitalId=1&page=1");
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
