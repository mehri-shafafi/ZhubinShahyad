using GraphQL;
using Products.Presentation;
using static Products.Presentation.ServiceRegistery;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});



// Add services to the container.
builder.AddServiceRegistery();

builder.AddInfrastructureServices();
builder.AddApplicationServices();
builder.AddMessagingConfiguration();

//builder.Services.AddScoped<AppMutations>();
//builder.Services.AddScoped<AppQueries>();
//builder.Services.AddScoped<AppSchema>();
builder.WebHost.UseUrls("http://*:8083");

builder.Services.AddGraphQL(b => b.AddSystemTextJson());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// اضافه کردن CORS

var app = builder.Build();

app.UseCors("AllowAll");           // قبل از Authorization
app.UseAuthorization();            // قبل از MapControllers
app.MapControllers();              // بعد از Authorization

app.UseSwagger();                  // بعد از CORS و قبل از Run
app.UseSwaggerUI();
app.Run();