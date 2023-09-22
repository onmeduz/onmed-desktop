using OnMed.Desktop.Component;
using OnMed.Integrated.Interfaces.Appointments;
using OnMed.Integrated.Services.Appoinments;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

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
        loader.Visibility = Visibility.Collapsed;
        scrolViver.Visibility = Visibility.Visible;
        if(patients.Count > 0)
        {
            foreach (var patient in patients)
            {
                if (patient.Status == 4)
                {
                    PatientComponent patientComponent = new PatientComponent();
                    patientComponent.SetData(patient);
                    wrpPatient.Children.Add(patientComponent);
                }
            }
            if (wrpPatient.Children.Count <= 0)
            {
                emptyData.Visibility = Visibility.Visible;
            }
        }
        else
        {
            emptyData.Visibility = Visibility.Visible;
        }
    }
}
