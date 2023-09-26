using OnMed.ViewModel.Appointments;
using System.Windows.Controls;
using System.Windows.Media;

namespace OnMed.Desktop.Component;

/// <summary>
/// Interaction logic for UserControlForDashboard.xaml
/// </summary>
public partial class UserControlForDashboard : UserControl
{
    public UserControlForDashboard()
    {
        InitializeComponent();
    }

    public int count = 1;
    public void SetData(AppointmentViewModel model)
    {
        lblNo.Content = count.ToString();
        lblName.Content = model.UserFullName;
        lblDoctor.Content = model.DoctorFullName;
        lblTime.Content = model.StartTime.Substring(0, 5);

        if (model.UserIsMale == false)
            lblGender.Content = "Erkak";
        else
            lblGender.Content = "Ayol";
        int month = model.RegisterDate.Month;
        switch (month)
        {
            case 1:
                lblDate.Content = model.RegisterDate.Day.ToString() + "-yanvar"; break;
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
