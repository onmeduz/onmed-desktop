using OnMed.ViewModel.Doctors;
using System;
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
        DoctorsImage.ImageSource = new BitmapImage(new System.Uri(doctorViewModel.ImagePath, UriKind.Relative));
        DoctorFirstName.Content = doctorViewModel.FirstName;
        DoctorLastName.Content = doctorViewModel.LastName;
    }

    private void DoctorImage_MouseDown(object sender, MouseButtonEventArgs e)
    {

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
}
