using OnMed.ViewModel.Appointments;

namespace OnMed.Integrated.Interfaces.Appointments;

public interface IAppointmentService
{
    public Task<List<AppointmentViewModel>> GetAsync(int id);
}
