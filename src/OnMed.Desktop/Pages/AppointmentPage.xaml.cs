using OnMed.Desktop.Component;
using OnMed.Integrated.Interfaces.Appointments;
using OnMed.Integrated.Services.Appoinments;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace OnMed.Desktop.Pages;

/// <summary>
/// Interaction logic for AppointmentPage.xaml
/// </summary>
public partial class AppointmentPage : Page
{
    private readonly IAppointmentService _appointmentService;
    int id = 1;
    public AppointmentPage()
    {
        InitializeComponent();
        this._appointmentService = new AppointmentService();
    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        RefreshId(1);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        RefreshId(1);
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        RefreshId(2);
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        RefreshId(3);
    }

    private void Button_Click_3(object sender, RoutedEventArgs e)
    {
        RefreshId(4);
    }

    public async void RefreshId(int id)
    {
        loader.Visibility = Visibility.Visible;
        var users = await _appointmentService.GetAsync(id);
        loader.Visibility = Visibility.Collapsed;
        scrolViver.Visibility = Visibility.Visible;
        int count = 1;
        wrpAppoinment.Children.Clear();
        if(users.Count > 0)
        {
            foreach (var user in users)
            {

                AppointmentComponent appointmentComponent = new AppointmentComponent();
                appointmentComponent.count = count;
                appointmentComponent.SetData(user);
                wrpAppoinment.Children.Add(appointmentComponent);
                count++;
            }
        }
        else
        {
            scrolViver.Visibility= Visibility.Collapsed;
            emptyData.Visibility = Visibility.Visible;
        }
    }

    private async void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            string search = tbSearch.Text;
            int count = 1;
            wrpAppoinment.Children.Clear();
            var users = await _appointmentService.SearchAsync(search);

            foreach (var user in users)
            {
                AppointmentComponent appointmentComponent = new AppointmentComponent();
                appointmentComponent.count = count;
                appointmentComponent.SetData(user);
                wrpAppoinment.Children.Add(appointmentComponent);
                count++;
            }
        }
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        if (string.IsNullOrEmpty(textBox.Text))
        {
            RefreshId(1);
        }
    }
}
