using Microsoft.Win32;
using OnMed.Dtos.Doctors;
using OnMed.Integrated.Interfaces.Categories;
using OnMed.Integrated.Interfaces.Doctors;
using OnMed.Integrated.Services;
using OnMed.Integrated.Services.Doctors;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OnMed.Desktop.Windows;

/// <summary>
/// Interaction logic for DoctorUpdateWindow.xaml
/// </summary>
public partial class DoctorUpdateWindow : Window
{
    private readonly ICategoryService _service;
    private readonly IDoctorService _doctorservice;

    public long DoctorId;
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
        else
            isMail = false;
    }

    List<int> WeekDays = new List<int>();

    Dictionary<string, long> Category = new Dictionary<string, long>();
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        DoctorUpdateDto dto = new DoctorUpdateDto();
        dto.FirstName = FirstName.Text;
        dto.LastName = LastName.Text;
        dto.MiddleName = MiddleName.Text;
        dto.PhoneNumber = (lbPhoneCode.Content.ToString() + tbPhoneNumber.Text);
        dto.Password = Password.Text;
        dto.Degree = Degree.Text;
        dto.Region = Region.Text;
        dto.BirthDay = DateOnly.FromDateTime(DateTime.Parse(tbBirthDay.SelectedDate.Value.ToString("dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)));
        dto.IsMale = isMail;
        dto.AppointmentMoney = double.Parse(tbMoney.Text);
        dto.Image = ImageBrushDoctor.ImageSource.ToString();

        bool response = await _doctorservice.UpdateAsync(DoctorId, dto);
        if (response)
        {
            MessageBox.Show("Ma'lumotlar o'gartirildi");
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

    private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
    {
        bordername.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#329DFF"));
    }

    private void Grid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
    {
        bordername.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));

    }

    private void Grid_MouseEnter_1(object sender, System.Windows.Input.MouseEventArgs e)
    {
        borderLastName.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#329DFF"));
    }

    private void Grid_MouseLeave_1(object sender, System.Windows.Input.MouseEventArgs e)
    {
        borderLastName.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
    }

    private void Grid_MouseEnter_2(object sender, System.Windows.Input.MouseEventArgs e)
    {
        borderMiddleName.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#329DFF"));
    }

    private void Grid_MouseLeave_2(object sender, System.Windows.Input.MouseEventArgs e)
    {
        borderMiddleName.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
    }

    private void Grid_MouseEnter_3(object sender, System.Windows.Input.MouseEventArgs e)
    {
        borderPassword.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#329DFF"));
    }

    private void Grid_MouseLeave_3(object sender, System.Windows.Input.MouseEventArgs e)
    {
        borderPassword.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
    }

    private void Grid_MouseEnter_4(object sender, System.Windows.Input.MouseEventArgs e)
    {
        borderRegion.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#329DFF"));
    }

    private void Grid_MouseLeave_4(object sender, System.Windows.Input.MouseEventArgs e)
    {
        borderRegion.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
    }

    private void Grid_MouseEnter_5(object sender, System.Windows.Input.MouseEventArgs e)
    {
        borderDegree.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#329DFF"));
    }

    private void Grid_MouseLeave_5(object sender, System.Windows.Input.MouseEventArgs e)
    {
        borderDegree.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
    }

    private void Grid_MouseEnter_6(object sender, System.Windows.Input.MouseEventArgs e)
    {
        borderStartime.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#329DFF"));
    }

    private void Grid_MouseLeave_6(object sender, System.Windows.Input.MouseEventArgs e)
    {
        borderStartime.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
    }

    private void Grid_MouseEnter_7(object sender, System.Windows.Input.MouseEventArgs e)
    {
        borderEndTime.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#329DFF"));
    }

    private void Grid_MouseLeave_7(object sender, System.Windows.Input.MouseEventArgs e)
    {
        borderEndTime.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
    }
}