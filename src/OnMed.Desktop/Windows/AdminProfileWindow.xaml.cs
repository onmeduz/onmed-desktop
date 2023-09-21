using OnMed.Integrated.Security;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static OnMed.Desktop.Windows.BlurWindow.BlurEffect;

namespace OnMed.Desktop.Windows;

/// <summary>
/// Interaction logic for AdminProfileWindow.xaml
/// </summary>
public partial class AdminProfileWindow : Window
{
    public const string BASE_URL = "https://localhost:7229/";

    public AdminProfileWindow()
    {
        InitializeComponent();
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    //////////////////////////////////////////////////////////////////

    [DllImport("user32.dll")]
    internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);
    internal void EnableBlur()
    {
        var windowHelper = new WindowInteropHelper(this);

        var accent = new AccentPolicy();
        accent.AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND;

        var accentStructSize = Marshal.SizeOf(accent);

        var accentPtr = Marshal.AllocHGlobal(accentStructSize);
        Marshal.StructureToPtr(accent, accentPtr, false);

        var data = new WindowCompositionAttributeData();
        data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
        data.SizeOfData = accentStructSize;
        data.Data = accentPtr;

        SetWindowCompositionAttribute(windowHelper.Handle, ref data);

        Marshal.FreeHGlobal(accentPtr);
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        EnableBlur();
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        AdminUpdateWindow adminUpdateWindow = new AdminUpdateWindow();

        string imageUrl = BASE_URL + IdentitySingelton.GetInstance().ImagePath;
        Uri imageUri = new Uri(imageUrl, UriKind.Absolute);
        adminUpdateWindow.adminProfileImage.ImageSource = new BitmapImage(imageUri);
        adminUpdateWindow.tbFirstName.Text = IdentitySingelton.GetInstance().Name;
        adminUpdateWindow.tbLastName.Text = IdentitySingelton.GetInstance().FirstName;
        adminUpdateWindow.tbMiddleName.Text = IdentitySingelton.GetInstance().MiddleName;
        adminUpdateWindow.tbRegion.Text = IdentitySingelton.GetInstance().Region;

        adminUpdateWindow.ShowDialog();
        this.Close();
    }

    private void Border_MouseEnter(object sender, MouseEventArgs e)
    {
        AdminBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C80707"));
    }

    private void Border_MouseLeave(object sender, MouseEventArgs e)
    {
        AdminBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#78B0E7"));
    }
}
