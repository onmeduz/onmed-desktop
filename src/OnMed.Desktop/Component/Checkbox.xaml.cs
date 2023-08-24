using OnMed.ViewModel.Categories;
using System.Windows.Controls;

namespace OnMed.Desktop.Component;

/// <summary>
/// Interaction logic for Checkbox.xaml
/// </summary>
public partial class Checkbox : UserControl
{
    public Checkbox()
    {
        InitializeComponent();
    }

    public void SetData(CategoryViewModel category)
    {
        checkboxName.Content = category.Professionality;
    }
}
