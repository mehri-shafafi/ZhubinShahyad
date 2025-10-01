
using Gallery.Presentation;
using static Gallery.Presentation.ServiceRegistery;


var builder = WebApplication.CreateBuilder(args);


// اضافه کردن CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// سرویس‌ها
builder.AddServiceRegistery();
builder.AddInfrastructureServices();
builder.AddApplicationServices();
builder.AddMessagingConfiguration();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.WebHost.UseUrls("http://*:8084");
// اضافه کردن CORS

var app = builder.Build();

app.UseCors("AllowAll");           // قبل از Authorization
app.UseAuthorization();            // قبل از MapControllers
app.MapControllers();              // بعد از Authorization

app.UseSwagger();                  // بعد از CORS و قبل از Run
app.UseSwaggerUI();
app.Run();