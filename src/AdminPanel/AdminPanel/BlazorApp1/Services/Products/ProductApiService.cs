using BlazorApp.Dtos.Products;

public class ProductApiService
{
    private readonly HttpClient _http;

    public ProductApiService(HttpClient http)
    {
        _http = http;
    }

    public Task<List<ProductDto>> GetAllAsync()
    {
        return _http.GetFromJsonAsync<List<ProductDto>>("api/GetListProduct");
    }

    public Task<ProductDto> GetByIdAsync(int id)
    {
        return _http.GetFromJsonAsync<ProductDto>($"api/products/{id}");

    }

    public async Task<ProductResDto?> CreateAsync(ProductReqDto dto)
    {
        var response = await _http.PostAsJsonAsync("api/AddedProduct", dto);

        return await response.Content.ReadFromJsonAsync<ProductResDto>();
    }
    public async Task<ProductResDto?> UpdateAsync(int id, ProductReqDto dto)
    {
        var response = await _http.PutAsJsonAsync($"api/products/{id}", dto);

        return await response.Content.ReadFromJsonAsync<ProductResDto>();
    }

    public Task DeleteAsync(int id)
    {
        return _http.DeleteAsync($"api/products/{id}");
    }
}
