using BlazorApp.Dtos.Products.Brands;

namespace BlazorApp.Services.Products
{
    public class BrandApiService
    {
        private readonly HttpClient _http;

        public BrandApiService(HttpClient http)
        {
            _http = http;
        }

        public Task<List<ProductBrandDto>> GetAllAsync()
            => _http.GetFromJsonAsync<List<ProductBrandDto>>("api/brands");
    }
}
