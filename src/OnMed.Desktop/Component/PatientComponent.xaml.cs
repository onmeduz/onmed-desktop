using OnMed.Desktop.Pages;
using OnMed.ViewModel.Appointments;
using OnMed.ViewModel.Categories;
using System;
using System.Security.Policy;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace OnMed.Desktop.Component;

/// <summary>
/// Interaction logic for PatientComponent.xaml
/// </summary>
public partial class PatientComponent : UserControl
{
    public const string BASE_URL = "http://coursezone.uz/";

    public PatientComponent()
    {
        InitializeComponent();
    }
    public void SetData(AppointmentViewModel viewModel)
    {
        if (viewModel.UserImagePath == "")
        {
            string imagePath = "C:\\Users\\Shodiyor\\OneDrive\\Desktop\\onmed-desktop\\src\\OnMed.Desktop\\Assets\\Images\\default_image.png";
            Uri uri = new Uri(imagePath, UriKind.Absolute);
            patientImage.ImageSource = new BitmapImage(uri);
        }
        else
        {
            string imageUrl = BASE_URL + viewModel.UserImagePath;
            Uri imageUri = new Uri(imageUrl, UriKind.Absolute);
            patientImage.ImageSource = new BitmapImage(imageUri);
        }

        patientName.Content = viewModel.UserFullName;
        patientPhone.Content = viewModel.UserPhoneNumber;
        doctorName.Content = viewModel.DoctorFullName;
        if (viewModel.UserIsMale)
            patientGender.Content = "Erkak";
        else
            patientGender.Content = "Ayol";
    }
}
