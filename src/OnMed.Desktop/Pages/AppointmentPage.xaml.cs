using OnMed.Desktop.Component;
using System.Windows;
using System.Windows.Controls;

namespace OnMed.Desktop.Pages;

/// <summary>
/// Interaction logic for AppointmentPage.xaml
/// </summary>
public partial class AppointmentPage : Page
{
    public AppointmentPage()
    {
        InitializeComponent();
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < 20; i++)
        {
            AppointmentComponent appointmentComponent = new AppointmentComponent();
            wrpAppoinment.Children.Add(appointmentComponent);
        }
    }
}
