using Microsoft.Win32;
using OnMed.Desktop.Halpers;
using OnMed.Dtos.Doctors;
using OnMed.Integrated.Interfaces.Categories;
using OnMed.Integrated.Interfaces.Doctors;
using OnMed.Integrated.Services.Doctors;
using OnMed.Integrated.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace OnMed.Desktop.Windows;

/// <summary>
/// Interaction logic for DoctorUpdateWindow.xaml
/// </summary>
public partial class DoctorUpdateWindow : Window
{
    private readonly ICategoryService _service;
    private readonly IDoctorService _doctorservice;

    string path = string.Empty;
    public DoctorUpdateWindow()
    {
        InitializeComponent();
        this._service = new CategoryService();
        this._doctorservice = new DoctorService();
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
    private async void rbErkak_Click(object sender, RoutedEventArgs e)
    {
        RadioButton radioButton = (RadioButton)sender;
        string? btnName = radioButton.Content.ToString();
        if (btnName == "Erkak")
            isMail = true;
        isMail = false;
    }

    List<int> WeekDays = new List<int>();

    Dictionary<string, long> Category = new Dictionary<string, long>();
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        DoctorCreateDto doctorCreateDto = new DoctorCreateDto();

        doctorCreateDto.FirstName = tbFirstName.Text;
        doctorCreateDto.LastName = tbLastName.Text;
        doctorCreateDto.MiddleName = tbMiddleName.Text;
        doctorCreateDto.PhoneNumber = (lbPhoneCode.Content.ToString() + tbPhoneNumber.Text);
        doctorCreateDto.Password = tbPassword.Text;
        doctorCreateDto.Degree = tbDegree.Text;
        doctorCreateDto.Region = tbRegion.Text;
        doctorCreateDto.StartTime = tbStartTime.Text;
        doctorCreateDto.EndTime = tbEndTime.Text;
        doctorCreateDto.BirthDay = DateOnly.FromDateTime(DateTime.Parse(tbBirthDay.SelectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture)));
        doctorCreateDto.IsMale = isMail;
        doctorCreateDto.AppointmentMoney = double.Parse(tbMoney.Text);
        WeekDays.Clear();
        if (D.IsChecked == true)
            WeekDays.Add(1);
        if (S.IsChecked == true)
            WeekDays.Add(2);
        if (CH.IsChecked == true)
            WeekDays.Add(3);
        if (P.IsChecked == true)
            WeekDays.Add(4);
        if (J.IsChecked == true)
            WeekDays.Add(5);
        if (Sh.IsChecked == true)
            WeekDays.Add(6);
        if (Y.IsChecked == true)
            WeekDays.Add(7);


        List<long> categories = new List<long>();

        string str = cbCategory.Text;

        foreach (var item in Category)
        {
            if (item.Key == str)
            {
                categories.Add(item.Value);
            }
        }
        string imagepath = ImageBrushDoctor.ImageSource.ToString();
        var imageName = ImageNameMarker.GetImageName(imagepath);
        byte[] image = await File.ReadAllBytesAsync(imagepath);

        doctorCreateDto.Image = image;
        doctorCreateDto.WeekDay = WeekDays;
        doctorCreateDto.CategoryIds = categories;
        doctorCreateDto.HospitalBranchId = 4;

        bool response = await _doctorservice.CreateAsync(doctorCreateDto);
        if (response)
        {
            MessageBox.Show("Ma'lumotlar saqlandi");
            this.Close();
        }
        else
            MessageBox.Show("Ma'lumotlar saqlanmadi. Tekshirib qayta urinib ko'ring");
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var categories = await _service.GetAllAsync();
        foreach (var category in categories)
        {
            ComboBoxItem item = new ComboBoxItem();
            item.Content = category.Professionality.ToString();
            cbCategory.Items.Add(item);
            Category.Add(category.Professionality, category.Id);
        }
    }
}