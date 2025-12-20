using BlazorApp.Components;
using BlazorApp.Services.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



builder.Services.AddHttpClient("ProductService", c =>
{
    c.BaseAddress = new Uri("http://89.32.250.205:10000/");
});

builder.Services.AddScoped(sp =>
    new ProductApiService(sp.GetRequiredService<IHttpClientFactory>()
        .CreateClient("ProductService")));

builder.Services.AddScoped(sp =>
    new CategoryApiService(sp.GetRequiredService<IHttpClientFactory>()
        .CreateClient("ProductService")));

builder.Services.AddScoped(sp =>
    new BrandApiService(sp.GetRequiredService<IHttpClientFactory>()
        .CreateClient("ProductService")));


app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
