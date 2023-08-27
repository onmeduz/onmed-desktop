using OnMed.ViewModel.Appointments;

namespace OnMed.Integrated.Interfaces.Appointments;

public interface IAppointmentService
{
    public Task<List<AppointmentViewModel>> GetAsync(int id);
    public Task<List<AppointmentViewModel>> SearchAsync(string search);
}
