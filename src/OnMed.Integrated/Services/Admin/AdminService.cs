﻿using OnMed.Dtos.Admin;
using OnMed.Dtos.Constants;
using OnMed.Integrated.Interfaces.Admin;
using OnMed.Integrated.Security;

namespace OnMed.Integrated.Services.Admin;

public class AdminService : IAdminProfileService
{
    private readonly string BASE_URL = BaseUrlConstants.BASE_URL;

    public async Task<bool> UpdateAsync(long id, AdminUpdateDto dto)
    {
        var token = IdentitySingelton.GetInstance().Token;
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Put, BASE_URL + $"/api/admin/profile?adminId={id}");
        request.Headers.Add("Authorization", $"Bearer {token}");

        var content = new MultipartFormDataContent();
        content.Add(new StringContent(dto.FirstName), "FirstName");
        content.Add(new StringContent(dto.LastName), "LastName");
        content.Add(new StringContent(dto.MiddleName), "MiddleName");
        content.Add(new StringContent(dto.Region.ToString()), "Region");

        request.Content = content;
        var response = await client.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            var res = await response.Content.ReadAsStringAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> UploadImageAsync(UploadImageDto dto)
    {
        var token = IdentitySingelton.GetInstance().Token;
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Put, BASE_URL + "/api/admin/profile/upload/image");
        request.Headers.Add("Authorization", $"Bearer {token}");

        var content = new MultipartFormDataContent();
        
        if(dto.Image.StartsWith(BaseUrlConstants.BASE_URL))
        {
            return true;
        }
        content.Add(new StreamContent(File.OpenRead(dto.Image)), "Image", dto.Image);

        request.Content = content;
        var response = await client.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            var res = await response.Content.ReadAsStringAsync();
            return true;
        }
        return false;
    }
}
