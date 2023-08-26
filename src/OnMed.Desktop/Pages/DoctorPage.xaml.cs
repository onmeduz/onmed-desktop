using OnMed.Desktop.Component;
using OnMed.Desktop.Windows;
using OnMed.Integrated.Interfaces.Doctors;
using OnMed.Integrated.Security;
using OnMed.Integrated.Services.Doctors;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OnMed.Desktop.Pages;

/// <summary>
/// Interaction logic for DoctorPage.xaml
/// </summary>
public partial class DoctorPage : Page
{
    private readonly IDoctorService _service;
    public DoctorPage()
    {
        InitializeComponent();
        this._service = new DoctorService();
    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        await RefreshAsync();
    }

    private async void btnCreateDoctor_Click(object sender, RoutedEventArgs e)
    {
        DoctorCreateWindow  window = new DoctorCreateWindow();
        window.ShowDialog();
        await RefreshAsync();
    }

    private async Task RefreshAsync()
    {
        var id = IdentitySingelton.GetInstance().HospitalBranchId;

        wrpDoctors.Children.Clear();
        var doctors = await _service.GetAllAsync(id);
        foreach (var doctor in doctors)
        {
            DoctorComponent doctorComponent = new DoctorComponent();
            doctorComponent.SetData(doctor);
            doctorComponent.RefreshDelegate = RefreshAsync;
            wrpDoctors.Children.Add(doctorComponent);
        }
    }
}
