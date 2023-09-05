using OnMed.ViewModel.Categories;
using OnMed.ViewModel.Doctors;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace OnMed.Desktop.Component;

/// <summary>
/// Interaction logic for CategoryComponent.xaml
/// </summary>
public partial class CategoryComponent : UserControl
{
    public const string BASE_URL = "https://localhost:7229/";
    public CategoryComponent()
    {
        InitializeComponent();
    }
    public void SetData(CategoryViewModel categoryViewModel)
    {
        string imageUrl = BASE_URL + categoryViewModel.ImagePath;
        Uri imageUri = new Uri(imageUrl, UriKind.Absolute);

        categoryImage.ImageSource = new BitmapImage(imageUri);
        categoryName.Content = categoryViewModel.Professionality;
        categoryDescription.Text = categoryViewModel.ProfessionalityHint;
    }
}
