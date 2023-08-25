using OnMed.ViewModel.Admin;

namespace OnMed.Integrated.Interfaces.Login;

public interface IAdminService
{
    public Task<AdminViewModel> GetAdminProfile();
}
