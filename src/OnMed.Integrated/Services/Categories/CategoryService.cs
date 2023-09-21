using Newtonsoft.Json;
using OnMed.Integrated.Interfaces.Categories;
using OnMed.ViewModel.Categories;
using System.Text.Json.Serialization;

namespace OnMed.Integrated.Services;

public class CategoryService : ICategoryService
{
    private readonly string BASE_URL = "http://157.230.45.112:4040/api/";

    public async Task<List<CategoryViewModel>> GetAllAsync()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(BASE_URL + "common/categories?page=1&PerPage=50");
        var result = await client.GetAsync(client.BaseAddress);
        string response = await result.Content.ReadAsStringAsync(); 
        var category =  JsonConvert.DeserializeObject<List<CategoryViewModel>>(response);
        return category!;
    }
}
