using OnMed.Desktop.Component;
using OnMed.Integrated.Interfaces.Doctors;
using OnMed.Integrated.Services.Doctors;
using System.Windows;
using System.Windows.Controls;

namespace OnMed.Desktop.Pages;

/// <summary>
/// Interaction logic for DashboardPage.xaml
/// </summary>
public partial class DashboardPage : Page
{
    private readonly IDoctorService _service;
    long id = 1;
    public DashboardPage()
    {
        InitializeComponent();
        this._service = new DoctorService();

    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < 15; i++)
        {
            UserControlForDashboard userControlForDashboard = new UserControlForDashboard();
            wrpUsers.Children.Add(userControlForDashboard);
        }
        var doctors = await _service.GetAllAsync(id);
        foreach (var doctor in doctors)
        {
            DoctorControlForDashboard doctorControlForDashboard = new DoctorControlForDashboard();
            doctorControlForDashboard.SetData(doctor);
            wrpDoctors.Children.Add(doctorControlForDashboard);
        }
        doctorCount.Content = doctors.Count;
    }
}
