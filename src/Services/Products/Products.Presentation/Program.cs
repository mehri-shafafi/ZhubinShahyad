using GraphQL.Server;
using GraphQL.SystemTextJson;
using Products.Infrastructure;
using Products.Infrastructure.CallSeeder;
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
//builder.Services.AddEndpointsApiExplorer();
///builder.Services.AddSwaggerGen();
// اضافه کردن CORS

var app = builder.Build();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{

    app.UseSwagger();
    app.UseSwaggerUI();
//}
//TODO برداشته بشه 

app.UseCors("AllowAll"); // این خیلی مهمه که قبل از UseAuthorization بیاد


app.UseGraphQL<AppSchema>();
//app.UseGraphQLGraphiQL("/ui/graphql");
app.UseAuthorization();

//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
//    await DbSeeder.SeedCategoryAsync(context); // این متد باید async باشه
//    //await DbSeeder.SeedAsync(context); // این متد باید async باشه
//}

app.MapControllers();
//app.MapGet("/", () => Results.Redirect("/ui/graphql"));

app.Run();