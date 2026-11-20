using BlazorApp.Components;
using BlazorApp.Services.Products;

var builder = WebApplication.CreateBuilder(args);

// -------------------- Services --------------------
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient("ProductService", c =>
{
    c.BaseAddress = new Uri("http://89.42.208.27:10000/");
});

builder.Services.AddScoped<ProductApiService>(sp =>
    new ProductApiService(
        sp.GetRequiredService<IHttpClientFactory>()
          .CreateClient("ProductService")));

builder.Services.AddScoped<CategoryApiService>(sp =>
    new CategoryApiService(
        sp.GetRequiredService<IHttpClientFactory>()
          .CreateClient("ProductService")));

builder.Services.AddScoped<BrandApiService>(sp =>
    new BrandApiService(
        sp.GetRequiredService<IHttpClientFactory>()
          .CreateClient("ProductService")));

// -------------------- Build --------------------
var app = builder.Build();

// -------------------- Middleware --------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
