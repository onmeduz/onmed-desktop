using OnMed.Desktop.Component;
using OnMed.Integrated.Interfaces.Appointments;
using OnMed.Integrated.Interfaces.Doctors;
using OnMed.Integrated.Interfaces.Patients;
using OnMed.Integrated.Security;
using OnMed.Integrated.Services.Appoinments;
using OnMed.Integrated.Services.Doctors;
using OnMed.Integrated.Services.Patients;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace OnMed.Desktop.Pages;

/// <summary>
/// Interaction logic for DashboardPage.xaml
/// </summary>
public partial class DashboardPage : Page
{
    private readonly IDoctorService _service;
    private readonly IPatientService _patientService;
    private readonly IAppointmentService _appointmentService;
    public DashboardPage()
    {
        InitializeComponent();
        this._service = new DoctorService();
        this._patientService = new PatientService();
        this._appointmentService = new AppointmentService();
    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        var users = await _appointmentService.GetAsync(1);
        int number = 1;
        foreach (var user in users)
        {
            if (user.Status == 2)
            {
                UserControlForDashboard userControlForDashboard = new UserControlForDashboard();
                userControlForDashboard.count = number;
                userControlForDashboard.SetData(user);
                wrpUsers.Children.Add(userControlForDashboard);
                number++;
            }
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
        lblPatient.Content = count.ToString();
        doctorCount.Content = doctors.Count;  
    }
    public void SetDataChart(List<double> nums, List<string> strings)
    {
        SetChart.Values.Clear();
        foreach (var item in nums)
        {
            SetChart.Values.Add(item);
        }
        DateLabel.Labels = strings.ToArray();
    }
}
