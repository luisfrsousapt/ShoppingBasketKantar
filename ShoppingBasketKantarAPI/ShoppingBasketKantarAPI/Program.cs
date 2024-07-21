using Microsoft.EntityFrameworkCore;
using ShoppingBasketKantarAPI.Data;
using ShoppingBasketKantarAPI.Data.Repositories;
using ShoppingBasketKantarAPI.Data.Repositories.Interfaces;
using ShoppingBasketKantarAPI.Mapper;
using ShoppingBasketKantarAPI.Services;
using ShoppingBasketKantarAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

//AUTOMAPPER
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//REPOSITORIES
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IDiscountRepository,DiscountRepository>();

//SERVICES
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IDiscountService,DiscountService>();


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
