using BlazorApp.Dtos.Products.Categories;

public class CategoryApiService
{
    private readonly HttpClient _http;

    public CategoryApiService(HttpClient http)
    {
        _http = http;
    }

    public Task<List<ProductCategoryDto>> GetAllAsync()
        => _http.GetFromJsonAsync<List<ProductCategoryDto>>(
            "api/GetListCateguriesProduct");
}
