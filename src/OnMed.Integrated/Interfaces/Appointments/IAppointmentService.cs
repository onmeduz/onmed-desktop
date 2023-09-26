using OnMed.ViewModel.Appointments;
using OnMed.ViewModel.Hospitals;

namespace OnMed.Integrated.Interfaces.Appointments;

public interface IAppointmentService
{
    public Task<List<AppointmentViewModel>> GetAsync(int id);
    public Task<List<AppointmentViewModel>> SearchAsync(string search);
    public Task<List<ChartInfoViewModel>> DetChartInfo(long id);
}
