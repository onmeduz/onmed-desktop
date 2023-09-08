using OnMed.Desktop.Constans;
using OnMed.Desktop.Pages;
using OnMed.Desktop.Windows;
using OnMed.Integrated.Interfaces.Doctors;
using OnMed.Integrated.Security;
using OnMed.Integrated.Services.Doctors;
using OnMed.ViewModel.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnMed.Desktop.Component;

/// <summary>
/// Interaction logic for DoctorControlForDashboard.xaml
/// </summary>
public partial class DoctorControlForDashboard : UserControl
{
    public const string BASE_URL = "https://localhost:7229/";
    private readonly IDoctorService _service;
    public long Id;
    public DoctorControlForDashboard()
    {
        InitializeComponent();
        this._service = new DoctorService();
    } 

    public void SetData(DoctorViewModel doctorViewModel)
    {
        string imageUrl = ContentConstans.BASE_URL + doctorViewModel.ImagePath;
        Uri imageUri = new Uri(imageUrl, UriKind.Absolute);
        doctorImageDashboard.ImageSource = new BitmapImage(imageUri);

        lbFullName.Content = doctorViewModel.ToString();
        Id = doctorViewModel.Id;
    }

    private async void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        GetByIdAsync(Id);
    }

    private void Border_MouseEnter(object sender, MouseEventArgs e)
    {
        Border_Image.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C80707"));
    }

    private void Border_Image_MouseLeave(object sender, MouseEventArgs e)
    {
        Border_Image.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#78B0E7"));
    }

    public async void GetByIdAsync(long doctorId)
    {
        long id = IdentitySingelton.GetInstance().HospitalBranchId;

        var doctors = await _service.GetAllAsync(id);

        foreach (var doctor in doctors)
        {
            if (doctor.Id == doctorId)
            {
                DoctorProfileWindow adminProfileWindow = new DoctorProfileWindow();

                string imageUrl = BASE_URL + doctor.ImagePath;
                Uri imageUri = new Uri(imageUrl, UriKind.Absolute);

                adminProfileWindow.adminProfileImage.ImageSource = new BitmapImage(imageUri);
                adminProfileWindow.lbAdminName.Content = doctor.ToString();
                adminProfileWindow.lbAdminMIddleName.Content = doctor.MiddleName;
                adminProfileWindow.AdminPhone.Content = doctor.PhoneNumber;
                adminProfileWindow.lbHospitalName.Content = doctor.CategoryNames[0];
                adminProfileWindow.lblStatus.Content = "Shifokor";
                adminProfileWindow.ShowDialog();
            }
        }
        
    }
}
