using OnMed.Desktop.Windows;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OnMed.Desktop.Pages.ForgotPasswordPages;

/// <summary>
/// Interaction logic for EnterVerificationCode.xaml
/// </summary>
public partial class EnterVerificationCode : Page
{
    public EnterVerificationCode()
    {
        InitializeComponent();
    }
    public EnterVerificationCode(ForgotPasswordWindow forgotPasswordWindow)
    {
        InitializeComponent();
    }

    private void textboxPhone_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        string text = textBox.Text;
        string filteredText = Regex.Replace(text, "[^0-9]+", "");

        if (text != filteredText)
        {
            int caretIndex = textBox.CaretIndex;
            textBox.Text = filteredText;
            textBox.CaretIndex = caretIndex > 0 ? caretIndex - 1 : 0;
        }
    }

    private void Border_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
    {
        Phoneborder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#329DFF"));
    }

    private void Border_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
    {
        Phoneborder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#979797"));
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        EnterNewPassword enterNewPassword = new EnterNewPassword();
        ForgotPasswordWindow window = GetWindow();
        window.PageNavigator.Content= enterNewPassword;
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
}
