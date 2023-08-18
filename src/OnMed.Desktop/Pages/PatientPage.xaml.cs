using OnMed.Desktop.Component;
using System.Windows;
using System.Windows.Controls;

namespace OnMed.Desktop.Pages;

/// <summary>
/// Interaction logic for PatientPage.xaml
/// </summary>
public partial class PatientPage : Page
{
    public PatientPage()
    {
        InitializeComponent();
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < 10; i++)
        {
            PatientComponent patientComponent = new PatientComponent();
            wrpPatient.Children.Add(patientComponent);
        }
    }
}
