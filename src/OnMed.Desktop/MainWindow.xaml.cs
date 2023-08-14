using OnMed.Desktop.Component;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace OnMed.Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void btnMaximize_Click(object sender, RoutedEventArgs e)
    {
        if (this.WindowState == WindowState.Maximized)
            this.WindowState = WindowState.Normal;
        else this.WindowState = WindowState.Maximized;
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void borderDragable_MouseDown(object sender, MouseButtonEventArgs e)
    {
        this.DragMove();
    }

    private void borderDragabl_MouseDown(object sender, MouseButtonEventArgs e)
    {
        this.DragMove();
    }

    private void rbDashboard_Click(object sender, RoutedEventArgs e)
    {
        UserControlForDashboard userControlForDashboard = new UserControlForDashboard();
        wrpUsers.Children.Add(userControlForDashboard);
    }

    private void IsChecked(object sender, RoutedEventArgs e)
    {
        //if (chkbox.IsChecked == true)
        //{
        //    AppTheme.ChangeTheme(new Uri("Themes/DarkTheme.xaml", UriKind.Relative));
        //    ProfileImg.ImageSource = new BitmapImage(new Uri("C:\\Users\\99891\\Desktop\\profex-desktop\\src\\Profex-Desktop\\Assets\\Profile images\\default image.jpg", UriKind.Relative));

        //}
        //else
        //{
        //    AppTheme.ChangeTheme(new Uri("Themes/LightTheme.xaml", UriKind.Relative));
        //    ProfileImg.ImageSource = new BitmapImage(new Uri("C:\\Users\\99891\\Desktop\\profex-desktop\\src\\Profex-Desktop\\Assets\\Profile images\\default imageLight.jpg", UriKind.Relative));
        //}
    }
}
