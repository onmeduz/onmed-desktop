using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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

    private void DoctorImage_MouseDown(object sender, MouseButtonEventArgs e)
    {

    }

    private void DoctorImage_MouseEnter(object sender, MouseEventArgs e)
    {
        DoctorImage.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C80707"));
    }

    private void DoctorImage_MouseLeave(object sender, MouseEventArgs e)
    {
        DoctorImage.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Transparent"));
    }
}
