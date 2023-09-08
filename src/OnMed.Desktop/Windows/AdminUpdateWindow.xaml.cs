using Microsoft.Win32;
using OnMed.Dtos.Admin;
using OnMed.Integrated.Interfaces.Admin;
using OnMed.Integrated.Security;
using OnMed.Integrated.Services.Admin;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using static OnMed.Desktop.Windows.BlurWindow.BlurEffect;

namespace OnMed.Desktop.Windows;

/// <summary>
/// Interaction logic for AdminUpdateWindow.xaml
/// </summary>
public partial class AdminUpdateWindow : Window
{
    private readonly IAdminProfileService _profileService;

    string path = string.Empty;
    public AdminUpdateWindow()
    {
        InitializeComponent();
        this._profileService = new AdminService();
    }

    private OpenFileDialog GetImgDialog()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        return openFileDialog;
    }


    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
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

    private void editbtn_Click(object sender, RoutedEventArgs e)
    {
        var openFileDialog = GetImgDialog();
        if (openFileDialog.ShowDialog() == true)
        {
            path = openFileDialog.FileName;
            adminProfileImage.ImageSource = new BitmapImage(new Uri(path, UriKind.Relative));
        }
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private async void btnManege_Click(object sender, RoutedEventArgs e)
    {
        UploadImageDto uploadImageDto = new UploadImageDto();
        AdminUpdateDto adminUpdateDto = new AdminUpdateDto();

        uploadImageDto.Image = adminProfileImage.ImageSource.ToString();
        var res = await _profileService.UploadImageAsync(uploadImageDto);

        adminUpdateDto.FirstName = tbFirstName.Text;
        adminUpdateDto.LastName = tbLastName.Text;
        adminUpdateDto.MiddleName = tbMiddleName.Text;
        adminUpdateDto.Region = tbRegion.Text;

        long Id = IdentitySingelton.GetInstance().AdminId;
        var response = await _profileService.UpdateAsync(Id, adminUpdateDto);

        if (res == true && response == true)
        {
            this.Close();
        }
    }
}
