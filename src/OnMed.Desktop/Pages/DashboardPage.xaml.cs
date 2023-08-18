using OnMed.Desktop.Component;
using System.Windows;
using System.Windows.Controls;

namespace OnMed.Desktop.Pages;

/// <summary>
/// Interaction logic for DashboardPage.xaml
/// </summary>
public partial class DashboardPage : Page
{
    public DashboardPage()
    {
        InitializeComponent();
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < 15; i++)
        {
            DoctorControlForDashboard doctorControlForDashboard = new DoctorControlForDashboard();
            wrpDoctors.Children.Add(doctorControlForDashboard);

            UserControlForDashboard userControlForDashboard = new UserControlForDashboard();
            wrpUsers.Children.Add(userControlForDashboard);
        }
    }
}
