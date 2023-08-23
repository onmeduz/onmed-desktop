using OnMed.Desktop.Constans;
using OnMed.ViewModel.Doctors;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OnMed.Desktop.Component;

/// <summary>
/// Interaction logic for DoctorComponent.xaml
/// </summary>
public partial class DoctorComponent : UserControl
{
    public DoctorComponent()
    {
        InitializeComponent();
    }

    public void SetData(DoctorViewModel doctorViewModel)
    {
        string imageUrl = ContentConstans.BASE_URL + doctorViewModel.ImagePath;
        Uri imageUri = new Uri(imageUrl, UriKind.Absolute);

        DoctorsImage.ImageSource = new BitmapImage(imageUri);
        DoctorName.Content = doctorViewModel.ToString();
    }

    private void DoctorImage_MouseEnter(object sender, MouseEventArgs e)
    {
        DoctorImage.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#329DFF"));
    }

    private void DoctorImage_MouseLeave(object sender, MouseEventArgs e)
    {
        DoctorImage.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Transparent"));
    }

    private void btnManege_Click(object sender, System.Windows.RoutedEventArgs e)
    {

    }

    private void DoctorImage_MouseDown(object sender, MouseButtonEventArgs e)
    {

    }
}
