using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Microsoft.Win32;

namespace OnMed.Desktop.Windows;

/// <summary>
/// Interaction logic for DoctorCreateWindow.xaml
/// </summary>
public partial class DoctorCreateWindow : Window
{
    string path = string.Empty;
    public DoctorCreateWindow()
    {
        InitializeComponent();
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void borderDragable_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        this.DragMove();
    }

    private void tbPhoneNumber_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
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

    private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        var openFileDialog = GetImgDialog();
        if (openFileDialog.ShowDialog() == true)
        {
            galary.Data = null;
            path = openFileDialog.FileName;
            ImageBrushDoctor.ImageSource = new BitmapImage(new Uri(path, UriKind.Relative));
        }
    }

    private OpenFileDialog GetImgDialog()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        return openFileDialog;
    }

    private void btnRasm_Click(object sender, RoutedEventArgs e)
    {

    }
}
