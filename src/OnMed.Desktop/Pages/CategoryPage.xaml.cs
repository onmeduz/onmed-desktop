using OnMed.Desktop.Component;
using System.Windows;
using System.Windows.Controls;

namespace OnMed.Desktop.Pages;

/// <summary>
/// Interaction logic for CategoryPage.xaml
/// </summary>
public partial class CategoryPage : Page
{
    public CategoryPage()
    {
        InitializeComponent();
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < 20; i++)
        {
            CategoryComponent categoryComponent = new CategoryComponent();
            wrpCategory.Children.Add(categoryComponent);
        }
    }
}
