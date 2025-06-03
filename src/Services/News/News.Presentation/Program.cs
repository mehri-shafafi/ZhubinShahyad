using News.Presentation;
using static News.Presentation.ServiceRegistery;

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

// ✅ اضافه کردن Swagger
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// فعال کردن Swagger فقط در حالت توسعه
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// فعال‌سازی CORS
app.UseCors("AllowAll");

// اگر احراز هویت داری، این خط قبل از UseAuthorization باید بیاد
// app.UseAuthentication(); 

app.UseAuthorization();

// روت کردن کنترلرها
app.MapControllers();

app.Run();
