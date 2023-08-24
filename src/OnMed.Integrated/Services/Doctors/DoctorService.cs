using Newtonsoft.Json;
using OnMed.Dtos.Doctors;
using OnMed.Integrated.Interfaces.Doctors;
using OnMed.Integrated.Security;
using OnMed.ViewModel.Categories;
using OnMed.ViewModel.Doctors;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Json;

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
            content.Add(new StringContent(createDto.Region), "Region");
            content.Add(new StringContent(createDto.Degree), "Degree");
            content.Add(new StringContent(createDto.StartTime), "StartTime");
            content.Add(new StringContent(createDto.EndTime), "EndTime");
            content.Add(new ByteArrayContent(createDto.Image), "Image");

            var Birthday = JsonConvert.SerializeObject(createDto.BirthDay);
            content.Add(new StringContent(Birthday), "BirthDay");

            var Weekday = JsonConvert.SerializeObject(createDto.WeekDay);
            content.Add(new StringContent(Weekday), "WeekDay");

            var IsMale = JsonConvert.SerializeObject(createDto.IsMale);
            content.Add(new StringContent(IsMale), "IsMale");

            var Money = JsonConvert.SerializeObject(createDto.AppointmentMoney);
            content.Add(new StringContent(Money), "AppointmentMoney");

            var HospitalId = JsonConvert.SerializeObject(createDto.HospitalBranchId);
            content.Add(new StringContent(HospitalId), "HospitalBranchId");

            var CategoryId = JsonConvert.SerializeObject(createDto.CategoryIds);
            content.Add(new StringContent(CategoryId), "CategoryIds");

            var token = IdentitySingelton.GetInstance().Token;
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

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
        client.BaseAddress = new Uri(BASE_URL + "common/hospital/branch/doctors/4?page=1");
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
