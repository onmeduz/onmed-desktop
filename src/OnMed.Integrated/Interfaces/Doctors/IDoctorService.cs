using OnMed.Dtos.Doctors;
using OnMed.ViewModel.Doctors;

namespace OnMed.Integrated.Interfaces.Doctors;

public interface IDoctorService
{
    public Task<List<DoctorViewModel>> GetAllAsync(long id);
    public Task<bool> CreateAsync(DoctorCreateDto createDto);
    public Task<bool> UpdateAsync(long id, DoctorCreateDto createDto);
    public Task<bool> DeleteAsync(long id);
}
