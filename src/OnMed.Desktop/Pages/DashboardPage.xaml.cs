using OnMed.Desktop.Component;
using OnMed.Integrated.Interfaces.Doctors;
using OnMed.Integrated.Interfaces.Patients;
using OnMed.Integrated.Security;
using OnMed.Integrated.Services.Doctors;
using OnMed.Integrated.Services.Patients;
using System.Windows;
using System.Windows.Controls;

namespace OnMed.Desktop.Pages;

/// <summary>
/// Interaction logic for DashboardPage.xaml
/// </summary>
public partial class DashboardPage : Page
{
    private readonly IDoctorService _service;
    private readonly IPatientService _patientService;
    public DashboardPage()
    {
        InitializeComponent();
        this._service = new DoctorService();
        this._patientService = new PatientService();

    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < 15; i++)
        {
            UserControlForDashboard userControlForDashboard = new UserControlForDashboard();
            wrpUsers.Children.Add(userControlForDashboard);
        }

        long Id = IdentitySingelton.GetInstance().HospitalBranchId;
        var doctors = await _service.GetAllAsync(Id);
        foreach (var doctor in doctors) 
        {
            DoctorControlForDashboard doctorControlForDashboard = new DoctorControlForDashboard();
            doctorControlForDashboard.SetData(doctor);
            wrpDoctors.Children.Add(doctorControlForDashboard);
        }
        long count = await _patientService.GetCount(Id);

        lblUserCount.Content = count.ToString();

        doctorCount.Content = doctors.Count;
        
    }
}
