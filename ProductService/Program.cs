using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Services;

var builder = WebApplication.CreateBuilder(args);

// C?u h�nh DbContext v?i SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ??ng k� ProductService cho DI (Dependency Injection)
builder.Services.AddScoped<IProductService, ProductService.Services.ProductService>();

// C?u h�nh c�c d?ch v? kh�c
builder.Services.AddControllers();

// Th�m Swagger n?u c?n thi?t
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// C?u h�nh middleware
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
