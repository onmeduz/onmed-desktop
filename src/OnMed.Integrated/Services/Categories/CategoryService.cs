using Newtonsoft.Json;
using OnMed.Integrated.Interfaces.Categories;
using OnMed.ViewModel.Categories;
using System.Text.Json.Serialization;

namespace OnMed.Integrated.Services;

public class CategoryService : ICategoryService
{
    private readonly string BASE_URL = "http://coursezone.uz/api/";

    public async Task<List<CategoryViewModel>> GetAllAsync()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(BASE_URL + "common/categories");
        var result = await client.GetAsync(client.BaseAddress);
        string response = await result.Content.ReadAsStringAsync(); 
        var category =  JsonConvert.DeserializeObject<List<CategoryViewModel>>(response);
        return category!;
    }
}
