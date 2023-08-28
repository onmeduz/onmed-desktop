using OnMed.Desktop.Constans;
using OnMed.Desktop.Pages;
using OnMed.Desktop.Windows;
using OnMed.Integrated.Interfaces.Doctors;
using OnMed.Integrated.Services.Doctors;
using OnMed.ViewModel.Doctors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
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
    public long Id;
    private DoctorViewModel _viewModel;
    private readonly List<string> stars = new List<string> {"Star1", "Star2", "Star3", "Star4", "Star5"};

    public readonly IDoctorService _service;
    public Func<Task> RefreshDelegate { get; set; }


    public DoctorComponent()
    {
        InitializeComponent();
        this._service = new DoctorService();
    }

    public void SetData(DoctorViewModel doctorViewModel)
    {
        _viewModel = doctorViewModel;
        string imageUrl = ContentConstans.BASE_URL + doctorViewModel.ImagePath;
        Uri imageUri = new Uri(imageUrl, UriKind.Absolute);

        DoctorsImage.ImageSource = new BitmapImage(imageUri);
        DoctorName.Content = doctorViewModel.ToString();
        DoctorPersonality.Content = doctorViewModel.CategoryNames[0];
        Id = doctorViewModel.Id;

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

    private async void btnManege_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        DoctorUpdateWindow doctorUpdateWindow = new DoctorUpdateWindow();
        doctorUpdateWindow.DoctorName.Content = DoctorName.Content;
        doctorUpdateWindow.SetData(_viewModel);
        doctorUpdateWindow.DoctorId = Id;
        doctorUpdateWindow.ShowDialog();
        await RefreshDelegate(); 
    }

    private void DoctorImage_MouseDown(object sender, MouseButtonEventArgs e)
    {
    }

    private async void deletebtn_Click(object sender, RoutedEventArgs e)
    {
        if (MessageBox.Show($"{DoctorName.Content} ni o'chirmoqchimisiz?",
                   "Shifokorni o'chirish",
            MessageBoxButton.YesNo,
                   MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            var response = await _service.DeleteAsync(Id);
            if (response)
            {
                MessageBox.Show("Shifokor o'chirildi");
                await RefreshDelegate();
            }
            else
                MessageBox.Show("Xatoliklar mavjud.");
        }
    }
}
