using OnMed.ViewModel.Categories;

namespace OnMed.Integrated.Interfaces.Categories;

public interface ICategoryService
{
    public Task<IList<CategoryViewModel>> GetAllAsync();
}
