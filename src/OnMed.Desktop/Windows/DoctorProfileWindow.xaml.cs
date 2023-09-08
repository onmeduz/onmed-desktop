using System.Runtime.InteropServices;
using System;
using System.Windows;
using static OnMed.Desktop.Windows.BlurWindow.BlurEffect;
using System.Windows.Interop;

namespace OnMed.Desktop.Windows;

/// <summary>
/// Interaction logic for DoctorProfileWindow.xaml
/// </summary>
public partial class DoctorProfileWindow : Window
{
    public DoctorProfileWindow()
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
}
