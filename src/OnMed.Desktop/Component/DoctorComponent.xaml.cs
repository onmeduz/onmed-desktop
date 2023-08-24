using OnMed.Desktop.Constans;
using OnMed.ViewModel.Doctors;
using System;
using System.Collections.Generic;
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
    private readonly List<string> stars = new List<string> {"Star1", "Star2", "Star3", "Star4", "Star5"};
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

        int count = 3;
        for (int i = 0; i < count; i++)
        {
            if (stars[i] == "Star1")
                Star1.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F4CA16"));
            if (stars[i] == "Star2")
                Star2.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F4CA16"));
            if (stars[i] == "Star3")
                Star3.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F4CA16"));
            if (stars[i] == "Star4")
                Star4.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F4CA16"));
            if (stars[i] == "Star5")
                Star5.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F4CA16"));
        }

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
