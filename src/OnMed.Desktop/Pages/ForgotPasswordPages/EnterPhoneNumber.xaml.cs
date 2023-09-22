using OnMed.Desktop.Windows;
using OnMed.Integrated.Interfaces.ForgotPassword;
using OnMed.Integrated.Services.ForgotPassword;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OnMed.Desktop.Pages.ForgotPasswordPages
{
    /// <summary>
    /// Interaction logic for EnterPhoneNumber.xaml
    /// </summary>
    public partial class EnterPhoneNumber : Page
    {
        public Func<Task> exit { get; set; }
        private readonly IVerificationCodeSendService _service;
        public EnterPhoneNumber()
        {
            InitializeComponent();
            this._service = new VerificationCodeSendService();
        }
        public EnterPhoneNumber(ForgotPasswordWindow forgotPasswordWindow)
        {
            InitializeComponent();
            this._service = new VerificationCodeSendService();
        }
        public EnterPhoneNumber(LoginWindow loginWindow)
        {
            InitializeComponent();
            this._service = new VerificationCodeSendService();
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            loader.Visibility = Visibility.Visible;
            var response = await _service.PhoneNumberSendAsync(textboxPhone.Text);
            loader.Visibility = Visibility.Collapsed;
            if (response)
            {
                lblNotFoundPhone.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
                EnterVerificationCode enterVerificationCode = new EnterVerificationCode();
                enterVerificationCode.PhoneNumber = textboxPhone.Text;
                ForgotPasswordWindow window = GetWindow();
                window.PageNavigator.Content = enterVerificationCode;
            }
            else
            {
                lblNotFoundPhone.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            }
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
        public static LoginWindow GetLoginWindow()
        {
            LoginWindow loginWindow = null;

            foreach (Window window in Application.Current.Windows)
            {
                Type type = typeof(LoginWindow);
                if (window != null && window.DependencyObjectType.Name == type.Name)
                {
                    loginWindow = (LoginWindow)window;
                    if (loginWindow != null)
                    {
                        break;
                    }
                }
            }
            return loginWindow;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
            exit();
        }
    }
}
