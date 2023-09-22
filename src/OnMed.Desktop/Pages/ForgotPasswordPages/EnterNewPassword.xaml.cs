using OnMed.Desktop.Windows;
using OnMed.Dtos.ForgotPassword;
using OnMed.Integrated.Interfaces.ForgotPassword;
using OnMed.Integrated.Services.ForgotPassword;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OnMed.Desktop.Pages.ForgotPasswordPages;

/// <summary>
/// Interaction logic for EnterNewPassword.xaml
/// </summary>
public partial class EnterNewPassword : Page
{
    public string PhoneNumber = string.Empty;

    private readonly IPasswordUpdateService _service;
    public EnterNewPassword()
    {
        InitializeComponent();
        this._service = new PasswordUpdateService();
    }
    public EnterNewPassword(ForgotPasswordWindow forgotPasswordWindow)
    {
        InitializeComponent();
        this._service = new PasswordUpdateService();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        UpdatePasswordDto dto = new UpdatePasswordDto();
        dto.PhoneNumber = PhoneNumber;
        dto.Password = textboxParol.Password;
        loader.Visibility = Visibility.Visible;
        bool res = await _service.UpdatePassword(dto);
        loader.Visibility = Visibility.Collapsed;
        if (res)
        {
            ForgotPasswordWindow window = GetWindow();
            MessageBox.Show("Sizning parolingiz o'zgartirildi.");
            window.Close();
        }
        else
            MessageBox.Show("Parol o'zgartirilmadi.");

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

    public static string Symbols { get; } = "~`!@#$%^&*()_-+={[}]|\\:;\"'<,>.?/";

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        EnterPhoneNumber enterPhoneNumber = new EnterPhoneNumber();
        ForgotPasswordWindow forgotPasswordWindow = GetWindow();
        forgotPasswordWindow.PageNavigator.Content = enterPhoneNumber;
    }
}
