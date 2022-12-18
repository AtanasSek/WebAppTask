using WebAppTask.Context;
using WebAppTask.Interfaces;
using WebAppTask.Repository;

var builder = WebApplication.CreateBuilder(args);


//Active endpoints, localhost/AllProducts ;  localhost/AllCategories

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();



// Pregenerated, swagger not needed
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
