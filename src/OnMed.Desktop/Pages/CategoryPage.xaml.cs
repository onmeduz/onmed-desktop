using OnMed.Desktop.Component;
using OnMed.Integrated.Interfaces.Categories;
using OnMed.Integrated.Services;
using System.Windows;
using System.Windows.Controls;

namespace OnMed.Desktop.Pages;

/// <summary>
/// Interaction logic for CategoryPage.xaml
/// </summary>
public partial class CategoryPage : Page
{
    private readonly ICategoryService _service;

    public CategoryPage()
    {
        InitializeComponent();
        this._service = new CategoryService();
    }

    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        var category = await _service.GetAllAsync();
        loader.Visibility = Visibility.Collapsed;
        scrolViver.Visibility = Visibility.Visible;
        foreach (var item in category)
        {
            CategoryComponent categoryComponent = new CategoryComponent();
            categoryComponent.SetData(item);
            wrpCategory.Children.Add(categoryComponent);
        }
    }
}
