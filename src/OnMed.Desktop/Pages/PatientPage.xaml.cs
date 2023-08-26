using OnMed.Desktop.Component;
using OnMed.Integrated.Interfaces.Appointments;
using OnMed.Integrated.Services.Appoinments;
using System.Windows;
using System.Windows.Controls;

namespace OnMed.Desktop.Pages;

/// <summary>
/// Interaction logic for PatientPage.xaml
/// </summary>
public partial class PatientPage : Page
{
    private readonly IAppointmentService _appointmentService;
    public PatientPage()
    {
        InitializeComponent();
        this._appointmentService = new AppointmentService();
    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        var patients = await _appointmentService.GetAsync(1);
        foreach (var patient in patients)
        {
            if (patient.Status == 4)
            {
                PatientComponent patientComponent = new PatientComponent();
                patientComponent.SetData(patient);
                wrpPatient.Children.Add(patientComponent);
            }
        }
    }
}
