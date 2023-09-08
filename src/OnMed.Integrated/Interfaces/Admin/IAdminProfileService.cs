using OnMed.Dtos.Admin;

namespace OnMed.Integrated.Interfaces.Admin;

public interface IAdminProfileService
{
    public Task<bool> UploadImageAsync(UploadImageDto dto);
    public Task<bool> UpdateAsync(long id, AdminUpdateDto dto);
}
