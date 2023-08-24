using OnMed.Desktop.Constans;
using OnMed.Desktop.Pages;
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
    public DoctorControlForDashboard()
    {
        InitializeComponent();
    }

    public void SetData(DoctorViewModel doctorViewModel)
    {
        string imageUrl = ContentConstans.BASE_URL + doctorViewModel.ImagePath;
        Uri imageUri = new Uri(imageUrl, UriKind.Absolute);

        doctorImageDashboard.ImageSource = new BitmapImage(imageUri);
        lbFullName.Content = doctorViewModel.ToString();
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show(lbFullName.Content.ToString(), lbCategory.Content.ToString());
    }

    private void Border_MouseEnter(object sender, MouseEventArgs e)
    {
        Border_Image.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C80707"));
    }

    private void Border_Image_MouseLeave(object sender, MouseEventArgs e)
    {
        Border_Image.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#78B0E7"));
    }
}
