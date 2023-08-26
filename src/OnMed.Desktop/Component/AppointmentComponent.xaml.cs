using OnMed.ViewModel.Appointments;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace OnMed.Desktop.Component;

/// <summary>
/// Interaction logic for AppointmentComponent.xaml
/// </summary>
public partial class AppointmentComponent : UserControl
{
    public int count = 1;
    public AppointmentComponent()
    {
        InitializeComponent();
    }

    private void BorderLine_MouseEnter(object sender, MouseEventArgs e)
    {
        BorderLine.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CC0000"));
        
    }

    private void BorderLine_MouseLeave(object sender, MouseEventArgs e)
    {
        BorderLine.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#898989"));
    }

    public void SetData(AppointmentViewModel model)
    {
        lblNo.Content = count.ToString();
        lblName.Content = model.UserFullName;
        lblDoctorName.Content = model.DoctorFullName;
        lblTime.Content = model.StartTime.Substring(0, 5);
        if (model.IsPaid == false)
            IsPaid.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red")); ;

        if (model.UserIsMale == true)
            lblGender.Content = "Erkak";
        else
            lblGender.Content = "Ayol";
        int month = model.RegisterDate.Month;
        switch (month)
        {
            case 1:
                lblDate.Content = model.RegisterDate.Day.ToString() + "-yanvar";break;
            case 2:
                lblDate.Content = model.RegisterDate.Day.ToString() + "-fevral"; break;
            case 3:
                lblDate.Content = model.RegisterDate.Day.ToString() + "-mart"; break;
            case 4:
                lblDate.Content = model.RegisterDate.Day.ToString() + "-aprel"; break;
            case 5:
                lblDate.Content = model.RegisterDate.Day.ToString() + "-may"; break;
            case 6:
                lblDate.Content = model.RegisterDate.Day.ToString() + "-iyun"; break;
            case 7:
                lblDate.Content = model.RegisterDate.Day.ToString() + "-iyul"; break;
            case 8:
                lblDate.Content = model.RegisterDate.Day.ToString() + "-avgust"; break;
            case 9:
                lblDate.Content = model.RegisterDate.Day.ToString() + "-sentabr"; break;
            case 10:
                lblDate.Content = model.RegisterDate.Day.ToString() + "-oktabr"; break;
            case 11:
                lblDate.Content = model.RegisterDate.Day.ToString() + "-noyabr"; break;
            case 12:
                lblDate.Content = model.RegisterDate.Day.ToString() + "-dekabr"; break;
        }
    }
}
