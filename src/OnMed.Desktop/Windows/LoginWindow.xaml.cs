using OnMed.Desktop.Windows;
using OnMed.Dtos.Login;
using OnMed.Integrated.Interfaces.Login;
using OnMed.Integrated.Services.Login;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace OnMed.Desktop
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly ILoginService _service;
        public LoginWindow()
        {
            InitializeComponent();
            this._service = new LoginService();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        
        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (textboxParolText.Visibility == Visibility.Collapsed)
            {
                textboxParolText.Text = textboxParol.Password;
            }
            else
            {
                textboxParol.Password = textboxParolText.Text;
            }
            int count = 0;
            if (textboxPhone.Text.Length > 0 && textboxPhone.Text.Length <= 13) { count++; }  
            if (textboxParol.Password.ToString().Length >= 8 && textboxParol.Password.ToString().Length <= 32) { count++; }
            if (count == 2)
            {
                LoginDto loginDto = new LoginDto()
                {
                    PhoneNumber = (lbCodePhone.Content.ToString() + textboxPhone.Text),
                    Password = textboxParol.Password
                };
                bool response = await _service.Login(loginDto);
                if (response)
                {
                    MainWindow mainWindow = new MainWindow();
                    this.Close();
                    mainWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bunday admin mavjud emas");
                }
            }
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            Phoneborder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#329DFF"));
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            Phoneborder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#979797"));
        }

        private void textboxPhone_TextChanged(object sender, TextChangedEventArgs e)
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

        private void Border_MouseEnter_1(object sender, MouseEventArgs e)
        {
            Parolborder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#329DFF"));
        }

        private void Border_MouseLeave_1(object sender, MouseEventArgs e)
        {
            Parolborder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#979797"));
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            lblForgotPassword.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#329DFF"));
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            lblForgotPassword.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ForgotPasswordWindow forgotPasswordWindow = new ForgotPasswordWindow();
            forgotPasswordWindow.ShowDialog();
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
    }
}
