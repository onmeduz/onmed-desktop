using OnMed.ViewModel.Categories;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace OnMed.Desktop.Component;

/// <summary>
/// Interaction logic for CategoryComponent.xaml
/// </summary>
public partial class CategoryComponent : UserControl
{
    public CategoryComponent()
    {
        InitializeComponent();
    }
    public void SetData(CategoryViewModel categoryViewModel)
    {
        categoryImage.ImageSource = new BitmapImage(new System.Uri(categoryViewModel.ImagePath, UriKind.Relative));
        categoryName.Content = categoryViewModel.Professionality;
        categoryDescription.Text = categoryViewModel.ProfessionalityHint;
    }
}
