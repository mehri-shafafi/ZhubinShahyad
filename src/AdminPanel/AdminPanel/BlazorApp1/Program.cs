using BlazorApp1.Components;
using BlazorApp1.Services.Products;

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

builder.Services.AddHttpClient<ProductApiService>(c =>
{
    c.BaseAddress = new Uri("https://localhost:5001/"); // ???? ????? API
});
builder.Services.AddHttpClient<CategoryApiService>(c =>
{
    c.BaseAddress = new Uri("https://localhost:5001/");
});
builder.Services.AddHttpClient<BrandApiService>(c =>
{
    c.BaseAddress = new Uri("https://localhost:5001/");
});

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
