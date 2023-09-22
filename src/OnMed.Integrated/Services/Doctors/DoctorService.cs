using Newtonsoft.Json;
using OnMed.Dtos.Constants;
using OnMed.Dtos.Doctors;
using OnMed.Integrated.Interfaces.Doctors;
using OnMed.Integrated.Security;
using OnMed.ViewModel.Doctors;

namespace OnMed.Integrated.Services.Doctors;

public class DoctorService : IDoctorService
{
    private readonly string BASE_URL = BaseUrlConstants.BASE_URL;

    public async Task<bool> CreateAsync(DoctorCreateDto dto)
    {
        var token = IdentitySingelton.GetInstance().Token;
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, BASE_URL + "/api/admin/doctor");
        request.Headers.Add("Authorization", $"Bearer {token}");
        var content = new MultipartFormDataContent();
        content.Add(new StringContent(dto.FirstName), "FirstName");
        content.Add(new StringContent(dto.LastName), "LastName");
        content.Add(new StringContent(dto.MiddleName), "MiddleName");
        content.Add(new StringContent(dto.BirthDay.ToString()), "BirthDay");
        content.Add(new StringContent(dto.PhoneNumber), "PhoneNumber");
        content.Add(new StringContent(dto.IsMale.ToString()), "IsMale");
        content.Add(new StreamContent(File.OpenRead(dto.Image)), "Image", dto.Image);
        content.Add(new StringContent(dto.Region), "Region");
        content.Add(new StringContent(dto.Password), "Password");
        content.Add(new StringContent(dto.AppointmentMoney.ToString()), "AppointmentMoney");
        content.Add(new StringContent(dto.Degree), "Degree");
        content.Add(new StringContent(dto.HospitalBranchId.ToString()), "HospitalBranchId");
        content.Add(new StringContent("true"), "IsActive");
        foreach (var item in dto.WeekDay)
        {
            content.Add(new StringContent($"{item}"), "WeekDay");
        }
        content.Add(new StringContent(dto.StartTime), "StartTime");
        content.Add(new StringContent(dto.EndTime), "EndTime");
        foreach (var item in dto.CategoryIds)
        {
            content.Add(new StringContent($"{item}"), "CategoryIds");
        }
        request.Content = content;
        var response = await client.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            var res = await response.Content.ReadAsStringAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(BASE_URL + $"/api/admin/doctor/{id}");

        var token = IdentitySingelton.GetInstance().Token;
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

        var result = await client.DeleteAsync(client.BaseAddress);
        string response = await result.Content.ReadAsStringAsync();
        return response == "true";
    }

    public async Task<List<DoctorViewModel>> GetAllAsync(long id)
    {

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(BASE_URL + $"/api/common/hospital/branch/doctors/{id}?page=1");
        var result = await client.GetAsync(client.BaseAddress);
        string response = await result.Content.ReadAsStringAsync();
        var doctor = JsonConvert.DeserializeObject<List<DoctorViewModel>>(response);
        return doctor!;
    }

    public async Task<bool> UpdateAsync(long id, DoctorUpdateDto dto)
    {
        var token = IdentitySingelton.GetInstance().Token;
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Put, BASE_URL + $"/api/admin/doctor?doctorId={id}");
        request.Headers.Add("Authorization", $"Bearer {token}");
        var content = new MultipartFormDataContent();
        content.Add(new StringContent(dto.FirstName), "FirstName");
        content.Add(new StringContent(dto.LastName), "LastName");
        content.Add(new StringContent(dto.MiddleName), "MiddleName");
        content.Add(new StringContent(dto.BirthDay.ToString()), "BirthDay");
        content.Add(new StringContent(dto.PhoneNumber), "PhoneNumber");
        content.Add(new StringContent(dto.IsMale.ToString()), "IsMale");
        if (!dto.Image.StartsWith(BaseUrlConstants.BASE_URL))
        {
            content.Add(new StreamContent(File.OpenRead(dto.Image)), "Image", dto.Image);
        }
        content.Add(new StringContent(dto.Region), "Region");
        content.Add(new StringContent(dto.Password), "Password");
        content.Add(new StringContent(dto.AppointmentMoney.ToString()), "AppointmentMoney");
        content.Add(new StringContent(dto.Degree), "Degree");
        
        request.Content = content;
        var response = await client.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            var res = await response.Content.ReadAsStringAsync();
            return true;
        }
        return false;
    }

    public async Task<List<DoctorViewModel>> SearchAsync(string search)
    {
        var token = IdentitySingelton.GetInstance().Token;
        var branchId = IdentitySingelton.GetInstance().HospitalBranchId;
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(BASE_URL + $"/api/admin/doctor/search?branchId={branchId}&search={search}");
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        var result = await client.GetAsync(client.BaseAddress);
        var response = await result.Content.ReadAsStringAsync();
        var doctor = JsonConvert.DeserializeObject<List<DoctorViewModel>>(response);
        return doctor!;
    }
}
