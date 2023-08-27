using System.Runtime.InteropServices;
using System;
using System.Windows;
using static OnMed.Desktop.Windows.BlurWindow.BlurEffect;
using System.Windows.Interop;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Media;
using OnMed.Desktop.Pages.ForgotPasswordPages;

namespace OnMed.Desktop.Windows;

/// <summary>
/// Interaction logic for ForgotPasswordWindow.xaml
/// </summary>
public partial class ForgotPasswordWindow : Window
{
    public ForgotPasswordWindow()
    {
        InitializeComponent();
    }

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
        EnterPhoneNumber enterPhoneNumber = new EnterPhoneNumber();
        PageNavigator.Content = enterPhoneNumber;
    }
    private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        this.DragMove();
    }
}
