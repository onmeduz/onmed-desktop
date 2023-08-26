using OnMed.Dtos.Doctors;
using OnMed.ViewModel.Doctors;

namespace OnMed.Integrated.Interfaces.Doctors;

public interface IDoctorService
{
    public Task<List<DoctorViewModel>> GetAllAsync(long id);
    public Task<bool> CreateAsync(DoctorCreateDto dto);
    public Task<bool> UpdateAsync(long id, DoctorUpdateDto updateDto);
    public Task<bool> DeleteAsync(long id);
}
