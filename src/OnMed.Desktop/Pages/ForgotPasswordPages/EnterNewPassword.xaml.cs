using OnMed.Desktop.Windows;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OnMed.Desktop.Pages.ForgotPasswordPages;

/// <summary>
/// Interaction logic for EnterNewPassword.xaml
/// </summary>
public partial class EnterNewPassword : Page
{
    public EnterNewPassword()
    {
        InitializeComponent();
    }
    public EnterNewPassword(ForgotPasswordWindow forgotPasswordWindow)
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        ForgotPasswordWindow window = GetWindow();
        MessageBox.Show("Sizning parolingiz o'zgartirildi.");
        window.Close();
    }
    public static ForgotPasswordWindow GetWindow()
    {
        ForgotPasswordWindow forgotPasswordWindow = null;

        foreach (Window window in Application.Current.Windows)
        {
            Type type = typeof(ForgotPasswordWindow);
            if (window != null && window.DependencyObjectType.Name == type.Name)
            {
                forgotPasswordWindow = (ForgotPasswordWindow)window;
                if (forgotPasswordWindow != null)
                {
                    break;
                }
            }
        }
        return forgotPasswordWindow;
    }

    private void showPassword_Click(object sender, RoutedEventArgs e)
    {
        if (textboxParolText.Visibility == Visibility.Collapsed)
        {
            showPassword.Style = (Style)FindResource("showPasswordCrosButton");
            textboxParolText.Text = textboxParol.Password;
            textboxParol.Visibility = Visibility.Collapsed;
            textboxParolText.Visibility = Visibility.Visible;
        }
        else
        {
            showPassword.Style = (Style)FindResource("showPasswordButton");
            textboxParol.Password = textboxParolText.Text;
            textboxParolText.Visibility = Visibility.Collapsed;
            textboxParol.Visibility = Visibility.Visible;
        }
    }

    private void Border_MouseEnter_1(object sender, System.Windows.Input.MouseEventArgs e)
    {
        Parolborder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#329DFF"));
    }

    private void Border_MouseLeave_1(object sender, System.Windows.Input.MouseEventArgs e)
    {
        Parolborder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#979797"));
    }
}
