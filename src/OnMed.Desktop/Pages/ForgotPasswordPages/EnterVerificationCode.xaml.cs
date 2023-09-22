using OnMed.Desktop.Windows;
using OnMed.Dtos.ForgotPassword;
using OnMed.Integrated.Interfaces.ForgotPassword;
using OnMed.Integrated.Services.ForgotPassword;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace OnMed.Desktop.Pages.ForgotPasswordPages;

/// <summary>
/// Interaction logic for EnterVerificationCode.xaml
/// </summary>
public partial class EnterVerificationCode : Page
{
    private readonly IRegisterService _service;

    public string PhoneNumber = string.Empty;
    int count = 0;

    private DispatcherTimer timer;
    private SolidColorBrush originalBrush;
    private bool isRed = true;
    public EnterVerificationCode()
    {
        InitializeComponent();
        this._service = new RegisterService();
        Start();

        originalBrush = (SolidColorBrush)lblError.Foreground;

        timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(2);
        timer.Tick += Timer_Tick;
    }
    public EnterVerificationCode(ForgotPasswordWindow forgotPasswordWindow)
    {
        InitializeComponent();
        this._service = new RegisterService();
        Start();

        originalBrush = (SolidColorBrush)lblError.Foreground;

        timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(2);
        timer.Tick += Timer_Tick;
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
        count++;
        VerifyRegisterDto dto = new VerifyRegisterDto();
        try
        {
            dto.Code = int.Parse(textboxCode.Text);
            dto.PhoneNumber = "+998" + PhoneNumber;
        }
        catch
        {}
        loader.Visibility = Visibility.Visible;
        var res = await _service.RegisterAsync(dto);
        loader.Visibility = Visibility.Collapsed;
        if (res)
        {
            check = false;
            EnterNewPassword enterNewPassword = new EnterNewPassword();
            enterNewPassword.PhoneNumber = dto.PhoneNumber;
            ForgotPasswordWindow window = GetWindow();
            window.PageNavigator.Content = enterNewPassword;
        }
        else if (count == 5)
        {
            EnterPhoneNumber enterPhoneNumber = new EnterPhoneNumber();
            ForgotPasswordWindow window = GetWindow();
            window.PageNavigator.Content = enterPhoneNumber;
        }
        else
        {
            lblUrinishlarSoni.Content = (5 - count).ToString();
            lblError.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Red"));
            timer.Start();
        }
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        if (isRed)
        {
            lblError.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
        }
        else
        {
            lblError.Foreground = originalBrush;
        }

        isRed = !isRed;
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

    CancellationTokenSource cts;
    public bool check = true;

    public async Task Metod()
    {
        int countt = count;
        for (int i = 60 - 1; i >= 0; i--)
        {
            try
            {
                await Task.Delay(1000, cts.Token);
                lblSecond.Content = i.ToString();
                if (countt == 5)
                {
                    check = false;
                    await Task.Delay(500);
                    try
                    {
                        EnterPhoneNumber enterPhoneNumber = new EnterPhoneNumber();
                        ForgotPasswordWindow window = GetWindow();
                        window.PageNavigator.Content = enterPhoneNumber;
                        cts.Cancel();
                    }
                    catch (NullReferenceException)
                    {
                    }
                    
                }
            }
            catch (TaskCanceledException)
            {
                break;
            }
        }
        try
        {
            if (check)
            {
                EnterPhoneNumber enterPhoneNumber = new EnterPhoneNumber();
                ForgotPasswordWindow window = GetWindow();
                window.PageNavigator.Content = enterPhoneNumber;
                cts.Cancel();
            }
        }
        catch (NullReferenceException)
        {
        }
    }
    private async void Start()
    {
        cts = new CancellationTokenSource();
        Task task1 = Metod();
        await task1;
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        EnterPhoneNumber enterPhoneNumber = new EnterPhoneNumber();
        ForgotPasswordWindow forgotPasswordWindow = GetWindow();
        forgotPasswordWindow.PageNavigator.Content = enterPhoneNumber;
    }
}
