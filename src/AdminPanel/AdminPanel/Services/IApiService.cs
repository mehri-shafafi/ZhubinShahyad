using System.Net.Http.Json;

public interface IApiService<T>
{
    Task<List<T>> GetAllAsync(string endpoint);
    Task<T?> GetByIdAsync(string endpoint, long id);
    Task AddAsync(string endpoint, T model);
    Task UpdateAsync(string endpoint, long id, T model);
    Task DeleteAsync(string endpoint, long id);
}

public class ApiService<T> : IApiService<T>
{
    private readonly HttpClient _http;

    public ApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<T>> GetAllAsync(string endpoint)
        => await _http.GetFromJsonAsync<List<T>>(endpoint) ?? new List<T>();

    public async Task<T?> GetByIdAsync(string endpoint, long id)
        => await _http.GetFromJsonAsync<T>($"{endpoint}/{id}");

    public async Task AddAsync(string endpoint, T model)
        => await _http.PostAsJsonAsync(endpoint, model);

    public async Task UpdateAsync(string endpoint, long id, T model)
        => await _http.PutAsJsonAsync($"{endpoint}/{id}", model);

    public async Task DeleteAsync(string endpoint, long id)
        => await _http.DeleteAsync($"{endpoint}/{id}");
}
