using OnMed.Desktop.Constans;
using OnMed.Desktop.Pages;
using OnMed.Desktop.Themes;
using OnMed.Desktop.Windows;
using OnMed.Integrated.Interfaces.Login;
using OnMed.Integrated.Security;
using OnMed.Integrated.Services.Login;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace OnMed.Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public const string BASE_URL = "https://localhost:7229/";
    private readonly IAdminService _adminService;
    public MainWindow()
    {
        InitializeComponent();
        rbDashboard.IsChecked = true;
        this._adminService = new AdminService();
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

        var identity = IdentitySingelton.GetInstance();

        identity.HospitalBranchId = 0;
        identity.AdminId = 0;
        identity.MiddleName = "";
        identity.Name = "";
        identity.ImagePath = "";
        identity.HospitalName = "";
        identity.PhoneNumber = "";
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        DashboardPage dashboardPage = new DashboardPage();
        PageNavigator.Content = dashboardPage;
        var admin = await _adminService.GetAdminProfile();

        var identity = IdentitySingelton.GetInstance();
        if (identity != null)
        {
            identity.HospitalBranchId = admin.HospitalBranchIds[0];
            identity.AdminId = admin.AdminId;
            identity.MiddleName = admin.MiddleName;
            identity.Name = admin.ToString();
            identity.ImagePath = admin.ImagePath;
            identity.HospitalName = admin.HospitalNames[0];
            identity.PhoneNumber = admin.PhoneNumber;

            string imageUrl = ContentConstans.BASE_URL + admin.ImagePath;
            Uri imageUri = new Uri(imageUrl, UriKind.Absolute);

            AdminImage.ImageSource = new BitmapImage(imageUri);
            lbAdminName.Content = admin.ToString();
        }
        else
            MessageBox.Show("Server bilan bog'lanishda muammo yuzaga keldi!");
    }

    private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
    {
        AdminProfileWindow adminProfileWindow = new AdminProfileWindow();

        string imageUrl = BASE_URL + IdentitySingelton.GetInstance().ImagePath;
        Uri imageUri = new Uri(imageUrl, UriKind.Absolute);
        adminProfileWindow.adminProfileImage.ImageSource = new BitmapImage(imageUri);

        adminProfileWindow.lbAdminName.Content = IdentitySingelton.GetInstance().Name;
        adminProfileWindow.lbAdminMIddleName.Content = IdentitySingelton.GetInstance().MiddleName;
        adminProfileWindow.AdminPhone.Content = IdentitySingelton.GetInstance().PhoneNumber;
        adminProfileWindow.lbHospitalName.Content = IdentitySingelton.GetInstance().HospitalName;
        adminProfileWindow.ShowDialog();
    }
}
