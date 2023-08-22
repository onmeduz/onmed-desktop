using OnMed.ViewModel.Doctors;

namespace OnMed.Integrated.Interfaces.Doctors;

public interface IDoctorService
{
    public Task<List<DoctorViewModel>> GetAllAsync(long id);
}
