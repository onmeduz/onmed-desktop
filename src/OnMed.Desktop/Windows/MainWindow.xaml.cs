using OnMed.Desktop.Component;
using OnMed.Desktop.Pages;
using OnMed.Desktop.Themes;
using System;
using System.Windows;
using System.Windows.Input;

namespace OnMed.Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void btnMaximize_Click(object sender, RoutedEventArgs e)
    {
        if (this.WindowState == WindowState.Maximized)
            this.WindowState = WindowState.Normal;
        else this.WindowState = WindowState.Maximized;
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void borderDragable_MouseDown(object sender, MouseButtonEventArgs e)
    {
        this.DragMove();
    }

    private void borderDragabl_MouseDown(object sender, MouseButtonEventArgs e)
    {
        this.DragMove();
    }

    private void IsChecked(object sender, RoutedEventArgs e)
    {
        if (chkbox.IsChecked == true)
        {
            AppTheme.ChangeTheme(new Uri("Themes/DarkTheme.xaml", UriKind.Relative));

        }
        else
        {
            AppTheme.ChangeTheme(new Uri("Themes/LightTheme.xaml", UriKind.Relative));
        }
    }

    private void rbDashboard_Click(object sender, RoutedEventArgs e)
    {
        DashboardPage dashboardPage = new DashboardPage();
        PageNavigator.Content = dashboardPage;
    }

    private void rbBemor_Click(object sender, RoutedEventArgs e)
    {
        PatientPage patientPage = new PatientPage();
        PageNavigator.Content = patientPage;
    }

    private void rbShifokor_Click(object sender, RoutedEventArgs e)
    {
        DoctorPage  doctorPage = new DoctorPage();
        PageNavigator.Content = doctorPage;
    }

    private void rbToifalar_Click(object sender, RoutedEventArgs e)
    {
        CategoryPage categoryPage = new CategoryPage();
        PageNavigator.Content = categoryPage;
    }

    private void rbUchrashuv_Click(object sender, RoutedEventArgs e)
    {
        AppointmentPage appointmentPage = new AppointmentPage();
        PageNavigator.Content = appointmentPage;
    }

    private void rbTolov_Click(object sender, RoutedEventArgs e)
    {
        PaymentPage paymentPage = new PaymentPage();
        PageNavigator.Content = paymentPage;
    }

    private void rbShifoxona_Click(object sender, RoutedEventArgs e)
    {
        HospitalPage hospitalPage = new HospitalPage();
        PageNavigator.Content = hospitalPage;
    }

    private void rbeslatma_Click(object sender, RoutedEventArgs e)
    {
        NotePage notePage = new NotePage();
        PageNavigator.Content = notePage;
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        LoginWindow loginWindow = new LoginWindow();
        this.Close();
        loginWindow.Show();
    }
}
