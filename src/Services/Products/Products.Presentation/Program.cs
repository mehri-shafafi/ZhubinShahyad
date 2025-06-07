using GraphQL.Server;
using Products.Presentation;
using Products.Presentation.GQL;
using Products.Presentation.GQL.Mutations;
using Products.Presentation.GQL.Queries;
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

builder.Services.AddScoped<AppMutations>();
builder.Services.AddScoped<AppQueries>();
builder.Services.AddScoped<AppSchema>();

builder.Services.AddGraphQL().AddSystemTextJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// اضافه کردن CORS

var app = builder.Build();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{

    app.UseSwagger();
    app.UseSwaggerUI();
app.UseCors("AllowAll");           // قبل از Authorization
app.UseAuthorization();            // قبل از MapControllers
app.MapControllers();              // بعد از Authorization

app.UseSwagger();                  // بعد از CORS و قبل از Run
app.UseSwaggerUI();
app.Run();