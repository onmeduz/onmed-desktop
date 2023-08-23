using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Microsoft.Win32;
using OnMed.Dtos.Doctors;
using System.Runtime.Intrinsics.Arm;
using System.IO;
using OnMed.Desktop.Constans;
using OnMed.Desktop.Halpers;
using System.Collections.Generic;

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

    private void Border_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
    {
        Phoneborder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#329DFF"));
    }

    private void Border_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
    {
        Phoneborder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
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

    private void MoneyBorder_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
    {
        MoneyBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#329DFF"));
    }

    private void MoneyBorder_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
    {
        MoneyBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
    }

    public bool isMail;
    private void rbErkak_Click(object sender, RoutedEventArgs e)
    {
        RadioButton radioButton = (RadioButton)sender;
        string? btnName = radioButton.Content.ToString();
        if (btnName == "Erkak")
            isMail = true;
        isMail = false;
    }
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
         string imagepath = ImageBrushDoctor.ImageSource.ToString();

         if (!Directory.Exists(ContentConstans.IMAGE_CONTENTS_PATH))
             Directory.CreateDirectory(ContentConstans.IMAGE_CONTENTS_PATH);


         var imageName = ImageNameMarker.GetImageName(imagepath);

         path = System.IO.Path.Combine(ContentConstans.IMAGE_CONTENTS_PATH, imageName);

         byte[] image = await File.ReadAllBytesAsync(imagepath);

        DoctorCreateDto doctorCreateDto = new DoctorCreateDto()
        {
            FirstName = tbFirstName.Text,
            LastName = tbLastName.Text,
            MiddleName = tbMiddleName.Text,
            PhoneNumber = tbPhoneNumber.Text,
            Password = tbPassword.Text,
            Degree = tbDegree.Text,
            Region = tbRegion.Text,
            StartTime = TimeOnly.Parse(tbStartTime.Text),
            EndTime = TimeOnly.Parse(tbEndTime.Text),
            BirthDay = DateOnly.Parse(tbBirthDay.Text),
            IsMale = isMail,
            AppointmentMoney = double.Parse(tbMoney.Text),
            Image = image
        };
        
    }

    List<string> lstWeekDays = new List<string>();
    private void Dushanba_Click(object sender, RoutedEventArgs e)
    {
        CheckBox checkBox = new CheckBox();
        if(checkBox.IsChecked == true)
        {
            lstWeekDays.Add(checkBox.Content.ToString());
        }
    }
}
