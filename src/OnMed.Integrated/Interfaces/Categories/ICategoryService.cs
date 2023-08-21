using OnMed.ViewModel.Categories;

namespace OnMed.Integrated.Interfaces.Categories;

public interface ICategoryService
{
    public Task<List<CategoryViewModel>> GetAllAsync();
}
