using OnMed.Desktop.Component;
using System.Windows;
using System.Windows.Controls;

namespace OnMed.Desktop.Pages;

/// <summary>
/// Interaction logic for DoctorPage.xaml
/// </summary>
public partial class DoctorPage : Page
{
    public DoctorPage()
    {
        InitializeComponent();
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < 20; i++)
        {
            DoctorComponent doctorComponent = new DoctorComponent();
            wrpDoctors.Children.Add(doctorComponent);
        }
    }
}
