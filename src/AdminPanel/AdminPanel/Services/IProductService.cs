// Services/ProductService.cs
using AdminPanel.Models.Products.Models;

public interface IProductService
{
    Task<List<ProductModel>> GetAllAsync();
    Task<ProductModel?> GetByIdAsync(long id);
    Task AddAsync(ProductModel model);
    Task UpdateAsync(ProductModel model);
    Task DeleteAsync(long id);
}

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProductModel>> GetAllAsync()
        => await _httpClient.GetFromJsonAsync<List<ProductModel>>("api/Product") ?? new();

    public async Task<ProductModel?> GetByIdAsync(long id)
        => await _httpClient.GetFromJsonAsync<ProductModel>($"api/Product/{id}");

    public async Task AddAsync(ProductModel model)
        => await _httpClient.PostAsJsonAsync("api/Product", model);

    public async Task UpdateAsync(ProductModel model)
        => await _httpClient.PutAsJsonAsync($"api/Product/{model.Id}", model);

    public async Task DeleteAsync(long id)
        => await _httpClient.DeleteAsync($"api/Product/{id}");
}
