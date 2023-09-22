using OnMed.Desktop.Component;
using OnMed.Desktop.Windows;
using OnMed.Integrated.Interfaces.Doctors;
using OnMed.Integrated.Security;
using OnMed.Integrated.Services.Doctors;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        loader.Visibility = Visibility.Visible;
        scrolViver.Visibility = Visibility.Collapsed;
        var doctors = await _service.GetAllAsync(id);
        loader.Visibility = Visibility.Collapsed;
        scrolViver.Visibility = Visibility.Visible;
        if(doctors.Count > 0)
        {
            foreach (var doctor in doctors)
            {
                DoctorComponent doctorComponent = new DoctorComponent();
                doctorComponent.SetData(doctor);
                doctorComponent.RefreshDelegate = RefreshAsync;
                wrpDoctors.Children.Add(doctorComponent);
            }
        }
        else
        {
            emptyData.Visibility = Visibility.Visible;
        }
        
    }
    private async void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            string search = tbSearch.Text;
            loader.Visibility = Visibility.Visible;
            scrolViver.Visibility = Visibility.Collapsed;
            wrpDoctors.Children.Clear();
            var doctors = await _service.SearchAsync(search);
            loader.Visibility = Visibility.Collapsed;
            scrolViver.Visibility = Visibility.Visible;

            if (doctors.Count > 0)
            {
                foreach (var doctor in doctors)
                {
                    DoctorComponent doctorComponent = new DoctorComponent();
                    doctorComponent.SetData(doctor);
                    doctorComponent.RefreshDelegate = RefreshAsync;
                    wrpDoctors.Children.Add(doctorComponent);
                }
            }
            else
            {
                emptyData.Visibility = Visibility.Visible;
            }
        }
    }

    private async void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        if (string.IsNullOrEmpty(textBox.Text))
        {
            await RefreshAsync();
        }
    }
}
