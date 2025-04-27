using UnitOfWork_Studying.Context.UnitOfWork;
using UnitOfWork_Studying.Context;
using UnitOfWork_Studying.Interfaces;
using UnitOfWork_Studying.Repositories;
using UnitOfWork_Studying.Services;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Util;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(10), null))
);


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
